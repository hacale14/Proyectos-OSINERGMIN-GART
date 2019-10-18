Public Partial Class Formulario_web124
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            With cboEmpresa
                .Limpia()
                .Cargar_dll()
            End With
            With cboTipo
                .Limpia()
                .Condicion = ":idtabla▓120"
                .Cargar_dll()
            End With
            Dim TipoUsuario As String = Obtiene_Cookies("TipoUsuario")
            If TipoUsuario = "SUPERVISOR" Then
                btnAceptar.Visible = False
                btnAplicar.Visible = False
                btnCancelar.Visible = False
            End If
        End If

    End Sub
    Function Obtiene_Cookies(ByVal id) As String
        '// Recogemos la cookie que nos interese
        Dim cogeCookie As HttpCookie = Request.Cookies.Get(id)
        Return cogeCookie.Value
    End Function
    Private Sub cboEmpresa_Click() Handles cboEmpresa.Click
        If cboEmpresa.Text <> "" Then
            With cboCartera
                .Limpia()
                .Condicion = ":idempresa▓" & cboEmpresa.Value
                .Cargar_dll()
            End With
        End If
    End Sub


    Private Sub cboCartera_Click() Handles cboCartera.Click
        If cboCartera.Text <> "" Then
            Dim ctl As New BL.Cobranza
            Dim dt_asignados As New DataTable
            Dim dt_no_asignados As New DataTable
            Try
                If cboCartera.Text <> "" Then
                    Dim dt As New DataTable
                    dt_asignados = ctl.FunctionGlobal(":idcartera▓" & cboCartera.Value, "SQL_N_GEST037")
                    dt_no_asignados = ctl.FunctionGlobal(":idcartera▓" & cboCartera.Value, "SQL_N_GEST038")

                    dt.Columns.Add("Gestor")
                    dt.Columns.Add("No Asigando")
                    For i = 0 To dt_asignados.Rows.Count - 1
                        dt.Columns.Add(dt_asignados.Rows(i)(0))
                    Next

                    Dim fila1 As DataRow = dt.NewRow
                    fila1(0) = "Asignado"
                    fila1(1) = dt_no_asignados.Rows(0)(0).ToString
                    For i = 0 To dt_asignados.Rows.Count - 1
                        fila1(i + 2) = dt_asignados.Rows(i)(1).ToString
                    Next
                    dt.Rows.Add(fila1)

                    Dim fila2 As DataRow = dt.NewRow
                    fila2(0) = "Coberturado"
                    fila2(1) = "0"
                    For i = 0 To dt_asignados.Rows.Count - 1
                        fila2(i + 2) = dt_asignados.Rows(i)(2).ToString
                    Next
                    dt.Rows.Add(fila2)

                    Dim fila3 As DataRow = dt.NewRow
                    fila3(0) = "No Coberturado"
                    For i = 1 To dt_asignados.Rows.Count + 1
                        Try
                            fila3(i) = (Integer.Parse(dt.Rows(0)(i)) - Integer.Parse(dt.Rows(1)(i))).ToString
                        Catch ex As Exception
                            fila3(i) = ""
                        End Try
                    Next
                    dt.Rows.Add(fila3)
                    gvTablaGenera.SourceDataTable = dt
                End If
            Catch ex As Exception
            End Try
            With cboGestor
                .Limpia()
                .Condicion = ":criterioidcartera▓HAVING Cartera.IdCartera = " & cboCartera.Value
                .Cargar_dll()
            End With
            With cboGestorAsigando
                .Limpia()
                .Condicion = ":criterioidcartera▓HAVING Cartera.IdCartera = " & cboCartera.Value
                .Cargar_dll()
            End With
        End If
    End Sub

    Private Sub btnAplicar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAplicar.Click
        Try
            Dim ctl As New BL.Cobranza
            Dim dt As New DataTable
            
            If Trim(txtDNI.Text) <> "" And Trim(cboGestor.Text) = "" And Trim(cboTipo.Text) = "" And Not IsNumeric(Trim(txtRangoInicio.Text)) And Not IsNumeric(Trim(txtRangoFin.Text)) Then
                Dim criterio As String
                criterio = " where T.DNI='" & txtDNI.Text & "'"
                dt = ctl.FunctionGlobal(":idcarteraƒ:idusuarioƒ:criterio▓" & cboCartera.Value & "ƒ" & cboGestor.Value & "ƒ" & criterio, "SQL_N_GEST042")
                SQL_Activo = ctl.sql_ejecuto
                gvTemporal.SourceDataTable = dt
            ElseIf Not IsNumeric(Trim(txtRangoInicio.Text)) Then
                CtlMensajes1.Mensaje("El rango de inicio debe de ser nuemrico")
            ElseIf Not IsNumeric(Trim(txtRangoFin.Text)) Then
                CtlMensajes1.Mensaje("El rango de fin debe de ser nuemrico")
            Else
                Tipo = "A"
                If Trim(cboGestor.Text) = "" And Trim(cboTipo.Text) = "" Then
                    Tipo = "N"
                    Dim criterio As String
                    If Trim(txtRangoInicio.Text) <> "" And Trim(txtRangoFin.Text) <> "" Then
                        criterio = " where T.Rango>=" & txtRangoInicio.Text & " and T.Rango<=" & txtRangoFin.Text
                    Else
                        criterio = ""
                    End If
                    dt = ctl.FunctionGlobal(":idcarteraƒ:idusuarioƒ:criterio▓" & cboCartera.Value & "ƒ" & cboGestor.Value & "ƒ" & criterio, "SQL_N_GEST042")
                    SQL_Activo = ctl.sql_ejecuto
                    gvTemporal.SourceDataTable = dt
                ElseIf Trim(cboGestor.Text) <> "" And Trim(txtDNI.Text) <> "" Then
                    Dim criterio As String
                    criterio = " where T.DNI='" & txtDNI.Text & "'"
                    dt = ctl.FunctionGlobal(":idcarteraƒ:idusuarioƒ:criterio▓" & cboCartera.Value & "ƒ" & cboGestor.Value & "ƒ" & criterio, "SQL_N_GEST039")
                    SQL_Activo = ctl.sql_ejecuto
                    gvTemporal.SourceDataTable = dt
                ElseIf Trim(cboGestor.Text) <> "" And Trim(cboTipo.Text) <> "" Then
                    Dim criterio As String
                    If Trim(txtRangoInicio.Text) <> "" And Trim(txtRangoFin.Text) <> "" Then
                        criterio = " where T.Rango>=" & txtRangoInicio.Text & " and T.Rango<=" & txtRangoFin.Text
                    Else
                        criterio = ""
                    End If
                    If UCase(cboTipo.Text) = "ASIGNADO" Then
                        dt = ctl.FunctionGlobal(":idcarteraƒ:idusuarioƒ:criterio▓" & cboCartera.Value & "ƒ" & cboGestor.Value & "ƒ" & criterio, "SQL_N_GEST039")
                        SQL_Activo = ctl.sql_ejecuto
                        gvTemporal.SourceDataTable = dt
                    ElseIf UCase(cboTipo.Text) = "NO COBERTURADO" Then
                        dt = ctl.FunctionGlobal(":idcarteraƒ:idusuarioƒ:criterio▓" & cboCartera.Value & "ƒ" & cboGestor.Value & "ƒ" & criterio, "SQL_N_GEST041")
                        SQL_Activo = ctl.sql_ejecuto
                        gvTemporal.SourceDataTable = dt
                    Else
                        CtlMensajes1.Mensaje("Falta seleccionar el tipo de asignacion")
                    End If
                Else
                    CtlMensajes1.Mensaje("Falta definir un criterio")
                End If
            End If
        Catch ex As Exception
            CtlMensajes1.Mensaje("Ocurrio un error al cargar los datos")
        End Try
    End Sub
    
    Public Property SQL_Activo() As String
        Get
            Return lblSQL_Activo.Text
        End Get
        Set(ByVal value As String)
            lblSQL_Activo.Text = value
        End Set
    End Property

    Public Property Tipo() As String
        Get
            Return lblTipo.Text
        End Get
        Set(ByVal value As String)
            lblTipo.Text = value
        End Set
    End Property


    Private Sub btnAceptar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Dim ctl As New BL.Cobranza
        If gvTemporal.GV.Rows.Count > 0 Then
            For i = 0 To gvTemporal.GV.Rows.Count - 1
                ctl.FunctionGlobal(":idclienteƒ:idusuario▓" & gvTemporal.GV.Rows(i).Cells(7).Text & "ƒ" & cboGestorAsigando.Value, "SPASIG001")
            Next
            Call cboCartera_Click()
            CtlMensajes1.Mensaje("Se guardo satisgactoriamente")
        Else
            CtlMensajes1.Mensaje("Error... No se guardo satisgactoriamente")
        End If

        'If SQL_Activo = "" Then
        '    CtlMensajes1.Mensaje("No se encontro datos de asigancion, seleccione un criterio y de click en aplicar")
        'ElseIf Trim(cboGestorAsigando.Text) = "" Then
        '    CtlMensajes1.Mensaje("Seleccione un gestor que va a asignar")
        'Else
        '    Dim ctl As New BL.Cobranza
        '    If Tipo = "N" Then
        '        ctl.FunctionGlobal(":idusuarioƒ:sql▓" & cboGestorAsigando.Value & "ƒ" & SQL_Activo, "SQL_N_GEST043")
        '    Else
        '        ctl.FunctionGlobal(":idusuario_nuevoƒ:idusuario_antiguoƒ:sql▓" & cboGestorAsigando.Value & "ƒ" & cboGestor.Value & "ƒ" & SQL_Activo, "SQL_N_GEST044")
        '    End If
        '    CtlMensajes1.Mensaje("Se guardo satisgactoriamente")
        '    Call cboCartera_Click()
        'End If
    End Sub
End Class