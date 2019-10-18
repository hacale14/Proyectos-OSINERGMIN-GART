Public Partial Class CtlCamposBusqueda
    Inherits System.Web.UI.UserControl
    Dim blbusqueda As New BL.Busquedas
    Dim Out_Cartera As Boolean
    Dim Out_Gestor As Boolean
    Dim Out_Condicion As Boolean
    Dim Out_Dni As Boolean
    Dim Out_Refin As Boolean
    Dim Out_Campaña As Boolean
    Dim Out_Producto As Boolean
    Dim Out_Negocio As Boolean
    Dim Out_NroOperacion As Boolean
    Dim Out_NroCuenta As Boolean
    Dim Out_Cliente As Boolean
    Dim Out_Telefono As Boolean
    Dim Out_TipoCartera As Boolean
    Dim Out_DiasMora As Boolean
    Dim Out_Tipo_Busqueda As String
    Dim Out_Titulo As String

    Public Property Muestra_Buscar() As Boolean
        Get
            Return btnBuscar.Enabled
        End Get
        Set(ByVal value As Boolean)
            btnBuscar.Enabled = value
        End Set
    End Property

    Public Property Titulo() As String
        Get
            Return lblTituloControl.Text
        End Get
        Set(ByVal value As String)
            lblTituloControl.Text = value
        End Set
    End Property
    Public Property Cartera() As Boolean
        Get
            Return Out_Cartera
        End Get
        Set(ByVal value As Boolean)
            Out_Cartera = value
            lblCartera.Visible = Out_Cartera
            cboCartera.Ocultar = Out_Cartera
        End Set
    End Property
    Public Property Gestor() As Boolean
        Get
            Return Out_Gestor
        End Get
        Set(ByVal value As Boolean)
            Out_Gestor = value
            lblGestor.Visible = Out_Gestor
            cboGestor.Ocultar = Out_Gestor
        End Set
    End Property
    Public Property Condicion() As Boolean
        Get
            Return Out_Condicion
        End Get
        Set(ByVal value As Boolean)
            Out_Condicion = value
            lblCondic.Visible = Out_Condicion
            cboCondicion.Ocultar = Out_Condicion
        End Set
    End Property
    Public Property DNI() As Boolean
        Get
            Return Out_Dni
        End Get
        Set(ByVal value As Boolean)
            Out_Dni = value
            lblDNI.Visible = Out_Dni
            txtDNI.Visible = Out_Dni
        End Set
    End Property
    Public Property Refinanciar() As Boolean
        Get
            Return Out_Refin
        End Get
        Set(ByVal value As Boolean)
            Out_Refin = value
            lblRefin.Visible = Out_Refin
            txtRefin.Visible = Out_Refin
        End Set
    End Property
    Public Property Campaña() As Boolean
        Get
            Return Out_Campaña
        End Get
        Set(ByVal value As Boolean)
            Out_Campaña = value
            lblCampaña.Visible = Out_Campaña
            txtCampaña.Visible = Out_Campaña
        End Set
    End Property
    Public Property Producto() As Boolean
        Get
            Return Out_Producto
        End Get
        Set(ByVal value As Boolean)
            Out_Producto = value
            lblProducto.Visible = Out_Producto
            txtProducto.Visible = Out_Producto
        End Set
    End Property
    Public Property Negocio() As Boolean
        Get
            Return Out_Negocio
        End Get
        Set(ByVal value As Boolean)
            Out_Negocio = value
            lblNegocio.Visible = Out_Negocio
            txtNegocio.Visible = Out_Negocio
        End Set
    End Property
    Public Property Nro_Operacion() As Boolean
        Get
            Return Out_NroOperacion
        End Get
        Set(ByVal value As Boolean)
            Out_NroOperacion = value
            lblNroOperacion.Visible = Out_NroOperacion
            txtNroOperacion.Visible = Out_NroOperacion
        End Set
    End Property
    Public Property Nro_Cuenta() As Boolean
        Get
            Return Out_NroCuenta
        End Get
        Set(ByVal value As Boolean)
            Out_NroCuenta = value
            lblNroCuenta.Visible = Out_NroCuenta
            txtNroCuenta.Visible = Out_NroCuenta
        End Set
    End Property
    Public Property Cliente() As Boolean
        Get
            Return Out_Cliente
        End Get
        Set(ByVal value As Boolean)
            Out_Cliente = value
            lblCiente.Visible = Out_Cliente
            txtCliente.Visible = Out_Cliente
        End Set
    End Property
    Public Property Telefono() As Boolean
        Get
            Return Out_Telefono
        End Get
        Set(ByVal value As Boolean)
            Out_Telefono = value
            lblTelefono.Visible = Out_Telefono
            txtTelefono.Visible = Out_Telefono
        End Set
    End Property
    Public Property Tipo_Cartera() As Boolean
        Get
            Return Out_TipoCartera
        End Get
        Set(ByVal value As Boolean)
            Out_TipoCartera = value
            lblTipoCartera.Visible = Out_TipoCartera
            cboTipoCartera.Visible = Out_TipoCartera
        End Set
    End Property
    Public Property Dias_Mora() As Boolean
        Get
            Return Out_DiasMora
        End Get
        Set(ByVal value As Boolean)
            Out_DiasMora = value
            lblDiasMora.Visible = Out_DiasMora
            cboDiasMora.Visible = Out_DiasMora
        End Set
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then         
            If Session("idPerfil") = "7" Then
                LlenaCombo(cboCartera, "QRYCCG01C", ":idusuarioƒ:idcorporacion▓" & Session("idusuario") & "ƒ" & Obtiene_Cookies("idcorporacion"), True)
            Else
                LlenaCombo(cboCartera, "QRYCG002C", ":criterioƒ:idcorporacion▓ALL" & "ƒ" & Obtiene_Cookies("idcorporacion"), True)
            End If
            LlenaCombo(cboCondicion, "QRYCGC001", "")
            LlenaCombo(cboTipoCartera, "QRYC008", ":cod▓100")
            LlenaCombo(cboDiasMora, "QRYC008", ":cod▓102")
            CargaPropuestas("")
            CargaCompromisos_Pendiente()
        End If
    End Sub
    Sub CargaCompromisos_Pendiente()
        Dim usuario As String = Obtiene_Cookies("usuario")
        Dim ctl As New BL.Cobranza
        Dim dt = ctl.FunctionGlobal(":usuario▓" & usuario, "GES004")
        If Not dt Is Nothing Then
            If dt.rows.count > 0 Then
                CtlMensajes1.Mensaje("¡Usted tiene clientes con compromisos pendiente por pagar el dia de hoy la cual se mostrara para su gestion...!", "")
                blbusqueda.idusuario = Session("idusuario")
                blbusqueda.idPerfil = Session("idPerfil")
                blbusqueda.CriterioTodos = usuario
                dt = blbusqueda.Buscar_Datos_Cliente_Compromiso(cboCartera.Value, cboGestor.Value, cboCondicion.Value, txtDNI.Text, txtCliente.Text, txtTelefono.Text, cboTipoCartera.Text)
                RaiseEvent Buscar(dt, 0)
            Else
                Session("indCompromoiso") = False
                blbusqueda.ConCompromiso = False
            End If
        Else
            Session("indCompromoiso") = False
            blbusqueda.ConCompromiso = False
        End If
        'dt = Nothing
    End Sub
    Function Obtiene_Cookies(ByVal id) As String
        '// Recogemos la cookie que nos interese
        Dim cogeCookie As HttpCookie = Request.Cookies.Get(id)
        Return cogeCookie.Value
    End Function
    Sub CargaPropuestas(ByVal criterio As String)
        Dim ctl As New BL.Cobranza
        Dim dt As New DataTable
        dt = ctl.FunctionGlobal(":criterio▓" & criterio, "SQL_N_GEST051")
        If Not dt Is Nothing Then
            If dt.Rows.Count > 0 Then
                lblAprobadasPropuesta.Text = dt.Rows(0)(0)
                lblPednientesPropuesta.Text = dt.Rows(0)(1)
                lblRechazadasPropuesta.Text = dt.Rows(0)(2)
            End If
        End If
    End Sub

    Private Sub LlenaCombo(ByVal Combo As CtCombo, ByVal Procedimiento As String, ByVal Condicion As String, Optional ByVal AP As Boolean = False)
        With Combo
            .Limpia()
            .Procedimiento = Procedimiento
            .Condicion = Condicion
            .AutoPostBack = AP
            .Cargar_dll()
            .Activa = True
        End With
    End Sub
    Public Sub Validar_Cartera(ByVal index As String)
        cboGestor.Limpia()
        If index = 1 Then
            If Session("idPerfil") = "7" Then
                LlenaCombo(cboCartera, "QRYCCG01", ":idusuario▓" & Session("idusuario"), True)
            Else
                LlenaCombo(cboCartera, "QRYCG002", ":criterio▓CASTIGO", True)
            End If
        ElseIf index = 2 Then
            LlenaCombo(cboCartera, "QRYCG002", ":criterio▓ACTIVA", True)
        Else
            LlenaCombo(cboCartera, "QRYCG002", ":criterio▓ALL", True)
        End If
    End Sub
    Private Sub cboCartera_Click() Handles cboCartera.Click
        'blbusqueda.CriterioIdCartera = " HAVING Cartera.IdCartera = " + CStr(cboCartera.Value)
        blbusqueda.CriterioIdCartera = " AND Cliente.IdCartera = " + CStr(cboCartera.Value)
        LlenaCombo(cboGestor, "SQL_N_GEST053", ":pcriterioidcartera▓" & blbusqueda.CriterioIdCartera)
        Dim cantidad_cartera As Long
        Dim grafico As DataTable

        cantidad_cartera = blbusqueda.CantidadCarteraAsignacion(cboCartera.Text)
        grafico = blbusqueda.GraficaCarteraAsignacionGestor(cboCartera.Text)
        Dim index As String = ""

        If Titulo = "BUSQUEDA POR DATOS DE CLIENTE" Then
            index = 0
        End If

        CargaPropuestas(" and idcliente in (select Cliente.IdCliente from Cliente where Cliente.IdCartera=" & cboCartera.Value & " and Cliente.Estado in ('A','N'))")

        RaiseEvent SeleccionCartera(cantidad_cartera, grafico, index)
    End Sub
    Private Sub btnBuscar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnBuscar.Click
        Dim dt As New DataTable
        Dim index As String = ""

        Using dt
            blbusqueda.CriterioTodos = "CLIENTE.IDCLIENTE>0"
            If Titulo = "BUSQUEDA POR DATOS DE CLIENTE" Then                
                If cboCartera.Value = 0 And Len(Trim(cboCondicion.Text)) = 0 And Len(Trim(txtDNI.Text)) = 0 And Len(Trim(txtCliente.Text)) = 0 And Len(Trim(txtTelefono.Text)) = 0 And Len(Trim(cboTipoCartera.Text)) = 0 Then
                    CtlMensajes1.Mensaje("AVISO..: SE DEBE DE SELECCIONAR O INGRESAR AL MENOS UN DATO PARA LA BUSQUEDA")
                    Exit Sub
                End If
                If cboCartera.Value = 0 And Len(Trim(txtDNI.Text)) = 0 And Len(Trim(txtCliente.Text)) = 0 And Len(Trim(txtTelefono.Text)) = 0 Then
                    CtlMensajes1.Mensaje("AVISO..: SE DEBE DE SELECCIONAR UNA CARTERA")
                    Exit Sub
                End If
                If cboCartera.Value = 0 And Val(cboGestor.Value) = 0 And Len(Trim(txtDNI.Text)) = 0 And Len(Trim(txtCliente.Text)) = 0 And Len(Trim(cboCondicion.Text)) = 0 And Len(Trim(txtTelefono.Text)) = 0 Then
                    CtlMensajes1.Mensaje("AVISO..: SE DEBE DE SELECCIONAR UN GESTOR")
                    Exit Sub
                End If            
                index = 0
                'dt = blbusqueda.Buscar_Datos_Cliente(cboCartera.Text, cboGestor.Text, cboCondicion.Text, txtDNI.Text, txtCliente.Text, txtTelefono.Text, cboTipoCartera.Text)
                blbusqueda.idusuario = Session("idusuario")
                blbusqueda.idPerfil = Session("idPerfil")
                dt = blbusqueda.Buscar_Datos_Cliente(cboCartera.Value, cboGestor.Value, cboCondicion.Value, txtDNI.Text, txtCliente.Text, txtTelefono.Text, cboTipoCartera.Text)
            ElseIf Titulo = "BUSQUEDA DE DATOS DE OPERACION - CASTIGO" Then
                If cboCartera.Value = 0 And Len(Trim(cboCondicion.Text)) = 0 And Len(Trim(txtRefin.Text)) = 0 And Len(Trim(txtCampaña.Text)) = 0 And Len(Trim(txtProducto.Text)) = 0 And Len(Trim(txtNegocio.Text)) = 0 And Len(Trim(txtNroOperacion.Text)) = 0 And Len(Trim(txtCliente.Text)) = 0 Then
                    CtlMensajes1.Mensaje("AVISO..: SE DEBE DE SELECCIONAR O INGRESAR AL MENOS UN DATO PARA LA BUSQUEDA")
                    Exit Sub
                End If
                If cboCartera.Value = 0 Then
                    CtlMensajes1.Mensaje("AVISO..: SE DEBE DE SELECCIONAR UNA CARTERA")
                    Exit Sub
                End If
                If cboCartera.Value <> 0 And cboGestor.Value = 0 Then
                    CtlMensajes1.Mensaje("AVISO..: SE DEBE DE SELECCIONAR UN GESTOR")
                    Exit Sub
                End If

                index = 1
                'dt = blbusqueda.Buscar_Operacion_Castigo(cboCartera.Value, cboCartera.Text, cboGestor.Text, cboCondicion.Value, cboCondicion.Text, txtRefin.Text, txtCampaña.Text, txtProducto.Text, txtNegocio.Text, txtNroOperacion.Text, txtCliente.Text)
                dt = blbusqueda.Buscar_Operacion_Castigo(cboCartera.Value, cboCartera.Text, cboGestor.Value, cboCondicion.Value, cboCondicion.Text, txtRefin.Text, txtCampaña.Text, txtProducto.Text, txtNegocio.Text, txtNroOperacion.Text, txtCliente.Text)
            ElseIf Titulo = "BUSQUEDA DE DATOS DE OPERACION - ACTIVA" Then

                If cboCartera.Value = 0 And Len(Trim(txtProducto.Text)) = 0 And Len(Trim(txtNegocio.Text)) = 0 And Len(Trim(txtNroCuenta.Text)) = 0 And Len(Trim(txtCliente.Text)) = 0 And Len(Trim(cboDiasMora.Text)) = 0 Then
                    CtlMensajes1.Mensaje("AVISO..: SE DEBE DE SELECCIONAR O INGRESAR AL MENOS UN DATO PARA LA BUSQUEDA")
                    Exit Sub
                End If
                If cboCartera.Value = 0 Then
                    CtlMensajes1.Mensaje("AVISO..: SE DEBE DE SELECCIONAR UNA CARTERA")
                    Exit Sub
                End If
                If cboCartera.Value <> 0 And cboGestor.Value = 0 Then
                    CtlMensajes1.Mensaje("AVISO..: SE DEBE DE SELECCIONAR UN GESTOR")
                    Exit Sub
                End If

                index = 2
                'dt = blbusqueda.Buscar_Operacion_Activa(cboCartera.Value, cboGestor.Text, txtProducto.Text, txtNegocio.Text, txtNroCuenta.Text, txtCliente.Text, cboDiasMora.Text)
                dt = blbusqueda.Buscar_Operacion_Activa(cboCartera.Value, cboGestor.Value, txtProducto.Text, txtNegocio.Text, txtNroCuenta.Text, txtCliente.Text, cboDiasMora.Text, cboCondicion.Text)
            End If
            RaiseEvent Buscar(dt, index)
        End Using
    End Sub
    Event Buscar(ByVal Dt As DataTable, ByVal index As String)
    Event SeleccionCartera(ByVal cantidad As Long, ByVal dt2 As DataTable, ByVal index As String)
    Event ClickPropuesta(ByVal dt As DataTable, ByVal tipo As String)

    Function PropuestaFuncion(ByVal estado As String) As DataTable
        Dim dt As New DataTable
        Dim ctl As New BL.Cobranza
        Dim criterio As String = ""
        criterio = criterio & " and p.estado='" & estado & "'"
        If Len(Trim(cboCartera.Text)) <> 0 Then
            criterio = criterio & " and ca.idcartera=" & cboCartera.Value
        End If
        dt = ctl.FunctionGlobal(":criterio▓" & criterio, "SQL_N_GEST050")
        Return dt
    End Function

    Private Sub lblAprobadasPropuesta_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblAprobadasPropuesta.Click
        RaiseEvent ClickPropuesta(PropuestaFuncion("A"), "A")
    End Sub

    Private Sub lblPednientesPropuesta_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblPednientesPropuesta.Click
        RaiseEvent ClickPropuesta(PropuestaFuncion("P"), "P")
    End Sub

    Private Sub lblRechazadasPropuesta_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblRechazadasPropuesta.Click
        RaiseEvent ClickPropuesta(PropuestaFuncion("R"), "R")
    End Sub
End Class