<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="Agendar.ascx.vb" Inherits="Controles.Agendar" %>
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
		<td>
			<fieldset style="margin:0; padding:0;">
			<legend>
			<asp:Label id="Label2" runat="server" Font-Size="11px" Text="Cliente"></asp:Label>
			</legend>
			<table style="width: 100%; margin-right: 0px;">
				<tr>
					<td>
					<table style="width: 100%">
						<tr>
							<td style="width: 709px" valign="middle">
							<asp:Label id="Label4" runat="server" Font-Size="11px" Text="Cliente"></asp:Label>
&nbsp;<asp:DropDownList id="DropDownList1" runat="server" Font-Size="11px" Height="16px" Width="145px">
								<asp:ListItem>Seleccione</asp:ListItem>
							</asp:DropDownList>
&nbsp;<asp:TextBox id="TextBox1" runat="server" Font-Size="11px" Width="142px"></asp:TextBox>
							<asp:TextBox id="TextBox2" runat="server" Font-Size="11px" Width="359px"></asp:TextBox>
							</td>
							<td align="center" rowspan="2">
							<asp:ImageButton id="imgAceptar" runat="server" Height="50px" Width="60px" 
                                    ImageUrl="~/imagenes/BotonAceptar.jpg" />
							</td>
						</tr>
						<tr>
							<td style="width: 709px">
							<asp:Label id="Label5" runat="server" Font-Size="11px" Text="Agenda"></asp:Label>
&nbsp;<asp:TextBox ID="txtFechaIni1" runat="server"  Width="100px" Enabled = "false" BackColor="White" BorderColor="Black" BorderWidth = "1" Font-Size="11px" />
                            <img id="fecha11" alt="calendario" height="24" valign="middle"
                            onclick="return showCalendar('fecha11','<%=txtFechaIni1.ClientID%>','%d/%m/%Y','24', true);" 
                            src="../../Imagenes/calendario.png" width="24" />
&nbsp;<asp:Label id="Label6" runat="server" Font-Size="11px" Text="Ho"></asp:Label>
&nbsp;<asp:TextBox id="TextBox3" runat="server" Font-Size="11px" Width="38px"></asp:TextBox>
&nbsp;<asp:Label id="Label7" runat="server" Font-Size="11px" Text="Mi"></asp:Label>
&nbsp;<asp:TextBox id="TextBox4" runat="server" Font-Size="11px" Width="38px"></asp:TextBox>
&nbsp;<asp:Label id="Label8" runat="server" Font-Size="11px" Text="Se"></asp:Label>
&nbsp;<asp:TextBox id="TextBox5" runat="server" Font-Size="11px" Width="38px"></asp:TextBox>
							</td>
						</tr>
					</table>
					</td>
				</tr>
				<tr>
					<td>
					<asp:Label id="Label9" runat="server" Font-Size="11px" Text="Mensaje"></asp:Label>
					<br />
					<asp:TextBox id="TextBox6" runat="server" Height="70px" Width="837px"></asp:TextBox>
					</td>
				</tr>
			</table>
			</fieldset>
		</td>
	</tr>
</table>