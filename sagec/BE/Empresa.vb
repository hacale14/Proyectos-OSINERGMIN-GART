Public Class Empresa
    Dim pCodEmpresa As String
    Dim pCodCorporacion As Integer
    Dim pDescripcion As String

    Public Property CodEmpresa() As String
        Get
            Return pCodEmpresa
        End Get
        Set(ByVal value As String)
            pCodEmpresa = value
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
    Public Property idCorporacion() As Integer
        Get
            Return pCodCorporacion
        End Get
        Set(ByVal value As Integer)
            pCodCorporacion = value
        End Set
    End Property
End Class
