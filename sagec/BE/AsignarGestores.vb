Public Class AsignarGestores
    'Asignar Gestor
    Private gmp_desde As String
    Private gmp_hasta As String
    Private gmp_idcartera As String
    Private gmp_idgestor As String
    Private gmp_idcliente As String
    Private gmp_cantidad As String
    'Reasignar Gestor
    Private gmp_dni As String
    Private gmp_idusuario As String
    Private gmp_idusuariocliente As String
    Private gmp_nombrecliente As String
    Private gmp_codigo As String
    Private gmp_usuario As String
    'Modificar Asignaciones
    Private gmp_clienteactual As Boolean
    Private gmp_todosclientes As Boolean
    Private gmp_rangoclientes As Boolean
    Private gmp_datatable As New DataTable
    'Asignar Gestores
    Public Property Cantidad() As String
        Get
            Return gmp_cantidad
        End Get
        Set(ByVal value As String)
            gmp_cantidad = value
        End Set
    End Property
    Public Property Desde() As String
        Get
            Return gmp_desde
        End Get
        Set(ByVal value As String)
            gmp_desde = value
        End Set
    End Property
    Public Property Hasta() As String
        Get
            Return gmp_hasta
        End Get
        Set(ByVal value As String)
            gmp_hasta = value
        End Set
    End Property
    Public Property Cartera_ID() As String
        Get
            Return gmp_idcartera
        End Get
        Set(ByVal value As String)
            gmp_idcartera = value
        End Set
    End Property
    Public Property Gestor_ID() As String
        Get
            Return gmp_idgestor
        End Get
        Set(ByVal value As String)
            gmp_idgestor = value
        End Set
    End Property
    Public Property Cliente_ID() As String
        Get
            Return gmp_idcliente
        End Get
        Set(ByVal value As String)
            gmp_idcliente = value
        End Set
    End Property
    'Reasignar Gestores
    Public Property Cliente_DNI() As String
        Get
            Return gmp_dni
        End Get
        Set(ByVal value As String)
            gmp_dni = value
        End Set
    End Property
    Public Property Usuario_ID() As String
        Get
            Return gmp_idusuario
        End Get
        Set(ByVal value As String)
            gmp_idusuario = value
        End Set
    End Property
    Public Property UsuarioCliente_ID() As String
        Get
            Return gmp_idusuariocliente
        End Get
        Set(ByVal value As String)
            gmp_idusuariocliente = value
        End Set
    End Property
    Public Property NombreCliente() As String
        Get
            Return gmp_nombrecliente
        End Get
        Set(ByVal value As String)
            gmp_nombrecliente = value
        End Set
    End Property
    Public Property Codigo() As String
        Get
            Return gmp_codigo
        End Get
        Set(ByVal value As String)
            gmp_codigo = value
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
    'Modificar Asginaciones
    Public Property Cliente_Actual() As Boolean
        Get
            Return gmp_clienteactual
        End Get
        Set(ByVal value As Boolean)
            gmp_clienteactual = value
        End Set
    End Property
    Public Property Todos_Clientes() As Boolean
        Get
            Return gmp_todosclientes
        End Get
        Set(ByVal value As Boolean)
            gmp_todosclientes = value
        End Set
    End Property
    Public Property Rango_Clientes() As Boolean
        Get
            Return gmp_rangoclientes
        End Get
        Set(ByVal value As Boolean)
            gmp_rangoclientes = value
        End Set
    End Property
    Public Property DatosBuscados() As DataTable
        Get
            Return gmp_datatable
        End Get
        Set(ByVal value As DataTable)
            gmp_datatable = value
        End Set
    End Property
End Class
