Imports BL

Partial Public Class NuevaCartera
    Inherits System.Web.UI.UserControl
    Dim BLCartera As New BL.Cartera
    Dim BLEmpresa As New BL.Empresa


    Sub CargarDatos()
        If lblTituloControl.Text = "NUEVA CARTERA" Then
            txtCartera.Text = ""
            txtCodigo.Text = ""
            lblIdCartera.Text = ""
            txtMeta.Text = Nothing
        ElseIf lblTituloControl.Text = "MODIFICAR CARTERA" Then
            cboEmpresa.Text = Empresa
            cbogrpcartera.Value = GrCartera
            txtCartera.Text = Cartera
            txtCodigo.Enabled = False
            txtCodigo.Text = Codigo
            txtMeta.Text = Metas
            If Tipo = "ACTIVA" Then
                cboTipo.Text = "ACTIVA"
            ElseIf Tipo = "CASTIGO" Then
                cboTipo.Text = "CASTIGO"
            End If

        End If
    End Sub


    Private Sub imgCerrar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgCerrar.Click
        RaiseEvent CerrarNuevaCartera()
    End Sub

    Event CerrarNuevaCartera()

    Public Property Titulo() As String
        Get
            Return lblTituloControl.Text
        End Get
        Set(ByVal value As String)
            lblTituloControl.Text = value
        End Set
    End Property

    Private Sub imgGrabar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgGrabar.Click
        Dim estado As Boolean
        If Len(Trim(txtCartera.Text)) = 0 Then
            CtlMensajes1.Mensaje("Escriba el nombre de la cartera", "SISTEMA DE GESTIÓN DE COBRANZAS")
        ElseIf Len(Trim(txtCodigo.Text)) = 0 Then
            CtlMensajes1.Mensaje("Escriba un codigo de cartera", "SISTEMA DE GESTIÓN DE COBRANZAS")
        ElseIf Len(Trim(txtMeta.Text)) = 0 Then
            CtlMensajes1.Mensaje("Escriba la meta", "SISTEMA DE GESTIÓN DE COBRANZAS")
        ElseIf IsNumeric(txtMeta.Text) = False Then
            CtlMensajes1.Mensaje("La meta debe de ser númerica", "SISTEMA DE GESTIÓN DE COBRANZAS")
        ElseIf Len(Trim(txtCodigo.Text)) > 20 Then
            CtlMensajes1.Mensaje("El codigo de Cartera no debe de exceder los 20 digitos", "SISTEMA DE GESTIÓN DE COBRANZAS")
        ElseIf Len(Trim(txtCartera.Text)) > 50 Then
            CtlMensajes1.Mensaje("El Nombre de la Cartera no debe de exceder los 50 digitos", "SISTEMA DE GESTIÓN DE COBRANZAS")
        Else
            If lblTituloControl.Text = "NUEVA CARTERA" Then
                BLCartera.Cartera = txtCartera.Text
                BLCartera.CodCartera = txtCodigo.Text
                BLCartera.Meta = txtMeta.Text
                BLCartera.IdCartera = IdCartera
                BLCartera.Tipo = cboTipo.Text
                BLCartera.IdEmpresa = cboEmpresa.Value
                BLCartera.GrpCartera = cbogrpcartera.Value
                BLCartera.MetaPDPT = txtPDPT.Text
                BLCartera.MetaRECT = txtRECT.Text
                estado = BLCartera.NuevaCartera
                If estado = True Then
                    CtlMensajes1.Mensaje("Se ha agregado satisfactoriamente")
                Else
                    CtlMensajes1.Mensaje("Se produjo un error")
                End If
            ElseIf lblTituloControl.Text = "MODIFICAR CARTERA" Then
                BLCartera.Cartera = txtCartera.Text
                BLCartera.CodCartera = txtCodigo.Text
                BLCartera.Meta = txtMeta.Text
                BLCartera.Tipo = cboTipo.Text
                BLCartera.IdCartera = IdCartera
                BLCartera.IdEmpresa = cboEmpresa.Value
                BLCartera.GrpCartera = cbogrpcartera.Value
                BLCartera.MetaPDPT = txtPDPT.Text
                BLCartera.MetaRECT = txtRECT.Text
                estado = BLCartera.ModificarCartera
                If estado = True Then
                    CtlMensajes1.Mensaje("Se ha modificado satisfactoriamente")
                Else
                    CtlMensajes1.Mensaje("Se produjo un error")
                End If
            End If
            txtMeta.Text = ""
            txtCodigo.Text = ""
            txtCartera.Text = ""
        End If
        RaiseEvent Actualizar()
        Call imgCerrar_Click(sender, e)
    End Sub

    Public Property Tipo() As String
        Get
            Return Session("Tipo")
        End Get
        Set(ByVal value As String)
            If value = "ACTIVA" Then
                cboTipo.Text = "ACTIVA"
            ElseIf value = "CASTIGO" Then
                cboTipo.Text = "CASTIGO"
            End If
            Session("Tipo") = value
        End Set
    End Property

    Public Property Codigo() As String
        Get
            Return Session("Codigo")
        End Get
        Set(ByVal value As String)
            Session("Codigo") = value
        End Set
    End Property

    Public Property Cartera() As String
        Get
            Return Session("Cartera")
        End Get
        Set(ByVal value As String)
            Session("Cartera") = value
        End Set
    End Property
    Public Property GrCartera() As String
        Get
            Return Session("GrpCartera")
        End Get
        Set(ByVal value As String)
            Session("GrpCartera") = value
        End Set
    End Property

    Public Property Empresa() As String
        Get
            Return Session("ccEmpresa")
        End Get
        Set(ByVal value As String)
            Session("ccEmpresa") = value
        End Set
    End Property

    Public Property Metas() As Integer
        Get
            Return Session("Metas")
        End Get
        Set(ByVal value As Integer)
            Session("Metas") = value
        End Set
    End Property

    Public Property IdCartera() As String
        Get
            Return lblIdCartera.Text
        End Get
        Set(ByVal value As String)
            lblIdCartera.Text = value
        End Set
    End Property

    Event Actualizar()

    Private Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            cboTipo.Cargar_dll()
            cboEmpresa.Cargar_dll()
            cbogrpcartera.Cargar_dll()
        End If
    End Sub

    Private Sub btnAgregarEmpresa_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAgregarEmpresa.Click
        'If btnAgregarEmpresa.Text = "Agregar Empresa" Then
        '    cboEmpresa.Visible = False
        '    txtEmpresa.Visible = True
        '    btnCancelar.Visible = True
        '    btnAgregarEmpresa.Text = "Aceptar"
        'Else
        '    If Len(Trim(txtEmpresa.Text)) = 0 Then
        '        CtlMensajes1.Mensaje("Falta introducir el nombre de la empresa que se va a registrar")
        '    Else
        '        BLEmpresa.Descripcion = txtEmpresa.Text
        '        BLEmpresa.InsertarEmpresa()
        '        cboEmpresa.Limpia()
        '        cboEmpresa.Cargar_dll()
        '        cboEmpresa.Visible = True
        '        txtEmpresa.Visible = False
        '        btnCancelar.Visible = False
        '        txtEmpresa.Text = ""
        '        btnAgregarEmpresa.Text = "Agregar Empresa"
        '    End If
        'End If
        Response.Redirect("Empresa.aspx")
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        cboEmpresa.Visible = True
        txtEmpresa.Visible = False
        btnCancelar.Visible = False
        txtEmpresa.Text = ""
        btnAgregarEmpresa.Text = "Agregar Empresa"
    End Sub
End Class