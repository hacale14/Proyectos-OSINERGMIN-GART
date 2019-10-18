Imports System.IO
Imports BL
Partial Public Class CtlImportarData
    Inherits System.Web.UI.UserControl
    Dim blcarga As New BL.Cobranza
    Dim blimportar As New BL.Importar
    Public mensaje As String

    Private Sub btnImportar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnImportar.Click

        If Len(Trim(cboTipoCartera.Text)) <= 0 Then
            CtlMensajes1.Mensaje("AVISO..: DEBE DE SELECCIONAR UN TIPO DE CARTERA!")
            Exit Sub
        End If
        If (Trim(cboTipoCartera.Text) = "CARTERA CASTIGO" And Len(Trim(cboCartera.Text)) <= 0) Or (Trim(cboTipoCartera.Text) = "CARTERA ACTIVA" And Len(Trim(cboCartera.Text)) <= 0) Then
            CtlMensajes1.Mensaje("AVISO..: DEBE DE SELECCIONAR UNA CARTERA!")
            Exit Sub
        End If

        Dim dt As New DataTable
        Dim con As New ConDB.ConSQL
        Try
            Using dt
                con.Graba_Log("Iniciando Importacion de Archivo")
                dt = blcarga.FunctionConsulta("SELECT 1 FROM tbl_procesos_carga WHERE Estado <> 'T'")
                If dt.Rows.Count > 0 Then
                    CtlMensajes1.Mensaje("¡Advertencia en este momento no puede haber cargas hay otro job que esta en proceso...!")
                    Exit Sub
                End If
                If FileArchivo.PostedFile IsNot Nothing Then
                    Dim FileName As String = Path.GetFileName(FileArchivo.PostedFile.FileName)
                    Dim Extension As String = Path.GetExtension(FileArchivo.PostedFile.FileName)
                    Dim Milisegundos As String = CStr(Now.Millisecond)
                    Dim NombreArchivo As String = "CARGA" & Format(Now(), "yyyyMMddhhmmss" & Milisegundos)
                    Dim ruta As String = Server.MapPath("Files/" & NombreArchivo & Extension)
                    FileArchivo.SaveAs(ruta)
                    Dim cantidad As Integer = 0
                    Session("usuario") = Obtiene_Cookies("usuario")
                    If cboCartera.Activa = False Then
                        blcarga.FunctionGlobal(":ptipocarteraƒ:pidcarteraƒ:pnombreƒ:pcantcargadaƒ:pusuarioƒ:pmotivoƒ:pfechacorte▓" & cboTipoCartera.Text & "ƒ" & 0 & "ƒ" & NombreArchivo & "ƒ" & cantidad & "ƒ" & Session("usuario") & "ƒ" & txtMotivo.Text & "ƒ" & txtFechaCorte.Text & " 00:00:00", "QRYIMP001")
                    Else
                        blcarga.FunctionGlobal(":ptipocarteraƒ:pidcarteraƒ:pnombreƒ:pcantcargadaƒ:pusuarioƒ:pmotivoƒ:pfechacorte▓" & cboTipoCartera.Text & "ƒ" & cboCartera.Value & "ƒ" & NombreArchivo & "ƒ" & cantidad & "ƒ" & Session("usuario") & "ƒ" & txtMotivo.Text & "ƒ" & txtFechaCorte.Text & " 00:00:00", "QRYIMP001")
                    End If
                    blcarga.FunctionEjecuta("Exec xp_cmdshell 'C:\ProcesoCargas\COBRANZA.bat " & blcarga.usuario & "ƒ" & blcarga.pwd & "ƒ" & blcarga.bd & "ƒ" & blcarga.servidor & "ƒ" & NombreArchivo & "'")
                    'blcarga.FunctionEjecuta("Execute [dbo].[sp_carga_cartera]")
                    blcarga.FunctionEjecuta("Exec xp_cmdshell 'C:\ProcesoCargas\CobranzaSube.bat")
                    dt = blcarga.FunctionGlobal(":criterio▓" & " ", "QRYIMP002")
                    CtlGrilla1.SourceDataTable = dt
                    Timer1.Enabled = True
                    con.Graba_Log("El Proceso Comenzo Correctamente")
                End If
            End Using
        Catch ex As Exception
            mensaje = ex.Message
            con.Graba_Log("//ERROR: " & mensaje)
            dt = Nothing
        End Try
    End Sub
    'final
    Private Sub cboTipoCartera_Click() Handles cboTipoCartera.Click
        lblMotivo.Visible = False
        txtMotivo.Visible = False
        With cboCartera
            If cboTipoCartera.Text = "CARTERA ACTIVA" Or cboTipoCartera.Text = "CARTERA CASTIGO" Then
                .Limpia()
                .Activa = True
                .Procedimiento = "QRYCG002"
                .Condicion = ":criterio▓" & Trim(Mid(cboTipoCartera.Text, 8, 8))
                .Cargar_dll()
            ElseIf cboTipoCartera.Text = "ASIGNACION" Then
                .Limpia()
                .Activa = True
                .Procedimiento = "QRYCG002"
                .Condicion = ":criterio▓ALL"
                .Cargar_dll()
            ElseIf cboTipoCartera.Text = "BOLSA" Then
                .Limpia()
                .Activa = True
                .Procedimiento = "QRYCG002"
                .Condicion = ":criterio▓ALL"
                .Cargar_dll()
                lblMotivo.Visible = True
                txtMotivo.Visible = True
            Else
                .Limpia()
                .Activa = False
            End If
        End With
    End Sub

    Private Sub CtlGrilla1_Boton_Click(ByVal GV As System.Web.UI.WebControls.GridView, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles CtlGrilla1.Boton_Click
        If e.Row.RowIndex <> -1 Then
            'If Trim(e.Row.Cells(15).Text) = "P" Then
            ' e.Row.Cells(1).Text = "<center><img src='Imagenes/ajax-loader.gif' width='20px' Height='20px' onclick=""window.open('Observacion.aspx?idProceso=" & e.Row.Cells(4).Text & "','winopen', 'status=yes, toolbar=no, menubar=no, location=no, addressbar=no,width=500,height=500,left=0,top=0,resizable=no,fullscreen,scrollbars');"""
            'ElseIf Trim(e.Row.Cells(15).Text) = "F" Then
            '    e.Row.Cells(1).Text = "<center><img src='Imagenes/semRojo.png' width='20px' Height='20px' onclick=""window.open('Observacion.aspx?idProceso=" & e.Row.Cells(4).Text & "','winopen', 'status=yes, toolbar=no, menubar=no, location=no, addressbar=no,width=500,height=500,left=0,top=0,resizable=no,fullscreen,scrollbars');"""
            'ElseIf Trim(e.Row.Cells(15).Text) = "E" Or e.Row.Cells(12).Text = "N" Then
            '   e.Row.Cells(1).Text = "<center><img src='Imagenes/ajax-loader.gif' width='20px' Height='20px' onclick=""window.open('Observacion.aspx?idProceso=" & e.Row.Cells(4).Text & "','winopen', 'status=yes, toolbar=no, menubar=no, location=no, addressbar=no,width=500,height=500,left=0,top=0,resizable=no,fullscreen,scrollbars');"""
            'If Trim(e.Row.Cells(15).Text) = "T" Then
            'e.Row.Cells(1).Text = "<center><img src='Imagenes/semVerde.png' width='20px' Height='20px' onclick=""window.open('Observacion.aspx?idProceso=" & e.Row.Cells(4).Text & "','winopen', 'status=yes, toolbar=no, menubar=no, location=no, addressbar=no,width=500,height=500,left=0,top=0,resizable=no,fullscreen,scrollbars');"""
            If Trim(e.Row.Cells(15).Text) = "T" Then
                e.Row.Cells(1).Text = "<center><img src='Imagenes/semVerde.png' width='20px' Height='20px' onclick=""window.open('Observacion.aspx?idProceso=" & e.Row.Cells(4).Text & "','winopen', 'status=yes, toolbar=no, menubar=no, location=no, addressbar=no,width=500,height=500,left=0,top=0,resizable=no,fullscreen,scrollbars');"""
            ElseIf Trim(e.Row.Cells(15).Text) = "R" Then
                e.Row.Cells(1).Text = "<center><img src='Imagenes/semRojo.png' width='20px' Height='20px' onclick=""window.open('Observacion.aspx?idProceso=" & e.Row.Cells(4).Text & "','winopen', 'status=yes, toolbar=no, menubar=no, location=no, addressbar=no,width=500,height=500,left=0,top=0,resizable=no,fullscreen,scrollbars');"""
            Else
                e.Row.Cells(1).Text = "<center><img src='Imagenes/ajax-loader.gif' width='20px' Height='20px' onclick=""window.open('Observacion.aspx?idProceso=" & e.Row.Cells(4).Text & "','winopen', 'status=yes, toolbar=no, menubar=no, location=no, addressbar=no,width=500,height=500,left=0,top=0,resizable=no,fullscreen,scrollbars');"""
            End If
        End If
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnBuscar.Click
        Dim idCartera As String = ""
        Try
            Dim dt As New DataTable
            Using dt

                If Len(Trim(cboTipoCartera.Text)) = 0 And Len(Trim(cboCartera.Text)) = 0 And Len(Trim(txtFechaFin.Text)) = 0 And Len(Trim(txtFechaInicio.Text)) = 0 Then
                    CtlMensajes1.Mensaje("AVISO..: PARA REALIZAR UNA BUSQUEDA ES NECESARIO SELECCIONAR O INGRESAR ALGUNOS DE LOS SIGUIENTES CAMPOS: TIPO IMPORTAR, CARTERA, FECHA REGISTRO Y FECHA TERMINO")
                    Exit Sub
                End If

                If Len(Trim(cboCartera.Text)) = 0 Then
                    idCartera = 0
                End If

                dt = blcarga.FunctionGlobal(":ptipocarteraƒ:pidcarteraƒ:pfechainicioƒ:pfechafin▓" & cboTipoCartera.Text & "ƒ" & Val(cboCartera.Value).ToString & "ƒ" & txtFechaInicio.Text & "ƒ" & txtFechaInicio.Text, "QRYPCB001")
                CtlGrilla1.SourceDataTable = dt
            End Using
        Catch ex As Exception

        End Try

    End Sub

    Private Sub Timer1_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Buscar()
    End Sub

    Sub Buscar()
        Dim idCartera As String = ""
        Try
            Dim dt As New DataTable
            Using dt

                If Len(Trim(cboTipoCartera.Text)) = 0 And Len(Trim(cboCartera.Text)) = 0 And Len(Trim(txtFechaFin.Text)) = 0 And Len(Trim(txtFechaInicio.Text)) = 0 Then
                    CtlMensajes1.Mensaje("AVISO..: PARA REALIZAR UNA BUSQUEDA ES NECESARIO SELECCIONAR O INGRESAR ALGUNOS DE LOS SIGUIENTES CAMPOS: TIPO IMPORTAR, CARTERA, FECHA REGISTRO Y FECHA TERMINO")
                    Exit Sub
                End If

                If Len(Trim(cboCartera.Text)) = 0 Then
                    idCartera = 0
                End If

                dt = blcarga.FunctionGlobal(":ptipocarteraƒ:pidcarteraƒ:pfechainicioƒ:pfechafin▓" & cboTipoCartera.Text & "ƒ" & cboCartera.Value & "ƒ" & IIf(txtFechaInicio.Text = "", Now().Date, txtFechaInicio.Text) & "ƒ" & IIf(txtFechaInicio.Text = "", Now().Date, txtFechaInicio.Text), "QRYPCB001")
                CtlGrilla1.SourceDataTable = dt
            End Using
        Catch ex As Exception

        End Try
    End Sub
    Private Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            Timer1.Enabled = False
            txtFechaCorte.Text = Now.Date()
            Dim Perfil As String = Obtiene_Cookies("TipoUsuario")
            If Perfil = "SUPERVISOR" Then
                cboTipoCartera.Condicion = ":cod▓127"
                cboTipoCartera.Cargar_dll()
            End If
        End If
    End Sub

    Private Sub CtlGrilla1_RowDeleting(ByVal GV As System.Web.UI.WebControls.GridView, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles CtlGrilla1.RowDeleting
        blcarga.FunctionGlobal(":idproceso▓" & Val(GV.Rows(e.RowIndex).Cells(4).Text), "QRYCARG001")
        CtlMensajes1.Mensaje("El proceos ha sido cancelado", "")
        Dim sender As Object
        Dim x As System.EventArgs
        btnBuscar_Click(sender, x)
    End Sub

    Private Sub CtlGrilla1_RowEditing(ByVal GV As System.Web.UI.WebControls.GridView, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs, ByVal row As System.Web.UI.WebControls.GridViewRow) Handles CtlGrilla1.RowEditing
        blcarga.FunctionGlobal(":idproceso▓" & Val(row.Cells(4).Text), "QRYCARG002")
        blcarga.FunctionEjecuta("Exec sp_carga_cartera")
        CtlMensajes1.Mensaje("El proceso ha sido cargado", "")
        Dim sender As Object
        Dim x As System.EventArgs
        btnBuscar_Click(sender, x)
    End Sub
    Function Obtiene_Cookies(ByVal id) As String
        '// Recogemos la cookie que nos interese
        Try
            Dim cogeCookie As HttpCookie = Request.Cookies.Get(id)
            Return cogeCookie.Value
        Catch ex As Exception
            Return ""
        End Try
    End Function
End Class