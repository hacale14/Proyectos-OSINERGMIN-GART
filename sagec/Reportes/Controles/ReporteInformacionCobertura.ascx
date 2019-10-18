<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="ReporteInformacionCobertura.ascx.vb" Inherits="Controles.ReporteInformacionCobertura" %>
<%@ Register src="CtlGrilla.ascx" tagname="CtlGrilla" tagprefix="uc1" %>

<%@ Register src="CtCombo.ascx" tagname="CtCombo" tagprefix="uc3" %>
<%@ Register src="CtlMensajes.ascx" tagname="CtlMensajes" tagprefix="uc2" %>
<table style="width: 100%;" align="center">
<tr align="center">
<td align="center" style="text-align:center;" class="titulo">
    <asp:Label id="lblTituloControl" runat="server"></asp:Label>
    <uc2:CtlMensajes ID="CtlMensajes1" runat="server" />
</td>
</tr>
</table>

<center>
<table style="width: 95%">
		<tr>
			<td colspan="2">
		    <fieldset>
			<table style="width: 100%" border="0">
				<tr>
				    <td width="50px"></td>
					<td>
			            <asp:Label id="Label2" runat="server" CssClass="lbl" Text="CARTERA"></asp:Label>
					</td>
					<td width="220">
			            <uc3:CtCombo ID="cboCartera" runat="server" Activa="true" Longitud="200" Procedimiento="QRYC007" Condicion="" />
					</td>
					<td width="290px">
					    <div runat="server" id="GrupoGestor">
			                <asp:Label id="Label1" runat="server" CssClass="lbl" Text="GESTOR" style="float:left;padding-left:0px;position:relative;top:5px;"></asp:Label>

					        <uc3:CtCombo ID="cboGestor" runat="server" Activa="true" Condicion="" Longitud="200" />
                        </div>
					</td>
					<td width="100">
			            <asp:Label id="Label3" runat="server" CssClass="lbl" Text="FECHA INICIO"></asp:Label>
					</td>
					<td width="150">
			            <asp:TextBox ID="txtFechaInicio" runat="server"  Width="100px" Enabled = "false" CssClass="textoContenido"/>
                        <img ID="txtFechaInicio" alt="calendario" height="16"  onclick="return showCalendar('txtFechaInicio','<%=txtFechaInicio.ClientID%>','%d/%m/%Y','24', true);" src="Imagenes/calendario.png" width="18" />							
					</td>
					<td width="80">
			            <asp:Label id="Label4" runat="server" CssClass="lbl" Text="FECHA FIN"></asp:Label>
					</td>
					<td width="150">
			            <asp:TextBox ID="txtFechaFin" runat="server"  Width="100px" Enabled = "false" CssClass="textoContenido"/>
                        <img ID="txtFechaFin" alt="calendario" height="16" onclick="return showCalendar('txtFechaFin','<%=txtFechaFin.ClientID%>','%d/%m/%Y','24', true);" src="Imagenes/calendario.png" width="18" />
					</td>
					<td width="100px"></td>
					<td align="center" style="text-align:center;">
					    <div class="curvo">
			                <asp:ImageButton id="ImageButton1" runat="server" ImageUrl="~/imagenes/BotonGenerarReporte.png" CssClass="curvoimg" />
			                <asp:Label id="Label19" runat="server" Text="Reporte" CssClass="curvolbl"></asp:Label>
					    </div>
					</td>
				</tr>
			</table>
			</fieldset>
			</td>
		</tr>
</table>
	
	
	<fieldset style="width:800px;">
	<legend>GRAFICO</legend>
	<table width="100%" border="0">
		<tr>
			<td align="center" style="text-align:center; vertical-align:top;">	
                <asp:CHART id="Chart1" runat="server" Palette="BrightPastel" Height="250px" Width="350px" ImageLocation="~/TempImages/ChartPic_#SEQ(300,3)" BackColor="Transparent" >
							<titles>
								<asp:Title Name="Title1" ForeColor="black"></asp:Title>
							</titles>
							<legends>
								<asp:Legend TableStyle="Wide" BackColor="Transparent" Alignment="Near" Docking="Top" Name="Default" LegendItemOrder="SameAsSeriesOrder" LegendStyle="Table"></asp:Legend>
							</legends>
							<borderskin SkinStyle="Sunken"></borderskin>
							<series>
								<asp:Series Name="Series1" ChartType="Pie" BorderColor="180, 26, 59, 105" Color="220, 65, 140, 240" Label="#PERCENT{P2}" LabelBackColor="Black" LabelForeColor="White" LegendText="#VALX" LabelBorderDashStyle="Solid" LabelFormat=""></asp:Series>
							</series>
							<chartareas>
								<asp:ChartArea Name="ChartArea1" BackSecondaryColor="Transparent" BackColor="Transparent" Area3DStyle-Enable3D="true">			
								</asp:ChartArea>
							</chartareas>
                    </asp:CHART>
            </td>
		</tr>
		<tr>
		    <td style="text-align:center; ">
				<uc1:CtlGrilla ID="CtlGrilla1" runat="server" Ancho="500px" Activa_ckeck="false" Activa_option="false" Desactiva_Boton="false" />
			</td>
		</tr>
	</table>
	</fieldset>
	</center>