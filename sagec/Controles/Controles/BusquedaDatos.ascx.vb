'************************************************************************************************************************
'***** Autor: EMPRESA PIMAY 
'***** DESCRIPCION: MULTIPLES CONEXIONES 
'************************************************************************************************************************
Imports BL
Partial Public Class BusquedaDatos
    Inherits System.Web.UI.UserControl
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

    Dim Busqueda As New BL.Busquedas

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
            cboTipoCartera.Ocultar = Out_TipoCartera
        End Set
    End Property
    Public Property Dias_Mora() As Boolean
        Get
            Return Out_DiasMora
        End Get
        Set(ByVal value As Boolean)
            Out_DiasMora = value
            lblDiasMora.Visible = Out_DiasMora
            cboDiasMora.Ocultar = Out_DiasMora
        End Set
    End Property
    Public Property Titulo() As String
        Get
            Return lblTituloControl.Text
        End Get
        Set(ByVal value As String)
            lblTituloControl.Text = value
            CtlModificarAsignacion1.TituloPrincipal = value
        End Set
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            CargaCombos()
        End If
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnBuscar.Click
        Dim dt As New DataTable

        Using dt
            Busqueda.CriterioTodos = "CLIENTE.IDCLIENTE>0"
            If Titulo = "BUSQUEDA POR DATOS DE CLIENTE" Then
                dt = Busqueda.Buscar_Datos_Cliente(cboCartera.Text, cboGestor.Text, cboCondicion.Text, txtDNI.Text, txtCliente.Text, txtTelefono.Text, cboTipoCartera.Text)
            ElseIf Titulo = "BUSQUEDA DE DATOS DE OPERACION - CASTIGO" Then
                dt = Busqueda.Buscar_Operacion_Castigo(cboCartera.Value, cboCartera.Text, cboGestor.Text, cboCondicion.Value, cboCondicion.Text, txtRefin.Text, txtCampaña.Text, txtProducto.Text, txtNegocio.Text, txtNroOperacion.Text, txtCliente.Text)
            ElseIf Titulo = "BUSQUEDA DE DATOS DE OPERACION - ACTIVA" Then
                dt = Busqueda.Buscar_Operacion_Activa(cboCartera.Value, cboGestor.Text, txtProducto.Text, txtNegocio.Text, txtNroCuenta.Text, txtCliente.Text, cboDiasMora.Text, cboCondicion.Value)
            End If
            lblCantidad.Text = dt.Rows.Count
            gvPrincipal.SourceDataTable = dt
            CtlModificarAsignacion1.DataTable = dt
        End Using

    End Sub
    Sub CargaCombos()
        If Titulo = "BUSQUEDA POR DATOS DE CLIENTE" Then
            If Session("idPerfil") <> "4" Then
                RellenaCombo(cboCartera, "QRYCG002", ":idusuario▓" & Session("idusuario"), True)
                RellenaCombo(cboCondicion, "QRYCGC001", "")
                RellenaCombo(cboTipoCartera, "QRYC008", ":cod▓100")
            Else
                RellenaCombo(cboCartera, "QRYCG002", ":criterio▓ALL", True)
                RellenaCombo(cboCondicion, "QRYCGC001", "")
                RellenaCombo(cboTipoCartera, "QRYC008", ":cod▓100")
            End If
        ElseIf Titulo = "BUSQUEDA DE DATOS DE OPERACION - CASTIGO" Then
            RellenaCombo(cboCartera, "QRYCG002", ":criterio▓CASTIGO", True)
            RellenaCombo(cboCondicion, "QRYCGC001", "")
        ElseIf Titulo = "BUSQUEDA DE DATOS DE OPERACION - ACTIVA" Then
            RellenaCombo(cboCartera, "QRYCG002", ":criterio▓ACTIVA", True)
            RellenaCombo(cboCondicion, "QRYCGC001", "")
            RellenaCombo(cboDiasMora, "QRYC008", ":cod▓102")
        End If
    End Sub
    Private Sub cboCartera_Click() Handles cboCartera.Click
        Busqueda.CriterioIdCartera = " AND Cartera.IdCartera = " + CStr(cboCartera.Value)
        RellenaCombo(cboGestor, "QRYCBG001", ":pcriterioidcartera▓" & Busqueda.CriterioIdCartera)
    End Sub
    Private Sub gvPrincipal_RowDeleting(ByVal GV As System.Web.UI.WebControls.GridView, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gvPrincipal.RowDeleting
        Dim IdCliente As String = ""
        Dim IdUsuarioCliente As String = ""
        Dim Cliente As String = ""
        Dim row As GridViewRow = GV.Rows(e.RowIndex)
        Dim Cantidad As String = ""
        If Titulo = "BUSQUEDA POR DATOS DE CLIENTE" Then
            IdCliente = IIf(Not IsDBNull(row.Cells(13).Text), row.Cells(13).Text, "")
            IdUsuarioCliente = IIf(Not IsDBNull(row.Cells(14).Text), row.Cells(14).Text, "")
            Cliente = IIf(Not IsDBNull(row.Cells(7).Text), row.Cells(7).Text, "")
            Cantidad = lblCantidad.Text
        ElseIf Titulo = "BUSQUEDA DE DATOS DE OPERACION - CASTIGO" Then
            IdCliente = IIf(Not IsDBNull(row.Cells(20).Text), row.Cells(20).Text, "")
            IdUsuarioCliente = IIf(Not IsDBNull(row.Cells(21).Text), row.Cells(21).Text, "")
            Cliente = IIf(Not IsDBNull(row.Cells(11).Text), row.Cells(11).Text, "")
            Cantidad = lblCantidad.Text
        ElseIf Titulo = "BUSQUEDA DE DATOS DE OPERACION - ACTIVA" Then
            IdCliente = IIf(Not IsDBNull(row.Cells(26).Text), row.Cells(26).Text, "")
            IdUsuarioCliente = IIf(Not IsDBNull(row.Cells(27).Text), row.Cells(27).Text, "")
            Cliente = IIf(Not IsDBNull(row.Cells(9).Text), row.Cells(9).Text, "")
            Cantidad = lblCantidad.Text
        End If
        CtlEliminarAsignacion1.Cargar_datos(IdUsuarioCliente, IdCliente, Cliente)
        CtlEliminarAsignacion1.Visible = True
    End Sub
    Private Sub gvPrincipal_RowEditing(ByVal GV As System.Web.UI.WebControls.GridView, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs, ByVal row As System.Web.UI.WebControls.GridViewRow) Handles gvPrincipal.RowEditing
        Dim IdCliente As String = ""
        Dim IdUsuarioCliente As String = ""
        Dim Cliente As String = ""
        Dim Usuario As String = ""
        Dim Cantidad As String = ""
        If Titulo = "BUSQUEDA POR DATOS DE CLIENTE" Then
            IdCliente = row.Cells(13).Text
            IdUsuarioCliente = row.Cells(14).Text
            Cliente = row.Cells(7).Text
            Usuario = row.Cells(4).Text
            Cantidad = lblCantidad.Text
        ElseIf Titulo = "BUSQUEDA DE DATOS DE OPERACION - CASTIGO" Then
            IdCliente = row.Cells(20).Text
            IdUsuarioCliente = row.Cells(21).Text
            Cliente = row.Cells(11).Text
            Usuario = row.Cells(4).Text
            Cantidad = lblCantidad.Text
        ElseIf Titulo = "BUSQUEDA DE DATOS DE OPERACION - ACTIVA" Then
            IdCliente = row.Cells(26).Text
            IdUsuarioCliente = row.Cells(27).Text
            Cliente = row.Cells(9).Text
            Usuario = row.Cells(4).Text
            Cantidad = lblCantidad.Text
        End If
        
        CtlModificarAsignacion1.CargaAsignacion(IdCliente, IdUsuarioCliente, Cliente, Usuario, Cantidad)
        CtlModificarAsignacion1.Visible = True
    End Sub
    Private Sub gvPrincipal_Seleccionarfila(ByVal sender As Object, ByVal e As System.EventArgs, ByVal row As System.Web.UI.WebControls.GridViewRow) Handles gvPrincipal.Seleccionarfila
        If Titulo = "BUSQUEDA POR DATOS DE CLIENTE" Then
            'Dim s = "window.open('" & "CGestion.aspx?idcliente=" & row.Cells(6).Text & "&cartera=" & row.Cells(11).Text & "&tipocartera=" & row.Cells(12).Text + "', 'popup_window', 'width=1000,height=800,left=0,top=0,resizable=no');"
            '.OnClientClick = s
            'Botones1.Direccionar_Pagina("CGestion.aspx?idcliente=" & row.Cells(6).Text & "&cartera=" & row.Cells(11).Text & "&tipocartera=" & row.Cells(12).Text)
        ElseIf Titulo = "BUSQUEDA DE DATOS DE OPERACION - CASTIGO" Then
            'Botones1.Direccionar_Pagina("CGestion.aspx?idcliente=" & row.Cells(10).Text & "&cartera=" & row.Cells(25).Text & "&tipocartera=" & row.Cells(23).Text)
        ElseIf Titulo = "BUSQUEDA DE DATOS DE OPERACION - ACTIVA" Then
            'Botones1.Direccionar_Pagina("CGestion.aspx?idcliente=" & row.Cells(8).Text & "&cartera=" & row.Cells(29).Text & "&tipocartera=" & row.Cells(23).Text)
        End If
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

End Class