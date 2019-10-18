'************************************************************************************************************************
'***** Autor: EMPRESA PIMAY 
'***** DESCRIPCION: MULTIPLES CONEXIONES 
'************************************************************************************************************************
Imports MySql.Data.MySqlClient
Imports System.Configuration
Imports System.Web
Imports System.IO 

Public Class Conexion
    Public Mensaje As String
    Public db As Object
    Public IPAsterisk As String
    Public conexion As MySqlConnection
    Dim cadCN As String = ConfigurationManager.ConnectionStrings("ConexioDB").ConnectionString
    Dim IpServicio As String = ConfigurationManager.ConnectionStrings("IPServicio").ConnectionString
    Dim fnc As Funciones
    Public Function Obteniendo_Datos_Asterisk(ByVal tipo As String, ByVal anexo As String, ByVal Fecha As String) As DataTable
        Try

            Dim table As New DataTable
            Dim column As DataColumn
            Dim row As DataRow

            Dim url As String = IpServicio & "/llamar.php?tipo=" & tipo & "&anexo=" & anexo & "&fecha=" & Fecha
            Call Graba_Log("Inicio:" & url)
            'Dim url As String = "http://192.168.1.20/Mantenimiento/llamar.php?tipo=" & tipo & "&anexo=" & anexo & "&fecha=" & Fecha
            'Dim url As String = "http://190.117.174.187:8030/llamar.php?tipo=" & tipo & "&anexo=" & anexo & "&fecha=" & Fecha

            Dim wc = New System.Net.WebClient()
            Dim sRt = wc.DownloadString(url)
            If Not sRt Is Nothing Then
                If sRt <> "" And sRt <> "[]" Then
                    ' determina la cabecera
                    sRt = sRt.Replace("}]}", "")
                    Dim ArrCab = Split(sRt, "[")
                    Dim NTabla = ArrCab(0) '--- Tabla
                    NTabla = NTabla.Replace("{", "").Replace("""", "").Replace(":", "").Replace(":", "")
                    Dim sp = Split(ArrCab(1), "{") '--- detalle 
                    table = New DataTable(NTabla)

                    'Dim sp = Split(sRt, "}")
                    For Each x1 In sp
                        If x1 <> "" Then
                            row = table.NewRow()
                            x1 = x1.ToString.Replace(""":""", "|").Replace(""",""", "@").Replace("},", "").Replace("""", "")
                            '--- @ Separacion de campos
                            '--- | Separacion de celdas

                            Dim p = Split(x1, "@")

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
            Call Graba_Log("Termino: " & url)
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

    Public Function Trae_Llamadas_asterisk(ByVal trama As String) As String
        Dim dts As New DataSet
        Dim strvalor As String = ""
        Try
            Dim svc As New svllamadas.llamadasSoapClient()
            Call Graba_Log("Trama I : " & trama)
            strvalor = svc.Servicios(trama)
            Call Graba_Log("Trama I : " & strvalor)
            Return strvalor
        Catch ex As Exception
            Return strvalor
        End Try
    End Function


    Public Function Conecta(ByVal Query As String) As System.Data.DataSet
        '    'se crea una conexion a la base de datos MySQL
        Try
            Call Graba_Log("QRY: " & Query)
            Dim connection As MySqlConnection
            connection = New MySqlConnection
            'se apunta a la cadena de conexion guardada en el archivo Web.config
            Call Graba_Log(cadCN)
            connection.ConnectionString = cadCN
            Call Graba_Log(connection.ConnectionString)
            'se abre la conexion
            connection.Open()
            Dim ComandoSQL As New MySqlCommand(Query, connection)
            Dim ds As New DataSet
            Dim da As New MySqlDataAdapter(ComandoSQL)
            da.Fill(ds)
            Return ds
        Catch ex As Exception
            Call Graba_Log("Error:" & ex.Message)
            Return Nothing
        End Try
    End Function
    Public Function CreateMySqlCommand(ByVal xSQL As String) As Object
        Dim myReader As MySqlDataReader
        Try
            Call Graba_Log(cadCN)
            Call Graba_Log(xSQL)
            Dim conexion As New MySqlConnection(cadCN)
            conexion.Open()
            xSQL = ValidaCaracterAsento(xSQL)
            Using myCommand As New MySqlCommand(xSQL, conexion)
                myCommand.CommandTimeout = 120
                If InStr(1, xSQL, "INSERT") > 0 Or InStr(1, xSQL, "UPDATE") > 0 Then
                    myCommand.ExecuteNonQuery()
                    conexion.Close()
                    Mensaje = ""
                Else
                    myReader = myCommand.ExecuteReader()
                    Dim dt As DataTable = New DataTable
                    dt.Load(myReader)
                    conexion.Close()
                    Mensaje = ""
                    Return dt
                End If
            End Using
        Catch ex As Exception
            Mensaje = ex.Message
            Call Graba_Log("Error:" & Mensaje)
            conexion = Nothing
        End Try
        Return Nothing
    End Function
    Public Function CreateMyReader(ByVal xSQL As String) As Object
        Dim myReader As MySqlDataReader
        Try
            Call Graba_Log(cadCN)
            Call Graba_Log(xSQL)
            Dim conexion As New MySqlConnection(cadCN)
            conexion.Open()
            Using myCommand As New MySqlCommand(xSQL, conexion)
                myCommand.CommandTimeout = 120
                If InStr(1, xSQL, "INSERT") > 0 Or InStr(1, xSQL, "UPDATE") > 0 Then
                    myCommand.ExecuteNonQuery()
                    conexion.Close()
                    Mensaje = ""
                Else
                    myReader = myCommand.ExecuteReader()
                    db = conexion
                    Mensaje = ""
                    Return myReader
                End If
            End Using
        Catch ex As Exception
            Mensaje = ex.Message
            Call Graba_Log("Error:" & Mensaje)
            conexion = Nothing
        End Try
        Return Nothing
    End Function
    Public Function Create_Procedure(ByVal procedimiento As String) As Object
        Dim myReader As MySqlDataReader
        Try
            Call Graba_Log(cadCN)
            Call Graba_Log(procedimiento)
            Dim conexion As New MySqlConnection(cadCN)
            conexion.Open()
            Dim cmd As New MySqlCommand
            cmd.CommandText = procedimiento
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = conexion
            myReader = cmd.ExecuteReader()
            conexion.Close()
            Return myReader
        Catch ex As Exception
            Call Graba_Log("Error:" & ex.Message.ToString)
            System.Console.Write(ex.Message.ToString)
            Return Nothing
        End Try
    End Function
    Public Function Obtiene_QUERY(ByVal KeyQuery As String) As DataTable
        'Dim dt As DataTable = CreateMySqlCommand("call MAE_QUERY('" & KeyQuery & "')")
        Dim dt As DataTable = CreateMySqlCommand("Select Query from maestro_query where Codigo='" & KeyQuery & "'")
        Return dt
    End Function
    Public Function Ejecuta_QUERY(ByVal strsql As String) As DataTable
        'Dim dt As DataTable = CreateMySqlCommand("call MAE_QUERY('" & KeyQuery & "')")
        Dim dt As DataTable = CreateMySqlCommand(strsql)
        Return dt
    End Function
    Public Function ValidaCaracter(ByVal StrCad As String) As String
        ValidaCaracter = Replace(StrCad, ",", ".")
        ValidaCaracter = Replace(StrCad, "'", Chr(34))
    End Function
    Public Function ValidaCaracterAsento(ByVal StrCad As String) As String
        ValidaCaracterAsento = StrCad
        ValidaCaracterAsento = Replace(ValidaCaracterAsento, "à", "a")
        ValidaCaracterAsento = Replace(ValidaCaracterAsento, "è", "e")
        ValidaCaracterAsento = Replace(ValidaCaracterAsento, "ì", "i")
        ValidaCaracterAsento = Replace(ValidaCaracterAsento, "ò", "o")
        ValidaCaracterAsento = Replace(ValidaCaracterAsento, "ù", "u")
        ValidaCaracterAsento = Replace(ValidaCaracterAsento, "á", "a")
        ValidaCaracterAsento = Replace(ValidaCaracterAsento, "é", "e")
        ValidaCaracterAsento = Replace(ValidaCaracterAsento, "í", "i")
        ValidaCaracterAsento = Replace(ValidaCaracterAsento, "ó", "o")
        ValidaCaracterAsento = Replace(ValidaCaracterAsento, "ú", "u")
        ValidaCaracterAsento = Replace(ValidaCaracterAsento, "ñ", "n")
        ValidaCaracterAsento = Replace(ValidaCaracterAsento, "Ñ", "N")
    End Function
    Sub Graba_Log(ByVal strCadenas As String)
        Try
            Dim Log As String = "COBRANZA"
            Dim objFSO = CreateObject("Scripting.FileSystemObject")
            Dim sCnn = ConfigurationManager.ConnectionStrings("ActivaLog").ConnectionString
            If sCnn = "1" Then
                Dim objReadFile = objFSO.OpenTextFile(HttpContext.Current.Request.PhysicalApplicationPath & "\" & Log & Format(Now(), "yyyyMMddhh") & ".log", 8, True)
                objReadFile.writeline(Log & " " & Format(Now(), "yyyyMMdd HH:MM:ss") & ": " & strCadenas & vbCrLf)
                objReadFile.close()
                objReadFile = Nothing
            End If
        Catch ex As Exception
        End Try
    End Sub

End Class

