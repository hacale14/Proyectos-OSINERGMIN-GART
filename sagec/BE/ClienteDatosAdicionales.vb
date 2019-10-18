Public Class ClienteDatosAdicionales
    Dim pidCliente As Integer
    Dim pidCartera As Integer
    Dim pidEmpresa As Integer
    Dim pDNI As String
    Dim pemail As String
    Dim paval As String
    Dim pRepLegal As String
    Dim pEdad As String
    Dim pSueldo As Double
    Dim pConyugue As String
    Dim pcentrolaboral As String
    Dim pTelfxVer As String
    Public Property idEmpresa() As Integer
        Get
            Return pidEmpresa
        End Get
        Set(ByVal value As Integer)
            pidEmpresa = value
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
    Public Property idCliente() As Integer
        Get
            Return pidCliente
        End Get
        Set(ByVal value As Integer)
            pidCliente = value
        End Set
    End Property
    Public Property DNI() As String
        Get
            Return pDNI
        End Get
        Set(ByVal value As String)
            pDNI = value
        End Set
    End Property
    Public Property Email() As String
        Get
            Return pemail
        End Get
        Set(ByVal value As String)
            pemail = value
        End Set
    End Property
    Public Property Aval() As String
        Get
            Return paval
        End Get
        Set(ByVal value As String)
            paval = value
        End Set
    End Property
    Public Property RepLegal() As String
        Get
            Return pRepLegal
        End Get
        Set(ByVal value As String)
            pRepLegal = value
        End Set
    End Property
    Public Property Edad() As String
        Get
            Return pEdad
        End Get
        Set(ByVal value As String)
            pEdad = value
        End Set
    End Property
    Public Property Sueldo() As String
        Get
            Return pSueldo
        End Get
        Set(ByVal value As String)
            pSueldo = value
        End Set
    End Property
    Public Property Conyugue() As String
        Get
            Return pConyugue
        End Get
        Set(ByVal value As String)
            pConyugue = value
        End Set
    End Property
    Public Property CentroLaboral() As String
        Get
            Return pcentrolaboral
        End Get
        Set(ByVal value As String)
            pcentrolaboral = value
        End Set
    End Property
    Public Property TelfxVer() As String
        Get
            Return pTelfxVer
        End Get
        Set(ByVal value As String)
            pTelfxVer = value
        End Set
    End Property
End Class
