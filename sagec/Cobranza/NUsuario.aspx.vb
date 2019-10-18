Imports Controles
Imports System.IO
Partial Public Class NUsuario
    Inherits System.Web.UI.Page
    Dim bl As New BL.Cobranza
    'PROPIEDADES
    Public Property Titulo() As String
        Get
            Return lblTitulo.Text
        End Get
        Set(ByVal value As String)
            lblTitulo.Text = value
        End Set
    End Property
    Public Property UbicacionFoto() As String
        Get
            Return lblUbicacionFoto.Text
        End Get
        Set(ByVal value As String)
            lblUbicacionFoto.Text = value
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
    'GLOBALES
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
    'CARGA INICIAL
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            Dim ctl As New Controles.General
            RellenaCombo(cboTipoUsuario, "QRYC008", ":cod▓110")
            RellenaCombo(cboPerfil, "QRYCBP002", "")
            RellenaCombo(cboSexo, "QRYC008", ":cod▓128", True)
            RellenaCombo(cboArea, "QRYC008", ":cod▓129", True)
            RellenaCombo(CboDistrito, "QRYC011", ":cod▓1", True)

            If Not Request.QueryString("idUsuario") Is Nothing Then
                IdUsuario = Request.QueryString("idUsuario")
                gvCartera.SourceDataTable = ctl.BuscarSQL(":idusuario▓" & IdUsuario, "GES001")
                Titulo = "MODIFICAR DATOS DEL USUARIO"
                Load_Usuario()

            End If
        End If
    End Sub

    Private Sub btnMostrar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnMostrar.Click
        If FileUpload1.PostedFile IsNot Nothing Then
            If FileUpload1.PostedFile.ContentLength < 1048576 Then
                Dim FileName As String = Path.GetFileName(FileUpload1.PostedFile.FileName)
                Dim ruta As String = Server.MapPath("Files") + "/" + FileName
                If FileName <> "" Then
                    lblUbicacionFoto.Text = ruta
                    FileUpload1.SaveAs(ruta)
                    imgFoto.ImageUrl = ("../Files/" + FileName)
                End If
            Else
                CtlMensajes1.Mensaje("AVISO..: EL TAMAÑO DE LA FOTO DEBE SER MENOR A UN MEGABYTE!")
            End If
        End If
    End Sub

    Private Sub btnGrabar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnGrabar.Click
        Dim CtM As New ConDB.Conexion

        If Val(Obtiene_Cookies("TipoTroncal")) > 1 Then
            CtlMensajes1.Mensaje("El perfil " & Obtiene_Cookies("TipoTroncal") & " no puede modificar al usuario")
            Exit Sub
        End If

        Dim dt2 As DataTable = CtM.CreateMySqlCommand("select * from asterisk.anexos where anexo=" & txtAnexo.Text)

        If Len(Trim(cboTipoUsuario.Text)) = 0 Then : CtlMensajes1.Mensaje("AVISO..: SELECCIONE UN TIPO DE USUARIO!") : Exit Sub : End If
        If Len(Trim(cboPerfil.Text)) = 0 Then : CtlMensajes1.Mensaje("AVISO..: SELECCIONE UN PERFIL!") : Exit Sub : End If
        If Len(Trim(txtNombres.Text)) = 0 Then : CtlMensajes1.Mensaje("AVISO..: ESCRIBA UN NOMBRE!") : Exit Sub : End If
        If Len(Trim(txtApellidos.Text)) = 0 Then : CtlMensajes1.Mensaje("AVISO..: ESCRIBA LOS APELLIDOS!") : Exit Sub : End If
        If Len(Trim(txtUsuario.Text)) = 0 Then : CtlMensajes1.Mensaje("AVISO..: ESCRIBA UN NOMBRE DE USUARIO!") : Exit Sub : End If
        If Len(Trim(txtContrasena.Text)) = 0 Then : CtlMensajes1.Mensaje("AVISO..: ESCRIBA UNA CONTRASEÑA!") : Exit Sub : End If
        If Len(Trim(txtAnexo.Text)) = 0 Then : CtlMensajes1.Mensaje("AVISO..: EL ANEXO ES OBLIGATORIO PARA EL CLICK TO CALL!") : Exit Sub : End If
        If Len(Trim(cboCarteraAsterisk.Text)) = 0 Then : CtlMensajes1.Mensaje("AVISO..: CARTERA ASTERISK ES OBLIGATORIO PARA LOS REPORTES!") : Exit Sub : End If
        'If Len(Trim(txtTipoTroncal.Text)) = 0 Then : CtlMensajes1.Mensaje("AVISO..: CARTERA ASTERISK ES OBLIGATORIO PARA LOS REPORTES!") : Exit Sub : End If
        Dim dt As New DataTable
        If Not dt2 Is Nothing Then
            If dt2.Rows.Count > 0 Then
                txtTipoTroncal.Text = dt2.Rows(0)(2)
            End If
        End If

        If Titulo = "INGRESAR NUEVO USUARIO" Then
            bl.FunctionGlobal(":ptipousuarioƒ:pnombresƒ:papellidosƒ:pusuarioƒ:pcontrasenaƒ:ubicacionfotoƒ:pdireccionƒ:ptelefonoƒ:pcelularƒ:pfechaIngresoƒ:pcargoƒ:anexoƒ:tipotroncalƒ:carteraasteriskƒ:bolsaƒ:fechanacimientoƒ:sexoƒ:distritoƒ:fechaceseƒ:areaƒ:motivo_cese▓" & cboTipoUsuario.Text & "ƒ" & txtNombres.Text & "ƒ" & txtApellidos.Text & "ƒ" & txtUsuario.Text & "ƒ" & txtContrasena.Text & "ƒ" & UbicacionFoto & "ƒ" & txtDireccion.Text & "ƒ" & txtTelefono.Text & "ƒ" & txtCelular.Text & "ƒ" & Format(CDate(txtFechaIngreso.Text), "yyyy/MM/dd") & "ƒ" & cboCargo.Value & "ƒ" & txtAnexo.Text & "ƒ" & txtTipoTroncal.Text & "ƒ" & cboCarteraAsterisk.Value & "ƒ" & "''" & "ƒ" & txtFecNac.Text & "ƒ" & cboSexo.Value & "ƒ" & CboDistrito.Value & "ƒ" & txtFechaCese.Text & "ƒ" & cboArea.Value & "ƒ" & txtMotivoCese.Text, "QRYUS001")
            Using dt
                dt = bl.FunctionGlobal(":pusuario▓" & Trim(txtUsuario.Text), "QRYPFL011")
                Dim idUsuario = dt(0)(0)
                bl.FunctionGlobal(":pidusuarioƒ:pidperfil▓" & idUsuario & "ƒ" & cboPerfil.Value, "QRYPFL010")
            End Using
        ElseIf Titulo = "MODIFICAR DATOS DEL USUARIO" Then
            If Trim(txtFechaIngreso.Text <> "") Then
                bl.FunctionGlobal(":ptipousuarioƒ:pnombresƒ:papellidosƒ:pusuarioƒ:pcontrasenaƒ:ubicacionfotoƒ:pdireccionƒ:ptelefonoƒ:pcelularƒ:pcargoƒ:pfechaIngresoƒ:pidusuarioƒ:anexoƒ:tipotroncalƒ:carteraasteriskƒ:bolsaƒ:fechanacimientoƒ:sexoƒ:distritoƒ:fechaceseƒ:areaƒ:motivo_cese▓" & _
                                  cboTipoUsuario.Text & "ƒ" & txtNombres.Text & "ƒ" & txtApellidos.Text & "ƒ" & txtUsuario.Text & "ƒ" & _
                                  txtContrasena.Text & "ƒ" & UbicacionFoto & "ƒ" & txtDireccion.Text & "ƒ" & txtTelefono.Text & "ƒ" & _
                                  txtCelular.Text & "ƒ" & cboCargo.Value & "ƒ" & txtFechaIngreso.Text & "ƒ" & lblIdUsuario.Text & "ƒ" & txtAnexo.Text & "ƒ" & txtTipoTroncal.Text & "ƒ" & cboCarteraAsterisk.Value & "ƒ" & "" & _
                                  "ƒ" & txtFecNac.Text & "ƒ" & cboSexo.Value & "ƒ" & CboDistrito.Value & "ƒ" & txtFechaCese.Text & "ƒ" & cboArea.Value & "ƒ" & txtMotivoCese.Text, "QRYUS002")
            Else
                bl.FunctionGlobal(":ptipousuarioƒ:pnombresƒ:papellidosƒ:pusuarioƒ:pcontrasenaƒ:ubicacionfotoƒ:pdireccionƒ:ptelefonoƒ:pcelularƒ:pcargoƒ:pfechaIngresoƒ:pidusuarioƒ:anexoƒ:tipotroncalƒ:carteraasteriskƒ:bolsaƒ:fechanacimientoƒ:sexoƒ:distritoƒ:fechaceseƒ:areaƒ:motivo_cese▓" & cboTipoUsuario.Text & "ƒ" & txtNombres.Text & "ƒ" & txtApellidos.Text & "ƒ" & txtUsuario.Text & "ƒ" & txtContrasena.Text & "ƒ" & UbicacionFoto & "ƒ" & txtDireccion.Text & "ƒ" & txtTelefono.Text & "ƒ" & txtCelular.Text & "ƒ" & cboCargo.Text & "ƒ" & "Null" & "ƒ" & lblIdUsuario.Text & "ƒ" & txtAnexo.Text & "ƒ" & txtTipoTroncal.Text & "ƒ" & cboCarteraAsterisk.Value & "ƒ" & "" & "ƒ" & txtFecNac.Text & "ƒ" & cboSexo.Value & "ƒ" & CboDistrito.Value & "ƒ" & txtFechaCese.Text & "ƒ" & cboArea.Value & "ƒ" & txtMotivoCese.Text, "QRYUS002")
            End If
            bl.FunctionGlobal(":idperfilƒ:idusuario▓" & cboPerfil.Value & "ƒ" & lblIdUsuario.Text, "SQL_N_USER")
        End If
        'actualizando la tabla de gestores
        CtM.CreateMySqlCommand("delete from asterisk.gestores where anexo=" & txtAnexo.Text)
        CtM.CreateMySqlCommand("delete from asterisk.gestores where codigo='" & txtUsuario.Text & "'")
        CtM.CreateMySqlCommand("insert into asterisk.gestores  (anexo,nombre,codigo,cartera,idcartera)  select '" & txtAnexo.Text & "','" & txtApellidos.Text & " " & txtNombres.Text & "','" & txtUsuario.Text & "','" & cboCarteraAsterisk.Text & "',0")
        Dim CAD As String = ""
        For Each row As GridViewRow In gvCartera.GV.Rows
            If row.RowType = DataControlRowType.DataRow Then
                Dim chkRow As CheckBox = TryCast(row.Cells(0).FindControl("ChkBox"), CheckBox)
                If chkRow.Checked Then
                    CAD &= row.Cells(4).Text & ","
                End If
            End If
        Next
        bl.FunctionGlobal(":cadƒ:idusuario▓" & CAD & "ƒ" & lblIdUsuario.Text, "GES0002")
        CtlMensajes1.Mensaje("AVISO..: EL USUARIO SE GUARDO CORRECTAMENTE!")
    End Sub
    Function Obtiene_Cookies(ByVal id) As String
        '// Recogemos la cookie que nos interese
        Dim cogeCookie As HttpCookie = Request.Cookies.Get(id)
        Return cogeCookie.Value
    End Function
    Private Sub Load_Usuario()
        Dim dt As New DataTable
        Dim criterio = ""        
        Using dt
            criterio = " USUARIO.idUsuario = " & lblIdUsuario.Text
            dt = bl.FunctionGlobal(":criterio▓" & criterio, "QRYUS003")
            cboPerfil.Value = IIf(Not IsDBNull(dt(0)("IDPERFIL")), dt(0)("IDPERFIL"), 0)
            cboTipoUsuario.Text = IIf(Not IsDBNull(dt(0)("TipoUsuario")), dt(0)("TipoUsuario"), "")
            txtNombres.Text = IIf(Not IsDBNull(dt(0)("Nombres")), dt(0)("Nombres"), "")
            txtApellidos.Text = IIf(Not IsDBNull(dt(0)("Apellidos")), dt(0)("Apellidos"), "")
            txtUsuario.Text = IIf(Not IsDBNull(dt(0)("Usuario")), dt(0)("Usuario"), "")
            txtContrasena.Text = IIf(Not IsDBNull(dt(0)("Clave")), dt(0)("Clave"), "")
            txtValidarContrasena.Text = IIf(Not IsDBNull(dt(0)("Clave")), dt(0)("Clave"), "")
            'imgFoto.ImageUrl = IIf(Not IsDBNull(dt(0)("RutaFoto")), dt(0)("RutaFoto"), "")
            imgFoto.ImageUrl = "FOTOS/" & Val(Trim(txtUsuario.Text)) & ".jpg"   'IIf(Not IsDBNull(dt(0)("RutaFoto")), dt(0)("RutaFoto"), "")
            txtDireccion.Text = IIf(Not IsDBNull(dt(0)("Direccion")), dt(0)("Direccion"), "")
            txtTelefono.Text = IIf(Not IsDBNull(dt(0)("Telefono")), dt(0)("Telefono"), "")
            txtCelular.Text = IIf(Not IsDBNull(dt(0)("Celular")), dt(0)("Celular"), "")
            txtFechaIngreso.Text = IIf(Not IsDBNull(dt(0)("FechaIngreso")), Format(CDate(dt(0)("FechaIngreso")), "dd/MM/yyyy"), "")            
            cboArea.Value = IIf(Not IsDBNull(dt(0)("area")), dt(0)("area"), "")
            RellenaCombo(cboCargo, "TAB007", ":pidtablaƒ:pidelemento▓131ƒ" & cboArea.Value, True)
            cboCargo.Value = IIf(Not IsDBNull(dt(0)("Cargo")), dt(0)("Cargo"), "")
            CboDistrito.Value = IIf(Not IsDBNull(dt(0)("distrito")), dt(0)("distrito"), "")
            cboSexo.Value = IIf(Not IsDBNull(dt(0)("sexo")), dt(0)("sexo"), "")
            txtFechaCese.Text = IIf(Not IsDBNull(dt(0)("FechaCese")), dt(0)("FechaCese"), "")
            txtFecNac.Text = IIf(Not IsDBNull(dt(0)("FechaNacimiento")), dt(0)("FechaNacimiento"), "")
            '----            
            txtAnexo.Text = IIf(Not IsDBNull(dt(0)("Anexo")), dt(0)("Anexo"), "")
            cboCarteraAsterisk.Value = IIf(Not IsDBNull(dt(0)("CarteraAsterisk")), dt(0)("CarteraAsterisk"), "")
            txtMotivoCese.Text = IIf(Not IsDBNull(dt(0)("motivo_cese")), dt(0)("motivo_cese"), "")
            Dim ctlm As New ConDB.Conexion
            Dim dt1 As DataTable = ctlm.Ejecuta_QUERY("Select troncal from anexos where anexo = " & Trim(txtAnexo.Text))
            If Not dt1 Is Nothing Then
                If dt1.Rows.Count > 0 Then
                    txtTipoTroncal.Text = IIf(Not IsDBNull(dt1(0)("troncal")), dt1(0)("troncal"), "")
                End If
            End If
        End Using
    End Sub

    Private Sub btnCerrar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnCerrar.Click
        Response.Redirect("Usuario.aspx")
    End Sub

    Private Sub gvCartera_Boton_Click(ByVal GV As System.Web.UI.WebControls.GridView, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvCartera.Boton_Click
        Dim row = e.Row
        If row.Cells(6).Text = "S" Then
            If row.RowType = DataControlRowType.DataRow Then
                Dim chkRow As CheckBox = TryCast(row.Cells(0).FindControl("ChkBox"), CheckBox)
                chkRow.Checked = True
            End If
        End If
    End Sub

    Private Sub gvCartera_elegirfila(ByVal sender As Object, ByVal e As System.EventArgs, ByVal row As System.Web.UI.WebControls.GridViewRow) Handles gvCartera.elegirfila

    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button1.Click
        Dim Ctl As New Controles.General
        Ctl.BuscarSQL(":usuario▓" & txtUsuario.Text, "QRYU003")
        CtlMensajes1.Mensaje("El usuario ha sido desbloqueado para iniciar session")
    End Sub

    Private Sub cboArea_Click() Handles cboArea.Click
        RellenaCombo(cboCargo, "TAB007", ":pidtablaƒ:pidelemento▓131ƒ" & cboArea.Value, True)
    End Sub

    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button2.Click
        Dim Ctl As New Controles.General
        Ctl.BuscarSQL(":usuario▓" & txtUsuario.Text, "QRYU004")
        CtlMensajes1.Mensaje("El usuario ha sido desbloqueado para iniciar session de gestion")
    End Sub
End Class