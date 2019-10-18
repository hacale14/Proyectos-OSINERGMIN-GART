'************************************************************************************************************************
'***** Autor: EMPRESA PIMAY 
'***** DESCRIPCION: MULTIPLES CONEXIONES 
'************************************************************************************************************************
Imports System.Data.OleDb
Imports System.Data.SqlClient
Imports System.Data.Common
Imports System.IO
Imports System.Configuration
Imports System.Web
Imports System.Web.HttpCookie
Imports Newtonsoft.Json
Imports System.Threading
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Data

Public Class ConSQL : Inherits Funciones

    Public Mensaje As String
    Public Proce As String
    Public Usuario As String
    Public CBox As Object
    Public DGrid As Object
    Public DTable As DataSet
    Public Columnas(,) As String
    Public Elem As String
    Public Valor As String 'String 'Valor a posicionar en el DDL, LBox    
    Public size_elem As Integer
    Public ServerName As String
    Public UserID As String
    Public Password As String
    Public DatabaseName As String

    Public Function CreateMySQLCommand(ByVal xSQL As String) As Boolean
        Try
            Graba_Log("Inicio..: " & xSQL)
            Call qtrama(xSQL, "")
            Mensaje = ""
            Graba_Log("Fin..: " & xSQL)
            Return True
        Catch ex As Exception
            Mensaje = ex.Message
            Graba_Log("Error..: " & Mensaje)
            Return False
        End Try
    End Function
    Public Function Obtiene_QUERYRpte(ByVal KeyQuery As String) As DataTable
        'Dim dt As DataTable = CreateMySqlCommand("call MAE_QUERY('" & KeyQuery & "')")
        Return Obtiene_dtRpte("Select Query from maestro_query where Codigo='" & KeyQuery & "'", 0)
    End Function

    Public Function Obtiene_QUERY(ByVal KeyQuery As String) As DataTable
        'Dim dt As DataTable = CreateMySqlCommand("call MAE_QUERY('" & KeyQuery & "')")
        Return Obtiene_dt("Select Query from maestro_query where Codigo='" & KeyQuery & "'", 0)
    End Function
    Public Function FunctionGlobal(ByVal Cadena As String, ByVal Query As String)
        Dim array
        Dim sql_ejecuto
        Dim nCount = 0
        Dim Str As New DataTable
        Dim R As DataRow = Str.NewRow
        Dim Dt As New DataTable
        Dim sql As String = ""
        Try
            'Dim sql As String = "EXECUTE ObtieneDtos @CADENA='" & Replace(Cadena, "'", "''") & "',@QUERY='" & Query & "'"
            'Dt = Cobranza.Obtiene_dt(Sql, 0)
            'Return Dt
            'Exit Function
            Dt = Obtiene_QUERY(Query)
            sql = Dt(0)(0).ToString

            array = Split(Cadena, "▓") 'ALT  + 1458
            If Cadena <> "" Then
                Dim arrParam = Split(array(0), "ƒ") 'ALT + 159
                Dim arrValores = Split(array(1), "ƒ") 'ALT + 159

                Dim p = 0
                For Each x In arrParam
                    sql = sql.Replace(x, ValSQL(arrValores(p)))
                    p += 1
                Next
                Graba_LogppREDIC(sql)
            End If
            Dt = Obtiene_dt(sql, 0)
            sql_ejecuto = sql.Clone
            Return Dt
        Catch ex As Exception
            Mensaje = ex.ToString
            Return Nothing
        End Try
    End Function

    Public Function Ejecuta_QUERY_Rpte(ByVal KeyQuery As String) As DataTable
        Return Obtiene_dtRpte(UCase(KeyQuery), 0)
    End Function
    Public Function qtramaRpte(ByVal sql As String, ByVal tipo As String) As DataTable
        Dim sCnn As String
        Dim sTrama As String = ""
        qtramaRpte = Nothing
        sCnn = ConfigurationManager.ConnectionStrings("CadenaSQL").ConnectionString
        sCnn = sCnn.Replace(":servidor", ConfigurationManager.ConnectionStrings("Servidor1").ConnectionString)
        sCnn = sCnn.Replace(":DB", ConfigurationManager.ConnectionStrings("DB1").ConnectionString)
        sCnn = sCnn.Replace(":Usuario", ConfigurationManager.ConnectionStrings("Usuario1").ConnectionString)
        sCnn = sCnn.Replace(":Clave", DesEncriptar(ConfigurationManager.ConnectionStrings("Clave").ConnectionString, "Peru"))

        Dim sSel As String = sql
        Dim da As SqlDataAdapter
        Dim dt As New DataTable
        Dim xsql As String = ""
        Try
            Call Graba_Log("INICIO // " & sSel)
            If InStr(1, UCase(sSel), UCase("Select")) > 0 Or InStr(1, UCase(sSel), UCase("CALL")) > 0 Or InStr(1, UCase(sSel), UCase("EXECUTE")) > 0 Then
                If InStr(1, UCase(sSel), UCase("Select")) > 0 Then
                    xsql = sSel
                    'xsql = "execute ObtieneDatos @SQL = '" & Replace(sSel, "'", "''") & "'"
                Else
                    xsql = sSel
                End If
                da = New SqlDataAdapter(UCase(xsql), sCnn)
                da.Fill(dt)
                Call Graba_Log("FIN // " & sSel)
                If tipo = "DT" Then
                    Return dt
                    Exit Function
                End If
                For c = 0 To dt.Columns.Count - 1
                    sTrama = sTrama & dt.Columns(c).Caption & "ƒ"
                Next
                sTrama = sTrama & "ç"
                For f = 0 To dt.Rows.Count - 1
                    For c = 0 To dt.Columns.Count - 1
                        sTrama = sTrama & dt.Rows(f)(c) & "ƒ"
                    Next
                    sTrama = sTrama & "ç"
                Next
            Else
                Dim objConn As New SqlConnection(sCnn)
                objConn.Open()
                xsql = "execute ObtieneDatos @SQL = '" & Replace(sSel, "'", "''") & "'"
                Call Graba_Log("INICIO // " & xsql)
                Dim objCmd As New SqlCommand(xsql, objConn)
                objCmd.ExecuteNonQuery()
                Call Graba_Log("FIN // " & xsql)
                sTrama = "la base ha sido actualizada"
            End If
        Catch ex As Exception
            Call Graba_Log("ERROR //" & sql & vbCrLf & ex.Message)
            Mensaje = "Error:..." & ex.Message
            Return Nothing
        End Try
    End Function

    Public Function Ejecuta_QUERY(ByVal KeyQuery As String) As DataTable
        Return Obtiene_dt(UCase(KeyQuery), 0)
    End Function

    Function qtrama(ByVal sql As String, ByVal tipo As String) As DataTable
        Dim sCnn As String
        Dim sTrama As String = ""
        qtrama = Nothing
        sCnn = ConfigurationManager.ConnectionStrings("cadenaSQL").ConnectionString
        sCnn = sCnn.Replace(":servidor", ConfigurationManager.ConnectionStrings("Servidor").ConnectionString)
        sCnn = sCnn.Replace(":DB", ConfigurationManager.ConnectionStrings("DB").ConnectionString)
        sCnn = sCnn.Replace(":Usuario", ConfigurationManager.ConnectionStrings("Usuario").ConnectionString)
        sCnn = sCnn.Replace(":Clave", DesEncriptar(ConfigurationManager.ConnectionStrings("Clave").ConnectionString, "Peru"))
        'sCnn = sCnn.Replace(":Clave", ConfigurationManager.ConnectionStrings("Clave").ConnectionString)

        Dim sSel As String = sql
        Dim da As SqlDataAdapter
        Dim dt As New DataTable
        Dim xsql As String = ""
        Try
            Call Graba_Log("INICIO // " & sSel)
            If InStr(1, UCase(sSel), UCase("Select")) > 0 Or InStr(1, UCase(sSel), UCase("CALL")) > 0 Or InStr(1, UCase(sSel), UCase("EXECUTE")) > 0 Then
                xsql = UCase(sSel)
                da = New SqlDataAdapter(UCase(xsql), sCnn)
                da.Fill(dt)
                Call Graba_Log("FIN // " & sSel)
                If tipo = "DT" Then
                    Return dt
                    Exit Function
                End If
                For c = 0 To dt.Columns.Count - 1
                    sTrama = sTrama & dt.Columns(c).Caption & "ƒ"
                Next
                sTrama = sTrama & "ç"
                For f = 0 To dt.Rows.Count - 1
                    For c = 0 To dt.Columns.Count - 1
                        sTrama = sTrama & dt.Rows(f)(c) & "ƒ"
                    Next
                    sTrama = sTrama & "ç"
                Next
            Else
                Dim objConn As New SqlConnection(sCnn)
                objConn.Open()
                xsql = "execute ObtieneDatos @SQL = '" & Replace(sSel, "'", "''") & "'"
                Call Graba_Log("INICIO // " & xsql)
                Dim objCmd As New SqlCommand(xsql, objConn)
                objCmd.ExecuteNonQuery()
                Call Graba_Log("FIN // " & xsql)
                sTrama = "la base ha sido actualizada"
            End If
        Catch ex As Exception
            Call Graba_Log("ERROR //" & sql & vbCrLf & ex.Message)
            Mensaje = "Error:..." & ex.Message
            Return Nothing
        End Try
    End Function
    Function Obtiene_dt(ByVal Query As String, ByVal Titulo As Integer) As DataTable
        Try
            Return qtrama(UCase(Query), "DT")
            Exit Function
            Mensaje = ""
            'Return dt
        Catch ex As Exception
            Mensaje = "Error:..." + ex.Message
            Return Nothing
        End Try
    End Function
    Function Obtiene_dtRpte(ByVal Query As String, ByVal Titulo As Integer) As DataTable
        Try
            Return qtramaRpte(UCase(Query), "DT")
            Exit Function
            Mensaje = ""
            'Return dt
        Catch ex As Exception
            Mensaje = "Error:..." + ex.Message
            Return Nothing
        End Try
    End Function
    Public Function ValidaCaracter(ByVal StrCad As String) As String
        'ValidaCaracter = Replace(StrCad, ",", ".")
        ValidaCaracter = Replace(StrCad, "'", "''")

    End Function
    Public Function ValSQL(ByVal StrCad As String) As String
        Dim strCadena As String = ""
        Dim strCadValidos As String = ""
        Dim strCaracValidos As String = "abcdefghijklmmnñopqrstuvwxyz@"
        strCaracValidos &= UCase(strCaracValidos)
        strCaracValidos &= "1234567890!$%&/()=?\¡¿-.,;|°:_+*#><'"
        StrCad = Replace(StrCad, "á", "a")
        StrCad = Replace(StrCad, "é", "e")
        StrCad = Replace(StrCad, "í", "i")
        StrCad = Replace(StrCad, "ó", "o")
        StrCad = Replace(StrCad, "ú", "u")
        StrCad = Replace(StrCad, "Á", "A")
        StrCad = Replace(StrCad, "É", "E")
        StrCad = Replace(StrCad, "Í", "I")
        StrCad = Replace(StrCad, "Ó", "O")
        StrCad = Replace(StrCad, "Ú", "U")
        For i = 1 To Len(StrCad)
            If InStr(1, strCaracValidos, Mid(StrCad, i, 1)) > 0 Then
                strCadValidos &= Mid(StrCad, i, 1)
            Else
                strCadValidos &= " "
            End If
        Next
        Return strCadValidos
    End Function
    Sub Graba_Log(ByVal strCadenas As String)
        Try
            Dim Log As String = "COBRANZA"
            Dim objFSO = CreateObject("Scripting.FileSystemObject")
            Dim sCnn = ConfigurationManager.ConnectionStrings("ActivaLog").ConnectionString
            If sCnn = "1" Then
                Dim objReadFile = objFSO.OpenTextFile(HttpContext.Current.Request.PhysicalApplicationPath & "\" & Log & Format(Now(), "yyyyMMddhh") & ".log", 8, True)
                objReadFile.writeline(Log & "||" & HttpContext.Current.Request.ServerVariables("REMOTE_ADDR").ToString & "||" & Format(Now(), "yyyyMMdd HH:mm:ss") & "|| " & strCadenas & vbCrLf)
                objReadFile.close()
                objReadFile = Nothing
            End If
        Catch ex As Exception
        End Try
    End Sub
    Sub Graba_LogppREDIC(ByVal strCadenas As String)
        Try
            Dim Log As String = "COBRANZA_PREDICTIVA"
            Dim objFSO = CreateObject("Scripting.FileSystemObject")
            Dim sCnn = ConfigurationManager.ConnectionStrings("CadenaSQLSimple").ConnectionString
            If sCnn = "1" Then
                Dim objReadFile = objFSO.OpenTextFile(HttpContext.Current.Request.PhysicalApplicationPath & "\" & Log & Format(Now(), "yyyyMMddhh") & ".log", 8, True)
                objReadFile.writeline(Log & "||" & HttpContext.Current.Request.ServerVariables("REMOTE_ADDR").ToString & "||" & Format(Now(), "yyyyMMdd HH:mm:ss") & "|| " & strCadenas & vbCrLf)
                objReadFile.close()
                objReadFile = Nothing
            End If
        Catch ex As Exception
        End Try
    End Sub
    Public Function json(ByVal keycode As String) As String
        Dim dt = Ejecuta_QUERY(keycode)
        Dim JSONString As String = String.Empty
        JSONString = JsonConvert.SerializeObject(dt)
        Return JSONString
    End Function
    Function Obtiene_Cookies(ByVal id) As String
        '// Recogemos la cookie que nos interese
        Dim cookie As HttpCookie

        Try
            cookie = New HttpCookie(id)
            'request.cookies(id)
            '            Dim cogeCookie As HttpCookie = Request.Cookies.Get(id)
            Return cookie.Value
            'Return cogeCookie.Value
        Catch ex As Exception
            Return ""
        End Try
    End Function
End Class
