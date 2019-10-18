Imports ConDB
Partial Public Class CtlValidaAcceso
    Inherits System.Web.UI.UserControl
    Public Sub valida_Accesos(ByVal usuario As String, ByVal meobj As Object)
        Dim conBD As New ConDB.Conexion
        Dim dt As DataTable
        Dim sql As String = ""
        Dim n As Integer = 0
        dt = conBD.Obtiene_QUERY("SS_SP_12")
        sql = dt.Rows(0)(0).ToString.Replace(":pusuario", usuario)
        sql = sql.Replace(":ppantalla", Replace(Replace(meobj.ToString, "{", ""), "ASP.", "").ToString)
        dt = Nothing
        dt = conBD.CreateMySqlCommand(sql)
        If dt.Rows.Count < 1 Then
            If Trim(usuario) = "" Then
                Response.Redirect("Login.aspx")
            Else
                Response.Redirect("Principal.aspx")
            End If
        End If
        dt = Nothing
    End Sub
End Class