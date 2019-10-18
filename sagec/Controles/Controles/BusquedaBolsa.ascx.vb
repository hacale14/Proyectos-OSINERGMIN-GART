Imports BL
Imports Controles
Partial Public Class BusquedaBolsa
    Inherits System.Web.UI.UserControl
    Dim Out_Cartera As Boolean
    Dim Out_Gestor As Boolean

    Dim Busqueda As New BL.Busquedas

    Public Property Cartera() As Boolean
        Get
            Return Out_Cartera
        End Get
        Set(ByVal value As Boolean)
            Out_Cartera = value
            lblCartera.Visible = Out_Cartera
            cboCartera.Ocultar = Out_Cartera
        End Set
    End Property
    Public Property Gestor() As Boolean
        Get
            Return Out_Gestor
        End Get
        Set(ByVal value As Boolean)
            Out_Gestor = value
            lblGestor.Visible = Out_Gestor
            cboGestor.Ocultar = Out_Gestor
        End Set
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            CargaCombos()


        End If
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnBuscar.Click
        Dim ctl As New Controles.General
        Dim dt As DataTable = ctl.BuscarSQL(":idusuarioƒ:idcarteraƒ:estado▓" & cboGestor.Value & "ƒ" & cboCartera.Value & "ƒ" & cboEstado.Value, "BOL003")
        gvPrincipal.SourceDataTable = dt
        ctl = Nothing
    End Sub
    Sub CargaCombos()
        RellenaCombo(cboCartera, "QRYCG002", ":criterio▓ALL", True)
        RellenaCombo(cboEstado, "BOL005", "", True)        
    End Sub
    Private Sub cboCartera_Click() Handles cboCartera.Click        
        RellenaCombo(cboGestor, "BOL004", ":idcartera▓" & CStr(cboCartera.Value))
    End Sub
    Private Sub RellenaCombo(ByVal Combo As CtCombo, ByVal Procedimiento As String, ByVal Condicion As String, Optional ByVal AP As Boolean = False)
        With Combo
            .Limpia()
            .Procedimiento = Procedimiento
            .Condicion = Condicion            
            .Cargar_dll()
            .Activa = True
        End With
    End Sub

    Protected Sub chkActivaBolsa_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles chkActivaBolsa.CheckedChanged
        Dim ctl As New Controles.General
        ctl.BuscarSQL(":idusuarioƒ:bolsa▓" & cboGestor.Value & "ƒ" & IIf(chkActivaBolsa.Checked, 1, 0), "BOL006")
        ctl = Nothing
    End Sub

    Private Sub gvPrincipal_RowDeleting(ByVal GV As System.Web.UI.WebControls.GridView, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gvPrincipal.RowDeleting
        Dim ctl As New Controles.General
        ctl.BuscarSQL(":idbolsa▓" & GV.Rows(e.RowIndex).Cells(4).Text, "BOL007")
        Dim sender As Object
        Dim e1 As System.Web.UI.ImageClickEventArgs
        btnBuscar_Click(sender, e1)
        ctl = Nothing        
    End Sub

    Private Sub cboGestor_Click() Handles cboGestor.Click
        Dim ctl As New Controles.General
        Dim dt As DataTable = ctl.BuscarSQL(":idusuario▓" & cboGestor.Value, "BOL008")
        If Not dt Is Nothing Then
            If dt.Rows.Count > 0 Then
                If IsDBNull(dt.Rows(0)(0)) Then
                    chkActivaBolsa.Checked = False
                ElseIf dt.Rows(0)(0) = "1" Then
                    chkActivaBolsa.Checked = True
                Else
                    chkActivaBolsa.Checked = False
                End If
            End If
        End If
        dt = Nothing
        ctl = Nothing
    End Sub

    Private Sub BtnEliminar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BtnEliminar.Click        
        Dim ctl As New Controles.General
        ctl.BuscarSQL(":idusuarioƒ:idcartera▓" & cboGestor.Value & "ƒ" & cboCartera.Value, "BOL010")
        Dim dt As DataTable = ctl.BuscarSQL(":idusuarioƒ:idcarteraƒ:estado▓" & cboGestor.Value & "ƒ" & cboCartera.Value & "ƒ" & cboEstado.Value, "BOL003")
        gvPrincipal.SourceDataTable = dt
        ctl = Nothing        
    End Sub
End Class