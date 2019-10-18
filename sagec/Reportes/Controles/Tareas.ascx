<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="Tareas.ascx.vb" Inherits="Controles.Tareas" %>
<%@ Register src="CtCombo.ascx" tagname="CtCombo" tagprefix="uc1" %>

<%@ Register src="CtlGrilla.ascx" tagname="CtlGrilla" tagprefix="uc2" %>

<%@ Register src="CtlMensajes.ascx" tagname="CtlMensajes" tagprefix="uc3" %>

<table style="width: 100%;" align="center">
<tr align="center">
<td align="center" style="text-align:center;" class="titulo">
    <asp:Label ID="lblTituloControl" runat="server"></asp:Label>    
    <uc3:CtlMensajes ID="CtlMensajes1" runat="server" />
</td>
</tr>
</table>
<table style="width: 100%;" align="center">
<tr>
<td align="center" valign="top" style="vertical-align:top; text-align:center;">
<fieldset>
<legend>DESCRIPCION DE TAREA</legend>
<table>
    <tr>
        <td>
            PERIODO DE TAREA</td>
        <td>
            <uc1:CtCombo ID="cboPeriodo" runat="server" Condicion=":condicion▓111" 
                Procedimiento="QRYMG001" AutoPostBack="true" />
        </td>
        <td rowspan="5">
            <div class="curvo">
			<asp:ImageButton id="imgGrabar" runat="server" Height="30px" Width="35px" 
                    ImageUrl="~/imagenes/BotonGrabar.png" />
			<asp:Label id="Label4" runat="server" Font-Size="11px" Text="Grabar"></asp:Label>
			</div>
        </td>
        <td rowspan="5">
            <div class="curvo">
			<asp:ImageButton id="imgEjecutar" runat="server" Height="30px" Width="35px" 
                    ImageUrl="~/imagenes/ejecuta.png" />
			<asp:Label id="Label1" runat="server" Font-Size="11px" Text="Ejecutar"></asp:Label>
			</div>
        </td>
    </tr>
    <tr>
        <td colspan="2">
            <uc1:CtCombo ID="cboDesPeriodo" runat="server" Condicion=":condicion▓111" 
                Procedimiento="QRYMG001" Visible="False"  />
            <asp:TextBox ID="txtesporadico" runat="server" Visible="False" Width="110px"></asp:TextBox>
            
            <uc1:CtCombo ID="cboHora" runat="server" Visible="True" />
            Horas
            <uc1:CtCombo ID="cboMinuto" runat="server" />
            Minutos
            <uc1:CtCombo ID="cboSegundo" runat="server" />
            Segundos
        </td>
    </tr>
    <tr>
        <td>
            EJECUCION</td>
        <td>
            <asp:TextBox ID="txtEjecucion" runat="server" Width="470px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            DESCRIPCION</td>
        <td>
            <asp:TextBox ID="txtDescripcion" runat="server" Width="470px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    </table>
</fieldset>
</td>
</tr>
<tr>
<td>
    <table>
    <tr>
    <td>
    <fieldset>
    <uc2:CtlGrilla ID="CtlGrilla1" runat="server" Ancho="930px" Largo="200px" Activa_Export="true" Activa_ckeck="false" Activa_Delete="true" Activa_Edita="false" Activa_option="false" Desactiva_Boton="false" />
    </fieldset>
    </td>
    </tr>
    </table>
</td>
</tr>
</table>
