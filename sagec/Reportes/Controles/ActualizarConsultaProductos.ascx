<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="ActualizarConsultaProductos.ascx.vb" Inherits="Controles.ActualizarConsultaProductos" %>
<%@ Register src="ConsultarProductoMontoCliente.ascx" tagname="ConsultarProductoMontoCliente" tagprefix="uc1" %>
<%@ Register src="ReporteProductoOperacionCliente.ascx" tagname="ReporteProductoOperacionCliente" tagprefix="uc2" %>
<%@ Register src="CtlMensajes.ascx" tagname="CtlMensajes" tagprefix="uc3" %>
<table style="width: 100%;" align="center">
<tr align="center">
<td align="center" style="text-align:center;" class="titulo">
    <asp:Label id="lblTituloControl" runat="server" ></asp:Label>
</td>
</tr>
</table>
<center>
<table style="width: 65%; margin:auto;" border="0">
		<tr>
			<td style="text-align:center; margin:auto;">
			<fieldset>
			<table border=0 width="100%">
				<tr>
					<td colspan="2" style="text-align:center; margin:0 auto;">
					<asp:TextBox id="TextBox1" runat="server" Height="100px" TextMode="MultiLine" Width="605px" Font-Size="17px" CssClass="textoContenido">
					Este porceso permitirá actualizar los gestores asignados a clientes para realizar CONSULSULTA DE PRODUCTOS por gestor y otros criterios. El proceso debe ejecutarse si se hicieron cambios en la asigna. Despues del proceso podrá realizar las consultas haciendo click en el botpon CONSULTAR PRODUCTOS
					</asp:TextBox>
					</td>
				</tr>
				<tr>
					<td colspan="2">&nbsp;</td>
				</tr>
				<tr>
					<td style="float:right; margin-right:120px;">
					    <div class="curvoaplica" style="width:220px;"> 
					        <asp:ImageButton id="imgActualizarGestores" runat="server" CssClass="curvoimg" ImageUrl="~/imagenes/BotonActualizar.png" />
							<asp:Label id="Label22" runat="server" CssClass="curvolbl" Text="Actualizar Gestores"></asp:Label>
					    </div>
				    </td>
					<td style="float:left;padding-left:120px;">
					        <div class="curvoacepta" style="width:220px;">
					        <asp:ImageButton id="imgConsultarProductos" runat="server" CssClass="curvoimg" ImageUrl="~/imagenes/BotonMetas.png" />
							<asp:Label id="Label23" runat="server" CssClass="curvolbl" Text="Consultar Productos"></asp:Label>
							</div>
					</td>
				</tr>
			</table>
			</fieldset>
			</td>
		</tr>
	</table>
</center>

<asp:Panel ID="pnlConsultarProducto" runat="server" Visible="false">
<div style="position:absolute; top:100px; left:10%;" class="fondo1">
<table>
<tr>
<td>            
    <uc3:CtlMensajes ID="CtlMensajes1" runat="server" />
    <uc1:ConsultarProductoMontoCliente ID="ConsultarProductoMontoCliente1" 
        runat="server" Titulo="CONSULTA POR PRODUCTO, MONTO Y CLIENTE" />    
</td>
</tr>
</table>
</div>
</asp:Panel>


<asp:Panel ID="pnlReporte" runat="server" Visible="false">
<div style="position:absolute; top:100px; left:5%;" class="fondo1">
<table>
<tr>
<td>                
    <uc2:ReporteProductoOperacionCliente ID="ReporteProductoOperacionCliente1" 
        runat="server" titulo="REPORTE DE PRODUCTO CON TODAS LAS OPERACIONES DEL CLIENTE" />    
</td>
</tr>
</table>
</div>
</asp:Panel>