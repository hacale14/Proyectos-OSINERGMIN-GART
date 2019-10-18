<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="GestionCliente.ascx.vb" Inherits="Controles.GestionCliente" %>
<%@ Register src="CtlGrilla.ascx" tagname="CtlGrilla" tagprefix="uc1" %>
<table style="width: 100%;" align="center">
<tr align="center">
<td align="center" style="text-align:center;" class="titulo">
    <asp:Label id="lblTituloControl" runat="server" Font-Size="16px" 
        Font-Bold="True"></asp:Label>
</td>
</tr>
</table>

<table width="100%" style="width:100%;">
<tr>
<td colspan="2" align="center" style="text-align:center;">
<fieldset style="margin:0; padding:0;">
<legend>
    DETALLE DE GESTION
</legend>
    <uc1:CtlGrilla ID="CtlGrilla1" runat="server" Alto="400" Largo="300" Ancho="500" Activa_ckeck="false" Activa_Delete="false" Activa_Edita="false" Activa_option="false" Desactiva_Boton="false"/>
</fieldset>
</td>
</tr>
<tr>
<td align="left" style="text-align:left;">
    <fieldset>
    <asp:Label id="Label1" runat="server" Font-Size="11px" Text="Existe(n): "></asp:Label>
    <asp:Label id="lblExistencia" runat="server" Font-Size="11px" ></asp:Label>
    </fieldset>
</td>
<td align="center" style="text-align:center;">
    <div class="curvo">
    <asp:ImageButton id="imgCerrar" runat="server" Height="30px" Width="35px" ImageUrl="~/imagenes/BotonCerrar.jpg" />				
    <asp:Label id="Label25" runat="server" Font-Size="11px" Text="Cerrar"></asp:Label>
    </div>
</td>
</tr>
</table>