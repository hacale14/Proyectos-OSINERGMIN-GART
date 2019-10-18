<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="CtlCamposBusqueda.ascx.vb" Inherits="Controles.CtlCamposBusqueda" %>

<%@ Register src="~/Controles/CtCombo.ascx" tagname="CtCombo" tagprefix="uc2" %>
<%@ Register src="~/Controles/CtlTxt.ascx" tagname="CtlTxt" tagprefix="uc3" %>
<%@ Register src="CtlMensajes.ascx" tagname="CtlMensajes" tagprefix="uc1" %>

<table style="width: 100%">
        <tr>
            <td class="titulo">
            <center>
                <asp:Label ID="lblTituloControl" runat="server" Text="" ForeColor="White" Font-Bold="true" Font-Size="16px"></asp:Label>
            </center>
            </td>
        </tr>
        <tr>
            <td>
                <fieldset>
                <uc1:CtlMensajes ID="CtlMensajes1" runat="server" />
                <table width="100%" cellpadding="0" cellspacing="0" border="0">
                <tr>
			        <td><asp:Label ID="lblCartera" runat="server" Text="CARTERA" CssClass="lbl" style="align:center;float:none;"/></td>
			        <td><asp:Label ID="lblGestor" runat="server" Text="ASESOR" CssClass="lbl" style="align:center;float:none;"/></td>
			        <td><asp:Label ID="lblCondic" runat="server" Text="CONDIC." CssClass="lbl" style="align:center;float:none;"/></td>
			        <td><asp:Label ID="lblDNI" runat="server" Text="DNI" CssClass="lbl" Visible="false" style="align:center;float:none;"/></td>
			        <td><asp:Label ID="lblRefin" runat="server" Text="REFIN." CssClass="lbl" Visible="false" style="align:center;float:none;" /></td>
			        <td><asp:Label ID="lblCampaña" runat="server" Text="CAMPAÑA" CssClass="lbl" Visible="false" style="align:center;float:none;" /></td>
			        <td><asp:Label ID="lblProducto" runat="server" Text="PRODUCTO" CssClass="lbl" Visible="false" style="align:center;float:none;" /></td>
			        <td><asp:Label ID="lblNegocio" runat="server" Text="NEGOCIO" CssClass="lbl" Visible="false" style="align:center;float:none;" /></td>
			        <td><asp:Label ID="lblNroOperacion" runat="server" Text="Nro.OPERACION" CssClass="lbl" Visible="false" style="align:center;float:none;" /></td>
			        <td><asp:Label ID="lblNroCuenta" runat="server" Text="Nro.DE CTA." CssClass="lbl" Visible="false" style="align:center;float:none;" /></td>
			        <td><asp:Label ID="lblCiente" runat="server" Text="NOMBRE DE CLIENTE" CssClass="lbl" style="align:center;float:none;"/></td>
			        <td><asp:Label ID="lblTelefono" runat="server" Text="TELEFONO" CssClass="lbl" Visible="false" style="align:center;float:none;"/></td>
			        <td><asp:Label ID="lblTipoCartera" runat="server" Text="TIPO CART." CssClass="lbl" Visible="false" style="align:center;float:none;"/></td>
			        <td><asp:Label ID="lblDiasMora" runat="server" Text="DIAS MORA" CssClass="lbl" Visible="false" style="align:center;float:none;" /></td>
		        </tr>
		        <tr><td style="height:5px;"></td></tr>
		        <tr>
			        <td><uc2:CtCombo ID="cboCartera" runat="server" Longitud="200" /></td>
			        <td><uc2:CtCombo ID="cboGestor" runat="server" Longitud="200"/></td>
			        <td><uc2:CtCombo ID="cboCondicion" runat="server" Longitud="40"/></td>
			        <td><uc3:CtlTxt ID="txtDNI" runat="server" Ancho="80" Visible="false" /></td>
			        <td><uc3:CtlTxt ID="txtRefin" runat="server" Ancho="40" Visible="false"/></td>
			        <td><uc3:CtlTxt ID="txtCampaña" runat="server" Ancho="80" Visible="false"/></td>
			        <td><uc3:CtlTxt ID="txtProducto" runat="server" Ancho="80" Visible="false"/></td>
			        <td><uc3:CtlTxt ID="txtNegocio" runat="server" Ancho="80" Visible="false"/></td>
			        <td><uc3:CtlTxt ID="txtNroOperacion" runat="server" Ancho="80" Visible="false"/></td>
			        <td><uc3:CtlTxt ID="txtNroCuenta" runat="server" Ancho="80" Visible="false" /></td>
			        <td><uc3:CtlTxt ID="txtCliente" runat="server" Ancho="200" /></td>
			        <td><uc3:CtlTxt ID="txtTelefono" runat="server" Ancho="80" Visible="false"/></td> 
			        <td><uc2:CtCombo ID="cboTipoCartera" runat="server" Longitud="100" Visible="false"/></td>
			        <td><uc2:CtCombo ID="cboDiasMora" runat="server" Longitud="80" Visible="false"/></td>
		        </tr>
		        <tr><td style="height:10px;"></td></tr>
		        <tr>
		            <td style="text-align:center" colspan="2">
			            <center>
			            <table >
			                <tr>
			                    <td class="semaf_x">
			                        APROBADAS
			                        <asp:Button ID="lblAprobadasPropuesta" runat="server" Text="0" CssClass="semaf_btn_p" />
			                    </td>
			                    <td width=10px></td>
			                    <td class="semaf_x">
			                        PENDIENTE
			                        <asp:Button ID="lblPednientesPropuesta" runat="server" Text="0" CssClass="semaf_btn_a"/>
			                    </td>
			                    <td width=10px></td>
			                    <td class="semaf_x">
			                        RECHAZADAS			                    
			                        <asp:Button ID="lblRechazadasPropuesta" runat="server" Text="0" CssClass="semaf_btn_r"/>
			                    </td>
			                </tr>
			            </table>
			            </center>
			        </td>
			        <td style="text-align:center" colspan="11">
			            <div class="curvo">
			                <asp:ImageButton ID="btnBuscar" runat="server" ImageUrl="~/Imagenes/Boton Busqueda.jpg" ToolTip="Buscar" CssClass="curvoimg"  />
			                <asp:Label ID="lblBuscar" runat="server" text="Buscar"  CssClass="curvolbl"/>
			            </div>
			        </td>
		        </tr>
                </table>
                </fieldset>
            </td>
        </tr>
	</table>