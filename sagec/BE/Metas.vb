Public Class Metas
    Private gmp_criterio_todos As String
    Private gmp_criterioGestor As String
    Private gmp_tipocambio As Double
    Private gmp_criterio As String
    Private gmp_idcartera As Integer
    Private gmp_idusuario As Integer
    Private gmp_moneda As String
    Private gmp_totalcobrado As Double
    Private gmp_porcentaje As Double
    Private gmp_usuario As String
    Private gmp_cartera As String
    Private gmp_deudatotal As Double
    Private gmp_meta As String
    Private gmp_SumaCobro As Double
    Private gmp_sumameta As Double

    Public Property SumaMeta() As Double
        Get
            Return gmp_sumameta
        End Get
        Set(ByVal value As Double)
            gmp_sumameta = value
        End Set
    End Property
    Public Property SumaCobro() As Double
        Get
            Return gmp_SumaCobro
        End Get
        Set(ByVal value As Double)
            gmp_SumaCobro = value
        End Set
    End Property
    Public Property Meta() As String
        Get
            Return gmp_meta
        End Get
        Set(ByVal value As String)
            gmp_meta = value
        End Set
    End Property
    Public Property Deuda_Total() As Double
        Get
            Return gmp_deudatotal
        End Get
        Set(ByVal value As Double)
            gmp_deudatotal = value
        End Set
    End Property
    Public Property Cartera() As String
        Get
            Return gmp_cartera
        End Get
        Set(ByVal value As String)
            gmp_cartera = value
        End Set
    End Property
    Public Property Usuario() As String
        Get
            Return gmp_usuario
        End Get
        Set(ByVal value As String)
            gmp_usuario = value
        End Set
    End Property
    Public Property Porcentaje() As Double
        Get
            Return gmp_Porcentaje
        End Get
        Set(ByVal value As Double)
            gmp_Porcentaje = value
        End Set
    End Property
    Public Property TotalCobrado() As Double
        Get
            Return gmp_totalcobrado
        End Get
        Set(ByVal value As Double)
            gmp_totalcobrado = value
        End Set
    End Property
    Public Property Moneda_Deuda() As String
        Get
            Return gmp_moneda
        End Get
        Set(ByVal value As String)
            gmp_moneda = value
        End Set
    End Property
    Public Property ID_Usuario() As Integer
        Get
            Return gmp_idusuario
        End Get
        Set(ByVal value As Integer)
            gmp_idusuario = value
        End Set
    End Property
    Public Property ID_Cartera() As Integer
        Get
            Return gmp_idcartera
        End Get
        Set(ByVal value As Integer)
            gmp_idcartera = value
        End Set
    End Property
    Public Property Criterio() As String
        Get
            Return gmp_criterio
        End Get
        Set(ByVal value As String)
            gmp_criterio = value
        End Set
    End Property
    Public Property Tipo_Cambio() As Double
        Get
            Return gmp_tipocambio
        End Get
        Set(ByVal value As Double)
            gmp_tipocambio = value
        End Set
    End Property
    Public Property Criterio_Gestor() As String
        Get
            Return gmp_criterioGestor
        End Get
        Set(ByVal value As String)
            gmp_criterioGestor = value
        End Set
    End Property
    Public Property Criterio_Todos() As String
        Get
            Return gmp_criterio_todos
        End Get
        Set(ByVal value As String)
            gmp_criterio_todos = value
        End Set
    End Property
End Class
