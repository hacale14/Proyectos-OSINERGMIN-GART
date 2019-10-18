<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="CtlMensajeAlerta.ascx.vb" Inherits="Controles.CtlMensajeAlerta" %>
<style type="text/css">
    .style1
    {
        width: 100%;
    }
    .style2
    {
        width: 34px;
    }
</style>
<table cellpadding="0" cellspacing="0" class="style1">
    <tr>
        <td colspan="2">
            Mensaje de Alerta</td>
    </tr>
    <tr>
        <td class="style2"><img src="../Imagenes/user.png" 
                style="height: 36px; width: 34px"/></td>
        <td>
            Mensaje de Alerta</td>
    </tr>
    <tr>
        <td colspan="2">
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        </td>
    </tr>
    <tr>
        <td align="center" colspan="2">
            <asp:Button ID="Button1" runat="server" Text="Cerrar" />
        </td>
    </tr>
</table>
