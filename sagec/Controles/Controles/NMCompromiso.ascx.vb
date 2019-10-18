Public Partial Class NMCompromiso
    Inherits System.Web.UI.UserControl
    Dim blcobranza As New BL.Cobranza
    Public Property Titulo() As String
        Get
            Return lblTituloControl.Text
        End Get
        Set(ByVal value As String)
            lblTituloControl.Text = value
        End Set
    End Property
    Public Property IdCompromiso() As String
        Get
            Return lblIdCompromiso.Text
        End Get
        Set(ByVal value As String)
            lblIdCompromiso.Text = value
        End Set
    End Property
    Public Property IdCliente() As String
        Get
            Return lblIdCliente.Text
        End Get
        Set(ByVal value As String)
            lblIdCliente.Text = value
        End Set
    End Property
    Public Sub Carga_Inicial(ByVal TipoCartera As String)
        If TipoCartera = "CASTIGO" Then
            With cboOperacion
                .Limpia()
                .Procedimiento = "QRYCMP003"
                .Condicion = ":pidcliente▓" & IdCliente
                .Activa = True
                .Cargar_dll()
            End With
        ElseIf TipoCartera = "ACTIVA" Then
            With cboOperacion
                .Limpia()
                .Procedimiento = "QRYCMP004"
                .Condicion = ":pidcliente▓" & IdCliente
                .Activa = True
                .Cargar_dll()
            End With
        End If

        If Session("TipoUsuario") = "GESTOR" Then
            txtFechaGenero.Enabled = False
        End If

        If Titulo = "NUEVO COMPROMISO" Then
            Cargar_TipoMoneda()
            cboMoneda.Text = "S"
            lblIdCliente.Text = IdCliente
            txtFechaGenero.Text = Format(Date.Now(), "dd/MM/yyyy")
            txtFechaCompromiso.Text = Format(Date.Now(), "dd/MM/yyyy")
        ElseIf Titulo = "MODIFICAR COMPROMISO" Then
            cargar_compromiso()
        End If

    End Sub
    Private Sub Cargar_TipoMoneda()
        With cboMoneda
            .Limpia()
            .Procedimiento = "QRYC008"
            .Condicion = ":cod▓103"
            .Cargar_dll()
            .Activa = True
        End With
    End Sub
    Private Sub Cargar_TipoPago()
        With cboTipoPago
            .Limpia()
            .Procedimiento = "QRYC008"
            .Condicion = ":cod▓104"
            .Cargar_dll()
            .Activa = True
        End With
    End Sub
    Private Sub cargar_compromiso()
        Dim Condicion As String = ""
        Dim Dt As New DataTable
        Using Dt
            Dt = blcobranza.FunctionGlobal(":pidcompromiso▓" & lblIdCompromiso.Text, "QRYCMP005")
            If Dt.Rows.Count > 0 Then
                txtFechaGenero.Text = IIf(Not IsDBNull(Dt(0)("FECHAGENERO")), Dt(0)("FECHAGENERO"), Dt(0)("FechaCompromiso"))
                txtFechaCompromiso.Text = IIf(Not IsDBNull(Dt(0)("FechaCompromiso")), Dt(0)("FechaCompromiso"), "")
                txtMonto.Text = IIf(Not IsDBNull(Dt(0)("Monto")), Dt(0)("Monto"), "")
                cboMoneda.Text = IIf(Not IsDBNull(Dt(0)("Moneda")), Dt(0)("Moneda"), "")
                cboOperacion.Text = IIf(Not IsDBNull(Dt(0)("NUMOPERACION")), Dt(0)("NUMOPERACION"), "")
                cboTipoPago.Text = IIf(Not IsDBNull(Dt(0)("TIPOPAGO")), Dt(0)("TIPOPAGO"), "")
                Condicion = IIf(Not IsDBNull(Dt(0)("PAGADO")), Dt(0)("PAGADO"), "")
                If Condicion = "SI" Then
                    chkPagado.Checked = True
                Else
                    chkPagado.Checked = False
                End If
            End If
        End Using
    End Sub

    Private Sub btnGrabar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnGrabar.Click
        Dim pagado As String = ""
        If txtFechaGenero.Text > txtFechaCompromiso.Text Then
            CtlMensajes1.Mensaje("AVISO..: La Fecha de Compromiso no puede ser menor que la Fecha Genero!")
            txtFechaGenero.Focus()
            Exit Sub
        End If

        If Len(Trim(txtMonto.Text)) = 0 Then
            CtlMensajes1.Mensaje("AVISO..: ESCRIBA UN MONTO DE PAGO!")
            txtMonto.Focus()
            Exit Sub
        End If

        If Len(Trim(cboMoneda.Text)) = 0 Then
            CtlMensajes1.Mensaje("AVISO..: SELECCIONE UNA MONEDA!")
            cboMoneda.Focus()
            Exit Sub
        End If

        If Len(Trim(cboTipoPago.Text)) = 0 Then
            CtlMensajes1.Mensaje("AVISO..: SELECCIONE UN TIPO DE PAGO!")
            cboTipoPago.Focus()
            Exit Sub
        End If

        If cboMoneda.Text = "" Then
            CtlMensajes1.Mensaje("AVISO..: SELECCIONE UN TIPO DE MONEDA!")
            Exit Sub
        End If

        If chkPagado.Checked = True Then
            PAGADO = "SI"
        Else
            PAGADO = "NO"
        End If

        Try
            If Titulo = "NUEVO COMPROMISO" Then
                blcobranza.FunctionGlobal(":pidclienteƒ:pfechageneroƒ:pfechacompromisoƒ:pmontoƒ:pmonedaƒ:poperacionƒ:ptipopagoƒ:ppagado▓" & lblIdCliente.Text & "ƒ" & Format(CDate(txtFechaGenero.Text), "yyyy/mm/dd") & "ƒ" & Format(CDate(txtFechaCompromiso.Text), "yyyy/mm/dd") & "ƒ" & txtMonto.Text & "ƒ" & cboMoneda.Text & "ƒ" & cboOperacion.Text & "ƒ" & cboTipoPago.Text & "ƒ" & pagado, "QRYCMP006")
            ElseIf Titulo = "MODIFICAR COMPROMISO" Then
                blcobranza.FunctionGlobal(":pfechacompromisoƒ:pmontoƒ:pmonedaƒ:poperacionƒ:ptipopagoƒ:ppagadoƒ:pidcompromiso▓" & Format(CDate(txtFechaCompromiso.Text), "yyyy/mm/dd") & "ƒ" & txtMonto.Text & "ƒ" & cboMoneda.Text & "ƒ" & cboOperacion.Text & "ƒ" & cboTipoPago.Text & "ƒ" & pagado & "ƒ" & lblIdCompromiso.Text, "QRYCMP007")
            End If
            CtlMensajes1.Mensaje("EL COMPROMISO SE GUARDÓ CORRECTAMENTE!")
        Catch ex As Exception
            CtlMensajes1.Mensaje("ERROR..: " & ex.Message)
        End Try
        Me.Visible = False
    End Sub

    Private Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            Cargar_TipoPago()
            Cargar_TipoMoneda()
        End If
    End Sub
End Class