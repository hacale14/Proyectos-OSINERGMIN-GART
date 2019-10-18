Public Partial Class CtlCalling
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    Event Cerrar()

    Private Sub btnCerrar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnCerrar.Click
        RaiseEvent Cerrar()
    End Sub
End Class