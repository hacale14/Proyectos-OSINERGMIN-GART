Imports System.Web.UI.WebControls

Public MustInherit Class CtlTelefono
    Inherits System.Web.UI.UserControl
    Private Out_TipoDatos As String '--- tipo de datos 
    Private Out_SetFocus As Boolean = False
    Private Out_AutoPostBack As Boolean = False
    Private Out_Ancho As Integer
    Private Out_Ele As Integer
    Private Out_Maximo As Integer
    Private Out_Decimal As Boolean
    Private Out_Formateo As Boolean
    Private Out_Enfoque As Boolean
    Private Out_Index As Boolean
    '---> declaracion de Propiedades del objeto 
    Public Sub Enfoque()
        'TextBox1.Focus()
    End Sub
    
    Public Property TabIndex() As Integer
        Get
            Return "" 'TextBox1.TabIndex
        End Get
        Set(ByVal value As Integer)
            'TextBox1.TabIndex = value
        End Set
    End Property
    
    
    Public ReadOnly Property Row() As Integer
        Get
            Return 0 'Len(Trim(TextBox1.Text))
        End Get
    End Property
End Class



