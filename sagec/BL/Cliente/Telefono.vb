Imports ConDB
Public Class Telefono : Inherits BE.Telefono
    Dim cnxM As New ConDB.Conexion
    Dim cnxS As New ConDB.ConSQL
    Public grv As Object
    Public Function Carga_Grilla() As Integer
        Dim fnc = New Cobranza
        grv.SourceDataTable = fnc.FunctionGlobal(":DNI▓" & DNI, "QRYCGT001")
        Return grv.gv.rows.count
    End Function
    Public Function Inserta() As Boolean
        Dim fnc = New Cobranza
        Call fnc.FunctionGlobal(":idcliente▓" & IdCliente, "QRYCGT002")
        Return True
    End Function
    Public Function Actualiza()
        Dim fnc = New Cobranza
        Call fnc.FunctionGlobal(":idcliente▓" & IdCliente, "QRYCGT003")
        Return True
    End Function
    Public Function Elimina()
        Dim fnc = New Cobranza
        Call fnc.FunctionGlobal(":idcliente▓" & IdCliente, "QRYCGT004")
        Return True
    End Function
    Public Function Consulta() As Boolean
        Dim fnc = New Cobranza
        Dim dt = fnc.FunctionGlobal(":idcliente▓" & IdCliente, "QRYCGT004")
        For Each d In dt
            IdCliente = d("idcliente")
            idTelefono = d("idtelefono")
            Telefono = d("Telefono")
            TipoTelefono = d("TipoTelefono")
            Prioridad = d("Prioridad")
            Origen = d("Origen")
            Observacion = d("Observacion")
            Estado = d("Estado")
            Fecha = d("Fecha")
        Next
        Return True
    End Function
    Public Function Valida_Telefono(ByVal idCliente As Integer, ByVal Strtelefono As Double, ByVal strDNI As String, ByRef strReservado As String) As Boolean
        Dim fnc = New Cobranza
        Dim xsql = "Select * from telefonos where DNI='" & strDNI & "' and telefono ='" & Strtelefono & "'"
        Dim dt = fnc.FunctionConsulta(xsql)
        Dim valTelf As Boolean
        If Not dt Is Nothing Then
            If dt.Rows.Count < 1 Then
                valTelf = False
                xsql = "insert into telefonos (idcliente,tiptelf,viatelf,telefono,area,score,fecha,Habilitado, Prioridad, orden, reservado, observacion, origen, dni )  values (" & _
                                        Val(idCliente) & ", '" & IIf(Mid(Strtelefono, 1, 1) = "9", "C", "F") & "','E'," & Strtelefono & ",1,'',getdate(),'A','q',99,'" & strReservado & "',' ','DTAM','" & strDNI & "')"
                fnc.FunctionConsulta(xsql)
                ' No inserta
            End If
        End If
        Return valTelf
    End Function
    Public Function ingresa_Telefono(ByVal idCliente As Integer, ByVal strDNI As String) As Boolean
        Try
            Dim fnc = New Cobranza
            Dim xsql = "EXECUTE inserta_telefonos '" & strDNI & "'," & idCliente
            Dim dt = fnc.FunctionConsulta(xsql)
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
End Class
