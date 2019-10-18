Public Partial Class SeleccionPerfil
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            Cargar_Datos()
        End If
    End Sub

    Sub Cargar_Datos()
        Dim Ctl As New Controles.General
        Dim dt_perfil As New DataTable
        dt_perfil = Ctl.BuscarSQL(":pidusuario▓" & Request.QueryString("usuario"), "QRYCBP001")
        CtlGrilla1.SourceDataTable = dt_perfil
    End Sub

    Sub Cargar(ByVal idperfil As String)
        Session("idPerfil") = idperfil
        Response.Redirect("Principal.aspx")
    End Sub

    Private Sub CtlGrilla1_elegirfila(ByVal sender As Object, ByVal e As System.EventArgs, ByVal row As System.Web.UI.WebControls.GridViewRow) Handles CtlGrilla1.elegirfila
        Cargar(row.Cells(4).Text)
    End Sub


End Class