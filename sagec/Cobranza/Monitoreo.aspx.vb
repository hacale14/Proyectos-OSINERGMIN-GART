Public Partial Class Monitoreo
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Timer1.Interval = 1000
        Timer1.Enabled = True
    End Sub
    Public Function Trae_Llamadas_asterisk(ByVal Trama As String) As DataTable
        Try

            Dim table As New DataTable
            Dim column As DataColumn
            Dim row As DataRow
            Dim url As String = Trama
            Dim wc = New System.Net.WebClient()
            Dim sRt = wc.DownloadString(url)
            Dim Fila = Split(sRt, "||")
            Dim contador As Integer = 0
            ' Creacion de las columnas 
            Dim TColumna = Split("Canales!Conetxto!Extension!Prioridad!Estado!Aplicaciones!Datos!Id_llamada!Campo1!Campo2!Codigo Cuenta!Duracion!Punto de Cuenta!Id Bridge", "!")

            For Each F In Fila
                row = table.NewRow()
                Dim Columna = Split(F, "!")

                For Each C In Columna
                    If Columna.Length < 5 Then Exit For
                    If table.Rows.Count < 1 Then
                        column = New DataColumn()
                        column.DataType = System.Type.GetType("System.String")
                        column.ColumnName = TColumna(contador)  '-- Nombre de la columna
                        column.ReadOnly = True
                        table.Columns.Add(column)
                    End If
                    row(TColumna(contador)) = C '-- Datos de la columna 
                    contador += 1
                Next
                table.Rows.Add(row)
                contador = 0
            Next
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

    Protected Sub Timer1_Tick(ByVal sender As Object, ByVal e As EventArgs) Handles Timer1.Tick
        Dim dt As DataTable = Trae_Llamadas_asterisk("http://192.168.0.20/pimaypred/leeragentes.php")
        GridView1.DataSource = dt
        GridView1.DataBind()
    End Sub
    
End Class