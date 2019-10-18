Imports ConDB
'Imports Newtonsoft.Json
Imports System.Collections.Generic
Imports System.Net
Imports System.Web.Script.Serialization
Imports System.IO
Partial Public Class WebForm1
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ' Dim db As New ConDB.Conexion
        '  Dim dt = db.Conecta_Servicios("F", "104", "2016-05-12 15:00:00")
        Call Obteniendo_Datos_Asterisk("A", "104", "2016-05-12 18:20:00")
    End Sub
    Private Function Obteniendo_Datos_Asterisk(ByVal tipo As String, ByVal anexo As String, ByVal Fecha As String) As DataTable
        Try

            Dim table As DataTable = New DataTable("Table1")
            Dim column As DataColumn
            Dim row As DataRow

            Dim url As String = "http://190.117.174.187:8030//llamar.php?tipo=" & tipo & "&anexo=" & anexo & "&fecha=" & Fecha
            Dim wc = New System.Net.WebClient()
            Dim sRt = wc.DownloadString(url)
            If Not sRt Is Nothing Then
                If sRt <> "" And sRt <> "[]" Then
                    sRt = Mid(sRt, InStr(1, sRt, "[") + 1, sRt.Length)
                    sRt = sRt.Replace("]}", "").Replace("{", "")
                    Dim sp = Split(sRt, "}")
                    For Each x1 In sp
                        If x1 <> "" Then
                            row = table.NewRow()
                            x1 = x1.ToString.Replace(""":""", "|").Replace("""", "")
                            Dim p = Split(x1, ",")

                            For Each x2 In p
                                If x2 <> "" Then
                                    Dim p1 = Split(x2, "|")
                                    If table.Rows.Count < 1 Then
                                        column = New DataColumn()
                                        column.DataType = System.Type.GetType("System.String")
                                        column.ColumnName = p1(0) '-- Nombre de la columna
                                        column.ReadOnly = True
                                        table.Columns.Add(column)
                                    End If
                                    row(p1(0)) = p1(1) '-- Datos de la columna 
                                End If
                            Next
                            table.Rows.Add(row)
                        End If
                    Next
                End If
            End If
            column = Nothing
            row = Nothing
            url = Nothing
            wc = Nothing
            sRt = Nothing
            Return table
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
End Class