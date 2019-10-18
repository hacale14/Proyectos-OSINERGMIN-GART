<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.Master" CodeBehind="ReporteCompromisoExterno.aspx.vb" Inherits="Cobranza.Formulario_web12" 
    title="Página sin título" %>
<%@ Register src="Controles/ReporteCompromisos.ascx" tagname="ReporteCompromisos" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Contenido" runat="server">
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>
<table style="background-color:White; width:100%; text-align:center;">
<tr>
<td style="background-color:White; width:100%; text-align:center;">
    <uc1:ReporteCompromisos ID="ReporteCompromisos1" runat="server" VerExportar="false"/>
</td>
</tr>
</table>
</ContentTemplate>
</asp:UpdatePanel>
</asp:Content>
