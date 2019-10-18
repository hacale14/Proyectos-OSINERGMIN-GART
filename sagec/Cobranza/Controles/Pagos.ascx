<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="Pagos.ascx.vb" Inherits="Controles.Pagos" %>

<%@ Register src="~/Controles/CtlGrilla.ascx" tagname="CtlGrilla" tagprefix="uc1" %>
<%@ Register src="~/Controles/CtlTxt.ascx" tagname="CtlTxt" tagprefix="uc2" %>
<%@ Register src="~/Controles/CtCombo.ascx" tagname="CtCombo" tagprefix="uc3" %>
<table class="fondoPantalla" width="100%">
<tr>
    <td>
        <center>
            <asp:Label ID="lblTituloControl" runat="server" Text="" ForeColor="White" Font-Bold="true" Font-Size="16px"></asp:Label>
        </center>
    </td>
</tr>
<tr>
    <td>
        <fieldset>
        <legend> FILTRAR POR </legend>
			<table style="width: 100%">
				<tr>
					<td>
					    <asp:Label ID="lblDNI" runat="server" Text="DNI" ForeColor="Maroon" Font-Size="10px" Font-Bold="true" />
					</td>
					<td>
					    <asp:Label ID="lblCliente" runat="server" Text="CLIENTE" ForeColor="Maroon" Font-Size="10px" Font-Bold="true" />
					</td>
					<td>
					    <asp:Label ID="lblInicio" runat="server" Text="INICIO" ForeColor="Maroon" Font-Size="10px" Font-Bold="true" />
					</td>
					<td>
					    <asp:Label ID="lblFin" runat="server" Text="FIN" ForeColor="Maroon" Font-Size="10px" Font-Bold="true" />
					</td>
					<td>
					    <asp:Label ID="lblCartera" runat="server" Text="CARTERA" ForeColor="Maroon" Font-Size="10px" Font-Bold="true" />
					</td>
					<td rowspan="2" style="text-align:center;">
					<div class="curvo">
					    <asp:ImageButton ID="btnBuscar" runat="server" ToolTip="Busqueda" ImageUrl="~/Imagenes/BotonBusquedaPequena.png" Width="30px" Height="25px" /><br />
                        <asp:Label ID="lblBuscar" runat="server" Text="Buscar" Font-Size="11px" Font-Bold="false" />
                    </div>
					</td>
				</tr>
				<tr>
					<td><uc2:CtlTxt ID="txtDNI" runat="server" Ancho="100" /></td>
					<td><uc2:CtlTxt ID="txtCliente" runat="server" Ancho="200" /></td>
					<td>
					    <asp:CheckBox ID="chkInicio" runat="server" Width="24" Height="24" />
					    <asp:TextBox ID="txtFechaInicio" runat="server"  Width="100px" Enabled = "false" BackColor="White" BorderColor="Black" BorderWidth = "1" Font-Size="11px" />
                        <img ID="fecha" alt="calendario" height="24" valign="middle"
                        onclick="return showCalendar('fecha','<%=txtFechaInicio.ClientID%>','%d/%m/%Y','24', true);" 
                        src="../../Imagenes/calendario.png" width="24" />
                    </td>
					<td>
					    <asp:CheckBox ID="chkFin" runat="server" Width="24" Height="24" />
					    <asp:TextBox ID="txtFechaFin" runat="server"  Width="100px" Enabled = "false" BackColor="White" BorderColor="Black" BorderWidth = "1" Font-Size="11px" />
                        <img ID="fecha1" alt="calendario" height="24" valign="middle"
                        onclick="return showCalendar('fecha1','<%=txtFechaFin.ClientID%>','%d/%m/%Y','24', true);" 
                        src="../../Imagenes/calendario.png" width="24" />
					</td>
					<td>
					    <uc3:CtCombo ID="cboCartera" runat="server" Longitud="100" Procedimiento="QRYC007" Condicion="" />
					</td>
				</tr>
			</table>
        </fieldset>
    </td>
</tr>
<tr><td bgcolor="#ff6600"><asp:Label ID="lblExisten" runat="server" Text="Existe(n) 0 Pago(s)" ForeColor="white" Font-Size="11px" Font-Bold="true" /></td></tr>
<tr>
	<td>
	<div style="border: thin groove #808080; background-color:White; height:250px; width:auto; overflow:scroll">
	    <uc1:CtlGrilla ID="gvPagos" runat="server" Desactiva_Boton="false" Activa_Export="false" Alto="300" Ancho="200"  />			
	</div>
	</td>
</tr>
<tr>
			<td>
			<table style="width: 100%">
				<tr>
					<td  style="text-align:center;">
					   <div class="curvoG">
			            <asp:ImageButton id="btnEliminar" runat="server" Height="30px" Width="30px" ImageUrl="~/Imagenes/BotonEliminar.png" ToolTip="Click para Eliminiar" />
			            <asp:Label id="lblEliminar" runat="server" Font-Size="9px" Text="Eliminar"></asp:Label>
			            <asp:Label id="lblEliminar1" runat="server" Font-Size="9px" Text="Pagos"></asp:Label>
			           </div>															 
					</td>
					<td  style="text-align:center;">
					   <div class="curvoG">
			            <asp:ImageButton id="btnNuevo" runat="server" Height="30px" Width="30px" ImageUrl="~/Imagenes/botonNuevo.jpg" ToolTip="Click para ingresar un nuevo pago" />
			            <asp:Label id="lblNuevo" runat="server" Font-Size="9px" Text="Nuevo"></asp:Label>
			            <asp:Label id="lblNuevo1" runat="server" Font-Size="9px" Text="Pago"></asp:Label>
			           </div>															 					
					</td>
					<td  style="text-align:center;">
					   <div class="curvoG">
			            <asp:ImageButton id="btnMetas" runat="server" Height="30px" Width="30px" ImageUrl="~/Imagenes/BotonMetas.png" ToolTip="Click para reivasr las metas" />
			            <asp:Label id="lblMetas" runat="server" Font-Size="9px" Text="Visualizar"></asp:Label>
			            <asp:Label id="lblMetas1" runat="server" Font-Size="9px" Text="Metas"></asp:Label>
			           </div>															 								     
					</td>
					<td style="text-align:center;">
					   <div class="curvoG">
			            <asp:ImageButton id="btnCerrar" runat="server" Height="30px" Width="30px" ImageUrl="~/Imagenes/BotonCerrar.jpg" ToolTip="Click para cerrar pagos" />
			            <asp:Label id="lblCerrar" runat="server" Font-Size="9px" Text="Cerrar"></asp:Label>
			            <asp:Label id="lblCerrar1" runat="server" Font-Size="9px" Text="Pagos"></asp:Label>
			           </div>															 							           					
					</td>
				</tr>
			</table>
			</td>
		</tr>
</table>
