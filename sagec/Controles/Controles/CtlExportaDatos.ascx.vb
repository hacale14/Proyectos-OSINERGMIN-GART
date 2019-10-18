Imports System.IO
Imports BL

Partial Public Class CtlExportaDatos
    Inherits System.Web.UI.UserControl
    Dim blcarga As New BL.Cobranza
    Dim blimportar As New BL.Importar
    Public mensaje As String

    Private Sub btnImportar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnImportar.Click
        Session("dt") = buscar_dt()
        Dim strScript = "window.open('Exporta.aspx?Tipo=XLSX','vb');"
        ScriptManager.RegisterStartupScript(Me, Me.GetType, "SCR" & Me.ClientID, strScript, True)        
    End Sub
    Function buscar_dt() As DataTable
        If Len(Trim(cboTipoCartera.Text)) <= 0 Then
            CtlMensajes1.Mensaje("AVISO..: DEBE DE SELECCIONAR UN TIPO DE CARTERA!")
            Exit Function
        End If


        Dim dt As New DataTable
        Dim con As New ConDB.ConSQL
        Try
            Using dt
                con.Graba_Log("Iniciando Importacion de Archivo")
                If dt.Rows.Count > 0 Then
                    CtlMensajes1.Mensaje("¡Advertencia en este momento no puede haber cargas hay otro job que esta en proceso...!")
                    Exit Function
                End If
                Return blcarga.FunctionGlobal(":ptipocarteraƒ:pidcarteraƒ:pfechainicioƒ:pfechafin▓" & cboTipoCartera.Text & "ƒ" & cboCartera.Value & "ƒ" & txtFechaInicio.Text & "ƒ" & txtFechaFin.Text, "QRYEXP001")
            End Using
        Catch ex As Exception
            mensaje = ex.Message
            con.Graba_Log("//ERROR: " & mensaje)
            dt = Nothing
        End Try
    End Function
    'final
    Private Sub cboTipoCartera_Click() Handles cboTipoCartera.Click
        CtlGrilla1.SourceDataTable = Nothing
        With cboCartera
            .Limpia()
            .Activa = True
            .Procedimiento = "QRYCG002"
            .Condicion = ":criterio▓ALL"
            .Cargar_dll()
        End With
    End Sub

    
    Private Sub btnBuscar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnBuscar.Click
        CtlGrilla1.SourceDataTable = buscar_dt()
    End Sub
    
    Private Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            Timer1.Enabled = False
            Dim Perfil As String = Obtiene_Cookies("TipoUsuario")
            If Perfil = "SUPERVISOR" Then
                cboTipoCartera.Condicion = ":cod▓127"
                cboTipoCartera.Cargar_dll()
            End If
        End If
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