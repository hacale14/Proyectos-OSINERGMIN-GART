Imports BL
Partial Public Class CalculoIndicadoresCobertura
    Inherits System.Web.UI.UserControl
    Dim BLTipoCambio As New BL.TipoCambio
    Dim BLIndicador As New BL.Calculo
    Dim Cobranza As New BL.Cobranza
    

    Dim dt As New DataTable

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
        End If
    End Sub



    Private Sub cboCartera_Click() Handles cboCartera.Click
        With cboGestor
            .Limpia()
            .Procedimiento = "QRYCOM003"
            .Condicion = ":criterioidcartera▓HAVING Cartera.IdCartera = " & cboCartera.Value
            .Cargar_dll()
        End With
        'BLTipoCambio.IdCartera = cboCartera.Value
        dt = BLTipoCambio.BuscarTipoCambio
        If dt.Rows.Count <> 0 Then
            Try
                txtCambio.Text = dt.Rows(0)(1)
            Catch ex As Exception
                CtlMensajes1.Mensaje("Se ha producido un error al cargar el tipo de cambio", "SISTEMA DE COBRANZA")
            End Try
        Else
            txtCambio.Text = "0"
        End If
    End Sub


    Private Sub imgCalcularIndicadores_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgCalcularIndicadores.Click
        Dim pagos As Double
        Dim DeudaVencida As Double
        Dim CuentasGestionadas As Integer
        Dim CuentaAsignadas As Integer
        Dim TotalPromesasPago As Integer
        Dim TotalGestionDirecta As Integer
        Dim ClientesAsignados As Integer
        Dim Capital As Double
        Dim DeudaTotal As Double
        Dim Efectividad As Double
        Dim Coberura As Double
        Dim Cont_Hum As Double
        Dim Cont_Direct As Double
        Dim Int_Gest As Double
        Dim Int_Contact As Double
        Dim Cierre_PDP As Double
        Dim Efect_PDP As Double
        Dim TotalPromesasCumplidas As Integer
        Dim TotalGestionesHumanas As Integer
        Dim TotalGestionTitular As Integer

        If Len(Trim(cboGestor.Text)) = 0 Then
            Dim dt As New DataTable
            Try
                Dim ClientesAsignados2 As Integer = 0
                Dim CuentaAsignadas2 As Integer = 0
                Dim CuentasGestionadas2 As Integer = 0
                Dim Capital2 As Double = 0
                Dim DeudaTotal2 As Double = 0
                Dim DeudaVencida2 As Double = 0
                Dim pagos2 As Double = 0
                Dim TotalPromesasPago2 As Integer = 0
                Dim TotalPromesasCumplidas2 As Integer = 0
                Dim TotalGestionesHumanas2 As Integer = 0
                Dim TotalGestionDirecta2 As Integer = 0
                Dim TotalGestionTitular2 As Integer = 0
                dt = Cobranza.FunctionGlobal(":criterioidcartera▓HAVING Cartera.IdCartera = " & cboCartera.Value, "QRYCOM003")
                If dt.Rows.Count <> 0 Then
                    For i = 0 To dt.Rows.Count - 1
                        BLIndicador.CalcularIndicadores(cboCartera.Text, cboCartera.Value, dt.Rows(i)(0), txtFechaInicio.Text, txtFechaFin.Text, txtCambio.Text, ClientesAsignados2, CuentaAsignadas2, CuentasGestionadas2, Capital2, DeudaTotal2, DeudaVencida2, pagos2, TotalPromesasPago2, TotalPromesasCumplidas2, TotalGestionesHumanas2, TotalGestionDirecta2, TotalGestionTitular2)

                        TotalGestionDirecta = TotalGestionDirecta + TotalGestionDirecta2
                        TotalGestionesHumanas = TotalGestionesHumanas + TotalGestionesHumanas2
                        TotalGestionTitular = TotalGestionTitular + TotalGestionTitular2
                        TotalPromesasPago = TotalPromesasPago + TotalPromesasPago2
                        TotalPromesasCumplidas = TotalPromesasCumplidas + TotalPromesasCumplidas2

                        ClientesAsignados = ClientesAsignados + ClientesAsignados2
                        CuentaAsignadas = CuentaAsignadas + CuentaAsignadas2
                        CuentasGestionadas = CuentasGestionadas + CuentasGestionadas2
                        Capital = Capital + Capital2
                        DeudaTotal = DeudaTotal + DeudaTotal2
                        DeudaVencida = DeudaVencida + DeudaVencida2
                        pagos = pagos + pagos2
                    Next
                Else
                    CtlMensajes1.Mensaje("Error al cargar las lista de gestores", "SISTEMA DE COBRANZA")
                    Exit Sub
                End If
                BLIndicador.CalcularIndices(pagos, DeudaVencida, CuentasGestionadas, CuentaAsignadas, TotalGestionesHumanas, TotalGestionDirecta, TotalGestionTitular, TotalPromesasPago, TotalPromesasCumplidas, Efectividad, Coberura, Cont_Hum, Cont_Direct, Int_Gest, Int_Contact, Cierre_PDP, Efect_PDP)
            Catch ex As Exception
                CtlMensajes1.Mensaje("Se produjo un error al cargar los archivos", "SISTEMA DE COBRANZA")
            End Try
        Else
            BLIndicador.CalcularIndicadores(cboCartera.Text, cboCartera.Value, cboGestor.Value, txtFechaInicio.Text, txtFechaFin.Text, txtCambio.Text, ClientesAsignados, CuentaAsignadas, CuentasGestionadas, Capital, DeudaTotal, DeudaVencida, pagos, TotalPromesasPago, TotalPromesasCumplidas, TotalGestionesHumanas, TotalGestionDirecta, TotalGestionTitular)
            BLIndicador.CalcularIndices(pagos, DeudaVencida, CuentasGestionadas, CuentaAsignadas, TotalGestionesHumanas, TotalGestionDirecta, TotalGestionTitular, TotalPromesasPago, TotalPromesasCumplidas, Efectividad, Coberura, Cont_Hum, Cont_Direct, Int_Gest, Int_Contact, Cierre_PDP, Efect_PDP)
        End If




        txtGDir.Text = TotalGestionDirecta
        txtGHum.Text = TotalGestionesHumanas
        txtGTit.Text = TotalGestionTitular
        txtCantPP.Text = TotalPromesasPago
        txtCantPC.Text = TotalPromesasCumplidas

        txtClientesAsignados.Text = ClientesAsignados
        txtCuentasAsignadas.Text = CuentaAsignadas
        txtCuentasGestionadas.Text = CuentasGestionadas
        txtCapital.Text = Capital
        txtTotal.Text = DeudaTotal
        txtDeudaVencida.Text = DeudaVencida

        txtPagos.Text = pagos
        txtEfectividad.Text = Math.Round(Efectividad * 100, 2)
        txtCobertura.Text = Math.Round(Coberura * 100, 2)
        txtContHum.Text = Math.Round(Cont_Hum * 100, 2)
        txtContDirect.Text = Math.Round(Cont_Direct * 100, 2)
        txtIntensGest.Text = Math.Round(Int_Gest, 2)
        txtIntensContac.Text = Math.Round(Int_Contact, 2)
        txtCierrePDPS.Text = Math.Round(Cierre_PDP * 100, 2)
        txtEfectPDPS.Text = Math.Round(Efect_PDP * 100, 2)
    End Sub


    Private Sub imgVerGrafico_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgVerGrafico.Click
        GraficoIndicadores1.SumaPagos = txtPagos.Text
        GraficoIndicadores1.DeudaVencida = txtDeudaVencida.Text
        GraficoIndicadores1.CuentasGestionadas = txtCuentasGestionadas.Text
        GraficoIndicadores1.CuentasAsignadas = txtCuentasAsignadas.Text
        GraficoIndicadores1.PromesasPago = txtCantPP.Text
        GraficoIndicadores1.GestionDirecta = txtGDir.Text
        pnlGrafico.Visible = True
        GraficoIndicadores1.CargarDatos()


    End Sub

    Private Sub GraficoIndicadores1_Cerrar() Handles GraficoIndicadores1.Cerrar
        pnlGrafico.Visible = False
    End Sub
End Class