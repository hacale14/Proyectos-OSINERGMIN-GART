<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.Master" CodeBehind="Propuesta.aspx.vb" Inherits="Cobranza.Formulario_web125" 
    title="Propuesta" %>
<%@ Register src="Controles/CtlMensajes.ascx" tagname="CtlMensajes" tagprefix="uc1" %>
<%@ Register src="Controles/CtCombo.ascx" tagname="CtCombo" tagprefix="uc2" %>
<%@ Register src="Controles/CtlGrilla.ascx" tagname="CtlGrilla" tagprefix="uc3" %>
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
<table width="100%">
        <tr>
            <td style="text-align:center; width:100%;" class="fondoPantalla">
            <table style="width: 100%;" align="center">
                <tr>
                    <td align="center" class="titulo">
                        CONSULTA PROPUESTA
                        <uc1:CtlMensajes ID="CtlMensajes1" runat="server" />
                    </td>
                </tr>
            </table>
            <table width="100%">
                <tr>
                    <td>
                        <fieldset>
                        <table border="0" width="100%">
                            <tr>
                                <td rowspan="3"></td>
                                <td style="width:90px;">                
                                    <asp:Label id="Label1" runat="server" CssClass="lbl" Text="EMPRESA"></asp:Label>
                                </td>
                                <td style="width:190px;">
                                    <uc2:CtCombo ID="cboEmpresa" runat="server" Longitud="180" Procedimiento="QRYMG002" AutoPostBack="true"/>                
                                </td>
                                <td style="width:70px;">
                                    <asp:Label id="Label2" runat="server" CssClass="lbl" Text="CARTERA"></asp:Label>
                                </td>
                                <td style="width:190px;">
                                    <uc2:CtCombo ID="cboCartera" runat="server" Procedimiento="QRYC014" Longitud="180" />                
                                </td>
                                <td style="width:70px;">
                                    <asp:Label id="Label3" runat="server" CssClass="lbl" Text="ESTADO"></asp:Label>
                                </td>
                                <td style="width:130px;">
                                    <uc2:CtCombo ID="cboEstado" Longitud="120" runat="server" Condicion=":idtabla▓117" Procedimiento="SQL_N_GEST012" />                
                                </td>
                                <td rowspan="3" style="width:20px;"></td>
			                    <td rowspan="3" style="width:50px;">
			                        <div class="curvo" id="Div1" runat="server">
		                            <asp:ImageButton id="imgBuscar" runat="server" ImageUrl="~/imagenes/boton busqueda.jpg"  CssClass="curvoimg"/>
				                    <asp:Label id="Label19" runat="server" CssClass="curvolbl" Text="Buscar"></asp:Label>
				                    </div>
			                    </td>
			                    <td rowspan="3"></td>
			                </tr>
			                <tr><td style="height:5px;"></td></tr>
			                <tr>
			                    <td >
			                        <asp:Label id="Label4" runat="server" CssClass="lbl" Text="FECHA INICIO"></asp:Label>
	                            </td>
	                            <td >
                                    <asp:TextBox ID="txtFechaInicio" runat="server"  Width="150px" Enabled = "false" CssClass="textoContenido"/>
                                    <img ID="imgFechaInicio" alt="calendario" height="16"  onclick="return showCalendar('imgFechaInicio','<%=txtFechaInicio.ClientID%>','%d/%m/%Y','24', true);" src="Imagenes/calendario.png" width="18" />							
			                    </td>
			                    <td >
	                                <asp:Label id="Label5" runat="server" CssClass="lbl" Text="FECHA FIN"></asp:Label>
			                    </td>
			                    <td>
                                    <asp:TextBox ID="txtFechaFin" runat="server"  Width="150px" Enabled = "false" CssClass="textoContenido" />
                                    <img ID="imgFechaFin" alt="calendario" height="16" onclick="return showCalendar('imgFechaFin','<%=txtFechaFin.ClientID%>','%d/%m/%Y','24', true);" src="Imagenes/calendario.png" width="18" />
			                    </td>
                            </tr>
                        </table>
                        </fieldset>
                    </td>
                </tr>
                <tr>
                    <td>                
                        <fieldset>
                            <uc3:CtlGrilla ID="gvPropuesta" runat="server" Activa_ckeck="false" Activa_Delete="false" Activa_option="false" Desactiva_Boton="false" OpocionNuevo="false" With_Grilla="400px" Activa_Edita="false" Largo="400px"  />                
                        </fieldset>
                    </td>
                </tr>
            </table> 
    </td>
        </tr>
    </table>   
</ContentTemplate>
</asp:UpdatePanel>
</asp:Content>
