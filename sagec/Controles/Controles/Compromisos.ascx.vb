Public Partial Class Compromisos
    Inherits System.Web.UI.UserControl
    Dim blcobranza As New BL.Cobranza
    Public Property TipoCartera() As String
        Get
            Return lblTipoCartera.Text
        End Get
        Set(ByVal value As String)
            lblTipoCartera.Text = value
        End Set
    End Property
    Private Sub btnCerrar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnCerrar.Click
        Me.Visible = False
    End Sub

    Public Sub Cargar_Compromiso(ByVal IdCliente As String)
        Try
            Dim Dt As New DataTable
            Using Dt

                Dt = blcobranza.FunctionGlobal(":pidcliente▓" & IdCliente, "QRYCMP001")
                gvCompromiso.SourceDataTable = Dt
                lblIdCliente.Text = IdCliente
            End Using
        Catch ex As Exception
            CtlMensajes1.Mensaje("Error..: " & ex.Message)
        End Try
    End Sub

    Private Sub gvCompromiso_RowDeleting(ByVal GV As System.Web.UI.WebControls.GridView, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gvCompromiso.RowDeleting
        Try
            Dim idcompromiso = ""
            Dim idcliente = ""
            Dim row As GridViewRow = GV.Rows(e.RowIndex)
            idcompromiso = row.Cells(12).Text
            idcliente = row.Cells(11).Text
            blcobranza.FunctionGlobal(":pidcompromiso▓" & idcompromiso, "QRYCMP002")
            Cargar_Compromiso(idcliente)
        Catch ex As Exception
            CtlMensajes1.Mensaje("Error..: " & ex.Message)
        End Try
    End Sub

    Private Sub gvCompromiso_RowEditing(ByVal GV As System.Web.UI.WebControls.GridView, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs, ByVal row As System.Web.UI.WebControls.GridViewRow) Handles gvCompromiso.RowEditing
        Try
            Dim idcompromiso = ""
            Dim idcliente = ""
            idcompromiso = row.Cells(12).Text
            idcliente = row.Cells(11).Text
            NMCompromiso1.Titulo = "MODIFICAR COMPROMISO"
            NMCompromiso1.Carga_Inicial(lblTipoCartera.Text)
            NMCompromiso1.IdCompromiso = idcompromiso
            NMCompromiso1.IdCliente = idcliente
            NMCompromiso1.Visible = True
        Catch ex As Exception
            CtlMensajes1.Mensaje("ERROR..: " & ex.Message)
        End Try
    End Sub
    Private Sub btnNuevo_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnNuevo.Click
        NMCompromiso1.IdCliente = lblIdCliente.Text
    End Sub
End Class