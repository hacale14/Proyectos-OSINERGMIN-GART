Partial Public Class NPerfil
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            If Not Request.QueryString("idPerfil") Is Nothing Then
                CtlNPerfil1.cod = Request.QueryString("idPerfil")
                CtlNPerfil1.titulo = "MODIFICAR DATOS DEL PERFIL"
            End If
        End If
    End Sub
End Class