<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="ReporteCompromisos.ascx.vb" Inherits="Controles.ReporteCompromisos" %>
<%@ Register src="CtlGrilla.ascx" tagname="CtlGrilla" tagprefix="uc1" %>
<%@ Register src="CtlMensajes.ascx" tagname="CtlMensajes" tagprefix="uc2" %>
<%@ Register src="CtCombo.ascx" tagname="CtCombo" tagprefix="uc3" %>

<table width="100%" style="align:center" border="0">
<tr>
<td align="center" style="text-align:center;" Class="titulo">
    <asp:Label id="lblTituloControl" runat="server" ></asp:Label>
    <uc2:CtlMensajes ID="CtlMensajes1" runat="server" />
    <asp:Timer ID="Timer1" runat="server" Enabled="False">
    </asp:Timer>
</td>
</tr>
</table>

<center>
	<table style="width: 100%">
		<tr>
			<td align="center" style="text-align:100%;" colspan="3">
	        <fieldset>

	        <table style="width: 100%" border="0">
				<tr>
				    <td width="50px"></td>
					<td>
			            <asp:Label id="Label2" runat="server" CssClass="lbl" Text="CARTERA"></asp:Label>
					</td>
					<td>
			            <uc3:CtCombo ID="cboCartera" runat="server" Activa="true" Longitud="200" Procedimiento="QRYC007" Condicion="" AutoPostBack="true" />
					</td>
					<td>
			            <asp:Label id="Label3" runat="server" CssClass="lbl" Text="GESTOR"></asp:Label>
					</td>
					<td>
					    <uc3:CtCombo ID="cboGestor" runat="server" Activa="true" Condicion="" Longitud="200" />
					</td>
					<td>
					    <div id="GrupoFechaInicio" runat="server">
			                <asp:Label id="Label4" runat="server" CssClass="lbl" Text="FECHA INICIO" style="float:left; padding-left:20px; position:relative; top:5px;"></asp:Label>

                            <asp:TextBox ID="txtFechaInicio" runat="server"  Width="100px" Enabled = "false" CssClass="textoContenido"/>
                            <img ID="txtFechaInicio" alt="calendario" height="16"  onclick="return showCalendar('txtFechaInicio','<%=txtFechaInicio.ClientID%>','%d/%m/%Y','24', true);" src="Imagenes/calendario.png" width="18" />							
					    </div>
					</td>
					<td>
					    <div id="GrupoFechaFin" runat="server">
			                <asp:Label id="Label6" runat="server" CssClass="lbl" Text="FECHA FIN" style="float:left; padding-left:20px; position:relative; top:5px;"></asp:Label>

                            <asp:TextBox ID="txtFechaFin" runat="server"  Width="100px" Enabled = "false" CssClass="textoContenido"/>
                            <img ID="txtFechaFin" alt="calendario" height="16" onclick="return showCalendar('txtFechaFin','<%=txtFechaFin.ClientID%>','%d/%m/%Y','24', true);" src="Imagenes/calendario.png" width="18" />
					    </div>
					</td>
					<td align="center" style="text-align:center;">
					    <div class="curvo" id="Div1" runat="server">
			            <asp:ImageButton id="imgBuscar" runat="server" ImageUrl="~/imagenes/boton busqueda.jpg" CssClass="curvoimg" />
					    <asp:Label id="Label19" runat="server" CssClass="curvolbl" Text="Buscar"></asp:Label>
					    </div>
					</td>
					
					<td style="text-align:center;">
					    <div class="curvo" id="GrupoReporte" runat="server" visible="false">
			            <asp:ImageButton id="imgGenerarReporte" runat="server" ImageUrl="~/imagenes/BotonGenerarReporte.jpg" CssClass="curvoimg" />
			            <asp:Label id="Label1" runat="server" CssClass="curvolbl" Text="Reporte"></asp:Label>
					    </div>
					</td>
					
				</tr>
			</table>
	        </fieldset>			
			</td>
		</tr>
	</table>
</center>

	<table width="100%">
		<tr>
			<td colspan="3">
			<fieldset>
			<legend>RESULTADOS ENCONTRADOS</legend>
			    <table width="100%">
			        <tr>
			            <td>
			                <uc1:CtlGrilla ID="CtlGrilla1" runat="server" Largo="300px" Ancho="930px" Activa_ckeck="false" Activa_Delete="false" Activa_Edita="false" Activa_option="false" Desactiva_Boton="false"/>
			            </td>    
			        </tr>
			        <tr><td style="height:10px;"></td></tr>
			        <tr>
			            <td>
			                <div class="curvoacepta" id="GrupoReporteCompromiso" runat="server" style="width:200px">
			                <asp:ImageButton id="mgRpteCompromiso" runat="server" CssClass="curvoimg" ImageUrl="~/imagenes/BotonGenerarReporte.png" />
			                <asp:Label id="Label23" runat="server" CssClass="curvolbl" Text="RPTE COMPRO."></asp:Label>
			                </div>
			            </td>
			        </tr>
			    </table>
				
			</fieldset>			
			</td>
		</tr>
		<tr align="center" style="text-align:center;">
		    <td style="text-align:center;">
			    <div class="curvoaplica" runat="server" visible="false" id="GrupoNoGestionado" style="width:200px">
			    <asp:ImageButton id="imgNoGestionados" runat="server" CssClass="curvoimg" ImageUrl="~/imagenes/BotonGestiones.png" />
			    <asp:Label id="Label5" runat="server" CssClass="curvolbl" Text="NO GESTIONADOS"></asp:Label>
			    </div>
			</td>
			<td align="center" style="text-align:center;">
			    
			    
			    <div class="modal2" runat="server" visible="false" id="Carga1">
                       <div class="center">
                            <img alt="" src="Imagenes/loader.gif" />
                        </div>
                </div>
			
			</td>
		</tr>
	</table>