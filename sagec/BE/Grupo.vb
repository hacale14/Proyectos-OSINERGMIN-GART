Public Class Grupo
    Dim pCodEmpresa As String
    Dim pCodGrupo As Integer
    Dim pDescripcion As String

    Public Property idGrupo() As String
        Get
            Return pCodGrupo
        End Get
        Set(ByVal value As String)
            pCodGrupo = value
        End Set
    End Property

    Public Property Descripcion() As String
        Get
            Return pDescripcion
        End Get
        Set(ByVal value As String)
            pDescripcion = value
        End Set
    End Property
    Public Property idEmpresa() As Integer
        Get
            Return pCodEmpresa
        End Get
        Set(ByVal value As Integer)
            pCodEmpresa = value
        End Set
    End Property
End Class
