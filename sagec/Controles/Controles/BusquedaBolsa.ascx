<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="BusquedaBolsa.ascx.vb" Inherits="Controles.BusquedaBolsa" %>
<%@ Register src="~/Controles/CtlGrilla.ascx" tagname="CtlGrilla" tagprefix="uc1" %>
<%@ Register src="~/Controles/CtCombo.ascx" tagname="CtCombo" tagprefix="uc2" %>
<%@ Register src="~/Controles/CtlTxt.ascx" tagname="CtlTxt" tagprefix="uc3" %>
<%@ Register src="~/Controles/Botones.ascx" tagname="Botones" tagprefix="uc4" %>

<table width="100%" cellpadding="0" cellspacing="0" id="TablaPrincipal" runat="server">
<tr>
    <td class="titulo">
        <center>
            <asp:Label ID="lblTituloControl" runat="server" Text="" ForeColor="White" Font-Bold="true" Font-Size="16px">BUSQUEDA BOLSA</asp:Label>
        </center>
    </td>
</tr>
</table>

<table width="100%">
<tr>
    <td>
        <fieldset>
	    <table cellpadding="0" cellspacing="0" border="0" width="100%">
		<tr>
		    <td rowspan="3"></td>
			<td width="70px">
			    <asp:Label ID="lblCartera" runat="server" Text="CARTERA" CssClass="lbl" />
			</td>
			<td width="270px">
			    <uc2:CtCombo ID="cboCartera" runat="server" Longitud="250" AutoPostBack="true" Procedimiento="QRYCG002" />
			</td>
			<td width="100px">
			    <asp:Label ID="lblEstado" runat="server" Text="ESTADO" CssClass="lbl" />
			</td>
			<td width="220px">
			    <uc2:CtCombo ID="cboEstado" runat="server" Longitud="200"  AutoPostBack="false" Procedimiento="AGE002"/>
			</td>						
			<td width="70px"></td>
			<td style="text-align:center;width:50px;float:none;" rowspan="3">
			    <div class="curvo" style="width:120px;">
			        <asp:ImageButton ID="btnBuscar" runat="server" ImageUrl="~/Imagenes/BotonBusquedaPequena.png" ToolTip="Buscar" CssClass="curvoimg"  />
			        <asp:Label ID="lblBuscar" runat="server" text="Buscar" CssClass="curvolbl" />			        
			    </div>
            </td>
            <td style="text-align:center; width:50px;" rowspan="3">
			    <div class="curvo" style="width:120px;">
			        <asp:ImageButton ID="BtnEliminar" runat="server" ImageUrl="~/Imagenes/BotonEliminar.png" ToolTip="Buscar" CssClass="curvoimg"  />
			        <asp:Label ID="lblEliminar" runat="server" text="Eliminar" CssClass="curvolbl" />
			    </div>
			</td>
			<td></td>			    			
		</tr>
		<tr><td style="height:10px;"></td></tr>
		<tr>
			<td>
			    <asp:Label ID="lblGestor" runat="server" Text="GESTOR" CssClass="lbl" />
			</td>
			<td>
			    <uc2:CtCombo ID="cboGestor" runat="server" Longitud="250"  AutoPostBack="true" />
			</td>
			<td>
			    <asp:Label ID="lblActiva" runat="server" Text="ACTIVA BOLSA" CssClass="lbl" />
			</td>
			<td>
			    <asp:CheckBox ID="chkActivaBolsa" runat="server" AutoPostBack="true" style="margin-right:180px;"/>
			</td>			
		</tr>
	</table>
	</fieldset>  
    </td>
</tr>
<tr>
    <td>       
    </td>   
</tr>
<tr>
    <td>
        <fieldset>
        <uc1:CtlGrilla ID="gvPrincipal" runat="server" Desactiva_Boton="false" Activa_option="false" largo="350px" Ancho="970px" Visualizar_Img="true" Visualizar_ChkBox="false" Activa_Edita="false" Activa_Delete="true" Activa_ckeck="false"/>
        </fieldset>
    </td>
</tr>    
<tr>
    <td style="text-align:center">
        
    </td>
</tr>
</table>
