Public Partial Class CtlLlamando
    Inherits System.Web.UI.UserControl    
    Public Property IdCtl() As String
        Get
            Return Label9.Text
        End Get
        Set(ByVal value As String)
            Label9.Text = value
        End Set
    End Property

    Protected Sub Timer1_Tick(ByVal sender As Object, ByVal e As EventArgs) Handles Timer1.Tick
        Me.Visible = False
    End Sub
End Class