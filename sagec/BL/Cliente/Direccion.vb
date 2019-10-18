Imports ConDB
Public Class Direccion : Inherits BE.Direccion
    Dim cnxM As New ConDB.Conexion
    Dim cnxS As New ConDB.ConSQL
    Public grv As Object
    Public mensaje As String
    Public Function Carga_Grilla() As Integer
        Dim fnc = New Cobranza
        grv.SourceDataTable = fnc.FunctionGlobal(":condicion▓" & IdCliente, "QRYCGD001")
        Return grv.gv.rows.count
    End Function
    Public Function Inserta() As Boolean
        Dim fnc = New Cobranza
        Call fnc.FunctionGlobal(":condicion▓" & IdCliente, "QRYCGD002")
        Return True
    End Function

    Public Function Valida_Direccion(ByVal StridCliente, ByVal strtipo, ByVal strdireccion, ByVal strdpto, ByVal strprov, ByVal strdist, ByVal strorden, ByVal strhabilitado, ByVal strreservado, ByVal TipoCartera) As Boolean
        Dim Condicion As Boolean = False
        Dim fnc = New Cobranza
        Dim dto As New DataTable
        Dim xsql = ""
        If TipoCartera = "ACTIVA" Then
            xsql = "Select * from operacion2 where idcliente = " & StridCliente & " and estado <>'E'"
            dto = fnc.FunctionConsulta(xsql)
        Else
            xsql = "Select * from operacion where idcliente = " & StridCliente & " and estado <>'E'"
            dto = fnc.FunctionConsulta(xsql)
        End If
        If Not dto Is Nothing Then
            If dto.Rows.Count > 0 Then
                xsql = "Select * from direccion where idcliente='" & StridCliente & "' and direccion ='" & dto(0)("Direccion") & "'"
                Dim dt = fnc.FunctionConsulta(xsql)
                If Not dt Is Nothing Then
                    If dt.Rows.Count < 1 Then
                        ' Inserta Direcciones                
                        xsql = "insert into direccion (IdCliente,Direccion,Distrito,Provincia,Departamento,Habilitado, orden, fecha, tipo, reservado)  values " & _
                                        "('" & StridCliente & "', '" & dto(0)("direccion") & "','" & dto(0)("distrito") & "','" & dto(0)("provincia") & "','" & dto(0)("departamento") & "','" & strhabilitado & "'," & strorden & ", getdate(), '" & strtipo & "', '" & strreservado & "')"
                        Call fnc.FunctionConsulta(xsql)
                    End If
                End If
                dt = Nothing
                Condicion = True
            Else
                dto = Nothing
                Condicion = False
            End If
        Else
            Condicion = True
        End If
salir:
        Return Condicion
    End Function

    Public Function Actualiza()
        Dim fnc = New Cobranza
        Call fnc.FunctionGlobal(":condicion▓" & IdCliente, "QRYCGD003")
        Return True
    End Function
    Public Function Elimina()
        Try
            Dim fnc = New Cobranza
            Call fnc.FunctionGlobal(":iddireccion▓" & IdDireccion, "QRYCGD004")
            If fnc.Mensaje <> "" Then
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            Mensaje = ex.Message
            Return False
        End Try
    End Function
    Public Function Consulta() As Boolean
        Dim fnc = New Cobranza
        Dim dt = fnc.FunctionGlobal(":condicion▓" & IdCliente, "QRYCGD001")
        For Each d In dt
            Tipo = d("Tipo")
            Reservado = d("Reservado")
            Provincia = d("Provincia")
            Orden = d("Orden")
            MotivoBaja = d("MotivoBaja")
            IdDireccion = d("IdDireccion")
            IdCliente = d("IdCliente")
            Habilitado = d("Habilitado")
            Fecha = d("Fecha")
            Distrito = d("Distrito")
            Direccion = d("Direccion")
            Destino = d("Destino")
            Departamento = d("Departamento")
            Activo = d("Activo")
        Next
        Return True
    End Function
End Class
