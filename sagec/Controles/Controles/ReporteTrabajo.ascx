<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="ReporteTrabajo.ascx.vb" Inherits="Controles.ReporteTrabajo" %>
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
					<br />
					</td>
					<td>
					<br />
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
			    <uc1:CtlGrilla ID="CtlGrilla1"  runat="server" Largo="300px" Ancho="930px" Activa_ckeck="false" Activa_Delete="false" Activa_Edita="false" Activa_option="false" Desactiva_Boton="false"/>
			</td>
		</tr>
		<tr align="center">
			<td align="center" style="text-align:center;">
			<asp:ImageButton id="imgRpteCompromiso" runat="server" Height="45px" Width="75px" 
                    ImageUrl="~/Imagenes/BotonExportarExcel.jpg" />
			<br />
			<asp:Label id="Label23" runat="server" Font-Size="11px" Text="Exportar a Excel"></asp:Label>
			</td>
			<td align="center" style="text-align:center;">
			<asp:ImageButton id="imgCerrar" runat="server" Height="45px" Width="75px" 
                    ImageUrl="~/imagenes/BotonCerrar.jpg" />
			<br />
			<asp:Label id="Label21" runat="server" Font-Size="11px" Text="Cerrar"></asp:Label>
			</td>
		</tr>
	</table>