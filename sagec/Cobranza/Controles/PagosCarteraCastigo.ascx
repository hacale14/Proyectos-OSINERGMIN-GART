<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="PagosCarteraCastigo.ascx.vb" Inherits="Controles.PagosCarteraCastigo" %>
<%@ Register src="CtlGrilla.ascx" tagname="CtlGrilla" tagprefix="uc1" %>
<table style="width: 100%;">
<tr>
<td align="center">
    <asp:Label id="lblTituloControl" runat="server" Font-Size="13px"></asp:Label>
</td>
</tr>
</table>

<fieldset style="margin:0; padding:0;">
	<legend>
	<asp:Label id="Label12" runat="server" Font-Size="11px" Text="FILTRAR POR"></asp:Label>
	</legend>
	<table style="width: 100%">
		<tr align="center">
			<td><asp:Label id="Label1" runat="server" Font-Size="11px" Text="DNI"></asp:Label></td>
			<td><asp:Label id="Label2" runat="server" Font-Size="11px" Text="CLIENTE"></asp:Label></td>
			<td><asp:Label id="Label3" runat="server" Font-Size="11px" Text="INICIO"></asp:Label></td>
			<td><asp:Label id="Label6" runat="server" Font-Size="11px" Text="FIN"></asp:Label></td>
			<td><asp:Label id="Label7" runat="server" Font-Size="11px" Text="CARTERA"></asp:Label></td>
			<td align="center" rowspan="2">
			<asp:ImageButton id="ImageButton1" runat="server" Height="30px" ImageUrl="~/imagenes/boton busqueda.jpg" Width="45px" />
			</td>
		</tr>
		<tr align="center">
			<td><asp:TextBox id="txtDNI" runat="server" Font-Size="10px" Width="100px"></asp:TextBox></td>
			<td><asp:TextBox id="txtCliente" runat="server" Font-Size="10px" Width="200px"></asp:TextBox></td>
			<td>
			<asp:DropDownList id="cboInicio" runat="server" Font-Size="10px" Width="120px">
				<asp:ListItem Value="0">Seleccione</asp:ListItem>
			</asp:DropDownList>
			</td>
			<td>
			<asp:DropDownList id="cboInicio0" runat="server" Font-Size="10px" Width="120px">
				<asp:ListItem Value="0">Seleccione</asp:ListItem>
			</asp:DropDownList>
			</td>
			<td>
			<asp:DropDownList id="cboInicio1" runat="server" Font-Size="10px" Width="120px">
				<asp:ListItem Value="0">Seleccione</asp:ListItem>
			</asp:DropDownList>
			</td>
		</tr>
	</table>
</fieldset>
<div id="Div1" runat="server" style="height: 300px; width: auto; overflow:scroll">

    <uc1:CtlGrilla ID="CtlGrilla1" runat="server" />

</div>
<div id = "Div2" runat="server" style="height: auto; width: auto; text-align:center">
<table style="width: 100%">
	<tr align="center">
		<td align="right">
			<asp:ImageButton id="ImageButton3" runat="server" Height="45px" Width="75px" 
                    ImageUrl="~/imagenes/botonNuevo.jpg" />
			<br />
			<asp:Label id="Label14" runat="server" Font-Size="11px" Text="Nuevo"></asp:Label>
		</td>
		<td>
			<asp:ImageButton id="ImageButton5" runat="server" Height="45px" Width="75px" 
                    ImageUrl="~/imagenes/BotonMetas.png" />
			<br />
			<asp:Label id="Label16" runat="server" Font-Size="11px" Text="Ver Metas"></asp:Label>
		</td>
		<td>
			<asp:ImageButton id="ImageButton6" runat="server" Height="45px" Width="75px" 
                    ImageUrl="~/imagenes/BotonExportarExcel.jpg" />
			<br />
			<asp:Label id="Label17" runat="server" Font-Size="11px" Text="Exportar a Excel"></asp:Label>
		</td>
		<td>
			<asp:ImageButton id="ImageButton7" runat="server" Height="45px" Width="75px" 
                    ImageUrl="~/imagenes/BotonCerrar.jpg" />
			<br />
			<asp:Label id="Label18" runat="server" Font-Size="11px" Text="Cerrar"></asp:Label>
		</td>
		</tr>
</table>
</div>
