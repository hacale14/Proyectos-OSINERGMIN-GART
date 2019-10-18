Public Partial Class CtlNPerfil
    Inherits System.Web.UI.UserControl
    Dim bl As New BL.Cobranza
    'PROPIEDADES
    Public Property cod() As String
        Get
            Return lblcod.Text
        End Get
        Set(ByVal value As String)
            lblcod.Text = value
        End Set
    End Property
    Public Property titulo() As String
        Get
            Return lblTitulo.Text
        End Get
        Set(ByVal value As String)
            lblTitulo.Text = value
        End Set
    End Property
    'CREAR UNA TABLA TEMPORAL
    Private Sub CrearTabla()
        Dim table As New DataTable
        table = New DataTable("Accesos")
        table.Columns.Add("ID", System.Type.GetType("System.String"))
        table.Columns.Add("MENU", System.Type.GetType("System.String"))
        table.Columns.Add("NOMBRE PANTALLA", System.Type.GetType("System.String"))
        Session("DtAccesos") = table
    End Sub
    Sub AgregarTabla(ByVal Nivel As String, ByVal Pantalla As String, ByVal Menu As String)
        Dim Dt As New DataTable
        Using Dt
            Dt = DirectCast(Session("DtAccesos"), DataTable)
            Dim row As DataRow = Dt.NewRow
            row(0) = Nivel
            row(1) = Menu
            row(2) = Pantalla
            Dt.Rows.Add(row)
            'Dim View As DataView = New DataView(Dt)
            'View.Sort = "ID DESC"
            'Session("DtAccesos") = View.ToTable
            gvAccesos.SourceDataTable = Dt
        End Using
    End Sub
    ' CARGA INICIAL
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            CrearTabla()
            If titulo = "MODIFICAR DATOS DEL PERFIL" Then
                CargaMantenimiento()
            End If
        End If
    End Sub
    ' METODOS PARA INGRESAR UN NUEVO PERFIL
    Private Sub btnCerrar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnCerrar.Click
        Response.Redirect("Perfil.aspx")
    End Sub
    Private Sub btnGrabar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnGrabar.Click
        If titulo = "MODIFICAR DATOS DEL PERFIL" Then
            Modificar_Perfil()
            Response.Redirect("Perfil.aspx")
        Else
            Ingresar_Perfil()
            Response.Redirect("Perfil.aspx")
        End If
    End Sub
    Private Sub btnSiguiente_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnSiguiente.Click
        Dim Nivel = ""
        Dim Nivelf = ""
        Dim Pantalla = ""
        Dim Menu = ""
        Dim count = 0
        Dim countgrid = 0

        For i = 0 To TV1.Nodes.Count - 1

            Menu = TV1.Nodes.Item(i).Text
            If TV1.Nodes.Item(i).Checked Then
                For x = 0 To TV1.Nodes.Item(i).ChildNodes.Count - 1
                    If TV1.Nodes.Item(i).ChildNodes.Item(x).Checked Then
                        If TV1.Nodes.Item(i).ChildNodes.Item(x).ChildNodes.Count > 0 Then
                            For y = 0 To TV1.Nodes.Item(i).ChildNodes.Item(x).ChildNodes.Count - 1
                                Nivel = TV1.Nodes.Item(i).ChildNodes.Item(x).ChildNodes.Item(y).Value
                                Pantalla = TV1.Nodes.Item(i).ChildNodes.Item(x).ChildNodes.Item(y).Text
                                If gvAccesos.GV.Rows.Count > 0 Then
                                    For z = 0 To gvAccesos.GV.Rows.Count - 1
                                        If Nivel = gvAccesos.GV.Rows(z).Cells(4).Text Then
                                            countgrid += 1
                                            Exit For
                                        End If
                                    Next
                                End If
                                If countgrid < 1 Then
                                    AgregarTabla(Nivel, Pantalla.ToUpper, Menu.ToUpper)
                                End If
                                countgrid = 0
                            Next
                        Else
                            Nivel = TV1.Nodes.Item(i).ChildNodes.Item(x).Value
                            Pantalla = TV1.Nodes.Item(i).ChildNodes.Item(x).Text
                            If gvAccesos.GV.Rows.Count > 0 Then
                                For z = 0 To gvAccesos.GV.Rows.Count - 1
                                    If Nivel = gvAccesos.GV.Rows(z).Cells(4).Text Then
                                        countgrid += 1
                                        Exit For
                                    End If
                                Next
                            End If
                            If countgrid < 1 Then
                                AgregarTabla(Nivel, Pantalla.ToUpper, Menu.ToUpper)
                            End If
                            countgrid = 0
                        End If
                    End If
                Next
                count += 1
            End If
        Next

        If count = 0 Then
            CtlMensajes1.Mensaje("AVISO..: DEBE SELECCIONAR UN MENU PADRE - SEGURIDAD, ADMINISTRACION, PROCESOS, REPORTES - PARA CONTINUAR!")
        End If
    End Sub
    Private Sub gvAccesos_RowDeleting(ByVal GV As System.Web.UI.WebControls.GridView, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gvAccesos.RowDeleting
        'Dim row As GridViewRow = GV.Rows(e.RowIndex)

        Dim index As Integer = Convert.ToInt32(e.RowIndex)
        Dim dt As DataTable = TryCast(Session("DtAccesos"), DataTable)

        bl.FunctionEjecuta("DELETE FROM PERFIL_PANTALLA WHERE IDPERFIL='" & cod & "' AND  IDPANTALLA='" & Trim(dt.Rows(index)(0).ToString()) & "'")
        'dt.Rows(index).Delete()
        CargaMantenimiento()
        dt = Nothing
        dt = bl.FunctionGlobal(":pidperfil▓" & cod, "QRYPVAL007")
        gvAccesos.SourceDataTable = dt
        Session("DtAccesos") = dt
        'CargaMantenimiento()
        dt = Nothing
    End Sub
    'METODOS PARA MODIFICAR UN NUEVO PERFIL
    Private Sub CargaMantenimiento()
        'QRYPFL006
        Dim dt As New DataTable
        Using dt
            dt = bl.FunctionGlobal(":pidperfil▓" & cod, "QRYPFL006")
            If dt.Rows.Count > 0 Then
                txtNombre.Text = IIf(Not IsDBNull(dt(0)("Nombre")), dt(0)("Nombre"), "")
                lblNombreExtra.Text = txtNombre.Text
            End If
            dt = Nothing
            'dt = bl.FunctionGlobal(":pidperfil▓" & cod, "QRYPFL007")
            dt = bl.FunctionGlobal(":pidperfil▓" & cod, "QRYPVAL007")

            For x = 0 To dt.Rows.Count - 1
                AgregarTabla(dt(x)("ID").ToString, dt(x)("NOMBRE PANTALLA").ToString, dt(x)("Menu").ToString)
                For i = 0 To TV1.Nodes.Count - 1
                    If Trim(TV1.Nodes.Item(i).Text.ToUpper) = Trim(dt(x)("Menu").ToString) Then
                        TV1.Nodes.Item(i).Checked = True
                        If TV1.Nodes.Item(i).ChildNodes.Count > 0 Then
                            For y = 0 To TV1.Nodes.Item(i).ChildNodes.Count - 1
                                If Trim(TV1.Nodes.Item(i).ChildNodes.Item(y).Value) = Trim(dt(x)("ID").ToString) Then
                                    TV1.Nodes.Item(i).ChildNodes.Item(y).Checked = True
                                    If TV1.Nodes.Item(i).ChildNodes.Item(y).ChildNodes.Count > 0 Then
                                        For z = 0 To TV1.Nodes.Item(i).ChildNodes.Item(y).ChildNodes.Count - 1
                                            If Trim(dt(x)("PERFIL").ToString) = "SI" Then
                                                TV1.Nodes.Item(i).ChildNodes.Item(y).ChildNodes.Item(z).Checked = True
                                                Exit For
                                            End If
                                        Next
                                    End If
                                    Exit For
                                End If
                            Next
                        End If
                        Exit For
                    End If
                Next
            Next



        End Using
    End Sub
    Private Sub Ingresar_Perfil()
        If Len(Trim(txtNombre.Text)) <= 0 Then : CtlMensajes1.Mensaje("AVISO..: DEBE INGRESAR EL NOMBRE DE PERFIL") : Exit Sub : End If
        If gvAccesos Is Nothing Then : CtlMensajes1.Mensaje("AVISO..: DEBE TENER ACCESOS PARA REGISTRAR AL PERFIL") : End If

        Dim dt As New DataTable
        Dim idPerfil = ""
        Dim countS = 0
        Dim countA = 0
        Dim countP = 0
        Dim countR = 0
        
        Using dt
            dt = bl.FunctionGlobal(":pnombre▓" & txtNombre.Text, "QRYPFL004")
            If dt.Rows.Count >= 2 Then
                CtlMensajes1.Mensaje("ERROR..: YA EXISTE UN PERFIL CON EL NOMBRE INGRESADO!")
                Exit Sub
            End If
        End Using

        Using dt
            bl.FunctionGlobal(":pnombreƒ:pusuario▓" & txtNombre.Text & "ƒ" & Session("usuario"), "QRYPFL002")
            dt = bl.FunctionGlobal(":pnombre▓" & txtNombre.Text, "QRYPFL004")
            idPerfil = dt(0)(0)
        End Using

        For i = 0 To gvAccesos.GV.Rows.Count - 1
            Dim idPantalla = ""

            Dim Menu = ""

            With gvAccesos.GV
                idPantalla = .Rows(i).Cells(4).Text
                Menu = .Rows(i).Cells(5).Text
                If Trim(Menu) = "SEGURIDAD" And countS = 0 Then
                    bl.FunctionGlobal(":pidperfilƒ:pidpantalla▓" & idPerfil & "ƒ" & "01000000", "QRYPFL003")
                    countS += 1
                End If
                If Trim(Menu) = "ADMINISTRACION" And countA = 0 Then
                    bl.FunctionGlobal(":pidperfilƒ:pidpantalla▓" & idPerfil & "ƒ" & "02000000", "QRYPFL003")
                    countA += 1
                End If
                If Trim(Menu) = "PROCESOS" And countP = 0 Then
                    bl.FunctionGlobal(":pidperfilƒ:pidpantalla▓" & idPerfil & "ƒ" & "03000000", "QRYPFL003")
                    countP += 1
                End If
                If Trim(Menu) = "REPORTES" And countR = 0 Then
                    bl.FunctionGlobal(":pidperfilƒ:pidpantalla▓" & idPerfil & "ƒ" & "04000000", "QRYPFL003")
                    countR += 1
                End If
                bl.FunctionGlobal(":pidperfilƒ:pidpantalla▓" & idPerfil & "ƒ" & idPantalla, "QRYPFL003")
            End With
        Next
        Dim dtGlobal As New DataTable
        Dim NewElement As Integer = 1 + CInt(dt.Rows(0)(0))
        dtGlobal = bl.FunctionConsulta("Select top 1 IDElemento From Global With(NoLock) where IdTabla=110 order by 1 desc")
        bl.FunctionConsulta("insert into global(IdTabla,IDElemento,DescCorta,DescLarga,Estado) values('110'," & NewElement & "," & txtNombre.Text & ")")
    End Sub
    Private Sub Modificar_Perfil()
        If Len(Trim(txtNombre.Text)) <= 0 Then : CtlMensajes1.Mensaje("AVISO..: DEBE INGRESAR EL NOMBRE DE PERFIL") : Exit Sub : End If
        If gvAccesos Is Nothing Then : CtlMensajes1.Mensaje("AVISO..: DEBE TENER ACCESOS PARA REGISTRAR AL PERFIL") : End If

        Dim dt As New DataTable
        Dim idPerfil = ""
        Dim countS = 0
        Dim countA = 0
        Dim countP = 0
        Dim countR = 0

        If txtNombre.Text <> lblNombreExtra.Text Then
            Using dt
                dt = bl.FunctionGlobal(":pnombre▓" & txtNombre.Text, "QRYPFL004")
                If dt.Rows.Count >= 2 Then
                    CtlMensajes1.Mensaje("ERROR..: YA EXISTE UN PERFIL CON EL NOMBRE INGRESADO!")
                    Exit Sub
                End If
            End Using
        End If

        bl.FunctionGlobal(":pnombreƒ:pusuarioƒ:pidperfil▓" & txtNombre.Text & "ƒ" & Session("usuario") & "ƒ" & cod, "QRYPFL008")
        bl.FunctionGlobal(":pidperfil▓" & cod, "QRYPFL009")

        For i = 0 To gvAccesos.GV.Rows.Count - 1
            Dim idPantalla = ""
            Dim Menu = ""

            With gvAccesos.GV
                idPantalla = .Rows(i).Cells(4).Text
                Menu = .Rows(i).Cells(5).Text
                If Trim(Menu) = "SEGURIDAD" And countS = 0 Then
                    bl.FunctionGlobal(":pidperfilƒ:pidpantalla▓" & cod & "ƒ" & "01000000", "QRYPFL003")
                    countS += 1
                End If
                If Trim(Menu) = "ADMINISTRACION" And countA = 0 Then
                    bl.FunctionGlobal(":pidperfilƒ:pidpantalla▓" & cod & "ƒ" & "02000000", "QRYPFL003")
                    countA += 1
                End If
                If Trim(Menu) = "PROCESOS" And countP = 0 Then
                    bl.FunctionGlobal(":pidperfilƒ:pidpantalla▓" & cod & "ƒ" & "03000000", "QRYPFL003")
                    countP += 1
                End If
                If Trim(Menu) = "REPORTES" And countR = 0 Then
                    bl.FunctionGlobal(":pidperfilƒ:pidpantalla▓" & cod & "ƒ" & "04000000", "QRYPFL003")
                    countR += 1
                End If
                bl.FunctionGlobal(":pidperfilƒ:pidpantalla▓" & cod & "ƒ" & idPantalla, "QRYPFL003")
            End With
        Next

    End Sub
End Class