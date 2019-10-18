Public Partial Class CtlAsignarGestor
    Inherits System.Web.UI.UserControl
    Dim blCobranza As New BL.Cobranza
    Dim blAsigncacion As New BL.Asignacion
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    Private Sub LlenaCombo(ByVal Combo As CtCombo, ByVal Procedimiento As String, ByVal Condicion As String, Optional ByVal AP As Boolean = False)
        With Combo
            .Limpia()
            .Procedimiento = Procedimiento
            .Condicion = Condicion
            .AutoPostBack = AP
            .Cargar_dll()
            .Activa = True
        End With
    End Sub
    Private Sub cboCartera_Click() Handles cboCartera.Click
        LlenaCombo(cboGestorA, "SQL_N_GEST053", ":pcriterioidcartera▓" & " AND Cliente.IdCartera = " + CStr(cboCartera.Value))
        cboGestorA.AutoPostBack = True
        Call Carga_Gestor()
    End Sub

    Private Sub BtnCerrar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BtnCerrar.Click
        Response.Redirect("Principal.aspx")
    End Sub

    Private Sub btnGrabar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnGrabar.Click
        'Validar Vacios
        If Len(Trim(txtDesde.Text)) = 0 Then
            CtlMensajes1.Mensaje("AVISO..: Escriba un Numero de Inicio!")
            txtDesde.Focus()
            Exit Sub
        End If
        If Len(Trim(txtHasta.Text)) = 0 Then
            CtlMensajes1.Mensaje("AVISO..: Escriba un Numero de Fin!")
            txtHasta.Focus()
            Exit Sub
        End If
        'Validar si es numerno
        If IsNumeric(Trim(txtDesde.Text)) = False Or IsNumeric(Trim(txtHasta.Text)) = False Then
            CtlMensajes1.Mensaje("AVISO..: El Numero de Inicio o Numero de Fin deben de ser NUMEROS ENTEROS!")
            Exit Sub
        End If
        'Validar Cantidades
        If CInt(Trim(txtDesde.Text)) <= 0 Or CInt(Trim(txtHasta.Text)) <= 0 Then
            CtlMensajes1.Mensaje("AVISO..: Los rangos deben de ser mayores a CERO (0)!")
            txtDesde.Focus()
            Exit Sub
        End If
        'Validar Numeros Enteros
        If InStr(1, Trim(txtDesde.Text), ",") > 0 Or InStr(1, Trim(txtDesde.Text), ".") > 0 Then
            CtlMensajes1.Mensaje("AVISO..: El Numero de Inicio no debe de ser DECIMAL!")
            txtDesde.Focus()
            Exit Sub
        End If
        If InStr(1, Trim(txtHasta.Text), ",") > 0 Or InStr(1, Trim(txtHasta.Text), ".") > 0 Then
            CtlMensajes1.Mensaje("AVISO..: El Numero de Fin no debe de ser DECIMAL!")
            txtHasta.Focus()
            Exit Sub
        End If
        If CInt(txtDesde.Text) > CInt(txtHasta.Text) Then
            CtlMensajes1.Mensaje("AVISO..: El Numero de Inicio no debe ser MAYOR al Numero de Fin!")
            txtDesde.Focus()
            Exit Sub
        End If
        blAsigncacion.Cantidad = txtCantidad.Text
        blAsigncacion.Cartera_ID = cboCartera.Value
        blAsigncacion.Desde = txtDesde.Text
        blAsigncacion.Hasta = txtHasta.Text
        blAsigncacion.Gestor_ID = cboGestor.Value
        If blCobranza.FunctionEjecuta("EXECUTE Sp_Asignar_Gestores " & blAsigncacion.Gestor_ID & "," & blAsigncacion.Cartera_ID & "," & cboGestorA.Value & "," & cbocint.Value & "," & blAsigncacion.Desde & "," & blAsigncacion.Hasta) = True Then
            CtlMensajes1.Mensaje("AVISO..: LA ASIGNACIÓN SE REALIZÓ CON ÉXITO!")
            Limpiador()
        Else
            CtlMensajes1.Mensaje("AVISO..: LA ASIGNACIÓN NO SE HA REALIZADO!")
        End If
    End Sub
    Private Sub Limpiador()
        cboCartera.Value = 0
        cboGestor.Value = 0
        txtCantidad.Text = ""
        txtDesde.Text = ""
        txtHasta.Text = ""
    End Sub

    Private Sub cbocint_Click() Handles cbocint.Click
        Call Carga_Gestor()
    End Sub
    Sub Carga_Gestor()
        Dim Dt As New DataTable
        'QRYCAG001
        With cboCartera
            Using Dt
                Dt = blCobranza.FunctionGlobal(":pidcarteraƒ:pidusuarioƒ:pidcondicion▓" & .Value & "ƒ" & cboGestorA.Value & "ƒ" & cbocint.Value, "QRYCAG002")
                txtCantidad.Text = Dt(0)("CANTIDAD")
            End Using
        End With
    End Sub

    Private Sub cboGestorA_Click() Handles cboGestorA.Click
        Call Carga_Gestor()
    End Sub
End Class