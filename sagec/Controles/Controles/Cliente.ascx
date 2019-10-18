<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="Cliente.ascx.vb" Inherits="Controles.Cliente" %>

<%@ Register src="CtlGrilla.ascx" tagname="CtlGrilla" tagprefix="uc1" %>
<table style="width: 100%;">
<tr>
<td align="center">
    <asp:Label id="lblTituloControl" runat="server" Font-Size="13px"></asp:Label>
</td>
</tr>
</table>

<style type="text/css">
    .style1
    {
        width: 96px;
    }
    .style2
    {
        width: 55px;
    }
    .style3
    {
        width: 54px;
    }
    .style4
    {
        width: 304px;
    }
    .style5
    {
        width: 85px;
    }
    .style6
    {
        width: 53px;
    }
    .style7
    {
        width: 450px;
    }
    .style9
    {
        width: 683px;
    }
    .style10
    {
        height: 18px;
    }
    </style>
 
<table style="width: 100%">
<tr>
    <td colspan="3" style="right">
    <table style="width: 100%">
        <tr>
            <td style="text-align:right" class="style9"><asp:Label ID="Label1" runat="server" Text="GESTOR" Font-Size="11px" /></td>
            <td style="text-align:right"><asp:TextBox ID="TextBox1" runat="server" Width="45px" Font-Size="11px" /></td>
        </tr>
    </table>
    </td>
</tr>
<tr>
    <td class="style4" valign="top">
    <fieldset style="margin:0; padding:0;">
        <table style="width: 100%">
        <tr>
            <td class="style1"><asp:label ID="lblCartera" runat="server" Text="CARTERA" Font-Size="11px" /></td>
            <td class="style2"><asp:Label ID="lblCINT" runat="server" Text="C.INT" Font-Size="11px" /></td>
            <td class="style3"><asp:Label ID="lblCEXT" runat="server" Text="C.EXT" Font-Size="11px" /></td>
            <td style="text-align:right"><asp:Label ID="lblSituacion" runat="server" Text="SITUAC." Font-Size="11px" /></td>
        </tr>
        <tr>
            <td class="style1"><asp:DropDownList ID="DDLCartera" runat="server" Font-Size="11px" /></td>
            <td class="style2"><asp:DropDownList ID="DDLCINT" runat="server" Width="51px" Font-Size="11px" /></td>
            <td class="style3"><asp:TextBox ID="txtCEXT" runat="server" Width="51px" Font-Size="11px" /></td>
            <td style="text-align:right"><asp:TextBox ID="txtSituacion" runat="server" Width="51px" Font-Size="11px" /></td>
        </tr>
        </table>
    </fieldset>
    </td>
    <td class="style7" valign="top">
    <fieldset style="margin:0; padding:0;">
        <table style="width: 100%">
        <tr>
            <td class="style5"><asp:Label ID="lblDNI" runat="server" Text="DNI" /></td>
            <td rowspan="2" class="style6" style="text-align:center" valign="middle"><asp:ImageButton ID="imgBuscar" runat="server" ImageUrl="~/Imagenes/BotonBusquedaPequena.png" Width="40px" Height="40px" /></td>
            <td style="text-align:center"><asp:Label ID="lblNombreCliente" runat="server" Text="NOMBRE DE CLIENTE" /></td>
        </tr>
        <tr>
            <td class="style5" style="text-align:center"><asp:TextBox ID="txtDNI" runat="server" Width="80px" Font-Size="11px" /></td>
            <td style="text-align:center"><asp:TextBox ID="txtNombreCliente" runat="server" 
                    Width="235px"  Font-Size="11px" /></td>
        </tr>
        </table>
    </fieldset>
    </td>
    <td valign="top">
        <table style="width: 100%">
        <tr>
            <td colspan="2" style="text-align:center" >
                <asp:ImageButton id="ImgACampo" runat="server" ImageUrl="~/Imagenes/Campo.jpg" />
                <asp:ImageButton id="ImgGrabar" runat="server" ImageUrl="~/Imagenes/BotonGrabar.png" Width="40px" Height="30px" />
            </td>
        </tr>
        </table>
    </td>
</tr>
<tr>
    <td colspan="3">
        <table width="100%">
        <tr>
            <td  class="style4"  valign="top">
                <fieldset style="margin:0; padding:0;">
                <legend>Telefonos</legend>
                <div style="overflow:scroll; width:auto; height:120px">
                <uc1:CtlGrilla ID="CtlGrilla1" runat="server" Activa_ckeck="true" Activa_Delete="false" Activa_Edita="false" Activa_Export="false" Activa_option="false" Desactiva_Boton="false"/>
                </div>
                </fieldset>
            </td>
            <td valign="top">
                <fieldset style="margin:0; padding:0;">
                <legend>Direcciones</legend>
                <div style="overflow:scroll; width:auto; height:60px">
                <uc1:CtlGrilla ID="CtlGrilla2" runat="server" Activa_ckeck="true" Activa_Delete="false" Activa_Edita="false" Activa_Export="false" Activa_option="false" Desactiva_Boton="false"/>
                </div>
                </fieldset>
                <fieldset style="margin:0; padding:0;">
                <legend>Anotaciones</legend>
                <div style="overflow:scroll; width:auto; height:50px">
                
                </div>
                </fieldset>
            </td>
        </tr>
        </table>
    </td>
</tr>
<tr>
    <td colspan="3">
        <table width="100%">
        <tr>
            <td class="style4" valign="top">
                <fieldset style="margin:0; padding:0;">
                <legend>Estadistica de Avance</legend>
                <table width="100%" style="height: 108px">
                <tr>
                    <td width="25%"><asp:Label ID="lblTotGestionRealizadas" runat="server" Text="Tot.Gest.Realizadas" Font-Size="11px" /></td>
                    <td rowspan="2"></td>
                </tr>
                <tr>
                    <td></td>
                </tr>
                <tr>
                    <td><asp:Label ID="lblTotEfectivoRealizadas" runat="server" Text="Tot.Efect.Realizada" Font-Size="11px" /></td>
                    <td rowspan="2"></td>
                </tr>
                <tr>
                    <td></td>
                </tr>
                </table>
                </fieldset>
            </td>
            <td>
                <fieldset style="margin:0; padding:0;">
                <legend>Datos Adicionales</legend>
                <table width="100%">
                <tr>
                    <td width="5%"><asp:Label ID="lblCLab" runat="server" Text="C.Lab" Font-Size="10px" /></td>
                    <td width="30%"><asp:TextBox ID="txtCLab" runat="server"  Width="100%" Font-Size="10px"/></td>
                    <td width="10%"><asp:Label ID="lblProd" runat="server" Text="1er Prod." Font-Size="10px"/></td>
                    <td width="25%"><asp:TextBox ID="TextBox2" runat="server" Width="100%" Font-Size="10px"/></td>
                    <td width="5%"><asp:Label ID="lblEdad" runat="server" Text="Edad" Font-Size="10px"/></td>
                    <td><asp:TextBox ID="TextBox3" runat="server" Width="100%" Font-Size="10px"/></td>
                </tr>
                <tr>
                    <td><asp:Label ID="lblCony" runat="server" Text="Cony." Font-Size="10px" /></td>
                    <td><asp:TextBox ID="TextBox4" runat="server" Width="100%" Font-Size="10px" /></td>
                    <td><asp:Label ID="lblAval" runat="server" Text="Aval" Font-Size="10px" /></td>
                    <td><asp:TextBox ID="TextBox5" runat="server" Width="100%" Font-Size="10px" /></td>
                    <td><asp:Label ID="lblIng" runat="server" Text="Ing." Font-Size="10px" /></td>
                    <td><asp:TextBox ID="TextBox6" runat="server" Width="100%" Font-Size="10px" /></td>
                </tr>
                <tr>
                    <td><asp:Label ID="lblEmail" runat="server" Text="E.mail" Font-Size="10px" /></td>
                    <td><asp:TextBox ID="TextBox7" runat="server" Width="100%" Font-Size="10px" /></td>
                    <td><asp:Label ID="lblRepLegal" runat="server" Text="Rep.Legal" Font-Size="10px" /></td>
                    <td colspan="3"><asp:TextBox ID="TextBox8" runat="server" Width="100%" Font-Size="10px" /></td>
                </tr>
                <tr>
                    <td colspan="6" valign="top">
                    <asp:Label ID="lblTelefonoVerificar" runat="server" Text="Telefono por Verificar: " valign="top" Font-Size="10px" />&nbsp;
                    <asp:TextBox ID="txtTelefonoVerificar" runat="server" Width="73%"  Font-Size="10px" ></asp:TextBox>
                    </td>
                </tr>
                </table>
                </fieldset>
            </td>
        </tr>
        </table>
    </td>
</tr>
<tr>
    <td colspan="3" valign="top">
    <table width="100%">
    <tr>
        <td width="80%" valign="top">
            <fieldset style="margin:0; padding:0;">
                <legend>GESTIONES REALIZADAS</legend>
                <table width="100%">
                <tr>
                    <td bgcolor="#3366ff"><asp:Label ID="lblGestionesTelefonicas" runat="server" Text="Gestiones Telefonicas" ForeColor="White" Font-Size="10px" /></td>
                </tr>
                <tr>
                    <td>
                        <div style="overflow:scroll; height:100px; width:auto">
                        <uc1:CtlGrilla ID="CtlGrilla3" runat="server" Activa_ckeck="false" Activa_Delete="true" Activa_Edita="true" Activa_Export="true" Activa_option="false" Desactiva_Boton="false"/>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td bgcolor="#3366ff"><asp:Label ID="lblGestionesCampos" runat="server" Text="Gestiones de Campo" ForeColor="White" Font-Size="10px" /></td>
                </tr>
                <tr>
                    <td>
                        <div style="overflow:scroll; height:100px; width:auto">
                        <uc1:CtlGrilla ID="CtlGrilla4" runat="server" Activa_ckeck="false" Activa_Delete="true" Activa_Edita="true" Activa_Export="true" Activa_option="false" Desactiva_Boton="false"/>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td style="text-align:center">
                        <asp:Button ID="btnEliminar" runat="server" Text="Eliminar Gestion" />&nbsp;
                        <asp:Button ID="btnNuevo" runat="server" Text="Nueva Gestion" />&nbsp;
                        <asp:Button ID="btnModificar" runat="server" Text="Modificar Gestion" />&nbsp;
                        <asp:Button ID="btnExportar" runat="server" Text="Exportar a Excel" />&nbsp;
                        <asp:Button ID="btnCerrar" runat="server" Text="Cerrar" />
                    </td>
                </tr>
                </table>
            </fieldset>
        </td>
        <td>
            <fieldset style="margin:0; padding:0;">
            <table width="100%">
            <tr><td style="text-align:center"><asp:Label ID="lblDeudaTotalSoles" runat="server" Text="Deuda Total S/." Font-Size="10px" /></td></tr>
            <tr><td style="text-align:center"><asp:TextBox ID="txtDeudaTotalSoles" runat="server" Width="100%" Font-Size="10px" /></td></tr>
            <tr><td style="text-align:center"><asp:Label ID="lblDeudaVSoles1" runat="server" Text="Deuda V. S/." Font-Size="10px" /></td></tr>
            <tr><td style="text-align:center"><asp:TextBox ID="txtDeudaVSoles1" runat="server" Width="100%" Font-Size="10px" /></td></tr>
            <tr><td style="text-align:center"><asp:Label ID="lblDeudaVDolares1" runat="server" Text="Deuda V. US$" Font-Size="10px" /></td></tr>
            <tr><td style="text-align:center"><asp:TextBox ID="txtDeudaVDolares1" runat="server" Width="100%" Font-Size="10px" /></td></tr>
            <tr><td style="text-align:center"><asp:Label ID="lblDeudaTotalDolares" runat="server" Text="Deuda Total US$" Font-Size="10px" /></td></tr>
            <tr><td style="text-align:center"><asp:TextBox ID="txtDeudaTotalDolares" runat="server" Width="100%" Font-Size="10px" /></td></tr>
            <tr><td style="text-align:center"><asp:Label ID="lblDeudaVDolares2" runat="server" Text="Deuda V. US$" Font-Size="10px" /></td></tr>
            <tr><td style="text-align:center"><asp:TextBox ID="txtDeudaVDolares2" runat="server" Width="100%" Font-Size="10px" /></td></tr>
            <tr><td style="text-align:center"><asp:Label ID="lblDeudaVSoles2" runat="server" Text="Deuda V. S/." Font-Size="10px" /></td></tr>
            <tr><td style="text-align:center"><asp:TextBox ID="txtDeudaVSoles2" runat="server" Width="100%" Font-Size="10px" /></td></tr>
            <tr><td style="text-align:center"><asp:Label ID="lblMTSoles" runat="server" Text="M.T(S/.)" Font-Size="10px" /></td></tr>
            <tr><td style="text-align:center"><asp:TextBox ID="txtMTSoles" runat="server" Width="100%" Font-Size="10px" /></td></tr>
            <tr><td style="text-align:center"><asp:Label ID="lblMKSoles" runat="server" Text="M.K(S/.)" Font-Size="10px" /></td></tr>
            <tr><td style="text-align:center"><asp:TextBox ID="txtMKSoles" runat="server" Width="100%" Font-Size="10px" /></td></tr>
            <tr><td style="text-align:center"><asp:Label ID="lblMKDolares" runat="server" Text="M.K(US$)" Font-Size="10px" /></td></tr>
            <tr><td style="text-align:center"><asp:TextBox ID="txtMKDolares" runat="server" Width="100%" Font-Size="10px" /></td></tr>
            <tr><td style="text-align:center"><asp:Label ID="lblMTDolares" runat="server" Text="M.T(US$)" Font-Size="10px" /></td></tr>
            <tr><td style="text-align:center"><asp:TextBox ID="txtMTDolares" runat="server" Width="100%" Font-Size="10px" /></td></tr>
            <tr><td style="text-align:center"><asp:ImageButton ID="imgDeuda" runat="server" ImageUrl="~/Imagenes/Deuda.jpg" Height="45px" Width="75px" /></td></tr>
            <tr><td style="text-align:center"><asp:ImageButton ID="imgCompromiso" runat="server"  Height="45px" Width="75px" ImageUrl="~/Imagenes/Compromiso.jpg" /></td></tr>
            <tr><td style="text-align:center"><asp:ImageButton ID="imgPagos" runat="server" Height="45px" Width="75px" ImageUrl="~/Imagenes/Pagos.jpg" /></td></tr>
            <tr><td style="text-align:center"><asp:ImageButton ID="imgHistorial" runat="server"  Height="45px" Width="75px" ImageUrl="~/Imagenes/Historial.jpg" /></td></tr>
            </table>
            </fieldset>
        </td>
    </tr>
    </table>
    
    </td>
</tr>
</table>
