<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="AdministracionEmpresa.ascx.vb" Inherits="Controles.AdministracionEmpresa" %>
<%@ Register src="CtlGrilla.ascx" tagname="CtlGrilla" tagprefix="uc1" %>
<%@ Register src="NuevaEmpresa.ascx" tagname="NuevaEmpresa" tagprefix="uc2" %>
<%@ Register src="CtCombo.ascx" tagname="CtCombo" tagprefix="uc3" %>

<%@ Register src="CtlMensajes.ascx" tagname="CtlMensajes" tagprefix="uc3" %>
<table style="width: 100%;" align="center">
<tr>
<td align="center" class="titulo">
    EMPRESA
    <uc3:CtlMensajes ID="CtlMensajes1" runat="server" />
</td>
</tr>
</table>

<center>
<table>
	<tr>
		<td>
		<center>
		<fieldset>
			<table style="width:100%;">
				<tr>
				   <td align="center" style="width:50px">
				       <asp:Label id="Label1" runat="server" CssClass="lbl" Text="CODIGO"></asp:Label>
				   </td>
				   <td style="width:200px;">
                       <asp:TextBox id="txtIdEmpresa" runat="server" Width="150px" CssClass="textoContenido"></asp:TextBox>									
                   </td>
                   <td style="width:50px;"></td>
				    <td style="text-align:right" width="50px" rowspan="3">
				        <div class="curvo">
				            <asp:ImageButton id="imgBuscar" runat="server" CssClass="curvoimg" ImageUrl="~/imagenes/boton busqueda.jpg" />
				            <asp:Label id="Label14" runat="server" CssClass="curvolbl" Text="Buscar"></asp:Label>
				    </td>
               </tr>
               <tr><td style="height:10px;"></td></tr>
               <tr>
                    <td align="center" style="width: 50px">
				        <asp:Label id="Label3" runat="server" CssClass="lbl" Text="EMPRESA"></asp:Label>
				    </td>
				    <td style="width:200px;">
                       <asp:TextBox id="txtEmpresa" runat="server" Width="150px" CssClass="textoContenido"></asp:TextBox>									
                    </td>
				</tr>
			</table>
	    </fieldset>
	    </center>
		</td>
	</tr>
	<tr>
		<td>
		<center>
		<fieldset>
		    <center>		    
		    <uc1:CtlGrilla ID="CtlGrilla1" runat="server" Largo="300px" Ancho="500px" Activa_ckeck="false" Activa_option="false" Desactiva_Boton="false" OpocionNuevo="true"/>		    
		    </center>
	    </fieldset>
	    </center>
		</td>
	</tr>
</table>
</center>

<asp:Panel ID="pnlNuevaEmpresa" runat="server" Visible="false">
<div style="position:absolute; top:200px; left:30%;" class="fondo1">
<table>
<tr>
<td>
    <uc2:NuevaEmpresa ID="NuevaEmpresaN" runat="server" titulo="NUEVA Empresa" />
</td>
</tr>
</table>
</div>
</asp:Panel>

<asp:Panel ID="pnlModificaEmpresa" runat="server" Visible="false">
<div style="position:absolute; top:200px; left:30%;" class="fondo1">
<table>
<tr>
<td>
    <uc2:NuevaEmpresa ID="NuevaEmpresaM" runat="server" titulo="NUEVA Empresa" />
</td>
</tr>
</table>
</div>
</asp:Panel>