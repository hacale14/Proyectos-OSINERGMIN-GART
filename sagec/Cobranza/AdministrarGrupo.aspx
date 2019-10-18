<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.Master" CodeBehind="AdministrarGrupo.aspx.vb" Inherits="Cobranza.AdministrarGrupo" 
    title="Administrar Grupos" %>
<%@ Register src="Controles/CtlAdmGrupos.ascx" tagname="CtlAdmGrupos" tagprefix="uc1" %>

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

<table  style="width:100%; text-align:center;">
<tr>
<td style="width:100%;text-align:center;" class="fondoPantalla">
    <uc1:CtlAdmGrupos ID="Grupos" runat="server" Titulo="CONSULTA DE GRUPOS"/>
</td>
</tr>
</table>
</ContentTemplate>
</asp:UpdatePanel>
</asp:Content>

