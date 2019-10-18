<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.Master" CodeBehind="Tarea.aspx.vb" Inherits="Cobranza.Formulario_web17" 
    title="Administracion de tareas" %>
<%@ Register src="Controles/Tareas.ascx" tagname="Tareas" tagprefix="uc1" %>
    
    
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contenido" runat="server">
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
<table width:100%; text-align:center;" width="100%">
<tr>
<td style="width:100%;" class="fondoPantalla">    
    <uc1:Tareas ID="Tareas1" runat="server" />    
</td>
</tr>
</table>
</ContentTemplate>
</asp:UpdatePanel>


</asp:Content>
