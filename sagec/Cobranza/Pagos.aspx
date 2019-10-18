<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.Master" CodeBehind="Pagos.aspx.vb" Inherits="Cobranza.Pagos" 
    title="Pagos Realizados" %>


<%@ Register src="Controles/CtlPagos.ascx" tagname="CtlPagos" tagprefix="uc1" %>


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
<asp:UpdatePanel id="UpdatePanel1" runat="server">
<ContentTemplate>
    <uc1:CtlPagos ID="CtlPagos1" runat="server" titulo="CONSULTA DE PAGOS - CARTERA CASTIGO" />
</ContentTemplate>
</asp:UpdatePanel>    
</asp:Content>
