Imports BL
Imports Controles
Partial Public Class BusquedaAgenda
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
            Dim TipoUsuario As String = Obtiene_Cookies("TipoUsuario")
            If TipoUsuario = "GESTOR" Then
                gvPrincipal.Activa_Export = False
                gvPrincipal.Desactivar_Exportar = False
            End If
        End If
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnBuscar.Click
        Dim ctl As New Controles.General
        Dim TipoUsuario As String = Obtiene_Cookies("TipoUsuario")
        Dim dt As DataTable
        If TipoUsuario <> "GESTOR" Then
            If Val(cboGestor.Value) <> 0 Then
                dt = ctl.BuscarSQL(":idusuarioƒ:idcarteraƒ:estado▓" & cboGestor.Value & "ƒ" & cboCartera.Value & "ƒ" & cboEstado.Value, "AGE001")
            Else
                dt = ctl.BuscarSQL(":idusuarioƒ:idcarteraƒ:estado▓909090ƒ" & cboCartera.Value & "ƒ" & cboEstado.Value, "AGE001")
            End If
        Else
            dt = ctl.BuscarSQL(":idusuarioƒ:idcarteraƒ:estado▓" & cboGestor.Value & "ƒ" & cboCartera.Value & "ƒ" & cboEstado.Value, "AGE001")
        End If
        gvPrincipal.SourceDataTable = dt
        ctl = Nothing
    End Sub
    Sub CargaCombos()
        RellenaCombo(cboCartera, "QRYCG002", ":criterio▓ALL", True)
        RellenaCombo(cboEstado, "AGE002", "", True)
    End Sub
    Private Sub cboCartera_Click() Handles cboCartera.Click        
        Dim idUsuario As String = Obtiene_Cookies("idusuario")
        Dim TipoUsuario As String = Obtiene_Cookies("TipoUsuario")        
        If TipoUsuario <> "GESTOR" Then
            RellenaCombo(cboGestor, "AGE003", ":pidcarteraƒ:pidusuario▓" & cboCartera.Value & "ƒ" & 0)
        Else
            RellenaCombo(cboGestor, "AGE003", ":pidcarteraƒ:pidusuario▓" & cboCartera.Value & "ƒ" & idUsuario)
        End If
    End Sub
    Private Sub RellenaCombo(ByVal Combo As CtCombo, ByVal Procedimiento As String, ByVal Condicion As String, Optional ByVal AP As Boolean = False)
        With Combo
            .Limpia()
            .Procedimiento = Procedimiento
            .Condicion = Condicion
            .AutoPostBack = AP
            .Cargar_dll()
            .Activa = True
        End With
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