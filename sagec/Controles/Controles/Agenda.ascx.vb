'************************************************************************************************************************
'***** Autor: EMPRESA PIMAY 
'***** DESCRIPCION: MULTIPLES CONEXIONES 
'************************************************************************************************************************
Imports System.Web.UI

Partial Public Class Agenda
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub imgAgendar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgAgendar.Click
        Try
            Dim loadmodule As UserControl
            loadmodule = Me.LoadControl("Agendar.ascx")
            place.Controls.Add(loadmodule)
        Catch ex As Exception
            Response.Write(ex.ToString & "<br />")
        End Try
    End Sub

End Class