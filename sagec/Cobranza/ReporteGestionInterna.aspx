<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.Master" CodeBehind="ReporteGestionInterna.aspx.vb" Inherits="Cobranza.Formulario_web110" 
    title="Reporte de Gestion Interno" %>
<%@ Register src="Controles/ReporteGestionInterno.ascx" tagname="ReporteGestionInterno" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Contenido" runat="server">
<asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
<ProgressTemplate>
    <div class="modal2">
        <div class="center">
            <img alt="" src="Imagenes/loader.gif" />
        </div>
    </div>
</ProgressTemplate>
</asp:UpdateProgress>


<asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>
<script type="text/javascript">
function DescarArchivo(archivo){
    document.location = archivo;
}
</script>

<table style="width:100%; text-align:center;">
<tr>
<td style="width:100%; text-align:center;" class="fondoPantalla">
    <uc1:ReporteGestionInterno ID="ReporteGestionInterno1" runat="server"></uc1:ReporteGestionInterno>
</td>
</tr>
</table>
</ContentTemplate>
</asp:UpdatePanel>
</asp:Content>
