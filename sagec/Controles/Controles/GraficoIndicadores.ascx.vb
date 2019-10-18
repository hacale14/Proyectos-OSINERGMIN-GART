Partial Public Class GraficoIndicadores
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            'Dim dt As New DataTable
            'dt.Columns.Add("Status")
            'dt.Columns.Add("Total")
            'dt.Rows.Add("Success", 34)
            'dt.Rows.Add("Missing", 2)
            'dt.Rows.Add("Failed", 10)
            'dt.Rows.Add("1", 10)
            'dt.Rows.Add("2", 10)
            'dt.Rows.Add("3", 10)
            'dt.Rows.Add("4", 10)

            'Chart2.DataSource = dt
            'Chart2.Series("Series1").XValueMember = "Status"
            'Chart2.Series("Series1").YValueMembers = "Total"
            'Chart2.DataBind()
        End If
    End Sub

    Public Property SumaPagos() As Double
        Get
            Return Session("SumaPagos")
        End Get
        Set(ByVal value As Double)
            Session("SumaPagos") = value
        End Set
    End Property

    Public Property DeudaVencida() As Double
        Get
            Return Session("DeudaVencida")
        End Get
        Set(ByVal value As Double)
            Session("DeudaVencida") = value
        End Set
    End Property

    Public Property CuentasGestionadas() As Integer
        Get
            Return Session("CuentasGestionadas")
        End Get
        Set(ByVal value As Integer)
            Session("CuentasGestionadas") = value
        End Set
    End Property

    Public Property CuentasAsignadas() As Integer
        Get
            Return Session("CuentasAsignadas")
        End Get
        Set(ByVal value As Integer)
            Session("CuentasAsignadas") = value
        End Set
    End Property

    Public Property PromesasPago() As Integer
        Get
            Return Session("PromesasPago")
        End Get
        Set(ByVal value As Integer)
            Session("PromesasPago") = value
        End Set
    End Property

    Public Property GestionDirecta() As Integer
        Get
            Return Session("GestionDirecta")
        End Get
        Set(ByVal value As Integer)
            Session("GestionDirecta") = value
        End Set
    End Property


    Sub CargarDatos()
        Dim dt As New DataTable
        dt.Columns.Add("Status")
        dt.Columns.Add("Total")
        dt.Clear()
        'Efectividad        
        dt.Rows.Add("Efectivo", SumaPagos)
        dt.Rows.Add("No Efectivo", DeudaVencida - SumaPagos)
        TortaEfectividad.Titles(0).Text = "INDICE DE EFECTIVIDAD"
        TortaEfectividad.DataSource = dt
        TortaEfectividad.Series("Series1").XValueMember = "Status"
        TortaEfectividad.Series("Series1").YValueMembers = "Total"
        TortaEfectividad.DataBind()

        dt.Clear()
        'Cobertura
        dt.Rows.Add("Coberturado", CuentasGestionadas)
        dt.Rows.Add("No Coberturado", CuentasAsignadas - CuentasGestionadas)
        TortaCobertura.Titles(0).Text = "INDICE DE COBERTURA"
        TortaCobertura.DataSource = dt
        TortaCobertura.Series("Series1").XValueMember = "Status"
        TortaCobertura.Series("Series1").YValueMembers = "Total"
        TortaCobertura.DataBind()

        dt.Clear()
        'PDP
        dt.Rows.Add("Promesas de Pago", PromesasPago)
        dt.Rows.Add("Sin Promesas", GestionDirecta - PromesasPago)
        TortaPDP.Titles(0).Text = "INDICE DE CIERRE DE PDP"
        TortaPDP.DataSource = dt
        TortaPDP.Series("Series1").XValueMember = "Status"
        TortaPDP.Series("Series1").YValueMembers = "Total"
        TortaPDP.DataBind()
    End Sub

    Event Cerrar()

    Private Sub imgCerrar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgCerrar.Click
        RaiseEvent Cerrar()
    End Sub
End Class