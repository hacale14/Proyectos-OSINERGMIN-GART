<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.Master" CodeBehind="ExportarData.aspx.vb" Inherits="Cobranza.ExportarData" 
    title="Exportar Datos" %>
<%@ Register src="Controles/CtlExportaDatos.ascx" tagname="CtlExportaDatos" tagprefix="uc1" %>


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
<Triggers>
    <asp:PostBackTrigger ControlID="Exportar"/>
</Triggers>
<ContentTemplate>
    <uc1:CtlExportaDatos ID="Exportar" runat="server" />
</ContentTemplate>
</asp:UpdatePanel>
</asp:Content>
