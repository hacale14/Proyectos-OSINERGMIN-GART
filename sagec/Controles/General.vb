'************************************************************************************************************************
'***** Autor: EMPRESA PIMAY 
'***** DESCRIPCION: MULTIPLES CONEXIONES 
'************************************************************************************************************************
Imports System.Data.OleDb
Imports System.Data.SqlClient
Imports System.Data.Common
Imports System.IO
Imports BL
Imports System.DirectoryServices.AccountManagement
Imports System.DirectoryServices
Imports ConDB
Imports System.Security.Principal
Imports System.Reflection
Imports System.Net
Imports System.Net.NetworkInformation

Public Class General
    Dim Log As BL.Acceso
    Public Telf As BL.Telefono
    Public Gv As Object
    Public Mensaje As String
    Const xlDiagonalDown = 5
    Const xlNone = -4142
    Const xlDiagonalUp = 6
    Const xlEdgeLeft = 7
    Const xlContinuous = 1
    Const xlThin = 2
    Const xlEdgeTop = 8
    Const xlEdgeBottom = 9
    Const xlEdgeRight = 10
    Const xlInsideVertical = 11
    Const xlInsideHorizontal = 12
    Const xl3Symbols = 7
    Const xlConditionValueNumber = 0
    Dim Datos As New BL.Cobranza
    Public Function IPAsterisk() As String
        Try
            Dim ctl As New ConDB.Conexion
            Mensaje = ""
            Return ctl.IPAsterisk
        Catch ex As Exception
            Mensaje = ex.Message
            Return ""
        End Try
    End Function
    Public Function Grabar_Anexo_usuario(ByVal Anexo, ByVal usuario) As Boolean
        Try
            Call Datos.FunctionGlobal(":anexoƒ:usuario▓" & Val(Anexo) & "ƒ" & usuario, "GES002")
            Return False
        Catch ex As Exception
            Mensaje = ex.Message
            Return False
        End Try
    End Function
    Public Function Obtener_usuario(ByVal idusuario As Integer, ByVal usuario As String, ByVal Anexo As String) As DataTable
        Try
            Dim srv As New ConDB.Conexion
            Dim Con As New ConDB.ConSQL
            Dim DT As New DataTable
            Return Con.FunctionGlobal(":pidusuarioƒ:panexoƒ:pusuario▓" & idusuario & "ƒ" & Anexo & "ƒ" & usuario, "QRYUSU001")
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function Obtener_Anexo(ByVal idusuario As String) As String
        Try
            Dim anexo = "0"
            Dim TipoTroncal = ""
            Dim srv As New ConDB.Conexion
            Dim Con As New ConDB.ConSQL
            Dim DT As New DataTable
            DT = Con.Obtiene_dt("SELECT [IdUsuario], [TipoUsuario], [Nombres], [Apellidos], [Usuario], [Cargo],[Anexo],[TipoTroncal] FROM USUARIO with (nolock) WHERE idusuario=" & idusuario, 0)
            If Not DT Is Nothing Then
                If DT.Rows.Count > 0 Then
                    Dim usuario = DT.Rows(0)("usuario")
                    Dim ctlsvc As New Controles.General
                    anexo = IIf(IsDBNull(DT.Rows(0)("Anexo")), 0, DT.Rows(0)("Anexo"))
                    TipoTroncal = IIf(IsDBNull(DT.Rows(0)("TipoTroncal")), 0, DT.Rows(0)("TipoTroncal"))
                    'Call Grabar_Anexo_usuario(anexo, usuario)
                    DT = Nothing
                    Con = Nothing
                    Return anexo & "|" & TipoTroncal
                Else
                    Return "0"
                End If
            Else
                Return "0"
            End If
        Catch ex As Exception
            Return "0"
            Mensaje = ex.Message
        End Try
    End Function
    Public Function Obtener_Datos_Asterisk(ByVal Tramas) As String
        Dim srv As New ConDB.Conexion
        Return srv.Trae_Llamadas_asterisk(Tramas)
    End Function
    Public Function Obtener_Datos_Asterisk(ByVal Tipo, ByVal Anexo, ByVal fecha) As DataTable
        Dim srv As New ConDB.Conexion
        Return srv.Obteniendo_Datos_Asterisk(Tipo, Anexo, fecha)
    End Function
    Sub Poner_Simbolo_Avances(ByVal Obj, ByVal Obj_Hoja)
        Obj.FormatConditions.AddIconSetCondition()
        Obj.FormatConditions(Obj.FormatConditions.Count).SetFirstPriority()
        With Obj.FormatConditions(1)
            .ReverseOrder = False
            .ShowIconOnly = False
            '.IconSet = Obj_Hoja.IconSets(xl3Symbols)
        End With
        With Obj.FormatConditions(1).IconCriteria(2)
            .Type = xlConditionValueNumber
            .Value = 0.8
            .Operator = 7
        End With
        With Obj.FormatConditions(1).IconCriteria(3)
            .Type = xlConditionValueNumber
            .Value = 1
            .Operator = 7
        End With
    End Sub
    Sub Linea_xls(ByVal Obj)
        Obj.Borders(xlDiagonalDown).LineStyle = xlNone
        Obj.Borders(xlDiagonalUp).LineStyle = xlNone
        With Obj.Borders(xlEdgeLeft)
            .LineStyle = xlContinuous
            .ColorIndex = 0
            .TintAndShade = 0
            .Weight = xlThin
        End With
        With Obj.Borders(xlEdgeTop)
            .LineStyle = xlContinuous
            .ColorIndex = 0
            .TintAndShade = 0
            .Weight = xlThin
        End With
        With Obj.Borders(xlEdgeBottom)
            .LineStyle = xlContinuous
            .ColorIndex = 0
            .TintAndShade = 0
            .Weight = xlThin
        End With
        With Obj.Borders(xlEdgeRight)
            .LineStyle = xlContinuous
            .ColorIndex = 0
            .TintAndShade = 0
            .Weight = xlThin
        End With
        With Obj.Borders(xlInsideVertical)
            .LineStyle = xlContinuous
            .ColorIndex = 0
            .TintAndShade = 0
            .Weight = xlThin
        End With
        With Obj.Borders(xlInsideHorizontal)
            .LineStyle = xlContinuous
            .ColorIndex = 0
            .TintAndShade = 0
            .Weight = xlThin
        End With
    End Sub
    Function DiasLaborales(ByVal fechaini As String, ByVal fechafin As String)
        Dim dif As Integer
        Dim i As Integer
        dif = Val(CDate(fechafin)) - Val(CDate(fechaini)) + 1
        For i = 0 To dif - 1
            If Weekday(System.DateTime.FromOADate(CDate(fechaini).ToOADate + i), Microsoft.VisualBasic.FirstDayOfWeek.Monday) = 6 Or Weekday(System.DateTime.FromOADate(CDate(fechaini).ToOADate + i), Microsoft.VisualBasic.FirstDayOfWeek.Monday) = 7 Then
                dif = dif - 1
            End If
        Next i
        Return dif
    End Function

    Public Sub exportar_xls(ByVal dt As DataTable)
        Dim Obj_Excel As Object
        Dim Obj_Libro As Object
        Dim Obj_Hoja As Object
        Try
            If dt.Rows.Count = 0 Then
                MsgBox("No hay datos para exportar a Excel") : Exit Sub
            Else
                Obj_Excel = CreateObject("Excel.Application")
                Obj_Libro = Obj_Excel.Workbooks.Add
                Dim fname
                Do
                    fname = Obj_Excel.GetSaveAsFilename(InitialFileName:="", filefilter:= _
                     " Excel Macro Free Workbook (*.xlsx), *.xlsx," & _
                     " Excel 2000-2003 Workbook (*.xls), *.xls," & _
                     " Excel Binary Workbook (*.xlsb), *.xlsb", _
                     FilterIndex:=2, Title:="This example copies the ActiveSheet to a new workbook")
                Loop Until fname <> ""
                Obj_Libro.SaveAs(FileName:=fname)
                Obj_Hoja = Obj_Excel.ActiveSheet
                For i = 0 To dt.Rows.Count
                    If i = 0 Then
                        For p = 0 To dt.Columns.Count - 1
                            Obj_Hoja.Cells(i + 1, p + 1).Value = dt.Columns(p).ColumnName
                        Next
                    Else
                        For j = 0 To dt.Columns.Count - 1
                            Obj_Hoja.Cells(i + 1, j + 1).Value = dt.Rows(i - 1)(j)
                        Next
                    End If
                Next
                Obj_Hoja.Columns.AutoFit()
                Obj_Hoja.Rows.AutoFit()
            End If
            Obj_Excel.Visible = True
            'vbMe.Caption = titulo
            'Eliminamos las variables de objeto exce
            Obj_Hoja = Nothing
            Obj_Libro = Nothing
            Obj_Excel = Nothing
            Exit Sub
        Catch ex As Exception
            Obj_Hoja = Nothing
            Obj_Libro = Nothing
            Obj_Excel = Nothing
            Mensaje = ex.Message
        End Try
    End Sub
    Public Sub exportar_Comrpromiso_xls(ByVal dtC As DataTable, ByVal dtd As DataTable, ByVal FechaInicio As String, ByVal FechaFin As String)
        Dim Obj_Excel As Object
        Dim Obj_Libro As Object
        Dim Obj_Hoja As Object

        Try
            Dim i As Double = 0.0
            Dim j As Double = 0.0

            If dtC.Rows.Count = 0 Then
                MsgBox("No hay datos para exportar a Excel") : Exit Sub
            Else
                Obj_Excel = CreateObject("Excel.Application")
                Obj_Libro = Obj_Excel.Workbooks.Add
                Dim fname
                Do
                    fname = Obj_Excel.GetSaveAsFilename(InitialFileName:="", filefilter:= _
                     " Excel Macro Free Workbook (*.xlsx), *.xlsx," & _
                     " Excel 2000-2003 Workbook (*.xls), *.xls," & _
                     " Excel Binary Workbook (*.xlsb), *.xlsb", _
                     FilterIndex:=2, Title:="This example copies the ActiveSheet to a new workbook")
                Loop Until fname <> ""
                Obj_Libro.SaveAs(FileName:=fname)
                'PonemoS la aplicación excel visible
                'Hoja activa
                Obj_Hoja = Obj_Excel.ActiveSheet
                ' lbl1.Caption = "Total de registro en progresos " & Format(rstd.RecordCount, "#,###,##0.00") & " en proceso: "
                ' Recorre el Datagrid
                Dim iCol = 0
                ' titulo = vbMe.Caption
                Dim tot = dtd.Rows.Count
                'bg.Max = tot
                'bg.Value = 0
                ' poniendo cabeceras
                Obj_Hoja.Cells(2, 2) = "DIAS LABORALES"
                Obj_Hoja.Range("B2:D2").Merge()

                Obj_Hoja.Range("B2:D2").HorizontalAlignment = -4108
                Obj_Hoja.Range("B2:D2").VerticalAlignment = -4107
                Obj_Hoja.Range("B2:D2").Borders(xlDiagonalDown).LineStyle = xlNone
                Obj_Hoja.Range("B2:D2").Borders(xlDiagonalUp).LineStyle = xlNone
                Obj_Hoja.Cells(3, 2) = FechaInicio
                Obj_Hoja.Cells(3, 3) = FechaFin
                Obj_Hoja.Cells(3, 2).NumberFormat = "mm/dd/yyyy"
                Obj_Hoja.Cells(3, 3).NumberFormat = "mm/dd/yyyy"
                'Obj_Hoja.Range("D3").Select()
                'Obj_Hoja.Cells(3, 4) = "=DIAS.LAB(B3,C3)"
                'Obj_Excel.Visible = True
                'Obj_Hoja.Range(3, 4).FormulaR1C1 = "=NETWORKDAYS(RC[-2],RC[-1])"
                Obj_Hoja.Cells(3, 4) = DiasLaborales(FechaInicio, FechaFin)

                '---
                Linea_xls(Obj_Hoja.Range("B2:D3"))

                Obj_Hoja.Cells(2, 6) = "DIAS DE PRODUCCION"
                Obj_Hoja.Range("F2:H2").Merge()

                Obj_Hoja.Range("F2:H2").HorizontalAlignment = -4108
                Obj_Hoja.Range("F2:H2").VerticalAlignment = -4107
                Obj_Hoja.Cells(3, 6) = FechaInicio
                Obj_Hoja.Cells(3, 7) = CDate(Date.Now()).ToString("dd/MM/yyyy")
                Obj_Hoja.Cells(3, 6).NumberFormat = "mm/dd/yyyy"
                Obj_Hoja.Cells(3, 7).NumberFormat = "mm/dd/yyyy"
                If DiasLaborales(FechaInicio, Date.Now()) < Obj_Hoja.Cells(3, 4).Value Then
                    Obj_Hoja.Cells(3, 8).Value = DiasLaborales(FechaInicio, Date.Now())
                Else
                    Obj_Hoja.Cells(3, 8).Value = Obj_Hoja.Cells(3, 4).Value + 1
                End If
                'Obj_Hoja.Cells(3, 8) = "=SI(DIAS.LAB(F3,G3)<D3,DIAS.LAB(F3,G3),D3)-1"
                'Obj_Hoja.Range("H3").Select()
                'Obj_Hoja.Cells(3, 8).FormulaR1C1 = "=IF(NETWORKDAYS(RC[-2],RC[-1])<RC[-4],NETWORKDAYS(RC[-2],RC[-1]),RC[-4])-1"


                Obj_Hoja.Range("B5").Value = dtC.Rows(0)(2)
                Obj_Hoja.Range("B5:I5").Merge()
                Obj_Hoja.Range("B6").Value = "Estudios"
                Obj_Hoja.Range("C6").Value = "N° Ctas Asignadas"
                Obj_Hoja.Range("D6").Value = "Asesores"
                Obj_Hoja.Range("E6").Value = "Meta " & UCase(Format(Date.Now(), "MMMM"))
                Obj_Hoja.Range("F6").Value = "Pagos Sin PDP"
                Obj_Hoja.Range("G6").Value = "Caida"
                Obj_Hoja.Range("H6").Value = "PDP Meta 100%"
                Obj_Hoja.Range("I6").Value = "PDP x Asesor x Dia"

                Obj_Hoja.Range("B7").Value = "MARTINEZ"
                Obj_Hoja.Range("C7").Value = Format(dtC.Rows(0)(8), "#,###,##0.00")
                Obj_Hoja.Range("E7").Value = Format(dtC.Rows(0)(5), "#,###,##0.00")
                Obj_Hoja.Range("F7").Value = dtC.Rows(0)(6) & "%"
                Obj_Hoja.Range("G7").Value = dtC.Rows(0)(7) & "%"
                'Obj_Hoja.Range("H7").FormulaR1C1 = "=(RC[-3]*(1-RC[-2]))/(1-R7C7)"
                'Obj_Hoja.Range("H7").Value = (Obj_Hoja.Cells("E7") * (1 - Obj_Hoja.Cells("F7")) / (1 - Obj_Hoja.Cells("G7")))
                Obj_Hoja.Range("H7").Value = (Obj_Hoja.Cells(7, 5).Value * (1 - Obj_Hoja.Cells(7, 6).Value) / (1 - Obj_Hoja.Cells(7, 7).Value))
                Obj_Hoja.Cells(7, 8).NumberFormat = "###,###,###.00"

                'Obj_Hoja.Range("I7").FormulaR1C1 = "=+RC[-1]/RC[-5]/R[-4]C[-5]"

                'Obj_Hoja.Range("I7").Value = (Obj_Hoja.Cells(7, 8).Value / Obj_Hoja.Cells(7, 4).Value) / Obj_Hoja.Cells(3, 4).Value

                Call Linea_xls(Obj_Hoja.Range("B2:D3"))
                Call Linea_xls(Obj_Hoja.Range("F2:H3"))
                Call Linea_xls(Obj_Hoja.Range("B5:i7"))

                Dim C = 9

                Dim Total_dias = DateDiff("d", FechaInicio, FechaFin) + 1
                If dtd.Rows.Count > 0 Then
                    Obj_Hoja.Range("B" & C).Value = "Nombre"
                    Call Linea_xls(Obj_Hoja.Range("B" & C))
                    Obj_Hoja.Range("C" & C).Value = "Apellidos"
                    Call Linea_xls(Obj_Hoja.Range("C" & C))
                    For i = 1 To Total_dias
                        Obj_Hoja.Cells(C, i + 3).Value = "Dia " & Day(DateAdd("d", i - 1, FechaInicio))
                        Call Linea_xls(Obj_Hoja.Cells(C, i + 3))
                    Next
                    Obj_Hoja.Cells(C, i + 3).Value = "TOTAL PDP"
                    Call Linea_xls(Obj_Hoja.Cells(C, i + 3))
                    Obj_Hoja.Cells(C, i + 4).Value = "GENERADAS TOTAL PDP"
                    Call Linea_xls(Obj_Hoja.Cells(C, i + 4))
                    Obj_Hoja.Cells(C, i + 5).Value = "REQ. A LA FECHA"
                    Call Linea_xls(Obj_Hoja.Cells(C, i + 5))
                    Obj_Hoja.Cells(C, i + 6).Value = "AVANCE  SUP / DEF"
                    Call Linea_xls(Obj_Hoja.Cells(C, i + 6))
                    Dim nombre = ""
                    'Dim tiempopaso
                    'Dim tiempopaso1
                    Dim duracion = Now.TimeOfDay
                    Dim Col
                    For fila = 0 To dtd.Rows.Count - 1
                        'bg.Value = bg.Value + 1
                        '0lbl1.Caption = "Total de registro en progresos " & Format(dtd.RecordCount, "#,###,##0.00") & " en proceso: " & Format(bg.Value, "#,###,##0.00") & " - " & Round(bg.Value / rstd.RecordCount, 2) * 100 & "%"
                        ' tiempopaso = Format(Time - duracion, "ss")
                        'tiempopaso = DateDiff("s", duracion, Now.TimeOfDay)
                        'tiempopaso1 = DateDiff("s", duracion, Now.TimeOfDay) / 60
                        'tiempopaso = (tiempopaso / bg.Value) * dtd.Rows.Count
                        'Dim tt
                        'If tiempopaso > 60 Then
                        '    tiempopaso = tiempopaso / 60
                        '    tt = " minutos"
                        'Else
                        '    tt = " segundo"
                        'End If
                        ' lbl2.Caption = "Tiempo estimado de termino: " & Math.Round(tiempopaso, 0) & tt & " / tiempo transcurrido : " & Round(tiempopaso1, 2) & " minutos"
                        If nombre <> dtd.Rows(fila)(1) & " " & dtd.Rows(fila)(2) Then
                            C = C + 1
                            Col = 3
                            Obj_Hoja.Range("D7").Value = C - 9
                            Obj_Hoja.Range("B" & C).Value = dtd.Rows(fila)(1)
                            Call Linea_xls(Obj_Hoja.Range("B" & C))
                            Obj_Hoja.Range("C" & C).Value = dtd.Rows(fila)(2)
                            Call Linea_xls(Obj_Hoja.Range("C" & C))
                            'Obj_Hoja.Cells(C, Total_dias + 4).Value = "=SUM(RC[-" & Total_dias & "]:RC[-1])"

                            'KKKKKKKK------>>>>>>>
                            'Dim TotalPDP As Double = 0
                            'For i = 4 To Total_dias
                            '    TotalPDP = TotalPDP + Obj_Hoja.Cells(fila + 10, i).Value
                            'Next
                            'Obj_Hoja.Cells(C, (Total_dias + 4)).Value = TotalPDP

                            ''''Obj_Hoja.Cells(C, Total_dias + 4).Style = "Comma"
                            Call Linea_xls(Obj_Hoja.Cells(C, Total_dias + 4))
                            'Obj_Hoja.Cells(C, Total_dias + 5).Value = "=+R7C9*R3C8"
                            'OBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBB
                            'Obj_Hoja.Cells(C, Total_dias + 5).Value = Obj_Hoja.Cells(7, 9).Value * Obj_Hoja.Cells(3, 8).Value

                            Call Linea_xls(Obj_Hoja.Cells(C, Total_dias + 5))
                            'Obj_Hoja.Cells(C, Total_dias + 5).Style = "Comma"

                            'Obj_Hoja.Cells(C, Total_dias + 7).FormulaR1C1 = "=+RC[-3]-RC[-2]"
                            Obj_Hoja.Cells(C, Total_dias + 7).Value = Obj_Hoja.Cells(C, 25).Value - Obj_Hoja.Cells(C, 26).Value

                            Call Linea_xls(Obj_Hoja.Cells(C, Total_dias + 7))
                            'Obj_Hoja.Cells(C, Total_dias + 7).Style = "Comma"
                            Call Linea_xls(Obj_Hoja.Cells(C, Total_dias + 6))


                            'Obj_Hoja.Cells(C, Total_dias + 6).FormulaR1C1 = "=+RC[-2]/RC[-1]"
                            Obj_Hoja.Cells(C, Total_dias + 6).Value = Obj_Hoja.Cells(C, 25).Value / Obj_Hoja.Cells(C, 26).Value

                            'Obj_Hoja.Cells(C, Total_dias + 6).Style = "Comma"
                            'Obj_Hoja.Cells(C, Total_dias + 6).Style = "Percent"
                            Call Poner_Simbolo_Avances(Obj_Hoja.Cells(C, Total_dias + 6), Obj_Libro)

                            For i = 1 To Total_dias
                                If Not (Day(DateAdd("d", i - 1, FechaInicio)) = dtd.Rows(fila)(5)) + 1 Then
                                    Obj_Hoja.Cells(C, i + 3).Value = 0
                                    Call Linea_xls(Obj_Hoja.Cells(C, i + 3))
                                    'Obj_Hoja.Cells(C, i + 3).Style = "Comma"
                                Else
                                    Obj_Hoja.Cells(C, i + 3).Value = dtd.Rows(fila)(6)
                                    'Obj_Hoja.Cells(C, i + 3).Style = "Comma"
                                    Call Linea_xls(Obj_Hoja.Cells(C, i + 3))
                                End If
                            Next
                        Else
                            For i = 1 To Total_dias
                                If Day(DateAdd("d", i - 1, FechaInicio)) = dtd.Rows(fila)(5) Then
                                    Obj_Hoja.Cells(C, i + 3).Value = dtd.Rows(fila)(6)
                                    'Obj_Hoja.Cells(C, i + 3).Style = "Comma"
                                    Call Linea_xls(Obj_Hoja.Cells(C, i + 3))
                                    Exit For
                                End If
                            Next
                        End If
                        nombre = dtd.Rows(fila)(1) & " " & dtd.Rows(fila)(2)
                    Next
                    'KKKKKKKK----->>>>>>
                    Obj_Hoja.Range("I7").Value = (Obj_Hoja.Cells(7, 8).Value / Obj_Hoja.Cells(7, 4).Value) / Obj_Hoja.Cells(3, 4).Value
                    Obj_Hoja.Cells(7, 9).NumberFormat = "###,###,###.00"
                    dtd = Nothing
                    dtC = Nothing
                    '---
                    Call Linea_xls(Obj_Hoja.Range("B" & C + 2 & ":C" & C + 2))
                    Obj_Hoja.Cells(C + 2, 2).Value = "REALIZADO GRUPAL"
                    Obj_Hoja.Range("B" & C + 2 & ":C" & C + 2).Merge()
                    Obj_Hoja.Cells(C + 3, 2).Value = "META GRUPAL DIARIA"
                    Obj_Hoja.Range("B" & C + 3 & ":C" & C + 3).Merge()
                    Call Linea_xls(Obj_Hoja.Range("B" & C + 3 & ":C" & C + 3))
                    Obj_Hoja.Cells(C + 4, 2).Value = "ALCANCE"
                    Obj_Hoja.Range("B" & C + 4 & ":C" & C + 4).Merge()
                    Call Linea_xls(Obj_Hoja.Range("B" & C + 4 & ":C" & C + 4))
                    Obj_Hoja.Cells(C + 5, 3).Value = "en la 1era semana se levantan las pdps del mes anterior."
                    Obj_Hoja.Cells(C + 6, 3).Value = "a partir de la 2da semana empiezan a generarse mayores promesas de pago"
                    Obj_Hoja.Range("C" & C + 5 & ":H" & C + 5).Merge()
                    Obj_Hoja.Range("C" & C + 6 & ":H" & C + 6).Merge()
                    For i = 1 To Total_dias
                        'Obj_Hoja.Cells(C + 2, i + 3).FormulaR1C1 = "=SUM(R[-" & C - 8 & "]C:R[-2]C)"
                        Dim sumas As Double = 0
                        For q = 10 To C
                            sumas = sumas + Obj_Hoja.Cells(q, i + 3).Value
                        Next
                        Obj_Hoja.Cells(C + 2, i + 3).Value = sumas
                        Obj_Hoja.Cells(C + 2, i + 3).NumberFormat = "###,###,###.00"
                        'Obj_Hoja.Cells(C + 2, i + 3).Style = "Comma"
                        Call Linea_xls(Obj_Hoja.Cells(C + 2, i + 3))

                        Obj_Hoja.Cells(C + 3, i + 3).Value = Obj_Hoja.Cells(7, 9).Value * Obj_Hoja.Cells(7, 4).Value
                        Obj_Hoja.Cells(C + 3, i + 3).NumberFormat = "###,###,###.00"

                        Obj_Hoja.Cells(C + 4, i + 3).Value = Obj_Hoja.Cells(C + 2, i + 3).Value / Obj_Hoja.Cells(C + 3, i + 3).Value
                        Obj_Hoja.Cells(C + 4, i + 3).NumberFormat = "0.00%"
                        'Obj_Hoja.Cells(C + 3, i + 3).FormulaR1C1 = "=+R7C9*R7C4"
                        'Obj_Hoja.Cells(fila + 10, Total_dias + 5).Value = Obj_Hoja.Cells(7, 9).Value * Obj_Hoja.Cells(7, 4).Value

                        'Obj_Hoja.Cells(C + 3, i + 3).Style = "Comma"
                        Call Linea_xls(Obj_Hoja.Cells(C + 3, i + 3))
                        Call Linea_xls(Obj_Hoja.Cells(C + 4, i + 3))
                        'Obj_Hoja.Cells(C + 4, i + 3).FormulaR1C1 = "=R[-2]C/R[-1]C"
                        'Obj_Hoja.Cells(C + 4, i + 3).Value = Obj_Hoja.Cells(C + 2, i + 2).Value / Obj_Hoja.Cells(C + 3, i + 2).Value

                        'Obj_Hoja.Cells(C + 4, i + 3).Style = "Percent"
                        Call Poner_Simbolo_Avances(Obj_Hoja.Cells(C + 4, i + 3), Obj_Libro)
                    Next

                    Dim sumaTotal1 As Double = 0
                    Dim sumatotal2 As Double = 0
                    Dim sumatotal3 As Double = 0

                    For fila = 10 To C
                        Dim TotalPDP As Double = 0
                        For i = 4 To Total_dias
                            TotalPDP = TotalPDP + Obj_Hoja.Cells(fila, i).Value
                        Next
                        Obj_Hoja.Cells(fila, Total_dias + 4).Value = TotalPDP
                        Obj_Hoja.Cells(fila, Total_dias + 5).Value = Obj_Hoja.Cells(7, 9).Value * Obj_Hoja.Cells(3, 8).Value
                        Obj_Hoja.Cells(fila, Total_dias + 5).NumberFormat = "###,###,###.00"
                        Obj_Hoja.Cells(fila, Total_dias + 6).Value = TotalPDP / Obj_Hoja.Cells(fila, Total_dias + 5).Value
                        Obj_Hoja.Cells(fila, Total_dias + 6).NumberFormat = "0.00%"
                        Obj_Hoja.Cells(fila, Total_dias + 7).Value = TotalPDP - Obj_Hoja.Cells(fila, Total_dias + 5).Value
                        Obj_Hoja.Cells(fila, Total_dias + 7).NumberFormat = "###,###,###.00"
                        sumaTotal1 = sumaTotal1 + TotalPDP
                        sumatotal2 = sumatotal2 + Obj_Hoja.Cells(fila, Total_dias + 5).Value
                        sumatotal3 = sumatotal3 + Obj_Hoja.Cells(fila, Total_dias + 7).Value
                        If fila = C Then
                            Obj_Hoja.Cells(fila + 2, Total_dias + 4).Value = sumaTotal1
                            Obj_Hoja.Cells(fila + 2, Total_dias + 4).NumberFormat = "###,###,###.00"
                            Obj_Hoja.Cells(fila + 2, Total_dias + 5).Value = sumatotal2
                            Obj_Hoja.Cells(fila + 2, Total_dias + 5).NumberFormat = "###,###,###.00"
                            Obj_Hoja.Cells(fila + 2, Total_dias + 6).Value = Obj_Hoja.Cells(fila + 2, Total_dias + 4).Value / Obj_Hoja.Cells(fila + 2, Total_dias + 5).Value
                            Obj_Hoja.Cells(fila + 2, Total_dias + 6).NumberFormat = "0.00%"
                            Obj_Hoja.Cells(fila + 2, Total_dias + 7).Value = sumatotal3
                            Obj_Hoja.Cells(fila + 2, Total_dias + 7).NumberFormat = "###,###,###.00"
                        End If
                    Next

                End If
                'Obj_Hoja.Cells(C + 2, i + 3).FormulaR1C1 = "=SUM(R[-" & C - 8 & "]C:R[-2]C)"
                Dim suma As Double = 0

                Call Linea_xls(Obj_Hoja.Cells(C + 2, i + 3))
                'Obj_Hoja.Cells(C + 2, i + 4).FormulaR1C1 = "=SUM(R[-" & C - 8 & "]C:R[-2]C)"
                Call Linea_xls(Obj_Hoja.Cells(C + 2, i + 4))
                'Obj_Hoja.Cells(C + 2, i + 5).FormulaR1C1 = "=+RC[-2]/RC[-1]"
                Call Linea_xls(Obj_Hoja.Cells(C + 2, i + 5))
                'Obj_Hoja.Cells(C + 2, i + 5).Style = "Percent"
                Call Linea_xls(Obj_Hoja.Cells(C + 2, i + 6))
                Call Poner_Simbolo_Avances(Obj_Hoja.Cells(C + 2, i + 5), Obj_Libro)
                Call Poner_Simbolo_Avances(Obj_Hoja.Cells(C + 2, i + 5), Obj_Libro)
                'Obj_Hoja.Cells(C + 2, i + 6).FormulaR1C1 = "=SUM(R[-" & C - 8 & "]C:R[-2]C)"
                'Autoajustamos
                Obj_Hoja.Columns("A:Z").AutoFit()
                Obj_Hoja.Columns.AutoFit()
                Obj_Hoja.Rows.AutoFit()
                'Obj_Hoja.Columns("F").NumberFormat = "000000000000"
            End If
            Obj_Excel.Visible = True
            'vbMe.Caption = titulo
            'Eliminamos las variables de objeto exce
            Obj_Hoja = Nothing
            Obj_Libro = Nothing
            Obj_Excel = Nothing
            Exit Sub
        Catch ex As Exception
            'Obj_Excel.Quit()
            Obj_Hoja = Nothing
            Obj_Libro = Nothing
            Obj_Excel = Nothing
            Mensaje = ex.Message
        End Try
    End Sub
    Sub ExcelBulkUpload(ByVal path, ByVal strSheetName)
        Try
            'Dim strFileame As String = "StudentRecords.xlsx"
            'Dim strSheetName As String = "StudentDetails"
            'Dim path As String = Server.MapPath("Import") & "\" & strFileame
            Dim excelConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & path & ";Extended Properties=""Excel 12.0;HDR=Yes;IMEX=2"""
            Dim excelConnection As New OleDbConnection(excelConnectionString)
            Dim cmd As New OleDbCommand("Select * from [" & strSheetName & "$]", excelConnection)
            excelConnection.Open()
            Dim dReader As OleDbDataReader
            dReader = cmd.ExecuteReader()

            Dim sqlBulk As New SqlBulkCopy(ConfigurationManager.ConnectionStrings("StudentConnectionString").ToString())
            sqlBulk.DestinationTableName = "StudentDetails"
            sqlBulk.ColumnMappings.Add("Roll No", "RollNo")
            sqlBulk.ColumnMappings.Add("Student Name", "Name")
            sqlBulk.ColumnMappings.Add("Department", "Department")
            sqlBulk.ColumnMappings.Add("Section", "Section")
            sqlBulk.WriteToServer(dReader)

            excelConnection.Close()
            Mensaje = "Your file data has been successfully uploaded."
        Catch ex As Exception
            Mensaje = ex.Message
        End Try
    End Sub
    Public Function Llenar_Combo(ByVal Combo As Object, ByVal cod As String, ByVal proceso As String) As Boolean
        Dim dt As DataTable
        Dim Cobranza As New BL.Cobranza
        Try
            dt = Cobranza.FunctionGlobal(cod, proceso)
            If dt Is Nothing Then
                Combo.Items.Add(" ")
                Combo.Items(0).Value = 0
            End If
            If Not dt Is Nothing Then
                Combo.Items.Add(" ")
                Combo.Items(0).Value = 0
                For n = 0 To dt.Rows.Count - 1
                    Combo.Items.Add(dt.Rows(n)(1))
                    Combo.Items(n + 1).Value = dt.Rows(n)(0)
                Next
            End If
            dt = Nothing
            Mensaje = ""
            Return True
        Catch ex As Exception
            Mensaje = ex.Message
            Return False
        End Try
    End Function
    Public Function Valida_Acceso(ByVal usuario, ByVal clave, ByRef Dt) As Boolean
        Log = New BL.Acceso
        Log.Usuario = usuario
        Log.Clave = clave
        If Log.Acceso(Dt) Then
            Mensaje = Log.Mensaje
            Return True
        Else
            Mensaje = Log.Mensaje
            Return False
        End If
    End Function
    Public Function Estadistica_grilla(ByVal idCliente As Integer, ByVal idUsuario As Integer, ByVal idCartera As Integer, ByRef gv As Object) As Boolean
        Dim bl As New BL.Estadistica
        bl.grv = gv
        bl.idUsuario = idUsuario
        bl.idCartera = idCartera
        bl.IdCliente = idCliente
        bl.Carga_Grilla()
        Return True
    End Function
    Public Function Deuda_Activa_grilla(ByVal idCliente As Integer) As DataTable
        Dim bl As New BL.Deuda
        bl.IdCliente = idCliente
        bl.TipoCartera = "ACTIVA"
        Return bl.DeudaActiva()
    End Function
    Public Function Deuda_Castigo_grilla(ByVal idCliente As Integer) As DataTable
        Dim bl As New BL.Deuda
        bl.IdCliente = idCliente
        bl.TipoCartera = "CASTIGO"
        Return bl.DeudaCastigo()
    End Function
    Public Function Telefono_grilla(ByVal dni As String, ByRef gv As Object) As Boolean
        Dim bl As New BL.Telefono
        bl.grv = gv
        bl.DNI = dni
        bl.Carga_Grilla()
        Return True
    End Function

    Public Function Pagos_grilla(ByVal dni As String, ByRef gv As Object) As Boolean
        Dim bl As New BL.Telefono
        bl.grv = gv
        bl.DNI = dni
        bl.Carga_Grilla()
        Return True
    End Function
    Public Function Informacion_Adcional_grilla(ByVal dni As String, ByRef gv As Object) As Boolean
        Dim bl As New BL.Telefono
        bl.grv = gv
        bl.DNI = dni
        bl.Carga_Grilla()
        Return True
    End Function
    Public Function Deuda_grilla(ByVal dni As String, ByRef gv As Object) As Boolean
        Dim bl As New BL.Telefono
        bl.grv = gv
        bl.DNI = dni
        bl.Carga_Grilla()
        Return True
    End Function
    Public Function Elimina_Gestion(ByVal idgestion As Integer) As Boolean
        Dim bl As New BL.Gestiones
        bl.IdGestion = idgestion
        bl.Elimina_Gestiones()
        Return True
    End Function
    Public Function Direccion_grilla(ByVal idCliente As Integer, ByRef gv As Object) As Boolean
        Dim bl As New BL.Direccion
        bl.grv = gv
        bl.IdCliente = idCliente
        bl.Carga_Grilla()
        Return True
    End Function
    Public Function Anotaciones_grilla(ByVal idCliente As Integer, ByRef gv As Object) As Boolean
        Dim bl As New BL.Mensaje
        bl.grv = gv
        bl.IdCliente = idCliente
        bl.Carga_Grilla()
        Return True
    End Function
    Public Function Gestion_Telefono_grilla(ByVal DNI As String, ByVal IdEmpresa As Integer, ByRef gv As Object) As Boolean
        Dim bl As New BL.Gestiones
        bl.grv = gv
        bl.DNI = DNI
        bl.idEmpresa = IdEmpresa
        bl.Carga_Grilla_Telefonia()
        Return True
    End Function
    Public Function Gestion_Telefono_grilla_h(ByVal DNI As String, ByVal IdEmpresa As Integer, ByRef gv As Object) As Boolean
        Dim bl As New BL.Gestiones
        bl.grv = gv
        bl.DNI = DNI
        bl.idEmpresa = IdEmpresa
        bl.Carga_Grilla_HTelefonia()
        Return True
    End Function
    Public Function Gestion_Campo_grilla(ByVal dni As String, ByVal idEmpresa As Integer, ByRef gv As Object) As Boolean
        Dim bl As New BL.Gestiones
        bl.grv = gv
        bl.DNI = dni
        bl.idEmpresa = idempresa
        bl.Carga_Grilla_Campo()
        Return True
    End Function
    Public Function Gestion_Campo_grilla_H(ByVal dni As String, ByVal idEmpresa As Integer, ByRef gv As Object) As Boolean
        Dim bl As New BL.Gestiones
        bl.grv = gv
        bl.DNI = dni
        bl.idEmpresa = idEmpresa
        bl.Carga_Grilla_Campo_h()
        Return True
    End Function
    Public Function Obtiene_Datos_adicionales(ByVal dni As String, ByVal idEmpresa As Integer) As DataTable
        Dim bl As New BL.ClienteDatosAdicionales
        bl.grv = Gv
        bl.DNI = dni
        bl.idEmpresa = idEmpresa
        Return bl.Obtiene_Datos()
    End Function

    Public Function FncCliente(ByVal idcliente As Integer) As DataTable
        Dim bl As New BL.Cliente
        bl.IdCliente = idcliente
        Return bl.ClientePuntual()
    End Function

    Public Function Obtiene_Consulta(ByVal trama, ByVal proceso)
        Dim con As New BL.Cobranza
        Return con.FunctionGlobal(trama, proceso)
    End Function
    Public Function ValidaNumero(ByVal Numero As String) As String
        Dim Cadena = "0123456789"
        Dim StrNumero = ""
        For i = 1 To Len(Numero)
            If InStr(1, Cadena, Mid(Numero, i, 1)) > 0 Then
                StrNumero &= Mid(Numero, i, 1)
            End If
        Next
        If StrNumero = "" Then StrNumero = "0"
        Return StrNumero
    End Function

    Public Function BuscarSQL(ByVal parametros As String, ByVal maestro_query As String)
        Dim dt As New DataTable
        Try
            dt = Datos.FunctionGlobal(parametros, maestro_query)
        Catch ex As Exception
            dt = Nothing
        End Try
        Return dt
    End Function
    Public Function Valida_Telefono(ByVal idClientea As Integer, ByVal Strtelefono As String, ByVal strDNI As String, ByRef strReservado As String) As Boolean
        Dim bl As New BL.Telefono
        Return bl.Valida_Telefono(idClientea, Val(Limpia_Numeros(Strtelefono)), strDNI, strReservado)
    End Function
    Public Function ingresa_Telefono(ByVal idClientea As Integer, ByVal strDNI As String) As Boolean
        Dim bl As New BL.Telefono
        Return bl.ingresa_Telefono(idClientea, strDNI)
    End Function

    Public Function Valida_Direccion(ByVal StridCliente, ByVal strtipo, ByVal strdireccion, ByVal strdpto, ByVal strprov, ByVal strdist, ByVal strorden, ByVal strhabilitado, ByVal strreservado, ByVal TipoCartera) As Boolean
        Dim bl As New BL.Direccion
        Return bl.Valida_Direccion(StridCliente, strtipo, strdireccion, strdpto, strprov, strdist, strorden, strhabilitado, strreservado, TipoCartera)
    End Function
    Public Function eliimina_Direccion(ByVal iddireccion As Integer) As Boolean
        Dim bl As New BL.Direccion
        bl.IdDireccion = iddireccion
        Return bl.Elimina
    End Function
    Public Function Limpia_Numeros(ByVal StrNumero As String) As String
        Dim i As Integer
        Dim numero = ""
        Dim cadena
        cadena = "1234567890"
        For i = 1 To Len(StrNumero)
            If InStr(1, cadena, Mid(StrNumero, i, 1)) > 0 Then
                numero = numero & Mid(StrNumero, i, 1) & ""
            End If
        Next
        Return Val(numero)
    End Function
    Public Function Crear_Usuario(ByVal Dominio As String, ByVal Usuario As String, ByVal Contrasenia As String) As Boolean
        Dim ouContex As PrincipalContext = New PrincipalContext(ContextType.Domain, Dominio, "OU=ADMINISTRADOR,DC=" & Mid(Dominio, 1, InStr(1, Dominio, ".") - 1) & ",DC=" & Mid(Dominio, InStr(1, Dominio, ".") + 1, 3))
        For i As Integer = 0 To 2 Step 1
            Try
                Dim up As UserPrincipal = New UserPrincipal(ouContex)
                up.SamAccountName = Usuario
                up.SetPassword(Contrasenia)
                up.Enabled = True
                'up.ExpirePasswordNow()
                up.Save()
                Return True
            Catch ex As Exception
                Return False
            End Try
        Next
    End Function

    Private Function getOnlineUsers() As List(Of [String])
        Dim activeSessions As New List(Of [String])()
        Dim obj As Object = GetType(HttpRuntime).GetProperty("CacheInternal", BindingFlags.NonPublic Or BindingFlags.[Static]).GetValue(Nothing, Nothing)
        Dim obj2 As Object() = DirectCast(obj.[GetType]().GetField("_caches", BindingFlags.NonPublic Or BindingFlags.Instance).GetValue(obj), Object())
        For i As Integer = 0 To obj2.Length - 1
            Dim c2 As Hashtable = DirectCast(obj2(i).[GetType]().GetField("_entries", BindingFlags.NonPublic Or BindingFlags.Instance).GetValue(obj2(i)), Hashtable)
            For Each entry As DictionaryEntry In c2
                Dim o1 As Object = entry.Value.[GetType]().GetProperty("Value", BindingFlags.NonPublic Or BindingFlags.Instance).GetValue(entry.Value, Nothing)
                If o1.[GetType]().ToString() = "System.Web.SessionState.InProcSessionState" Then
                    Dim sess As SessionStateItemCollection = DirectCast(o1.[GetType]().GetField("_sessionItems", BindingFlags.NonPublic Or BindingFlags.Instance).GetValue(o1), SessionStateItemCollection)
                    If sess IsNot Nothing Then
                        If sess("usuario") IsNot Nothing Then
                            activeSessions.Add(sess("usuario").ToString())
                        End If
                    End If
                End If
            Next
        Next
        Return activeSessions
    End Function

    Public Function ValidaIP(ByVal StrIp As String)
        Dim ip As IPAddress = IPAddress.Parse(StrIp)
        Dim ArrLocal(4) As String
        Dim ping As Ping = New Ping()
        For i = 0 To 3
            Dim pr As PingReply = ping.Send(ip)
            If Not pr.Address Is Nothing Then
                ArrLocal(1) = pr.Address.ToString
                ArrLocal(2) = pr.Buffer.Length
                ArrLocal(3) = pr.RoundtripTime
                ArrLocal(4) = pr.Status.ToString()
            Else
                ArrLocal(1) = StrIp
                ArrLocal(2) = 0
                ArrLocal(3) = 0
                ArrLocal(4) = "Off"
            End If
        Next
        Return ArrLocal
    End Function
    Public Function Trae_Llamadas_asterisk(ByVal Trama As String) As DataTable
        Try

            Dim table As New DataTable
            Dim column As DataColumn
            Dim row As DataRow
            Dim url As String = Trama
            Dim wc = New System.Net.WebClient()
            Dim sRt = wc.DownloadString(url)
            Dim Fila = Split(sRt, "||")
            Dim contador As Integer = 0
            ' Creacion de las columnas 
            Dim TColumna = Split("Canales!Contexto!Extension!Prioridad!Estado!Aplicaciones!Datos!Id_llamada!Campo1!Campo2!Codigo Cuenta!Duracion!Punto de Cuenta!Id Bridge", "!")

            For Each F In Fila
                row = table.NewRow()
                Dim Columna = Split(F, "!")

                For Each C In Columna
                    If Columna.Length < 5 Then Exit For
                    If table.Rows.Count < 1 Then
                        column = New DataColumn()
                        column.DataType = System.Type.GetType("System.String")
                        column.ColumnName = TColumna(contador)  '-- Nombre de la columna
                        column.ReadOnly = True
                        table.Columns.Add(column)
                    End If
                    row(TColumna(contador)) = C '-- Datos de la columna 
                    contador += 1
                Next
                table.Rows.Add(row)
                contador = 0
            Next

            column = Nothing
            row = Nothing
            url = Nothing
            wc = Nothing
            sRt = Nothing
            Return table
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function SelectDataTable(ByVal dt As DataTable, ByVal filter As String, ByVal sort As String) As DataTable

        Dim rows As DataRow()

        Dim dtNew As DataTable

        ' copy table structure
        dtNew = dt.Clone()

        ' sort and filter data
        rows = dt.Select(filter, sort)

        ' fill dtNew with selected rows

        For Each dr As DataRow In rows
            dtNew.ImportRow(dr)

        Next

        ' return filtered dt
        Return dtNew

    End Function
    Public Function Trae_datos_php(ByVal tramas As String) As DataTable
        'Return Trae_Llamadas_asterisk("http://192.168.0.20/pimaypred/leeragentes.php")
        Dim cnx As New ConDB.Conexion
        Return Trae_Llamadas_asterisk("http://" & cnx.IPAsterisk & tramas)
    End Function
End Class