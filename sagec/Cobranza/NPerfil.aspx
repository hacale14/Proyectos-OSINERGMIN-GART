<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.Master" CodeBehind="NPerfil.aspx.vb" Inherits="Cobranza.NPerfil" %>

<%@ Register src="Controles/CtlNPerfil.ascx" tagname="CtlNPerfil" tagprefix="uc1" %>

<asp:Content ID="Content4" ContentPlaceHolderID="Contenido" runat="server">
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

    <uc1:CtlNPerfil ID="CtlNPerfil1" runat="server" />

</ContentTemplate>
</asp:UpdatePanel>
</asp:Content>
