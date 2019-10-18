<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.Master" CodeBehind="NUsuario.aspx.vb" Inherits="Cobranza.NUsuario" %>

<%@ Register src="~/Controles/CtlTxt.ascx" tagname="CtlTxt" tagprefix="uc1" %>
<%@ Register src="~/Controles/CtCombo.ascx" tagname="CtCombo" tagprefix="uc2" %>
<%@ Register src="~/Controles/CtlMensajes.ascx" tagname="CtlMensajes" tagprefix="uc3" %>
<%@ Register src="~/Controles/CtlGrilla.ascx" tagname="CtlGrilla" tagprefix="uc4" %>




<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contenido" runat="server">
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
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
<Triggers>
    <asp:PostBackTrigger ControlID="btnMostrar" />
</Triggers>
<ContentTemplate>
<script type="text/javascript">
function jsRemoveWindowLoad() {
    // eliminamos el div que bloquea pantalla
    $("#WindowLoad").remove();
 
}
 
function jsShowWindowLoad(mensaje) {
    //eliminamos si existe un div ya bloqueando
    jsRemoveWindowLoad();
 
    //si no enviamos mensaje se pondra este por defecto
    if (mensaje === undefined) mensaje = "Procesando la información<br>Espere por favor";
 
    //centrar imagen gif
    height = 20;//El div del titulo, para que se vea mas arriba (H)
    var ancho = 0;
    var alto = 0;
 
    //obtenemos el ancho y alto de la ventana de nuestro navegador, compatible con todos los navegadores
    if (window.innerWidth == undefined) ancho = window.screen.width;
    else ancho = window.innerWidth;
    if (window.innerHeight == undefined) alto = window.screen.height;
    else alto = window.innerHeight;
 
    //operación necesaria para centrar el div que muestra el mensaje
    var heightdivsito = alto/2 - parseInt(height)/2;//Se utiliza en el margen superior, para centrar
 
   //imagen que aparece mientras nuestro div es mostrado y da apariencia de cargando
    imgCentro = "<div style='text-align:center;height:" + alto + "px;'><div  style='color:#000;margin-top:" + heightdivsito + "px; font-size:20px;font-weight:bold'>" + mensaje + "</div><img  src='img/load.gif'></div>";
 
        //creamos el div que bloquea grande------------------------------------------
        div = document.createElement("div");
        div.id = "WindowLoad"
        div.style.width = ancho + "px";
        div.style.height = alto + "px";
        $("body").append(div);
 
        //creamos un input text para que el foco se plasme en este y el usuario no pueda escribir en nada de atras
        input = document.createElement("input");
        input.id = "focusInput";
        input.type = "text"
 
        //asignamos el div que bloquea
        $("#WindowLoad").append(input);
 
        //asignamos el foco y ocultamos el input text
        $("#focusInput").focus();
        $("#focusInput").hide();
 
        //centramos el div del texto
        $("#WindowLoad").html(imgCentro);
 
}
</script>
<style type="text/css">
#WindowLoad
{
    position:fixed;
    top:0px;
    left:0px;
    z-index:3200;
    filter:alpha(opacity=65);
   -moz-opacity:65;
    opacity:0.65;
    background:#999;
}
</style>

<table width="100%" class="fondoPantalla">
<tr>
    <td class="titulo" colspan="3">
        <asp:Label ID="lblTitulo" runat="server" Text="INGRESAR NUEVO USUARIO" ForeColor="White"></asp:Label>
        <uc3:CtlMensajes ID="CtlMensajes1" runat="server" />
        <asp:Label id="lblIdUsuario" runat="server" Text="" Visible="false"/>
        <asp:Label id="lblUbicacionFoto" runat="server" Text="" Visible="false"/>
    </td>
</tr>
<tr>
    <td valign="top" align="center">
    <center>
        <fieldset style="width:250px;">
	    <legend> INFORMACION DEL PERSONAL </legend>
	    <table width="100%" height="100%">
	    <tr>
	        <td style="width: 120px"><asp:Label id="lblTipoUsuario" runat="server" Text="TIPO USUARIO: " /></td>
		    <td style="width: 90px" ><uc2:CtCombo ID="cboTipoUsuario" runat="server" Longitud="120" /></td>
	    </tr>
	    <tr>
	        <td><asp:Label id="lblNombre" runat="server" Text="NOMBRES: " /></td>
	        <td width="170px"><uc1:CtlTxt ID="txtNombres" runat="server" ancho="120" /></td>
	        <td><asp:Label id="lblApellidos" runat="server" Text="APELLIDOS: " /></td>
	        <td><uc1:CtlTxt ID="txtApellidos" runat="server" ancho="120" /></td>
	    </tr>
		<tr>
			<td><asp:Label id="lblFechaIngreso" runat="server" Text="FECHA INGRESO: " /></td>
			<td>
			    <asp:TextBox ID="txtFechaIngreso" runat="server"  Width="100px" Enabled = "false" BackColor="White"/>
                <img ID="fecha1" alt="calendario" height="16" onclick="return showCalendar('fecha1','<%=txtFechaIngreso.ClientID%>','%d/%m/%Y','24', true);" src="Imagenes/calendario.png" width="18" />
			</td>
			<td><asp:Label id="lblArea" runat="server" Text="AREA: " /></td>			
			<td><uc2:CtCombo ID="cboArea" runat="server" Longitud="120" AutoPostBack="true"/></td>
			
		</tr>
		<tr>
		    <td><asp:Label id="lblfechacese" runat="server" Text="CESE.: " /></td>
			<td><asp:TextBox ID="txtFechaCese" runat="server"  Width="100px" Enabled = "false" BackColor="White"/>
                <img ID="Img1" alt="calendario" height="16" onclick="return showCalendar('fecha1','<%=txtFechaCese.ClientID%>','%d/%m/%Y','24', true);" src="Imagenes/calendario.png" width="18" /></td>            		    
			<td><asp:Label id="lblcargo" runat="server" Text="CARGO: " /></td>
			<td><uc2:CtCombo ID="cboCargo" runat="server" Longitud="120" /></td>
		</tr>
		<tr>
			<td><asp:Label id="Label1" runat="server" Text="MOTIVO CESE.: " /></td>
		    <td><uc1:CtlTxt ID="txtMotivoCese" runat="server" ancho="120" /></td>
			<td><asp:Label id="lblSexo" runat="server" Text="SEXO: " /></td>
			<td><uc2:CtCombo ID="cboSexo" runat="server" Longitud="120" /></td>
		</tr>
		<tr>
			<td><asp:Label id="lblTelefono" runat="server" Text="TELEFONO: " /></td>
			<td><uc1:CtlTxt ID="txtTelefono" runat="server" ancho="120" /></td>
			<td><asp:Label id="lblcelular" runat="server" Text="CELULAR: " /></td>
			<td><uc1:CtlTxt ID="txtCelular" runat="server" ancho="120" /></td>
		</tr>
		<tr>
			<td><asp:Label id="lbldireccion" runat="server" Text="DIRECCION: " /></td>
			<td colspan="3"><uc1:CtlTxt ID="txtDireccion" runat="server" ANCHO="360" /></td>
		</tr>
		<tr>
			<td><asp:Label id="lblFechaNacimiento" runat="server" Text="FEC. NAC.: " /></td>
			<td><asp:TextBox ID="txtFecNac" runat="server"  Width="100px" Enabled = "false" BackColor="White"/>
                <img ID="fecha2" alt="calendario" height="16" onclick="return showCalendar('fecha1','<%=txtFecNac.ClientID%>','%d/%m/%Y','24', true);" src="Imagenes/calendario.png" width="18" /></td>
            <td><asp:Label id="lblDistrito" runat="server" Text="Distrito: " /></td>
			<td><uc2:CtCombo ID="CboDistrito" runat="server" Longitud="120" /></td>    			
		</tr>
		
		
		<tr>
		    <td colspan=2 width="40%">
		        <fieldset>
	                <legend> DATOS DE ACCESO </legend>
	                <table style="width: 100%">
	                <tr>
			            <td><asp:Label id="lblPerfil" runat="server" Text="PERFIL: "></asp:Label></td>
			            <td><uc2:CtCombo ID="cboPerfil" runat="server" Longitud="120" /></td>
			            <td><asp:Label id="lblUsuario" runat="server" Text="NOMBRE DE USUARIO: " /></td>
			            <td><uc1:CtlTxt ID="txtUsuario" runat="server" ancho="120" /></td>
		            </tr>
		            <tr>
			            <td><asp:Label id="lblPclave" runat="server" Text="ESCRIBIR CLAVE: " /></td>
			            <td><asp:TextBox ID="txtContrasena" runat="server" TextMode="Password" MaxLength="10" Width="120px" /></td>
			            <td><asp:Label id="lblSclave" runat="server" Text="CONFIRMAR CLAVE: " /></td>
			            <td><asp:TextBox ID="txtValidarContrasena" runat="server" TextMode="Password" MaxLength="10" Width="120px" /></td>
		            </tr>
	                    <tr>
                            <td>
                                ANEXO:</td>
                            <td>
                                <asp:TextBox ID="txtAnexo" runat="server" Width="120px" />
                            </td>
                            <td>
                                CARTERA ASTERISK</td>
                            <td>
                                <uc2:CtCombo ID="cboCarteraAsterisk" runat="server" Longitud="120" AutoPostBack="true" Procedimiento="QRYC007" Condicion=""/>                                                                
                            </td>
                        </tr>
						<tr>
                            <td>
                                TONCAL ASTERISK:</td>
                            <td>
                                <asp:TextBox ID="txtTipoTroncal" runat="server" Width="120px" BackColor="#FFFF99" />
                            </td>
                            <td>
                                &nbsp;</td>
                            <td>
                                <asp:Button ID="Button1" runat="server" Text="Desbloquear Sesion" />
                                <br />
                                <asp:Button ID="Button2" runat="server" Text="Desbloquear Gestion" />
                            </td>
                        </tr>
	                </table>
	            </fieldset>
		    </td>
		    <td rowspan=2 colspan=2>		  
                <fieldset style="width:200px">
                <legend>CARTERA</legend>
	            <uc4:CtlGrilla ID="gvCartera" runat="server" Ancho="150px" Largo="280px" Activa_Delete="false" Activa_Edita="false"  Activa_ckeck="true" Desactiva_Boton="false" Activa_option="false"  OpocionNuevo="false" OcultarFormatos="false" Desactivar_Paginacion="false" OcultarColumnas="4;6"/>
	            </fieldset>    
		    </td>
		</tr>
		<tr>
		    <td colspan=2>		        
            <fieldset>
            <legend>FOTO DEL USUARIO</legend>
            <div class="curvoG1">
	        <asp:Image ID="imgFoto" runat="server" height="150px" width="150px"/>
	        </div>
	        <br />
	        <asp:FileUpload id="FileUpload1" runat="server" />
	        <asp:Button ID="btnMostrar" runat="server" Text="Cargar" />
	        </fieldset>            
		    </td>
		</tr>		
		<tr>		    		    
			<td colspan=4>
			    <center>
			    <fieldset>
			    <table>
			    <tr>
			    <td>
			    <div class="curvo">
			        <asp:ImageButton id="btnGrabar" runat="server" Height="30px" Width="30px" 
			        ImageUrl="~/Imagenes/BotonGrabar.png"/>
			        <asp:Label ID="lblGrabar" runat="server" Text="Grabar" />
			    </div>					
			    </td>
			    <td>
			    <div class="curvo">
			        <asp:ImageButton id="btnCerrar" runat="server" Height="30px" Width="30px"
			        ImageUrl="~/Imagenes/BotonCerrar.jpg" />
			        <asp:Label ID="lblCerrar" runat="server" Text="Cerrar" />
			    </td>
			    </div>
			    </tr>
			    </table>
			    </fieldset>
			    </center>
			</td>
		</tr>		
	</table>
	</fieldset>
	</center>
    </td>        
</tr>

</table>

</ContentTemplate>
</asp:UpdatePanel>
<asp:UpdateProgress ID ="Loader" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
<ProgressTemplate>
        <div class="loading"></div>
</ProgressTemplate>
</asp:UpdateProgress>
</asp:Content>
