Imports ConDB
Partial Public Class CtlProv
    Inherits System.Web.UI.UserControl
    Dim pprc As String
    Dim val As String
    Dim valcodigo As Integer
    Dim In_CodEle As String
    Dim in_codTab As String
    Dim out_text As String
    Dim Out_Length As Integer
    Dim Out_SetFocus As Boolean
    Dim Out_Ancho As Integer
    Dim Out_AutoPostBack As Boolean
    Event Click()
    Public Sub Limpia()
        DropDownList1.Items.Clear()
    End Sub
    Public Property CodTab() As String
        Get
            Return in_codTab
        End Get
        Set(ByVal value As String)
            If value = "" Then
                Throw New Exception _
                    ("El valor ingresado no es correcto o deber ser mayor que cero")
            Else
                in_codTab = value
            End If
        End Set
    End Property

    Public Property CodEle() As String
        Get
            Return In_CodEle
        End Get
        Set(ByVal value As String)
            If value = "" Then
                Throw New Exception _
                    ("El valor ingresado no es correcto o deber ser mayor que cero")
            Else
                In_CodEle = value
            End If
        End Set
    End Property

    Public Property TabIndex() As Integer
        Get
            Return DropDownList1.TabIndex
        End Get
        Set(ByVal value As Integer)
            DropDownList1.TabIndex = value
        End Set
    End Property

    Public Property Activa() As Boolean
        Get
            Return DropDownList1.Enabled
        End Get
        Set(ByVal value As Boolean)
            DropDownList1.Enabled = value
        End Set
    End Property

    Public Sub Inicializa()
        DropDownList1.SelectedIndex = 0
    End Sub
    Public ReadOnly Property Text() As String
        Get
            out_text = DropDownList1.Items(DropDownList1.SelectedIndex).Text
            Return out_text
        End Get
    End Property
    Public Property Value() As String
        Get
            Return DropDownList1.SelectedValue
        End Get
        Set(ByVal valor As String)
            If Trim(valor) <> "" Then
                On Error GoTo OpenError
                If DropDownList1.Items.Count < 1 Then
                    Call Cargar_dll()
                End If
                DropDownList1.SelectedValue = Trim(valor)
            End If
            On Error GoTo 0
            Exit Property
OpenError:
            'Call MsgBox("Error al asignar valor" & valor, MsgBoxStyle.Exclamation, "Renovacion de Cartera")
        End Set
    End Property
    Public ReadOnly Property Length() As String
        Get
            Return Out_Length
        End Get
    End Property
    Public Property SetFocus() As Boolean
        Get
            Return Out_SetFocus
        End Get
        Set(ByVal valor As Boolean)
            Out_SetFocus = valor
        End Set
    End Property
    Public Property Ancho() As Integer
        Get
            Dim O_Ancho
            O_Ancho = DropDownList1.Width
            Return O_Ancho
        End Get
        Set(ByVal value As Integer)
            If value < 0 Then
                Throw New Exception _
                    ("El valor ingresado no es correcto o deber ser mayor que cero")
            Else
                DropDownList1.Width = value
            End If
        End Set
    End Property
    Public Property AutoPostBack() As Boolean
        Get
            Return DropDownList1.AutoPostBack
        End Get
        Set(ByVal value As Boolean)
            DropDownList1.AutoPostBack = value
        End Set
    End Property


    Public Property Procedimiento() As String
        Get
            Return pprc
        End Get
        Set(ByVal value As String)
            pprc = value
        End Set
    End Property
    Public Property Valor() As String
        Get
            Return val
        End Get
        Set(ByVal value As String)
            val = value
        End Set
    End Property
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If (Not MyBase.IsPostBack) Then
            If DropDownList1.Items.Count < 1 Then
                Call Cargar_dll()
            End If
        End If
    End Sub
    Sub Cargar_dll()
        'Dim conBD As New ComBD.Conexion
        'Dim dt As DataTable
        'Dim sql As String = ""
        'Dim n As Integer = 0
        'DropDownList1.Items.Clear()
        'dt = conBD.Obtiene_QUERY(Procedimiento)
        'sql = dt.Rows(0)(0).ToString.Replace(":ptipoglobal", CodTab)
        'sql = sql.Replace(":pcodglobal", CodEle)
        'dt = Nothing
        'dt = conBD.CreateMySqlCommand(sql)
        'For n = 0 To dt.Rows.Count - 1
        'DropDownList1.Items.Add(dt.Rows(n)(1))
        'DropDownList1.Items(n).Value = dt.Rows(n)(0)
        'Next
        'DropDownList1.SelectedIndex = 0
    End Sub
    Private Sub DropDownList1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownList1.SelectedIndexChanged
        RaiseEvent Click()
    End Sub
End Class