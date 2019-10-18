Imports ConDB
Public Class ClienteDatosAdicionales : Inherits BE.ClienteDatosAdicionales
    Dim cnxM As New ConDB.Conexion
    Dim cnxS As New ConDB.ConSQL
    Public grv As Object
    Public Function Obtiene_Datos() As DataTable
        Dim fnc = New Cobranza
        Return fnc.FunctionGlobal(":dniƒ:idempresa▓" & DNI & "ƒ" & idempresa, "QRYCG005")
    End Function
End Class
