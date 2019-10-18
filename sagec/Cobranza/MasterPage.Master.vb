Imports System.Threading
Imports System.Web.Services
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Data
Imports System.Net
Imports System.Net.NetworkInformation

Partial Public Class MasterPage
    Inherits System.Web.UI.MasterPage
    Public colorMenu As String
    Public colorMenuF As String
    Public ColorLetraF As String
    Public Estilos As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Obtiene_Cookies("idcorporacion") = 1 Then
            Estilos = "Estilos.css"
            colorMenu = "3BDF16"
            colorMenuF = "#3BDF16"
            ColorLetraF = "white"
        Else
            Estilos = "Estilos.css"
            colorMenu = "FF6700"
            colorMenuF = "#FFF2E5"
            ColorLetraF = "#170C00"
        End If
        If Not Me.IsPostBack Then
            Call Obtiene_Login()
        End If
        Dim Corporacion = Obtiene_Cookies("idcorporacion") & " - " & Obtiene_Cookies("corporacion")
        Label1.Text = Corporacion & ": " & UCase(Hidusuario.Value & " - " & Husuario.Value & " - (" & Hcargo.Value & ") - " & HNombreGestor.Value & " - (" & HNombrePerfil.Value & ")")
        If Hidusuario.Value = "" Then
            Response.Redirect("Login.aspx")
        End If
        Obtiene_Login()
        CtlMenu1.GetMenu(Hidusuario.Value, HidPerfil.Value)

    End Sub
    Function Obtiene_Cookies(ByVal id) As String
        '// Recogemos la cookie que nos interese
        Dim cogeCookie As HttpCookie = Request.Cookies.Get(id)
        Return cogeCookie.Value
    End Function
    Sub Obtiene_Login()
        Try
            Hidusuario.Value = Obtiene_Cookies("idusuario")
            Husuario.Value = Obtiene_Cookies("Usuario")
            Hcargo.Value = Obtiene_Cookies("cargo")
            HNombreGestor.Value = Obtiene_Cookies("NombreUsuario")
            HTipoUsuario.Value = Obtiene_Cookies("TipoUsuario")
            HidPerfil.Value = Obtiene_Cookies("idPerfil")
            HNombrePerfil.Value = Obtiene_Cookies("NombrePerfil")
        Catch ex As Exception
        End Try
    End Sub

    Private Sub form1_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles form1.Unload
        Dim entry As DictionaryEntry
        For Each entry In System.Web.HttpContext.Current.Cache
            System.Web.HttpContext.Current.Cache.Remove(entry.Key.ToString)
        Next
    End Sub

    Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload

    End Sub



End Class