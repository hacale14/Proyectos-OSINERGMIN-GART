Imports ConDB
Public Class Cartera : Inherits BE.Cartera
    Dim Cobranza As New Cobranza
    Dim dt As New DataTable
    Public Combo As Object
    Public Mensaje As String
    Public Estado As String
    Function BuscarCartera()
        Dim CriterioTodos As String = "IDCARTERA > 0"
        Dim CriterioCartera As String = ""
        Dim CriterioCodCartera As String = ""
        Dim CriterioIdEmpresa As String = ""
        Dim CriterioIdCorporacion As String = ""
        Try
            If Len(Trim(CodCartera)) = 0 And Len(Trim(Cartera)) = 0 And Len(Trim(IdEmpresa)) = 0 And Len(Trim(IdCorporacion)) = 0 Then
                dt = Cobranza.FunctionGlobal(":criterio▓" & CriterioTodos, "QRYC001")
            Else
                If Len(Trim(CodCartera)) > 0 Then
                    CriterioCodCartera = " AND CODCARTERA LIKE '" & CodCartera & "%' "
                Else
                    CriterioCodCartera = ""
                End If

                If Len(Trim(Cartera)) > 0 Then
                    CriterioCartera = " AND NOMCARTERA LIKE '" & Cartera & "%' "
                Else
                    CriterioCartera = ""
                End If

                If Len(Trim(IdCorporacion)) > 0 Then
                    CriterioIdCorporacion = " AND EMPRESA.idcorporacion = " & IdCorporacion
                Else
                    CriterioIdCorporacion = ""
                End If

                If Val(Trim(IdEmpresa)) > 0 Then
                    CriterioIdEmpresa = " AND EMPRESA.idEmpresa = " & IdEmpresa
                Else
                    CriterioIdEmpresa = ""
                End If

                dt = Cobranza.FunctionGlobal(":criterio▓" & CriterioTodos & CriterioCartera & CriterioCodCartera & CriterioIdEmpresa & CriterioIdCorporacion, "QRYC001")
            End If
        Catch ex As Exception
            Return Nothing
        End Try
        Return dt
    End Function

    Function NuevaCartera()
        Dim estado As Boolean = False
        Try
            dt = Cobranza.FunctionGlobal(":codcarteraƒ:carteraƒ:tipoƒ:metaƒ:MetaPDPTƒ:MetaRECTƒ:idempresaƒ:id_grp_cartera▓" & CodCartera & "ƒ" & Cartera & "ƒ" & Tipo & "ƒ" & Meta & "ƒ" & MetaPDPT & "ƒ" & MetaRECT & "ƒ" & IdEmpresa & "ƒ" & GrpCartera, "QRYC002")
            If dt.Rows.Count <> 0 Then
                IdCartera = dt.Rows(0)(0)
                Cobranza.FunctionGlobal(":idcartera▓" & IdCartera, "QRYC002")
                estado = True
            End If
        Catch ex As Exception
            estado = False
        End Try
        Return estado
    End Function

    Function ModificarCartera()
        Dim estado As Boolean = False
        Try
            dt = Cobranza.FunctionGlobal(":codƒ:carteraƒ:tipoƒ:metaƒ:MetaPDPTƒ:MetaRECTƒ:idcarteraƒ:idempresaƒ:id_grp_cartera▓" & CodCartera & "ƒ" & Cartera & "ƒ" & Tipo & "ƒ" & Meta & "ƒ" & MetaPDPT & "ƒ" & MetaRECT & "ƒ" & IdCartera & "ƒ" & IdEmpresa & "ƒ" & GrpCartera, "QRYC005")
            estado = True
            Return estado
        Catch ex As Exception
            Return estado
        End Try
    End Function

    Function EliminarCartera()
        Dim estado As Boolean = False
        Try
            dt = Cobranza.FunctionGlobal(":idcartera▓" & IdCartera, "QRYC006")
            estado = True
        Catch ex As Exception
            estado = False
        End Try
        Return estado
    End Function

    Function ReporteGestion(ByVal TipoCartera As String, ByVal TipoReporte As String, ByVal idCartera As Integer, _
                            ByVal FechaInicio As String, ByVal FechaFin As String)
        Dim dt As New DataTable
        Dim criterio As String = ""
        If idCartera > 0 Then
            criterio = " and cartera.idcartera = " & idCartera
        End If

        Try
            If UCase(TipoReporte) = "INTERNO" Then
                dt = Cobranza.FunctionGlobal(":idcarteraƒ:TipoCarteraƒ:FechaInicioƒ:FechaFin▓" & criterio & "ƒ" & TipoCartera & "ƒ" & Format(CDate(FechaInicio), "yyyy/MM/dd") & "ƒ" & Format(CDate(FechaFin), "yyyy/MM/dd"), "QRYRG006")
            Else
                dt = Cobranza.FunctionGlobal(":idcarteraƒ:TipoCarteraƒ:FechaInicioƒ:FechaFin▓" & criterio & "ƒ" & TipoCartera & "ƒ" & Format(CDate(FechaInicio), "yyyy/MM/dd") & "ƒ" & Format(CDate(FechaFin), "yyyy/MM/dd"), "QRYRG007")
            End If
            Return dt
        Catch ex As Exception
            Return Nothing
        End Try
        Return dt
    End Function
End Class
