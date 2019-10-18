Public Partial Class ChartColumn
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Sub Cargar_Datos(ByVal Dt As DataTable, ByVal titulo As String, ByVal t_x As String, ByVal t_y As String)
        Dim ctl As New BL.Busquedas
        Dim datos As String = ""
        Dim serie As String = ""
        datos = datos & "{'Criterio':'" & t_x & "',"
        For i = 0 To dt.Rows.Count - 1
            If i = 0 Then
                datos = datos & "'" & dt.Rows(i)(0) & "':" & dt.Rows(i)(1)

                serie = serie & "{"
                serie = serie & "type: 'column',"
                serie = serie & "series: ["
                serie = serie & "{ dataField: '" & dt.Rows(i)(0) & "', displayText: '" & dt.Rows(i)(0) & "'}"
                serie = serie & "]"
                serie = serie & "}"
            Else
                datos = datos & ",'" & dt.Rows(i)(0) & "':" & dt.Rows(i)(1)

                serie = serie & ",{"
                serie = serie & "type: 'column',"
                serie = serie & "series: ["
                serie = serie & "{ dataField: '" & dt.Rows(i)(0) & "', displayText: '" & dt.Rows(i)(0) & "'}"
                serie = serie & "]"
                serie = serie & "}"
            End If
        Next
        datos = datos & "}"
        Dim numero_ As Double
        For j = 0 To dt.Rows.Count - 1
            If numero_ < ((Dt.Rows(j)(1))) Then
                numero_ = (Dt.Rows(j)(1))
            End If
        Next

        Dim genera_datos_java As String = ""
        genera_datos_java = genera_datos_java & "var  sampleData = ["
        genera_datos_java = genera_datos_java & datos
        genera_datos_java = genera_datos_java & "   ];"
        genera_datos_java = genera_datos_java & "var settings = {"
        genera_datos_java = genera_datos_java & "   title: '" & titulo & "',"
        genera_datos_java = genera_datos_java & "  description: '',"
        genera_datos_java = genera_datos_java & "	enableAnimations: true,"
        genera_datos_java = genera_datos_java & "   showLegend: true,"
        genera_datos_java = genera_datos_java & "padding: { left: 5, top: 5, right: 5, bottom: 5 },"
        genera_datos_java = genera_datos_java & "titlePadding: { left: 90, top: 0, right: 0, bottom: 10 },"
        genera_datos_java = genera_datos_java & "source: sampleData,"
        genera_datos_java = genera_datos_java & "xAxis:"
        genera_datos_java = genera_datos_java & "   {"
        genera_datos_java = genera_datos_java & "       dataField: 'Criterio',"
        genera_datos_java = genera_datos_java & "       showGridLines: true,"
        genera_datos_java = genera_datos_java & "       valuesOnTicks: false"
        genera_datos_java = genera_datos_java & "   },"
        genera_datos_java = genera_datos_java & "   colorScheme: 'scheme01',"
        genera_datos_java = genera_datos_java & "           valueAxis:"
        genera_datos_java = genera_datos_java & "       {"
        genera_datos_java = genera_datos_java & "           unitInterval: " & (Math.Round(numero_ / 20)).ToString & ","
        genera_datos_java = genera_datos_java & "           minValue: 0,"
        genera_datos_java = genera_datos_java & "           maxValue: " & numero_.ToString & ","
        genera_datos_java = genera_datos_java & "           displayValueAxis: true,"
        genera_datos_java = genera_datos_java & "           description: '" & t_y & "',"
        genera_datos_java = genera_datos_java & "           axisSize: 'auto',"
        genera_datos_java = genera_datos_java & "           tickMarksColor: '#888888'"
        genera_datos_java = genera_datos_java & "       },"
        genera_datos_java = genera_datos_java & "   seriesGroups:"
        genera_datos_java = genera_datos_java & "   ["
        'genera_datos_java = genera_datos_java & "       {"
        'genera_datos_java = genera_datos_java & "           type: 'column',"
        'genera_datos_java = genera_datos_java & "           columnsGapPercent: 50,"
        'genera_datos_java = genera_datos_java & "           seriesGapPercent: 0,"
        'genera_datos_java = genera_datos_java & "       series: ["
        genera_datos_java = genera_datos_java & serie
        'genera_datos_java = genera_datos_java & "               ]"
        'genera_datos_java = genera_datos_java & "       }"
        genera_datos_java = genera_datos_java & "   ]"
        genera_datos_java = genera_datos_java & "};"
        genera_datos_java = genera_datos_java & "$('#" & jqxChart.ClientID & "').jqxChart(settings);"


        Dim javaScript As String = "<script type='text/javascript'>" & _
                    genera_datos_java & _
                    "</script>"
        'Page.ClientScript.RegisterStartupScript(Me.GetType(), "xscript" & jqxChart.ClientID, javaScript, False)
        RaiseEvent Ejecscript(jqxChart.ClientID, genera_datos_java)
    End Sub
    Event Ejecscript(ByVal id As String, ByVal scrpt As String)

End Class