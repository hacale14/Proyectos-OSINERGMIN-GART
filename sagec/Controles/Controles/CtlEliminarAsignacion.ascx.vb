Public Partial Class CtlEliminarAsignacion
    Inherits System.Web.UI.UserControl
    Dim blcobranza As New BL.Cobranza

    Public Sub Cargar_datos(ByVal IdUsuarioCliente As String, ByVal IdCliente As String, ByVal Cliente As String)
        lblIdUsuarioCliente.Text = IdUsuarioCliente
        lblIdCliente.Text = IdCliente
        txtCliente.Text = Cliente
        RDBActual.Checked = True
    End Sub

    Private Sub btnCerrar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnCerrar.Click
        Me.Visible = False
    End Sub

    Private Sub btnEliminar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnEliminar.Click
        If RDBActual.Checked = True Then
            If lblIdUsuarioCliente.Text <> "" Then
                blcobranza.FunctionGlobal(":pIdUsuarioCliente▓" & lblIdUsuarioCliente.Text, "QRYCRG003")
            Else
                CtlMensajes1.Mensaje("AVISO..: NO SE PUEDE ELIMINAR PORQUE NO TIENE UN GESTOR ASIGNADO!")
                Exit Sub
            End If
        ElseIf RDBAllRegisters.Checked = True Then
            blcobranza.FunctionGlobal("", "QRYCRG004")
        End If
        CtlMensajes1.Mensaje("AVISO..: LA ELIMINACIÓN SE EJECUTÓ CORRECTAMENTE CORRECTAMENTE!")
        Me.Visible = False
        limpiador()
    End Sub
    Sub limpiador()
        lblIdCliente.Text = ""
        lblIdUsuarioCliente.Text = ""
        txtCliente.Text = ""
    End Sub
End Class