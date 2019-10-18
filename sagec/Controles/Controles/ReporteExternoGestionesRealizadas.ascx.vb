Public Partial Class ReporteExternoGestionesRealizadas
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Titulo = Request.QueryString("titulo")
        imgCerrar.Attributes.Add("onclick", "javascript:redireccionar();")
    End Sub
    Public Property Titulo()
        Get
            Return lblTituloControl.Text
        End Get
        Set(ByVal value)
            lblTituloControl.Text = value
        End Set
    End Property
End Class