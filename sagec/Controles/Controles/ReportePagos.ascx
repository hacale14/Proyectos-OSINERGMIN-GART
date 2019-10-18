<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="ReportePagos.ascx.vb" Inherits="Controles.ReportePagos" %>
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

<table style="width:100%;">
	<tr>
		<td>
	        <fieldset>
	                <table style="width: 100%" align="center" border="0">
		            <tr align="center">
			            <td width="100px">
			                <asp:Label ID="idcartera" runat="server" Text="CARTERA" CssClass="lbl" />
			            </td>
			            <td>
			                <uc3:CtCombo ID="cboCartera" runat="server" Activa="true"  Condicion=""  AutoPostBack="true" Longitud="200" />
			            </td>
			            <td>
			                <asp:Label ID="Label1" runat="server" Text="GESTOR" CssClass="lbl" />
			            </td>
			            <td>
			                <uc3:CtCombo ID="cboGestor" runat="server" Activa="true" Condicion="" Longitud="200" />
		                </td>
			            <td>
			                <asp:Label ID="Label4" runat="server" Text="CONCEPTO" CssClass="lbl" />
			            </td>
			            <td>
			                <asp:TextBox id="txtConcepto" runat="server" Width="175px" CssClass="textoContenido"></asp:TextBox>
			            </td>
		                <td align="center" style="text-align:center;" rowspan="2">
			            <div class="curvo" id="Div1" runat="server">
			                <asp:ImageButton id="imgBuscar" runat="server" ImageUrl="~/imagenes/boton busqueda.jpg" CssClass="curvoimg" />
				            <asp:Label id="Label19" runat="server" CssClass="curvolbl" Text="Buscar"></asp:Label>
			            </div>
			            </td>
		            </tr>
		            <tr>
		                <td colspan="2">
			                <div id="GrupoFechaInicio" runat="server" style="padding-left:40px;">
			                    <asp:Label ID="Label2" runat="server" Text="FECHA INICIO" CssClass="lbl" style="float:left;position:relative;top:8px; padding-left:10px;"/>
    			            
			                    <asp:CheckBox ID="chkInicio" runat="server" />           
                                <asp:TextBox ID="txtFechaInicio" runat="server" Enabled = "false" Width="120px" CssClass="textoContenido"/>
                                <img ID="txtFechaInicio" alt="calendario" height="16"  onclick="return showCalendar('txtFechaInicio','<%=txtFechaInicio.ClientID%>','%d/%m/%Y','24', true);" 
                                src="Imagenes/calendario.png" width="18" />							
		                    </div>
			            </td>
			            <td colspan="2">
			                <div id="GrupoFechaFin" runat="server" style="padding-left:10px;">
			                    <asp:Label ID="Label3" runat="server" Text="FECHA FIN" CssClass="lbl" style="float:left;position:relative;top:8px; padding-left:10px;"/>
    				            
			                    <asp:CheckBox ID="chkFin" runat="server" />
                                <asp:TextBox ID="txtFechaFin" runat="server"  Width="120px" Enabled = "false" CssClass="textoContenido"/>
                                <img ID="txtFechaFin" alt="calendario" height="16" onclick="return showCalendar('txtFechaFin','<%=txtFechaFin.ClientID%>','%d/%m/%Y','24', true);" 
                                src="Imagenes/calendario.png" width="18" />
			                </div>
		                </td>
		                <td>
			                <asp:Label ID="Label5" runat="server" Text="MONEDA" CssClass="lbl" />
			            </td>
			            <td style="text-align:left; padding-left:42px;">
			                <uc3:CtCombo ID="cboMoneda" runat="server" Activa="true" Longitud="100" Condicion=":condicion▓105" Procedimiento="QRYMG001" />
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
	    <uc1:CtlGrilla ID="CtlGrilla1" runat="server" Largo="300px" Ancho="930px" Activa_ckeck="false" Activa_Delete="false" Activa_Edita="false" Activa_option="false" Desactiva_Boton="false"/>
	    </fieldset>
	</td>	
	</tr>
</table>

<center>
<table width="50%">
	<tr>
	<td>
	<fieldset>
	<table style="width: 100%" border=0>
		<tr align="center">
			<td></td>
			<td align="right" style="text-align:right;">
			    <asp:Label id="Label24" runat="server" CssClass="lbl" Text="TOTAL PAGOS S./"></asp:Label>
			</td>
			<td width="170px">
			    <asp:TextBox Enabled="false" id="txtConcepto0" runat="server" CssClass="textoContenido" Width="150px"></asp:TextBox>
			</td>
			<td align="right" style="text-align:right;">
			    <asp:Label id="Label25" runat="server" CssClass="lbl" Text="TOTAL PAGOS US$"></asp:Label>
			</td>
			<td width="170px">
			    <asp:TextBox Enabled="false" id="txtConcepto1" runat="server" CssClass="textoContenido" Width="150px"></asp:TextBox>
			</td>
			<td width="45px"></td>
		</tr>
	</table>
	</fieldset>
	</td>
	</tr>	
</table>
</center>