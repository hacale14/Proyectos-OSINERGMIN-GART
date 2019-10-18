Imports System.IO
Partial Public Class MarcoExportar
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load                
        Dim GridViewExport As New GridView()
        GridViewExport.AllowPaging = False
        GridViewExport.DataSource = Session("dte")
        GridViewExport.DataBind()
        Response.Clear()
        Response.Buffer = True
        Response.AddHeader("content-disposition", "attachment;filename=Reporte" & Format(Now(), "yyyyMMddhhmmss") & ".xls")
        Response.Charset = ""
        Response.ContentType = "application/vnd.ms-excel"
        Dim sw As New StringWriter()
        Dim hw As New HtmlTextWriter(sw)
        For i As Integer = 0 To GridViewExport.Rows.Count - 1
            GridViewExport.Rows(i).Attributes.Add("class", "textmode")
            For c As Integer = 0 To GridViewExport.Columns.Count - 1

            Next
        Next
        GridViewExport.RenderControl(hw)
        Dim style As String = "<style> .textmode{mso-number-format:\@;}</style>"
        Response.Write(style)
        Response.Output.Write(sw.ToString())
        Response.Flush()
        Response.End()
    End Sub

End Class