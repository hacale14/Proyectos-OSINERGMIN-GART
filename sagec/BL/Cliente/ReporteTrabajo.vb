Imports ConDB

Public Class ReporteTrabajo
    Dim Cobranza As New BL.Cobranza

    Function Reporte(ByVal criterio As String)
        Dim dt As New DataTable
        Try
            dt = Cobranza.FunctionGlobal(":criterio▓" & criterio, "QRYREC001")
        Catch ex As Exception
            dt = Nothing
        End Try
        Return dt
    End Function

End Class
