Public Partial Class Formulario_web125
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            cboEmpresa.Limpia()
            cboEmpresa.Cargar_dll()
            cboEstado.Limpia()
            cboEstado.Cargar_dll()
            txtFechaInicio.Text = "01/" & Date.Now.ToString("MM/yyyy")
            txtFechaFin.Text = DateTime.DaysInMonth(Date.Now.Year, Date.Now.Month) & "/" & Date.Now.ToString("MM/yyyy")
        End If
    End Sub


    Private Sub cboEmpresa_Click() Handles cboEmpresa.Click
        With cboCartera
            .Limpia()
            .Condicion = ":idempresa▓" & cboEmpresa.Value
            .Cargar_dll()
        End With
    End Sub


    Private Sub imgBuscar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgBuscar.Click
        Dim criterio As String = ""
        Dim ctl As New BL.Cobranza
        Dim dt As New DataTable
        If Len(Trim(cboEmpresa.Text)) <> 0 Then
            criterio = criterio & " and ca.idEmpresa=" & cboEmpresa.Value
        End If
        If Len(Trim(cboCartera.Text)) <> 0 Then
            criterio = criterio & " and ca.idcartera=" & cboCartera.Value
        End If
        If Len(Trim(cboEstado.Text)) <> 0 Then
            criterio = criterio & " and p.estado='" & cboEstado.Value & "'"
        End If
        If Len(Trim(txtFechaInicio.Text)) <> 0 Then
            criterio = criterio & "and convert(date,p.fechapropuesta)>='" & txtFechaInicio.Text & "'"
        End If
        If Len(Trim(txtFechaFin.Text)) <> 0 Then
            criterio = criterio & "and convert(date,p.fechapropuesta)<='" & txtFechaFin.Text & "'"
        End If
        Try
            dt = ctl.FunctionGlobal(":criterio▓" & criterio, "SQL_N_GEST050")
            gvPropuesta.SourceDataTable = dt
        Catch ex As Exception
            CtlMensajes1.Mensaje("Ocurrio un error al cargar el reporte, vuelva a intentarlo")
        End Try
    End Sub
End Class