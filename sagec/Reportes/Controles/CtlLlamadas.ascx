<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="CtlLlamadas.ascx.vb" Inherits="Controles.CtlLlamadas" %>
<style type="text/css">
    .style1
    {
        width: 100%;
    }
    .style2
    {
        width: 100px;
    }
    .style3
    {
        width: 288px;
    }
    .style4
    {
        width: 493px;
    }
</style>
<table class="fondo1">
    <tr>
        <td class="style2">
            <asp:ImageButton ID="ImageButton1" runat="server" Height="125px" 
                ImageUrl="Imagens/gTelf.gif" Width="145px" />
        </td>
        <td class="style3">
            <asp:Label ID="Label1" runat="server" Font-Size="XX-Large" Text="999999999999"></asp:Label>
        </td>
        <td class="style4">
            <asp:ImageButton ID="ImageButton2" runat="server" Height="62px" 
                ImageUrl="Imagenes/BotonEliminar.png" Width="70px" />
        </td>
    </tr>
</table>
