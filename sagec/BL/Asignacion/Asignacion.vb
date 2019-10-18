Public Class Asignacion : Inherits BE.AsignarGestores
    Dim j = 1
    Dim i = 0
    Dim blcobranza As New BL.Cobranza
    Public Mensaje As String = ""
    Public Function Grabar_Asignacion()
        Dim Dt As New DataTable
        Try
            Dim TotalPasadas = Val(Hasta) - (Val(Desde) - 1)
            Using Dt
                Dt = blcobranza.FunctionGlobal(":pidcartera▓" & Cartera_ID, "QRYCAG001")
                If Dt.Rows.Count > 0 Then
                    i = Desde
                    Do While j <= TotalPasadas
                        Cliente_ID = Dt(i)("IdCliente")
                        blcobranza.FunctionGlobal(":pidgestorƒ:pidcliente▓" & Gestor_ID & "ƒ" & Cliente_ID, "QRYCAG003")
                        i = i + 1
                        j = j + 1
                    Loop
                    Mensaje = "LA ASIGNACIÓN SE REALIZÓ CON ÉXITO!"
                Else
                    Mensaje = "NO HAY REGISTROS QUE ASIGNAR!"
                End If
            End Using
        Catch ex As Exception
            Mensaje = ex.Message
            Return Mensaje
        End Try
        Return Mensaje
    End Function
    'Reasignar Gestores
    Public Function Buscar_Cliente() As String
        Dim Dt As New DataTable
        Try
            Using Dt
                Dt = blcobranza.FunctionGlobal(":pdni▓" & Cliente_DNI, "QRYCRG001")
                If Dt.Rows.Count > 0 Then
                    Cliente_ID = IIf(Not IsDBNull(Dt(0)("IdCliente")), Dt(0)("IdCliente"), "")
                    Usuario_ID = IIf(Not IsDBNull(Dt(0)("IdUsuario")), Dt(0)("IdUsuario"), "")
                    UsuarioCliente_ID = IIf(Not IsDBNull(Dt(0)("IDUSUARIOCLIENTE")), Dt(0)("IDUSUARIOCLIENTE"), "")
                    NombreCliente = IIf(Not IsDBNull(Dt(0)("NombreCliente")), Dt(0)("NombreCliente"), "")
                    Codigo = IIf(Not IsDBNull(Dt(0)("Codigo")), Dt(0)("Codigo"), "")
                    Usuario = IIf(Not IsDBNull(Dt(0)("Usuario")), Dt(0)("Usuario"), "")
                    Mensaje = "AVISO..: LOS DATOS SE HAN CARGADO CORRECTAMENTE"
                Else
                    Cliente_ID = ""
                    Usuario_ID = ""
                    UsuarioCliente_ID = ""
                    NombreCliente = ""
                    Codigo = ""
                    Usuario = ""
                    Mensaje = "AVISO..: EL CLIENTE NO TIENE UN GESTOR ASIGNADO!"
                End If
            End Using
        Catch ex As Exception
            Mensaje = ex.Message
            Return Mensaje
        End Try
        Return Mensaje
    End Function
    Public Function Buscar_Cliente_dt() As DataTable
        Try
            Return blcobranza.FunctionGlobal(":pdni▓" & Cliente_DNI, "QRYCRG001")
        Catch ex As Exception
            Mensaje = ex.Message
            Return Nothing
        End Try
    End Function
    Public Function Actualizar() As String
        Try
            blcobranza.FunctionGlobal(":pidgestorƒ:pIdUsuarioCliente▓" & Gestor_ID & "ƒ" & UsuarioCliente_ID, "QRYCRG002")
            Mensaje = "AVISO..: LA ACTUALIZACIÓN SE REALIZÓ CON ÉXITO!"

        Catch ex As Exception
            Mensaje = ex.Message
            Return Mensaje
        End Try
        Return Mensaje
    End Function
    'Modificar Asignaciones
    Public Function Modificar_Asignacion()
        Try
            If Cliente_Actual = True Then
                If Len(Trim(UsuarioCliente_ID)) > 0 Then
                    blcobranza.FunctionGlobal(":pgestorƒ:pclienteƒ:pusuario▓" & Gestor_ID & "ƒ" & Cliente_ID & "ƒ" & UsuarioCliente_ID, "QRYNMA0002")
                Else
                    blcobranza.FunctionGlobal(":pgestorƒ:pcliente▓" & Gestor_ID & "ƒ" & Cliente_ID, "QRYNMA0001")
                End If
                Return "LA ASIGNACIÓN SE REALIZÓ CORRECTAMENTE!"
            ElseIf Todos_Clientes = True Then
                Cliente_ID = ""
                UsuarioCliente_ID = ""
                For Each row In DatosBuscados.Rows
                    Cliente_ID = row("IdCliente")
                    UsuarioCliente_ID = IIf(Not IsDBNull(row("IDUSUARIOCLIENTE")), row("IDUSUARIOCLIENTE"), "")
                    If Not Len(Trim(UsuarioCliente_ID)) = 0 Then
                        blcobranza.FunctionGlobal(":pidgestorƒ:pIdUsuarioCliente▓" & Gestor_ID & "ƒ" & UsuarioCliente_ID, "QRYCRG002")
                    Else
                        blcobranza.FunctionGlobal(":pgestorƒ:pcliente▓" & Gestor_ID & "ƒ" & Cliente_ID, "QRYNMA0001")
                    End If
                Next
                Return "LA ASIGNACIÓN SE REALIZÓ CORRECTAMENTE!"
            ElseIf Rango_Clientes = True Then
                If Len(Trim(Desde)) = 0 Then : Return "ESCRIBA UN NUMERO DE INICIO!" : End If
                If Len(Trim(Hasta)) = 0 Then : Return "ESCRIBA UN NUMERO DE FIN!" : End If
                If Not IsNumeric(Desde) Then : Return "EL NUMERO DE INICIO NO ES UN NUMERO" : End If
                If Not IsNumeric(Hasta) Then : Return "EL NUMERO DE FIN NO ES UN NUMERO" : End If
                If InStr(1, Trim(Desde), ",") > 0 Or InStr(1, Trim(Desde), ".") > 0 Then : Return "EL NUMERO DE INICIO NO PUEDE SER DECIMALES" : End If
                If InStr(1, Trim(Hasta), ",") > 0 Or InStr(1, Trim(Hasta), ".") > 0 Then : Return "EL NUMERO DE FIN NO PUEDE SER DECIMALES" : End If
                If CInt(Trim(Desde)) = 0 Or CInt(Trim(Hasta)) Then : Return "LOS NUMEROS DEBEN DE SER MAYORES A CERO (0)" : End If
                If CInt(Trim(Desde)) > CInt(Trim(Hasta)) Then : Return "EL NUMERO DE INICIO NO DEBE SER MAYOR AL NUMERO DE FIN" : End If

                Dim totalpasadas = 0
                Cliente_ID = ""
                UsuarioCliente_ID = ""
                totalpasadas = Val(Hasta) - (Val(Desde) - 1)
                If DatosBuscados.Rows.Count > 0 Then
                    i = Desde
                    Do While j <= totalpasadas
                        Cliente_ID = IIf(Not IsDBNull(DatosBuscados(i)("IdCliente")), DatosBuscados(i)("IdCliente"), "")
                        UsuarioCliente_ID = IIf(Not IsDBNull(DatosBuscados(i)("IDUSUARIOCLIENTE")), DatosBuscados(i)("IDUSUARIOCLIENTE"), "")
                        If Trim(UsuarioCliente_ID) <> "" Then
                            blcobranza.FunctionGlobal(":pgestorƒ:pclienteƒ:pusuario▓" & Gestor_ID & "ƒ" & Cliente_ID & "ƒ" & UsuarioCliente_ID, "QRYNMA0002")
                        Else
                            blcobranza.FunctionGlobal(":pgestorƒ:pcliente▓" & Gestor_ID & "ƒ" & Cliente_ID, "QRYNMA0001")
                        End If
                        i = i + 1
                        j = j + 1
                    Loop
                    Return "LA ASIGNACIÓN SE REALIZÓ CORRECTAMENTE!"
                Else
                    Return "NO HAY REGISTROS QUE ASIGNAR!"
                End If
            End If
        Catch ex As Exception
            Mensaje = ex.Message
            Return Mensaje
        End Try
        Return Nothing
    End Function

End Class
