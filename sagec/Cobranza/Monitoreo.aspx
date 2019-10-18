<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.Master" CodeBehind="Monitoreo.aspx.vb" Inherits="Cobranza.Monitoreo" 
    title="Monitorear" %>

<asp:Content ID="Content3" ContentPlaceHolderID="Contenido" runat="server">

<asp:UpdatePanel ID="UpdatePanel2" runat="server">
<ContentTemplate>
                    <asp:GridView ID="GridView1" runat="server" BackColor="White" 
                    BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3">
                    <RowStyle Font-Size="XX-Small" ForeColor="#000066" />
                    <FooterStyle BackColor="White" ForeColor="#000066" />
                    <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                    <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#006699" Font-Bold="True" Font-Size="XX-Small" 
                        ForeColor="White" />
                </asp:GridView>
                <asp:Timer ID="Timer1" runat="server">
                </asp:Timer>
</ContentTemplate>
</asp:UpdatePanel>
</asp:Content>


