Public Class Telefono
    Dim pidTelefono As String
    Dim pIdCliente As String
    Dim pTelefono As Integer
    Dim pTipoTelefono As String
    Dim pPrioridad As String
    Dim pReservado As String
    Dim pEstado As String
    Dim pObservacion As String
    Dim pOrigen As String
    Dim pFecha As String
    Dim pDNI As String
    Event Click()
    Public Property DNI() As String
        Get
            Return pDNI
        End Get
        Set(ByVal value As String)
            pDNI = value
        End Set
    End Property
    Public Property idTelefono() As String
        Get
            Return pidTelefono
        End Get
        Set(ByVal value As String)
            pidTelefono = value
        End Set
    End Property
    Public Property IdCliente() As String
        Get
            Return pIdCliente
        End Get
        Set(ByVal value As String)
            pIdCliente = value
        End Set
    End Property
    Public Property Telefono() As String
        Get
            Return pTelefono
        End Get
        Set(ByVal value As String)
            pTelefono = value
        End Set
    End Property
    Public Property TipoTelefono() As String
        Get
            Return pTipoTelefono
        End Get
        Set(ByVal value As String)
            pTipoTelefono = value
        End Set
    End Property

    Public Property Prioridad() As String
        Get
            Return pPrioridad
        End Get
        Set(ByVal value As String)
            pPrioridad = value
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
    Public Property Estado() As String
        Get
            Return pEstado
        End Get
        Set(ByVal value As String)
            pEstado = value
        End Set
    End Property
    Public Property Observacion() As String
        Get
            Return pEstado
        End Get
        Set(ByVal value As String)
            pEstado = value
        End Set
    End Property
    Public Property Origen() As String
        Get
            Return pOrigen
        End Get
        Set(ByVal value As String)
            pOrigen = value
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
End Class
