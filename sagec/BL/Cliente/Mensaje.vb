Imports ConDB
Public Class Mensaje : Inherits BE.Mensaje
    Dim cnxM As New ConDB.Conexion
    Dim cnxS As New ConDB.ConSQL
    Public grv As Object
    Public Function Carga_Grilla() As Integer
        Dim fnc = New Cobranza
        Dim dt1 As New DataTable
        Dim fil = 0
        Dim dt As DataTable = fnc.FunctionGlobal(":condicion▓" & IdCliente, "QRYCGM001")
        Dim row = dt1.NewRow()
        dt1.Columns.Add("FECHA")
        dt1.Columns.Add("USUARIO")
        dt1.Columns.Add("MENSAJE")
        For Each e In dt.Rows
            If IsDBNull(e(1)) Then Exit For
            Dim filas = Split(e(1), "|@@")
            For Each f In filas
                Dim campos = Split(f, "|@")
                If UBound(campos) > 0 Then
                    row = dt1.NewRow()
                    Dim colu = 0
                    For Each c In campos
                        If colu < 3 Then
                            row(dt1.Columns(colu)) = c
                        End If
                        colu += 1
                    Next
                    dt1.Rows.Add(row)
                End If
            Next
        Next
        If dt1.Rows.Count < 3 Then
            For i = 0 To 2 - dt1.Rows.Count
                row = dt1.NewRow()
                row(dt1.Columns(0)) = ""
                row(dt1.Columns(1)) = ""
                row(dt1.Columns(2)) = ""
                dt1.Rows.Add(row)
            Next
        End If
        dt = Nothing
        grv.SourceDataTable = dt1
        Return grv.gv.rows.count
    End Function
    Public Function Inserta() As Boolean
        Dim fnc = New Cobranza
        Call fnc.FunctionGlobal(":condicion▓" & IdCliente, "QRYCGM002")
        Return True
    End Function
    Public Function Actualiza()
        Dim fnc = New Cobranza
        Call fnc.FunctionGlobal(":condicion▓" & IdCliente, "QRYCGM003")
        Return True
    End Function
    Public Function Elimina()
        Dim fnc = New Cobranza
        Call fnc.FunctionGlobal(":condicion▓" & IdCliente, "QRYCGM004")
        Return True
    End Function
    Public Function Consulta() As Boolean
        Dim fnc = New Cobranza
        Using dt = fnc.FunctionGlobal(":condicion▓" & IdCliente, "QRYCGM001")
            For Each d In dt.rows
                Mensaje = d("Mensaje")
                IdCliente = d("IdCliente")
                Fecha = d("fecha")
            Next
        End Using
        Return True
    End Function
End Class
