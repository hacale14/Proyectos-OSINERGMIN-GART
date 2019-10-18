Imports BL
Partial Public Class ReporteInformacionCobertura
    Inherits System.Web.UI.UserControl
    Dim BLReporte As New BL.Reporte

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Titulo = Request.QueryString("titulo")
        If Not Me.IsPostBack Then
            If Titulo = "REPORTE DE INFORMACION DE COBERTURA" Then
                GrupoGestor.Visible = False
            Else
                cboCartera.AutoPostBack = True
            End If
        End If
    End Sub
    Public Property Titulo() As String
        Get
            Return lblTituloControl.Text
        End Get
        Set(ByVal value As String)
            lblTituloControl.Text = value
        End Set
    End Property

    Private Sub ImageButton1_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButton1.Click
        Dim criterioFechaInicio As String = ""
        Dim criterioFechaFin As String = ""
        Dim criterioCartera As String = ""
        Dim criterioGestor As String = ""
        Dim dt As New DataTable

        If Len(Trim(txtFechaInicio.Text)) <> 0 Then
            criterioFechaInicio = " AND GESTION.FECHA>='" & txtFechaInicio.Text & "' "
        Else
            criterioFechaInicio = ""
        End If

        If Len(Trim(txtFechaFin.Text)) <> 0 Then
            criterioFechaFin = " AND GESTION.FECHA<='" & txtFechaFin.Text & "'"
        Else
            criterioFechaFin = ""
        End If

        If Len(Trim(cboCartera.Text)) <> 0 Then
            criterioCartera = " AND CARTERA.IDCARTERA=" & cboCartera.Value
        Else
            criterioCartera = ""
        End If

        If Len(Trim(cboCartera.Text)) = 0 Then
            CtlMensajes1.Mensaje("Seleccione una Cartera", "SISTEMA DE COBRANZA")
        Else
            If Titulo = "REPORTE DE INFORMACION DE COBERTURA x GESTOR" Then
                If Len(Trim(cboGestor.Text)) <> 0 Then
                    criterioGestor = " AND USUARIOCLIENTE.IDUSUARIO=" & cboGestor.Value
                Else
                    criterioGestor = ""
                End If
                dt = BLReporte.ReporteCoberturaGestor(criterioCartera, criterioGestor)
                If dt.Rows.Count <> 0 Then
                    Dim dt2 As New DataTable
                    Dim NombreCartera As String = ""
                    Dim CodGestor As String = ""
                    Dim CLientesTotales As Integer
                    Dim CLientesAtendidos As Integer
                    Dim CLientesNoAtendidos As Integer
                    Dim estado As Boolean = False

                    estado = BLReporte.ReporteCoberturaGestor2(txtFechaInicio.Text, txtFechaFin.Text, dt, NombreCartera, CodGestor, CLientesAtendidos, CLientesTotales, CLientesNoAtendidos)

                    dt2.Columns.Add("NomCartera")
                    dt2.Columns.Add("CodGestor")
                    dt2.Columns.Add("Fecha Ini")
                    dt2.Columns.Add("Fecha Fin")
                    dt2.Columns.Add("Total Client")
                    dt2.Columns.Add("Atendidos")
                    dt2.Columns.Add("No atendidos")
                    dt2.Columns.Add("% Coberturado")
                    dt2.Columns.Add("% Por Coberturar")

                    Dim fila As DataRow = dt2.NewRow
                    fila(0) = NombreCartera
                    fila(1) = CodGestor
                    fila(2) = txtFechaInicio.Text
                    fila(3) = txtFechaFin.Text
                    fila(4) = CLientesTotales
                    fila(5) = CLientesAtendidos
                    fila(6) = CLientesNoAtendidos
                    fila(7) = Math.Round(CLientesAtendidos / CLientesTotales * 100, 2)
                    fila(8) = Math.Round(CLientesNoAtendidos / CLientesTotales * 100, 2)
                    dt2.Rows.Add(fila)
                    If dt2.Rows.Count <> 0 Then
                        CtlGrilla1.SourceDataTable = dt2
                        Dim dt3 As New DataTable
                        dt3.Columns.Add("Status")
                        dt3.Columns.Add("Total")
                        'Coberurados
                        dt3.Rows.Add("COBERTURADOS", dt2.Rows(0)(7))
                        dt3.Rows.Add("POR COBERTURAR", dt2.Rows(0)(8))
                        Chart1.DataSource = dt3
                        Chart1.Series("Series1").XValueMember = "Status"
                        Chart1.Series("Series1").YValueMembers = "Total"
                        Chart1.DataBind()
                        Chart1.Titles("Title1").Text = "COBERTURA DE CARTERA " & NombreCartera & " X GESTOR " & CodGestor
                    End If
                End If

            Else
                dt = BLReporte.ReporteCobertura(criterioCartera)
                If dt.Rows.Count <> 0 Then
                    Dim dt2 As New DataTable
                    Dim NombreCartera As String = ""
                    Dim CLientesTotales As Integer
                    Dim CLientesAtendidos As Integer
                    Dim CLientesNoAtendidos As Integer
                    Dim estado As Boolean = False
                    estado = BLReporte.ReporteCobertura2(txtFechaInicio.Text, txtFechaFin.Text, dt, NombreCartera, CLientesTotales, CLientesAtendidos, CLientesNoAtendidos)
                    dt2.Columns.Add("NomCartera")
                    dt2.Columns.Add("Fecha Ini")
                    dt2.Columns.Add("Fecha Fin")
                    dt2.Columns.Add("Total Client")
                    dt2.Columns.Add("Atendidos")
                    dt2.Columns.Add("No atendidos")
                    dt2.Columns.Add("% Coberturado")
                    dt2.Columns.Add("% Por Coberturar")

                    Dim fila As DataRow = dt2.NewRow
                    fila(0) = NombreCartera
                    fila(1) = txtFechaInicio.Text
                    fila(2) = txtFechaFin.Text
                    fila(3) = CLientesTotales
                    fila(4) = CLientesAtendidos
                    fila(5) = CLientesNoAtendidos
                    fila(6) = Math.Round(CLientesAtendidos / CLientesTotales * 100, 2)
                    fila(7) = Math.Round(CLientesNoAtendidos / CLientesTotales * 100, 2)
                    dt2.Rows.Add(fila)
                    If dt2.Rows.Count <> 0 Then
                        CtlGrilla1.SourceDataTable = dt2
                        Dim dt3 As New DataTable
                        dt3.Columns.Add("Status")
                        dt3.Columns.Add("Total")
                        'Coberurados
                        dt3.Rows.Add("COBERTURADOS", dt2.Rows(0)(6))
                        dt3.Rows.Add("POR COBERTURAR", dt2.Rows(0)(7))
                        Chart1.DataSource = dt3
                        Chart1.Series("Series1").XValueMember = "Status"
                        Chart1.Series("Series1").YValueMembers = "Total"
                        Chart1.DataBind()
                        Chart1.Titles("Title1").Text = "COBERTURA DE CARTERA " & NombreCartera
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub cboCartera_Click() Handles cboCartera.Click
        With cboGestor
            .Limpia()
            .Procedimiento = "QRYCOM003"
            .Condicion = ":criterioidcartera▓HAVING Cartera.IdCartera = " & cboCartera.Value
            .Cargar_dll()
        End With
    End Sub
End Class