Imports BL
Imports System.IO
Imports System.Web

Public Class Reporte
    Dim BLCobranza As New BL.Cobranza
    Dim mensaje As String = ""
    Dim Datos As New BL.Cobranza

    Function ReporteCobertura(ByVal criterioCartera As String) As DataTable
        Dim CriterioTodos As String = "CARTERA.IDCARTERA>0"
        Dim criterio As String = ""
        Dim dt As New DataTable
        criterio = criterioCartera
        Try
            dt = BLCobranza.FunctionGlobal(":criterio▓" & CriterioTodos & criterio, "QRYRCG001")
        Catch ex As Exception
            Return Nothing
        End Try
        Return dt
    End Function

    Function ReporteCobertura2(ByVal criterioFechaInicio As String, ByVal criterioFechaFin As String, ByVal dt2 As DataTable, ByRef NombreCartera As String, ByRef ClientesTotales As Integer, ByRef ClientesAtendidos As Integer, ByRef ClientesNoAtendidos As Integer) As Boolean
        Dim dt As New DataTable
        Try
            dt = BLCobranza.FunctionGlobal(":fechainicioƒ:fechafinƒ:idcartera▓" & criterioFechaInicio & "ƒ" & criterioFechaFin & "ƒ" & dt2.Rows(0)(0), "QRYRCG002")
            NombreCartera = dt2.Rows(0)(1)
            ClientesTotales = dt2.Rows(0)(2)
            ClientesAtendidos = dt.Rows.Count
            ClientesNoAtendidos = ClientesTotales - ClientesAtendidos
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function


    Function ReporteCoberturaGestor(ByVal criterioCartera As String, ByVal criterioGestor As String) As DataTable
        Dim CriterioTodos As String = "CARTERA.IDCARTERA>0"
        Dim criterio As String = ""
        Dim dt As New DataTable
        criterio = criterioCartera & criterioGestor
        Try
            dt = BLCobranza.FunctionGlobal(":criterio▓" & CriterioTodos & criterio, "QRYRCG003")
        Catch ex As Exception
            Return Nothing
        End Try
        Return dt
    End Function

    Function ReporteCoberturaGestor2(ByVal criterioFechaInicio As String, ByVal criterioFechaFin As String, ByVal dt2 As DataTable, ByRef NombreCartera As String, ByRef CodGestor As String, ByRef ClientesAtendidos As Integer, ByRef ClientesTotales As Integer, ByRef CLientesNoAtendidos As Integer) As Boolean
        Dim dt As New DataTable
        Try
            dt = BLCobranza.FunctionGlobal(":fechainicioƒ:fechafinƒ:idcarteraƒ:idusuario▓" & criterioFechaInicio & "ƒ" & criterioFechaFin & "ƒ" & dt2.Rows(0)(0) & "ƒ" & dt2.Rows(0)(1), "QRYRCG004")
            NombreCartera = dt2.Rows(0)(2)
            CodGestor = dt2.Rows(0)(3)
            ClientesTotales = dt2.Rows(0)(6)
            ClientesAtendidos = dt.Rows.Count
            CLientesNoAtendidos = ClientesTotales - ClientesAtendidos
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Function ReporteCoberturaClientesAsignados(ByVal criterioTodos As String, ByVal criterioCartera As String, ByVal criterioGestor As String) As DataTable
        Dim dt As New DataTable
        Dim criterio As String = ""
        criterio = criterioTodos & criterioCartera & criterioGestor
        Try
            dt = BLCobranza.FunctionGlobal(":criterio▓" & criterio, "QRYRCCG001")
            Return dt
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Function ReporteCoberturaCarteraGestor(ByVal criterioTodos As String, ByVal criterioCartera As String, ByVal criterioGestor As String, ByVal fechaInicio As String, ByVal fechaFin As String) As DataTable        
        Try
            Dim dt = ReporteCoberturaClientesAsignados(criterioTodos, criterioCartera, criterioGestor)            
            Return dt
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Function ReporteClienteNoGestionado(ByVal criterioCarteraFecha As String, ByVal criterioCartera As String, ByVal criterioGestor As String, ByVal criterioFechaInicio As String, ByVal criterioFechaFin As String) As DataTable
        Dim dt As New DataTable
        Dim criterioEstado As String = " AND Cliente.Estado IN('A','N') "
        Dim criterioEstado_Fecha As String = " AND Cl.Estado IN('A','N') "
        Dim criterio As String = ""
        Dim criterioFecha As String = " AND (cl.fecha between '" & criterioFechaInicio & "' AND '" & criterioFechaFin & "'"
        criterio = criterioCartera & criterioGestor & criterioEstado
        criterioFecha = criterioCarteraFecha & criterioFechaInicio & criterioFechaFin & criterioEstado_Fecha
        dt = BLCobranza.FunctionGlobal(":pcriterioƒ:fcriterio▓" & criterio & "ƒ" & criterioFecha, "QRYRCCG005")
        Return dt
    End Function

    Function ReporteClienteNoGestionadoBatch(ByVal usuario As String, ByVal criterioCarteraFecha As String, ByVal criterioCartera As String, ByVal criterioGestor As String, ByVal criterioFechaInicio As String, ByVal criterioFechaFin As String) As Boolean
        Dim criterioEstado As String = " AND Cliente.Estado IN('A','N') "
        Dim criterioEstado_Fecha As String = " AND Cl.Estado IN('A','N') "
        Dim criterio As String = ""
        Dim criterioFecha As String = ""
        Dim arch As New StreamWriter(HttpContext.Current.Server.MapPath(".") & "/Files/CROWN_" & Format(Now, "yyyyMMddhhss") & ".lst", True)
        criterio = criterioCartera & criterioGestor & criterioEstado
        criterioFecha = criterioCarteraFecha & criterioFechaInicio & criterioFechaFin & criterioEstado_Fecha
        arch.WriteLine(Datos.usuario.ToString)
        arch.WriteLine(Datos.pwd.ToString)
        arch.WriteLine(Datos.bd.ToString)
        arch.WriteLine(Datos.servidor.ToString)
        arch.WriteLine("Consulta")
        arch.WriteLine("Consultas.exe")
        arch.WriteLine("SIƒQRYRCCG005ƒ:pcriterio☺:fcriterio♦" & criterio & "☺" & criterioFecha & "ƒ" & "REPORTE_CLIENTE_NO_GESTIONADO" & Format(Now, "yyyyMMddhhss"))
        arch.WriteLine(usuario)
        arch.WriteLine("Esporadico")
        arch.WriteLine("")
        arch.WriteLine("")
        arch.WriteLine("")
        arch.WriteLine("")
        arch.WriteLine("")
        arch.WriteLine("REPORTE CLIENTES NO GESTIONADOS")
        arch.WriteLine("REPORTE AGREGADO AUTOMATICAMENTE A LA COLA")
        arch.Close()
    End Function

End Class
