Imports BL
Imports System.Web.UI.WebControls

Partial Public Class ConsultaCondiciones
    Inherits System.Web.UI.UserControl
    Dim BLCondicion As New BL.Condicion
    Dim dt As New DataTable

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            BuscarCondicion()
        End If
    End Sub

    Sub BuscarCondicion()
        BLCondicion.Codigo = txtCOdigo.Text
        BLCondicion.Descripcion = txtDescripcion.Text
        dt = BLCondicion.BuscarCondicion
        CtlGrilla1.OcultarColumnas = "4"
        CtlGrilla1.SourceDataTable = dt
        dt = Nothing
    End Sub



    Private Sub NuevaCondicion1_Actualizar() Handles NuevaCondicion1.Actualizar
        BuscarCondicion()
    End Sub

    Private Sub NuevaCondicion1_CerrarNuevaCondicion() Handles NuevaCondicion1.CerrarNuevaCondicion
        pnlNuevaCartera.Visible = False
    End Sub

    Private Sub NuevaCondicion2_Actualizar() Handles NuevaCondicion2.Actualizar
        BuscarCondicion()
    End Sub


    Private Sub NuevaCondicion2_CerrarNuevaCondicion() Handles NuevaCondicion2.CerrarNuevaCondicion
        pnlModificarCartera.Visible = False
        NuevaCondicion1.CargarDatos()
    End Sub

    Private Sub CtlGrilla1_Nuevo() Handles CtlGrilla1.Nuevo
        pnlNuevaCartera.Visible = True
    End Sub

    Private Sub CtlGrilla1_RowDeleting(ByVal GV As System.Web.UI.WebControls.GridView, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles CtlGrilla1.RowDeleting
        Dim row As GridViewRow = GV.Rows(e.RowIndex)
        BLCondicion.IdCondicion = row.Cells(4).Text
        BLCondicion.EliminaCondicion()
        BuscarCondicion()
    End Sub


    Private Sub CtlGrilla1_RowEditing(ByVal GV As System.Web.UI.WebControls.GridView, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs, ByVal row As System.Web.UI.WebControls.GridViewRow) Handles CtlGrilla1.RowEditing
        pnlModificarCartera.Visible = True
        NuevaCondicion2.IdCondicion = row.Cells(4).Text
        NuevaCondicion2.Codigo = row.Cells(5).Text
        NuevaCondicion2.Descripcion = row.Cells(6).Text
        Call NuevaCondicion2.CargarDatos()
    End Sub

    Private Sub imgBuscar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgBuscar.Click
        BuscarCondicion()
    End Sub
End Class