
Public Class Cartera
    Dim pCodCartera As String
    Dim pCartera As String
    Dim pMeta As String
    Dim pMetaPDPT As String
    Dim pMetaRECT As String
    Dim pTipo As String
    Dim pIdCartera As String
    Dim pIdEmpresa As String
    Dim pGrpCartera As String
    Dim pIdCorporacion As String
    Event Click()

    Public Property IdCorporacion() As String
        Get
            Return pIdCorporacion
        End Get
        Set(ByVal value As String)
            pIdCorporacion = value
        End Set
    End Property

    Public Property IdEmpresa() As String
        Get
            Return pIdEmpresa
        End Get
        Set(ByVal value As String)
            pIdEmpresa = value
        End Set
    End Property

    Public Property MetaPDPT() As String
        Get
            Return pMetaPDPT
        End Get
        Set(ByVal value As String)
            pMetaPDPT = value
        End Set
    End Property
    Public Property MetaRECT() As String
        Get
            Return pMetaRECT
        End Get
        Set(ByVal value As String)
            pMetaRECT = value
        End Set
    End Property
    Public Property Meta() As String
        Get
            Return pMeta
        End Get
        Set(ByVal value As String)
            pMeta = value
        End Set
    End Property
    Public Property Tipo() As String
        Get
            Return pTipo
        End Get
        Set(ByVal value As String)
            pTipo = value
        End Set
    End Property
    Public Property IdCartera() As String
        Get
            Return pIdCartera
        End Get
        Set(ByVal value As String)
            pIdCartera = value
        End Set
    End Property
    Public Property CodCartera() As String
        Get
            Return pCodCartera
        End Get
        Set(ByVal value As String)
            pCodCartera = value
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
    Public Property GrpCartera() As String
        Get
            Return pGrpCartera
        End Get
        Set(ByVal value As String)
            pGrpCartera = value
        End Set
    End Property
End Class
