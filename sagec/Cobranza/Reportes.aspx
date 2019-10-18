<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.Master" CodeBehind="Reportes.aspx.vb" Inherits="Cobranza.Reportes" 
    title="Página sin título" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contenido" runat="server">
    <table class="style1">
        <tr>
            <td width=20%>
                
                <fieldset>                                
                <legend>Cartera</legend>
                    <asp:CheckBoxList ID="lstCartera" runat="server" AutoPostBack="True">
                        <asp:ListItem>FALABELLA</asp:ListItem>
                        <asp:ListItem>BCP</asp:ListItem>
                    </asp:CheckBoxList>
                </fieldset>
            </td>
            <td width=80%>asdasdasdsad
                </td>
        </tr>        
    </table>
</asp:Content>
