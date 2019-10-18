Imports System.Net
Imports System.Net.NetworkInformation
Imports System.Management
Partial Public Class Login
    Inherits System.Web.UI.Page
    Public imgEmpresa As String
    Public imgsize As String
    Public colorLogin As String
    Public colorLogin1 As String
    Public colorLetra As String
    Public imgEmpresa1 As String
    Public tablasize As String
    Public colorFondo As String
    Public conGrupo As String
    Dim conexion As New BL.Cobranza
    Dim Mac As String = ""
    Dim NameMachine As String = ""
    Dim SistemaOperativo As String = ""
    'Private Sub btnIngresar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnIngresar.Click

    'Private Sub usuario_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles usuario.TextChanged
    '    With cboPerfil
    '        .Limpia()
    '        .Procedimiento = "QRYCBP001"
    '        .Condicion = ":pidusuario▓" & usuario.Text
    '        .Cargar_dll()
    '        .Activa = True
    '    End With
    'End Sub

    Private Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click
        usuario.Text = ""
        clave.Text = ""
    End Sub

    Sub Crear_Cookies(ByVal id, ByVal valor)
        '// Creamos elemento HttpCookie con su nombre y su valor
        Response.Cookies.Remove(id)
        Dim addCookie As HttpCookie = New HttpCookie(id, valor)

        '// Si queremos le asignamos un fecha de expiración: mañana
        addCookie.Expires = DateTime.Today.AddDays(1)

        '// Y finalmente ñadimos la cookie a nuestro usuario
        Response.Cookies.Add(addCookie)
    End Sub

    Sub Graba_Login(ByRef dt As DataTable, ByRef dt_perfil As DataTable)
        Try
            Call Crear_Cookies("usuario", usuario.Text)
            Call Crear_Cookies("idusuario", dt.Rows(0)("idusuario"))
            Call Crear_Cookies("Anexo", IIf(IsDBNull(dt.Rows(0)("Anexo")), "0", dt.Rows(0)("Anexo").ToString))
            Call Crear_Cookies("cargo", dt.Rows(0)("cargo"))
            Call Crear_Cookies("NombreUsuario", dt.Rows(0)("Apellidos") & " " & dt.Rows(0)("Nombres"))
            Call Crear_Cookies("TipoUsuario", dt.Rows(0)("TipoUsuario"))
            Call Crear_Cookies("idPerfil", dt_perfil.Rows(0)(0))
            Call Crear_Cookies("NombrePerfil", dt_perfil.Rows(0)(1))
            Call Crear_Cookies("TipoTroncal", IIf(IsDBNull(dt.Rows(0)("TipoTroncal")), "", dt.Rows(0)("TipoTroncal").ToString))
        Catch ex As Exception
        End Try
    End Sub
    Public Sub ValidaUsuarios()
        Dim Dt As New DataTable
        Dim Ctl As New Controles.General
        If Len(Trim(usuario.Text)) > 0 And Len(Trim(clave.Text)) > 0 Then
            Dim valida As Boolean
            Dim DTs As DataTable
            valida = Ctl.Valida_Acceso(usuario.Text, clave.Text, Dt)
            If valida = True Then
                DTs = Ctl.BuscarSQL(":usuario▓" & usuario.Text, "QRYU002")
                'If DTs.Rows(0)(0) > 1 Then
                '    CtlMensajes1.Mensaje("¡El usuario no puede abrir mas de una session, o comuniquese con su supervisor...!")
                '    Response.Redirect("login.aspx")
                '    Exit Sub
                'End If
                DTs = Nothing
                Dim Arrnexo = Split(Ctl.Obtener_Anexo(Dt.Rows(0)("idusuario")), "|")
                Crear_Cookies("TipoTroncal", Arrnexo(1))
                Crear_Cookies("Anexo", Arrnexo(0))
                Dim Anexo = Arrnexo(0)
                Session("usuario") = usuario.Text
                Session("clave") = clave.Text
                Session("idusuario") = Dt.Rows(0)("idusuario")
                Session("cargo") = Dt.Rows(0)("cargo")
                Session("NombreGestor") = Dt.Rows(0)("Apellidos") & " " & Dt.Rows(0)("Nombres")
                Session("TipoUsuario") = Dt.Rows(0)("TipoUsuario")
                Session("Anexo") = IIf(IsDBNull(Dt.Rows(0)("Anexo")), "0", Dt.Rows(0)("Anexo").ToString)
                Session("TipoTroncal") = IIf(IsDBNull(Dt.Rows(0)("TipoTroncal")), "", Dt.Rows(0)("TipoTroncal").ToString)
                Session("TipoGestion") = IIf(IsDBNull(Dt.Rows(0)("TipoGestion")), "", Dt.Rows(0)("TipoGestion").ToString)
                Dim dt_perfil As New DataTable
                dt_perfil = Ctl.BuscarSQL(":pidusuario▓" & usuario.Text, "QRYCBP001")

                If dt_perfil.Rows.Count = 0 Then
                    CtlMensajes1.Mensaje("No se ha encontrado perfil para el usuario ingresado")
                    Exit Sub
                ElseIf dt_perfil.Rows.Count = 1 Then
                    Session("idPerfil") = dt_perfil.Rows(0)(0)
                    Session("NonbrePerfil") = dt_perfil.Rows(0)(1)
                    Call Graba_Login(Dt, dt_perfil)
                    Ctl.BuscarSQL(":usuario▓" & usuario.Text, "QRYU001")
                    If Session("NonbrePerfil") = "GESTOR" Or Session("TipoGestion") = "NORMAL" Then
                        Response.Redirect("Principal.aspx")
                    Else
                        Response.Redirect("Agente.aspx")
                    End If
                Else
                    Response.Redirect("SeleccionPerfil.aspx?usuario=" & usuario.Text)
                End If
            Else
                Session("usuario") = ""
                Session("clave") = ""
                Session("idusuario") = ""
                Session("cargo") = ""
                Session("NombreGestor") = ""
                Session("TipoUsuario") = ""
                Session("idPerfil") = ""
                Session("Anexo") = ""
                CtlMensajes1.Mensaje("Usuario o Contraseña Errada!!, Intente otra vez", "SISTEMA DE GESTIÓN DE COBRANZA")
            End If
        Else
            CtlMensajes1.Mensaje("ESCRIBA LOS DATOS DE USUARIO, CONTRASEÑA Y PERFIL!", "SISTEMA DE GESTIÓN DE COBRANZA")
        End If
    End Sub

    Protected Sub btnIngresar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnIngresar.Click
        Dim Dt As New DataTable
        Dim Ctl As New Controles.General
        Dim DTs As DataTable
        If Len(Trim(usuario.Text)) > 0 And Len(Trim(clave.Text)) > 0 Then
            Dim valida As Boolean
            DTs = Ctl.BuscarSQL(":usuario▓" & usuario.Text, "QRYU002")
            If DTs.Rows.Count > 0 Then
                If Not DTs Is Nothing Then
                    'If DTs.Rows(0)(0) > 0 Then
                    '    CtlMensajes1.Mensaje("¡El usuario no puede abrir mas de una session, o comuniquese con su supervisor...!")
                    '    Exit Sub
                    'End If
                    DTs = Nothing
                    valida = Ctl.Valida_Acceso(usuario.Text, clave.Text, Dt)
                    If valida = True Then
                        Dim Arrnexo = Split(Ctl.Obtener_Anexo(Dt.Rows(0)("idusuario")), "|")
                        Crear_Cookies("TipoTroncal", Arrnexo(1))
                        Crear_Cookies("Anexo", Arrnexo(0))
                        Dim Anexo = Arrnexo(0)
                        Session("usuario") = usuario.Text
                        Session("clave") = clave.Text
                        Session("idusuario") = Dt.Rows(0)("idusuario")
                        Session("cargo") = Dt.Rows(0)("cargo")
                        Session("NombreGestor") = Dt.Rows(0)("Apellidos") & " " & Dt.Rows(0)("Nombres")
                        Session("TipoUsuario") = Dt.Rows(0)("TipoUsuario")
                        Session("Anexo") = IIf(IsDBNull(Dt.Rows(0)("Anexo")), "0", Dt.Rows(0)("Anexo").ToString)
                        Session("TipoTroncal") = IIf(IsDBNull(Dt.Rows(0)("TipoTroncal")), "", Dt.Rows(0)("TipoTroncal").ToString)
                        Dim dt_perfil As New DataTable
                        dt_perfil = Ctl.BuscarSQL(":pidusuario▓" & usuario.Text, "QRYCBP001")
                        If Not dt_perfil Is Nothing Then
                            If dt_perfil.Rows.Count = 0 Then
                                CtlMensajes1.Mensaje("No se ha encontrado perfil para el usuario ingresado")
                                Exit Sub
                            ElseIf dt_perfil.Rows.Count = 1 Then
                                Session("idPerfil") = dt_perfil.Rows(0)(0)
                                Session("NonbrePerfil") = dt_perfil.Rows(0)(1)
                                ObtenerDatos()
                                Call Graba_Login(Dt, dt_perfil)
                                Ctl.BuscarSQL(":usuario▓" & usuario.Text, "QRYU001")

                                Response.Redirect("Principal.aspx")
                            Else
                                Response.Redirect("SeleccionPerfil.aspx?usuario=" & usuario.Text)
                            End If
                        Else
                        End If
                    Else
                        Session("usuario") = ""
                        Session("clave") = ""
                        Session("idusuario") = ""
                        Session("cargo") = ""
                        Session("NombreGestor") = ""
                        Session("TipoUsuario") = ""
                        Session("idPerfil") = ""
                        Session("Anexo") = ""
                        CtlMensajes1.Mensaje("Usuario o Contraseña Errada!!, Intente otra vez", "SISTEMA DE GESTIÓN DE COBRANZA")
                    End If

                Else
                    CtlMensajes1.Mensaje("ESCRIBA LOS DATOS DE USUARIO, CONTRASEÑA Y PERFIL!", "SISTEMA DE GESTIÓN DE COBRANZA")
                End If
            Else
                CtlMensajes1.Mensaje("ESCRIBA LOS DATOS DE USUARIO, CONTRASEÑA Y PERFIL!", "SISTEMA DE GESTIÓN DE COBRANZA")
            End If
        Else
            CtlMensajes1.Mensaje("ESCRIBA LOS DATOS DE USUARIO, CONTRASEÑA Y PERFIL!", "SISTEMA DE GESTIÓN DE COBRANZA")
            End If
    End Sub

    Private Sub usuario_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Usuario.TextChanged
        imgEmpresa = "Estudio-logo-negro.png"
        RellenaCombo(cboEmpresa, "QRYCO001", ":pusuario▓" & CStr(usuario.Text))
        If cboEmpresa.Cbo.Items.Count > 1 Then
            cboEmpresa.Cbo.SelectedIndex = 1
            cboEmpresa.Cbo.Attributes("style") = "Font-Bold:true;Font-size:12"
            'cboEmpresa.Cbo.BackColor = "#F5F6CE"
            'Drawing.Color.Yellow
        Else
            RellenaCombo(cboEmpresa, "QRYCO002", "")
            cboEmpresa.Cbo.SelectedIndex = 0
            cboEmpresa.Cbo.Attributes("style") = "Font-Bold:true;Font-size:12"
            'cboEmpresa.Cbo.BackColor = Drawing.Color.Yellow
        End If
        Crear_Cookies("idcorporacion", cboEmpresa.Value)
        Crear_Cookies("corporacion", cboEmpresa.Text)
    End Sub

    Private Sub RellenaCombo(ByVal Combo As Object, ByVal Procedimiento As String, ByVal Condicion As String, Optional ByVal AP As Boolean = False)
        With Combo
            .Limpia()
            .Procedimiento = Procedimiento
            .Condicion = Condicion
            .Cargar_dll()
            .Activa = True
        End With
    End Sub

    Private Sub cboEmpresa_Click() Handles cboEmpresa.Click
        Crear_Cookies("idcorporacion", cboEmpresa.Value)
        Crear_Cookies("corporacion", cboEmpresa.Text)
        If cboEmpresa.Value = 1 Then
            imgEmpresa = "Estudio-logo-negro.png"
            imgsize = 150
            colorLogin = "2D3B4A"
            imgEmpresa1 = "ImgOpcion1.jpg"
            colorLetra = "white"
            colorFondo = ""
            colorLogin1 = "415162"
            tablasize = "320"
            conGrupo = "curvoG1"
        Else
            imgEmpresa = "logo telecontacto.png"
            imgsize = 300
            imgEmpresa1 = "image008.jpg"
            colorLogin = "FF6700"
            colorLetra = "black"
            colorLogin1 = "FFF2E5"
            colorFondo = ""
            tablasize = "320"
            conGrupo = "curvoG1"
        End If
    End Sub

    Private Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Request.QueryString("Opcion") = "S" Then
            Dim Ctl As New Controles.General
            Dim DTs As DataTable
            DTs = Ctl.BuscarSQL(":usuario▓" & Session("usuario"), "QRYU003")
            Ctl = Nothing
            DTs = Nothing
        End If
        If cboEmpresa.Cbo.Items.Count > 0 Then
            imgEmpresa = "Estudio-logo-negro.png"
            imgsize = 150
            colorLogin = "2D3B4A"
            imgEmpresa1 = "ImgOpcion1.jpg"
            colorLetra = "white"
            colorFondo = ""
            colorLogin1 = "415162"
            tablasize = "320"
            conGrupo = "curvoG1"
        Else
            imgEmpresa = "iniciativa-empresarial.jpg"
            imgsize = 150
            imgEmpresa1 = "DF.gif"
            colorLogin = "2D3B4A"
            colorLetra = "white"
            colorLogin1 = "415162"
            tablasize = "200"
            colorFondo = "white"
            conGrupo = ""
        End If
    End Sub
    'Sub InformacionPC()
    '    '  Dim Nics() As NetworkInterface
    '    'Nics = NetworkInterface.GetAllNetworkInterfaces()
    '    'Mac = Nics(0).GetPhysicalAddress().ToString()
    '    'NameMachine = System.Net.Dns.GetHostEntry(Request.UserHostAddress).HostName


    '    'If IsError(NetworkInterface.GetAllNetworkInterfaces()) = False Then
    '    '    Nics = NetworkInterface.GetAllNetworkInterfaces()
    '    'End If
    '    'If IsError(Nics(0).GetPhysicalAddress().ToString()) = False Then
    '    '    Mac = Nics(0).GetPhysicalAddress().ToString()
    '    'End If
    '    'If IsError(System.Net.Dns.GetHostEntry(Request.UserHostAddress).HostName) = False Then
    '    '    NameMachine = System.Net.Dns.GetHostEntry(Request.UserHostAddress).HostName
    '    'End If


    '    'Nics = NetworkInterface.GetAllNetworkInterfaces()
    '    'Mac = Nics(0).GetPhysicalAddress().ToString()
    '    '        NameMachine = System.Net.Dns.GetHostEntry(Request.UserHostAddress).HostName
    'End Sub
    Private Sub ObtenerDatos()
        Dim dt As New DataTable
        Dim IpMaquina As String = ""
        NameMachine = Request.UserHostName.ToString.Trim
        IpMaquina = Request.UserHostAddress
        'If IsError(Request.UserHostAddress) = False Then
        '    IpMaquina = Request.UserHostAddress
        'End If
        dt = conexion.FunctionConsulta("SELECT idSoporte,IDUSUARIO,FECHAREGISTRO,Estado,IP FROM SOPORTE WITH(NOLOCK) WHERE IDUSUARIO= " & Session("idusuario").ToString.Trim & " AND Estado <> 'E'")
        validarDatosMaquina(dt, NameMachine, IpMaquina, Mac, Session("idusuario").ToString.Trim)
        dt = Nothing
    End Sub
    Sub validarDatosMaquina(ByVal DT As DataTable, ByVal NameMachine As String, ByVal IpMaquina As String, ByVal Mac As String, ByVal idUsuario As String)
        If DT.Rows.Count = 0 Then
            conexion.FunctionGlobal(":IdUsuarioƒ:NameMachineƒ:IpMaquinaƒ:Mac▓" & idUsuario.Trim & "ƒ" & NameMachine.Trim & "ƒ" & IpMaquina.Trim & "ƒ" & Mac.Trim, "QUERYVIC01")
        ElseIf DT.Rows(0)("IP").ToString.Trim <> IpMaquina.Trim And DT.Rows(0)("IdUsuario").ToString.Trim = idUsuario.Trim Then
            conexion.FunctionEjecuta("UPDATE SOPORTE SET ESTADO='E',FechaEliminacion=getdate(),UsuarioElimino='" & idUsuario.Trim & "' WHERE IDSOPORTE='" & DT.Rows(0)("IdSoporte") & "'")
            conexion.FunctionGlobal(":IdUsuarioƒ:NameMachineƒ:IpMaquinaƒ:Mac▓" & idUsuario.Trim & "ƒ" & NameMachine.Trim & "ƒ" & IpMaquina.Trim & "ƒ" & Mac.Trim, "QUERYVIC01")
        End If
    End Sub
    'Function Obtiene_Cookies(ByVal id) As String
    '    '// Recogemos la cookie que nos interese
    '    Dim cogeCookie As HttpCookie = Request.Cookies.Get(id)
    '    Return cogeCookie.Value
    'End Function
End Class
