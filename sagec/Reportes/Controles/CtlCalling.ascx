<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="CtlCalling.ascx.vb" Inherits="Controles.CtlCalling" %>

<%@ Register src="CtCombo.ascx" tagname="CtCombo" tagprefix="uc1" %>
<%@ Register src="CtlTxt.ascx" tagname="CtlTxt" tagprefix="uc2" %>

<div style="font-size: 11px;">
<fieldset style="margin:0; padding:0;">
<legend>GESTION COBRANZA</legend>
<table width="100%">
<tr>
    <td colspan="5" style="text-align:right"><asp:Label id="lblGestor" runat="server" Text="GESTOR: " Font-Size="11px"/></td>
    <td width="20%" style="text-align:left">
        <uc2:CtlTxt ID="CtlTxt1" runat="server"  Ancho="50" Desactiva="false"/>
    </td>
</tr>
<tr>
    <td><asp:Label id="lblFecha" runat="server" Text="Fecha: " Font-Size="11px" /></td>
    <td>
        <uc2:CtlTxt ID="txtFecha1" runat="server" Ancho="100" Desactiva="false" />
        <img ID="fecha" alt="calendario" height="24" valign="middle"
        onclick="return showCalendar('fecha','ctl00_ContenPlaceHolder1_txtFecha1','%d/%m/%Y','24', true);" 
        src="~/Imagenes/calendario.png" width="24" />
    </td>
    <td><asp:Label id="Label1" runat="server" Text="Hora: " Font-Size="11px"/></td>
    <td><asp:Label id="lblHora" runat="server" Text="" Font-Size="11px" /></td>
    <td><asp:Label id="lblTipoGestion" runat="server" Text="Tipo Gestion: " Font-Size="11px"/></td>
    <td>
        <uc1:CtCombo ID="CtCombo1" runat="server"  Longitud="100"  />
	</td>
</tr>
<tr>
    <td><asp:Label ID="lblDiscado" runat="server" Text="Discado: " Font-Size="11px" /></td>
    <td colspan="3">
        <uc1:CtCombo ID="CtCombo3" runat="server" Longitud="100"/>
    </td>
    <td><asp:Label ID="lblDetalleGestion" runat="server" Text="Detalle Gestion: " Font-Size="11px" /></td>
    <td>
        <uc1:CtCombo ID="CtCombo2" runat="server" Longitud="100"/>
    </td>
</tr>
<tr>
    <td><asp:Label ID="lblTelefono" runat="server" Text="Telefono: " Font-Size="11px"/></td>
    <td>
        <uc1:CtCombo ID="CtCombo4" runat="server" Longitud="100"/>
    </td>
    <td><asp:Label ID="lblIndicador" runat="server" Text="Indicador: " Font-Size="11px"/></td>
    <td colspan="4">
        <uc1:CtCombo ID="CtCombo5" runat="server" Longitud="200"/>
    </td>
</tr>
<tr>
    <td colspan="6" style="text-align:left">
        <asp:Button id="btnLlamar" runat="server" Text="Llamar" />
    </td>
</tr>
<tr>
    <td colspan="6" style="text-align:center">
        <textarea cols="100" id="txtArea" runat="server" Font-Size="11px" 
            style="height: 100px">
        </textarea>
    </td>
</tr>
<tr>
    <td colspan="6" style="text-align:center">
        <asp:ImageButton ID="btnGrabar" runat="server" ToolTip="Grabar" ImageUrl="~/Imagenes/BotonGrabar.png" Width="40px" Height="35px" />
        <asp:ImageButton ID="btnCerrar" runat="server" ToolTip="Cerrar" ImageUrl="~/Imagenes/BotonCerrar.jpg" Width="40px" Height="35px" />
    </td>
</tr>
</table>
</fieldset>
</div>