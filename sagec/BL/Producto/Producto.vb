Imports BL
Imports System.Web.UI.WebControls

Public Class Producto
    Dim Cobranza As New BL.Cobranza

    Function ConsultaProducto(ByVal criterio As String)
        Dim dt As New DataTable
        Try
            dt = Cobranza.FunctionGlobal(":criterio▓" & criterio, "QRYCPM001")
        Catch ex As Exception
            Return Nothing
        End Try
        Return dt
    End Function

    Function ConsultaProductoBatch(ByVal criterio As String, ByVal nombreusuario As String)
        Try
            Cobranza.ReporteBatch("SI", "QRYCPM001", ":criterio♦" & criterio, "CONSULTA - MONTO - PRODUCTO", nombreusuario)
        Catch ex As Exception
            Return Nothing
        End Try
        Return Nothing
    End Function

    Function ReporteProducto(ByVal lista As ListBox)
        Dim dt As New DataTable
        Dim dtfinal As New DataTable
        Try
            For i = 0 To lista.Items.Count - 1
                dt = Cobranza.FunctionGlobal(":idcliente▓" & lista.Items(i).Text, "QRYRCP001")
                If dt.Rows.Count <> 0 Then
                    dtfinal.Merge(dt, True)
                End If
            Next
        Catch ex As Exception
            dtfinal = Nothing
        End Try
        Return dtfinal
    End Function

    Function ActualizarClienteGestor() As Boolean
        Dim dt As New DataTable
        Dim dtdatos As New DataTable
        Dim estado As Boolean = False
        Dim SQLUpdate As String = ""
        Try
            Cobranza.FunctionGlobal("", "QRYAP001")
            estado = True
        Catch ex As Exception
            estado = False
        End Try
        Return estado
    End Function
End Class
