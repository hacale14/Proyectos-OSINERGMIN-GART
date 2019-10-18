<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.Master" CodeBehind="Agenda.aspx.vb" Inherits="Cobranza.Formulario_web19" 
    title="Agenda" %>
<%@ Register src="Controles/Agenda.ascx" tagname="Agenda" tagprefix="uc1" %>
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
<Triggers>
<asp:PostBackTrigger ControlID="Agenda1" />
</Triggers>
<ContentTemplate>
<table style="width:100%;">
<tr>
<td style="width:100%; text-align:center;" class="fondoPantalla">
    <uc1:Agenda ID="Agenda1" runat="server" />
</td>
</tr>
</table>
</ContentTemplate>
</asp:UpdatePanel>
</asp:Content>
