<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="CtlCuadroMensaje.ascx.vb" Inherits="Controles.CtlCuadroMensaje" %>
<table style="width: 100%;" align="center">
<tr align="center">
<td align="center" style="text-align:center;" class="titulo">
    <asp:Label id="lblTituloControl" runat="server"></asp:Label>
</td>
</tr>
</table>

<fieldset>
<table style="width: 100%;" align="center">
<tr align="center">
<td align="center" style="text-align:center;" colspan="2">
    <asp:Label id="lblContexto" runat="server"></asp:Label>
    <asp:Label id="lblVariable" runat="server" Visible="false"></asp:Label>
</td>
</tr>
<tr>
<td style="text-align:center;">
    <asp:Button ID="btnSi" runat="server" Text="SI"/>
</td>
<td style="text-align:center;">
    <asp:Button ID="btnNO" runat="server" Text="NO"/>
</td>
</tr>
</table>
</fieldset>
