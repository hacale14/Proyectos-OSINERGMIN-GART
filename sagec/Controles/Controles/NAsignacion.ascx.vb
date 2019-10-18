Partial Public Class NAsignacion
    Inherits System.Web.UI.UserControl
    Dim Mensaje As New CtlMensajes
    Dim bl As New BL.Cobranza
    Public Property Titulo() As String
        Get
            Return lblTituloControl.Text
        End Get
        Set(ByVal value As String)
            lblTituloControl.Text = value
        End Set
    End Property
    Private Sub btnCerrar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnCerrar.Click
        Me.Visible = False
    End Sub
    Private Sub btnGrabar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnGrabar.Click
        If Len(Trim(txtCliente.Text)) = 0 Then
            Mensaje.Mensaje("Seleccione un Cliente!")
            Exit Sub
        End If
        If Len(Trim(cboGestor.Text)) = 0 Then
            Mensaje.Mensaje("Seleccione un Gestor!")
            Exit Sub
        End If
        If Titulo = "Nueva Asignacion" Then
            bl.FunctionGlobal(":pgestorƒ:pcliente▓" & CStr(cboGestor.Value) & "ƒ" & CStr(lblCodCliente.Text), "QRYNMA0001")
        ElseIf Titulo = "Modificar Asignacion" Then
            bl.FunctionGlobal(":pgestorƒ:pclienteƒ:pusuario▓" & CStr(cboGestor.Value) & "ƒ" & CStr(lblCodCliente.Text) & "ƒ" & CStr(lblCodUsuario.Text), "QRYNMA0001")
        End If
        Mensaje.Mensaje("La Asignacion se realizo Correctamente!")

    End Sub

    Private Sub cargar_combo(ByVal Combo As CtCombo, ByVal procedimiento As String, ByVal condicion As String, Optional ByVal Ap As Boolean = False)
        With Combo
            .Limpia()
            .Procedimiento = procedimiento
            .Condicion = condicion
            .Activa = True
            .Cargar_dll()
        End With
    End Sub

    Private Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            cargar_combo(cboGestor, "QRYCBG002", "")
        End If
    End Sub
End Class