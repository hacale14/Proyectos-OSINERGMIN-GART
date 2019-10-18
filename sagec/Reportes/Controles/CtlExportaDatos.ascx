<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="CtlExportaDatos.ascx.vb" Inherits="Controles.CtlExportaDatos" %>
<%@ Register src="CtCombo.ascx" tagname="CtCombo" tagprefix="uc1" %>

<%@ Register src="CtlGrilla.ascx" tagname="CtlGrilla" tagprefix="uc2" %>
<%@ Register src="CtlMensajes.ascx" tagname="CtlMensajes" tagprefix="uc3" %>

<script>
function myFunction(textbox) {
alert('entre aqui');
    var x1 = document.getElementById(textbox).value;    
    var x2 = document.getElementById('h'+textbox).value;
    alert(x1+' '+x2);
    x2.value = x1.value.toUpperCase();
}
</script>

<asp:HiddenField  ID="htxtFechaInicio" runat="server"/>
<asp:HiddenField  ID="htxtFechaFin" runat="server"/>

<table width="100%" class="fondoPantalla">
    <tr>
        <td class="titulo">
            <asp:Label ID="lblTituloControl" runat="server" Text="IMPORTACION DE DATOS EN EXCEL" ForeColor="White"></asp:Label>
        </td>
    </tr>
</table>
<table>
<tr>
    <td>
        <fieldset>
        <table width="100%" border="0">
        <tr>
            <td style="width:100px">
                Tipo Exportacion<uc3:CtlMensajes ID="CtlMensajes1" runat="server" /></td>
            <td style="width:210px;">
                <uc1:CtCombo ID="cboTipoCartera" runat="server" Longitud="200" Procedimiento="QRYC008" Condicion=":cod▓130" AutoPostBack="true" />
            </td>
            <td>
                Cartera</td>
            <td style="width:210px;">
                <uc1:CtCombo ID="cboCartera" runat="server" Longitud="200" Activa="false" />
                            </td>
        </tr>
        <tr>
            <td style="width:70px;">
                <asp:Label ID="lblFechaInicio" runat="server" Text="FECHA REGISTRO" CssClass="lbl" />
            </td>
            <td>
                <asp:TextBox ID="txtFechaInicio" runat="server"  Width="170px" CssClass="textoContenido" onkeypress="myFunction('txtFechaInicio')"/>
                <img ID="fecha" alt="calendario" height="16"  onclick="return showCalendar('fecha','<%=txtFechaInicio.ClientID%>','%d/%m/%Y','24', true);" src="Imagenes/calendario.png" width="18" />
            </td>
            <td style="width:100px;">
                <asp:Label ID="lblFechaFin" runat="server" Text="FECHA TERMINO" CssClass="lbl" />
            </td>
            <td style="width:100px">
                <asp:TextBox ID="txtFechaFin" runat="server"  Width="170px" CssClass="textoContenido" onkeypress="myFunction('txtFechaFin')"/>
                <img ID="fecha1" alt="calendario" height="16"  onclick="return showCalendar('fecha1','<%=txtFechaFin.ClientID%>','%d/%m/%Y','24', true);" src="Imagenes/calendario.png" width="18" />
            </td>
        </tr>
        <tr><td style="height:10px;"></td></tr>
        <tr>
            <td width="35px" colspan="4" style="padding-right:100px;">
                <div class="curvo" style="width:120px;">
                <asp:ImageButton id="btnImportar" runat="server" CssClass="curvoimg" 
                        ImageUrl="~/Imagenes/BotonExportarExcel.jpg" 
                        ToolTip="Importar Archivo en Excel" />
                <asp:Label ID="lblImportar" runat="server" Text="Importar" CssClass="curvolbl"></asp:Label>
                </div>
            
                <div class="curvo">
                <asp:ImageButton id="btnBuscar" runat="server" CssClass="curvoimg" ToolTip="Buscar Carga" ImageUrl="~/Imagenes/BotonBusquedaPequena.png" />
                <asp:Label ID="lblBuscar" runat="server" Text="Buscar" CssClass="curvolbl"></asp:Label>
                </div>
            </td>
        </tr>
        </table>
        </fieldset>
    </td>
</tr>
<tr>
    <td>
        <fieldset>
            <uc2:CtlGrilla ID="CtlGrilla1" runat="server" Activa_ckeck="FALSE" Activa_Delete="true" Activa_Edita="true" Activa_option="false" Desactiva_Boton="false" Ancho="970px" Desactivar_Paginacion="true" Paginacion="12"  Largo="330px"/>
        </fieldset>
    </td>
</tr>

</table>

<asp:Timer ID="Timer1" runat="server" Interval="60000">
</asp:Timer>

