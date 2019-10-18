Imports ConDB
Public Class Busquedas
    Inherits BE.ConsultaAsignacion
    Dim Dt As New DataTable
    Dim Cobranza As New Cobranza
    Dim Criterio As String
    Dim con As New ConDB.ConSQL
    Public idPerfil As Integer
    Public idusuario As Integer
    Private Function Buscar(ByVal Tipo As String, ByVal codigoSQL As String) As DataTable
        Try
            If (Tipo = "D") And (Len(Cartera) = 0 And Len(Condicion) = 0 And Len(Gestor) = 0 And Len(Dni) = 0 And Len(NombreCliente) = 0 And Len(Telefono) = 0 And Len(TipoCartera) = 0) Then
                Dt = Cobranza.FunctionGlobal(":pcriterio▓" & CriterioTodos, codigoSQL)
            ElseIf (Tipo = "C") And (Cartera = "" And Gestor = "" And Condicion = "" And Refinanciados = "" And Campaña = "" And Producto = "" And Negocio = "" And Nro_Operacion = "" And NombreCliente = "") Then
                Dt = Cobranza.FunctionGlobal(":pcriterio▓" & CriterioTodos, codigoSQL)
            ElseIf (Tipo = "A") And (Cartera = "" And Gestor = "" And Producto = "" And Negocio = "" And Cuenta = "" And NombreCliente = "" And DiasMora = "") Then
                Dt = Cobranza.FunctionGlobal(":pcriterio▓" & CriterioTodos, codigoSQL)
            ElseIf Tipo = "D" Then
                Criterio = CriterioTodos + Gestor + Condicion + Dni + NombreCliente + Telefono + Cartera + CriterioEstado + TipoCartera
                Dt = Cobranza.FunctionGlobal(":pcriterio▓" & Criterio, codigoSQL)
            ElseIf Tipo = "C" Then
                Criterio = CriterioTodos + Gestor + Refinanciados + Campaña + Producto + Negocio + Nro_Operacion + NombreCliente + Cartera + Condicion + CriterioEstado
                Dt = Cobranza.FunctionGlobal(":pcriterio▓" & Criterio, codigoSQL)
            ElseIf Tipo = "A" Then
                Criterio = CriterioTodos + Producto + Negocio + Cuenta + NombreCliente + Cartera + CriterioEstado + Gestor + DiasMora
                Dt = Cobranza.FunctionGlobal(":pcriterio▓" & Criterio, codigoSQL)
            End If
        Catch ex As Exception
            Return Nothing
        End Try
        Return Dt
    End Function
    Public Function Buscar_Datos_Cliente(ByVal Text_Cartera As String, ByVal Text_Gestor As String, ByVal Text_Condicion As String, ByVal Text_Dni As String, ByVal Text_Cliente As String, ByVal Text_Telefono As String, ByVal Text_TipoCartera As String) As DataTable
        Try
            CriterioEstado = " AND Cliente.Estado IN('A','N')"
            Cartera = ""
            Gestor = ""
            Condicion = ""
            Dni = ""
            NombreCliente = ""
            Telefono = ""
            If Len(Trim(Text_Cartera)) > 0 And Val(Trim(Text_Cartera)) > 0 Then
                Cartera = " AND Cartera.idCartera = " + Text_Cartera : End If
            If Len(Trim(Text_Gestor)) > 0 And Val(Trim(Text_Gestor)) > 0 Then
                Gestor = " AND UsuarioCliente.idUsuario = " + Text_Gestor : End If
            If Val(Trim(Text_Condicion)) > 0 Then
                Condicion = " AND cliente.idcondicion = " + Text_Condicion : End If
            If Len(Trim(Text_Dni)) > 0 Then
                Dni = " AND Cliente.DNI LIKE '" + Text_Dni + "%'" : End If
            If Len(Trim(Text_Cliente)) > 0 Then
                NombreCliente = " AND Cliente.NOMBRECLIENTE LIKE '" + Text_Cliente + "%'" : End If
            If Len(Trim(Text_Telefono)) > 0 Then
                Telefono = " AND exists " & _
                                " (Select 1 from telefonos x where x.idcliente = cliente.idcliente and  x.telefono like '" + Text_Telefono + "%')"
            End If
            If Len(Trim(Text_TipoCartera)) > 0 Then
                TipoCartera = " AND TIPOCARTERA LIKE '" + Text_TipoCartera + "%'"
            End If
            If idPerfil = 7 Then
                TipoCartera = " AND exists (SELECT top 1 1 FROM SupervisorCartera where uc_idcartera = cartera.idcartera and uc_idsupervisor = " & idusuario & ")"
            End If
            Dt = Buscar("D", "SQL_BUSCAR_DATOS")
            Return Dt
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function Buscar_Datos_Cliente_Compromiso(ByVal Text_Cartera As String, ByVal Text_Gestor As String, ByVal Text_Condicion As String, ByVal Text_Dni As String, ByVal Text_Cliente As String, ByVal Text_Telefono As String, ByVal Text_TipoCartera As String) As DataTable
        Try
            CriterioEstado = " AND Cliente.Estado IN('A','N')"
            Cartera = ""
            Gestor = ""
            Condicion = ""
            Dni = ""
            NombreCliente = ""
            Telefono = ""
            If Len(Trim(Text_Cartera)) > 0 And Val(Trim(Text_Cartera)) > 0 Then
                Cartera = " AND Cartera.idCartera = " + Text_Cartera : End If
            If Len(Trim(Text_Gestor)) > 0 And Val(Trim(Text_Gestor)) > 0 Then
                Gestor = " AND UsuarioCliente.idUsuario = " + Text_Gestor : End If
            If Val(Trim(Text_Condicion)) > 0 Then
                Condicion = " AND cliente.idcondicion = " + Text_Condicion : End If
            If Len(Trim(Text_Dni)) > 0 Then
                Dni = " AND Cliente.DNI LIKE '" + Text_Dni + "%'" : End If
            If Len(Trim(Text_Cliente)) > 0 Then
                NombreCliente = " AND Cliente.NOMBRECLIENTE LIKE '" + Text_Cliente + "%'" : End If
            If Len(Trim(Text_Telefono)) > 0 Then
                Telefono = " AND exists " & _
                                " (Select 1 from telefonos x where x.idcliente = cliente.idcliente and  x.telefono like '" + Text_Telefono + "%')"
            End If
            If Len(Trim(Text_TipoCartera)) > 0 Then
                TipoCartera = " AND TIPOCARTERA LIKE '" + Text_TipoCartera + "%'"
            End If
            If idPerfil = 7 Then
                TipoCartera = " AND exists (SELECT top 1 1 FROM SupervisorCartera where uc_idcartera = cartera.idcartera and uc_idsupervisor = " & idusuario & ")"
            End If
            Dt = Buscar("D", "SQL_BUSCAR_DATOSC")
            Return Dt
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function Buscar_Operacion_Castigo(ByVal Val_Cartera As Integer, ByVal Text_Cartera As String, ByVal Text_Gestor As String, ByVal Val_Condicion As Integer, ByVal Text_Condicion As String, ByVal Text_Refinanciado As String, ByVal Text_Campaña As String, ByVal Text_Producto As String, ByVal text_Negocio As String, ByVal Text_NroOperacion As String, ByVal Text_Cliente As String) As DataTable
        Try
            CriterioEstado = " AND Cliente.Estado IN('A','N') AND (Operacion.Estado <> 'E')"

            If Val_Cartera > 0 Then
                Cartera = " AND Cliente.idCartera=" + CStr(Val_Cartera) : Else : Cartera = ""
            End If
            If Len(Trim(Text_Gestor)) > 0 Then
                Gestor = " AND UsuarioCliente.idUsuario = " + Text_Gestor : Else : Gestor = """"
            End If
            If Val_Condicion > 0 Then
                Condicion = " AND CLIENTE.IDCONDICION=" + CStr(Val_Condicion) : Else : Condicion = ""
            End If
            If Len(Trim(Text_Refinanciado)) > 0 Then
                Refinanciados = " AND Operacion.REFINANCIADO LIKE '" + Text_Refinanciado + "%'" : Else : Refinanciados = ""
            End If
            If Len(Trim(Text_Campaña)) > 0 Then
                Campaña = " AND Operacion.CAMPANIA LIKE '" + Text_Campaña + "%'" : Else : Campaña = ""
            End If
            If Len(Trim(Text_Producto)) > 0 Then
                Producto = " AND Operacion.PRODUCTO LIKE '" + Text_Producto + "%'" : Else : Producto = ""
            End If
            If Len(Trim(text_Negocio)) > 0 Then
                Negocio = " AND Operacion.NEGOCIO LIKE '" + text_Negocio + "%'" : Else : Negocio = ""
            End If
            If Len(Trim(Text_NroOperacion)) > 0 Then
                Nro_Operacion = " AND Operacion.NROOPERACION LIKE '" + Text_NroOperacion + "%'" : Else : Nro_Operacion = ""
            End If
            If Len(Trim(Text_Cliente)) > 0 Then
                NombreCliente = " AND Cliente.NOMBRECLIENTE LIKE '" + Text_Cliente + "%'" : Else : NombreCliente = ""
            End If

            Dt = Buscar("C", "SQL_BUSCAR_CASTIGO")
            Return Dt
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function Buscar_Operacion_Activa(ByVal Val_Cartera As Integer, ByVal Text_Gestor As String, ByVal Text_Producto As String, ByVal Text_Negocio As String, ByVal Text_NroCuenta As String, ByVal Text_Cliente As String, ByVal Text_DiasMora As String, ByVal Text_Condicion As String) As DataTable
        Try
            If Val_Cartera > 0 Then
                Cartera = " AND Cliente.IdCartera=" + CStr(Val_Cartera) : Else : Cartera = "" : End If
            If Len(Trim(Text_Gestor)) > 0 Then
                Gestor = " AND UsuarioCliente.idUsuario = " + Text_Gestor : Else : Gestor = "" : End If
            If Len(Trim(Text_Producto)) > 0 Then
                Producto = " AND Operacion2.PRODUCTO LIKE '" + Text_Producto + "%'" : Else : Producto = "" : End If
            If Len(Trim(Text_Negocio)) > 0 Then
                Negocio = " AND Operacion2.NEGOCIO LIKE '" + Text_Negocio + "%'" : Else : Negocio = "" : End If
            If Len(Trim(Text_NroCuenta)) > 0 Then
                Cuenta = " AND Operacion2.NROCUENTA LIKE '" + Text_NroCuenta + "%'" : Else : Cuenta = "" : End If
            If Len(Trim(Text_Cliente)) > 0 Then
                NombreCliente = " AND Cliente.NOMBRECLIENTE LIKE '" + Text_Cliente + "%'" : Else : NombreCliente = "" : End If
            If Val(Trim(Text_Condicion)) > 0 Then
                Text_Condicion = " AND Cliente.idCondicion = " + Text_Condicion + "" : Else : Text_Condicion = "" : End If
            If Text_DiasMora = "" Then
                DiasMora = ""
            Else
                Select Case Text_DiasMora
                    Case "De 01 a 08 días"
                        DiasMora = " AND OPERACION2.DIASMORA<=8"
                    Case "De 09 a 30 días"
                        DiasMora = " AND OPERACION2.DIASMORA>=9 AND OPERACION2.DIASMORA<=30"
                    Case "De 31 a 60 días"
                        DiasMora = " AND OPERACION2.DIASMORA>=31 AND OPERACION2.DIASMORA<=60"
                    Case "De 61 a 90 días"
                        DiasMora = " AND OPERACION2.DIASMORA>=61 AND OPERACION2.DIASMORA<=90"
                    Case "De 91 a 120 días"
                        DiasMora = " AND OPERACION2.DIASMORA>=91 AND OPERACION2.DIASMORA<=120"
                    Case "Más de 120 días"
                        DiasMora = " AND OPERACION2.DIASMORA>=120"
                    Case Else
                        'DiasMora = " AND OPERACION2.DIASMORA<0"
                        DiasMora = " "
                End Select
            End If
            CriterioEstado = " AND Cliente.Estado IN('A','N') AND (Operacion2.Estado <> 'E')"
            Dt = Buscar("A", "SQL_BUSCAR_ACTIVA")
            Return Dt
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function AsigancionesCartera()
        Dim dt As New DataTable
        Try
            dt = Cobranza.FunctionGlobal("", "QRYBQ001")
        Catch ex As Exception
            Return Nothing
        End Try
        Return dt
    End Function

    Public Function CantidadCarteraAsignacion(ByVal cartera As String) As Long
        Dim dt As New DataTable
        Dim cantidad As Long
        Try
            dt = Cobranza.FunctionGlobal(":cartera▓" & cartera, "QRYBQ002")
            cantidad = Long.Parse(dt.Rows(0)(0))
        Catch ex As Exception
            Return Nothing
        End Try
        Return cantidad
    End Function

    Public Function GraficaCarteraAsignacionGestor(ByVal cartera As String)
        Dim dt As New DataTable
        Try
            dt = Cobranza.FunctionGlobal(":cartera▓" & cartera, "QRYBQ003")
        Catch ex As Exception
            Return Nothing
        End Try
        Return dt
    End Function

    Public Function BusquedaVacia()
        Dim dt As New DataTable
        Try
            dt = con.Obtiene_dt("SELECT Usuario.Usuario, Condicion.Codigo, Cliente.Dni,Cliente.NombreCliente, Cliente.Telefono1 , CASE WHEN isnull(datoscliente.telefono,'0') = '0' then Cliente.Telefono else str(datoscliente.telefono) end as telefono , CASE WHEN isnull(datoscliente.celular,'0') = '0' then  Cliente.Celular else str(datoscliente.celular) end  as celular, Cartera.NomCartera, Cartera.TipoCartera, Cliente.IdCliente , UsuarioCliente.IdUsuarioCliente, Cliente.Estado,  Cartera.Meta FROM Usuario RIGHT OUTER JOIN UsuarioCliente ON Usuario.IdUsuario = UsuarioCliente.IdUsuario RIGHT OUTER JOIN Cartera INNER JOIN Cliente ON Cartera.IdCartera = Cliente.IdCartera INNER JOIN Condicion ON Cliente.IdCondicion = Condicion.IdCondicion ON UsuarioCliente.IdCliente = Cliente.IdCliente LEFT JOIN datosCliente on datosCliente.idcliente =  Cliente.idcliente WHERE CLIENTE.IDCLIENTE = 0 ORDER BY Usuario,NombreCliente", 1)
        Catch ex As Exception
            Return Nothing
        End Try
        Return dt
    End Function
End Class
