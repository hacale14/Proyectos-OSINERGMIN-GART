<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="CtlPagos.ascx.vb" Inherits="Controles.CtlPagos" %>

<%@ Register src="CtlTxt.ascx" tagname="CtlTxt" tagprefix="uc1" %>
<%@ Register src="CtCombo.ascx" tagname="CtCombo" tagprefix="uc2" %>

<%@ Register src="CtlGrilla.ascx" tagname="CtlGrilla" tagprefix="uc3" %>

<%@ Register src="NMPagos.ascx" tagname="NMPagos" tagprefix="uc4" %>

<%@ Register src="Metas.ascx" tagname="Metas" tagprefix="uc5" %>

<%@ Register src="CtlMensajes.ascx" tagname="CtlMensajes" tagprefix="uc6" %>

<table class="fondoPantalla" width="100%">
<tr>
    <td class="titulo">
        <center>
            <uc6:CtlMensajes ID="CtlMensajes1" runat="server" />
            <asp:Label ID="lblTituloControl" runat="server" Text="" ForeColor="White" Font-Bold="true" Font-Size="16px"></asp:Label>
        </center>
    </td>
</tr>
<tr>
    <td>
        <fieldset>
        <table width="100%" cellpadding="0" cellspacing="0" border="0">
        <tr>
            <td></td>
            <td width="60px">
                <asp:Label ID="lblDNI" runat="server" Text="DNI" CssClass="lbl" />
            </td>
            <td>
                <uc1:CtlTxt ID="txtDNI" runat="server"  Ancho="90" />
            </td>
            <td width="60px">
                <asp:Label ID="lblCliente" runat="server" Text="CLIENTE" CssClass="lbl" />
            </td>
            <td>
                <uc1:CtlTxt ID="txtCliente" runat="server" Ancho="200" />
            </td>
            <td width="70px">
                <asp:Label ID="lblFechaInicio" runat="server" text="FEC. INICIO" CssClass="lbl" />
            </td>
            <td> 
                <asp:CheckBox ID="chkInicio" runat="server" />           
                <asp:TextBox ID="txtFechaInicio" runat="server"  Width="80px" Enabled = "false" CssClass="textoContenido"/>
                <img ID="fecha" alt="calendario" height="16"  onclick="return showCalendar('fecha','<%=txtFechaInicio.ClientID%>','%d/%m/%Y','24', true);" src="Imagenes/calendario.png" width="18" />
            </td>
            <td width="70px">
                <asp:Label ID="lblFechaFin" runat="server" Text="FEC. FIN" CssClass="lbl" />
            </td>
            <td>
                <asp:CheckBox ID="chkFin" runat="server" />
                <asp:TextBox ID="txtFechaFin" runat="server"  Width="80px" Enabled = "false" CssClass="textoContenido"/>
                <img ID="fecha1" alt="calendario" height="16" onclick="return showCalendar('fecha1','<%=txtFechaFin.ClientID%>','%d/%m/%Y','24', true);" 
                src="Imagenes/calendario.png" width="18" />
            </td>
            <td width="60px">
                <asp:Label ID="lblCartera" runat="server" Text="CARTERA" CssClass="lbl" />
            </td>
            <td><uc2:CtCombo ID="cboCartera" runat="server" Ancho="90" Procedimiento="QRYC007" Condicion="" /></td>
            <td style="text-align:center">
                <div class="curvo">
					    <asp:ImageButton ID="btnBuscar" runat="server" ToolTip="Busqueda" ImageUrl="~/Imagenes/Boton Busqueda.jpg" CssClass="curvoimg" />
                        <asp:Label ID="lblBuscar" runat="server" Text="Buscar"  CssClass="curvolbl" />
                </div>
            </td>
            <td></td>
        </tr>
        </table>
        </fieldset>
    </td>
</tr>
<tr><td><asp:Label ID="lblSubTitulo" runat="server" Text="" ForeColor="white" Font-Size="13px" Font-Bold="true" Visible="false" /></td></tr>
<tr>
	<td>
	    <fieldset>
	    <uc3:CtlGrilla ID="gvPagos" runat="server"  Activa_option="false" Desactiva_Boton="false" Ancho="970px" Largo="350px" />
	    </fieldset>    
	</td>
</tr>
<tr>
    <td>
        <table style="width: 100%">
		<tr>
		    <td></td>
		    <td  style="text-align:right;" width="35px">
				<div class="curvoaplica" style="width:150px;">
			        <asp:ImageButton id="btnNuevo" runat="server" Height="30px" Width="30px" ImageUrl="~/Imagenes/botonNuevo.png" ToolTip="Click para ingresar un nuevo pago" />
			        <asp:Label id="lblNuevo" runat="server" CssClass="curvolbl" Text="Nuevo Pago"></asp:Label>
			    </div>															 					
			</td>
			<td  style="text-align:right;" width="35px">
				<div class="curvoacepta" style="width:180px;">
			        <asp:ImageButton id="btnMetas" runat="server" Height="30px" Width="30px" ImageUrl="~/Imagenes/BotonMetas.png" ToolTip="Click para revisar las metas" />
			        <asp:Label id="lblMetas" runat="server" CssClass="curvolbl" Text="Visualizar Metas"></asp:Label>
			    </div>															 								     
			</td>
			<td style="text-align:right;" width="35px">
				<div class="curvocancela" style="width:150px;">
			        <asp:ImageButton id="btnCerrar" runat="server" Height="30px" Width="30px" ImageUrl="~/Imagenes/BotonCerrar.png" ToolTip="Click para cerrar pagos" />
			        <asp:Label id="lblCerrar" runat="server" CssClass="curvolbl" Text="Cerrar Pagos"></asp:Label>
			    </div>															 							           					
			</td>
		</tr>
		</table>
    </td>
</tr>
</table>
<div id="DivNPago" runat="server" style="height:auto; width:auto; position: absolute; left:30%; top:30%;">
    <uc4:NMPagos ID="NMPagos1" runat="server" Visible="false" />
</div>
<div id="DivMetas" runat="server" style="height:auto; width:auto; position: absolute; left:10%; top:20%;" >
    <uc5:Metas ID="Metas1" runat="server" Visible="false" />
</div>