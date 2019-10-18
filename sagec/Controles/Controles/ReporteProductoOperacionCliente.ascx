<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="ReporteProductoOperacionCliente.ascx.vb" Inherits="Controles.ReporteProductoOperacionCliente" %>
<%@ Register src="CtlGrilla.ascx" tagname="CtlGrilla" tagprefix="uc1" %>
<%@ Register src="CtlMensajes.ascx" tagname="CtlMensajes" tagprefix="uc2" %>
<table>
<tr align="center">
<td align="center" style="text-align:center;" class="titulo">
    <asp:Label id="lblTituloControl" runat="server"></asp:Label>
    <uc2:CtlMensajes ID="CtlMensajes1" runat="server" />
</td>
</tr>
</table>

<table style="width:100%; text-align:center;">
<tr>
<td >
    <uc1:CtlGrilla ID="CtlGrilla1" runat="server" Ancho="400px" Largo="300px" Activa_ckeck="false" Activa_Delete="false" Activa_Edita="false" Activa_option="false" Desactiva_Boton="false" />
</td>
</tr>
<tr>
<td align="center" style="text-align:center;">
    <div class="curvo">
    <asp:ImageButton id="imgCerrar" runat="server" Height="30px" Width="35px" 
                    ImageUrl="~/imagenes/BotonCerrar.jpg" />
	<asp:Label id="Label18" runat="server" Font-Size="11px" Text="Cerrar"></asp:Label>			
    </div>
</td>
</tr>
</table>