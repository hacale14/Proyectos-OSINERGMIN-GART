Imports BL
Partial Public Class Condicion
    Inherits System.Web.UI.UserControl
    Dim BLCondicion As New BL.Condicion

    Sub CargarDatos()
        If lblTituloControl.Text = "NUEVA CONDICION" Then
            txtCodigo.Text = ""
            txtDescripcion.Text = ""
        ElseIf lblTituloControl.Text = "MODIFICAR CONDICION" Then
            txtCodigo.Text = Codigo
            txtDescripcion.Text = Descripcion
        End If
        RaiseEvent RecargarDatos()
    End Sub

    Private Sub imgCerrar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgCerrar.Click
        RaiseEvent CerrarNuevaCondicion()
    End Sub

    Event CerrarNuevaCondicion()
    Event RecargarDatos()

    Public Property Titulo() As String
        Get
            Return lblTituloControl.Text
        End Get
        Set(ByVal value As String)
            lblTituloControl.Text = value
        End Set
    End Property

    Public Property Codigo() As String
        Get
            Return Session("Codigo")
        End Get
        Set(ByVal value As String)
            Session("Codigo") = value
        End Set
    End Property

    Public Property Descripcion() As String
        Get
            Return Session("Descripcion")
        End Get
        Set(ByVal value As String)
            Session("Descripcion") = value
        End Set
    End Property

    Public Property IdCondicion() As String
        Get
            Return lblIdCondicion.Text
        End Get
        Set(ByVal value As String)
            lblIdCondicion.Text = value
        End Set
    End Property

    Private Sub imgGrabar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgGrabar.Click
        If Len(Trim(txtCodigo.Text)) = 0 Then
            CtlMensajes1.Mensaje("Escriba el codigo de la condicion", "SISTEMA DE GESTIÓN DE COBRANZAS")
        ElseIf Len(Trim(txtDescripcion.Text)) = 0 Then
            CtlMensajes1.Mensaje("Escriba la descripcion de la condicion", "SISTEMA DE GESTIÓN DE COBRANZAS")
        ElseIf Len(Trim(txtCodigo.Text)) > 2 Then
            CtlMensajes1.Mensaje("El codigo no debe de exceder los 2 digitos", "SISTEMA DE GESTIÓN DE COBRANZAS")
        Else
            Dim estado As Boolean = False
            If lblTituloControl.Text = "NUEVA CONDICION" Then
                BLCondicion.Codigo = txtCodigo.Text.ToUpper
                BLCondicion.Descripcion = txtDescripcion.Text.ToUpper
                estado = BLCondicion.NuevaCondicion()
                If estado = True Then
                    CtlMensajes1.Mensaje("Se ha creado la nueva condicion satisfactoriamente", "SISTEMA DE GESTIÓN DE COBRANZAS")
                End If
            ElseIf lblTituloControl.Text = "MODIFICAR CONDICION" Then
                BLCondicion.IdCondicion = lblIdCondicion.Text
                BLCondicion.Codigo = txtCodigo.Text.ToUpper
                BLCondicion.Descripcion = txtDescripcion.Text.ToUpper
                estado = BLCondicion.ModificarCondicion
                If estado = True Then
                    CtlMensajes1.Mensaje("Se ha modificado la condicion satisfactoriamente", "SISTEMA DE GESTIÓN DE COBRANZAS")
                End If
            End If
            If estado = False Then
                CtlMensajes1.Mensaje("Se ha producido un error", "SISTEMA DE GESTIÓN DE COBRANZAS")
            End If
        End If
        Call imgCerrar_Click(sender, e)
        RaiseEvent Actualizar()
    End Sub

    Event Actualizar()
End Class