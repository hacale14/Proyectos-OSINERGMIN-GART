<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="CtlModificarAsignacion.ascx.vb" Inherits="Controles.CtlModificarAsignacion" %>
<%@ Register src="CtlTxt.ascx" tagname="CtlTxt" tagprefix="uc1" %>
<%@ Register src="CtCombo.ascx" tagname="CtCombo" tagprefix="uc2" %>

<%@ Register src="CtlMensajes.ascx" tagname="CtlMensajes" tagprefix="uc3" %>

<table width="100%" class="fondoPantalla">
<tr>
    <td class="titulo">
    <center>
    <asp:label id="lblTituloControl" runat="server" font-size="20px" forecolor="white" text="MODIFICAR ASIGNACION" />
    </center>
    </td>
</tr>
<tr>
    <td>
        <fieldset>
        <table width="100%">
        <tr>
            <td width="150px"><asp:RadioButton ID="RDBCliente" runat="server" Text="CLIENTE ACTUAL" GroupName="GrpRDB" AutoPostBack="true" OnCheckedChanged="ChangeOption" /></td>
            <td><uc1:CtlTxt ID="txtCliente" runat="server" Ancho="200" Desactiva="false" /></td>
        </tr>
        <tr>
            <td><asp:RadioButton ID="RDBAllSearch" runat="server" Text="TODOS LOS CLIENTES FILTRADOS" GroupName="GrpRDB" AutoPostBack="true" OnCheckedChanged="ChangeOption" /></td>
            <td><asp:Label ID="lblIdUsuarioCliente" runat="server" Text="" Visible="false"></asp:Label>
            <asp:Label ID="lblTotalCliente" runat="server" Text="" Visible="false"></asp:Label>
            <asp:Label ID="lblTituloPrincipal" runat="server" Text="" Visible="false"></asp:Label>
                <uc3:CtlMensajes ID="CtlMensajes1" runat="server" />
            </td>
        </tr>
        <tr>
            <td><asp:RadioButton ID="RDBRangeSearch" runat="server" Text="LOS CLIENTES FILTRADOS: " GroupName="GrpRDB" AutoPostBack="true" OnCheckedChanged="ChangeOption" /></td>
            <td><asp:Label ID="lblIdCliente" runat="server" Text="" Visible="false"></asp:Label></td>
        </tr>
        <tr>
            <td colspan="2">
            <table width="100%">
            <tr>
                <td><asp:Label ID="lblDesde" runat="server" Text="DE: " /></td>
                <td><uc1:CtlTxt ID="txtDesde" runat="server" Ancho="90" Desactiva="false" /></td>
                <td><asp:Label ID="lblHasta" runat="server" Text="HASTA: " /></td>
                <td><uc1:CtlTxt ID="txtHasta" runat="server" Ancho="90" desactiva="false"/></td>
            </tr>
            </table>
            </td>
        </tr>
        </table>
        </fieldset>
    </td>
</tr>
<tr>
    <td>
    <center>
    <asp:Label ID="lblGestor" runat="server" Text="GESTOR" ForeColor="White"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;
    <uc2:CtCombo ID="cboGestor" runat="server" Longitud="60" />
    </center>
    </td>
</tr>
<tr>
    <td>
    <table width="100%" cellspacing="0" cellpadding="0">
    <tr>
        <td></td>
        <td  style="text-align:right;" width="35px">
			<div class="curvo">
            <asp:ImageButton id="btnGrabar" runat="server" Height="30px" Width="30px" ToolTip="Grabar" 
            ImageUrl="~/Imagenes/BotonGrabar.png"/>
            <asp:Label id="lblGrabar" runat="server" Font-Size="11px" Text="Grabar"></asp:Label>
            </div>															 					
		</td>
        <td style="text-align:right;" width="35px">
			<div class="curvo">
		        <asp:ImageButton id="btnCerrar" runat="server" Height="30px" Width="30px" ImageUrl="~/Imagenes/BotonCerrar.jpg" ToolTip="Click para cerrar pagos" />
		        <asp:Label id="lblCerrar" runat="server" Font-Size="9px" Text="Cerrar"></asp:Label>
		    </div>															 							           					
		</td>
    </tr>
    </table>
    </td>
</tr>
</table>