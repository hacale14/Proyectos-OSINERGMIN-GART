<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="ctlConsulta.ascx.vb" Inherits="Controles.ctlConsulta" %>
<%@ Register src="CtlGrilla.ascx" tagname="CtlGrilla" tagprefix="uc1" %>
<style type="text/css">
    .style1
    {
        width: 100px;
        border-collapse: collapse;
    }
    .style2
    {
        font-size: 11px;
        font-family: sans-serif;
        text-align: left;
    }
</style>
<table cellpadding="0" class="style1">
    <tr>
        <td>
            <fieldset style="margin:0; padding:0; height:117px; width:760px;">
            <legend>
            <asp:Label id="lbltitulo" runat="server" Font-Size="11px" Text="" BackColor="#E2E2E2"></asp:Label>
            </legend>

            <uc1:CtlGrilla ID="CtlGrilla1" runat="server" />

            </fieldset>
        </td>
    </tr>
    <tr>
        <td align="center">
            <asp:Button ID="Button1" runat="server" Text="Cerrar" />
        </td>
    </tr>
</table>
<p>
    &nbsp;</p>
