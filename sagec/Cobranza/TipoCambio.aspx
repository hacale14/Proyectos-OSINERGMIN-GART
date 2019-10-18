<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.Master" CodeBehind="TipoCambio.aspx.vb" Inherits="Cobranza.Formulario_web18" 
    title="Tipo de Cambio" %>
<%@ Register src="Controles/TipoCambio.ascx" tagname="TipoCambio" tagprefix="uc1" %>
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
    <table style="width:100%;" >
        <tr>
            <td style="text-align:center; width:100%;" class="fondoPantalla">
                <uc1:TipoCambio ID="TipoCambio1" runat="server" />
            </td>
        </tr>
    </table>
</ContentTemplate>
</asp:UpdatePanel>
</asp:Content>
