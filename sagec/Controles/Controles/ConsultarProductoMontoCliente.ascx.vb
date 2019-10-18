Imports BL

Partial Public Class ConsultarProductoMontoCliente
    Inherits System.Web.UI.UserControl
    Dim BLProducto As New BL.Producto

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            cboCartera.Cargar_dll()
            cboMoneda.Cargar_dll()
            cboMoneda2.Cargar_dll()
            cboOpcion.Cargar_dll()
            cboOpcion2.Cargar_dll()
            cboCondicion.Cargar_dll()
        End If
    End Sub
    Public Property Titulo() As String
        Get
            Return lblTituloControl.Text
        End Get
        Set(ByVal value As String)
            lblTituloControl.Text = value
        End Set
    End Property

    Private Sub cboCartera_Click() Handles cboCartera.Click
        With cboGestor
            .Limpia()
            .Procedimiento = "QRYCOM003"
            .Condicion = ":criterioidcartera▓HAVING Cartera.IdCartera = " & cboCartera.Value
            .Cargar_dll()
        End With
    End Sub

    'Consulta Producto
    Private Sub imgCerrar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgCerrar.Click
        RaiseEvent CerrarConsultaProducto()
    End Sub

    Event CerrarConsultaProducto()

    'Reporte


    Private Sub imgBuscar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgBuscar.Click
        Dim dt As New DataTable
        Dim CriteriosTodos = "OPERACION.IDOPERACION>0"
        Dim criterioCartera = ""
        Dim criterioGestor = ""
        Dim criterioProducto = ""
        Dim criterioMonto = ""
        Dim criterioDeuda = ""
        Dim criterioCondicion = ""
        Dim criterioEstado = " AND Cliente.Estado IN('A','N') AND (Operacion.Estado <> 'E')"
        Dim criterioNegocio = ""

        If Len(Trim(txtCapital.Text)) > 0 And Len(Trim(cboOpcion.Text)) > 0 And Len(Trim(cboMoneda.Text)) > 0 Then
            criterioMonto = " AND CAPITAL" & cboOpcion.Text & txtCapital.Text & " AND MONEDA='" & cboMoneda.Text & "'"
        Else
            criterioMonto = ""
        End If

        If Len(Trim(txtDTotal.Text)) > 0 And Len(Trim(cboOpcion2.Text)) > 0 And Len(Trim(cboMoneda2.Text)) > 0 Then
            criterioDeuda = " AND DEUDATOTAL" & cboOpcion2.Text & txtDTotal.Text & " AND MONEDA='" & cboMoneda2.Text & "'"
        Else
            criterioDeuda = ""
        End If

        If Len(Trim(cboCartera.Text)) > 0 Then
            criterioCartera = " AND NOMCARTERA LIKE '" & cboCartera.Text & "%'"
        Else
            criterioCartera = ""
        End If

        If Len(Trim(cboGestor.Text)) > 0 Then
            criterioGestor = " AND GESTOR LIKE '" & cboGestor.Text & "%'"
        Else
            criterioGestor = ""
        End If

        If Len(Trim(cboCondicion.Text)) > 0 Then
            criterioCondicion = " AND CODIGO IN ('" & cboCondicion.Text & "')"
        Else
            criterioCondicion = ""
        End If

        If Len(Trim(txtNegocio.Text)) > 0 Then
            criterioNegocio = " AND NEGOCIO LIKE '" & txtNegocio.Text & "%'"
        Else
            criterioNegocio = ""
        End If

        If Len(Trim(txtProducto.Text)) > 0 Then
            criterioProducto = " AND PRODUCTO  LIKE '" & txtProducto.Text & "%'"
        Else
            criterioProducto = ""
        End If

        'If Len(Trim(cboCartera.Text)) = 0 Or Len(Trim(cboCondicion.Text)) = 0 Or Len(Trim(cboGestor.Text)) = 0 Or ((Len(Trim(txtCapital.Text)) > 0 And Len(Trim(cboOpcion.Text)) > 0 And Len(Trim(cboMoneda.Text)) > 0) Or (Len(Trim(txtDTotal.Text)) > 0 And Len(Trim(cboOpcion2.Text)) > 0 And Len(Trim(cboMoneda2.Text)) > 0)) Then
        '    BLProducto.ConsultaProductoBatch(CriteriosTodos & criterioCartera & criterioCondicion & criterioDeuda & criterioEstado & criterioGestor & criterioMonto & criterioNegocio & criterioProducto, Session("NombreGestor"))
        '    CtlMensajes1.Mensaje("EL REPORTE FUE AÑADIDO A LA COLA, ESTARA DISPONIBLE EN BREVE, SE VISUALIZARA EN LA VENTANA DE REPORTES GENERADOS", "")
        'Else
        Try
            dt = BLProducto.ConsultaProducto(CriteriosTodos & criterioCartera & criterioCondicion & criterioDeuda & criterioEstado & criterioGestor & criterioMonto & criterioNegocio & criterioProducto)
            CtlGrilla1.SourceDataTable = dt
        Catch ex As Exception
            BLProducto.ConsultaProductoBatch(CriteriosTodos & criterioCartera & criterioCondicion & criterioDeuda & criterioEstado & criterioGestor & criterioMonto & criterioNegocio & criterioProducto, Session("NombreGestor"))
            CtlMensajes1.Mensaje("EL REPORTE FUE AÑADIDO A LA COLA, ESTARA DISPONIBLE EN BREVE, SE VISUALIZARA EN LA VENTANA DE REPORTES GENERADOS", "")
        End Try
        
        'End If
    End Sub

    Private Sub imgReporte_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgReporte.Click
        Dim lista As New ListBox
        For i = 0 To CtlGrilla1.GV.Rows.Count - 1
            Dim v As Boolean = False
            For j = 0 To lista.Items.Count - 1
                If j <> 0 Then
                    If CtlGrilla1.GV.Rows(i).Cells(29).Text = lista.Items(j).Text Then
                        v = True
                    End If
                End If
            Next
            If v = False Then
                lista.Items.Add(CtlGrilla1.GV.Rows(i).Cells(29).Text)
            End If
        Next
        pnlReporte.Visible = True
        ReporteProductoOperacionCliente1.criterio = lista
        ReporteProductoOperacionCliente1.cargar()
    End Sub

    Private Sub ReporteProductoOperacionCliente1_CerrarReporteProducto() Handles ReporteProductoOperacionCliente1.CerrarReporteProducto
        pnlReporte.Visible = False
    End Sub
End Class