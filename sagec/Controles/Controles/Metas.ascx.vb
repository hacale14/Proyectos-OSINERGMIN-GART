Public Partial Class Metas
    Inherits System.Web.UI.UserControl
    Dim PrimerDiaMes As String
    Public TipoUsuarioActual As String
    Dim blMetas As New BL.Metas
    Public Property Titulo() As String
        Get
            Return lblTituloControl.Text
        End Get
        Set(ByVal value As String)
            lblTituloControl.Text = value
        End Set
    End Property
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            cargar_combo(cboGestor, "QRYCM001", "")
            PrimerDiaMes = CDate("01/" + Format(Month(DateTime.Now), "00") + "/" + Format(Year(DateTime.Now), "0000"))
            txtFechaInicio.Text = CStr(PrimerDiaMes)
            txtFechaFin.Text = CStr(Format(DateTime.Now, "dd/MM/yyyy"))
            ' Sessiones!
            If Session("TipoUsuario") = "GESTOR" Then
                cboGestor.Value = Session("idusuario")
                cboGestor.Activa = False
            End If
            'QRYTC001
        End If
    End Sub

    Private Sub btnEjecutar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnEjecutar.Click
        Dim Dt As New DataTable
        Dim Porcentaje As Double = 0
        Try
            Using Dt
                Dim Fecha_Inicio As String = txtFechaInicio.Text
                Dim Fecha_Fin As String = txtFechaFin.Text
                Dt = blMetas.GenerarReporte(Session("TipoUsuario"), Session("idusuario"), cboGestor.Text, cboGestor.Value, Fecha_Inicio, Fecha_Fin)
                'lblSubTitulo.Text = "Existe(n) " & Dt.Rows.Count & " Registros"
                gvMetas.SourceDataTable = Dt
            End Using
            txtTotalMetas.Text = Format(blMetas.SumaMeta, "#,##0.00")
            txtTotalPagos.Text = Format(blMetas.SumaCobro, "#,##0.00")
            If blMetas.SumaMeta > 0 Then
                Porcentaje = (blMetas.SumaCobro / blMetas.SumaMeta) * 100
                txtAvance.Text = Format(Porcentaje, "0.00") & " %"
            Else
                txtAvance.Text = "0 %"
            End If
        Catch ex As Exception
            Dim mensaje = "Error..:" & ex.Message
        End Try
        
    End Sub

    Private Sub btnCerrar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnCerrar.Click
        Me.Visible = False
    End Sub

    Private Sub cargar_combo(ByVal Combo As CtCombo, ByVal procedimiento As String, ByVal condicion As String, Optional ByVal Ap As Boolean = False)
        With Combo
            .Limpia()
            .Procedimiento = procedimiento
            .Condicion = condicion
            .Activa = True
            .Cargar_dll()
        End With
    End Sub
End Class