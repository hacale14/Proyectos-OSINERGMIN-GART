Partial Public Class Gestion
    Inherits System.Web.UI.UserControl
    Dim Out_DeudaTotalSoles As Boolean
    Dim Out_DeudaVSolesUno As Boolean
    Dim Out_DeudaVDolaresUno As Boolean
    Dim Out_DeudaTotalDolares As Boolean
    Dim Out_DeudaVDolaresDos As Boolean
    Dim Out_DeudaVSolesDos As Boolean
    Dim Out_MTSoles As Boolean
    Dim Out_MKSoles As Boolean
    Dim Out_MTDolares As Boolean
    Dim Out_MKDolares As Boolean
    Dim Out_BotonDeuda As Boolean
    Dim Out_BotonPagos As Boolean
    Dim Out_BotonCompromiso As Boolean
    Dim Out_BotonHistorial As Boolean

    Public Property DeudaTotalSoles() As Boolean
        Get
            Return Out_DeudaTotalSoles
        End Get
        Set(ByVal value As Boolean)
            Out_DeudaTotalSoles = value
            lblDeudaTotalSoles.Visible = Out_DeudaTotalSoles
            txtDeudaTotalSoles.Visible = Out_DeudaTotalSoles
        End Set
    End Property
    Public Property DeudaVSolesPrimero() As Boolean
        Get
            Return Out_DeudaVSolesUno
        End Get
        Set(ByVal value As Boolean)
            Out_DeudaVSolesUno = value
            lblDeudaVSoles1.Visible = Out_DeudaVSolesUno
            txtDeudaVSoles1.Visible = Out_DeudaVSolesUno
        End Set
    End Property
    Public Property DeudaVDolaresPrimero() As Boolean
        Get
            Return Out_DeudaVDolaresUno
        End Get
        Set(ByVal value As Boolean)
            Out_DeudaVDolaresUno = value
            lblDeudaVDolares1.Visible = Out_DeudaVDolaresUno
            txtDeudaVDolares1.Visible = Out_DeudaVDolaresUno
        End Set
    End Property
    Public Property DeudaTotalDolares() As Boolean
        Get
            Return Out_DeudaTotalDolares
        End Get
        Set(ByVal value As Boolean)
            Out_DeudaTotalDolares = value
            lblDeudaTotalDolares.Visible = Out_DeudaTotalDolares
            txtDeudaTotalDolares.Visible = Out_DeudaTotalDolares
        End Set
    End Property
    Public Property DeudaVDoralesDos() As Boolean
        Get
            Return Out_DeudaVDolaresDos
        End Get
        Set(ByVal value As Boolean)
            Out_DeudaVDolaresDos = value
            lblDeudaVDolares2.Visible = Out_DeudaVDolaresDos
            txtDeudaVDolares2.Visible = Out_DeudaVDolaresDos
        End Set
    End Property
    Public Property DeudaVSolesDos() As Boolean
        Get
            Return Out_DeudaVSolesDos
        End Get
        Set(ByVal value As Boolean)
            Out_DeudaVSolesDos = value
            lblDeudaVSoles2.Visible = Out_DeudaVSolesDos
            txtDeudaVSoles2.Visible = Out_DeudaVSolesDos
        End Set
    End Property
    Public Property MTSoles() As Boolean
        Get
            Return Out_MTSoles
        End Get
        Set(ByVal value As Boolean)
            Out_MTSoles = value
            lblMTSoles.Visible = Out_MTSoles
            txtMTSoles.Visible = Out_MTSoles
        End Set
    End Property
    Public Property MKSoles() As Boolean
        Get
            Return Out_MKSoles
        End Get
        Set(ByVal value As Boolean)
            Out_MKSoles = value
            lblMKSoles.Visible = Out_MKSoles
            txtMKSoles.Visible = Out_MKSoles
        End Set
    End Property
    Public Property MTDolares() As Boolean
        Get
            Return Out_MTDolares
        End Get
        Set(ByVal value As Boolean)
            Out_MTDolares = value
            lblMTDolares.Visible = Out_MTDolares
            txtMTDolares.Visible = Out_MTDolares
        End Set
    End Property
    Public Property MKDolares() As Boolean
        Get
            Return Out_MKDolares
        End Get
        Set(ByVal value As Boolean)
            Out_MKDolares = value
            lblMKDolares.Visible = Out_MKDolares
            txtMKDolares.Visible = Out_MKDolares
        End Set
    End Property

    'Public Property BotonDeuda() As Boolean
    '    Get
    '        Return Out_BotonDeuda
    '    End Get
    '    Set(ByVal value As Boolean)
    '        Out_BotonDeuda = value
    '        lblBotonDeuda.Visible = Out_BotonDeuda
    '        btnDeuda.Visible = Out_BotonDeuda
    '    End Set
    'End Property
    Public Property BotonPagos() As Boolean
        Get
            Return Out_BotonPagos
        End Get
        Set(ByVal value As Boolean)
            Out_BotonPagos = value
            lblBotonPago.Visible = Out_BotonPagos
            btnPagos.Visible = Out_BotonPagos
        End Set
    End Property
    Public Property BotonCompromiso() As Boolean
        Get
            Return Out_BotonCompromiso
        End Get
        Set(ByVal value As Boolean)
            Out_BotonCompromiso = value
            lblBotonCompromiso.Visible = Out_BotonCompromiso
            btnCompromiso.Visible = Out_BotonCompromiso
        End Set
    End Property
    Public Property BotonHistorial() As Boolean
        Get
            Return Out_BotonHistorial
        End Get
        Set(ByVal value As Boolean)
            Out_BotonHistorial = value
            lblBotonHistorial.Visible = Out_BotonHistorial
            btnHistorial.Visible = Out_BotonHistorial
        End Set
    End Property
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub btnNueva_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnNueva.Click
        'RaiseEvent NuevaGestion()
    End Sub

    Event Cerrar()
    Private Sub btnCerrar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnCerrar.Click
        RaiseEvent Cerrar()
    End Sub

    Private Sub btnPagos_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnPagos.Click
        pnlPagos.Visible = True
    End Sub

    Private Sub btnCompromiso_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnCompromiso.Click
        pnlCompromisos.Visible = True
    End Sub

End Class