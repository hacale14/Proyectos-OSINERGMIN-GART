Imports ConDB
Partial Public Class Predictivo
    Inherits System.Web.UI.Page
    Dim ctl As New ConDB.ConSQL

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        PredictivoLoad(Request("idCliente"), Request("Telefono"))
    End Sub

    Function PredictivoLoad(ByVal Idcliente As String, ByVal Telefono As String)
        Dim dt As New DataTable
        dt = ctl.FunctionGlobal(":pIdCliente▓" & Idcliente, "PREDIC01")
        If (dt.Rows.Count) = 0 Then
            System.Web.HttpContext.Current.Response.Write("El IdCliente No existe:" & Idcliente & "")
        Else
            Dim url As String = ""
            url = "http://192.168.1.19/valsys/Gestion_Predictiva.aspx?DNI=" & dt.Rows(0)(0) & "&idcliente=" & Idcliente & "&idcartera=" & dt.Rows(0)(4) & "&idusuario=" & dt.Rows(0)(1) & "&NombreGestor=" & dt.Rows(0)(2) & "&tipocartera=" & dt.Rows(0)(6) & "&usuario=" & dt.Rows(0)(3) & "&Telefono=" & Telefono
            Response.Redirect(url)
        End If
        dt = Nothing
    End Function

End Class