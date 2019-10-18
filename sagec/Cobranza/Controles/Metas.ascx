<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="Metas.ascx.vb" Inherits="Controles.Metas" %>


<%@ Register src="~/Controles/CtlGrilla.ascx" tagname="CtlGrilla" tagprefix="uc1" %>
<%@ Register src="CtCombo.ascx" tagname="CtCombo" tagprefix="uc2" %>
<%@ Register src="CtlTxt.ascx" tagname="CtlTxt" tagprefix="uc3" %>
<table style="width: 100%; box-shadow: 1px 1px 1px;" class="fondoPantalla" cellpadding="0" cellspacing="0" >
<tr>
    <td class="titulo" colspan="2">
        <asp:Label id="lblTituloControl" runat="server" Font-Size="13px" ForeColor="White" Font-Bold="true"></asp:Label>
    </td>
</tr>
<tr>
	<td>
	<fieldset>
	<legend> PAGOS REALIZADOS </legend>
	<table style="width: 100%" cellpadding="0"  cellspacing="0">
	<tr>
		<td><asp:Label id="Label1" runat="server" Font-Size="11px" Text="GESTOR"></asp:Label></td>
        <td><uc2:CtCombo ID="cboGestor" runat="server" Longitud="60"/></td>
		<td style="width: 50px"><asp:Label id="Label3" runat="server" Font-Size="11px" Text="DESDE"></asp:Label></td>
		<td style="width: 135px">
		    <asp:TextBox ID="txtFechaInicio" runat="server"  Width="80px" Enabled = "false" BackColor="White"/>
            <img ID="fecha2" alt="calendario" height="16"  onclick="return showCalendar('fecha2','<%=txtFechaInicio.ClientID%>','%d/%m/%Y','24', true);" 
            src="Imagenes/calendario.png" width="18" />
        </td>
		<td style="width: 50px">
		<asp:Label id="Label4" runat="server" Font-Size="11px" Text="HASTA"></asp:Label>
		</td>
		<td>
			<asp:TextBox ID="txtFechaFin" runat="server"  Width="80px" Enabled = "false" BackColor="White"/>
            <img ID="fecha3" alt="calendario" height="16"  onclick="return showCalendar('fecha3','<%=txtFechaInicio.ClientID%>','%d/%m/%Y','24', true);" 
            src="Imagenes/calendario.png" width="18" />
		</td>
		<td style="text-align:right">
			<div class="curvo">
			    <asp:ImageButton ID="btnEjecutar" runat="server" ToolTip="Generar Reporte" ImageUrl="~/Imagenes/BotonGenerarReporte.jpg" Width="30px" Height="30px" />
                <asp:Label ID="lblBuscar" runat="server" Text="Reporte" Font-Size="10px" Font-Bold="false" />
            </div>
		</td>
	</tr>
	</table>
	</fieldset>
	</td>
</tr>
<tr>
	<td>
	<fieldset>
	    <uc1:CtlGrilla ID="gvMetas" runat="server" Activa_ckeck="false" Activa_Delete="false" Activa_Edita="false" Activa_option="false" Desactiva_Boton="false" Ancho="500px" Largo="300px"  />
	</fieldset>
	</td>
</tr>
<tr>
	<td>
	<table style="width: 100%" cellpadding="0" cellspacing="0">
	<tr>
	    <td><asp:Label id="Label5" runat="server" Font-Size="11px" Text="TOTAL META" ForeColor="White"></asp:Label></td>
		<td><asp:Label id="Label6" runat="server" Font-Size="11px" Text="TOTAL PAGOS" ForeColor="White"></asp:Label></td>
		<td><asp:Label id="Label7" runat="server" Font-Size="11px" Text="% DE AVANCE" ForeColor="White"></asp:Label></td>
		<td style="text-align:right" rowspan="2" width="30px">
			<div class="curvo">
			<asp:ImageButton id="btnCerrar" runat="server" Height="30px" Width="30px" ImageUrl="~/Imagenes/BotonCerrar.jpg" />
			<asp:Label id="Label2" runat="server" Font-Size="11px" Text="Cerrar"></asp:Label>
			</div>
		</td>
	</tr>
	<tr>
		<td><uc3:CtlTxt ID="txtTotalMetas" runat="server" Ancho="90" Desactiva="false" /></td>
		<td><uc3:CtlTxt ID="txtTotalPagos" runat="server" Ancho="90" Desactiva="false" /></td>
		<td><uc3:CtlTxt ID="txtAvance" runat="server"  Ancho="90" Desactiva="false" /></td>
	</tr>
	</table>
</td>
</tr>
</table>