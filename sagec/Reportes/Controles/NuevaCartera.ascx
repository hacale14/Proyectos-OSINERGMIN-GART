<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="NuevaCartera.ascx.vb" Inherits="Controles.NuevaCartera" %>
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
			<asp:Label id="Label8" runat="server" Font-Size="11px" Text="Empresa"></asp:Label>
			</td>
			<td>
			<uc2:CtCombo ID="cboEmpresa" runat="server" Activa="true" 
                            Procedimiento="QRYMG002"  />
            <asp:TextBox id="txtEmpresa" runat="server" Font-Size="11px" Visible="false"></asp:TextBox>
            <asp:Button ID="btnAgregarEmpresa" runat="server" Text="Agregar Empresa" />
            <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" Visible="false" />            
			</td>
		</tr>
		<tr>
			<td align="right">
			<asp:Label id="Label1" runat="server" Font-Size="11px" Text="Código"></asp:Label>
			</td>
			<td>
			<asp:TextBox id="txtCodigo" runat="server" Font-Size="11px"></asp:TextBox>
			<asp:Label id="lblIdCartera" runat="server" Font-Size="11px" Visible="false"></asp:Label>
			</td>
		</tr>
		<tr>
			<td align="right">
			<asp:Label id="Label2" runat="server" Font-Size="11px" Text="Cartera"></asp:Label>
			</td>
			<td>
			<asp:TextBox id="txtCartera" runat="server" Font-Size="11px" Width="245px"></asp:TextBox>
			</td>
		</tr>
		<tr>
			<td align="right">
			<asp:Label id="Label3" runat="server" Font-Size="11px" Text="Tipo Cartera"></asp:Label>
			</td>
			<td>
			    <uc2:CtCombo ID="cboTipo" runat="server" Activa="true" 
                            Condicion=":condicion▓100" Procedimiento="QRYMG001"  />
			</td>
		</tr>
		<tr>
		    <td align="right">
			<asp:Label id="Label9" runat="server" Font-Size="11px" Text="Grupo de Cartera"></asp:Label>
			</td>
			<td>
			    <uc2:CtCombo ID="cbogrpcartera" runat="server" Activa="true" Procedimiento="SQL_GRP_CARTERA001" Condicion=":id_grp_cartera▓0"  />
			</td>
		</tr>
		<tr>
			<td align="right">
			<asp:Label id="Label4" runat="server" Font-Size="11px" Text="Meta"></asp:Label>
			</td>
			<td>
			<asp:TextBox id="txtMeta" runat="server" Font-Size="11px" Width="90px"></asp:TextBox>
			<asp:Label id="Label5" runat="server" Font-Size="11px" Text="Soles"></asp:Label>
			</td>
		</tr>
		<tr>
			<td align="right">
			<asp:Label id="Label10" runat="server" Font-Size="11px" Text="Meta Timming PDP"></asp:Label>
			</td>
			<td>
			<asp:TextBox id="txtPDPT" runat="server" Font-Size="11px" Width="90px"></asp:TextBox>
			<asp:Label id="Label11" runat="server" Font-Size="11px" Text="Soles"></asp:Label>
			</td>
		</tr>
		<tr>
			<td align="right">
			<asp:Label id="Label12" runat="server" Font-Size="11px" Text="Meta Timing Recupero"></asp:Label>
			</td>
			<td>
			<asp:TextBox id="txtRECT" runat="server" Font-Size="11px" Width="90px"></asp:TextBox>
			<asp:Label id="Label13" runat="server" Font-Size="11px" Text="Soles"></asp:Label>
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