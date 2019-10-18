<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Gestion.aspx.vb" Inherits="Cobranza.Gestion" %>
<%@ Register src="Controles/CtCombo.ascx" tagname="CtCombo" tagprefix="uc2" %>
<%@ Register src="Controles/CtlTxt.ascx" tagname="CtlTxt" tagprefix="uc3" %>
<%@ Register src="Controles/CtlCboCartera.ascx" tagname="CtlCboCartera" tagprefix="uc4" %>
<%@ Register src="Controles/CtlLlamando.ascx" tagname="CtlLlamando" tagprefix="uc5" %>
<%@ Register src="Controles/CtlGrilla.ascx" tagname="CtlGrilla" tagprefix="uc1" %>
<%@ Register src="Controles/CtlMensajes.ascx" tagname="CtlMensajes" tagprefix="uc6" %>
<%@ Register src="Controles/ctlConsulta.ascx" tagname="ctlConsulta" tagprefix="uc7" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Administracion de la gestion del cliente</title>

<style type="text/css">  
#base-map {    position:absolute;    left:0;    top:0;    width:500px;    height:320px;    z-index:1;    background-color: #CCCCCC;}  
#user-1 {position: absolute;left: 0;top: 0;width: 16px;height: 21px;z-index: 2;background-color: #006699;}  
#flec {    position:absolute;    left:514px;    top:18px;    width:103px;    height:81px;    z-index:3;}  
    .style2
    {
        width: 110px;
    }
</style>  
<script type="text/javascript"> 
    function abajo(){ 
    var posiciony=document.getElementById("user-1").offsetTop; 
    var abajo = document.getElementById("user-1").style.top=posiciony + 20; 
    } 

    function arriba(){ 
    var posiciony=document.getElementById("user-1").offsetTop; 
    var arriba = document.getElementById("user-1").style.top=posiciony - 20; 
    } 

    function izquierda(){ 
    var posicionx=document.getElementById("user-1").offsetLeft; 
    var izquierda = document.getElementById("user-1").style.left=posicionx  - 20; 
    } 

    function derecha(){ 
    var posicionx=document.getElementById("user-1").offsetLeft; 
    var derecha = document.getElementById("user-1").style.left=posicionx + 20; 
    } 
</script> 


    <link href="style/pimay.css" rel="stylesheet" type="text/css" />
    <link rel="shortcut icon" href="/img/logo.jpg">
    <link href="calendar-blue.css" rel="stylesheet" type="text/css" />        
 
    
    <script src="scripts/gridview.js" type="text/javascript"></script>    
    <script type="text/javascript" src="scripts/scriptsSistema.js" charset="iso-8859-1"></script>
    <script type="text/javascript" src="scripts/prototype.js"></script>
    <script type="text/javascript" src="scripts/calendar.js"></script>
    <script type="text/javascript" src="scripts/calendar-utils.js"></script>
    <script type="text/javascript" src="scripts/calendar-es.js"></script>   
    <script type="text/javascript" src="jquery.min.js"></script>     
    <script type="text/javascript" src="jquery-ui.min.js"></script> 
    <script type="text/javascript" src="gridviewScroll.min.js"></script>

    <script type="text/javascript"        
        src="https://www.google.com/jsapi?autoload={'modules':[{'name':'visualization','version':'1','packages':['gauge']}]}">
        windows.document.fullScreenElement;
    </script>
    <script type="text/javascript">      
      
      google.load('visualization', '1', {packages: ['gauge']});      
      google.setOnLoadCallback(Cobertura);
      google.setOnLoadCallback(Efectividad);
      var gaugeOptions = {min: 0, max: 100, yellowFrom: 80, yellowTo: 95, greenFrom: 95, greenTo: 100, minorTicks: 5};
      var gauge;      
      
      function Efectividad() {
        gaugeData = new google.visualization.DataTable();
        gaugeData.addColumn('number', 'Efectividad');        
        gaugeData.addRows(1);
        gaugeData.setCell(0, 0, <%=Me.Efectividad%>);       

        gauge = new google.visualization.Gauge(document.getElementById('gauge_dive'));
        gauge.draw(gaugeData, gaugeOptions);
      }  
      function Cobertura() {
        gaugeData = new google.visualization.DataTable();
        gaugeData.addColumn('number', 'Cobertura');        
        gaugeData.addRows(1);
        gaugeData.setCell(0, 0, <%=Me.Cobertura%>);       

        gauge = new google.visualization.Gauge(document.getElementById('gauge_div'));
        gauge.draw(gaugeData, gaugeOptions);
      }

      function changeTemp(dir) {
        gaugeData.setValue(0, 0, gaugeData.getValue(0, 0) + dir * 25);        
        gauge.draw(gaugeData, gaugeOptions);
      }
    </script>
    <script type="text/javascript">
        function GetChar (event){
            var chCode = ('charCode' in event) ? event.charCode : event.keyCode;
            alert ("The Unicode character code is: " + chCode);
        }
        function LlamarTelefono(mensaje,objimg){       
        ColocarTelefono(mensaje);
        ifrllamar.src = 'http://192.168.1.200/llamar.php?anexo=178&telefono=' + mensaje + '&idcliente=0';        
        }
    </script>
    <script>
        function teclas(e) {
          var keynum;
          if (window.event) {
            //Internet Explorer
            keynum = e.KeyCode;
          }
          else if (e.which) {
            //Netscape, Firefox, Opera
            keynum = e.which;
          }
          alert(keynum);
        }
    </script>

    
</head>
<body body style="margin:0; padding:0;" bgcolor="#000116">
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>               
    
    <asp:Label ID="lblId_Cliente" runat="server" Visible="false"></asp:Label>
    <asp:Label ID="lblId_Usuario" runat="server" Visible="false"></asp:Label>
    <asp:Label ID="lblId_Empresa" runat="server" Visible="false"></asp:Label>
    <asp:Label ID="lblId_Cartera" runat="server" Visible="false"></asp:Label>
    <asp:Label ID="lblTipo_Cartera" runat="server" Visible="false"></asp:Label>
    <asp:Label ID="lblDni_Activo" runat="server" Visible="false"></asp:Label>
    <asp:Label ID="lblTelefono_Activo" runat="server" Visible="false"></asp:Label>
    
    
    <center>
    <table style="background-color:#E2E2E2" >
    <tr>
        <td align="center" colspan=2><font color="black"><center>RECUPERACION DEL CLIENTE</center></font></td>
    </tr>
    <tr>
    <td colspan=2>
        <fieldset style="margin:0; padding:0;width:700px; background-color:#000116;" >
        <table>
        <tr>
            <td valign="bottom"><FONT COLOR=White><b>CARTERA</b></FONT></td>
            <td valign="bottom"><FONT COLOR=White><b>C.INT</b></FONT></td>
            <td valign="bottom"><FONT COLOR=White><b>C.EXT</b></FONT></td>
            <td valign="bottom"><FONT COLOR=White><b>TIPO C.</b></FONT></td>
            <td valign="bottom"><FONT COLOR=White><b>SITUAC.</b></FONT></td>
            <td valign="bottom"><FONT COLOR=White><b>DNI</b></FONT></td>
            <td rowspan=2 valign="middle" style="background-color:#E2E2E2"><div class="curvop"><asp:ImageButton id="imgBuscar" runat="server" Height="30px" Width="35px" ImageUrl="~/imagenes/boton busqueda.jpg" ToolTip="Buscar"/><asp:Label id="lblBuscar" runat="server" Font-Size="11px" Text="" ToolTip="Buscar"></asp:Label></div></td>
            <td valign="bottom" class="style2"><FONT COLOR=White><b>NOMBRE DE CLIENTE</b></FONT></td>
            <td rowspan="2" valign="middle" style="background-color:#E2E2E2"><div class="curvop"><asp:ImageButton id="imgPropuesta" runat="server" Height="30px" Width="25px" ImageUrl="~/imagenes/BotonReporte.jpg" ToolTip="Propuesta" /><asp:Label id="Label23" runat="server" Font-Size="11px" Text="" ToolTip="Campo"></asp:Label></div></td>
            <td rowspan="2" valign="middle" style="background-color:#E2E2E2"><div class="curvop"><asp:ImageButton id="ImageButton1" runat="server" Height="30px" Width="25px" ImageUrl="~/imagenes/campo.png" ToolTip="Campo" /><asp:Label id="Label3" runat="server" Font-Size="11px" Text="" ToolTip="Campo"></asp:Label></div></td>
            <td rowspan="2" valign="middle" style="background-color:#E2E2E2"><div class="curvop"><asp:ImageButton id="ImageButton2" runat="server" Height="30px" Width="25px" ImageUrl="~/imagenes/botonGrabar.png" ToolTip="Grabar"/><asp:Label id="Label4" runat="server" Font-Size="11px" Text="" ToolTip="Grabar"></asp:Label></div></td>
        </tr>
        <tr>    
            <td><uc2:CtCombo ID="cbocartera" runat="server" Longitud="100" Procedimiento="QRYCG002"/></td>
	        <td><uc2:CtCombo ID="cbocint" runat="server" Longitud="100" Procedimiento="QRYCGC001"/></td>
	        <td><uc3:CtlTxt ID="txtcext" runat="server" Ancho="100"/></td>
	        <td><uc2:CtCombo ID="cbotipoc" Longitud="100" runat="server" /></td>
	        <td><uc3:CtlTxt ID="txtsitua" runat="server" Ancho="50"/></td>
	        <td><uc3:CtlTxt ID="txtDNI" runat="server" Ancho="100"/></td>
			<td class="style2"><uc3:CtlTxt ID="txtnombre" runat="server" Ancho="360"/></td>
        </tr>
        </table>    
        </fieldset>
    </td> 
    </tr>    
    <tr>
    <td>
            <fieldset style="margin:0; padding:0;height:200px; width:320px;">
		        <legend>
		            <asp:Label id="Label2" runat="server" Font-Size="11px" BackColor="#E2E2E2" Text=" TELEFONOS "></asp:Label>
		        </legend>
                <uc1:CtlGrilla ID="CtlTelefono" runat="server" Activa_ckeck="false" Activa_option="true" Desactiva_Boton="false" Activa_Titulo="false" Largo="165px" With_Grilla="320px" Activa_Delete="false" OcultarColumnas="4;5;6;8;9;10;11;13;14;16;17;19" Desactivar_Exportar="0;1;2;3;4" Activa_Edita="true" OpocionNuevo="true"/>
            </fieldset>
    </td>
    <td align="right">
            <fieldset style="margin:0; padding:0; height:117px; width:760px;">
		        <legend>
		            <asp:Label id="Label1" runat="server" Font-Size="11px" Text=" DIRECCIONES " BackColor="#E2E2E2"></asp:Label>
		        </legend>
                <uc1:CtlGrilla ID="CtlDireccion" runat="server" Largo="80px" Ancho="755px" Activa_ckeck="false" Activa_option="false" Desactiva_Boton="false" OcultarColumnas="4;5;8;9;10;11;14;15;17"  Activa_Titulo="false" Desactivar_Exportar="0;1;2;3;4" OpocionNuevo="true" />
            </fieldset>
            <fieldset style="margin:0; padding:0; height:76px; width:760px;">
		        <legend>
		            <asp:Label id="Label13" runat="server" Font-Size="11px" Text=" ANOTACIONES "  BackColor="#E2E2E2"></asp:Label>
		        </legend>
                <uc1:CtlGrilla ID="CtlAnotaciones" runat="server" Largo="67px" Ancho="755px" Activa_Delete="false"  Activa_ckeck="false" Activa_option="false" Activa_Titulo="false" Desactiva_Boton="False" OcultarFormatos="False" />
            </fieldset>
    </td>
    </tr>
    
    <tr>
    <td>
            <fieldset style="margin:0; padding:0;height:80px; width:320px;">
		        <legend>
		            <asp:Label id="Label5" runat="server" Font-Size="11px" BackColor="#E2E2E2" Text=" ESTADISTICAS DE AVANCES "></asp:Label>
		        </legend>
		        <table style="top:0;">
                <tr>
                <td width=20% valign="top"><div id="gauge_div" style="width:70px; height:65px;"></div></td>
                <td width=20% valign="top"><div id="gauge_dive" style="width:70px; height:65px;"></div></td>                          
                <td width=60% valign="top" ><uc1:CtlGrilla ID="CtlEstadistica" runat="server" Largo="60px" Ancho="155px"  
                                                           Activa_Delete="false" Activa_Edita="false" 
                                                           Activa_ckeck="false" Activa_option="false" 
                                                           OcultarFormatos="false" Desactiva_Boton="false" 
                                                           Activa_Titulo="false"/></td>                            
                </tr>
                </table>
		       
            </fieldset>
    </td>
    <td>
            <fieldset style="margin:0; padding:0; height:80px; width:760px;">
		        <legend>
		            <asp:Label id="Label6" runat="server" Font-Size="11px" Text=" DATOS ADICIONALES " BackColor="#E2E2E2"></asp:Label>
		        </legend>
                <table style="margin:0; padding:0; height:60px; width:590px;">
                    <tr><td></td></tr>
                    <tr><td></td></tr>
                    <tr>
                    <td><FONT COLOR=#640003><b>Cent.Laboral</b></FONT></td>
                    <td>
                        <uc3:CtlTxt ID="txtCentroLaboral" runat="server" Ancho="260" Largo="10"/>
                        </td>
                    <td><FONT COLOR=#640003><b>1erProd</b></FONT></td>
                    <td>
                        <uc3:CtlTxt ID="txt1erProd" runat="server" Ancho="260" Largo="10"/>
                        </td>
                    <td><FONT COLOR=#640003><b>Edad</b></FONT></td>
                    <td>
                        <uc3:CtlTxt ID="txtEdad" runat="server" Ancho="50" Largo="10"/>
                        </td>
                    </tr>
                    <tr>
                    <td><FONT COLOR=#640003><b>Conyugue</b></FONT></td>
                    <td>
                        <uc3:CtlTxt ID="txtConyugue" runat="server" Ancho="260" Largo="10"/>
                        </td>
                    <td><FONT COLOR=#640003><b>Aval</b></FONT></td>
                    <td>
                        <uc3:CtlTxt ID="txtAval" runat="server" Ancho="260" Largo="10"/>
                        </td>
                    <td><FONT COLOR=#640003><b>Ing.</b></FONT></td>
                    <td>
                        <uc3:CtlTxt ID="txtIngreso" runat="server" Ancho="50" Largo="10"/>
                        </td>
                    </tr>
                    <tr>
                    <td><FONT COLOR=#640003><b>E.mail</b></FONT></td>
                    <td colspan="2">
                        <uc3:CtlTxt ID="txtemail" runat="server" Ancho="310" Largo="10"/>
                        </td>
                    <td colspan="3"><FONT COLOR=#640003><b>Rep. Legal:</b></FONT>
                        <uc3:CtlTxt ID="txtRepresentanteLegal" runat="server" Ancho="285" Largo="10"/>
                        </td>
                    </tr>
                </table>
            </fieldset>
    </td>
    </tr>
    <tr>
    <td colspan=2>
    <table>
    <tr>    
    <td>
    
        <fieldset style="margin:0; padding:0; height:330px; width:940px;">
            <legend>
                <asp:Label id="Label7" runat="server" Font-Size="11px" Text=" GESTIONES REALIZADAS " BackColor="#E2E2E2"></asp:Label>
            </legend>
            <fieldset style="margin:0; padding:0; height:42px; width:935px;">
                <table style="height:10px; width:930px;">            
                    <tr>
                    <td><FONT COLOR=#640003><b>Detalle de la Gestión</b></FONT></td>
                    <td><FONT COLOR=#640003><b>Indicador de la Gestión</b></FONT></td>
                    <td><FONT COLOR=#640003><b>Observacion</b></FONT></td>
                    <td><FONT COLOR=#640003><b>Propuesta</b></FONT></td>
                    <td><FONT COLOR=#640003><b>Campo</b></FONT></td>
                    <td><FONT COLOR=#640003><b>Call</b></FONT></td>
                    <td rowspan=2 valign="middle"><center><div class="curvop"><asp:ImageButton id="ImageButton4" runat="server" Height="32px" Width="32px" ImageUrl="~/imagenes/Save.png" ToolTip="Guardar Gestion"/><asp:Label id="Label12" runat="server" Font-Size="2px" Text="" ToolTip="Guardar Gestion"></asp:Label></div></center> </td>
                    <tr>
                    <td><uc2:CtCombo ID="CboGestion" Longitud="120" runat="server" /></td>
                    <td><uc2:CtCombo ID="cboIndicador" Longitud="200" runat="server" /></td>
                    <td><uc3:CtlTxt ID="txtGestion" runat="server" Ancho="420"/></td>                                        
                    <td><center><asp:RadioButton ID="RDBPropuesta" runat="server" AutoPostBack="true" GroupName="tipoGestion"/></center></td>
                    <td><center><asp:RadioButton ID="RDBCampo" runat="server" AutoPostBack="true" GroupName="tipoGestion" /></center></td>
                    <td><center><asp:RadioButton ID="RDBCall" runat="server" AutoPostBack="true" GroupName="tipoGestion" /></center></td>                    
                    </tr>
                </table> 
            </fieldset>
            <fieldset style="margin:0; padding:0; height:140px; width:935px;">
                <legend>
                    <asp:Label id="Label10" runat="server" Font-Size="11px" Text=" GESTIONES TELEFONICAS " BackColor="#E2E2E2"></asp:Label>
                </legend>           
                <uc1:CtlGrilla ID="CtlGestionTelefonica" runat="server" Largo="120px" With_Grilla="937px" Activa_ckeck="false" Activa_Delete="false" Activa_Edita="false" Activa_option="false" Activa_Titulo="false" Desactiva_Boton="False" OcultarFormatos="False" OcultarColumnas="7;12;13;14;15" />
            </fieldset>
            
            <fieldset style="margin:0; padding:0; height:120px; width:935px;">
                <legend>
                    <asp:Label id="Label11" runat="server" Font-Size="11px" Text=" GESTIONES DE CAMPO " BackColor="#E2E2E2"></asp:Label>
                </legend> 
                <uc1:CtlGrilla ID="CtlGestionCampo" runat="server" Largo="100px" With_Grilla="937px"  Activa_ckeck="false" Activa_Delete="false" Activa_Edita="false" Activa_option="false" Activa_Titulo="false"   Desactiva_Boton="False" OcultarFormatos="False"  OcultarColumnas="7;12;13;14;15" />
            </fieldset>
        </fieldset>        
    </td>
    <td>    
        <fieldset style="margin:0; padding:0; height:330px; width:140px;">
            <legend>
                <asp:Label id="Label8" runat="server" Font-Size="11px" Text=" DATOS DE LA DEUDA " BackColor="#E2E2E2"></asp:Label>
            </legend>                     
            <table style="height:300px; width:140px;">            
                <tr><td><center><FONT COLOR=#1A0A4C><b>TOTAL S/.</b></FONT></center></td></tr>
                <tr><td><center><uc3:CtlTxt ID="txtDeudaTotalSoles" runat="server" style="text-align:center" Ancho="100"/></center></td></tr>
                <tr><td><center><FONT COLOR=#1A0A4C><b>DEUDA  VCDA S/.</b></FONT></center></td></tr>
                <tr><td><center><uc3:CtlTxt ID="txtDeudaVcdaSoles" style="text-align:center" runat="server" Ancho="100"/></center></td></tr>
                <tr><td><center><FONT COLOR=#1A0A4C><b>DEUDA  VCDA US$</b></FONT></center></td></tr>
                <tr><td><center><uc3:CtlTxt ID="txtDeudaVcdaCUSD" style="text-align:center" runat="server" Ancho="100"/></center></td></tr>
                <tr><td><center><FONT COLOR=#1A0A4C><b>TOTAL US$</b></FONT></center></td></tr>
                <tr><td><center><uc3:CtlTxt ID="txtDeudaTotalUSD" style="text-align:center" runat="server" Ancho="100"/></center></td></tr>
                <tr><td><center><FONT COLOR=#1A0A4C><b>DEUDA  VCDA US$</b></FONT></center></td></tr>          
                <tr><td><center><uc3:CtlTxt ID="txtDeudaVcdaUSD" style="text-align:center" runat="server" Ancho="100"/></center></td></tr>
                <tr><td><center><FONT COLOR=#1A0A4C><b>DEUDA  VCDA S/.</b></FONT></center></td></tr>          
                <tr><td><center><uc3:CtlTxt ID="txtDeudaVcdaCSoles" style="text-align:center" runat="server" Ancho="100"/></center></td></tr>
                <tr><td rowspan=2 valign="middle">
                <center>
                <table>
                <tr>
                <td><div class="curvop"><asp:ImageButton id="btnPagos" runat="server" Height="30px" Width="35px" ImageUrl="~/imagenes/Pago.png" ToolTip="Click para mostrar pagos"/><asp:Label id="Label9" runat="server" Font-Size="11px" Text="Pagos" ToolTip="Reporte de Pagos"></asp:Label></div></td>
                <td><div class="curvop"><asp:ImageButton id="btnCompromisos" runat="server" Height="30px" Width="35px" ImageUrl="~/imagenes/oferta.png" ToolTip="Click para mostrar compromisos"/><asp:Label id="Label14" runat="server" Font-Size="11px" Text="Compro" ToolTip="Consuta Compromisos" ></asp:Label></div></td>
                </tr>
                <tr>
                <td>
                    <div class="curvop">
                    <asp:ImageButton id="btnInfAdd" runat="server" Height="30px" Width="35px" ImageUrl="~/imagenes/infadicional.png" ToolTip="Click para Informacion Adicional"/>
                    <asp:Label id="Label15" runat="server" Font-Size="11px" Text="Inf_Add" ToolTip="Informacion adicional" ></asp:Label>
                    </div>
                </td>
                <td>
                    <div class="curvop">
                    <asp:ImageButton id="btnDeuda" runat="server" Height="30px" Width="35px" ImageUrl="~/imagenes/Deudaf.png" ToolTip="Click para mostrar deuda"/>
                    <asp:Label id="Label16" runat="server" Font-Size="11px" Text="Deuda" ToolTip="Deuda" ></asp:Label>
                    </div>
                </td>
                </tr>
                </table>                                                          
                </center></td>
                </tr>
                
            </table>            
        </fieldset>
    
    </td>
    </tr>
    </table>
    </tr>
    </table>
    </center>
    <iframe id="ifrllamar" style="visibility:hidden;"></iframe>        
    
    <asp:Panel ID="pnlInformacionAdicional" runat="server" Visible="false">
        <div style="top:200px; left:200px; z-index:10; background-color:White; border:1px solid; position:absolute;text-align:-moz-right; border-radius: 4px;">    
            <table>
                <tr>
                    <td>
                        INFORMACION ADICIONAL DE: <asp:Label ID="Label18" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <uc1:CtlGrilla ID="gvInformacionAdicional" runat="server" Activa_ckeck="false" Activa_Export="true"  Activa_option="false" Desactiva_Boton="false" Activa_Titulo="false" Largo="165px" Ancho="500px"  Activa_Delete="false" Activa_Edita="false" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="btnCarrarInformacionAdicional" runat="server" Text="Cerrar" />
                    </td>
                </tr>
            </table>
        </div>
    </asp:Panel>
    
    <asp:Panel ID="pnlAnotaciones" runat="server" Visible="false">
        <div style="top:200px; left:200px; z-index:10; background-color:White; border:1px solid; position:absolute;text-align:-moz-right; border-radius: 4px;">    
            <asp:Label ID="lblIndexAnotacion" runat="server" Visible="false"></asp:Label>
            <table>
                <tr>
                    <td>
                        ANOTACION
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="txtAnotacionNueva" runat="server" Width="200px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="btnAceptarAnotacion" runat="server" Text="Aceptar" />
                        <asp:Button ID="btnCancelarAnotacion" runat="server" Text="Cancelar" />
                    </td>                    
                </tr>
            </table>
        </div>
    </asp:Panel>
    
    <asp:Panel ID="pnlPagos" runat="server" Visible="false">
        <div style="top:200px; left:200px; z-index:4; background-color:White; border:1px solid; position:absolute;text-align:-moz-right; border-radius: 4px;">    
            <table>
                <tr>
                    <td>
                        <asp:Label ID="lblIdClientePagos" runat="server" Visible="false"></asp:Label>
                        CONSULTA DE PAGOS - CARTERA <asp:Label ID="lblTiposCartera" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>    
                    <td>
                        <table>
                            <tr>
                                <td>
                                    DNI
                                    <br />
                                    <asp:TextBox ID="txtDNIPagos" runat="server"></asp:TextBox>
                                </td>
                                <td>
                                    CLIENTE
                                    <br />
                                    <asp:TextBox ID="txtClientePagos" runat="server"></asp:TextBox>
                                </td>
                                <td>
                                    FECHA INICIO
			                        <br />
                                    <asp:TextBox ID="txtFechaInicioPagos" runat="server"  Width="80px" Enabled = "false" BackColor="White"/>
                                    <img ID="txtFechaInicio1" alt="calendario" height="16"  onclick="return showCalendar('txtFechaInicio1','<%=txtFechaInicioPagos.ClientID%>','%d/%m/%Y','24', true);" 
                                        src="Imagenes/calendario.png" width="18" />	
                                </td>
                                <td>
                                    FECHA FIN
					                <br />
                                    <asp:TextBox ID="txtFechaFinPagos" runat="server"  Width="80px" Enabled = "false" BackColor="White"/>
                                    <img ID="txtFechaFin1" alt="calendario" height="16" onclick="return showCalendar('txtFechaFin1','<%=txtFechaFinPagos.ClientID%>','%d/%m/%Y','24', true);" 
                                        src="Imagenes/calendario.png" width="18" />
                                </td>
                                <td>
                                    CARTERA
                                    <br />
                                    <uc2:CtCombo ID="cboCarteraPagos" Longitud="100" Procedimiento="QRYCG002" runat="server" />                                   
                                </td>
                                <td>
                                    <div class="curvo" id="GrupoReporte" runat="server">
			                            <asp:ImageButton id="imgBuscarPagos" runat="server" Height="30px" 
                                            ImageUrl="imagenes/BotonGenerarReporte.jpg" Width="35px" />
					                    <br />
			                            <asp:Label id="Label17" runat="server" Font-Size="11px" Text="Buscar"></asp:Label>
					                </div>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td>
                        <uc1:CtlGrilla ID="gvConsultaPagos" runat="server" Activa_ckeck="false" Activa_Export="true"  Activa_option="false" Desactiva_Boton="false" Activa_Titulo="false" Largo="165px" Ancho="320px" Activa_Delete="true" Activa_Edita="true"/>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="btnCerrarPagos" runat="server" Text="Cerrar" />
                    </td>
                </tr>
            </table>
        </div>
    </asp:Panel>
    
    <asp:Panel ID="pnlCompromisos" runat="server" Visible="false">
        <div style="top:200px; left:200px; z-index:4; background-color:White; border:1px solid; position:absolute;text-align:-moz-right; border-radius: 4px;">    
            <table>
                <tr>
                    <td>
                        COMPROMISOS  DE <asp:Label ID="lblCompromisos" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <uc1:CtlGrilla ID="gvCompromisos" runat="server" Activa_ckeck="false" Activa_Export="true"  Activa_option="false" Desactiva_Boton="false" Activa_Titulo="false" Largo="165px" Ancho="320px" Activa_Delete="true" Activa_Edita="true" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="btnCerrarCompromisos" runat="server" Text="Cerrar" />
                    </td>
                </tr>
            </table>
        </div>
    </asp:Panel>
    
    <asp:Panel ID="pnlMantenimientoDireccion" runat="server" Visible="false">
        <div style="top:200px; left:200px; z-index:4; background-color:White; border:1px solid; position:absolute;text-align:-moz-right; border-radius: 4px;">    
            <asp:Label ID="lblId_Direccion_Activa" runat="server" Visible="false"></asp:Label>
            <asp:Label ID="lblTipo_Mantenimiento_Direccion" runat="server" Visible="false"></asp:Label>
            <table>
                <tr>
                    <td colspan="2">
                        DIRECCION
                    </td>
                </tr>
                <tr>
                    <td>
                        DEPARTAMENTO
                    </td>
                    <td>
                        <uc2:CtCombo ID="cboDepartamentoMantenimietoDireccion" runat="server" AutoPostBack="true" Procedimiento="QRYC009" Longitud="150" />
                    </td>
                </tr>
                <tr>
                    <td>
                        PROVINCIA
                    </td>
                    <td>
                        <uc2:CtCombo ID="cboProvinciaMantenimietoDireccion" runat="server" AutoPostBack="true" Procedimiento="QRYC010" Longitud="150"/>                  
                    </td>
                </tr>
                <tr>
                    <td>
                        DISTRITO
                    </td>
                    <td>
                        <uc2:CtCombo ID="cboDistritoMantenimientoDireccion" runat="server" Procedimiento="QRYC011" Longitud="150" />                              
                    </td>
                </tr>
                <tr>
                    <td>
                        TIPO
                    </td>
                    <td>
                        <uc2:CtCombo ID="cboTipoMantenimietoDireccion" runat="server" Procedimiento="SQL_N_GEST012" Condicion=":idtabla▓122" Longitud="150" />
                    </td>
                </tr>
                <tr>
                    <td>
                        DIRECCION
                    </td>
                    <td>
                        <asp:TextBox ID="txtDireccionMantenimietoDireccion" runat="server" Width="150px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="btnAceptarMantenimietoDireccion" runat="server" Text="Aceptar" />
                    </td>
                    <td>
                        <asp:Button ID="btnCancelarMantenimietoDireccion" runat="server" Text="Cancelar" />
                    </td>
                </tr>
            </table>
        </div>
    </asp:Panel>
    
    <asp:Panel ID="pnlCompromisoMantenimiento" runat="server" Visible="false">
            <asp:Label ID="lblId_Compromiso" runat="server" Visible="false"></asp:Label>
            <asp:Label ID="lblId_Gestion" runat="server" Visible="false"></asp:Label>
            <div style="top:200px; left:200px; z-index:5; background-color:White; border:1px solid; position:absolute;text-align:-moz-right; border-radius: 4px;">    
                <table>
                    <tr>
                        <td>
                            COMPROMISO
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Fecha Genero
                            <br />
                            <asp:TextBox ID="txtFechaGeneroCompromisoMantenieminto" runat="server"  Width="80px" Enabled = "false" BackColor="White"/>
                                    <img ID="imgFechaGeneroCOmpromisoMantenimiento" alt="calendario" height="16" onclick="return showCalendar('imgFechaGeneroCOmpromisoMantenimiento','<%=txtFechaGeneroCompromisoMantenieminto.ClientID%>','%d/%m/%Y','24', true);" 
                                        src="Imagenes/calendario.png" width="18" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Fecha Compromiso
                            <br />
                            <asp:TextBox ID="txtFechaCompromisoMantenimiento" runat="server"  Width="80px" Enabled = "false" BackColor="White"/>
                                    <img ID="imgFechaCOmpromisoMantenimeinto" alt="calendario" height="16" onclick="return showCalendar('imgFechaCOmpromisoMantenimeinto','<%=txtFechaCompromisoMantenimiento.ClientID%>','%d/%m/%Y','24', true);" 
                                        src="Imagenes/calendario.png" width="18" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Nro Operacion
                            <br />
                            <uc2:CtCombo ID="txtNroOperacionCompromisoManteniemito" Longitud="150" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table>
                                <tr>
                                    <td>
                                        MONTO
                                        <br />
                                        <asp:TextBox ID="txtMontoCompromisoMantenimiento" runat="server"></asp:TextBox>
                                    </td>
                                    <td>
                                        MONEDA
                                        <br />
                                        <uc2:CtCombo ID="cboMonedaCompromisoMantemiento" Longitud="100" Procedimiento="SQL_N_GEST012" runat="server" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Tipo Pago
                            <br />
                            <uc2:CtCombo ID="cboTipoPagoCompromisoMantenimiento" Longitud="100" Procedimiento="SQL_N_GEST012" runat="server" />
                        </td>                        
                    </tr>
                    <tr>
                        <td>
                            <table>
                                <tr>
                                    <td>
                                        <asp:CheckBox ID="chkPagadoCompromisoMantenimiento" runat="server" Text="Pagado" />
                                    </td>
                                    <td>
                                        Fecha Pago
                                        <br />
                                        <asp:TextBox ID="txtFechaPagoCompromisoMantenimeinto" runat="server"  Width="80px" Enabled = "false" BackColor="White"/>
                                        <img ID="imgFechaPagoCOmpromisoMantenimiento" alt="calendario" height="16" onclick="return showCalendar('imgFechaPagoCOmpromisoMantenimiento','<%=txtFechaPagoCompromisoMantenimeinto.ClientID%>','%d/%m/%Y','24', true);" 
                                            src="Imagenes/calendario.png" width="18" />
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
                                        Monto
                                        <br />
                                        <asp:TextBox ID="txtMontoCompromisoMantenimientoA" runat="server"></asp:TextBox>
                                    </td>
                                    <td>
                                        Moneda
                                        <br />
                                        <uc2:CtCombo ID="cboMonedaCompromisoMantenimiento" Longitud="100" Procedimiento="SQL_N_GEST012" runat="server" />
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
                                        <div class="curvo" id="Div3" runat="server">
			                            <asp:ImageButton id="imgGrabarCompromisoMantenimiento" runat="server" Height="30px" 
                                            ImageUrl="imagenes/BotonGenerarReporte.jpg" Width="35px" />
					                    <br />
			                            <asp:Label id="Label21" runat="server" Font-Size="11px" Text="Grabar"></asp:Label>
					                </div>
                                    </td>
                                    <td>
                                         <div class="curvo" id="Div4" runat="server">
			                            <asp:ImageButton id="imgCerrarCOmpromisoMantenimiento" runat="server" Height="30px" 
                                            ImageUrl="imagenes/BotonGenerarReporte.jpg" Width="35px" />
					                    <br />
			                            <asp:Label id="Label22" runat="server" Font-Size="11px" Text="Cerrar"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </div>
        </asp:Panel>
    
    <asp:Panel ID="pnlDeuda" runat="server" Visible="false">
        <div style="top:200px; left:200px; z-index:4; background-color:White; border:1px solid; position:absolute;text-align:-moz-right; border-radius: 4px;">    
            <table>
                <tr>
                    <td>
                        DEUDA DE CLIENTE DE <asp:Label ID="lblDeudaClienteTitulo" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <uc1:CtlGrilla ID="gvDeuda" runat="server" Activa_ckeck="false" Activa_Export="true"  Activa_option="false" Desactiva_Boton="false" Activa_Titulo="false" Largo="165px" Ancho="320px" Activa_Delete="false" Activa_Edita="false" With_Grilla="800px" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="btnCerrarDeuda" runat="server" Text="Cerrar" />
                    </td>
                </tr>
            </table>
        </div>
    </asp:Panel>
    
    <asp:Panel ID="pnlPropuesta" runat="server" Visible="false">
        <div style="top:200px; left:200px; z-index:4; background-color:White; border:1px solid; position:absolute;text-align:-moz-right; border-radius: 4px;">    
            <table>
                <tr>
                    <td>
                        CONSULTA DE PROPUESTA
                    </td>
                </tr>
                <tr>
                    <td>
                        <uc1:CtlGrilla ID="gvPropuesta" runat="server" Activa_ckeck="false" Activa_Export="true"  Activa_option="false" Desactiva_Boton="false" Activa_Titulo="false" Largo="165px" Ancho="320px" Activa_Delete="false" Activa_Edita="true" OpocionNuevo="true" With_Grilla="1000px" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="btnCerrarPropuesta" runat="server" Text="Cerrar" />
                    </td>
                </tr>
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
                                        <uc2:CtCombo ID="cboEstadoPropuesta" Longitud="100" runat="server"  Procedimiento="SQL_N_GEST012" Condicion=":idtabla▓117"/>
                                    </td>
                                    <td>
                                        <div class="curvo" id="Div1" runat="server">
			                                <asp:ImageButton id="imgGrabarPropuesta" runat="server" Height="30px" 
                                                ImageUrl="imagenes/boton busqueda.jpg" Width="45px" />
                                                <br />
					                        <asp:Label id="Label19" runat="server" Font-Size="11px" Text="Grabar"></asp:Label>
					                    </div>
                                    </td>
                                    <td>
                                        <div class="curvo" id="Div2" runat="server">
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
                                        <uc2:CtCombo ID="cboOperacionPropuesta" Longitud="100" runat="server" />
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
                                        <uc2:CtCombo ID="cboMonedaPropuesta" Longitud="100" runat="server" Procedimiento="SQL_N_GEST006" Condicion=":idtabla▓105" />
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
                                                    <uc2:CtCombo ID="cboMonedaPropuestaMantenimeinto" Longitud="100" runat="server"  Procedimiento="SQL_N_GEST006" Condicion=":idtabla▓105" />
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
    
    
    <asp:Panel ID="pnlMantenimeintoTelefono" runat="server" Visible="false">
    <div style="top:200px; left:200px; z-index:4; background-color:White; border:1px solid; position:absolute;text-align:-moz-right; border-radius: 4px;">    
        <asp:Label ID="lblTipoTelefonoMantenieminto" runat="server" Visible="false"></asp:Label>
        <asp:Label ID="lblNumero_Activo" runat="server" Visible="false"></asp:Label>
        <table>
            <tr>
                <td style=" text-align:center;" colspan="2">
                    TELEFONO
                </td>
            </tr>
            <tr>
                <td>
                    NUMERO
                </td>
                <td>
                    <asp:TextBox ID="txtNumeroTelefono" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    CONTACTO
                </td>
                <td>
                    <uc2:CtCombo ID="cboContactoTelefono" Longitud="122" runat="server" Procedimiento="SQL_N_GEST006" Condicion=":idtabla▓121" />
                </td>
            </tr>
            <tr>
                <td>
                    ORIGEN
                </td>
                <td>
                    <asp:TextBox ID="txtOrigenTelefono" runat="server" ></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    VIA TELEFONO
                </td>
                <td>
                    <uc2:CtCombo ID="cboViaTelefono" Longitud="122" runat="server" Procedimiento="SQL_N_GEST012" Condicion=":idtabla▓122" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="btnAceptarTelefono" runat="server" Text="Aceptar" />
                </td>
                <td>
                    <asp:Button ID="btnCancelaTelefono" runat="server" Text="Cancelar" />
                </td>
            </tr>
        </table>
    </div>
    </asp:Panel>
    
    <uc6:CtlMensajes ID="CtlMensajes1" runat="server" />
    </ContentTemplate>
    
    
    
    </asp:UpdatePanel>
    <asp:UpdateProgress ID="UpdateProgress1" runat="server">
    </asp:UpdateProgress>
    
    
    
    
    
    
    
    
    
    </form>
</body>
</html>
