Public Partial Class Observacion
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            lblidProceso.Text = Request.QueryString("idProceso")
            LoadIndice()
        End If
    End Sub

    Private Sub LoadIndice()
        Dim bl As New BL.Cobranza
        Dim dt As New DataTable
        Using dt
            dt = bl.FunctionGlobal(":pidproceso▓ " & lblidProceso.Text, "QRYBOB001")
            gvObservacion.SourceDataTable = dt
        End Using
    End Sub
End Class