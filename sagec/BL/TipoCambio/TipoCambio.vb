Imports ConDB
Public Class TipoCambio : Inherits BE.TipoCambio
    Dim Cobranza As New BL.Cobranza
    Dim dt As New DataTable

    Function BuscarTipoCambio()
        Try
            dt = Cobranza.FunctionGlobal(":idempresa▓" & IdEmpresa, "QRYTC001")
        Catch ex As Exception
            dt = Nothing
        End Try
        Return dt
    End Function

    Function ActualizarTipoCambio()
        Dim estado As Boolean
        Try
            If IdTipoCambio = "" Then
                IdTipoCambio = "0"
            End If
            dt = Cobranza.FunctionGlobal(":tipocambioƒ:idtipocambioƒ:idempresa▓" & TipoCambio & "ƒ" & IdTipoCambio & "ƒ" & IdEmpresa, "QRYTC002")
            estado = True
        Catch ex As Exception
            estado = False
        End Try
        Return estado
    End Function
End Class
