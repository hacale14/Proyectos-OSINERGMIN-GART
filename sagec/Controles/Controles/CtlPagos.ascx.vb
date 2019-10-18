Public Partial Class CtlPagos
    Inherits System.Web.UI.UserControl
    Dim gmp_fcliente As Boolean
    Dim gmp_fgestor As Boolean

    Dim IdPago As String
    Dim IdCliente As String
    Dim FechaPago As String
    Dim Cliente As String
    Dim NroOperacion As String
    Dim Monto As String
    Dim Moneda As String
    Dim Concepto As String

    Dim blPagos As New BL.Pagos
    Dim dt As New DataTable

    Public Property Titulo() As String
        Get
            Return lblTituloControl.Text
        End Get
        Set(ByVal value As String)
            lblTituloControl.Text = value
        End Set
    End Property
    Public Property ComboCartera() As Boolean
        Get
            Return cboCartera.Ocultar
        End Get
        Set(ByVal value As Boolean)
            cboCartera.Ocultar = value
        End Set
    End Property
    Public Property FCliente() As Boolean
        Get
            Return gmp_fcliente
        End Get
        Set(ByVal value As Boolean)
            If Trim(value) = "" Then
                gmp_fcliente = False
            Else
                gmp_fcliente = value
            End If

        End Set
    End Property
    Public Property FGestor() As Boolean
        Get
            Return gmp_fgestor
        End Get
        Set(ByVal value As Boolean)
            If Trim(value) = "" Then
                gmp_fgestor = False
            Else
                gmp_fgestor = value
            End If
        End Set
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            If Not FCliente = True Or FGestor = True Then
                Carga_Inicial()
            End If
        End If
    End Sub
    Private Sub btnBuscar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnBuscar.Click
        dt = blPagos.CriteriosBusqueda(txtDNI.Text, txtCliente.Text, txtFechaInicio.Text, txtFechaFin.Text, cboCartera.Text, chkInicio.Checked, chkFin.Checked)
        gvPagos.SourceDataTable = dt
        lblSubTitulo.Text = "Existe(n) " & dt.Rows.Count & " Pago(s)"
        dt = Nothing
    End Sub
    Public Sub Carga_Inicial()
        Try
            If FCliente = True Then
                dt = blPagos.CriteriosBusqueda(txtDNI.Text, "", "", "", "", chkInicio.Checked, chkFin.Checked)
            ElseIf FGestor = True Then
                dt = blPagos.CriteriosBusqueda(txtDNI.Text, "", "", "", cboCartera.Text, chkInicio.Checked, chkFin.Checked)
            Else
                txtFechaInicio.Text = Format(DateTime.Now, "dd/MM/yyyy")
                txtFechaFin.Text = Format(DateTime.Now, "dd/MM/yyyy")
                chkInicio.Checked = True
                chkFin.Checked = True
                dt = blPagos.CriteriosBusqueda("", "", DateTime.Now, DateTime.Now, "", chkInicio.Checked, chkFin.Checked)
                gvPagos.SourceDataTable = dt
            End If
            lblSubTitulo.Text = "Existe(n) " & dt.Rows.Count & " Pago(s)"
            dt = Nothing
        Catch ex As Exception
            CtlMensajes1.Mensaje("Ocurrio un Error:" & ex.Message)
        End Try
    End Sub

    Private Sub btnNuevo_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnNuevo.Click
        If Len(Trim(txtDNI.Text)) >= 7 Then
            If Len(Trim(cboCartera.Text)) > 0 Then
                NMPagos1.Titulo = "NUEVO PAGO - CARTERA CASTIGO"
                NMPagos1.Nuevo(txtDNI.Text, cboCartera.Value)
                NMPagos1.Visible = True
            Else
                CtlMensajes1.Mensaje("AVISO..: Seleccione una cartera!")
            End If
        Else
            CtlMensajes1.Mensaje("AVISO..: Seleccione un cliente!")
        End If
    End Sub
    Private Sub btnMetas_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnMetas.Click
        Metas1.Titulo = "METAS DE COBRANZA Y AVANCE REALIZADO"
        Metas1.Visible = True
    End Sub
    Private Sub gvPagos_RowDeleting(ByVal GV As System.Web.UI.WebControls.GridView, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gvPagos.RowDeleting
        Dim row As GridViewRow = GV.Rows(e.RowIndex)
        Dim blcobranza As New BL.Cobranza
        blcobranza.FunctionGlobal(":pidpago▓" & row.Cells(14).Text, "QRYCP007")
        Carga_Inicial()
    End Sub

    Private Sub gvPagos_RowEditing(ByVal GV As System.Web.UI.WebControls.GridView, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs, ByVal row As System.Web.UI.WebControls.GridViewRow) Handles gvPagos.RowEditing
        IdPago = row.Cells(14).Text
        IdCliente = row.Cells(13).Text
        FechaPago = Format(CDate(row.Cells(6).Text), "dd/MM/yyyy")
        Cliente = row.Cells(5).Text
        NroOperacion = row.Cells(7).Text
        Monto = row.Cells(9).Text
        Moneda = row.Cells(8).Text
        Concepto = row.Cells(10).Text
        NMPagos1.Titulo = "MODIFICAR PAGO - CARTERA CASTIGO"
        NMPagos1.Cargar_Pago(IdPago, IdCliente, FechaPago, Cliente, NroOperacion, Monto, Moneda, Concepto)
        NMPagos1.Visible = True
    End Sub

    Private Sub gvPagos_Seleccionarfila(ByVal sender As Object, ByVal e As System.EventArgs, ByVal row As System.Web.UI.WebControls.GridViewRow) Handles gvPagos.Seleccionarfila
        txtDNI.Text = row.Cells(4).Text
    End Sub

    Public Sub Cargar_Fuera(ByVal dni As String, ByVal cartera As String)
        If dni <> "" And Fcliente = True Then
            txtDNI.Text = dni
        ElseIf dni <> "" And cartera <> "" And FGestor = True Then
            txtDNI.Text = dni
            cboCartera.Text = cartera
        End If
        Carga_Inicial()
    End Sub

    Private Sub btnCerrar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnCerrar.Click
        If FCliente = True Or FGestor = True Then
            RaiseEvent Cerrar()
        Else
            Me.Visible = False
        End If
    End Sub

    Event Cerrar()
End Class