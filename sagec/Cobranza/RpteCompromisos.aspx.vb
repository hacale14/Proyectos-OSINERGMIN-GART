Imports ConDB
Imports Controles
Imports System.Data
Imports System.Data.SqlClient
Imports System.Text
Imports System.IO
Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports iTextSharp.text.html
Imports iTextSharp.text.html.simpleparser
Partial Public Class RpteCompromisos
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub BtnMetas_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnMetas.Click
        Dim Conn As New ConDB.ConSQL
        Dim dt = Conn.Ejecuta_QUERY("select top 1 meta, caida, hgestion  from tmp_cartera where idcartera = " & CtCombo1.Value & " order by anio desc , mes desc , dia desc")
        If Not dt Is Nothing Then
            If dt.Rows.Count > 0 Then
                TextBox1.Text = dt.Rows(0)(0)
                TextBox2.Text = dt.Rows(0)(1)
                TextBox3.Text = dt.Rows(0)(2)
            Else
                TextBox1.Text = ""
                TextBox2.Text = "0"
                TextBox3.Text = "0"
            End If
            lblCaida.Visible = True
            lblHW.Visible = True
            Label3.Visible = True
            TextBox1.Visible = True
            TextBox2.Visible = True
            TextBox3.Visible = True
            BtnMetas0.Visible = True
            dt = Nothing
            Conn = Nothing
        Else
            Label3.Visible = True
            lblcaida.visible = True
            lblhw.visible = True
            TextBox1.Visible = True
            TextBox2.Visible = True
            TextBox3.Visible = True
            TextBox1.Text = "0.00"
            TextBox2.Text = "0"
            TextBox3.Text = "0"
            BtnMetas0.Visible = True
        End If
    End Sub

    Private Sub CtCombo1_Click() Handles CtCombo1.Click
        cboGestor.Limpia()
        Dim Conn As New ConDB.ConSQL
        Dim dt = Conn.Ejecuta_QUERY("select top 1 meta, caida, hgestion from tmp_cartera where idcartera = " & CtCombo1.Value & " order by id desc ")
        If Not dt Is Nothing Then
            If dt.Rows.Count > 0 Then
                cboGestor.Procedimiento = "SQL_N_GEST056"
                cboGestor.Condicion = ":pcriterioidcartera▓" & " and cliente.idcartera = " & CtCombo1.Value
                cboGestor.Cargar_dll()
                For Each e In dt.Rows
                    Label2.Visible = True
                    Label2.Text = e(0) * ((e(1) / 100) + 1)
                    Exit For
                Next
                dt = Nothing
                Conn = Nothing
                Call cboGestor_Click()
            Else
                Label2.Visible = True
                Label2.Text = "0.00"
            End If
        Else
            Label2.Visible = True
            Label2.Text = "0.00"
        End If
    End Sub

    Private Sub BtnMetas0_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnMetas0.Click
        Try
            Dim Conn As New ConDB.ConSQL
            If TextBox1.Text <> "" Then
                Dim dt = Conn.Ejecuta_QUERY("select top 1 meta, id  from tmp_cartera where idcartera = " & CtCombo1.Value & " order by id desc ")
                If Not dt Is Nothing Then
                    If dt.Rows.Count > 0 Then
                        Conn.Ejecuta_QUERY("update tmp_cartera set meta = " & TextBox1.Text & ", caida = " & TextBox2.Text & ", hgestion = " & TextBox3.Text & "  where id= " & dt.Rows(0)(1))
                    Else
                        Conn.Ejecuta_QUERY("insert into tmp_cartera (idcartera, meta, caida, hgestion, anio, mes, dia) values (" & CtCombo1.Value & "," & TextBox1.Text & "," & Val(TextBox2.Text) & "," & Val(TextBox3.Text) & "," & Now().Year & "," & Now().Month & "," & Now().Day & ")")
                    End If
                Else
                    Conn.Ejecuta_QUERY("insert into tmp_cartera (idcartera, meta, caida, hgestion, anio, mes, dia) values (" & CtCombo1.Value & "," & TextBox1.Text & "," & Val(TextBox2.Text) & "," & Val(TextBox3.Text) & "," & Now().Year & "," & Now().Month & "," & Now().Day & ")")
                End If
                BtnMetas0.Visible = False
                TextBox1.Visible = False
                TextBox2.Visible = False
                TextBox3.Visible = False
                lblcaida.visible = False
                lblhw.visible = False
                Label3.Visible = False
                Label2.Visible = True
                Label2.Text = Val(TextBox1.Text) * ((Val(TextBox2.Text) / 100) + 1)
                CtlMensajes1.Mensaje("Datos Grabados con exito", "")
                dt = Nothing
            End If
        Catch ex As Exception
            CtlMensajes1.Mensaje(ex.Message, "")
            Label2.Text = ex.Message
            Label2.Visible = True
        End Try
    End Sub

    Private Sub bTNiR_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles bTNiR.Click
        Dim conCtl As New Controles.General
        Dim Conn As New ConDB.ConSQL
        Dim tc = 3.3
        Dim ArrHor(24, 3) As Double
        Dim dt = conCtl.BuscarSQL(":idcartera▓" & CtCombo1.Value, "QRYRG002")
        If Not dt Is Nothing Then
            If dt.Rows.Count > 1 Then
                For I = 0 To 19
                    For c = 0 To dt.Rows.Count - 1
                        If I = dt.Rows(c)(0) Then
                            ArrHor(I, 1) = dt.Rows(c)(1)
                            ArrHor(I, 2) = Label2.Text
                            ArrHor(I, 3) = dt.Rows(c)(2)
                            Exit For
                        End If
                    Next
                Next
            End If
        End If
        Dim tbl As DataTable = New DataTable("Compromisos")
        Dim column As DataColumn
        Dim row As DataRow

        column = New DataColumn()
        column.DataType = System.Type.GetType("System.String")
        column.ColumnName = "HORA" '-- Nombre de la columna
        column.ReadOnly = True
        tbl.Columns.Add(column)

        column = New DataColumn()
        column.DataType = System.Type.GetType("System.String")
        column.ColumnName = "PDP" '-- Nombre de la columna
        column.ReadOnly = True
        tbl.Columns.Add(column)

        column = New DataColumn()
        column.DataType = System.Type.GetType("System.String")
        column.ColumnName = "META" '-- Nombre de la columna
        column.ReadOnly = True
        tbl.Columns.Add(column)

        column = New DataColumn()
        column.DataType = System.Type.GetType("System.String")
        column.ColumnName = "AVANCE" '-- Nombre de la columna
        column.ReadOnly = True
        tbl.Columns.Add(column)
        Dim MontoAv As Double = 0.0
        Dim MontoPag As Double = 0.0
        For i = 0 To IIf(Now().Hour <= 19, Now().Hour, 19)
            If i > 8 Then
                row = tbl.NewRow()
                MontoAv += Val(ArrHor(i, 1))
                MontoPag += Val(ArrHor(i, 3))
                row("HORA") = Format(i, "00") & ":00"
                row("PDP") = Format(MontoAv, "0,000.00")
                row("META") = Val(Label2.Text)
                row("AVANCE") = Format(MontoAv / Val(Label2.Text), "###.00%")
                tbl.Rows.Add(row)
            Else
                MontoAv += Val(ArrHor(i, 1))
                MontoPag += Val(ArrHor(i, 3))
            End If
        Next
        column = Nothing
        row = Nothing
        Dim view As New DataView(tbl)
        view.Sort = "Hora DESC"
        CtlGrilla1.SourceDataTable = view
        cboGestor_Click()
    End Sub

    Private Sub cboGestor_Click() Handles cboGestor.Click
        Dim cnCtl As New Controles.General
        Dim Conn As New ConDB.ConSQL
        Dim tc = 3.3
        Dim ArrHor(24, 3) As Double
        Dim dt
        If cboGestor.Value = 0 Then
            dt = cnCtl.BuscarSQL(":idcarteraƒ:idusuario▓" & CtCombo1.Value & "ƒ" & "", "QRYRG003")
            'dt = Conn.Ejecuta_QUERY("select concat(Usuario.usuario, ' - ', usuario.Nombres,' ',Usuario.Apellidos) usuario, count(*) Cantidad, sum(case when moneda = 'D' then 3.3 else 1 end * Monto) PDP from cliente, usuariocliente, usuario, Compromiso where cliente.IdCliente = UsuarioCliente.IdCliente  and cliente.IdCliente = Compromiso.idcliente and UsuarioCliente.IdUsuario = Usuario.IdUsuario  and year(fechagenero) = year(getdate()) and month(fechagenero)=  month(getdate()) and  day(fechagenero) = day(getdate()) and cliente.idcartera = " & CtCombo1.Value & " and len(usuario.usuario)=8 and exists (Select 1 from gestion where gestion.idgestion  =  Compromiso.idGestion and convert(varchar(2),fecha,108)>7  )  group by concat(Usuario.usuario, ' - ', usuario.Nombres,' ',Usuario.Apellidos) order by 3 desc")
        Else
            dt = cnCtl.BuscarSQL(":idcarteraƒ:idusuario▓" & CtCombo1.Value & "ƒ" & " And idusuario=" & cboGestor.Value, "QRYRG003")
            'dt = Conn.Ejecuta_QUERY("select concat(Usuario.usuario, ' - ', usuario.Nombres,' ',Usuario.Apellidos) usuario, count(*) Cantidad, sum(case when moneda = 'D' then 3.3 else 1 end * Monto) PDP from cliente, usuariocliente, usuario, Compromiso where cliente.IdCliente = UsuarioCliente.IdCliente  and cliente.IdCliente = Compromiso.idcliente and UsuarioCliente.IdUsuario = Usuario.IdUsuario  and year(fechagenero) = year(getdate()) and month(fechagenero)=  month(getdate()) and  day(fechagenero) = day(getdate()) and cliente.idcartera = " & CtCombo1.Value & " and  usuario.idusuario = " & cboGestor.Value & " and exists (Select 1 from gestion where gestion.idgestion  =  Compromiso.idGestion and convert(varchar(2),fecha,108)>7  )  group by concat(Usuario.usuario, ' - ', usuario.Nombres,' ',Usuario.Apellidos) order by 3 desc")
        End If


        Dim tbl As DataTable = New DataTable("CompromisosGestor")
        Dim column As DataColumn
        Dim row As DataRow

        column = New DataColumn()
        column.DataType = System.Type.GetType("System.String")
        column.ColumnName = "USUARIO" '-- Nombre de la columna
        column.ReadOnly = True
        tbl.Columns.Add(column)

        column = New DataColumn()
        column.DataType = System.Type.GetType("System.String")
        column.ColumnName = "CANT" '-- Nombre de la columna
        column.ReadOnly = True
        tbl.Columns.Add(column)

        column = New DataColumn()
        column.DataType = System.Type.GetType("System.String")
        column.ColumnName = "PDP" '-- Nombre de la columna
        column.ReadOnly = True
        tbl.Columns.Add(column)

        column = New DataColumn()
        column.DataType = System.Type.GetType("System.String")
        column.ColumnName = "META" '-- Nombre de la columna
        column.ReadOnly = True
        tbl.Columns.Add(column)

        column = New DataColumn()
        column.DataType = System.Type.GetType("System.String")
        column.ColumnName = "AVANCE" '-- Nombre de la columna
        column.ReadOnly = True
        tbl.Columns.Add(column)

        column = New DataColumn()
        column.DataType = System.Type.GetType("System.String")
        column.ColumnName = "OBJ(%)" '-- Nombre de la columna
        column.ReadOnly = True
        tbl.Columns.Add(column)


        Dim Cantidad As Double = 0.0
        Dim PDP As Double = 0.0
        Dim Meta As Double = 0.0
        Dim Metagestor As Double = Format(Val(Label2.Text) / (cboGestor.Cbo.Items.Count - 1), "#,###,###.00")

        For i = 0 To dt.rows.count - 1
            row = tbl.NewRow()
            Cantidad += dt.rows(i)(1)
            PDP += dt.rows(i)(2)
            row(0) = dt.rows(i)(0)

            row(1) = Format(dt.rows(i)(1), "#,###,##0")
            row(2) = Format(dt.rows(i)(2), "#,###,###.00")
            row(3) = Format(Metagestor, "#,###,###.00")
            row(4) = Format(dt.rows(i)(2) / Metagestor, "###.00%")
            'row(5) = dt.rows(i)(2) / ((Metagestor / 11) * (Now().Hour - 9 + 1)) * 100
            row(5) = dt.rows(i)(2) / Metagestor * 100
            Meta += row(3)
            tbl.Rows.Add(row)
        Next
        Dim tag = ""
        For i = 0 To cboGestor.Cbo.Items.Count - 1
            If Trim(cboGestor.Cbo.Items(i).Text) <> "" Then
                For rr = 0 To tbl.Rows.Count - 1
                    If tbl.Rows(rr)(0) = cboGestor.Cbo.Items(i).Text Then
                        tag = "1"
                        Exit For
                    End If
                Next
                If tag = "" Then
                    row = tbl.NewRow()
                    row(0) = cboGestor.Cbo.Items(i).Text
                    row(1) = Format(0, "#,###,##0")
                    row(2) = Format(0.0, "#,###,###.00")
                    row(3) = Format(Metagestor, "#,###,###.00")
                    row(4) = Format(0 / Metagestor, "###.00%")
                    'row(5) = 0 / ((Metagestor / 11) * (Now().Hour - 9 + 1)) * 100
                    row(5) = 0 / Metagestor * 100
                    Meta += row(3)
                    tbl.Rows.Add(row)
                End If
                tag = ""
            End If
        Next
        row = tbl.NewRow()
        row(0) = "TOTAL"
        row(1) = Format(Cantidad, "#,###,##0")
        row(2) = Format(PDP, "#,###,###.00")
        row(3) = Format(Meta, "#,###,###.00")
        row(4) = Format(PDP / Meta, "###.00%")
        row(5) = (PDP / Meta) * 100
        tbl.Rows.Add(row)
        CtlGrilla2.SourceDataTable = tbl
        row = Nothing
        column = Nothing
        tbl = Nothing
    End Sub

    Private Sub CtlGrilla2_Boton_Click(ByVal GV As System.Web.UI.WebControls.GridView, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles CtlGrilla2.Boton_Click
        If e.Row.Cells(4).Text <> "USUARIO" Then
            e.Row.Cells(5).VerticalAlign = VerticalAlign.Middle
            e.Row.Cells(6).VerticalAlign = VerticalAlign.Middle
            e.Row.Cells(7).VerticalAlign = VerticalAlign.Middle

            If Val(e.Row.Cells(9).Text) >= 0 Then
                Select Case Val(e.Row.Cells(9).Text)
                    Case Is >= 100
                        e.Row.Cells(9).Text = "<center><img src='Imagenes/circle_green.png' alt='Smiley face' height='12px' width='10px'></center>"
                    Case Is >= 90
                        e.Row.Cells(9).Text = "<center><img src='Imagenes/circle_yellow.png' alt='Smiley face' height='12px' width='10px'></center>"
                    Case Else
                        e.Row.Cells(9).Text = "<center><img src='Imagenes/circle_red.png' alt='Smiley face' height='12px' width='10px'></center>"
                End Select
            End If
        End If
        If e.Row.Cells(4).Text = "TOTAL" Then
            e.Row.Cells(4).Font.Bold = True
            e.Row.Cells(5).Font.Bold = True
            e.Row.Cells(6).Font.Bold = True
            e.Row.Cells(7).Font.Bold = True
            e.Row.Cells(8).Font.Bold = True
            e.Row.Cells(4).BackColor = Drawing.Color.Yellow
            e.Row.Cells(5).BackColor = Drawing.Color.Yellow
            e.Row.Cells(6).BackColor = Drawing.Color.Yellow
            e.Row.Cells(7).BackColor = Drawing.Color.Yellow
            e.Row.Cells(8).BackColor = Drawing.Color.Yellow
            e.Row.Cells(9).BackColor = Drawing.Color.Yellow
        End If
    End Sub

    Private Sub Timer1_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Call cboGestor_Click()
        Call bTNiR_Click(sender, e)
    End Sub

    
    Private Sub BtnExportar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnExportar.Click
        Dim cnCtl As New Controles.General
        Dim dt = cnCtl.BuscarSQL(":idcartera▓" & CtCombo1.Value, "QRYRG004")
        Session("dt") = dt
        Dim strScript = "window.open('Exporta.aspx?Tipo=XLSX','vb');"
        ScriptManager.RegisterStartupScript(Me, Me.GetType, "SCR" & Me.ClientID, strScript, True)
    End Sub
End Class