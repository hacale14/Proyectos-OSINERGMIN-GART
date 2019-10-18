
Partial Public Class DefinirCondicion
    Inherits System.Web.UI.UserControl
    Dim blcondicion As New BL.Cobranza
    Dim Botones1 As New Botones
    Public Property Titulo() As String
        Get
            Return lblTituloControl.Text
        End Get
        Set(ByVal value As String)
            lblTituloControl.Text = value
        End Set
    End Property
    

    Private Sub btnCambiar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnCambiar.Click
        If Len(Trim(cboCondicion.Text)) = 0 Then
            CtlMensajes1.Mensaje("AVISO..: SELECCIONE UNA CONDICION!")
            cboCondicion.Focus()
            Exit Sub
        End If

        If Botones1.DtBusquedaGestor.Rows.Count > 0 Then
            Dim IdCliente = ""
            For Each fila In Botones1.DtBusquedaGestor.Rows
                IdCliente = fila("IdCliente")
                blcondicion.FunctionGlobal(":pcondicionƒ:pidcliente▓" & cboCondicion.Text & "ƒ" & IdCliente, "QRYCD0001")
            Next
            CtlMensajes1.Mensaje("AVISO..: EL CAMBIO SE REALIZO CORRECTAMENTE!")
        Else
            CtlMensajes1.Mensaje("AVISO..: NO HAY DATOS EN LA GRILLA DE BUSQUEDA!")
        End If

        Me.Visible = False
    End Sub

    Private Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            cargar_combo(cboCondicion, "QRYCGC001", "")
        End If
    End Sub
    Private Sub cargar_combo(ByVal Combo As CtCombo, ByVal procedimiento As String, ByVal condicion As String, Optional ByVal Ap As Boolean = False)
        With Combo
            .Limpia()
            .Procedimiento = procedimiento
            .Condicion = condicion
            .Activa = True
            .Cargar_dll()
        End With
    End Sub

    Private Sub btnCerrar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnCerrar.Click
        Me.Visible = False
    End Sub
End Class