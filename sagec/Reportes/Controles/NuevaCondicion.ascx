<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="NuevaCondicion.ascx.vb" Inherits="Controles.Condicion" %>
<%@ Register src="CtlMensajes.ascx" tagname="CtlMensajes" tagprefix="uc1" %>

<table style="width: 100%;" align="center">
<tr align="center">
<td align="center" style="text-align:center;">
    <asp:Label id="lblTituloControl" runat="server" CssClass="titulo"></asp:Label>
    <uc1:CtlMensajes ID="CtlMensajes1" runat="server" />
</td>
</tr>
</table>
<fieldset>
<table style="width: 26%">
		<tr>
			<td align="right">
			<asp:Label id="Label1" runat="server" Text="Código"></asp:Label>
			</td>
			<td>
			<asp:TextBox id="txtCodigo" runat="server"></asp:TextBox>
			<asp:Label id="lblIdCondicion" runat="server" Visible="false"></asp:Label>
			</td>
		</tr>
		<tr>
			<td align="right">
			<asp:Label id="Label2" runat="server" Text="Descripcion"></asp:Label>
			</td>
			<td>
			<asp:TextBox id="txtDescripcion" runat="server" Font-Size="11px" Width="262px"></asp:TextBox>
			</td>
		</tr>
		<tr>
			<td colspan="2">
			<table style="width: 100%">
				<tr>
					<td align="center" style="text-align:center;">
					<div class="curvo">
					<asp:ImageButton id="imgGrabar" runat="server" Height="30px" Width="35px" 
                            ImageUrl="~/imagenes/BotonGrabar.png" />
					<asp:Label id="Label3" runat="server" Text="Grabar"></asp:Label>
					</div>
					</td>
					<td align="center" style="text-align:center;">
					<div class="curvo">
					<asp:ImageButton id="imgCerrar" runat="server" Height="30px" Width="35px" 
                            ImageUrl="~/imagenes/BotonCerrar.jpg" />
					<asp:Label id="Label4" runat="server"  Text="Cerrar"></asp:Label>
					</div>
					</td>
				</tr>
			</table>
			</td>
		</tr>
	</table>
</fieldset>