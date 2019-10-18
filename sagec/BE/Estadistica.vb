Public Class Estadistica
    Dim pIdCliente As Integer
    Dim pCantidad_Gestion As Double
    Dim pCantidad_Gestionado As Double
    Dim pRecupero_Gestion As Double
    Dim pMeta_Gestionado As Double
    Dim pPorcentajeGestion As Double
    Dim pPorcentajeRecupero As Double
    Dim pGestor As String
    Dim pCartera As String
    Dim pidUsuario As Integer
    Dim pidCartera As Integer

    Public Property idUsuario() As Integer
        Get
            Return pidUsuario
        End Get
        Set(ByVal value As Integer)
            pidUsuario = value
        End Set
    End Property
    Public Property idCartera() As Integer
        Get
            Return pidCartera
        End Get
        Set(ByVal value As Integer)
            pidCartera = value
        End Set
    End Property
    Public Property Gestor() As String
        Get
            Return pGestor
        End Get
        Set(ByVal value As String)
            pGestor = value
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
    Public Property IdCliente() As Double
        Get
            Return pIdCliente
        End Get
        Set(ByVal value As Double)
            pIdCliente = value
        End Set
    End Property
    Public Property Cantidad_Gestion() As Double
        Get
            Return pCantidad_Gestion
        End Get
        Set(ByVal value As Double)
            pCantidad_Gestion = value
        End Set
    End Property
    Public Property Cantidad_Gestionado() As Double
        Get
            Return pCantidad_Gestionado
        End Get
        Set(ByVal value As Double)
            pCantidad_Gestionado = value
        End Set
    End Property
    Public Property Recupero_Gestion() As Double
        Get
            Return pRecupero_Gestion
        End Get
        Set(ByVal value As Double)
            pRecupero_Gestion = value
        End Set
    End Property
    Public Property Meta_Gestionado() As Double
        Get
            Return pMeta_Gestionado
        End Get
        Set(ByVal value As Double)
            pMeta_Gestionado = value
        End Set
    End Property
    Public Property PorcentajeGestion() As Double
        Get
            Return pPorcentajeGestion
        End Get
        Set(ByVal value As Double)
            pPorcentajeGestion = value
        End Set
    End Property
    Public Property PorcentajeRecupero() As Double
        Get
            Return pPorcentajeRecupero
        End Get
        Set(ByVal value As Double)
            pPorcentajeRecupero = value
        End Set
    End Property
End Class
