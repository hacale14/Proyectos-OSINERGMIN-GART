Imports BL
Imports System.IO

Partial Public Class ReporteGestionInterno
    Inherits System.Web.UI.UserControl
    Dim BLReporteGestion As New BL.Cartera

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Titulo = Request.QueryString("titulo")
        If Not Me.IsPostBack Then
            CargaInicio()
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


    Sub CargaInicio()
        Dim dt As New DataTable
        Dim criterioInicioFecha = " AND convert(date,Fecha_Registro,103)>='" & Format(Now, "dd/MM/yyyy") & "'"
        Dim criterioFinFecha = " AND convert(date,Fecha_Registro,103)<='" & Format(Now, "dd/MM/yyyy") & "'"
        'dt = BLReporteGestion.ReporteGestion(criterioInicioFecha, criterioFinFecha)
        'CtlGrilla1.SourceDataTable = dt
    End Sub


    Private Sub imgBuscar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgBuscar.Click
        Dim dt As New DataTable
        Dim criterioTipoInformacion As String = ""
        Dim criterioTipoCartera As String = ""
        Dim criterioInicioFecha As String = ""
        Dim criterioFinFecha As String = ""

        If Len(Trim(txtFechaInicio.Text)) = 0 Or Len(Trim(txtFechaFin.Text)) = 0 Then
            CtlMensajes1.Mensaje("Seleccione un rango de fecha", "SISTEMA DE COBRANZA")
        Else
            dt = BLReporteGestion.ReporteGestion(cboTipo.Text, cboInformacion.Text, CboCartera.Value, txtFechaInicio.Text, txtFechaFin.Text)
            CtlGrilla1.SourceDataTable = dt
            CtlGrilla1.Visible = True
        End If

    End Sub

    Private Sub CtlGrilla1_Boton_Click(ByVal GV As System.Web.UI.WebControls.GridView, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles CtlGrilla1.Boton_Click
        ' If e.Row.RowIndex <> -1 Then
        ' Dim myFilePath As String = Server.MapPath("~/Files/" & e.Row.Cells(8).Text & ".xlsx")
        ' If File.Exists(myFilePath) Then
        ' e.Row.Cells(3).Text = "<center><img src='Imagenes/descargar.png' id='imgButton' alt='Smiley face' height='20px' width='20px' onclick=DescarArchivo('Files/" & e.Row.Cells(8).Text.Replace(" ", "%20") & ".xlsx')></center>"
        ' Else
        'e.Row.Cells(3).Text = ""
        ' End If
        ' End If
    End Sub

    Private Sub cboTipo_Click() Handles cboTipo.Click
        CboCartera.Condicion = ":criterio▓" & cboTipo.Text
        CboCartera.Cargar_dll()
    End Sub
End Class