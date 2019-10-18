<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="Usuario.ascx.vb" Inherits="Controles.Usuario" %>


<%@ Register src="~/Controles/CtlGrilla.ascx" tagname="CtlGrilla" tagprefix="uc1" %>
<%@ Register src="~/Controles/CtCombo.ascx" tagname="CtCombo" tagprefix="uc2" %>
<%@ Register src="~/Controles/CtlTxt.ascx" tagname="CtlTxt" tagprefix="uc3" %>

<%@ Register src="NMUsuario.ascx" tagname="NMUsuario" tagprefix="uc4" %>

<table class="fondoPantalla">
    <tr>
        <td colspan="2" class="titulo">
            <asp:Label ID="lblTitulo" runat="server" Text="USUARIOS" ForeColor="White"></asp:Label>
        </td>
    </tr>
	<tr>
		<td colspan="2">
		<fieldset>
		<legend> FILTRAR POR: </legend>
		<table width= "100%">
			<tr>
				<td width="200px"><asp:Label id="lblNombre" runat="server" Text="NOMBRES Y APELLIDOS" ></asp:Label></td>
                <td width="100px"><asp:Label id="lblPerfil" runat="server" Text="PERFIL"></asp:Label></td>
				<td><asp:Label id="lblUsuario" runat="server" Text="USUARIO"></asp:Label></td>
				<td></td>
				<td style="text-align:right" rowspan="2" width="30px">
				<div class="curvo">
				    <asp:ImageButton id="btnBuscar" runat="server" Height="30px" Width="30px" ToolTip="Buscar Usuarios" ImageUrl="~/Imagenes/BotonBusquedaPequena.png"/>
				    <asp:Label ID="lblBuscar" runat="server" Text="Buscar"></asp:Label>
				 </div>
				</td>
			</tr>
			<tr>
				<td><uc3:CtlTxt ID="txtNombre" runat="server" Ancho="200" /></td>
				<td ><uc2:CtCombo ID="cboPerfil" runat="server" longitud="100" /></td>
				<td><uc3:CtlTxt ID="txtUsuario" runat="server" Ancho="100" /></td>
				<td></td>
			</tr>
		</table>
		</fieldset></td>
	</tr>
	<tr>
		<td colspan="2">
		<fieldset>
		    <uc1:CtlGrilla ID="gvUsuario" runat="server" Ancho="950px" Largo="350px" />
		</fieldset>
		</td>
	</tr>
	<tr>
		<td colspan="2">
		<table width="100%">
		<tr>
		    <td></td>
		    <td style="text-align:right" width="35px">
		        <div class="curvo">
		        <asp:ImageButton id="btnNuevo" runat="server" Height="30px" Width="30px"
		        ImageUrl="~/Imagenes/botonNuevo.jpg" Class="showPopup" />
		        <asp:Label id="lblNuevo" runat="server" Font-Size="9px" Text="Nuevo"></asp:Label>
		        </div>
		    </td>
		</tr>
		</table>
		
		</td>
	</tr>
</table>
<div id="DivMantenimiento" runat="server" style="height:auto; width:auto; position: absolute; left:30%; top:30%;">
    <uc4:NMUsuario ID="NMUsuario1" runat="server" visible="false" />
</div>
