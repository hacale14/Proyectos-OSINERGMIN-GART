Imports BL
Partial Public Class NuevoCLienteGestionarCliente
    Inherits System.Web.UI.UserControl
    Dim BLCliente As New BL.Cliente

    Private Sub ImageButton5_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButton5.Click
        RaiseEvent CerrarNuevoClienteGestion()
    End Sub
    Event CerrarNuevoClienteGestion()

    'Control Gestion Cliente
    Private Sub ImageButton3_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButton3.Click
        GestionCliente1.IdCliente = IdCliente
        pnlGestionCliente.Visible = True
        GestionCliente1.Cargar()
    End Sub

    Private Sub GestionCliente1_CerrarGestionCliente() Handles GestionCliente1.CerrarGestionCliente
        pnlGestionCliente.Visible = False
    End Sub

    'Control de Pagos
    Private Sub imgPagos_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgPagos.Click
        pnlPagos.Visible = True
    End Sub

  

    Public Property Titulo() As String
        Get
            Return lblTituloControl.Text
        End Get
        Set(ByVal value As String)
            lblTituloControl.Text = value
        End Set
    End Property

    Public Property ActivaGrupo1() As Boolean
        Get
            Return txtDireccion1.Visible
        End Get
        Set(ByVal value As Boolean)
            txtDireccion1.Enabled = value
            txtTelefono1.Enabled = value
            txtDepartamento.Enabled = value
            txtProvincia.Enabled = value
            txtDistrito.Enabled = value
        End Set
    End Property

    Public Property ActivaGrupo2() As Boolean
        Get
            Return txtDIreccion2.Visible
        End Get
        Set(ByVal value As Boolean)
            txtDIreccion2.Visible = value
            txtTelefono.Enabled = value
            txtCelular.Enabled = value
            cboDepartamento.Activa = value
            cboProvincia.Activa = value
            cboDIstrito.Activa = value
        End Set
    End Property

    Public Property ActivaGrupoMontos() As Boolean
        Get
            Return txtMontoKS.Visible
        End Get
        Set(ByVal value As Boolean)
            txtMontoKS.Enabled = value
            txtMontoTS.Enabled = value
            txtMontoKUS.Enabled = value
            txtMontoTUS.Enabled = value
        End Set
    End Property

    Private Sub cboDepartamento_Click() Handles cboDepartamento.Click
        With cboProvincia
            .Limpia()
            .Condicion = ":cod▓" & cboDepartamento.Value
            .Cargar_dll()
        End With
    End Sub

    Private Sub cboProvincia_Click() Handles cboProvincia.Click
        With cboDIstrito
            .Limpia()
            .Condicion = ":cod▓" & cboProvincia.Value
            .Cargar_dll()
        End With
    End Sub


    Public Property IdCliente() As String
        Get
            Return lblIdCliente.Text
        End Get
        Set(ByVal value As String)
            lblIdCliente.Text = value
        End Set
    End Property

    Public Property Cartera() As String
        Get
            Return Session("NCartera")
        End Get
        Set(ByVal value As String)
            Session("NCartera") = value
        End Set
    End Property

    Public Property Condicion() As String
        Get
            Return Session("NCondicion")
        End Get
        Set(ByVal value As String)
            Session("NCondicion") = value
        End Set
    End Property

    Public Property DNI() As String
        Get
            Return Session("NDNI")
        End Get
        Set(ByVal value As String)
            Session("NDNI") = value
        End Set
    End Property

    Public Property NombreCliente() As String
        Get
            Return Session("NombreCliente")
        End Get
        Set(ByVal value As String)
            Session("NombreCliente") = value
        End Set
    End Property

    Public Property Tipo() As String
        Get
            Return lblTipoVentana.Text
        End Get
        Set(ByVal value As String)
            lblTipoVentana.Text = value
        End Set
    End Property


    Sub Cargar()
        cboDepartamento.Limpia()
        cboDepartamento.Cargar_dll()

        CtlGrilla1.OcultarColumnas = "12"
        If lblTipoVentana.Text = "ACTUALIZAR" Then
            Dim dt As New DataTable
            BLCliente.IdCliente = IdCliente
            dt = BLCliente.BuscarClienteGestion()

            For i = 0 To dt.Columns.Count - 1
                If IsDBNull(dt.Rows(0)(i)) Then
                    dt.Rows(0)(i) = ""
                End If
            Next

            cboCartera.Text = dt.Rows(0)(1)
            cboCondic.Text = dt.Rows(0)(2)
            txtSituac.Text = dt.Rows(0)(3)
            txtDNI.Text = dt.Rows(0)(4)
            txtNombreCliente.Text = dt.Rows(0)(5)
            txtDIreccion2.Text = dt.Rows(0)(6)
            txtTelefono.Text = dt.Rows(0)(8)
            txtCelular.Text = dt.Rows(0)(9)
            If IsDBNull(dt.Rows(0)(10)) Then
                cboDepartamento.Text = "Lima"
            Else
                cboDepartamento.Text = dt.Rows(0)(10)
            End If
            Call cboDepartamento_Click()
            If IsDBNull(dt.Rows(0)(11)) Then
                cboDepartamento.Text = "Lima"
            Else
                cboProvincia.Text = dt.Rows(0)(11)
            End If
            Call cboProvincia_Click()
            If IsDBNull(dt.Rows(0)(12)) Then
                cboDIstrito.Text = ""
            Else
                cboDIstrito.Text = dt.Rows(0)(12)
            End If

            dt = BLCliente.BuscarClienteGestion2()
            If dt.Rows.Count <> 0 Then
                For i = 0 To dt.Columns.Count - 1
                    If IsDBNull(dt.Rows(0)(i)) Then
                        dt.Rows(0)(i) = ""
                    End If
                Next
                txtDireccion1.Text = dt.Rows(0)(5)
                txtTelefono1.Text = dt.Rows(0)(9)
                txtDepartamento.Text = dt.Rows(0)(8)
                txtProvincia.Text = dt.Rows(0)(7)
                txtDistrito.Text = dt.Rows(0)(6)
                txtSituac.Text = dt.Rows(0)(3)
            End If

            dt = BLCliente.BuscarClienteGestion3()
            If dt.Rows.Count <> 0 Then
                For i = 0 To dt.Columns.Count - 1
                    If IsDBNull(dt.Rows(0)(i)) Then
                        dt.Rows(0)(i) = ""
                    End If
                Next
                If dt.Rows(0)(1) = "S" Then
                    txtMontoKS.Text = dt.Rows(0)(2)
                    txtMontoTS.Text = dt.Rows(0)(3)
                ElseIf dt.Rows(0)(1) = "D" Then
                    txtMontoKUS.Text = dt.Rows(0)(2)
                    txtMontoTUS.Text = dt.Rows(0)(3)
                End If
            End If

            dt = BLCliente.BuscarClienteGestion4
            If dt.Rows.Count <> 0 Then
                For i = 0 To dt.Columns.Count - 1
                    If IsDBNull(dt.Rows(0)(i)) Then
                        dt.Rows(0)(i) = ""
                    End If
                Next
                CtlGrilla1.SourceDataTable = dt
            End If
        End If
    End Sub

    Private Sub imgGrabar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgGrabar.Click
        If Len(Trim(cboCartera.Text)) = 0 Then
            CtlMensajes1.Mensaje("Seleccione una cartera", "SISTEMA DE COBRANZA")
        ElseIf Len(Trim(cboCondic.Text)) = 0 Then
            CtlMensajes1.Mensaje("Seleccione una condicion", "SISTEMA DE COBRANZA")
        ElseIf Len(Trim(txtSituac.Text)) = 0 Then
            CtlMensajes1.Mensaje("Escriba la situacion del Cliente", "SISTEMA DE COBRANZA")
        ElseIf Len(Trim(txtDNI.Text)) = 0 Then
            CtlMensajes1.Mensaje("Escriba el DNI del Cliente", "SISTEMA DE COBRANZA")
        ElseIf Len(Trim(txtNombreCliente.Text)) = 0 Then
            CtlMensajes1.Mensaje("Escriba el nombre del Cliente", "SISTEMA DE COBRANZA")
        ElseIf Len(Trim(cboDIstrito.Text)) = 0 Then
            CtlMensajes1.Mensaje("Seleccione el Distrito del Cliente", "SISTEMA DE COBRANZA")
        Else
            If lblTipoVentana.Text = "ACTUALIZAR" Then
                BLCliente.Cartera = cboCartera.Value
                BLCliente.Condicion = cboCondic.Value
                BLCliente.Distrito = cboDIstrito.Value
                BLCliente.Cliente = txtNombreCliente.Text
                BLCliente.DNI = txtDNI.Text
                BLCliente.Direccion = txtDIreccion2.Text
                BLCliente.Telefono1 = txtTelefono.Text
                BLCliente.Telefono2 = txtTelefono1.Text
                BLCliente.Celular = txtCelular.Text
                BLCliente.Situacion = txtSituac.Text
                BLCliente.IdCliente = lblIdCliente.Text
                BLCliente.ActualizarCliente()
                If InStr(1, BLCliente.Mensaje, "Error") > 0 Then
                    CtlMensajes1.Mensaje(BLCliente.Mensaje, "SISTEMA DE COBRANZA")
                Else
                    CtlMensajes1.Mensaje("Se actualizo correctamente al cliente", "SISTEMA DE COBRANZA")
                End If
            ElseIf lblTipoVentana.Text = "NUEVO" Then
                BLCliente.Cartera = cboCartera.Value
                BLCliente.Condicion = cboCondic.Value
                BLCliente.Distrito = cboDIstrito.Value
                BLCliente.Cliente = txtNombreCliente.Text
                BLCliente.DNI = txtDNI.Text
                BLCliente.Direccion = txtDIreccion2.Text
                BLCliente.Telefono2 = txtTelefono.Text
                BLCliente.Celular = txtCelular.Text
                BLCliente.Situacion = txtSituac.Text
                BLCliente.NuevoCliente()
                If InStr(1, BLCliente.Mensaje, "Error") > 0 Then
                    CtlMensajes1.Mensaje(BLCliente.Mensaje, "SISTEMA DE COBRANZA")
                Else
                    CtlMensajes1.Mensaje("Se ingreso correctamente al cliente", "SISTEMA DE COBRANZA")
                End If
                Call ImageButton5_Click(sender, e)
            End If
        End If
    End Sub

    Private Sub CtlPagos1_Cerrar() Handles CtlPagos1.Cerrar
        pnlPagos.Visible = False
    End Sub

    Private Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        
    End Sub

    Sub CargarCombo()
        cboCartera.Limpia()
        cboCartera.Cargar_dll()
        cboCondic.Limpia()
        cboCondic.Cargar_dll()
        cboDepartamento.Limpia()
        cboDepartamento.Cargar_dll()
    End Sub
End Class