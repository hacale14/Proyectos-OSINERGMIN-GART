<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="CtlAdmGrupos.ascx.vb" Inherits="Controles.CtlAdmGrupos" %>
<%@ Register src="CtlGrilla.ascx" tagname="CtlGrilla" tagprefix="uc1" %>
<%@ Register src="CtCombo.ascx" tagname="CtCombo" tagprefix="uc3" %>
<%@ Register src="CtlMensajes.ascx" tagname="CtlMensajes" tagprefix="uc3" %>
<%@ Register src="CtlNuevoGrupo.ascx" tagname="CtlNuevoGrupo" tagprefix="uc4" %>
<table style="width: 100%;" align="center">
<tr>
<td align="center" class="titulo">
    GRUPOS
    <uc3:CtlMensajes ID="CtlMensajes1" runat="server" />
</td>
</tr>
</table>

<table style="width: 100%">
	<tr>
		<td style="width:100%;">
		<center>
		<fieldset style="width:1000px;">
			<table style="width:100%;">
				<tr>
				        <td></td>
				        <td style="width:70px">
					        <asp:Label id="Label1" runat="server" CssClass="lbl" Text="CODIGO"></asp:Label>
					    </td>
					    <td style="width:170px">
                            <asp:TextBox id="txtIdGrupo" runat="server" CssClass="textoContenido" Width="150"></asp:TextBox>									
                        </td>
				        <td style="width:70px">
					        <asp:Label id="Label3" runat="server" CssClass="lbl" Text="GRUPOS"></asp:Label>
					    </td>
					    <td style="width:170px">
                            <asp:TextBox id="txtEmpresa" runat="server" CssClass="textoContenido" Width="150"></asp:TextBox>									
                        </td>
                        <td style="width:70px">
					        <asp:Label id="Label2" runat="server" CssClass="lbl" Text="EMPRESA"></asp:Label>
					    </td>
					    <td style="width:200px">
                            <uc3:CtCombo ID="cboEmpresa" runat="server" Longitud="190" />
                        </td>
                        <td style="width:10px;"></td>
				        <td style="text-align:right" width="50px" >
					        <div class="curvo">
					            <asp:ImageButton id="imgBuscar" runat="server" CssClass="curvoimg" ImageUrl="~/imagenes/boton busqueda.jpg" />
					            <asp:Label id="Label14" runat="server" CssClass="curvolbl" Text="Buscar"></asp:Label>
					        </div>
					    </td>
					    <td></td>
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

<asp:Panel ID="pnlGrupo" runat="server" Visible="false">
<div style="position:absolute; top:200px; left:30%;" class="fondo1">
<table>
<tr>
<td>
    <uc4:CtlNuevoGrupo ID="NuevaGrupo" runat="server" />
</td>
</tr>
</table>
</div>
</asp:Panel>
