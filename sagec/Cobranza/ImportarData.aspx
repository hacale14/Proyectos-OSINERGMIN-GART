<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.Master" CodeBehind="ImportarData.aspx.vb" Inherits="Cobranza.ImportarData" title="Importar Data" %>


<%@ Register src="Controles/CtlImportarData.ascx" tagname="CtlImportarData" tagprefix="uc1" %>


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
    <asp:PostBackTrigger ControlID="Importar"/>
</Triggers>
<ContentTemplate>
    <uc1:CtlImportarData ID="Importar" runat="server" />
</ContentTemplate>
</asp:UpdatePanel>
</asp:Content>
