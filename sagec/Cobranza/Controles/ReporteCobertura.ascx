<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="ReporteCobertura.ascx.vb" Inherits="Controles.ReporteCobertura" %>
<%@ Register src="CtlGrilla.ascx" tagname="CtlGrilla" tagprefix="uc1" %>

<%@ Register src="CtCombo.ascx" tagname="CtCombo" tagprefix="uc3" %>
<%@ Register src="ClienteNoGestionado.ascx" tagname="ClienteNoGestionado" tagprefix="uc2" %>
<%@ Register src="CtlMensajes.ascx" tagname="CtlMensajes" tagprefix="uc4" %>
<table style="width: 100%;" align="center">
<tr align="center">
<td align="center" style="text-align:center;" class="titulo">
    REPORTE DE COBERTURA
    <uc4:CtlMensajes ID="CtlMensajes1" runat="server" />
</td>
</tr>
</table>


<table style="width: 100%">
		<tr>
			<td>
			<fieldset>
			<table style="width: 100%">
				<tr align="center">
					<td width="40px"></td>
					<td>
			            <asp:Label id="Label2" runat="server" CssClass="lbl" Text="CARTERA"></asp:Label>
					</td>
					<td>
			            <uc3:CtCombo ID="cboCartera" runat="server" Activa="true" Procedimiento="QRYC007" Condicion="" AutoPostBack="true" Longitud="200"/>
					</td>
					<td>
			            <asp:Label id="Label1" runat="server" CssClass="lbl" Text="GESTOR"></asp:Label>
					</td>
					<td>
					    <uc3:CtCombo ID="cboGestor" runat="server" Activa="true" Condicion="" Longitud="200" />
					</td>
					<td>
			            <asp:Label ID="lblTipoCartera" runat="server" CssClass="lbl" Text="FECHA INICIO"></asp:Label>
					</td>
					<td>
					    <asp:TextBox ID="txtFechaInicio" runat="server"  Width="100px" Enabled = "false" CssClass="textoContenido"/>
                        <img ID="txtFechaInicio" alt="calendario" height="16"  onclick="return showCalendar('txtFechaInicio','<%=txtFechaInicio.ClientID%>','%d/%m/%Y','24', true);" src="Imagenes/calendario.png" width="18" />							
					</td>
					<td>
			            <asp:Label ID="Label3" runat="server" CssClass="lbl" Text="FECHA FIN"></asp:Label>
					</td>
					<td>
			            <asp:TextBox ID="txtFechaFin" runat="server"  Width="100px" Enabled = "false" CssClass="textoContenido"/>
                        <img ID="txtFechaFin" alt="calendario" height="16" onclick="return showCalendar('txtFechaFin','<%=txtFechaFin.ClientID%>','%d/%m/%Y','24', true);" src="Imagenes/calendario.png" width="18" />
					</td>
					<td style="text-align:center;">
					<div class="curvo">
			            <asp:ImageButton id="imgGenerarReporte" runat="server" CssClass="curvoimg" ImageUrl="~/imagenes/BotonGenerarReporte.png"/>
			            <asp:Label id="Label19" runat="server"  CssClass="curvolbl" Text="Reporte"></asp:Label>
					</div>
					</td>
				</tr>
			</table>
			</fieldset>
			</td>
		</tr>
</table>

<fieldset>
<table width="100%">
		<tr>
			<td>
				<uc1:CtlGrilla ID="CtlGrilla1" runat="server" Ancho="1000px" Largo="300px" Activa_ckeck="false" Activa_option="false" Desactiva_Boton="false" Activa_Delete="false" Activa_Edita="false" />
			</td>
	    </tr>
	    <tr><td style="height:10px;"></td></tr>
	    <tr>
			<td style=" text-align:center;">
				<div class="curvo" style="width:150px;">
			        <asp:ImageButton id="imgNoGestionados" runat="server" CssClass="curvoimg" ImageUrl="~/imagenes/BotonGestiones.png" />
			        <asp:Label id="Label20" runat="server" CssClass="curvolbl" Text="NO Gestion"></asp:Label>
				</div>
			</td>
		</tr>
</table>
</fieldset>

<asp:Panel ID="pnlNoGestionado" runat="server" Visible="false">
<div style="position:absolute; top:200px; left:10%;" class="fondo1">
<table>
<tr>
<td>    
    <uc2:ClienteNoGestionado ID="ClienteNoGestionado1" runat="server" />    
</td>
</tr>
</table>
</div>
</asp:Panel>