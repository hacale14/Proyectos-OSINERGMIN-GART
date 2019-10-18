Imports System
Imports System.Configuration
Imports System.Object
Imports System.Web.UI.Control
Imports System.Web.UI.ScriptManager
Imports System.Web.UI

Partial Public Class CtlMensajes
    Inherits System.Web.UI.UserControl
    Dim StrMensaje As String
    Public Sub Mensaje(ByVal strCuerpo As String, Optional ByVal strTitulo As String = "")
        Session("Mensaje") = strCuerpo
        Dim strMessage = ConfigurationManager.ConnectionStrings("Empresa").ConnectionString & "\n"
        strMessage &= Valcarcateres(Replace(strCuerpo, """", "'"))
        Dim strScript = "alert('" & strMessage & "');"
        ScriptManager.RegisterStartupScript(Me, Me.GetType, "MyScript", strScript, True)
    End Sub
    Public Sub EjecutaURL(ByVal strCuerpo As String)
        Dim strScript = strCuerpo
        Dim s = "window.open('" & strCuerpo + "', 'popup_window', 'width=1000,height=800,left=0,top=0,resizable=no');"
        ScriptManager.RegisterStartupScript(Me, Me.GetType, "MyScript", s, True)
    End Sub
    Public Sub EjecutaRedirect(ByVal strCuerpo As String)
        Dim strScript = strCuerpo
        Dim s = "window.location.href = " & strCuerpo & ";"
        ScriptManager.RegisterStartupScript(Me, Me.GetType, "RedirectSCR", s, True)
    End Sub
    Public Function Valcarcateres(ByVal StrCad As String) As String
        Dim strCadena As String = ""
        Dim strCadValidos As String = ""
        Dim strCaracValidos As String = "abcdefghijklmmnñopqrstuvwxyz@"
        strCaracValidos &= UCase(strCaracValidos)
        strCaracValidos &= "1234567890!$%&/()=?¡¿-.,|°:_+*# "
        StrCad = Replace(StrCad, "Ñ", "N")
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
End Class