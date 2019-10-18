<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="CtlExportaFormatos.ascx.vb" Inherits="Controles.CtlExportaFormatos" %>

<script src="js/tableExport.js" type="text/javascript"></script>
<script src="js/jquery.base64.js" type="text/javascript"></script>
<script type="text/javascript" src="js/libs/sprintf.js"></script>
<script type="text/javascript" src="js/jspdf.js"></script>
<script type="text/javascript" src="js/libs/base64.js"></script>
<script src="js/libs/jspdf.plugin.autotable.js" type="text/javascript"></script>
<script src="js/libs/jspdf.min.js" type="text/javascript"></script>

<table>
                       <tr>
                    <td class="style4" bgcolor="White">
                    <asp:Label ID="lblAgregar" Text="Agregar:" runat="server" Visible="false"></asp:Label>
                    <asp:ImageButton Visible="false" ID="LnkNew" ImageUrl="~/Imagenes/nuevo.png" runat="server" Height="15px" Width="15px"/>                           
                    <asp:Label ID="Label1" runat="server" Text="Exportación:"></asp:Label>
                    <asp:ImageButton ID="LnkXLS" ImageUrl="~/Imagenes/excel.png" runat="server" Height="15px" Width="15px"/>
                    <asp:ImageButton ID="LnkDOC" ImageUrl="~/Imagenes/word.png" runat="server" Height="15px" Width="15px"/>
                    <asp:ImageButton ID="LnkPDF" ImageUrl="~/Imagenes/PDF.png" runat="server" Height="15px" Width="15px"/> 
                    <asp:ImageButton ID="LnkCSV" ImageUrl="~/Imagenes/CSV.png" runat="server" Height="15px" Width="15px"/>
                    <asp:PlaceHolder ID="place" runat="server"></asp:PlaceHolder>
                </td>
            </tr>
</table>
                
                       

                
              