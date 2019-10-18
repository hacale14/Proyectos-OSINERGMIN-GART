Imports ConDB
Public Class Combo
    Dim Cobranza As New BL.Cobranza
    Dim dt As New DataTable

    Function LlenarSolo(ByVal cod As Integer, ByVal proces As String)
        Try
            dt = Cobranza.FunctionGlobal(":cod▓" & cod, proces)
        Catch ex As Exception
            dt = Nothing
            dt.Columns.Add()
            dt.Columns.Add()
            Dim fila As DataRow = dt.NewRow
            fila(0) = 0
            fila(1) = "No hay Elementos"
            dt.Rows.Add(fila)
        End Try
        Return dt
    End Function

End Class
