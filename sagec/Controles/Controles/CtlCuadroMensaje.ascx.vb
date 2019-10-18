Public Partial Class CtlCuadroMensaje
    Inherits System.Web.UI.UserControl

    Public Property Titulo() As String
        Get
            Return Session("TituloCM")
        End Get
        Set(ByVal value As String)
            Session("TituloCM") = value
        End Set
    End Property

    Public Property Contexto() As String
        Get
            Return Session("ContextoCM")
        End Get
        Set(ByVal value As String)
            Session("ContextoCM") = value
        End Set
    End Property

    Public Property Variable() As String
        Get
            Return lblVariable.Text
        End Get
        Set(ByVal value As String)
            lblVariable.Text = value
        End Set
    End Property

    Sub CargarContexto()
        lblTituloControl.Text = Titulo
        lblContexto.Text = Contexto
    End Sub

    Private Sub btnSi_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSi.Click
        RaiseEvent Si()
    End Sub

    Private Sub btnNO_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNO.Click
        RaiseEvent No()
    End Sub

    Event Si()
    Event No()
End Class