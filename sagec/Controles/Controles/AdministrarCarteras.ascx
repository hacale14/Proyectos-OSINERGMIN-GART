<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="AdministrarCarteras.ascx.vb" Inherits="Controles.AdministrarCarteras" %>
<%@ Register src="CtlGrilla.ascx" tagname="CtlGrilla" tagprefix="uc1" %>
<%@ Register src="NuevaCartera.ascx" tagname="NuevaCartera" tagprefix="uc2" %>
<%@ Register src="CtCombo.ascx" tagname="CtCombo" tagprefix="uc3" %>

<%@ Register src="CtlMensajes.ascx" tagname="CtlMensajes" tagprefix="uc3" %>

<table style="width: 100%;" align="center">
<tr>
<td align="center" class="titulo">
    CONSULTA CARTERA
    <uc3:CtlMensajes ID="CtlMensajes1" runat="server" />
</td>
</tr>
</table>

<table style="width: 100%">
	<tr>
		<td style="width:100%;">
		<fieldset>
			<table width="100%">
				<tr>
				    <td align="center" style="width: 110px">
					    <asp:Label id="Label3" runat="server" Text="EMPRESA" CssClass="lbl"></asp:Label>
					</td>
					<td>
					    <uc3:CtCombo ID="cboEmpresa" runat="server" Activa="true" Procedimiento="QRYMG002" Longitud="180" />
					</td>
					<td align="center" style="width: 110px">
					    <asp:Label id="Label1" runat="server" Text="CÒDIGO" CssClass="lbl"></asp:Label>
					</td>
					<td>
					    <asp:TextBox id="txtCodCartera" runat="server" Width="150px" CssClass="textoContenido"></asp:TextBox>
					</td>
					<td align="center" style="width: 250px">
					    <asp:Label id="Label2" runat="server" Text="CARTERA" CssClass="lbl"></asp:Label>
					</td>
					<td>
					    <asp:TextBox id="txtCartera" runat="server" Width="150px" CssClass="textoContenido"></asp:TextBox>
					</td>
					<td>
					</td>
					<td style="text-align:right" width="50px" >
					<div class="curvo">
					    <asp:ImageButton id="imgBuscar" runat="server" ImageUrl="~/imagenes/boton busqueda.jpg" CssClass="curvoimg"/>
					    <asp:Label id="Label14" runat="server" Text="Buscar" CssClass="curvolbl"></asp:Label>
					</td>
				</tr>
			</table>
	    </fieldset>
		</td>
	</tr>
	<tr>
		<td>
		<fieldset>
		    <uc1:CtlGrilla ID="CtlGrilla1" runat="server" Largo="350px" Ancho="930px"  Activa_ckeck="false" Activa_option="false" Desactiva_Boton="false" OpocionNuevo="true"/>
	    </fieldset>
		</td>
	</tr>
</table>


<asp:Panel ID="pnlNuevaCartera" runat="server" Visible="false">
<div style="position:absolute; top:200px; left:30%;" class="fondo1">
<table>
<tr>
<td>
    <uc2:NuevaCartera ID="NuevaCartera1" runat="server" titulo="NUEVA CARTERA" />
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
    <uc2:NuevaCartera ID="NuevaCartera2" runat="server" titulo="MODIFICAR CARTERA" />
</td>
</tr>
</table>
</div>
</asp:Panel>