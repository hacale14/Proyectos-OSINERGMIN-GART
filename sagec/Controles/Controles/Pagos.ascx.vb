Public Partial Class Pagos
    Inherits System.Web.UI.UserControl
    Dim blPagos As New BL.Pagos
    Dim gmp_fcliente As Boolean
    Dim gmp_fgestor As Boolean
    Public Property ComboCartera() As Boolean
        Get
            Return cboCartera.Ocultar
        End Get
        Set(ByVal value As Boolean)
            cboCartera.Ocultar = value
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
    Public Property FCliente() As Boolean
        Get
            Return FCliente
        End Get
        Set(ByVal value As Boolean)
            If Trim(value) = "" Then
                gmp_fcliente = False
            Else
                gmp_fcliente = value
            End If

        End Set
    End Property
    Public Property FGestor() As Boolean
        Get
            Return gmp_fgestor
        End Get
        Set(ByVal value As Boolean)
            If Trim(value) = "" Then
                gmp_fgestor = False
            Else
                gmp_fgestor = value
            End If
        End Set
    End Property
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            Cargar_Datos()
        End If
    End Sub

    Event Botones(ByVal Nombre As String)

    Private Sub btnNuevo_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnNuevo.Click

    End Sub

    Private Sub btnMetas_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnMetas.Click

    End Sub
    
    Private Sub btnCerrar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnCerrar.Click

    End Sub

    Private Sub btnBuscar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnBuscar.Click
        Dim FechaInicio As String = txtFechaInicio.Text
        Dim FechaFin As String = txtFechaFin.Text
        'gvPagos.SourceDataTable = blPagos.CriteriosBusqueda(txtDNI.Text, txtCliente.Text, FechaInicio, FechaFin, cboCartera.Text)
    End Sub
    Private Sub Cargar_Datos()
        If FCliente = True Then
        ElseIf FGestor = True Then            
        Else
            'txtFechaInicio.Text = Format(DateTime.Now, "dd/MM/yyyy")
            'txtFechaFin.Text = Format(DateTime.Now, "dd/MM/yyyy")
            'gvPagos.SourceDataTable = blPagos.CriteriosBusqueda("", "", DateTime.Now, DateTime.Now, "")
        End If
    End Sub
End Class