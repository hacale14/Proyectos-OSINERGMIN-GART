'************************************************************************************************************************
'***** Autor: EMPRESA PIMAY 
'***** DESCRIPCION: MULTIPLES CONEXIONES 
'************************************************************************************************************************
Partial Public Class Botones
    Inherits System.Web.UI.UserControl

    Public Property Titulo_Principal() As String
        Get
            Return lblTituloPrincipal.Text
        End Get
        Set(ByVal value As String)
            lblTituloPrincipal.Text = value
        End Set
    End Property
    Public Property DtBusquedaGestor() As DataTable
        Get
            Dim dt As DataTable = Nothing
            If Titulo_Principal = "BUSQUEDA POR DATOS DE CLIENTE" Then
                dt = Session("DTBGSR1")
            ElseIf Titulo_Principal = "BUSQUEDA DE DATOS DE OPERACION - CASTIGO" Then
                dt = Session("DTBGSR2")
            ElseIf Titulo_Principal = "BUSQUEDA DE DATOS DE OPERACION - ACTIVA" Then
                dt = Session("DTBGSR3")
            End If
            Return dt
        End Get
        Set(ByVal value As DataTable)
            If Titulo_Principal = "BUSQUEDA POR DATOS DE CLIENTE" Then
                Session("DTBGSR1") = value
            ElseIf Titulo_Principal = "BUSQUEDA DE DATOS DE OPERACION - CASTIGO" Then
                Session("DTBGSR2") = value
            ElseIf Titulo_Principal = "BUSQUEDA DE DATOS DE OPERACION - ACTIVA" Then
                Session("DTBGSR3") = value
            End If
        End Set
    End Property

    Event ButtonClick(ByVal Nombre)
    Private Sub btnNuevo_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnNuevo.Click
        NAsignacion1.Visible = True
        NAsignacion1.Titulo = "NUEVA ASIGNACION"
    End Sub
    Private Sub btnDefinirCD_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnDefinirCD.Click
        DefinirCondicion1.Visible = True
        DefinirCondicion1.Titulo = "DEFINIR CONDICION"
    End Sub

    Private Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            Session("DTBGSR1") = ""
            Session("DTBGSR2") = ""
            Session("DTBGSR3") = ""
        End If
    End Sub
End Class