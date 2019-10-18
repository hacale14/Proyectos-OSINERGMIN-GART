Imports BL

Partial Public Class ReportePagos
    Inherits System.Web.UI.UserControl
    Dim BLReportePago As New BL.Pagos
    
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Titulo = Request.QueryString("titulo")
        If Not Me.IsPostBack Then
            If Titulo = "REPORTE DE PAGOS - CARTERA CASTIGO" Then
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
        Dim criterioConcepto As String = ""
        Dim criterioMoneda As String = ""
        txtConcepto0.Text = ""
        txtConcepto1.Text = ""

        If Len(Trim(cboCartera.Text)) = 0 Then
            criterioCartera = ""
        Else
            criterioCartera = " AND Cartera.NOMCARTERA LIKE '" & cboCartera.Text & "%'"
        End If

        If Len(Trim(cboGestor.Text)) = 0 Then
            criterioGestor = ""
        Else
            criterioGestor = " AND USUARIO LIKE '" & cboGestor.Text & "%'"
        End If

        If Len(Trim(txtFechaInicio.Text)) <> 0 And chkInicio.Checked = True Then
            If Titulo = "REPORTE DE PAGOS - CARTERA CASTIGO" Then
                criterioFechaIni = " AND PAGO.FECHAPAGO>='" & txtFechaInicio.Text & "'"
            Else
                criterioFechaIni = " AND PAGOACTIVA.FECHAPAGO>='" & txtFechaInicio.Text & "'"
            End If
        Else
            criterioFechaIni = ""
        End If

        If Len(Trim(txtFechaFin.Text)) <> 0 And chkFin.Checked = True Then
            If Titulo = "REPORTE DE PAGOS - CARTERA CASTIGO" Then
                criterioFechaFin = " AND PAGO.FECHAPAGO<='" & txtFechaFin.Text & "'"
            Else
                criterioFechaFin = " AND PAGOACTIVA.FECHAPAGO<='" & txtFechaFin.Text & "'"
            End If
        Else
            criterioFechaFin = ""
        End If

        If Len(Trim(cboMoneda.Text)) = 0 Then
            criterioMoneda = ""
        Else
            If cboMoneda.Text = "Soles" Then
                criterioMoneda = " AND PAGO.MONEDA = 'S'"
            ElseIf cboMoneda.Text = "Dolares" Then
                criterioMoneda = " AND PAGO.MONEDA = 'D'"
            End If
        End If

        If Len(Trim(txtConcepto.Text)) = 0 Then
            criterioConcepto = ""
        Else
            criterioConcepto = " AND CONCEPTO LIKE '%" & txtConcepto.Text & "%'"
        End If

        Try
            If Len(Trim(txtFechaInicio.Text)) <> 0 Or Len(Trim(txtFechaFin.Text)) <> 0 Then
                If Len(Trim(cboCartera.Text)) = 0 Then
                    CtlMensajes1.Mensaje("Seleccione una cartera", "SISTEMA DE COBRANZA")
                Else
                    If Trim(cboGestor.Text) = "" Or (DateDiff(DateInterval.Day, Date.Parse(txtFechaInicio.Text), Date.Parse(txtFechaFin.Text))) > 31 Then
                        If Titulo = "REPORTE DE PAGOS - CARTERA CASTIGO" Then
                            BLReportePago.ReportePagosBatch(criterioCartera, criterioGestor, criterioFechaIni, criterioFechaFin, criterioMoneda, criterioConcepto, Session("NombreGestor"))
                        Else
                            BLReportePago.ReportePagosActivaBatch(criterioCartera, criterioGestor, criterioFechaIni, criterioFechaFin, criterioMoneda, criterioConcepto, Session("NombreGestor"))
                        End If
                        CtlMensajes1.Mensaje("EL REPORTE FUE AÑADIDO A LA COLA, ESTARA DISPONIBLE EN BREVE, SE VISUALIZARA EN LA VENTANA DE REPORTES GENERADOS", "")
                    Else
                        If Titulo = "REPORTE DE PAGOS - CARTERA CASTIGO" Then
                            dt = BLReportePago.ReportePagos(criterioCartera, criterioGestor, criterioFechaIni, criterioFechaFin, criterioMoneda, criterioConcepto)
                            'dtPagos = BLReportePago.CanridadPagos(criterioCartera, criterioGestor, criterioFechaIni, criterioFechaFin, criterioMoneda, criterioConcepto)
                        Else
                            dt = BLReportePago.ReportePagosActiva(criterioCartera, criterioGestor, criterioFechaIni, criterioFechaFin, criterioMoneda, criterioConcepto)
                            'dtPagos = BLReportePago.CanridadPagosActiva(criterioCartera, criterioGestor, criterioFechaIni, criterioFechaFin, criterioMoneda, criterioConcepto)
                        End If

                        CtlGrilla1.SourceDataTable = dt
                        If dt.Rows.Count <> 0 Then
                            Dim total As Double = 0

                            For i = 0 To dt.Rows.Count - 1
                                total = total + dt.Rows(i)("Monto")
                            Next

                            If dt.Rows(0)("Moneda") = "S" Then
                                txtConcepto0.Text = total
                            ElseIf dt.Rows(0)("Moneda") = "D" Then
                                txtConcepto1.Text = total
                            End If
                        End If
                    End If
                End If
            Else
                CtlMensajes1.Mensaje("Seleccione un rango de fecha", "SISTEMA DE COBRANZA")
            End If
        Catch ex As Exception
            CtlMensajes1.Mensaje("Error:... " & ex.Message)
        End Try
    End Sub
End Class