'************************************************************************************************************************
'***** Autor: EMPRESA PIMAY 
'***** DESCRIPCION: MULTIPLES CONEXIONES 
'************************************************************************************************************************
Imports BL

Partial Public Class ActualizarConsultaProductos
    Inherits System.Web.UI.UserControl
    Dim BLProducto As New BL.Producto

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Titulo = Request.QueryString("titulo")
    End Sub

    Public Property Titulo() As String
        Get
            Return lblTituloControl.Text
        End Get
        Set(ByVal value As String)
            lblTituloControl.Text = value
        End Set
    End Property

    Private Sub imgConsultarProductos_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgConsultarProductos.Click
        pnlConsultarProducto.Visible = True
    End Sub

    Private Sub ConsultarProductoMontoCliente1_CerrarConsultaProducto() Handles ConsultarProductoMontoCliente1.CerrarConsultaProducto
        pnlConsultarProducto.Visible = False
    End Sub


    Private Sub imgActualizarGestores_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgActualizarGestores.Click
        If BLProducto.ActualizarClienteGestor() Then
            CtlMensajes1.Mensaje("LOS GESTORES SE ACTUALIZARON CORRECTAMENTE", "SISTEMA DE COBRANZA")
        Else
            CtlMensajes1.Mensaje("SE PRODUJO UN ERROR", "SISTEMA DE COBRANZA")
        End If

    End Sub


    Private Sub ReporteProductoOperacionCliente1_CerrarReporteProducto() Handles ReporteProductoOperacionCliente1.CerrarReporteProducto
        pnlReporte.Visible = False
    End Sub
End Class