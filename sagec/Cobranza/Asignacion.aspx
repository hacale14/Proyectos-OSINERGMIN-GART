<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.Master" CodeBehind="Asignacion.aspx.vb" Inherits="Cobranza.Formulario_web124" 
    title="Asignacion" %>
<%@ Register src="Controles/CtlGrilla.ascx" tagname="CtlGrilla" tagprefix="uc1" %>
<%@ Register src="Controles/CtCombo.ascx" tagname="CtCombo" tagprefix="uc2" %>
<%@ Register src="Controles/CtlMensajes.ascx" tagname="CtlMensajes" tagprefix="uc3" %>
<asp:Content ID="Content2" ContentPlaceHolderID="Contenido" runat="server">
<asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
<ProgressTemplate>
    <div class="modal2">
        <div class="center">
            <img alt="" src="Imagenes/loader.gif" />
        </div>
    </div>
</ProgressTemplate>
</asp:UpdateProgress>

<asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>
<asp:Label ID="lblSQL_Activo" runat="server" Visible="false"></asp:Label>
<asp:Label ID="lblTipo" runat="server" Visible="false"></asp:Label>

    <table style="width: 100%;" align="center">
        <tr>
            <td align="center" class="titulo">
                ASIGNACION
                <uc3:CtlMensajes ID="CtlMensajes1" runat="server" />
            </td>
        </tr>
    </table>
    
    <table style="width: 100%;" align="center">
        <tr>
            <td>   
                <fieldset>
                <center>
                    <table width="45%" border="0">
                        <tr>
                            <td>
                                <asp:Label id="Label2" runat="server" CssClass="lbl" Text="EMPRESA"></asp:Label>
                            </td>
                            <td>
                                <uc2:CtCombo ID="cboEmpresa" runat="server" AutoPostBack="true" Procedimiento="QRYMG002" Longitud="200" />                
                            </td>
                            <td>
                                <asp:Label id="Label1" runat="server" CssClass="lbl" Text="CARTERA"></asp:Label>
                            </td>
                            <td>
                                <uc2:CtCombo ID="cboCartera" runat="server" AutoPostBack="true" Procedimiento="QRYC014" Longitud="200"/>                
                            </td>
                        </tr>
                    </table>
                </center>
                </fieldset>             
            </td>
        </tr>
        <tr>
            <td>   
                <fieldset>
                    <uc1:CtlGrilla ID="gvTablaGenera" runat="server" Activa_ckeck="false" Activa_Delete="false" Activa_Edita="false" Activa_Export="false" Activa_option="false" Desactiva_Boton="false" OpocionNuevo="false" Largo="80px" />                
                </fieldset>            
            </td>
        </tr>
        <tr>
            <td>
                <fieldset>
                <table width="100%" border="0">
                    <tr>
                        <td>
                            <asp:Label id="Label3" runat="server" CssClass="lbl" Text="INICIO"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtRangoInicio" runat="server" Width="80px" CssClass="textoContenido"></asp:TextBox>
                        </td>
                        <td>
                            <asp:Label id="Label4" runat="server" CssClass="lbl" Text="FIN"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtRangoFin" runat="server" Width="80px" CssClass="textoContenido"></asp:TextBox>
                        </td>
                        <td>
                            <asp:Label id="Label5" runat="server" CssClass="lbl" Text="GESTOR"></asp:Label>
                        </td>
                        <td>
                            <uc2:CtCombo ID="cboGestor" runat="server" Procedimiento="SQL_N_GEST052" Longitud="210"/>                
                        </td>
                        <td>
                            <asp:Label id="Label6" runat="server" CssClass="lbl" Text="TIPO"></asp:Label>
                        </td>
                        <td>
                            <uc2:CtCombo ID="cboTipo" runat="server" Procedimiento="SQL_N_GEST006" Longitud="150"/>                
                        </td>
                        <td>
                            <asp:Label id="Label7" runat="server" CssClass="lbl" Text="DNI"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtDNI" runat="server" Width="80px" CssClass="textoContenido"></asp:TextBox>
                        </td>
                        <td>
                            <asp:Label ID="lblMensaje" runat="server" Text="Dejar gestor y tipo en blanco para utilizar los clientes que no fueron asignados" ForeColor="black"></asp:Label>
                        </td>
                    </tr>                
                </table>
                </fieldset>
            </td>
        </tr>
        <tr>
            <td>
                <fieldset>
                    <table border="0" width="100%">
                        <tr>
                            <td>
                                <asp:Label id="Label8" runat="server" CssClass="lbl" Text="GESTOR ASIGNADO"></asp:Label>
                            </td>
                            <td style="width:230px;">
                                <uc2:CtCombo ID="cboGestorAsigando" runat="server" Procedimiento="SQL_N_GEST057" Longitud="210"/>      
                            </td>
                            <td style="width:300px;"></td>
                            <td style="width:40px;">
					            <asp:Button ID="btnAplicar" Text="Aplicar" runat="server" Height="40px" CssClass="curvoaplica" />
                            </td>
                            <td style="width:40px;">
                                <asp:Button ID="btnAceptar" Text="Aceptar" runat="server" Height="40px" CssClass="curvoacepta"/>
                            </td>
                            <td style="width:40px;">
                                <asp:Button ID="btnCancelar" Text="Cancelar" runat="server" Height="40px" CssClass="curvocancela"/>          
                            </td>
                            <td style="width:150px;"></td>
                        </tr>
                    </table>
                </fieldset>
            </td>
        </tr>
        <tr>
            <td>
                <fieldset>
                    <uc1:CtlGrilla ID="gvTemporal" runat="server" Activa_ckeck="false" Activa_Delete="false" Activa_Edita="false" Activa_Export="false" Activa_option="false" Desactiva_Boton="false" OpocionNuevo="false" Largo="400px"/>                
                </fieldset>
            </td>
        </tr>
    </table>



</ContentTemplate>
</asp:UpdatePanel>
</asp:Content>
