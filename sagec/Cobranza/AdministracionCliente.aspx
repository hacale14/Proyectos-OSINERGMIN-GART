<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.Master" CodeBehind="AdministracionCliente.aspx.vb" Inherits="Cobranza.AdministracionCliente" 
    title="Administracion Cliente" %>
<%@ Register src="Controles/ConsultaClientes.ascx" tagname="ConsultaClientes" tagprefix="uc1" %>
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
<td class="fondoPantalla">
    <uc1:ConsultaClientes ID="ConsultaClientes1" runat="server" Titulo="Consulta de Cliente" />
</td>
</tr>
</table>
</ContentTemplate>
</asp:UpdatePanel>
</asp:Content>
