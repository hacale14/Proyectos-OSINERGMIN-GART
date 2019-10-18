Public Partial Class NuevaEmpresa
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load        
    End Sub

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
            Return lblIdEmpresa.Text
        End Get
        Set(ByVal value As String)
            lblIdEmpresa.Text = value
        End Set
    End Property

    Public Property Empresa() As String
        Get
            Return txtEmpresa.Text
        End Get
        Set(ByVal value As String)
            txtEmpresa.Text = value
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
        If Len(Trim(txtEmpresa.Text)) <> 0 Then
            Dim EmpresaBL As New BL.Empresa
            If Tipo = "Nuevo" Then
                EmpresaBL.Descripcion = txtEmpresa.Text
                EmpresaBL.idCorporacion = Obtiene_Cookies("idcorporacion")
                EmpresaBL.InsertarEmpresa()
            ElseIf Tipo = "Modificar" Then
                EmpresaBL.ModificarEmpresa(idEmpresa, txtEmpresa.Text, Obtiene_Cookies("idcorporacion"))
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
End Class