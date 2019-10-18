Public Class TipoCambio
    Dim _IdTipoCambio As String
    Dim _Fecha As String
    Dim _TipoCambio As String
    Dim _idEmpresa As String

    Public Property IdEmpresa() As String
        Get
            Return _idEmpresa
        End Get
        Set(ByVal value As String)
            _idEmpresa = value
        End Set
    End Property

    Public Property IdTipoCambio() As String
        Get
            Return _IdTipoCambio
        End Get
        Set(ByVal value As String)
            _IdTipoCambio = value
        End Set
    End Property

    Public Property Fecha() As String
        Get
            Return _Fecha
        End Get
        Set(ByVal value As String)
            _Fecha = value
        End Set
    End Property

    Public Property TipoCambio() As String
        Get
            Return _TipoCambio
        End Get
        Set(ByVal value As String)
            _TipoCambio = value
        End Set
    End Property
End Class
