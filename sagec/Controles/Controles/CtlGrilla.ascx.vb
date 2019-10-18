Imports System.Web.UI.WebControls
Imports System
Imports System.Configuration
Imports System.Object
Imports System.Web.UI.Control
Imports System.Web.UI.ScriptManager
Imports System.Web.UI
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Data

Partial Public Class CtlGrilla
    Inherits System.Web.UI.UserControl
    Dim plargo As String
    Dim pancho As String
    Dim pocultarc As String
    Dim pColumna As String
    Dim pVisualizar_ChkBox As String = "False"
    Dim pid
    Dim pVisualizar_Img As String = "False"
    Private _Column As String
    Private _Contador As Integer
    Public Property Desactivar_Paginacion() As Boolean
        Get
            Return GridView1.AllowPaging
        End Get
        Set(ByVal value As Boolean)
            GridView1.AllowPaging = value
        End Set
    End Property
    Public Property Nro_Paginacion() As Integer
        Get
            Return GridView1.PageSize
        End Get
        Set(ByVal value As Integer)
            GridView1.PageSize = value
        End Set
    End Property
    'Public Sub Desactivar_Exportar(ByVal Column As String)
    '    CtlExportaFormatos1.Desactiva_Exportar(Column)
    'End Sub
    Public Property Desactivar_Exportar() As String
        Get
            Return pColumna
        End Get
        Set(ByVal value As String)
            pColumna = value
            Call CtlExportaFormatos1.Desactiva_Exportar(value)
        End Set
    End Property
    Public Property IdCtl() As String
        Get
            Return GridView1.ClientID
        End Get
        Set(ByVal value As String)
            pid = value
        End Set
    End Property
    Public Property OcultarFormatos() As Boolean
        Get
            Return CtlExportaFormatos1.Visible
        End Get
        Set(ByVal value As Boolean)
            CtlExportaFormatos1.Visible = value
        End Set
    End Property
    Public Property OcultarColumnas() As String
        Get
            Return pocultarc
        End Get
        Set(ByVal value As String)
            pocultarc = value
        End Set
    End Property
    Public Property Titulo() As String
        Get
            Return lblTituloGrilla.Text
        End Get
        Set(ByVal value As String)
            lblTituloGrilla.Text = value
        End Set
    End Property

    Public Property Contador() As Integer
        Get
            Return _Contador
        End Get
        Set(ByVal value As Integer)
            _Contador = value
        End Set
    End Property
    Public Property Column() As String
        Get
            Return _Column
        End Get
        Set(ByVal value As String)
            _Column = value
        End Set
    End Property
    Public Property Desactiva_Boton() As Boolean
        Get
            Return Button1.Visible
        End Get
        Set(ByVal value As Boolean)
            Button1.Visible = value
        End Set
    End Property

    Public Property Largo() As String
        Get
            Return plargo
        End Get
        Set(ByVal value As String)
            plargo = value
        End Set
    End Property

    Public Property Ancho() As String
        Get
            Return Nothing
        End Get
        Set(ByVal value As String)

        End Set
    End Property

    Public Property With_Grilla() As String
        Get
            Return divGrilla.Style.Item("width")
        End Get
        Set(ByVal value As String)
            divGrilla.Style.Item("width") = value
        End Set
    End Property

    Public Property GV() As GridView
        Get
            Return GridView1
        End Get
        Set(ByVal value As GridView)
            GridView1 = value
        End Set
    End Property

    Public Property mensaje() As Boolean
        Get
            Return Label1.Visible
        End Get
        Set(ByVal value As Boolean)
            Label1.Visible = value
        End Set
    End Property



    Public Property Source() As DataSet
        Get
            Return GridView1.DataSource
        End Get
        Set(ByVal value As DataSet)
            GridView1.DataSource = value
            Datos = value.Tables(0)
            GridView1.DataBind()
            'Label1.Text = gridview1.Rows.Count
            Contador = GridView1.Rows.Count
        End Set
    End Property
    Public Property Datos_ID() As String
        Get
            Return "Datos_Grilla" & GridView1.ClientID
        End Get
        Set(ByVal value As String)
            value = "Datos_Grilla" & GridView1.ClientID
        End Set
    End Property
    Public Property SourceDataTable()
        Get
            Return GridView1.DataSource
        End Get
        Set(ByVal value)
            GridView1.DataSource = value
            CtlExportaFormatos1.dte = value
            Datos = value
            If Not value Is Nothing Then
                If value.GetType().ToString() = "System.Data.DataView" Then
                    If Not value Is Nothing Then
                        If value.table.Rows.Count > 1 Then
                            Contador = value.table.Rows.count
                            GridView1.PageIndex = 0
                        End If
                    End If
                Else
                    If Not value Is Nothing Then
                        If value.Rows.Count > 1 Then
                            Contador = value.Rows.count
                            GridView1.PageIndex = 0
                        End If
                    End If
                End If
            End If
            GridView1.DataBind()
            'Label1.Text = gridview1.Rows.Count                        
            If lblTituloGrilla.Visible Then
                lblTituloGrilla.Text = "Registros encontrados: " & Contador
            End If
            CtlExportaFormatos1.GV = GridView1
        End Set
    End Property

    Public Property Activa_Export() As Boolean
        Get
            Return CtlExportaFormatos1.Visible
        End Get
        Set(ByVal value As Boolean)
            CtlExportaFormatos1.Visible = value
        End Set
    End Property
    Public Property Activa_Delete() As Boolean
        Get
            Return GridView1.Columns(3).Visible
        End Get
        Set(ByVal value As Boolean)
            GridView1.Columns(3).Visible = value
            GridView1.Columns(3).ItemStyle.Width = 20
        End Set
    End Property
    Public Property Activa_Plomo() As Boolean
        Get
            Return GridView1.Columns(2).Visible
        End Get
        Set(ByVal value As Boolean)
            GridView1.Columns(2).Visible = value
            GridView1.Columns(2).ItemStyle.Width = 20
        End Set
    End Property
    Public Property Activa_Titulo() As Boolean
        Get
            Return lblTituloGrilla.Visible
        End Get
        Set(ByVal value As Boolean)
            lblTituloGrilla.Visible = value
        End Set
    End Property
    Public Property Activa_Amarillo() As Boolean
        Get
            Return GridView1.Columns(2).Visible
        End Get
        Set(ByVal value As Boolean)
            GridView1.Columns(2).Visible = value
            GridView1.Columns(2).ItemStyle.Width = 20
        End Set
    End Property
    Public Property Activa_Verde() As Boolean
        Get
            Return GridView1.Columns(2).Visible
        End Get
        Set(ByVal value As Boolean)
            GridView1.Columns(2).Visible = value
            GridView1.Columns(2).ItemStyle.Width = 20
        End Set
    End Property
    Public Property Activa_Rojo() As Boolean
        Get
            Return GridView1.Columns(2).Visible
        End Get
        Set(ByVal value As Boolean)
            GridView1.Columns(2).Visible = value
            GridView1.Columns(2).ItemStyle.Width = 20
        End Set
    End Property
    Public Property Activa_Edita() As Boolean
        Get
            Return GridView1.Columns(2).Visible
        End Get
        Set(ByVal value As Boolean)
            GridView1.Columns(2).Visible = value
            GridView1.Columns(2).ItemStyle.Width = 20
        End Set
    End Property

    Public Property Visualizar_Img() As String
        Get
            Return pVisualizar_Img
        End Get
        Set(ByVal value As String)
            pVisualizar_Img = value
        End Set
    End Property
    Public Property Visualizar_ChkBox() As String
        Get
            Return pVisualizar_ChkBox
        End Get
        Set(ByVal value As String)
            pVisualizar_ChkBox = value
        End Set
    End Property
    Public Property Activa_ckeck() As Boolean
        Get
            Return GridView1.Columns(1).Visible
        End Get
        Set(ByVal value As Boolean)
            GridView1.Columns(1).Visible = value
            GridView1.Columns(1).ItemStyle.Width = 20
        End Set
    End Property

    Public Property Activa_option() As Boolean
        Get
            Return GridView1.Columns(0).Visible
        End Get
        Set(ByVal value As Boolean)
            GridView1.Columns(0).Visible = value
            GridView1.Columns(0).ItemStyle.Width = 20
        End Set
    End Property


    Private Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        RaiseEvent Boton_Click(GridView1, e)
    End Sub

    Private Sub GridView1_RowCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowCreated
        RaiseEvent CreacionFila(sender, e)
    End Sub


    Private Sub gridview1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        RaiseEvent Boton_Click(GridView1, e)
        '     e.Row.Cells.Count = e.Row.Cells.Count - 1
        Try
            'For c = 0 To e.Row.Cells.Count - 1
            '    'e.Row.Cells(c).ToolTip = e.Row.Cells(c).Text
            '    If InStr(1, UCase(e.Row.Cells(c).Text), "HTTP") > 0 Then
            '        e.Row.Cells(c).Text = "<a onclick=Abrir_Pagina('" & e.Row.Cells(c).Text & "')>Abre Documento</a>"
            '        'e.Row.Cells(c).Text = "Enviado"
            '    End If
            'Next
            Color(GridView1, e, Column)

            If e.Row.RowType = DataControlRowType.DataRow Then
                For i = 4 To e.Row.Cells.Count - 1
                    e.Row.Cells(i).ToolTip = e.Row.Cells(i).Text
                Next
            End If

            If (e.Row.RowType = 0) Or (e.Row.RowType = DataControlRowType.DataRow) Then
                CtlExportaFormatos1.Ocultar(OcultarColumnas, e)
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub gridview1_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GridView1.RowDeleting
        RaiseEvent RowDeleting(sender, e)
    End Sub

    Private Sub gridview1_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GridView1.RowEditing
        Dim vistarow As GridViewRow = GridView1.Rows(e.NewEditIndex)
        RaiseEvent RowEditing(sender, e, vistarow)
    End Sub

    Sub Color(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs, ByVal colum As String)
        If e.Row.RowType = DataControlRowType.DataRow Then
            e.Row.Cells(colum).Font.Bold = True
            If e.Row.Cells(colum).Text = "PENDIENTE" Then
                e.Row.Cells(colum).ForeColor = Drawing.Color.LightSkyBlue
            ElseIf e.Row.Cells(colum).Text = "ANULADO" Then
                e.Row.Cells(colum).ForeColor = Drawing.Color.Red
            ElseIf e.Row.Cells(colum).Text = "SOLICITADO" Then
                e.Row.Cells(colum).ForeColor = Drawing.Color.Blue
            ElseIf e.Row.Cells(colum).Text = "ACEPTADO" Then
                e.Row.Cells(colum).ForeColor = Drawing.Color.DarkGreen
            End If
            e.Row.Cells(colum).BorderColor = Drawing.Color.Black
        End If
    End Sub

    Sub elegir(ByVal sender As Object, ByVal e As EventArgs)
        Dim rdbton As RadioButton = CType(sender, RadioButton)
        Dim row As GridViewRow = DirectCast(rdbton.Parent.Parent, GridViewRow)

        Dim a As Integer = row.RowIndex
        For Each rw As GridViewRow In GridView1.Rows
            If rdbton.Checked = True Then
                If rw.RowIndex <> a Then
                    Dim RD As RadioButton = CType(rw.FindControl("RadioButton"), RadioButton)
                    RD.Checked = False
                End If
            End If
        Next
        RaiseEvent elegirfila(sender, e, row)
    End Sub
    Sub Seleccionar(ByVal sender As Object, ByVal e As EventArgs)
        Dim row As GridViewRow
        If Visualizar_Img = False Then
            Dim chkbox As CheckBox = CType(sender, CheckBox)
            row = DirectCast(chkbox.Parent.Parent, GridViewRow)
        Else
            Dim imgBtn As ImageButton = CType(sender, ImageButton)
            row = DirectCast(imgBtn.Parent.Parent, GridViewRow)
        End If    
        RaiseEvent Seleccionarfila(sender, e, row)
    End Sub

    Event Boton_Click(ByVal GV As GridView, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs)
    Event RowDeleting(ByVal GV As GridView, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs)
    Event RowEditing(ByVal GV As GridView, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs, ByVal row As GridViewRow)
    Event elegirfila(ByVal sender As Object, ByVal e As EventArgs, ByVal row As GridViewRow)
    Event Seleccionarfila(ByVal sender As Object, ByVal e As EventArgs, ByVal row As GridViewRow)
    Event CreacionFila(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs)
    Event Nuevo()
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            CtlExportaFormatos1.CargarJS(GridView1.ClientID)
            'GridView1.Attributes.Add("class", "table table-striped")
        End If
    End Sub
    Private Sub CtlExportaFormatos1_Nuevo() Handles CtlExportaFormatos1.Nuevo
        RaiseEvent Nuevo()
    End Sub

    Private Sub CtlExportaFormatos1_Exportar_Excel() Handles CtlExportaFormatos1.Exportar_Excel
        Dim gen As New Controles.General
        gen.exportar_xls(Datos)
    End Sub

    Private Sub GridView1_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridView1.PageIndexChanging
        GridView1.PageIndex = e.NewPageIndex
        GridView1.DataSource = Datos
        GridView1.DataBind()
        CtlExportaFormatos1.dte = Datos
        Me.Visible = True
    End Sub

    Public Property Datos()
        Get
            Return Session("Datos_Grilla" & GridView1.ClientID)
        End Get
        Set(ByVal value)
            Session("Datos_Grilla" & GridView1.ClientID) = value
            CtlExportaFormatos1.CargarJS("Datos_Grilla" & GridView1.ClientID)
        End Set
    End Property


    Public Property Paginacion() As Integer
        Get
            Return GridView1.PageSize
        End Get
        Set(ByVal value As Integer)
            GridView1.PageSize = value
        End Set
    End Property

    Public Property OpocionNuevo() As Boolean
        Get
            Return CtlExportaFormatos1.OpcionNuevo
        End Get
        Set(ByVal value As Boolean)
            CtlExportaFormatos1.OpcionNuevo = value
        End Set
    End Property

    Public Property Rows() As Object
        Get
            Return GridView1.Rows
        End Get
        Set(ByVal value As Object)

        End Set
    End Property
    Protected Sub GridView1_Sorting(ByVal sender As Object, ByVal e As GridViewSortEventArgs)
        Dim sortingDirection As String = String.Empty

        If direction = SortDirection.Ascending Then
            direction = SortDirection.Descending
            sortingDirection = "Desc"
        Else
            direction = SortDirection.Ascending
            sortingDirection = "Asc"
        End If

        Dim sortedView As DataView = New DataView(GridView1.DataSource)
        sortedView.Sort = e.SortExpression & " " & sortingDirection
        Session("SortedView") = sortedView
        GridView1.DataSource = sortedView
        GridView1.DataBind()
    End Sub

    Public Property direction() As SortDirection
        Get

            If ViewState("directionState") Is Nothing Then
                ViewState("directionState") = SortDirection.Ascending
            End If
            Return CType(ViewState("directionState"), SortDirection)
        End Get
        Set(ByVal value As SortDirection)
            ViewState("directionState") = value
        End Set
    End Property
End Class