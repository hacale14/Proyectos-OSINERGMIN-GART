<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="NConvenios.ascx.vb" Inherits="Controles.NConvenios" %>
<%@ Register src="CtCombo.ascx" tagname="CtCombo" tagprefix="uc1" %>
<%@ Register src="CtlTxt.ascx" tagname="CtlTxt" tagprefix="uc2" %>

<%@ Register src="CtlMensajes.ascx" tagname="CtlMensajes" tagprefix="uc3" %>

<table class="fondoPantalla" width="100%">
<tr>
    <td class="titulo">
        <asp:Label id="lblTituloControl" runat="server" Text=""></asp:Label>
        <asp:Label id="lblIdCompromiso" runat="server" Text="" Visible="false"></asp:Label>
        <asp:Label id="lblIdCliente" runat="server" Text="" Visible="false"></asp:Label>
        <uc3:CtlMensajes ID="CtlMensajes1" runat="server" />
    </td>
</tr>
<tr>
    <td>
        <fieldset>
        
        <table width="100%" cellpadding="0" cellspacing="0">
        <tr><td colspan="2"><asp:Label ID="lblFechaGenero" runat="server" Text="FECHA GENERO"></asp:Label></td></tr>
        <tr>
            <td colspan="2">      
                <asp:TextBox ID="txtFechaGenero" runat="server"  Width="80px" Enabled = "false" BackColor="White"/>
                <img ID="fecha" alt="calendario" height="16"  onclick="return showCalendar('fecha','<%=txtFechaGenero.ClientID%>','%d/%m/%Y','24', true);" 
                src="~/Imagenes/calendario.png" width="18" />
            </td>
        </tr>
        <tr><td colspan="2"><asp:Label ID="lblFechaCompromiso" runat="server" 
                Text="FECHA CONVENIO"></asp:Label></td></tr>
        <tr>
            <td colspan="2">      
                <asp:TextBox ID="txtFechaCompromiso" runat="server"  Width="80px" Enabled = "false" BackColor="White"/>
                <img ID="fecha1" alt="calendario" height="16"  onclick="return showCalendar('fecha1','<%=txtFechaCompromiso.ClientID%>','%d/%m/%Y','24', true);" 
                src="~/Imagenes/calendario.png" width="18" />
            </td>
        </tr>
        <tr><td colspan="2"><asp:Label ID="lblNroOperacion" runat="server" Text="Nro OPERACION" ></asp:Label></td></tr>
        <tr><td colspan="2">
            <uc1:CtCombo ID="cboOperacion" runat="server" Longitud="150" />
            </td></tr>
        <tr>
            <td>NRO CUOTA&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>
                <uc2:CtlTxt ID="txtMonto0" runat="server" Ancho="90" />
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td><asp:Label id="lblMonto" runat="server" Text="MONTO"></asp:Label></td>
            <td><asp:Label ID="lblMoneda" runat="server" Text="MONEDA"></asp:Label></td>
        </tr>
        <tr>
            <td>
                <uc2:CtlTxt ID="txtMonto" runat="server" Ancho="90" />
            </td>
            <td>
                <uc1:CtCombo ID="cboMoneda" runat="server" Longitud="60" />
            </td>
        </tr>
        <tr>
            <td colspan="2"><asp:Label ID="lblTipoPago" runat="server" Text="TIPO PAGO"></asp:Label></td>
        </tr>
        <tr>
            <td colspan="2">
            <uc1:CtCombo ID="cboTipoPago" runat="server" />
            </td>
        </tr>
        <tr>
            <td colspan="2" style="text-align:center">
                <asp:CheckBox ID="chkPagado" runat="server" />
                <asp:label ID="lblPagado" runat="server" Text="PAGADO"></asp:label>
            </td>
        </tr>
        </table>
        </fieldset>
    </td>
</tr>
<tr>
    <td>
        <table width="100%">
        <tr>
            <td></td>
            <td  style="text-align:right;" width="35px">
				<div class="curvo">
	            <asp:ImageButton id="btnGrabar" runat="server" Height="30px" Width="30px" ToolTip="Grabar" 
	            ImageUrl="~/Imagenes/BotonGrabar.png"/>
                <asp:Label id="lblGrabar" runat="server" Font-Size="11px" Text="Grabar"></asp:Label>
                </div>															 					
			</td>
            <td style="text-align:right;" width="35px">
				<div class="curvo">
			        <asp:ImageButton id="btnCerrar" runat="server" Height="30px" Width="30px" ImageUrl="~/Imagenes/BotonCerrar.jpg" ToolTip="Click para cerrar compromiso" />
			        <asp:Label id="lblCerrar" runat="server" Font-Size="9px" Text="Cerrar"></asp:Label>
			    </div>															 							           					
			</td>
        </tr>
        </table>
    </td>
</tr>
</table>