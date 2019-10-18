Imports ConDB

Public Class Condicion : Inherits BE.Condicion
    Dim Cobranza As New BL.Cobranza
    Dim dt As New DataTable
    Function BuscarCondicion()
        Dim CriterioTodos As String = "IDCONDICION >0"
        Dim CriterioCodCondicion As String = ""
        Dim CriterioCondicion As String = ""

        Try
            If Len(Trim(Codigo)) = 0 And Len(Trim(Descripcion)) = 0 Then
                dt = Cobranza.FunctionGlobal(":criterio▓" & CriterioTodos, "QRYCON001")
            Else
                If Len(Trim(Codigo)) > 0 Then
                    CriterioCodCondicion = " AND CODIGO LIKE '" & Codigo & "%'"
                Else
                    CriterioCodCondicion = ""
                End If

                If Len(Trim(Descripcion)) > 0 Then
                    CriterioCondicion = " AND DESCRIPCION LIKE '" & Descripcion & "%'"
                Else
                    CriterioCondicion = ""
                End If
                dt = Cobranza.FunctionGlobal(":criterio▓" & CriterioTodos & CriterioCodCondicion & CriterioCondicion, "QRYCON001")
            End If
        Catch ex As Exception
            Return Nothing
        End Try
        Return dt
    End Function


    Function NuevaCondicion()
        Dim estado As Boolean
        Try
            dt = Cobranza.FunctionGlobal(":codigoƒ:descripcion▓" & Codigo & "ƒ" & Descripcion, "QRYCON002")
            IdCondicion = dt.Rows(0)(0)
            Cobranza.FunctionGlobal(":idcondicion▓" & IdCondicion, "QRYCON004")
            estado = True
        Catch ex As Exception
            estado = False
        End Try
        Return estado
    End Function

    Function ModificarCondicion()
        Dim estado As Boolean
        Try
            dt = Cobranza.FunctionGlobal(":codigoƒ:descripcionƒ:idcondicion▓" & Codigo & "ƒ" & Descripcion & "ƒ" & IdCondicion, "QRYCON005")
            estado = True
        Catch ex As Exception
            estado = False
        End Try
        Return estado
    End Function

    Function EliminaCondicion()
        Dim estado As Boolean
        Try
            dt = Cobranza.FunctionGlobal(":idcondicion▓" & IdCondicion, "QRYCON006")
            estado = True
        Catch ex As Exception
            estado = False
        End Try
        Return estado
    End Function
End Class
