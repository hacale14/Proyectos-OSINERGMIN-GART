Imports System.IO
Imports System.Data
Imports System.Data.OleDb
Imports System.Configuration
'Imports excel = Microsoft.Office.Interop.Excel
Public Class Importar : Inherits BE.Importar

    Public mensaje As String = ""
    Function Import_To_Grid(Optional ByVal Before As Boolean = False) As DataTable
        Try
            Dim conStr As String = ""
            Select Case Extension
                Case ".xls"
                    'Excel 97-03 
                    conStr = ConfigurationManager.ConnectionStrings("Excel03ConString").ConnectionString
                    Exit Select
                Case ".xlsx"
                    'Excel 07 
                    conStr = ConfigurationManager.ConnectionStrings("Excel07ConString").ConnectionString
                    Exit Select
            End Select
            conStr = String.Format(conStr, FilePath, "SI")

            Dim connExcel As New OleDbConnection(conStr)
            Dim cmdExcel As New OleDbCommand()
            Dim oda As New OleDbDataAdapter()
            Dim dt As New DataTable()

            cmdExcel.Connection = connExcel

            'Get the name of First Sheet 
            connExcel.Open()

            Dim dtExcelSchema As DataTable
            dtExcelSchema = connExcel.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, Nothing)
            Dim SheetName As String = dtExcelSchema.Rows(0)("TABLE_NAME").ToString()

            ''''''''''''''''''''''''''''''''''''''''
            Dim MiSQL = "IF EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE='BASE TABLE'AND TABLE_NAME='DATAEXCEL') DROP TABLE DATAEXCEL"
            cargamanual(MiSQL)

            'Import by using Jet Provider.
            Dim strSQL = "SELECT * INTO [odbc;Driver={SQL Server};" & _
                "Server=SERVIDOR;Database=cobranza_desa;" & _
                "UID=sa;PWD=innova].DATAEXCEL " & _
                "FROM [" & SheetName & "]"
            cmdExcel.CommandText = strSQL
            cmdExcel.ExecuteNonQuery()
            ''''''''''''''''''''''''''''''
            connExcel.Close()

            'Read Data from First Sheet 
            connExcel.Open()

            If Before = False Then
                cmdExcel.CommandText = Consulta & " [" & SheetName & "]"
                'Else
                'cmdExcel.CommandText = Consulta & " [" & SheetName & "] " & ConsultaBefore
            End If
            oda.SelectCommand = cmdExcel

            oda.Fill(dt)
            '--- Verifica si la DT tiene valores vacios 


            For fila = 0 To dt.Rows.Count - 1
                If fila = dt.Rows.Count Then Exit For
                Dim row As DataRow = dt.Rows(fila)
                If IsDBNull(dt.Rows(fila)(0)) Then
                    dt.Rows.Remove(row)
                    fila -= 1
                End If
            Next

            For col = 0 To dt.Columns.Count - 1
                If col = dt.Columns.Count Then Exit For
                Dim column As DataColumn = dt.Columns(col)
                If IsDBNull(dt.Rows(0)(col)) Then
                    dt.Columns.Remove(column)
                    col -= 1
                End If
            Next


            connExcel.Close()

            Return dt
        Catch ex As Exception
            Return Nothing
        End Try
    End Function


    Public Function cargamanual(ByVal QUERY As String) As DataTable
        Dim dt As New DataTable
        Dim consql As New ConDB.ConSQL
        Try
            dt = consql.Obtiene_dt(QUERY, 0)
        Catch ex As Exception
            mensaje = ex.Message
            Return Nothing
        End Try
        Return dt

    End Function

    'Public Function ConvertXLStoTXT(ByVal nombre As String, ByVal ruta As String, ByVal ObjExcel As Object) As Boolean
    '    'Dim XLS As New Microsoft.Office.Interop.Excel.ApplicationClass
    '    Dim con As New ConDB.ConSQL
    '    Dim excelApp As excel.Application = Nothing
    '    Dim XLS As excel.Workbooks
    '    Dim sheet As excel.Worksheet
    '    con.Graba_Log("Conectando con EXCEL APPLICATION")
    '    'Dim XLS As New Excel.Application
    '    Try

    '        con.Graba_Log("Abriendo archivo: " & FilePath)
    '        XLS.Open(FilePath)
    '        Dim valorr = ruta & ".txt"
    '        If Dir(valorr) <> "" Then
    '            Kill(valorr)
    '        End If
    '        sheet.DisplayAlerts = False
    '        con.Graba_Log("Convierte en formato TXT: " & valorr)
    '        XLS(1).SaveAs(valorr, FileFormat:=-4158, CreateBackup:=False)
    '        con.Graba_Log("Copiando Archivo Origen: " & valorr & ", a la ruta virtual &  : " & "z:\" & nombre & ".txt")
    '        File.Copy(valorr, "z:\" & nombre & ".txt")
    '        con.Graba_Log("Termino del Proceso")
    '        XLS.Close()
    '        excelApp.Quit()
    '        sheet = Nothing
    '        XLS = Nothing
    '        Return True
    '    Catch ex As Exception
    '        mensaje = ex.Message
    '        XLS.Close()
    '        excelApp.Quit()
    '        sheet = Nothing
    '        XLS = Nothing            
    '        Return False
    '    End Try
    'End Function

    Function prueba(Optional ByVal Before As Boolean = False) As DataTable
        Try
            Dim conStr As String = ""
            Select Case Extension
                Case ".xls"
                    'Excel 97-03 
                    conStr = ConfigurationManager.ConnectionStrings("Excel03ConString").ConnectionString
                    Exit Select
                Case ".xlsx"
                    'Excel 07 
                    conStr = ConfigurationManager.ConnectionStrings("Excel07ConString").ConnectionString
                    Exit Select
            End Select
            conStr = String.Format(conStr, FilePath, "SI")

            Dim connExcel As New OleDbConnection(conStr)
            Dim cmdExcel As New OleDbCommand()
            Dim oda As New OleDbDataAdapter()
            Dim dt As New DataTable()

            cmdExcel.Connection = connExcel

            'Get the name of First Sheet 
            connExcel.Open()

            Dim dtExcelSchema As DataTable
            dtExcelSchema = connExcel.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, Nothing)
            Dim SheetName As String = dtExcelSchema.Rows(0)("TABLE_NAME").ToString()

            ''''''''''''''''''''''''''''''''''''''''
            Dim MiSQL = "IF EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE='BASE TABLE'AND TABLE_NAME='DATAEXCEL') DROP TABLE DATAEXCEL"
            cargamanual(MiSQL)
            'Import by using Jet Provider.
            Dim strSQL = "SELECT * INTO [odbc;Driver={SQL Server};" & _
                "Server=SERVIDOR;Database=cobranza_desa;" & _
                "UID=sa;PWD=innova].DATAEXCEL " & _
                "FROM [" & SheetName & "]"
            cmdExcel.CommandText = strSQL
            cmdExcel.ExecuteNonQuery()
            ''''''''''''''''''''''''''''''
            connExcel.Close()

            Return dt
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
End Class
