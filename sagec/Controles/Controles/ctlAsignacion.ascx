<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="ctlAsignacion.ascx.vb" Inherits="Controles.ctlAsignacion" %>

<%@ Register src="CtCombo.ascx" tagname="CtCombo" tagprefix="uc1" %>
<%@ Register src="CtlTxt.ascx" tagname="CtlTxt" tagprefix="uc2" %>

<div id="Div1" runat="server" style="width:auto" >
<table width="100%" style="text-align:justify; font-size:x-small; font-family:Calibri Light;">
<tr>
    <td width="25%"><asp:Label ID="lblCartera" runat="server" Text="Cartera: " /></td>
    <td><uc1:CtCombo ID="cboCartera" runat="server" /></td>
</tr>
<tr>
    <td><asp:Label ID="lblCantidad" runat="server" Text="Cantidad de Clientes: " /></td>
    <td><uc2:CtlTxt ID="txtCantidad" runat="server" />
        <uc2:CtlTxt ID="CtlTxt1" runat="server" />
    </td>
</tr>
</table>
</div>
<div id="Div2" runat="server" style="text-align:justify; font-size:x-small; font-family:Calibri Light;width:auto;">
<fieldset style="margin:0; padding:0;">
<table width="100%" style="text-align:center; font-size:x-small; font-family:Calibri Light;">
<tr>
    <td width="8%">De: </td>
    <td width="10%"><asp:TextBox ID="txtDesde" runat="server" Width="50px" /></td>
    <td width="8%">Hasta: </td>
    <td width="10%"><asp:TextBox ID="txtHasta" runat="server" Width="50px" /></td>
    <td width="8%">A: </td>
    <td><uc1:CtCombo ID="CtCombo1" runat="server" Ancho="10px" /></td>
</tr>
</table>
</fieldset>
</div>