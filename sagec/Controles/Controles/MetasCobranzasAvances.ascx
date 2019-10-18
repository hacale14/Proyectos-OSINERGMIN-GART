<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="MetasCobranzasAvances.ascx.vb" Inherits="Controles.MetasCobranzasAvances" %>
<%@ Register src="CtlGrilla.ascx" tagname="CtlGrilla" tagprefix="uc1" %>
<table style="width: 100%;" align="center">
<tr align="center">
<td align="center" style="text-align:center;">
    INFORMACION CLIENTE Y OPERACION
</td>
</tr>
</table>

<table style="width: 100%">
		<tr>
			<td style="width: 96px">
			<fieldset>
			<legend>FILTRAR POR</legend>
			<table align="center" style="width: 100%">
				<tr>
					<td align="center">
					<asp:Label id="Label1" runat="server" Font-Size="11px" Text="Gestor"></asp:Label>
					</td>
				</tr>
				<tr>
					<td align="center">
					<asp:DropDownList id="cboGestor" runat="server" Font-Size="11px">
						<asp:ListItem Value="0">Seleccione</asp:ListItem>
					</asp:DropDownList>
					</td>
				</tr>
			</table>
			</fieldset>
			</td>
			<td style="width: 321px"><fieldset style="margin:0; padding:0;" name="Group1">
			<legend>
			<asp:Label id="Label2" runat="server" Font-Size="11px" Text="Pagos realizados"></asp:Label>
			</legend>
			<table style="width: 100%">
				<tr>
					<td align="right">
					<asp:Label id="Label3" runat="server" Font-Size="11px" Text="Desde"></asp:Label>
					</td>
					<td>
					<asp:TextBox ID="txtFechaInicio" runat="server"  Width="100px" Enabled = "false" BackColor="White" BorderColor="Black" BorderWidth = "1" Font-Size="11px" />
                            <img id="fecha1" alt="calendario" height="24" valign="middle"
                            onclick="return showCalendar('fecha1','<%=txtFechaInicio.ClientID%>','%d/%m/%Y','24', true);" 
                            src="../../Imagenes/calendario.png" width="24" />							
					</td>
					<td align="right">
					<asp:Label id="Label4" runat="server" Font-Size="11px" Text="Hasta"></asp:Label>
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
			<asp:ImageButton id="imgGenerarReporte" runat="server" Height="30px" Width="35px" 
                    ImageUrl="~/imagenes/BotonGenerarReporte.jpg" />
					<asp:Label id="Label8" runat="server" Font-Size="11px" 
                    Text="Reporte"></asp:Label>
            </div>
			</td>
		</tr>
		<tr>
			<td colspan="3">
			    <fieldset>
			    <legend>METAS Y COBRANZAS ENCONTRADAS</legend>
			        <uc1:CtlGrilla ID="CtlGrilla1" runat="server" />
			    </fieldset>
			</td>
		</tr>
		<tr>
			<td colspan="3">
			<fieldset>
			<table style="width: 100%">
				<tr align="center">
					<td align="center">
					<asp:Label id="Label5" runat="server" Font-Size="11px" Text="Total Meta"></asp:Label>
					<br />
					s/.
					<asp:TextBox id="txtTotalMeta" runat="server" Font-Size="11px"></asp:TextBox>
					</td>
					<td>
					<asp:Label id="Label6" runat="server" Font-Size="11px" Text="Total Pagos"></asp:Label>
					<br />
					s/.<asp:TextBox id="txtTotalPagos" runat="server" Font-Size="11px"></asp:TextBox>
					</td>
					<td>
					<asp:Label id="Label7" runat="server" Font-Size="11px" Text="% de Avance"></asp:Label>
					<br />
					<asp:TextBox id="txtAvance" runat="server" Font-Size="11px"></asp:TextBox>
					</td>
					<td align="center" style="text-align:center;">
					<div class="curvo">
					<asp:ImageButton id="imgCerrar" runat="server" Height="30px" Width="35px" 
                            ImageUrl="~/imagenes/BotonCerrar.jpg" />
					<asp:Label id="Label9" runat="server" Font-Size="11px" Text="Cerrar"></asp:Label>
				    </div>
					</td>
				</tr>
			</table>
			</fieldset>
			</td>
		</tr>
	</table>