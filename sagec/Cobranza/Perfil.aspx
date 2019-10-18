<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Perfil.aspx.vb" Inherits="Cobranza.Perfil"  MasterPageFile="~/MasterPage.Master" Title="Lista de Perfiles" %>

<%@ Register src="Controles/CtlTxt.ascx" tagname="CtlTxt" tagprefix="uc1" %>
<%@ Register src="Controles/CtlGrilla.ascx" tagname="CtlGrilla" tagprefix="uc2" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="Contenido">
<asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
<ProgressTemplate>
    <div class="modal2">
        <div class="center">
            <img alt="" src="Imagenes/loader.gif" />
        </div>
    </div>
</ProgressTemplate>
</asp:UpdateProgress>
<asp:UpdatePanel ID="UpdatePanel1" runat="server" >
<ContentTemplate>
<table width="100%" class="fondoPantalla">
<tr>
    <td class="titulo"><asp:Label ID="lblTitulo" runat="server" Text="PERFILES" ForeColor="White"></asp:Label></td>
</tr>
<tr>
    <td>
        <fieldset>
        <table width="100%" border="0">
        <tr>
            <td width="600px"><asp:Label ID="lblNombre" runat="server" Text="NOMBRE DE PERFIL" CssClass="lbl"/></td>
            <td width="170px"><uc1:CtlTxt ID="txtNombre" runat="server" Ancho ="150" /></td>
            <td style="text-align:right" width="200px">
				<div class="curvo">
				    <asp:ImageButton id="btnBuscar" runat="server" ToolTip="Buscar Perfiles" ImageUrl="~/Imagenes/boton busqueda.jpg" CssClass="curvoimg"/>
				    <asp:Label ID="lblBuscar" runat="server" Text="Buscar" CssClass="curvolbl"></asp:Label>
				 </div>
			</td>
			<td></td>
        </tr>
        </table>
        </fieldset>
    </td>
</tr>
<tr>
    <td>
        <fieldset>
            <uc2:CtlGrilla ID="gvPerfiles" runat="server" Ancho="950px" Largo="350px" Activa_ckeck="false" Desactiva_Boton="false" Activa_option="false"  OpocionNuevo="true" />
        </fieldset>
    </td>
</tr>
</table>
</ContentTemplate>
</asp:UpdatePanel>
</asp:Content>
