Imports ConDB
Public Class Deuda : Inherits BE.Deuda
    Dim cnxM As New ConDB.Conexion
    Dim cnxS As New ConDB.ConSQL
    Public grv As Object
    Public Function Carga_Grilla() As Integer
        Dim fnc = New Cobranza
        Dim dt1 As DataTable
        If TipoCartera = "ACTIVA" Then
            dt1 = DeudaActiva()
            For i = 0 To dt1.Rows.Count - 1
                If dt1.Rows(i)("Moneda") = "S" Then
                    DeudaVencidadSoles = dt1.Rows(i)("DeudaVencidaSol")
                    DeudaVencidadSolesDolares = dt1.Rows(i)("DeudaVencidaDol")
                    DeudaTotalVencidadSoles = dt1.Rows(i)("DEUDATOTAL")
                ElseIf dt1.Rows(i)("Moneda") = "D" Then
                    DeudaVencidadDolares = dt1.Rows(i)("DeudaVencidaSol")
                    DeudaVencidadDolaresSoles = dt1.Rows(i)("DeudaVencidaDol")
                    DeudaTotalVencidadDolares = dt1.Rows(i)("DEUDATOTAL")
                End If
            Next
        Else
            dt1 = DeudaCastigo()
            For i = 0 To dt1.Rows.Count - 1
                If dt1.Rows(i)("Moneda") = "S" Then
                    DeudaVencidadSoles = dt1.Rows(i)("TotalK")
                    DeudaVencidadSolesDolares = DeudaVencidadSoles / 3.1
                    DeudaTotalVencidadSoles = dt1.Rows(i)("TotalD")
                ElseIf dt1.Rows(i)("Moneda") = "D" Then
                    DeudaVencidadDolares = dt1.Rows(i)("TotalK")
                    DeudaVencidadDolaresSoles = DeudaVencidadSoles * 3.1
                    DeudaTotalVencidadDolares = dt1.Rows(i)("TotalD")
                End If
            Next            
        End If
        dt1 = Nothing
        dt1 = New DataTable
        Dim fil = 0
        Dim row = dt1.NewRow()

        dt1.Columns.Add("Deuda V. S/.")
        dt1.Columns.Add("Deuda V. US$")
        dt1.Columns.Add("Deuda  Total S/.")
        row = dt1.NewRow()
        row(dt1.Columns("Deuda V. S/.")) = Math.Round(DeudaVencidadSoles, 2)
        row(dt1.Columns("Deuda V. US$")) = Math.Round(DeudaVencidadSolesDolares, 2)
        row(dt1.Columns("Deuda  Total S/.")) = Math.Round(DeudaTotalVencidadSoles, 2)
        dt1.Rows.Add(row)
        row = dt1.NewRow()
        row(dt1.Columns("Deuda V. S/.")) = "Deuda V. US$."
        row(dt1.Columns("Deuda V. US$")) = "Deuda V. S/."
        row(dt1.Columns("Deuda  Total S/.")) = "Deuda Total US$"
        dt1.Rows.Add(row)
        row = dt1.NewRow()
        row(dt1.Columns("Deuda V. S/.")) = Math.Round(DeudaTotalVencidadDolares, 2)
        row(dt1.Columns("Deuda V. US$")) = Math.Round(DeudaVencidadDolaresSoles, 2)
        row(dt1.Columns("Deuda  Total S/.")) = Math.Round(DeudaTotalVencidadDolares, 2)
        dt1.Rows.Add(row)
        grv.SourceDataTable = dt1
        Return grv.gv.rows.count
    End Function
    Public Function DeudaActiva() As DataTable
        Dim cb As New Cobranza
        Try
            Return cb.FunctionGlobal(":condicion▓" & IdCliente, "QRYCGDA001")
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function DeudaCastigo() As DataTable
        Dim cb As New Cobranza
        Try
            Return cb.FunctionGlobal(":condicion▓" & IdCliente, "QRYCGDC001")
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
End Class
