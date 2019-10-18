<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="CtlReasignar.ascx.vb" Inherits="Controles.CtlReasignar" %>

<table style="width: 100%">
		<tr>
			<td align="right" style="width: 108px">
			<asp:Label id="Label1" runat="server" Font-Size="11px" Text="DNI Cliente"></asp:Label>
			</td>
			<td align="left" style="width: 162px">
			<asp:TextBox id="TextBox1" runat="server" Font-Size="11px"></asp:TextBox>
			</td>
			<td align="center">
			<asp:ImageButton id="ImageButton1" runat="server" Height="46px" Width="75px" />
			</td>
		</tr>
		<tr>
			<td colspan="3" style="height: 70px"><fieldset style="margin:0; padding:0;" name="Group1">
			<legend></legend>
			<table style="width: 100%">
				<tr>
					<td style="width: 219px">
					<asp:Label id="Label2" runat="server" Font-Size="11px" Text="CLIENTE"></asp:Label>
					</td>
					<td>
					<asp:Label id="Label3" runat="server" Font-Size="11px" Text="CONDIC."></asp:Label>
					</td>
					<td>
					<asp:Label id="Label4" runat="server" Font-Size="11px" Text="G. ACTUAL"></asp:Label>
					</td>
				</tr>
				<tr>
					<td style="width: 219px">
					<asp:TextBox id="TextBox2" runat="server" Font-Size="11px" Width="220px"></asp:TextBox>
					</td>
					<td>
					<asp:TextBox id="TextBox3" runat="server" Font-Size="11px" Width="127px"></asp:TextBox>
					</td>
					<td>
					<asp:TextBox id="TextBox4" runat="server" Font-Size="11px" Width="127px"></asp:TextBox>
					</td>
				</tr>
			</table>
			<br />
			</fieldset></td>
		</tr>
		<tr>
			<td align="center" colspan="3">
			<table style="width: 100%">
				<tr>
					<td align="right">
					<asp:Label id="Label5" runat="server" Font-Size="11px" Text="Cambiar Gestor:"></asp:Label>
					</td>
					<td align="left">
					<asp:DropDownList id="DropDownList1" runat="server" Font-Size="11px" Height="16px">
						<asp:ListItem Value="0">Seleccione</asp:ListItem>
					</asp:DropDownList>
					</td>
				</tr>
			</table>
			</td>
		</tr>
		<tr>
			<td colspan="3">
			<table style="width: 100%">
				<tr>
					<td align="right">
					<asp:ImageButton id="ImageButton2" runat="server" Height="50px" Width="100px" />
					</td>
					<td>
					<asp:ImageButton id="ImageButton3" runat="server" Height="50px" Width="100px" />
					</td>
				</tr>
			</table>
			</td>
		</tr>
	</table>