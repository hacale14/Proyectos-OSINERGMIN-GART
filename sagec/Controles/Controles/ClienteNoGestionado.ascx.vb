Imports BL
Partial Public Class ClienteNoGestionado
    Inherits System.Web.UI.UserControl
    Dim BLReporte As New BL.Reporte

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            Session("CriterioCartera") = ""
            Session("CriterioGestor") = ""
            Session("CriterioFechaInicio") = ""
            Session("CriterioFechaFin") = ""
            Session("CriterioCarteraFecha") = ""
        End If
    End Sub

    Public Property CriterioCartera()
        Get
            Return Session("CriterioCartera")
        End Get
        Set(ByVal value)
            Session("CriterioCartera") = value
        End Set
    End Property

    Public Property CriterioGestor()
        Get
            Return Session("CriterioGestor")
        End Get
        Set(ByVal value)
            Session("CriterioGestor") = value
        End Set
    End Property

    Public Property CriterioFechaInicio()
        Get
            Return Session("CriterioFechaInicio")
        End Get
        Set(ByVal value)
            Session("CriterioFechaInicio") = value
        End Set
    End Property

    Public Property CriterioFechaFin()
        Get
            Return Session("CriterioFechaFin")
        End Get
        Set(ByVal value)
            Session("CriterioFechaFin") = value
        End Set
    End Property
    Public Property CriterioCartera_Fecha()
        Get
            Return Session("CriterioCarteraFecha")
        End Get
        Set(ByVal value)
            Session("CriterioCarteraFecha") = value
        End Set
    End Property

    Sub CargarDatos()
        'Dim dt As New DataTable
        'dt = BLReporte.ReporteClienteNoGestionado(CriterioCartera_Fecha, CriterioCartera, CriterioGestor, CriterioFechaInicio, CriterioFechaFin)
        'CtlGrilla1.SourceDataTable = dt
        'lblCantidad.Text = "Total de Clientes NO Atendidos=" & dt.Rows.Count
        BLReporte.ReporteClienteNoGestionadoBatch(Session("NombreGestor"), CriterioCartera_Fecha, CriterioCartera, CriterioGestor, CriterioFechaInicio, CriterioFechaFin)
    End Sub

    Private Sub imgCerrar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgCerrar.Click
        RaiseEvent Cerrar()
    End Sub
    Event Cerrar()
End Class