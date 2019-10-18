<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="NuevoCLienteGestionarCliente.ascx.vb" Inherits="Controles.NuevoCLienteGestionarCliente" %>
<%@ Register src="CtlGrilla.ascx" tagname="CtlGrilla" tagprefix="uc1" %>
<%@ Register src="GestionCliente.ascx" tagname="GestionCliente" tagprefix="uc2" %>


<%@ Register src="CtCombo.ascx" tagname="CtCombo" tagprefix="uc4" %>


<%@ Register src="CtlMensajes.ascx" tagname="CtlMensajes" tagprefix="uc5" %>


<%@ Register src="CtlPagos.ascx" tagname="CtlPagos" tagprefix="uc3" %>


<table style="width: 100%;" align="center">
<tr align="center">
<td align="center" style="text-align:center;" class="titulo"> 
    <asp:Label id="lblTituloControl" runat="server" Text="INFORMACION CLIENTE Y OPERACION" CssClass="titulo"></asp:Label>
    <asp:Label id="lblTipoVentana" runat="server" Visible="false"></asp:Label>
    <asp:Label id="lblIdCliente" runat="server" Visible="false"></asp:Label>
    <uc5:CtlMensajes ID="CtlMensajes1" runat="server" />
</td>
</tr>
</table>

<table style="width: 100%; padding:0;"  cellpadding="0" cellspacing="0">
		<tr>
			<td style="padding:0;">
			<fieldset>
			<legend>FILTRAR POR</legend>
			<table style="height:47px; width:330px;" cellpadding="0" cellspacing="0">
				<tr>
					<td>
					<asp:Label id="Label1" runat="server" Font-Size="11px" Text="CARTERA"></asp:Label>
					<br />
					<uc4:CtCombo ID="cboCartera" runat="server" Activa="true" 
                            Procedimiento="QRYC007" Condicion=""/>
					</td>
					<td>
					<asp:Label id="Label2" runat="server" Font-Size="11px" Text="CONDIC."></asp:Label>
					<br />
					<uc4:CtCombo ID="cboCondic" runat="server" Activa="true" 
                            Procedimiento="QRYCGC001" />
					</td>
					<td>
					<asp:Label id="Label3" runat="server" Font-Size="11px" Text="SITUAC."></asp:Label>
					<br />
					<asp:TextBox id="txtSituac" runat="server" Font-Size="11px"></asp:TextBox>
					</td>
				</tr>
			</table>
			</fieldset>
			</td>
			<td>
			<fieldset>
			<legend>DATOS</legend>
			<table cellpadding="0" cellspacing="0">
				<tr>
					<td align="center">
					<asp:Label id="Label4" runat="server" Font-Size="11px" Text="DNI"></asp:Label>
					<br />
					<asp:TextBox id="txtDNI" runat="server" Font-Size="11px" Width="136px"></asp:TextBox>
					</td>
					<td align="center">
					<asp:ImageButton id="imgHome" runat="server" Height="30px" Width="30px" 
                            ImageUrl="~/imagenes/BotonHome.png" />
					</td>
					<td align="center">
					<asp:Label id="Label5" runat="server" Font-Size="11px" Text="NOMBRE DE CLIENTE"></asp:Label>
					<br />
					<asp:TextBox id="txtNombreCliente" runat="server" Font-Size="11px" Width="367px"></asp:TextBox>
					</td>
					<td align="center">
					<div class="curvo">
					<asp:ImageButton id="imgGrabar" runat="server" Height="30px" Width="35px" 
                            ImageUrl="~/imagenes/BotonGrabar.png" />
					<asp:Label id="Label24" runat="server" Font-Size="11px" Text="Grabar"></asp:Label>
					</div>
					</td>
				</tr>
			</table>
			</fieldset>			
			</td>
		</tr>
		<tr>
			<td colspan="2">
			<table style="width: 100%" cellpadding="0" cellspacing="0">
				<tr>
					<td>
					<fieldset>
					<legend>OTROS DATOS</legend>
					<table cellpadding="0" cellspacing="0">
						<tr>
							<td>
							<table border="1px" style="width: 100%" cellpadding="0" cellspacing="0">
								<tr>
									<td>
									<table style="width: 100%">
										<tr>
											<td>
											<asp:Label id="Label6" runat="server" Font-Size="11px" Text="Dirección 1"></asp:Label>
											<br />
											<asp:TextBox id="txtDireccion1" runat="server" Font-Size="11px" Width="300px"></asp:TextBox>
											</td>
											<td>
											<asp:Label id="Label7" runat="server" Font-Size="11px" Text="Teléfono 1"></asp:Label>
											<br />
											<asp:TextBox id="txtTelefono1" runat="server" Font-Size="11px"></asp:TextBox>
											</td>
										</tr>
									</table>
									</td>
								</tr>
								<tr>
									<td>
									<table style="width: 100%">
										<tr>
											<td>
											<asp:Label id="Label8" runat="server" Font-Size="11px" Text="Departamento"></asp:Label>
											<br />
											<asp:TextBox id="txtDepartamento" runat="server" Font-Size="11px" Width="190px"></asp:TextBox>
											</td>
											<td>
											<asp:Label id="Label9" runat="server" Font-Size="11px" Text="Provincia"></asp:Label>
											<br />
											<asp:TextBox id="txtProvincia" runat="server" Font-Size="11px" Width="191px"></asp:TextBox>
											</td>
											<td>
											<asp:Label id="Label10" runat="server" Font-Size="11px" Text="Distrito"></asp:Label>
											<br />
											<asp:TextBox id="txtDistrito" runat="server" Font-Size="11px" Width="186px"></asp:TextBox>
											</td>
										</tr>
									</table>
									</td>
								</tr>
							</table>
							</td>
						</tr>
						<tr>
							<td>
							<table border="1px" style="width: 100%" cellpadding="0" cellspacing="0">
								<tr>
									<td>
									<table style="width: 100%">
										<tr>
											<td>
											<asp:Label id="Label11" runat="server" Font-Size="11px" Text="Dirección 2"></asp:Label>
											<br />
											<asp:TextBox id="txtDIreccion2" runat="server" Font-Size="11px" Width="300px"></asp:TextBox>
											</td>
											<td>
											<asp:Label id="Label12" runat="server" Font-Size="11px" Text="Teléfono 2"></asp:Label>
											<br />
											<asp:TextBox id="txtTelefono" runat="server" Font-Size="11px" Width="156px"></asp:TextBox>
											</td>
											<td>
											<asp:Label id="Label16" runat="server" Font-Size="11px" Text="Celular"></asp:Label>
											<br />
											<asp:TextBox id="txtCelular" runat="server" Font-Size="11px" Width="172px"></asp:TextBox>
											</td>
										</tr>
									</table>
									</td>
								</tr>
								<tr>
									<td>
									<table style="width: 100%">
										<tr>
											<td>
											<asp:Label id="Label13" runat="server" Font-Size="11px" Text="Departamento"></asp:Label>
											<br />
											<uc4:CtCombo ID="cboDepartamento" runat="server" Activa="true" 
                                                Procedimiento="QRYC009" Condicion="" AutoPostBack="true"/>
											</td>
											<td>
											<asp:Label id="Label14" runat="server" Font-Size="11px" Text="Provincia"></asp:Label>
											<br />
											<uc4:CtCombo ID="cboProvincia" Procedimiento="QRYC010" runat="server" Activa="true" 
                                                AutoPostBack="true" Longitud="100"/>
											</td>
											<td>
											<asp:Label id="Label15" runat="server" Font-Size="11px" Text="Distrito"></asp:Label>
											<br />
											<uc4:CtCombo ID="cboDIstrito" runat="server" Activa="true" 
                                                Longitud="100" Procedimiento="QRYC011"/>
											</td>
										</tr>
									</table>
									</td>
								</tr>
							</table>
							</td>
						</tr>
					</table>
					</fieldset>
					</td>
					<td valign="top">
					<fieldset>
					<legend>OBLIGACIONES</legend>
					<table align="left" style=" width:230px; height:161px;" cellpadding="0" cellspacing="0">
						<tr>
							<td align="right">
							<asp:Label id="Label17" runat="server" Font-Size="11px" Text="Monto K (S/.)"></asp:Label>
							</td>
							<td align="center">
							<asp:TextBox id="txtMontoKS" runat="server" Font-Size="11px" Width="134px"></asp:TextBox>
							</td>
						</tr>
						<tr>
							<td align="right">
							<asp:Label id="Label18" runat="server" Font-Size="11px" Text="Monto T (S/.)"></asp:Label>
							</td>
							<td align="center">
							<asp:TextBox id="txtMontoTS" runat="server" Font-Size="11px" Width="134px"></asp:TextBox>
							</td>
						</tr>
						<tr>
							<td align="right">
							<asp:Label id="Label19" runat="server" Font-Size="11px" Text="Monto K (US$)"></asp:Label>
							</td>
							<td align="center">
							<asp:TextBox id="txtMontoKUS" runat="server" Font-Size="11px" Width="134px"></asp:TextBox>
							</td>
						</tr>
						<tr>
							<td align="right">
							<asp:Label id="Label20" runat="server" Font-Size="11px" Text="Monto T (US$)"></asp:Label>
							</td>
							<td align="center">
							<asp:TextBox id="txtMontoTUS" runat="server" Font-Size="11px" Width="134px"></asp:TextBox>
							</td>
						</tr>
						<tr>
							<td align="center" style="text-align:center;">
							<div class="curvo" style="padding:auto; margin:auto;">
							<asp:ImageButton id="ImageButton3" runat="server" Height="30px" Width="35px" 
                                    ImageUrl="~/imagenes/BotonGestiones.png" />
							<asp:Label id="Label21" runat="server" Font-Size="11px" Text="Gestiones"></asp:Label>
							</div>
							</td>
							<td align="center" style="text-align:center;">
							<div class="curvo" style="padding:auto; margin:auto;">
							<asp:ImageButton id="imgPagos" runat="server" Height="30px" Width="35px" 
                                    ImageUrl="~/imagenes/BotonPagos.png" />
							<asp:Label id="Label22" runat="server" Font-Size="11px" Text="Pagos"></asp:Label>
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
		<tr>
			<td align="center" colspan="2">
		    <fieldset>
		    <legend>RESULTADOS</legend>
				<uc1:CtlGrilla ID="CtlGrilla1" runat="server" Ancho="900px" Largo="250px" Activa_ckeck="false" Activa_Delete="false" Activa_Edita="false" Activa_option="false" />				
			</fieldset>
			</td>
		</tr>
		<tr>
			<td colspan="2">
			<table style="width: 100%">
				<tr>
					<td style="text-align:right" width="35px" >
					<div class="curvo" witd="35px">
					<asp:ImageButton id="ImageButton5" runat="server" Height="30px" Width="35px" 
                            ImageUrl="~/imagenes/BotonCerrar.jpg"/>
							<asp:Label id="Label25" runat="server" Font-Size="11px" Text="Cerrar"></asp:Label>
				    </div>							
					</td>
				</tr>
			</table>
			</td>
		</tr>
</table>

<asp:Panel ID="pnlPagos" runat="server" Visible="false">
<div style="position:absolute; top:100px; left:5%;" class="fondo1">
<table>
<tr>
<td>     
    <uc3:CtlPagos ID="CtlPagos1" runat="server" FCliente="true"  Titulo="PAGOS"/>
</td>
</tr>
</table>
</div>
</asp:Panel>
	
	
<asp:Panel ID="pnlGestionCliente" runat="server" Visible="false">
<div style="position:absolute; top:100px; left:0%;" class="fondo1">
<table>
<tr>
<td> 
    <uc2:GestionCliente ID="GestionCliente1" runat="server" titulo="GESTION DE CLIENTE" />
</td>
</tr>
</table>
</div>
</asp:Panel>

