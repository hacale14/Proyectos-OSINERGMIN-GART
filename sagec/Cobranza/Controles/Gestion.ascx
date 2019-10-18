<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="Gestion.ascx.vb" Inherits="Controles.Gestion" %>


<%@ Register src="~/Controles/CtlTxt.ascx" tagname="CtlTxt" tagprefix="uc1" %>
<%@ Register src="~/Controles/CtCombo.ascx" tagname="CtCombo" tagprefix="uc2" %>
<%@ Register Src="~/Controles/CtlGrilla.ascx" TagName="CtlGrilla" TagPrefix="uc3" %>


<%@ Register src="Pagos.ascx" tagname="Pagos" tagprefix="uc4" %>


<%@ Register src="Compromisos.ascx" tagname="Compromisos" tagprefix="uc5" %>


<table width="100%" cellpadding="0" cellspacing="0" style="background-color:#045FB4;">
<tr>
    <td colspan="2">
        <fieldset style="background-color:#FAFAFA; border: thin groove #808080;">
        <table width="100%" cellpadding="0" cellspacing="0">
        <tr>
            <td><asp:Label ID="lblGestor" runat="server" Text="GESTOR" ForeColor="Maroon" Font-Size="10px" Font-Bold="true" /></td>
            <td><asp:Label ID="lblCartera" runat="server" Text="CARTERA" ForeColor="Maroon" Font-Size="10px" Font-Bold="true" /></td>
            <td><asp:Label ID="lblCarteraInterna" runat="server" Text="C.INT." ForeColor="Maroon" Font-Size="10px" Font-Bold="true" /></td>
            <td><asp:Label ID="lblCarteraExterna" runat="server" Text="C.EXT." ForeColor="Maroon" Font-Size="10px" Font-Bold="true" /></td>
            <td><asp:Label ID="lblSituacion" runat="server" Text="SITUAC." ForeColor="Maroon" Font-Size="10px" Font-Bold="true" /></td>
            <td><asp:Label ID="lblDNI" runat="server" Text="DNI" ForeColor="Maroon" Font-Size="10px" Font-Bold="true" /></td>
            <td rowspan="2">
                <asp:ImageButton ID="btnBuscar" runat="server" ToolTip="Buscar" ImageUrl="~/Imagenes/BotonBusquedaPequena.png" Width="30px" Height="25px" /><br />
                <asp:Label ID="lblBuscar" runat="server" Text="Buscar" Font-Size="9px" Font-Bold="false" />
            </td>
            <td><asp:Label ID="lblCliente" runat="server" Text="NOMBRES DEL CLIENTE" ForeColor="Maroon" Font-Size="10px" Font-Bold="true" /></td>
            <td rowspan="2">
                <asp:ImageButton ID="btnCampo" runat="server" ToolTip="A Campo" ImageUrl="~/Imagenes/Notas.png" Width="30px" Height="25px" /><br />
                <asp:Label ID="lblCampo" runat="server" Text="A Campo" Font-Size="9px" Font-Bold="false" />
            </td>
            <td rowspan="2">
                <asp:ImageButton ID="btnGrabar" runat="server" ToolTip="Grabar" ImageUrl="~/Imagenes/BotonGrabar.png" Width="30px" Height="25px" /><br />
                <asp:Label ID="lblGrabar" runat="server" Text="Grabar" Font-Size="9px" Font-Bold="false" />
            </td>
        </tr>
        <tr>
            <td><uc1:CtlTxt ID="txtGestor" runat="server" Ancho="40"/></td>
            <td><uc2:CtCombo ID="cboCartera" runat="server" Longitud="40" /></td>
            <td><uc2:CtCombo ID="cboCarteraInterna" runat="server" Longitud="40" /></td>
            <td><uc1:CtlTxt ID="txtCarteraExterna" runat="server" Ancho="40"/></td>
            <td><uc1:CtlTxt ID="txtSituacion" runat="server" Ancho="40"/></td>
            <td><uc1:CtlTxt ID="txtDNI" runat="server" Ancho="100"/></td>
            <td><uc1:CtlTxt ID="txtNombreCliente" runat="server" Ancho="200"/></td>
        </tr>
        </table>
        </fieldset>
    </td>
</tr>
<tr>
    <td width="20%" rowspan="2">
            <uc3:CtlGrilla Titulo="Telefonos" ID="gvTelefonos" runat="server" Activa_Export="false" Desactiva_Boton="false" Activa_ckeck="false" Activa_option="false" OpocionNuevo="true" />
    </td>
    <td>
        <fieldset style="font-size:11px; background-color:#FAFAFA; font-family:Arial; border: thin groove #808080 ">
        <legend>Direcciones</legend>
            <uc3:CtlGrilla ID="gvDirecciones" runat="server" Activa_Export="false" Desactiva_Boton="false" OpocionNuevo="true" />
        </fieldset>
    </td>
</tr>
<tr>
    <td>
        <fieldset style="font-size:11px; color:White; background-color:#FAFAFA; font-family:Arial; border: thin groove #808080 ">
        <legend>Anotaciones</legend>
            <uc3:CtlGrilla ID="gvAnotaciones" runat="server" Activa_Export="false" Desactiva_Boton="false" />
        </fieldset>
    </td>
</tr>
<tr>
    <td>
        <fieldset style="font-size:11px; background-color:#FAFAFA; font-family:Arial; border: thin groove #808080 ">
        <legend>Estadisticas de Avance</legend>
        <table width="100%" cellpadding="0" cellspacing="1">
        <tr>
            <td width="50%"><asp:Label ID="lblTotalGestionesRealizadas" runat="server" Text="Tot.Gest.Realizadas" ForeColor="Maroon" Font-Size="10px" Font-Bold="true" /></td>
            <td rowspan="2">
                    <uc3:CtlGrilla ID="gvTotalGestionesRealizadas" runat="server" Activa_Export="false" Desactiva_Boton="false" />
            </td>
        </tr>
        <tr>
            <td><uc1:CtlTxt ID="CtlTxt1" runat="server" Ancho="100" Desactiva="false"/></td>
        </tr>
        <tr>
            <td><asp:Label ID="lbltotalEfectividad" runat="server" Text="Tot.Efec.Realizadas" ForeColor="Maroon" Font-Size="10px" Font-Bold="true" /></td>
            <td rowspan="2">
                    <uc3:CtlGrilla ID="gvTotalEfectividadRealizadas" runat="server" Activa_Export="false" Desactiva_Boton="false" />
            </td>
        </tr>
        <tr>
            <td><uc1:CtlTxt ID="CtlTxt2" runat="server" Ancho="100" Desactiva="false"/></td>
        </tr>
        </table>
        </fieldset>
    </td>
    <td valign="top">
        <fieldset style="font-size:11px; background-color:#FAFAFA; font-family:Arial; border: thin groove #808080 ">
        <legend>Datos Adicionales</legend>
        <table width="100%" cellpadding="0" cellspacing="1">
        <tr>
            <td><asp:Label ID="lblClab" runat="server" Text="C.Lab." ForeColor="Maroon" Font-Size="10px" Font-Bold="true" /></td>
            <td><uc1:CtlTxt ID="txtCLab" runat="server" Ancho="100"/></td>
            <td><asp:Label ID="lblProducto" runat="server" Text="1er Prod." ForeColor="Maroon" Font-Size="10px" Font-Bold="true" /></td>
            <td><uc1:CtlTxt ID="txtProducto" runat="server" Ancho="100"/></td>
            <td><asp:Label id="lblDeudaTotalSoles" runat="server" Font-Bold="True" Font-Size="10px" ForeColor="Maroon" Text="DEUDA TOTAL S/."></asp:Label></td>
            <td><uc1:CtlTxt ID="txtDeudaTotalSoles" runat="server" Ancho="70" /></td>
            <td><asp:Label id="lblDeudaTotalDolares" runat="server" Font-Bold="True" Font-Size="10px" ForeColor="Maroon" Text="DEUDA TOTAL US$"></asp:Label></td>
            <td><uc1:CtlTxt ID="txtDeudaTotalDolares" runat="server" Ancho="70" /></td>
        </tr>    
        <tr>
            <td><asp:Label ID="lblEdad" runat="server" Text="Edad" ForeColor="Maroon" Font-Size="10px" Font-Bold="true" /></td>
            <td><uc1:CtlTxt ID="txtEdad" runat="server" Ancho="100"/></td>
            <td><asp:Label ID="lblCony" runat="server" Text="Cony." ForeColor="Maroon" Font-Size="10px" Font-Bold="true" /></td>
            <td><uc1:CtlTxt ID="txtCony" runat="server" Ancho="100"/></td>
            <td><asp:Label id="lblDeudaVSoles1" runat="server" Font-Bold="True" Font-Size="10px" ForeColor="Maroon" Text="DEUDA V. S/."></asp:Label></td>
            <td><uc1:CtlTxt ID="txtDeudaVSoles1" runat="server" Ancho="70" /></td>
            <td><asp:Label id="lblDeudaVDolares2" runat="server" Font-Bold="True" Font-Size="10px" ForeColor="Maroon" Text="DEUDA V. US$"></asp:Label></td>
            <td><uc1:CtlTxt ID="txtDeudaVDolares2" runat="server" Ancho="70" /></td>
        </tr>
        <tr>
            <td><asp:Label ID="lblAval" runat="server" Text="Aval" ForeColor="Maroon" Font-Size="10px" Font-Bold="true" /></td>
            <td><uc1:CtlTxt ID="txtAval" runat="server" Ancho="100"/></td>
            <td><asp:Label ID="lblIng" runat="server" Text="Ing." ForeColor="Maroon" Font-Size="10px" Font-Bold="true" /></td>
            <td><uc1:CtlTxt ID="txtIng" runat="server" Ancho="100"/></td>
            <td><asp:Label id="lblDeudaVDolares1" runat="server" Font-Bold="True" Font-Size="10px" ForeColor="Maroon" Text="DEUDA V. US$"></asp:Label></td>
            <td><uc1:CtlTxt ID="txtDeudaVDolares1" runat="server" Ancho="70" /></td>
            <td><asp:Label id="lblDeudaVSoles2" runat="server" Font-Bold="True" Font-Size="10px" ForeColor="Maroon" Text="DEUDA V. S/."></asp:Label></td>
            <td><uc1:CtlTxt ID="txtDeudaVSoles2" runat="server" Ancho="70" /></td>
            
        </tr>
       
        <tr>
            <td><asp:Label ID="lblCorreo" runat="server" Text="Correo" ForeColor="Maroon" Font-Size="10px" Font-Bold="true" /></td>
            <td><uc1:CtlTxt ID="txtCorreo" runat="server" Ancho="100"/></td>
            <td><asp:Label ID="lblRepLegal" runat="server" Text="Rep.Legal" ForeColor="Maroon" Font-Size="10px" Font-Bold="true" /></td>
            <td><uc1:CtlTxt ID="txtRepLegal" runat="server" Ancho="100"/></td>
            <td><asp:Label id="lblMTSoles" runat="server" Font-Bold="True" Font-Size="10px" ForeColor="Maroon" Text="M.T.(S/.)"></asp:Label></td>
            <td><uc1:CtlTxt ID="txtMTSoles" runat="server" Ancho="70" /></td>
            <td><asp:Label id="lblMKSoles" runat="server" Font-Bold="True" Font-Size="11px" ForeColor="Maroon" Text="M.K.(S/.)"></asp:Label></td>
            <td><uc1:CtlTxt ID="txtMKSoles" runat="server" Ancho="70" /></td>
        </tr>
        <tr>
            <td></td>
            <td></td>
            <td></td>
            <td></td>
            <td><asp:Label id="lblMTDolares" runat="server" Font-Bold="True" Font-Size="11px" ForeColor="Maroon" Text="M.T.(US$)"></asp:Label></td>
            <td><uc1:CtlTxt ID="txtMTDolares" runat="server" Ancho="70" /></td>
            <td><asp:Label id="lblMKDolares" runat="server" Font-Bold="True" Font-Size="11px" ForeColor="Maroon" Text="M.K.(US$)"></asp:Label></td>
            <td><uc1:CtlTxt ID="txtMKDolares" runat="server" Ancho="70" /></td>    
        </tr>
        </table>
        </fieldset>
    </td>
</tr>
<tr>
    <td colspan="2">
        <table width="100%" cellpadding="0" cellspacing="1">
        <tr>
            <td valign="top">
                <fieldset style="font-size:11px; background-color:#FAFAFA; font-family:Arial; border: thin groove #808080 ">
                <legend>Gestiones Telefonicas</legend>
                        <uc3:CtlGrilla ID="gvGestionesTelefonicas" runat="server" Activa_Export="false"  Desactiva_Boton="false" />
                </fieldset>
                <br />
                <fieldset style="font-size:11px; background-color:#FAFAFA; font-family:Arial; border: thin groove #808080 ">
                <legend>Gestiones de Campo</legend>
                        <uc3:CtlGrilla ID="gvGestionesCampo" runat="server" Activa_Export="false" Desactiva_Boton="false" />
                </fieldset>
            </td>
            <td width="120px" valign="top">
                <fieldset style="font-size:11px; background-color:#FAFAFA; font-family:Arial; border: thin groove #808080 ">
                <legend>Datos del Saldo</legend>
                <table width="100%"  cellpadding="0" cellspacing="1">
                <tr>
                    <td style="text-align:center">
                            <asp:ImageButton ID="btnElimina" runat="server" ToolTip="Eliminar" ImageUrl="~/Imagenes/BotonEliminar.png" Width="30px" Height="25px" /><br />
                            <asp:Label ID="lblBotonElimina" runat="server" Text="Eliminar" Font-Size="11px" Font-Bold="false" />
                    </td >
                </tr>
                <tr>   
                    <td style="text-align:center">
                            <asp:ImageButton ID="btnNueva" runat="server" ToolTip="Nueva Gestion" ImageUrl="~/Imagenes/botonNuevo.jpg" Width="30px" Height="25px" /><br />
                            <asp:Label ID="lblBotonNueva" runat="server" Text="Nueva Gestion" Font-Size="11px" Font-Bold="false" />
                    </td>
                </tr>
                <tr>
                    <td style="text-align:center">
                            <asp:ImageButton ID="btnCompromiso" runat="server" ToolTip="Compromisos" ImageUrl="~/Imagenes/Compromiso.png" Width="30px" Height="25px" /><br />
                            <asp:Label ID="lblBotonCompromiso" runat="server" Text="Compromisos" Font-Size="11px" Font-Bold="false" />
                    </td>
                </tr>
                <tr>
                    <td style="text-align:center">
                            <asp:ImageButton ID="btnPagos" runat="server" ToolTip="Pagos" ImageUrl="~/Imagenes/Pago.png" Width="30px" Height="25px" /><br />
                            <asp:Label ID="lblBotonPago" runat="server" Text="Pagos" Font-Size="11px" Font-Bold="false" />
                    </td>
                </tr>
                <tr>
                    <td style="text-align:center">
                            <asp:ImageButton ID="btnHistorial" runat="server" ToolTip="Historial" ImageUrl="~/Imagenes/Notas.png" Width="30px" Height="25px" /><br />
                            <asp:Label ID="lblBotonHistorial" runat="server" Text="Hist. Gestiones" Font-Size="11px" Font-Bold="false" />
                    </td>
                </tr>
                <tr>
                    <td style="text-align:center">
                            <asp:ImageButton ID="btnCerrar" runat="server" ToolTip="Cerrar" ImageUrl="~/Imagenes/BotonCerrar.jpg" Width="30px" Height="25px" /><br />
                            <asp:Label ID="lblCerrar" runat="server" Text="Cerrar" Font-Size="11px" Font-Bold="false" />
                    </td>
                </tr>
                </table>
                </fieldset>
            </td>
        </tr>
        </table>
    </td>
</tr>
</table>
<div style="height:auto; width:auto; position: absolute; left:30%; top:30%; background-color:#FAFAFA; box-shadow: 1px 1px 4px; border: thin groove #808080;">
<asp:Panel ID="pnlPagos" runat="server" Visible="false">
    <uc4:Pagos ID="Pagos1" runat="server" />
</asp:Panel>   
</div>
<div style="height:auto; width:auto; position: absolute; left:10%; top:20%; background-color:#FAFAFA; box-shadow: 1px 1px 4px; border: thin groove #808080;">
<asp:Panel ID="pnlCompromisos" runat="server" Visible="false" style="background:#CED1D7;">
    <uc5:Compromisos ID="Compromisos1" runat="server" />
</asp:Panel>   
</div>