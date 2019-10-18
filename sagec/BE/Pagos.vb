Public Class Pagos
    'Criterios 
    Dim gmp_dni As String
    Dim gmp_cliente As String
    Dim gmp_fechainicio As String
    Dim gmp_fechafin As String
    Dim gmp_Cartera As String
    Dim gmp_CriterioTodos As String
    Dim gmp_CriterioEstado As String
    Dim gmp_Criterio As String
    Dim pidPago As Integer
    'Datos para Mantenimiento de pago (Nuevo - Modificar)
    Dim dt_dni As String
    Dim dt_cartera As String
    'Criterios
    Public Property idPago() As Integer
        Get
            Return pidPago
        End Get
        Set(ByVal value As Integer)
            pidPago = value
        End Set
    End Property
    Public Property Criterio() As String
        Get
            Return gmp_Criterio
        End Get
        Set(ByVal value As String)
            gmp_Criterio = value
        End Set
    End Property
    Public Property CriterioEstado() As String
        Get
            Return gmp_CriterioEstado
        End Get
        Set(ByVal value As String)
            gmp_CriterioEstado = value
        End Set
    End Property
    Public Property CriterioTodos() As String
        Get
            Return gmp_CriterioTodos
        End Get
        Set(ByVal value As String)
            gmp_CriterioTodos = value
        End Set
    End Property
    Public Property CriterioDNI() As String
        Get
            Return gmp_dni
        End Get
        Set(ByVal value As String)
            gmp_dni = value
        End Set
    End Property
    Public Property CriterioCliente() As String
        Get
            Return gmp_cliente
        End Get
        Set(ByVal value As String)
            gmp_cliente = value
        End Set
    End Property
    Public Property CriterioFechaInicio() As String
        Get
            Return gmp_fechainicio
        End Get
        Set(ByVal value As String)
            gmp_fechainicio = value
        End Set
    End Property
    Public Property CriterioFechaFin() As String
        Get
            Return gmp_fechafin
        End Get
        Set(ByVal value As String)
            gmp_fechafin = value
        End Set
    End Property
    Public Property CriterioCartera() As String
        Get
            Return gmp_Cartera
        End Get
        Set(ByVal value As String)
            gmp_Cartera = value
        End Set
    End Property

    'Datos para Mantenimiento
    Public Property DNI() As String
        Get
            Return dt_dni
        End Get
        Set(ByVal value As String)
            dt_dni = value
        End Set
    End Property
    Public Property Cartera_ID() As String
        Get
            Return dt_cartera
        End Get
        Set(ByVal value As String)
            dt_cartera = value
        End Set
    End Property
End Class