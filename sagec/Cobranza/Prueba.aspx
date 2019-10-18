<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Prueba.aspx.vb" Inherits="Cobranza.Prueba" MasterPageFile="~/MasterPage.Master" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="Contenido">

<asp:UpdatePanel ID="UpdatePanel1" runat="server" >
<Triggers>
<asp:PostBackTrigger ControlID="btnCargar" />
</Triggers>
<ContentTemplate>
<asp:Image ID="img" runat="server" />
<br />
<asp:FileUpload ID="FileUpload1" runat="server" />
<asp:Button ID="btnCargar" runat="server" Text="Cargar" />
</ContentTemplate> 
</asp:UpdatePanel>
</asp:Content>

