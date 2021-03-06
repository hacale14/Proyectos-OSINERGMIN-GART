﻿Imports Controles
Imports System.Threading
Imports System.Web.Services
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Data
Imports System.Web.Services.Protocols
Imports System.ComponentModel
Imports ConDB

Partial Public Class Gestion_Predictiva
    Inherits System.Web.UI.Page
    Dim idtelefono As Integer
    Dim conexion As New ConDB.ConSQL
    Public DNI As String
    Public Efectividad As Integer
    Public Cobertura As Integer
    Public CodGestor As String
    Public Pagos As String
    'Public obje As Object
    Public Perfil As String
    Dim TipoDatos As String
    Public Evento As String
    Public IpLlamada As String
    Public StrMensaje As String
    Public ppDNI As String
    Public ppidcliente As Integer
    Public ppidcartera As Integer
    Public ppidagenda As Integer
    Sub Carga_gestion()
        Try
            If Not Me.IsPostBack Then
                Dim dt As DataTable
                Crear_Cookies("Estado", "")
                cbocartera.Condicion = ":criterio▓" & TipoCartera

                cbocartera.Cargar_dll()
                cbocartera.Value = idCartera
                cboCarteraPagos.Condicion = ":criterio▓" & TipoCartera
                cboCarteraPagos.Cargar_dll()
                cboCarteraPagos.Value = idCartera
                cboIndicador.Condicion = ":criterio▓" & ""
                idcliente = Hidcliente.Value
                If Not Me.IsPostBack Then
                    Dim ctl As New Controles.General
                    dt = ctl.FncCliente(idcliente)
                    If Not dt Is Nothing Then
                        idEmpresa = dt(0)("idempresa")
                        idUsuario = dt(0)("idusuarioa")
                        cbocartera.Text = dt(0)("NomCartera")
                        txtnombre.Text = dt(0)("NombreCliente")
                        txtsitua.Text = dt(0)("Situacion")

                        'Dim Anexo = ctl.Obtener_Anexo(Hidusuario.Value)
                        Dim Anexo = Val(Obtiene_Cookies("Anexo"))
                        lblGestor.Text = "USUARIO CONECTADO: " & UCase(Husuario.Value & " - " & HNombreGestor.Value)
                        lblAnexo.Text = "ANEXO: " & Anexo
                        TipoDatos = ""
                        TipoDatos = Obtiene_Cookies("TipoTroncal")
                        lblUuario.Text = "GESTOR ASIGNADO: " & dt(0)("Usuario") & " - " & dt(0)("NomUsu")
                        cbocint.Value = dt(0)("idcondicion")
                        txtDNI.Text = DNI.Clone
                        Dni_Activo = DNI.Clone
                        '----
                        cbotipoc.Limpia()
                        If cbocint.Text = "UT" Or cbocint.Text = "PP" Or cbocint.Text = "LL" Or cbocint.Text = "CO" Or cbocint.Text = "PI" Then
                            cbotipoc.Procedimiento = "SQL_N_GEST006"
                            cbotipoc.Condicion = ":idtabla▓124"
                            cbotipoc.Cargar_dll()
                            cbotipoc.Text = dt(0)("TipoContacto")
                            cbotipoc.Visible = True
                        Else
                            cbotipoc.Visible = False
                        End If
                        '----
                        ctl.ingresa_Telefono(idcliente, Dni_Activo)
                        Dim dta As DataTable = ctl.Obtiene_Datos_adicionales(DNI, idEmpresa)
                        If Not dta Is Nothing Then
                            If dta.Rows.Count > 0 Then
                                txtCentroLaboral.Text = IIf(IsDBNull(dta(0)("centrolaboral")), "", dta(0)("centrolaboral"))
                                txtemail.Text = IIf(IsDBNull(dta(0)("email")), "", dta(0)("email"))
                                txt1erProd.Text = IIf(IsDBNull(dta(0)("Conyugie")), "", dta(0)("Conyugie"))
                                txtEdad.Text = IIf(IsDBNull(dta(0)("Edad")), "", dta(0)("Edad"))
                                txtIngreso.Text = IIf(IsDBNull(dta(0)("Sueldo")), "", dta(0)("Sueldo"))
                                txtAval.Text = IIf(IsDBNull(dta(0)("aval")), "", dta(0)("aval"))
                                txtRepresentanteLegal.Text = IIf(IsDBNull(dta(0)("RepLegal")), "", dta(0)("RepLegal"))
                            End If
                        End If
                        dta = Nothing
                        ''Validar telefonos
                        'Dim telefono As String = IIf(IsDBNull(dt(0)("telefono")), "", dt(0)("telefono"))
                        'Dim telefono1 As String = IIf(IsDBNull(dt(0)("telefono1")), "", dt(0)("telefono1"))
                        'Dim Celular As String = IIf(IsDBNull(dt(0)("celular")), "", dt(0)("celular"))
                        'Dim Celular1 As String = IIf(IsDBNull(dt(0)("celular2")), "", dt(0)("celular2"))
                        'Dim TelfAct As String = IIf(IsDBNull(dt(0)("TelefActi")), "", dt(0)("TelefActi"))
                        'Dim TelfCast As String = IIf(IsDBNull(dt(0)("TelefCast")), "", dt(0)("TelefCast"))
                        'Dim nro As Single = 0
                        'Dim ArrTelefono = Split(telefono, "/")
                        'For Each g In ArrTelefono
                        '    If Len(Trim(g)) > 0 Then
                        '        nro = nro + 1
                        'ctl.Valida_Telefono(idcliente, Trim(g), Dni_Activo, "R")
                        '    End If
                        'Next

                        'ArrTelefono = Split(TelfAct, "/")
                        'For Each g In ArrTelefono
                        '    If Len(Trim(g)) > 0 Then
                        '        nro = nro + 1
                        'ctl.Valida_Telefono(idcliente, Trim(g), Dni_Activo, "R")
                        '    End If
                        'Next
                        'ArrTelefono = Split(TelfCast, "/")
                        'For Each g In ArrTelefono
                        '    If Len(Trim(g)) > 0 Then
                        '        nro = nro + 1
                        '        ctl.Valida_Telefono(idcliente, Trim(g), Dni_Activo, "R")
                        '    End If
                        'Next

                        'ArrTelefono = Split(telefono1, "/")
                        'For Each g In ArrTelefono
                        '    If Len(Trim(g)) > 0 Then
                        '        nro = nro + 1
                        '        ctl.Valida_Telefono(idcliente, Trim(g), Dni_Activo, "R")
                        '    End If
                        'Next
                        'ArrTelefono = Split(Celular, "/")
                        'For Each g In ArrTelefono
                        '    If Len(Trim(g)) > 0 Then
                        '        nro = nro + 1
                        '        ctl.Valida_Telefono(idcliente, Trim(g), Dni_Activo, "R")
                        '    End If
                        'Next
                        'ArrTelefono = Split(Celular1, "/")
                        'For Each g In ArrTelefono
                        '    If Len(Trim(g)) > 0 Then
                        '        nro = nro + 1
                        '        ctl.Valida_Telefono(idcliente, Trim(g), Dni_Activo, "R")
                        '    End If
                        'Next
                        '--- ingresando Direcciones 

                        Call ctl.Valida_Direccion(idcliente, "D", IIf(IsDBNull(dt(0)("Direccion")), "", dt(0)("direccion")), "LIMA", IIf(IsDBNull(dt(0)("NombreProvincia")), "", dt(0)("NombreProvincia")), IIf(IsDBNull(dt(0)("NombreDistrito")), "", dt(0)("NombreDistrito")), 1, "q", "R", TipoCartera)
                        Dim Telefono As Integer = Request.QueryString("Telefono")
                        '  Call ctl.Telefono_grilla(DNI, CtlTelefono)
                        CargarTelefonos(Telefono)

                        Call ctl.Direccion_grilla(dt(0)(0), CtlDireccion)
                        Call ctl.Anotaciones_grilla(dt(0)(0), CtlAnotaciones)
                        Call ctl.Gestion_Campo_grilla(DNI, idEmpresa, CtlGestionCampo)
                        txtDeudaVcdaSoles.Text = 0
                        txtDeudaVcdaCUSD.Text = 0
                        txtDeudaTotalSoles.Text = 0
                        txtDeudaVcdaUSD.Text = 0
                        txtDeudaVcdaCSoles.Text = 0
                        txtDeudaTotalUSD.Text = 0
                        If TipoCartera = "ACTIVA" Then
                            dta = ctl.Deuda_Activa_grilla(dt(0)(0))
                            If Not dta Is Nothing Then
                                If dta.Rows.Count > 0 Then
                                    txt1erProd.Text = IIf(IsDBNull(dta(0)("PRIMERPRODUCTO")), "", dta(0)("PRIMERPRODUCTO"))
                                    For i = 0 To dta.Rows.Count - 1
                                        If dta.Rows(i)("Moneda") = "S" Then
                                            txtDeudaVcdaSoles.Text = dta.Rows(i)("DeudaVencidaSol")
                                            txtDeudaVcdaCUSD.Text = dta.Rows(i)("DeudaVencidaDol")
                                            txtDeudaTotalSoles.Text = dta.Rows(i)("DEUDATOTAL")
                                        ElseIf dta.Rows(i)("Moneda") = "D" Then
                                            txtDeudaVcdaUSD.Text = dta.Rows(i)("DeudaVencidaDol")
                                            txtDeudaVcdaCSoles.Text = dta.Rows(i)("DeudaVencidaSol")
                                            txtDeudaTotalUSD.Text = dta.Rows(i)("DEUDATOTAL")
                                        End If
                                    Next
                                End If
                            End If

                        Else
                            dta = ctl.Deuda_Castigo_grilla(dt(0)(0))
                            For i = 0 To dta.Rows.Count - 1
                                If dta.Rows(i)("Moneda") = "S" Then
                                    txtDeudaVcdaSoles.Text = dta.Rows(i)("TotalK")
                                    txtDeudaVcdaCUSD.Text = Format(txtDeudaVcdaSoles.Text / 3.1, "#,###,###.00")
                                    txtDeudaTotalSoles.Text = dta.Rows(i)("TotalD")
                                ElseIf dta.Rows(i)("Moneda") = "D" Then
                                    txtDeudaVcdaUSD.Text = dta.Rows(i)("TotalK")
                                    txtDeudaVcdaCSoles.Text = Format(txtDeudaVcdaUSD.Text * 3.1, "#,###,###.00")
                                    txtDeudaTotalUSD.Text = dta.Rows(i)("TotalD")
                                End If
                            Next
                        End If
                        dta = Nothing
                        Call ctl.Gestion_Telefono_grilla(DNI, idEmpresa, CtlGestionTelefonica)
                        dt = Nothing
                        txtNroOperacionCompromisoManteniemito.Limpia()
                        If TipoCartera = "ACTIVA" Then
                            txtNroOperacionCompromisoManteniemito.Procedimiento = "SQL_N_GEST034"
                        Else
                            txtNroOperacionCompromisoManteniemito.Procedimiento = "SQL_N_GEST033"
                        End If
                        txtNroOperacionCompromisoManteniemito.Condicion = ":idcliente▓" & idcliente
                        txtNroOperacionCompromisoManteniemito.Cargar_dll()
                    Else
                        If Not Hidusuario.Value <> "" Then
                            CtlMensajes1.Mensaje("El cliente no existe o el dato requiere que se reinicie el sistema, verifique y vuelve a intentar", "")
                        Else
                            CtlMensajes1.Mensaje("EL Cliente no esta asignado, Consulte con su administrador de cuenta y vuelve a intentar", "")
                        End If
                    End If
                Else
                    If Not Hidusuario.Value <> "" Then
                        CtlMensajes1.Mensaje("El cliente no existe o el dato requiere que se reinicie el sistema, verifique y vuelve a intentar", "")
                    Else
                        CtlMensajes1.Mensaje("EL Cliente no esta asignado, Consulte con su administrador de cuenta y vuelve a intentar", "")
                    End If
                End If
            End If
            'Timer1.Interval = 10000
            'Timer1.Enabled = True
        Catch ex As Exception
            CtlMensajes1.Mensaje(ex.Message, "")
        End Try
    End Sub

    Sub CargarTelefonos(ByVal Telefono)
        Dim fnc As New BL.Cobranza
        CtlTelefono.SourceDataTable = fnc.FunctionGlobal(":Telefono▓" & Telefono, "PREDIC02")
    End Sub

    Private Sub CtlTelefono_Boton_Click(ByVal GV As System.Web.UI.WebControls.GridView, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles CtlTelefono.Boton_Click
        Dim COL As Integer = 12
        Dim COL1 As Integer = 19
        If UCase(e.Row.Cells(COL).Text) = "PRIORIDAD" Then
            For c = 5 To e.Row.Cells.Count - 1
                e.Row.Cells(c).Text = UCase(e.Row.Cells(c).Text)
            Next
            e.Row.Cells(COL1).Text = " ACC "
            e.Row.Cells(COL).Text = " EST "
            e.Row.Cells(3).Text = "EL"
            e.Row.Cells(7).Text = "TELEFONOS"
            e.Row.Cells(7).Width = "150"
            e.Row.Cells(15).Width = "750"
            e.Row.Cells(7).Height = "10"
            Exit Sub
        End If
        For c = 5 To e.Row.Cells.Count - 1
            If c = COL Then
                Select Case Trim(e.Row.Cells(c).Text)
                    Case "R"
                        e.Row.Cells(c).Text = "<center><img src='Imagenes/circle_red.png' alt='Smiley face' height='12px' width='10px'></center>"
                    Case "A"
                        e.Row.Cells(c).Text = "<center><img src='Imagenes/circle_yellow.png' alt='Smiley face' height='12px' width='10px'></center>"
                    Case "V"
                        e.Row.Cells(c).Text = "<center><img src='Imagenes/circle_green.png' alt='Smiley face' height='12px' width='10px'></center>"
                    Case "&#254;"
                        e.Row.Cells(c).Text = "<center><img src='Imagenes/circle_green.png' alt='Smiley face' height='12px' width='10px'></center>"
                    Case Else
                        e.Row.Cells(c).Text = "<center><img src='Imagenes/circle_grey.png' alt='Smiley face' height='12px' width='10px'></center>"
                End Select
            End If
            If c = COL1 Then
                Dim ctl As New Controles.General
                'Dim Anexo As
                Dim Anexo = Obtiene_Cookies("Anexo")
                TipoDatos = Obtiene_Cookies("TipoTroncal")
                e.Row.Cells(c).Text = "<center><img src='Imagenes/imgCall3.png' id='imgButton' alt='Smiley face' height='10px' width='10px' ondblclick=LlamarTelefono('" & Anexo & "','" & IIf(TipoDatos = "salidas-ilimitadas", "*", "") & ctl.ValidaNumero(e.Row.Cells(7).Text) & "','imgButton')></center>"
                ctl = Nothing
                '
            End If
            If e.Row.Cells(15).Text = "R" Then
                e.Row.Cells(c).Text = "<b>" & e.Row.Cells(c).Text
            End If
        Next
    End Sub


    Private Sub CtlDireccion_Boton_Click(ByVal GV As System.Web.UI.WebControls.GridView, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles CtlDireccion.Boton_Click
        If e.Row.Cells(6).Text = "Direccion" Then
            e.Row.Cells(6).Width = "400"
            e.Row.Cells(7).Width = "150"
            e.Row.Cells(12).Width = "150"
            e.Row.Cells(13).Width = "150"
            For c = 5 To e.Row.Cells.Count - 1
                e.Row.Cells(c).Text = UCase(e.Row.Cells(c).Text)
            Next
        End If
    End Sub

    Private Sub CtlAnotaciones_Boton_Click(ByVal GV As System.Web.UI.WebControls.GridView, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles CtlAnotaciones.Boton_Click
        If UCase(e.Row.Cells(4).Text) = "FECHA" Then
            e.Row.Cells(4).Width = "100"
            e.Row.Cells(6).Width = "575"
            For c = 5 To e.Row.Cells.Count - 1
                e.Row.Cells(c).Text = UCase(e.Row.Cells(c).Text)
            Next
        Else
            For c = 4 To e.Row.Cells.Count - 1
                'e.Row.Cells(c).Style.Add("BORDER-BOTTOM", "#aaccee 1px solid")
                'e.Row.Cells(c).Style.Add("BORDER-RIGHT", "#aaccee 1px solid")
                'e.Row.Cells(c).Style.Add("padding-left", "1px")
                'e.Row.Cells(c).BackColor = Drawing.Color.FromName("#F9F496")
                'e.Row.Cells(c).ForeColor = Drawing.Color.Black
            Next
        End If
    End Sub

    Private Sub CtlGestionTelefonica_Boton_Click(ByVal GV As System.Web.UI.WebControls.GridView, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles CtlGestionTelefonica.Boton_Click
        Dim l As Integer = 3
        If UCase(e.Row.Cells(l + 1).Text) = "FECHA" Then
            e.Row.Cells(l + 1).Text = "FECHA"
            e.Row.Cells(l + 2).Text = "HORA"
            e.Row.Cells(l + 3).Text = "TIPO"
            e.Row.Cells(l + 4).Text = "OPER."
            e.Row.Cells(l + 5).Text = "IND"
            e.Row.Cells(l + 6).Text = "TELEFONO"
            e.Row.Cells(l + 7).Text = "DESCRIPCION DE LA GESTION"
            e.Row.Cells(l + 8).Text = "USUARIO"

            e.Row.Cells(l + 1).Width = "20"
            e.Row.Cells(l + 2).Width = "40"
            e.Row.Cells(l + 3).Width = "10"
            e.Row.Cells(l + 4).Width = "10"
            e.Row.Cells(l + 5).Width = "10"
            e.Row.Cells(l + 7).Width = "500"
        Else
            If Not e.Row.Cells(l + 1).Text = "&nbsp;" Then : e.Row.Cells(l + 1).Text = Format(CDate(e.Row.Cells(l + 1).Text), "dd/MM/yyyy") : End If
            If Not e.Row.Cells(l + 2).Text = "&nbsp;" Then : e.Row.Cells(l + 2).Text = e.Row.Cells(l + 2).Text : End If
        End If
    End Sub

    Private Sub CtlEstadistica_Boton_Click(ByVal GV As System.Web.UI.WebControls.GridView, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles CtlEstadistica.Boton_Click
        If UCase(e.Row.Cells(4).Text) = "TOTAL" Then
            e.Row.Cells(5).Text = "CANTIDAD"
            e.Row.Cells(6).Text = "(%)COB"
            e.Row.Cells(4).Width = "50"
            e.Row.Cells(5).Width = "50"
            e.Row.Cells(6).Width = "50"
            e.Row.Cells(4).BackColor = System.Drawing.Color.Orange
            e.Row.Cells(5).BackColor = System.Drawing.Color.Orange
            e.Row.Cells(6).BackColor = System.Drawing.Color.Orange

        ElseIf UCase(e.Row.Cells(4).Text) = "META" Then
            e.Row.Cells(4).Text = "<center>META</center>"
            e.Row.Cells(5).Text = "<center>PAGOS</center>"
            e.Row.Cells(6).Text = "<center>(%)EFE</center>"
            e.Row.Cells(4).BackColor = System.Drawing.Color.Orange
            e.Row.Cells(5).BackColor = System.Drawing.Color.Orange
            e.Row.Cells(6).BackColor = System.Drawing.Color.Orange
            e.Row.Cells(4).BackColor = System.Drawing.Color.FromName("#565C54")
            e.Row.Cells(5).BackColor = System.Drawing.Color.FromName("#565C54")
            e.Row.Cells(6).BackColor = System.Drawing.Color.FromName("#565C54")
            e.Row.Cells(4).ForeColor = System.Drawing.Color.White
            e.Row.Cells(5).ForeColor = System.Drawing.Color.White
            e.Row.Cells(6).ForeColor = System.Drawing.Color.White
            e.Row.Cells(4).HorizontalAlign = HorizontalAlign.Center
            e.Row.Cells(5).HorizontalAlign = HorizontalAlign.Center
            e.Row.Cells(6).HorizontalAlign = HorizontalAlign.Center
        Else
            e.Row.Cells(4).BackColor = System.Drawing.Color.White
            e.Row.Cells(5).BackColor = System.Drawing.Color.White
            e.Row.Cells(6).BackColor = System.Drawing.Color.White
            If e.Row.RowIndex = 0 Then
                Cobertura = e.Row.Cells(6).Text
            ElseIf e.Row.RowIndex = 2 Then
                Efectividad = e.Row.Cells(6).Text
            End If
            Dim strScript = "<script>drawGauge();</script>"
            ScriptManager.RegisterStartupScript(Me, Me.GetType, "MyScript1", strScript, True)
            e.Row.Cells(4).Text = "<center>" & e.Row.Cells(4).Text & "<center>"
            e.Row.Cells(5).Text = "<center>" & e.Row.Cells(5).Text & "<center>"
            e.Row.Cells(6).Text = "<center>" & e.Row.Cells(6).Text & "<center>"
        End If
    End Sub

    Private Sub RDBCall_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RDBCall.CheckedChanged
        RDBCampo.Checked = False
        RDBPropuesta.Checked = False
        Call carga_Call()
    End Sub
    Public Sub carga_Call()
        cboIndicador.Limpia()
        cboIndicador.Procedimiento = "SQL_N_GEST032"
        cboIndicador.Condicion = ":tipoƒ:idEmpresa▓TELEFONIAƒ" & idEmpresa
        cboIndicador.Cargar_dll()

        CboGestion.Limpia()
        CboGestion.Procedimiento = "SQL_N_GEST006"
        CboGestion.Condicion = ":idtabla▓118"
        CboGestion.Cargar_dll()
        Tipo_Telefono()
    End Sub
    Private Sub RDBCampo_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RDBCampo.CheckedChanged
        RDBCall.Checked = False
        RDBPropuesta.Checked = False

        cboIndicador.Limpia()
        cboIndicador.Procedimiento = "SQL_N_GEST032"
        cboIndicador.Condicion = ":tipoƒ:idEmpresa▓CARTAƒ" & idEmpresa
        cboIndicador.Cargar_dll()

        CboGestion.Limpia()
        CboGestion.Procedimiento = "SQL_N_GEST006"
        CboGestion.Condicion = ":idtabla▓119"
        CboGestion.Cargar_dll()

    End Sub

    Public Property idcliente() As String
        Get
            Return lblId_Cliente.Text
        End Get
        Set(ByVal value As String)
            lblId_Cliente.Text = value
        End Set
    End Property

    Public Property idEmpresa() As String
        Get
            Return lblId_Empresa.Text
        End Get
        Set(ByVal value As String)
            lblId_Empresa.Text = value
        End Set
    End Property

    Public Property idUsuario() As String
        Get
            Return lblId_Usuario.Text
        End Get
        Set(ByVal value As String)
            lblId_Usuario.Text = value
        End Set
    End Property

    Public Property idCartera() As String
        Get
            Return lblId_Cartera.Text
        End Get
        Set(ByVal value As String)
            lblId_Cartera.Text = value
        End Set
    End Property

    Public Property TipoCartera() As String
        Get
            Return lblTipo_Cartera.Text
        End Get
        Set(ByVal value As String)
            lblTipo_Cartera.Text = value
        End Set
    End Property

    Private Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        
        If Not Me.IsPostBack Then
            'Dim ConSQL As New ConDB.ConSQL
            'Dim IdUsuariocookie As Integer = Obtiene_Cookies(idUsuario)
            'Dim dtPredictivo As DataTable
            'dtPredictivo = ConSQL.FunctionGlobal(":pidUsuario▓" & IdUsuariocookie, "PREDIC03")

            CboHoraProxAcc.Cargar_dll()
            CboMinutoProxAcc.Cargar_dll()
            DNI = Request.QueryString("DNI")
            'Call Crear_Cookies("Dnit", Request.QueryString("DNI"))
            idCartera = Request.QueryString("IdCartera")
            'Call Crear_Cookies("idCartera", Request.QueryString("IdCartera"))

            'Call Crear_Cookies("TelefonoPredictivo", Request.QueryString("Telefono"))
            NumTelf.Value = Request.QueryString("Telefono")
            'Hidusuario.Value = Request.QueryString("Idusuario")
            Hidusuario.Value = Obtiene_Cookies("idusuario")
            HNombreGestor.Value = Obtiene_Cookies("NombreUsuario")
            Husuario.Value = Obtiene_Cookies("usuario")
            Hidcliente.Value = Request.QueryString("idcliente")
            TipoCartera = Request.QueryString("tipocartera")
            Dim tp = Obtiene_Cookies("TipoUsuario")
            'If DNI Is Nothing OrElse DNI = "" Then
            '    Dim dt As New DataTable
            '    conexion = New ConDB.ConSQL
            '    dt = conexion.FunctionGlobal(":pIdCliente▓" & Hidcliente.Value, "PREDIC01")
            '    DNI = dt(0)(0)
            '    Hidusuario.Value = dt(0)(1)
            '    HNombreGestor.Value = dt(0)(2)
            '    Husuario.Value = dt(0)(3)
            '    Hidcliente.Value = dt(0)(5)
            '    TipoCartera = dt(0)(6)
            'End If

            If tp <> "GESTOR" Then
                CtlTelefono.Activa_Delete = True
            End If
            'obje = Session("Parametros" & DNI & idCartera)
            Carga_gestion()
            Dim sendere As Object
            Dim eu As System.EventArgs
            Call form1_Load(sendere, eu)
        End If
        Dim strScript As String = "Efectividad();Cobertura();"
        ScriptManager.RegisterStartupScript(Me, Me.GetType, "Estadistica", strScript, True)
    End Sub

    Private Sub btnCompromisos_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnCompromisos.Click
        cboMonedaCompromisoMantemiento.Limpia()
        cboMonedaCompromisoMantemiento.Condicion = ":idtabla▓105"
        cboMonedaCompromisoMantemiento.Cargar_dll()
        cboMonedaCompromisoMantenimientoA.Limpia()
        cboMonedaCompromisoMantenimientoA.Condicion = ":idtabla▓105"
        cboMonedaCompromisoMantenimientoA.Cargar_dll()
        cboTipoPagoCompromisoMantenimiento.Limpia()
        cboTipoPagoCompromisoMantenimiento.Condicion = ":idtabla▓104"
        cboTipoPagoCompromisoMantenimiento.Cargar_dll()
        lblCompromisos.Text = txtnombre.Text
        pnlCompromisos.Visible = True
        CargarCompromiso()
        txtFechaPagoCompromisoMantenimeinto.Enabled = True
        txtMontoCompromisoMantenimientoA.Enabled = True
    End Sub

    Sub CargarCompromiso()
        Dim ctl As New BL.Cobranza
        Dim dt As New DataTable
        Try
            dt = ctl.FunctionGlobal(":idcliente▓" & idcliente, "SQL_N_GEST026")
            gvCompromisos.SourceDataTable = dt

            Dim PerfilUsuario = Obtiene_Cookies("TipoUsuario")
            If PerfilUsuario <> "GESTOR" Then
                gvCompromisos.Activa_Delete = True
            End If
        Catch ex As Exception
            CtlMensajes1.Mensaje("Ocurrio un error al cargar los compromisos")
        End Try
    End Sub


    Private Sub btnDeuda_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnDeuda.Click
        lblDeudaClienteTitulo.Text = txtnombre.Text
        pnlDeuda.Visible = True
        CargarDeuda()
    End Sub

    Sub CargarDeuda()
        Dim ctl As New BL.Cobranza
        Dim dt As New DataTable
        Try
            If TipoCartera = "ACTIVA" Then
                dt = ctl.FunctionGlobal(":idcliente▓" & idcliente, "SQL_N_GEST028")
            Else
                dt = ctl.FunctionGlobal(":idcliente▓" & idcliente, "SQL_N_GEST029")
            End If
            gvDeuda.SourceDataTable = dt
        Catch ex As Exception
            CtlMensajes1.Mensaje("Ocurrio un error al cargar las deuda")
        End Try
    End Sub

    Private Sub btnInfAdd_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnInfAdd.Click
        pnlInformacionAdicional.Visible = True
        Label18.Text = txtnombre.Text
        CargarInformacionAdicional()
    End Sub

    Sub CargarInformacionAdicional()
        Dim ctl As New BL.Cobranza
        Try
            gvInformacionAdicional.SourceDataTable = prepara_informacion()
        Catch ex As Exception
            CtlMensajes1.Mensaje("Ocurrio un error al cargar la informacion adicional")
        End Try
    End Sub
    Function prepara_informacion() As DataTable
        Dim ctl As New BL.Cobranza
        Dim dt As New DataTable
        Dim table As New DataTable
        Dim column As DataColumn
        Dim row As DataRow
        Try
            dt = ctl.FunctionGlobal(":idcarteraƒ:idclienteƒ:tipo▓" & cbocartera.Text & "ƒ0ƒ1", "SQL_N_GEST025")
            'Cabecera
            If Not dt Is Nothing Then
                Dim FilArr = Split(dt(0)(3), "€")
                For i = 0 To FilArr.Length - 2
                    column = New DataColumn()
                    column.DataType = System.Type.GetType("System.String")
                    column.ColumnName = FilArr(i)
                    table.Columns.Add(column)
                Next
            End If
            dt = Nothing
            ' detalle
            dt = ctl.FunctionGlobal(":idcarteraƒ:idclienteƒ:tipo▓" & cbocartera.Text & "ƒ" & idcliente & "ƒ0", "SQL_N_GEST025")
            'Cabecera
            If Not dt Is Nothing Then
                For i = 0 To dt.Rows.Count - 1
                    Dim FilArr = Split(dt(i)(3), "€")
                    row = table.NewRow()
                    For c = 0 To FilArr.Length - 2
                        row(table.Columns(c)) = FilArr(c)
                    Next
                    table.Rows.Add(row)
                Next
            End If
            dt = Nothing
            Return table
        Catch ex As Exception
            CtlMensajes1.Mensaje("Ocurrio un error al cargar la informacion adicional")
            Return Nothing
        End Try
    End Function
    Public Property Dni_Activo() As String
        Get
            Return lblDni_Activo.Text
        End Get
        Set(ByVal value As String)
            lblDni_Activo.Text = value
        End Set
    End Property

    Private Sub btnPagos_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnPagos.Click
        pnlPagos.Visible = True
        txtDNIPagos.Text = Dni_Activo
        txtClientePagos.Text = txtnombre.Text
        Id_Cliente_Pagos = idcliente
        cboCarteraPagos.Text = cbocartera.Text
        txtFechaInicioPagos.Text = "01/" & Date.Now.ToString("MM/yyyy")
        txtFechaFinPagos.Text = DateTime.DaysInMonth(Date.Now.Year, Date.Now.Month) & "/" & Date.Now.ToString("MM/yyyy")
        CargarPagos()
    End Sub

    Sub CargarPagos()
        Dim ctl As New BL.Cobranza
        Dim dt As New DataTable
        Dim criterio As String = ""
        If cbocartera.Text = cboCarteraPagos.Text Then
            criterio = criterio & " p.IdCliente=" & Id_Cliente_Pagos
        Else
            criterio = criterio & " p.Dni='" & txtDNIPagos.Text & "' and c.IdCartera='" & cboCarteraPagos.Value & "'"
        End If
        If Len(Trim(txtFechaInicioPagos.Text)) <> 0 Then
            criterio = criterio & " and convert(date,p.FechaPago,103)>='" & txtFechaInicioPagos.Text & "'"
        End If
        If Len(Trim(txtFechaFinPagos.Text)) <> 0 Then
            criterio = criterio & " and convert(date,p.FechaPago,103)<='" & txtFechaFinPagos.Text & "'"
        End If
        Try
            dt = ctl.FunctionGlobal(":criterio▓" & criterio, "SQL_N_GEST023")
            gvConsultaPagos.SourceDataTable = dt
        Catch ex As Exception
            CtlMensajes1.Mensaje("Ocurrio un error al cargar los pagos del cliente")
        End Try
    End Sub

    Public Property Id_Cliente_Pagos() As String
        Get
            Return lblIdClientePagos.Text
        End Get
        Set(ByVal value As String)
            lblIdClientePagos.Text = value
        End Set
    End Property

    Private Sub btnCerrarPagos_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCerrarPagos.Click
        pnlPagos.Visible = False
        Crear_Cookies("Estado", "")
    End Sub

    Private Sub btnCarrarInformacionAdicional_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCarrarInformacionAdicional.Click
        pnlInformacionAdicional.Visible = False
    End Sub

    Private Sub btnCerrarCompromisos_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCerrarCompromisos.Click
        pnlCompromisos.Visible = False
    End Sub

    Public Property Id_Propuesta_Activa() As String
        Get
            Return lblId_Propuesta.Text
        End Get
        Set(ByVal value As String)
            lblId_Propuesta.Text = value
        End Set
    End Property

    Private Sub imgGrabarPropuesta_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgGrabarPropuesta.Click
        Dim ctl As New BL.Cobranza

        Evento = Obtiene_Cookies("Estado")
        If Evento = "P" Then Exit Sub
        Crear_Cookies("Estado", "P")
        Try
            If cboEstadoPropuesta.Value = "P" Then
                ctl.FunctionGlobal(":idclienteƒ:dniƒ:nrocuentaƒ:monedaƒ:montopropuestaƒ:fechapropuestaƒ:sustentoƒ:idusuarioƒ:fechaingresoƒ:nrocuotasƒ:estado▓" & _
                                idcliente & "ƒ" & Dni_Activo & "ƒ" & cboOperacionPropuesta.Text & "ƒ" & cboMonedaPropuesta.Value & "ƒ" & txtMontoPropuesta.Text & "ƒ" & txtFechaGeneroPropuesta.Text & "ƒ" & _
                                txtSustentoPropuesta.Text & "ƒ" & idUsuario & "ƒ" & Date.Now.ToString("dd/MM/yyyy") & "ƒ" & txtNroPartesPropuesta.Text & "ƒ" & cboEstadoPropuesta.Value, "SQL_N_GEST027")
                pnlMantenimientoPropuesta.Visible = False
                cargarPropuesta()
            ElseIf cboEstadoPropuesta.Value = "A" Or cboEstadoPropuesta.Value = "R" Then
                If Id_Propuesta_Activa <> "" Then
                    Dim criterio As String
                    If cboEstadoPropuesta.Value = "R" Then
                        criterio = criterio & " ,IdUsuarioPropuesta=" & idUsuario
                    ElseIf cboEstadoPropuesta.Value = "A" Then
                        criterio = criterio & " ,IdUsuarioPropuesta=" & idUsuario
                    End If
                    If chkPagoPropuesta.Checked = True Then
                        criterio = criterio & " ,IdUsuarioPago=" & idUsuario & ",MontoPago='" & txtMontoPropuestaMantenimiento.Text & "',MonedaPago='" & cboMonedaPropuestaMantenimeinto.Value & "',FechaPago='" & txtFechaPagoPropuesta.Text & "'"
                    End If
                    ctl.FunctionGlobal(":montocomprometidoƒ:fecharespuestaƒ:montoaceptadaƒ:monedaƒ:nrocuetasaceptadasƒ:estadoƒ:criterioƒ:idpropuesta▓" & _
                                    txtMontoPropuesta.Text & "ƒ" & txtFechaRespuesta.Text & "ƒ" & txtMontoPropuesta.Text & "ƒ" & cboMonedaPropuesta.Value & "ƒ" & _
                                    txtNroPartesPropuesta.Text & "ƒ" & cboEstadoPropuesta.Value & "ƒ" & criterio & "ƒ" & Id_Propuesta_Activa, "SQL_N_GEST047")
                    pnlMantenimientoPropuesta.Visible = False
                    cargarPropuesta()
                Else
                    CtlMensajes1.Mensaje("El ingreso solo puede ser de tipo pendiente")
                End If
            End If
        Catch ex As Exception
            CtlMensajes1.Mensaje("Ocurrio un error al ingresar la propuesta")
        End Try
    End Sub

    Private Sub btnCerrarDeuda_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCerrarDeuda.Click
        pnlDeuda.Visible = False
    End Sub

    Private Sub gvCompromisos_Nuevo() Handles gvCompromisos.Nuevo
        pnlCompromisoMantenimiento.Visible = True
        imgGrabarCompromisoMantenimiento.Visible = True
        pnlCompromisoMantenimiento.Enabled = True
        txtFechaGeneroCompromisoMantenieminto.Text = Date.Now.ToString("dd/MM/yyyy")
        txtFechaCompromisoMantenimiento.Text = Date.Now.ToString("dd/MM/yyyy")
        txtMontoCompromisoMantenimiento.Text = ""
        chkPagadoCompromisoMantenimiento.Checked = False
        txtMontoCompromisoMantenimientoA.Text = ""
        id_gestion_activa = Hidgestion.Value
        cboMonedaCompromisoMantemiento.Limpia()
        cboMonedaCompromisoMantemiento.Condicion = ":idtabla▓105"
        cboMonedaCompromisoMantemiento.Cargar_dll()
        cboMonedaCompromisoMantenimientoA.Limpia()
        cboMonedaCompromisoMantenimientoA.Condicion = ":idtabla▓105"
        cboMonedaCompromisoMantenimientoA.Cargar_dll()
        cboTipoPagoCompromisoMantenimiento.Limpia()
        cboTipoPagoCompromisoMantenimiento.Condicion = ":idtabla▓104"
        cboTipoPagoCompromisoMantenimiento.Cargar_dll()
        lblId_Compromiso.Text = ""
        Dim ctls As New Controles.General
        If RDBCall.Checked = True Then
            Call ctls.Gestion_Telefono_grilla(Dni_Activo, idEmpresa, CtlGestionTelefonica)
        ElseIf RDBCampo.Checked = True Then
            Call ctls.Gestion_Campo_grilla(Dni_Activo, idEmpresa, CtlGestionCampo)
        End If
        Limpiar_Gestion()
        ' CargarTelefonos(Dni_Activo)
        gvCompromisos.OpocionNuevo = True
        txtFechaPagoCompromisoMantenimeinto.Enabled = True
        txtMontoCompromisoMantenimientoA.Enabled = True
        Crear_Cookies("Estado", "")
    End Sub

    Private Sub gvCompromisos_RowDeleting(ByVal GV As System.Web.UI.WebControls.GridView, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gvCompromisos.RowDeleting
        Dim ctl As New BL.Cobranza
        Dim row As GridViewRow = GV.Rows(e.RowIndex)
        Try
            Dim PerfilUsuario = Obtiene_Cookies("TipoUsuario")
            If PerfilUsuario <> "GESTOR" Then
                ctl.FunctionGlobal(":idcompromiso▓" & row.Cells(14).Text, "SQL_N_GEST031")
                CargarCompromiso()
                CtlMensajes1.Mensaje("El compromisos ha sido eliminado com exito")
            Else
                CtlMensajes1.Mensaje("Error.. usted no tiene permiso para eliminar compromisos, consulte con su administrador")
            End If
        Catch ex As Exception
            CtlMensajes1.Mensaje("Ocurrio un error al eliminar el compromiso, vuelva a intertarlo")
        End Try
    End Sub

    Private Sub gvCompromisos_RowEditing(ByVal GV As System.Web.UI.WebControls.GridView, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs, ByVal row As System.Web.UI.WebControls.GridViewRow) Handles gvCompromisos.RowEditing
        pnlCompromisoMantenimiento.Visible = True
        lblId_Compromiso.Text = row.Cells(14).Text
        txtNroOperacionCompromisoManteniemito.Text = row.Cells(6).Text
        txtMontoCompromisoMantenimiento.Text = row.Cells(7).Text
        txtFechaGeneroCompromisoMantenieminto.Text = Left(row.Cells(4).Text, 10)
        txtFechaCompromisoMantenimiento.Text = Left(row.Cells(5).Text, 10)
        cboTipoPagoCompromisoMantenimiento.Value = row.Cells(9).Text
        cboMonedaCompromisoMantemiento.Value = Mid(row.Cells(8).Text, 1, 1)
        If row.Cells(10).Text = "SI" Then
            txtFechaPagoCompromisoMantenimeinto.Enabled = True
            txtMontoCompromisoMantenimientoA.Enabled = True
            chkPagadoCompromisoMantenimiento.Checked = True
            txtFechaPagoCompromisoMantenimeinto.Text = Left(Replace(row.Cells(11).Text, "&nbsp;", ""), 10)
            txtMontoCompromisoMantenimientoA.Text = Replace(row.Cells(12).Text, "&nbsp;", "")
            cboMonedaCompromisoMantenimientoA.Value = Replace(row.Cells(13).Text, "&nbsp;", "")
            Dim PerfilUsuario = Obtiene_Cookies("TipoUsuario")
            pnlCompromisoMantenimiento.Visible = True
        Else
            chkPagadoCompromisoMantenimiento.Checked = False
        End If
    End Sub

    Private Sub imgCerrarCOmpromisoMantenimiento_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgCerrarCOmpromisoMantenimiento.Click
        '-VERIFICA ANTES DE CERRAR
        CtlMensajes1.Mensaje("El boton esta desactivado por el ingreso compromisos o pago del mismo es obligatorio", "")
        Exit Sub
        If txtFechaGeneroCompromisoMantenieminto.Text = "" Then
            CtlMensajes1.Mensaje("La fecha de registro del compromiso es obligatorio", "")
            Exit Sub
        End If
        If txtFechaCompromisoMantenimiento.Text = "" Then
            CtlMensajes1.Mensaje("La moneda del compromiso es obligatorio", "")
            Exit Sub
        End If
        If cboMonedaCompromisoMantemiento.Text = "" Then
            CtlMensajes1.Mensaje("La moneda del compromiso es obligatorio", "")
            Exit Sub
        End If
        If cboTipoPagoCompromisoMantenimiento.Text = "" Then
            CtlMensajes1.Mensaje("El tipo de pago del compromiso es obligatorio", "")
            Exit Sub
        End If
        If txtMontoCompromisoMantenimiento.Text = "" Then
            CtlMensajes1.Mensaje("El Monto del compromiso es obligatorio", "")
            Exit Sub
        End If

        If chkPagadoCompromisoMantenimiento.Checked Then
            If cboMonedaCompromisoMantenimientoA.Text = "" Then
                CtlMensajes1.Mensaje("moneda de pago del compromiso es obligatorio", "")
                Exit Sub
            End If
            If txtMontoCompromisoMantenimientoA.Text = "" Then
                CtlMensajes1.Mensaje("Monto de pago del compromiso es obligatorio", "")
                Exit Sub
            End If
            If txtFechaPagoCompromisoMantenimeinto.Text = "" Then
                CtlMensajes1.Mensaje("El pago del compromiso es obligatorio", "")
                Exit Sub
            End If
        End If
        pnlCompromisoMantenimiento.Visible = False
    End Sub
    Function Obtiene_Cookies(ByVal id) As String
        '// Recogemos la cookie que nos interese
        Try
            Dim cogeCookie As HttpCookie = Request.Cookies.Get(id)
            Return cogeCookie.Value
        Catch ex As Exception
            Return ""
        End Try
    End Function
    Private Sub imgGrabarCompromisoMantenimiento_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgGrabarCompromisoMantenimiento.Click
        Dim ctl As New BL.Cobranza
        'Evento = Obtiene_Cookies("Estado")
        'If Evento = "P" Then Exit Sub
        'Crear_Cookies("Estado", "P")
        Try

            Dim PerfilUsuario = Obtiene_Cookies("TipoUsuario")

            '----
            If txtFechaGeneroCompromisoMantenieminto.Text = "" Then
                CtlMensajes1.Mensaje("La fecha de registro del compromiso es obligatorio", "")
                Exit Sub
            End If
            If txtFechaCompromisoMantenimiento.Text = "" Then
                CtlMensajes1.Mensaje("La moneda del compromiso es obligatorio", "")
                Exit Sub
            End If
            If cboMonedaCompromisoMantemiento.Text = "" Then
                CtlMensajes1.Mensaje("La moneda del compromiso es obligatorio", "")
                Exit Sub
            End If
            If cboTipoPagoCompromisoMantenimiento.Text = "" Then
                CtlMensajes1.Mensaje("El tipo de pago del compromiso es obligatorio", "")
                Exit Sub
            End If
            If txtMontoCompromisoMantenimiento.Text = "" Then
                CtlMensajes1.Mensaje("El Monto del compromiso es obligatorio", "")
                Exit Sub
            End If
            If cboMonedaCompromisoMantemiento.Text = "" Then
                CtlMensajes1.Mensaje("La moneda del compromiso es obligatorio", "")
                Exit Sub
            End If
            '---
            If chkPagadoCompromisoMantenimiento.Checked Then

                If cboMonedaCompromisoMantenimientoA.Text = "" Then
                    CtlMensajes1.Mensaje("moneda de pago del compromiso es obligatorio", "")
                    Exit Sub
                End If
                If txtMontoCompromisoMantenimientoA.Text = "" Then
                    CtlMensajes1.Mensaje("Monto de pago del compromiso es obligatorio", "")
                    Exit Sub
                End If
                If txtFechaPagoCompromisoMantenimeinto.Text = "" Then
                    CtlMensajes1.Mensaje("El pago del compromiso es obligatorio", "")
                    Exit Sub
                End If
                If txtFechaPagoCompromisoMantenimeinto.Text <> "" And CDate(txtFechaPagoCompromisoMantenimeinto.Text) > Now.Date() Then
                    CtlMensajes1.Mensaje("El pago no puede tener fecha futura", "")
                    Exit Sub
                End If
            End If
            Dim pagado As String = ""
            If chkPagadoCompromisoMantenimiento.Checked = True Then
                pagado = "SI"
            Else
                pagado = "NO"
            End If

            Dim fechapago As String = ""
            Dim moneda As String = ""

            If Trim(txtFechaPagoCompromisoMantenimeinto.Text) = "" Then
                fechapago = "null"
            Else
                fechapago = "'" & txtFechaPagoCompromisoMantenimeinto.Text & "'"
            End If

            If cboMonedaCompromisoMantenimientoA.Value.ToString = "0" Then
                moneda = ""
            Else
                moneda = cboMonedaCompromisoMantenimientoA.Value
            End If
            Dim deudad As Single = 0
            Dim ctln As New Controles.General
            Dim Mensajenopago As String = ""
            Dim cadcartera = "7,28,33,46,50,"
            If idEmpresa = "1" Then
                If InStr(cadcartera, idCartera.Trim & ",") > 0 Then
                    If TipoCartera = "ACTIVA" Then
                        Dim dt As DataTable = ctln.Obtiene_Consulta(":pcriterio▓ cliente.idcliente=" & idcliente & " and Operacion2.NroCuenta ='" & txtNroOperacionCompromisoManteniemito.Text & "'", "SQL_BUSCAR_ACTIVA")
                        If Not dt Is Nothing Then
                            If dt.Rows.Count > 0 Then
                                deudad = dt.Rows(0)("DeudaTotal")
                            End If
                        End If
                    Else
                        Dim dt = ctln.Obtiene_Consulta(":pcriterio▓ cliente.idcliente=" & idcliente & " and Operacion.NroOperacion='" & txtNroOperacionCompromisoManteniemito.Text & "'", "SQL_BUSCAR_CASTIGO")
                        If Not dt Is Nothing Then
                            If dt.Rows.Count > 0 Then
                                deudad = dt.Rows(0)("DeudaTotal")
                            End If
                        End If
                    End If
                    If Val(Trim(txtMontoCompromisoMantenimiento.Text.Replace(",", ""))) < (deudad * (5 / 100)) And Val(txtMontoCompromisoMantenimientoA.Text.Replace(",", "")) < 1 Then
                        Mensajenopago = " pero el importe ingresado es menor al 5% esperado..."
                        'Exit Sub
                    End If
                End If
            End If
            If lblId_Compromiso.Text <> "" Then
                If PerfilUsuario <> "GESTOR" Then
                    ctl.FunctionGlobal(":fechageneroƒ:fechacompromisoƒ:montoƒ:monedaƒ:numoperacionƒ:tipopagoƒ:pagadoƒ:fechapagoƒ:montpagadoƒ:monedpagoƒ:idcompromiso▓" & _
                                txtFechaGeneroCompromisoMantenieminto.Text & "ƒ" & txtFechaCompromisoMantenimiento.Text & "ƒ" & txtMontoCompromisoMantenimiento.Text & "ƒ" & IIf(cboMonedaCompromisoMantemiento.Value = "0", "S", cboMonedaCompromisoMantemiento.Value) & "ƒ" & _
                                txtNroOperacionCompromisoManteniemito.Text & "ƒ" & cboTipoPagoCompromisoMantenimiento.Text & "ƒ" & pagado & "ƒ" & fechapago & "ƒ" & _
                                txtMontoCompromisoMantenimientoA.Text & "ƒ" & IIf(moneda = "0", "S", moneda) & "ƒ" & lblId_Compromiso.Text, "SQL_N_GEST030A")
                Else
                    ctl.FunctionGlobal(":fechageneroƒ:fechacompromisoƒ:montoƒ:monedaƒ:numoperacionƒ:tipopagoƒ:pagadoƒ:fechapagoƒ:montpagadoƒ:monedpagoƒ:idcompromiso▓" & _
                                txtFechaGeneroCompromisoMantenieminto.Text & "ƒ" & txtFechaCompromisoMantenimiento.Text & "ƒ" & txtMontoCompromisoMantenimiento.Text & "ƒ" & IIf(cboMonedaCompromisoMantemiento.Value = "0", "S", cboMonedaCompromisoMantemiento.Value) & "ƒ" & _
                                txtNroOperacionCompromisoManteniemito.Text & "ƒ" & cboTipoPagoCompromisoMantenimiento.Text & "ƒ" & pagado & "ƒ" & fechapago & "ƒ" & _
                                txtMontoCompromisoMantenimientoA.Text & "ƒ" & IIf(moneda = "0", "S", moneda) & "ƒ" & lblId_Compromiso.Text, "SQL_N_GEST030")
                End If
            Else
                ctl.FunctionGlobal(":fechageneroƒ:fechacompromisoƒ:montoƒ:monedaƒ:numoperacionƒ:tipopagoƒ:pagadoƒ:fechapagoƒ:montpagadoƒ:monedpagoƒ:idgestionƒ:idcliente▓" & _
                    txtFechaGeneroCompromisoMantenieminto.Text & "ƒ" & txtFechaCompromisoMantenimiento.Text & "ƒ" & txtMontoCompromisoMantenimiento.Text & "ƒ" & IIf(cboMonedaCompromisoMantemiento.Value = "0", "S", cboMonedaCompromisoMantemiento.Value) & "ƒ" & _
                    txtNroOperacionCompromisoManteniemito.Text & "ƒ" & cboTipoPagoCompromisoMantenimiento.Text & "ƒ" & pagado & "ƒ" & fechapago & "ƒ" & _
                    txtMontoCompromisoMantenimientoA.Text & "ƒ" & IIf(moneda = "0", "S", moneda) & "ƒ" & id_gestion_activa & "ƒ" & idcliente, "SQL_N_GEST035")
            End If

            If txtMontoCompromisoMantenimientoA.Text <> "" Then
                ctl.FunctionGlobal(":pIdClienteƒ:pFechaPagoƒ:pmonedaƒ:pmontoƒ:pconceptoƒ:pnumoperacionƒ:pdniƒ:pidcartera▓" & idcliente & "ƒ" & Replace(fechapago, "'", "") & "ƒ" & IIf(moneda = "0", "S", moneda) & "ƒ" & txtMontoCompromisoMantenimientoA.Text & "ƒ" & "PAGO DEL COMPROMISO" & "ƒ" & txtNroOperacionCompromisoManteniemito.Text & "ƒ" & Dni_Activo & "ƒ" & idCartera, "QRYCP005")
            End If
            pnlCompromisos.Visible = True
            CargarCompromiso()
            pnlCompromisoMantenimiento.Visible = False
            CtlMensajes1.Mensaje("Se grabo correctamente" + Mensajenopago)
        Catch ex As Exception
            CtlMensajes1.Mensaje("Ocrurrio un error al grabar compromiso")
            Crear_Cookies("Estado", "")
        End Try
    End Sub

    Private Sub RDBPropuesta_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RDBPropuesta.CheckedChanged
        cboIndicador.Limpia()
        CboGestion.Limpia()
        RDBCall.Checked = False
        RDBPropuesta.Checked = False
        RDBPropuesta.Checked = True

    End Sub
    Protected Sub btnOne_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim strScript = "Desactivabtn(" & ImageButton4.ID & ");"
        ScriptManager.RegisterStartupScript(Me, Me.GetType, "MyScript", strScript, True)
        'Call ImageButton4_Click(sender, e)
        strScript = "Activarbtn(" & ImageButton4.ID & ");"
        ScriptManager.RegisterStartupScript(Me, Me.GetType, "MyScript", strScript, True)
        
    End Sub
    Private Sub ImageButton4_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButton4.Click

        Dim ctlsvc As New Controles.General
        Dim codindicador As String
        Dim idindicador As String
        Dim id_gestion As String = ""
        Dim dt_gestion As New DataTable
        Dim ctl As New BL.Cobranza
        Dim ctl1 As New ConDB.ConSQL
        'If (Len(Trim(cboIndicador.Text)) = 0 Or Len(Trim(CboGestion.Text)) = 0) And RDBPropuesta.Checked = False Then
        '    CtlMensajes1.Mensaje("Falta seleccionar datos en la gestion")
        'End If

        Evento = Obtiene_Cookies("Estado")
        If Evento = "P" Then
            CtlMensajes1.Mensaje("Falta seleccionar datos en la gestion")
            Response.Cookies("Estado").Expires = Now()
            Exit Sub
        End If
        Crear_Cookies("Estado", "P")
        If ImageButton4.AlternateText = "1" Then Exit Sub
        ImageButton4.AlternateText = "1"
        Try
            If (Len(Trim(cboIndicador.Text)) = 0 Or Len(Trim(CboGestion.Text)) = 0) And RDBPropuesta.Checked = False Then
                CtlMensajes1.Mensaje("Falta seleccionar datos en la gestion")
                Exit Sub
            Else
                Dim dt_semaforo As DataTable
                Dim semafono As String
                Dim propuesta As Boolean

                If RDBPropuesta.Checked = True Then
                    codindicador = "0"
                    idindicador = "0"
                Else
                    Dim array
                    array = Split(cboIndicador.Value, "?")
                    idindicador = array(0)
                    codindicador = array(1)
                    semafono = array(2)
                    If array(3) <> "N" Then
                        propuesta = True
                    Else
                        propuesta = False
                    End If

                    Dim tipo As String = ""
                    If RDBCall.Checked Then
                        tipo = "TELEFONIA"
                    ElseIf RDBCampo.Checked Then
                        tipo = "CARTA"
                    ElseIf RDBCampo.Checked Then
                        tipo = "PROPUESTA"
                    End If
                    telefono_activo = Obtiene_Cookies("TelefonoPredictivo")
                    'telefono_activo = telefono_activo.ToString.Replace("*", "")
                    Dim FechaHora
                    'Dim dtk = ctlsvc.Obtener_Datos_Asterisk("F", "000", "000")
                    'If Not dtk Is Nothing Then
                    '    If dtk.Rows.Count > 0 Then
                    '        FechaHora = dtk.Rows(0)(0)
                    '    End If
                    'End If
                    'dtk = Nothing
                    FechaHora = Now()
                    'Dim FechaHora = Replace(Replace(Replace(ctlsvc.Obtener_Datos_Asterisk("|||||F|"), "|", ""), "@", ""), ".", "")
                    Dim Anexo = Obtiene_Cookies("Anexo")

                    Dim canllamc = 0
                    Dim canllam = 0
                    Dim canllamm = 0
                    Dim respuesta = "PREDICTIVO"
                    Dim fecaill = Format(CDate("01/01/1900 00:00:00"), "dd/MM/yyyy hh:mm:ss")
                    Dim fecafll = Format(CDate("01/01/1900 00:00:00"), "dd/MM/yyyy hh:mm:ss")
                    Dim fecais = Format(CDate("01/01/1900 00:00:00"), "dd/MM/yyyy hh:mm:ss")


                    'dtk = ctlsvc.Obtener_Datos_Asterisk("F", "000", "000")
                    Dim fechasistema
                    'If Not dtk Is Nothing Then
                    ' If dtk.Rows.Count > 0 Then
                    ' fechasistema = dtk.Rows(0)(0)
                    'End If
                    'End If
                    'dtk = Nothing
                    fechasistema = Now()
                    'fechasistema = Replace(Replace(Replace(fechasistema, "|", ""), "@", ""), ".", "")
                    Dim Diferencia
                    If Len(HoraClick.Value) > 6 Then
                        Diferencia = -1 * DateDiff(DateInterval.Second, CDate(HoraClick.Value), Now())
                        FechaHora = Replace(Replace(DateAdd(DateInterval.Second, Diferencia, CDate(fechasistema)), ". ", ""), ".", "")
                    Else
                        Diferencia = 0
                        FechaHora = fechasistema
                    End If

                    'If Val(Trim(telefono_activo)) > 0 Then
                    '    'dtk = ctlsvc.Obtener_Datos_Asterisk("C", Anexo, Format(Now(), "yyyy-MM-dd") & " " & Format(Hour(FechaHora), "00") & "|" & Format(Minute(FechaHora), "00") & "|00")
                    '    dtk = Nothing
                    '    Dim valor
                    '    If Not dtk Is Nothing Then
                    '        If dtk.Rows.Count > 0 Then
                    '            valor = dtk.Rows(0)(0)
                    '            'Dim valor = ctlsvc.Obtener_Datos_Asterisk(Trim(Val(telefono_activo)) & "|" & Anexo & "|" & Hour(FechaHora) & "|" & Minute(FechaHora) & "|" & Second(FechaHora) & "|C")                                
                    '            For i = 0 To dtk.Rows.Count - 1
                    '                If Len(dtk.Rows(i)(1)) = 3 And Len(dtk.Rows(i)(5)) < 4 Then
                    '                    fecais = dtk.Rows(i)(0)
                    '                    canllamc += dtk.Rows(i)(2)
                    '                End If
                    '                If Len(dtk.Rows(i)(5)) > 3 And dtk.Rows(i)(5).ToString.Replace("*", "") = telefono_activo Then
                    '                    fecaill = dtk.Rows(i)(0)
                    '                    fecafll = DateAdd(DateInterval.Second, Val(dtk.Rows(i)(2)), CDate(fecaill))
                    '                    canllam += dtk.Rows(i)(2)
                    '                    canllamm += dtk.Rows(i)(3)
                    '                    respuesta = dtk.Rows(i)(4)
                    '                End If
                    '            Next
                    '        End If
                    '        dtk = Nothing
                    '    End If
                    '    dtk = Nothing
                    'End If
                    'Dim carteraid As String = Obtiene_Cookies("idCartera")
                    ' Dim TelefonoPredictivo As String = Obtiene_Cookies("TelefonoPredictivo")
                    ' CtlMensajes1.Mensaje("prueba")
                    dt_gestion = ctl.FunctionGlobal(":gestionƒ:tipoƒ:detallegestionƒ:idusuarioƒ:idclienteƒ:codindicadorƒ:idindicadorƒ:telefonoƒ:DNIƒ:idcarteraƒ:anexoƒ:fingcallsisƒ:fmarccallastƒ:fllamcallastƒ:ffincallastƒ:ffincallsisƒ:durarƒ:durallƒ:duracƒ:respast▓" & _
                                    txtGestion.Text & "ƒ" & tipo & "ƒ" & CboGestion.Text & "ƒ" & Hidusuario.Value & "ƒ" & idcliente & "ƒ" & codindicador & "ƒ" & idindicador & "ƒ" & Trim(NumTelf.Value) & "ƒ" & Dni_Activo & "ƒ" & Trim(idCartera) & "ƒ" & Anexo & _
                                    "ƒ" & Format(CDate(FechaHora), "dd/MM/yyyy HH:mm:ss") & "ƒ" & Format(CDate(fecais), "dd/MM/yyyy HH:mm:ss") & "ƒ" & Format(CDate(fecaill), "dd/MM/yyyy HH:mm:ss") & "ƒ" & Format(CDate(fecafll), "dd/MM/yyyy HH:mm:ss") & "ƒ" & Format(CDate(fechasistema), "dd/MM/yyyy HH:mm:ss") & "ƒ" & canllamm & "ƒ" & canllam & "ƒ" & canllamc & "ƒ" & respuesta, _
                                    "SQL_N_GEST015")
                    '   CtlMensajes1.Mensaje("Prueba1")
                    If dt_gestion.Rows.Count > 0 Then
                        id_gestion = dt_gestion.Rows(0)(0).ToString
                        dt_semaforo = ctl.FunctionGlobal(":idEmpresaƒ:CodIndicadorƒ:TipoIndicador▓" & idEmpresa & "ƒ" & codindicador & "ƒ" & tipo, "QRYSC001")
                    End If

                    If RDBCall.Checked Then
                        'harry mantenimiento
                        Dim SemaForoAtual As String = ""
                        Dim dtTelf = CtlTelefono.GV
                        For i = 0 To dtTelf.Rows.Count - 1
                            If dtTelf.Rows(i).Cells(7).Text.Trim = telefono_activo.ToString.Trim Then
                                SemaForoAtual = dtTelf.Rows(i).Cells(12).Text.ToString.Trim
                                Exit For
                            End If
                        Next
                        Dim dtIndicadorVal As New DataTable
                        dtIndicadorVal = conexion.Obtiene_dt("SELECT Prioridad FROM Telefonos where dni ='" & Dni_Activo & "'  and telefono ='" & NumTelf.Value & "'", 0)
                        dtTelf = Nothing
                        Select Case dt_semaforo(0)("indSemaforo")
                            Case "P"

                            Case "R"
                                If dtIndicadorVal(0)("Prioridad").ToString <> "V" And dtIndicadorVal(0)("Prioridad").ToString <> "R" Then
                                    ctl.FunctionEjecuta("update telefonos set fecha_actualizacion = getdate(), prioridad = 'R' where  DNI ='" & Dni_Activo & "' and telefono = " & NumTelf.Value)
                                    If Mid(Trim(Val(telefono_activo)), 1, 1) = "9" Or Mid(Trim(Val(telefono_activo)), 1, 1) = "8" Then
                                        ctl.FunctionEjecuta("Update DatosCliente " & _
                                                " set celular= isnull((select top 1 telefono " & _
                                                      " From TelefonoS " & _
                                                     " where Prioridad='þ' " & _
                                                      " and tiptelf ='C' and estado <> 'E' " & _
                                                      " AND TelefonoS.idcliente= DatosCliente.idcliente " & _
                                                      " order by fecha_actualizacion desc),0) " & _
                                                " where idcliente =" & idcliente)
                                    Else
                                        ctl.FunctionEjecuta("Update DatosCliente " & _
                                            " set telefono= isnull((select top 1 telefono " & _
                                                  " From TelefonoS " & _
                                                 " where Prioridad='þ' " & _
                                                  " and tiptelf <>'C' and estado <> 'E' " & _
                                                  " AND TelefonoS.idcliente= DatosCliente.idcliente " & _
                                                  " order by fecha_actualizacion desc),0) " & _
                                            " where idcliente =" & idcliente)
                                    End If
                                End If
                            Case "A"

                                If dtIndicadorVal(0)("Prioridad").ToString <> "V" And dtIndicadorVal(0)("Prioridad").ToString <> "R" Then
                                    ctl.FunctionEjecuta("update telefonos set fecha_actualizacion = getdate(), prioridad = 'A' where  DNI ='" & Dni_Activo & "' and telefono = " & Trim(Val(NumTelf.Value)))
                                End If
                            Case "V"
                                If dtIndicadorVal(0)("Prioridad").ToString <> "V" Or dtIndicadorVal(0)("Prioridad").ToString = "R" Then
                                    ctl.FunctionEjecuta("update telefonos set fecha_actualizacion = getdate(), prioridad = 'V' where DNI ='" & Dni_Activo & "' and telefono = " & Trim(Val(NumTelf.Value)))
                                    If Mid(Trim(Val(telefono_activo)), 1, 1) = "9" Or Mid(Trim(Val(telefono_activo)), 1, 1) = "8" Then
                                        ctl.FunctionEjecuta("Update DatosCliente " & _
                                                " set celular= " & telefono_activo & _
                                                " where idcliente =" & idcliente)
                                    Else
                                        ctl.FunctionEjecuta("Update DatosCliente " & _
                                            " set telefono= " & telefono_activo & _
                                            " where idcliente =" & idcliente)
                                    End If
                                End If
                            Case Else

                        End Select
                    End If
                    'If "PPC" = codindicador Or "PCA" = codindicador Or "PDC" = codindicador Or "PDP" = codindicador Or "PAR" = codindicador Or "PPM" = codindicador Then
                    If dt_semaforo(0)("indPromesa") = "S" Then
                        pnlCompromisoMantenimiento.Visible = True
                        txtFechaGeneroCompromisoMantenieminto.Text = Date.Now.ToString("dd/MM/yyyy")
                        txtFechaCompromisoMantenimiento.Text = Date.Now.ToString("dd/MM/yyyy")
                        txtMontoCompromisoMantenimiento.Text = ""
                        chkPagadoCompromisoMantenimiento.Checked = False
                        txtMontoCompromisoMantenimientoA.Text = ""
                        Hidgestion.Value = id_gestion
                        id_gestion_activa = Hidgestion.Value
                        cboMonedaCompromisoMantemiento.Limpia()
                        cboMonedaCompromisoMantemiento.Condicion = ":idtabla▓105"
                        cboMonedaCompromisoMantemiento.Cargar_dll()
                        cboMonedaCompromisoMantenimientoA.Limpia()
                        cboMonedaCompromisoMantenimientoA.Condicion = ":idtabla▓105"
                        cboMonedaCompromisoMantenimientoA.Cargar_dll()
                        cboTipoPagoCompromisoMantenimiento.Limpia()
                        cboTipoPagoCompromisoMantenimiento.Condicion = ":idtabla▓104"
                        cboTipoPagoCompromisoMantenimiento.Cargar_dll()
                        lblId_Compromiso.Text = ""
                        Dim ctls As New Controles.General
                        If RDBCall.Checked = True Then
                            Call ctls.Gestion_Telefono_grilla(Dni_Activo, idEmpresa, CtlGestionTelefonica)
                        ElseIf RDBCampo.Checked = True Then
                            Call ctls.Gestion_Campo_grilla(Dni_Activo, idEmpresa, CtlGestionCampo)
                        End If
                        Limpiar_Gestion()
                        'CargarTelefonos(Dni_Activo)
                        gvCompromisos.OpocionNuevo = True
                    Else
                        Dim ctls As New Controles.General
                        If RDBCall.Checked = True Then
                            Call ctls.Gestion_Telefono_grilla(Dni_Activo, idEmpresa, CtlGestionTelefonica)
                        ElseIf RDBCampo.Checked = True Then
                            Call ctls.Gestion_Campo_grilla(Dni_Activo, idEmpresa, CtlGestionCampo)
                        End If
                        Limpiar_Gestion()
                        'CargarTelefonos(Dni_Activo)
                        CtlMensajes1.Mensaje("Se ha grabado la gestion satisfactoriamente")
                        Dim dt = ctls.Obtiene_Consulta(":idusuario▓" & Obtiene_Cookies("idusuario"), "GES008")
                        If Not dt Is Nothing Then
                            For i = 0 To dt.rows.count - 1
                                Crear_Cookies("ppDNI", dt.ROWS(i)("dni"))
                                Crear_Cookies("ppidcartera", dt.ROWS(i)("idcartera"))
                                Crear_Cookies("ppidcliente", dt.ROWS(i)("idcliente"))
                                Crear_Cookies("ppidagenda", dt.ROWS(i)("idagenda"))
                                txtAnotacionMensaje.BackColor = Drawing.Color.Yellow
                                txtAnotacionMensaje.Text = "!ALERTA...! TIENES UNA PROXIMA GESTION PENDIENTE" & vbCrLf
                                txtAnotacionMensaje.Text &= "================================================" & vbCrLf
                                txtAnotacionMensaje.Text &= "Fecha y Hora : " & dt.rows(i)(2) & vbCrLf
                                txtAnotacionMensaje.Text &= "Mensaje      : " & dt.rows(i)("anotacion")
                                PnlMensajeAlerta.Visible = True
                                Exit For
                            Next
                        End If
                    End If
                End If

            End If
            NumTelf.Value = ""
            ImageButton4.Enabled = True
            pnlmarcatelf.Visible = False
            Dim dtIndicador As New DataTable
            dtIndicador = conexion.Obtiene_dt("SELECT TipoContacto FROM INDICADOR WHERE  IdIndicador='" & idindicador & "'  AND  CodIndicador='" & codindicador & "'", 0)
            Call Crear_Cookies("TipoContactoPredictivo", (dtIndicador(0)("TipoContacto").ToString))
            dtIndicador = Nothing
        Catch ex As Exception
            CtlMensajes1.Mensaje("Ocurrio un error al grabar" & ex.Message)
            If Not dt_gestion Is Nothing Then
                If dt_gestion.Rows.Count > 0 Then
                    id_gestion = dt_gestion.Rows(0)(0).ToString
                    ctl.FunctionGlobal(":idgestion▓" & id_gestion, "SQL_D_GEST015")
                End If
            End If
            ImageButton4.Enabled = True
            Crear_Cookies("Estado", "")
        End Try


    End Sub


    Sub Limpiar_Gestion()
        CboGestion.Text = ""
        cboIndicador.Value = ""
        RDBCall.Checked = False
        RDBCampo.Checked = False
        RDBPropuesta.Checked = False
        txtGestion.Text = ""
    End Sub

    Public Property id_gestion_activa() As String
        Get
            Return lblId_Gestion.Text
        End Get
        Set(ByVal value As String)
            lblId_Gestion.Text = value
        End Set
    End Property

    Public Property telefono_activo()
        Get
            Return lblTelefono_Activo.Text
        End Get
        Set(ByVal value)
            lblTelefono_Activo.Text = value
        End Set
    End Property

    Public Property Tipo_Mantenimiento_Telefono() As String
        Get
            Return lblTipoTelefonoMantenieminto.Text
        End Get
        Set(ByVal value As String)
            lblTipoTelefonoMantenieminto.Text = value
        End Set
    End Property


    Sub CargarComboTelefonoMantenimeinto()
        cboContactoTelefono.Procedimiento = "SQL_N_GEST080"
        cboContactoTelefono.Condicion = ":idtablaƒ:condicion▓121ƒAND SUBSTRING(IDElemento, 1, 2) =" & Format(Val(idEmpresa), "00")
        cboContactoTelefono.Limpia()
        cboContactoTelefono.Cargar_dll()
        cboViaTelefono.Limpia()
        cboViaTelefono.Cargar_dll()
    End Sub

    Private Sub CtlTelefono_elegirfila(ByVal sender As Object, ByVal e As System.EventArgs, ByVal row As System.Web.UI.WebControls.GridViewRow) Handles CtlTelefono.elegirfila
        telefono_activo = row.Cells(5).Text
    End Sub

    Private Sub CtlTelefono_Nuevo() Handles CtlTelefono.Nuevo
        CargarComboTelefonoMantenimeinto()
        pnlMantenimeintoTelefono.Visible = True
        Tipo_Mantenimiento_Telefono = "N"
        txtNumeroTelefono.Text = ""
        txtOrigenTelefono.Text = ""
    End Sub

    Private Sub CtlTelefono_RowDeleting(ByVal GV As System.Web.UI.WebControls.GridView, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles CtlTelefono.RowDeleting
        Dim ctl As New BL.Cobranza
        Dim row As GridViewRow = GV.Rows(e.RowIndex)
        Numero_ant = row.Cells(7).Text
        txtNumeroTelefono.Text = row.Cells(7).Text
        Try
            Dim PerfilUsuario = Obtiene_Cookies("TipoUsuario")
            If PerfilUsuario <> "GESTOR" Then
                ctl.FunctionGlobal(":dniƒ:telefono▓" & txtDNI.Text & "ƒ" & txtNumeroTelefono.Text, "SQL_N_GEST058")
                ' CargarTelefonos(txtDNI.Text)
                CtlMensajes1.Mensaje("El telefono ha sido eliminado con exito")
            Else
                CtlMensajes1.Mensaje("Error.. usted no tiene permiso para eliminar telefonos, consulte con su administrador")
            End If
        Catch ex As Exception
            CtlMensajes1.Mensaje("Ocurrio un error al eliminar el telefono, vuelva a intertarlo")
        End Try
    End Sub

    Private Sub CtlTelefono_RowEditing(ByVal GV As System.Web.UI.WebControls.GridView, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs, ByVal row As System.Web.UI.WebControls.GridViewRow) Handles CtlTelefono.RowEditing
        Try
            CargarComboTelefonoMantenimeinto()
            pnlMantenimeintoTelefono.Visible = True
            'telefono_activo = row.Cells(7).Text
            Numero_ant = row.Cells(7).Text
            txtNumeroTelefono.Text = row.Cells(7).Text
            cboContactoTelefono.Text = row.Cells(15).Text
            txtOrigenTelefono.Text = row.Cells(18).Text
            cboViaTelefono.Value = row.Cells(6).Text
        Catch ex As Exception
        End Try
    End Sub


    Private Sub CtlTelefono_Seleccionarfila(ByVal sender As Object, ByVal e As System.EventArgs, ByVal row As System.Web.UI.WebControls.GridViewRow) Handles CtlTelefono.Seleccionarfila
        telefono_activo = row.Cells(7).Text
        Tipo_Telefono()
    End Sub

    Private Sub ImageButton2_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButton2.Click
        Dim ctl As New BL.Cobranza
        Try
            ctl.FunctionGlobal(":idcarteraƒ:idcondicionƒ:situacionƒ:tipocontactoƒ:idcliente▓" & _
                               idCartera & "ƒ" & cbocint.Value & "ƒ" & txtsitua.Text & "ƒ" & cbotipoc.Text & "ƒ" & idcliente, "SQL_N_GEST036")
        Catch ex As Exception
        End Try
        Dim contactabilidad As String = Obtiene_Cookies("TipoContactoPredictivo")
        Dim url As String = ""
        If Trim(contactabilidad) = "CEF" Then
            'Dim javascript As String = ""
            'javascript = "<script type='text/javascript'>"
            'javascript += "function redireccionar(){"
            'javascript += " window.location='http://192.168.2.11/inactivacliente.php?id_cliente=" & idcliente & "';"
            'javascript += "}"
            'javascript += "</script>"
            'ScriptManager.RegisterStartupScript(Me, Me.GetType, "redireccionar", javascript, True)
            url = "http://192.168.2.11/inactivacliente.php?id_cliente=" & idcliente
            Response.Redirect(url)
        End If
        Thread.Sleep(1000)
        url = ""
        url = "http://192.168.2.11/despausaragente.php?agente=" & Husuario.Value
        Response.Redirect(url)
        'url = ""
        'url = "http://192.168.2.11/predictivo/agente/inicio.php"
        'Response.Redirect(url, False)
    End Sub

    Sub Tipo_Telefono()
        If RDBCall.Checked = True Then
            If Left(NumTelf.Value, 1) = "9" Then
                CboGestion.Text = "CELULAR"
            Else
                CboGestion.Text = "TELEF. FIJO"
            End If
        End If
    End Sub


    Private Sub btnAceptarTelefono_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAceptarTelefono.Click
        Try
            Dim ctl As New BL.Cobranza
            Dim tipotelefono As String

            If Tipo_Mantenimiento_Telefono = "N" Then
                If Left(Trim(txtNumeroTelefono.Text), 1) = "9" Then
                    tipotelefono = "C"
                Else
                    tipotelefono = "F"
                End If
                ctl.FunctionGlobal(":idclienteƒ:tipotelefonoƒ:viatelefonoƒ:telefonoƒ:prioridadƒ:contactoƒ:dniƒ:origen▓" & _
                                   idcliente & "ƒ" & tipotelefono & "ƒ" & Mid(cboViaTelefono.Text, 1, 1) & "ƒ" & txtNumeroTelefono.Text & "ƒ" & _
                                   "Pƒ" & cboContactoTelefono.Text & "ƒ" & Dni_Activo & "ƒ" & txtOrigenTelefono.Text, "SQL_N_GEST045")
                CtlMensajes1.Mensaje("Se grabo satisfactoriamente")
            Else
                If Left(Trim(txtNumeroTelefono.Text), 1) = "9" Then
                    tipotelefono = "C"
                Else
                    tipotelefono = "F"
                End If
                ctl.FunctionGlobal(":numero_nuevoƒ:contactoƒ:origenƒ:viatelefonoƒ:idclienteƒ:numero_antiguoƒ:dni▓" & txtNumeroTelefono.Text & "ƒ" & cboContactoTelefono.Text & "ƒ" & _
                                    txtOrigenTelefono.Text & "ƒ" & Mid(cboViaTelefono.Text, 1, 1) & "ƒ" & idcliente & "ƒ" & Numero_ant & "ƒ" & Dni_Activo, "SQL_N_GEST046")
                CtlMensajes1.Mensaje("Se grabo satisfactoriamente")
            End If
            pnlMantenimeintoTelefono.Visible = False
            ' CargarTelefonos(Dni_Activo)
            '   Crear_Cookies("Estado", "")
        Catch ex As Exception
            CtlMensajes1.Mensaje("Ocurrio un error al grabar")
        End Try
    End Sub

    Public Property Numero_ant() As String
        Get
            Return lblNumero_Activo.Text
        End Get
        Set(ByVal value As String)
            lblNumero_Activo.Text = value
        End Set
    End Property

    Private Sub btnCancelaTelefono_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancelaTelefono.Click
        pnlMantenimeintoTelefono.Visible = False
    End Sub

    Private Sub imgBuscarPagos_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgBuscarPagos.Click
        CargarPagos()
    End Sub

    Private Sub btnCerrarPropuesta_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCerrarPropuesta.Click
        pnlPropuesta.Visible = False
    End Sub

    Private Sub gvPropuesta_Nuevo() Handles gvPropuesta.Nuevo
        pnlMantenimientoPropuesta.Visible = True
        CargarPropuestaMantenieminto()
        cboEstadoPropuesta.Text = "Pendiente"
        txtFechaGeneroPropuesta.Text = Date.Now.ToString("dd/MM/yyyy")
        txtFechaRespuesta.Text = Date.Now.ToString("dd/MM/yyyy")
        txtFechaPagoPropuesta.Text = Date.Now.ToString("dd/MM/yyyy")
        txtMontoPropuesta.Text = ""
        txtMontoPropuestaMantenimiento.Text = ""
        txtSustentoPropuesta.Text = ""
        txtNroPartesPropuesta.Text = ""
    End Sub

    Sub CargarPropuestaMantenieminto()
        cboEstadoPropuesta.Limpia()
        cboEstadoPropuesta.Cargar_dll()
        cboMonedaPropuesta.Limpia()
        cboMonedaPropuesta.Cargar_dll()
        cboMonedaPropuestaMantenimeinto.Limpia()
        cboMonedaPropuestaMantenimeinto.Cargar_dll()
        If TipoCartera = "ACTIVA" Then
            cboOperacionPropuesta.Procedimiento = "SQL_N_GEST034"
        Else
            cboOperacionPropuesta.Procedimiento = "SQL_N_GEST033"
        End If
        cboOperacionPropuesta.Condicion = ":idcliente▓" & idcliente
        cboOperacionPropuesta.Limpia()
        cboOperacionPropuesta.Cargar_dll()
    End Sub

    Sub cargarPropuesta()
        Dim ctl As New BL.Cobranza
        Dim dt As New DataTable
        Try
            dt = ctl.FunctionGlobal(":dni▓" & Dni_Activo, "SQL_N_GEST048")
            gvPropuesta.SourceDataTable = dt
        Catch ex As Exception
            CtlMensajes1.Mensaje("Ocurrio un error al cargar propuestas")
        End Try
    End Sub

    Private Sub imgPropuesta_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgPropuesta.Click
        pnlPropuesta.Visible = True
        cargarPropuesta()
    End Sub

    Private Sub imgCerrarPropuesta_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgCerrarPropuesta.Click
        pnlMantenimientoPropuesta.Visible = False
    End Sub

    Private Sub gvPropuesta_RowEditing(ByVal GV As System.Web.UI.WebControls.GridView, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs, ByVal row As System.Web.UI.WebControls.GridViewRow) Handles gvPropuesta.RowEditing
        pnlMantenimientoPropuesta.Visible = True
        txtFechaGeneroPropuesta.Enabled = True
        txtFechaPagoPropuesta.Enabled = True
        txtFechaRespuesta.Enabled = True
        CargarPropuestaMantenieminto()
        Id_Propuesta_Activa = row.Cells(4).Text
        txtFechaGeneroPropuesta.Text = Left(row.Cells(13).Text, 10)
        cboEstadoPropuesta.Value = row.Cells(15).Text
        cboOperacionPropuesta.Value = row.Cells(7).Text
        txtNroPartesPropuesta.Text = row.Cells(14).Text
        txtMontoPropuesta.Text = row.Cells(9).Text
        cboMonedaPropuesta.Text = row.Cells(8).Text
        txtSustentoPropuesta.Text = row.Cells(11).Text
        txtFechaPagoPropuesta.Text = Left(row.Cells(21).Text, 10)
        txtFechaRespuesta.Text = Left(row.Cells(17).Text, 10)
        If txtFechaPagoPropuesta.Text <> "" Then
            chkPagoPropuesta.Checked = True
            txtMontoPropuestaMantenimiento.Text = row.Cells(22).Text
            cboMonedaPropuestaMantenimeinto.Text = row.Cells(23).Text
        End If
    End Sub


    Function ColocarTelefono(ByVal telef As String) As String
        telefono_activo = telef
        Return ""
    End Function


    Private Sub CtlDireccion_Nuevo() Handles CtlDireccion.Nuevo
        pnlMantenimientoDireccion.Visible = True
        tipo_direccion = "N"
        CargarCombosDireccion()
    End Sub

    Sub CargarCombosDireccion()
        With cboDepartamentoMantenimietoDireccion
            .Limpia()
            .Cargar_dll()
        End With
        With cboTipoMantenimietoDireccion
            .Limpia()
            .Cargar_dll()
        End With
        cbotipoDireccion1.Limpia()
        cbotipoDireccion1.Procedimiento = "SQL_N_GEST006"
        cbotipoDireccion1.Condicion = ":idtabla▓125"
        cbotipoDireccion1.Cargar_dll()
        cboCondVivienda.Limpia()
        cboCondVivienda.Procedimiento = "SQL_N_GEST006"
        cboCondVivienda.Condicion = ":idtabla▓126"
        cboCondVivienda.Cargar_dll()
    End Sub


    Private Sub cboDepartamentoMantenimietoDireccion_Click() Handles cboDepartamentoMantenimietoDireccion.Click
        With cboProvinciaMantenimietoDireccion
            .Limpia()
            .Condicion = ":cod▓" & cboDepartamentoMantenimietoDireccion.Value
            .Cargar_dll()
        End With
    End Sub


    Private Sub cboProvinciaMantenimietoDireccion_Click() Handles cboProvinciaMantenimietoDireccion.Click
        With cboDistritoMantenimientoDireccion
            .Limpia()
            .Condicion = ":cod▓" & cboProvinciaMantenimietoDireccion.Value
            .Cargar_dll()
        End With
    End Sub

    Public Property id_direccion_activa() As String
        Get
            Return lblId_Direccion_Activa.Text
        End Get
        Set(ByVal value As String)
            lblId_Direccion_Activa.Text = value
        End Set
    End Property

    Public Property tipo_direccion() As String
        Get
            Return lblTipo_Mantenimiento_Direccion.Text
        End Get
        Set(ByVal value As String)
            lblTipo_Mantenimiento_Direccion.Text = value
        End Set
    End Property

    Private Sub btnAceptarMantenimietoDireccion_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAceptarMantenimietoDireccion.Click
        Try
            Dim ctl As New BL.Cobranza
            Dim Control As New Controles.General
            If tipo_direccion = "N" Then
                ctl.FunctionGlobal(":idclienteƒ:departamentoƒ:distritoƒ:provinciaƒ:direccionƒ:tipoƒ:TipoDireccionƒ:CondVivienda▓" & _
                          idcliente & "ƒ" & cboDepartamentoMantenimietoDireccion.Text & "ƒ" & cboDistritoMantenimientoDireccion.Text & "ƒ" & cboProvinciaMantenimietoDireccion.Text & "ƒ" & txtDireccionMantenimietoDireccion.Text & "ƒ" & cboTipoMantenimietoDireccion.Value & "ƒ" & cbotipoDireccion1.Value & "ƒ" & cboCondVivienda.Value, "SQL_N_GEST013")
            ElseIf tipo_direccion = "M" Then
                If id_direccion_activa <> "" Then
                    ctl.FunctionGlobal(":departamentoƒ:provinciaƒ:distritoƒ:direccionƒ:tipoƒ:iddireccionƒ:TipoDireccionƒ:CondVivienda▓" & _
                          cboDepartamentoMantenimietoDireccion.Text & "ƒ" & cboProvinciaMantenimietoDireccion.Text & "ƒ" & cboDistritoMantenimientoDireccion.Text & "ƒ" & txtDireccionMantenimietoDireccion.Text & "ƒ" & cboTipoMantenimietoDireccion.Value & "ƒ" & id_direccion_activa & "ƒ" & cbotipoDireccion1.Value & "ƒ" & cboCondVivienda.Value, "SQL_N_GEST011")
                Else
                    CtlMensajes1.Mensaje("No se selecciono una direccion, actualize y vuelva a intentarlo")
                End If
            End If
            pnlMantenimientoDireccion.Visible = False
            Call Control.Direccion_grilla(idcliente, CtlDireccion)
        Catch ex As Exception
            CtlMensajes1.Mensaje("Ocurrio un error al guardar la direccion, vuelva a intentarlo")
        End Try
    End Sub

    Private Sub CtlDireccion_RowDeleting(ByVal GV As System.Web.UI.WebControls.GridView, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles CtlDireccion.RowDeleting
        If GV.Rows(e.RowIndex).Cells(GV.Rows(e.RowIndex).Cells.Count - 1).Text <> "R" Then
            Dim ctl As New Controles.General
            Call ctl.eliimina_Direccion(Val(GV.Rows(e.RowIndex).Cells(4).Text))
            Call ctl.Direccion_grilla(Val(GV.Rows(e.RowIndex).Cells(5).Text), CtlDireccion)
            ctl = Nothing
            CtlMensajes1.Mensaje("La Direccion fue eliminado con exito", "")
        Else
            CtlMensajes1.Mensaje("La Direccion no puede ser eliminado por ser informacion reservada", "")
        End If
    End Sub

    Private Sub CtlDireccion_RowEditing(ByVal GV As System.Web.UI.WebControls.GridView, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs, ByVal row As System.Web.UI.WebControls.GridViewRow) Handles CtlDireccion.RowEditing
        Try
            pnlMantenimientoDireccion.Visible = True
            CargarCombosDireccion()
            id_direccion_activa = row.Cells(4).Text
            CtlMensajes1.Mensaje(row.Cells(4).Text)
            cboDepartamentoMantenimietoDireccion.Text = row.Cells(13).Text
            Call cboDepartamentoMantenimietoDireccion_Click()
            cboProvinciaMantenimietoDireccion.Text = row.Cells(12).Text
            Call cboProvinciaMantenimietoDireccion_Click()
            cboDistritoMantenimientoDireccion.Text = row.Cells(7).Text
            txtDireccionMantenimietoDireccion.Text = row.Cells(6).Text
            cboTipoMantenimietoDireccion.Value = row.Cells(16).Text
            cbotipoDireccion1.Limpia()
            cbotipoDireccion1.Procedimiento = "SQL_N_GEST006"
            cbotipoDireccion1.Condicion = ":idtabla▓125"
            cbotipoDireccion1.Cargar_dll()
            cbotipoDireccion1.Value = row.Cells(17).Text
            cboCondVivienda.Limpia()
            cboCondVivienda.Procedimiento = "SQL_N_GEST006"
            cboCondVivienda.Condicion = ":idtabla▓126"
            cboCondVivienda.Cargar_dll()
            cboCondVivienda.Value = row.Cells(18).Text
            tipo_direccion = "M"
        Catch ex As Exception
            CtlMensajes1.Mensaje("No se seleciono una direccion, vuelva a intentarlo")
        End Try
    End Sub

    Private Sub btnCancelarMantenimietoDireccion_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancelarMantenimietoDireccion.Click
        pnlMantenimientoDireccion.Visible = False
    End Sub

    Private Sub CtlAnotaciones_RowEditing(ByVal GV As System.Web.UI.WebControls.GridView, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs, ByVal row As System.Web.UI.WebControls.GridViewRow) Handles CtlAnotaciones.RowEditing
        pnlAnotaciones.Visible = True
        lblIndexAnotacion.Text = e.NewEditIndex
        txtAnotacionNueva.Text = GV.Rows(e.NewEditIndex).Cells(6).Text
    End Sub


    Private Sub btnAceptarAnotacion_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAceptarAnotacion.Click
        Dim ctl As New BL.Cobranza
        Dim control As New Controles.General
        Try
            Dim dt As New DataTable
            dt = CtlAnotaciones.Datos
            Dim filanuevas As String = ""
            Dim ingreso_anotacion As String = ""
            filanuevas = Date.Now.ToString("dd/MM/yyyy hh:mm:ss") & "|@" & Husuario.Value & "|@" & txtAnotacionNueva.Text.Replace("|@", "") & "|@|@@"

            Dim arreglo As String()
            ReDim arreglo(3)

            For i = 0 To dt.Rows.Count - 1
                For y = 0 To dt.Columns.Count - 1
                    arreglo(i) = arreglo(i) & dt.Rows(i)(y) & "|@"
                Next
                arreglo(i) = arreglo(i) & "|@@"
            Next

            If lblIndexAnotacion.Text = "0" Then
                arreglo(0) = filanuevas
            ElseIf lblIndexAnotacion.Text = "1" Then
                arreglo(1) = filanuevas
            ElseIf lblIndexAnotacion.Text = "2" Then
                arreglo(2) = filanuevas
            End If

            For i = 0 To 2
                ingreso_anotacion = ingreso_anotacion & arreglo(i)
            Next
            'CtlMensajes1.Mensaje(ingreso_anotacion)
            ctl.FunctionGlobal(":idclienteƒ:mensaje▓" & idcliente & "ƒ" & ingreso_anotacion, "SQL_N_GEST049")
            CtlMensajes1.Mensaje("Se registro con exito")
            pnlAnotaciones.Visible = False
            Call control.Anotaciones_grilla(idcliente, CtlAnotaciones)
        Catch ex As Exception
            CtlMensajes1.Mensaje("Ocurrio un error" & ex.Message)
            pnlAnotaciones.Visible = False
        End Try
    End Sub

    Private Sub btnCancelarAnotacion_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancelarAnotacion.Click
        pnlAnotaciones.Visible = False
    End Sub

    Private Sub NumTelf_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles NumTelf.ValueChanged
        If NumTelf.Value.Length > 3 Then
            RDBCall.Checked = True
        End If
    End Sub

    Public Function ActivarRaB() As String
        'implementation code        
        RDBCall.Checked = True
        Return ""
    End Function

    Private Sub form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles form1.Load
        If Not Me.IsPostBack Then
            If 0 = 0 Then
                'en este caso lanzamos un alert            
                ActivarRaB()
                carga_Call()
                pnlmarcatelf.Visible = False
                lblNunmTelfC.Text = NumTelf.Value
                ImageButton4.AlternateText = ""
                Crear_Cookies("Estado", "")
            Else
                pnlmarcatelf.Visible = False
            End If
            Dim PerfilUsuario = Obtiene_Cookies("TipoUsuario")
            If PerfilUsuario <> "GESTOR" Then
                CtlGestionTelefonica.Activa_Delete = True
                CtlGestionCampo.Activa_Delete = True
            End If
            Dim idPerfil = Obtiene_Cookies("idPerfil")
            If idPerfil = "7" Then
                ImageButton4.Visible = False
                imgGrabarPropuesta.Visible = False
                btnAceptarTelefono.Visible = False
                gvCompromisos.Activa_Delete = False
                gvCompromisos.Activa_Edita = False
                gvConsultaPagos.Activa_Delete = False
                gvConsultaPagos.Activa_Edita = False
                gvConsultaPagos.OpocionNuevo = False
                CtlGestionTelefonica.Activa_Delete = False
                CtlGestionCampo.Activa_Delete = False
            End If
            Refresh_Anotaciones()
        End If

        'IpLlamada = ConfigurationManager.ConnectionStrings("IPServicio").ConnectionString
    End Sub
    Sub Refresh_Estadistica()
        For p = 0 To CtlAnotaciones.GV.Rows.Count - 1
            Dim e = CtlAnotaciones.GV.Rows(p)
            If UCase(e.Cells(4).Text) = "TOTAL" Then
                e.Cells(5).Text = "CANTIDAD"
                e.Cells(6).Text = "(%)COB"
                e.Cells(4).Width = "50"
                e.Cells(5).Width = "50"
                e.Cells(6).Width = "50"
                e.Cells(4).BackColor = System.Drawing.Color.Orange
                e.Cells(5).BackColor = System.Drawing.Color.Orange
                e.Cells(6).BackColor = System.Drawing.Color.Orange

            ElseIf UCase(e.Cells(4).Text) = "META" Then
                e.Cells(4).Text = "<center>META</center>"
                e.Cells(5).Text = "<center>PAGOS</center>"
                e.Cells(6).Text = "<center>(%)EFE</center>"
                e.Cells(4).BackColor = System.Drawing.Color.Orange
                e.Cells(5).BackColor = System.Drawing.Color.Orange
                e.Cells(6).BackColor = System.Drawing.Color.Orange
                e.Cells(4).BackColor = System.Drawing.Color.FromName("#565C54")
                e.Cells(5).BackColor = System.Drawing.Color.FromName("#565C54")
                e.Cells(6).BackColor = System.Drawing.Color.FromName("#565C54")
                e.Cells(4).ForeColor = System.Drawing.Color.White
                e.Cells(5).ForeColor = System.Drawing.Color.White
                e.Cells(6).ForeColor = System.Drawing.Color.White
                e.Cells(4).HorizontalAlign = HorizontalAlign.Center
                e.Cells(5).HorizontalAlign = HorizontalAlign.Center
                e.Cells(6).HorizontalAlign = HorizontalAlign.Center
            Else
                e.Cells(4).BackColor = System.Drawing.Color.White
                e.Cells(5).BackColor = System.Drawing.Color.White
                e.Cells(6).BackColor = System.Drawing.Color.White
                If e.RowIndex = 0 Then
                    Cobertura = e.Cells(6).Text
                ElseIf e.RowIndex = 2 Then
                    Efectividad = e.Cells(6).Text
                End If
                Dim strScript = "<script>drawGauge();</script>"
                ScriptManager.RegisterStartupScript(Me, Me.GetType, "MyScript1", strScript, True)
                e.Cells(4).Text = "<center>" & e.Cells(4).Text & "<center>"
                e.Cells(5).Text = "<center>" & e.Cells(5).Text & "<center>"
                e.Cells(6).Text = "<center>" & e.Cells(6).Text & "<center>"
            End If
        Next
    End Sub


    Sub Refresh_Anotaciones()
        For p = 0 To CtlAnotaciones.GV.Rows.Count - 1
            Dim e = CtlAnotaciones.GV.Rows(p)
            If UCase(e.Cells(4).Text) = "FECHA" Then
                e.Cells(4).Width = "100"
                e.Cells(6).Width = "575"
                For c = 5 To e.Cells.Count - 1
                    e.Cells(c).Text = UCase(e.Cells(c).Text)
                Next
            Else
                For c = 4 To e.Cells.Count - 1
                    'e.Cells(c).Style.Add("BORDER-BOTTOM", "#aaccee 1px solid")
                    'e.Cells(c).Style.Add("BORDER-RIGHT", "#aaccee 1px solid")
                    'e.Cells(c).Style.Add("padding-left", "1px")
                    'e.Cells(c).BackColor = Drawing.Color.FromName("#F9F496")
                    'e.Cells(c).ForeColor = Drawing.Color.Black
                Next
            End If
        Next
    End Sub
    Private Sub gvConsultaPagos_Nuevo() Handles gvConsultaPagos.Nuevo
        pnlPagosMantenimiento.Visible = True
        CboMonedaPago.Limpia()
        CboMonedaPago.Condicion = ":idtabla▓105"
        CboMonedaPago.Cargar_dll()
        If TipoCartera = "ACTIVA" Then
            CboNroOperacioPago.Procedimiento = "SQL_N_GEST034"
        Else
            CboNroOperacioPago.Procedimiento = "SQL_N_GEST033"
        End If


        CboNroOperacioPago.Condicion = ":idcliente▓" & idcliente
        CboNroOperacioPago.Limpia()
        CboNroOperacioPago.Cargar_dll()

        cboConceptoPago.Limpia()
        cboConceptoPago.Condicion = ":idtabla▓123"
        cboConceptoPago.Cargar_dll()
        txtFechaPago.Text = Format(Now(), "dd/MM/yyyy")
        Crear_Cookies("Estado", "")
    End Sub

    Private Sub ImgGrabraPago_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImgGrabraPago.Click
        Dim ctl As New BL.Cobranza
        'Evento = Obtiene_Cookies("Estado")
        'If Evento = "P" Then Exit Sub
        'Crear_Cookies("Estado", "P")

        'If Pagos <> "P" Then
        Try
            Pagos = "P"
            '----
            If txtFechaPago.Text <> "" And CDate(txtFechaPago.Text) > Now.Date() Then
                CtlMensajes1.Mensaje("El pago no puede tener fecha futura", "")
                Exit Sub
            End If
            If txtFechaPago.Text = "" Then
                CtlMensajes1.Mensaje("La fecha de pago es obligatorio", "")
                Exit Sub
            End If
            If CboMonedaPago.Text = "" Then
                CtlMensajes1.Mensaje("La moneda del pago es obligatorio", "")
                Exit Sub
            End If
            If txtMontoPago.Text = "" Then
                CtlMensajes1.Mensaje("El importe del pago es obligatorio", "")
                Exit Sub
            End If
            If cboConceptoPago.Text = "" Then
                CtlMensajes1.Mensaje("El concepto de pago es obligatorio", "")
                Exit Sub
            End If


            ctl.FunctionGlobal(":pIdClienteƒ:pFechaPagoƒ:pmonedaƒ:pmontoƒ:pconceptoƒ:pnumoperacionƒ:pdniƒ:pidcartera▓" & idcliente & "ƒ" & Format(CDate(txtFechaPago.Text), "dd/MM/yyyy") & "ƒ" & Mid(CboMonedaPago.Text, 1, 1) & "ƒ" & txtMontoPago.Text & "ƒ" & cboConceptoPago.Text & "ƒ" & CboNroOperacioPago.Text & "ƒ" & Dni_Activo & "ƒ" & idCartera, "QRYCP005")

            pnlPagosMantenimiento.Visible = False
            CargarPagos()
            CtlMensajes1.Mensaje("Los pagos se crearon correctamente...!")
            Pagos = ""
        Catch ex As Exception
            CtlMensajes1.Mensaje("Ocurrio un error al grabar el pago, consulte o verufique el ingreso de su pago")
        End Try
        'End If
    End Sub

    Private Sub chkPagadoCompromisoMantenimiento_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkPagadoCompromisoMantenimiento.CheckedChanged
        txtFechaPagoCompromisoMantenimeinto.Enabled = True
        txtMontoCompromisoMantenimientoA.Enabled = True
        Crear_Cookies("Estado", "")
    End Sub

    Private Sub ImgCerrarPago_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImgCerrarPago.Click
        pnlPagosMantenimiento.Visible = False
        Crear_Cookies("Estado", "")
    End Sub

    Private Sub CtlDireccion_Seleccionarfila(ByVal sender As Object, ByVal e As System.EventArgs, ByVal row As System.Web.UI.WebControls.GridViewRow) Handles CtlDireccion.Seleccionarfila
    End Sub

    Private Sub gvConsultaPagos_RowDeleting(ByVal GV As System.Web.UI.WebControls.GridView, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gvConsultaPagos.RowDeleting
        Dim PerfilUsuario = Obtiene_Cookies("TipoUsuario")
        If PerfilUsuario <> "Gestor" Then
            Dim ctl As New BL.Cobranza
            ctl.FunctionGlobal(":idpago▓" & GV.Rows(e.RowIndex).Cells(12).Text, "QRYCP009")
            CtlMensajes1.Mensaje("El registro ha sido eliminado", "")
            pnlPagos.Visible = True
            txtDNIPagos.Text = Dni_Activo
            txtClientePagos.Text = txtnombre.Text
            Id_Cliente_Pagos = idcliente
            cboCarteraPagos.Text = cbocartera.Text
            txtFechaInicioPagos.Text = "01/" & Date.Now.ToString("MM/yyyy")
            txtFechaFinPagos.Text = DateTime.DaysInMonth(Date.Now.Year, Date.Now.Month) & "/" & Date.Now.ToString("MM/yyyy")
            CargarPagos()
            Crear_Cookies("Estado", "")
        End If
    End Sub

    Private Sub gvConsultaPagos_RowEditing(ByVal GV As System.Web.UI.WebControls.GridView, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs, ByVal row As System.Web.UI.WebControls.GridViewRow) Handles gvConsultaPagos.RowEditing
        '    Dim PerfilUsuario = Obtiene_Cookies("TipoUsuario")
        '    If PerfilUsuario <> "Gestor" Then            
        ' pnlPagosMantenimiento.Visible = True
        ' CboMonedaPago.Limpia()
        ' CboMonedaPago.Condicion = ":idtabla▓105"
        ' CboMonedaPago.Cargar_dll()
        ' If TipoCartera = "ACTIVA" Then
        ' CboNroOperacioPago.Procedimiento = "SQL_N_GEST034"
        ' Else
        ' CboNroOperacioPago.Procedimiento = "SQL_N_GEST033"
        ' End If
        '
        ' CboNroOperacioPago.Condicion = ":idcliente▓" & idcliente
        'CboNroOperacioPago.Limpia()
        'CboNroOperacioPago.Cargar_dll()
        '
        'cboConceptoPago.Limpia()
        'cboConceptoPago.Condicion = ":idtabla▓123"
        ' cboConceptoPago.Cargar_dll()
        ' txtFechaPago.Text = GV.Rows(e.NewEditIndex).Cells(6).Text
        '     cboConceptoPago.Valor = gv.
        'End If
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

    Private Sub CtlGestionTelefonica_RowDeleting(ByVal GV As System.Web.UI.WebControls.GridView, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles CtlGestionTelefonica.RowDeleting
        Dim ctl As New Controles.General
        Dim row As GridViewRow = GV.Rows(e.RowIndex)
        Dim PerfilUsuario = Obtiene_Cookies("TipoUsuario")
        If PerfilUsuario <> "GESTOR" Then
            If ctl.Elimina_Gestion(row.Cells(0).Text) Then
                CtlMensajes1.Mensaje("su gestion ha sido eliminado", "")
                Call ctl.Gestion_Telefono_grilla(DNI, idEmpresa, CtlGestionTelefonica)
            Else
                CtlMensajes1.Mensaje("su gestion no ha sido eliminado, verifique con su administrador", "")
            End If
        Else
            CtlMensajes1.Mensaje("usted no tiene permiso para eliminar, verifique con su administrador", "")
        End If
    End Sub

    Private Sub CtlGestionCampo_RowDeleting(ByVal GV As System.Web.UI.WebControls.GridView, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles CtlGestionCampo.RowDeleting
        Dim ctl As New Controles.General
        Dim row As GridViewRow = GV.Rows(e.RowIndex)
        Dim PerfilUsuario = Obtiene_Cookies("TipoUsuario")
        If PerfilUsuario <> "GESTOR" Then
            If ctl.Elimina_Gestion(row.Cells(0).Text) Then
                CtlMensajes1.Mensaje("su gestion ha sido eliminado", "")
                Call ctl.Gestion_Telefono_grilla(DNI, idEmpresa, CtlGestionTelefonica)
            Else
                CtlMensajes1.Mensaje("su gestion no ha sido eliminado, verifique con su administrador", "")
            End If
        Else
            CtlMensajes1.Mensaje("usted no tiene permiso para eliminar, verifique con su administrador", "")
        End If
    End Sub
    <System.Web.Services.WebMethod()> _
    <System.Web.Script.Services.ScriptMethod()> _
    Public Shared Function GetMensaje() As String
        Dim ctl As New Controles.General
        Dim StrMensaje As String = ""
        Dim cogeCookie = HttpContext.Current.Request.Cookies.Get("idcliente")
        Dim pidusuario = cogeCookie.Value
        Dim idMensaje As Integer = 0
        Dim dt = ctl.BuscarSQL(":idcliente▓" & pidusuario, "GES008")
        If Not dt Is Nothing Then
            If dt.Rows.Count > 0 Then
                idMensaje = dt.Rows(0)(0)
                StrMensaje = " (" & dt.Rows(0)(0) & ") " & dt.Rows(0)(2)
                dt = Nothing
            Else
                dt = Nothing
            End If
        End If
        Return StrMensaje
    End Function
    '<System.Web.Services.WebMethod()> _
    '<System.Web.Script.Services.ScriptMethod()> _
    'Public Shared Function GetUploadStatus() As String
    '    Dim ctl As New Controles.General
    '    Dim StrMensaje As String = ""
    '    Dim cogeCookie = HttpContext.Current.Request.Cookies.Get("idusuario")
    '    Dim pidusuario = cogeCookie.Value
    '    Dim idMensaje As Integer = 0
    '    Dim dt = ctl.BuscarSQL(":idUsuario▓" & pidusuario, "QRYSIC001")
    '    If Not dt Is Nothing Then
    '        If dt.Rows.Count > 0 Then
    '            idMensaje = dt.Rows(0)(0)
    '            StrMensaje = " (" & dt.Rows(0)(0) & ") " & dt.Rows(0)(2)
    '            dt = Nothing
    '        Else
    '            dt = Nothing
    '        End If
    '    End If
    '    Return StrMensaje
    'End Function
    <System.Web.Services.WebMethod()> _
   <System.Web.Script.Services.ScriptMethod()> _
   Public Shared Function GrabarMensaje(ByVal lblCCidMensajes) As Boolean
        Try
            Dim ctl As New Controles.General
            ctl.BuscarSQL(":idMensaje▓" & lblCCidMensajes.ToString.Trim(), "QRYSIC002")
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    'Private Sub Timer1_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Timer1.Tick
    '    Dim ctl As New Controles.General
    '    Call ctl.Estadistica_grilla(Dni_Activo, idUsuario, idCartera, CtlEstadistica)
    '    ctl = Nothing
    '    Timer1.Interval = 0
    '    Timer1.Enabled = False

    'End Sub

    Private Sub cboIndicador_Click() Handles cboIndicador.Click

    End Sub

    Protected Sub btnProximaAccion_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnProximaAccion.Click
        PnlProximaAccion.Visible = True
        txtAnotacion.Text = ""
        CboHoraProxAcc.Value = ""
        CboMinutoProxAcc.Value = ""
        txtProximaAccion.Text = ""
    End Sub

    Private Sub btnAceptarFP_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAceptarFP.Click
        Dim ctl As New Controles.General
        ctl.Obtiene_Consulta(":idclienteƒ:fechaProxAccƒ:anotacionƒ:idusuario▓" & idcliente & "ƒ" & txtProximaAccion.Text & " " & CboHoraProxAcc.Text & ":" & CboMinutoProxAcc.Text & ":00ƒ" & _
                             txtAnotacion.Text & "ƒ" & Hidusuario.Value, "GES007")
        CtlMensajes1.Mensaje("Cliente Agendado...")
        PnlProximaAccion.Visible = False
    End Sub

    Private Sub btnCerrarFP_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCerrarFP.Click
        CtlMensajes1.Mensaje("Se ha cancelado la agenda del presente cliente...", "")
        PnlProximaAccion.Visible = False
    End Sub

    Private Sub BtnRedirect_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnRedirect.Click
        Dim ctl As New Controles.General
        ctl.Obtiene_Consulta(":idagenda▓" & Obtiene_Cookies("ppidagenda"), "GES009")
        Dim Url As String = "Gestion.aspx?DNI=" & Obtiene_Cookies("ppDNI") & "&idcliente=" & Obtiene_Cookies("ppidcliente") & "&idcartera=" & Obtiene_Cookies("ppidcartera") & "&idusuario=" & Obtiene_Cookies("idusuario") & "&NombreGestor=MARTINEZ+RENZO&tipocartera=CASTIGO&usuario=renzo"
        Response.Redirect(Url)
        ctl = Nothing
    End Sub

    Private Sub BtnPosponer_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnPosponer.Click
        Dim ctl As New Controles.General
        ctl.Obtiene_Consulta(":idagenda▓" & Obtiene_Cookies("ppidagenda"), "GES009")
        ctl = Nothing
        PnlProximaAccion.Visible = True
        PnlMensajeAlerta.Visible = False
        CtlMensajes1.Mensaje("Accion suspendida, dar click en aceptar para ingresar nueva programacion... ", "")
    End Sub

    Private Sub BtnEliminar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnEliminar.Click
        Dim ctl As New Controles.General
        ctl.Obtiene_Consulta(":idagenda▓" & Obtiene_Cookies("ppidagenda"), "GES009")
        ctl = Nothing
        CtlMensajes1.Mensaje("Se eliminacion la accion de gestion ...", "")
        PnlMensajeAlerta.Visible = False
    End Sub


End Class
