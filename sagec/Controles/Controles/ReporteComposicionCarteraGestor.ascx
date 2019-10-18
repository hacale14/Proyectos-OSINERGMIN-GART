<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="ReporteComposicionCarteraGestor.ascx.vb" Inherits="Controles.ReporteComposicionCarteraGestor" %>
<%@ Register src="CtlGrilla.ascx" tagname="CtlGrilla" tagprefix="uc1" %>

<%@ Register src="CtCombo.ascx" tagname="CtCombo" tagprefix="uc3" %>
<%@ Register src="CtlMensajes.ascx" tagname="CtlMensajes" tagprefix="uc2" %>
<table style="width: 100%;" align="center">
<tr align="center">
<td align="center" style="text-align:center;" class="titulo">
    <asp:Label id="lblTituloControl" runat="server" ></asp:Label>
    <uc2:CtlMensajes ID="CtlMensajes1" runat="server" />
</td>
</tr>
</table>

<center>
<table width="40%">
    <tr>
        <td>
            <fieldset>
                <table style="width:100%" border=0>
	                <tr>
		                <td>
                            <asp:Label id="Label2" runat="server" CssClass="lbl" Text="CARTERA" style="float:left;padding-left:20px;position:relative;top:5px;"></asp:Label>
		                            
                            <uc3:CtCombo ID="cboCartera" runat="server" Activa="true" Procedimiento="QRYC007" Condicion="" />
		                 </td>
		                 <td>
                        <div id="GrupoGestor" runat="server">
                            <asp:Label id="Label1" runat="server" CssClass="lbl" Text="GESTOR" ></asp:Label>
                            
                            <uc3:CtCombo ID="cboGestor" runat="server" Activa="true" Condicion="" Longitud="100" />
                        </div>
                    </td>
	                    <td>
	                        <div id="GrupoInicio" runat="server">
                                <asp:Label id="Label3" runat="server" CssClass="lbl" Text="FECHA INICIO"></asp:Label>
	                            
                                <asp:TextBox ID="txtFechaInicio" runat="server"  Width="80px" Enabled = "false" BackColor="White"/>
                                <img ID="txtFechaInicio" alt="calendario" height="16"  onclick="return showCalendar('txtFechaInicio','<%=txtFechaInicio.ClientID%>','%d/%m/%Y','24', true);" 
                                src="Imagenes/calendario.png" width="18" />							
	                            </div>
	                    </td>
	                    <td>
	                        <div id="GrupoFin" runat="server">
                                <asp:Label id="Label6" runat="server" CssClass="lbl" Text="FECHA FIN"></asp:Label>
	                            
                                <asp:TextBox ID="txtFechaFin" runat="server"  Width="80px" Enabled = "false" BackColor="White"/>
                                <img ID="txtFechaFin" alt="calendario" height="16" onclick="return showCalendar('txtFechaFin','<%=txtFechaFin.ClientID%>','%d/%m/%Y','24', true);" 
                                src="Imagenes/calendario.png" width="18" />
	                        </div>
	                    </td>
	                    <td align="center" style="text-align:center;">
	                        <div class="curvo">
                                <asp:ImageButton id="imgGenerarReporte" runat="server" CssClass="curvoimg" ImageUrl="~/imagenes/BotonGenerarReporte.png" />
                                <asp:Label id="Label4" runat="server" CssClass="curvolbl" Text="Reporte"></asp:Label>
	                        </div>
	                    </td>
	                </tr>
                </table>
                </fieldset>
        </td>
    </tr>
</table>

<table width="80%">
    <tr>
        <td>
            <fieldset>
            <legend >GRAFICA</legend>
            <table style="width: 100%" border=0>
	            <tr>
	                <td valign="top" colspan="2">
		                <asp:CHART id="Chart1" runat="server" Palette="BrightPastel" Height="250" Width="350" ImageLocation="~/TempImages/ChartPic_#SEQ(300,3)" BackColor="Transparent">
					            <titles>
						            <asp:Title Name="Title1" ForeColor="black"></asp:Title>
					            </titles>
					            <legends>
						            <asp:Legend TableStyle="Wide" BackColor="Transparent" Alignment="Near" Docking="Top" Name="Default" LegendItemOrder="SameAsSeriesOrder" LegendStyle="Table"></asp:Legend>
					            </legends>
					            <borderskin SkinStyle="Sunken"></borderskin>
					            <series>
						            <asp:Series Name="Series1" ChartType="Pie" BorderColor="180, 26, 59, 105" Color="220, 65, 140, 240" Label="#PERCENT{P2}" LegendText="#VALX"></asp:Series>
					            </series>
					            <chartareas>
						            <asp:ChartArea Name="ChartArea1" BackSecondaryColor="Transparent" BackColor="Transparent" Area3DStyle-Enable3D="true">			
						            </asp:ChartArea>
					            </chartareas>
                        </asp:CHART>
		            </td>
	            </tr>
	            <tr>
		            <td colspan="2">
                        <uc1:CtlGrilla ID="CtlGrilla1" runat="server" Ancho="400px" Activa_ckeck="false" Activa_option="false" Desactiva_Boton="false" Activa_Delete="false" Activa_Edita="false" />
		            </td>
	            </tr>
	            <tr><td style="height:10px;"></td></tr>
	            <tr>
		            <td width="500px">
                        <asp:Label id="Label5" runat="server" CssClass="lbl" Text="TOTAL CLIENTES GESTIONADOS"></asp:Label>
	                </td>
	                <td style="float:left; padding-left:20px;">
			            <asp:TextBox id="txtTotalClienteCartera" Enabled="false" runat="server" CssClass="textoContenido" Width="200px"></asp:TextBox>
		            </td>
	            </tr>
            </table>
            </fieldset>
        </td>
    </tr>
</table>
</center>