<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="CtlNPerfil.ascx.vb" Inherits="Controles.CtlNPerfil" %>

<%@ Register src="CtlGrilla.ascx" tagname="CtlGrilla" tagprefix="uc1" %>
<%@ Register src="CtlTxt.ascx" tagname="CtlTxt" tagprefix="uc2" %>
<%@ Register src="CtlMensajes.ascx" tagname="CtlMensajes" tagprefix="uc3" %>

    <script type="text/javascript">
        $(function(){
            $("[id*=TV1] input[type=checkbox]").bind("click", function() {
                var table = $(this).closest("table");
                if (table.next().length > 0 && table.next()[0].tagName == "DIV") {
                    //Is Parent CheckBox
                    var childDiv = table.next();
                    var isChecked = $(this).is(":checked");
                    $("input[type=checkbox]", childDiv).each(function() {
                        if (isChecked) {
                            $(this).attr("checked", "checked");
                        } else {
                            $(this).removeAttr("checked");
                        }
                    });
                } else {
                    //Is Child CheckBox
                    var parentDIV = $(this).closest("DIV");
                    if ($("input[type=checkbox]", parentDIV).length == $("input[type=checkbox]:checked", parentDIV).length) {
                        $("input[type=checkbox]", parentDIV.prev()).attr("checked", "checked");
                    } else {
                        //$("input[type=checkbox]", parentDIV.prev()).removeAttr("checked");
                    }
                }
            });
        })
         

    </script>

<table width="100%" class="fondoPantalla">
<tr>
    <td colspan="2" class="titulo">
    <asp:Label ID="lblTitulo" runat="server" Text="INGRESAR NUEVO PERFIL" ForeColor="White"></asp:Label>
    </td>
</tr>
<tr>
    <td colspan="2">
    <fieldset>
    <legend>Datos del Perfil<uc3:CtlMensajes ID="CtlMensajes1" runat="server" />
        </legend>
        <table>
        <tr>
            <td width="100px"><asp:Label ID="lblNombre" runat="server" Text="NOMBRE DE PERFIL: " /><asp:Label ID="lblcod" runat="server" Text="" Visible="false" /><asp:Label ID="lblNombreExtra" runat="server" Text="" Visible="false" /></td>
            <td><uc2:CtlTxt ID="txtNombre" runat="server" /></td>
        </tr>
        </table>
    </fieldset>
    </td>
</tr>
<tr>
    <td valign="top">
        <br />
        <fieldset>
        <legend>Lista de Pantallas</legend>
        <div style="overflow:auto; height:300px; background-color:gray; color: White "  >
            <asp:TreeView Id="TV1" ShowCheckBoxes="All" runat="server" CssClass="MainTV">
                <LeafNodeStyle CssClass="leafNode"  />
                <NodeStyle CssClass="treeNode" />
                <RootNodeStyle CssClass="rootNode" />
                <SelectedNodeStyle CssClass="selectNode" />
            <Nodes>
              <asp:TreeNode Text="Seguridad" Expanded="false" ImageUrl="~/Imagenes/service.png" SelectAction="None" >
                  <asp:TreeNode Text="Pantalla Usuario" Value="01010000" ImageUrl="~/Imagenes/service.png" SelectAction="None"/>
                  <asp:TreeNode Text="Pantalla Perfil" Value="01020000" ImageUrl="~/Imagenes/service.png" SelectAction="None"/>
              </asp:TreeNode>
              <asp:TreeNode Text="Administracion" Expanded="false" ImageUrl="~/Imagenes/home1.png" SelectAction="None">
                  <asp:TreeNode Text="Pantalla Adm. Cartera" Value="02010000" ImageUrl="~/Imagenes/home1.png" SelectAction="None"/>
                  <asp:TreeNode Text="Pantalla Adm. Condicion" value="02020000" ImageUrl="~/Imagenes/home1.png" SelectAction="None"/>
                  <asp:TreeNode Text="Pantalla Adm. Cliente" Value="02030000" ImageUrl="~/Imagenes/home1.png" SelectAction="None"/>
                  <asp:TreeNode Text="Pantalla Tipo de Cambio" value="02040000" ImageUrl="~/Imagenes/home1.png" SelectAction="None"/>
                  <asp:TreeNode Text="Administrador de Tareas" value="02050000" ImageUrl="~/Imagenes/home1.png" SelectAction="None"/>
              </asp:TreeNode>
              <asp:TreeNode Text="Procesos" Expanded="false" ImageUrl="~/Imagenes/blue-purchase-32.png" SelectAction="None">
                  <asp:TreeNode Text="Pantalla Importacion DATA" Value="03010000" ImageUrl="~/Imagenes/blue-purchase-32.png" SelectAction="None"/>
                  <asp:TreeNode Text=" Asignacion de Gestores" value="03020000" Expanded="false" ShowCheckBox="true" ImageUrl="~/Imagenes/blue-purchase-32.png" SelectAction="None">
                        <asp:TreeNode Text="Pantalla Asignar Gestores" Value="03020100" ImageUrl="~/Imagenes/blue-purchase-32.png" SelectAction="None" />
                        <asp:TreeNode Text="Pantalla Reasignar Gestores" Value="03020200" ImageUrl="~/Imagenes/blue-purchase-32.png" SelectAction="None" />
                        <asp:TreeNode Text="Pantalla Consultar Asiganciones" Value="03020300" ImageUrl="~/Imagenes/blue-purchase-32.png" SelectAction="None" />
                  </asp:TreeNode>  
                  <asp:TreeNode Text="Pantalla Gestionar" Value="03030000" SelectAction="None" ImageUrl="~/Imagenes/blue-purchase-32.png"/>
                  <asp:TreeNode Text="Pantalla Pagos Realizados" value="03040000" SelectAction="None" ImageUrl="~/Imagenes/blue-purchase-32.png"/>
              </asp:TreeNode>
              <asp:TreeNode Text="Reportes" Expanded="false" ImageUrl="~/Imagenes/dollar.png" SelectAction="None">
                  <asp:TreeNode Text="Pantalla Reporte Gestion" Value="04010000" ImageUrl="~/Imagenes/dollar.png" SelectAction="None"/>
                  <asp:TreeNode Text=" Pantallas Cartera Castigo" value="04020000" Expanded="false" ShowCheckBox="true" SelectAction="None" ImageUrl="~/Imagenes/dollar.png">
                        <asp:TreeNode Text="Pantalla Reporte de Pago" Value="04020100"  SelectAction="None" ImageUrl="~/Imagenes/dollar.png"/>
                        <asp:TreeNode Text="Pantalla Consulta de Productos" Value="04020200" SelectAction="None" ImageUrl="~/Imagenes/dollar.png" />
                        <asp:TreeNode Text="Pantalla Cartas a Campo" Value="04020300" SelectAction="None" ImageUrl="~/Imagenes/dollar.png" />
                  </asp:TreeNode>
                  <asp:TreeNode Text=" Pantallas Cartera Activa" value="04030000" Expanded="false" ShowCheckBox="true" SelectAction="None" ImageUrl="~/Imagenes/dollar.png">
                        <asp:TreeNode Text="Pantalla Reporte de Pago" Value="04030100" ImageUrl="~/Imagenes/dollar.png" />
                        <asp:TreeNode Text="Pantalla Cartas a Campo" Value="04030200" ImageUrl="~/Imagenes/dollar.png" />
                  </asp:TreeNode>
                  <asp:TreeNode Text=" Pantallas Reporte de Cobertura" value="04040000" Expanded="false" ShowCheckBox="true" SelectAction="None" ImageUrl="~/Imagenes/dollar.png">
                        <asp:TreeNode Text="Pantalla Cobertura por Cartera y Gestor" Value="04040100"  SelectAction="None" ImageUrl="~/Imagenes/dollar.png"/>
                        <asp:TreeNode Text="Pantalla Informacion de Cobertura Global" Value="04040200" SelectAction="None" ImageUrl="~/Imagenes/dollar.png"/>
                        <asp:TreeNode Text="Pantalla Composicion de Cartera Global" Value="04040300" SelectAction="None" ImageUrl="~/Imagenes/dollar.png"/>
                        <asp:TreeNode Text="Pantalla Informacion de Cobertura por Gestor" Value="04040400" SelectAction="None" ImageUrl="~/Imagenes/dollar.png"/>
                        <asp:TreeNode Text="Pantalla Composicion de Cartera por Gestor" Value="04040500" SelectAction="None" ImageUrl="~/Imagenes/dollar.png" />
                  </asp:TreeNode>
                  <asp:TreeNode Text="Pantalla Reporte de Compromiso" Value="04050000" SelectAction="None" ImageUrl="~/Imagenes/dollar.png" />
                  <asp:TreeNode Text="Pantalla Reporte de Trabajo" Value="04060000" SelectAction="None" ImageUrl="~/Imagenes/dollar.png" />
                  <asp:TreeNode Text="Pantalla Calculo de Indicadores" Value="04070000" SelectAction="None" ImageUrl="~/Imagenes/dollar.png" />
              </asp:TreeNode>
            </Nodes>
            </asp:TreeView>   
            </div>     
        </fieldset>
    </td>
    <td valign="top" width="500px">
        <br />
        <fieldset>
        <legend>Lista de Accesos</legend>
            <uc1:CtlGrilla ID="gvAccesos" Ancho="500px" Largo="300px" runat="server" Activa_ckeck="false" Activa_Delete="true" Activa_Edita="false" Activa_Export="false" Activa_option="false" Desactiva_Boton="false" />
        </fieldset>
    </td>
</tr>
<tr>
    <td>
        <table width="100%">
        <tr>
        <td></td>
        <td style="text-align:right" width="35px">
            <div class="curvo">
                <asp:ImageButton id="btnSiguiente" runat="server" Height="30px" Width="30px" ImageUrl="~/Imagenes/Siguiente.png" ToolTip="Agregar" />
    		    <asp:Label ID="lblAgregar" runat="server"  Text="Agregar"></asp:Label>
            </div>        
        </td>
        </tr>
        </table>
    </td>
    <td>
    <table width="100%">
    <tr>
        <td></td>
        <td style="text-align:right" width="35px">
            <div class="curvo">
                <asp:ImageButton id="btnGrabar" runat="server" Height="30px" Width="30px" ImageUrl="~/Imagenes/BotonGrabar.png" ToolTip="Grabar" />
    		    <asp:Label ID="lblGrabar" runat="server"  Text="Grabar"></asp:Label>
            </div>        
        </td>
        <td style="text-align:right" width="35px">
            <div class="curvo" >
                <asp:ImageButton id="btnCerrar" runat="server" Height="30px" Width="30px" ImageUrl="~/Imagenes/BotonCerrar.jpg" ToolTip="Cerrar" />
                <asp:Label ID="lblCerrar" runat="server"  Text="Cerrar"></asp:Label>
            </div>        
        </td>
    </tr>
    </table>
    </td>
</tr>
</table>


