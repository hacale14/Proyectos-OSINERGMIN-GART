<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="CtlReasignarGestor.ascx.vb" Inherits="Controles.CtlReasignarGestor" %>

<%@ Register src="CtlTxt.ascx" tagname="CtlTxt" tagprefix="uc1" %>
<%@ Register src="CtlGrilla.ascx" tagname="CtlGrilla" tagprefix="uc5"%>
<%@ Register src="CtCombo.ascx" tagname="CtCombo" tagprefix="uc2" %>

<%@ Register src="CtlMensajes.ascx" tagname="CtlMensajes" tagprefix="uc3" %>

<table cellpadding="0" width="100%" cellspacing="0" class="fondoPantalla">
<tr>
    <td class="titulo">
        <center>
            <uc3:CtlMensajes ID="CtlMensajes1" runat="server" />
            <asp:Label ID="lblIdCliente" runat="server" Visible="false"></asp:Label>
            <asp:Label ID="lblIdUsuario" runat="server" Visible="false"></asp:Label>
            <asp:Label ID="lblIdUsuarioCliente" runat="server" Visible="false"></asp:Label>            
            
            <asp:Label ID="lblTituloControl" runat="server" Text="REASIGNAR GESTORES" ForeColor="White" Font-Bold="true" Font-Size="16px"></asp:Label>
        </center>
    </td>
</tr>
</table>

<table width="500px;">
<tr>
    <td colspan="2">
        <center>
        <fieldset>
            <table border="0" width="100%">
                <td>
                    <asp:Label ID="lblClienteDNI" runat="server" text="DNI CLIENTE" CssClass="lbl" />
                </td>
                <td>
                    <uc1:CtlTxt ID="txtCienteDNI" runat="server" Ancho="150"/>
                </td>
                <td>
                    <div class="curvo">
	                    <asp:ImageButton id="btnBuscar" runat="server" CssClass="curvoimg" ToolTip="Buscar" ImageUrl="~/Imagenes/BotonBusquedaPequena.png"/>
                        <asp:Label id="lblBuscar" runat="server" CssClass="curvolbl" Text="Buscar"></asp:Label>
                    </div>
                </td>
            </table>
        </fieldset>
        </center>
    </td>
</tr>
</table>

<table>
<tr>
    <td>
        <fieldset>
            <legend> Clientes Encontrados</legend>
                <table width="100%" cellpadding="0" cellspacing="0">
                <tr>
                    <td colspan="4">
                        <uc5:CtlGrilla ID="CtlClenteAsignado" runat="server" Activa_ckeck="false" Activa_option="false" Desactiva_Boton="false" Activa_Titulo="false" Largo="165px" Ancho="800"  With_Grilla="800px" Activa_Delete="false" Desactivar_Exportar="0;1;2;3;4" Activa_Edita="true" OpocionNuevo="true"/>
                    </td>
                </tr>        
                </table>
        </fieldset>
    </td>
</tr>
</table>

<table width="500px;">
<tr>
    <td>
    <center>
    <fieldset>
        <table width="100%">
            <tr>
                <td style="width:100px;">
                    <asp:Label ID="lblCambiarGestor" runat="server" text="CAMBIAR A GESTOR" CssClass="lbl" />
                </td>
                <td style="width:320px;">
                    <uc2:CtCombo ID="cboGestor" runat="server" Procedimiento="QRYCBG002" Condicion="" Longitud="300" />
                </td>
            </tr>
            <tr><td style="height:10px;"></td></tr>
            <tr>
                <td  style="text-align:right;" width="35px" colspan="2">
		            <div class="curvo" style="float:left; margin-left:90px;">
                    <asp:ImageButton id="btnGrabar" runat="server" CssClass="curvoimg" ToolTip="Grabar" ImageUrl="~/Imagenes/BotonGrabar.png"/>
                    <asp:Label id="lblGrabar" runat="server" CssClass="curvolbl" Text="Grabar"></asp:Label>
                    </div>									
                    
		            <div class="curvo" style="float:right; margin-right:90px;">
                    <asp:ImageButton id="BtnCerrar" runat="server" CssClass="curvoimg" ToolTip="Cerrar" ImageUrl="~/Imagenes/BotonCerrar.png"/>
                    <asp:Label id="Label1" runat="server" CssClass="curvolbl" Text="Cerrar"></asp:Label>
                    </div>															 					
	            </td>
            </tr>
        </table>
    </fieldset>
    </center>
    </td>
</tr>
</table>
