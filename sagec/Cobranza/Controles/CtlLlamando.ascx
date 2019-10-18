<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="CtlLlamando.ascx.vb" Inherits="Controles.CtlLlamando" %>
<style type="text/css">
    .style1
    {
        width: 11%;
    }
</style>
<fieldset style="padding:0; margin:0; height:20;">
    <legend>
        <asp:Label id="Label8" runat="server" Font-Size="11px" Text="EN PROCESO DE LLAMADA..."></asp:Label>
    </legend>
    <table style="width:100%;height:25px;padding:0;margin:0;">	    				        
    <tr>                                
    <td class="style1">
    <center style="width: 103px"><img src='/Imagenes/imgCell6.png' alt='Smiley face' height='100px' width='100px'></center>
    </td>
    <td>
        <asp:Label ID="Label9" runat="server" Font-Size="XX-Large" Text="S/N" ForeColor="#000066"></asp:Label>     
    </td width=80%>
    </tr>
    </table>
</fieldset>

<asp:Timer ID="Timer1" runat="server" Interval="5000">
</asp:Timer>
