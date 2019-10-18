Public Class ReporteComposicion
    Dim BLCobranza As New BL.Cobranza

    Function ReporteComposicionCartera(ByVal criterioCartera As String, ByRef NumeroCLientes As Integer) As DataTable
        Dim dt As New DataTable
        Dim dt2 As New DataTable

        Dim criteriotodos As String = "CARTERA.IDCARTERA>0"
        Dim criterio As String = criteriotodos & criterioCartera
        Try
            dt = BLCobranza.FunctionGlobal(":criterio▓" & criterio, "QRYRCC001")
            If dt.Rows.Count <> 0 Then
                NumeroCLientes = dt.Rows(0)(2)
                dt2 = BLCobranza.FunctionGlobal(":numeroclientesporcarteraƒ:criterio▓" & dt.Rows(0)(2) & "ƒ" & criterio, "QRYRCC002")
            End If
            Return dt2
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Function ReporteComposicionCarteraGestor(ByVal fechainicio As String, ByVal fechafin As String, ByVal idusuario As String, ByVal idcartera As String, ByRef Numero As Integer, ByRef dt2 As DataTable)
        Dim dt As New DataTable
        Try
            dt = BLCobranza.FunctionGlobal(":fechainicioƒ:fechafinƒ:idcarteraƒ:idusuario▓" & fechainicio & "ƒ" & fechafin & "ƒ" & idcartera & "ƒ" & idusuario, "QRYRCC003")
            If dt.Rows.Count <> 0 Then
                dt2.Columns.Add("Cartera")
                dt2.Columns.Add("Gestor")
                dt2.Columns.Add("Nro Clientes")
                dt2.Columns.Add("Condicion")
                dt2.Columns.Add("Codigo")
                dt2.Columns.Add("Porcentaje")

                Numero = dt.Rows.Count

                For i = 0 To dt.Rows.Count - 1
                    If i = 0 Then
                        Dim fila As DataRow = dt2.NewRow
                        fila(0) = dt.Rows(i)(0)
                        fila(1) = dt.Rows(i)(1)
                        fila(2) = 1
                        fila(3) = dt.Rows(i)(2)
                        fila(4) = dt.Rows(i)(3)
                        fila(5) = 1 / Numero
                        dt2.Rows.Add(fila)
                    Else
                        For j = 0 To dt2.Rows.Count - 1
                            If dt.Rows(i)(3) = dt2.Rows(j)(4) Then
                                dt2.Rows(j)(2) = dt2.Rows(j)(2) + 1
                                dt2.Rows(j)(5) = dt2.Rows(j)(2) / Numero
                                Exit For
                            Else
                                If j = dt2.Rows.Count - 1 Then
                                    Dim fila As DataRow = dt2.NewRow
                                    fila(0) = dt.Rows(i)(0)
                                    fila(1) = dt.Rows(i)(1)
                                    fila(2) = 1
                                    fila(3) = dt.Rows(i)(2)
                                    fila(4) = dt.Rows(i)(3)
                                    fila(5) = 1 / Numero
                                    dt2.Rows.Add(fila)
                                End If
                            End If
                        Next
                    End If
                Next
            End If
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
End Class
