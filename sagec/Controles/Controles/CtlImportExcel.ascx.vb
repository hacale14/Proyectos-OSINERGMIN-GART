Imports System.IO
Imports System.Web.UI.WebControls

Partial Public Class CtlImportExcel
    Inherits System.Web.UI.UserControl
    Dim BImportar As New BL.Importar
    Dim contador As Integer


    Public Property Destino() As DataTable
        Get
            Return Session("Campos")
        End Get
        Set(ByVal value As DataTable)
            Session("Campos") = value
        End Set
    End Property

    Public Property DtImportar() As DataTable
        Get
            Return Session("Excel")
        End Get
        Set(ByVal value As DataTable)
            Session("Excel") = value
        End Set
    End Property

    Private Sub listar_Campos()
        For Each rw As GridViewRow In gvDetalle.Rows
            Dim DDL As DropDownList = CType(rw.FindControl("DDLCampos"), DropDownList)
            DDL.Items.Add("No Importar")
            For i = 0 To Destino.Columns.Count - 1
                DDL.Items.Add(Destino.Columns(i).ToString)
            Next
        Next
    End Sub

    Private Sub btnCargar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCargar.Click
        'Page.Master.FindControl("ScriptManager1")
        'Dim ScriptManager As ScriptManager = Page.Master.FindControl("ScriptManager1")
        'Dim CtlMe As Control = Me
        'ScriptManager.RegisterPostBackControl(CtlMe)
        If Field.HasFile Then
            Try
                Dim Dt As New DataTable
                Dim DFt As New DataTable
                Dim FileName As String = Path.GetFileName(Field.PostedFile.FileName)
                BImportar.Extension = Path.GetExtension(Field.PostedFile.FileName)
                BImportar.FilePath = Server.MapPath("~\Files\") + FileName
                Field.SaveAs(BImportar.FilePath)
                BImportar.Consulta = "SELECT * From "
                DtImportar = BImportar.Import_To_Grid()
                DFt.Columns.Add("Campos del Excel")
                For i = 0 To DtImportar.Columns.Count - 1
                    DFt.Rows.Add(DtImportar.Columns(i).ToString)
                Next
                gvDetalle.DataSource = DFt
                gvDetalle.DataBind()
                gvDetalle.Columns(0).Visible = True
                btnSiguiente.Visible = True
                listar_Campos()
            Catch ex As Exception
                Dim errors As String = "ERROR: " & ex.Message.ToString()
            End Try
        End If
    End Sub

    Private Sub btnSiguiente_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSiguiente.Click
        CargarColumnas()
        btnSiguiente.Visible = False
    End Sub

    Private Sub CargarColumnas()
        Dim Dt As New DataTable
        Dim DtSet As New DataSet
        Dim Row As DataRow = Dt.NewRow
        DtSet.Tables.Add()
        Dim Col = 0
        Dim i = 0

        For Each rw As GridViewRow In gvDetalle.Rows
            Dim DDL As DropDownList = CType(rw.FindControl("DDLCampos"), DropDownList)
            If Not DDL.Items.Item(0).Selected Then
                Dt.Columns.Add(rw.Cells(1).Text)
                DtSet.Tables(0).Columns.Add(DDL.SelectedItem.Text)
            End If
        Next

        For i = 0 To Dt.Columns.Count - 1
            For c = Col To DtImportar.Columns.Count - 1
                If c = DtImportar.Columns.Count Then Exit For
                If Dt.Columns(i).ColumnName = DtImportar.Columns(c).ColumnName And i < Dt.Columns.Count - 1 Then
                    DtImportar.Columns(c).ColumnName = DtSet.Tables(0).Columns(i).ColumnName
                    Col += 1 : Exit For
                ElseIf Dt.Columns(i).ColumnName = DtImportar.Columns(c).ColumnName And i = Dt.Columns.Count - 1 Then
                    DtImportar.Columns(c).ColumnName = DtSet.Tables(0).Columns(i).ColumnName
                    Col += 1
                Else
                    DtImportar.Columns.Remove(DtImportar.Columns(c).ColumnName) : c -= 1
                End If
            Next
        Next

        gvDetalle.DataSource = DtImportar
        gvDetalle.DataBind()
        gvDetalle.Columns(0).Visible = False
        Destino = DtImportar
    End Sub

    Sub LimpiarGrilla()
        gvDetalle.DataSource = Nothing
        gvDetalle.DataBind()
    End Sub


    Private Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Page.Master.FindControl("ScriptManager1")
        'Dim ScriptManager As ScriptManager = Page.Master.FindControl("ScriptManager1")
        'Dim CtlMe As Control = Me
        'ScriptManager.RegisterPostBackControl(CtlMe)
        'If Not Me.IsPostBack Then
        '    btnCargar_Click(sender, e)
        'End If
    End Sub


End Class