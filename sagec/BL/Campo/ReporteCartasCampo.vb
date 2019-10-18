Public Class ReporteCartasCampo
    Dim BLCobranza As New BL.Cobranza
    Dim mensaje As String = ""

    Function ReporteCartaCampoCastigo(ByVal CriterioCartera As String, ByVal CriterioGestor As String, ByVal CriterioFechaInicio As String, ByVal CriterioFechaFin As String)
        Dim criterioTodos As String = " IDCARTACAMPO>0 "
        Dim criterio As String = ""
        Dim dt As New DataTable
        criterio = criterioTodos & CriterioCartera & CriterioGestor & CriterioFechaInicio & CriterioFechaFin
        Try
            dt = BLCobranza.FunctionGlobal(":criterio▓" & criterio, "QRYCC001")
            Return dt
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Function ReporteCartaCampoCastigoBatch(ByVal CriterioCartera As String, ByVal CriterioGestor As String, ByVal CriterioFechaInicio As String, ByVal CriterioFechaFin As String, ByVal nombreusuario As String)
        Dim criterioTodos As String = " IDCARTACAMPO>0 "
        Dim criterio As String = ""
        criterio = criterioTodos & CriterioCartera & CriterioGestor & CriterioFechaInicio & CriterioFechaFin
        Try
            BLCobranza.ReporteBatch("SI", "QRYCC001", ":criterio♦" & criterio, "REPORTE DE CARTAS A CAMPO - CASTIGO", nombreusuario)
        Catch ex As Exception
            Return Nothing
        End Try
        Return Nothing
    End Function

    Function ReporteCartaCampoActiva(ByVal CriterioCartera As String, ByVal CriterioGestor As String, ByVal CriterioFechaInicio As String, ByVal CriterioFechaFin As String)
        Dim criterioTodos As String = " IDCARTACAMPO>0 "
        Dim criterio As String = ""
        Dim dt As New DataTable
        criterio = criterioTodos & CriterioCartera & CriterioGestor & CriterioFechaInicio & CriterioFechaFin
        Try
            dt = BLCobranza.FunctionGlobal(":criterio▓" & criterio, "QRYCC002")
            Return dt
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Function ReporteCartaCampoActivaBatch(ByVal CriterioCartera As String, ByVal CriterioGestor As String, ByVal CriterioFechaInicio As String, ByVal CriterioFechaFin As String, ByVal nombreusuario As String)
        Dim criterioTodos As String = " IDCARTACAMPO>0 "
        Dim criterio As String = ""
        criterio = criterioTodos & CriterioCartera & CriterioGestor & CriterioFechaInicio & CriterioFechaFin
        Try
            BLCobranza.ReporteBatch("SI", "QRYCC002", ":criterio♦" & criterio, "REPORTE CARTAS A CAMPO - ACTIVA", nombreusuario)
        Catch ex As Exception
            Return Nothing
        End Try
        Return Nothing
    End Function

    Function EliminarCartaCampoCastigo(ByVal idCarta As String)
        Try
            BLCobranza.FunctionGlobal(":idcartacampo▓" & idCarta, "QRYCC003")
        Catch ex As Exception
            Return False
            mensaje = ex.Message
        End Try
        Return True
    End Function

    Function EliminarCartaClienteCastigo(ByVal idCliente As String)
        Try
            BLCobranza.FunctionGlobal(":idcliente▓" & idCliente, "QRYCC004")
        Catch ex As Exception
            Return False
            mensaje = ex.Message
        End Try
        Return True
    End Function

    Function EliminarCartaCampoActiva(ByVal idCarta As String)
        Try
            BLCobranza.FunctionGlobal(":idcartacampo▓" & idCarta, "QRYCC005")
        Catch ex As Exception
            Return False
            mensaje = ex.Message
        End Try
        Return True
    End Function

    Function EliminarCartaClienteActiva(ByVal idCliente As String)
        Try
            BLCobranza.FunctionGlobal(":idcliente▓" & idCliente, "QRYCC006")
        Catch ex As Exception
            Return False
            mensaje = ex.Message
        End Try
        Return True
    End Function
End Class
