<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.Master" CodeBehind="ReporteTrabajo.aspx.vb" Inherits="Cobranza.Formulario_web13" 
    title="Reporte de Trabajo" %>
<%@ Register src="Controles/ReporteCompromisos.ascx" tagname="ReporteCompromisos" tagprefix="uc1" %>

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
<table style="width:100%; text-align:center;">
<tr>
<td style="width:100%;" class="fondoPantalla">
    <uc1:ReporteCompromisos ID="ReporteCompromisos1" runat="server" VerFechaInicio="false" VerFechaFin="false" />
</td>
</tr>
</table>
</ContentTemplate>
</asp:UpdatePanel>
</asp:Content>
