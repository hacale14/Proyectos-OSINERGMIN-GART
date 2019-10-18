<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="DefinirCondicion.ascx.vb" Inherits="Controles.DefinirCondicion" %>


<%@ Register src="CtCombo.ascx" tagname="CtCombo" tagprefix="uc1" %>

<%@ Register src="CtlMensajes.ascx" tagname="CtlMensajes" tagprefix="uc2" %>

<table class="fondoPantalla" width="100%" >
<tr>
    <td class="titulo">
        <center>
            <asp:Label ID="lblTituloControl" runat="server" Text="" ForeColor="White" Font-Bold="true" Font-Size="16px"></asp:Label>
            <uc2:CtlMensajes ID="CtlMensajes1" runat="server" />
        </center>
    </td>
</tr>
<tr>
    <td>
    <fieldset>
    <table width="100%">
    <tr>
        <td style="text-align:center;" colspan="2">
            <asp:TextBox ID="txtAviso" runat="server" TextMode="MultiLine" Rows="3" Columns="55" BackColor="#99ccff" 
            Text="Se Cambiara la condicion de todos los registros filtrados en la ventana anterior. Elija la nueva CONDICION y presione el boton de CAMBIAR CONDICION." Enabled="false"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="text-align:right"><asp:Label ID="lblCondicion" runat="server" Text="CONDICION" ForeColor="Maroon" Font-Size="10px" Font-Bold="true" /></td>
        <td style="text-align:left">
            <uc1:CtCombo ID="cboCondicion" runat="server" Longitud="50"/>
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
        <td>
            <div class="curvo" width="30px" style="text-align:right">
            <asp:ImageButton ID="btnCambiar" runat="server" ImageUrl="~/Imagenes/Cambiar.png" ToolTip="Cambiar Condicion" Width="30px" Height="30px" />
                <asp:Label ID="lblCambiar" runat="server" Text="Cambiar" Font-Size="9px"></asp:Label>
            </div>
        </td>
        <td>
            <div class="curvo" width="30px" style="text-align:right">
            <asp:ImageButton ID="btnCerrar" runat="server" ImageUrl="Imagenes/BotonCerrar.jpg" ToolTip="Cerrar Condicion" Width="30px" Height="30px" />
                <asp:Label ID="lblCerrar" runat="server" Text="Cerrar" Font-Size="9px"></asp:Label>
            </div>
        </td>
    </tr>
    </table>
    </td>
</tr>
</table>