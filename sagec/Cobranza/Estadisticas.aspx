<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Estadisticas.aspx.vb" Inherits="Cobranza.Estadisticas" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >

<head runat="server">
    <title>Estaditicas</title>
    <script type="text/javascript" src="/js/Chart.js"></script>
    <script type="text/javascript">
        function Actualiza(){                      
            myBar.datasets[0].bars[parseInt(document.getElementById('<%=txtPosicion.ClientID%>').value)].value = document.getElementById('<%=txtCriterio.ClientID%>').value;
            myBar.update();
        };    
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <center>
        <div style="width:400px; height:400px; text-align:center " >
        <table>
            <tr>
                <td colspan="3">
                    <asp:Label ID="lblTitulo" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="transform: rotate(270deg);">
                    <asp:Label ID="lblEjeY" runat="server"></asp:Label>
                </td>
                <td>
                    <canvas id="myChart" width="400" height="400" style="width: 400px; height: 400px;"></canvas>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td colspan="3">
                
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
    </form>
</body>
</html>
