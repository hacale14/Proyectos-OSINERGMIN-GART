<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="NMPagos.ascx.vb" Inherits="Controles.NMPagos" %>
<%@ Register src="~/Controles/CtlTxt.ascx" tagname="CtlTxt" tagprefix="uc1" %>
<%@ Register src="~/Controles/CtCombo.ascx" tagname="CtCombo" tagprefix="uc2" %>
<%@ Register src="CtlMensajes.ascx" tagname="CtlMensajes" tagprefix="uc3" %>
<table class="fondoPantalla">
<tr>
    <td style="text-align:center;" colspan="2">
        <asp:Label id="lblTituloControl" runat="server" CssClass="titulo"></asp:Label>
        <asp:Label ID="lblIDCliente" runat="server" Text="" Visible="false" />
        <uc3:CtlMensajes ID="CtlMensajes1" runat="server" />
        <asp:Label ID="lblIDPago" runat="server" Text="" Visible="false" />
    </td>
</tr>
<tr>
    <td colspan="2">
    <fieldset>
    <table style="width: 100%">
		    <tr>
			    <td><asp:Label ID="lblCliente" runat="server" Text="CLIENTE" /></td>
			    <td><uc1:CtlTxt ID="txtCliente" runat="server" Ancho="150" /></td>
			    <td>
			        <div class="curvo">
			            <asp:ImageButton id="btnBuscar" runat="server" ImageUrl="~/Imagenes/BotonBusquedaPequena.png" Width="30px" Height="30px" ToolTip="Buscar" />
			        </div>
			    </td>
		    </tr>
		    <tr>
			    <td><asp:Label ID="lblFecha" runat="server" Text="FECHA"/></td>
			    <td>
                    <asp:TextBox ID="txtFechaPago" runat="server"  Width="80px" Enabled = "false" BackColor="White"/>
                    <img ID="fecha5" alt="calendario" height="16" onclick="return showCalendar('fecha5','<%=txtFechaPago.ClientID%>','%d/%m/%Y','24', true);" 
                    src="~/Imagenes/calendario.png" width="18" />
                </td>
			    <td>&nbsp;</td>
		    </tr>
		    <tr>
			    <td><asp:Label ID="lblOperacion" runat="server" Text="Nro OPERACION"  /></td>
			    <td><uc2:CtCombo ID="cboOperacion" runat="server" Longitud="150"/></td>
			    <td>&nbsp;</td>
		    </tr>
		    <tr>
			    <td><asp:Label ID="lblPago" runat="server" Text="PAGO"  /></td>
			    <td>
			        <uc1:CtlTxt ID="txtPago" runat="server" Ancho="75" />
			        <uc2:CtCombo ID="cboMoneda" runat="server" Longitud="50" />
			    </td>
			    <td>&nbsp;</td>           
		    </tr>
		    <tr>
			    <td><asp:Label ID="lblObservacion" runat="server" Text="OBSERVACION"  /></td>
			    <td><uc1:CtlTxt ID="txtObservacion" runat="server" Ancho="150" /></td>
			    <td>&nbsp;</td>
		    </tr>
	    </table>
    </fieldset>
    </td>
</tr>
<tr>
	<td style="text-align: center;" align="center">
	    <div class="curvo">
	    <asp:ImageButton id="btnGrabar" runat="server" Height="30px" Width="35px" ToolTip="Grabar" 
	     ImageUrl="~/Imagenes/BotonGrabar.png"/>
        <asp:Label id="Label12" runat="server" Font-Size="11px" Text="Grabar"></asp:Label>
        </div>
	</td>
	<td style="text-align: center;" align="center">
	    <div class="curvo">
	    <asp:ImageButton id="BtnCerrar" runat="server" Height="30px" Width="35px" ToolTip="Cerrar"
	     ImageUrl="~/Imagenes/BotonCerrar.jpg"/>
        <asp:Label id="Label1" runat="server" Font-Size="11px" Text="Cerrar"></asp:Label>
        </div>
	</td>
</tr>
</table>
