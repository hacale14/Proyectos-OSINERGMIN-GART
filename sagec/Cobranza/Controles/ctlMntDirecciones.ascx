<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="ctlMntDirecciones.ascx.vb" Inherits="Controles.ctlMntDirecciones" %>
<%@ Register src="CtlTxt.ascx" tagname="CtlTxt" tagprefix="uc1" %>
<%@ Register src="CtlDpto.ascx" tagname="CtlDpto" tagprefix="uc2" %>
<%@ Register src="CtlDist.ascx" tagname="CtlDist" tagprefix="uc3" %>
<%@ Register src="CtlProv.ascx" tagname="CtlProv" tagprefix="uc4" %>
<%@ Register src="CtCombo.ascx" tagname="CtCombo" tagprefix="uc5" %>
<fieldset style="width:200px" >
<legend>Mantenimiento de Direcciones
</legend>
<table>
<tr>
<td><FONT COLOR=#640003><b>Direccion</b></FONT></td>
<td><uc1:CtlTxt ID="tztDireccion" runat="server" Largo="20" Ancho="200"  /></td>
</tr>
<tr>
<td><FONT COLOR=#640003><b>Tipo Direccion</b></FONT></td>
<td>
    <uc5:CtCombo ID="ctlTipoDireccion"  runat="server" />
    </td>
</tr>
<tr>
<td><FONT COLOR=#640003><b>Departamento</b></FONT></td>
<td>
    <uc2:CtlDpto ID="CtlDpto1" runat="server" />
    </td>
</tr>
<tr>
<td><FONT COLOR=#640003><b>Provincia</b></FONT></td>
<td>
    <uc4:CtlProv ID="CtlProv1" runat="server" />
    </td>
</tr>
<tr>
<td><FONT COLOR=#640003><b>Distrito</b></FONT></td>
<td>
    <uc3:CtlDist ID="CtlDist1" runat="server" />
    </td>
</tr>
</table> 
</fieldset>