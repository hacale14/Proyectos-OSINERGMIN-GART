Public Partial Class CtlReasignarGestor
    Inherits System.Web.UI.UserControl
    Dim blasignacion As New BL.Asignacion

    Private Sub btnBuscar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnBuscar.Click
        Dim Mensaje As String = ""
        If Len(Trim(txtCienteDNI.Text)) = 0 Then
            CtlMensajes1.Mensaje("AVISO..: ESCRIBA EL DNI DEL CLIENTE!")
            txtCienteDNI.Focus()
            Exit Sub
        End If

        blasignacion.Cliente_DNI = txtCienteDNI.Text
        CtlClenteAsignado.SourceDataTable = blasignacion.Buscar_Cliente_dt()
        CtlClenteAsignado.Activa_option = True 
        CtlClenteAsignado.Activa_Edita = False
        CtlClenteAsignado.Activa_Delete = False        
    End Sub

    Private Sub BtnCerrar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BtnCerrar.Click
        Response.Redirect("Principal.aspx")
    End Sub

    Private Sub btnGrabar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnGrabar.Click
        blasignacion.Gestor_ID = cboGestor.Value

        For Each row As GridViewRow In CtlClenteAsignado.GV.Rows
            Dim chkaux As RadioButton = row.FindControl("RadioButton")
            If chkaux.Checked = True Then
                blasignacion.UsuarioCliente_ID = row.Cells(9).Text
                Exit For
            End If
        Next
        If Val(blasignacion.UsuarioCliente_ID) = 0 Then
            CtlMensajes1.Mensaje("No tiene asgignado un gestoro le falta ciente para ser reasignado...!")
            limpiador()
            Exit Sub
        End If
        blasignacion.Actualizar()
        btnBuscar_Click(sender, e)
        limpiador()        
        CtlMensajes1.Mensaje("La reasignacion de gestor:" & cboGestor.Value & " a sido cambiado con exito ", "")
    End Sub

    Private Sub limpiador()
        lblIdCliente.Text = ""
        lblIdUsuario.Text = ""
        lblIdUsuarioCliente.Text = ""         
        txtCienteDNI.Text = ""        
    End Sub

    Private Sub CtlClenteAsignado_elegirfila(ByVal sender As Object, ByVal e As System.EventArgs, ByVal row As System.Web.UI.WebControls.GridViewRow) Handles CtlClenteAsignado.elegirfila
        lblIdUsuarioCliente.Text = row.Cells(9).Text
    End Sub
End Class