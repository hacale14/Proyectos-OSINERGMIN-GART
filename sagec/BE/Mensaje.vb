Public Class Mensaje
    Dim pidCliente As Integer
    Dim pMensaje As String
    Dim pFecha As String
    Public Property IdCliente() As Integer
        Get
            Return pIdCliente
        End Get
        Set(ByVal value As Integer)
            pIdCliente = value
        End Set
    End Property
    Public Property Mensaje() As String
        Get
            Return pMensaje
        End Get
        Set(ByVal value As String)
            pMensaje = value
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
