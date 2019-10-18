<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.Master" CodeBehind="ReporteBolsa.aspx.vb" Inherits="Cobranza.ReporteBolsa" 
        title="Reporte de Bolsa de Trabajo" %>
<%@ Register src="Controles/BusquedaBolsa.ascx" tagname="BusquedaBolsa" tagprefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="Contenido" runat="server">
    <table cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>                
                        <table cellpadding="0" cellspacing="0" width="100%">
                            <tr>
                                <td>                                    
                                    <uc2:BusquedaBolsa ID="BusquedaBolsa1" runat="server" />
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1" DisplayAfter="1">
	            <ProgressTemplate>
                    <div class="loading"></div>
                </ProgressTemplate>
                </asp:UpdateProgress>
                
           </td>
        </tr>
    </table>
</asp:Content>

