Imports System.Net.Mail
Partial Public Class CtlCorreo
    Inherits System.Web.UI.UserControl
    Dim _Para As String
    Dim _CC As String
    Dim _asunto As String
    Dim _body As String
    Dim Mensaje As String
    Public Property Para() As String
        Get
            Return _Para
        End Get
        Protected Set(ByVal value As String)
            _Para = value
        End Set
    End Property
    Public Property CopiaCC() As String
        Get
            Return _CC
        End Get
        Protected Set(ByVal value As String)
            _CC = value
        End Set
    End Property
    Public Property Asunto() As String
        Get
            Return _asunto
        End Get
        Protected Set(ByVal value As String)
            _asunto = value
        End Set
    End Property
    Public Property Body() As String
        Get
            Return _body
        End Get
        Protected Set(ByVal value As String)
            _body = value
        End Set
    End Property
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    Public Function SendEmail(ByVal asunto, ByVal para, ByVal cc, ByVal body) As Boolean
        Try
            Dim mail As New MailMessage()

            Dim ArrMail = Split(para, ";")
            Dim ArrCC = Split(cc, ";")

            For Each x In ArrMail
                If x <> "" Then mail.To.Add(x)
            Next
            For Each x In ArrCC
                If x <> "" Then mail.CC.Add(x)
            Next

            'mail.From = New MailAddress("jmejia@pimay.org", "JHOSEP")
            mail.From = New MailAddress("soporte@3plmining.com", "3PL MINING")
            mail.Subject = asunto
            mail.Body = body
            mail.IsBodyHtml = True

            Dim smtp As New SmtpClient()
            smtp.Host = "smtp.gmail.com"
            smtp.Credentials = New System.Net.NetworkCredential("jmejia@pimay.org", "pimay2014")
            smtp.EnableSsl = True
            smtp.Port = 25 '465 '587  
            smtp.EnableSsl = True
            smtp.Send(mail)

        Catch ex As Exception
            Mensaje = ex.Message
        End Try
    End Function

    Public Function SendEmail(ByVal asunto, ByVal para, ByVal cc, ByVal body, ByVal correo, ByVal contrasena, ByVal nombre) As Boolean
        Try
            Dim Email_Personal As String = correo.ToString
            Dim Contrasena_Personal As String = contrasena.ToString
            Dim Nombre_Personal As String = nombre.ToString

            Dim mail As New MailMessage()

            Dim ArrMail = Split(para, ";")
            Dim ArrCC = Split(cc, ";")

            For Each x In ArrMail
                If x <> "" Then mail.To.Add(x)
            Next
            For Each x In ArrCC
                If x <> "" Then mail.CC.Add(x)
            Next

            mail.From = New MailAddress(Email_Personal, Nombre_Personal)
            'mail.From = New MailAddress("soporte@3plmining.com", "3PL MINING")
            mail.Subject = asunto
            mail.Body = body
            mail.IsBodyHtml = True

            Dim smtp As New SmtpClient()
            smtp.Host = "smtp.gmail.com"
            smtp.Credentials = New System.Net.NetworkCredential(Email_Personal, Contrasena_Personal)
            smtp.EnableSsl = True
            smtp.Port = 25 '465 '587  
            smtp.EnableSsl = True
            smtp.Send(mail)

        Catch ex As Exception
            Mensaje = ex.Message
        End Try
    End Function
End Class