Imports ConDB

Public Class Calculo
    Dim Cobranza As New BL.Cobranza
    Dim Mensaje As String

    Function ClientesAsignados(ByVal idcartera As String, ByVal idusuario As String) As Long
        Dim dt As New DataTable
        Dim NumClientesAsing As Long = 0
        Try
            dt = Cobranza.FunctionGlobal(":idcarteraƒ:idusuario▓" & idcartera & "ƒ" & idusuario, "QRYIN002")
            If dt.Rows.Count <> 0 Then
                NumClientesAsing = dt.Rows(0)(2)
            End If
        Catch ex As Exception
            NumClientesAsing = 0
            Mensaje = Mensaje & "Error en Cliente Asignados:" & ex.Message & ";"
        End Try
        Return NumClientesAsing
    End Function

    Function CuentasAsigandas(ByVal TipoCartera As String, ByVal idcartera As String, ByVal idusuario As String) As Integer
        Dim dt As New DataTable
        Dim NumCuentasAsignadas As Integer = 0
        Try
            If TipoCartera = "CASTIGO" Then
                dt = Cobranza.FunctionGlobal(":idcarteraƒ:idusuario▓" & idcartera & "ƒ" & idusuario, "QRYIN003")
            Else
                dt = Cobranza.FunctionGlobal(":idcarteraƒ:idusuario▓" & idcartera & "ƒ" & idusuario, "QRYIN004")
            End If
            If dt.Rows.Count <> 0 Then
                NumCuentasAsignadas = dt.Rows(0)(2)
            End If
        Catch ex As Exception
            NumCuentasAsignadas = 0
            Mensaje = Mensaje & "Error en Cuentas Asignadas:" & ex.Message & ";"
        End Try
        Return NumCuentasAsignadas
    End Function

    Function CapitalDeudaTotalDeudaVencida(ByRef arreglo() As Double, ByVal TipoCartera As String, ByVal idcartera As String, ByVal idusuario As String, ByVal TipoCambio As Double) As Boolean
        Dim dt As New DataTable
        ReDim Arreglo(2)
        Arreglo(0) = 0
        Arreglo(1) = 0
        Arreglo(2) = 0
        Try
            If TipoCartera = "CASTIGO" Then
                dt = Cobranza.FunctionGlobal(":idcarteraƒ:idusuario▓" & idcartera & "ƒ" & idusuario, "QRYIN005")
                If dt.Rows.Count <> 0 Then
                    For i = 0 To dt.Rows.Count - 1
                        If dt.Rows(i)(2) = "D" Then
                            Arreglo(0) = Arreglo(0) + (dt.Rows(i)(3) * TipoCambio)
                            Arreglo(1) = Arreglo(1) + (dt.Rows(i)(4) * TipoCambio)
                            Arreglo(2) = Arreglo(2) + (dt.Rows(i)(5) * TipoCambio)
                        Else
                            Arreglo(0) = Arreglo(0) + dt.Rows(i)(3)
                            Arreglo(1) = Arreglo(1) + dt.Rows(i)(4)
                            Arreglo(2) = Arreglo(2) + dt.Rows(i)(5)
                        End If
                    Next
                End If
            Else
                dt = Cobranza.FunctionGlobal(":idcarteraƒ:idusuario▓" & idcartera & "ƒ" & idusuario, "QRYIN006")
                If dt.Rows.Count <> 0 Then
                    For i = 0 To dt.Rows.Count - 1
                        If dt.Rows(i)(2) = "D" Then
                            arreglo(1) = arreglo(1) + (dt.Rows(i)(3) * TipoCambio)
                        Else
                            Arreglo(1) = Arreglo(1) + dt.Rows(i)(3)
                        End If
                        Arreglo(2) = Arreglo(2) + dt.Rows(i)(4)
                    Next
                End If
                Arreglo(0) = 0
            End If
            Return True
        Catch ex As Exception
            Return False
            Arreglo(0) = 0
            Arreglo(1) = 0
            Arreglo(2) = 0
            Mensaje = Mensaje & "Error en Capital, DeudaTotal, DeudaVencida:" & ex.Message & ";"
        End Try
    End Function

    Function PagosRealizados(ByVal TipoCartera As String, ByVal idcartera As String, ByVal idusuario As String, ByVal fechainicio As String, ByVal fechafin As String, ByVal TipoCambio As Double) As Double
        Dim dt As New DataTable
        Dim TotalPagos As Double = 0
        Try
            If TipoCartera = "CASTIGO" Then
                dt = Cobranza.FunctionGlobal(":idcarteraƒ:idusuarioƒ:fechainicioƒ:fechafin▓" & idcartera & "ƒ" & idusuario & "ƒ" & fechainicio & "ƒ" & fechafin, "QRYIN007")
            Else
                dt = Cobranza.FunctionGlobal(":idcarteraƒ:idusuarioƒ:fechainicioƒ:fechafin▓" & idcartera & "ƒ" & idusuario & "ƒ" & fechainicio & "ƒ" & fechafin, "QRYIN008")
            End If
            If dt.Rows.Count <> 0 Then
                For i = 0 To dt.Rows.Count - 1
                    If dt.Rows(i)(2) = "D" Then
                        TotalPagos = TotalPagos + (dt.Rows(i)("Total_Pagos") * TipoCambio)
                    Else
                        TotalPagos = TotalPagos + dt.Rows(i)("Total_Pagos")
                    End If
                Next
            End If
        Catch ex As Exception
            TotalPagos = 0
            Mensaje = Mensaje & "Error en Pagos Realizados:" & ex.Message & ";"
        End Try
        Return TotalPagos
    End Function

    Function PromesaPago(ByVal idcartera As String, ByVal idusuario As String, ByVal fechainicio As String, ByVal fechafin As String) As Integer
        Dim dt As New DataTable
        Dim SumPromesaPago As Integer = 0
        Try
            dt = Cobranza.FunctionGlobal(":idcarteraƒ:idusuarioƒ:fechainicioƒ:fechafin▓" & idcartera & "ƒ" & idusuario & "ƒ" & fechainicio & "ƒ" & fechafin, "QRYIN009")
            If dt.Rows.Count <> 0 Then
                SumPromesaPago = dt.Rows(0)("Nro_PP")
            End If
        Catch ex As Exception
            SumPromesaPago = 0
            Mensaje = Mensaje & "Error en Promesa Pagos:" & ex.Message & ";"
        End Try
        Return SumPromesaPago
    End Function


    Function CuentasGestionadas(ByVal TipoCartera As String, ByVal idcartera As String, ByVal idusuario As String, ByVal fechainicio As String, ByVal fechafin As String) As Integer
        Dim dt As New DataTable()
        Dim SumCuentasGestionadas As Integer = 0
        Try
            If TipoCartera = "CASTIGO" Then
                dt = Cobranza.FunctionGlobal(":idcarteraƒ:idusuarioƒ:fechainicioƒ:fechafin▓" & idcartera & "ƒ" & idusuario & "ƒ" & fechainicio & "ƒ" & fechafin, "QRYIN010")
            Else
                dt = Cobranza.FunctionGlobal(":idcarteraƒ:idusuarioƒ:fechainicioƒ:fechafin▓" & idcartera & "ƒ" & idusuario & "ƒ" & fechainicio & "ƒ" & fechafin, "QRYIN011")
            End If
            If dt.Rows.Count <> 0 Then
                If Not IsDBNull(dt.Rows(0)(0)) Then
                    SumCuentasGestionadas = dt.Rows(0)(0)
                Else
                    SumCuentasGestionadas = 0
                End If
            End If
        Catch ex As Exception
            SumCuentasGestionadas = 0
            Mensaje = Mensaje & "Error en Cuentas Gestionadas:" & ex.Message & ";"
        End Try
        Return SumCuentasGestionadas
    End Function

    Function CuentaGesionHumana(ByVal TipoCartera As String, ByVal Cartera As String, ByVal idcartera As String, ByVal idusuario As String, ByVal fechainicio As String, ByVal fechafin As String) As Integer
        Dim dt As New DataTable
        Dim SumCuentaGestionHumana As Integer = 0
        Try
            If TipoCartera = "CASTIGO" Then
                If Left(Cartera, 9) = "FALABELLA" Then
                    dt = Cobranza.FunctionGlobal(":idcarteraƒ:idusuarioƒ:fechainicioƒ:fechafin▓" & idcartera & "ƒ" & idusuario & "ƒ" & fechainicio & "ƒ" & fechafin, "QRYIN012")
                Else
                    dt = Cobranza.FunctionGlobal(":idcarteraƒ:idusuarioƒ:fechainicioƒ:fechafin▓" & idcartera & "ƒ" & idusuario & "ƒ" & fechainicio & "ƒ" & fechafin, "QRYIN013")
                End If
            Else
                dt = Cobranza.FunctionGlobal(":idcarteraƒ:idusuarioƒ:fechainicioƒ:fechafin▓" & idcartera & "ƒ" & idusuario & "ƒ" & fechainicio & "ƒ" & fechafin, "QRYIN014")
            End If
            If dt.Rows.Count <> 0 Then
                If Not IsDBNull(dt.Rows(0)(0)) Then
                    SumCuentaGestionHumana = dt.Rows(0)(0)
                End If
            End If
        Catch ex As Exception
            SumCuentaGestionHumana = 0
            Mensaje = Mensaje & "Error en Cuentas Gestionadas Humanas:" & ex.Message & ";"
        End Try
        Return SumCuentaGestionHumana
    End Function

    Function CuentasGestionDirecta(ByVal TipoCartera As String, ByVal Cartera As String, ByVal idcartera As String, ByVal idusuario As String, ByVal fechainicio As String, ByVal fechafin As String) As Integer
        Dim dt As New DataTable
        Dim SumCuentasGestionDirecta As Integer = 0
        Try
            If TipoCartera = "CASTIGO" Then
                If Left(Cartera, 9) = "FALABELLA" Then
                    dt = Cobranza.FunctionGlobal(":idcarteraƒ:idusuarioƒ:fechainicioƒ:fechafin▓" & idcartera & "ƒ" & idusuario & "ƒ" & fechainicio & "ƒ" & fechafin, "QRYIN015")
                Else
                    dt = Cobranza.FunctionGlobal(":idcarteraƒ:idusuarioƒ:fechainicioƒ:fechafin▓" & idcartera & "ƒ" & idusuario & "ƒ" & fechainicio & "ƒ" & fechafin, "QRYIN016")
                End If
            Else
                dt = Cobranza.FunctionGlobal(":idcarteraƒ:idusuarioƒ:fechainicioƒ:fechafin▓" & idcartera & "ƒ" & idusuario & "ƒ" & fechainicio & "ƒ" & fechafin, "QRYIN017")
            End If
            If dt.Rows.Count <> 0 Then
                If Not IsDBNull(dt.Rows(0)(0)) Then
                    SumCuentasGestionDirecta = dt.Rows(0)(0)
                End If
            End If
        Catch ex As Exception
            SumCuentasGestionDirecta = 0
            Mensaje = Mensaje & "Error en Cuentas Gestionadas Directa:" & ex.Message & ";"
        End Try
        Return SumCuentasGestionDirecta
    End Function

    Function CuentasGestionTitular(ByVal TipoCartera As String, ByVal Cartera As String, ByVal idcartera As String, ByVal idusuario As String, ByVal fechainicio As String, ByVal fechafin As String) As Integer
        Dim dt As New DataTable
        Dim SumCuentaGestionTitular As Integer = 0
        Try
            If TipoCartera = "CASTIGO" Then
                If Left(Cartera, 9) = "FALABELLA" Then
                    dt = Cobranza.FunctionGlobal(":idcarteraƒ:idusuarioƒ:fechainicioƒ:fechafin▓" & idcartera & "ƒ" & idusuario & "ƒ" & fechainicio & "ƒ" & fechafin, "QRYIN018")
                Else
                    dt = Cobranza.FunctionGlobal(":idcarteraƒ:idusuarioƒ:fechainicioƒ:fechafin▓" & idcartera & "ƒ" & idusuario & "ƒ" & fechainicio & "ƒ" & fechafin, "QRYIN019")
                End If
            Else
                dt = Cobranza.FunctionGlobal(":idcarteraƒ:idusuarioƒ:fechainicioƒ:fechafin▓" & idcartera & "ƒ" & idusuario & "ƒ" & fechainicio & "ƒ" & fechafin, "QRYIN020")
            End If
            If dt.Rows.Count <> 0 Then
                If Not IsDBNull(dt.Rows(0)(0)) Then
                    SumCuentaGestionTitular = dt.Rows(0)(0)
                End If
            End If
        Catch ex As Exception
            SumCuentaGestionTitular = 0
            Mensaje = Mensaje & "Error en Cuentas Gestionadas Titular:" & ex.Message & ";"
        End Try
        Return SumCuentaGestionTitular
    End Function

    Function PromesasCumplidas(ByVal TipoCartera As String, ByVal idcartera As String, ByVal idusuario As String, ByVal fechainicio As String, ByVal fechafin As String) As Integer
        Dim dt As New DataTable
        Dim dt2 As New DataTable
        Dim SumPromesasCumplidas As Integer = 0
        Try
            dt = Cobranza.FunctionGlobal(":idcarteraƒ:idusuarioƒ:fechainicioƒ:fechafin▓" & idcartera & "ƒ" & idusuario & "ƒ" & fechainicio & "ƒ" & fechafin, "QRYIN021")
            If dt.Rows.Count <> 0 Then
                For i = 0 To dt.Rows.Count - 1
                    If TipoCartera = "CASTIGO" Then
                        dt2 = Cobranza.FunctionGlobal(":idclienteƒ:fechacompromisoƒ:monedaƒ:monto▓" & dt.Rows(i)(0) & "ƒ" & dt.Rows(i)(2) & "ƒ" & dt.Rows(i)(3) & "ƒ" & dt.Rows(i)(4), "QRYIN022")
                    Else
                        dt2 = Cobranza.FunctionGlobal(":idclienteƒ:fechacompromisoƒ:monedaƒ:monto▓" & dt.Rows(i)(0) & "ƒ" & dt.Rows(i)(2) & "ƒ" & dt.Rows(i)(3) & "ƒ" & dt.Rows(i)(4), "QRYIN023")
                    End If
                    If dt2.Rows.Count <> 0 Then
                        SumPromesasCumplidas = SumPromesasCumplidas + 1
                    End If
                Next
            End If
        Catch ex As Exception
            SumPromesasCumplidas = 0
            Mensaje = Mensaje & "Error en Promesas Cumplidas Titular:" & ex.Message & ";"
        End Try
        Return SumPromesasCumplidas
    End Function

    Function TipoDeCartera(ByVal idcartera As String) As String
        Dim dt As New DataTable
        Dim tipo As String = ""
        Try
            dt = Cobranza.FunctionGlobal(":idcartera▓" & idcartera, "QRYIN001")
            If dt.Rows.Count <> 0 Then
                tipo = dt.Rows(0)(1)
            End If
        Catch ex As Exception
            tipo = ""
            Mensaje = Mensaje & "Error en Promesas Cumplidas Titular:" & ex.Message & ";"
        End Try
        Return tipo
    End Function


    Function CalcularIndicadores(ByVal cartera As String, ByVal idcartera As String, ByVal idusuario As String, ByVal fechainicio As String, ByVal fechafin As String, ByVal TipoDeCambio As Double, ByRef TotalClientesAsignados As Integer, ByRef TotalCuentasAsigandas As Integer, ByRef TotalCuentasGestionadas As Integer, ByRef Capital As Double, ByRef DeudaTotal As Double, ByRef DeudaVencida As Double, ByRef TotalSumaPagos As Double, ByRef TotalPromesasPago As Integer, ByRef TotalPromesasCumplidas As Integer, ByRef TotalGestionesHumanas As Integer, ByRef TotalGestionDirecta As Integer, ByRef TotalGestionTitular As Integer) As Boolean
        Try
            Dim arreglo() As Double
            ReDim arreglo(20)
            For i = 0 To 19
                arreglo(i) = 0
            Next

            Dim TipoCartera As String = ""
            TipoCartera = TipoDeCartera(idcartera)
            If TipoCartera = "" Then
                Return False
                Exit Function
            End If

            TotalClientesAsignados = TotalClientesAsignados + ClientesAsignados(idcartera, idusuario)

            TotalCuentasAsigandas = TotalCuentasAsigandas + CuentasAsigandas(TipoCartera, idcartera, idusuario)

            Dim CapitalDeudaTDeudaV(3) As Double
            Capital = 0
            DeudaTotal = 0
            DeudaVencida = 0
            If CapitalDeudaTotalDeudaVencida(CapitalDeudaTDeudaV, TipoCartera, idcartera, idusuario, TipoDeCambio) Then
                Capital = CapitalDeudaTDeudaV(0)
                DeudaTotal = CapitalDeudaTDeudaV(1)
                DeudaVencida = CapitalDeudaTDeudaV(2)
            End If

            TotalSumaPagos = TotalSumaPagos + PagosRealizados(TipoCartera, idcartera, idusuario, fechainicio, fechafin, TipoDeCambio)

            TotalPromesasPago = TotalPromesasPago + PromesaPago(idcartera, idusuario, fechainicio, fechafin)

            TotalCuentasGestionadas = TotalCuentasGestionadas + CuentasGestionadas(TipoCartera, idcartera, idusuario, fechainicio, fechafin)

            TotalGestionesHumanas = TotalGestionesHumanas + CuentaGesionHumana(TipoCartera, cartera, idcartera, idusuario, fechainicio, fechafin)

            TotalGestionDirecta = TotalGestionDirecta + CuentasGestionDirecta(TipoCartera, cartera, idcartera, idusuario, fechainicio, fechafin)

            TotalGestionTitular = TotalGestionTitular + CuentasGestionTitular(TipoCartera, cartera, idcartera, idusuario, fechainicio, fechafin)

            TotalPromesasCumplidas = TotalPromesasCumplidas + PromesasCumplidas(TipoCartera, idcartera, idusuario, fechainicio, fechafin)

        Catch ex As Exception
            Return False
        End Try
    End Function


    Function CalcularIndices(ByVal TotalSumaPagos As Double, ByVal DeudaVencida As Double, ByVal TotalCuentasGestionadas As Integer, ByVal TotalCuentasAsigandas As Integer, ByVal TotalGestionesHumanas As Integer, ByVal TotalGestionDirecta As Integer, ByVal TotalGestionTitular As Integer, ByVal TotalPromesasPago As Double, ByVal TotalPromesasCumplidas As Integer, ByRef Efectividad As Double, ByRef Cobertura As Double, ByRef Cont_Hum As Double, ByRef Cont_Direc As Double, ByRef Int_Gest As Double, ByRef Int_Contact As Double, ByRef Cierre_PDP As Double, ByRef Efect_PDP As Double) As Boolean
        Try
            'Indicadores
            If DeudaVencida <> 0 Then
                Efectividad = TotalSumaPagos / DeudaVencida
            Else
                Efectividad = 0
            End If

            If TotalCuentasAsigandas <> 0 Then
                Cobertura = TotalCuentasGestionadas / TotalCuentasAsigandas
            Else
                Cobertura = 0
            End If

            If TotalCuentasGestionadas <> 0 Then
                Cont_Hum = TotalGestionesHumanas / TotalCuentasGestionadas
            Else
                Cont_Hum = 0
            End If

            If TotalCuentasGestionadas <> 0 Then
                Cont_Direc = TotalGestionDirecta / TotalCuentasGestionadas
            Else
                Cont_Direc = 0
            End If

            If TotalCuentasGestionadas <> 0 Then
                Int_Gest = TotalCuentasAsigandas / TotalCuentasGestionadas
            Else
                Int_Gest = 0
            End If

            If TotalGestionTitular <> 0 Then
                Int_Contact = TotalGestionDirecta / TotalGestionTitular
            Else
                Int_Contact = 0
            End If

            If TotalGestionDirecta <> 0 Then
                Cierre_PDP = TotalPromesasPago / TotalGestionDirecta
            Else
                Cierre_PDP = 0
            End If

            If TotalPromesasPago <> 0 Then
                Efect_PDP = TotalPromesasCumplidas / TotalPromesasPago
            Else
                Efect_PDP = 0
            End If
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
End Class
