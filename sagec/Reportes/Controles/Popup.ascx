<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="Popup.ascx.vb" Inherits="Controles.Popup" %>


<div class="popup" id="popup">
    <div class="handle" id="handle">
        <span class="caption"><asp:Label ID="lblTituloMantenimiento" runat="server" Text="" /></span>
        <span class="closeBox"><a href="#">X</a></span>
    </div>
    
    <div class="popup_content">
        <uc4:NMUsuario ID="NMUsuario1" runat="server" />                 
    </div>
</div>
</div>
