<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.Master" CodeBehind="CAReporteGestionInterno.aspx.vb" Inherits="Cobranza.Formulario_web115" 
    title="Reporte de Gestion Interno" %>
<%@ Register src="Controles/ReporteGestionInterno.ascx" tagname="ReporteGestionInterno" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contenido" runat="server">
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>
<table style="width:100%; background-color:White; text-align:center;">
<tr>
<td style="width:100%; background-color:White; text-align:center;">
    <uc1:ReporteGestionInterno ID="ReporteGestionInterno1" runat="server" VerImportar="false"/>    
</td>
</tr>
</table>
</ContentTemplate>
</asp:UpdatePanel>
</asp:Content>
