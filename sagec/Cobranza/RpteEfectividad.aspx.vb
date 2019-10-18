Imports ConDB
Imports System.Net
Imports System.Web.UI.WebControls
Imports System
Imports System.Configuration
Imports System.Object
Imports System.Web.UI.Control
Imports System.Web.UI.ScriptManager
Imports System.Web.UI

Partial Public Class RpteEfectividad
    Inherits System.Web.UI.Page
    Public VarMenu As String
    Public VarSubMenu As String
    Public idcartera As String
    Public Hora As Integer
    Sub obtienAccesos()
        'Dim ipValido As String = ConfigurationManager.ConnectionStrings("IpValido").ConnectionString
        If Not Me.IsPostBack Then
            'Dim ip As String = Request.ServerVariables("REMOTE_ADDR").ToString()
            'If Not InStr(1, ipValido, ip) Then
            ' Response.Redirect("SinAcceso.aspx")
            'End If
        End If
    End Sub
    
    Protected Sub CheckBox1_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles CheckBox1.CheckedChanged
        Dim objConSQL As New ConDB.ConSQL
        Dim xsql = "SELECT NOMCARTERA as CARTERA, TIPOCARTERA as TIPO, FORMAT(METACARTERA,'#,###,###.00') as META  FROM CARTERA where tipoCartera ='" & IIf(CheckBox1.Checked, "CASTIGO", "ACTIVA") & "' AND ESTADO <> 'E' ORDER BY 2,1"
        GridView1.DataSource = objConSQL.Ejecuta_QUERY(xsql)
        GridView1.DataBind()

        'Chart1.TablaCarga = dt
        'Chart1.CargarDataTable("Avance diario por Produccion -  " & MonthName(Month(Now())) & " - " & Year(Now()), "Pagos", "Dia")
    End Sub

    Function obtener_ip()
        Dim strHostName As String = Dns.GetHostName()
        Dim ipEntry As IPHostEntry = Dns.GetHostEntry(strHostName)

        Dim ip As String = Convert.ToString(ipEntry.AddressList(ipEntry.AddressList.Length - 1))

        'Find IP Address Behind Proxy Or Client Machine In ASP.NET  
        Dim IPAdd As String = String.Empty
        IPAdd = Request.ServerVariables("HTTP_X_FORWARDED_FOR")

        If String.IsNullOrEmpty(IPAdd) Then
            IPAdd = Request.ServerVariables("REMOTE_ADDR")
            ip = IPAdd
        End If
        Return ip
    End Function
    Protected Sub RadioButton1_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles RadioButton1.CheckedChanged
        Dim xsql As String = ""
        Dim conn As New ConDB.ConSQL
        Dim chkbox As CheckBox = CType(sender, CheckBox)

        If Not CheckBox1.Checked Then
            xsql = "select Operacion.Producto PRODUCTO, SUM(case when PAGO.moneda ='S' THEN 1 ELSE 3.45 END * ISNULL(PAGO.MONTO,0)) MONTO from Pago inner join operacion ON pago.idcliente = operacion.IdCliente inner join cliente on cliente.IdCliente = operacion.IdCliente   inner join cartera on cartera.IdCartera = cliente.IdCartera Where cartera.nomcartera in (:cadena) and CONVERT(VARCHAR(6),pago.FechaPago,112) IN (:FECHAS) group by Operacion.Producto "
        Else
            xsql = "select Operacion2.Producto PRODUCTO, SUM(case when PAGO.moneda ='S' THEN 1 ELSE 3.45 END * ISNULL(PAGO.MONTO,0)) MONTO from Pago inner join operacion2 ON pago.idcliente = operacion2.IdCliente inner join cliente on cliente.IdCliente = operacion2.IdCliente   inner join cartera on cartera.IdCartera = cliente.IdCartera Where cartera.nomcartera in (:cadena) and CONVERT(VARCHAR(6),pago.FechaPago,112) IN (:FECHAS) group by Operacion2.Producto "
        End If
        Dim cadenacarr As String = ""
        For Each rw1 As GridViewRow In GridView1.Rows
            If chkbox.Checked = True Then
                Dim ChBx As CheckBox = CType(rw1.FindControl("ChkBox"), CheckBox)
                If ChBx.Checked = True Then
                    cadenacarr &= IIf(cadenacarr = "", "", ",")
                    cadenacarr &= "'" & rw1.Cells(1).Text & "'"
                End If
            End If
        Next
        Dim cadenaperiodo As String = ""
        For Each rw1 As GridViewRow In GridView3.Rows
            If chkbox.Checked = True Then
                Dim ChBx As CheckBox = CType(rw1.FindControl("ChkBox"), CheckBox)
                If ChBx.Checked = True Then
                    cadenaperiodo &= IIf(cadenaperiodo = "", "", ",")
                    cadenaperiodo &= "'" & rw1.Cells(1).Text & format(val(rw1.Cells(2).Text), "00") & "'"
                End If
            End If
        Next
        If RadioButton1.Checked Then
            Dim dt As DataTable = conn.Ejecuta_QUERY(xsql.Replace(":cadena", cadenacarr).replace(":FECHAS", cadenaperiodo))
            Cargar_Datos(dt, "Avance de produccion por Producto ", "Pagos", "Dia")
        End If
        RadioButton1.Checked = False
        RadioButton2.Checked = False
        RadioButton3.Checked = False
        RadioButton4.Checked = False
        RadioButton5.Checked = False
    End Sub

    Sub Cargar_Datos(ByVal Dt As DataTable, ByVal titulo As String, ByVal t_x As String, ByVal t_y As String)
        ChkAcumumulativo.Visible = False
        Dim ctl As New BL.Busquedas
        Dim datos As String = ""
        Dim serie As String = ""
        datos = datos & "{'Criterio':'" & t_x & "',"
        If Dt Is Nothing Then Exit Sub
        For i = 0 To Dt.Rows.Count - 1
            If i = 0 Then
                datos = datos & "'" & Dt.Rows(i)(0) & "':" & Dt.Rows(i)(1)

                serie = serie & "{"
                serie = serie & "type: 'column',"
                serie = serie & "series: ["
                serie = serie & "{ dataField: '" & Dt.Rows(i)(0) & "', displayText: '" & Dt.Rows(i)(0) & "'}"
                serie = serie & "]"
                serie = serie & "}"
            Else
                datos = datos & ",'" & Dt.Rows(i)(0) & "':" & Dt.Rows(i)(1)

                serie = serie & ",{"
                serie = serie & "type: 'column',"
                serie = serie & "series: ["
                serie = serie & "{ dataField: '" & Dt.Rows(i)(0) & "', displayText: '" & Dt.Rows(i)(0) & "'}"
                serie = serie & "]"
                serie = serie & "}"
            End If
        Next
        datos = datos & "}"
        Dim numero_ As Double
        For j = 0 To Dt.Rows.Count - 1
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
        genera_datos_java = genera_datos_java & "$('#jqxChart').jqxChart(settings);"


        Dim javaScript As String = "<script type='text/javascript'>$(document).ready(function () {" & _
                    genera_datos_java & _
                    "});</script>"
        Page.ClientScript.RegisterStartupScript(Me.GetType(), "xscript", javaScript, False)
        RadioButton2.Checked = False
    End Sub
    Public Sub Carga_grafico_Circular(ByVal dt As DataTable, ByVal Titulo As String, ByVal SubTitulo As String)
        Dim monto As Double = 0.0
        For i = 0 To dt.Rows.Count - 1
            monto += dt.Rows(i)(1)
        Next
        For i = 0 To dt.Rows.Count - 1
            If i = 0 Then
                Graba_Log("datos.txt", dt.Rows(i)(0) & ", " & Format(dt.Rows(i)(1), "##0.00"), 2, True)
            Else
                Graba_Log("datos.txt", dt.Rows(i)(0) & ", " & Format(dt.Rows(i)(1), "##0.00"), 8, True)
            End If
        Next

        Dim StrFile As String = "GrafCircular.js"

        Graba_Log(StrFile, "$(document).ready(function () {", 2, True)
        Graba_Log(StrFile, "// prepare chart data as an array", 8, True)
        Graba_Log(StrFile, "var source =", 8, True)
        Graba_Log(StrFile, "{", 8, True)
        Graba_Log(StrFile, "datatype: 'csv',", 8, True)
        Graba_Log(StrFile, "datafields: [", 8, True)
        Graba_Log(StrFile, "{ name: 'Browser' },", 8, True)
        Graba_Log(StrFile, "{ name: 'Share' }", 8, True)
        Graba_Log(StrFile, "],", 8, True)
        Graba_Log(StrFile, "url:'datos.txt'", 8, True)
        Graba_Log(StrFile, "};", 8, True)

        Graba_Log(StrFile, "var dataAdapter = new $.jqx.dataAdapter(source, { async: false, autoBind: true, loadError: function (xhr, status, error) { alert('Error loading ""' + source.url + '"" : ' + error); } });", 8, True)

        Graba_Log(StrFile, "// prepare jqxChart settings", 8, True)
        Graba_Log(StrFile, "var settings = {", 8, True)
        Graba_Log(StrFile, "title: '" & Titulo.ToString & "',", 8, True)
        Graba_Log(StrFile, "description: '(" & SubTitulo.ToString & ")',", 8, True)
        Graba_Log(StrFile, "enableAnimations: true,", 8, True)
        Graba_Log(StrFile, "showLegend: true,", 8, True)
        Graba_Log(StrFile, "showBorderLine: true,", 8, True)
        Graba_Log(StrFile, "legendLayout: { left: 700, top: 160, width: 300, height: 200, flow: 'vertical' },", 8, True)
        Graba_Log(StrFile, "padding: { left: 5, top: 5, right: 5, bottom: 5 },", 8, True)
        Graba_Log(StrFile, "titlePadding: { left: 0, top: 0, right: 0, bottom: 10 },", 8, True)
        Graba_Log(StrFile, "source: dataAdapter,", 8, True)
        Graba_Log(StrFile, "colorScheme:  'scheme03',", 8, True)
        Graba_Log(StrFile, "seriesGroups:", 8, True)
        Graba_Log(StrFile, "[", 8, True)
        Graba_Log(StrFile, "{", 8, True)
        Graba_Log(StrFile, "type:   'pie',", 8, True)
        Graba_Log(StrFile, "showLabels: true,", 8, True)
        Graba_Log(StrFile, "series:", 8, True)
        Graba_Log(StrFile, "[", 8, True)
        Graba_Log(StrFile, "{ ", 8, True)
        Graba_Log(StrFile, "dataField:  'Share',", 8, True)
        Graba_Log(StrFile, "displayText:  'Browser',", 8, True)
        Graba_Log(StrFile, "labelRadius: 170,", 8, True)
        Graba_Log(StrFile, "initialAngle: 15,", 8, True)
        Graba_Log(StrFile, "radius: 145,", 8, True)
        Graba_Log(StrFile, "centerOffset: 0,", 8, True)
        Graba_Log(StrFile, "formatFunction: function (value) {", 8, True)
        Graba_Log(StrFile, "if (isNaN(value)) ", 8, True)
        Graba_Log(StrFile, "return value;", 8, True)
        Graba_Log(StrFile, "return parseFloat(value);", 8, True)
        Graba_Log(StrFile, "},}]}]", 8, True)
        Graba_Log(StrFile, "};", 8, True)

        Graba_Log(StrFile, "// setup the chart", 8, True)
        Graba_Log(StrFile, "$('#jqxChart').jqxChart(settings);", 8, True)
        Graba_Log(StrFile, "});", 8, True)

        Dim javaScript As String = "<script type='text/javascript' src='GrafCircular.js'></script>"
        Page.ClientScript.RegisterStartupScript(Me.GetType(), "xscript", javaScript, False)
    End Sub
    Public Sub Carga_grafico_lineal(ByVal dt As DataTable, ByVal Tipo As String)
        Dim genera_datos_java As String = ""
        Dim Arr(31, 12) As Double
        Dim ArrP(12) As String
        Dim StrFile As String = "GrafLineal.js"
        'Graba_Log(StrFile, "<script type='text/javascript'>", 2, True)
        Graba_Log(StrFile, "$(document).ready(function () {", 2, True)
        Graba_Log(StrFile, "// prepare chart data as an array", 8, True)
        Graba_Log(StrFile, "var sampleData = [", 8, True)

        Dim Periodo = ""
        Dim intPeriodo = 0
        Dim MontoMax As Double = 0.0
        Dim AMontoMax(12) As Double
        For i = 0 To dt.Rows.Count - 1

            If Periodo <> dt.Rows(i)("Periodo") Then
                intPeriodo += 1
                ArrP(intPeriodo) = dt.Rows(i)("Periodo")
            End If

            Arr(dt.Rows(i)("Dia"), intPeriodo) = dt.Rows(i)("Monto")
            If MontoMax < dt.Rows(i)("Monto") Then
                MontoMax = dt.Rows(i)("Monto")
            End If
            Periodo = dt.Rows(i)("Periodo")
        Next
        Dim NumMax = MontoMax + 1
        Dim grupo = Val("1".ToString.PadRight(Len(Str(Convert.ToInt32(NumMax))) - 1, "0"))

        Dim MAcumu(12) As Double
        For i = 1 To 31
            Dim DetPeriodo As String = ""
            For n = 1 To intPeriodo
                If Tipo = "A" Then
                    MAcumu(n) += Arr(i, n)
                Else
                    MAcumu(n) = Arr(i, n)
                End If
                DetPeriodo += ArrP(n) & ": " & MAcumu(n) & ", "
            Next
            Graba_Log(StrFile, "{ Day: '" & Format(i, "00").ToString & "', " & DetPeriodo & " Cycling: 25, Goal: 40 }" & IIf(i = 31, "", ","), 8, True)
        Next
        '---        
        If Tipo = "A" Then
            For n = 1 To intPeriodo
                If MAcumu(n) > NumMax Then
                    NumMax = MAcumu(n)
                    grupo = Val("1".ToString.PadRight(Len(Str(Convert.ToInt32(NumMax / 2))) - 1, "0"))
                End If
            Next
        End If
        '---
        ChkAcumumulativo.Visible = True
        Graba_Log(StrFile, "];", 8, True)
        Graba_Log(StrFile, "", 8, True)
        Graba_Log(StrFile, "// prepare jqxChart settings", 8, True)
        Graba_Log(StrFile, "var settings = {", 8, True)
        Graba_Log(StrFile, "title: 'REPORTE POR PERIODO',", 8, True)
        Graba_Log(StrFile, "description: 'Evalucion por dia de dos periodos',", 8, True)
        Graba_Log(StrFile, "enableAnimations: true,", 8, True)
        Graba_Log(StrFile, "showLegend: true,", 8, True)
        Graba_Log(StrFile, "padding: { left: 10, top: 10, right: 15, bottom: 20 },", 8, True)
        Graba_Log(StrFile, "titlePadding: { left: 90, top: 0, right: 0, bottom: 20 },", 8, True)
        Graba_Log(StrFile, "source: sampleData,", 8, True)
        Graba_Log(StrFile, "colorScheme: 'scheme05',", 8, True)
        Graba_Log(StrFile, "xAxis: {", 8, True)
        Graba_Log(StrFile, "dataField: 'Day',", 8, True)
        Graba_Log(StrFile, "unitInterval: 1,", 8, True)
        Graba_Log(StrFile, "tickMarks: { visible: true, interval: 1 },", 8, True)
        Graba_Log(StrFile, "gridLinesInterval: { visible: true, interval: 1 },", 8, True)
        Graba_Log(StrFile, "valuesOnTicks: false,", 8, True)
        Graba_Log(StrFile, "padding: { bottom: 10 }", 8, True)
        Graba_Log(StrFile, "},", 8, True)
        Graba_Log(StrFile, "valueAxis: {", 8, True)
        Graba_Log(StrFile, "unitInterval: " & grupo.ToString & ",", 8, True)
        Graba_Log(StrFile, "minValue: 0,", 8, True)
        Graba_Log(StrFile, "maxValue: " & NumMax.ToString & ",", 8, True)
        Graba_Log(StrFile, "title: { text: 'Por Periodo de Dias<br><br>' },", 8, True)
        Graba_Log(StrFile, "labels: { horizontalAlignment: 'right' }", 8, True)
        Graba_Log(StrFile, "},", 8, True)
        Graba_Log(StrFile, "seriesGroups:", 8, True)
        Graba_Log(StrFile, "[", 8, True)
        Graba_Log(StrFile, "{", 8, True)
        Graba_Log(StrFile, "type: 'line',", 8, True)
        Graba_Log(StrFile, "series:", 8, True)
        Graba_Log(StrFile, "[", 8, True)

        For n = 1 To intPeriodo
            Graba_Log(StrFile, "{", 8, True)
            Graba_Log(StrFile, "dataField: '" & ArrP(n) & "',", 8, True)
            Graba_Log(StrFile, "symbolType: 'square',", 8, True)
            Graba_Log(StrFile, "", 8, True)
            Graba_Log(StrFile, "labels:", 8, True)
            Graba_Log(StrFile, "{", 8, True)
            Graba_Log(StrFile, "visible: false,", 8, True)
            Graba_Log(StrFile, "backgroundColor: '#FEFEFE',", 8, True)
            Graba_Log(StrFile, "backgroundOpacity: 0.2,", 8, True)
            Graba_Log(StrFile, "borderColor: '#7FC4EF',", 8, True)
            Graba_Log(StrFile, "borderOpacity: 0.7,", 8, True)
            Graba_Log(StrFile, "padding: { left: 5, right: 5, top: 0, bottom: 20 }", 8, True)
            Graba_Log(StrFile, "}", 8, True)
            Graba_Log(StrFile, "}" & IIf(n = intPeriodo, "", ","), 8, True)
        Next


        Graba_Log(StrFile, "", 8, True)
        Graba_Log(StrFile, "]", 8, True)
        Graba_Log(StrFile, "}", 8, True)
        Graba_Log(StrFile, "]", 8, True)
        Graba_Log(StrFile, "};", 8, True)
        Graba_Log(StrFile, "", 8, True)
        Graba_Log(StrFile, "// setup the chart", 8, True)
        Graba_Log(StrFile, "$('#jqxChart').jqxChart(settings);", 8, True)
        Graba_Log(StrFile, "", 8, True)
        Graba_Log(StrFile, "});", 8, True)
        'Graba_Log(StrFile, "</script>", 8, True)
        Dim javaScript As String = "<script type='text/javascript' src='GrafLineal.js'></script>"
        Page.ClientScript.RegisterStartupScript(Me.GetType(), "xscript", javaScript, False)
    End Sub

    Sub Graba_Log(ByVal File As String, ByVal datos As String, ByVal Tipo As Integer, ByVal Cond As Boolean)
        Try
            Dim Log As String = "COBRANZA"
            Dim objFSO = CreateObject("Scripting.FileSystemObject")
            Dim objReadFile = objFSO.OpenTextFile(HttpContext.Current.Request.PhysicalApplicationPath & "\" & File, Tipo, Cond)
            objReadFile.writeline(datos)
            objReadFile.close()
            objReadFile = Nothing
        Catch ex As Exception
        End Try
    End Sub

    Private Sub RadioButton2_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButton2.CheckedChanged
        Dim xsql As String = ""
        Dim conn As New ConDB.ConSQL
        Dim chkbox As CheckBox = CType(sender, CheckBox)

        If Not CheckBox1.Checked Then
            xsql = "select day(pago.FechaPago) as DIA, SUM(case when PAGO.moneda ='S' THEN 1 ELSE 3.45 END * ISNULL(PAGO.MONTO,0)) MONTO from Pago inner join cliente on cliente.IdCliente = pago.IdCliente   inner join cartera on cartera.IdCartera = cliente.IdCartera Where cartera.nomcartera in (:cadena) and CONVERT(VARCHAR(6),pago.FechaPago,112) IN (:FECHAS) group by day(pago.FechaPago) "
        Else
            xsql = "select day(pago.FechaPago) as DIA, SUM(case when PAGO.moneda ='S' THEN 1 ELSE 3.45 END * ISNULL(PAGO.MONTO,0)) MONTO from Pago inner join cliente on cliente.IdCliente = pago.IdCliente   inner join cartera on cartera.IdCartera = cliente.IdCartera Where cartera.nomcartera in (:cadena) and CONVERT(VARCHAR(6),pago.FechaPago,112) IN (:FECHAS) group by day(pago.FechaPago) "
        End If

        Dim cadenacarr As String = ""
        For Each rw1 As GridViewRow In GridView1.Rows
            If chkbox.Checked = True Then
                Dim ChBx As CheckBox = CType(rw1.FindControl("ChkBox"), CheckBox)
                If ChBx.Checked = True Then
                    cadenacarr &= IIf(cadenacarr = "", "", ",")
                    cadenacarr &= "'" & rw1.Cells(1).Text & "'"
                End If
            End If
        Next
        Dim cadenaperiodo As String = ""
        For Each rw1 As GridViewRow In GridView3.Rows
            If chkbox.Checked = True Then
                Dim ChBx As CheckBox = CType(rw1.FindControl("ChkBox"), CheckBox)
                If ChBx.Checked = True Then
                    cadenaperiodo &= IIf(cadenaperiodo = "", "", ",")
                    cadenaperiodo &= "'" & rw1.Cells(1).Text & format(val(rw1.Cells(2).Text), "00") & "'"
                End If
            End If
        Next

        If RadioButton2.Checked Then
            Dim dt As DataTable = conn.Ejecuta_QUERY(xsql.Replace(":cadena", cadenacarr).replace(":FECHAS", cadenaperiodo))
            Cargar_Datos(dt, "Avance de produccion por DIA", "Pagos", "Dia")
        End If
        RadioButton1.Checked = False
        RadioButton2.Checked = False
        RadioButton3.Checked = False
        RadioButton4.Checked = False
        RadioButton5.Checked = False
    End Sub

    Protected Sub RadioButton3_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles RadioButton3.CheckedChanged
        Dim xsql As String = ""
        Dim conn As New ConDB.ConSQL
        Dim chkbox As CheckBox = CType(sender, CheckBox)

        If Not CheckBox1.Checked Then
            xsql = "select cartera.nomcartera CARTERA, SUM(case when PAGO.moneda ='S' THEN 1 ELSE 3.45 END * ISNULL(PAGO.MONTO,0)) MONTO from Pago inner join cliente on cliente.IdCliente = pago.IdCliente   inner join cartera on cartera.IdCartera = cliente.IdCartera Where cartera.nomcartera in (:cadena) and CONVERT(VARCHAR(6),pago.FechaPago,112) IN (:FECHAS) group by cartera.nomcartera "
        Else
            xsql = "select cartera.nomcartera CARTERA, SUM(case when PAGO.moneda ='S' THEN 1 ELSE 3.45 END * ISNULL(PAGO.MONTO,0)) MONTO from Pago inner join cliente on cliente.IdCliente = pago.IdCliente   inner join cartera on cartera.IdCartera = cliente.IdCartera Where cartera.nomcartera in (:cadena) and CONVERT(VARCHAR(6),pago.FechaPago,112) IN (:FECHAS) group by cartera.nomcartera "
        End If
        Dim cadenacarr As String = ""
        For Each rw1 As GridViewRow In GridView1.Rows
            If chkbox.Checked = True Then
                Dim ChBx As CheckBox = CType(rw1.FindControl("ChkBox"), CheckBox)
                If ChBx.Checked = True Then
                    cadenacarr &= IIf(cadenacarr = "", "", ",")
                    cadenacarr &= "'" & rw1.Cells(1).Text & "'"
                End If
            End If
        Next
        Dim cadenaperiodo As String = ""
        For Each rw1 As GridViewRow In GridView3.Rows
            If chkbox.Checked = True Then
                Dim ChBx As CheckBox = CType(rw1.FindControl("ChkBox"), CheckBox)
                If ChBx.Checked = True Then
                    cadenaperiodo &= IIf(cadenaperiodo = "", "", ",")
                    cadenaperiodo &= "'" & rw1.Cells(1).Text & format(val(rw1.Cells(2).Text), "00") & "'"
                End If
            End If
        Next
        If RadioButton3.Checked Then
            Dim dt As DataTable = conn.Ejecuta_QUERY(xsql.Replace(":cadena", cadenacarr).Replace(":FECHAS", cadenaperiodo))
            Carga_grafico_Circular(dt, "Avance de produccion por Cartera", "Pagos x Dia")
            'Cargar_Datos(dt, "Avance de produccion por Cartera", "Pagos", "Dia")
        End If
        RadioButton1.Checked = False
        RadioButton2.Checked = False
        RadioButton3.Checked = False
        RadioButton4.Checked = False
        RadioButton5.Checked = False
    End Sub

    Protected Sub ImageButton2_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButton2.Click
        Dim javaScript As String = "<script type='text/javascript'>$(document).ready(function () {window.open('http://192.168.1.49/Compromisos/Comp_Diario.html', '_blank', 'toolbar=yes, scrollbars=yes, resizable=yes, top=500, left=500, width=400, height=400');});</script>"
        Page.ClientScript.RegisterStartupScript(Me.GetType(), "xscript", javaScript, False)
    End Sub

    Private Sub RadioButton4_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButton4.CheckedChanged
        Dim xsql As String = ""
        Dim conn As New ConDB.ConSQL
        Dim chkbox As CheckBox = CType(sender, CheckBox)

        If Not CheckBox1.Checked Then
            xsql = "select usuario.usuario USUARIO, SUM(case when PAGO.moneda ='S' THEN 1 ELSE 3.45 END * ISNULL(PAGO.MONTO,0)) MONTO from Pago inner join cliente on cliente.IdCliente = pago.IdCliente   inner join cartera on cartera.IdCartera = cliente.IdCartera  inner join usuarioCliente on cliente.idcliente = usuarioCliente.idcliente  inner join usuario on UsuarioCliente.idusuario = usuario.idusuario  Where cartera.nomcartera in (:cadena) and CONVERT(VARCHAR(6),pago.FechaPago,112) IN (:FECHAS) group by usuario.usuario"
        Else
            xsql = "select usuario.usuario USUARIO, SUM(case when PAGO.moneda ='S' THEN 1 ELSE 3.45 END * ISNULL(PAGO.MONTO,0)) MONTO from Pago inner join cliente on cliente.IdCliente = pago.IdCliente   inner join cartera on cartera.IdCartera = cliente.IdCartera  inner join usuarioCliente on cliente.idcliente = usuarioCliente.idcliente  inner join usuario on UsuarioCliente.idusuario = usuario.idusuario  Where cartera.nomcartera in (:cadena) and CONVERT(VARCHAR(6),pago.FechaPago,112) IN (:FECHAS) group by usuario.usuario "
        End If
        Dim cadenacarr As String = ""
        For Each rw1 As GridViewRow In GridView1.Rows
            If chkbox.Checked = True Then
                Dim ChBx As CheckBox = CType(rw1.FindControl("ChkBox"), CheckBox)


                If ChBx.Checked = True Then
                    cadenacarr &= IIf(cadenacarr = "", "", ",")
                    cadenacarr &= "'" & rw1.Cells(1).Text & "'"
                End If
            End If
        Next
        Dim cadenaperiodo As String = ""
        For Each rw1 As GridViewRow In GridView3.Rows
            If chkbox.Checked = True Then
                Dim ChBx As CheckBox = CType(rw1.FindControl("ChkBox"), CheckBox)
                If ChBx.Checked = True Then
                    cadenaperiodo &= IIf(cadenaperiodo = "", "", ",")
                    cadenaperiodo &= "'" & rw1.Cells(1).Text & format(val(rw1.Cells(2).Text), "00") & "'"
                End If
            End If
        Next
        If RadioButton4.Checked Then
            Dim dt As DataTable = conn.Ejecuta_QUERY(xsql.Replace(":cadena", cadenacarr).replace(":FECHAS", cadenaperiodo))
            Cargar_Datos(dt, "Avance de produccion por Gestor", "Pagos", "Dia")
        End If
        RadioButton1.Checked = False
        RadioButton2.Checked = False
        RadioButton3.Checked = False
        RadioButton4.Checked = False
        RadioButton5.Checked = False
    End Sub

    Private Sub RadioButton5_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButton5.CheckedChanged
        Dim xsql As String = "select convert(varchar(6),pago.FechaPago,112) Periodo, day(pago.FechaPago) Dia, sum(case when pago.Moneda = 'S' then 1 else 3.3 end * pago.Monto) Monto from pago, cliente, cartera where pago.IdCliente = cliente.idcliente and cliente.IdCartera = Cartera.IdCartera and cartera.NomCartera in (:cartera)  and convert(varchar(6),pago.FechaPago,112) in (:periodo) group by convert(varchar(6),pago.FechaPago,112),day(pago.FechaPago) order by 1,2"
        Dim cartera As String = ""
        Dim cartera1 As String = ""
        Dim cartera2 As String = ""
        Dim cadena As String = ""
        Dim conn As New ConDB.ConSQL
        Dim chkbox As CheckBox = CType(sender, CheckBox)
        For Each rw1 As GridViewRow In GridView1.Rows
            If chkbox.Checked = True Then
                Dim ChBx As CheckBox = CType(rw1.FindControl("ChkBox"), CheckBox)
                If ChBx.Checked = True Then
                    cadena += cadena & "'" & rw1.Cells(1).Text & "',"
                End If
            End If
        Next
        cadena = Mid(cadena, 1, Len(cadena) - 1)
        xsql = xsql.Replace(":cartera", cadena)

        chkbox = CType(sender, CheckBox)
        cadena = ""
        For Each rw1 As GridViewRow In GridView3.Rows
            If chkbox.Checked = True Then
                Dim ChBx As CheckBox = CType(rw1.FindControl("ChkBox"), CheckBox)
                If ChBx.Checked = True Then
                    cadena += cadena & Format(Val(rw1.Cells(1).Text), "0000") & Format(Val(rw1.Cells(2).Text), "00") & ","
                End If
            End If
        Next
        cadena = Mid(cadena, 1, Len(cadena) - 1)
        xsql = xsql.Replace(":periodo", cadena)

        If RadioButton5.Checked Then
            Dim dt As DataTable = conn.Ejecuta_QUERY(xsql)
            Carga_grafico_lineal(dt, "L") ', "Avance de produccion por Periodo", "Pagos", "Dia")
            dt = Nothing
        End If
        RadioButton1.Checked = False
        RadioButton2.Checked = False
        RadioButton3.Checked = False
        RadioButton4.Checked = False
        RadioButton5.Checked = False
    End Sub

    Private Sub ChkAcumumulativo_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChkAcumumulativo.CheckedChanged
        Dim xsql As String = "select convert(varchar(6),pago.FechaPago,112) Periodo, day(pago.FechaPago) Dia, sum(case when pago.Moneda = 'S' then 1 else 3.3 end * pago.Monto) Monto from pago, cliente, cartera where pago.IdCliente = cliente.idcliente and cliente.IdCartera = Cartera.IdCartera and cartera.NomCartera in (:cartera)  and convert(varchar(6),pago.FechaPago,112) in (:periodo) group by convert(varchar(6),pago.FechaPago,112),day(pago.FechaPago) order by 1,2"
        Dim cartera As String = ""
        Dim cartera1 As String = ""
        Dim cartera2 As String = ""
        Dim cadena As String = ""
        Dim conn As New ConDB.ConSQL
        Dim chkbox As CheckBox = CType(sender, CheckBox)
        RadioButton5.Checked = True
        For Each rw1 As GridViewRow In GridView1.Rows
            If chkbox.Checked = True Then
                Dim ChBx As CheckBox = CType(rw1.FindControl("ChkBox"), CheckBox)
                If ChBx.Checked = True Then
                    cadena += cadena & "'" & rw1.Cells(1).Text & "',"
                End If
            End If
        Next
        If Trim(cadena) = "" Then Exit Sub
        cadena = Mid(cadena, 1, Len(cadena) - 1)
        xsql = xsql.Replace(":cartera", cadena)

        chkbox = CType(sender, CheckBox)
        cadena = ""
        For Each rw1 As GridViewRow In GridView3.Rows
            If chkbox.Checked = True Then
                Dim ChBx As CheckBox = CType(rw1.FindControl("ChkBox"), CheckBox)
                If ChBx.Checked = True Then
                    cadena += cadena & Format(Val(rw1.Cells(1).Text), "0000") & Format(Val(rw1.Cells(2).Text), "00") & ","
                End If
            End If
        Next
        cadena = Mid(cadena, 1, Len(cadena) - 1)
        xsql = xsql.Replace(":periodo", cadena)

        If RadioButton5.Checked Then
            Dim dt As DataTable = conn.Ejecuta_QUERY(xsql)
            Carga_grafico_lineal(dt, "A") ', "Avance de produccion por Periodo", "Pagos", "Dia")
            dt = Nothing
        End If
        ChkAcumumulativo.Checked = False
        RadioButton1.Checked = False
        RadioButton2.Checked = False
        RadioButton3.Checked = False
        RadioButton4.Checked = False
        RadioButton5.Checked = False
    End Sub

    Private Sub RpteEfectividad_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load    
        obtienAccesos()
        Dim conn As New ConDB.Conexion
        If Not Me.IsPostBack Then
            'Hora = ConfigurationManager.ConnectionStrings("HoraCorte").ConnectionString
            Hora = 20
            'Dim dt As DataTable = conn.Ejecuta_QUERY("select ucase(cartera)  from gestores group by ucase(cartera)")
            'VarMenu = ""
            'For x = 0 To dt.Rows.Count - 1
            'VarMenu += "<li><a href='Reporteador.aspx?idcartera=" & dt.Rows(x)(0) & "' rel='external'><img src='img/smico5.png'>" & dt.Rows(x)(0) & "</a></li>"
            'Next
            'dt = Nothing

            'Dim ipValido As String = ConfigurationManager.ConnectionStrings("IpValido").ConnectionString
            'If InStr(1, ipValido, obtener_ip()) Then
            '    VarSubMenu = "<li><a href='http://192.168.1.249/Cobranza/Login.aspx'><img src='img/smico3.png'>Cobranza</a></li>"
            '    VarSubMenu += "<li><a href='http://192.168.1.200/monast' rel='external'><img src='img/smico5.png'>Monast</a></li>"
            '    VarSubMenu += "<li><a href='http://192.168.1.200/asterisk' rel='external'><img src='img/smico5.png'>Asterisk</a></li>"
            '    VarSubMenu += "<li><a href='http://192.168.1.219/Daten'><img src='img/smico6.png'>Daten</a></li>"
            '    VarSubMenu += "<li><a href='http://192.168.1.3/MBMartinez' rel='external'><img src='img/smico4.png'>MotBus</a></li>"
            '    VarSubMenu += "<li><a href='http://buscandope.com/'><img src='img/smico3.png'>Validata</a></li>"
            '    VarSubMenu += "<li><a href='http://192.168.1.249/svc' rel='external'><img src='img/smico5.png'>Correos</a></li>"
            'End If

            idcartera = Request.QueryString("idCartera")
            Label1.Text = " * REPORTE DE EFECTIVIDAD * "
            Call CheckBox1_CheckedChanged(sender, e)

            Dim xsql = "SELECT distinct  year(PAGO.FechaPago) AS ANIO, month(PAGO.FechaPago)  MES, concat(datename(mm,PAGO.FechaPago),'-', year(PAGO.FechaPago)) PERIODO FROM PAGO where year(PAGO.FechaPago) =  " & Year(Now()) & " and month(PAGO.FechaPago) <= " & Month(Now()) & " order by 1"
            Dim objConSQL As New ConDB.ConSQL
            Dim dt = objConSQL.Ejecuta_QUERY(xsql)
            GridView3.DataSource = dt
            GridView3.DataBind()

            'If Not dt Is Nothing Then
            '    DropDownList1.Items.Add("--- Sin Seleccion ---")
            '    DropDownList1.Items(0).Value = 0
            '    Dim n
            '    For n = 0 To dt.Rows.Count - 1
            '        DropDownList1.Items.Add(dt.Rows(n)(1))
            '        DropDownList1.Items(n + 1).Value = dt.Rows(n)(0)
            '    Next
            '    DropDownList1.SelectedIndex = n
            'End If
            dt = Nothing
        End If
    End Sub
End Class