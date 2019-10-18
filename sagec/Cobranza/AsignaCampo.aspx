<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.Master"
    CodeBehind="AsignaCampo.aspx.vb" Inherits="Cobranza.AsignaCampo" Title="Página sin título" %>

<%@ Register Src="Controles/CtlGrilla.ascx" TagName="CtlGrilla" TagPrefix="uc1" %>
<%@ Register Src="Controles/CtCombo.ascx" TagName="CtCombo" TagPrefix="uc2" %>
<%@ Register Src="Controles/CtlMensajes.ascx" TagName="CtlMensajes" TagPrefix="uc3" %>
<%@ Register Src="Controles/CtlTxt.ascx" TagName="CtlTxt" TagPrefix="uc4" %>
<asp:Content ID="Content3" runat="server" ContentPlaceHolderID="head">

<link href="css/main.css" rel="stylesheet" type="text/css" />
<link href="style/bootstrap.min.css" rel="stylesheet" type="text/css" />
<script src="lib/jquery/jquery.min.js" type="text/javascript"></script>
<script src="js/bootstrap.min.js" type="text/javascript"></script>

</asp:Content>
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
            <table>
                <tr>
                    <td>
                        <fieldset>
                            <legend>
                                <h4 class="texto">
                                    Filtros de Búsqueda</h4>
                            </legend>
                            <table class="p-f-10">
                                <tr>
                                    <td class="top">
                                        <table width="100%">
                                            <caption>
                                            </caption>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="p-t-10">
                                        <fieldset>
                                            <legend>Empresa</legend>
                                            <uc2:CtCombo ID="cboEmpresa" runat="server" Activa="true" AutoPostBack="true" Condicion=""
                                                Longitud="200" Procedimiento="QRYMG002" />
                                        </fieldset>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="p-t-10">
                                        <fieldset>
                                            <legend>Grupo</legend>
                                            <uc2:CtCombo ID="cboGrupo" runat="server" Activa="true" Condicion="" Longitud="200"
                                                Procedimiento="QRYC016" />
                                        </fieldset>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="p-t-10">
                                        <fieldset>
                                            <legend>Cartera</legend>
                                            <uc2:CtCombo ID="cboCartera" runat="server" Activa="true" AutoPostBack="true" Condicion=""
                                                Longitud="200" Procedimiento="QRYC007" />
                                        </fieldset>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="p-t-10">
                                        <fieldset>
                                            <legend>Usuario</legend>
                                            <uc2:CtCombo ID="CboUsuario" runat="server" Activa="true" Condicion="" Longitud="200"
                                                Procedimiento="SQL_N_GEST057" />
                                        </fieldset>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="p-t-10">
                                        <fieldset>
                                            <legend>Situacion</legend>
                                            <uc2:CtCombo ID="CboSituacion" runat="server" Activa="true" Longitud="200" Procedimiento="SQL_N_GEST006" />
                                        </fieldset>
                                    </td>
                                </tr>
                            </table>
                        </fieldset>
                    </td>
                    <td>
                        <asp:Panel ID="pnlPrinicipal" runat="server" Visible="true" CssClass="panel_hand"
                            Style="vertical-align: top;">
                            <fieldset>
                                <legend>Asignacion de la cartera a campo via movil o manual</legend>
                                <table class="p-h-20" width="100%">
                                    <tr>
                                        <td>
                                            <h4 class="texto">
                                                Mapa General</h4>
                                        </td>
                                        <td>
                                            <h4 class="texto">
                                                Mapa Detallado</h4>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="20%">
                                            <fieldset>
                                                <uc1:CtlGrilla ID="gvAsignaGeneral" runat="server" Activa_ckeck="false" Activa_Delete="false"
                                                    Activa_Edita="false" Activa_Export="false" Activa_option="false" Desactiva_Boton="false"
                                                    Largo="80px" OpocionNuevo="false" />
                                            </fieldset>
                                        </td>
                                        <td>
                                            <fieldset>
                                                <uc1:CtlGrilla ID="gvAsignaDetalle" runat="server" Activa_ckeck="false" Activa_Delete="false"
                                                    Activa_Edita="false" Activa_Export="false" Activa_option="false" Desactiva_Boton="false"
                                                    Largo="80px" OpocionNuevo="false" />
                                            </fieldset>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="p-f-10" colspan="2">
                                            <uc2:CtCombo ID="CboUsuarioxAsignar" runat="server" Activa="true" Condicion="" Longitud="200"
                                                Procedimiento="SQL_N_GEST057" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="p-h-5" colspan="2">
                                            <uc4:CtlTxt ID="txtMontoIni" runat="server" Ancho="30" Text="0" TipoDatos="Numero" />
                                            <uc4:CtlTxt ID="txtMontoFin" runat="server" Ancho="30" Text="0" TipoDatos="Numero" />
                                            <uc2:CtCombo ID="cboDpto" runat="server" AutoPostBack="true" Longitud="200" Procedimiento="QRYC009" />
                                            <uc2:CtCombo ID="cboProv" runat="server" AutoPostBack="true" Longitud="200" Procedimiento="QRYC010" />
                                            <uc2:CtCombo ID="cboDist" runat="server" AutoPostBack="true" Longitud="200" Procedimiento="" />
                                            <asp:Button ID="btnProcesaAsig" runat="server" CssClass="curvoaplica p-f-0" Height="30px"
                                                Text="pre-asignar" />
                                            <button type="button" class="btn btn-primary" data-toggle="modal" data-target="#MD_PRE_ASIGNACION">
                                                VER
                                            </button>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="p-v-20" colspan="2" width="100%">
                                            <asp:Button ID="btnGenerarCartas" runat="server" CssClass="curvoaplica" Height="40px"
                                                Text="Generar Cartas" Width="300px" />
                                        </td>
                                    </tr>
                                </table>
                            </fieldset>
                        </asp:Panel>
                        <asp:Panel ID="pnlCartas" runat="server" Visible="false" CssClass="panel_hand">
                            <fieldset>
                                <legend>Filtro de impresion de cartas</legend>
                                <table class="p-h-10" width="100%">
                                    <tr>
                                        <td colspan="2" width="100%">
                                            <uc4:CtlTxt ID="txtMontoIniC" runat="server" Ancho="30" Text="0" TipoDatos="Numero" />
                                            <uc4:CtlTxt ID="txtMontoFinC" runat="server" Ancho="30" Text="0" TipoDatos="Numero" />
                                            <uc2:CtCombo ID="CboDptoC" runat="server" AutoPostBack="true" Longitud="200" Procedimiento="QRYC009" />
                                            <uc2:CtCombo ID="CboProvC" runat="server" AutoPostBack="true" Longitud="200" Procedimiento=""
                                                Text="Empresa" />
                                            <uc2:CtCombo ID="CboDistC" runat="server" AutoPostBack="true" Longitud="200" Procedimiento=""
                                                Text="Empresa" />
                                            <asp:ListBox ID="lstiniC" runat="server" class="m-b-5" Height="25px" Width="90px">
                                            </asp:ListBox>
                                            <asp:ListBox ID="lstFinC" runat="server" class="m-b-5" Height="25px" Width="90px">
                                            </asp:ListBox>
                                            <asp:Button ID="Procesar" runat="server" CssClass="curvoaplica" Height="40px" Text="Procesar" />
                                            <asp:CheckBox ID="chkManualMovil" runat="server" Text="Manual/Movil" TextAlign="Right" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="79%">
                                            <fieldset>
                                                <uc1:CtlGrilla ID="gvCarta" runat="server" Activa_ckeck="false" Activa_Delete="false"
                                                    Activa_Edita="false" Activa_Export="false" Activa_option="false" Desactiva_Boton="false"
                                                    Largo="80px" OpocionNuevo="false" />
                                            </fieldset>
                                        </td>
                                        <td>
                                            <asp:Button ID="Imprimir" runat="server" CssClass="curvoaplica" Height="40px" Text="Imprimir" />
                                            <asp:CheckBox ID="chkRevisita" runat="server" Text="Revisita" TextAlign="Right" />
                                            <asp:Button ID="btnFormato" runat="server" CssClass="curvoaplica p-t-10" Height="40px"
                                                Text="Formato" />
                                        </td>
                                    </tr>
                                </table>
                            </fieldset>
                        </asp:Panel>
                    </td>
                </tr>
            </table>
            <asp:Panel ID="PnlFormato" runat="server" Visible="false" CssClass="panel_hand">
                <div onmousecl="conecta(this);" id="dvFormato" style="width: 650px; top: 280px; left: 400px;
                    z-index: 4; background-color: rgba(255,255,255,1); border: 0px solid; position: absolute;
                    text-align: -moz-right; border-radius: 4px;">
                    <fieldset>
                        <legend>Formato</legend>
                        <table width="100%">
                            <tr>
                                <td>
                                    Cartera
                                </td>
                                <td>
                                    Archivo Plantilla
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: left">
                                    <uc2:CtCombo ID="CboCarteraF" runat="server" Activa="true" AutoPostBack="true" Condicion=""
                                        Longitud="200" Procedimiento="QRYC007" />
                                </td>
                                <td style="text-align: left">
                                    <asp:FileUpload ID="FileUpload1" runat="server" />
                                    <asp:Button ID="btnCargar" runat="server" CssClass="curvoaplica p-f-0" Height="30px"
                                        Text="Cargar" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <center>
                                        <asp:Label ID="lblUuario" runat="server" CssClass="jc_usuario" Text="Mensaje:" Style="color: black;" />
                                    </center>
                                </td>
                            </tr>
                        </table>
                    </fieldset>
                </div>
            </asp:Panel>
            <uc3:CtlMensajes ID="CtlMensajes1" runat="server" />
        </ContentTemplate>
    </asp:UpdatePanel>

    <script type="text/javascript" src="scripts/demos.js"></script>

    <script type="text/javascript">
        
        $( document ).ready(function() {
            var selectedmov = null, // Object of the element to be moved
		x_pos = 0, y_pos = 0, // Stores x & y coordinates of the mouse pointer
		x_elem = 0, y_elem = 0; // Stores top, left values (edge) of the element	
		// Will be called when user starts dragging an element
		
		function _drag_init(elem) {		
		// Store the object of the element which needs to be moved		
		selectedmov = elem;
		x_elem = x_pos - selectedmov.offsetLeft;
		y_elem = y_pos - selectedmov.offsetTop;
		}

		// Will be called when user dragging an element
		function _move_elem(e) {		
		x_pos = document.all ? window.event.clientX : e.pageX;
		y_pos = document.all ? window.event.clientY : e.pageY;							
		if (selected !== null) {
			selectedmov.style.left = (x_pos - x_elem) + 'px';
			selectedmov.style.top = (y_pos - y_elem) + 'px';
			
		}		
		}

		// Destroy the object when we are done
		function _destroy() {
		selectedmov = null;	
		}
		document.onmousemove = _move_elem;
		document.onmouseup = _destroy;
		// Bind the functions...	
		function conecta(e){							
			_drag_init(e);
			return false;
		}
        });
		
    </script>

    <%--  MODALES--%>
    <div class="modal fade" id="MD_PRE_ASIGNACION" tabindex="-1" role="dialog" data-backdrop="static"
        data-keyboard="false" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-lg" role="document">
            <div class="modal-content">
                <div class="modal-header">
                <span>Seleccione clientes ha asignar</span>
  <%--                  <fieldset>
                        <legend>Seleccione rango a asignar</legend>
                        <table>
                            <tr>
                                <td>
                                    <asp:TextBox ID="txtRangI" CssClass="" runat="server"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtRangF" CssClass="" runat="server"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:Button ID="btnAsignar" runat="server" Text="Asignar" CssClass="curvoaplica p-f-0"
                                        Height="30px" />
                                </td>
                            </tr>
                        </table>
                    </fieldset>--%>
                </div>
                <div class="modal-body">
                    <asp:UpdatePanel runat="server">
                        <ContentTemplate>
                            <uc1:CtlGrilla ID="Clientesgr" runat="server" Activa_ckeck="true" Activa_Delete="true"
                                Activa_Edita="true" Activa_Export="false" Activa_option="false" Desactiva_Boton="false"
                                OpocionNuevo="false" OcultarColumnas="7;8;10;12;14" />
                                
                                <uc1:CtlGrilla ID="pruebagv" runat="server" Activa_ckeck="true" Activa_Delete="true"
                                Activa_Edita="true" Activa_Export="false" Activa_option="false" Desactiva_Boton="false"
                                OpocionNuevo="false"  />
                                
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">
                        CERRAR</button>
                        <asp:Button ID="btnGetSelected" runat="server" Text="ASIGNAR" OnClick="GetSelectedRecords" />
                </div>
            </div>
        </div>
    </div>

    <script>
            $('#MD_PRE_ASIGNACION').modal({backdrop: 'static', keyboard: false})  
    </script>

</asp:Content>
