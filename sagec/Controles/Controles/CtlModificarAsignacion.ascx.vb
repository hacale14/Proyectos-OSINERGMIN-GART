
Partial Public Class CtlModificarAsignacion
    Inherits System.Web.UI.UserControl
    Dim blasignacion As New BL.Asignacion
    Public Property TituloPrincipal() As String
        Get
            Return lblTituloPrincipal.Text
        End Get
        Set(ByVal value As String)
            lblTituloPrincipal.Text = value
        End Set
    End Property
    Public Property DataTable() As DataTable
        Get
            If lblTituloPrincipal.Text = "BUSQUEDA POR DATOS DE CLIENTE" Then
                Return Session("DtBDC")
            ElseIf lblTituloPrincipal.Text = "BUSQUEDA DE DATOS DE OPERACION - CASTIGO" Then
                Return Session("DtBDOC")
            ElseIf lblTituloPrincipal.Text = "BUSQUEDA DE DATOS DE OPERACION - ACTIVA" Then
                Return Session("DtBDOA")
            End If
            Return Nothing
        End Get
        Set(ByVal value As DataTable)
            If lblTituloPrincipal.Text = "BUSQUEDA POR DATOS DE CLIENTE" Then
                Session("DtBDC") = value
            ElseIf lblTituloPrincipal.Text = "BUSQUEDA DE DATOS DE OPERACION - CASTIGO" Then
                Session("DtBDOC") = value
            ElseIf lblTituloPrincipal.Text = "BUSQUEDA DE DATOS DE OPERACION - ACTIVA" Then
                Session("DtBDOA") = value
            End If
        End Set
    End Property
    Private Sub btnCerrar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnCerrar.Click
        limpiador()
        Me.Visible = False
    End Sub
    Sub CargaAsignacion(ByVal IdCliente As String, ByVal IdUsuarioCliente As String, ByVal NombreCliente As String, ByVal Usuario As String, ByVal Cantidad As String)

        RDBCliente.Checked = True
        lblIdCliente.Text = IdCliente

        If Not Len(Trim(IdUsuarioCliente)) = 0 Then
            lblIdUsuarioCliente.Text = IdUsuarioCliente
        Else
            lblIdUsuarioCliente.Text = ""
        End If

        If Not Len(Trim(NombreCliente)) = 0 Then
            txtCliente.Text = NombreCliente : Else : txtCliente.Text = ""
        End If

        If Not Len(Trim(Usuario)) = 0 Then
            cboGestor.Text = Usuario : Else : cboGestor.Value = 0
        End If
        lblTotalCliente.Text = Cantidad
    End Sub
    Sub ChangeOption()
        If RDBRangeSearch.Checked = True Then
            txtDesde.Desactiva = True
            txtHasta.Desactiva = True
        Else
            txtDesde.Desactiva = False
            txtHasta.Desactiva = False
            txtDesde.Text = ""
            txtHasta.Text = ""
        End If
    End Sub
    Private Sub btnGrabar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnGrabar.Click
        If Len(Trim(cboGestor.Text)) = 0 Then
            CtlMensajes1.Mensaje("AVISO..: SELECCIONAR UN GESTOR!")
            cboGestor.Focus()
            Exit Sub
        End If
        blasignacion.Cliente_Actual = RDBCliente.Checked
        blasignacion.Todos_Clientes = RDBAllSearch.Checked
        blasignacion.Rango_Clientes = RDBRangeSearch.Checked
        blasignacion.DatosBuscados = DataTable
        blasignacion.Gestor_ID = cboGestor.Value
        blasignacion.Cliente_ID = lblIdCliente.Text
        blasignacion.UsuarioCliente_ID = lblIdUsuarioCliente.Text
        Dim Mensaje As String = blasignacion.Modificar_Asignacion()
        CtlMensajes1.Mensaje(Mensaje)
        limpiador()
        Me.Visible = False
    End Sub
    Sub limpiador()
        txtCliente.Text = ""
        txtDesde.Text = ""
        txtHasta.Text = ""
        lblIdCliente.Text = ""
        lblIdUsuarioCliente.Text = ""
        lblTotalCliente.Text = ""
        RDBCliente.Checked = True
    End Sub

    Private Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            RellenaCombo(cboGestor, "QRYCBG002", "")
        End If
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