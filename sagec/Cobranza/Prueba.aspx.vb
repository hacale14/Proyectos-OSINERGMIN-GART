Imports System.IO

Partial Public Class Prueba
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub btnCargar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCargar.Click
        If FileUpload1.PostedFile IsNot Nothing Then
            If FileUpload1.PostedFile.ContentLength < 1048576 Then
                Dim FileName As String = Path.GetFileName(FileUpload1.PostedFile.FileName)
                FileUpload1.SaveAs(Server.MapPath("Files") + "/" + FileName)
                img.ImageUrl = ("../Files/" + FileName)
            End If
        End If

    End Sub
End Class