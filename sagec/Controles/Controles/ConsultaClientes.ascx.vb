Imports BL

Partial Public Class ConsultaClientes
    Inherits System.Web.UI.UserControl
    Dim BLCliente As New BL.Cliente
    Dim dt As New DataTable

    Private Sub NuevoCLienteGestionarCliente1_CerrarNuevoClienteGestion() Handles NuevoCLienteGestionarCliente1.CerrarNuevoClienteGestion
        pnlNuevaCartera.Visible = False
        Call imgBuscar_Click()
    End Sub

    Private Sub imgBuscar_Click() Handles imgBuscar.Click
        BLCliente.Cartera = cboCartera.Text
        BLCliente.Condicion = cboCondicion.Text
        BLCliente.Situacion = txtSituac.Text
        BLCliente.DNI = txtDNI.Text
        BLCliente.Cliente = txtCliente.Text
        BLCliente.Telefono1 = txtTelefono1.Text
        BLCliente.Telefono2 = txtTelefono2.Text
        dt = BLCliente.BuscarCliente
        CtlGrilla1.OcultarColumnas = "11;12;13;14;15;16"
        CtlGrilla1.SourceDataTable = dt
        dt = Nothing
    End Sub

    Private Sub CtlGrilla1_Nuevo() Handles CtlGrilla1.Nuevo
        pnlNuevaCartera.Visible = True
        NuevoCLienteGestionarCliente1.Tipo = "NUEVO"
        NuevoCLienteGestionarCliente1.CargarCombo()
    End Sub

    Private Sub CtlGrilla1_RowDeleting(ByVal GV As System.Web.UI.WebControls.GridView, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles CtlGrilla1.RowDeleting
        Dim row As GridViewRow = GV.Rows(e.RowIndex)
        BLCliente.IdCliente = row.Cells(15).Text
        BLCliente.BorrarCliente()
        imgBuscar_Click()
        CtlMensajes1.Mensaje("La cartera fue removida satisfactoriamente", "SISTEMA DE COBRANZA")
    End Sub


    Private Sub CtlGrilla1_RowEditing(ByVal GV As System.Web.UI.WebControls.GridView, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs, ByVal row As System.Web.UI.WebControls.GridViewRow) Handles CtlGrilla1.RowEditing

        pnlModificarCartera.Visible = True
        NuevoCLienteGestionarClienteM.Tipo = "ACTUALIZAR"
        NuevoCLienteGestionarClienteM.IdCliente = row.Cells(15).Text
        NuevoCLienteGestionarClienteM.Cartera = row.Cells(5).Text
        NuevoCLienteGestionarClienteM.Condicion = row.Cells(6).Text
        Call NuevoCLienteGestionarClienteM.Cargar()
    End Sub


    Private Sub NuevoCLienteGestionarClienteM_CerrarNuevoClienteGestion() Handles NuevoCLienteGestionarClienteM.CerrarNuevoClienteGestion
        pnlModificarCartera.Visible = False
        Call imgBuscar_Click()
    End Sub

    Private Sub imgCerrar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgCerrar.Click
        Me.Visible = False
    End Sub

End Class