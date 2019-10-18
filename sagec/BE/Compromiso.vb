Public Class Compromiso
    Dim pCriterio As String
    Public Property Criterio() As String
        Get
            Return pCriterio
        End Get
        Set(ByVal value As String)
            pCriterio = value
        End Set
    End Property
End Class
