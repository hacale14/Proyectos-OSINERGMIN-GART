Imports System.IO
Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports iTextSharp.text.html
Imports iTextSharp.text.html.simpleparser
Imports System.Web.UI.HtmlControls
Imports System.Web.UI
Imports System.Text



Public MustInherit Class CtlExportaFormatos
    Inherits System.Web.UI.UserControl
    Public grd As System.Web.UI.WebControls.GridView
    Public GridView1 As System.Web.UI.WebControls.GridView
    Public Formato As String
    Public _cantidad As Single
    Dim Gen As New General

    'Public Property _DATOS() As DataTable
    '    Get
    '        Return Session("_DATOS")
    '    End Get
    '    Set(ByVal value As DataTable)
    '        Session("_DATOS") = value
    '    End Set
    'End Property


    Public Sub Desactiva_Exportar(ByVal Column As String)
        Dim dc = Split(Column, ";")
        For Each x In dc
            Select Case x
                Case 0 : Label1.Visible = False
                Case 1 : LnkXLS.Visible = False
                Case 2 : LnkDOC.Visible = False
                Case 3 : LnkPDF.Visible = False
                Case 4 : LnkCSV.Visible = False
            End Select
        Next
    End Sub
    Public Property dte() As Object
        Get
            Return Session("dte")
        End Get
        Set(ByVal value As Object)
            Session("dte") = value
        End Set
    End Property
    Public Property GV() As System.Web.UI.WebControls.GridView
        Get
            Return Session("GridView1")
        End Get
        Set(ByVal value As System.Web.UI.WebControls.GridView)
            Session("GridView1") = value
        End Set
    End Property

    Public Property Cantidad() As Single
        Get
            Return _cantidad
        End Get
        Set(ByVal value As Single)
            _cantidad = value
        End Set
    End Property
    Public Property GrvExporta() As System.Web.UI.WebControls.GridView
        Get
            Return grd
        End Get
        Set(ByVal value As System.Web.UI.WebControls.GridView)
            'If Session("grv") = Nothing Then                
            grd = value
            '    Session("grv") = grd
            '    Else                
            '    grd = Session("grv")
            '    End If
        End Set
    End Property
    Public Function Exporta() As Boolean
        ''GridView1 = Session("objgrd")
        'Try
        '    Select Case Formato
        '        Case "XLS"
        '            Call ExportExcel()
        '        Case "PDF"
        '            Call ExportPDF()
        '        Case "CSV"
        '            Call ExportCSV()
        '        Case "DOC"
        '            Call ExportWord()
        '    End Select
        '    Return True
        'Catch ex As Exception
        '    Return False
        'End Try
    End Function

    Protected Sub ExportWord1()
        Dim form As New HtmlForm()
        Response.Clear()
        Response.Buffer = True
        Response.Charset = ""
        Response.AddHeader("content-disposition", String.Format("attachment;filename={0}", "3PLMINING.doc"))
        Response.ContentType = "application/ms-msword"
        Dim sw As New StringWriter()
        Dim hw As New HtmlTextWriter(sw)
        GridView1.AllowPaging = False
        '        BindGridDetails(GridView1)
        'form.Attributes("runat") = "server"
        form.Controls.Add(GridView1)
        Me.Controls.Add(form)
        form.RenderControl(hw)
        Dim style As String = "<!--mce:0-->"
        Response.Write(style)
        Response.Output.Write(sw.ToString())
        Response.Flush()
        Response.End()
    End Sub
    Protected Sub ExportWord()

    End Sub
    Protected Sub ExportExcel()
        'Gen.exportar_xls(_DATOS)
    End Sub

    Protected Sub ExportPDF()
        'Dim Grillas As New GridView
        'Grillas.DataSource = _DATOS
        'Grillas.DataBind()
        'Dim pagina As New Page
        'Dim form As New HtmlForm()
        'Dim pageToRender As New Page()
        'pagina.Controls.Add(form)
        'Response.Clear()
        'Response.Buffer = True
        'Response.Charset = ""
        'Response.ContentType = "application/pdf"
        'Response.AddHeader("content-disposition", "attachment;filename=3PLMINING.pdf")
        'Dim sw As New StringWriter()
        'Dim hw As New HtmlTextWriter(sw)
        'Grillas.AllowPaging = False
        ''BindGridDetails(GridView1)
        'form.Attributes("runat") = "server"
        'form.Controls.Add(Grillas)
        'pageToRender.Controls.Add(form)
        'pageToRender.RenderControl(hw)
        ''Me.Controls.Add(form)
        'Dim sr = New StringReader(sw.ToString())
        'Dim pdfDoc As New iTextSharp.text.Document(PageSize.A4, 10.0F, 10.0F, 10.0F, 0.0F)
        'Dim htmlparser As New HTMLWorker(pdfDoc)
        'PdfWriter.GetInstance(pdfDoc, Response.OutputStream)
        'pdfDoc.Open()
        'htmlparser.Parse(sr)
        'pdfDoc.Close()
        'Response.Write(pdfDoc)
        'Response.End()
    End Sub
    Protected Sub ExportCSV()
        'BindGridDetails(GridView1); 

        Response.Clear()
        Response.Buffer = True
        Response.AddHeader("content-disposition", "attachment;filename=3PLMINING.csv")
        Response.Charset = ""
        Response.ContentType = "application/text"
        GridView1.AllowPaging = False
        GridView1.DataBind()
        Dim sb As New StringBuilder()
        For k = 0 To GridView1.DataSource.Columns.Count - 1
            sb.Append(GridView1.DataSource.Columns(k).caption & "|")
        Next
        Response.Output.WriteLine(sb.ToString())
        For i = 0 To GridView1.DataSource.Rows.Count - 1
            sb = New StringBuilder()
            For k = 0 To GridView1.DataSource.Columns.Count - 1
                sb.Append(GridView1.DataSource.Rows(i)(k) & "|")
            Next
            Response.Output.WriteLine(sb.ToString())
        Next
        sb = Nothing
        Response.Flush()
        Response.End()
    End Sub
    Public Overridable Sub VerifyRenderingInServerForm(ByVal control As Control)
    End Sub

    'Protected Sub LnkPDF_Click(ByVal sender As Object, ByVal e As EventArgs) Handles LnkPDF.Click
    '    Formato = "PDF"
    '    Exporta()
    'End Sub
    Public Sub cambia_estado(ByVal colu As Integer, ByVal estado As String, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs)
        If estado = "PENDIENTE" Then
            e.Row.Cells(colu).ForeColor = Drawing.Color.Green
        ElseIf estado = "ACEPTADO" Then
            e.Row.Cells(colu).ForeColor = Drawing.Color.Blue
        ElseIf estado = "RECHAZADO" Then
            e.Row.Cells(colu).ForeColor = Drawing.Color.Red
        End If
    End Sub
    Public Sub cambia_estado_seguimiento(ByVal estado As String, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs)
        If estado = "ANULADO" Then
            e.Row.BackColor = Drawing.Color.Red
        ElseIf estado <> "ANULADO" Then
            e.Row.BackColor = Drawing.Color.Green
        End If
    End Sub
    Public Sub centrar(ByVal colstr As String, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs)
        Dim arrCentar = Split(colstr, ";")
        For Each xx In arrCentar
            e.Row.Cells(xx).Style.Add("text-Align", "center")
        Next
    End Sub
    Public Sub Ocultar(ByVal colstr As String, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs)
        If colstr <> "" Then
            Dim arrCentar = Split(colstr, ";")
            For Each xx In arrCentar
                e.Row.Cells(xx).Visible = False
            Next
        End If
    End Sub
    Public Sub Ancho(ByVal colstr As String, ByVal ancho As String, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs)
        Dim arrCentar = Split(colstr, ";")
        For Each xx In arrCentar
            e.Row.Cells(xx).Width = ancho
        Next
    End Sub
    Public Sub izquerda(ByVal colstr As String, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs)
        Dim arrCentar = Split(colstr, ";")
        For Each xx In arrCentar
            e.Row.Cells(xx).Style.Add("text-Align", "left")
        Next
    End Sub
    Public Sub derecha(ByVal colstr As String, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs)
        Dim arrCentar = Split(colstr, ";")
        For Each xx In arrCentar
            e.Row.Cells(xx).Style.Add("text-Align", "right")
        Next
    End Sub

    Event Nuevo()


    Private Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    End Sub


    Sub CargarJS(ByVal idcliente As String)
        'DOC
        LnkDOC.Attributes.Add("onclick", "$('#" & idcliente & "').tableExport({type:'doc',escape:'false'});")
        LnkDOC.Attributes.Add("href", "#")


        'EXCEL
        LnkXLS.Attributes.Add("onclick", "window.open('" & "MarcoExportar.aspx?session=" & idcliente & "');")
        LnkXLS.Attributes.Add("href", "#")

        'PDF
        LnkPDF.Attributes.Add("onclick", "$('#" & idcliente & "').tableExport({type:'pdf',escape:'false'});")
        'LnkPDF.Attributes.Add("onclick", "var doc = new jsPDF('p', 'pt');var elem = document.getElementById(" & idcliente & ");var res = doc.autoTableHtmlToJson(document.getElementById(" & idcliente & "));doc.autoTable(res.columns, res.data);doc.save('table.pdf');")
        LnkPDF.Attributes.Add("href", "#")

        'CSV
        LnkCSV.Attributes.Add("onclick", "$('#" & idcliente & "').tableExport({type:'csv',escape:'false'});")
        LnkCSV.Attributes.Add("href", "#")


    End Sub
    
    Event Exportar_Excel()

    Protected Sub LnkXLS_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles LnkXLS.Click
        ' Call ExportToExcel(dte, sender, e)
        'RaiseEvent Exportar_Excel()
        'Formato = "XLS"
        'Exporta()
    End Sub

    Protected Sub LnkDOC_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        Formato = "DOC"
        Exporta()
    End Sub

    Protected Sub LnkPDF_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles LnkPDF.Click
        Formato = "PDF"
        Exporta()
    End Sub

    Protected Sub LnkCSV_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles LnkCSV.Click
        Formato = "CSV"
        Exporta()
    End Sub

    Private Sub LnkNew_Click1(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles LnkNew.Click
        RaiseEvent Nuevo()
    End Sub

    Public Property OpcionNuevo() As Boolean
        Get
            Return lblAgregar.Visible
        End Get
        Set(ByVal value As Boolean)
            lblAgregar.Visible = value
            LnkNew.Visible = value
        End Set
    End Property


    Protected Sub ExportToExcel(ByVal dt As DataTable)
        'Get the data from database into datatable

        'Create a dummy GridView
        Dim GridView1 As New GridView()
        GridView1.AllowPaging = False
        GridView1.DataSource = dt
        GridView1.DataBind()

        Response.Clear()
        Response.Buffer = True
        Response.AddHeader("content-disposition", _
             "attachment;filename=export_" & Format(Now(), "yyyyMMddhhmmss") & ".xls")
        Response.Charset = ""
        Response.ContentType = "application/vnd.ms-excel"
        Dim sw As New StringWriter()
        Dim hw As New HtmlTextWriter(sw)

        For i As Integer = 0 To GridView1.Rows.Count - 1
            'Apply text style to each Row
            GridView1.Rows(i).Attributes.Add("class", "textmode")
        Next
        GridView1.RenderControl(hw)

        'style to format numbers to string
        Dim style As String = "<style> .textmode{mso-number-format:\@;}</style>"
        Response.Write(style)
        Response.Output.Write(sw.ToString())
        Response.Flush()
        Response.End()
    End Sub

    Private Sub LnkXLS_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles LnkXLS.Init

    End Sub

    Private Sub LnkDOC_Click1(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles LnkDOC.Click

    End Sub

    Private Sub LnkDOC_Command(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.CommandEventArgs) Handles LnkDOC.Command

    End Sub
End Class