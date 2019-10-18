<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="ConsultaClientes.ascx.vb" Inherits="Controles.ConsultaClientes" %>
<%@ Register src="CtlGrilla.ascx" tagname="CtlGrilla" tagprefix="uc1" %>
<%@ Register src="NuevoCLienteGestionarCliente.ascx" tagname="NuevoCLienteGestionarCliente" tagprefix="uc2" %>
<%@ Register src="CtCombo.ascx" tagname="CtCombo" tagprefix="uc3" %>


<%@ Register src="CtlMensajes.ascx" tagname="CtlMensajes" tagprefix="uc4" %>


<table style="width:100%" align="center">
    <tr>
        <td class="titulo">
            CONSULTA DE CLIENTE
            <uc4:CtlMensajes ID="CtlMensajes1" runat="server" />
        </td>
    </tr>
</table>
<table style="width: 100%">
	<tr>
		<td>
			<fieldset name="Group1">
			<table style="width: 100%" border="0">
				<tr>
				    <td style="width:200px;"></td>
					<td style="width:50px">
					    <asp:Label id="Label1" runat="server" CssClass="lbl" Text="CARTERA"></asp:Label>
					</td>
					<td style="width:180px">
					    <uc3:CtCombo ID="cboCartera" runat="server" Activa="true" Procedimiento="QRYC007" Longitud="150" Condicion=""/>
					</td>
					<td style="width:60px">
					    <asp:Label id="Label3" runat="server" CssClass="lbl" Text="CONDIC."></asp:Label>
					</td>
					<td style="width:90px">
					    <uc3:CtCombo ID="cboCondicion" Longitud="75" runat="server" Activa="true" Procedimiento="QRYCGC001" />
					</td>
					<td style="width:50px">
					    <asp:Label id="Label4" runat="server" CssClass="lbl" Text="SITUAC."></asp:Label>
					</td>
					<td style="width:150px">
					    <asp:TextBox id="txtSituac" runat="server" CssClass="textoContenido" Width="100px"></asp:TextBox>
					</td>
					<td style="width:70px">
					    <asp:Label id="Label5" runat="server" CssClass="lbl" Text="DNI"></asp:Label>
					</td>
					<td style="width:160px">
					    <asp:TextBox id="txtDNI" runat="server" CssClass="textoContenido" Width="150px"></asp:TextBox>
					</td>
				</tr>
				<tr>
				    <td></td>
					<td>
					    <asp:Label id="Label6" runat="server" CssClass="lbl" Text="CLIENTE"></asp:Label>
					</td>
					<td colspan="2">
					    <asp:TextBox id="txtCliente" runat="server" CssClass="textoContenido" Width="205px"></asp:TextBox>
					</td>
					<td colspan="1" >
					    <asp:Label id="Label7" runat="server" CssClass="lbl" Text="TELÉFONO 1"></asp:Label>
					</td>
					<td colspan="2" style="width:180px">
					    <asp:TextBox id="txtTelefono1" runat="server"  Width="150px" CssClass="textoContenido"></asp:TextBox>
					</td>
					<td>
					    <asp:Label id="Label8" runat="server" CssClass="lbl" Text="TELÉFONO 2"></asp:Label>
					</td>
					<td style="width:180px">
					    <asp:TextBox id="txtTelefono2" runat="server" Width="150px" CssClass="textoContenido"></asp:TextBox>
					</td>
					<td style="text-align:right" width="50px">
					    <div class="curvo">
					    <asp:ImageButton id="imgBuscar" runat="server" ImageUrl="~/imagenes/boton busqueda.jpg" CssClass="curvoimg" />
					    <asp:Label id="Label14" runat="server" CssClass="curvolbl" Text="Buscar"></asp:Label>
					</div>
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
			<uc1:CtlGrilla ID="CtlGrilla1" runat="server" Ancho="930px" Largo="350px" Activa_ckeck="false" Activa_option="false" Desactiva_Boton="false" OpocionNuevo="true" />
		</fieldset>
		</td>
	</tr>
	<tr>
		<td>
		<table style="width: 100%">
			<tr align="center">
				<td align="center" style="text-align:center;">
				<div class="curvo" id="GrupoCerrar" runat="server" visible="false">
				<asp:ImageButton id="imgCerrar" runat="server" Height="30px" Width="35px" 
                            ImageUrl="~/imagenes/BotonCerrar.jpg" />
					<asp:Label id="Label2" runat="server" Font-Size="11px" Text="Cerrar"></asp:Label>
				</div>
				</td>
			</tr>
		</table>
		</td>
	</tr>
</table>



<asp:Panel ID="pnlNuevaCartera" runat="server" Visible="false">
<div style="position:absolute; width:100% auto; top:60px; left:10%;" class="fondo1">
<table>
<tr>
<td>        
    <uc2:NuevoCLienteGestionarCliente ID="NuevoCLienteGestionarCliente1" 
        runat="server" titulo="INFORMACION CLIENTE Y OPERACION" ActivaGrupo1="false" ActivaGrupo2="true" ActivaGrupoMontos="false" />    
</td>
</tr>
</table>
</div>
</asp:Panel>


<asp:Panel ID="pnlModificarCartera" runat="server" Visible="false">
<div style="position:absolute; width:100% auto; top:60px; left:5%;" class="fondo1">
<table>
<tr>
<td>        
    <uc2:NuevoCLienteGestionarCliente ID="NuevoCLienteGestionarClienteM" 
        runat="server" titulo="INFORMACION CLIENTE Y OPERACION" ActivaGrupo1="false" ActivaGrupo2="true" ActivaGrupoMontos="false" />    
</td>
</tr>
</table>
</div>
</asp:Panel>