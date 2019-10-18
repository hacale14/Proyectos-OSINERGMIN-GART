<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="ConsultaPagos.ascx.vb" Inherits="Controles.ConsultaPagos" %>
<%@ Register src="CtlGrilla.ascx" tagname="CtlGrilla" tagprefix="uc1" %>
<%@ Register src="NMPagos.ascx" tagname="NMPagos" tagprefix="uc2" %>
<%@ Register src="MetasCobranzasAvances.ascx" tagname="MetasCobranzasAvances" tagprefix="uc3" %>
<table style="width: 100%;" align="center">
<tr align="center">
<td align="center" style="text-align:center;">
    CONSULTA DE PAGOS - CARTERA CASTIGO 
</td>
</tr>
</table>

<table style="width: 100%">
	<tr>
		<td>
			<table style="width: 100%">
				<tr>
					<td>
					<fieldset>
					<legend>filtrar por</legend>
					<table style="width: 100%">
						<tr align="center">
							<td>
							<asp:Label id="Label3" runat="server" Font-Size="11px" Text="DNI"></asp:Label>
							<br />
							<asp:TextBox id="txtDNI" runat="server" Font-Size="11px"></asp:TextBox>
							</td>
							<td>
							<asp:Label id="Label4" runat="server" Font-Size="11px" Text="CLIENTE"></asp:Label>
							<br />
							<asp:TextBox id="txtCliente" runat="server" Font-Size="11px" Width="222px"></asp:TextBox>
							</td>
							<td>
							<asp:Label id="Label5" runat="server" Font-Size="11px" Text="INICIO"></asp:Label>
							<br />
							<asp:TextBox ID="txtFechaInicio13" runat="server"  Width="100px" Enabled = "false" BackColor="White" BorderColor="Black" BorderWidth = "1" Font-Size="11px" />
                            <img id="fecha113" alt="calendario" height="24" valign="middle"
                            onclick="return showCalendar('fecha113','<%=txtFechaInicio13.ClientID%>','%d/%m/%Y','24', true);"
                            src="~/Imagenes/calendario.png" width="24" />	 
							</td>
							<td>
							<asp:Label id="Label6" runat="server" Font-Size="11px" Text="FIN"></asp:Label>
							<br />
							<asp:TextBox ID="txtFechaFin13" runat="server"  Width="100px" Enabled = "false" BackColor="White" BorderColor="Black" BorderWidth = "1" Font-Size="11px" />
                            <img id="fecha23" alt="calendario" height="24" valign="middle"
                            onclick="return showCalendar('fecha23','<%=txtFechaFin13.ClientID%>','%d/%m/%Y','24', true);"
                            src="../../Imagenes/calendario.png" width="24" />	 
							</td>
							<td>
							<asp:Label id="Label7" runat="server" Font-Size="11px" Text="CARTERA"></asp:Label>
							<br />
							<asp:DropDownList id="cboCartera" runat="server" Font-Size="11px" Height="19px" Width="134px">
								<asp:ListItem Value="0">Seleccion</asp:ListItem>
							</asp:DropDownList>
							</td>
							<td>
							<asp:ImageButton id="imgBuscar" runat="server" Height="40px" Width="50px" 
                                    ImageUrl="~/imagenes/boton busqueda.jpg" />
							    <br />
							<asp:Label id="Label14" runat="server" Font-Size="11px" Text="Busqueda"></asp:Label>
							</td>
						</tr>
					</table>
					</fieldset>
					</td>
				</tr>
				<tr>
					<td align="center" style="text-align:center;">
					<fieldset>
					<legend>RESULTADOS DE PAGOS</legend>
						<uc1:CtlGrilla ID="CtlGrilla1" runat="server" Ancho="700px" Largo="250px" />
				    </fieldset>
					</td>
				</tr>
				<tr>
					<td>
					<fieldset>
					<table style="width: 100%">
						<tr align="center">
							<td align="center" style="text-align:center;">
							<div class="curvo">
							<asp:ImageButton id="imgEliminar" runat="server" Height="30px" Width="35px" 
                                    ImageUrl="~/imagenes/BotonEliminar.png" />
							<asp:Label id="Label8" runat="server" Font-Size="11px" Text="Eliminar"></asp:Label>
							</div>
							</td>
							<td align="center" style="text-align:center;">
							<div class="curvo">
							<asp:ImageButton id="imgNuevo" runat="server" Height="30px" Width="35px" 
                                    ImageUrl="~/imagenes/botonNuevo.jpg" />
							<asp:Label id="Label9" runat="server" Font-Size="11px" Text="Nuevo"></asp:Label>
							</div>
							</td>
							<td align="center" style="text-align:center;">
							<div class="curvo">
							<asp:ImageButton id="imgModificar" runat="server" Height="30px" Width="35px" 
                                    ImageUrl="~/imagenes/BotonModificar.png" />
							<asp:Label id="Label10" runat="server" Font-Size="11px" Text="Modificar"></asp:Label>
							</div>
							</td>
							<td align="center" style="text-align:center;">
							<div class="curvo">
							<asp:ImageButton id="imgVerMetas" runat="server" Height="30px" Width="35px" 
                                    ImageUrl="~/imagenes/BotonMetas.png" />
							<asp:Label id="Label11" runat="server" Font-Size="11px" Text="Metas"></asp:Label>
							</div>
							</td>
							<td align="center" style="text-align:center;">
							<div class="curvo">
							<asp:ImageButton id="imgExportarExcel" runat="server" Height="30px" Width="35px" 
                                    ImageUrl="~/imagenes/BotonExportarExcel.jpg" />
							<asp:Label id="Label12" runat="server" Font-Size="11px" Text="Exportar"></asp:Label>
							</div>
							</td>
							<td align="center" style="text-align:center;">
							<div class="curvo">
							<asp:ImageButton id="imgCerrar" runat="server" Height="30px" Width="35px" 
                                    ImageUrl="~/imagenes/BotonCerrar.jpg" />
							<asp:Label id="Label13" runat="server" Font-Size="11px" Text="Cerrar"></asp:Label>
							</div>
							</td>
						</tr>
					</table>
					</fieldset>
					</td>
				</tr>
			</table>
			
		</td>
	</tr>
</table>


<asp:Panel ID="pnlNuevoPago" runat="server" Visible="false">
<div style="position:absolute; top:100px; left:5%;" class="fondo1">
<table>
<tr>
<td>    
    <uc2:NMPagos ID="NMPagos1" runat="server" titulo="NUEVO - PAGO - CARTERA CASTIGO" Accion="N"/>
</td>
</tr>
</table>
</div>
</asp:Panel>


<asp:Panel ID="pnlModificarPago" runat="server" Visible="false">
<div style="position:absolute; top:100px; left:5%;" class="fondo1">
<table>
<tr>
<td>    
    <uc2:NMPagos ID="NMPagos2" runat="server" titulo="MODIFICAR - PAGO - CARTERA CASTIGO" Accion="M"/>
</td>
</tr>
</table>
</div>
</asp:Panel>


<asp:Panel ID="pnlMetas" runat="server" Visible="false">
<div style="position:absolute; top:100px; left:5%;" class="fondo1">
<table>
<tr>
<td>        
    <uc3:MetasCobranzasAvances ID="MetasCobranzasAvances1" runat="server" Titulo="METAS DE COBRANZA Y AVANCE REALIZADO" />    
</td>
</tr>
</table>
</div>
</asp:Panel>

