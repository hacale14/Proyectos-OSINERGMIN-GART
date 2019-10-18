Partial Public Class ConsultaPagos
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Dim cnx As New ConSQL
        'cnx.Obtiene_dt("Select top 20  * from pagos", 1)
    End Sub

    Private Sub imgCerrar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgCerrar.Click
        RaiseEvent CerrarPagos()
    End Sub

    Event CerrarPagos()

    'Nuevo Pago
    Private Sub imgNuevo_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgNuevo.Click
        pnlNuevoPago.Visible = True
    End Sub


    'Modicar Pago
    Private Sub imgModificar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgModificar.Click
        pnlModificarPago.Visible = True
    End Sub

    'Metas
    Private Sub imgVerMetas_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgVerMetas.Click
        pnlMetas.Visible = True
    End Sub

    Private Sub MetasCobranzasAvances1_CerraMetas() Handles MetasCobranzasAvances1.CerraMetas
        pnlMetas.Visible = False
    End Sub

End Class