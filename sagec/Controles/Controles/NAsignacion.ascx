<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="NAsignacion.ascx.vb" Inherits="Controles.NAsignacion" %>

<%@ Register src="~/Controles/CtlTxt.ascx" tagname="CtlTxt" tagprefix="uc1" %>
<%@ Register src="~/Controles/CtCombo.ascx" tagname="CtCombo" tagprefix="uc2" %>

<table class="fondoPantalla" style="width: 100%">
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
        <table width="100%">
        <tr>
		    <td><asp:Label ID="lblCliente" runat="server" Text="CLIENTE" ForeColor="Maroon" Font-Size="10px" Font-Bold="true" /></td>
		    <td><uc1:CtlTxt ID="txtCliente" runat="server" Ancho="200" /></td>
		    <td><asp:ImageButton id="btnBuscar" runat="server" Height="30px" Width="30px" ImageUrl="~/Imagenes/BotonBusquedaPequena.png" ToolTip="Buscar"/></td>
	    </tr>
	    <tr>
		    <td><asp:Label ID="lblGestor" runat="server" Text="GESTOR" ForeColor="Maroon" Font-Size="10px" Font-Bold="true" /></td>
		    <td><uc2:CtCombo ID="cboGestor" runat="server" Longitud="60"/></td>
		    <td>
		        <asp:Label ID="lblCodCliente" runat="server" Text="" Visible="false" />
		        <asp:Label ID="lblCodUsuario" runat="server" Text="" Visible="false" />
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
		        <td style="text-align:right" width="35px">
		            <div class="curvo">
		                <asp:ImageButton id="btnGrabar" runat="server" Height="30px" Width="30px" ImageUrl="~/Imagenes/BotonGrabar.png" ToolTip="Grabar" />
            		    <asp:Label ID="lblGrabar" runat="server"  Text="Grabar"></asp:Label>
		            </div>        
		        </td>
		        <td style="text-align:right" width="35px">
		            <div class="curvo" >
		                <asp:ImageButton id="btnCerrar" runat="server" Height="30px" Width="30px" ImageUrl="~/Imagenes/BotonCerrar.jpg" ToolTip="Cerrar" />
		                <asp:Label ID="lblCerrar" runat="server"  Text="Cerrar"></asp:Label>
		            </div>        
		        </td>
		    </tr>
		</table>
		</td>
	</tr>
</table>