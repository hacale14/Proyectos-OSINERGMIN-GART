
Public Class Pagos : Inherits BE.Pagos    
    Dim Cobranza As New BL.Cobranza
    Dim Mensaje As String
    Private Function Buscar() As DataTable
        Dim Dt As New DataTable
        Try
            Criterio = CriterioTodos + CriterioDNI + CriterioCliente + CriterioFechaInicio + CriterioFechaFin + CriterioCartera
            Dt = Cobranza.FunctionGlobal(":criterio▓" & Criterio, "QRYCP001")
        Catch ex As Exception
            Mensaje = ex.Message
            Return Nothing
        End Try
        Return Dt
    End Function
    Public Function Elimina() As Boolean
        Try
            Cobranza.FunctionGlobal(":idpago▓" & idPago, "QRYCP009")
        Catch ex As Exception
            Return False
        End Try
    End Function


    Public Function CriteriosBusqueda(ByVal Text_DNI As String, ByVal Text_Cliente As String, ByVal Fecha_Inicio As String, ByVal Fecha_Fin As String, ByVal Text_Cartera As String, ByVal chkInicio As Boolean, ByVal chkFin As Boolean)
        Dim Dt As New DataTable
        Try
            CriterioTodos = "IDPAGO >0"
            If Len(Trim(Text_DNI)) > 0 Then : CriterioDNI = " AND Cliente.DNI LIKE '" + Text_DNI + "%'" : Else : CriterioDNI = "" : End If
            If Len(Trim(Text_Cliente)) > 0 Then : CriterioCliente = " AND Cliente.NOMBRECLIENTE LIKE '" + Text_Cliente + "%'" : Else : CriterioCliente = "" : End If
            If Len(Trim(Fecha_Inicio)) > 0 And chkInicio = True Then
                Dim FechaI As DateTime = Fecha_Inicio
                CriterioFechaInicio = " AND year(FechaPago) >=CONVERT(DATETIME,'" + Format(FechaI, "yyyy/MM/dd") + "',102)" : Else : CriterioFechaInicio = "" : End If
            If Len(Trim(Fecha_Fin)) > 0 And chkFin = True Then
                Dim FechaF As DateTime = Fecha_Fin
                CriterioFechaFin = " AND FechaPago<=CONVERT(DATETIME,'" + Format(FechaF, "yyyy/MM/dd") + "',102)" : Else : CriterioFechaFin = "" : End If
            If Len(Trim(Text_Cartera)) > 0 Then : CriterioCartera = " AND Cartera.NOMCARTERA LIKE '" + Text_Cartera + "%'" : Else : CriterioCartera = "" : End If
            Dt = Buscar()
        Catch ex As Exception
            Mensaje = ex.Message
            Return Nothing
        End Try
        Return Dt
    End Function

    Function ReportePagos(ByVal CriterioCartera As String, ByVal CriterioGestor As String, ByVal CriterioFechaInicio As String, ByVal CriterioFechaFin As String, ByVal CriterioMoneda As String, ByVal CriterioConcepto As String)
        Dim dt As New DataTable
        Dim CriterioTodos As String = "IDPAGO>0 AND CLIENTE.ESTADO<>'E'"
        Dim Criterio As String = ""
        Criterio = CriterioTodos & CriterioCartera & CriterioGestor & CriterioFechaInicio & CriterioFechaFin & CriterioConcepto & CriterioMoneda
        Try
            dt = Cobranza.FunctionGlobal(":criterio▓" & Criterio, "QRYRP001")
        Catch ex As Exception
            Return Nothing
        End Try
        Return dt
    End Function

    Function ReportePagosBatch(ByVal CriterioCartera As String, ByVal CriterioGestor As String, ByVal CriterioFechaInicio As String, ByVal CriterioFechaFin As String, ByVal CriterioMoneda As String, ByVal CriterioConcepto As String, ByVal usuario As String)
        Dim CriterioTodos As String = "IDPAGO>0 AND CLIENTE.ESTADO<>'E'"
        Dim Criterio As String = ""
        Criterio = CriterioTodos & CriterioCartera & CriterioGestor & CriterioFechaInicio & CriterioFechaFin & CriterioConcepto & CriterioMoneda
        Try
            Cobranza.ReporteBatch("SI", "QRYRP001", ":criterio♦" & Criterio, "REPORTE DE PAGOS - CASTIGO", usuario)
        Catch ex As Exception
            Return Nothing
        End Try
        Return Nothing
    End Function

    Function ReportePagosActiva(ByVal CriterioCartera As String, ByVal CriterioGestor As String, ByVal CriterioFechaInicio As String, ByVal CriterioFechaFin As String, ByVal CriterioMoneda As String, ByVal CriterioConcepto As String)
        Dim dt As New DataTable
        Dim CriterioTodos As String = "IDPAGO>0 AND CLIENTE.ESTADO<>'E'"
        Dim Criterio As String = ""
        Criterio = CriterioTodos & CriterioCartera & CriterioGestor & CriterioFechaInicio & CriterioFechaFin & CriterioConcepto & CriterioMoneda
        Try
            dt = Cobranza.FunctionGlobal(":criterio▓" & Criterio, "QRYRP003")
        Catch ex As Exception
            Return Nothing
        End Try
        Return dt
    End Function

    Function ReportePagosActivaBatch(ByVal CriterioCartera As String, ByVal CriterioGestor As String, ByVal CriterioFechaInicio As String, ByVal CriterioFechaFin As String, ByVal CriterioMoneda As String, ByVal CriterioConcepto As String, ByVal usuario As String)
        Dim CriterioTodos As String = "IDPAGO>0 AND CLIENTE.ESTADO<>'E'"
        Dim Criterio As String = ""
        Criterio = CriterioTodos & CriterioCartera & CriterioGestor & CriterioFechaInicio & CriterioFechaFin & CriterioConcepto & CriterioMoneda
        Try
            Cobranza.ReporteBatch("SI", "QRYRP003", ":criterio♦" & Criterio, "REPORTE DE PAGOS - ACTIVA", usuario)
        Catch ex As Exception
            Return Nothing
        End Try
        Return Nothing
    End Function
End Class
