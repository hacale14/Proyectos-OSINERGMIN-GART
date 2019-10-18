<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Gestion_Predictiva.aspx.vb" Inherits="Cobranza.Gestion_Predictiva" %>
<%@ Register src="Controles/CtCombo.ascx" tagname="CtCombo" tagprefix="uc2" %>
<%@ Register src="Controles/CtlTxt.ascx" tagname="CtlTxt" tagprefix="uc3" %>
<%@ Register src="Controles/CtlCboCartera.ascx" tagname="CtlCboCartera" tagprefix="uc4" %>
<%@ Register src="Controles/CtlLlamando.ascx" tagname="CtlLlamando" tagprefix="uc5" %>
<%@ Register src="Controles/CtlGrilla.ascx" tagname="CtlGrilla" tagprefix="uc1" %>
<%@ Register src="Controles/CtlMensajes.ascx" tagname="CtlMensajes" tagprefix="uc6" %>
<%@ Register src="Controles/ctlConsulta.ascx" tagname="ctlConsulta" tagprefix="uc7" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<html>
<head id="Head1" runat="server">
    <title>Administracion de la gestion del cliente</title>
    <link rel="icon" type="image/x-icon" href="images/logo.ico"/> 

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
	var panel = document.getElementById('pnlCCMensaje');
    panel.style.visibility = 'hidden';
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
 
    <script src="scripts/ckeditor.js" type="text/javascript"></script>    
    <script src="scripts/gridview.js" type="text/javascript"></script>    
    <script type="text/javascript" src="scripts/scriptsSistema.js" charset="iso-8859-1"></script>
    <script type="text/javascript" src="scripts/prototype.js"></script>
    <script type="text/javascript" src="scripts/calendar.js"></script>
    <script type="text/javascript" src="scripts/calendar-utils.js"></script>
    <script type="text/javascript" src="scripts/calendar-es.js"></script>   
    <script type="text/javascript" src="jquery.min.js"></script>     
    <script type="text/javascript" src="jquery-ui.min.js"></script> 
    <script type="text/javascript" src="gridviewScroll.min.js"></script>
    <script src="js/jquery-1.4.2.min.js" type="text/javascript"></script>
    <script src="js/jquery.timers.js" type="text/javascript"></script>

    <link rel="stylesheet" href="jqwidgets/styles/jqx.base.css" type="text/css" />
    <script type="text/javascript" src="scripts/jquery-1.11.1.min.js"></script>
    <script type="text/javascript" src="jqwidgets/jqxcore.js"></script>
    <script type="text/javascript" src="jqwidgets/jqxnotification.js"></script>
    <script type="text/javascript" src="jqwidgets/jqxbuttons.js"></script>
    <script type="text/javascript" src="jqwidgets/jqxexpander.js"></script>
    <script type="text/javascript" src="jqwidgets/jqxradiobutton.js"></script>
    <script type="text/javascript" src="jqwidgets/jqxscrollbar.js"></script>
    <script type="text/javascript" src="jqwidgets/jqxlistbox.js"></script>
    <script type="text/javascript" src="jqwidgets/jqxdropdownlist.js"></script>
    <script type="text/javascript" src="jqwidgets/jqxcheckbox.js"></script>
    <script type="text/javascript" src="scripts/demos.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#jqxNotification").jqxNotification({ width: "auto", position: "top-right", opacity: 0.9,
                autoOpen: false, closeOnClick: true, autoClose: true, template: "info", blink: false,
                icon: { width: 25, height: 25, url: '../../images/smiley.png', padding: 5 }
            });

            $("#openNotification, #closeLastNotification, #closeNotifications").jqxButton({ width: 150 });
            $("#settingsExpander").jqxExpander({ width: 200, height: 385, toggleMode: "none", showArrow: false });

            $("#topLeft, #bottomLeft, #bottomRight").jqxRadioButton({ checked: false, groupName: "position" });
            $("#topRight").jqxRadioButton({ checked: true, groupName: "position" });

            $("#templateDropDownList").jqxDropDownList({ source: ["info", "warning", "success", "error", "mail", "time", "null"], selectedIndex: 0, width: "100%", height: 25, autoDropDownHeight: true });

            $("#closeOnClickCheckbox, #autoCloseCheckBox").jqxCheckBox({ checked: true });
            $("#blinkCheckbox").jqxCheckBox({ checked: false });

            $("#openNotification").click(function () {
                $("#jqxNotification").jqxNotification("open");
            });
            $("#closeLastNotification").click(function () {
                $("#jqxNotification").jqxNotification("closeLast");
            });
            $("#closeNotifications").click(function () {
                $("#jqxNotification").jqxNotification("closeAll");
            });

            $("#topLeft").on("checked", function (event) {
                $("#jqxNotification").jqxNotification({ position: "top-left" });
            });
            $("#topRight").on("checked", function (event) {
                $("#jqxNotification").jqxNotification({ position: "top-right" });
            });
            $("#bottomLeft").on("checked", function (event) {
                $("#jqxNotification").jqxNotification({ position: "bottom-left" });
            });
            $("#bottomRight").on("checked", function (event) {
                $("#jqxNotification").jqxNotification({ position: "bottom-right" });
            });

            $("#templateDropDownList").on("change", function (event) {
                var choice = event.args.item.label;
                var newTemplate;
                if (choice != "null") {
                    newTemplate = choice;
                } else {
                    newTemplate = null;
                }
                $("#jqxNotification").jqxNotification({ template: newTemplate });
            });

            $("#closeOnClickCheckbox").on("change", function (event) {
                var checked = event.args.checked;
                $("#jqxNotification").jqxNotification({ closeOnClick: checked });
            });
            $("#autoCloseCheckBox").on("change", function (event) {
                var checked = event.args.checked;
                $("#jqxNotification").jqxNotification({ autoClose: checked });
            });
            $("#blinkCheckbox").on("change", function (event) {
                var checked = event.args.checked;
                $("#jqxNotification").jqxNotification({ blink: checked });
            });
        });
	</script>

    
    <script type="text/javascript"        
       // src="https://www.google.com/jsapi?autoload={'modules':[{'name':'visualization','version':'1','packages':['gauge']}]}">
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
        function LlamarTelefono(anexo,mensaje,strid,objimg){       	
		document.getElementById('NumTelf').value = mensaje;
		if (anexo.toString != ' ')  {
		    //alert('Se llamara al numero : ' + document.getElementById('NumTelf').value + ' del anexo: ' + anexo);
		    document.getElementById('HoraClick').value = '<%=Now()%>';		    
		    //alert(document.getElementById('HoraClick').value);			
			
            document.getElementById('ifrllamar').src = 'http://192.168.1.20/llamar.php?anexo=' + anexo + '&telefono=' + mensaje + '&idcliente=' + strid ;        
            // __doPostBack("ActivarRDB", "");            
        }
        else
        {
            //-------------------
            alert('El usuario no tiene anexo relacionado favor consulte con su administrador');
        }
        //alert('Se esta llamando al numero : ' + document.getElementById('NumTelf').value + ' del anexo: ' + anexo);
        }
        function cerrarpanel()
        {
            document.getElementById('pnlmarcatelf').style.visibility = "hidden";
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
        
       function Desactivabtn(btnID) {            
                btn.disabled = true;                
        }   
        function Activar(btnID) {            
                btn.disabled = false;                
        }        
    </script>
    <script type="text/javascript">
          function close_window() {
  if (confirm("Close Window?")) {
    close();
  }
}
            
</script>
 <style  type="text/css">
        .loading {
  position: fixed;
  z-index: 999;
  height: 2em;
  width: 2em;
  overflow: show;
  margin: auto;
  top: 0;
  left: 0;
  bottom: 0;
  right: 0;
}

/* Transparent Overlay */
.loading:before {
  content: '';
  display: block;
  position: fixed;
  top: 0;
  left: 0;
  width: 100%;
  height: 100%;
  background-color: rgba(0,0,0,0.3);
}

/* :not(:required) hides these rules from IE9 and below */
.loading:not(:required) {
  /* hide "loading..." text */
  font: 0/0 a;
  color: transparent;
  text-shadow: none;
  background-color: transparent;
  border: 0;
}

.loading:not(:required):after {
  content: '';
  display: block;
  font-size: 10px;
  width: 1em;
  height: 1em;
  margin-top: -0.5em;
  -webkit-animation: spinner 1500ms infinite linear;
  -moz-animation: spinner 1500ms infinite linear;
  -ms-animation: spinner 1500ms infinite linear;
  -o-animation: spinner 1500ms infinite linear;
  animation: spinner 1500ms infinite linear;
  border-radius: 0.5em;
  -webkit-box-shadow: rgba(0, 0, 0, 0.75) 1.5em 0 0 0, rgba(0, 0, 0, 0.75) 1.1em 1.1em 0 0, rgba(0, 0, 0, 0.75) 0 1.5em 0 0, rgba(0, 0, 0, 0.75) -1.1em 1.1em 0 0, rgba(0, 0, 0, 0.5) -1.5em 0 0 0, rgba(0, 0, 0, 0.5) -1.1em -1.1em 0 0, rgba(0, 0, 0, 0.75) 0 -1.5em 0 0, rgba(0, 0, 0, 0.75) 1.1em -1.1em 0 0;
  box-shadow: rgba(0, 0, 0, 0.75) 1.5em 0 0 0, rgba(0, 0, 0, 0.75) 1.1em 1.1em 0 0, rgba(0, 0, 0, 0.75) 0 1.5em 0 0, rgba(0, 0, 0, 0.75) -1.1em 1.1em 0 0, rgba(0, 0, 0, 0.75) -1.5em 0 0 0, rgba(0, 0, 0, 0.75) -1.1em -1.1em 0 0, rgba(0, 0, 0, 0.75) 0 -1.5em 0 0, rgba(0, 0, 0, 0.75) 1.1em -1.1em 0 0;
}

/* Animation */

@-webkit-keyframes spinner {
  0% {
    -webkit-transform: rotate(0deg);
    -moz-transform: rotate(0deg);
    -ms-transform: rotate(0deg);
    -o-transform: rotate(0deg);
    transform: rotate(0deg);
  }
  100% {
    -webkit-transform: rotate(360deg);
    -moz-transform: rotate(360deg);
    -ms-transform: rotate(360deg);
    -o-transform: rotate(360deg);
    transform: rotate(360deg);
  }
}
@-moz-keyframes spinner {
  0% {
    -webkit-transform: rotate(0deg);
    -moz-transform: rotate(0deg);
    -ms-transform: rotate(0deg);
    -o-transform: rotate(0deg);
    transform: rotate(0deg);
  }
  100% {
    -webkit-transform: rotate(360deg);
    -moz-transform: rotate(360deg);
    -ms-transform: rotate(360deg);
    -o-transform: rotate(360deg);
    transform: rotate(360deg);
  }
}
@-o-keyframes spinner {
  0% {
    -webkit-transform: rotate(0deg);
    -moz-transform: rotate(0deg);
    -ms-transform: rotate(0deg);
    -o-transform: rotate(0deg);
    transform: rotate(0deg);
  }
  100% {
    -webkit-transform: rotate(360deg);
    -moz-transform: rotate(360deg);
    -ms-transform: rotate(360deg);
    -o-transform: rotate(360deg);
    transform: rotate(360deg);
  }
}
@keyframes spinner {
  0% {
    -webkit-transform: rotate(0deg);
    -moz-transform: rotate(0deg);
    -ms-transform: rotate(0deg);
    -o-transform: rotate(0deg);
    transform: rotate(0deg);
  }
  100% {
    -webkit-transform: rotate(360deg);
    -moz-transform: rotate(360deg);
    -ms-transform: rotate(360deg);
    -o-transform: rotate(360deg);
    transform: rotate(360deg);
  }
} 
</style>

    
</head>

<body style="margin:0; padding:0;" bgcolor="#000116">    
    <form id="form1" runat="server">
    <asp:hiddenfield id="HiidMensaje" value="" runat="server"/>
    <asp:hiddenfield id="Hidusuario" value="" runat="server"/>
    <asp:hiddenfield id="Husuario" value="" runat="server"/>
    <asp:hiddenfield id="Hclave" value="" runat="server"/>
    <asp:hiddenfield id="Hcargo" value="" runat="server"/>
    <asp:hiddenfield id="HNombreGestor" value="" runat="server"/>
    <asp:hiddenfield id="HTipoUsuario" value="" runat="server"/>
    <asp:hiddenfield id="HidPerfil" value="" runat="server"/>    
    <asp:hiddenfield id="Hidgestion" value="" runat="server"/>
    <asp:hiddenfield id="Hidcliente" value="" runat="server"/>            
    
    <asp:hiddenfield id="NumTelf" value="" runat="server"/>
    <asp:hiddenfield id="HoraClick" value="" runat="server"/>    
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" EnablePartialRendering="true">
    </asp:ScriptManager>
    <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1" DisplayAfter="1">
	<ProgressTemplate>
         <div class="loading"></div>
    </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
      <ContentTemplate>  
  <Triggers>       
        <asp:PostBackTrigger ControlID="ImageButton4" />       
        <asp:PostBackTrigger ControlID="imgCerrarPropuesta" />                
        <asp:PostBackTrigger ControlID="imgBuscarPagos" />
        <asp:PostBackTrigger ControlID="ImageButton1" />
        <asp:PostBackTrigger ControlID="ImageButton2" />
        <asp:PostBackTrigger ControlID="imgBuscar" />
        <asp:PostBackTrigger ControlID="CtlTelefono" />
        <asp:PostBackTrigger ControlID="CtlDireccion" />
        <asp:PostBackTrigger ControlID="CtlAnotaciones" />
        <asp:PostBackTrigger ControlID="CtlEstadistica" />                
        <asp:PostBackTrigger ControlID="CtlGestionTelefonica" />
        <asp:PostBackTrigger ControlID="CtlGestionCampo" />
        <asp:PostBackTrigger ControlID="btnCompromisos" />
        <asp:PostBackTrigger ControlID="btnInfAdd" />
        <asp:PostBackTrigger ControlID="btnDeuda" />
        <asp:PostBackTrigger ControlID="gvInformacionAdicional" />
        <asp:PostBackTrigger ControlID="btnCarrarInformacionAdicional" />
        <asp:PostBackTrigger ControlID="btnAceptarAnotacion" />
        <asp:PostBackTrigger ControlID="btnCancelarAnotacion" />
        <asp:PostBackTrigger ControlID="imgBuscarPagos" />
        <asp:PostBackTrigger ControlID="gvConsultaPagos" />
        <asp:PostBackTrigger ControlID="btnCerrarPagos" />
        <asp:PostBackTrigger ControlID="gvCompromisos" />
        <asp:PostBackTrigger ControlID="btnCerrarCompromisos" />
        <asp:PostBackTrigger ControlID="cboDepartamentoMantenimietoDireccion" />
        <asp:PostBackTrigger ControlID="cboProvinciaMantenimietoDireccion" />
        <asp:PostBackTrigger ControlID="btnAceptarMantenimietoDireccion" />
        <asp:PostBackTrigger ControlID="btnCancelarMantenimietoDireccion" />
        <asp:PostBackTrigger ControlID="imgCerrarCOmpromisoMantenimiento" />
        <asp:PostBackTrigger ControlID="imgGrabarCompromisoMantenimiento" />
        <asp:PostBackTrigger ControlID="gvDeuda" />
        <asp:PostBackTrigger ControlID="btnCerrarDeuda" />
        <asp:PostBackTrigger ControlID="gvPropuesta" />
        <asp:PostBackTrigger ControlID="btnCerrarPropuesta" />
        <asp:PostBackTrigger ControlID="imgGrabarPropuesta" />
    </Triggers>
    
                
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
        <td colspan=2>
            <table width="100%">
                <tr>
                    <td width="30%" align="right" ><bold><font color="blue"><asp:Label id="lblGestor" runat="server" Font-Size="14px" BackColor="#E2E2E2" Text=""/></font></bold></td>
                    <td width="30%" align="center"><bold><font color="red"><center><asp:Label id="lblAnexo" runat="server" Font-Size="14px" BackColor="#E2E2E2" Text=""/> </center></font></bold></td>
                    <td width="40%" align="left"><bold><font color="blue"><asp:Label id="lblUuario" runat="server" Font-Size="14px" BackColor="#E2E2E2" Text=""/></font></bold></td>
                </tr>
            </table>
        </td>        
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
                <uc1:CtlGrilla ID="CtlTelefono" runat="server" Activa_ckeck="false" Activa_option="false" Desactiva_Boton="false" Activa_Titulo="false" Largo="165px" With_Grilla="320px" Activa_Delete="false" OcultarColumnas="4;5;6;8;9;10;11;13;14;16;17    " Desactivar_Exportar="0;1;2;3;4" Activa_Edita="true" OpocionNuevo="true" />
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
                    <td rowspan=2 valign="middle"><center><div class="curvop"><asp:ImageButton id="ImageButton4" onclick="btnOne_Click" runat="server" Height="32px" Width="32px" ImageUrl="~/imagenes/Save.png" ToolTip="Guardar Gestion"/><asp:Label id="Label12" runat="server" Font-Size="2px" Text="" ToolTip="Guardar Gestion"></asp:Label></div></center> </td>
                     
                    <tr>
                    <td><uc2:CtCombo Color="#F9F496" ID="CboGestion" Longitud="120" runat="server" /></td>
                    <td><uc2:CtCombo Color="#F9F496" ID="cboIndicador" Longitud="200" runat="server" /></td>
                    <td><uc3:CtlTxt Color="#F9F496"  ID="txtGestion" runat="server" Ancho="370" Maximo="150" />
                        <asp:Button ID="btnProximaAccion" runat="server" Text="Agenda" BackColor=Red ForeColor=white />
                        </td>                                        
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
        <div onmousedown="conecta(this);" id="dvInfAdic" style="top:20px; left:200px; z-index:10; background-color:White; border:1px solid; position:absolute;text-align:-moz-right; border-radius: 4px;">    
            <table style="background:#CED1D7;">
                <tr>
                    <td style="background:#2E4172;color:White; ">
                        INFORMACION ADICIONAL DE: <asp:Label ID="Label18" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <uc1:CtlGrilla ID="gvInformacionAdicional" runat="server" Activa_ckeck="false" Activa_Export="true"  Activa_option="false" Desactiva_Boton="false" Activa_Titulo="false" Largo="500px" Ancho="800px"  Activa_Delete="false" Activa_Edita="false" />
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
        <div onmousedown="conecta(this);" id="dvAnotac" style="top:200px; left:200px; z-index:10; background-color:White; border:1px solid; position:absolute;text-align:-moz-right; border-radius: 4px;">    
            <asp:Label ID="lblIndexAnotacion" runat="server" Visible="false"></asp:Label>
            <table style="background:#CED1D7;">
                <tr>
                    <td style="background:#2E4172;color:White; ">
                        ANOTACION
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="txtAnotacionNueva" runat="server" Width="400px" MaxLength="150" ></asp:TextBox>
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
    <div id="pnlCCMensaje" style="visibility:hidden;">
        <div onmousedown="conecta(this);" id="dvdCCMensaje" style="color:black; border-radius:5px;box-shadow: 2px 2px 3px #999; background: rgba(232,232,232,1);
background: -moz-linear-gradient(left, rgba(232,232,232,1) 0%, rgba(255,255,255,1) 0%, rgba(224,224,224,1) 50%, rgba(214,214,214,1) 100%);
background: -webkit-gradient(left top, right top, color-stop(0%, rgba(232,232,232,1)), color-stop(0%, rgba(255,255,255,1)), color-stop(50%, rgba(224,224,224,1)), color-stop(100%, rgba(214,214,214,1)));
background: -webkit-linear-gradient(left, rgba(232,232,232,1) 0%, rgba(255,255,255,1) 0%, rgba(224,224,224,1) 50%, rgba(214,214,214,1) 100%);
background: -o-linear-gradient(left, rgba(232,232,232,1) 0%, rgba(255,255,255,1) 0%, rgba(224,224,224,1) 50%, rgba(214,214,214,1) 100%);
background: -ms-linear-gradient(left, rgba(232,232,232,1) 0%, rgba(255,255,255,1) 0%, rgba(224,224,224,1) 50%, rgba(214,214,214,1) 100%);
background: linear-gradient(to right, rgba(232,232,232,1) 0%, rgba(255,255,255,1) 0%, rgba(224,224,224,1) 50%, rgba(214,214,214,1) 100%);            
            top:20px; left:400px; z-index:10; background-color:White; position:absolute;">    
            <asp:Label ID="lblCCidMensajes" runat="server" Visible="false"></asp:Label>
            <table style="border-radius:5px;box-shadow: 2px 2px 3px #999;">
                <tr>
                    <td style="background-color:#ff6600; bold:true; color: #FFFFFF; font-family: 'Arial Narrow'; font-size: 2em;">
                        <bold><center>Area de Monitoreo y Calidad de Gestion</center></bold>
                    </td>
                </tr>
				<tr>
                    <td><center>
					 <img id="imgUrl" src="Imagenes/BotonModificar.png" alt="Smiley face" style="width:55px; height:40px;" >                     
					 </center>
                    </td>
                </tr>
                <tr>
                    <td>
                        <textarea name="message" id="txtCCMensaje" rows="5" cols="1" style="background: transparent;  color: black;  resize: none;  border: 0 none;  font-size: 1.2em;  outline: none; 
  width:400px;text-align:center;vertical-align:middle;"></textarea>                        
                    </td>
                </tr>
                <tr>
                    <td>
                        <input type="button" value="Aceptar" onclick="grabarm()" style="background-color:#ff6600; color: #FFFFFF; font-family: 'Arial Narrow'; font-size: small;"/>
                        <input type="button" value="Cancelar" onclick="desactMsg()" style="background-color:#ff6600; color: #FFFFFF; font-family: 'Arial Narrow'; font-size: small;"/>
                        <A id="url" class="link" visible="false" style="font-family: 'Arial Narrow'; font-size: small;">Dar click aqui para ver ficha de su evaluacion</A>
                    </td>                    
                </tr>
            </table>
        </div>
    </div>
    
	<script type="text/javascript" >
	var panel = document.getElementById('pnlCCMensaje');
    panel.style.visibility = 'hidden';		
        function bigImg(x) {
            x.style.height = "64px";
            x.style.width = "64px";
        }    
        function desactMsg(){
            var panel = document.getElementById('pnlCCMensaje');
            panel.style.visibility = 'hidden';			
            var objurl = document.getElementById('url');
            objurl.style.visibility = 'hidden';
			
        }
        function grabarm(){       
            desactMsg();
            PageMethods.GrabarMensaje(document.getElementById('HiidMensaje').value,function (resul) {
                            return true;
                        },
                        function () {
                            return false;
                        });            
        }                                
        setInterval(function(){
                        PageMethods.GetUploadStatus(function(result){
                        if(result!=''){
							var ghi;
                            var res = result.toString();
                            var pos = res.indexOf('FELICITACIONES');							
							var ghi = res;
							if (pos==-1){
								pos = res.indexOf('COACHING');		
								ghi = res.substring(6,7) + res.substring(7,200).toLowerCase().trim().replace('ruta','');
								}
							else
							{
								ghi = res.substring(5,7) + res.substring(7,200).toLowerCase().trim();
							}										
                            if (pos>1){								
                                var pos = res.toUpperCase().indexOf('RUTA');
								var url = res.substring(pos+5,2000);
								if (pos==-1){
									var pos = res.toUpperCase().indexOf('RUTA');							
									var url = res.substring(pos+5,2000);
								}                                
                                var nomwin = 'openwind';                          								
								ghi= ghi.replace('¡¡','¡').replace('!!','!');
								var posi = ghi.indexOf('!');
								if (posi!=-1){
									ghi = ghi.substring(1,posi+1).toUpperCase() + ghi.substring(posi+1,200).toLowerCase();
									var pos = ghi.indexOf('ruta');
									ghi = ghi.substring(0,pos-2);
								}								
								document.getElementById("txtCCMensaje").innerHTML= ghi;
                                var panel = document.getElementById('pnlCCMensaje');
                                panel.style.visibility = 'visible';
                                panel.style.display='true';                                
                                document.getElementById('HiidMensaje').value=res.substring(0,res.indexOf(')',1)).replace('(','').trim();                                
								var a = document.getElementById('url');
                                a.style.visibility='visible';
                                a.style.display='true'; 
								document.getElementById('imgUrl').src='Imagenes/excenlente.png';
								a.href="javascript:window.open('"+url.trim()+"','winopn');"
                                $("a.link").on("click",function(){
                                     window.open(url.trim(),'winopn');
                                 });                                
                            }
                            else{
                                var panel = document.getElementById('pnlCCMensaje');
                                panel.style.visibility = 'visible';
                                panel.style.display='true';
                                var a = document.getElementById('url');
                                a.style.visibility='hidden';
                                a.style.display='true';
								document.getElementById('imgUrl').src='Imagenes/mejorar.png';
								document.getElementById('imgUrl').style.width = "150px";
								document.getElementById('imgUrl').style.height = "100px";																								
								var ghi= res.replace('¡¡','¡').replace('!!','!');								
								var posi = ghi.indexOf('!');
								if (posi!=-1){									
									ghi = ghi.substring(6,posi+1) + ghi.substring(posi+1,200).toLowerCase();
									}
								else{
									ghi = res.substring(6,7) + res.substring(7,200).toLowerCase();
								}																							
                                document.getElementById("txtCCMensaje").innerHTML=ghi;								
                                document.getElementById('HiidMensaje').value=res.substring(0,res.indexOf(')',1)).replace('(','');                                
                            }
                        }
                    })
        ;}, 10000);
    </script>    
			
	<asp:Panel ID="PnlProximaAccion" runat="server" Visible="false">
        <div onmousedown="conecta(this);" id="Div7" style="top:400px; left:400px; z-index:4; background-color:White; border:1px solid; position:absolute;text-align:-moz-right; border-radius: 4px;">    
            <table style="background:#CED1D7;">
                <tr>
                    <td style="background:#2E4172;color:White;">
                        <asp:Label ID="Label29" runat="server" Visible="false"></asp:Label>
                        AGENDA <asp:Label ID="Label30" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>    
                    <td>
                        <table>
                            <tr>                                                                
                                <td>
                                    FECHA
			                        <br />
                                    <asp:TextBox ID="txtProximaAccion" runat="server"  Width="80px" Enabled = "false" BackColor="White"/>
                                    <img ID="Img3" alt="calendario" height="16"  onclick="return showCalendar('txtProximaAccion','<%=txtProximaAccion.ClientID%>','%d/%m/%Y','24', true);" 
                                        src="Imagenes/calendario.png" width="18" />	
                                    HORA: <uc2:CtCombo ID="CboHoraProxAcc" runat="server" Procedimiento="GES006" Longitud="50"/>    
                                    MINUTO: <uc2:CtCombo ID="CboMinutoProxAcc" runat="server" Procedimiento="GES005" Longitud="50" />    
                                </td>                                                                
                            </tr>
                            <tr>
                                <td>
                                    Anotacion 
                                    <br />
                                    <asp:TextBox ID="txtAnotacion" runat="server"  Enabled = "true" BackColor="#FFFFAA"  TextMode="SingleLine" Height="30px" Width="300px"  MaxLength="30"/>                        
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>                
                <tr>
                    <td>
                        <asp:Button ID="btnAceptarFP" runat="server" Text="Aceptar" />						
                        <asp:Button ID="btnCerrarFP" runat="server" Text="Cerrar" />						
                    </td>
                </tr>
            </table>
        </div>
    </asp:Panel>       
	<asp:Panel ID="PnlMensajeAlerta" runat="server" Visible="false">
        <div onmousedown="conecta(this);" id="Div8" style="top:400px; left:400px; z-index:4; background-color:White; border:1px solid; position:absolute;text-align:-moz-right; border-radius: 4px;">    
            <table style="background:#CED1D7;">
                <tr>
                    <td style="background:#2E4172;color:White;">
                        <asp:Label ID="Label31" runat="server" Visible="false"></asp:Label>
                        MENSAJE DE PROXIMA GESTION<asp:Label ID="Label32" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>    
                    <td>
                        <table>                            
                            <tr>
                                <td>
                                    Anotacion 
                                    <br />
                                    <asp:TextBox ID="txtAnotacionMensaje" runat="server"  Enabled = "true" BackColor="#FFBE8A" ReadOnly="false"  TextMode="MultiLine" Height="100px" Width="300px"/>                        
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>                
                <tr>
                    <td>
                        <asp:Button ID="BtnRedirect" runat="server" Text="Ir al Cliente"/>
                        <asp:Button ID="BtnPosponer" runat="server" Text="Posponer"/>
                        <asp:Button ID="BtnEliminar" runat="server" Text="Eliminar"/>
                    </td>
                </tr>
            </table>
        </div>
    </asp:Panel>       
	
    <asp:Panel ID="pnlPagos" runat="server" Visible="false">
        <div onmousedown="conecta(this);" id="dvPagos" style="top:200px; left:200px; z-index:4; background-color:White; border:1px solid; position:absolute;text-align:-moz-right; border-radius: 4px;">    
            <table style="background:#CED1D7;">
                <tr>
                    <td style="background:#2E4172;color:White;">
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
                        <uc1:CtlGrilla ID="gvConsultaPagos" runat="server" Activa_ckeck="false" Activa_Export="true"  Activa_option="false" Desactiva_Boton="false" Activa_Titulo="false" Largo="165px" Ancho="320px" Activa_Delete="true" Activa_Edita="true" OpocionNuevo="true"/>
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
        <div onmousedown="conecta(this);" id="dvComp" style="top:200px; left:100px; z-index:4; background-color:White; border:1px solid; position:absolute;text-align:-moz-right; border-radius: 4px;">    
            <table style="background:#CED1D7;">
                <tr>
                    <td style="background:#2E4172;color:White; ">COMPROMISOS  DE <asp:Label ID="lblCompromisos" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <uc1:CtlGrilla ID="gvCompromisos" runat="server" Activa_ckeck="false" Activa_Export="true"  Activa_option="false" Desactiva_Boton="false" Activa_Titulo="false" Largo="165px" Ancho="800px" Activa_Delete="true" Activa_Edita="true" />
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
        <div onmousedown="conecta(this);" id="dvMantDir" style="top:200px; left:200px; z-index:4; background-color:White; border:1px solid; position:absolute;text-align:-moz-right; border-radius: 4px;">    
            <asp:Label ID="lblId_Direccion_Activa" runat="server" Visible="false"></asp:Label>
            <asp:Label ID="lblTipo_Mantenimiento_Direccion" runat="server" Visible="false"></asp:Label>
            <table style="background:#CED1D7;">
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
                        TIPO DE DIRECCION
                    </td>
                    <td>
                        <uc2:CtCombo ID="cbotipoDireccion1" runat="server" Procedimiento="SQL_N_GEST012" Condicion=":idtabla▓122" Longitud="150" />
                    </td>
                </tr>
                <tr>
                    <td>
                        CONDICION DE VIVIENDA
                    </td>
                    <td>
                        <uc2:CtCombo ID="cboCondVivienda" runat="server" Procedimiento="SQL_N_GEST012" Condicion=":idtabla▓122" Longitud="150" />
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
    
    <asp:Panel ID="pnlPagosMantenimiento" runat="server" Visible="false">
            <asp:Label ID="Label24" runat="server" Visible="false"></asp:Label>
            <asp:Label ID="Label25" runat="server" Visible="false"></asp:Label>
            <div onmousedown="conecta(this);" id="dvPgiMant" style="top:200px; left:600px; z-index:5; background-color:White; border:1px solid; position:absolute;text-align:-moz-right; border-radius: 4px;">    
                <table style="background:#CED1D7;">
                    <tr>
                        <td style="background:#2E4172;color:White; " >
                            MANTENIMIENTO DE PAGOS
                        </td>
                    </tr>
                    <tr>
                        <td>
                            FECHA PAGO
                            <br />
                            <asp:TextBox ID="txtFechaPago" runat="server"  Width="80px" Enabled = "false" BackColor="White"/>
                                    <img ID="imgFechaPago" alt="calendario" height="16" onclick="return showCalendar('imgFechaPago','<%=txtFechaPago.ClientID%>','%d/%m/%Y','24', true);" 
                                        src="Imagenes/calendario.png" width="18" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            NRO OPERACION
                            <br />
                            <uc2:CtCombo ID="CboNroOperacioPago" Longitud="150" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            CONCEPTO DEL PAGO
                            <br />
                            <uc2:CtCombo ID="cboConceptoPago" Longitud="150" runat="server" Procedimiento="SQL_N_GEST012" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table>
                                <tr>
                                    <td>
                                        MONTO
                                        <br />
                                        <asp:TextBox ID="txtMontoPago" runat="server"></asp:TextBox>
                                    </td>
                                    <td>
                                        MONEDA
                                        <br />
                                        <uc2:CtCombo ID="CboMonedaPago" Longitud="100" Procedimiento="SQL_N_GEST012" runat="server" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>                                                          
                    <tr>
                        <td>
                        <center>
                            <table>
                                <tr>
                                    <td>
                                        <div class="curvo" id="Div5" runat="server">
			                            <asp:ImageButton id="ImgGrabraPago" runat="server" Height="30px" 
                                            ImageUrl="imagenes/BotonGrabar.png" Width="35px" />
					                    <br />
			                            <asp:Label id="Label26" runat="server" Font-Size="11px" Text="Grabar"></asp:Label>
					                </div>
                                    </td>
                                    <td>
                                         <div class="curvo" id="Div6" runat="server">
			                            <asp:ImageButton id="ImgCerrarPago" runat="server" Height="30px" 
                                            ImageUrl="imagenes/BotonCerrar.jpg" Width="35px" />
					                    <br />
			                            <asp:Label id="Label27" runat="server" Font-Size="11px" Text="Cerrar"></asp:Label>
			                            
                                    </td>
                                </tr>
                            </table>
                            </center>
                        </td>
                    </tr>
                </table>
            </div>
        </asp:Panel>
    
    
    <asp:Panel ID="pnlCompromisoMantenimiento" runat="server" Visible="false">
            <asp:Label ID="lblId_Compromiso" runat="server" Visible="false"></asp:Label>
            <asp:Label ID="lblId_Gestion" runat="server" Visible="false"></asp:Label>
            <div onmousedown="conecta(this);" id="dvCmpMant" style="top:200px; left:600px; z-index:5; background-color:White; border:1px solid; position:absolute;text-align:-moz-right; border-radius: 4px;">    
                <table style="background:#CED1D7;">
                    <tr>
                        <td style="background:#2E4172;color:White; " >
                            COMPROMISO
                        </td>
                    </tr>
                    <tr>
                        <td>
                            FECHA GENERO
                            <br />
                            <asp:TextBox ID="txtFechaGeneroCompromisoMantenieminto" runat="server"  AutoPostBack="true" Width="80px" Enabled = "false" BackColor="White"/>
                                    <img ID="imgFechaGeneroCOmpromisoMantenimiento" alt="calendario" height="16" onclick="return showCalendar('imgFechaGeneroCOmpromisoMantenimiento','<%=txtFechaGeneroCompromisoMantenieminto.ClientID%>','%d/%m/%Y','24', true);" 
                                        src="Imagenes/calendario.png" width="18" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            FECHA COMPROMISO
                            <br />
                            <asp:TextBox ID="txtFechaCompromisoMantenimiento" runat="server"  Width="80px" AutoPostBack="true" BackColor="White"/>
                                    <img ID="imgFechaCOmpromisoMantenimeinto" alt="calendario" height="16" onclick="return showCalendar('imgFechaCOmpromisoMantenimeinto','<%=txtFechaCompromisoMantenimiento.ClientID%>','%d/%m/%Y','24', true);" 
                                        src="Imagenes/calendario.png" width="18" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            NRO OPERACION
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
                            TIPO DE PAGO
                            <br />
                            <uc2:CtCombo ID="cboTipoPagoCompromisoMantenimiento" Longitud="100" Procedimiento="SQL_N_GEST012" runat="server" />
                        </td>                        
                    </tr>
                    <tr>
                        <td>
                            <table>
                                <tr>
                                    <td>
                                        <asp:CheckBox ID="chkPagadoCompromisoMantenimiento" runat="server" Text="Pagado" AutoPostBack="true" />
                                    </td>
                                    <td>
                                        FECHA PAGO
                                        <br />
                                        <asp:TextBox ID="txtFechaPagoCompromisoMantenimeinto" runat="server"  AutoPostBack="true" Width="80px" Enabled = "false" BackColor="White"/>
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
                                        MONTO
                                        <br />
                                        <asp:TextBox ID="txtMontoCompromisoMantenimientoA" runat="server"></asp:TextBox>
                                    </td>
                                    <td>
                                        MONEDA
                                        <br />
                                        <uc2:CtCombo ID="cboMonedaCompromisoMantenimientoA" Longitud="100" Procedimiento="SQL_N_GEST012" runat="server" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        <center>
                            <table>
                                <tr>
                                    <td>
                                        <div class="curvo" id="Div3" runat="server">
			                            <asp:ImageButton id="imgGrabarCompromisoMantenimiento" runat="server" Height="30px"  
                                            ImageUrl="imagenes/BotonGrabar.png" Width="35px" />
					                    <br />
			                            <asp:Label id="Label21" runat="server" Font-Size="11px" Text="Grabar"></asp:Label>
					                </div>
                                    </td>
                                    <td>
                                         <div class="curvo" id="Div4" runat="server">
			                            <asp:ImageButton id="imgCerrarCOmpromisoMantenimiento" runat="server" Height="30px" 
                                            ImageUrl="imagenes/BotonCerrar.jpg" Width="35px" />
					                    <br />
			                            <asp:Label id="Label22" runat="server" Font-Size="11px" Text="Cerrar"></asp:Label>
			                            
                                    </td>
                                </tr>
                            </table>
                            </center>
                        </td>
                    </tr>
                </table>
            </div>
        </asp:Panel>
    
    <asp:Panel ID="pnlDeuda" runat="server" Visible="false" >
        <div onmousedown="conecta(this);" id="dvDeuda" style="top:200px; left:100px;z-index:4; background-color:White; border:1px solid; position:absolute;text-align:-moz-right; border-radius: 4px;">    
            <table style="background:#CED1D7;">
                <tr>
                    <td style="background:#2E4172;color:White;">
                        DEUDA DE CLIENTE DE <asp:Label ID="lblDeudaClienteTitulo" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <uc1:CtlGrilla ID="gvDeuda" runat="server" Activa_ckeck="false" Activa_Export="true"  Activa_option="false" Desactiva_Boton="false" Activa_Titulo="false" Largo="165px" Ancho="1020px" Activa_Delete="false" Activa_Edita="false" With_Grilla="1020px" />
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
        <div onmousedown="conecta(this);" id="dvPropuesta" style="top:200px; left:200px; z-index:4; background-color:White; border:1px solid; position:absolute;text-align:-moz-right; border-radius: 4px;">    
            <table style="background:#CED1D7;"> 
                <tr>
                    <td style="background:#2E4172;color:White; ">
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
            <div onmousedown="conecta(this);" id="dvMantenimientoPropuesta" style="top:200px; left:200px; z-index:4; background-color:White; border:1px solid; position:absolute;text-align:-moz-right; border-radius: 4px;">    
                <asp:Label ID="lblId_Propuesta" runat="server" Visible="false"></asp:Label>
                <table style="background:#CED1D7;">
                    <tr>
                        <td style="background:#2E4172;color:White; ">
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
                                        <uc2:CtCombo ID="cboMonedaPropuesta" Longitud="100" runat="server" Procedimiento="SQL_N_GEST080" Condicion=":idtabla▓105" />
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
    <asp:Button ID="btnCerrarPantalla1" runat="server" Visible="false"></asp:Button>  
    
    <asp:Panel ID="pnlMantenimeintoTelefono" runat="server" Visible="false">
    <div onmousedown="conecta(this);" id="dvMantenimeintoTelefono" style="top:200px; left:200px; cursor:move; z-index:4; background-color:White; border:1px solid; position:absolute;text-align:-moz-right; border-radius: 4px;">    
        <asp:Label ID="lblTipoTelefonoMantenieminto" runat="server" Visible="false"></asp:Label>
        <asp:Label ID="lblNumero_Activo" runat="server" Visible="false"></asp:Label>
        <table style="background:#CED1D7;">
            <tr>
                <td style="background:#2E4172;color:White;text-align:center;" colspan="2">
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

    <asp:Panel ID="pnlmarcatelf" runat="server" Visible="false">    
    <div style="top:120px; left:90px; z-index:4; background-color:#FFFD8C; border:1px solid; position:absolute;text-align:-moz-right; border-radius: 4px;">            
    <fieldset style="margin:0; padding:0;height:60px; width:280px;background-color:#FFFD8C;">
		        <legend>
		            <asp:Label id="Label28" runat="server" Font-Size="11px" BackColor="#FFFD8C" Text=" Llamada en progreso "></asp:Label>
		        </legend>                
		        <center>
    <table>
   
        <tr>
        <td>
        <img ID="img2" style="width:40px;height:40px" src="Imagenes/numtelfani.gif" />
        </td>
        <td align="center">
        
        <asp:Label ID="lblNunmTelfC" style="background-color:#FFFD8C; font-size:xx-large;" runat="server" ></asp:Label>        
        
        </td>
        <td>
        <img ID="img1" style="width:40px;height:40px" onclick="cerrarpanel();" src="Imagenes/BotonEliminar.png"/>
        </td>
        </tr>
                
    </tr>
    
    </table>
    </center>
            </fieldset>    
    </div>
    </asp:Panel>


    
    <uc6:CtlMensajes ID="CtlMensajes1" runat="server" />
    </ContentTemplate>
    
    
    
    </asp:UpdatePanel>
    
    
      <script>
		var selectedmov = null, // Object of the element to be moved
		x_pos = 0, y_pos = 0, // Stores x & y coordinates of the mouse pointer
		x_elem = 0, y_elem = 0; // Stores top, left values (edge) of the element	
		// Will be called when user starts dragging an element
		
		function _drag_init(elem) {		
		// Store the object of the element which needs to be moved		
		selectedmov = elem;
		x_elem = x_pos - selectedmov.offsetLeft;
		y_elem = y_pos - selectedmov.offsetTop;
		}

		// Will be called when user dragging an element
		function _move_elem(e) {		
		x_pos = document.all ? window.event.clientX : e.pageX;
		y_pos = document.all ? window.event.clientY : e.pageY;							
		if (selected !== null) {
			selectedmov.style.left = (x_pos - x_elem) + 'px';
			selectedmov.style.top = (y_pos - y_elem) + 'px';
			
		}		
		}

		// Destroy the object when we are done
		function _destroy() {
		selectedmov = null;	
		}
		document.onmousemove = _move_elem;
		document.onmouseup = _destroy;
		// Bind the functions...	
		function conecta(e){							
			_drag_init(e);
			return false;
		}
  </script>      
    
    </form>
</body>

</html>
