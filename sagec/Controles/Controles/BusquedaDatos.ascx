<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="BusquedaDatos.ascx.vb" Inherits="Controles.BusquedaDatos" %>

<%@ Register src="~/Controles/CtlGrilla.ascx" tagname="CtlGrilla" tagprefix="uc1" %>
<%@ Register src="~/Controles/CtCombo.ascx" tagname="CtCombo" tagprefix="uc2" %>
<%@ Register src="~/Controles/CtlTxt.ascx" tagname="CtlTxt" tagprefix="uc3" %>
<%@ Register src="~/Controles/Botones.ascx" tagname="Botones" tagprefix="uc4" %>
<%@ Register src="CtlModificarAsignacion.ascx" tagname="CtlModificarAsignacion" tagprefix="uc5" %>
<%@ Register src="CtlEliminarAsignacion.ascx" tagname="CtlEliminarAsignacion" tagprefix="uc6" %>

<table width="100%" cellpadding="0" cellspacing="0" id="TablaPrincipal" runat="server">
<tr>
    <td class="titulo">
        <center>
            <asp:Label ID="lblTituloControl" runat="server" Text="" ForeColor="White" Font-Bold="true" Font-Size="16px"></asp:Label>
        </center>
    </td>
</tr>
<tr>
    <td>
        <fieldset>
	    <legend><asp:Label id="lblTituloGrupo" runat="server" Font-Size="11px" Text="FILTRAR POR"></asp:Label></legend>
	    <table style="width: 100%" cellpadding="0" cellspacing="0">
		<tr>
			<td><asp:Label ID="lblCartera" runat="server" Text="CARTERA" ForeColor="Maroon" Font-Size="10px" Font-Bold="true" /></td>
			<td><asp:Label ID="lblGestor" runat="server" Text="GESTOR" ForeColor="Maroon" Font-Size="10px" Font-Bold="true" /></td>
			<td><asp:Label ID="lblCondic" runat="server" Text="CONDIC." ForeColor="Maroon" Font-Size="10px" Font-Bold="true" /></td>
			<td><asp:Label ID="lblDNI" runat="server" Text="DNI" ForeColor="Maroon" Font-Size="10px" Font-Bold="true" /></td>
			<td><asp:Label ID="lblRefin" runat="server" Text="REFIN." ForeColor="Maroon" Font-Size="10px" Font-Bold="true" /></td>
			<td><asp:Label ID="lblCampaña" runat="server" Text="CAMPAÑA" ForeColor="Maroon" Font-Size="10px" Font-Bold="true" /></td>
			<td><asp:Label ID="lblProducto" runat="server" Text="PRODUCTO" ForeColor="Maroon" Font-Size="10px" Font-Bold="true" /></td>
			<td><asp:Label ID="lblNegocio" runat="server" Text="NEGOCIO" ForeColor="Maroon" Font-Size="10px" Font-Bold="true" /></td>
			<td><asp:Label ID="lblNroOperacion" runat="server" Text="Nro.OPERACION" ForeColor="Maroon" Font-Size="10px" Font-Bold="true" /></td>
			<td><asp:Label ID="lblNroCuenta" runat="server" Text="Nro.DE CTA." ForeColor="Maroon" Font-Size="10px" Font-Bold="true" /></td>
			<td><asp:Label ID="lblCiente" runat="server" Text="NOMBRE DE CLIENTE" ForeColor="Maroon" Font-Size="10px" Font-Bold="true" /></td>
			<td><asp:Label ID="lblTelefono" runat="server" Text="TELEFONO" ForeColor="Maroon" Font-Size="10px" Font-Bold="true" /></td>
			<td><asp:Label ID="lblTipoCartera" runat="server" Text="TIPO CART." ForeColor="Maroon" Font-Size="10px" Font-Bold="true" /></td>
			<td><asp:Label ID="lblDiasMora" runat="server" Text="DIAS MORA" ForeColor="Maroon" Font-Size="10px" Font-Bold="true" /></td>
			<td style="text-align:center" rowspan="2">
			    <div class="curvo">
			        <asp:ImageButton ID="btnBuscar" runat="server" ImageUrl="~/Imagenes/BotonBusquedaPequena.png" ToolTip="Buscar" Width="35px" Height="30px"  />
			        <asp:Label ID="lblBuscar" runat="server" text="Buscar" />
			    </div>
			</td>
		</tr>
		<tr>
			<td><uc2:CtCombo ID="cboCartera" runat="server" Longitud="200"    AutoPostBack="true" Procedimiento="QRYCG002" /></td>
			<td><uc2:CtCombo ID="cboGestor" runat="server" Longitud="200"  Activa="false" /></td>
			<td><uc2:CtCombo ID="cboCondicion" runat="server" Longitud="40"/></td>
			<td><uc3:CtlTxt ID="txtDNI" runat="server" Ancho="80" /></td>
			<td><uc3:CtlTxt ID="txtRefin" runat="server" Ancho="40" /></td>
			<td><uc3:CtlTxt ID="txtCampaña" runat="server" Ancho="80" /></td>
			<td><uc3:CtlTxt ID="txtProducto" runat="server" Ancho="80" /></td>
			<td><uc3:CtlTxt ID="txtNegocio" runat="server" Ancho="80" /></td>
			<td><uc3:CtlTxt ID="txtNroOperacion" runat="server" Ancho="80" /></td>
			<td><uc3:CtlTxt ID="txtNroCuenta" runat="server" Ancho="80" /></td>
			<td><uc3:CtlTxt ID="txtCliente" runat="server" Ancho="200" /></td>
			<td><uc3:CtlTxt ID="txtTelefono" runat="server" Ancho="80" /></td> 
			<td><uc2:CtCombo ID="cboTipoCartera" runat="server" Longitud="60"/></td>
			<td><uc2:CtCombo ID="cboDiasMora" runat="server" Longitud="80"/></td>
		</tr>
	</table>
	</fieldset>  
    </td>
</tr>
<tr>
    <td>
        <asp:Label ID="lblCantidad" runat="server" Text="" Visible="false"></asp:Label>
    </td>   
</tr>
<tr>
    <td>
        <fieldset>
        <uc1:CtlGrilla ID="gvPrincipal" runat="server" Desactiva_Boton="false" Activa_option="false" largo="350px" Ancho="970px" Visualizar_Img="true" Visualizar_ChkBox="false" />
        </fieldset>
    </td>
</tr>
<tr>
    <td style="text-align:center">
        
    </td>
</tr>
</table>
<div style="height:auto; width:auto; position: absolute; left:10%; top:20%; border:none" >
<uc5:CtlModificarAsignacion ID="CtlModificarAsignacion1" runat="server" Visible="false" />
</div>
<div style="height:auto; width:auto; position: absolute; left:30%; top:20%; border:none" >
<uc6:CtlEliminarAsignacion ID="CtlEliminarAsignacion1" runat="server" Visible="false" />
</div>