Public Partial Class ConsultaAsigancion
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            Dim ctl As New BL.Cobranza
            Dim dt As New DataTable

        End If
    End Sub
End Class