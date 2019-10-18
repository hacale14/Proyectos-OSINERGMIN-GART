Imports Controles
Partial Public Class ConsultaAsignacion
    Inherits System.Web.UI.Page
    Dim busqueda As New BL.Busquedas
    Public Sub Menu1_MenuItemClick(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.MenuEventArgs) Handles Menu1.MenuItemClick
        Dim index As Integer = Int32.Parse(e.Item.Value)
        If Session("idPerfil") = "7" Then
            MultiView1.ActiveViewIndex = 0
            Condicion_Pestañas(0)
            Campos.Validar_Cartera(0)
        Else
            MultiView1.ActiveViewIndex = index
            Condicion_Pestañas(index)
            Campos.Validar_Cartera(index)
        End If
    End Sub
    Function Obtiene_Cookies(ByVal id) As String
        '// Recogemos la cookie que nos interese
        Dim cogeCookie As HttpCookie = Request.Cookies.Get(id)
        Return cogeCookie.Value
    End Function
    Private Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Obtiene_Cookies("idcorporacion") = 1 Then
            'Estilos = "Estilos.css"
            'colorMenu = 
            'colorMenuF = "#2D3B4A"
            'ColorLetraF = "white"
            Menu1.Style.Add("backcolor", "#9EBCF6")
        Else
            Menu1.Style.Add("backcolor", "#FF6700")
        End If


        If Not Me.IsPostBack Then
            Campos.Titulo = "BUSQUEDA POR DATOS DE CLIENTE"
            Dim mpHidden = Obtiene_Cookies("TipoUsuario")
            Dim ctlp1 As New Controles.General
            Dim dtp1 = ctlp1.Obtiene_Consulta(":idusuario▓" & Obtiene_Cookies("idusuario"), "BOL001")
            If Not dtp1 Is Nothing Then
                If dtp1.rows.count > 0 Then
                    PnlBolsa.Visible = True
                    txtBolsa.Text = "Mensaje de Alerta: usted va ingresar en modo bolsa de trabajo favor dar click en boton ingresar para gestionar sus clientes, o comuniquese con su Supervisor de cartera... ¡Gracias!"
                    BtnIngresarBolsa.Attributes.Add("onclick", "javascript:window.open('Gestion.aspx?" & _
                                  "DNI=" & dtp1.rows(0)(0) & _
                                  "&idcliente=" & dtp1.rows(0)(1) & _
                                  "&idcartera=" & dtp1.rows(0)(2) & _
                                  "&idusuario=" & dtp1.rows(0)(3) & _
                                  "&NombreGestor=" & dtp1.rows(0)(4) & _
                                  "&tipocartera=" & dtp1.rows(0)(5) & _
                                  "&usuario=" & dtp1.rows(0)(6) & _
                                  "','winopen', 'status=yes, directories=no, toolbar=no, menubar=no, location=no, addressbar=no,width=1600,height=900,left=0,top=0,resizable=no,fullscreen,scrollbars');")
                    Menu1.Visible = False
                    Campos.Visible = False
                End If
            End If
            dtp1 = Nothing
            Condicion_Pestañas(0)
            Dim dtp = ctlp1.Obtiene_Consulta(":idusuario▓" & Obtiene_Cookies("idusuario"), "GES010")
            txtAnotacionMensaje.Text = ""
            PnlMensajeAlerta.Visible = False
            If Not dtp Is Nothing Then
                For i = 0 To dtp.rows.count - 1
                    txtAnotacionMensaje.Text &= "===========" & vbCrLf
                    txtAnotacionMensaje.Text &= "Anotacion: " & i & vbCrLf
                    txtAnotacionMensaje.Text &= "===========" & vbCrLf
                    txtAnotacionMensaje.Text &= "Id-Agenda: " & dtp.rows(i)("idagenda") & vbCrLf
                    txtAnotacionMensaje.Text &= "Id-Cartera: " & dtp.rows(i)("anotacion") & vbCrLf
                    txtAnotacionMensaje.Text &= "Id-Cliente: " & dtp.rows(i)("idcartera") & " / DNI: " & dtp.rows(i)("dni") & vbCrLf
                    txtAnotacionMensaje.Text &= "Fecha y Hora Agendada: " & dtp.rows(i)("fechaProxAcc") & vbCrLf
                    txtAnotacionMensaje.Text &= "Anotacion: " & dtp.rows(i)("anotacion") & vbCrLf
                    PnlMensajeAlerta.Visible = True
                Next
            End If
            dtp = Nothing
            ctlp1 = Nothing
        End If
    End Sub
    Private Sub Condicion_Pestañas(ByVal index As String)
        Campos.DNI = False
        Campos.Telefono = False
        Campos.Tipo_Cartera = False
        Campos.Refinanciar = False
        Campos.Campaña = False
        Campos.Producto = False
        Campos.Negocio = False
        Campos.Nro_Operacion = False
        Campos.Nro_Cuenta = False
        Campos.Dias_Mora = False
        If PnlBolsa.Visible = True Then
            Campos.Muestra_Buscar = False
        End If
        If index = 0 Then
            Campos.DNI = True
            Campos.Telefono = True
            Campos.Tipo_Cartera = True
            Campos.Titulo = "BUSQUEDA POR DATOS DE CLIENTE"
            gvCliente.SourceDataTable = Nothing
            '  Botones1.Titulo_Principal = "BUSQUEDA POR DATOS DE CLIENTE"
        ElseIf index = 1 Then
            Campos.Refinanciar = True
            Campos.Campaña = True
            Campos.Producto = True
            Campos.Negocio = True
            Campos.Nro_Operacion = True
            Campos.Titulo = "BUSQUEDA DE DATOS DE OPERACION - CASTIGO"
            gvCastigo.SourceDataTable = Nothing
            ' Botones1.Titulo_Principal = "BUSQUEDA DE DATOS DE OPERACION - CASTIGO"
        ElseIf index = 2 Then
            Campos.Producto = True
            Campos.Negocio = True
            Campos.Nro_Cuenta = True
            Campos.Dias_Mora = True
            Campos.Titulo = "BUSQUEDA DE DATOS DE OPERACION - ACTIVA"
            gvActiva.SourceDataTable = Nothing
            'Botones1.Titulo_Principal = "BUSQUEDA DE DATOS DE OPERACION - ACTIVA"
        End If
    End Sub
    Private Sub Campos_Buscar(ByVal Dt As System.Data.DataTable, ByVal index As String) Handles Campos.Buscar
        If PnlBolsa.Visible Then
            CtlMensajes1.Mensaje("¡Advertencia...! usted esta asignado a BOLSA por lo que no podra usar esta opcion o comuniquese con su supervisor", "")
            Exit Sub
            Campos.Muestra_Buscar = False
        End If
        Using Dt
            If index = 0 Then
                gvCliente.Visible = True
                gvCliente.SourceDataTable = Dt
                If Not Dt Is Nothing Then
                    lblcantidadCliente.Text = Dt.Rows.Count
                End If
                '   Botones1.DtBusquedaGestor = Dt
            ElseIf index = 1 Then
                gvCastigo.Visible = True
                gvCastigo.SourceDataTable = Dt
                If Not Dt Is Nothing Then : lblcantidadCastigo.Text = Dt.Rows.Count : End If
                '  Botones1.DtBusquedaGestor = Dt
            ElseIf index = 2 Then
                gvActiva.Visible = True
                gvActiva.SourceDataTable = Dt
                If Not Dt Is Nothing Then : lblcantidadActiva.Text = Dt.Rows.Count : End If
                'Botones1.DtBusquedaGestor = Dt
            End If
        End Using
    End Sub

    Private Sub gvCliente_Boton_Click(ByVal GV As System.Web.UI.WebControls.GridView, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvCliente.Boton_Click
        Call Carga_Link(e)
    End Sub
    Private Sub gvCliente_RowDeleting(ByVal GV As System.Web.UI.WebControls.GridView, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gvCliente.RowDeleting
        Try
            Dim row As GridViewRow = GV.Rows(e.RowIndex)
            Dim IdCliente = IIf(Not row.Cells(13).Text = "&nbsp;", row.Cells(13).Text, "")
            Dim IdUsuarioCliente = IIf(Not row.Cells(14).Text = "&nbsp;", row.Cells(14).Text, "")
            Dim Cliente = IIf(Not row.Cells(7).Text = "&nbsp;", row.Cells(7).Text, "")
            Dim Cantidad = lblcantidadCliente.Text
            CtlEliminarAsignacion1.Cargar_datos(IdUsuarioCliente, IdCliente, Cliente)
            CtlEliminarAsignacion1.Visible = True
        Catch ex As Exception
            CtlMensajes1.Mensaje("Error..: " & ex.Message)
        End Try
    End Sub
    Private Sub gvCliente_RowEditing(ByVal GV As System.Web.UI.WebControls.GridView, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs, ByVal row As System.Web.UI.WebControls.GridViewRow) Handles gvCliente.RowEditing
        Try
            Dim IdCliente = IIf(Not row.Cells(13).Text = "&nbsp;", row.Cells(13).Text, "")
            Dim IdUsuarioCliente = IIf(Not row.Cells(14).Text = "&nbsp;", row.Cells(14).Text, "")
            Dim Cliente = IIf(Not row.Cells(7).Text = "&nbsp;", row.Cells(7).Text, "")
            Dim Usuario = IIf(Not row.Cells(4).Text = "&nbsp;", row.Cells(4).Text, "")
            Dim Cantidad = lblcantidadCliente.Text
            CtlModificarAsignacion1.CargaAsignacion(IdCliente, IdUsuarioCliente, Cliente, Usuario, Cantidad)
            CtlModificarAsignacion1.Visible = True
        Catch ex As Exception
            CtlMensajes1.Mensaje("Error..: " & ex.Message)
        End Try
    End Sub

    Private Sub gvCastigo_Boton_Click(ByVal GV As System.Web.UI.WebControls.GridView, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvCastigo.Boton_Click
        Call Carga_Link(e)
    End Sub
    Private Sub gvCastigo_RowDeleting(ByVal GV As System.Web.UI.WebControls.GridView, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gvCastigo.RowDeleting
        Try
            Dim row As GridViewRow = GV.Rows(e.RowIndex)
            Dim IdCliente = IIf(Not row.Cells(20).Text = "&nbsp;", row.Cells(20).Text, "")
            Dim IdUsuarioCliente = IIf(Not row.Cells(21).Text = "&nbsp;", row.Cells(21).Text, "")
            Dim Cliente = IIf(Not row.Cells(11).Text = "&nsbp;", row.Cells(11).Text, "")
            Dim Cantidad = lblcantidadCastigo.Text
            CtlEliminarAsignacion1.Cargar_datos(IdUsuarioCliente, IdCliente, Cliente)
            CtlEliminarAsignacion1.Visible = True
        Catch ex As Exception
            CtlMensajes1.Mensaje("Error..: " & ex.Message)
        End Try
    End Sub
    Private Sub gvCastigo_RowEditing(ByVal GV As System.Web.UI.WebControls.GridView, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs, ByVal row As System.Web.UI.WebControls.GridViewRow) Handles gvCastigo.RowEditing
        Try
            Dim IdCliente = IIf(Not row.Cells(20).Text = "&nbsp;", row.Cells(20).Text, "")
            Dim IdUsuarioCliente = IIf(Not row.Cells(21).Text = "&nbsp;", row.Cells(21).Text, "")
            Dim Cliente = IIf(Not row.Cells(11).Text = "&nbsp;", row.Cells(11).Text, "")
            Dim Usuario = IIf(Not row.Cells(4).Text = "&nbsp;", row.Cells(4).Text, "")
            Dim Cantidad = lblcantidadCastigo.Text
            CtlModificarAsignacion1.CargaAsignacion(IdCliente, IdUsuarioCliente, Cliente, Usuario, Cantidad)
            CtlModificarAsignacion1.Visible = True
        Catch ex As Exception
            CtlMensajes1.Mensaje("Error..: " & ex.Message)
        End Try
    End Sub

    Private Sub gvActiva_Boton_Click(ByVal GV As System.Web.UI.WebControls.GridView, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvActiva.Boton_Click       
        Call Carga_Link(e)
    End Sub

    Sub Carga_Link(ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs)
        Dim Hidusuario, _
            Husuario, _
            Hclave, _
            Hcargo, _
            HNombreGestor, _
            HTipoUsuario, _
            HidPerfil As HiddenField

        Hidusuario = CType(Master.FindControl("Hidusuario"), HiddenField)
        Husuario = CType(Master.FindControl("Husuario"), HiddenField)
        Hclave = CType(Master.FindControl("Hclave"), HiddenField)
        Hcargo = CType(Master.FindControl("Hcargo"), HiddenField)
        HNombreGestor = CType(Master.FindControl("HNombreGestor"), HiddenField)
        HTipoUsuario = CType(Master.FindControl("HTipoUsuario"), HiddenField)
        HidPerfil = CType(Master.FindControl("HidPerfil"), HiddenField)

        If e.Row.RowIndex <> -1 Then
            'For c = 0 To e.Row.Cells.Count - 1
            'Session("Parametros" & e.Row.Cells(6).Text & e.Row.Cells(17).Text) = e.Row.Cells
            'Next

            For i = 0 To e.Row.Cells.Count - 1
                If e.Row.Cells(15).Text = "T" Then
                    e.Row.Cells(i).BackColor = System.Drawing.ColorTranslator.FromHtml("#0ED5E2")
                Else
                    'If Val(e.Row.Cells(13).Text) > 0 Then
                    ' e.Row.Cells(i).BackColor = System.Drawing.ColorTranslator.FromHtml("#0ED5E2")
                    'End If
                End If
            Next
            e.Row.Cells(1).ToolTip = ""
            e.Row.Cells(1).Text = "<center><img src='Imagenes/imgCall6.png' id='imgButton' alt='Smiley face' height='20px' width='20px' onclick=""window.open('" & "Gestion.aspx?" & _
                                  "DNI=" & e.Row.Cells(6).Text & _
                                  "&idcliente=" & e.Row.Cells(18).Text & _
                                  "&idcartera=" & e.Row.Cells(22).Text & _
                                  "&idusuario=" & Hidusuario.Value & _
                                  "&NombreGestor=" & HNombreGestor.Value & _
                                  "&tipocartera=" & e.Row.Cells(17).Text & _
                                  "&usuario=" & Husuario.Value & _
                                  "','winopen', 'status=yes, directories=no, toolbar=no, menubar=no, location=no, addressbar=no,width=1600,height=900,left=0,top=0,resizable=no,fullscreen,scrollbars');""" & "></center>"
        End If
    End Sub
    Private Sub gvActiva_RowDeleting(ByVal GV As System.Web.UI.WebControls.GridView, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gvActiva.RowDeleting
        Try
            Dim row As GridViewRow = GV.Rows(e.RowIndex)
            Dim IdCliente = IIf(Not row.Cells(26).Text = "&nbsp;", row.Cells(26).Text, "")
            Dim IdUsuarioCliente = IIf(Not row.Cells(27).Text = "&nbsp;", row.Cells(27).Text, "")
            Dim Cliente = IIf(Not row.Cells(9).Text = "&nbsp;", row.Cells(9).Text, "")
            Dim Cantidad = lblcantidadActiva.Text
            CtlEliminarAsignacion1.Cargar_datos(IdUsuarioCliente, IdCliente, Cliente)
            CtlEliminarAsignacion1.Visible = True
        Catch ex As Exception
            CtlMensajes1.Mensaje("Error..: " & ex.Message)
        End Try
    End Sub
    Private Sub gvActiva_RowEditing(ByVal GV As System.Web.UI.WebControls.GridView, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs, ByVal row As System.Web.UI.WebControls.GridViewRow) Handles gvActiva.RowEditing
        Try
            Dim IdCliente = IIf(Not row.Cells(26).Text = "&nbsp;", row.Cells(26).Text, "")
            Dim IdUsuarioCliente = IIf(Not row.Cells(27).Text = "&nbsp;", row.Cells(27).Text, "")
            Dim Cliente = IIf(Not row.Cells(9).Text = "&nbsp;", row.Cells(9).Text, "")
            Dim Usuario = IIf(Not row.Cells(4).Text = "&nbsp;", row.Cells(4).Text, "")
            Dim Cantidad = lblcantidadActiva.Text
            CtlModificarAsignacion1.CargaAsignacion(IdCliente, IdUsuarioCliente, Cliente, Usuario, Cantidad)
            CtlModificarAsignacion1.Visible = True
        Catch ex As Exception
            CtlMensajes1.Mensaje("Error..: " & ex.Message)
        End Try
    End Sub

    Private Sub gvCliente_Seleccionarfila(ByVal sender As Object, ByVal e As System.EventArgs, ByVal row As System.Web.UI.WebControls.GridViewRow) Handles gvCliente.Seleccionarfila
        'If e.Row.RowType = ListItemType.Item Or e.Row.RowType = ListItemType.AlternatingItem Then
        ' Dim chkBox As CheckBox = CType(e.Row.FindControl("ImgCall"), ImageButton)
        ' End If
    End Sub

    Private Sub Campos_ClickPropuesta(ByVal dt As System.Data.DataTable, ByVal tipo As String) Handles Campos.ClickPropuesta
        pnlPropuesta.Visible = True
        gvPropuesta.SourceDataTable = dt
        If Tipo_Propuesta = "R" Then
            gvPropuesta.Activa_Edita = False
        End If
    End Sub

    Public Property Tipo_Propuesta() As String
        Get
            Return lblTipoPropuesta.Text
        End Get
        Set(ByVal value As String)
            lblTipoPropuesta.Text = value
        End Set
    End Property


    Private Sub Campos_SeleccionCartera(ByVal cantidad As Long, ByVal dt2 As System.Data.DataTable, ByVal index As String) Handles Campos.SeleccionCartera
        If Len(Trim(index)) > 0 And Session("idPerfil") <> "4" Then
            grupo_estaditica.Visible = False
            'grafica.Visible = True
            lblPieContenido.Text = "Total de Asiganciones " & cantidad
            Campos.Titulo = "REPORTE DE ASIGNACION POR CARTERA"
            Condicion_Pestañas(0)
            'Chart1.TablaCarga = dt2
            'Chart1.CargarDataTable("Asignacion de Clientes por Gestor", "Gestor", "Asigancion de Cliente")
            'grafica.DataSource = dt2
            'If dt2.Rows.Count < 3 Then
            '    grafica.Height = 150
            'Else
            '    grafica.Height = (dt2.Rows.Count * 25) + 50
            'End If
            'grafica.Series("Series1").XValueMember = "Usuario"
            'grafica.Series("Series1").YValueMembers = "CANTIDAD"
            'grafica.DataBind()
            'grafica.Titles("Title1").Text = "ASIGNACION POR CLIENTE"
        End If
    End Sub

    Private Sub imgCerrar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgCerrar.Click
        grupo_estaditica.Visible = False
    End Sub

    Private Sub View1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles View1.Load
        If gvCliente.Contador = 0 Then
            gvCliente.Visible = False
        End If
    End Sub

    Private Sub View2_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles View2.Load
        If gvCastigo.Contador = 0 Then
            gvCastigo.Visible = False
        End If
    End Sub

    Private Sub View3_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles View3.Load
        If gvActiva.Contador = 0 Then
            gvActiva.Visible = False
        End If
    End Sub

    Private Sub btnCerrarPropuesta_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCerrarPropuesta.Click
        pnlPropuesta.Visible = False
    End Sub

    Function ObtenerIdElemento(ByVal dato As String) As String
        Try
            Dim ctl As New BL.Cobranza
            Dim dt As New DataTable
            Dim criterio As String
            criterio = " idtabla=105 and and DescCorta='" & dato & "'"
            dt = ctl.FunctionGlobal(":criterio▓" & criterio, "SQL_N_GEST055")
        Catch ex As Exception

        End Try
    End Function

    Private Sub gvPropuesta_RowEditing(ByVal GV As System.Web.UI.WebControls.GridView, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs, ByVal row As System.Web.UI.WebControls.GridViewRow) Handles gvPropuesta.RowEditing
        Try
            pnlMantenimientoPropuesta.Visible = True
            Id_Propuesta_Activa = row.Cells(4).Text
            txtFechaGeneroPropuesta.Text = Left(row.Cells(9).Text, 10)
            txtNroPartesPropuesta.Text = row.Cells(13).Text
            txtMontoPropuesta.Text = row.Cells(15).Text
            cboMonedaPropuesta.Text = row.Cells(17).Text
            txtSustentoPropuesta.Text = row.Cells(10).Text
            CargarPropuestaMantenieminto()
            cboOperacionPropuesta.Value = row.Cells(8).Text
            cboEstadoPropuesta.Value = ObtenerIdElemento(row.Cells(14).Text)

            If Tipo_Propuesta = "A" Then
                cboEstadoPropuesta.Activa = False
                cboOperacionPropuesta.Activa = False
                txtMontoPropuesta.Enabled = False
                cboMonedaPropuesta.Activa = False
                txtSustentoPropuesta.Enabled = False
            Else
                cboEstadoPropuesta.Activa = True
                cboOperacionPropuesta.Activa = True
                txtMontoPropuesta.Enabled = True
                cboMonedaPropuesta.Activa = True
                txtSustentoPropuesta.Enabled = True
            End If
        Catch ex As Exception
            CtlMensajes1.Mensaje("Ocurrio un error al cargar los datos")
        End Try
    End Sub

    Public Property Id_Propuesta_Activa() As String
        Get
            Return lblId_Propuesta.Text
        End Get
        Set(ByVal value As String)
            lblId_Propuesta.Text = value
        End Set
    End Property

    Sub CargarPropuestaMantenieminto()
        cboEstadoPropuesta.Limpia()
        cboEstadoPropuesta.Cargar_dll()
        cboMonedaPropuesta.Limpia()
        cboMonedaPropuesta.Cargar_dll()
        cboMonedaPropuestaMantenimeinto.Limpia()
        cboMonedaPropuestaMantenimeinto.Cargar_dll()

        Dim dt As New DataTable
        Dim ctl As New BL.Cobranza
        dt = ctl.FunctionGlobal(":idpropuesta▓" & Id_Propuesta_Activa, "SQL_N_GEST054")
        If dt.Rows.Count > 0 Then
            If dt.Rows(0)(1) = "ACTIVA" Then
                cboOperacionPropuesta.Procedimiento = "SQL_N_GEST034"
            Else
                cboOperacionPropuesta.Procedimiento = "SQL_N_GEST033"
            End If
            cboOperacionPropuesta.Condicion = ":idcliente▓" & dt.Rows(0)(0)
            cboOperacionPropuesta.Limpia()
            cboOperacionPropuesta.Cargar_dll()
        End If
    End Sub

    Private Sub imgCerrarPropuesta_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgCerrarPropuesta.Click
        pnlMantenimientoPropuesta.Visible = False
    End Sub

    Private Sub imgGrabarPropuesta_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgGrabarPropuesta.Click
        Dim ctl As New BL.Cobranza
        Dim criterio As String
        If cboEstadoPropuesta.Value = "R" Then
            criterio = criterio & " ,IdUsuarioPropuesta=" & Session("idusuario")
        ElseIf cboEstadoPropuesta.Value = "A" Then
            criterio = criterio & " ,IdUsuarioPropuesta=" & Session("idusuario")
        End If
        If chkPagoPropuesta.Checked = True Then
            criterio = criterio & " ,IdUsuarioPago=" & Session("idusuario") & ",MontoPago='" & txtMontoPropuestaMantenimiento.Text & "',MonedaPago='" & cboMonedaPropuestaMantenimeinto.Value & "',FechaPago='" & txtFechaPagoPropuesta.Text & "'"
        End If
        ctl.FunctionGlobal(":montocomprometidoƒ:fecharespuestaƒ:montoaceptadaƒ:monedaƒ:nrocuetasaceptadasƒ:estadoƒ:criterioƒ:idpropuesta▓" & _
                        txtMontoPropuesta.Text & "ƒ" & txtFechaRespuesta.Text & "ƒ" & txtMontoPropuesta.Text & "ƒ" & cboMonedaPropuesta.Value & "ƒ" & _
                        txtNroPartesPropuesta.Text & "ƒ" & cboEstadoPropuesta.Value & "ƒ" & criterio & "ƒ" & Id_Propuesta_Activa, "SQL_N_GEST047")
        pnlMantenimientoPropuesta.Visible = False
        pnlPropuesta.Visible = False
    End Sub

    Private Sub btnCerrar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        PnlMensajeAlerta.Visible = False
    End Sub

    Private Sub BtnIngresarBolsa_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnIngresarBolsa.Click
        Response.Redirect("Principal.aspx")
    End Sub
End Class