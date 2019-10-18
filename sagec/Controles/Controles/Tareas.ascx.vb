Imports System
Imports System.Collections.Generic
Imports System.IO
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls

Partial Public Class Tareas
    Inherits System.Web.UI.UserControl
    Dim datos As New BL.Cobranza


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Titulo = Request.QueryString("titulo")
        If Not Me.IsPostBack Then
            Dim dt As New DataTable
            dt.Columns.Add()
            dt.Columns.Add()
            For i = 0 To 23
                Dim row As DataRow = dt.NewRow()
                row(0) = (i).ToString("00")
                row(1) = (i).ToString("00")
                dt.Rows.Add(row)
            Next
            cboHora.Carga_DT(dt.Copy)
            dt.Rows.Clear()
            For i = 0 To 59
                Dim row As DataRow = dt.NewRow()
                row(0) = (i).ToString("00")
                row(1) = (i).ToString("00")
                dt.Rows.Add(row)
            Next
            cboMinuto.Carga_DT(dt.Copy)
            cboSegundo.Carga_DT(dt.Copy)
            dt = Nothing
            Cargar()
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

    Private Sub Cargar()
        Dim dt As New DataTable
        dt.Columns.Add("Comando")
        dt.Columns.Add("Aplicacion")
        dt.Columns.Add("Parametros")
        dt.Columns.Add("Usuario")
        dt.Columns.Add("Periodo")
        dt.Columns.Add("Esporadico")
        dt.Columns.Add("Fecha")
        dt.Columns.Add("Hora")
        dt.Columns.Add("Descripcion")
        dt.Columns.Add("Ubicacion")
        Dim lista As New ListBox
        Dim myFilePath As String = Server.MapPath("~/Files/")
        'For Each foundFile As String In My.Computer.FileSystem.GetFiles(My.Computer.FileSystem.CurrentDirectory & "\Files\", Microsoft.VisualBasic.FileIO.SearchOption.SearchAllSubDirectories, "CROWN*.lst")
        For Each foundFile As String In My.Computer.FileSystem.GetFiles(myFilePath, Microsoft.VisualBasic.FileIO.SearchOption.SearchAllSubDirectories, "CROWN*.lst")
            lista.Items.Add(foundFile)
        Next
        If lista.Items.Count > 0 Then
            For i = 0 To lista.Items.Count - 1
                Dim freader As New StreamReader(lista.Items(i).ToString)
                Dim contenido As String
                Dim lineas As New ArrayList()
                Do
                    contenido = freader.ReadLine()
                    If Not contenido Is Nothing Then
                        'If contenido.Length <> 0 Then
                        lineas.Add(contenido)
                        'End If
                    Else
                        Exit Do
                    End If
                Loop Until contenido Is Nothing
                freader.Close()
                Dim filas As DataRow = dt.NewRow
                filas(0) = lineas.Item(4).ToString
                filas(1) = lineas.Item(5).ToString
                filas(2) = lineas.Item(6).ToString
                filas(3) = lineas.Item(7).ToString
                filas(4) = lineas.Item(8).ToString
                filas(5) = lineas.Item(9).ToString
                filas(6) = lineas.Item(10).ToString
                filas(7) = lineas.Item(11).ToString & ":" & lineas.Item(12).ToString & ":" & lineas.Item(13).ToString
                filas(8) = lineas.Item(15).ToString
                Dim fracmentos() As String
                fracmentos = Split(lista.Items(i).ToString, "\")
                filas(9) = fracmentos(fracmentos.Length - 1)
                dt.Rows.Add(filas)
            Next
            CtlGrilla1.SourceDataTable = dt
        Else
            CtlGrilla1.SourceDataTable = Nothing
        End If

    End Sub

    Private Sub cboPeriodo_Click() Handles cboPeriodo.Click
        If cboPeriodo.Text = "Diario" Then
            cboDesPeriodo.Visible = False
            txtesporadico.Visible = False
        ElseIf cboPeriodo.Text = "Semanal" Then
            cboDesPeriodo.Visible = True
            cboDesPeriodo.Limpia()
            cboDesPeriodo.Procedimiento = "QRYMG001"
            cboDesPeriodo.Condicion = ":condicion▓114"
            cboDesPeriodo.Cargar_dll()
            txtesporadico.Visible = False
        ElseIf cboPeriodo.Text = "Mensual" Then
            'cboDesPeriodo.Visible = True
            'cboDesPeriodo.Limpia()
            'cboDesPeriodo.Procedimiento = "QRYMG001"
            'cboDesPeriodo.Condicion = ":condicion▓113"
            'cboDesPeriodo.Cargar_dll()
            Dim dt As New DataTable
            dt.Columns.Add()
            dt.Columns.Add()
            For i = 0 To 30
                Dim row As DataRow = dt.NewRow
                row(0) = (i + 1).ToString("00")
                row(1) = (i + 1).ToString("00")
                dt.Rows.Add(row)
            Next
            cboDesPeriodo.Limpia()
            cboDesPeriodo.Carga_DT(dt)
            cboDesPeriodo.Visible = True
            txtesporadico.Visible = False
        ElseIf cboPeriodo.Text = "Esporadico" Then
            txtesporadico.Visible = True
            cboDesPeriodo.Visible = False
        End If
    End Sub

    Private Sub imgGrabar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgGrabar.Click
        If Len(Trim(cboPeriodo.Text)) = 0 Then
            CtlMensajes1.Mensaje("Seleccione un periodo", "")
        ElseIf Len(Trim(cboHora.Text)) = 0 Then
            CtlMensajes1.Mensaje("Seleccione una hora", "")
        ElseIf Len(Trim(cboMinuto.Text)) = 0 Then
            CtlMensajes1.Mensaje("Seleccione el minuto", "")
        ElseIf Len(Trim(txtEjecucion.Text)) = 0 Then
            CtlMensajes1.Mensaje("Especifique el programa que se va a ejecutar", "")
        ElseIf Len(Trim(txtDescripcion.Text)) = 0 Then
            CtlMensajes1.Mensaje("Especifique la descripcion de la tarea")
        Else
            Dim arrcad
            arrcad = Split(Trim(txtEjecucion.Text), " ")
            Dim arch As New StreamWriter(Server.MapPath(".") & "/Files/CROWN_" & Format(Now, "yyyyMMddhhss") & ".lst", True)
            arch.WriteLine(datos.usuario.ToString)
            arch.WriteLine(datos.pwd.ToString)
            arch.WriteLine(datos.bd.ToString)
            arch.WriteLine(datos.servidor.ToString)
            arch.WriteLine("Consulta")
            arch.WriteLine(arrcad(0))
            If arrcad.Length > 1 Then
                arch.WriteLine(arrcad(1))
            Else
                arch.WriteLine(" ")
            End If
            arch.WriteLine(Session("NombreGestor"))
            arch.WriteLine(cboPeriodo.Text)
            If cboPeriodo.Text = "Esporadico" Then
                arch.WriteLine(txtesporadico.Text)
            Else
                arch.WriteLine("")
            End If
            If cboPeriodo.Text = "Diario" Then
                arch.WriteLine("")
            Else
                arch.WriteLine(cboDesPeriodo.Text)
            End If
            arch.WriteLine(cboHora.Text)
            arch.WriteLine(cboMinuto.Text)
            arch.WriteLine(cboSegundo.Text)
            arch.WriteLine("DEFINIDO POR USUARIO")
            arch.WriteLine(txtDescripcion.Text)
            arch.Close()
            Cargar()
        End If
    End Sub

    Private Sub imgEjecutar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgEjecutar.Click
        Dim arrcad
        arrcad = Split(Trim(txtEjecucion.Text), " ")
        Dim arch As New StreamWriter(Server.MapPath(".") & "/Files/CROWN_" & Format(Now, "yyyyMMddhhss") & ".lst", True)
        arch.WriteLine(datos.usuario.ToString)
        arch.WriteLine(datos.pwd.ToString)
        arch.WriteLine(datos.bd.ToString)
        arch.WriteLine(datos.servidor.ToString)
        arch.WriteLine("Consulta")
        arch.WriteLine(arrcad(0))
        If arrcad.Length > 1 Then
            arch.WriteLine(arrcad(1))
        Else
            arch.WriteLine(" ")
        End If
        arch.WriteLine(Session("NombreGestor"))
        arch.WriteLine("Esporadico")
        arch.WriteLine("")
        arch.WriteLine("")
        arch.WriteLine("")
        arch.WriteLine("")
        arch.WriteLine("")
        arch.WriteLine("DEFINIDO POR USUARIO")
        arch.WriteLine(txtDescripcion.Text)
        arch.Close()
        CtlMensajes1.Mensaje("EL PROGRAMA ACABA DE SER EJECUTADO EN EL SERVIDOR", "")
    End Sub

    Private Sub CtlGrilla1_RowDeleting(ByVal GV As System.Web.UI.WebControls.GridView, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles CtlGrilla1.RowDeleting
        Dim row As GridViewRow = GV.Rows(e.RowIndex)
        Dim myFilePath As String = Server.MapPath("~/Files/")
        My.Computer.FileSystem.DeleteFile(myFilePath & row.Cells(13).Text)
        Cargar()
    End Sub
End Class