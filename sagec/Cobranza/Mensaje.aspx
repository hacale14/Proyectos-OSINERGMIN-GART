<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.Master" CodeBehind="Mensaje.aspx.vb" Inherits="Cobranza.Mensaje" 
    title="Página sin título" %>
<%@ Register src="Controles/CtlTxt.ascx" tagname="CtlTxt" tagprefix="uc1" %>
<%@ Register src="Controles/CtCombo.ascx" tagname="CtCombo" tagprefix="uc2" %>
<%@ Register src="Controles/CtlEditor.ascx" tagname="CtlEditor" tagprefix="uc3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contenido" runat="server">
    <table class="style1">
        <tr>
            <td colspan="4">
                Mantenimiento de Alertas
            </td>
        </tr>
        <tr>
            <td colspan="4">
                Filtro del Mensaje</td>
        </tr>
        <tr>
            <td>
                Fecha Inicio
            </td>
            <td>
                <uc1:CtlTxt ID="CtlTxt1" runat="server" />
                (Separado &quot;;&quot; -&gt; indica ejecucion preiodica &quot;-&quot; indica por rangi de fecha)</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                Horas(s)</td>
            <td>
                <uc1:CtlTxt ID="CtlTxt2" runat="server" />
                (Separado &quot;;&quot; -&gt; indica ejecucion preiodica &quot;-&quot; indica por rangi de fecha)</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                Minutos(s)</td>
            <td>
                <uc1:CtlTxt ID="CtlTxt3" runat="server" />
                (Separado &quot;;&quot; -&gt; indica ejecucion preiodica &quot;-&quot; indica por rangi de fecha)</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                Tipo de Mensaje
            </td>
            <td>&nbsp;<uc2:CtCombo ID="CtCombo1" runat="server" />
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                Cuerpo del Mensaje</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="4">
                <uc3:CtlEditor ID="CtlEditor1" runat="server" Largo="100"  />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="Button1" runat="server" Text="Agregar" />
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                Consulta de Mensaje de Generados</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="4">
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>
