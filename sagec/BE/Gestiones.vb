Public Class Gestiones
    Dim pIdGestion As Integer
    Dim pIdCliente As Integer
    Dim pDNI As String
    Dim pIdUsuario As Integer
    Dim pGestion As String
    Dim pFecha As String
    Dim pHora As String
    Dim pEstado As String
    Dim pTipoTel As String
    Dim pTipoOperador As String
    Dim pCodIndicador As String
    Dim pIdIndicador As String
    Dim ptelefono As String
    Dim pidEmpresa As Integer
    Public Property idEmpresa() As Integer
        Get
            Return pidEmpresa
        End Get
        Set(ByVal value As Integer)
            pidEmpresa = value
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
    Public Property IdGestion() As Integer
        Get
            Return pIdGestion
        End Get
        Set(ByVal value As Integer)
            pIdGestion = value
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
    Public Property IdUsuario() As Integer
        Get
            Return pIdUsuario
        End Get
        Set(ByVal value As Integer)
            pIdUsuario = value
        End Set
    End Property
    Public Property Gestion() As String
        Get
            Return pGestion
        End Get
        Set(ByVal value As String)
            pGestion = value
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
    Public Property Hora() As String
        Get
            Return pHora
        End Get
        Set(ByVal value As String)
            pHora = value
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
    Public Property TipoTel() As String
        Get
            Return pTipoTel
        End Get
        Set(ByVal value As String)
            pTipoTel = value
        End Set
    End Property
    Public Property TipoOperador() As String
        Get
            Return pTipoOperador
        End Get
        Set(ByVal value As String)
            pTipoOperador = value
        End Set
    End Property    
    Public Property CodIndicador() As String
        Get
            Return pCodIndicador
        End Get
        Set(ByVal value As String)
            pCodIndicador = value
        End Set
    End Property
    Public Property IdIndicador() As String
        Get
            Return pIdIndicador
        End Get
        Set(ByVal value As String)
            pIdIndicador = value
        End Set
    End Property
    Public Property Telefono() As String
        Get
            Return ptelefono
        End Get
        Set(ByVal value As String)
            ptelefono = value
        End Set
    End Property
End Class
