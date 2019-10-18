<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.Master" CodeBehind="Gestionarbk.aspx.vb" Inherits="Cobranza.Gestionar" 
    title="Gestionar" %>
<%@ Register src="~/Controles/Gestion.ascx" tagname="Gestion" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contenido" runat="server">
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>
        <center>
            <asp:Label ID="Titulo" runat="server" Text="GESTIONAR" ForeColor="#3399ff" Font-Bold="true" Font-Size="Small"></asp:Label>
        </center>
    <div style="border: thin groove #808080; width:auto; height:auto;background-color:#045FB4;">
            <uc1:Gestion ID="Gestion1" runat="server" MKDolares="false" MKSoles="false" MTDolares="false" MTSoles="false" BotonHistorial="false"  />    
    </div>

</ContentTemplate>
</asp:UpdatePanel>
</asp:Content>
