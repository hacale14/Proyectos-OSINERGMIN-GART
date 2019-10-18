<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.Master" CodeBehind="ConsultaAsignacion.aspx.vb" Inherits="Cobranza.ConsultaAsignacion" Debug="true"
    title="Consultar Asignaciones" %>
<%@ Register src="~/Controles/BusquedaDatos.ascx" tagname="BusquedaDatos" tagprefix="uc1" %>    
<%@ Register src="Controles/CtlCamposBusqueda.ascx" tagname="CtlCamposBusqueda" tagprefix="uc2" %>
<%@ Register src="Controles/CtlGrilla.ascx" tagname="CtlGrilla" tagprefix="uc3" %>
<%@ Register src="Controles/CtlMensajes.ascx" tagname="CtlMensajes" tagprefix="uc4" %>
<%@ Register Src="~/Controles/CtlEliminarAsignacion.ascx" TagName="CtlEliminarAsignacion" TagPrefix="uc5"  %>
<%@ Register Src="~/Controles/CtlModificarAsignacion.ascx" TagName="CtlModificarAsignacion" TagPrefix="uc6"  %>
<%@ Register src="Controles/Chart.ascx" tagname="Chart" tagprefix="uc7" %>
<%@ Register src="Controles/CtCombo.ascx" tagname="CtCombo" tagprefix="uc8" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <style>
/* MultiView Tab Using Menu Control */
.tabs2
    {
    	position:relative;
    	top:1px;    	
    	z-index:2;    	
    }
    
    .tab2
    {
        border:1px solid black;
        background-image:url(Imagenes/navigation.jpg);
        background-repeat:repeat-x;
        color:White;        
        padding:2px 10px;	
    }
    
    .selectedtab2
    {
    	background:none;
    	background-repeat:repeat-x;
    	color:black;  
   }
    
    
    
    .tabcontents2
    {
    	border:1px solid black;
    	padding:10px;
    	width:auto;
    	height:540px;	
    	font-family: Arial; 	  
	    background-color: #003366; 
	    border-radius: 13px 13px 13px 13px;
        -moz-border-radius: 13px 13px 13px 13px;
        -webkit-border-radius: 13px 13px 13px 13px;   	
    	
    }
</style>
    <script type="text/javascript" src="js/jquery.min.js"></script>
    <script src="js/jquery-ui.js" type="text/javascript"></script>
    <link href="js/jquery-ui.css"rel="stylesheet" type="text/css" />
    
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
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
<Triggers>
    <asp:PostBackTrigger ControlID="Chart1" />
    <asp:PostBackTrigger ControlID="Campos" />
    <asp:PostBackTrigger ControlID="gvCliente" />
    <asp:PostBackTrigger ControlID="gvActiva" />
    <asp:PostBackTrigger ControlID="gvCastigo" />
</Triggers>
<ContentTemplate>

<asp:Label ID="lblcantidadCliente" runat="server" Text="" Visible="false" />
<asp:Label ID="lblcantidadCastigo" runat="server" Text="" Visible="false" />
<asp:Label ID="lblcantidadActiva" runat="server" Text="" Visible="false" />
    <div id="Div1" runat="server" style="width:100%; height:auto">            
    <asp:Label ID="TimeLabel" runat="server" Text="" />                             
    <div style="display:none; visibility:hidden;">
    <asp:Menu ID="Menu1" Orientation="Horizontal"  StaticMenuItemStyle-CssClass="tab" Width="100%"  
    StaticSelectedStyle-CssClass="selectedtab" runat="server" onmenuitemclick="Menu1_MenuItemClick">
        <Items>
            <asp:MenuItem Text="BUSQUEDA POR DATOS DEL CLIENTE" Value="0" Selected="true"></asp:MenuItem>
            <asp:MenuItem Text="BUSQUEDA POR DATOS DE OPERACION - CASTIGO" Value="1"></asp:MenuItem>           
            <asp:MenuItem Text="BUSQUEDA POR DATOS DE OPERACION - ACTIVA" Value="2"></asp:MenuItem>           
        </Items>
    </asp:Menu>
    </div>
    <div class="tabcontents">
        
        <uc4:CtlMensajes ID="CtlMensajes1" runat="server" />
        <uc2:CtlCamposBusqueda ID="Campos" runat="server" />				
        <asp:MultiView ID="MultiView1" ActiveViewIndex="0" runat="server">    
            <asp:View ID="View1" runat="server">
                 <fieldset style="width:100%; height:350px; max-width:98%; text-align:left;">                 
					<uc3:CtlGrilla ID="gvCliente" runat="server" Desactiva_Boton="false" Activa_option="false" Activa_Delete="false" Activa_Edita="false" largo="300px" Ancho="1200px" Visualizar_Img="true" Visualizar_ChkBox="false" Desactivar_Paginacion="true" Nro_Paginacion="11" Activa_Export="true" OpocionNuevo=true/>									     
                 </fieldset>
            </asp:View>
            <asp:View ID="View2" runat="server">
                 <fieldset style="width:98%; height:350px;">
                <uc3:CtlGrilla ID="gvCastigo" runat="server" Desactiva_Boton="false" Activa_option="false" largo="350px" Ancho="970px" Visualizar_Img="true" Visualizar_ChkBox="false" Desactivar_Paginacion="true" Nro_Paginacion="11"/>
                 </fieldset>               
            </asp:View>        
            <asp:View ID="View3" runat="server">
                <fieldset style="width:98%; height:350px;">
                <uc3:CtlGrilla ID="gvActiva" runat="server" Desactiva_Boton="false" Activa_option="false" largo="350px" Ancho="970px" Visualizar_Img="true" Visualizar_ChkBox="false" Desactivar_Paginacion="true" Nro_Paginacion="11"   />
                </fieldset>
            </asp:View>        
        </asp:MultiView>
		<asp:Label runat="server" ID="lblPieContenido" ForeColor="White"></asp:Label>
    </div>              
    </div>
    <div style="height:auto; width:auto; position: absolute; left:10%; top:20%; border:none" >
    <uc6:CtlModificarAsignacion ID="CtlModificarAsignacion1" runat="server" Visible="false" />
    </div>
    <div style="height:auto; width:auto; position: absolute; left:30%; top:20%; border:none" >
    <uc5:CtlEliminarAsignacion ID="CtlEliminarAsignacion1" runat="server" Visible="false" />
    </div>
    
    
<asp:Panel ID="grupo_estaditica" runat="server" Visible="false">
<div style="position: absolute; bottom:10px; right:10px;" class="fondo1">
<table width="100%">
<tr>
    <td>
        <uc7:Chart ID="Chart1" runat="server" />        
    </td>
</tr>
<tr>
    <td align="center" style="text-align:center;">
		<div class="curvo">
		    <asp:ImageButton id="imgCerrar" runat="server" Height="30px" Width="35px" ImageUrl="~/imagenes/BotonCerrar.jpg" />
		    <asp:Label id="Label7" runat="server" Font-Size="11px" Text="Cerrar"></asp:Label>
	    </div>
    </td>
</tr>
</table>
</div>
</asp:Panel>

<asp:Panel ID="PnlMensajeAlerta" runat="server" Visible="false">
        <div onmousedown="conecta(this);" id="Div8" style="height:400px; top:150px; left:500px; z-index:4; background-color:White; border:1px solid; position:absolute;text-align:-moz-right; border-radius: 4px;">
            <table style="background:#white;">
                <tr>
                    <td style="background:#FFA865;color:White;font:'Arial Narrow';font-size=09px;">
                        <asp:Label ID="Label31" runat="server" Visible="false"></asp:Label>
                        <center><br>MENSAJE DE PROXIMA GESTION</br>
			            <br></center><asp:Label ID="Label32" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>    
                    <td> 
                        <table>                            
                            <tr>
                                <td>                       
                                    <br />
                                    <asp:TextBox ID="txtAnotacionMensaje" runat="server"  Enabled = "true" BackColor="#FFD3B2" ReadOnly="false"  TextMode="MultiLine" Height="320px" Width="300px"/>                        
                                </td>
                            </tr>
                            <tr>
                            <td>
                                <center>
                                <asp:Button ID="btnCerrar" runat="server" Text="Cerrar Agenda" style="ForeColor:White;BackColor:Red;Font-Size:Small;Font-Names:'Arial Narrow';"/>
				                <center>
                            </td>
                            </tr>
                        </table>
                    </td>
                </tr>                                
            </table>
        </div>
    </asp:Panel>       
    <asp:Panel ID="PnlBolsa" runat="server" Visible="false">
        <div id="Div4" style="height:200px; top:60px; left:100px; z-index:4; background-color:White; border:1px solid; position:absolute;text-align:-moz-right; border-radius: 4px;">
            <table style="background:#white;">
                <tr>
                    <td style="background:#FFF41B;color:#57530A;font:'Arial Narrow';font-size=09px;">
                        <asp:Label ID="Label1" runat="server" Visible="false"></asp:Label>
                        <center><u1><br>BOLSA DE TRABAJO</br></u1>
			            <br></center><asp:Label ID="Label2" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>    
                    <td>
                        <table>                            
                            <tr>
                                <td>                       
                                    <br />                                    
                                    <asp:TextBox ID="txtBolsa" runat="server"  Enabled = "true" BackColor="#FFFBB7" ForeColor="#57530A" ReadOnly="false"  TextMode="MultiLine" Height="100px" Width="300px" valign="center"/>                                                            
                                </td>
                            </tr>
                            <tr>
                            <td>
                                <center>
                                <asp:Button ID="BtnIngresarBolsa" runat="server" Text="Ingresar Bolsa" style="ForeColor:White;BackColor:Red;Font-Size:Small;Font-Names:'Arial Narrow';"/>
				                <center>                                
                            </td>
                            </tr>
                        </table>
                    </td>
                </tr>                                
            </table>
        </div>
    </asp:Panel>       
    
<asp:Panel ID="pnlPropuesta" runat="server" Visible="false" CssClass="panel_hand">
<asp:Label ID="lblTipoPropuesta" runat="server" Visible="false"></asp:Label>
<div style="position: absolute; top: 150px; left: 100px;">
<table style="background:#E7E6E6; width:100%;border:solid 1px rgba(255,195,0,1);margin:4px; border-radius:5px;">
<tr>
    <td style="font-family:'josefin sans'; font-size:14px; background:rgba(255,195,0,1); border-radius:0px;padding:5px;color:black; font-weight:900;">
        PROPUESTA   
    </td>
</tr>
<tr>
    <td align="center" style="text-align:center;">
		<uc3:CtlGrilla ID="gvPropuesta" runat="server" Desactiva_Boton="false" Activa_ckeck="false" Activa_Delete="false" Activa_Export="false" Activa_option="false" Desactivar_Exportar="0;1;2;3" largo="350px" Ancho="970px" With_Grilla="1100px" />
    </td>
</tr>
<tr>
    <td>
        <asp:Button ID="btnCerrarPropuesta" runat="server" Text="Cerrar" CssClass="semaf_btn_a" style="width:100px; font-size:14px; margin-left:5px;"/>
    </td>
</tr>
<tr><td style="height:10px;"></td></tr>
</table>
</div>

        <asp:Panel ID="pnlMantenimientoPropuesta" runat="server" Visible="false">
            <div style="top:200px; left:200px; z-index:4; background-color:White; border:1px solid; position:absolute;text-align:-moz-right; border-radius: 4px;">    
                <asp:Label ID="lblId_Propuesta" runat="server" Visible="false"></asp:Label>
                <table>
                    <tr>
                        <td>
                            PROPUESTA
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table>
                                <tr>
                                    <td>
                                        Fecha Genero
                                        <br />
                                        <asp:TextBox ID="txtFechaGeneroPropuesta" runat="server"  Width="80px" Enabled = "false" BackColor="White"/>
                                        <img ID="imgFechaGenero" alt="calendario" height="16" onclick="return showCalendar('imgFechaGenero','<%=txtFechaGeneroPropuesta.ClientID%>','%d/%m/%Y','24', true);" 
                                            src="Imagenes/calendario.png" width="18" />
                                    </td>
                                    <td>
                                        Estado
                                        <br />
                                        <uc8:CtCombo ID="cboEstadoPropuesta" Longitud="100" runat="server"  Procedimiento="SQL_N_GEST012" Condicion=":idtabla▓117"/>
                                    </td>
                                    <td>
                                        <div class="curvo" id="Div2" runat="server">
			                                <asp:ImageButton id="imgGrabarPropuesta" runat="server" Height="30px" 
                                                ImageUrl="imagenes/boton busqueda.jpg" Width="45px" />
                                                <br />
					                        <asp:Label id="Label19" runat="server" Font-Size="11px" Text="Grabar"></asp:Label>
					                    </div>
                                    </td>
                                    <td>
                                        <div class="curvo" id="Div3" runat="server">
			                                <asp:ImageButton id="imgCerrarPropuesta" runat="server" Height="30px" 
                                                ImageUrl="imagenes/boton busqueda.jpg" Width="45px" />
                                                <br />
					                        <asp:Label id="Label20" runat="server" Font-Size="11px" Text="Cerrar"></asp:Label>
					                    </div>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table>
                                <tr>
                                    <td>
                                        Nro Operacion
                                        <br />
                                        <uc8:CtCombo ID="cboOperacionPropuesta" Longitud="100" runat="server" />
                                    </td>
                                    <td>
                                        Nro Partes
                                        <br />
                                        <asp:TextBox ID="txtNroPartesPropuesta" runat="server"></asp:TextBox>
                                    </td>
                                    <td>
                                        Monto
                                        <br />
                                        <asp:TextBox ID="txtMontoPropuesta" runat="server"></asp:TextBox>
                                    </td>
                                    <td>
                                        Moneda
                                        <br />
                                        <uc8:CtCombo ID="cboMonedaPropuesta" Longitud="100" runat="server" Procedimiento="SQL_N_GEST006" Condicion=":idtabla▓105" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:TextBox ID="txtSustentoPropuesta" runat="server" Rows="4" Width="454px" 
                                TextMode="MultiLine"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table>
                                <tr>
                                    <td>
                                        Fecha Repuesta
                                        <br />
                                        <asp:TextBox ID="txtFechaRespuesta" runat="server"  Width="80px" Enabled = "false" BackColor="White"/>
                                        <img ID="imgFechaRespuesta" alt="calendario" height="16" onclick="return showCalendar('imgFechaRespuesta','<%=txtFechaRespuesta.ClientID%>','%d/%m/%Y','24', true);" 
                                            src="Imagenes/calendario.png" width="18" />
                                        <br />
                                        Observacion
                                        <br />
                                        <asp:TextBox ID="txtObservacionPropuesta" runat="server" Rows="3" Width="218px" TextMode="MultiLine"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:CheckBox ID="chkPagoPropuesta" runat="server" Text="Pagado" />                                     
                                        <br />
                                        Fecha Pago
                                        <br />
                                        <asp:TextBox ID="txtFechaPagoPropuesta" runat="server"  Width="80px" Enabled = "false" BackColor="White"/>
                                        <img ID="imgFechaPagoPropuesta" alt="calendario" height="16" onclick="return showCalendar('imgFechaPagoPropuesta','<%=txtFechaPagoPropuesta.ClientID%>','%d/%m/%Y','24', true);" 
                                            src="Imagenes/calendario.png" width="18" />
                                        <br />
                                        <table>
                                            <tr>
                                                <td>
                                                    Monto
                                                    <br />
                                                    <asp:TextBox ID="txtMontoPropuestaMantenimiento" runat="server"></asp:TextBox>
                                                </td>
                                                <td>
                                                    Moneda
                                                    <br />
                                                    <uc8:CtCombo ID="cboMonedaPropuestaMantenimeinto" Longitud="100" runat="server"  Procedimiento="SQL_N_GEST006" Condicion=":idtabla▓105" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </div>
        </asp:Panel>


</asp:Panel>

</ContentTemplate>
</asp:UpdatePanel>
</asp:Content>
    
    