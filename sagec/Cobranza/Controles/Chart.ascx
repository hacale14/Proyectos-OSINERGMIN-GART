<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="Chart.ascx.vb" Inherits="Controles.Chart" %>

<script type="text/javascript" src="js/Chart.js"></script>
<script type="text/javascript">
    function Actualiza(){                      
        myBar.datasets[0].bars[parseInt(document.getElementById('<%=txtPosicion.ClientID%>').value)].value = document.getElementById('<%=txtCriterio.ClientID%>').value;
        myBar.update();
    };    
</script>
<div>
    <center>
        <div style="text-align:center; background-color:#fff;border-radius:1em;" >
        <table>
            <tr>
                <td colspan="3" style="text-align:center; font-size:12px;" align="center">
                    <asp:Label ID="lblTitulo" runat="server" Font-Size="12px"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="transform: rotate(270deg);">
                    <asp:Label ID="lblEjeY" runat="server"></asp:Label>
                </td>
                <td>
                    <canvas id="myChart"></canvas>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td colspan="3" align="center" style="text-align:center; border-bottom:1px solid #000000;">
                
                    <asp:Label ID="lblEjeX" runat="server"></asp:Label>
                
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    <asp:PlaceHolder ID="place" runat="server">
                    
                    </asp:PlaceHolder>
                </td>
            </tr>
        </table>
            
        </div>       
         
        <asp:Button ID="Cargar" runat="server" Text="Cargar" OnClientClick="Actualiza();return false;" Visible="false"  />
        <asp:TextBox ID="txtCriterio" runat="server" Text="" Visible="false"></asp:TextBox>
        <asp:TextBox ID="txtPosicion" runat="server" Text="" Visible="false"></asp:TextBox>

    </center>
</div>