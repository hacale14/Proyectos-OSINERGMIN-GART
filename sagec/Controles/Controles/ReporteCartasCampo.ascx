<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="ReporteCartasCampo.ascx.vb" Inherits="Controles.ReporteCartasCampo" %>
<%@ Register src="CtlGrilla.ascx" tagname="CtlGrilla" tagprefix="uc1" %>
<%@ Register src="CtlMensajes.ascx" tagname="CtlMensajes" tagprefix="uc2" %>
<%@ Register src="CtCombo.ascx" tagname="CtCombo" tagprefix="uc3" %>

<%@ Register src="CtlCuadroMensaje.ascx" tagname="CtlCuadroMensaje" tagprefix="uc4" %>

<table style="width: 100%;" align="center">
<tr align="center">
<td align="center" style="text-align:center;" class="titulo">
    <asp:Label id="lblTituloControl" runat="server"></asp:Label>
    <asp:Label id="lblVariable" runat="server" Visible="false"></asp:Label>
    <uc2:CtlMensajes ID="CtlMensajes1" runat="server" />
</td>
</tr>
</table>

<table style="width: 100%; margin:0; padding:0;">
	<tr>
		<td>
	<fieldset>
	    <table style="width: 100%" align="center" border="0">
		    <tr align="center">
			    <td width="80px"></td>
			    <td>
			        <asp:Label ID="lblFechaFin" runat="server" Text="CARTERA" CssClass="lbl" />
			    </td>
			    <td>
			        <uc3:CtCombo ID="cboCartera" runat="server" Activa="true" Condicion="" AutoPostBack="true" Longitud="200" />
			    </td>
			    <td>
			        <asp:Label ID="Label1" runat="server" Text="GESTOR" CssClass="lbl" />
			    </td>
			    <td>
			        <uc3:CtCombo ID="cboGestor" runat="server" Activa="true" Condicion="" Longitud="200" />
		        </td>
			    <td>
			        <div id="GrupoFechaInicio" runat="server">
			            <asp:Label ID="Label2" runat="server" Text="FECHA INICIO" CssClass="lbl" style="float:left; padding-left:10px; position:relative; top:10px;" />
			        
			            <asp:CheckBox ID="chkInicio" runat="server" />           
                        <asp:TextBox ID="txtFechaInicio" runat="server"  Width="80px" Enabled = "false" CssClass="textoContenido"/>
                        <img ID="fecha" alt="calendario" height="16"  onclick="return showCalendar('fecha','<%=txtFechaInicio.ClientID%>','%d/%m/%Y','24', true);" src="Imagenes/calendario.png" width="18" />							
		            </div>
			    </td>
			    <td>
			        <div id="GrupoFechaFin" runat="server">
			            <asp:Label ID="Label3" runat="server" Text="FECHA FIN" CssClass="lbl" style="float:left; padding-left:10px; position:relative; top:10px;" />
			            
			            <asp:CheckBox ID="chkFin" runat="server" />
                        <asp:TextBox ID="txtFechaFin" runat="server"  Width="80px" Enabled = "false" CssClass="textoContenido"/>
                        <img ID="Img1" alt="calendario" height="16" onclick="return showCalendar('fecha','<%=txtFechaFin.ClientID%>','%d/%m/%Y','24', true);" src="Imagenes/calendario.png" width="18" />
			        </div>
		        </td>
			    <td align="center" style="text-align:center;">
			        <div class="curvo" id="Div1" runat="server">
			            <asp:ImageButton id="imgBuscar" runat="server" ImageUrl="~/imagenes/boton busqueda.jpg" CssClass="curvoimg" />
				        <asp:Label id="Label19" runat="server" CssClass="curvolbl" Text="Buscar"></asp:Label>
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
	        <uc1:CtlGrilla ID="CtlGrilla1" runat="server" Largo="300px" Ancho="930px" Activa_ckeck="false" Activa_Delete="true" Activa_Edita="false" Activa_option="false" Desactiva_Boton="false"/>
        </fieldset>
	    </td>
	</tr>
</table>

<asp:Panel ID="pnlCuadroMensaje" runat="server" Visible="false">
<div style="position:absolute; top:200px; left:30%;" class="fondo1">
<table>
<tr>
<td>    
    <uc4:CtlCuadroMensaje ID="CtlCuadroMensaje1" runat="server" />    
</td>
</tr>
</table>
</div>
</asp:Panel>