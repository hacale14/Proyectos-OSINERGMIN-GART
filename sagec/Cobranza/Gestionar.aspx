<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Gestionar.aspx.vb" Inherits="Cobranza.Gestionar"%>

<%@ Register src="Controles/CtlGrilla.ascx" tagname="CtlGrilla" tagprefix="uc1" %>

<%@ Register src="Controles/CtCombo.ascx" tagname="CtCombo" tagprefix="uc2" %>

<%@ Register src="Controles/CtlTxt.ascx" tagname="CtlTxt" tagprefix="uc3" %>

<%@ Register src="Controles/CtlCboCartera.ascx" tagname="CtlCboCartera" tagprefix="uc4" %>

<%@ Register src="Controles/CtlLlamando.ascx" tagname="CtlLlamando" tagprefix="uc5" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Pantalla de Gestion al Cliente</title>
    <meta http-equiv="content-type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="Estilos.css" type="text/css" />
    <link href="style/style.css" rel="stylesheet" type="text/css" />
    <link href="calendar-blue.css" rel="stylesheet" type="text/css" />    
    <script src="scripts/gridview.js" type="text/javascript"></script>
    <link href="style/gridview.css" rel="stylesheet" type="text/css" />
    
    <script type="text/javascript">
    function redireccionar(){
    location.href="Principal.aspx";
    } 
    </script>
    
    <style>
        ._css3m
        {
            display: none;
        }
        gr
    </style>
    
    
    
    <style type="text/css">
    #vertgraph {                    
        width: 378px; 
        height: 207px; 
        position: relative; 
        background: url("g_backbar.gif") no-repeat; 
    }
    #vertgraph ul { 
        width: 378px; 
        height: 207px; 
        margin: 0; 
        padding: 0; 
    }
    #vertgraph ul li {  
        position: absolute; 
        width: 28px; 
        height: 160px; 
        bottom: 34px; 
        padding: 0 !important; 
        margin: 0 !important; 
        background: url("g_colorbar3.jpg") no-repeat !important;
        text-align: center; 
        font-weight: bold; 
        color: white; 
        line-height: 2.5em;
    }

    #vertgraph li.critical { left: 24px; background-position: 0px bottom !important; }
    #vertgraph li.high { left: 101px; background-position: -28px bottom !important; }
    #vertgraph li.medium { left: 176px; background-position: -56px bottom !important; }
    #vertgraph li.low { left: 251px; background-position: -84px bottom !important; }
    #vertgraph li.info { left: 327px; background-position: -112px bottom !important; }
    </style>
	
    
    
    <script language="javascript" type="text/javascript"> 
    function url(url,parametro,titulo,ancho,alto) {
    newwindows=window.open(url + '?palabra=' + parametro + '&titulo=' + titulo ,'PopUp','top=50,left=50,width=1100,height=800,status=yes,resizable=yes,scrollbars=yes');
    if (window.focus) {newwindows.focus()}
        if (!newwindows.closed) {newwindows.focus()}
        return false;
    }

    </script>

    
    

    <script type="text/javascript">   
            function validarLetras(e) { // 1
            tecla = (document.all) ? e.keyCode : e.which;
            if (tecla == 8) return true; // backspace
            if (tecla == 32) return true; // espacio
            if (tecla == 9) return true; // espacio
           // if (tecla == 13) return true; // espacio
            
            if (e.ctrlKey && tecla == 86) { return true; } //Ctrl v
            if (e.ctrlKey && tecla == 67) { return true; } //Ctrl c
            if (e.ctrlKey && tecla == 88) { return true; } //Ctrl x
    
            patron = /[a-zA-Z]/; //patron

            te = String.fromCharCode(tecla);
            return patron.test(te); // prueba de patron
        }
        function validarNumeros(e) { // 1
            tecla = (document.all) ? e.keyCode : e.which; // 2
            if (tecla == 8) return true; // backspace
            if (tecla == 109) return true; // menos
            if (tecla == 110) return true; // punto
            if (tecla == 189) return true; // guion
            if (tecla == 9) return true; // guion
           //   if (tecla == 13) return true; // espacio      
            if (e.ctrlKey && tecla == 86) { return true }; //Ctrl v
            if (e.ctrlKey && tecla == 67) { return true }; //Ctrl c
            if (e.ctrlKey && tecla == 88) { return true }; //Ctrl x
            if (tecla >= 96 && tecla <= 105) { return true; } //numpad
            patron = /[0-9]/; // patron
            te = String.fromCharCode(tecla);
            return patron.test(te); // prueba
        }
       validateSpecialCharsStep2 = function() {
    var characterReg = /[`~!@#$%^&*()_°¬|+\-=?;:'",.<>\{\}\[\]\\\/]/gi;
    $('#roomClientFirstName_1').bind("keydown", function(event){		
		var inputVal = $(this).val();		
		if(characterReg.test(inputVal)) {			
			$(this).val(inputVal.replace(/[`~!@#$%^&*()_|+\-=?;:'",.<>\{\}\[\]\\\/]/gi,''));			
		}
	});
 
}
        function valEmail(valor) {    // Cortesía de http://www.ejemplode.com
            re = /^[_a-z0-9-]+(.[_a-z0-9-]+)*@[a-z0-9-]+(.[a-z0-9-]+)*(.[a-z]{2,3})$/
            if (!re.exec(valor)) {
                return false;
            } else {
                return true;
            }
        }       
        
    </script>
        
    <script type="text/javascript" src="scripts/scriptsSistema.js" charset="iso-8859-1"></script>
    <script type="text/javascript" src="scripts/prototype.js"></script>
    <script type="text/javascript" src="scripts/calendar.js"></script>
    <script type="text/javascript" src="scripts/calendar-utils.js"></script>
    <script type="text/javascript" src="scripts/calendar-es.js"></script>   
    <script type="text/javascript" src="jquery.min.js"></script>     
    <script type="text/javascript" src="jquery-ui.min.js"></script> 
    <script type="text/javascript" src="gridviewScroll.min.js"></script>

    <link rel="shortcut icon" href="/img/logo.jpg">
     <script type="text/javascript"
        src="https://www.google.com/jsapi?autoload={'modules':[{'name':'visualization','version':'1','packages':['gauge']}]}">
  </script>
  <script type="text/javascript">
      google.load('visualization', '1', {packages: ['gauge']});
      google.setOnLoadCallback(drawGauge);

      var gaugeOptions = {min: 0, max: 100, yellowFrom: 80, yellowTo: 95,
       greenFrom: 95, greenTo: 100, minorTicks: 5};
      var gauge;

      function drawGauge() {
        gaugeData = new google.visualization.DataTable();
        gaugeData.addColumn('number', 'Cobertura');
        gaugeData.addColumn('number', 'Efectiv.');
        gaugeData.addRows(2);
        gaugeData.setCell(0, 0, <%=Me.Cobertura%>);
        gaugeData.setCell(0, 1, <%=Me.Efectividad%>);

        gauge = new google.visualization.Gauge(document.getElementById('gauge_div'));
        gauge.draw(gaugeData, gaugeOptions);
      }

      function changeTemp(dir) {
        gaugeData.setValue(0, 0, gaugeData.getValue(0, 0) + dir * 25);
        gaugeData.setValue(0, 1, gaugeData.getValue(0, 1) + dir * 20);
        gauge.draw(gaugeData, gaugeOptions);
      }
  </script>
  <script type="text/javascript">
        function GetChar (event){
            var chCode = ('charCode' in event) ? event.charCode : event.keyCode;
            alert ("The Unicode character code is: " + chCode);
        }
        function LlamarTelefono(mensaje,objimg){        
        window.navigate('http://192.168.1.200/llamar.php?anexo=178&telefono=' + mensaje + '&idcliente=0',target="DBox");
        alert('invocado');
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
<body class="fondo2" onkeypress="javascript: teclas(event);">
    <form id="form1" runat="server" style="top:0;left:0;">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">    
        <ContentTemplate>            
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager><center>
        <fieldset style=" padding:0; margin:0; width:20%; height:100%;">
            <legend>
                <center><asp:Label ID="Label14" runat="server" Font-Size="11px" Text="PANTALLA GESTION DE COBRANZA AL CLIENTE"></asp:Label></center>
            </legend>
            <table style="width:100%; padding:0; margin:0;top:0;" >                               
                <tr>
                    <td style="padding:0; margin:0; height:20;">
                            <fieldset style="padding:0; margin:0; width:99%; height:20;">
			                <legend>
					            <asp:Label id="Label8" runat="server" Font-Size="11px" Text="PANTALLA DE GESTION AL CLIENTE"></asp:Label>
					        </legend>
					        <table style="width:800px;height:25px;padding:0;margin:0;">					        
					        <tr>                                
					            <td><asp:Label ID="Label1" runat="server" Text="Label"></asp:Label></td>
					            <td></td>
					            <td></td>
					            <td></td>
					            <td></td>
					            <td></td>
					            <td></td>
                                <td></td>
                                <td>GESTOR: </td>
					            <td align="Left" style="background-color:#ff6600;"><center></center> <asp:Label BackColor="White" ID="Label4" runat="server" Width="40px" Text="MA"></asp:Label></center></td>
                            </tr>
					        
					        <tr>
					        <td valign="bottom">CARTERA</td>
					        <td valign="bottom">C.INT</td>
					        <td valign="bottom">C.EXT</td>
					        <td valign="bottom">TIPO C.</td>
					        <td valign="bottom">SITUAC.</td>
					        <td rowspan=2 valign="middle"><div class="curvop"><asp:ImageButton id="imgBuscar" runat="server" Height="30px" Width="35px" ImageUrl="~/imagenes/boton busqueda.jpg" /><asp:Label id="lblBuscar" runat="server" Font-Size="11px" Text="Buscar"></asp:Label></div></td>
					        <td valign="bottom">DNI</td>
					        <td valign="bottom">NOMBRE DE CLIENTE</td>					        					        					        
					        <td rowspan="2" valign="middle"><div class="curvop"><asp:ImageButton id="ImageButton1" runat="server" Height="30px" Width="25px" ImageUrl="~/imagenes/campo.png" /><asp:Label id="Label2" runat="server" Font-Size="11px" Text="Campo"></asp:Label></div></td>
                            <td rowspan="2" valign="middle"><div class="curvop"><asp:ImageButton id="ImageButton2" runat="server" Height="30px" Width="25px" ImageUrl="~/imagenes/botonGrabar.png" /><asp:Label id="Label3" runat="server" Font-Size="11px" Text="Grabar"></asp:Label></div></td>					        
					        
					        </tr>
					        
					        <tr>
					        
					        <td><uc2:CtCombo ID="cbocartera" runat="server" Condicion="" Procedimiento="QRYCG002"/></td>
					        <td><uc2:CtCombo ID="cbocint" runat="server" Condicion="" Procedimiento="QRYCGC001"/></td>
					        <td><uc3:CtlTxt ID="txtcext" runat="server" Ancho="50"/></td>
					        <td><uc2:CtCombo ID="cbotipoc" Longitud="50" runat="server" /></td>
					        <td><uc3:CtlTxt ID="txtsitua" runat="server" Ancho="40"/></td>
					        <td><uc3:CtlTxt ID="txtDNI" runat="server" Ancho="100"/></td>
					        <td><uc3:CtlTxt ID="txtnombre" runat="server" Ancho="100"/></td>                            
					        </tr>
					        </table>					        
					        					        
					    </fieldset>
				    </td>
                </tr>
                <tr>
                <td>               
                <table style="padding:0; margin:0; width: 100%;">
                    <tr>
                    <td style="width:15%" >
                        <fieldset style=" padding:0; margin:0; width:100%; height:216px;">
                            <legend>
                                <asp:Label ID="Label9" runat="server" Font-Size="11px" Text="TELEFONO"></asp:Label>
                            </legend>                            
                            <uc1:CtlGrilla ID="CtlTelefono" runat="server" Activa_ckeck="false" Activa_option="false" Largo="170px" Ancho="300px" OcultarColumnas="4;5;6;8;9;10;11;12;14;15;17" Desactivar_Exportar="0;1;2;3;4"  Desactiva_Boton="false" Activa_Titulo="false" />                                                        
                        </fieldset></td>
                        <td valign="top">
                        <fieldset style=" padding:0; margin:0; width:70%; height:100px;">
                            <legend>
                                <asp:Label ID="Label5" runat="server" Font-Size="11px" Text="DIRECCION"></asp:Label>
                            </legend>                            
                            <uc1:CtlGrilla ID="CtlDireccion" runat="server" Activa_Delete="true" Activa_Edita="true" Activa_ckeck="false" Activa_option="false" OcultarColumnas="4;5;8;9;10;11;14;15;16;17" OcultarFormatos="true" Ancho="670px" Largo="70px" Desactiva_Boton="false" Activa_Titulo="false"/>                            
                        </fieldset>
&nbsp;<fieldset style=" padding:0; margin:0; width:99%; height:100px;">
                            <legend>
                                <asp:Label ID="Label6" runat="server" Font-Size="11px" Text="Anotacion"></asp:Label>
                            </legend>                            
                            <uc1:CtlGrilla ID="CtlAnotaciones" runat="server" Activa_ckeck="false" Activa_option="false"  Ancho="670px" OcultarFormatos="false" Desactiva_Boton="false" Activa_Titulo="false"/>                            
                        </fieldset>
                        </td>
                        
                        <tr>
                                <td style="width:15%" valign="top">
                                    <fieldset style=" padding:0; margin:0; width:100%; height:85px;">
                                        <legend>
                                            <asp:Label ID="Label7" runat="server" Font-Size="11px" Text="Estadistica"></asp:Label>
                                        </legend>  
                                        <table style="top:0;">
                                        <tr>
                                        <td width=40% valign="top"><div id="gauge_div" style="width:140px; height: 70px;"></div></td>                          
                                        <td width=60% valign="top" ><uc1:CtlGrilla ID="CtlEstadistica" runat="server" Activa_Delete="false" Activa_Edita="false" Activa_ckeck="false" Activa_option="false" Largo="69px" Ancho="155px" OcultarFormatos="false" Desactiva_Boton="false" Activa_Titulo="false"/></td>                            
                                        </tr>
                                        </table>
                                    </fieldset>
                                </td>
                                <td valign="middle" >
                                    <fieldset style=" padding:0; margin:0; width:99%; height:85px;">
                                        <legend>
                                            <asp:Label ID="Label10" runat="server" Font-Size="11px" Text="Datos Adiconales"></asp:Label>
                                        </legend>                            
                                        <table width="100%">
                                        <tr>
                                        <td>Cent.Laboral</td>
                                        <td style="width:27%" >
                                            <uc3:CtlTxt ID="txtCentroLaboral" runat="server" Ancho="200"/>
                                            </td>
                                        <td>1erProd</td>
                                        <td>
                                            <uc3:CtlTxt ID="txt1erProd" runat="server" Ancho="180"/>
                                            </td>
                                        <td>Edad</td>
                                        <td>
                                            <uc3:CtlTxt ID="txtEdad" runat="server" Ancho="50" />
                                            </td>
                                        </tr>
                                        <tr>
                                        <td>Conyugue</td>
                                        <td>
                                            <uc3:CtlTxt ID="txtConyugue" runat="server" Ancho="200"/>
                                            </td>
                                        <td>Aval</td>
                                        <td>
                                            <uc3:CtlTxt ID="txtAval" runat="server" Ancho="180"/>
                                            </td>
                                        <td>Ing.</td>
                                        <td>
                                            <uc3:CtlTxt ID="txtIngreso" runat="server" Ancho="50"/>
                                            </td>
                                        </tr>
                                        <tr>
                                        <td>E.mail</td>
                                        <td colspan="2">
                                            <uc3:CtlTxt ID="txtemail" runat="server" Ancho="282"/>
                                            </td>
                                        <td colspan="3">Rep. Legal:
                                            <uc3:CtlTxt ID="txtRepresentanteLegal" runat="server" Ancho="240"/>
                                            </td>
                                        </tr>
                                        </table>
                                    </fieldset>                        
                                </td>
                                
                            </tr>
                        
                        </tr>
                        </table>
                        </center>
                        <table width="100%" valign="top">
                           <tr>
                           <td valign="top">
                                <fieldset style=" padding:0; margin:0; width:100%; height:150px;">
                                    <legend>
                                        <asp:Label ID="Label11" runat="server" Font-Size="11px" Text="GESTION TELFONICA"></asp:Label>
                                    </legend>                                                                
                                    <uc1:CtlGrilla ID="CtlGestionTelefonica" runat="server" Activa_Delete="true" Activa_Edita="true" Activa_ckeck="false" Activa_option="false" Largo="120px" Ancho="770px" Desactiva_Boton="false" OcultarColumnas="12;13;14;15" Activa_Titulo="false"/>                                                                                            
                                </fieldset>
                           </td>                                    
                           <td rowspan=2 width="20%" valign="top">
                                <fieldset style="padding:0; top:0; margin:0; width:200px; height:240px;">
                                    <legend>
                                        <asp:Label ID="Label12" runat="server" Font-Size="11px" Text="DATOS DE LA DEUDA"></asp:Label>                                     
                                    </legend>                                                            
                                       <table style="top:0;">
                                        <tr>                                        
                                        <td width=60% valign="top" ><uc1:CtlGrilla ID="CtlDeuda" runat="server" Activa_Delete="false" Activa_Edita="false" Activa_ckeck="false" Activa_option="false" Largo="112px" Ancho="190px" OcultarFormatos="false" Desactiva_Boton="false" Activa_Titulo="false"/></td>                            
                                        </tr>
                                        </table>
                                </fieldset>
                           </td>
                           </tr>
                           <tr>
                               <td valign="top">                                    
                                    <fieldset style=" padding:0; margin:0; width:100%; height:80px;">
                                        <legend>
                                            <asp:Label ID="Label13" runat="server" Font-Size="11px" Text="GESTION DE CAMPO"></asp:Label>
                                        </legend>                            
                                        <uc1:CtlGrilla ID="CtlGestionCampo" runat="server" Activa_Delete="true" Activa_Edita="true" Activa_ckeck="false" Activa_option="false" Largo="55px" Ancho="770px" Desactiva_Boton="false" OcultarColumnas="12;13;14;15" Activa_Titulo="false"/>                                                        
                                    </fieldset>
                               </td>                                    
                         </tr>
                      </table>
                   
                </tr>
                <tr>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td>
                        &nbsp;</td>
                </tr>
            </table>  
            </fieldset>                     
            <iframe name="DBox" frameborder="0" style="width:1%;height:1%"></iframe>
            
            
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>    
</body>
</html>
