Public Partial Class CtlEditor
    Inherits System.Web.UI.UserControl
    Dim pLargo As Integer
    Dim pAncho As Integer    
    Public Property Largo() As Integer
        Get
            Return pLargo
        End Get
        Set(ByVal value As Integer)
            pLargo = value
        End Set
    End Property
    Public Property Ancho() As Integer
        Get
            Return pAncho
        End Get
        Set(ByVal value As Integer)
            pAncho = value
        End Set
    End Property
End Class