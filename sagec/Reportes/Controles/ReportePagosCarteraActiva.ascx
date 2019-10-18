<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="ReportePagosCarteraActiva.ascx.vb" Inherits="Controles.ReportePagosCarteraActiva" %>
<table style="width: 100%;">
<tr>
<td align="center">
    <asp:Label id="lblTituloControl" runat="server" Font-Size="13px"></asp:Label>
</td>
</tr>
</table>

<table style="width: 100%">
	<tr>
		<td style="height: 500px">
	<fieldset style="margin:0; padding:0;" name="Group1">
	<legend>
	<asp:Label id="Label12" runat="server" Font-Size="11px" Text="FILTRAR POR"></asp:Label>
	</legend>
	<table style="width: 100%" align="center">
		<tr align="center">
			<td>
			<asp:Label id="Label1" runat="server" Font-Size="11px" Text="CARTERA"></asp:Label>
			</td>
			<td>
			<asp:Label id="Label20" runat="server" Font-Size="11px" Text="GESTOR"></asp:Label>
			</td>
			<td>
			<asp:Label id="Label26" runat="server" Font-Size="11px" Text="INICIO"></asp:Label>
			</td>
			<td style="width: 75px">
			<asp:Label id="Label27" runat="server" Font-Size="11px" Text="FIN"></asp:Label>
			</td>
			<td>
			<asp:Label id="Label29" runat="server" Font-Size="11px" Text="CONCEPTO"></asp:Label>
			</td>
			<td>
			<asp:Label id="Label30" runat="server" Font-Size="11px" Text="Moneda"></asp:Label>
			</td>
			<td align="center" rowspan="2">
			<asp:ImageButton id="imgBuscar" runat="server" Height="30px" 
                    ImageUrl="~/imagenes/boton busqueda.jpg" Width="45px" />
			<br />
			<asp:Label id="Label19" runat="server" Font-Size="11px" Text="Buscar"></asp:Label>
			</td>
		</tr>
		<tr align="center">
			<td>
			<asp:DropDownList id="cboCartera" runat="server" Font-Size="10px">
				<asp:ListItem Value="0">Seleccione</asp:ListItem>
			</asp:DropDownList>
			</td>
			<td>
			<asp:DropDownList id="cboGestor" runat="server" Font-Size="10px">
				<asp:ListItem Value="0">Seleccione</asp:ListItem>
			</asp:DropDownList>
			</td>
			<td>
			<asp:DropDownList id="cboInicio" runat="server" Font-Size="10px">
				<asp:ListItem Value="0">Seleccione</asp:ListItem>
			</asp:DropDownList>
			</td>
			<td style="width: 75px">
			<asp:DropDownList id="cboFin" runat="server" Font-Size="10px">
				<asp:ListItem Value="0">Seleccione</asp:ListItem>
			</asp:DropDownList>
			</td>
			<td>
			<asp:TextBox id="txtConcepto" runat="server" Font-Size="11px"></asp:TextBox>
			</td>
			<td>
			<asp:DropDownList id="cboMoneda" runat="server" Font-Size="10px">
				<asp:ListItem Value="0">Seleccione</asp:ListItem>
			</asp:DropDownList>
			</td>
		</tr>
	</table>
	</fieldset><br />
	<div style="height: 325px">
		<asp:GridView id="GridView1" runat="server" Font-Size="10px">
		</asp:GridView>
		<br />
		<br />
		<br />
		<br />
		<br />
		<br />
		<br />
	</div>
	<table style="width: 100%">
		<tr align="center">
			<td>
			<asp:ImageButton id="imgExportarExcel" runat="server" Height="45px" Width="75px" 
                    ImageUrl="~/imagenes/BotonExportarExcel.jpg" />
			<br />
			<asp:Label id="Label16" runat="server" Font-Size="11px" Text="Exportar a Excel"></asp:Label>
			</td>
			<td>
			<asp:ImageButton id="imgVerTodasGestiones" runat="server" Height="45px" 
                    Width="75px" ImageUrl="~/imagenes/VerTodasGestiones.png" />
			<br />
			<asp:Label id="Label28" runat="server" Font-Size="11px" Text="Ver Todas las Gestiones"></asp:Label>
			</td>
			<td>
			<asp:ImageButton id="imgCerrar" runat="server" Height="45px" Width="75px" 
                    ImageUrl="~/imagenes/BotonCerrar.jpg" />
			<br />
			<asp:Label id="Label18" runat="server" Font-Size="11px" Text="Cerrar"></asp:Label>
			</td>
		</tr>
	</table>
		</td>
	</tr>
</table>