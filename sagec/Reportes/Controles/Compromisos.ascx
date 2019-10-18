<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="Compromisos.ascx.vb" Inherits="Controles.Compromisos" %>


<%@ Register src="CtlGrilla.ascx" tagname="CtlGrilla" tagprefix="uc1" %>


<%@ Register src="CtlMensajes.ascx" tagname="CtlMensajes" tagprefix="uc2" %>


<%@ Register src="NMCompromiso.ascx" tagname="NMCompromiso" tagprefix="uc3" %>


<table width="100%" class="fondoPantalla">
<tr>
    <td class="titulo">
        <asp:label ID="lblTituloControl" runat="server" Text="LISTA DE COMPROMISOS"></asp:label>
        <uc2:CtlMensajes ID="CtlMensajes1" runat="server" />
        <asp:label ID="lblTipoCartera" runat="server" Text="" Visible="false"></asp:label>
        <asp:label ID="lblIdCliente" runat="server" Text="" Visible="false"></asp:label>
    </td>
</tr>
<tr>
    <td>
        <fieldset>
            <uc1:CtlGrilla ID="gvCompromiso" runat="server" Activa_ckeck="false" Desactiva_Boton="false" Activa_option="false" Ancho="300px" Largo="400px"/>
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
                    <asp:ImageButton id="btnNuevo" runat="server" Height="30px" Width="30px" ImageUrl="~/Imagenes/botonNuevo.jpg" ToolTip="Click para ingresar un nuevo compromiso" />
			        <asp:Label id="lblNuevo" runat="server" Font-Size="9px" Text="Nuevo"></asp:Label>
                </div>
            </td>
            <td style="text-align:right" width="35px">
                <div class="curvo">
                    <asp:ImageButton id="btnCerrar" runat="server" Height="30px" Width="30px" ImageUrl="~/Imagenes/BotonCerrar.jpg" ToolTip="Click para cerrar compromisos" />
			        <asp:Label id="lblCerrar" runat="server" Font-Size="9px" Text="Cerrar"></asp:Label>
                </div>
            </td>
        </tr>
        </table>
    </td>
</tr>
</table>
<div id="DivNCompromiso" runat="server" style="height:auto; width:auto; position: absolute; left:30%; top:30%;">
    <uc3:NMCompromiso ID="NMCompromiso1" runat="server" />
</div>