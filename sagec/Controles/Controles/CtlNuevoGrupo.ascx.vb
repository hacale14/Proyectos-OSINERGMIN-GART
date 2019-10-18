Imports BL.Grupo
Partial Public Class CtlNuevoGrupo
    Inherits System.Web.UI.UserControl

    Public Property Titulo() As String
        Get
            Return lblTituloControl.Text
        End Get
        Set(ByVal value As String)
            lblTituloControl.Text = value
        End Set
    End Property

    Event Cerrar()

    Private Sub imgCerrar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgCerrar.Click
        RaiseEvent Cerrar()
    End Sub

    Public Property idEmpresa() As String
        Get
            Return cboEmpresa.Value
        End Get
        Set(ByVal value As String)
            cboEmpresa.Value = value
        End Set
    End Property
    Public Property Empresa() As String
        Get
            Return cboEmpresa.Text
        End Get
        Set(ByVal value As String)
            cboEmpresa.Text = value
        End Set
    End Property
    Public Property idGrupo() As String
        Get
            Return lblIdGrupo.Text
        End Get
        Set(ByVal value As String)
            lblIdGrupo.Text = value
        End Set
    End Property
    Public Property Grupo() As String
        Get
            Return txtGrupo.Text
        End Get
        Set(ByVal value As String)
            txtGrupo.Text = value
        End Set
    End Property

    Public Property Tipo() As String
        Get
            Return lblTipo.Text
        End Get
        Set(ByVal value As String)
            lblTipo.Text = value
        End Set
    End Property

    Private Sub imgGrabar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgGrabar.Click
        If Len(Trim(txtGrupo.Text)) <> 0 Then
            Dim grupoBL As New BL.Grupo
            If Tipo = "Nuevo" Then
                grupoBL.Descripcion = txtGrupo.Text
                grupoBL.idEmpresa = cboEmpresa.Value
                grupoBL.InsertarGrupo()
            ElseIf Tipo = "Modificar" Then
                grupoBL.ModificarGrupo(idGrupo, txtGrupo.Text, idEmpresa)
            End If
            CtlMensajes1.Mensaje("Se agrego la nueva empresa satisfactoriamente")
            RaiseEvent Fin_Grabar()
        End If
        CtlMensajes1.Mensaje("Escriba el nombre de la Empresa")
        Call imgCerrar_Click(sender, e)
    End Sub
    Function Obtiene_Cookies(ByVal id) As String
        '// Recogemos la cookie que nos interese
        Dim cogeCookie As HttpCookie = Request.Cookies.Get(id)
        Return cogeCookie.Value
    End Function
    Event Fin_Grabar()

    Private Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then            
            cboEmpresa.Procedimiento = "SQLE002C"
            cboEmpresa.Condicion = ":criterio▓" & " where empresa.idcorporacion = " & Obtiene_Cookies("idcorporacion")
            cboEmpresa.Cargar_dll()
            cboEmpresa.Value = idEmpresa
        End If
    End Sub
End Class