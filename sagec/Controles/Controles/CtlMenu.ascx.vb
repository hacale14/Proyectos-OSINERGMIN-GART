Public Partial Class CtlMenu
    Inherits System.Web.UI.UserControl
    Public MenuPrincipal As String


    Public Sub GetMenu(ByVal Hidusuario, ByVal HidPerfil)
        Dim dt As New DataTable
        Dim bl As New BL.Cobranza
        Dim cadena As String = ""
        Dim cadenaCabI As String = ""
        Dim cadenaCabF As String = ""
        Dim cadenaCabDI As String = ""
        Dim cadenaCabDF As String = ""
        Dim cadenaCabD1I As String = ""
        Dim cadenaCabD1F As String = ""
        Dim Menu As String = ""
        Dim sMenu As String = ""
        Dim tMenu As String = ""
        Dim Menup As String = ""
        Using dt
            dt = bl.FunctionGlobal(":pidusuarioƒ:pidperfilƒ:papp▓" & Hidusuario & "ƒ" & HidPerfil & "ƒVALSYS", "QRYMENU")
            Menup = ""
            For i = 0 To dt.Rows.Count - 1
                '1er nivel 
                If Mid(dt.Rows(i)(0), 3, 2) = "00" Then
                    If Menu <> Mid(dt.Rows(i)(0), 1, 2) And Menu <> "" Then
                        Menup &= cadenaCabI & cadenaCabDI & "</ul></li>"
                        If cadenaCabD1I <> "" Then
                            Menup &= "</ul></li>"
                            cadenaCabD1I = ""
                        End If
                        cadenaCabDI = ""
                    End If
                    Menu = Mid(dt.Rows(i)(0), 1, 2)
                    cadenaCabI = "<li class='topfirst'><a href='#' ><span>"
                    cadenaCabI &= "<img src='" & dt.Rows(i)(5) & "' alt='" & dt.Rows(i)(1) & "'/>" & dt.Rows(i)(2) & "</span></a>"
                    cadenaCabI &= "<ul>"
                ElseIf Mid(dt.Rows(i)(0), 3, 2) <> "00" And Mid(dt.Rows(i)(0), 5, 2) = "00" Then
                    If cadenaCabD1I <> "" Then
                        cadenaCabDI &= cadenaCabD1I & "</ul></li>"
                        cadenaCabD1I = ""
                    End If
                    sMenu = Mid(dt.Rows(i)(0), 3, 2)
                    cadenaCabDI &= "<li><a href='" & dt.Rows(i)(1) & "'><img src='" & dt.Rows(i)(5) & "' alt='Usuario'/>" & dt.Rows(i)(2) & "</a></li>"
                ElseIf Mid(dt.Rows(i)(0), 3, 2) <> "00" And Mid(dt.Rows(i)(0), 5, 2) <> "00" And Mid(dt.Rows(i)(0), 7, 2) = "00" Then
                    tMenu = Mid(dt.Rows(i)(0), 5, 2)
                    If cadenaCabD1I = "" Then cadenaCabDI = Mid(cadenaCabDI, 1, Len(cadenaCabDI) - 5) & "<ul>"
                    cadenaCabD1I &= "<li><a href='" & dt.Rows(i)(1) & "'><img src='" & dt.Rows(i)(5) & "' alt='Usuario'/>" & dt.Rows(i)(2) & "</a></li>"
                End If
            Next
            Menup &= cadenaCabI & cadenaCabDI & "</ul></li>"
            If cadenaCabD1I <> "" Then
                Menup &= "</ul></li>"
                cadenaCabD1I = ""
            End If
            cadenaCabDI = ""
            Menup &= "<li class='topfirst'><a href='Login.aspx?Opcion=S' ><img src='Imagenes/256-2.png' alt='Salir' />Salir</a></li>"
            MenuPrincipal = Menup
        End Using
    End Sub

End Class