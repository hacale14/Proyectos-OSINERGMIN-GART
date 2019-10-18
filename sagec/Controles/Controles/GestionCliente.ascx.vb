Imports BL
Partial Public Class GestionCliente
    Inherits System.Web.UI.UserControl
    Dim BLCliente As New BL.Cliente


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        
    End Sub

    Sub Cargar()
        Dim dt As New DataTable
        If Len(Trim(IdCliente)) <> 0 Then
            BLCliente.IdCliente = IdCliente
            dt = BLCliente.BuscarClienteGestion5
            If dt.Rows.Count <> 0 Then
                CtlGrilla1.OcultarColumnas = "8;9;10"
                CtlGrilla1.SourceDataTable = dt
                lblExistencia.Text = dt.Rows.Count & " operacion(es)"
            End If
        End If
    End Sub


    Private Sub imgCerrar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgCerrar.Click
        RaiseEvent CerrarGestionCliente()
    End Sub

    Event CerrarGestionCliente()


    Public Property Titulo() As String
        Get
            Return lblTituloControl.Text
        End Get
        Set(ByVal value As String)
            lblTituloControl.Text = value
        End Set
    End Property

    Public Property IdCliente() As String
        Get
            Return Session("IdCliente")
        End Get
        Set(ByVal value As String)
            Session("IdCliente") = value
        End Set
    End Property


End Class