'************************************************************************************************************************
'***** Autor: EMPRESA PIMAY 
'***** DESCRIPCION: MULTIPLES CONEXIONES 
'************************************************************************************************************************
Public MustInherit Class Calendar
    Inherits System.Web.UI.UserControl
    Dim cadena As String
    Dim In_CodEle As String
    Dim In_Id_Button As String
    Dim In_Texto As String
    Dim In_Lectura As Boolean
    Dim Out_AutoPostBack As Boolean
    Public Property TabIndex() As String
        Get
            Return DC.TabIndex
        End Get
        Set(ByVal value As String)
            DC.TabIndex = value
        End Set
    End Property
    Public Property Texto() As String
        Get
            Return DC.Text
        End Get
        Set(ByVal value As String)
            DC.Text = value
        End Set
    End Property
    Public Property SoloLectura() As Boolean
        Get
            Return DC.ReadOnly
        End Get
        Set(ByVal value As Boolean)
            DC.ReadOnly = value
        End Set
    End Property
    Public Property Id_Button() As String
        Get
            Return In_Id_Button
        End Get
        Set(ByVal value As String)
            If value < Me.Id_Button Then
                Throw New Exception _
                    ("El valor ingresado no es correcto o deber diferente de vacio")
            Else
                In_Id_Button = value
            End If
        End Set
    End Property
    Public Property ID_Calendar() As String
        Get
            Return In_CodEle
        End Get
        Set(ByVal value As String)
            In_CodEle = value
            ImageButton1.OnClientClick = "javascript:popFrame" & Id_Button & ".fPopCalendar(" & value & "," & value & ",popCal);return false"
        End Set
    End Property
    Public Property AutoPostBack() As Boolean
        Get
            DC.AutoPostBack = Out_AutoPostBack
            Return Out_AutoPostBack
        End Get
        Set(ByVal value As Boolean)
            Out_AutoPostBack = value
        End Set
    End Property
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
    End Sub
End Class