Public Partial Class Perfil
    Inherits System.Web.UI.Page
    Dim bl As New BL.Cobranza
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            cargaInicial()
        End If
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnBuscar.Click
        Dim dt As New DataTable
        Using dt
            If Len(Trim(txtNombre.Text)) > 0 Then
                dt = bl.FunctionGlobal(":pnombre▓" & txtNombre.Text, "QRYUS005")
            End If
            gvPerfiles.SourceDataTable = dt
        End Using
    End Sub

    Private Sub cargaInicial()
        Dim dt As New DataTable
        Using dt
            dt = bl.FunctionGlobal(":pnombre▓" & "", "QRYUS005")
            gvPerfiles.SourceDataTable = dt
        End Using
    End Sub

    Private Sub gvPerfiles_Nuevo() Handles gvPerfiles.Nuevo
        Response.Redirect("NPerfil.aspx")
    End Sub

    
    Private Sub gvPerfiles_RowDeleting(ByVal GV As System.Web.UI.WebControls.GridView, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gvPerfiles.RowDeleting
        Dim row As GridViewRow = GV.Rows(e.RowIndex)
        bl.FunctionGlobal(":pusuarioƒ:pidperfil▓" & Session("usuario") & "ƒ" & row.Cells(4).Text, "QRYPFL005")
        cargaInicial()
    End Sub

    Private Sub gvPerfiles_RowEditing(ByVal GV As System.Web.UI.WebControls.GridView, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs, ByVal row As System.Web.UI.WebControls.GridViewRow) Handles gvPerfiles.RowEditing
        Dim idPerfil = row.Cells(4).Text
        Response.Redirect(String.Format("NPerfil.aspx?idPerfil={0}", idPerfil))
    End Sub
End Class