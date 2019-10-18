<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.Master" CodeBehind="Consulta.aspx.vb" Inherits="Cobranza.Formulario_web15" 
    title="Administracion Condicion" %>

<%@ Register src="Controles/ConsultaCondiciones.ascx" tagname="ConsultaCondiciones" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Contenido" runat="server">
<asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
<ProgressTemplate>
    <div class="modal2">
        <div class="center">
            <img alt="" src="Imagenes/loader.gif" />
        </div>
    </div>
</ProgressTemplate>
</asp:UpdateProgress>

<asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate> 
<table width="100%">
<tr>
<td class="fondoPantalla" style="width:100%">
    <uc1:ConsultaCondiciones ID="ConsultaCondiciones1" runat="server" />    
</td>
</tr>
</table>
</ContentTemplate>
</asp:UpdatePanel>
</asp:Content>
