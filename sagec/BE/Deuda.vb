
Public Class Deuda
    Dim pIdCliente As Integer
    Dim pIdOperacion As String
    Dim pDeudaVencidadSoles As Double
    Dim pDeudaVencidadDolares As Double
    Dim pDeudaVencidadDolaresSoles As Double
    Dim pDeudaVencidadSolesDolares As Double
    Dim pDeudaTotalVencidadSoles As Double
    Dim pDeudaTotalVencidadDolares As Double
    Dim pSaldoCapital As Double
    Dim pInteres As Double
    Dim pComisiones As Double
    Dim pMora As Double
    Dim pTipoCartera As String
    Public ArrCuotas(10, 500) As Double
    Public Property TipoCartera() As String
        Get
            Return pTipoCartera
        End Get
        Set(ByVal value As String)
            pTipoCartera = value
        End Set
    End Property
    Public Property IdCliente() As String
        Get
            Return pIdCliente
        End Get
        Set(ByVal value As String)
            pIdCliente = value
        End Set
    End Property
    Public Property IdOperacion() As String
        Get
            Return pIdOperacion
        End Get
        Set(ByVal value As String)
            pIdOperacion = value
        End Set
    End Property
    Public Property DeudaTotalVencidadDolares() As Double
        Get
            Return pDeudaTotalVencidadDolares
        End Get
        Set(ByVal value As Double)
            pDeudaTotalVencidadDolares = value
        End Set
    End Property
    Public Property DeudaTotalVencidadSoles() As Double
        Get
            Return pDeudaTotalVencidadSoles
        End Get
        Set(ByVal value As Double)
            pDeudaTotalVencidadSoles = value
        End Set
    End Property
    Public Property DeudaVencidadSoles() As Double
        Get
            Return pDeudaVencidadSoles
        End Get
        Set(ByVal value As Double)
            pDeudaVencidadSoles = value
        End Set
    End Property
    Public Property DeudaVencidadDolares() As Double
        Get
            Return pDeudaVencidadDolares
        End Get
        Set(ByVal value As Double)
            pDeudaVencidadDolares = value
        End Set
    End Property
    Public Property DeudaVencidadDolaresSoles() As Double
        Get
            Return pDeudaVencidadDolaresSoles
        End Get
        Set(ByVal value As Double)
            pDeudaVencidadDolaresSoles = value
        End Set
    End Property
    Public Property DeudaVencidadSolesDolares() As Double
        Get
            Return pDeudaVencidadSolesDolares
        End Get
        Set(ByVal value As Double)
            pDeudaVencidadSolesDolares = value
        End Set
    End Property
    Public Property SaldoCapital() As Double
        Get
            Return pSaldoCapital
        End Get
        Set(ByVal value As Double)
            pSaldoCapital = value
        End Set
    End Property
    Public Property Interes() As Double
        Get
            Return pInteres
        End Get
        Set(ByVal value As Double)
            pInteres = value
        End Set
    End Property
    Public Property Comisiones() As Double
        Get
            Return pComisiones
        End Get
        Set(ByVal value As Double)
            pComisiones = value
        End Set
    End Property
    Public Property Mora() As Double
        Get
            Return pMora
        End Get
        Set(ByVal value As Double)
            pMora = value
        End Set
    End Property

End Class
