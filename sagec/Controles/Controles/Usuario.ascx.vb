Public Partial Class Usuario
    Inherits System.Web.UI.UserControl

    Private Sub btnNuevo_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnNuevo.Click
        NMUsuario1.titulo = "NUEVO USUARIO"
        NMUsuario1.Visible = True
    End Sub


    
End Class