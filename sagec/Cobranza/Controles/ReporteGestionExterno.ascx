<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="ReporteGestionExterno.ascx.vb" Inherits="Controles.ReporteGestionExterno" %>
<%@ Register src="CtlGrilla.ascx" tagname="CtlGrilla" tagprefix="uc1" %>
<table style="width: 100%;" align="center">
<tr align="center">
<td align="center" style="text-align:center;">
    <asp:Label id="lblTituloControl" runat="server" Font-Size="16px" 
        Font-Bold="True"></asp:Label>
</td>
</tr>
</table>
<table style="width: 100%">
	<tr>
		<td>
	<fieldset style="margin:0; padding:0;">
	<legend>
	<asp:Label id="Label12" runat="server" Font-Size="11px" Text="FILTRAR POR"></asp:Label>
	</legend>
	<table style="width: 100%">
		<tr align="center">
			<td rowspan="2">
			<asp:Label id="Label1" runat="server" Font-Size="11px" Text="CARTERA"></asp:Label>
			    <br />
			<asp:DropDownList id="cboCartera" runat="server" Font-Size="10px">
				<asp:ListItem Value="0">Seleccione</asp:ListItem>
			</asp:DropDownList>
			</td>
			<td rowspan="2">
			<asp:Label id="Label20" runat="server" Font-Size="11px" Text="GESTOR"></asp:Label>
			    <br />
			<asp:DropDownList id="cboGestor" runat="server" Font-Size="10px">
				<asp:ListItem Value="0">Seleccione</asp:ListItem>
			</asp:DropDownList>
			</td>
			<td rowspan="2">
			<asp:Label id="Label21" runat="server" Font-Size="11px" Text="CONDIC."></asp:Label>
			    <br />
			<asp:DropDownList id="cboCondic" runat="server" Font-Size="10px">
				<asp:ListItem Value="0">Seleccione</asp:ListItem>
			</asp:DropDownList>
			</td>
			<td style="width: 129px" rowspan="2">
			<asp:Label id="Label2" runat="server" Font-Size="11px" Text="TIPO GEST."></asp:Label>
			<asp:DropDownList id="cboTipoGest" runat="server" Font-Size="10px">
				<asp:ListItem Value="0">Seleccione</asp:ListItem>
			</asp:DropDownList>
			</td>
			<td rowspan="2">
			<asp:Label id="Label22" runat="server" Font-Size="11px" Text="COD. IND."></asp:Label>
			    <br />
			<asp:DropDownList id="cboCodInd" runat="server" Font-Size="10px">
				<asp:ListItem Value="0">Seleccione</asp:ListItem>
			</asp:DropDownList>
			</td>
			<td>
			<asp:Label id="Label3" runat="server" Font-Size="11px" Text="INICIO"></asp:Label>
			</td>
			<td>
			<asp:Label id="Label6" runat="server" Font-Size="11px" Text="FIN"></asp:Label>
			</td>
			<td align="center" rowspan="2" style="text-align:center;">
			<asp:ImageButton id="ImageButton1" runat="server" Height="30px" 
                    ImageUrl="~/Imagenes/boton busqueda.jpg" Width="45px" />
			<br />
			<asp:Label id="Label19" runat="server" Font-Size="11px" Text="Buscar"></asp:Label>
			</td>
		</tr>
		<tr align="center">
			<td>
			<asp:TextBox ID="txtFechaInicio" runat="server"  Width="100px" Enabled = "false" BackColor="White" BorderColor="Black" BorderWidth = "1" Font-Size="11px" />
                            <img id="fecha1" alt="calendario" height="24" valign="middle"
                            onclick="return showCalendar('fecha1','<%=txtFechaInicio.ClientID%>','%d/%m/%Y','24', true);" 
                            src="~/Imagenes/calendario.png" width="24" />
			</td>
			<td>
			<asp:TextBox ID="txtFechaFin" runat="server"  Width="100px" Enabled = "false" BackColor="White" BorderColor="Black" BorderWidth = "1" Font-Size="11px" />
                            <img id="fecha2" alt="calendario" height="24" valign="middle"
                            onclick="return showCalendar('fecha2','<%=txtFechaFin.ClientID%>','%d/%m/%Y','24', true);" 
                            src="~/Imagenes/calendario.png" width="24" />
			</td>
		</tr>
	</table>
	</fieldset><br />
	<div style="height: 350px; width:100%;overflow:scroll; background-color:#F5F5F5;">
	    <uc1:CtlGrilla ID="CtlGrilla1" runat="server" />
	</div>
	<table style="width: 100%">
		<tr align="center">
			<td align="center" style="text-align:center;">
			<div class="curvo">
			<asp:ImageButton id="imgExportarExcel" runat="server" Height="30px" Width="35px" 
                    ImageUrl="~/imagenes/BotonExportarExcel.jpg" />
			<asp:Label id="Label16" runat="server" Font-Size="11px" Text="Exportar a Excel"></asp:Label>
			</div>
			</td>
			<td align="center" style="text-align:center;">
			<div class="curvo">
			<asp:ImageButton id="imgVerTodasGestion" runat="server" Height="30px" Width="35px" 
                    ImageUrl="~/imagenes/VerTodasGestiones.png" />
			<asp:Label id="Label17" runat="server" Font-Size="11px" Text="Ver todas las getiones"></asp:Label>
			</div>
			</td>
		</tr>
	</table>

		</td>
	</tr>
</table>
