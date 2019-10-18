<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="ConsultarProductoMontoCliente.ascx.vb" Inherits="Controles.ConsultarProductoMontoCliente" %>
<%@ Register src="CtlGrilla.ascx" tagname="CtlGrilla" tagprefix="uc1" %>
<%@ Register src="CtlMensajes.ascx" tagname="CtlMensajes" tagprefix="uc2" %>
<%@ Register src="CtCombo.ascx" tagname="CtCombo" tagprefix="uc3" %>

<%@ Register src="ReporteProductoOperacionCliente.ascx" tagname="ReporteProductoOperacionCliente" tagprefix="uc4" %>

<table style="width: 100%;align="center">
<tr align="center">
<td align="center" style="text-align:center;" class="titulo">
    <asp:Label id="lblTituloControl" runat="server"></asp:Label>
    <uc2:CtlMensajes ID="CtlMensajes1" runat="server" />
</td>
</tr>
</table>

<table style="width:100%;">
	<tr>
		<td>
	<fieldset>
	<legend>
	FILTRAR POR
	</legend>
	<table style="width: 100%" align="center">
		<tr align="center">
			<td>
			CARTERA
			<br />
			    <uc3:CtCombo ID="cboCartera" runat="server" Activa="true" 
                Procedimiento="QRYC007" Condicion="" Longitud="100" AutoPostBack="true" />
			</td>
			<td>
			GESTOR
			<br />
			    <uc3:CtCombo ID="cboGestor" runat="server" Activa="true" 
                Condicion="" Longitud="60" />
		    </td>
		    <td>
			PRODUCTO
			<br />
			<asp:TextBox id="txtProducto" runat="server" Font-Size="11px"></asp:TextBox>
			</td>
			<td>
			NEGOCIO
			<br />
			<asp:TextBox id="txtNegocio" runat="server" Font-Size="11px"></asp:TextBox>
			</td>
			<td>
			<br />
			    <uc3:CtCombo ID="cboOpcion" runat="server" Activa="true" 
                Condicion=":condicion▓107" Procedimiento="QRYMG001" Longitud="40" />
			</td>
			<td>
			CAPITAL
			<br />
			<asp:TextBox id="txtCapital" runat="server" Font-Size="11px"></asp:TextBox>
			</td>
			<td>
			MONEDA
			<br />
			    <uc3:CtCombo ID="cboMoneda" runat="server" Activa="true" 
                Condicion=":condicion▓103" Procedimiento="QRYMG001" Longitud="40" />
			</td>
			<td>
			<br />
			    <uc3:CtCombo ID="cboOpcion2" runat="server" Activa="true" 
                Condicion=":condicion▓107" Procedimiento="QRYMG001" Longitud="40" />
			</td>
			<td>
			D. TOTAL
			<br />
			<asp:TextBox id="txtDTotal" runat="server" Font-Size="11px"></asp:TextBox>
			</td>
			<td>
			MONEDA
			<br />
			    <uc3:CtCombo ID="cboMoneda2" runat="server" Activa="true" 
                Condicion=":condicion▓103" Procedimiento="QRYMG001" Longitud="40" />
			</td>
			<td>
			CONDICION
			<br />
			    <uc3:CtCombo ID="cboCondicion" runat="server" Activa="true" 
                Procedimiento="QRYCGC001" Longitud="60" />
			</td>
			<td align="center" style="text-align:center;">
			<div class="curvo" id="Div1" runat="server">
			    <asp:ImageButton id="imgBuscar" runat="server" Height="30px" 
                ImageUrl="~/imagenes/boton busqueda.jpg" Width="45px" />
				<asp:Label id="Label19" runat="server" Font-Size="11px" Text="Buscar"></asp:Label>
			</div>
			</td>
		</tr>		
	</table>
	</fieldset>
	<fieldset>
	<table style="width: 100%">
		<tr align="center" style="text-align:center;">
			<td colspan="2">
			    <uc1:CtlGrilla ID="CtlGrilla1" runat="server" Largo="300px" Ancho="900px" Activa_ckeck="false" Activa_Delete="false" Activa_Edita="false" Activa_option="false" Desactiva_Boton="false"/>
			</td>
		</tr>
		<tr>
		    <td align="center" style="text-align:center;">
					<div class="curvo">
					<asp:ImageButton id="imgCerrar" runat="server" Height="30px" Width="35px" 
                            ImageUrl="~/imagenes/BotonCerrar.jpg" />
					<asp:Label id="Label7" runat="server" Font-Size="11px" Text="Cerrar"></asp:Label>
					</div>
			</td>
			<td align="center" style="text-align:center;">
					<div class="curvo">
					<asp:ImageButton id="imgReporte" runat="server" Height="30px" Width="35px" 
                            ImageUrl="~/imagenes/BotonReporte.jpg" />
					<asp:Label id="Label1" runat="server" Font-Size="11px" Text="Reporte"></asp:Label>
					</div>
			</td>
		</tr>
	</table>
	</fieldset>
		</td>
	</tr>
</table>


<asp:Panel ID="pnlReporte" runat="server" Visible="false">
<div style="position:absolute; top:100px; left:5%;" class="fondo1">
<table>
<tr>
<td>     
    <uc4:ReporteProductoOperacionCliente ID="ReporteProductoOperacionCliente1" 
        runat="server" Titulo="Reporte Producto con Operaciones del Cliente" />
</td>
</tr>
</table>
</div>
</asp:Panel>