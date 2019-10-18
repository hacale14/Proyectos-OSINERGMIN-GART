<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="BusquedaDeuda.ascx.vb" Inherits="Controles.BusquedaDeuda" %>

<%@ Register src="CtlGrilla.ascx" tagname="CtlGrilla" tagprefix="uc1" %>
<table style="width: 100%;">
<tr>
<td align="center">
    <asp:Label id="lblTituloControl" runat="server" Font-Size="13px"></asp:Label>
</td>
</tr>
</table>

<div style="font-size:11px; height:auto;width:auto">
<fieldset style="margin:0; padding:0;">
<legend>DETALLE DE DEUDA</legend>
<div style="font-size:11px; height:250px;width:auto; overflow:scroll">

    <uc1:CtlGrilla ID="CtlGrilla1" runat="server" />

</div>
</fieldset>
<div style="font-size:11px; height:auto;width:auto;">
<table width="100%" style="font-size:11px;">
<tr>
    <td width="10%">Existe(n): </td>
    <td><asp:Label id="lblCantidad" runat="server"></asp:Label></td>
    <td style="text-align:right"><asp:ImageButton id="ImageButton4" runat="server" Height="45px" Width="75px" 
					 ImageUrl="~/Imagenes/BotonCerrar.jpg"/></td>
</tr>
</table>
</div>
</div>
