<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="ResultadoConsultaMontoCliente.ascx.vb" Inherits="Controles.ResultadoConsultaMontoCliente" %>
<table style="width: 100%;">
<tr>
<td align="center">
    <asp:Label id="lblTituloControl" runat="server" Font-Size="13px"></asp:Label>
</td>
</tr>
</table>

<table style="width: 100%; height: 397px;">
	<tr>
		<td style="height: 500px" valign="top">
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
			<td align="left">
			<asp:Label id="Label16" runat="server" Font-Size="11px" Text="Existe(n):"></asp:Label>
			</td>
			<td>
			<asp:ImageButton id="imgExportarExcel" runat="server" Height="45px" Width="75px" 
                    ImageUrl="~/imagenes/BotonExportarExcel.jpg" />
			<br />
			<asp:Label id="Label28" runat="server" Font-Size="11px" Text="Exportar a Excel"></asp:Label>
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