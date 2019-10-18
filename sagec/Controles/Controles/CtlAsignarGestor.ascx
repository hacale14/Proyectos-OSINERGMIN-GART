<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="CtlAsignarGestor.ascx.vb" Inherits="Controles.CtlAsignarGestor" %>

<%@ Register src="CtCombo.ascx" tagname="CtCombo" tagprefix="uc1" %>
<%@ Register src="CtlTxt.ascx" tagname="CtlTxt" tagprefix="uc2" %>

<%@ Register src="CtlMensajes.ascx" tagname="CtlMensajes" tagprefix="uc3" %>

<table cellpadding="0" width="100%" cellspacing="0" class="fondoPantalla">
<tr>
    <td colspan="2" class="titulo">
        <center>
            <uc3:CtlMensajes ID="CtlMensajes1" runat="server" />
            <asp:Label ID="lblTituloControl" runat="server" Text="ASIGNAR GESTORES" ForeColor="White" Font-Bold="true" Font-Size="16px"></asp:Label>
        </center>
    </td>
</tr>
</table>

<fieldset>
<table border="0" width="400px">
<tr>
    <td colspan="2">
        <asp:Label ID="lblCartera" runat="server" CssClass="lbl" text="CARTERA"/>
    </td>
    <td colspan="2">
        <uc1:CtCombo ID="cboCartera" runat="server" Longitud="200" Procedimiento="QRYC007" Condicion="" AutoPostBack="true" />
    </td>
</tr>
<tr><td style="height:10px;"></td></tr>
<tr>    
    <td colspan="2">
        <asp:Label ID="Label2" runat="server" CssClass="lbl" text="GESTOR"/>
    </td>
    <td colspan="2">
        <uc1:CtCombo ID="cboGestorA" runat="server" Longitud="200" AutoPostBack="true"/>
    </td>    
</tr>    
<tr><td style="height:10px;"></td></tr>
<tr>    
    <td colspan="2">
        <asp:Label ID="Label3" runat="server" CssClass="lbl" text="COND.INTERNA"/>
    </td>
    <td colspan="2">
        <uc1:CtCombo ID="cbocint" runat="server" Longitud="200" Procedimiento="QRYCGC001" AutoPostBack="true"/>
    </td>    
</tr>
<tr><td style="height:10px;"></td></tr>
<tr>
    <td colspan="2">
        <asp:Label ID="lblCantidad" runat="server" CssClass="lbl" text="CANTIDAD DE CLIENTES"/>
    </td>
    <td colspan="2">
        <uc2:CtlTxt ID="txtCantidad" runat="server" Ancho="192" Desactiva="false" />
    </td>
</tr>    
<tr><td style="height:10px;"></td></tr>
<tr>
    <td style="width:10px;">
        <asp:Label ID="lblDe" runat="server" CssClass="lbl" text="DE"/>
    </td>
    <td style="width:110px;">
        <uc2:CtlTxt ID="txtDesde" runat="server" Ancho="120" />
    </td>
    <td style="width:60px;">
        <asp:Label ID="lblHasta" runat="server" CssClass="lbl" text="HASTA"/>
    </td>
    <td style="width:110px;">
        <uc2:CtlTxt ID="txtHasta" runat="server" Ancho="120" />
    </td>
</tr>
<tr><td style="height:10px;"></td></tr>
<tr>
    <td colspan="1">
        <asp:Label ID="lblA" runat="server" CssClass="lbl" Text="A: " />
    </td>
    <td colspan="3">
        <uc1:CtCombo ID="cboGestor" runat="server" Longitud="360" Procedimiento="QRYCBG002" Condicion=""  />
    </td>            
</tr>
<tr><td style="height:20px;"></td></tr>
<tr>
    <td  style="text-align:center;" width="35px" colspan="4">
		<div class="curvo" style="float:left; margin-left:60px;">
        <asp:ImageButton id="btnGrabar" runat="server" CssClass="curvoimg" ToolTip="Grabar" ImageUrl="~/Imagenes/BotonGrabar.png"/>
        <asp:Label id="lblGrabar" runat="server" CssClass="curvolbl" Text="Grabar"></asp:Label>
        </div>												
        
		<div class="curvo" style="float:right;">
        <asp:ImageButton id="BtnCerrar" runat="server" CssClass="curvoimg" ToolTip="Cerrar" ImageUrl="~/Imagenes/BotonCerrar.png"/>
        <asp:Label id="Label1" runat="server" CssClass="curvolbl" Text="Cerrar"></asp:Label>
        </div>															 					
	</td>
</tr>
</table>
</fieldset>
