Imports BL

Public MustInherit Class CtCombo
    Inherits System.Web.UI.UserControl
    Dim pprc As String
    Dim val As String
    Dim pcondicion As String
    Dim valcodigo As Integer
    Dim In_CodEle As String
    Dim in_codTab As String
    Dim out_text As String
    Dim Out_Length As Integer
    Dim Out_SetFocus As Boolean
    Dim Out_Ancho As Integer
    Dim Out_Largo As Integer
    Dim Out_AutoPostBack As Boolean
    Dim Out_Ocultar As Boolean
    Dim dt As New DataTable
    Dim prows As New Integer
    Public Mensaje As String

    Public Property clase() As String
        Get
            Return DropDownList1.CssClass
        End Get
        Set(ByVal value As String)
            DropDownList1.CssClass = value
        End Set
    End Property

    Public Property Color() As Drawing.Color
        Get
            Return DropDownList1.BackColor
        End Get
        Set(ByVal value As Drawing.Color)
            DropDownList1.BackColor = value
        End Set
    End Property
    Public Property ColorTexto() As Drawing.Color
        Get
            Return DropDownList1.ForeColor
        End Get
        Set(ByVal value As Drawing.Color)
            DropDownList1.ForeColor = value
        End Set
    End Property
    Public Property ColorBorde() As Drawing.Color
        Get
            Return DropDownList1.BorderColor
        End Get
        Set(ByVal value As Drawing.Color)
            DropDownList1.BorderColor = value
        End Set
    End Property

    Public Property Ocultar() As Boolean
        Get
            Return DropDownList1.Visible
        End Get
        Set(ByVal value As Boolean)
            DropDownList1.Visible = value
        End Set
    End Property

    Public Property CodTab() As String
        Get
            Return in_codTab
        End Get
        Set(ByVal value As String)
            If value < Me.CodTab Then
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
            If value < Me.CodEle Then
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
    Public Property Text() As String
        Get
            If DropDownList1.SelectedIndex = -1 Then
            Else
                out_text = DropDownList1.Items(DropDownList1.SelectedIndex).Text
            End If
            Return out_text
        End Get
        Set(ByVal valor As String)
            If Trim(valor) <> "" Then
                If DropDownList1.Items.Count < 1 Then
                    Call Cargar_dll()
                End If
                For i = 0 To DropDownList1.Items.Count - 1
                    If DropDownList1.Items(i).Text = valor Then
                        DropDownList1.SelectedValue = DropDownList1.Items(i).Value
                        Exit For
                    End If
                Next
            End If
            Exit Property
        End Set
    End Property
    Public Property Value() As String
        Get
            Return DropDownList1.SelectedValue
        End Get
        Set(ByVal valor As String)
            Try
                If Trim(valor) <> "" Then
                    If DropDownList1.Items.Count < 1 Then
                        Call Cargar_dll()
                    End If

                    DropDownList1.SelectedValue = Trim(valor)
                    If Len(Trim(valor)) > 4 Then
                        'DropDownList1.se = Trim(valor)
                    End If
                End If
                Exit Property
            Catch ex As Exception
            End Try
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
    Public Property Filas() As Integer
        Get
            Return DropDownList1.Items.Count
        End Get
        Set(ByVal value As Integer)
            If value < 0 Then
                Throw New Exception _
                    ("El valor ingresado no es correcto o deber ser mayor que cero")
            End If
        End Set
    End Property
    Public Property Cbo() As DropDownList
        Get
            Return DropDownList1
        End Get
        Set(ByVal value As DropDownList)
            DropDownList1 = value
        End Set
    End Property
    Public Property Longitud() As Integer
        Get
            DropDownList1.Width = Out_Ancho
            Return Out_Ancho
        End Get
        Set(ByVal value As Integer)
            If value < 0 Then
                Throw New Exception _
                    ("El valor ingresado no es correcto o deber ser mayor que cero")
            Else
                Out_Ancho = value
                DropDownList1.Width = Out_Ancho
            End If
        End Set
    End Property
    Public Property Largo() As Integer
        Get
            DropDownList1.Height = Out_Largo
            Return Out_Largo
        End Get
        Set(ByVal value As Integer)
            If value < 0 Then
                Throw New Exception _
                    ("El valor ingresado no es correcto o deber ser mayor que cero")
            Else
                Out_Largo = value
                DropDownList1.Height = Out_Largo
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
    Public Property Condicion() As String
        Get
            Return pcondicion
        End Get
        Set(ByVal value As String)
            pcondicion = value
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
            If Len(Trim(Procedimiento)) > 0 And Me.Visible = True Then
                If DropDownList1.Items.Count < 1 Then
                    Call Cargar_dll()
                End If
            End If
        End If
    End Sub

    Public Sub Cargar_dll()
        Dim gen As New General
        Mensaje = ""
        If Not gen.Llenar_Combo(DropDownList1, Condicion, Procedimiento) Then
            Mensaje = gen.Mensaje
        End If
    End Sub

    Sub Carga_DT(ByVal dt As DataTable)
        If Not dt Is Nothing Then
            DropDownList1.Items.Add(" ")
            DropDownList1.Items(0).Value = 0
            For n = 0 To dt.Rows.Count - 1
                DropDownList1.Items.Add(dt.Rows(n)(1))
                DropDownList1.Items(n + 1).Value = dt.Rows(n)(0)
            Next
        End If
        dt = Nothing
    End Sub

    Public Property Rows() As Integer
        Get
            Return DropDownList1.Items.Count
        End Get
        Set(ByVal value As Integer)
            prows = value
        End Set
    End Property

    Event Click()

    Private Sub DropDownList1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownList1.SelectedIndexChanged
        RaiseEvent Click()
    End Sub
    Public Sub Limpia()
        DropDownList1.Items.Clear()
    End Sub

    Public Property Seleccionar()
        Get
            Return DropDownList1.SelectedItem.Text
        End Get
        Set(ByVal value)
            DropDownList1.SelectedIndex = value
        End Set
    End Property
End Class