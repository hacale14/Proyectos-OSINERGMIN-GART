Public Partial Class ReporteProductoOperacionCliente
    Inherits System.Web.UI.UserControl
    Dim BLOperacion As New BL.Producto

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Public Property criterio() As ListBox
        Get
            Return Session("criterio_reporte_producto")
        End Get
        Set(ByVal value As ListBox)
            Session("criterio_reporte_producto") = value
        End Set
    End Property

    Sub cargar()
        Dim dt As New DataTable
        Try
            dt = BLOperacion.ReporteProducto(criterio)
            CtlGrilla1.SourceDataTable = dt
        Catch ex As Exception
            CtlMensajes1.Mensaje("Ocurrio un error al cargar los archivos")
        End Try
    End Sub


    Public Property Titulo() As String
        Get
            Return lblTituloControl.Text
        End Get
        Set(ByVal value As String)
            lblTituloControl.Text = value
        End Set
    End Property

    Private Sub imgCerrar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgCerrar.Click
        RaiseEvent CerrarReporteProducto()
    End Sub

    Event CerrarReporteProducto()
End Class