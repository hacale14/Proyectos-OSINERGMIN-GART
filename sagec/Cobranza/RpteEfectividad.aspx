<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.Master" CodeBehind="RpteEfectividad.aspx.vb" Inherits="Cobranza.RpteEfectividad" 
    title="Efectividad de la Cartera" %>
    <%@ Register src="Controles/CtlExportaFormatos.ascx" tagname="CtlExportaFormatos" tagprefix="uc1" %>
<%@ Register src="Controles/CtlGrilla.ascx" tagname="CtlGrilla" tagprefix="uc2" %>
<%@ Register src="Controles/Chart.ascx" tagname="Chart" tagprefix="uc3" %>
<%@ Register src="Controles/ChartColumn.ascx" tagname="ChartColumn" tagprefix="uc4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1">
	<meta name="HandheldFriendly" content="True">
	<meta name="MobileOptimized" content="320"/>
	<meta name="apple-mobile-web-app-capable" content="yes">
	<meta name="apple-mobile-web-app-status-bar-style" content="black">
	<meta http-equiv="cleartype" content="on">
	<meta name="viewport" content="width=device-width, 
	                               initial-scale=1.0, 
	                               maximum-scale=1.0, 
	                               minimum-scale=1.0, 
	                               user-scalable=no">
    <link href="style/pimay.css" rel="stylesheet" type="text/css" />
    <link rel="shortcut icon" href="/img/logo.jpg">
    
    <!-- Libreria de chart column --->    
    <script type="text/javascript" src="js/scripts/jquery-1.11.1.min.js"></script>
    <script type="text/javascript" src="js/jqwidgets/jqxcore.js"></script>
    <script type="text/javascript" src="js/jqwidgets/jqxdraw.js"></script>
    <script type="text/javascript" src="js/jqwidgets/jqxgauge.js"></script>
    <script type="text/javascript" src="js/jqwidgets/jqxchart.core.js"></script>
    <script type="text/javascript" src="js/jqwidgets/jqxdata.js"></script>

    <script type="text/javascript" src="js/JSGeneral.js"></script>
    <link href="style/gestion.css" rel="stylesheet" type="text/css"/>    
    <script type="text/javascript" src="scripts/calendar.js"></script>
    <script type="text/javascript" src="scripts/calendar-utils.js"></script>
    <script type="text/javascript" src="scripts/calendar-es.js"></script>   
    <script type="text/javascript" src="jquery. min.js"></script>     
    <script type="text/javascript" src="jquery-ui.min.js"></script>
    
    
    
    <link href="calendar-blue.css" rel="stylesheet" type="text/css" />        
	<title>Reporte</title>

	
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contenido" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>    	
		<div data-role="page" id="main_page" data-theme="a">

		<div data-role="header" data-position="fixed" data-tap-toggle="false" data-update-page-padding="false">			
            <h1>            
            <asp:Label ID="Label1" runat="server" Text="Label" Font-Size="Small"></asp:Label>            
            </h1>                                        
		</div>

		<div data-role="content" style="padding:0px" >
		</div>
		<center>
		<table>
		<tr>
		<td>
		        <fieldset style="font-size:11px; background-color:#FAFAFA; font-family:Arial; border: thin groove #808080;" >
                    <legend>CARTERA</legend>
                        <asp:CheckBox ID="CheckBox1" runat="server" Text="ACTIVA/CASTIGO"  AutoPostBack="True" />
                       
                    </fieldset>                                                                
                 </td>
                 <td rowspan=3 valign="top">
                 <fieldset style="font-size:11px; background-color:#FAFAFA; font-family:Arial; border: thin groove #808080 ">
                                <legend>FILTROS POR CALIFICAR</legend>
                                <table>
                                <tr>
                                <td valign="middle">                                    
                                <table>
                                <tr>                                    
                                    <td>
                                    <asp:RadioButton ID="RadioButton1" AutoPostBack="true" text="PRODUCTO" runat="server" />
                                    </td>
                                    <td>
                                    <asp:RadioButton ID="RadioButton2" AutoPostBack="true" text="DIAS" runat="server" />
                                    </td>
                                    <td>
                                    <asp:RadioButton ID="RadioButton3" AutoPostBack="true" text="POR CARTERA" runat="server" />                                    
                                    </td>
                                    <td>
                                    <asp:RadioButton ID="RadioButton4" AutoPostBack="true" text="POR GESTOR" runat="server" />                                    
                                    </td>
                                    <td>
                                    <asp:RadioButton ID="RadioButton5" AutoPostBack="true" text="POR PERIODO" runat="server" />                                    
                                    </td>
                                 </tr>
                                </table> 
                                </td>
                                </tr>
                                </table>
                                </fieldset>                                                 
                 <fieldset style="font-size:11px; background-color:#FAFAFA; font-family:Arial; border: thin groove #808080 ">
                                <legend>GRAFICA DE AVANCES
                                <asp:CheckBox ID="ChkAcumumulativo" runat="server" Text="ACUMULATIVO" Visible="false"  AutoPostBack="True" />
                                </legend>                                
                                <div id='jqxChart' style="width:900px; height:400px; position: relative; left: 0px; top: 0px;">                                    
                                </div>                                          		                                         
                                </fieldset>                                                 
                 &nbsp;                     
                </td>
                
         </tr>
         <tr>
         <td>
                <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" 
                GridLines="None">
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <EditRowStyle BackColor="#999999" />
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <Columns>
                    <asp:TemplateField>
                    <HeaderStyle Width="30"></HeaderStyle>                    
                    <ItemTemplate>
                    <asp:CheckBox ID="ChkBox" runat="server" Visible="true" AutoPostBack="false"  ToolTip="Seleccione" />                                                
                    </ItemTemplate>
                    </asp:TemplateField>                                                                                
                    </Columns>                     
                </asp:GridView>
                </td>                
                </tr>
                <tr>
                <td>
                <fieldset style="font-size:11px; background-color:#FAFAFA; font-family:Arial; border: thin groove #808080 ">
                                <legend>HISTORICO</legend>
                                <center>
                                    <asp:GridView ID="GridView3" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
                                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                        <EditRowStyle BackColor="#999999" />
                                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                        <Columns>
                                        <asp:TemplateField>
                                        <HeaderStyle Width="30"></HeaderStyle>                    
                                        <ItemTemplate>
                                        <asp:CheckBox ID="ChkBox" runat="server" Visible="true" AutoPostBack="false"  ToolTip="Seleccione" />                                                
                                        </ItemTemplate>
                                        </asp:TemplateField>                                                                                
                                        </Columns>                     
                                    </asp:GridView>
                                </center>                                    
                                </fieldset>  
                                
                                <fieldset style="font-size:11px; font-family:Arial; border: thin groove #808080 ">
                                <legend >AVANCES DIARIOS </legend>
                                <center>
                                <table>
                                <tr>
                                <td align="center">
                                <center>
                                <asp:ImageButton ID="ImageButton1" runat="server" Height="56px" ForeColor="White" 
                                    ImageUrl="~/Imagenes/BotonVerEstadisticas.jpg" Width="54px" OnClientClick="abre_Excel();"/>
                                
                                </td>
                                <td class="style2">
                                </td>
                                </center> 
                                <td align="center">
                                <center> 
                                <asp:ImageButton ID="ImageButton2" runat="server" Height="56px" ForeColor="White"  
                                    ImageUrl="~/Imagenes/Compromiso.png" Width="54px"  OnClientClick="window.open('http://192.168.1.49/Compromisos/Comp_Diario.html', '_blank', 'toolbar=yes, scrollbars=yes, resizable=yes, top=10, left=10, width=1020, height=1000');" />
                                </td>
                                </center> 
                                </tr>
                                <tr>
                                <td>INDICADORES
                                </td>
                                <td class="style2">
                                    .
                                </td>
                                <td>COMPROMISOS
                                </td>
                                </tr>
                                </table>
                                </center>
                                </fieldset>                                
		</td>		
		<td>		
		</td>
        </tr>
            </table> 
            </center>
            <iframe id=frmdatos></iframe>
        </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
