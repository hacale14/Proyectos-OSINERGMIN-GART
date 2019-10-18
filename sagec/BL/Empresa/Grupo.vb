Imports BE
Public Class Grupo : Inherits BE.Grupo
    Dim Cobranza As New Cobranza
    Public Mensaje As String
    Public Estado As String

    Function InsertarGrupo()
        Try
            Cobranza.FunctionGlobal(":NomCarteraƒ:Metaƒ:MCarteraƒ:PagosSPDPƒ:Caidaƒ:idEmpresaƒ:Estado▓" & _
                                    Descripcion & "ƒ0ƒ0ƒ0ƒ0ƒ" & idEmpresa & "ƒA", "QRYEG001")
        Catch ex As Exception
            Return Nothing
            Mensaje = ex.Message
        End Try
        Return Nothing
    End Function

    Function BuscaGrupo(ByVal criterio As String)
        Dim dt As New DataTable
        Try
            dt = Cobranza.FunctionGlobal(":criterio▓" & criterio, "SQLEG002")
        Catch ex As Exception
            dt = Nothing
        End Try
        Return dt
    End Function

    Function ModificarGrupo(ByVal idgrupo As String, ByVal grupo As String, ByVal idempresa As String)
        Cobranza.FunctionGlobal(":id_grp_carteraƒ:grupoƒ:idempresa▓" & idgrupo & "ƒ" & grupo & "ƒ" & idempresa, "SQLEG003")
        Return Nothing
    End Function

    Function EliminarGrupo(ByVal idgrupo As String)
        Cobranza.FunctionGlobal(":id_grp_cartera▓" & idgrupo, "SQLE004")
        Return Nothing
    End Function
End Class
