Public Class ReasignarGestores
    Private gmp_dni As String
    Private gmp_idcliente As String
    Private gmp_idusuario As String
    Private gmp_idusuariocliente As String
    Private gmp_nombrecliente As String
    Private gmp_codigo As String
    Private gmp_usuario As String

    Public Property Cliente_DNI() As String
        Get
            Return gmp_dni
        End Get
        Set(ByVal value As String)
            gmp_dni = value
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
End Class
