Imports ConDB
Public Class Cliente : Inherits BE.Cliente
    Dim CriterioTodos As String = "IDCLIENTE>0"
    Dim CriterioCartera As String = ""
    Dim CriterioCondicion As String = ""
    Dim CriterioSituacion As String = ""
    Dim CriterioDNI As String = ""
    Dim CriterioIdCliente As Integer = 0
    Dim CriterioCliente As String = ""
    Dim CriterioTelefono As String = ""
    Dim CriterioTelefono1 As String = ""
    Dim CriterioEstado As String = " AND Cliente.Estado IN('A','N')"
    Dim Cobranza As New BL.Cobranza
    Public Mensaje As String
    Public Function ClientePuntual() As DataTable
        Try
            If IdCliente > 0 Then
                CriterioIdCliente = IdCliente
            Else
                CriterioIdCliente = 0
            End If
            Return Cobranza.FunctionGlobal(":idcliente▓" & CriterioIdCliente, "QRYCG001")
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Function BuscarCliente()
        Dim dt As New DataTable
        Try
            If Len(Trim(Cartera)) <> 0 Then
                CriterioCartera = " AND NOMCARTERA LIKE '" & Cartera & "%'"
            Else
                CriterioCartera = ""
            End If

            If Len(Trim(Condicion)) <> 0 Then
                CriterioCondicion = " AND DESCRIPCION LIKE '" & Condicion & "%'"
            Else
                CriterioCondicion = ""
            End If

            If Len(Trim(Situacion)) > 0 Then
                CriterioSituacion = " AND SITUACION LIKE '" & Situacion & "%'"
            Else
                CriterioSituacion = ""
            End If

            If Len(Trim(DNI)) > 0 Then
                CriterioDNI = " AND DNI LIKE '" & DNI & "%'"
            Else
                CriterioDNI = ""
            End If

            If Len(Trim(Cliente)) > 0 Then
                CriterioCliente = " AND NOMBRECLIENTE LIKE '" & Cliente & "%'"
            Else
                CriterioCliente = ""
            End If

            If Len(Trim(Telefono1)) > 0 Then
                CriterioTelefono = " AND TELEFONO LIKE '" & Telefono1 & "%'"
            Else
                CriterioTelefono = ""
            End If

            If Len(Trim(Telefono2)) > 0 Then
                CriterioTelefono1 = " AND TELEFONO1 LIKE '" & Telefono2 & "%'"
            Else
                CriterioTelefono1 = ""
            End If

            dt = Cobranza.FunctionGlobal(":criterio▓" & CriterioTodos & CriterioCartera & CriterioCondicion & CriterioSituacion & CriterioDNI & CriterioCliente & CriterioTelefono & CriterioTelefono1 & CriterioEstado, "SQL_BUSCAR_CLIENTE")
        Catch ex As Exception
            Return Nothing
        End Try
        Return dt
    End Function


    Function BuscarClienteGestion()
        Dim dt As New DataTable
        Try
            dt = Cobranza.FunctionGlobal(":idcliente▓" & IdCliente, "QRYCL001")
        Catch ex As Exception
            Return Nothing
        End Try
        Return dt
    End Function


    Function BuscarClienteGestion2()
        Dim dt As New DataTable
        Try
            dt = Cobranza.FunctionGlobal(":idcliente▓" & IdCliente, "QRYCL002")
        Catch ex As Exception
            Return Nothing
        End Try
        Return dt
    End Function

    Function BuscarClienteGestion3()
        Dim dt As New DataTable
        Try
            dt = Cobranza.FunctionGlobal(":idcliente▓" & IdCliente, "QRYCL003")
        Catch ex As Exception
            Return Nothing
        End Try
        Return dt
    End Function

    Function BuscarClienteGestion4()
        Dim dt As New DataTable
        Try
            dt = Cobranza.FunctionGlobal(":idcliente▓" & IdCliente, "QRYCL004")
        Catch ex As Exception
            Return Nothing
        End Try
        Return dt
    End Function

    Function BuscarClienteGestion5()
        Dim dt As New DataTable
        Try
            dt = Cobranza.FunctionGlobal(":idcliente▓" & IdCliente, "QRYCL005")
        Catch ex As Exception
            Return Nothing
        End Try
        Return dt
    End Function

    Function NuevoCliente()
        Dim dt As New DataTable
        Try
            dt = Cobranza.FunctionGlobal(":carteraƒ:condicionƒ:distritoƒ:nombreclienteƒ:dniƒ:direccionƒ:telefonoƒ:celularƒ:situacion▓" & Cartera & "ƒ" & Condicion & "ƒ" & Distrito & "ƒ" & Cliente & "ƒ" & DNI & "ƒ" & Direccion & "ƒ" & Telefono2 & "ƒ" & Celular & "ƒ" & Situacion, "QRYCL006")
            Mensaje = Cobranza.Mensaje
        Catch ex As Exception
            Mensaje = "Error:..." & ex.Message
            Return Nothing
        End Try
        Return dt
    End Function

    Function ActualizarCliente()
        Dim dt As New DataTable
        Try
            dt = Cobranza.FunctionGlobal(":idcarteraƒ:idcondicionƒ:iddistritoƒ:nombreclienteƒ:dniƒ:direccionƒ:telefono1ƒ:telefonoƒ:celularƒ:situacionƒ:idcliente▓" & _
                                        Cartera & "ƒ" & Condicion & "ƒ" & Distrito & "ƒ" & Cliente & "ƒ" & DNI & "ƒ" & Direccion & "ƒ" & Telefono2 & "ƒ" & Telefono1 & "ƒ" & Celular & "ƒ" & Situacion & "ƒ" & IdCliente, "QRYCL007")
            Mensaje = Cobranza.Mensaje
        Catch ex As Exception
            Mensaje = "Error:..." & ex.Message
            Return Nothing
        End Try
        Return dt
    End Function

    Function BorrarCliente()
        Dim dt As New DataTable
        Try
            dt = Cobranza.FunctionGlobal(":idcliente▓" & IdCliente, "QRYCL008")
            Mensaje = Cobranza.Mensaje
        Catch ex As Exception
            Mensaje = Cobranza.Mensaje
            Return Nothing
        End Try
    End Function
End Class
