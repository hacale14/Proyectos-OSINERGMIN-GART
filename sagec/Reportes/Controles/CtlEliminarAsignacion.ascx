<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="CtlEliminarAsignacion.ascx.vb" Inherits="Controles.CtlEliminarAsignacion" %>

<%@ Register src="CtlTxt.ascx" tagname="CtlTxt" tagprefix="uc1" %>

<%@ Register src="CtlMensajes.ascx" tagname="CtlMensajes" tagprefix="uc2" %>

<table class="fondoPantalla">
<tr>
    <td class="titulo">
        <asp:Label ID="lblTituloControl" runat="server" Text="ELIMINAR ASIGNACION" ForeColor="white"></asp:Label>
        <uc2:CtlMensajes ID="CtlMensajes1" runat="server" />
        <asp:Label ID="lblTituloPrincipal" runat="server" Text="" visible ="false"></asp:Label>
    </td>
</tr>
<tr>
    <td>
        <fieldset>
        <table width="100%">
        <tr>
            <td width="130px"><asp:RadioButton ID="RDBActual" runat="server" Text="REGISTRO ACTUAL" GroupName="RDBGroup" /></td>
            <td><uc1:CtlTxt ID="txtCliente" runat="server" Ancho="200" Desactiva="false" /></td>
        </tr>
        <tr>
            <td><asp:RadioButton ID="RDBAllRegisters" runat="server" Text="TODOS LOS REGISTROS" GroupName="RDBGroup" /></td>
            <td>
                <asp:Label ID="lblIdUsuarioCliente" runat="server" Text="" Visible="false"></asp:Label>
                <asp:Label ID="lblIdCliente" runat="server" Text="" Visible="false"></asp:Label>
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
            <td style="text-align:right;" width="35px">
			    <div class="curvo">
			        <asp:ImageButton id="btnEliminar" runat="server" Height="30px" Width="30px" ImageUrl="~/Imagenes/BotonEliminar.png" ToolTip="Click para eliminar asignaciones" />
			        <asp:Label id="lblEliminar" runat="server" Font-Size="9px" Text="Eliminar"></asp:Label>
			    </div><td style="text-align:right;" width="35px">
				<div class="curvo">
			        <asp:ImageButton id="btnCerrar" runat="server" Height="30px" Width="30px" ImageUrl="~/Imagenes/BotonCerrar.jpg" ToolTip="Click para cerrar" />
			        <asp:Label id="lblCerrar" runat="server" Font-Size="9px" Text="Cerrar"></asp:Label>
			    </div>														 							           					
			</td>
			</td>
			
        </tr>
        </table>
    </td>
</tr>
</table>