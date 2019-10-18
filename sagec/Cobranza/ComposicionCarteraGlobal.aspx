<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.Master" CodeBehind="ComposicionCarteraGlobal.aspx.vb" Inherits="Cobranza.Formulario_web121" 
    title="Composicion de Cartera Global" %>
<%@ Register src="Controles/ReporteComposicionCarteraGestor.ascx" tagname="ReporteComposicionCarteraGestor" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contenido" runat="server">
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
<table style="width:100%; text-align:center;">
<tr>
<td style="width:100%; text-align:center;" class="fondoPantalla">
    <uc1:ReporteComposicionCarteraGestor ID="ReporteComposicionCarteraGestor1" 
        runat="server" />
</td>
</tr>
</table>
</ContentTemplate>
</asp:UpdatePanel>
</asp:Content>
