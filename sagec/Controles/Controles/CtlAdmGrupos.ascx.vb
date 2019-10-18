Public Partial Class CtlAdmGrupos
    Inherits System.Web.UI.UserControl

    Private Sub imgBuscar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgBuscar.Click
        BuscarEmpresa()
    End Sub

    Private Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            BuscarEmpresa()
            cboEmpresa.Procedimiento = "SQLE002C"
            cboEmpresa.Condicion = ":criterio▓" & " where empresa.idcorporacion = " & Obtiene_Cookies("idcorporacion")
            cboEmpresa.Cargar_dll()
        End If
    End Sub

    Sub BuscarEmpresa()
        Dim dt As New DataTable
        Dim grupo As New BL.Grupo
        Dim criterio As String = ""
        If Len(Trim(txtEmpresa.Text)) <> 0 Or Len(Trim(txtIdGrupo.Text)) Or Val(cboEmpresa.Value) > 0 Then
            criterio = " where "
            If Len(Trim(txtEmpresa.Text)) <> 0 Then
                criterio = criterio & " grupo.nomcartera like '%" & txtEmpresa.Text & "%' and empresa.idcorporacion = " & Obtiene_Cookies("idcorporacion")
            End If
            If Len(Trim(txtIdGrupo.Text)) <> 0 Then
                criterio = criterio & " grupo.id_grp_cartera = " & txtIdGrupo.Text & " and empresa.idcorporacion = " & Obtiene_Cookies("idcorporacion")
            End If
            If Val(cboEmpresa.Value) > 0 Then
                criterio = criterio & " empresa.idempresa =" & cboEmpresa.Value & " and empresa.idcorporacion = " & Obtiene_Cookies("idcorporacion")
            End If
        Else
            criterio = criterio & " where empresa.idcorporacion = " & Obtiene_Cookies("idcorporacion")
        End If
        dt = grupo.BuscaGrupo(criterio)
        CtlGrilla1.SourceDataTable = dt
    End Sub

    Private Sub CtlGrilla1_Nuevo() Handles CtlGrilla1.Nuevo
        NuevaGrupo.Tipo = "Nuevo"
        NuevaGrupo.Empresa = ""
        NuevaGrupo.idGrupo = "0"
        NuevaGrupo.Grupo = ""
        NuevaGrupo.idEmpresa = "0"        
        pnlGrupo.Visible = True
    End Sub

    Private Sub CtlGrilla1_RowDeleting(ByVal GV As System.Web.UI.WebControls.GridView, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles CtlGrilla1.RowDeleting
        Dim BLEmpresa As New BL.Empresa
        Dim row As GridViewRow = GV.Rows(e.RowIndex)
        BLEmpresa.EliminarEmpresa(row.Cells(4).Text)
        CtlMensajes1.Mensaje("La cartera fue removida satisfactoriamente", "SISTEMA DE COBRANZA")
    End Sub

    Private Sub CtlGrilla1_RowEditing(ByVal GV As System.Web.UI.WebControls.GridView, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs, ByVal row As System.Web.UI.WebControls.GridViewRow) Handles CtlGrilla1.RowEditing
        NuevaGrupo.Empresa = ""
        NuevaGrupo.idGrupo = row.Cells(4).Text
        NuevaGrupo.Grupo = row.Cells(5).Text
        NuevaGrupo.idEmpresa = row.Cells(10).Text
        NuevaGrupo.Tipo = "Modificar"
        pnlGrupo.Visible = True
    End Sub

    Function Obtiene_Cookies(ByVal id) As String
        '// Recogemos la cookie que nos interese
        Dim cogeCookie As HttpCookie = Request.Cookies.Get(id)
        Return cogeCookie.Value
    End Function

    Private Sub NuevaGrupo_Cerrar() Handles NuevaGrupo.Cerrar
        pnlGrupo.Visible = False
    End Sub

    Private Sub NuevaGrupo_Fin_Grabar() Handles NuevaGrupo.Fin_Grabar
        Dim sender As Object
        Dim e As ImageClickEventArgs
        Call imgBuscar_Click(sender, e)
    End Sub

End Class
