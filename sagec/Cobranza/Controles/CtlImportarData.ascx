<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="CtlImportarData.ascx.vb" Inherits="Controles.CtlImportarData" %>

<%@ Register src="CtCombo.ascx" tagname="CtCombo" tagprefix="uc1" %>

<%@ Register src="CtlGrilla.ascx" tagname="CtlGrilla" tagprefix="uc2" %>
<%@ Register src="CtlMensajes.ascx" tagname="CtlMensajes" tagprefix="uc3" %>
<%@ Register src="CtlTxt.ascx" tagname="CtlTxt" tagprefix="uc4" %>
<table width="100%" class="fondoPantalla">
<tr>
    <td class="titulo">
        <asp:Label ID="lblTituloControl" runat="server" Text="IMPORTACION DE DATOS EN EXCEL" ForeColor="White"></asp:Label>
    </td>
</tr>
<tr>
    <td>
        <fieldset>
        <table width="100%">
        <tr>
            <td><asp:Label ID="lblTipoCartera" runat="server" Text="TIPO IMPORTAR: "></asp:Label>
                <uc3:CtlMensajes ID="CtlMensajes1" runat="server" />
            </td>
            <td><uc1:CtCombo ID="cboTipoCartera" runat="server" Longitud="130" Procedimiento="QRYC008" Condicion=":cod▓108" AutoPostBack="true" /></td>
            <td><asp:Label ID="lblCartera" runat="server" Text="CARTERA: "></asp:Label></td>
            <td><uc1:CtCombo ID="cboCartera" runat="server" Longitud="150" Activa="false" /></td>
        </tr>
        <tr>
            <td><asp:Label ID="lblArchivo" runat="server" Text="ARCHIVO: "></asp:Label></td>
            <td><asp:FileUpload ID="FileArchivo" runat="server" /></td>
            <td><asp:Label ID="lblMotivo" runat="server" Text="Motivo: "></asp:Label></td>
            <td><uc4:CtlTxt ID="txtMotivo" runat="server" Largo="100px" Maximo="50" />
                <asp:TextBox ID="txtFechaCorte" runat="server"  Width="80px" Enabled = "false" 
                    BackColor="White"/>
                <img ID="fecha2" alt="calendario" height="16"  onclick="return showCalendar('fecha1','<%=txtFechaCorte.ClientID%>','%d/%m/%Y','24', true);" 
                src="Imagenes/calendario.png" width="18" />
                Fecha Corte</td>
        </tr>
        <tr>
            <td><asp:Label ID="lblFechaInicio" runat="server" Text="Fecha Registro: "/></td>
            <td>
                <asp:TextBox ID="txtFechaInicio" runat="server"  Width="80px" Enabled = "false" BackColor="White"/>
                <img ID="fecha" alt="calendario" height="16"  onclick="return showCalendar('fecha','<%=txtFechaInicio.ClientID%>','%d/%m/%Y','24', true);" 
                src="Imagenes/calendario.png" width="18" />
            </td>
            <td><asp:Label ID="lblFechaFin" runat="server" Text="Fecha Termino: "/></td>
            <td>
                <asp:TextBox ID="txtFechaFin" runat="server"  Width="80px" Enabled = "false" BackColor="White"/>
                <img ID="fecha1" alt="calendario" height="16"  onclick="return showCalendar('fecha1','<%=txtFechaFin.ClientID%>','%d/%m/%Y','24', true);" 
                src="Imagenes/calendario.png" width="18" />
            </td>
        </tr>
        <tr>
            <td colspan="4">
            <table width="100%">
            <tr>
                <td></td>
                <td width="35px" style="text-align:right">
                    <div class="curvo">
                    <asp:ImageButton id="btnImportar" runat="server" Height="30px" Width="30px" ImageUrl="~/Imagenes/Importar.png" ToolTip="Importar Archivo en Excel" />
                    <asp:Label ID="lblImportar" runat="server" Text="Importar" Font-Size="9px"></asp:Label>
                    </div>
                </td>
                <td width="35px" style="text-align:right">
                    <div class="curvo">
                    <asp:ImageButton id="btnBuscar" runat="server" Height="30px" Width="30px" ToolTip="Buscar Carga" ImageUrl="~/Imagenes/BotonBusquedaPequena.png" />
                    <asp:Label ID="lblBuscar" runat="server" Text="Buscar" Font-Size="9px"></asp:Label>
                    </div>
                </td>
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
        <fieldset>
            <uc2:CtlGrilla ID="CtlGrilla1" runat="server" Activa_ckeck="FALSE" Activa_Delete="true" Activa_Edita="true" Activa_option="false" Desactiva_Boton="false" Ancho="970px" Largo="350px"/>
        </fieldset>
    </td>
</tr>

</table>

<asp:Timer ID="Timer1" runat="server" Interval="60000">
</asp:Timer>