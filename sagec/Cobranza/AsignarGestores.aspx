<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="AsignarGestores.aspx.vb" Inherits="Cobranza.AsignarGestores" MasterPageFile="~/MasterPage.Master" %>

<%@ Register src="Controles/CtlAsignarGestor.ascx" tagname="CtlAsignarGestor" tagprefix="uc1" %>

<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style1
        {
            width: 100%;
            height: 540px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="Contenido">
<asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
<ProgressTemplate>
    <div class="modal2">
        <div class="center">
            <img alt="" src="Imagenes/loader.gif" />
        </div>
    </div>
</ProgressTemplate>
</asp:UpdateProgress>
<asp:UpdatePanel ID="UpdatePanel1" runat="server" >
<ContentTemplate>
    <table>
            <tr>
                <td>
                    <center>
                    <uc1:CtlAsignarGestor ID="CtlAsignarGestor1" runat="server" />
                    </center>
                </td>
            </tr>
    </table>
</ContentTemplate>
</asp:UpdatePanel>
</asp:Content>




