Imports ConDB
Partial Public Class Principal
    Inherits System.Web.UI.Page
    Public StrCartera As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub cboEmpresa_Click() Handles cboempresa.Click
        cboGrupo.Cbo.Items.Clear()
        CtCombo1.Cbo.Items.Clear()
        cboGrupo.Condicion = ":idempresa▓" & cboempresa.Value
        cboGrupo.Cargar_dll()
    End Sub

    Private Sub cboGrupo_Click() Handles cboGrupo.Click
        CtCombo1.Cbo.Items.Clear()
        CtCombo1.Condicion = ":pid_grp_cartera▓" & cboGrupo.Value
        CtCombo1.Cargar_dll()
        'If CtlGrilla1.GV.Rows.Count < 1 Then
        'cboEmpresa_Click()
        'End If
    End Sub

    Private Sub cboCorporacion_Click() Handles cboCorporacion.Click
        cboempresa.Cbo.Items.Clear()
        cboempresa.Condicion = ":pidcorporacion▓" & cboCorporacion.Value
        cboempresa.Cargar_dll()
        CtCombo1.Cbo.Items.Clear()
        cboGrupo.Cbo.Items.Clear()
    End Sub

    Sub Carga_Corporacion()
        Dim con As New ConDB.ConSQL
        Dim dt As DataTable = con.FunctionGlobal(":pidcorporacion▓" & cboCorporacion.Value, "RPTES001")
        StrCartera = ""
        If Not dt Is Nothing Then
            If dt.Rows.Count > 1 Then
                For i = 0 To dt.Rows.Count - 1
                    StrCartera &= dt.Rows(i)(0)
                Next
            End If
        End If
    End Sub

    Function Pintado() As String
        
    End Function
End Class