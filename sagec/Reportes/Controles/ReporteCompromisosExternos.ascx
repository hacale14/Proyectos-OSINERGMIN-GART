<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="ReporteCompromisosExternos.ascx.vb" Inherits="Controles.ReporteCompromisosExternos" %>
<%@ Register src="CtlGrilla.ascx" tagname="CtlGrilla" tagprefix="uc1" %>
<table style="width: 100%;" align="center">
<tr align="center">
<td align="center" style="text-align:center;">
    <asp:Label id="lblTituloControl" runat="server" Font-Size="16px" 
        Font-Bold="True"></asp:Label>
</td>
</tr>
</table>
	
	<table style="width: 100%">
		<tr>
			<td colspan="2">
			<table style="width: 100%">
				<tr>
					<td>
			<asp:Label id="Label2" runat="server" Font-Size="11px" Text="CARTERA"></asp:Label>
					<br />
			<asp:DropDownList id="cboCartera" runat="server" Font-Size="10px">
				<asp:ListItem Value="0">Seleccione</asp:ListItem>
			</asp:DropDownList>
					</td>
					<td>
			<asp:Label id="Label3" runat="server" Font-Size="11px" Text="GESTOR"></asp:Label>
					<br />
			<asp:DropDownList id="cboGestor" runat="server" Font-Size="10px">
				<asp:ListItem Value="0">Seleccione</asp:ListItem>
			</asp:DropDownList>
					</td>
					<td>
			<asp:Label id="Label4" runat="server" Font-Size="11px" Text="FECHA INICIO"></asp:Label>
					<br />
			                <asp:TextBox ID="txtFechaInicio" runat="server"  Width="100px" Enabled = "false" BackColor="White" BorderColor="Black" BorderWidth = "1" Font-Size="11px" />
                            <img id="fecha1" alt="calendario" height="24" valign="middle"
                            onclick="return showCalendar('fecha1','<%=txtFechaInicio.ClientID%>','%d/%m/%Y','24', true);" 
                            src="~/Imagenes/calendario.png" width="24" />					
							
					</td>
					<td>
			<asp:Label id="Label22" runat="server" Font-Size="11px" Text="FECHA FIN"></asp:Label>
					<br />
			                <asp:TextBox ID="txtFechaFin" runat="server"  Width="100px" Enabled = "false" BackColor="White" BorderColor="Black" BorderWidth = "1" Font-Size="11px" />
                            <img id="fecha2" alt="calendario" height="24" valign="middle"
                            onclick="return showCalendar('fecha1','<%=txtFechaFin.ClientID%>','%d/%m/%Y','24', true);" 
                            src="~/Imagenes/calendario.png" width="24" />							
							
					</td>
					<td align="center">
			<asp:ImageButton id="imgBuscar" runat="server" Height="30px" 
                            ImageUrl="~/imagenes/boton busqueda.jpg" Width="45px" />
					<br />
			<asp:Label id="Label19" runat="server" Font-Size="11px" Text="Buscar"></asp:Label>
					</td>
				</tr>
			</table>
			</td>
		</tr>
		<tr>
			<td colspan="2">
			<div style="width:100%; overflow:scroll; height:300px;">
				<uc1:CtlGrilla ID="CtlGrilla1" runat="server" />
			</div>
			</td>
		</tr>
		<tr align="center">
			<td style="text-align:center;">
			<asp:ImageButton id="imgRpteCompromiso" runat="server" Height="45px" Width="75px" 
                    ImageUrl="~/imagenes/BotonReporte.jpg" />
			<br />
			<asp:Label id="Label23" runat="server" Font-Size="11px" Text="Rpte Compromiso"></asp:Label>
			</td>
			<td style="text-align:center;">
			<asp:ImageButton id="imgCerrar" runat="server" Height="45px" Width="75px" 
                    ImageUrl="~/imagenes/BotonCerrar.jpg" />
			<br />
			<asp:Label id="Label21" runat="server" Font-Size="11px" Text="Cerrar"></asp:Label>
			</td>
		</tr>
	</table>