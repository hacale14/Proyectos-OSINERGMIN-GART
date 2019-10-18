Public Partial Class NMPagos
    Inherits System.Web.UI.UserControl
    Dim gmp_activa As Boolean
    Dim blpagos As New BL.Pagos
    Dim blcobranza As New BL.Cobranza


    Public Property Titulo() As String
        Get
            Return lblTituloControl.Text
        End Get
        Set(ByVal value As String)
            lblTituloControl.Text = value
        End Set
    End Property
    Private Sub BtnCerrar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BtnCerrar.Click
        Limpiar()
        Me.Visible = False
    End Sub
    Public Sub Nuevo(Optional ByVal Dni As String = "", Optional ByVal IdCartera As String = "")
        Dim Dt As New DataTable
        If Titulo = "NUEVO PAGO - CARTERA CASTIGO" Then
            Cargar_TipoMoneda()
            cboMoneda.Text = "S"
            txtFechaPago.Text = Format(DateTime.Now, "dd/MM/yyyy")
            If Len(Trim(Dni)) > 0 Then
                Using Dt
                    Dt = blcobranza.FunctionGlobal(":pdniƒ:pidCartera▓" & Dni & "ƒ" & IdCartera, "QRYCP002")
                    If Not Dt.Rows.Count = 0 Then
                        For Each dtr In Dt.Rows
                            lblIDCliente.Text = dtr("IdCliente")
                            txtCliente.Text = dtr("NombreCliente")
                            Cargar_Operacion()
                            btnBuscar.Enabled = False
                        Next
                    Else
                        CtlMensajes1.Mensaje("EL CLIENTE NO PERTENECE A DICHA CARTERA!")
                        btnGrabar.Enabled = False
                    End If
                End Using
            Else
                lblIDCliente.Text = ""
                txtCliente.Text = ""
                btnBuscar.Enabled = True
            End If
        End If
    End Sub
    Private Sub Cargar_Operacion()
        With cboOperacion
            .Limpia()
            .Procedimiento = "QRYCP003"
            .Condicion = ":pIdCliente▓" & lblIDCliente.Text
            .Cargar_dll()
            .Activa = True
        End With
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
    Public Sub Cargar_Pago(ByVal IdPago As String, ByVal IdCliente As String, ByVal FechaPago As String, ByVal NombreCliente As String, ByVal NroOperacion As String, ByVal Monto As String, ByVal Moneda As String, ByVal Concepto As String)
        lblIDPago.Text = IdPago
        lblIDCliente.Text = IdCliente
        txtFechaPago.Text = FechaPago
        Cargar_Operacion()
        txtCliente.Text = NombreCliente
        cboOperacion.Text = NroOperacion
        txtPago.Text = Monto
        Cargar_TipoMoneda()
        cboMoneda.Text = Moneda
        txtObservacion.Text = Concepto
    End Sub
    Private Sub Limpiar()
        txtCliente.Text = ""
        txtFechaPago.Text = ""
        txtObservacion.Text = ""
        txtPago.Text = ""
        lblIDCliente.Text = ""
        lblIDPago.Text = ""
        cboMoneda.Text = "S"
    End Sub

    Private Sub btnGrabar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnGrabar.Click
        If Len(Trim(cboOperacion.Text)) = 0 Then
            CtlMensajes1.Mensaje("AVISO..: Seleccione una Operacion")
            cboOperacion.Focus()
            Exit Sub
        End If

        If Len(Trim(txtPago.Text)) = 0 Then
            CtlMensajes1.Mensaje("AVISO..: Escriba un Monto de Pago")
            txtPago.Focus()
            Exit Sub
        End If

        If Len(Trim(cboMoneda.Text)) = 0 Then
            CtlMensajes1.Mensaje("AVISO..: Seleccione una Moneda")
            cboMoneda.Focus()
            Exit Sub
        End If

        If Val(txtPago.Text) = 0 Then
            CtlMensajes1.Mensaje("AVISO..: El Monto a Pagar no puede ser CERO(0)!")
            txtPago.Focus()
            Exit Sub
        End If

        If Len(Trim(txtObservacion.Text)) = 0 Then
            CtlMensajes1.Mensaje("AVISO..: Escriba una Observacion o Concepto de Pago!")
            txtObservacion.Focus()
            Exit Sub
        End If

        If Titulo = "NUEVO PAGO - CARTERA CASTIGO" Then
            blcobranza.FunctionGlobal(":pIdClienteƒ:pFechaPagoƒ:pmonedaƒ:pmontoƒ:pconceptoƒ:pnumoperacion▓" & lblIDCliente.Text & "ƒ" & Format(CDate(txtFechaPago.Text), "yyyy/MM/dd") & "ƒ" & cboMoneda.Text & "ƒ" & txtPago.Text & "ƒ" & txtObservacion.Text & "ƒ" & cboOperacion.Text, "QRYCP005")
        ElseIf Titulo = "MODIFICAR PAGO - CARTERA CASTIGO" Then
            blcobranza.FunctionGlobal(":pfechapagoƒ:pmonedaƒ:pmontoƒ:pconceptoƒ:pnumoperacionƒ:pidpago▓" & Format(CDate(txtFechaPago.Text), "yyyy/MM/dd") & "ƒ" & cboMoneda.Text & "ƒ" & txtPago.Text & "ƒ" & txtObservacion.Text & "ƒ" & cboOperacion.Text & "ƒ" & lblIDPago.Text, "QRYCP006")
        End If
        Limpiar()
        CtlMensajes1.Mensaje("AVISO..: EL PAGO SE GUARDO CORRECTAMENTE!")

        Me.Visible = False
    End Sub
End Class