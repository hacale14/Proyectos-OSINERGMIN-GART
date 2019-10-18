<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.Master" CodeBehind="Empresa.aspx.vb" Inherits="Cobranza.Formulario_web123" 
    title="Adminsitracion de Empresa" %>
<%@ Register src="Controles/AdministracionEmpresa.ascx" tagname="AdministracionEmpresa" tagprefix="uc1" %>
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

<table  style="width:100%; text-align:center;">
<tr>
<td style="width:100%;text-align:center;" class="fondoPantalla">
    <uc1:AdministracionEmpresa ID="AdministrarCarteras1" runat="server" Titulo="CONSULTA DE CARTERA"/>
</td>
</tr>
</table>
</ContentTemplate>
</asp:UpdatePanel>
</asp:Content>
