Imports System.IO
Imports System.Web.UI.ScriptManager
Partial Public Class NMUsuario
    Inherits System.Web.UI.UserControl
    Dim bl As New BL.Cobranza
    Public Property Titulo() As String
        Get
            Return lblTituloControl.Text
        End Get
        Set(ByVal value As String)
            lblTituloControl.Text = value
        End Set
    End Property

    Public Property UbicacionFoto() As String
        Get
            Return lblUbicacionFoto.text
        End Get
        Set(ByVal value As String)
            lblUbicacionFoto.text = value
        End Set
    End Property

    Public Property IdUsuario() As String
        Get
            Return lblIdUsuario.Text
        End Get
        Set(ByVal value As String)
            lblIdUsuario.Text = value
        End Set
    End Property
    Private Sub btnCerrar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnCerrar.Click
        Me.Visible = False
    End Sub

    Private Sub btnGrabar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnGrabar.Click
        If Len(Trim(cboTipoUsuario.Text)) = 0 Then : CtlMensajes1.Mensaje("AVISO..: SELECCIONE UN TIPO DE USUARIO!") : Exit Sub : End If
        If Len(Trim(cboPerfil.Text)) = 0 Then : CtlMensajes1.Mensaje("AVISO..: SELECCIONE UN PERFIL!") : Exit Sub : End If
        If Len(Trim(txtNombres.Text)) = 0 Then : CtlMensajes1.Mensaje("AVISO..: ESCRIBA UN NOMBRE!") : Exit Sub : End If
        If Len(Trim(txtApellidos.Text)) = 0 Then : CtlMensajes1.Mensaje("AVISO..: ESCRIBA LOS APELLIDOS!") : Exit Sub : End If
        If Len(Trim(txtUsuario.Text)) = 0 Then : CtlMensajes1.Mensaje("AVISO..: ESCRIBA UN NOMBRE DE USUARIO!") : Exit Sub : End If
        If Len(Trim(txtContrasena.Text)) = 0 Then : CtlMensajes1.Mensaje("AVISO..: ESCRIBA UNA CONTRASEÑA!") : Exit Sub : End If

        If txtContrasena.Text <> txtValidarContrasena.Text Then : CtlMensajes1.Mensaje("ERROR EN LA CONFIRMACION DE CONTRASEÑA!") : Exit Sub : End If
        Dim dt As New DataTable
        If Titulo = "NUEVO USUARIO" Then
            Using dt
                dt = bl.FunctionGlobal(":ptipousuarioƒ:pnombresƒ:papellidosƒ:pusuarioƒ:pcontrasenaƒ:pubicacionfotoƒ:pdireccionƒ:ptelefonoƒ:pcelularƒ:pfechaIngresoƒ:pcargo▓" & cboTipoUsuario.Text & "ƒ" & txtNombres.Text & "ƒ" & txtApellidos.Text & "ƒ" & txtUsuario.Text & "ƒ" & txtContrasena.Text & "ƒ" & UbicacionFoto & "ƒ" & txtDireccion.Text & "ƒ" & txtTelefono.Text & "ƒ" & txtCelular.Text & "ƒ" & Format(txtFechaIngreso.Text, "yyyy/mm/dd") & "ƒ" & txtCargo.Text, "QRYUS001")
                Dim idUsuario = dt(0)(0)
                bl.FunctionGlobal(":pidusuarioƒ:pidperfil▓" & idUsuario & "ƒ" & cboPerfil.Value, "QRYPFL010")
            End Using
        ElseIf Titulo = "MODIFICAR USUARIO" Then
            If Trim(txtFechaIngreso.Text <> "") Then
                bl.FunctionGlobal(":ptipousuarioƒ:pnombresƒ:papellidosƒ:pusuarioƒ:pcontrasenaƒ:pubicacionfotoƒ:pdireccionƒ:ptelefonoƒ:pcelularƒ:pcargoƒ:pfechaIngresoƒ:pidusuario▓" & cboTipoUsuario.Text & "ƒ" & txtNombres.Text & "ƒ" & txtApellidos.Text & "ƒ" & txtUsuario.Text & "ƒ" & txtContrasena.Text & "ƒ" & UbicacionFoto & "ƒ" & txtDireccion.Text & "ƒ" & txtTelefono.Text & "ƒ" & txtCelular.Text & "ƒ" & txtCargo.Text & "ƒ" & Format(txtFechaIngreso.Text, "yyyy/mm/dd") & "ƒ" & lblIdUsuario.Text, "QRYUS001")
            Else
                bl.FunctionGlobal(":ptipousuarioƒ:pnombresƒ:papellidosƒ:pusuarioƒ:pcontrasenaƒ:pubicacionfotoƒ:pdireccionƒ:ptelefonoƒ:pcelularƒ:pcargoƒ:pfechaIngresoƒ:pidusuario▓" & cboTipoUsuario.Text & "ƒ" & txtNombres.Text & "ƒ" & txtApellidos.Text & "ƒ" & txtUsuario.Text & "ƒ" & txtContrasena.Text & "ƒ" & UbicacionFoto & "ƒ" & txtDireccion.Text & "ƒ" & txtTelefono.Text & "ƒ" & txtCelular.Text & "ƒ" & txtCargo.Text & "ƒ" & "Null" & "ƒ" & lblIdUsuario.Text, "QRYUS001")
            End If
        End If
        CtlMensajes1.Mensaje("AVISO..: EL USUARIO SE GUARDO CORRECTAMENTE!")
        Me.Visible = False
    End Sub
    Private Sub RellenaCombo(ByVal Combo As CtCombo, ByVal Procedimiento As String, ByVal Condicion As String, Optional ByVal AP As Boolean = False)
        With Combo
            .Limpia()
            .Procedimiento = Procedimiento
            .Condicion = Condicion
            .AutoPostBack = AP
            .Cargar_dll()
            .Activa = True
        End With
    End Sub

    Private Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            RellenaCombo(cboTipoUsuario, "QRYC008", ":cod▓110")
            RellenaCombo(cboPerfil, "QRYCBP002", "")
            imgFoto.Src = "z:\" & Val(Trim(txtUsuario.Text)) & ".jpg"
        End If
    End Sub

    Private Sub btnSubir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSubir.Click
        If FileUpload1.PostedFile IsNot Nothing Then
            Dim FileName As String = Path.GetFileName(FileUpload1.PostedFile.FileName)
            Dim ruta As String = Server.MapPath("Files/" & FileName)
            FileUpload1.SaveAs(ruta)
            UbicacionFoto = ruta
            imgFoto.Src = ruta
        End If
    End Sub

    Public Sub LoadUsuario(ByVal tipousuario As String, ByVal nombres As String, ByVal apellidos As String, ByVal direccion As String, ByVal telefono As String, ByVal celular As String, ByVal fechaingreso As String, ByVal cargo As String, ByVal clave As String, ByVal ruta As String, ByVal usuario As String)

        cboTipoUsuario.Text = tipousuario
        txtNombres.Text = nombres
        txtApellidos.Text = apellidos
        txtDireccion.Text = direccion
        txtTelefono.Text = telefono
        txtCelular.Text = celular
        txtFechaIngreso.Text = fechaingreso
        txtCargo.Text = cargo
        txtUsuario.Text = Usuario
        txtContrasena.Text = clave
        txtValidarContrasena.Text = ""
        If ruta <> "" Then
            imgFoto.Src = ruta
        End If
    End Sub

    Public Sub limpiador()
        cboTipoUsuario.Text = ""
        txtNombres.Text = ""
        txtApellidos.Text = ""
        txtDireccion.Text = ""
        txtTelefono.Text = ""
        txtCelular.Text = ""
        txtFechaIngreso.Text = ""
        txtCargo.Text = ""
        txtUsuario.Text = ""
        txtContrasena.Text = ""
        txtValidarContrasena.Text = ""
        imgFoto.Src = ""
    End Sub
End Class