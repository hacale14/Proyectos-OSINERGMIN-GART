<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="CarteraCastigo.ascx.vb" Inherits="Controles.CarteraCastigo" %>
<table style="width: 100%;">
<tr>
<td align="center">
    <asp:Label id="lblTituloControl" runat="server" Font-Size="13px"></asp:Label>
</td>
</tr>
</table>

<table align="left" style="width: 49%">
		<tr valign="middle">
			<td align="right" style="width: 208px">
			<asp:Label id="Label1" runat="server" Font-Size="11px" Text="Cliente"></asp:Label>
			</td>
			<td style="width: 262px">
			<asp:TextBox id="txtCliente" runat="server" Font-Size="11px" Width="164px"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;
			<asp:ImageButton id="imgBusqueda" runat="server" Height="20px" Width="20px" 
                    ImageUrl="~/imagenes/BotonBusquedaPequena.png" />
			</td>
		</tr>
		<tr>
			<td align="right" style="width: 208px">
			<asp:Label id="Label2" runat="server" Font-Size="11px" Text="Fecha"></asp:Label>
			</td>
			<td style="width: 262px">
			<asp:DropDownList id="cboFecha" runat="server" Font-Size="11px" Width="120px">
				<asp:ListItem Value="0">Seleccione</asp:ListItem>
			</asp:DropDownList>
			</td>
		</tr>
		<tr>
			<td align="right" style="width: 208px">
			<asp:Label id="Label3" runat="server" Font-Size="11px" Text="N° Operacion"></asp:Label>
			</td>
			<td style="width: 262px">
			<asp:DropDownList id="cboNOperacion" runat="server" Font-Size="11px" Width="180px">
				<asp:ListItem Value="0">Seleccione</asp:ListItem>
			</asp:DropDownList>
			</td>
		</tr>
		<tr>
			<td align="right" style="width: 208px">
			<asp:Label id="Label4" runat="server" Font-Size="11px" Text="Pago"></asp:Label>
			</td>
			<td style="width: 262px">
			<asp:TextBox id="txtPago" runat="server" Font-Size="11px" Width="164px"></asp:TextBox>
&nbsp;&nbsp;
			<asp:DropDownList id="cboTipoPago" runat="server" Font-Size="11px">
				<asp:ListItem Value="0">Seleccione</asp:ListItem>
			</asp:DropDownList>
			</td>
		</tr>
		<tr>
			<td align="right" style="width: 208px">
			<asp:Label id="Label5" runat="server" Font-Size="11px" Text="Observacion"></asp:Label>
			</td>
			<td style="width: 262px">
			<asp:TextBox id="txtObservacion" runat="server" Font-Size="11px" Width="350px"></asp:TextBox>
			</td>
		</tr>
		<tr>
			<td align="center" colspan="2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
			<table style="width: 100%">
				<tr align="center">
					<td>
					<asp:ImageButton id="imgCerrar" runat="server" Height="60px" Width="80px" 
                            ImageUrl="~/imagenes/BotonGrabar.png" />
					<br />
					<asp:Label id="Label6" runat="server" Font-Size="11px" Text="Grabar"></asp:Label>
					</td>
					<td>
					<asp:ImageButton id="imgCerrar0" runat="server" Height="60px" Width="80px" 
                            ImageUrl="~/imagenes/BotonCerrar.jpg" />
					<br />
					<asp:Label id="Label7" runat="server" Font-Size="11px" Text="Cerrar"></asp:Label>
					</td>
				</tr>
			</table>
			</td>
		</tr>
	</table>