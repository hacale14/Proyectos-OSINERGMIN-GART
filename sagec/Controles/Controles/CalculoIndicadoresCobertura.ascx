<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="CalculoIndicadoresCobertura.ascx.vb" Inherits="Controles.CalculoIndicadoresCobertura" %>
<%@ Register src="CtCombo.ascx" tagname="CtCombo" tagprefix="uc3" %>
<%@ Register src="CtlMensajes.ascx" tagname="CtlMensajes" tagprefix="uc1" %>
<%@ Register src="GraficoIndicadores.ascx" tagname="GraficoIndicadores" tagprefix="uc2" %>
<table style="width: 100%;" align="center">
<tr align="center">
<td align="center" style="text-align:center;" class="titulo">
    CALCULO DE INDICADORES POR CARTERA Y GESTOR
    <uc1:CtlMensajes ID="CtlMensajes1" runat="server" />
</td>
</tr>
</table>


<div style="width:100%;">
<table style="width: 100%" cellpadding="0" cellspacing="0">
		<tr>
			<td>
			<fieldset>
			<table style="width: 100%" cellpadding="0" cellspacing="0">
				<tr align="center">
					<td>
			            <asp:Label id="Label9" runat="server" CssClass="lbl" Text="CARTERA"></asp:Label>
					</td>
					<td>
			            <uc3:CtCombo ID="cboCartera" runat="server" Activa="true" Longitud="200" Procedimiento="QRYC007" Condicion="" AutoPostBack="true" />
					</td>
					<td>
			            <asp:Label id="Label10" runat="server" CssClass="lbl" Text="GESTOR"></asp:Label>
					</td>
					<td>
			            <uc3:CtCombo ID="cboGestor" runat="server" Activa="true" Condicion=""  Longitud="200"/>
					</td>
					<td>
			            <asp:Label id="Label1" runat="server" CssClass="lbl" Text="FECHA INICIO"></asp:Label>
					</td>
					<td>
			            <asp:TextBox ID="txtFechaInicio" runat="server"  Width="80px" Enabled = "false" CssClass="textoContenido"/>
                        <img ID="txtFechaInicio" alt="calendario" height="16"  onclick="return showCalendar('txtFechaInicio','<%=txtFechaInicio.ClientID%>','%d/%m/%Y','24', true);" src="Imagenes/calendario.png" width="18" />							
					</td>
					<td>
			            <asp:Label id="Label2" runat="server" CssClass="lbl" Text="FECHA FIN"></asp:Label>
					</td>
					<td>
			            <asp:TextBox ID="txtFechaFin" runat="server"  Width="80px" Enabled = "false" CssClass="textoContenido"/>
                        <img ID="txtFechaFin" alt="calendario" height="16" onclick="return showCalendar('txtFechaFin','<%=txtFechaFin.ClientID%>','%d/%m/%Y','24', true);" src="Imagenes/calendario.png" width="18" />
					</td>
					<td>
			            <asp:Label id="Label13" runat="server" CssClass="lbl" Text="T. CAMBIO"></asp:Label>
					</td>
					<td>
					    <asp:TextBox id="txtCambio" runat="server" CssClass="textoContenido"></asp:TextBox>
					</td>
					<td style="text-align:center;" align="center">
					    <div class="curvo">
			                <asp:ImageButton id="imgCalcularIndicadores" runat="server" CssClass="curvoimg" ImageUrl="~/Imagenes/calcular.png" />
					        <asp:Label id="Label14" runat="server" CssClass="curvolbl" Text="Calculo"></asp:Label>
				        </div>
					</td>
				</tr>
			</table>
			</fieldset>
			</td>
		</tr>
		<tr>
			<td>
			<fieldset>
			<legend>
			    RESULTADOS
			</legend>
			<table style="width: 100%;" cellpadding="0" cellspacing="0" border="0">
				<tr>
					<td>
			            <asp:Label id="Label15" runat="server" CssClass="lbl" Text="CLIENTES ASIGNADOS"></asp:Label>
					</td>
					<td>
					    <asp:TextBox Enabled="false" id="txtClientesAsignados" runat="server" CssClass="textoContenido" Width="150px"></asp:TextBox>
					</td>
					<td>
			            <asp:Label id="Label18" runat="server" CssClass="lbl" Text="CAPITAL (S + D)"></asp:Label>
					</td>
					<td>
			            <asp:Label id="Label38" runat="server" CssClass="lbl" Text="S./"></asp:Label>
					</td>
					<td>
					    <asp:TextBox Enabled="false" id="txtCapital" runat="server" CssClass="textoContenido" Width="150px"></asp:TextBox>
					</td>
					<td>
					<table border="0">
						<tr>
							<td align="right">
			                <asp:Label id="Label21" runat="server" CssClass="lbl" Text="PAGOS (S + D)"></asp:Label>
							</td>
							<td>
			                <asp:Label id="Label41" runat="server" CssClass="lbl" Text="S./"></asp:Label>
							</td>
							<td width="200px">
							<asp:TextBox Enabled="false" id="txtPagos" runat="server" CssClass="textoContenido" Width="150px"></asp:TextBox>
							</td>
						</tr>
					</table>
					</td>
				</tr>
				<tr><td style="height:10px;"></td></tr>
				<tr>
					<td>
			            <asp:Label id="Label16" runat="server" CssClass="lbl" Text="CUENTAS ASIGNADAS"></asp:Label>
					</td>
					<td>
					    <asp:TextBox Enabled="false" id="txtCuentasAsignadas" runat="server" CssClass="textoContenido" Width="150px"></asp:TextBox>
					</td>
					<td>
			            <asp:Label id="Label19" runat="server" CssClass="lbl" Text="DEUDA TOTAL (S + D)"></asp:Label>
					</td>
					<td>
			            <asp:Label id="Label39" runat="server" CssClass="lbl" Text="S./"></asp:Label>
					</td>
					<td>
					    <asp:TextBox Enabled="false" id="txtTotal" runat="server" CssClass="textoContenido" Width="150px"></asp:TextBox>
					</td>
					<td>
					<table style="width: 100%">
						<tr>
							<td>
			                    <asp:Label id="Label22" runat="server" CssClass="lbl" Text="CANT PP"></asp:Label>
							</td>
							<td>
							    <asp:TextBox Enabled="false" id="txtCantPP" runat="server" CssClass="textoContenido" Width="150px"></asp:TextBox>
							</td>
							<td>
			                    <asp:Label id="Label23" runat="server" CssClass="lbl" Text="CANT PC"></asp:Label>
							</td>
							<td>
							    <asp:TextBox Enabled="false" id="txtCantPC" runat="server" CssClass="textoContenido" Width="150px"></asp:TextBox>
							</td>
						</tr>
					</table>
					</td>
				</tr>
				<tr><td style="height:10px;"></td></tr>
				<tr>
					<td>
			            <asp:Label id="Label17" runat="server" CssClass="lbl" Text="CUENTAS GESTIONADAS"></asp:Label>
					</td>
					<td>
					    <asp:TextBox Enabled="false" id="txtCuentasGestionadas" runat="server" CssClass="textoContenido" Width="150px"></asp:TextBox>
					</td>
					<td>
			            <asp:Label id="Label20" runat="server" CssClass="lbl" Text="DEUDA VENCIDA (S + D)"></asp:Label>
					</td>
					<td>
			            <asp:Label id="Label40" runat="server" CssClass="lbl" Text="S./"></asp:Label>
					</td>
					<td>
					    <asp:TextBox Enabled="false" id="txtDeudaVencida" runat="server" CssClass="textoContenido" Width="150px"></asp:TextBox>
					</td>
					<td>
					<table style="width: 100%">
						<tr>
							<td>
			                    <asp:Label id="Label24" runat="server" CssClass="lbl" Text="G. HUM."></asp:Label>
							</td>
							<td>
							    <asp:TextBox Enabled="false" id="txtGHum" runat="server" CssClass="textoContenido" Width="100px"></asp:TextBox>
							</td>
							<td>
			                    <asp:Label id="Label25" runat="server" CssClass="lbl" Text="G. DIR."></asp:Label>
							</td>
							<td>
							    <asp:TextBox Enabled="false" id="txtGDir" runat="server" CssClass="textoContenido" Width="100px"></asp:TextBox>
							</td>
							<td>
			                    <asp:Label id="Label26" runat="server" CssClass="lbl" Text="G. TIT."></asp:Label>
							</td>
							<td>
							    <asp:TextBox Enabled="false" id="txtGTit" runat="server" CssClass="textoContenido" Width="100px"></asp:TextBox>
							</td>
						</tr>
					</table>
					</td>
				</tr>
			</table>
			</fieldset>
			</td>
		</tr>
		<tr>
			<td>
			<fieldset>
			<legend>
			    INDICADORES
			</legend>
			<table style="width: 100%" cellpadding="0" cellspacing="0" border=0>
				<tr align="center">
					<td>
			            <asp:Label id="Label27" runat="server" CssClass="lbl" Text="EFECTIVIDAD" style="padding-right:50px;"></asp:Label>
					</td>
					<td>
			            <asp:Label id="Label28" runat="server" CssClass="lbl" Text="COBERTURA" style="padding-right:50px;"></asp:Label>
					</td>
					<td>
			            <asp:Label id="Label29" runat="server" CssClass="lbl" Text="CONT. HUM." style="padding-right:50px;"></asp:Label>
					</td>
					<td>
			            <asp:Label id="Label30" runat="server" CssClass="lbl" Text="CONT. DIREC." style="padding-right:50px;"></asp:Label>
					</td>
					<td>
			            <asp:Label id="Label31" runat="server" CssClass="lbl" Text="INTENS. GEST." style="padding-right:50px;"></asp:Label>
					</td>
					<td>
			            <asp:Label id="Label32" runat="server" CssClass="lbl" Text="INTENS. CONTAC." style="padding-right:50px;"></asp:Label>
					</td>
					<td>
			            <asp:Label id="Label33" runat="server" CssClass="lbl" Text="CIERRE PDP'S" style="padding-right:50px;"></asp:Label>
					</td>
					<td>
			            <asp:Label id="Label34" runat="server" CssClass="lbl" Text="EFECT PDP'S" style="padding-right:50px;"></asp:Label>
					</td>
				</tr>
				<tr>
					<td>
					    <asp:TextBox Enabled="false" id="txtEfectividad" runat="server" CssClass="textoContenido" Width="50px"></asp:TextBox>
					</td>
					<td>
					    <asp:TextBox Enabled="false" id="txtCobertura" runat="server" CssClass="textoContenido" Width="50px"></asp:TextBox>
					</td>
					<td>
					    <asp:TextBox Enabled="false" id="txtContHum" runat="server" CssClass="textoContenido" Width="50px"></asp:TextBox>
					</td>
					<td>
					    <asp:TextBox Enabled="false" id="txtContDirect" runat="server" CssClass="textoContenido" Width="50px"></asp:TextBox>
					</td>
					<td>
					    <asp:TextBox Enabled="false" id="txtIntensGest" runat="server" CssClass="textoContenido" Width="50px"></asp:TextBox>
					</td>
					<td>
					    <asp:TextBox Enabled="false" id="txtIntensContac" runat="server" CssClass="textoContenido" Width="50px"></asp:TextBox>
					</td>
					<td>
					    <asp:TextBox Enabled="false" id="txtCierrePDPS" runat="server" CssClass="textoContenido" Width="50px"></asp:TextBox>
					</td>
					<td>
					    <asp:TextBox Enabled="false" id="txtEfectPDPS" runat="server" CssClass="textoContenido" Width="50px"></asp:TextBox>
					</td>
				</tr>
			</table>
			</fieldset>
			</td>
		</tr>
		<tr>
			<td style="text-align:center;">
			<table style="width: 100%" cellpadding="0" cellspacing="0">
				<tr align="center">
					<td style="text-align:center;" align="center">
					    <div class="curvo" style="width:120px;">
			            <asp:ImageButton id="imgVerGrafico" runat="server" CssClass="curvoimg" ImageUrl="~/Imagenes/BotonVerEstadisticas.png" />
			            <asp:Label id="Label36" runat="server" CssClass="curvolbl" Text="Graficos"></asp:Label>
					    </div>
					    <br />
					</td>
				</tr>
			</table>
			</td>
		</tr>
	</table>
</div>

<table>
	<tr>
	<td>
	<asp:Panel ID="pnlGrafico" runat="server" Visible="false">
        <div style="position:absolute; left:100px; top:100px;" class="fondo1">
        <table>
        <tr>
        <td>
            <uc2:GraficoIndicadores ID="GraficoIndicadores1" runat="server" />    
        </td>
        </tr>
        </table>
        </div>
    </asp:Panel>
	</td>
	</tr>
</table>



