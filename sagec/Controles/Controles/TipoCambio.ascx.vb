Imports BL
Partial Public Class TipoCambio
    Inherits System.Web.UI.UserControl
    Dim BLTipoCambio As New BL.TipoCambio
    Dim dt As New DataTable

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            Try
                cboEmpresa.Limpia()
                cboEmpresa.Cargar_dll()
            Catch ex As Exception
                CtlMensajes1.Mensaje("Ocurrio un error al cargar empresa")
            End Try
        End If
    End Sub

    Sub CargarDatos()
        Dim ctl As New BL.Cobranza
        Dim dt As New DataTable
        Try
            dt = ctl.FunctionGlobal(":idempresa▓" & cboEmpresa.Value, "QRYTC001")
            If dt.Rows.Count > 0 Then
                lblIdTipoCambio.Text = dt.Rows(0)(0).ToString
                TextBox1.Text = dt.Rows(0)(1).ToString
                Label3.Text = dt.Rows(0)(2).ToString
            Else
                lblIdTipoCambio.Text = ""
                TextBox1.Text = ""
                Label3.Text = "No se ha registrado"
            End If
        Catch ex As Exception
            CtlMensajes1.Mensaje("Ocurrio un error al cargar el tipo de cambio")
        End Try
    End Sub

    Private Sub imgGrabar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgGrabar.Click
        Dim estado As Boolean
        Try
            BLTipoCambio.IdTipoCambio = lblIdTipoCambio.Text
            BLTipoCambio.TipoCambio = Trim(Replace(TextBox1.Text, ",", "."))
            BLTipoCambio.IdEmpresa = cboEmpresa.Value
            BLTipoCambio.Fecha = DateTime.Today
            estado = BLTipoCambio.ActualizarTipoCambio()
        Catch ex As Exception
            estado = False
        End Try
        If estado = True Then
            CtlMensajes1.Mensaje("Se ha guardado los cambios satisfactoriamente")
        Else
            CtlMensajes1.Mensaje("Se ha producido un error")
        End If
    End Sub

    Private Sub cboEmpresa_Click() Handles cboEmpresa.Click
        CargarDatos()
    End Sub

End Class