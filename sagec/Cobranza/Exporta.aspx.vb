Imports System.Data
Imports System.Data.SqlClient
Imports System.Text
Imports System.IO
Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports iTextSharp.text.html
Imports iTextSharp.text.html.simpleparser
Partial Public Class Exporta
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Select Case Request.QueryString("Tipo")
            Case "XLSX"
                ExportToExcel(Session("dt"))
            Case "WORD"
                ExportToWord(Session("dt"))
            Case "PDF"
                ExportToPDF(Session("dt"))
        End Select
    End Sub

    Protected Sub ExportToWord(ByRef dt As DataTable)
        'Get the data from database into datatable 
        'Create a dummy GridView 
        Dim GridView1 As New GridView()
        GridView1.AllowPaging = False
        GridView1.DataSource = dt
        GridView1.DataBind()

        Response.Clear()
        Response.Buffer = True
        Response.AddHeader("content-disposition", _
           "attachment;filename=GridViewExport.doc")
        Response.Charset = ""
        Response.ContentType = "application/vnd.ms-word "
        Dim sw As New StringWriter()
        Dim hw As New HtmlTextWriter(sw)
        GridView1.RenderControl(hw)
        Response.Output.Write(sw.ToString())
        Response.Flush()
        Response.End()
    End Sub

    Protected Sub ExportToExcel(ByRef dt As DataTable)
        'Get the data from database into datatable         
        'Create a dummy GridView 
        Dim GridView1 As New GridView()
        GridView1.AllowPaging = False
        GridView1.DataSource = dt
        GridView1.DataBind()

        Response.Clear()
        Response.Buffer = True
        Response.AddHeader("content-disposition", "attachment;filename=export" & Format(Now(), "yyyyMMddHHmmss") & ".xls")
        Response.Charset = ""
        Response.ContentType = "application/vnd.ms-excel"
        Dim sw As New StringWriter()
        Dim hw As New HtmlTextWriter(sw)

        For i As Integer = 0 To GridView1.Rows.Count - 1
            'Apply text style to each Row 
            'GridView1.Rows(i).Attributes.Add("class", "textmode")
            For c As Integer = 0 To GridView1.Rows(i).Cells.Count - 1
                GridView1.Rows(i).Cells(c).Attributes.Add("class", "textmode")
            Next
        Next
        GridView1.RenderControl(hw)

        'style to format numbers to string 
        Dim style As String = "<style> .textmode { mso-number-format:\@; } </style>"
        Response.Write(style)
        Response.Output.Write(sw.ToString())
        Response.Flush()
        Response.End()

    End Sub

    Protected Sub ExportToPDF(ByRef dt As DataTable)
        'Get the data from database into datatable         
        'Create a dummy GridView 
        Dim GridView1 As New GridView()
        GridView1.AllowPaging = False
        GridView1.DataSource = dt
        GridView1.DataBind()

        Response.ContentType = "application/pdf"
        Response.AddHeader("content-disposition", "attachment;filename=GridViewExport.pdf")
        Response.Cache.SetCacheability(HttpCacheability.NoCache)
        Dim sw As New StringWriter()
        Dim hw As New HtmlTextWriter(sw)
        GridView1.RenderControl(hw)
        Dim sr As New StringReader(sw.ToString())
        Dim pdfDoc As New Document(PageSize.A4, 10.0F, 10.0F, 10.0F, 0.0F)
        Dim htmlparser As New HTMLWorker(pdfDoc)
        PdfWriter.GetInstance(pdfDoc, Response.OutputStream)
        pdfDoc.Open()
        htmlparser.Parse(sr)
        pdfDoc.Close()
        Response.Write(pdfDoc)
        Response.End()
    End Sub

    Protected Sub ExportToCSV(ByRef dt As DataTable)
        'Get the data from database into datatable 

        Response.Clear()
        Response.Buffer = True
        Response.AddHeader("content-disposition", "attachment;filename=GridViewExport.csv")
        Response.Charset = ""
        Response.ContentType = "application/text"


        Dim sb As New StringBuilder()
        For k As Integer = 0 To dt.Columns.Count - 1
            'add separator 
            sb.Append(dt.Columns(k).ColumnName + ","c)
        Next
        'append new line 
        sb.Append(vbCr & vbLf)
        For i As Integer = 0 To dt.Rows.Count - 1
            For k As Integer = 0 To dt.Columns.Count - 1
                'add separator 
                sb.Append(dt.Rows(i)(k).ToString().Replace(",", ";") + ","c)
            Next
            'append new line 
            sb.Append(vbCr & vbLf)
        Next
        Response.Output.Write(sb.ToString())
        Response.Flush()
        Response.End()
    End Sub
End Class