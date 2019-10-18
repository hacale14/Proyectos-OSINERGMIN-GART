<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="ReporteCampoCartera.ascx.vb" Inherits="Controles.ReporteCampoCartera" %>
<table style="width: 100%;">
<tr>
<td align="center">
    <asp:Label id="lblTituloControl" runat="server" Font-Size="13px"></asp:Label>
</td>
</tr>
</table>

<table style="width: 100%">
		<tr>
			<td valign="top">
			<table style="width: 100%">
				<tr>
					<td style="height: 23px">
					<table style="width: 100%">
						<tr>
							<td align="left">
			<asp:Label id="Label3" runat="server" Font-Size="11px" Text="CARTERA"></asp:Label>
							<br />
			<asp:DropDownList id="cboCartera" runat="server" Font-Size="10px" Height="20px" Width="187px">
				<asp:ListItem Value="0">Seleccione</asp:ListItem>
			</asp:DropDownList>
							</td>
							<td align="center">
			<asp:ImageButton id="imgGenerarReporte" runat="server" Height="29px" 
                                    ImageUrl="~/imagenes/BotonGenerarReporte.jpg" Width="45px" />
							<br />
			<asp:Label id="Label4" runat="server" Font-Size="11px" Text="Generar Reporte"></asp:Label>
							</td>
						</tr>
					</table>
					</td>
				</tr>
				<tr>
					<td>
					<div>
						<asp:GridView id="GridView2" runat="server">
						</asp:GridView>
						<br />
					</div>
					&nbsp;</td>
				</tr>
				<tr>
					<td>
					<table style="width: 100%">
						<tr>
							<td align="right">
			<asp:Label id="Label5" runat="server" Font-Size="11px" Text="Total Clientes Cartera"></asp:Label>
							</td>
							<td>
							<asp:TextBox id="txtTotalClienteCartera" runat="server" Font-Size="11px" Height="21px" Width="106px"></asp:TextBox>
							</td>
						</tr>
					</table>
					</td>
				</tr>
				<tr>
					<td>
					<table style="width: 100%">
						<tr align="center">
							<td>
			<asp:ImageButton id="imgExportarExcel0" runat="server" Height="45px" Width="75px" 
                                    ImageUrl="~/imagenes/BotonExportarExcel.jpg" />
							<br />
			<asp:Label id="Label6" runat="server" Font-Size="11px" Text="Exportar a Excel"></asp:Label>
							</td>
							<td>
			<asp:ImageButton id="imgVerGrafico" runat="server" Height="45px" Width="75px" 
                                    ImageUrl="~/imagenes/BotonVerEstadisticas.jpg" />
							<br />
			<asp:Label id="Label7" runat="server" Font-Size="11px" Text="Ver Grafico"></asp:Label>
							</td>
							<td>
			<asp:ImageButton id="imgCerrar" runat="server" Height="45px" Width="75px" 
                                    ImageUrl="~/imagenes/BotonCerrar.jpg" />
							<br />
			<asp:Label id="Label8" runat="server" Font-Size="11px" Text="Cerrar"></asp:Label>
							</td>
						</tr>
					</table>
					</td>
				</tr>
			</table>
			</td>
			<td valign="top">
			<div>
				<asp:GridView id="GridView1" runat="server">
				</asp:GridView>
			</div>
			</td>
		</tr>
	</table>