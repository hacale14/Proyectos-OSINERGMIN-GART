<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="NMUsuario.ascx.vb" Inherits="Controles.NMUsuario" %>

<%@ Register src="~/Controles/CtlGrilla.ascx" tagname="CtlGrilla" tagprefix="uc4" %>
<%@ Register src="~/Controles/CtlTxt.ascx" tagname="CtlTxt" tagprefix="uc1" %>
<%@ Register src="~/Controles/CtCombo.ascx" tagname="CtCombo" tagprefix="uc2" %>

<%@ Register src="CtlMensajes.ascx" tagname="CtlMensajes" tagprefix="uc3" %>

<table width="100%" class="fondoPantalla">
<tr>
    <td class="titulo">
        <asp:Label ID="lblTituloControl" runat="server" Text="" ForeColor="White"></asp:Label>
    </td>
</tr>
<tr>
    <td>
        <fieldset>
	    <legend> ACCESO AL SISTEMA </legend>
	    <table style="width: 100%">
		<tr>
		    <td style="width: 120px"><asp:Label id="lblTipoUsuario" runat="server" Text="TIPO USUARIO"></asp:Label></td>
		    <td style="width: 90px" ><uc2:CtCombo ID="cboTipoUsuario" runat="server" Longitud="90" /></td>
			<td style="width: 55px"><asp:Label id="lblPerfil" runat="server" Text="PERFIL"></asp:Label></td>
			<td><uc2:CtCombo ID="cboPerfil" runat="server" Longitud="90" />
                <uc3:CtlMensajes ID="CtlMensajes1" runat="server" />
                <asp:Label id="lblUbicacionFoto" runat="server" Text="" Visible="false"/>
                <asp:Label id="lblIdUsuario" runat="server" Text="" Visible="false"/>
            </td>
		</tr>
	    </table>
	    </fieldset>
    </td>
</tr>
<tr>
    <td>
        <fieldset style="border: thin groove #808080;">
	    <legend> INFORMACION DEL PERSONAL </legend>
	    <table style="width: 100%">
		<tr>
			<td style="width: 140px">
			    <asp:Label id="lblNombre" runat="server" Text="NOMBRES"></asp:Label>
			</td>
			<td style="width: 140px">
			    <asp:Label id="lblApellidos" runat="server" Text="APELLIDOS"></asp:Label>
			</td>
			<td align="center" rowspan="8">
			    <fieldset>
		            <uc4:CtlGrilla ID="gvSubCartera" runat="server" Ancho="950px" Largo="350px" Activa_ckeck="false" Desactiva_Boton="false" Activa_option="false"  OpocionNuevo="false"/>
		        </fieldset>
			</td>
			<td align="center" rowspan="8">
			<img id="imgFoto" runat="server" height="122" src="" width="126" /><br />
			<asp:FileUpload id="FileUpload1" runat="server" Font-Size="11px" />
			<asp:Button ID="btnSubir" runat="server" Text="Subir" />
			</td>
		</tr>
		<tr>
			<td><uc1:CtlTxt ID="txtNombres" runat="server" ancho="100" /></td>
			<td><uc1:CtlTxt ID="txtApellidos" runat="server" ancho="100" /></td>
		</tr>
		<tr>
			<td><asp:Label id="lblFechaIngreso" runat="server" Text="FECHA INGRESO"></asp:Label></td>
			<td><asp:Label id="lblcargo" runat="server" Text="CARGO"></asp:Label></td>
		</tr>
		<tr>
			<td>
			    <asp:TextBox ID="txtFechaIngreso" runat="server"  Width="80px" Enabled = "false" BackColor="White"/>
                <img ID="fecha1" alt="calendario" height="16" onclick="return showCalendar('fecha1','<%=txtFechaIngreso.ClientID%>','%d/%m/%Y','24', true);" 
                src="Imagenes/calendario.png" width="18" />
			</td>
			<td><uc1:CtlTxt ID="txtCargo" runat="server" ANCHO="100" /></td>
		</tr>
		<tr>
			<td colspan="2">
			<asp:Label id="lbldireccion" runat="server" Text="DIRECCION"></asp:Label>
			</td>
		</tr>
		<tr>
			<td>
                <uc1:CtlTxt ID="txtDireccion" runat="server" ANCHO="100" />
            </td>
			<td>&nbsp;</td>
		</tr>
		<tr>
			<td><asp:Label id="lblTelefono" runat="server" Text="TELEFONO"></asp:Label></td>
			<td><asp:Label id="lblcelular" runat="server" Text="CELULAR"></asp:Label></td>
		</tr>
		<tr>
			<td><uc1:CtlTxt ID="txtTelefono" runat="server" ancho="100" />
            </td>
			<td><uc1:CtlTxt ID="txtCelular" runat="server" ancho="100" /></td>
		</tr>
	</table>
	</fieldset>
    </td>
</tr>
<tr>
    <td>
        <fieldset>
	    <legend> DATOS DE ACCESO </legend>
	    <table style="width: 100%">
		<tr>
			<td><asp:Label id="lblUsuario" runat="server" Text="NOMBRE DE USUARIO"></asp:Label></td>
			<td><asp:Label id="lblPclave" runat="server" Text="ESCRIBIR CLAVE"></asp:Label></td>
			<td><asp:Label id="lblSclave" runat="server" Text="CONFIRMAR CLAVE"></asp:Label></td>
		</tr>
		<tr>
			<td><uc1:CtlTxt ID="txtUsuario" runat="server" ancho="90" /></td>
			<td><asp:TextBox ID="txtContrasena" runat="server" TextMode="Password" MaxLength="10" Width="90px"></asp:TextBox></td>
			<td><asp:TextBox ID="txtValidarContrasena" runat="server" TextMode="Password" MaxLength="10" Width="90px"></asp:TextBox></td>
		</tr>
	    </table>
	    </fieldset>
    </td>
</tr>
<tr>
    <td>
        <table style="width: 100%">
		<tr>
		    <td></td>
			<td style="text-align:right" width="35px">
			    <div class="curvo">
			    <asp:ImageButton id="btnGrabar" runat="server" Height="30px" Width="30px" 
			    ImageUrl="~/Imagenes/BotonGrabar.png"/>
			    <asp:Label ID="lblGrabar" runat="server" Text="Grabar" />
			    </div>
			</td>
			<td style="text-align:right" width="35px">
			    <div class="curvo">
			    <asp:ImageButton id="btnCerrar" runat="server" Height="30px" Width="30px"
			    ImageUrl="~/Imagenes/BotonCerrar.jpg" />
			    <asp:Label ID="lblCerrar" runat="server" Text="Cerrar" />
			    </div>
			</td>
		</tr>
	    </table>
    </td>
</tr>
</table>



	