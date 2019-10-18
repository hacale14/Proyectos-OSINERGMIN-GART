Imports ConDB
Imports System.IO
Imports System.Web
Imports System.Configuration


Public Class Cobranza
    Dim Cobranza As New ConDB.ConSQL
    Public Mensaje As String
    Public usuario As String = ConfigurationManager.ConnectionStrings("Usuario").ConnectionString
    Public pwd As String = Cobranza.DesEncriptar(ConfigurationManager.ConnectionStrings("Clave").ConnectionString, "Peru")
    Public bd As String = ConfigurationManager.ConnectionStrings("DB").ConnectionString
    Public servidor As String = ConfigurationManager.ConnectionStrings("Servidor").ConnectionString
    Dim _sql_utilizo As String

    Public Function FunctionEjecuta(ByVal Query As String) As Boolean
        Dim cond = Cobranza.CreateMySQLCommand(Query)
        Mensaje = Cobranza.Mensaje
        Return cond
    End Function

    Public Property sql_ejecuto() As String
        Get
            Return _sql_utilizo
        End Get
        Set(ByVal value As String)
            _sql_utilizo = value
        End Set
    End Property
    Public Function FunctionConsulta(ByVal Query As String) As DataTable
        Return Cobranza.Ejecuta_QUERY(Query)
    End Function
    Public Function FunctionGlobalRpte(ByVal Cadena As String, ByVal Query As String)
        Dim array
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
            Dt = Cobranza.Obtiene_QUERYRpte(Query)
            sql = Dt(0)(0).ToString

            array = Split(Cadena, "▓") 'ALT  + 1458
            If Cadena <> "" Then
                Dim arrParam = Split(array(0), "ƒ") 'ALT + 159
                Dim arrValores = Split(array(1), "ƒ") 'ALT + 159

                Dim p = 0
                For Each x In arrParam
                    sql = sql.Replace(x, Cobranza.ValSQL(arrValores(p)))
                    p += 1
                Next
            End If
            Dt = Cobranza.Obtiene_dt(sql, 0)
            sql_ejecuto = sql.Clone
            Return Dt
        Catch ex As Exception
            Mensaje = ex.ToString
            Return Nothing
        End Try
    End Function
    Public Function FunctionGlobal(ByVal Cadena As String, ByVal Query As String)
        Dim array
        Dim nCount = 0
        Dim Str As New DataTable
        Dim R As DataRow = Str.NewRow
        Dim Dt As New DataTable
        Dim condb As New ConDB.ConSQL
        Dim sql As String = ""
        Try
            'Dim sql As String = "EXECUTE ObtieneDtos @CADENA='" & Replace(Cadena, "'", "''") & "',@QUERY='" & Query & "'"
            'Dt = Cobranza.Obtiene_dt(Sql, 0)
            'Return Dt
            'Exit Function
            Dt = Cobranza.Obtiene_QUERY(Query)
            Graba_LogppREDIC("QUERY :" & Query)
            sql = Dt(0)(0).ToString
            Graba_LogppREDIC("INICIO :" & sql)
            array = Split(Cadena, "▓") 'ALT  + 1458
            If Cadena <> "" Then
                Dim arrParam = Split(array(0), "ƒ") 'ALT + 159
                Dim arrValores = Split(array(1), "ƒ") 'ALT + 159

                Dim p = 0
                For Each x In arrParam
                    sql = sql.Replace(x, Cobranza.ValSQL(arrValores(p)))
                    p += 1
                Next
                Graba_LogppREDIC(sql)
            End If
            Dt = Cobranza.Obtiene_dt(sql, 0)
            sql_ejecuto = sql.Clone
            Graba_LogppREDIC("FIN :" & sql)
            Return Dt
        Catch ex As Exception
            Mensaje = ex.ToString
            Return Nothing
        End Try
    End Function
    Sub Graba_LogppREDIC(ByVal strCadenas As String)
        Try
            Dim Log As String = "COBRANZA_PREDICTIVA"
            Dim objFSO = CreateObject("Scripting.FileSystemObject")
            Dim sCnn = ConfigurationManager.ConnectionStrings("CadenaSQLSimple").ConnectionString

            Dim objReadFile = objFSO.OpenTextFile(HttpContext.Current.Request.PhysicalApplicationPath & "\" & Log & Format(Now(), "yyyyMMddhh") & ".log", 8, True)
            objReadFile.writeline(Log & "||" & HttpContext.Current.Request.ServerVariables("REMOTE_ADDR").ToString & "||" & Format(Now(), "yyyyMMdd HH:mm:ss") & "|| " & strCadenas & vbCrLf)
            objReadFile.close()
            objReadFile = Nothing

        Catch ex As Exception
        End Try
    End Sub
    Function ReporteBatch(ByVal maestroquery As String, ByVal parametros As String, ByVal criterio As String, ByVal nombreproceso As String, ByVal nombreusuario As String) As Boolean
        Dim arch As New StreamWriter(HttpContext.Current.Server.MapPath(".") & "/Files/CROWN_" & Format(Now, "yyyyMMddhhss") & ".lst", True)
        arch.WriteLine(usuario)
        arch.WriteLine(pwd)
        arch.WriteLine(bd)
        arch.WriteLine(servidor)
        arch.WriteLine("Consulta")
        arch.WriteLine("Consultas.exe")
        arch.WriteLine(maestroquery & "ƒ" & parametros & "ƒ" & criterio & "ƒ" & nombreproceso & Format(Now, "yyyyMMddhhssfffff"))
        arch.WriteLine(nombreusuario)
        arch.WriteLine("Esporadico")
        arch.WriteLine("")
        arch.WriteLine("")
        arch.WriteLine("")
        arch.WriteLine("")
        arch.WriteLine("")
        arch.WriteLine(nombreproceso)
        arch.WriteLine("REPORTE AGREGADO AUTOMATICAMENTE A LA COLA")
        arch.Close()
    End Function

End Class
