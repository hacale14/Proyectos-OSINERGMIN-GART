<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.Master" CodeBehind="ReasignarGestor.aspx.vb" Inherits="Cobranza.ReasignarGestor" 
    title="Reasignar Gestor" %>
<%@ Register src="Controles/CtlReasignarGestor.ascx" tagname="CtlReasignarGestor" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<style type="text/css">
        .style1
        {
            width: 100%;
            height: 540px;
        }
    </style>
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
<asp:UpdatePanel ID="UpdatePanel1" runat="server" >
<ContentTemplate>
    <table>
            <tr>
                <td>
                    <center>
                        <uc1:CtlReasignarGestor ID="CtlReasignarGestor1" runat="server" />
                    </center>
                </td>
            </tr>
    </table>
</ContentTemplate>
</asp:UpdatePanel>
</asp:Content>
