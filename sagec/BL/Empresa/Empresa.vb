Imports ConDB
Public Class Empresa : Inherits BE.Empresa
    Dim Cobranza As New Cobranza
    Public Mensaje As String
    Public Estado As String

    Function InsertarEmpresa()
        Try
            Cobranza.FunctionGlobal(":empresaƒ:idcorporacion▓" & Descripcion & "ƒ" & idCorporacion, "QRYE001")
        Catch ex As Exception
            Return Nothing
            Mensaje = ex.Message
        End Try
        Return Nothing
    End Function

    Function BuscarEmpresa(ByVal criterio As String)
        Dim dt As New DataTable
        Try
            dt = Cobranza.FunctionGlobal(":criterio▓" & criterio, "SQLE002")
        Catch ex As Exception
            dt = Nothing
        End Try
        Return dt
    End Function

    Function ModificarEmpresa(ByVal idempresa As String, ByVal empresa As String, ByVal idCorporacion As String)
        Cobranza.FunctionGlobal(":idempresaƒ:empresaƒ:idcorporacion▓" & idempresa & "ƒ" & empresa & "ƒ" & idCorporacion, "SQLE003")
        Return Nothing
    End Function

    Function EliminarEmpresa(ByVal idempresa As String)
        Cobranza.FunctionGlobal(":idempresa▓" & idempresa, "SQLE004")
        Return Nothing
    End Function
End Class
