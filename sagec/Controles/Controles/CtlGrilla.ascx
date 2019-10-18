<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="CtlGrilla.ascx.vb" Inherits="Controles.CtlGrilla" %>
<%@ Register src="CtlExportaFormatos.ascx" tagname="CtlExportaFormatos" tagprefix="uc1" %>
<script type="text/javascript" src="../js/jquery.min.js"></script> 
<script type="text/javascript" src="../js/jquery-ui.min.js"></script> 
<script type="text/javascript" src="../scripts/gridviewScroll.min.js"></script>
<script type="text/javascript"> 
    $(document).ready(function () { 
        gridviewScroll(); 
    }); 
 
    function gridviewScroll() { 
        $('#<%=GridView1.ClientID%>').gridviewScroll({ 
            width: parseFloat('<%=Me.Ancho%>', 10), 
            height: parseFloat('<%=Me.Largo%>', 10), 
            arrowsize: 30, 
            varrowtopimg: "../Imagenes/arrowvt.png", 
            varrowbottomimg: "../Imagenes/arrowvb.png", 
            harrowleftimg: "../Imagenes/arrowhl.png", 
            harrowrightimg: "../Imagenes/arrowhr.png" 
        }); 
    } 
</script>
 
<table cellpadding="0" cellspacing="0" width="100%" class="grillatabla">
        <tr>
        <td class="grillaconta">
            <asp:Label ID="lblTituloGrilla" runat="server" 
                Font-Bold="True"  cssclass="titleGrid"></asp:Label>
            </td>
        </tr>
        <tr>
        <td>
        <asp:Label ID="Label2" runat="server" Text="" Visible="False"/>
        <asp:Label ID="Label3" runat="server" Text="" Visible="False"/>
        <asp:Label ID="Label1" runat="server" ForeColor="#CC0000" Text="No Hay Registros a mostrar...!" 
        Visible="False"></asp:Label>
        <div runat="server" id="divGrilla">
        <div id="<%=Me.Clientid%>_HeaderDiv">
        </div>
        <div id="<%=Me.Clientid%>_DataDiv" style="overflow: auto; width:<%=Me.Ancho%>; height:<%=Me.Largo%>;" onscroll="Onscrollfnction(<%=Me.Clientid%>_HeaderDiv,<%=Me.Clientid%>_DataDiv);">
        <asp:GridView ID="GridView1" runat="server" Width="100%" allowsorting="true">          
             <HeaderStyle CssClass="GridviewScrollHeader" />               
             <RowStyle CssClass="GridviewScrollItem" /> 
             <PagerStyle CssClass="GridviewScrollPager" /> 
            <Columns>
                    <asp:TemplateField ShowHeader="False" HeaderText="" HeaderStyle-Width="25px">
                    <ItemTemplate>
                        <asp:RadioButton ID="RadioButton"  AutoPostBack="true" runat="server" ToolTip="Seleccione" OnCheckedChanged="elegir"/>
                    </ItemTemplate>
                    
                    <HeaderStyle Width="10px"></HeaderStyle>
                    </asp:TemplateField>                                              
                    <asp:TemplateField ShowHeader="False" HeaderText="" HeaderStyle-Width="15">
                    <ItemTemplate>
                    <asp:CheckBox ID="ChkBox" runat="server" Visible="true" AutoPostBack="true"  ToolTip="Seleccione" OnCheckedChanged="Seleccionar" />
                    <!--<asp:ImageButton ID="ImgCall" runat="server" Visible="true" ImageUrl="~/Imagenes/imgCall6.png" Width="10px" Height="10px"/>-->                 
                    </ItemTemplate>                    
                    <HeaderStyle Width="15"></HeaderStyle>
                    </asp:TemplateField>                                                                  
                     <asp:TemplateField ShowHeader="False" HeaderStyle-VerticalAlign="Middle"  HeaderStyle-HorizontalAlign="Center" HeaderStyle-Width="15">
                        <ItemTemplate>
                            <center>
                                <asp:ImageButton ID="ImageButton1" runat="server" CausesValidation="False"  CommandName="Edit" ImageUrl="~/Imagenes/select.png" OnClientClick="return confirm('Esta seguro que desea modificar el registro?');" Text="Edit" ToolTip="Modificar" />
                            </center>
                        </ItemTemplate>
                    <HeaderStyle Width="15"></HeaderStyle>
                    </asp:TemplateField>
                    <asp:TemplateField ShowHeader="False" HeaderStyle-Width="15">
                        <ItemTemplate>
                            <center>
                            <asp:ImageButton ID="ImageButton2" runat="server" CausesValidation="False" CommandName="Delete" ImageUrl="~/Imagenes/cancel.png" OnClientClick="return confirm('Esta seguro que desea eliminar el registro?');" Text="Delete" ToolTip="Eliminar" />
                            </center>
                        </ItemTemplate>                                                                    
                    <HeaderStyle Width="15"></HeaderStyle>                    
                    </asp:TemplateField>
                </Columns>                     
        </asp:GridView>    
        </div>
        </div>
        </td>
        </tr>
        <tr>
        <td style="color: black; font-family: 'Arial Narrow'; font-size: small;">
        <uc1:CtlExportaFormatos ID="CtlExportaFormatos1" runat="server" />
        </td>
        </tr>   
        </table>        
<asp:Button ID="Button1" runat="server" Text="Seleccionar" />