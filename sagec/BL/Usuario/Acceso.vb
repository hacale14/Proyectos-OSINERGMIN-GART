Imports ConDB
Public Class Acceso : Inherits BE.Acceso
    Dim Con As New ConDB.ConSQL
    Public Mensaje As String
    Function Acceso(ByRef Dt As Object)
        Dim valida As Boolean
        Dt = New DataTable
        Try
            'Dt = Con.Obtiene_dt("SELECT [IdUsuario], [TipoUsuario], [Nombres], [Apellidos], [Usuario], [Cargo], [Anexo], [TipoTroncal] FROM USUARIO WHERE USUARIO='" & Usuario & "' AND CLAVE='" & Clave & "'", 0)
            Dt = Con.FunctionGlobal(":pUsuarioƒ:pClave▓" & Usuario & "ƒ" & Clave, "LOGINVALSYS1")
            If Not IsDBNull(Dt.Rows(0)("Cargo")) Then
                If Dt.Rows(0)("FechaCese") >= Now.Date Then
                    valida = False
                    Mensaje = "Error... su usuario a sido cesado, consulte con su administrador"
                    Dt = Nothing
                    Return False
                End If
            End If
            NombreGestor = Dt.Rows(0)("Apellidos") & " " & Dt.Rows(0)("Nombres")
            Cargo = Dt.Rows(0)("Cargo")
            IdUsuario = Dt.Rows(0)("IdUsuario")
            TipoUsuario = Dt.Rows(0)("TipoUsuario")
            Anexo = IIf(IsDBNull(Dt.Rows(0)("Anexo")), "0", Dt.Rows(0)("Anexo").ToString)
            TipoTroncal = IIf(IsDBNull(Dt.Rows(0)("TipoTroncal")), "0", Dt.Rows(0)("TipoTroncal").ToString)
            If Dt.Rows.Count > 0 Then
                valida = True
                Mensaje = ""
            Else
                Mensaje = "Error... usuario no existe"
                valida = False
            End If
        Catch ex As Exception
            Mensaje = "Error... usuario no existe"
            valida = False
        End Try
        Return valida
    End Function
End Class
