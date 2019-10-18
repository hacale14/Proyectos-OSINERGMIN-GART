'************************************************************************************************************************
'***** Autor: EMPRESA PIMAY 
'***** DESCRIPCION: MULTIPLES CONEXIONES 
'************************************************************************************************************************
Partial Public Class AdministracionEmpresa
    Inherits System.Web.UI.UserControl


    Private Sub imgBuscar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgBuscar.Click
        BuscarEmpresa()
    End Sub

    Private Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            BuscarEmpresa()
        End If
    End Sub

    Sub BuscarEmpresa()
        Dim dt As New DataTable
        Dim Empresa As New BL.Empresa
        Dim criterio As String = ""
        If Len(Trim(txtEmpresa.Text)) <> 0 Or Len(Trim(txtIdEmpresa.Text)) Then
            criterio = " where "
            If Len(Trim(txtEmpresa.Text)) <> 0 Then
                criterio = criterio & " empresa.descripcion like '%" & txtEmpresa.Text & "%' and empresa.idcorporacion = " & Obtiene_Cookies("idcorporacion")
            End If
            If Len(Trim(txtIdEmpresa.Text)) <> 0 Then
                criterio = criterio & " empresa.idempresa like '%" & txtIdEmpresa.Text & "%' and empresa.idcorporacion = " & Obtiene_Cookies("idcorporacion")
            End If
        Else
            criterio = criterio & " where empresa.idcorporacion = " & Obtiene_Cookies("idcorporacion")
        End If
        dt = Empresa.BuscarEmpresa(criterio)
        CtlGrilla1.SourceDataTable = dt
    End Sub

    Private Sub NuevaEmpresaN_Cerrar() Handles NuevaEmpresaN.Cerrar
        pnlNuevaEmpresa.Visible = False
    End Sub

    Private Sub NuevaEmpresaM_Cerrar() Handles NuevaEmpresaM.Cerrar
        pnlModificaEmpresa.Visible = False
    End Sub

    Private Sub CtlGrilla1_Nuevo() Handles CtlGrilla1.Nuevo
        NuevaEmpresaN.Tipo = "Nuevo"
        pnlNuevaEmpresa.Visible = True
    End Sub

    Private Sub CtlGrilla1_RowDeleting(ByVal GV As System.Web.UI.WebControls.GridView, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles CtlGrilla1.RowDeleting
        Dim BLEmpresa As New BL.Empresa
        Dim row As GridViewRow = GV.Rows(e.RowIndex)
        BLEmpresa.EliminarEmpresa(row.Cells(4).Text)
        CtlMensajes1.Mensaje("La cartera fue removida satisfactoriamente", "SISTEMA DE COBRANZA")
    End Sub

    Private Sub CtlGrilla1_RowEditing(ByVal GV As System.Web.UI.WebControls.GridView, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs, ByVal row As System.Web.UI.WebControls.GridViewRow) Handles CtlGrilla1.RowEditing
        NuevaEmpresaM.Empresa = ""
        NuevaEmpresaM.idEmpresa = row.Cells(4).Text
        NuevaEmpresaM.Empresa = row.Cells(5).Text
        NuevaEmpresaM.Tipo = "Modificar"
        pnlModificaEmpresa.Visible = True
    End Sub

    Private Sub NuevaEmpresaN_Fin_Grabar() Handles NuevaEmpresaN.Fin_Grabar
        Dim sender As Object
        Dim e As ImageClickEventArgs
        Call imgBuscar_Click(sender, e)
    End Sub
    Function Obtiene_Cookies(ByVal id) As String
        '// Recogemos la cookie que nos interese
        Dim cogeCookie As HttpCookie = Request.Cookies.Get(id)
        Return cogeCookie.Value
    End Function
End Class