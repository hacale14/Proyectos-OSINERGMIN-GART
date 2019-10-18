Public Class Direccion
    Dim pTipo As String
    Dim pReservado As String
    Dim pProvincia As String
    Dim pOrden As Integer
    Dim pMotivoBaja As String
    Dim pIdDireccion As Integer
    Dim pIdCliente As Integer
    Dim pHabilitado As String
    Dim pFecha As String
    Dim pDistrito As String
    Dim pDireccion As String
    Dim pDestino As String
    Dim pDepartamento As String
    Dim pActivo As String

    Public Property Tipo() As String
        Get
            Return pTipo
        End Get
        Set(ByVal value As String)
            pTipo = value
        End Set
    End Property
    Public Property Reservado() As String
        Get
            Return pReservado
        End Get
        Set(ByVal value As String)
            pReservado = value
        End Set
    End Property
    Public Property Provincia() As String
        Get
            Return pProvincia
        End Get
        Set(ByVal value As String)
            pProvincia = value
        End Set
    End Property
    Public Property Orden() As Integer
        Get
            Return pOrden
        End Get
        Set(ByVal value As Integer)
            pOrden = value
        End Set
    End Property
    Public Property MotivoBaja() As String
        Get
            Return pMotivoBaja
        End Get
        Set(ByVal value As String)
            pMotivoBaja = value
        End Set
    End Property
    Public Property IdDireccion() As Integer
        Get
            Return pIdDireccion
        End Get
        Set(ByVal value As Integer)
            pIdDireccion = value
        End Set
    End Property
    Public Property IdCliente() As Integer
        Get
            Return pIdCliente
        End Get
        Set(ByVal value As Integer)
            pIdCliente = value
        End Set
    End Property
    Public Property Habilitado() As String
        Get
            Return pHabilitado
        End Get
        Set(ByVal value As String)
            pHabilitado = value
        End Set
    End Property
    Public Property Fecha() As String
        Get
            Return pFecha
        End Get
        Set(ByVal value As String)
            pFecha = value
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
    Public Property Direccion() As String
        Get
            Return pDireccion
        End Get
        Set(ByVal value As String)
            pDireccion = value
        End Set
    End Property
    Public Property Destino() As String
        Get
            Return pDestino
        End Get
        Set(ByVal value As String)
            pDestino = value
        End Set
    End Property
    Public Property Departamento() As String
        Get
            Return pDepartamento
        End Get
        Set(ByVal value As String)
            pDepartamento = value
        End Set
    End Property
    Public Property Activo() As String
        Get
            Return pActivo
        End Get
        Set(ByVal value As String)
            pActivo = value
        End Set
    End Property
End Class
