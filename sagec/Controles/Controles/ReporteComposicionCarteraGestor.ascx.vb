Imports BL

Partial Public Class ReporteComposicionCarteraGestor
    Inherits System.Web.UI.UserControl
    Dim BLReporte As New BL.ReporteComposicion

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Titulo = Request.QueryString("titulo")
        If Not Me.IsPostBack Then
            If Titulo = "REPORTE DE COMPOSICION DE CARTERA" Then
                GrupoGestor.Visible = False
                GrupoInicio.Visible = False
                GrupoFin.Visible = False
            Else
                cboCartera.AutoPostBack = True
                CtlGrilla1.Ancho = "480px"
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



    Private Sub imgGenerarReporte_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgGenerarReporte.Click
        Dim CriterioCartera As String = ""
        Dim dt As New DataTable
        Dim numerocliente As Integer

        If Len(Trim(cboCartera.Text)) <> 0 Then
            CriterioCartera = " AND CARTERA.IDCARTERA=" & cboCartera.Value
        Else
            CriterioCartera = ""
        End If

        If Titulo = "REPORTE DE COMPOSICION DE CARTERA x GESTOR" Then
            If Len(Trim(txtFechaInicio.Text)) = 0 Then
                CtlMensajes1.Mensaje("SELECCIONE UNA FECHA DE INICIO", "SISTEMA DE COBRANZA")
            ElseIf Len(Trim(txtFechaFin.Text)) = 0 Then
                CtlMensajes1.Mensaje("SELECCIONE UNA FECHA DE FIN", "SISTEMA DE COBRANZA")
            ElseIf Len(Trim(cboCartera.Text)) = 0 Then
                CtlMensajes1.Mensaje("SELECCIONE UNA CARTERA", "SISTEMA DE COBRANZA")
            ElseIf Len(Trim(cboGestor.Text)) = 0 Then
                CtlMensajes1.Mensaje("SELECCIONE UNA GESTOR", "SISTEMA DE COBRANZA")
            Else
                BLReporte.ReporteComposicionCarteraGestor(txtFechaInicio.Text, txtFechaFin.Text, cboGestor.Value, cboCartera.Value, numerocliente, dt)
                txtTotalClienteCartera.Text = numerocliente
                If dt.Rows.Count <> 0 Then
                    Chart1.DataSource = dt
                    Chart1.Series("Series1").XValueMember = "Condicion"
                    Chart1.Series("Series1").YValueMembers = "Porcentaje"
                    Chart1.DataBind()
                    CtlGrilla1.SourceDataTable = dt
                    Chart1.Titles("Title1").Text = "COMPOSICION DE CARTERA " & cboCartera.Text & " GESTOR " & cboGestor.Text
                    Chart1.Series("Series1")("PieLabelStyle") = "Outside"
                Else
                    CtlMensajes1.Mensaje("NO HAY CLIENTES GESTIONADOS POR EL GESTOR")
                End If
            End If
        Else
            If Len(Trim(cboCartera.Text)) = 0 Then
                CtlMensajes1.Mensaje("SELECCIONE UNA CARTERA", "SISTEMA DE COBRANZA")
            Else
                dt = BLReporte.ReporteComposicionCartera(CriterioCartera, numerocliente)
                txtTotalClienteCartera.Text = numerocliente
                If dt.Rows.Count <> 0 Then
                    Chart1.DataSource = dt
                    Chart1.Series("Series1").XValueMember = "Descripcion"
                    Chart1.Series("Series1").YValueMembers = "Porcentaje"
                    Chart1.DataBind()
                    CtlGrilla1.SourceDataTable = dt
                    Chart1.Titles("Title1").Text = "COMPOSICION DE CARTERA " & cboCartera.Text
                    Chart1.Series("Series1")("PieLabelStyle") = "Outside"
                End If
            End If
        End If
    End Sub
End Class