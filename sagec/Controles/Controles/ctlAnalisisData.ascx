<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="ctlAnalisisData.ascx.vb" Inherits="Controles.ctlAnalisisData" %>

<%@ Register src="CtCombo.ascx" tagname="CtCombo" tagprefix="uc1" %>

<div id="Aviso" runat="server" style="border-style:outset;background-color:#FBFBEF;">
<table width="100%">
<tr>
    <td style="text-align:justify; font-size:x-small; font-family:Calibri Light;">
    Este proceso realiza una comparacion entre la data importada desde el archivo en Excel
    y la data existente en la base de datos del sistema, con el fin de actualizar los datos del cliente
    y sus operaciones.
    </td>
</tr>
</table>
</div>
<div id="Operacion" runat="server" style="text-align:justify; font-size:x-small; font-family:Calibri Light; width:auto" >
<fieldset style="margin:0; padding:0;">
<legend> Archivo </legend>
<table width="100%" cellpadding="0" cellspacing="0">
<tr>
    <td rowspan="2" height="40px" width="35%">
        <asp:RadioButtonList ID="RDB" runat="server" style="font-size:x-small; font-family:Calibri Light;" >
        <asp:ListItem Value="0" Text = "Actualizar Data Actual"></asp:ListItem> 
        <asp:ListItem Value="1" Text = "Agregar Nueva Cartera"></asp:ListItem> 
        </asp:RadioButtonList>
    </td>
</tr>
<tr>
    <td valign="top">
        <uc1:CtCombo ID="CboData" runat="server" />
    </td>
</tr>
<tr>
    <td colspan="2"></td>
</tr>
<tr>
    <td style="text-align:center" colspan="2">
        &nbsp;</td>
</tr>
</table>
</fieldset>
</div>