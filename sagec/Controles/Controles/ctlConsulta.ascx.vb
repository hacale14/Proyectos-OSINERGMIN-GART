Imports BL
Public Class ctlConsulta
    Inherits System.Web.UI.UserControl
    Dim pidCliente As Integer
    Dim pidEmpresa As Integer
    Dim pDNI As String
    Dim pProcedimiento As String
    Dim Mensaje As String
    Public Property Titulo() As String
        Get
            Return lbltitulo.Text
        End Get
        Protected Set(ByVal value As String)
            lbltitulo.Text = value
        End Set
    End Property
    Public Property idCliente() As Integer
        Get
            Return pidCliente
        End Get
        Protected Set(ByVal value As Integer)
            pidCliente = value
        End Set
    End Property
    Public Property idEmpresa() As Integer
        Get
            Return pidEmpresa
        End Get
        Protected Set(ByVal value As Integer)
            pidEmpresa = value
        End Set
    End Property
    Public Property DNI() As String
        Get
            Return pDNI
        End Get
        Protected Set(ByVal value As String)
            pDNI = value
        End Set
    End Property
    Public Property Procedimiento() As String
        Get
            Return pProcedimiento
        End Get
        Protected Set(ByVal value As String)
            pProcedimiento = value
        End Set
    End Property
    Public Sub Carga_Consulta_Compromisos(ByVal idCliente As Integer, ByVal Procedieminto As String)

        If Len(Trim(Procedieminto)) > 0 Then
            Carga_Grilla("idcliente= " & idCliente, Procedieminto)
            Me.Visible = True
        End If

    End Sub
    Public Sub Carga_Consulta_Pagos(ByVal idCliente As Integer, ByVal Procedieminto As String)

        If Len(Trim(Procedieminto)) > 0 Then
            Carga_Grilla("idcliente= " & idCliente, Procedieminto)
            Me.Visible = True
        End If

    End Sub
    Public Sub Carga_Consulta_Deuda(ByVal idCliente As Integer, ByVal Procedieminto As String)

        If Len(Trim(Procedieminto)) > 0 Then
            Carga_Grilla("idcliente= " & idCliente, Procedieminto)
            Me.Visible = True
        End If

    End Sub
    Public Sub Carga_Consulta_Informacion_Adicional(ByVal DNI As String, ByVal idEmpresa As Integer, ByVal Procedieminto As String)

        If Len(Trim(Procedieminto)) > 0 Then
            Carga_Grilla("DNI like '" & DNI & "%' and idEmpresa=" & idEmpresa, Procedieminto)
            Me.Visible = True
        End If

    End Sub
    Public Function Carga_Grilla(ByVal Criterio As String, ByVal pSP As String) As Integer
        Dim fnc = New BL.Cobranza
        CtlGrilla1.SourceDataTable = fnc.FunctionGlobal(":criterio▓" & Criterio, pSP)
        Return CtlGrilla1.GV.Rows.Count
    End Function

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button1.Click
        Me.Visible = False
    End Sub
End Class