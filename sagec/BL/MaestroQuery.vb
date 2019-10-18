Imports BE
Public Class MaestroQuery
    Inherits BE.MaestroQuery

    Public Function SP_ConsultarDatos_01() As DataTable
        Dim SQL = "SELECT Usuario.Usuario, Operacion2.Producto, " & _
                        "Operacion2.Negocio, Operacion2.NroCuenta, " & _
                        "Cliente.Dni, Cliente.NombreCliente, " & _
                        "Operacion2.DIASMORA, Operacion2.DeudaTotal, " & _
                        "Operacion2.DeudaVencidaSol, Operacion2.DeudaVencidaDol, " & _
                        "CASE WHEN isnull(DatosCliente.Direccion1,'') = '' THEN Operacion2.Direccion ELSE DatosCliente.Direccion1 END as Direccion1," & _
                        "CASE WHEN isnull(DatosCliente.Direccion1,'') = '' THEN Operacion2.Distrito ELSE DatosCliente.dist1 END AS Distrito1," & _
                        "CASE WHEN isnull(DatosCliente.Direccion2,'') = '' THEN Cliente.Direccion ELSE DatosCliente.Direccion2 END as Direccion2," & _
                        "CASE WHEN isnull(DatosCliente.Direccion2,'') = '' THEN Distrito.NombreDistrito ELSE DatosCliente.dist2 END AS Distrito2," & _
                        "DatosCliente.Direccion3, " & _
                        "DatosCliente.dist3 as Distrito3, " & _
                        "Cliente.TipoContacto, Operacion2.TipoTel," & _
                        "Operacion2.TipoOperador, Cartera.TipoCartera," & _
                        "Cliente.IdCartera, Cliente.IdCondicion,Cliente.IdCliente," & _
                        "UsuarioCliente.IdUsuarioCliente, Cliente.Estado," & _
                        "Cartera.NomCartera, Cartera.Meta FROM UsuarioCliente " + _
                        "INNER JOIN Cliente ON UsuarioCliente.IdCliente = Cliente.IdCliente " & _
                        "INNER JOIN Usuario ON UsuarioCliente.IdUsuario = Usuario.IdUsuario " & _
                        "INNER JOIN Operacion2 ON Cliente.IdCliente = Operacion2.IdCliente " & _
                        "INNER JOIN Cartera ON Cliente.IdCartera = Cartera.IdCartera " & _
                        "LEFT OUTER JOIN Distrito ON Cliente.IdDistrito = Distrito.IdDistrito " + _
                        "LEFT JOIN DatosCliente ON DatosCliente.idcliente = Cliente.IdCliente " & _
                        "WHERE " + Criterio + " ORDER BY Usuario.Usuario,NombreCliente"
        Return Nothing
    End Function


End Class
