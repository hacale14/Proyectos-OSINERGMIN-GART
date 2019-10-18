<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="NuevaEmpresa.ascx.vb" Inherits="Controles.NuevaEmpresa" %>
<%@ Register src="CtlMensajes.ascx" tagname="CtlMensajes" tagprefix="uc1" %>
<%@ Register src="CtCombo.ascx" tagname="CtCombo" tagprefix="uc2" %>
<table style="width: 100%;" align="center">
<tr align="center">
<td align="center" style="text-align:center;" class="titulo">
    <asp:Label id="lblTituloControl" runat="server" ></asp:Label>
    <uc1:CtlMensajes ID="CtlMensajes1" runat="server" />
</td>
</tr>
</table>
<fieldset>
<table style="width: 100%">
        <tr>
			<td align="right">
			<asp:Label id="Label9" runat="server" Font-Size="11px" Text="id"></asp:Label>
			</td>
			<td>
            <asp:Label ID="lblIdEmpresa" runat="server" Visible="false"></asp:Label>
            <asp:Label ID="lblTipo" runat="server" Visible="false"></asp:Label>
			</td>
		</tr>
        <tr>
			<td align="right">
			<asp:Label id="Label8" runat="server" Font-Size="11px" Text="Empresa"></asp:Label>
			</td>
			<td>
            <asp:TextBox id="txtEmpresa" runat="server" Font-Size="11px"></asp:TextBox>
			</td>
		</tr>		        
	</table>
</fieldset>
<table style="width: 100%">
	<tr>
		<td align="center" style="text-align:center;">
		<div class="curvo">
		    <asp:ImageButton id="imgGrabar" runat="server" Height="30px" Width="35px" 
                ImageUrl="~/imagenes/BotonGrabar.png" />
		    <asp:Label id="Label6" runat="server" Font-Size="11px" Text="Grabar"></asp:Label>
		</div>			
		</td>
		<td align="center" style="text-align:center;">
		<div class="curvo">
		<asp:ImageButton id="imgCerrar" runat="server" Height="30px" Width="35px" 
                ImageUrl="~/imagenes/BotonCerrar.jpg" />
		<asp:Label id="Label7" runat="server" Font-Size="11px" Text="Cerrar"></asp:Label>
		</div>
		</td>
	</tr>
</table>