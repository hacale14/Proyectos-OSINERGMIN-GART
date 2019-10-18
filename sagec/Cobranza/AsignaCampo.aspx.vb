Public Partial Class AsignaCampo
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Me.IsPostBack Then
            With CboSituacion
                .Limpia()
                .Condicion = ":idtabla▓120"
                .Cargar_dll()
            End With

        End If
    End Sub

    Private Sub cboEmpresa_Click() Handles cboEmpresa.Click
        cboGrupo.Limpia()
        cboGrupo.Procedimiento = "QRYC016"
        cboGrupo.Condicion = ":idempresa▓" & cboEmpresa.Value
        cboGrupo.Cargar_dll()

    End Sub

    Private Sub cboDpto_Click() Handles cboDpto.Click
        cboProv.Limpia()
        cboProv.Procedimiento = "QRYC010"
        cboProv.Condicion = ":cod▓" & cboDpto.Value
        cboProv.Cargar_dll()
    End Sub


    Private Sub cboProv_Click() Handles cboProv.Click
        cboDist.Limpia()
        cboDist.Procedimiento = "QRYC011"
        cboDist.Condicion = ":cod▓" & cboProv.Value
        cboDist.Cargar_dll()
    End Sub

    Private Sub cboDptoC_Click() Handles CboDptoC.Click
        CboProvC.Limpia()
        CboProvC.Procedimiento = "QRYC010"
        CboProvC.Condicion = ":cod▓" & CboDptoC.Value
        CboProvC.Cargar_dll()
    End Sub

    Private Sub cboProvC_Click() Handles CboProvC.Click
        CboDistC.Limpia()
        CboDistC.Procedimiento = "QRYC011"
        CboDistC.Condicion = ":cod▓" & CboProvC.Value
        CboDistC.Cargar_dll()
    End Sub

    Private Sub cboCartera_Click() Handles cboCartera.Click
        Dim ctl As New BL.Cobranza
        Dim dt As New DataTable
        Dim dt_asignados As New DataTable
        Dim dt_no_asignados As New DataTable

        dt_asignados = ctl.FunctionGlobal(":idcartera▓" & cboCartera.Value, "SQL_N_GEST037")
        dt_no_asignados = ctl.FunctionGlobal(":idcartera▓" & cboCartera.Value, "SQL_N_GEST038")


        gvAsignaGeneral.SourceDataTable = dt_no_asignados
        gvAsignaGeneral.DataBind()


        gvAsignaDetalle.SourceDataTable = dt_asignados
        gvAsignaDetalle.DataBind()

    End Sub

    Private Sub btnGenerarCartas_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGenerarCartas.Click
        PnlCartas.Visible = Not PnlCartas.Visible
    End Sub


    Protected Sub btnFormato_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnFormato.Click
        PnlFormato.Visible = Not PnlFormato.Visible
    End Sub


    Private Sub btnProcesaAsig_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnProcesaAsig.Click

        Dim ctl As New BL.Cobranza
        Dim dt As New DataTable
        Dim dt_preasignacion As New DataTable
        Dim cartera As String = cboCartera.Value
        Dim departamento As String = cboDpto.Value
        Dim provincia As String = cboProv.Value
        Dim distrito As String = cboDist.Value
        Dim monI As String = txtMontoIni.Text
        Dim monF As String = txtMontoFin.Text

        dt_preasignacion = ctl.FunctionGlobal(":idCarteraƒ:idDepartamentoƒ:idProvinciaƒ:idDistritoƒ:MontIniƒ:MontFin▓" & cartera & "ƒ" & departamento & "ƒ" & provincia & "ƒ" & distrito & "ƒ" & monI & "ƒ" & monF, "SP_ASIG_CAM_S_01")
   
        If dt_preasignacion.Rows.Count > 0 Then

            Clientesgr.SourceDataTable = dt_preasignacion
            Clientesgr.DataBind()
            'Dim script As String = "$('#MD_PRE_ASIGNACION').modal({backdrop: 'static', keyboard: false})"
            'If Not Page.ClientScript.IsStartupScriptRegistered(Me.GetType(), "alertscript") Then
            '    Page.ClientScript.RegisterStartupScript(Me.GetType(), "alertscript", script, True)
            'End If

            Dim strMessage = "$('#MD_PRE_ASIGNACION').modal();"
            ScriptManager.RegisterStartupScript(Me, Me.GetType, "MyScript", strMessage, True)


        Else
            CtlMensajes1.Mensaje("No se encontraron datos para la búsqueda")

        End If

    End Sub


    'Private Sub btnAsignar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAsignar.Click

    '    Dim ctl As New BL.Cobranza

    '    Dim cartera As String = cboCartera.Value
    '    Dim departamento As String = cboDpto.Value
    '    Dim provincia As String = cboProv.Value
    '    Dim distrito As String = cboDist.Value
    '    Dim monI As String = txtMontoIni.Text
    '    Dim monF As String = txtMontoFin.Text
    '    Dim idUsuario As String = CboUsuarioxAsignar.Value
    '    'Dim rangI As String = txtRangI.Text
    '    'Dim rangF As String = txtRangF.Text

    '    'ctl.FunctionGlobal(":idCarteraƒ:idDepartamentoƒ:idProvinciaƒ:idDistritoƒ:MontIniƒ:MontFinƒ:idUsuarioƒ:ƒrangI:ƒrangF▓" & cartera & "ƒ" & departamento & "ƒ" & provincia & "ƒ" & distrito & "ƒ" & monI & "ƒ" & monF & "ƒ" & idUsuario & "ƒ" & rangI & "ƒ" & rangF, "SP_ASIG_CAM_I_02")

    'End Sub

    Private Sub Clientesgr_RowEditing(ByVal GV As System.Web.UI.WebControls.GridView, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs, ByVal row As System.Web.UI.WebControls.GridViewRow) Handles Clientesgr.RowEditing
        'row.Cells(1).Text 
    End Sub


    Private Sub Clientesgr_Seleccionarfila(ByVal sender As Object, ByVal e As System.EventArgs, ByVal row As System.Web.UI.WebControls.GridViewRow) Handles Clientesgr.Seleccionarfila




    End Sub

    Protected Sub GetSelectedRecords(ByVal sender As Object, ByVal e As EventArgs)
        Dim ctl As New BL.Cobranza
        Dim dt As New DataTable()
        Dim idUsuario As String = CboUsuarioxAsignar.Value
        For Each row As GridViewRow In Clientesgr.Rows()
            If row.RowType = DataControlRowType.DataRow Then
                Dim chkRow As CheckBox = TryCast(row.Cells(2).FindControl("ChkBox"), CheckBox)
                If chkRow.Checked Then
                    Dim idCliente As String = row.Cells(7).Text
                    Dim idCartera As String = row.Cells(8).Text
                    ctl.FunctionGlobal(":idClienteƒ:idUsuarioƒ:idCartera▓" & idCliente & "ƒ" & idUsuario & "ƒ" & idCartera, "SP_ASIG_CAM_I_03")
                End If
            End If
        Next

    End Sub
End Class