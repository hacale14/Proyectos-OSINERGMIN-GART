Public Partial Class ReporteCartasCampo
    Inherits System.Web.UI.UserControl
    Dim BLReporteCartas As New BL.ReporteCartasCampo

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Titulo = Request.QueryString("titulo")
        If Not Me.IsPostBack Then
            If Titulo = "REPORTE DE CARTAS A CAMPO" Then
                cboCartera.Procedimiento = "QRYC012"
                cboCartera.Cargar_dll()
            Else
                cboCartera.Procedimiento = "QRYC013"
                cboCartera.Cargar_dll()
            End If
        End If
    End Sub
    Public Property Titulo()
        Get
            Return lblTituloControl.Text
        End Get
        Set(ByVal value)
            lblTituloControl.Text = value
        End Set
    End Property

    Private Sub cboCartera_Click() Handles cboCartera.Click
        With cboGestor
            .Limpia()
            .Procedimiento = "QRYCOM003"
            .Condicion = ":criterioidcartera▓HAVING Cartera.IdCartera = " & cboCartera.Value
            .Cargar_dll()
        End With
    End Sub


    Private Sub imgBuscar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgBuscar.Click
        Dim dt As New DataTable
        Dim dtPagos As New DataTable
        Dim criterioCartera As String = ""
        Dim criterioGestor As String = ""
        Dim criterioFechaIni As String = ""
        Dim criterioFechaFin As String = ""

        If Len(Trim(cboCartera.Text)) = 0 Then
            criterioCartera = ""
        Else
            criterioCartera = " AND NOMCARTERA LIKE '" & cboCartera.Text & "%'"
        End If

        If Len(Trim(cboGestor.Text)) = 0 Then
            criterioGestor = ""
        Else
            criterioGestor = " AND GESTOR LIKE '" & cboGestor.Text & "%'"
        End If

        If Len(Trim(txtFechaInicio.Text)) <> 0 And chkInicio.Checked = True Then
            If Titulo = "REPORTE DE CARTAS A CAMPO" Then
                criterioFechaIni = " AND FECHACAMPO>='" & txtFechaInicio.Text & "'"
            Else
                criterioFechaIni = " AND FECHACAMPO>='" & txtFechaInicio.Text & "'"
            End If
        Else
            criterioFechaIni = ""
        End If

        If Len(Trim(txtFechaFin.Text)) <> 0 And chkFin.Checked = True Then
            If Titulo = "REPORTE DE CARTAS A CAMPO" Then
                criterioFechaFin = " AND FECHACAMPO<='" & txtFechaFin.Text & "'"
            Else
                criterioFechaFin = " AND FECHACAMPO<='" & txtFechaFin.Text & "'"
            End If
        Else
            criterioFechaFin = ""
        End If
        Try
            If Len(Trim(cboCartera.Text)) = 0 Then
                CtlMensajes1.Mensaje("Seleccione una cartera", "")
            Else
                If Len(Trim(cboGestor.Text)) = 0 Or (DateDiff(DateInterval.Day, Date.Parse(txtFechaInicio.Text), Date.Parse(txtFechaFin.Text))) > 60 Then
                    If Titulo = "REPORTE DE CARTAS A CAMPO" Then
                        BLReporteCartas.ReporteCartaCampoCastigoBatch(criterioCartera, criterioGestor, criterioFechaIni, criterioFechaFin, Session("NombreGestor"))
                    Else
                        BLReporteCartas.ReporteCartaCampoActivaBatch(criterioCartera, criterioGestor, criterioFechaIni, criterioFechaFin, Session("NombreGestor"))
                    End If
                    CtlMensajes1.Mensaje("EL REPORTE FUE AÑADIDO A LA COLA, ESTARA DISPONIBLE EN BREVE, SE VISUALIZARA EN LA VENTANA DE REPORTES GENERADOS", "")
                Else
                    If Titulo = "REPORTE DE CARTAS A CAMPO" Then
                        dt = BLReporteCartas.ReporteCartaCampoCastigo(criterioCartera, criterioGestor, criterioFechaIni, criterioFechaFin)
                    Else
                        dt = BLReporteCartas.ReporteCartaCampoActiva(criterioCartera, criterioGestor, criterioFechaIni, criterioFechaFin)
                    End If
                    CtlGrilla1.SourceDataTable = dt
                End If
            End If
        Catch ex As Exception
            CtlMensajes1.Mensaje("Error:... " & ex.Message)
        End Try
    End Sub

    Private Sub CtlGrilla1_RowDeleting(ByVal GV As System.Web.UI.WebControls.GridView, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles CtlGrilla1.RowDeleting
        Dim row As GridViewRow = GV.Rows(e.RowIndex)
        If Titulo = "REPORTE DE CARTAS A CAMPO" Then
            If Not BLReporteCartas.EliminarCartaCampoCastigo(row.Cells(21).Text) Then
                CtlMensajes1.Mensaje("Se produjo un Error al eliminar la Carta Campo")
            End If
            pnlCuadroMensaje.Visible = True
            CtlCuadroMensaje1.Titulo = "SISTEMA DE COBRANZA"
            CtlCuadroMensaje1.Contexto = "DESEA ACTIVAR EL BOTÓN DEL CLIENTE: " & row.Cells(6).Text
            CtlCuadroMensaje1.CargarContexto()
            lblVariable.Text = row.Cells(20).Text
        Else
            If Not BLReporteCartas.EliminarCartaCampoActiva(row.Cells(22).Text) Then
                CtlMensajes1.Mensaje("Se produjo un Error al eliminar la Carta Campo")
            End If
            pnlCuadroMensaje.Visible = True
            CtlCuadroMensaje1.Titulo = "SISTEMA DE COBRANZA"
            CtlCuadroMensaje1.Contexto = "DESEA ACTIVAR EL BOTÓN DEL CLIENTE: " & row.Cells(6).Text
            CtlCuadroMensaje1.CargarContexto()
            lblVariable.Text = row.Cells(21).Text
        End If
    End Sub

    Private Sub CtlCuadroMensaje1_No() Handles CtlCuadroMensaje1.No
        Dim e As New EventArgs
        pnlCuadroMensaje.Visible = False
        Call imgBuscar_Click("", e)
    End Sub


    Private Sub CtlCuadroMensaje1_Si() Handles CtlCuadroMensaje1.Si
        Dim e As New EventArgs
        If Titulo = "REPORTE DE CARTAS A CAMPO" Then
            If Not BLReporteCartas.EliminarCartaClienteCastigo(lblVariable.Text) Then
                CtlMensajes1.Mensaje("Se produjo un Error al eliminar la Carta Campo")
            End If
        Else
            If Not BLReporteCartas.EliminarCartaClienteActiva(lblVariable.Text) Then
                CtlMensajes1.Mensaje("Se produjo un Error al eliminar la Carta Campo")
            End If
        End If
        pnlCuadroMensaje.Visible = False
        Call imgBuscar_Click("", e)
    End Sub
End Class