<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="Agenda.ascx.vb" Inherits="Controles.Agenda" %>
<%@ Register src="CtlGrilla.ascx" tagname="CtlGrilla" tagprefix="uc1" %>
<table style="width: 100%;" align="center">
<tr align="center">
<td align="center" style="text-align:center;" class="titulo">
    AGENDA
</td>
</tr>
</table>

<table style="width:100%;">
	<tr>
		<td>
			<fieldset style="margin:0; padding:0;">
			<legend >
			<asp:Label id="Label2" runat="server" Font-Size="11px" Text="FILTRO DE LA AGENDA"></asp:Label>
			</legend>
			<table style="width: 100%">
				<tr>
					<td><fieldset style="margin:0; padding:0;">
					<legend style="width: 119px">
					<asp:Label id="Label3" runat="server" Font-Size="11px" Text="Fecha Agendada"></asp:Label>
					</legend>
					<table style="width: 100%">
						<tr>
							<td>
							<asp:Label id="Label4" runat="server" Font-Size="11px" Text="Desde"></asp:Label>
							</td>
							<td>
							<asp:TextBox ID="txtFechaInicio" runat="server"  Width="100px" Enabled = "false" BackColor="White" BorderColor="Black" BorderWidth = "1" Font-Size="11px" />
                            <img id="fecha1" alt="calendario" height="24" valign="middle"
                            onclick="return showCalendar('fecha1','<%=txtFechaInicio.ClientID%>','%d/%m/%Y','24', true);" 
                            src="../../Imagenes/calendario.png" width="24" />
							</td>
							<td>
							<asp:Label id="Label5" runat="server" Font-Size="11px" Text="Hasta"></asp:Label>
							</td>
							<td>
							<asp:TextBox ID="txtFechaFin" runat="server"  Width="100px" Enabled = "false" BackColor="White" BorderColor="Black" BorderWidth = "1" Font-Size="11px" />
                            <img id="fecha2" alt="calendario" height="24" valign="middle"
                            onclick="return showCalendar('fecha2','<%=txtFechaFin.ClientID%>','%d/%m/%Y','24', true);" 
                            src="../../Imagenes/calendario.png" width="24" />							
							</td>
						</tr>
					</table>
					</fieldset></td>
					<td align="center" style="text-align:center;">
					<div class="curvo">
					<asp:ImageButton id="imgBuscar" runat="server" Height="30px" Width="35px" 
                            ImageUrl="~/imagenes/BotonBuscarContacto.jpg" />
					<asp:Label id="Label6" runat="server" Font-Size="11px" Text="Buscar"></asp:Label>
					</div>
					</td>
					<td align="center" style="text-align:center;">
					<div class="curvo">
					<asp:ImageButton id="imgAgendar" runat="server" Height="30px" Width="35px" 
                            ImageUrl="~/imagenes/BotonAgendar.png" />
					<asp:Label id="Label7" runat="server" Font-Size="11px" Text="Agendar"></asp:Label>
					</div>
					</td>
				</tr>
			</table>
			</fieldset></form>
		</td>
	</tr>
	<tr>
		<td>
		<fieldset>
		<legend>AGENDAS ENCONTRADAS</legend>
			<uc1:CtlGrilla ID="CtlGrilla1" runat="server" />
		</fieldset>
		</td>
	</tr>
</table>
<table>
    <tr>
        <td style="width:100%;">
            <asp:Panel ID="place" runat="server" Width="100%"></asp:Panel>
        </td>
    </tr>
</table>
