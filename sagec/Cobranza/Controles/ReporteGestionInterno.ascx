<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="ReporteGestionInterno.ascx.vb" Inherits="Controles.ReporteGestionInterno" %>
<%@ Register src="CtlGrilla.ascx" tagname="CtlGrilla" tagprefix="uc1" %>
<%@ Register src="CtlMensajes.ascx" tagname="CtlMensajes" tagprefix="uc2" %>
<%@ Register src="CtCombo.ascx" tagname="CtCombo" tagprefix="uc3" %>



<table style="width: 100%;" align="center">
<tr align="center">
<td align="center" style="text-align:center;" class="titulo">
    <asp:Label id="lblTituloControl" runat="server"></asp:Label>
    <uc2:CtlMensajes ID="CtlMensajes1" runat="server" />
</td>
</tr>
</table>

<table style="width: 100%">
	<tr>
		<td>
	        <fieldset>
                <table style="width: 100%" border="0">
		            <tr align="center">
			            <td>
			                <asp:Label ID="lblFechaInicio" runat="server" Text="TIPO CARTERA" CssClass="lbl" />
			            </td>
			            <td>
		                    <uc3:CtCombo ID="cboTipo" runat="server" Activa="true" AutoPostBack="true" Condicion=":condicion▓100" Procedimiento="QRYMG001"  />
			            </td>
			            <td>
			                <asp:Label ID="Label1" runat="server" Text="CARTERA" CssClass="lbl" />
			            </td>
			            <td>
			                <uc3:CtCombo ID="CboCartera" runat="server" Activa="true" 
                                Condicion=":criterio▓'---'" Procedimiento="QRYCG002" Longitud="200"   />
			            </td>
			            <td>
			                <asp:Label ID="Label2" runat="server" Text="TIPO INFORMACION" CssClass="lbl" />
			            </td>
			            <td>
			                <uc3:CtCombo ID="cboInformacion" runat="server" Activa="true" 
                                Condicion=":condicion▓109" Procedimiento="QRYMG001"  />
                        </td>
			            <td>
			                <asp:Label ID="Label3" runat="server" Text="FECHA INICIO" CssClass="lbl" />
			            </td>
			            <td>
			                <asp:CheckBox ID="chkInicio" runat="server" />           
                            <asp:TextBox ID="txtFechaInicio" runat="server"  Width="80px" Enabled = "false" CssClass="textoContenido"/>
                            <img ID="txtFechaInicio" alt="calendario" height="16"  onclick="return showCalendar('txtFechaInicio','<%=txtFechaInicio.ClientID%>','%d/%m/%Y','24', true);" 
                            src="Imagenes/calendario.png" width="18" />							
			            </td>
			            <td>
	                        <asp:Label ID="Label4" runat="server" Text="FECHA FIN" CssClass="lbl" />
		                </td>
			            <td>
			                <asp:CheckBox ID="chkFin" runat="server" />
                            <asp:TextBox ID="txtFechaFin" runat="server"  Width="80px" Enabled = "false" CssClass="textoContenido"/>
                            <img ID="txtFechaFin" alt="calendario" height="16" onclick="return showCalendar('txtFechaFin','<%=txtFechaFin.ClientID%>','%d/%m/%Y','24', true);" 
                            src="Imagenes/calendario.png" width="18" />
		                </td>
		                <td align="center" style="text-align:center;">
			            <div class="curvo" id="Div1" runat="server">
			                <asp:ImageButton id="imgBuscar" runat="server" CssClass="curvoimg" ImageUrl="~/imagenes/boton busqueda.jpg" />
				            <asp:Label id="Label19" runat="server" CssClass="curvolbl" Text="Buscar"></asp:Label>
			            </div>
			            </td>
		            </tr>
	            </table>
	        </fieldset>
		</td>
	</tr>
</table>
<table width="100%">
	<tr>
	    <td>
	        <fieldset>
	            <uc1:CtlGrilla ID="CtlGrilla1" runat="server" Largo="300px" Ancho="930px" Activa_ckeck="false" Activa_Delete="true" Activa_Edita="false" Activa_option="false" Desactiva_Boton="false"/>
	        </fieldset>
	    </td>
	</tr>
</table>