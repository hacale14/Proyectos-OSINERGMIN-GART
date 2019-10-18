<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Gestion.aspx.vb" Inherits="Cobranza.Gestion" %>
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
    function abre_menu(url){
        window.location.href = url; 
    }
    function redirect(storeID) {

    alert("finally");   <--- just a test
    alert(storeID);     <--- another test

    location.href="" + storeID;
    //return false;
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
        function LlamarTelefono(anexo,mensaje,objimg){  
   			
		document.getElementById('NumTelf').value = mensaje;
		if (anexo.toString != ' ')  {
		    //alert('Se llamara al numero : ' + document.getElementById('NumTelf').value + ' del anexo: ' + anexo);
		    document.getElementById('HoraClick').value = '<%=Now()%>';		    
		    //alert(document.getElementById('HoraClick').value);			
			
            document.getElementById('ifrllamar').src = 'http://192.168.1.20/llamar.php?anexo=' + anexo + '&telefono=' + mensaje + '&idcliente=0';        
            __doPostBack("ActivarRDB", "");            
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

    <link href="https://fonts.googleapis.com/css?family=Bubbler+One|Coda|Josefin+Sans|Kalam|Righteous" rel="stylesheet">
    <link rel="Stylesheet" type="text/css" href="Estilos.css" />
    
</head>

<body style="background-color:rgba(2,117,216,.09);">        
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
    <asp:hiddenfield id="Hidtelefono" value="" runat="server"/>    
    <asp:hiddenfield id="CodTelefono" value="" runat="server"/>    
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" EnablePartialRendering="true">
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
    
    <table width="100%">
    <tr>        
        <td colspan=2>
            <table width="100%" border="0">
                <tr>
                    <td width="35%" align="right" ><asp:Label id="lblGestor" runat="server" style="color:black;" CssClass="jc_usuario" Text=""/></td>
                    <td width="30%" align="center"><center><asp:Label id="lblAnexo" runat="server" style="color:black;" CssClass="jc_usuario" Text=""/> </center></td>
                    <td width="40%" align="left"><asp:Label id="lblUuario" runat="server" CssClass="jc_usuario" Text="" style="float:right;color:black;" /></td>
                </tr>
            </table>
        </td>        
    </tr>
    </table>

<table border=0 width="100%"> <%--width="100%" border=1--%>
    <tr>
    <td colspan=2>
        <fieldset style="margin:0; padding:3px;background-color:#070719; border:solid 1px #070719;" > 
        <table width="100%">
            <tr>
                <td colspan="2">    
		            <center>
                    <table style="margin:0; padding:3px 0px 0px 0px; width:99%;" border=0>
                        <tr>
                            <td><asp:Label ID="lblArchivo" runat="server" Text="CARTERA" CssClass="p_lbl" style="font-size:10px;color:White;"/></td>
                            <td><uc2:CtCombo ID="cbocartera" runat="server" Largo="20" Longitud="210" Procedimiento="QRYCG002" Condicion=":criterio▓ALL"/></td>
                            <td><asp:Label ID="Label41" runat="server" Text="NOMBRE DE CLIENTE" CssClass="p_lbl" style="font-size:10px;color:White;"/></td>
                            <td><uc3:CtlTxt ID="txtnombre" runat="server" Ancho="200" Largo="10" Desactiva="false"/></td>
                            <td><asp:Label ID="Label47" runat="server" CssClass="p_lbl" Text="E-MAIL" style="font-size:10px;color:White;"></asp:Label></td>
                            <td><uc3:CtlTxt ID="txtemail" runat="server" Ancho="200" Largo="10"/></td>
                            <td rowspan="7">
                                <img id="fotox" src="Imagenes/fotox.jpg"/>
                            </td>
                            <td rowspan="7" style="padding-left:20px;">
                                <table>
                                    <tr><td><center><div class="curvo_deuda2"><asp:ImageButton id="imgBuscar" runat="server" CssClass="curvoimg_deuda2" ImageUrl="~/imagenes/boton busqueda.jpg" ToolTip="Buscar"/><asp:Label id="lblBuscar" runat="server" CssClass="curvolbl_deuda2" Text="Buscar" ToolTip="Buscar"></asp:Label></div></center></td>
                                        <td><center><div class="curvo_deuda2"><asp:ImageButton id="imgPropuesta" runat="server" CssClass="curvoimg_deuda2" ImageUrl="~/imagenes/BotonGenerarReporte.png" ToolTip="Propuesta" /><asp:Label id="Label23" runat="server" CssClass="curvolbl_deuda2" Text="Propuesta" ToolTip="Propuesta"></asp:Label></div></center></td>
                                    </tr>
                                    <tr><td><center><div class="curvo_deuda2"><asp:ImageButton id="ImageButton1" runat="server" CssClass="curvoimg_deuda2" ImageUrl="~/imagenes/BotonGestiones.png" ToolTip="Campo" /><asp:Label id="Label3" runat="server" CssClass="curvolbl_deuda2" Text="Campo" ToolTip="Campo"></asp:Label></div></center></td>
                                        <td><center><div class="curvo_deuda2"><asp:ImageButton id="ImageButton2" runat="server" CssClass="curvoimg_deuda2" ImageUrl="~/imagenes/BotonGrabar.png" ToolTip="Grabar"/><asp:Label id="Label4" runat="server" CssClass="curvolbl_deuda2" Text="Grabar" ToolTip="Grabar"></asp:Label></div></center></td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr><td height="2px"></td></tr>
                        <tr>
                            <td width="75px"><asp:Label ID="lblTipoCartera" runat="server" CssClass="p_lbl" Text="CENT. LABORAL" style="font-size:10px;color:White;"></asp:Label></td>
                            <td><uc3:CtlTxt ID="txtCentroLaboral" runat="server" Ancho="200" Largo="10"/></td>
                            <td><asp:Label ID="Label42" runat="server" CssClass="p_lbl" Text="1er PROD" style="font-size:10px;color:White;"></asp:Label></td>
                            <td><uc3:CtlTxt ID="txt1erProd" runat="server" Ancho="200" Largo="10" Desactiva="false"/></td>
                            <td><asp:Label ID="Label5" runat="server" CssClass="p_lbl" Text="2do PROD" style="font-size:10px;color:White;"></asp:Label></td>
                            <td><uc3:CtlTxt ID="txt2doProd" runat="server" Ancho="200" Largo="10" Desactiva="false"/></td>
                            
                        </tr>
                        <tr><td height="2px"></td></tr>
                        <tr>
                            <td><asp:Label ID="Label44" runat="server" CssClass="p_lbl" Text="CONYUGE" style="font-size:10px;color:White;"></asp:Label></td>
                            <td><uc3:CtlTxt ID="txtConyugue" runat="server" Ancho="200" Largo="10"/></td>
                            <td><asp:Label ID="Label45" runat="server" CssClass="p_lbl" Text="AVAL" style="font-size:10px;color:White;"></asp:Label></td>
                            <td><uc3:CtlTxt ID="txtAval" runat="server" Ancho="200" Largo="10" Desactiva="false"/></td>
                            <td><asp:Label ID="Label48" runat="server" CssClass="p_lbl" Text="REP. LEGAL" style="font-size:10px;color:White;"></asp:Label></td>
                            <td><uc3:CtlTxt ID="txtRepresentanteLegal" runat="server" Ancho="200" Largo="10" Desactiva="false"/></td>
                            
                        </tr>
                        <tr><td height="2px"></td></tr>
                        <tr>
                            <td colspan="6">
                                <table width="100%">
                                    <tr>
                                        <td><asp:Label ID="Label37" runat="server" Text="C.INT" CssClass="p_lbl" style="font-size:10px;color:White;"/></td>
                                        <td><uc2:CtCombo ID="cbocint" runat="server" Longitud="50" Largo="20" Procedimiento="QRYCGC001" clase="xx" /></td>
                                        <td><asp:Label ID="Label38" runat="server" Text="C.EXT" CssClass="p_lbl" style="font-size:10px;color:White;"/></td>
                                        <td><uc3:CtlTxt ID="txtcext" runat="server" Ancho="50" Largo="10"/></td>
                                        <td><asp:Label ID="Label39" runat="server" Text="TIPO C." CssClass="p_lbl" style="font-size:10px;color:White;"/></td>
                                        <td><uc2:CtCombo ID="cbotipoc" Longitud="100" runat="server" Largo="20" /></td>
                                        <td><asp:Label ID="Label40" runat="server" Text="SITUAC." CssClass="p_lbl" style="font-size:10px;color:White;"/></td>
                                        <td><uc3:CtlTxt ID="txtsitua" runat="server" Ancho="50" Largo="10" /></td>
                                        <td><asp:Label ID="LabeXl41" runat="server" Text="DNI" CssClass="p_lbl" style="font-size:10px;color:White;"/></td>
                                        <td><uc3:CtlTxt ID="txtDNI" runat="server" Ancho="70" Largo="10" /></td>
                                        <td><asp:Label ID="Label43" runat="server" CssClass="p_lbl" Text="EDAD" style="font-size:10px;color:White;"></asp:Label></td>
                                        <td><uc3:CtlTxt ID="txtEdad" runat="server" Ancho="50" Largo="10"/></td>
                                        <td><asp:Label ID="Label46" runat="server" CssClass="p_lbl" Text="ING." style="font-size:10px;color:White;"></asp:Label></td>
                                        <td><uc3:CtlTxt ID="txtIngreso" runat="server" Ancho="50" Largo="10"/></td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                    </center>
                </td>
            </tr>
        </table>   
        </fieldset>
    </td> 
    </tr>
</table>    

<table border="0">
    <tr>
        <td >
            <fieldset style="margin:0; padding:5px; height:137px; width:760px;">
		        <legend>
		            <asp:Label id="Label1" runat="server"  Text=" DIRECCIONES "></asp:Label>
		        </legend>
                <uc1:CtlGrilla ID="CtlDireccion" runat="server" Largo="95px" Ancho="755px" Activa_ckeck="false" Activa_option="false" Desactiva_Boton="false" OcultarColumnas="4;5;8;9;10;11;14;15;17"  Activa_Titulo="false" Desactivar_Exportar="0;1;2;3;4" OpocionNuevo="true" />
            </fieldset>
            <fieldset style="margin:0; padding:5px; height:128px; width:760px;">
		        <legend>
		            <asp:Label id="Label13" runat="server" Text=" ANOTACIONES"></asp:Label>
		        </legend>
                <uc1:CtlGrilla ID="CtlAnotaciones" runat="server" Largo="95px" Ancho="755px" Activa_Delete="false"  Activa_ckeck="false" Activa_option="false" Activa_Titulo="false" Desactiva_Boton="False" OcultarFormatos="False" />
            </fieldset>
        </td>
        <td width="5px"></td>
        <td>
            <fieldset style="margin:0; padding:5px;height:277px; width:320px;">
		        <legend>
		            <asp:Label id="Label2" runat="server" Text=" TELEFONOS "></asp:Label>
		        </legend>
                <uc1:CtlGrilla ID="CtlTelefono" runat="server" Activa_ckeck="false" Activa_option="false" Desactiva_Boton="false" Activa_Titulo="false" Largo="235px" With_Grilla="320px" Activa_Delete="false" OcultarColumnas="4;5;6;8;9;10;11;13;14;16;17    " Desactivar_Exportar="0;1;2;3;4" Activa_Edita="true" OpocionNuevo="true" />
            </fieldset>
        </td>
        <td width="5px"></td>
        <td rowspan="2">    
        <fieldset style="margin:0; padding:5px; height:349px; width:140px;">
            <legend>
                <asp:Label id="Label8" runat="server" Text=" DATOS DE LA DEUDA "></asp:Label>
            </legend>                     
            <table style="height:300px; width:140px;">            
                <tr><td><center><asp:Label ID="Label49" runat="server" Text="TOTAL S/." CssClass="p_lbl"/></center></td></tr>
                <tr><td><center><uc3:CtlTxt ID="txtDeudaTotalSoles" runat="server" style="text-align:center" Ancho="100" Largo="9px"/></center></td></tr>
                <tr><td><center><asp:Label ID="Label50" runat="server" Text="DEUDA  VCDA S/." CssClass="p_lbl"/></center></td></tr>
                <tr><td><center><uc3:CtlTxt ID="txtDeudaVcdaSoles" style="text-align:center" runat="server" Ancho="100" Largo="9px"/></center></td></tr>
                <tr><td><center><asp:Label ID="Label51" runat="server" Text="DEUDA  VCDA US$" CssClass="p_lbl"/></center></td></tr>
                <tr><td><center><uc3:CtlTxt ID="txtDeudaVcdaCUSD" style="text-align:center" runat="server" Ancho="100" Largo="9px"/></center></td></tr>
                <tr><td><center><asp:Label ID="Label52" runat="server" Text="TOTAL US$" CssClass="p_lbl"/></center></td></tr>
                <tr><td><center><uc3:CtlTxt ID="txtDeudaTotalUSD" style="text-align:center" runat="server" Ancho="100" Largo="9px"/></center></td></tr>
                <tr><td><center><asp:Label ID="Label53" runat="server" Text="DEUDA  VCDA US$" CssClass="p_lbl"/></center></td></tr>          
                <tr><td><center><uc3:CtlTxt ID="txtDeudaVcdaUSD" style="text-align:center" runat="server" Ancho="100" Largo="9px"/></center></td></tr>
                <tr><td><center><asp:Label ID="Label54" runat="server" Text="DEUDA  VCDA S/." CssClass="p_lbl"/></center></td></tr>          
                <tr><td><center><uc3:CtlTxt ID="txtDeudaVcdaCSoles" style="text-align:center" runat="server" Ancho="100" Largo="9px"/></center></td></tr>
                <tr><td><center><asp:Label ID="Label84" runat="server" Text="CAMPAÑA S/." CssClass="p_lbl"/></center></td></tr>          
                <tr><td><center><uc3:CtlTxt ID="txtCampania" style="text-align:center" runat="server" Ancho="100" Largo="9px"/></center></td></tr>
                <tr><td rowspan=2 valign="middle">
                <center>
                <table border=0 height="100%" style="margin-top:5px;">
                    <tr><td><div class="curvo_deuda"><asp:ImageButton id="btnPagos" runat="server" CssClass="curvoimg_deuda" ImageUrl="~/imagenes/Pago.png" ToolTip="Click para mostrar pagos"/><asp:Label id="Label9" runat="server" Text="Pagos" ToolTip="Reporte de Pagos" CssClass="curvolbl_deuda" ></asp:Label></div></td></tr>
                    <tr><td><div class="curvo_deuda"><asp:ImageButton id="btnCompromisos" runat="server" CssClass="curvoimg_deuda" ImageUrl="~/imagenes/oferta.png" ToolTip="Click para mostrar compromisos"/><asp:Label id="Label14" runat="server" Text="Compro" ToolTip="Consuta Compromisos" CssClass="curvolbl_deuda" ></asp:Label></div></td></tr>
                    <tr><td><div class="curvo_deuda"><asp:ImageButton id="btnInfAdd" runat="server" CssClass="curvoimg_deuda" ImageUrl="~/imagenes/BotonGenerarReporte.png" ToolTip="Click para Informacion Adicional"/><asp:Label id="Label15" runat="server" Text="Inf_Add" ToolTip="Informacion adicional" CssClass="curvolbl_deuda" ></asp:Label></div></td></tr>
                    <tr><td><div class="curvo_deuda"><asp:ImageButton id="btnDeuda" runat="server" CssClass="curvoimg_deuda" ImageUrl="~/imagenes/Deudaf.png" ToolTip="Click para mostrar deuda"/><asp:Label id="Label16" runat="server" Text="Deuda" ToolTip="Deuda" CssClass="curvolbl_deuda" ></asp:Label></div></td></tr>
                </table>                                                          
                </center></td>
                </tr>
                
            </table>            
        </fieldset>
    </td>
    </tr>
    
    <tr>
        <td colspan="3">
            <fieldset style="margin:0; padding:5px;height:60px;">
		        <legend>    
		            <asp:Label id="Label6" runat="server" Font-Size="11px" Text="GESTIONES REALIZADAS" BackColor="#E2E2E2"></asp:Label>
		        </legend>
		        <table style="height:10px; width:100%;" border=0>            
                    <tr>
                    <td><asp:Label ID="Label55" runat="server" CssClass="p_lbl" Text="DETALLE DE LA GESTION" style="font-size:10px" /></td>
                    <td><asp:Label ID="Label56" runat="server" CssClass="p_lbl" Text="INDICADOR DE LA GESTION" style="font-size:10px" /></td>
                    <td style="padding-right:80px;"><asp:Label ID="Label57" runat="server" CssClass="p_lbl" Text="OBSERVACION" style="font-size:10px" /></td>
                    <td><asp:Label ID="Label58" runat="server" CssClass="p_lbl" Text="PROPUESTA" style="font-size:10px" /></td>
                    <td><asp:Label ID="Label59" runat="server" CssClass="p_lbl" Text="CAMPO" style="font-size:10px" /></td>
                    <td><asp:Label ID="Label60" runat="server" CssClass="p_lbl" Text="CALL" style="font-size:10px" /></td>
                    <td rowspan=2 valign="bottom"><center>
                        <div class="curvo_deuda" style="width:150px;margin-top:2px;">
                            <asp:ImageButton id="ImageButton4" onclick="btnOne_Click" runat="server" CssClass="curvoimg_deuda" ImageUrl="~/imagenes/BotonGrabar.png" ToolTip="Guardar Gestion"/>
                            <asp:Label id="Label12" runat="server" CssClass="curvolbl_deuda" Text="" ToolTip="Guardar Gestion">GUARDAR</asp:Label>
                        </div></center> </td>
                    <tr>
                    <td><uc2:CtCombo Largo="20" ID="CboGestion" Longitud="120" runat="server" clase="xx" /></td>
                    <td><uc2:CtCombo Largo="20" ID="cboIndicador" Longitud="200" runat="server" clase="xx"  AutoPostBack="true"/></td>
		            <td><uc3:CtlTxt ID="txtGestion" runat="server" Largo="12" Ancho="300" Maximo="150" />
                    <asp:Button ID="btnProximaAccion" runat="server" Text="AGENDA" CssClass="p_btnx" />                    
                    <asp:Button ID="btnAvanzar" runat="server"  Text="SIGUIENTE" Visible="False" CssClass="p_btnx"/></td>
                    <td><center><asp:RadioButton ID="RDBPropuesta" runat="server" AutoPostBack="true" GroupName="tipoGestion"/></center></td>
                    <td><center><asp:RadioButton ID="RDBCampo" runat="server" AutoPostBack="true" GroupName="tipoGestion" /></center></td>
                    <td><center><asp:RadioButton ID="RDBCall" runat="server" AutoPostBack="true" GroupName="tipoGestion" /></center></td>                    
                    </tr>
                </table>
            </fieldset>
        </td>
        <td width="5px"></td>
    </tr>
    <tr>
    <td colspan=5>
    <table width="100%">
    <tr>    
    <td>
        <center>
            <fieldset style="margin:0; padding:0; height:82px;">
                <legend>
                    <asp:Label id="Label10" runat="server" Font-Size="11px" Text=" GESTIONES TELEFONICAS " BackColor="#E2E2E2"></asp:Label>
                </legend>           
                <uc1:CtlGrilla ID="CtlGestionTelefonica" runat="server" Largo="55px" Activa_ckeck="false" Activa_Delete="false" Activa_Edita="false" Activa_option="false" Activa_Titulo="false" Desactiva_Boton="False" OcultarFormatos="False" OcultarColumnas="7;12;13;14;15" />
            </fieldset>
            <fieldset style="margin:0; padding:0; height:82px;">
                <legend>
                    <asp:Label id="Label11" runat="server" Font-Size="11px" Text=" GESTIONES DE CAMPO " BackColor="#E2E2E2"></asp:Label>
                </legend> 
                <uc1:CtlGrilla ID="CtlGestionCampo" runat="server" Largo="100px" With_Grilla="937px"  Activa_ckeck="false" Activa_Delete="false" Activa_Edita="false" Activa_option="false" Activa_Titulo="false"   Desactiva_Boton="False" OcultarFormatos="False"  OcultarColumnas="7;12;13;14;15" />
            </fieldset>       
        </center>
    </td>
    <td width="5px"></td>
    </tr>
    </table>
    </tr>
    </table>
    </center>
    
    <div id="medidor">
        <table class="flot_t" border=0>
            <tr><td></td></tr>
            <tr><td width="10px">E&nbsp;&nbsp;</td><td rowspan="12" valign="middle" id="tdtd">
                <div id="medidor-content" style="padding-left:20px;">
                    <fieldset style="margin:0; padding:5px;height:230px; width:250px; background:rgba(1,1,1,.9);">
		                <legend style="text-align:center">    
		                    <asp:Label id="Label7" runat="server" Text="AVANCES DE COBERTURA Y EFECTIVIDAD "></asp:Label>
		                </legend>
		                <table style="top:0;"  border=0>
                        <tr>
                            <td  width=100px><div id="gauge_div" style="width:100px; height:100px;"></div></td>
                        <td ></td>
                            <td  width=100px><div id="gauge_dive" style="width:100px; height:100px;"></div></td>                          
                        </tr>
                        <tr>
                            <td width=250px  valign="top" colspan="3" ><uc1:CtlGrilla ID="CtlEstadistica" runat="server" Largo="100px" Ancho="155px"  Activa_Delete="false" Activa_Edita="false" Activa_ckeck="false" Activa_option="false" OcultarFormatos="false" Desactiva_Boton="false" Activa_Titulo="false"/></td>                            
                        </tr>
                        </table>
                    </fieldset>
                </div>
            </td></tr>
            <tr><td>S</td></tr>
            <tr><td>T</td></tr>
            <tr><td>A</td></tr>
            <tr><td>D</td></tr>
            <tr><td>I</td></tr>
            <tr><td>S</td></tr>
            <tr><td>T</td></tr>
            <tr><td>I</td></tr>
            <tr><td>C</td></tr>
            <tr><td>A</td></tr>
            <tr><td>S</td></tr>
            <tr><td></td></tr>
        </table>
        
        
    </div>
    
    <iframe id="ifrllamar" style="visibility:hidden;"></iframe>        
    <asp:Panel ID="pnlInformacionAdicional" runat="server" Visible="false" CssClass="panel_hand">
        <div onmousedown="conecta(this);" id="dvInfAdic" style="top:20px; left:200px; z-index:10; background-color:rgba(255,255,255,0); border:0px solid; position:absolute;text-align:-moz-right; border-radius: 4px;">    
            <table style="background:#E7E6E6; width:100%; border:solid 1px rgba(255,195,0,1);margin:4px;border-radius:5px;">
                <tr>
                    <td style="font-family:'josefin sans';font-size:14px; background:rgba(255,195,0,1);border-radius:0px;color:black; font-weight:900; padding:5px;">
                        INFORMACION ADICIONAL DE: <asp:Label ID="Label18" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <uc1:CtlGrilla ID="gvInformacionAdicional" runat="server" Activa_ckeck="false" Activa_Export="true"  Activa_option="false" Desactiva_Boton="false" Activa_Titulo="false" Largo="500px" Ancho="800px"  Activa_Delete="false" Activa_Edita="false" />
                    </td>
                </tr>
                <tr><td style="height:10px;"></td></tr>
                <tr>
                    <td>
                        <asp:Button ID="btnCarrarInformacionAdicional" runat="server" Text="Cerrar" CssClass="semaf_btn_a" style="width:100px; font-size:14px; margin-left:5px;"/>						
                    </td>
                </tr>
                <tr><td style="height:10px;"></td></tr>
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
    <asp:Panel ID="PnlProximaAccion" runat="server" Visible="false" CssClass="panel_hand">
        <div onmousedown="conecta(this);" id="Div7" style="width:360px; top:280px; left:400px; z-index:4; background-color:rgba(255,255,255,0); border:0px solid; position:absolute;text-align:-moz-right; border-radius: 4px;">    
            <table style="width:100%; background:#E7E6E6; border:solid 1px rgba(255,195,0,1);margin:4px;border-radius:5px;">
                <tr>
                    <td style="font-family:'josefin sans';font-size:14px; background:rgba(255,195,0,1);color:black; font-weight:900;padding:5px;border-radius:0px;">
                        <asp:Label ID="Label29" runat="server" Visible="false"></asp:Label>
                        AGENDA <asp:Label ID="Label30" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>    
                    <td>
                        <table style="margin:5px;" border=0>
                            <tr>                                                                
                                <td>
                                    <asp:Label ID="lblfech" runat="server" Text="FECHA" CssClass="p_lbl" style="font-size:10px;"/>
			                        <asp:TextBox ID="txtProximaAccion" runat="server"  Width="80px" Enabled = "false" CssClass="textoContenido" style="height:12px;"/>
                                    <img ID="Img3" alt="calendario" height="16"  onclick="return showCalendar('txtProximaAccion','<%=txtProximaAccion.ClientID%>','%d/%m/%Y','24', true);" src="Imagenes/calendario.png" width="18" />	
                                    &nbsp;&nbsp;
                                    <asp:Label ID="Label61" runat="server" Text="HORA" CssClass="p_lbl" style="font-size:10px;"/> 
                                    <uc2:CtCombo ID="CboHoraProxAcc" runat="server" Procedimiento="GES006" Longitud="57"/>    
                                    &nbsp;&nbsp;
                                    <asp:Label ID="Label62" runat="server" Text="MINUTO" CssClass="p_lbl" style="font-size:10px;"/> 
                                    <uc2:CtCombo ID="CboMinutoProxAcc" runat="server" Procedimiento="GES005" Longitud="57" />    
                                </td>                                                                
                            </tr>
                            <tr><td style="height:10px;"></td></tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label63" runat="server" Text="ANOTACION" CssClass="p_lbl" style="font-size:10px;"/> 
                                    <br />
                                    <asp:TextBox ID="txtAnotacion" runat="server"  Enabled="true" TextMode="SingleLine" Height="30px" Width="350px"  MaxLength="100" CssClass="textoContenido" style="margin-top:4px;"/>                        
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr><td style="height:10px;"></td></tr>                
                <tr>
                    <td>
                        <asp:Button ID="btnAceptarFP" runat="server" Text="Aceptar" CssClass="semaf_btn_a" style="width:100px; font-size:14px; margin-left:5px;"/>						
                        <asp:Button ID="btnCerrarFP" runat="server" Text="Cerrar" OnClientClick="if ( !confirm('¿Estas seguro que deseas cancelar la agenda?')) return false;" CssClass="semaf_btn_a" style="width:100px; font-size:14px; margin-left:5px;"/>						
                    </td>
                </tr>
                <tr><td style="height:10px;"></td></tr>
            </table>
        </div>
    </asp:Panel>    
	<asp:Panel ID="PnlMensajeAlerta" runat="server" Visible="false"  CssClass="panel_hand">
        <div onmousedown="conecta(this);" id="Div8" style="top:250px; left:400px; z-index:4; background-color:rgba(255,255,255,0); border:none; position:absolute;text-align:-moz-right; border-radius: 4px;">    
            <table style="background:#E7E6E6; width:100%;border:solid 1px rgba(255,195,0,1);margin:4px; border-radius:5px;">
                <tr>
                    <td style="font-family:'josefin sans'; font-size:14px; background:rgba(255,195,0,1); border-radius:0px;padding:5px;color:black; font-weight:900;">
                        <asp:Label ID="Label31" runat="server" Visible="false"></asp:Label>
                        MENSAJE DE PROXIMA GESTION<asp:Label ID="Label32" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr><td style="height:10px;"></td></tr> 
                <tr>    
                    <td align=center style="padding-left:12px; background:#E7E6E6;">
                        <table>                            
                            <tr>
                                <td>
                                    <asp:TextBox ID="txtAnotacionMensaje" runat="server"  Enabled = "true" BackColor="#FFC300" ReadOnly="false"  TextMode="MultiLine" Height="100px" Width="300px" style="font-family:coda; background:#E7E6E6;"/>                        
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr> 
                <tr><td style="height:10px;"></td></tr>               
                <tr>
                    <td>
                        <asp:Button ID="BtnRedirect" runat="server" Text="Ir al Cliente" CssClass="semaf_btn_a" style="width:100px; font-size:14px; margin-left:5px;"/>
                        <asp:Button ID="BtnPosponer" runat="server" Text="Posponer" CssClass="semaf_btn_a" style="width:100px; font-size:14px; margin-left:5px;"/>
                        <asp:Button ID="BtnEliminar" runat="server" Text="Eliminar" CssClass="semaf_btn_a" style="width:100px; font-size:14px; margin-left:5px;"/>
                    </td>
                </tr>
                <tr><td style="height:10px;"></td></tr>
            </table>
        </div>
    </asp:Panel>       	
    <asp:Panel ID="pnlPagos" runat="server" Visible="false" CssClass="panel_hand">
        <div onmousedown="conecta(this);" id="dvPagos" style="width:850px;top:200px; left:200px; z-index:4; background-color:rgba(255,255,255,0); border:none; position:absolute;text-align:-moz-right;">    
            <table style="background:#E7E6E6; width:100%;border:solid 1px rgba(255,195,0,1);margin:4px; border-radius:5px;">
                <tr>
                    <td style="font-family:'josefin sans'; font-size:14px; background:rgba(255,195,0,1); border-radius:0px;padding:5px;color:black; font-weight:900;">
                        <asp:Label ID="lblIdClientePagos" runat="server" Visible="false"></asp:Label>
                        CONSULTA DE PAGOS - CARTERA 
                        <asp:Label ID="lblTiposCartera" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr><td style="height:5px;"></td></tr>
                <tr>    
                    <td>
                        <table border="0" width="100%">
                            <tr>
                                <td style="text-align:center;">
                                    <asp:Label ID="idni" runat="server" CssClass="p_lbl" Text="DNI"></asp:Label>
                                </td>
                                <td style="text-align:center;">
                                    <asp:Label ID="Label33" runat="server" CssClass="p_lbl" Text="CLIENTE"></asp:Label>
                                </td>
                                <td style="text-align:center;">
                                    <asp:Label ID="Label34" runat="server" CssClass="p_lbl" Text="FECHA INICIO"></asp:Label>
			                    </td>
			                    <td style="text-align:center;">
                                    <asp:Label ID="Label35" runat="server" CssClass="p_lbl" Text="FECHA FIN"></asp:Label>
					            </td>
					            <td style="text-align:center;">
                                    <asp:Label ID="Label36" runat="server" CssClass="p_lbl" Text="CARTERA"></asp:Label>
                                </td>
                                <td rowspan="2">
                                    <div class="curvo" id="GrupoReporte" runat="server" style="margin-right:5px;">
			                            <asp:ImageButton id="imgBuscarPagos" runat="server" ImageUrl="imagenes/boton busqueda.jpg" CssClass="curvoimg" />
			                            <asp:Label id="Label17" runat="server" CssClass="curvolbl" Text="Buscar"></asp:Label>
					                </div>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align:center; height:10px;">
                                    <asp:TextBox ID="txtDNIPagos" runat="server" CssClass="textoContenido" Width="60px"></asp:TextBox>
                                </td>
                                <td style="text-align:center;">
                                    <asp:TextBox ID="txtClientePagos" runat="server" CssClass="textoContenido" Width="150"></asp:TextBox>
                                </td>
                                <td style="text-align:center;">
                                    <asp:TextBox ID="txtFechaInicioPagos" runat="server"  Width="80px" Enabled = "false" CssClass="textoContenido"/>
                                    <img ID="txtFechaInicio1" alt="calendario" height="16"  onclick="return showCalendar('txtFechaInicio1','<%=txtFechaInicioPagos.ClientID%>','%d/%m/%Y','24', true);" src="Imagenes/calendario.png" width="18" />	
                                </td>
                                <td style="text-align:center;">
                                    <asp:TextBox ID="txtFechaFinPagos" runat="server"  Width="80px" Enabled = "false" CssClass="textoContenido"/>
                                    <img ID="txtFechaFin1" alt="calendario" height="16" onclick="return showCalendar('txtFechaFin1','<%=txtFechaFinPagos.ClientID%>','%d/%m/%Y','24', true);" src="Imagenes/calendario.png" width="18" />
                                </td>
                                <td style="text-align:center;">
                                    <uc2:CtCombo ID="cboCarteraPagos" Longitud="180" Procedimiento="QRYCG002" runat="server"/>           
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td>
                        <uc1:CtlGrilla ID="gvConsultaPagos" runat="server" Activa_ckeck="false" Activa_Export="true"  Activa_option="false" Desactiva_Boton="false" Activa_Titulo="false" Largo="200px" Ancho="320px" Activa_Delete="true" Activa_Edita="true" OpocionNuevo="true"/>
                    </td>
                </tr>
                <tr><td style="height:10px;"></td></tr>
                <tr>
                    <td>
                        <asp:Button ID="btnCerrarPagos" runat="server" Text="Cerrar" CssClass="semaf_btn_a" style="width:100px; font-size:14px; margin-left:5px;"/>
                    </td>
                </tr>
                <tr><td style="height:10px;"></td></tr>
            </table>
        </div>
    </asp:Panel>       
    <asp:Panel ID="pnlCompromisos" runat="server" Visible="false" CssClass="panel_hand">
        <div onmousedown="conecta(this);" id="dvComp" style="top:200px; left:100px; z-index:4; background-color:rgba(255,255,255,0); border:0px solid; position:absolute;text-align:-moz-right; border-radius: 4px;">    
            <table style="background:#E7E6E6; border:solid 1px rgba(255,195,0,1);margin:4px;border-radius:5px;">
                <tr>
                    <td style="font-family:'josefin sans';font-size:14px; background:rgba(255,195,0,1);color:black; font-weight:900;padding:5px;border-radius:0px; ">COMPROMISOS  DE <asp:Label ID="lblCompromisos" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <uc1:CtlGrilla ID="gvCompromisos" runat="server" Activa_ckeck="false" Activa_Export="true"  Activa_option="false" Desactiva_Boton="false" Activa_Titulo="false" Largo="165px" Ancho="800px" Activa_Delete="true" Activa_Edita="true" />
                    </td>
                </tr>
                <tr><td style="height:10px;"></td></tr>
                <tr>
                    <td>
                        <asp:Button ID="btnCerrarCompromisos" runat="server" Text="Cerrar" CssClass="semaf_btn_a" style="width:100px; font-size:14px; margin-left:5px;"/>
                    </td>
                </tr>
                <tr><td style="height:10px;"></td></tr>
            </table>
        </div>
    </asp:Panel>
    <asp:Panel ID="pnlMantenimientoDireccion" runat="server" Visible="false" CssClass="panel_hand">
        <div onmousedown="conecta(this);" id="dvMantDir" style="top:200px; left:200px; z-index:4; background-color:rgba(255,255,255,0); border:none; position:absolute;text-align:-moz-right;">    
            <asp:Label ID="lblId_Direccion_Activa" runat="server" Visible="false"></asp:Label>
            <asp:Label ID="lblTipo_Mantenimiento_Direccion" runat="server" Visible="false"></asp:Label>
            <table style="background:#E7E6E6; width:100%;border:solid 1px rgba(255,195,0,1);margin:4px; border-radius:5px;">
                <tr>
                    <td colspan="2" style="font-family:'josefin sans'; font-size:14px; background:rgba(255,195,0,1); border-radius:0px;padding:5px;color:black; font-weight:900;">
                        DIRECCION
                    </td>
                </tr>
                <tr>
                    <td>
                        <table style="padding:5px;">
                            <tr>
                                <td style="width:150px;">
                                    <asp:Label ID="Label73" runat="server" CssClass="p_lbl" Text="DEPARTAMENTO"></asp:Label>
                                </td>
                                <td>
                                    <uc2:CtCombo ID="cboDepartamentoMantenimietoDireccion" runat="server" AutoPostBack="true" Procedimiento="QRYC009" Longitud="150" />
                                </td>
                            </tr>
                            <tr><td style="height:5px;"></td></tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label74" runat="server" CssClass="p_lbl" Text="PROVINCIA"></asp:Label>
                                </td>
                                <td>
                                    <uc2:CtCombo ID="cboProvinciaMantenimietoDireccion" runat="server" AutoPostBack="true" Procedimiento="QRYC010" Longitud="150"/>                  
                                </td>
                            </tr>
                            <tr><td style="height:5px;"></td></tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label75" runat="server" CssClass="p_lbl" Text="DISTRITO"></asp:Label>
                                </td>
                                <td>
                                    <uc2:CtCombo ID="cboDistritoMantenimientoDireccion" runat="server" Procedimiento="QRYC011" Longitud="150" />                              
                                </td>
                            </tr>
                            <tr><td style="height:5px;"></td></tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label76" runat="server" CssClass="p_lbl" Text="TIPO"></asp:Label>
                                </td>
                                <td>
                                    <uc2:CtCombo ID="cboTipoMantenimietoDireccion" runat="server" Procedimiento="SQL_N_GEST012" Condicion=":idtabla▓122" Longitud="150" />
                                </td>
                            </tr>
                            <tr><td style="height:5px;"></td></tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label77" runat="server" CssClass="p_lbl" Text="DIRECCION"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtDireccionMantenimietoDireccion" runat="server" CssClass="textoContenido" Width="140px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr><td style="height:5px;"></td></tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label78" runat="server" CssClass="p_lbl" Text="TIPO DE DIRECCION"></asp:Label>
                                </td>
                                <td>
                                    <uc2:CtCombo ID="cbotipoDireccion1" runat="server" Procedimiento="SQL_N_GEST012" Condicion=":idtabla▓122" Longitud="150" />
                                </td>
                            </tr>
                            <tr><td style="height:5px;"></td></tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label79" runat="server" CssClass="p_lbl" Text="CONDICION DE VIVIENDA"></asp:Label>
                                </td>
                                <td>
                                    <uc2:CtCombo ID="cboCondVivienda" runat="server" Procedimiento="SQL_N_GEST012" Condicion=":idtabla▓122" Longitud="150" />
                                </td>
                            </tr>
                            <tr><td style="height:5px;"></td></tr>
                            <tr>
                                <td>
                                    <asp:Button ID="btnAceptarMantenimietoDireccion" runat="server" Text="Aceptar" class="semaf_btn_a" style="width:100px; font-size:14px; margin-left:5px;"/>
                                </td>
                                <td>
                                    <asp:Button ID="btnCancelarMantenimietoDireccion" runat="server" Text="Cancelar" class="semaf_btn_a" style="width:100px; font-size:14px; margin-left:5px;"/>
                                </td>
                            </tr>
                            <tr><td style="height:5px;"></td></tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
    </asp:Panel>
    <asp:Panel ID="pnlPagosMantenimiento" runat="server" Visible="false" CssClass="panel_hand">
            <asp:Label ID="Label24" runat="server" Visible="false"></asp:Label>
            <asp:Label ID="Label25" runat="server" Visible="false"></asp:Label>
            <div onmousedown="conecta(this);" id="dvPgiMant" style="top:250px; left:240px; z-index:5; background-color:rgba(255,255,255,0); border:0px solid; position:absolute;text-align:-moz-right; border-radius: 4px;">    
                <table style="width:100%; background:#E7E6E6; border:solid 1px rgba(255,195,0,1);margin:4px;border-radius:5px;">
                    <tr>
                        <td style="font-family:'josefin sans';font-size:14px; background:rgba(255,195,0,1);color:black; font-weight:900;padding:5px;border-radius:0px;">
                            MANTENIMIENTO DE PAGOS
                        </td>
                    </tr>
                    <tr><td style="height:5px;"></td></tr>
                    <tr>
                        <td>
                            <table>
                                <tr>
                                    <td style="text-align:center;">
                                        <asp:Label ID="fecha_pago" runat="server" CssClass="p_lbl" Text="FECHA DE PAGO"></asp:Label>
                                    </td>
                                    <td style="text-align:center;">
                                        <asp:Label ID="num_opera" runat="server" CssClass="p_lbl" Text="NUMERO DE OPERACION"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align:center;">
                                        <asp:TextBox ID="txtFechaPago" runat="server"  Width="80px" Enabled = "false" CssClass="textoContenido"/>
                                        <img ID="imgFechaPago" alt="calendario" height="16" onclick="return showCalendar('imgFechaPago','<%=txtFechaPago.ClientID%>','%d/%m/%Y','24', true);" src="Imagenes/calendario.png" width="18" />
                                    </td>
                                    
                                    <td style="text-align:center;">
                                        <uc2:CtCombo ID="CboNroOperacioPago" Longitud="150" runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align:center;">
                                        <asp:Label ID="concepto_pago" runat="server" CssClass="p_lbl" Text="CONCEPTO DE PAGO"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" style="text-align:center;">
                                        <uc2:CtCombo ID="cboConceptoPago" Longitud="260" runat="server" Procedimiento="SQL_N_GEST012" />
                                    </td>
                                </tr>
                                <tr>        
                                    <td style="text-align:center;">
                                        <asp:Label ID="lbl_monto" runat="server" CssClass="p_lbl" Text="MONTO"></asp:Label>
                                    </td>
                                    <td style="text-align:center;">
                                        <asp:Label ID="lbl_moneda" runat="server" CssClass="p_lbl" Text="MONEDA"></asp:Label>
                                    </td>
                                <tr>
                                    <td style="text-align:center;">
                                        <asp:TextBox ID="txtMontoPago" runat="server" CssClass="textoContenido" width="60px"></asp:TextBox>
                                    </td>
                                    <td style="text-align:center;">
                                        <uc2:CtCombo ID="CboMonedaPago" Longitud="100" Procedimiento="SQL_N_GEST012" runat="server" />
                                    </td>
                                </tr> 
                                <tr><td style="height:5px;"></td></tr>
                                <tr>
                                    <td style="text-align:center;">
                                        <div class="curvo" id="Div5" runat="server" style="margin-right:5px;">
                                        <asp:ImageButton id="ImgGrabraPago" runat="server" ImageUrl="imagenes/BotonGrabar.png" CssClass="curvoimg" />
                                        <asp:Label id="Label26" runat="server" CssClass="curvolbl" Text="Grabar"></asp:Label>
                                        </div>
                                    </td>
                                    <td style="text-align:center;">
                                         <div class="curvo" id="Div6" runat="server" style="margin-right:5px;">
                                        <asp:ImageButton id="ImgCerrarPago" runat="server" ImageUrl="imagenes/BotonCerrar.png" CssClass="curvoimg" />
                                        <asp:Label id="Label27" runat="server" CssClass="curvolbl" Text="Cerrar"></asp:Label>
                                    </td>
                                </tr>    
                                <tr><td style="height:5px;"></td></tr>  
                            </table>
                        </td>
                    </tr>                                                          
                </table>
            </div>
        </asp:Panel>
    <asp:Panel ID="pnlCompromisoMantenimiento" runat="server" Visible="false" CssClass="panel_hand">
            <asp:Label ID="lblId_Compromiso" runat="server" Visible="false"></asp:Label>
            <asp:Label ID="lblId_Gestion" runat="server" Visible="false"></asp:Label>
            <div onmousedown="conecta(this);" id="dvCmpMant" style="top:200px; left:600px; z-index:5; background-color:rgba(255,255,255,0); border:0px solid; position:absolute;text-align:-moz-right; border-radius: 4px;">    
                <table style="background:#E7E6E6; border:solid 1px rgba(255,195,0,1);margin:4px; border-radius:5px;">
                    <tr>
                        <td style="font-family:'josefin sans';font-size:14px; background:rgba(255,195,0,1);color:black; font-weight:900;padding:5px;border-radius:0px;" >
                            COMPROMISO
                        </td>
                    </tr>
                    <tr><td style="height:5px;"></td></tr>
                    <tr>
                        <td>
                            <table style="padding:5px;">
                                <tr>
                                    <td style="width:130px;">
                                        <asp:Label ID="Label64" runat="server" CssClass="p_lbl" Text="FECHA GENERO"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label65" runat="server" CssClass="p_lbl" Text="FECHA COMPROMISO"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:TextBox ID="txtFechaGeneroCompromisoMantenieminto" runat="server"  AutoPostBack="true" Width="80px" Enabled = "false" CssClass="textoContenido"/>
                                        <img ID="imgFechaGeneroCOmpromisoMantenimiento" alt="calendario" height="16" onclick="return showCalendar('imgFechaGeneroCOmpromisoMantenimiento','<%=txtFechaGeneroCompromisoMantenieminto.ClientID%>','%d/%m/%Y','24', true);" src="Imagenes/calendario.png" width="18" />
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtFechaCompromisoMantenimiento" runat="server"  Width="80px" AutoPostBack="true" CssClass="textoContenido"/>
                                        <img ID="imgFechaCOmpromisoMantenimeinto" alt="calendario" height="16" onclick="return showCalendar('imgFechaCOmpromisoMantenimeinto','<%=txtFechaCompromisoMantenimiento.ClientID%>','%d/%m/%Y','24', true);" src="Imagenes/calendario.png" width="18" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label66" runat="server" CssClass="p_lbl" Text="NRO OPERACION"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label67" runat="server" CssClass="p_lbl" Text="MONTO"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <uc2:CtCombo ID="txtNroOperacionCompromisoManteniemito" Longitud="110" runat="server" />
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtMontoCompromisoMantenimiento" runat="server" CssClass="textoContenido" Width="100"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label68" runat="server" CssClass="p_lbl" Text="MONEDA"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label69" runat="server" CssClass="p_lbl" Text="TIPO DE PAGO"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <uc2:CtCombo ID="cboMonedaCompromisoMantemiento" Longitud="110" Procedimiento="SQL_N_GEST012" runat="server" />
                                    </td>
                                    <td>
                                        <uc2:CtCombo ID="cboTipoPagoCompromisoMantenimiento" Longitud="110" Procedimiento="SQL_N_GEST012" runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td rowspan="2">
                                        <asp:CheckBox ID="chkPagadoCompromisoMantenimiento" runat="server" Text="Pagado" AutoPostBack="true" />
                                    </td>
                                    <td>
                                        <asp:Label ID="Label70" runat="server" CssClass="p_lbl" Text="FECHA PAGO"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align:center;">
                                        <asp:TextBox ID="txtFechaPagoCompromisoMantenimeinto" runat="server"  AutoPostBack="true" Width="80px" Enabled = "false" CssClass="textoContenido"/>
                                        <img ID="imgFechaPagoCOmpromisoMantenimiento" alt="calendario" height="16" onclick="return showCalendar('imgFechaPagoCOmpromisoMantenimiento','<%=txtFechaPagoCompromisoMantenimeinto.ClientID%>','%d/%m/%Y','24', true);" src="Imagenes/calendario.png" width="18" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label71" runat="server" CssClass="p_lbl" Text="MONTO"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label72" runat="server" CssClass="p_lbl" Text="MONEDA"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:TextBox ID="txtMontoCompromisoMantenimientoA" runat="server" CssClass="textoContenido" Width="100"></asp:TextBox>
                                    </td>
                                    <td>
                                        <uc2:CtCombo ID="cboMonedaCompromisoMantenimientoA" Longitud="110" Procedimiento="SQL_N_GEST012" runat="server" />
                                    </td>
                                </tr>
                                <tr><td style="height:5px;"></td></tr>
                                <tr>
                                    <td colspan="2">
                                    <center>
                                        <table>
                                            <tr>
                                                <td>
                                                    <div class="curvo_deuda2" id="Div3" runat="server">
			                                        <asp:ImageButton id="imgGrabarCompromisoMantenimiento" runat="server" ImageUrl="imagenes/BotonGrabar.png" CssClass="curvoimg_deuda2" />
			                                        <asp:Label id="Label21" runat="server" CssClass="curvolbl_deuda2" Text="Grabar"></asp:Label>
					                            </div>
                                                </td>
                                                <td>
                                                     <div class="curvo_deuda2" id="Div4" runat="server">
			                                        <asp:ImageButton id="imgCerrarCOmpromisoMantenimiento" runat="server" ImageUrl="imagenes/BotonCerrar.png" CssClass="curvoimg_deuda2" />
			                                        <asp:Label id="Label22" runat="server" CssClass="curvolbl_deuda2" Text="Cerrar"></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                        </center>
                                    </td>
                                </tr>
                                <tr><td style="height:5px;"></td></tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </div>
        </asp:Panel>
    <asp:Panel ID="pnlDeuda" runat="server" Visible="false" CssClass="panel_hand">
        <div onmousedown="conecta(this);" id="dvDeuda" style="top:200px; left:100px;z-index:4; background-color:rgba(255,255,255,0); border:0px solid; position:absolute;text-align:-moz-right; border-radius: 4px;">    
            <table style="background:#E7E6E6; border:solid 1px rgba(255,195,0,1);margin:4px;border-radius:5px;">
                <tr>
                    <td style="font-family:'josefin sans';font-size:14px; background:rgba(255,195,0,1);color:black; font-weight:900;padding:5px;border-radius:0px;">
                        DEUDA DE CLIENTE DE <asp:Label ID="lblDeudaClienteTitulo" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <uc1:CtlGrilla ID="gvDeuda" runat="server" Activa_ckeck="false" Activa_Export="true"  Activa_option="false" Desactiva_Boton="false" Activa_Titulo="false" Largo="165px" Ancho="1020px" Activa_Delete="false" Activa_Edita="false" With_Grilla="1020px" />
                    </td>
                </tr>
                <tr><td style="height:10px;"></td></tr>
                <tr>
                    <td>
                        <asp:Button ID="btnCerrarDeuda" runat="server" Text="Cerrar" CssClass="semaf_btn_a" style="width:100px; font-size:14px; margin-left:5px;"/>
                    </td>
                </tr>
                <tr><td style="height:10px;"></td></tr>
            </table>
        </div>
    </asp:Panel>
    <asp:Panel ID="pnlPropuesta" runat="server" Visible="false" CssClass="panel_hand">
        <div onmousedown="conecta(this);" id="dvPropuesta" style="top:200px; left:200px; z-index:4; background-color:rgba(255,255,255,0); border:0px solid; position:absolute;text-align:-moz-right; border-radius: 4px;">    
            <table style="background:#E7E6E6; border:solid 1px rgba(255,195,0,1);margin:4px;border-radius:5px;"> 
                <tr>
                    <td style="font-family:'josefin sans';font-size:14px; background:rgba(255,195,0,1);color:black; font-weight:900;padding:5px;border-radius:0px;">
                        CONSULTA DE PROPUESTA
                    </td>
                </tr>
                <tr>
                    <td>
                        <uc1:CtlGrilla ID="gvPropuesta" runat="server" Activa_ckeck="false" Activa_Export="true"  Activa_option="false" Desactiva_Boton="false" Activa_Titulo="false" Largo="165px" Ancho="320px" Activa_Delete="false" Activa_Edita="true" OpocionNuevo="true" With_Grilla="1000px" CssClass="semaf_btn_a" style="width:100px; font-size:14px; margin-left:5px;"/>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="btnCerrarPropuesta" runat="server" Text="Cerrar" CssClass="semaf_btn_a" style="width:100px; font-size:14px; margin-left:5px;" />
                    </td>
                </tr>
                <tr><td style="height:10px;"></td></tr>
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
    <asp:Panel ID="pnlMantenimeintoTelefono" runat="server" Visible="false">
    <div onmousedown="conecta(this);" id="dvMantenimeintoTelefono" style="top:200px; left:200px; cursor:move; z-index:4; background-color:rgba(255,255,255,0); border:none; position:absolute;text-align:-moz-right;">    
        <asp:Label ID="lblTipoTelefonoMantenieminto" runat="server" Visible="false"></asp:Label>
        <asp:Label ID="lblNumero_Activo" runat="server" Visible="false"></asp:Label>
        <table style="background:#E7E6E6; width:100%;border:solid 1px rgba(255,195,0,1);margin:4px; border-radius:5px;">
            <tr>
                <td style="font-family:'josefin sans'; font-size:14px; background:rgba(255,195,0,1); border-radius:0px;padding:5px;color:black; font-weight:900;">
                    TELEFONO
                </td>
            </tr>
            <tr>
                <td>
                    <table style="padding:5px;">
                        <tr>
                            <td>
                                <asp:Label ID="Label80" runat="server" CssClass="p_lbl" Text="NUMERO"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtNumeroTelefono" runat="server" Width="115px" class="textoContenido" ></asp:TextBox>
                            </td>
                        </tr>
                        <tr><td style="height:5px;"></td></tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label81" runat="server" CssClass="p_lbl" Text="CONTACTO"></asp:Label>
                            </td>
                            <td>
                                <uc2:CtCombo ID="cboContactoTelefono" Longitud="120" runat="server" Procedimiento="SQL_N_GEST006" Condicion=":idtabla▓121" />
                            </td>
                        </tr>
                        <tr><td style="height:5px;"></td></tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label82" runat="server" CssClass="p_lbl" Text="ORIGEN"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtOrigenTelefono" runat="server" Width="115px" class="textoContenido"></asp:TextBox>
                            </td>
                        </tr>
                        <tr><td style="height:5px;"></td></tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label83" runat="server" CssClass="p_lbl" Text="VIA TELEFONO"></asp:Label>
                            </td>
                            <td>
                                <uc2:CtCombo ID="cboViaTelefono" Longitud="120" runat="server" Procedimiento="SQL_N_GEST012" Condicion=":idtabla▓122" />
                            </td>
                        </tr>
                        <tr><td style="height:10px;"></td></tr>
                        <tr>
                            <td>
                                <asp:Button ID="btnAceptarTelefono" runat="server" Text="Aceptar" class="semaf_btn_a" style="width:100px; font-size:14px; margin-left:5px;"/>
                            </td>
                            <td>
                                <asp:Button ID="btnCancelaTelefono" runat="server" Text="Cancelar" class="semaf_btn_a" style="width:100px; font-size:14px; margin-left:5px;"/>
                            </td>
                        </tr>
                        <tr><td style="height:5px;"></td></tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
    </asp:Panel>
    
    <asp:Panel ID="pnlmarcatelf" runat="server" Visible="false"> 
    <div style="top:320px; left:830px; z-index:4; background-color:#C70039; position:absolute;text-align:-moz-right; border-radius: 4px;">            
    <fieldset style="margin:0; padding:0;height:90px; width:300px;background-color:#C70039;">
		        <center><legend><asp:Label id="Label28" runat="server" Font-Size="14px" Text="LLAMADA EN PROGRESO" style="font-family:'coda';"></asp:Label></legend></center>
		        <center>
                    <table style="background:black;">
                        <tr>
                        <td width="5px"></td>
                        <td>
                            <img ID="img2" style="width:60px;height:60px" src="Imagenes/btn_call_1.gif" />
                        </td>
                        <td width="25px"></td>
                        <td align="center">
                        <asp:Label ID="lblNunmTelfC" style="color:White; font-family:'coda'; font-size:xx-large;" runat="server" ></asp:Label>
                        </td>
                        <td width="25px"></td>
                        <td>
                        <img ID="img1" style="width:40px;height:40px" onclick="cerrarpanel();" src="Imagenes/colgar1.png"/>
                        </td>
                        <td width="10px"></td>
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
    <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1" DisplayAfter="1">
	<ProgressTemplate>
        <div class="loading"></div>        
    </ProgressTemplate>
    </asp:UpdateProgress>
    
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
