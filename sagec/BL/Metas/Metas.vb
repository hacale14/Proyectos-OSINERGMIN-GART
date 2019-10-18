
Public Class Metas : Inherits BE.Metas
    Dim cobranza As New BL.Cobranza
    Dim Mensaje As String

    Public Function GenerarReporte(ByVal TipoUsuarioActual As String, ByVal IdUsuarioActual As String, ByVal Text_Gestor As String, ByVal Value_Gestor As String, ByVal Text_FechaInicio As DateTime, ByVal Text_FechaFin As DateTime) As DataTable
        Dim tbMetasCobranzas As New DataTable
        tbMetasCobranzas = Crear_tblAvanceMetas()

        Try
            Dim Dt2 As New DataTable
            Dim Dt As New DataTable

            If TipoUsuarioActual = "ADMINISTRADOR" Then
                If Trim(Text_Gestor) = "" Then : Criterio_Gestor = "" : Else : Criterio_Gestor = " AND USUARIOCLIENTE.IDUSUARIO=" + CStr(Value_Gestor) : End If
            Else
                Criterio_Gestor = " AND USUARIOCLIENTE.IDUSUARIO=" + CStr(IdUsuarioActual)
            End If

            Dt = cobranza.FunctionGlobal("", "QRYTC001")
            If Dt.Rows.Count > 0 Then : Tipo_Cambio = CDbl(Dt(0)("TipoCambio")) : Else : Tipo_Cambio = 0 : End If
            Dt = Nothing

            Criterio_Todos = "USUARIOCLIENTE.IDUSUARIO>0"
            Criterio = Criterio_Todos + Criterio_Gestor

            Dt = cobranza.FunctionGlobal(":pcriterio▓" & Criterio, "QRYCM002")
            For Each dtr In Dt.Rows
                ID_Cartera = IIf(Not IsDBNull(dtr("IdCartera")), dtr("IdCartera"), "")
                ID_Usuario = IIf(Not IsDBNull(dtr("IdUsuario")), dtr("IdUsuario"), "")
                Moneda_Deuda = IIf(Not IsDBNull(dtr("Moneda")), dtr("Moneda"), "")
                Usuario = IIf(Not IsDBNull(dtr("Usuario")), dtr("Usuario"), "")
                Cartera = IIf(Not IsDBNull(dtr("NomCartera")), dtr("NomCartera"), "")
                Deuda_Total = IIf(Not IsDBNull(dtr("DEUDA_TOTAL")), dtr("DEUDA_TOTAL"), 0)

                If Moneda_Deuda = "S" Then
                    Meta = IIf(Not IsDBNull(dtr("Meta")), dtr("Meta"), 0)
                Else
                    Meta = 0
                End If

                Dt2 = cobranza.FunctionGlobal(":pfechainicioƒ:pfechafinƒ:pidusuarioƒ:pidcarteraƒ:pmonedadeuda▓" & Format(Text_FechaInicio, "yyyy/MM/dd") & "ƒ" & Format(Text_FechaFin, "yyyy/MM/dd") & "ƒ" & ID_Usuario & "ƒ" & ID_Cartera & "ƒ" & Moneda_Deuda, "QRYCM003")
                If Dt2.Rows.Count > 0 Then
                    TotalCobrado = IIf(Not IsDBNull(Dt2(0)("SumaMonto")), Dt2(0)("SumaMonto"), 0)
                Else
                    TotalCobrado = 0
                End If
                Porcentaje = (TotalCobrado / Deuda_Total) * 100

                'INSERT INTO TABLA AVANCE 
                Agregar_Datos(tbMetasCobranzas, Usuario, Cartera, Moneda_Deuda, Format(Deuda_Total, "0.00"), Format(TotalCobrado, "0.00"), Format(Porcentaje, "0.00") + " %", Meta)

            Next
            Dim Cobro As Double = 0

            If tbMetasCobranzas.Rows.Count > 0 Then
                For Each dtr In tbMetasCobranzas.Rows
                    If dtr("Moneda") = "S" Then
                        Cobro = CDbl(dtr("Pagos"))
                    Else
                        Cobro = CDbl(dtr("Pagos")) * CDbl(Tipo_Cambio)
                    End If
                    SumaCobro = SumaCobro + Cobro
                    SumaMeta = SumaMeta + CDbl(dtr("Meta"))
                Next
            End If
            

        Catch ex As Exception
            Mensaje = "Error..: " & ex.Message
            Return Nothing
        End Try
        Return tbMetasCobranzas
    End Function
    Private Function Crear_tblAvanceMetas() As DataTable
        Dim table As DataTable
        Try
            table = New DataTable("AvanceMetas")
            table.Columns.Add("Usuario", System.Type.GetType("System.String"))
            table.Columns.Add("NomCartera", System.Type.GetType("System.String"))
            table.Columns.Add("Moneda", System.Type.GetType("System.String"))
            table.Columns.Add("Deuda_Total", System.Type.GetType("System.String"))
            table.Columns.Add("Pagos", System.Type.GetType("System.String"))
            table.Columns.Add("Porcentaje", System.Type.GetType("System.String"))
            table.Columns.Add("Meta", System.Type.GetType("System.String"))
        Catch ex As Exception
            Mensaje = ex.Message
            Return Nothing
        End Try
        Return table
    End Function
    Private Function Agregar_Datos(ByVal tbMetas As DataTable, ByVal Usuario As String, ByVal NomCartera As String, ByVal Moneda As String, ByVal DeudaTotal As String, ByVal Pagos As String, ByVal Porcentaje As String, ByVal Meta As String) As DataTable
        Dim Dt As New DataTable
        Try

            Dt = DirectCast(tbMetas, DataTable)

            Dim row As DataRow = Dt.NewRow
            row(0) = Usuario
            row(1) = NomCartera
            row(2) = Moneda
            row(3) = DeudaTotal
            row(4) = Pagos
            row(5) = Porcentaje
            row(6) = Meta
            Dt.Rows.Add(row)

        Catch ex As Exception
            Mensaje = ex.Message
            Return Nothing
        End Try
        Return Dt
    End Function

End Class
