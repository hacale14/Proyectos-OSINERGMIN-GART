Imports ConDB
Public Class Gestiones : Inherits BE.Gestiones
    Dim cnxM As New ConDB.Conexion
    Dim cnxS As New ConDB.ConSQL
    Public grv As Object
    Public Function Carga_Grilla_Campo() As Integer
        Dim fnc = New Cobranza
        Dim Sql = idEmpresa & "ƒ" & DNI
        Dim dt As DataTable = fnc.FunctionGlobal(":pIdempresaƒ:pDNI▓" & Sql, "QRYCG007")
        grv.SourceDataTable = dt
        dt = Nothing
        Return grv.gv.rows.count
    End Function
    Public Function Carga_Grilla_Campo_h() As Integer
        Dim fnc = New Cobranza
        Dim Sql = idEmpresa & "ƒ" & DNI
        Dim dt As DataTable = fnc.FunctionGlobal(":pIdempresaƒ:pDNI▓" & Sql, "QRYCG007H")
        grv.SourceDataTable = dt
        dt = Nothing
        Return grv.gv.rows.count
    End Function
    Public Function Carga_Grilla_Telefonia() As Integer
        Dim fnc = New Cobranza
        Dim Sql = idEmpresa & "ƒ" & DNI
        Dim dt As DataTable = fnc.FunctionGlobal(":pIdempresaƒ:pDNI▓" & Sql, "QRYCG006")
        grv.SourceDataTable = dt
        dt = Nothing
        Return grv.gv.rows.count
    End Function
    Public Function Carga_Grilla_HTelefonia() As Integer
        Dim fnc = New Cobranza
        Dim Sql = idEmpresa & "ƒ" & DNI
        Dim dt As DataTable = fnc.FunctionGlobal(":pIdempresaƒ:pDNI▓" & Sql, "QRYCG006H")
        grv.SourceDataTable = dt
        dt = Nothing
        Return grv.gv.rows.count
    End Function
    Public Function Elimina_Gestiones() As Boolean
        Try
            Dim fnc = New Cobranza
            Dim Sql = IdGestion
            Dim dt As DataTable = fnc.FunctionGlobal(":idgestion▓" & Sql, "SQL_D_GEST015")
            dt = Nothing
            Return True
        Catch ex As Exception            
            Return False
        End Try        
    End Function
End Class
