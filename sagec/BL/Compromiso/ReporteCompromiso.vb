Imports ConDB

Public Class ReporteCompromiso : Inherits BE.Compromiso
    Dim Cobranza As New BL.Cobranza
    Public grv As Object
    Public Function Carga_Grilla() As Integer
        Dim fnc = New Cobranza
        grv.SourceDataTable = fnc.FunctionGlobalRpte(":criterio▓" & Criterio, "QRYCOM001")
        Return grv.gv.rows.count
    End Function
    Function Reporte(ByVal criterio As String)
        Dim dt As New DataTable
        Try
            dt = Cobranza.FunctionGlobalRpte(":criterio▓" & criterio, "QRYCOM001")
        Catch ex As Exception
            dt = Nothing
        End Try
        Return dt
    End Function
    Function generarReporte(ByVal cartera As String, ByVal fechaInicio As String, ByVal fechaFin As String, ByRef dt As DataTable, ByRef dt2 As DataTable) As Boolean
        Try
            dt = Cobranza.FunctionGlobalRpte(":cartera▓" & cartera, "QRYRCH001")
            Dim anio As String = ""
            Dim mes As String = ""
            Dim arreglo As Array
            arreglo = fechaInicio.Split("/")
            anio = arreglo(2)
            mes = arreglo(1)
            dt2 = Cobranza.FunctionGlobalRpte(":carteraƒ:anioƒ:mes▓" & cartera & "ƒ" & anio & "ƒ" & mes, "QRYRCH002")
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    Function generarReportes(ByVal Ruta As String, ByVal FechaInicio As String, ByVal FechaFin As String)
        Dim dt As Boolean = False
        Try
            dt = Cobranza.FunctionEjecuta("execute xp_cmdshell  'D:\ProcesoDescargas\EjecutaReporte.bat saƒinnovaƒcobranza_desaƒservidorƒ" & Ruta & "ƒ" & FechaInicio & "ƒ" & FechaFin & "'")
            dt = True
        Catch ex As Exception
            Return dt
        End Try
        Return dt
    End Function
End Class
