Public Class Condicion
    Dim pIdCondicion As Integer
    Dim pCodigo As String
    Dim pDescripcion As String
    Event Click()

    Public Property IdCondicion() As String
        Get
            Return pIdCondicion
        End Get
        Set(ByVal value As String)
            pIdCondicion = value
        End Set
    End Property

    Public Property Codigo() As String
        Get
            Return pCodigo
        End Get
        Set(ByVal value As String)
            pCodigo = value
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
End Class
