Public Class ConsultaAsignacion
    'Criterios
    Dim gmp_criterioTodos As String
    Dim gmp_concompromiso As Boolean
    Dim gmp_criterioEstado As String
    Dim gmp_criterioIdCartera As String
    'Campos
    Dim gmp_Cartera As String
    Dim gmp_Gestor As String
    Dim gmp_Condicion As String
    Dim gmp_Dni As String
    Dim gmp_NombreCliente As String
    Dim gmp_Telefono As String
    Dim gmp_TipoCartera As String
    Dim gmp_Refinanciado As String
    Dim gmp_Campaña As String
    Dim gmp_Producto As String
    Dim gmp_Negocio As String
    Dim gmp_NroOperacion As String
    Dim gmp_NroCuenta As String
    Dim gmp_DiasMora As String

    'Criterios
    Public Property CriterioIdCartera() As String
        Get
            Return gmp_criterioIdCartera
        End Get
        Set(ByVal value As String)
            gmp_criterioIdCartera = value
        End Set
    End Property
    Public Property ConCompromiso() As Boolean
        Get
            Return gmp_concompromiso
        End Get
        Set(ByVal value As Boolean)
            gmp_concompromiso = value
        End Set
    End Property
    Public Property CriterioTodos() As String
        Get
            Return gmp_criterioTodos
        End Get
        Set(ByVal value As String)
            gmp_criterioTodos = value
        End Set
    End Property
    Public Property CriterioEstado() As String
        Get
            Return gmp_criterioEstado
        End Get
        Set(ByVal value As String)
            gmp_criterioEstado = value
        End Set
    End Property
    'Campos
    Public Property DiasMora() As String
        Get
            Return gmp_DiasMora
        End Get
        Set(ByVal value As String)
            gmp_DiasMora = value
        End Set
    End Property
    Public Property Cuenta() As String
        Get
            Return gmp_NroCuenta
        End Get
        Set(ByVal value As String)
            gmp_NroCuenta = value
        End Set
    End Property
    Public Property Nro_Operacion() As String
        Get
            Return gmp_NroOperacion
        End Get
        Set(ByVal value As String)
            gmp_NroOperacion = value
        End Set
    End Property
    Public Property Negocio() As String
        Get
            Return gmp_Negocio
        End Get
        Set(ByVal value As String)
            gmp_Negocio = value
        End Set
    End Property
    Public Property Producto() As String
        Get
            Return gmp_Producto
        End Get
        Set(ByVal value As String)
            gmp_Producto = value
        End Set
    End Property
    Public Property Campaña() As String
        Get
            Return gmp_Campaña
        End Get
        Set(ByVal value As String)
            gmp_Campaña = value
        End Set
    End Property
    Public Property Refinanciados() As String
        Get
            Return gmp_Refinanciado
        End Get
        Set(ByVal value As String)
            gmp_Refinanciado = value
        End Set
    End Property
    Public Property Cartera() As String
        Get
            Return gmp_Cartera
        End Get
        Set(ByVal value As String)
            gmp_Cartera = value
        End Set
    End Property
    Public Property Gestor() As String
        Get
            Return gmp_Gestor
        End Get
        Set(ByVal value As String)
            gmp_Gestor = value
        End Set
    End Property
    Public Property Condicion() As String
        Get
            Return gmp_Condicion
        End Get
        Set(ByVal value As String)
            gmp_Condicion = value
        End Set
    End Property
    Public Property Dni() As String
        Get
            Return gmp_Dni
        End Get
        Set(ByVal value As String)
            gmp_Dni = value
        End Set
    End Property
    Public Property NombreCliente() As String
        Get
            Return gmp_NombreCliente
        End Get
        Set(ByVal value As String)
            gmp_NombreCliente = value
        End Set
    End Property
    Public Property Telefono() As String
        Get
            Return gmp_Telefono
        End Get
        Set(ByVal value As String)
            gmp_Telefono = value
        End Set
    End Property
    Public Property TipoCartera() As String
        Get
            Return gmp_TipoCartera
        End Get
        Set(ByVal value As String)
            gmp_TipoCartera = value
        End Set
    End Property
End Class