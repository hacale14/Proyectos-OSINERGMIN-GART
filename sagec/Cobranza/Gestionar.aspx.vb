Imports Controles
Partial Public Class Gestionar
    Inherits System.Web.UI.Page
    Dim idCliente As String = ""
    Dim idCartera As String = ""
    Public Efectividad As Integer
    Public Cobertura As Integer
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Not Me.IsPostBack Then
                Dim dt As DataTable
                Dim TipoCartera As String = UCase(Request.QueryString("tipocartera"))
                cbocartera.Condicion = ":criterio▓" & TipoCartera
                idCliente = Request.QueryString("idCliente")
                idCartera = Request.QueryString("Cartera")
                If Not Me.IsPostBack Then
                    Dim ctl As New Controles.General
                    dt = ctl.FncCliente(idCliente)
                    If Not dt Is Nothing Then
                        'Cliente.IdCliente, Cartera.NomCartera, Condicion.Codigo, Cliente.Situacion,  Cliente.Dni, Cliente.NombreCliente,  Cliente.Direccion, Cliente.Telefono1,  Cliente.Celular,Cliente.Celular2,  Estado.NombreEstado, Provincia.Nombreprovincia,  Distrito.Nombredistrito,Cliente.Edad, Cliente.Sueldo,Cliente.Expediente,Cliente.Juzgado,  Cliente.TipoContacto,Cartera.IdCartera,Cliente.ACampo
                        cbocartera.Text = dt(0)("NomCartera")
                        txtDNI.Text = idCliente
                        txtnombre.Text = dt(0)("NombreCliente")
                        txtsitua.Text = dt(0)("Situacion")
                        txtnombre.Ancho = "400"
                        txtDNI.Text = idCliente

                        Dim dta As DataTable = ctl.Obtiene_Datos_adicionales(dt(0)(0))
                        If Not dta Is Nothing Then
                            txtCentroLaboral.Text = IIf(IsDBNull(dta(0)("centrolaboral")), "", dta(0)("centrolaboral"))
                            txtemail.Text = IIf(IsDBNull(dta(0)("email")), "", dta(0)("email"))
                            txt1erProd.Text = IIf(IsDBNull(dta(0)("Conyugie")), "", dta(0)("Conyugie"))
                            txtEdad.Text = IIf(IsDBNull(dta(0)("Edad")), "", dta(0)("Edad"))
                            txtIngreso.Text = IIf(IsDBNull(dta(0)("Sueldo")), "", dta(0)("Sueldo"))
                            txtAval.Text = IIf(IsDBNull(dta(0)("aval")), "", dta(0)("aval"))
                            txtRepresentanteLegal.Text = IIf(IsDBNull(dta(0)("RepLegal")), "", dta(0)("RepLegal"))
                        End If
                        dta = Nothing
                        Call ctl.Telefono_grilla(dt(0)(0), CtlTelefono)
                        Call ctl.Direccion_grilla(dt(0)(0), CtlDireccion)
                        Call ctl.Anotaciones_grilla(dt(0)(0), CtlAnotaciones)
                        Call ctl.Gestion_Campo_grilla(dt(0)(0), CtlGestionCampo)
                        'Call ctl.Estadistica_grilla(dt(0)(0), Request.QueryString("gestor"), dt(0)("NomCartera"), CtlEstadistica)
                        If TipoCartera = "ACTIVA" Then
                            Call ctl.Deuda_Activa_grilla(dt(0)(0), CtlDeuda)
                        Else
                            Call ctl.Deuda_Castigo_grilla(dt(0)(0), CtlDeuda)
                        End If
                        Call ctl.Gestion_Telefono_grilla(dt(0)(0), CtlGestionTelefonica)
                        dt = Nothing
                    Else
                        '"""
                    End If
                End If
            End If
        Catch ex As Exception

        End Try
        'CtlGrilla1.SourceDataTable
    End Sub

    Sub Carga_Datos()
        'If CtlCboCondicion1.Text = "UT" Or CtlCboCondicion1.Text = "PP" Or CtlCboCondicion1.Text = "LL" Or CtlCboCondicion1.Text = "CO" Or dcbCondicion.Text = "PI" Then
        ' cboTipoContacto.Visible = True
        ' lblTipoContacto.Visible = True
        ' Else
        ' cboTipoContacto.Visible = False
        ' lblTipoContacto.Visible = False
        ' End If

    End Sub
    Sub Seleccionar(ByVal sender As Object, ByVal e As EventArgs)

    End Sub

    Private Sub CtlTelefono_Boton_Click(ByVal GV As System.Web.UI.WebControls.GridView, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles CtlTelefono.Boton_Click
        Dim COL As Integer = 13
        Dim COL1 As Integer = 18
        If e.Row.Cells(COL).Text = "Prioridad" Then
            For c = 5 To e.Row.Cells.Count - 1
                e.Row.Cells(c).Text = UCase(e.Row.Cells(c).Text)
            Next
            e.Row.Cells(COL).Text = " EST "
            e.Row.Cells(COL1).Text = " ACC "
            e.Row.Cells(2).Text = "UP"
            e.Row.Cells(3).Text = "EL"
            e.Row.Cells(7).Text = "TELEFONOS"
            e.Row.Cells(7).Width = "200"
            Exit Sub
        End If
        For c = 5 To e.Row.Cells.Count - 1
            If c = COL Then
                Select Case e.Row.Cells(c).Text
                    Case "R"
                        e.Row.Cells(c).Text = "<center><img src='Imagenes/circle_red.png' alt='Smiley face' height='15px' width='15px'></center>"
                    Case "A"
                        e.Row.Cells(c).Text = "<center><img src='Imagenes/circle_yellow.png' alt='Smiley face' height='15px' width='15px'></center>"
                    Case "&#254;"
                        e.Row.Cells(c).Text = "<center><img src='Imagenes/circle_green.png' alt='Smiley face' height='15px' width='15px'></center>"
                    Case Else
                        e.Row.Cells(c).Text = "<center><img src='Imagenes/circle_grey.png' alt='Smiley face' height='15px' width='15px'></center>"
                End Select
            End If
            If c = COL1 Then
                Dim ctl As New Controles.General
                e.Row.Cells(c).Text = "<center><img src='Imagenes/imgCall3.png' id='imgButton' alt='Smiley face' height='20px' width='20px' onclick=LlamarTelefono('" & ctl.ValidaNumero(e.Row.Cells(7).Text) & "','imgButton')></center>"
                '"<center><asp:ImageButton ID=""ImgCall6"" runat=""server"" Visible=""true"" ImageUrl=""~/Imagenes/imgCall3.png"" Width=""15px"" Height=""15px"" OnClick=""Seleccionar""/></center>"
                ctl = Nothing
                '
            End If
            If e.Row.Cells(15).Text = "R" Then                
                e.Row.Cells(c).Text = "<b>" & e.Row.Cells(c).Text
            End If
        Next
    End Sub

    Private Sub CtlDireccion_Boton_Click(ByVal GV As System.Web.UI.WebControls.GridView, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles CtlDireccion.Boton_Click
        If e.Row.Cells(6).Text = "Direccion" Then
            e.Row.Cells(6).Width = "400"
            e.Row.Cells(7).Width = "150"
            e.Row.Cells(12).Width = "150"
            e.Row.Cells(13).Width = "150"
            For c = 5 To e.Row.Cells.Count - 1
                e.Row.Cells(c).Text = UCase(e.Row.Cells(c).Text)
            Next
        End If
    End Sub

    Private Sub CtlAnotaciones_Boton_Click(ByVal GV As System.Web.UI.WebControls.GridView, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles CtlAnotaciones.Boton_Click
        If e.Row.Cells(4).Text = "FECHA" Then
            e.Row.Cells(4).Width = "100"
            e.Row.Cells(5).Width = "70"
            e.Row.Cells(6).Width = "500"
            For c = 5 To e.Row.Cells.Count - 1
                e.Row.Cells(c).Text = UCase(e.Row.Cells(c).Text)
            Next
        End If
    End Sub

    Private Sub CtlGestionTelefonica_Boton_Click(ByVal GV As System.Web.UI.WebControls.GridView, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles CtlGestionTelefonica.Boton_Click
        Dim l As Integer = 3
        If UCase(e.Row.Cells(l + 1).Text) = "FECHA" Then
            e.Row.Cells(l + 1).Text = "FECHA"
            e.Row.Cells(l + 2).Text = "HORA"
            e.Row.Cells(l + 3).Text = "TIPO"
            e.Row.Cells(l + 4).Text = "OPER."
            e.Row.Cells(l + 5).Text = "IND"
            e.Row.Cells(l + 6).Text = "TELEFONO"
            e.Row.Cells(l + 7).Text = "DESCRIPCION DE LA GESTION"
            e.Row.Cells(l + 8).Text = "USUARIO"

            e.Row.Cells(l + 1).Width = "20"
            e.Row.Cells(l + 2).Width = "40"
            e.Row.Cells(l + 3).Width = "10"
            e.Row.Cells(l + 4).Width = "10"
            e.Row.Cells(l + 5).Width = "10"
            e.Row.Cells(l + 7).Width = "500"
        Else
            e.Row.Cells(l + 1).Text = Format(CDate(e.Row.Cells(l + 1).Text), "dd/MM/yyyy")
            e.Row.Cells(l + 2).Text = Format(CDate(e.Row.Cells(l + 1).Text), "hh:mm:ss")
        End If
    End Sub

    Private Sub CtlEstadistica_Boton_Click(ByVal GV As System.Web.UI.WebControls.GridView, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles CtlEstadistica.Boton_Click
        If UCase(e.Row.Cells(4).Text) = "TOTAL" Then
            e.Row.Cells(5).Text = "CANTIDAD"
            e.Row.Cells(6).Text = "(%)COB"
            e.Row.Cells(4).Width = "50"
            e.Row.Cells(5).Width = "50"
            e.Row.Cells(6).Width = "50"
            e.Row.Cells(4).BackColor = System.Drawing.Color.Orange
            e.Row.Cells(5).BackColor = System.Drawing.Color.Orange
            e.Row.Cells(6).BackColor = System.Drawing.Color.Orange

        ElseIf UCase(e.Row.Cells(4).Text) = "META" Then
            e.Row.Cells(4).Text = "<center>META</center>"
            e.Row.Cells(5).Text = "<center>PAGOS</center>"
            e.Row.Cells(6).Text = "<center>(%)EFE</center>"
            e.Row.Cells(4).BackColor = System.Drawing.Color.Orange
            e.Row.Cells(5).BackColor = System.Drawing.Color.Orange
            e.Row.Cells(6).BackColor = System.Drawing.Color.Orange

            'e.Row.Cells(4).BackColor = System.Drawing.Color.FromName("#565C54")
            'e.Row.Cells(5).BackColor = System.Drawing.Color.FromName("#565C54")
            'e.Row.Cells(6).BackColor = System.Drawing.Color.FromName("#565C54")
            e.Row.Cells(4).ForeColor = System.Drawing.Color.White
            e.Row.Cells(5).ForeColor = System.Drawing.Color.White
            e.Row.Cells(6).ForeColor = System.Drawing.Color.White
            e.Row.Cells(4).HorizontalAlign = HorizontalAlign.Center
            e.Row.Cells(5).HorizontalAlign = HorizontalAlign.Center
            e.Row.Cells(6).HorizontalAlign = HorizontalAlign.Center
        Else
            e.Row.Cells(4).BackColor = System.Drawing.Color.White
            e.Row.Cells(5).BackColor = System.Drawing.Color.White
            e.Row.Cells(6).BackColor = System.Drawing.Color.White
            If e.Row.RowIndex = 0 Then
                Cobertura = e.Row.Cells(6).Text
            ElseIf e.Row.RowIndex = 2 Then
                Efectividad = e.Row.Cells(6).Text
            End If
            Dim strScript = "<script>drawGauge();</script>"
            ScriptManager.RegisterStartupScript(Me, Me.GetType, "MyScript1", strScript, True)
            e.Row.Cells(4).Text = "<center>" & e.Row.Cells(4).Text & "<center>"
            e.Row.Cells(5).Text = "<center>" & e.Row.Cells(5).Text & "<center>"
            e.Row.Cells(6).Text = "<center>" & e.Row.Cells(6).Text & "<center>"
        End If
    End Sub

    Private Sub CtlDeuda_Boton_Click(ByVal GV As System.Web.UI.WebControls.GridView, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles CtlDeuda.Boton_Click
        e.Row.Cells(4).Font.Size = 10
        e.Row.Cells(5).Font.Size = 10
        e.Row.Cells(6).Font.Size = 10
        e.Row.Cells(4).Font.Bold = False
        e.Row.Cells(5).Font.Bold = False
        e.Row.Cells(6).Font.Bold = False
        e.Row.Cells(4).Font.Name = "Arial Narrow"
        e.Row.Cells(5).Font.Name = "Arial Narrow"
        e.Row.Cells(6).Font.Name = "Arial Narrow"
        If e.Row.Cells(4).Text = "Deuda V. S/." Then
            e.Row.Cells(5).Text = "Deuda V. US$"
            e.Row.Cells(6).Text = "Deuda Total S/."
            e.Row.Cells(4).Width = "50"
            e.Row.Cells(5).Width = "50"
            e.Row.Cells(6).Width = "50"
            e.Row.Cells(4).BackColor = System.Drawing.Color.Orange
            e.Row.Cells(5).BackColor = System.Drawing.Color.Orange
            e.Row.Cells(6).BackColor = System.Drawing.Color.Orange
        ElseIf e.Row.Cells(4).Text = "Deuda V. US$." Then
            e.Row.Cells(4).Text = "<center>Deuda V. US$.</center>"
            e.Row.Cells(5).Text = "<center>Deuda V. S/.</center>"
            e.Row.Cells(6).Text = "<center>Deuda Total US$</center>"
            e.Row.Cells(4).BackColor = System.Drawing.Color.Orange
            e.Row.Cells(5).BackColor = System.Drawing.Color.Orange
            e.Row.Cells(6).BackColor = System.Drawing.Color.Orange
            e.Row.Cells(4).ForeColor = System.Drawing.Color.White
            e.Row.Cells(5).ForeColor = System.Drawing.Color.White
            e.Row.Cells(6).ForeColor = System.Drawing.Color.White
            e.Row.Cells(4).HorizontalAlign = HorizontalAlign.Center
            e.Row.Cells(5).HorizontalAlign = HorizontalAlign.Center
            e.Row.Cells(6).HorizontalAlign = HorizontalAlign.Center
        Else
            e.Row.Cells(4).BackColor = System.Drawing.Color.White
            e.Row.Cells(5).BackColor = System.Drawing.Color.White
            e.Row.Cells(6).BackColor = System.Drawing.Color.White
            e.Row.Cells(4).Text = "<center>" & e.Row.Cells(4).Text & "</center>"
            e.Row.Cells(5).Text = "<center>" & e.Row.Cells(5).Text & "</center>"
            e.Row.Cells(6).Text = "<center>" & e.Row.Cells(6).Text & "</center>"
        End If
    End Sub
End Class