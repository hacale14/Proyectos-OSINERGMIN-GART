<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.Master" CodeBehind="ReporteAgenda.aspx.vb" Inherits="Cobranza.ReporteAgenda" 
    title="Reporte de Agenda" %>
<%@ Register src="Controles/BusquedaAgenda.ascx" tagname="BusquedaAgenda" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contenido" runat="server">
    <table cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td>
                
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>                
                        <table cellpadding="0" cellspacing="0" width="100%" >
                            <tr>
                                <td>                                    
                                    <uc1:BusquedaAgenda ID="BusquedaAgenda1" runat="server" />
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
