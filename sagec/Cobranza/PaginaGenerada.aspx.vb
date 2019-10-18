Public Partial Class PaginaGenerada
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Me.Title = Request.QueryString("titulo")
            Dim loadmodule As UserControl
            loadmodule = Me.LoadControl(Request.QueryString("palabra"))
            pnlPrincipal.Controls.Add(loadmodule)
        Catch ex As Exception
            Response.Write(ex.ToString & "<br />")
        End Try
    End Sub

End Class