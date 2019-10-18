<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.Master" CodeBehind="ReporteGestionExterna.aspx.vb" Inherits="Cobranza.Formulario_web111" 
    title="Reporte de Gestion Externo" %>

<%@ Register src="Controles/ReporteGestionInterno.ascx" tagname="ReporteGestionInterno" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Contenido" runat="server">
<asp:UpdatePanel runat="server" ID="UpdatePanel1">
<ContentTemplate>
<table style="background-color:White; width:100%; text-align:center;">
<tr>
<td style="background-color:White; width:100%; text-align:center;">    
    <uc1:ReporteGestionInterno ID="ReporteGestionInterno1" runat="server" VerImportar="false"/>    
</td>
</tr>
</table>
</ContentTemplate>
</asp:UpdatePanel>
</asp:Content>
