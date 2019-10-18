<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="BusquedaAgenda.ascx.vb" Inherits="Controles.BusquedaAgenda" %>

<%@ Register src="~/Controles/CtlGrilla.ascx" tagname="CtlGrilla" tagprefix="uc1" %>
<%@ Register src="~/Controles/CtCombo.ascx" tagname="CtCombo" tagprefix="uc2" %>
<%@ Register src="~/Controles/CtlTxt.ascx" tagname="CtlTxt" tagprefix="uc3" %>
<%@ Register src="~/Controles/Botones.ascx" tagname="Botones" tagprefix="uc4" %>

<table width="100%" cellpadding="0" cellspacing="0" id="TablaPrincipal" runat="server">
<tr>
    <td class="titulo">
        <center>
            <asp:Label ID="lblTituloControl" runat="server" Text="REPORTE AGENDA"></asp:Label>
        </center>
    </td>
</tr>
</table>
<center>
<table width="65%" >
<tr>
    <td>
        <fieldset>
	    <legend><asp:Label id="lblTituloGrupo" runat="server" Font-Size="11px" Text="FILTRAR POR"></asp:Label></legend>
	    <table style="width: 100%" cellpadding="0" cellspacing="0" border="0">
		<tr>
			<td >
			    <asp:Label ID="lblCartera" runat="server" Text="CARTERA" CssClass="lbl" style="padding-right:80px;"/>
			</td>
			<td >
			    <asp:Label ID="lblGestor" runat="server" Text="GESTOR" CssClass="lbl" style="padding-right:82px;"/>
			</td>
			<td >
			    <asp:Label ID="lblEstado" runat="server" Text="ESTADO" CssClass="lbl" style="padding-right:85px;"/>
			</td>
			<td style="text-align:center" rowspan="3">
			    <div class="curvo">
			        <asp:ImageButton ID="btnBuscar" runat="server" ImageUrl="~/Imagenes/BotonBusquedaPequena.png" ToolTip="Buscar" CssClass="curvoimg"  />
			        <asp:Label ID="lblBuscar" runat="server" text="Buscar" CssClass="curvolbl" />
			    </div>
			</td>
		</tr>
		<tr><td style="height:5px;"></td></tr>
		<tr>
			<td>
			    <uc2:CtCombo ID="cboCartera" runat="server" Longitud="200" AutoPostBack="true" Procedimiento="QRYCG002" />
			</td>
			<td>
			    <uc2:CtCombo ID="cboGestor" runat="server" Longitud="200"  Activa="false" />
			</td>
			<td>
			    <uc2:CtCombo ID="cboEstado" runat="server" Longitud="200"  AutoPostBack="false" Activa="false" Procedimiento="AGE002"/>
			</td>			
		</tr>
	</table>
	</fieldset>  
    </td>
</tr>
</table>

<table width="100%">
<tr>
    <td>
        <fieldset>
        <uc1:CtlGrilla ID="gvPrincipal" runat="server" Desactiva_Boton="false" Activa_option="false" largo="350px" Ancho="970px" Visualizar_Img="true" Visualizar_ChkBox="false" Activa_Edita="false" Activa_Delete="false" Activa_ckeck="false"/>
        </fieldset>
    </td>
</tr>
</table>
</center>

