<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.Master" CodeBehind="Usuario.aspx.vb" Inherits="Cobranza.Usuario" 
    title="Usuarios" %>
    
<%@ Register src="~/Controles/CtlGrilla.ascx" tagname="CtlGrilla" tagprefix="uc1" %>
<%@ Register src="~/Controles/CtCombo.ascx" tagname="CtCombo" tagprefix="uc2" %>
<%@ Register src="~/Controles/CtlTxt.ascx" tagname="CtlTxt" tagprefix="uc3" %>

<%@ Register src="~/Controles/NMUsuario.ascx" tagname="NMUsuario" tagprefix="uc4" %>

<%@ Register src="Controles/CtlMensajes.ascx" tagname="CtlMensajes" tagprefix="uc5" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contenido" runat="server">
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
<Triggers>
    <asp:PostBackTrigger ControlID ="NMUsuario1" />
</Triggers>
<ContentTemplate>


<table class="fondoPantalla" width="100%">
    <tr>
        <td colspan="2" class="titulo">
            <uc5:CtlMensajes ID="CtlMensajes1" runat="server" />
            <asp:Label ID="lblTitulo" runat="server" Text="USUARIOS" ForeColor="White"></asp:Label>
        </td>
    </tr>
	<tr>
		<td colspan="2">
		<fieldset>
		
		<table width= "100%" border="0">
			<tr>
				<td width="100px"><asp:Label id="lblNombre" runat="server" Text="NOMBRES" CssClass="lbl" ></asp:Label></td>
				<td><uc3:CtlTxt ID="txtNombres" runat="server" Ancho="150"/></td><%--textoContenido--%>
				<td width="100px"><asp:Label id="lblApellido" runat="server" Text="APELLIDOS" CssClass="lbl" ></asp:Label></td>
				<td><uc3:CtlTxt ID="txtApellidos" runat="server" Ancho="150" /></td>
                <td width="100px"><asp:Label id="lblPerfil" runat="server" Text="TIPO USUARIO" CssClass="lbl"></asp:Label></td>
                <td ><uc2:CtCombo ID="cboTipoUsuario" runat="server" longitud="150"/></td><%--TextContenido--%>
				<td width="100px"><asp:Label id="lblUsuario" runat="server" Text="USUARIO:" CssClass="lbl"></asp:Label></td>
				<td><uc3:CtlTxt ID="txtUsuario" runat="server" Ancho="150" /></td>
				<td width="200px">
				<div class="curvo">
				    <asp:ImageButton id="btnBuscar" runat="server" ToolTip="Buscar Usuarios" ImageUrl="~/Imagenes/boton busqueda.jpg" CssClass="curvoimg"/>
				    <asp:Label ID="lblBuscar" runat="server" Text="Buscar" CssClass="curvolbl"></asp:Label>
				 </div>
				</td>
			</tr>
		</table>
		</fieldset></td>
	</tr>
	<tr>
		<td colspan="2">
		<fieldset>
		    <uc1:CtlGrilla ID="gvUsuario" runat="server" Ancho="950px" Largo="350px" Activa_ckeck="false" Desactiva_Boton="false" Activa_option="false"  OpocionNuevo="true" />
		</fieldset>
		</td>
	</tr>
</table>
<div id="DivMantenimiento" runat="server" style="height:auto; width:auto; position: absolute; left:30%; top:30%;">
    <uc4:NMUsuario ID="NMUsuario1" runat="server" visible="false" />
</div>

</ContentTemplate>
</asp:UpdatePanel>
</asp:Content>
