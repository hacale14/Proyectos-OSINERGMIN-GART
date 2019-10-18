Imports Controles

Partial Public Class Usuario
    Inherits System.Web.UI.Page
    Dim bl As New BL.Cobranza
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            RellenaCombo(cboTipoUsuario, "QRYC008", ":cod▓110")            
        End If
    End Sub

    Private Sub gvUsuario_Nuevo() Handles gvUsuario.Nuevo
        'NMUsuario1.Titulo = "NUEVO USUARIO"
        'NMUsuario1.limpiador()
        'NMUsuario1.Visible = True
        Response.Redirect("NUsuario.aspx")
    End Sub



    Private Sub gvUsuario_RowDeleting(ByVal GV As System.Web.UI.WebControls.GridView, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gvUsuario.RowDeleting
        Dim row As GridViewRow = GV.Rows(e.RowIndex)
        bl.FunctionGlobal(":pidusuario▓" & row.Cells(4).Text, "QRYUS004")
        CtlMensajes1.Mensaje("AVISO..: SE ELIMINO CORRECTAMENTE!")
        gvUsuario.SourceDataTable = Nothing
    End Sub

    Private Sub gvUsuario_RowEditing(ByVal GV As System.Web.UI.WebControls.GridView, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs, ByVal row As System.Web.UI.WebControls.GridViewRow) Handles gvUsuario.RowEditing
        Dim id = row.Cells(4).Text
        Response.Redirect(String.Format("NUsuario.aspx?idUsuario={0}", id))

        'NMUsuario1.Titulo = "MODIFICAR USUARIO"
        'NMUsuario1.IdUsuario = row.Cells(4).Text
        'Dim tipo_usuario As String = IIf(row.Cells(5).Text = "&nbsp;", "", row.Cells(5).Text)
        'Dim nombre As String = IIf(row.Cells(6).Text = "&nbsp;", "", row.Cells(6).Text)
        'Dim apellido As String = IIf(row.Cells(7).Text = "&nbsp;", "", row.Cells(7).Text)
        'Dim usuario As String = IIf(row.Cells(8).Text = "&nbsp;", "", row.Cells(8).Text)
        'Dim clave As String = IIf(row.Cells(9).Text = "&nbsp;", "", row.Cells(9).Text)
        'Dim ruta As String = IIf(row.Cells(10).Text = "&nbsp;", "", row.Cells(10).Text)
        'Dim direccion As String = IIf(row.Cells(11).Text = "&nbsp;", "", row.Cells(11).Text)
        'Dim telefono As String = IIf(row.Cells(12).Text = "&nbsp;", "", row.Cells(12).Text)
        'Dim celular As String = IIf(row.Cells(13).Text = "&nbsp;", "", row.Cells(13).Text)
        'Dim fecha_ingreso As String = IIf(row.Cells(14).Text = "&nbsp;", "", row.Cells(14).Text)
        'Dim cargo As String = IIf(row.Cells(15).Text = "&nbsp;", "", row.Cells(15).Text)
        'NMUsuario1.LoadUsuario(tipo_usuario, nombre, apellido, direccion, telefono, celular, fecha_ingreso, cargo, clave, ruta, usuario)
        'NMUsuario1.Visible = True
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnBuscar.Click
        Dim CriterioTipo = ""
        Dim Criterio = ""
        Dim CriterioTodos = ""
        Dim CriterioUsuario = ""
        Dim CriterioNombres = ""
        Dim CriterioApellidos = ""
        Dim dt As New DataTable

        If Len(Trim(cboTipoUsuario.Text)) = 0 And Len(Trim(txtApellidos.Text)) = 0 And Len(Trim(txtNombres.Text)) = 0 And Len(Trim(txtUsuario.Text)) = 0 Then
            CtlMensajes1.Mensaje("AVISO..: DEBE DE INGRESAR AL MENOS UN CAMPO DE BUSQUEDA!")
            Exit Sub
        End If

        If Len(Trim(cboTipoUsuario.Text)) > 0 Then
            CriterioTipo = " AND USUARIO.TIPOUSUARIO LIKE '" + cboTipoUsuario.Text + "%'"
        Else
            CriterioTipo = ""
        End If
        If Len(Trim(txtApellidos.Text)) > 0 Then
            CriterioApellidos = " AND USUARIO.APELLIDOS LIKE '" + txtApellidos.Text + "%'"
        Else
            CriterioApellidos = ""
        End If
        If Len(Trim(txtNombres.Text)) > 0 Then
            CriterioNombres = " AND USUARIO.NOMBRES LIKE '" + txtNombres.Text + "%'"
        Else
            CriterioNombres = ""
        End If
        If Len(Trim(txtUsuario.Text)) > 0 Then
            CriterioUsuario = " AND USUARIO.USUARIO LIKE '" + txtUsuario.Text + "%'"
        Else
            CriterioUsuario = ""
        End If
        CriterioTodos = " USUARIO.IDUSUARIO >0"
        Criterio = CriterioTodos + CriterioTipo + CriterioUsuario + CriterioNombres + CriterioApellidos

        Using dt
            dt = bl.FunctionGlobal(":criterio▓" & Criterio, "QRYUS003")
            gvUsuario.SourceDataTable = dt
        End Using

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
End Class