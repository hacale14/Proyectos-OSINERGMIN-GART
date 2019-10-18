Imports System.Web.UI.WebControls
Imports BL
Partial Public Class AdministrarCarteras
    Inherits System.Web.UI.UserControl
    Dim BLCartera As New BL.Cartera
    Dim dt As New DataTable

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim Titulo = Request.QueryString("titulo")
        If Not Me.IsPostBack Then
            BuscarCartera()
        End If
    End Sub

    Sub BuscarCartera()
        BLCartera.IdCorporacion = Obtiene_Cookies("idcorporacion")
        BLCartera.IdEmpresa = cboEmpresa.Value
        BLCartera.CodCartera = txtCodCartera.Text
        BLCartera.Cartera = txtCartera.Text
        dt = BLCartera.BuscarCartera()
        CtlGrilla1.SourceDataTable = dt
        dt = Nothing
    End Sub

    Function Obtiene_Cookies(ByVal id) As String
        '// Recogemos la cookie que nos interese
        Dim cogeCookie As HttpCookie = Request.Cookies.Get(id)
        Return cogeCookie.Value
    End Function


    Private Sub NuevaCartera1_Actualizar() Handles NuevaCartera1.Actualizar
        BuscarCartera()
    End Sub


    Private Sub NuevaCartera1_CerrarNuevaCartera() Handles NuevaCartera1.CerrarNuevaCartera
        pnlNuevaCartera.Visible = False
    End Sub


    Private Sub NuevaCartera2_Actualizar() Handles NuevaCartera2.Actualizar
        BuscarCartera()
    End Sub


    Private Sub NuevaCartera2_CerrarNuevaCartera() Handles NuevaCartera2.CerrarNuevaCartera
        pnlModificarCartera.Visible = False
    End Sub

    Private Sub CtlGrilla1_Nuevo() Handles CtlGrilla1.Nuevo
        pnlNuevaCartera.Visible = True
    End Sub

    Private Sub CtlGrilla1_RowDeleting(ByVal GV As System.Web.UI.WebControls.GridView, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles CtlGrilla1.RowDeleting
        Dim row As GridViewRow = GV.Rows(e.RowIndex)
        BLCartera.IdCartera = row.Cells(4).Text
        BLCartera.EliminarCartera()
        BuscarCartera()
        CtlMensajes1.Mensaje("La cartera fue removida satisfactoriamente", "SISTEMA DE COBRANZA")
    End Sub


    Private Sub CtlGrilla1_RowEditing(ByVal GV As System.Web.UI.WebControls.GridView, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs, ByVal row As System.Web.UI.WebControls.GridViewRow) Handles CtlGrilla1.RowEditing
        pnlModificarCartera.Visible = True
        NuevaCartera2.IdCartera = row.Cells(4).Text
        NuevaCartera2.Codigo = row.Cells(5).Text
        NuevaCartera2.Cartera = row.Cells(6).Text
        NuevaCartera2.Tipo = row.Cells(7).Text
        NuevaCartera2.Metas = row.Cells(8).Text
        NuevaCartera2.Empresa = row.Cells(12).Text
        NuevaCartera2.GrCartera = row.Cells(13).Text
        Call NuevaCartera2.CargarDatos()
    End Sub

    Private Sub imgBuscar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgBuscar.Click
        BuscarCartera()
    End Sub
End Class