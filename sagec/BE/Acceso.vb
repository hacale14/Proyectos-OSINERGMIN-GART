Public MustInherit Class Acceso
    Dim pUsuario As String
    Dim pIdUsuario As String
    Dim pTipoUsuario As String
    Dim pClave As String
    Dim pCriterio As String
    Dim pNombreGestor As String
    Dim pCargo As String
    Dim pPerfil As String
    Dim pAnexo As String
    Dim pTipoTroncal As String
    Event Click()
    Public Property TipoTroncal() As String
        Get
            Return pTipoTroncal
        End Get
        Set(ByVal value As String)
            pTipoTroncal = value
        End Set
    End Property
    Public Property TipoUsuario() As String
        Get
            Return pTipoUsuario
        End Get
        Set(ByVal value As String)
            pTipoUsuario = value
        End Set
    End Property
    Public Property Anexo() As String
        Get
            Return pAnexo
        End Get
        Set(ByVal value As String)
            pAnexo = value
        End Set
    End Property
    Public Property IdUsuario() As String
        Get
            Return pIdUsuario
        End Get
        Set(ByVal value As String)
            pIdUsuario = value
        End Set
    End Property
    Public Property NombreGestor() As String
        Get
            Return pNombreGestor
        End Get
        Set(ByVal value As String)
            pNombreGestor = value
        End Set
    End Property
    Public Property Cargo() As String
        Get
            Return pCargo
        End Get
        Set(ByVal value As String)
            pCargo = value
        End Set
    End Property
    Public Property Perfil() As String
        Get
            Return pPerfil
        End Get
        Set(ByVal value As String)
            pPerfil = value
        End Set
    End Property
    Public Property Usuario() As String
        Get
            Return pUsuario
        End Get
        Set(ByVal value As String)
            pUsuario = value
        End Set
    End Property
    Public Property Clave() As String
        Get
            Return pClave
        End Get
        Set(ByVal value As String)
            pClave = value
        End Set
    End Property
    Public Property Criterio() As String
        Get
            Return pCriterio
        End Get
        Set(ByVal value As String)
            pCriterio = value
        End Set
    End Property
End Class
