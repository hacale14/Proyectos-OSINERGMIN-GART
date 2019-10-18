Imports BL
Imports Controles

Partial Public Class ReporteCobertura
    Inherits System.Web.UI.UserControl
    Dim Reporte As New BL.Reporte

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub


    Private Sub cboCartera_Click() Handles cboCartera.Click
        With cboGestor
            .Limpia()
            .Procedimiento = "QRYCOM003"
            .Condicion = ":criterioidcartera▓HAVING Cartera.IdCartera = " & cboCartera.Value
            .Cargar_dll()
        End With
    End Sub

    Private Sub imgGenerarReporte_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgGenerarReporte.Click
        Dim dt As New DataTable
        Dim criterioTodos As String = "CARTERA.IDCARTERA>0"
        Dim criterioCartera As String = ""
        Dim criterioGestor As String = ""

        If Len(Trim(cboCartera.Text)) <> 0 Then
            criterioCartera = " AND CARTERA.IDCARTERA=" & cboCartera.Value
        Else
            criterioCartera = ""
        End If

        If Len(Trim(cboGestor.Text)) <> 0 Then
            criterioGestor = " AND USUARIOCLIENTE.IDUSUARIO=" & cboGestor.Value
        Else
            criterioGestor = ""
        End If
        Dim ctl As New Controles.General
        If Len(Trim(txtFechaInicio.Text)) <> 0 And Len(Trim(txtFechaFin.Text)) <> 0 Then
            If Len(Trim(cboCartera.Text)) = 0 Then
                CtlMensajes1.Mensaje("Seleccione una cartera", "SISTEMA DE COBRANZA")
            ElseIf Len(Trim(cboGestor.Text)) = 0 And (Len(Trim(txtFechaFin.Text)) = 0 Or Len(Trim(txtFechaInicio.Text)) = 0) Then
                CtlMensajes1.Mensaje("Seleccione un gestor o una fecha para minimizar el tiempo de consulta", "SISTEMA DE COBRANZA")
            Else                                
                CtlGrilla1.SourceDataTable = Reporte.ReporteCoberturaCarteraGestor(criterioTodos, criterioCartera, criterioGestor, txtFechaInicio.Text, txtFechaFin.Text)
            End If
        Else
        CtlMensajes1.Mensaje("Seleccione una fecha", "SISTEMA DE COBRANZA")
        End If        
    End Sub

    Private Sub imgNoGestionados_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgNoGestionados.Click
        Dim criterioTodos As String = "CARTERA.IDCARTERA>0"
        Dim criterioFechaInicio As String = ""
        Dim criterioFechaFin As String = ""
        Dim criterioCartera As String = ""
        Dim criterioGestor As String = ""
        Dim dt As New DataTable

        If Len(Trim(txtFechaInicio.Text)) <> 0 Then
            criterioFechaInicio = " AND G.FECHA>='" & txtFechaInicio.Text & "'"
        Else
            criterioFechaInicio = ""
        End If

        If Len(Trim(txtFechaFin.Text)) <> 0 Then
            criterioFechaFin = " AND G.FECHA<='" & txtFechaFin.Text & "'"
        Else
            criterioFechaFin = ""
        End If

        If Len(Trim(cboCartera.Text)) <> 0 Then
            criterioCartera = " AND CARTERA.IDCARTERA=" & cboCartera.Value
        Else
            criterioCartera = ""
        End If

        If Len(Trim(cboGestor.Text)) <> 0 Then
            criterioGestor = " AND USUARIOCLIENTE.IDUSUARIO=" & cboGestor.Value
        Else
            criterioGestor = ""
        End If

        'pnlNoGestionado.Visible = True
        'ClienteNoGestionado1.CriterioCartera = criterioCartera
        'ClienteNoGestionado1.CriterioGestor = criterioGestor
        'ClienteNoGestionado1.CriterioFechaInicio = criterioFechaInicio
        'ClienteNoGestionado1.CriterioFechaFin = criterioFechaFin
        'ClienteNoGestionado1.CargarDatos()
        Reporte.ReporteClienteNoGestionadoBatch(Session("NombreGestor"), "", criterioCartera, criterioGestor, criterioFechaInicio, criterioFechaFin)
        CtlMensajes1.Mensaje("EL REPORTE FUE AÑADIDO A LA COLA, ESTARA DISPONIBLE EN BREVE, SE VISUALIZARA EN LA VENTANA DE REPORTES GENERADOS", "")
    End Sub

    Private Sub ClienteNoGestionado1_Cerrar() Handles ClienteNoGestionado1.Cerrar
        pnlNoGestionado.Visible = False
    End Sub

    Private Sub CtlGrilla1_Boton_Click(ByVal GV As System.Web.UI.WebControls.GridView, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles CtlGrilla1.Boton_Click
        If e.Row.Cells(8).Text <> "CLIENTES ATENDIDOS" Then
            e.Row.Cells(9).Text = Format(((Val(e.Row.Cells(8).Text) / Val(e.Row.Cells(7).Text)) * 100).ToString, "###.00")
            e.Row.Cells(8).Text = Format(Val(e.Row.Cells(8).Text), "###,###,###.00")
            e.Row.Cells(9).Text = Format(Val(e.Row.Cells(9).Text), "###,###,###.00")
        End If
    End Sub

End Class