Public Partial Class Chart
    Inherits System.Web.UI.UserControl
    Dim _TablaCarga As DataTable

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Sub CargarDataTable(ByVal titulo As String, ByVal TituloX As String, ByVal TituloY As String)
        GraficoBar(TablaCarga, titulo, TituloX, TituloY)
    End Sub

    Public Property TablaCarga() As DataTable
        Get
            Return _TablaCarga
        End Get
        Set(ByVal value As DataTable)
            _TablaCarga = value
        End Set
    End Property

    Sub GraficoBar(ByVal dt As DataTable, ByVal Titulo As String, ByVal ejeX As String, ByVal ejeY As String)

        lblTitulo.Text = Titulo

        lblEjeX.Text = ejeX
        lblEjeY.Text = ejeY

        Dim criterio_horizontal As String = ""
        Dim criterio_datos As String = ""
        Dim pindice As Integer = 1
        place.Controls.Clear()
        place.Controls.Add(New LiteralControl("<table>"))

        For i = 0 To dt.Rows.Count - 1
            AgregarEtiqueta(i + 1, dt.Rows(i)(0).ToString, pindice)

            If pindice = 3 Then
                pindice = 1
            Else
                pindice = pindice + 1
            End If

            If i = 0 Then
                criterio_horizontal = "'" & i + 1 & "'"
                criterio_datos = dt.Rows(i)(1).ToString
            Else
                criterio_horizontal = criterio_horizontal & ",'" & i + 1 & "'"
                criterio_datos = criterio_datos & "," & dt.Rows(i)(1).ToString
            End If
        Next

        place.Controls.Add(New LiteralControl("</table>"))
        Dim javaScript As String = "<script type='text/javascript'>" & _
            "var barChartData = {" & _
                "labels: [" & criterio_horizontal & "]," & _
                "datasets: [" & _
                "{" & _
                "fillColor : '#002BFF'," & _
                "strokeColor : 'rgba(151,187,205,0.8)'," & _
                "highlightFill: 'rgba(151,187,205,0.75)'," & _
                "highlightStroke: 'rgba(151,187,205,1)'," & _
                "data: [" & criterio_datos & "]" & _
                "}" & _
                 "]" & _
            "};" & _
            "var ctx = document.getElementById('myChart').getContext('2d');" & _
            "window.myBar = new Chart(ctx).Bar(barChartData, {" & _
                "responsive : true," & _
                "scaleShowHorizontalLines: false," & _
                "barStrokeWidth : 2," & _
                "barValueSpacing : 10," & _
                "scaleFontSize: 9," & _
                "tooltipTemplate: '<%if (label){%><%=label%>: <%}%><%= value %>'," & _
                "scaleShowVerticalLines: false" & _
            "});" & _
            "" & _
            "myChart.onclick = function(evt){" & _
            "var activeBars = myBar.getBarsAtEvent2(evt);" & _
            "alert(activeBars[0].value);" & _
            "};" & _
            "</script>"
        Page.ClientScript.RegisterStartupScript(Me.GetType(), "script", javaScript, False)
    End Sub

    Sub AgregarEtiqueta(ByVal ind As Integer, ByVal valor As String, ByVal indice As String)
        If indice = 1 Then
            place.Controls.Add(New LiteralControl("<tr>"))
        End If
        place.Controls.Add(New LiteralControl("<td align='left' style='text-align:left'>"))
        Dim etiqueta As New Label
        etiqueta.ID = "lbl" & ind
        etiqueta.Text = ind & ".- " & valor
        etiqueta.Style.Add("padding", "1em")
        place.Controls.Add(etiqueta)
        place.Controls.Add(New LiteralControl("</td>"))
        If indice = 3 Then
            place.Controls.Add(New LiteralControl("</tr>"))
        End If
    End Sub
End Class