Imports BL
Imports System.IO
Imports System.Security.Permissions
Imports ConDB



Partial Public Class ReporteCompromisos
    Inherits System.Web.UI.UserControl
    Dim BLReporteCompromiso As New BL.ReporteCompromiso
    Dim BLReporteTrabajo As New BL.ReporteTrabajo
    Dim dt As New DataTable
    Dim Gen As New General
    Dim Con As New ConDB.ConSQL
    Dim Datos As New BL.Cobranza


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Titulo = Request.QueryString("titulo")
        If Not Me.IsPostBack Then
            Timer1.Enabled = False
            If Titulo = "REPORTE DE CLIENTES POR EMPRESA Y DIRECCION DE TRABAJO" Then
                GrupoReporteCompromiso.Visible = False
            End If
        End If
    End Sub


    Public Property VerFechaInicio() As Boolean
        Get
            Return GrupoFechaInicio.Visible
        End Get
        Set(ByVal value As Boolean)
            GrupoFechaInicio.Visible = value
        End Set
    End Property

    Public Property VerFechaFin() As Boolean
        Get
            Return GrupoFechaFin.Visible
        End Get
        Set(ByVal value As Boolean)
            GrupoFechaFin.Visible = value
        End Set
    End Property

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

    Sub BuscarReporteCompromiso()
        Try
            If lblTituloControl.Text = "REPORTE DE COMPROMISO" Then
                Dim CriterioTodos As String = "IDCOMPROMISO>0"
                Dim CriterioCartera As String = ""
                Dim CriterioGestor As String = ""
                Dim CriterioFechaIni As String = ""
                Dim CriterioFechaFin As String = ""

                If Len(Trim(cboCartera.Text)) <> 0 Then
                    CriterioCartera = " AND NOMCARTERA LIKE '" & cboCartera.Text & "%'"
                End If

                If Len(Trim(cboGestor.Text)) <> 0 Then
                    CriterioGestor = " AND USUARIO LIKE '" & cboGestor.Text & "%'"
                End If

                If Len(Trim(txtFechaInicio.Text)) <> 0 And Len(Trim(txtFechaFin.Text)) <> 0 Then
                    CriterioFechaIni = " AND COMPROMISO.FECHACOMPROMISO>='" & txtFechaInicio.Text & "'"
                    CriterioFechaFin = " AND COMPROMISO.FECHACOMPROMISO<='" & txtFechaFin.Text & "'"
                End If
                dt = BLReporteCompromiso.Reporte(CriterioTodos & CriterioCartera & CriterioGestor & CriterioFechaIni & CriterioFechaFin)
                CtlGrilla1.OcultarColumnas = "19;20;21"
                CtlGrilla1.SourceDataTable = dt
            ElseIf lblTituloControl.Text = "REPORTE DE CLIENTES POR EMPRESA Y DIRECCION DE TRABAJO" Then
                Dim CriterioTodos As String = "(Cliente.Estado <> 'E') AND (Operacion.Estado <> 'E') AND (LEN(RTRIM(Operacion.EmpresaTrabajo)) > 0) AND (Operacion.EmpresaTrabajo<>'----------')"
                Dim CriterioCartera As String = ""
                Dim CriterioGestor As String = ""

                If Len(Trim(cboCartera.Text)) <> 0 Then
                    CriterioCartera = " AND NOMCARTERA LIKE '" & cboCartera.Text & "%'"
                End If

                If Len(Trim(cboGestor.Text)) <> 0 Then
                    CriterioGestor = " AND  GESTOR LIKE '" & cboGestor.Text & "%'"
                End If

                dt = BLReporteTrabajo.Reporte(CriterioTodos & CriterioCartera & CriterioGestor)
                CtlGrilla1.SourceDataTable = dt
            End If
        Catch ex As Exception
            CtlMensajes1.Mensaje("Se ha producido un error al cargar los datos", "SISTEMA DE COBRANZA")
        End Try
    End Sub

    Private Sub imgBuscar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgBuscar.Click
        BuscarReporteCompromiso()
    End Sub

    Private Sub mgRpteCompromiso_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles mgRpteCompromiso.Click
        'Dim dt1 As New DataTable
        'Dim dt2 As New DataTable
        Dim dt As Boolean = False


        If Len(Trim(txtFechaInicio.Text)) = 0 Or Len(Trim(txtFechaInicio.Text)) = 0 Then
            CtlMensajes1.Mensaje("Falta Seleccionar Fecha")
        ElseIf Len(Trim(cboCartera.Text)) = 0 Then
            CtlMensajes1.Mensaje("Seleccione la Cartera para generar el Reporte", "SISTEMA DE COBRANZA")
        Else

            'BLReporteCompromiso.generarReporte(cboCartera.Text, txtFechaInicio.Text, txtFechaFin.Text, dt, dt2)
            'Gen.exportar_Comrpromiso_xls(dt, dt2, txtFechaInicio.Text, txtFechaFin.Text)
            Dim ruta As String = cboCartera.Text & Date.Now.ToString("yyyyMMddhhmmssfff")
            'dt = BLReporteCompromiso.generarReportes(ruta, Mid(txtFechaInicio.Text, 7, 4) & Mid(txtFechaInicio.Text, 4, 2) & Mid(txtFechaInicio.Text, 1, 2), Mid(txtFechaFin.Text, 7, 4) & Mid(txtFechaFin.Text, 4, 2) & Mid(txtFechaFin.Text, 1, 2))
            Dim Parametros = ruta & "ƒ" & Mid(txtFechaInicio.Text, 7, 4) & Mid(txtFechaInicio.Text, 4, 2) & Mid(txtFechaInicio.Text, 1, 2) & "ƒ" & Mid(txtFechaFin.Text, 7, 4) & Mid(txtFechaFin.Text, 4, 2) & Mid(txtFechaFin.Text, 1, 2) & "ƒ" & cboCartera.Text


            Dim initString As String = "maRtinez@81"
            ' Instantiate the secure string.
            Dim testString As New System.Security.SecureString
            ' Use the AppendChar method to add each char value to the secure string.
            For Each ch As Char In initString
                testString.AppendChar(ch)
            Next


            'Con.CreateMySQLCommand("Exec xp_cmdshell 'C:\ProcesoDescargas\EjecutaCompromiso.bat " & Parametros & "'")

            'System.Diagnostics.Process.Start(Server.MapPath("Files\GeneraCompromiso.exe"), Parametros)

            'Dim proc As New System.Diagnostics.Process
            'proc.StartInfo.UseShellExecute = True
            'proc.StartInfo.FileName = Server.MapPath("Files/EXE.exe")
            'proc.StartInfo.Arguments = Parametros
            'proc.StartInfo.CreateNoWindow = True
            'proc.StartInfo.ErrorDialog = True
            'proc.StartInfo.LoadUserProfile = True
            'proc.Start()

            'Dim MObj = Server.CreateObject("WScript.Shell")
            'Dim oExec = MObj.Exec("start D:\PIMAY\Infoteca\Produccion\ASPNet\Cobranza\Files\EXE.exe " & Parametros)


            'Dim pObj As New Process()
            'pObj.StartInfo.RedirectStandardOutput = True
            'pObj.StartInfo.FileName = Server.MapPath("Files/GeneraReporte.exe")
            'pObj.StartInfo.Arguments = Parametros
            'pObj.StartInfo.UseShellExecute = False
            'pObj.StartInfo.CreateNoWindow = False
            'pObj.Start()




            'Dim startInfo As New ProcessStartInfo(Server.MapPath("Files/GeneraReporte.exe"))
            'startInfo.WindowStyle = ProcessWindowStyle.Minimized
            'startInfo.Arguments = Parametros
            'Process.Start(startInfo)

            'Dim Proc As New ProcessStartInfo
            'Proc.FileName = Server.MapPath("Files/EXE.exe")
            'Proc.Arguments = Parametros
            'Process.Start(Proc)

            Dim arch As New StreamWriter(Server.MapPath(".") & "/Files/CROWN_" & Format(Now, "yyyyMMddhhss") & ".lst", True)
            arch.WriteLine(Datos.usuario.ToString)
            arch.WriteLine(Datos.pwd.ToString)
            arch.WriteLine(Datos.bd.ToString)
            arch.WriteLine(Datos.servidor.ToString)
            arch.WriteLine("ReporteCompromiso")
            arch.WriteLine("GeneraReporte.exe")
            arch.WriteLine(Parametros)
            arch.WriteLine(Session("NombreGestor"))
            arch.Close()

            Rutas = ruta
            Timer1.Enabled = True
            Timer1.Interval = 1000

            'Response.Redirect("Files/" & ruta & ".xlsx")

        End If
    End Sub

    Private Sub Timer1_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If File.Exists(Server.MapPath("Files/" & Rutas & ".xlsx")) Then
            ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "script", "window.open('Files/" & Rutas & ".xlsx');", True)
            Timer1.Enabled = False
            Carga1.Visible = False
        Else
            Carga1.Visible = True
        End If
    End Sub

    Private Property Rutas() As String
        Get
            Return Session("ruta")
        End Get
        Set(ByVal value As String)
            Session("ruta") = value
        End Set
    End Property

End Class