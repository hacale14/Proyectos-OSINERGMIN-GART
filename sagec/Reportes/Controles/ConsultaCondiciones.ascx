<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="ConsultaCondiciones.ascx.vb" Inherits="Controles.ConsultaCondiciones" %>
<%@ Register src="CtlGrilla.ascx" tagname="CtlGrilla" tagprefix="uc1" %>
<%@ Register src="NuevaCondicion.ascx" tagname="NuevaCondicion" tagprefix="uc2" %>
<table width="100%">
    <tr >
    <td class="titulo">
       CONSULTA DE CONDICIONES 
    </td>
    </tr>
	<tr>
		<td>
			<fieldset>
			<table style="width: 100%" border="0">
				<tr>
					<td align="center" style="width: 350px">
					    <asp:Label id="Label1" runat="server" Font-Size="11px" Text="CÒDIGO" CssClass="lbl"></asp:Label>
					</td>
					<td style="width: 200px;">
					    <asp:TextBox id="txtCOdigo" runat="server" CssClass="textoContenido" Width="150px"></asp:TextBox>
					</td>
					<td align="center" style="width: 80px">
					    <asp:Label id="Label2" runat="server" Font-Size="11px" Text="DESCRIPCION" CssClass="lbl"></asp:Label>
					</td>
					<td style="width: 200px;">
					    <asp:TextBox id="txtDescripcion" runat="server" CssClass="textoContenido" Width="150px"></asp:TextBox>
					</td>
					<td style="width: 30px;"></td>
					<td style="text-align:right" width="35px" >
					<div class="curvo">
					<asp:ImageButton id="imgBuscar" runat="server" ImageUrl="~/imagenes/boton busqueda.jpg" CssClass="curvoimg"/>
					<asp:Label id="Label14" runat="server" Text="Buscar" CssClass="curvolbl"></asp:Label>
					</td>
					<td></td>
				</tr>
			</table>
			</fieldset>
		</td>
	</tr>	
	<tr>
		<td>
		    <fieldset>
			    <uc1:CtlGrilla ID="CtlGrilla1" runat="server"  Desactiva_Boton="false" Largo="300px" Activa_ckeck="false" Activa_option="false" OpocionNuevo="true"/>
			</fieldset>
		</td>
	</tr>
</table>

<asp:Panel ID="pnlNuevaCartera" runat="server" Visible="false">
<div style="position:absolute; top:200px; left:30%;" class="fondo1">
<table>
<tr>
<td>    
    <uc2:NuevaCondicion ID="NuevaCondicion1" runat="server" titulo="NUEVA CONDICION" />    
</td>
</tr>
</table>
</div>
</asp:Panel>

<asp:Panel ID="pnlModificarCartera" runat="server" Visible="false">
<div style="position:absolute; top:200px; left:30%;" class="fondo1">
<table>
<tr>
<td>    
    <uc2:NuevaCondicion ID="NuevaCondicion2" runat="server" titulo="MODIFICAR CONDICION" />    
</td>
</tr>
</table>
</div>
</asp:Panel>
