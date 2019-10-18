Imports ConDB
Public Class Estadistica : Inherits BE.Estadistica
    Dim cnxM As New ConDB.Conexion
    Dim cnxS As New ConDB.ConSQL
    Public grv As Object
    Public Function Carga_Grilla() As Integer
        Dim fnc = New Cobranza
        Dim dt1 As New DataTable
        Dim dt As New DataTable
        Dim fil = 0        
        Dim Meta As Double = 0
        Try
            'Traendo Valores
            'Array = Split(Cadena, "▓") 'ALT  + 1458
            'arrParam = Split(Array(0), "ƒ") 'ALT + 159
            dt = fnc.FunctionGlobal(":idusuarioƒ:idcartera▓" & idUsuario & "ƒ" & idCartera, "QRYCGA001")
            If Not dt Is Nothing Then
                If dt.Rows.Count > 0 Then
                    Cantidad_Gestion = dt.Rows(0)(0)
                    If Not IsDBNull(dt.Rows(0)(1)) Then
                        Meta_Gestionado = dt.Rows(0)(1)
                    Else
                        Meta_Gestionado = 0
                    End If
                End If
            End If
            dt = Nothing
            dt = fnc.FunctionGlobal(":idusuarioƒ:idcartera▓" & idUsuario & "ƒ" & idCartera, "QRYCFA002")
            If Not dt Is Nothing Then
                If dt.Rows.Count > 0 Then
                    Cantidad_Gestionado = dt.Rows(0)(0)
                End If
            End If
            dt = Nothing
            Dim dttc As New DataTable
            dt = fnc.FunctionGlobal(":idusuarioƒ:idcartera▓" & idUsuario & "ƒ" & idCartera, "QRYCGA003")
            dttc = fnc.FunctionGlobal(":idusuarioƒ:idcartera▓" & idUsuario & "ƒ" & idCartera, "QRYCGA004")
            Recupero_Gestion = 0
            If Not dt Is Nothing Then
                If dt.Rows.Count > 0 Then
                    For C = 0 To dt.Rows.Count - 1
                        Recupero_Gestion += IIf(dt(C)(0) = "D", Math.Round(dttc.Rows(0)(0) * dt(C)(1), 2), Math.Round(dt(C)(1), 2))
                    Next
                End If
            End If
            dttc = Nothing
            dt = Nothing
            Dim row = dt1.NewRow()
            dt1.Columns.Add("TOTAL")
            dt1.Columns.Add("CANTIDAD")
            dt1.Columns.Add("%")
            row = dt1.NewRow()
            row(dt1.Columns("TOTAL")) = Math.Round(Cantidad_Gestion, 2)
            row(dt1.Columns("CANTIDAD")) = Math.Round(Cantidad_Gestionado, 2)
            row(dt1.Columns("%")) = Math.Round((Cantidad_Gestionado / Cantidad_Gestion) * 100, 2)
            dt1.Rows.Add(row)
            row = dt1.NewRow()
            row(dt1.Columns("TOTAL")) = "META"
            row(dt1.Columns("CANTIDAD")) = "PAGOS"
            row(dt1.Columns("%")) = "EFECT."
            dt1.Rows.Add(row)
            row = dt1.NewRow()
            row(dt1.Columns("TOTAL")) = Meta_Gestionado
            row(dt1.Columns("CANTIDAD")) = Recupero_Gestion
            If Recupero_Gestion > 0 Then
                row(dt1.Columns("%")) = Math.Round((Recupero_Gestion / Meta_Gestionado * 100), 2)
            Else
                row(dt1.Columns("%")) = 0
            End If
            dt1.Rows.Add(row)
            grv.SourceDataTable = dt1
            Return grv.gv.rows.count
        Catch ex As Exception
            Return 0
        End Try
    End Function
End Class
