<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="ClienteNoGestionado.ascx.vb" Inherits="Controles.ClienteNoGestionado" %>
<%@ Register src="CtlGrilla.ascx" tagname="CtlGrilla" tagprefix="uc1" %>


<table style="width: 100%;" align="center">
<tr align="center">
<td align="center" style="text-align:center;" class="titulo">
    RELACION DE CLIENTES NO ATENDIDOS
</td>
</tr>
</table>

<table>
<tr>
    <td colspan="3">
        <uc1:CtlGrilla ID="CtlGrilla1" runat="server" Ancho="900px" Largo="300px" Activa_ckeck="false" Activa_option="false" Desactiva_Boton="false" Activa_Delete="false" Activa_Edita="false" />
    </td>
</tr>
<tr>
    <td style="text-align:center;">
    <fieldset>
        <asp:Label ID="lblCantidad" runat="server"></asp:Label>
    </fieldset>
    </td>
    <td style="text-align:right;">
        <div class="curvo">
		<asp:ImageButton id="imgCerrar" runat="server" Height="30px" Width="35px" 
            ImageUrl="~/imagenes/BotonCerrar.jpg" />
		<asp:Label id="Label7" runat="server" Font-Size="11px" Text="Cerrar"></asp:Label>
		</div>
    </td>
</tr>
</table>