Public Class Cliente
    Dim pIdCliente As String

    Dim pCartera As String
    Dim pCondicion As String
    Dim pSituacion As String
    Dim pDNI As String
    Dim pCliente As String
    Dim pTelefono1 As String
    Dim pTelefono2 As String
    Dim pDistrito As String
    Dim pDireccion As String
    Dim pCelular As String

    Public Property IdCliente() As String
        Get
            Return pIdCliente
        End Get
        Set(ByVal value As String)
            pIdCliente = value
        End Set
    End Property

    Public Property Celular() As String
        Get
            Return pCelular
        End Get
        Set(ByVal value As String)
            pCelular = value
        End Set
    End Property

    Public Property Direccion() As String
        Get
            Return pDireccion
        End Get
        Set(ByVal value As String)
            pDireccion = value
        End Set
    End Property

    Public Property Distrito() As String
        Get
            Return pDistrito
        End Get
        Set(ByVal value As String)
            pDistrito = value
        End Set
    End Property

    Public Property Cartera() As String
        Get
            Return pCartera
        End Get
        Set(ByVal value As String)
            pCartera = value
        End Set
    End Property
    Public Property Condicion() As String
        Get
            Return pCondicion
        End Get
        Set(ByVal value As String)
            pCondicion = value
        End Set
    End Property
    Public Property Situacion() As String
        Get
            Return pSituacion
        End Get
        Set(ByVal value As String)
            pSituacion = value
        End Set
    End Property
    Public Property DNI() As String
        Get
            Return pDNI
        End Get
        Set(ByVal value As String)
            pDNI = value
        End Set
    End Property
    Public Property Cliente() As String
        Get
            Return pCliente
        End Get
        Set(ByVal value As String)
            pCliente = value
        End Set
    End Property
    Public Property Telefono1() As String
        Get
            Return pTelefono1
        End Get
        Set(ByVal value As String)
            pTelefono1 = value
        End Set
    End Property
    Public Property Telefono2() As String
        Get
            Return pTelefono2
        End Get
        Set(ByVal value As String)
            pTelefono2 = value
        End Set
    End Property
End Class
