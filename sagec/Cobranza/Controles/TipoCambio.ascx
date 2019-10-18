<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="TipoCambio.ascx.vb" Inherits="Controles.TipoCambio" %>
<%@ Register src="CtlMensajes.ascx" tagname="CtlMensajes" tagprefix="uc1" %>
<%@ Register src="CtCombo.ascx" tagname="CtCombo" tagprefix="uc2" %>
<asp:Label ID="lblId_cartera" runat="server" Visible="false"></asp:Label>
<table style="width: 100%;" align="center">
    <tr align="center">
        <td align="center" style="text-align:center;" class="titulo">
            TIPO DE CAMBIO
            <uc1:CtlMensajes ID="CtlMensajes1" runat="server" />
        </td>
    </tr>
</table>

<center>
<table>
<tr align="center" style="text-align:center;">
<td style="text-align:center; margin:auto;" align="center">
    <fieldset>
    <table style="text-align:center; margin:auto;" border="0" width="350px;">
        <tr>
            <td>
                <asp:Label id="Label5" runat="server" CssClass="lbl" Text="EMPRESA"></asp:Label>
            </td>
            <td>
                <uc2:CtCombo ID="cboEmpresa" runat="server" Procedimiento="QRYMG002" Longitud="200" AutoPostBack="true"/>
            </td>
        </tr>
        <tr><td style="height:10px;"></td></tr>
		<tr>
			<td align="right" style="text-align:right;">
			    <asp:Label id="Label1" runat="server" CssClass="lbl" Text="TIPO DE CAMBIO"></asp:Label>
			</td>
			<td align="center" style="text-align:center;">
			    <asp:TextBox id="TextBox1" runat="server" CssClass="textoContenido" Width="190px"></asp:TextBox>
			    <asp:Label id="lblIdTipoCambio" runat="server" CssClass="lbl" Visible="false"></asp:Label>
			</td>
		</tr>
		<tr><td style="height:10px;"></td></tr>
		<tr>
			<td align="right" style="text-align:right;">
			    <asp:Label id="Label2" runat="server" CssClass="lbl" Text="ÚLTIMA FECHA ACT"></asp:Label>
			</td>
			<td height="30px;">
			    <asp:Label id="Label3" runat="server" CssClass="lbl"></asp:Label>
			</td>
		</tr>
		<tr><td style="height:30px;"></td></tr>
		<tr align="center" style="text-align:center;">
			<td colspan="2" style="padding-right:35px;">
			    <div class="curvo">
			        <asp:ImageButton id="imgGrabar" runat="server" ImageUrl="~/imagenes/BotonGrabar.png" CssClass="curvoimg" />
			        <asp:Label id="Label4" runat="server" CssClass="curvolbl" Text="Grabar"></asp:Label>
			    </div>
			</td>
		</tr>
	</table>
	</fieldset>
</td>
</tr>
</table>
</center>
