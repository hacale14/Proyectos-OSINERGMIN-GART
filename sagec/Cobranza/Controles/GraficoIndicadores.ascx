<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="GraficoIndicadores.ascx.vb" Inherits="Controles.GraficoIndicadores" %>
<%@ Register assembly="System.Web.DataVisualization, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>

<table style="width: 100%;" align="center">
<tr align="center">
<td align="center" style="text-align:center;" class="titulo">
    <asp:Label id="lblTituloControl" runat="server" Text="GRAFICO DE INDICADORES"></asp:Label>
</td>
</tr>
</table>


<table>
    <tr>
        <td>
            <%--<asp:Chart ID="TortaEfectividad" runat="server" Width="500px" Height="00px" BackColor="Transparent">
                <Series>
                    <asp:Series Name="Series1"  ChartType="Pie" ChartArea="ChartArea1" Label="#PERCENT{P2}" LegendText="#VALX" LabelForeColor="White" LabelBackColor="Black">
                </asp:Series>         
                </Series>
                <ChartAreas>
                    <asp:ChartArea Name="ChartArea1" BackColor="Transparent" Area3DStyle-Enable3D="true" >
                    </asp:ChartArea>
                </ChartAreas>
                <Legends>
                    <asp:Legend Name="Default"/>
                </Legends>
            </asp:Chart>--%>
            
            <asp:CHART id="TortaEfectividad" runat="server" Palette="BrightPastel" Height="300px" Width="300px" ImageLocation="~/TempImages/ChartPic_#SEQ(300,3)" BackColor="Transparent">
							<titles>
								<asp:Title ShadowColor="32, 0, 0, 0" ShadowOffset="3" Name="Title1" ForeColor="26, 59, 105"></asp:Title>
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
        <td>
            <%--<asp:Chart ID="TortaCobertura" runat="server" Width="400px" Height="300px" 
            Palette="BrightPastel" BackColor="Transparent">
                <Series>
                    <asp:Series Name="Series1" ChartType="Pie" ChartArea="ChartArea1" Legend="Default" Label="#PERCENT{P2}" LegendText="#VALX" LabelForeColor="White" LabelBackColor="Black">
                    </asp:Series>
                </Series>
            <ChartAreas>
                <asp:ChartArea Name="ChartArea1" BackColor="Transparent" Area3DStyle-Enable3D="true" >
                </asp:ChartArea>
            </ChartAreas>
            <Titles>
                <asp:Title Text="Indice de Cobertura" />
            </Titles>
            <Legends>
                <asp:Legend Name="Default"/>
            </Legends>
            </asp:Chart>--%>
            
            <asp:CHART id="TortaCobertura" runat="server" Palette="BrightPastel" Height="300px" Width="300px" ImageLocation="~/TempImages/ChartPic_#SEQ(300,3)" BackColor="Transparent">
							<titles>
								<asp:Title ShadowColor="32, 0, 0, 0" ShadowOffset="3" Name="Title1" ForeColor="26, 59, 105"></asp:Title>
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
        <td colspan="2" style="text-align:center;" align="center">
            <div style="margin:auto;">
                <%--<asp:Chart ID="TortaPDP" runat="server" Width="400px" Height="300px" Palette="BrightPastel" 
                BackColor="Transparent">
                    <Series>
                        <asp:Series Name="Series1" ChartType="Pie" ChartArea="ChartArea1" Legend="Default" Label="#PERCENT{P2}" LegendText="#VALX" LabelForeColor="White" LabelBackColor="Black">
                        </asp:Series>
                    </Series>
                <ChartAreas>
                    <asp:ChartArea Name="ChartArea1" BackColor="Transparent" Area3DStyle-Enable3D="true" >
                </asp:ChartArea>
                </ChartAreas>
                <Titles>
                    <asp:Title Text="Indice de Cierre PDP" />
                </Titles>
                <Legends>
                    <asp:Legend Name="Default"/>
                </Legends>
                </asp:Chart>--%>
                
                <asp:CHART id="TortaPDP" runat="server" Palette="BrightPastel" Height="300px" Width="300px" ImageLocation="~/TempImages/ChartPic_#SEQ(300,3)" BackColor="Transparent">
							<titles>
								<asp:Title ShadowColor="32, 0, 0, 0" ShadowOffset="3" Name="Title1" ForeColor="26, 59, 105"></asp:Title>
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
            </div>
        </td>
    </tr>
    <tr>
        <td align="right" text-align:right;" colspan="3">
            <div class="curvo">
                <asp:ImageButton id="imgCerrar" runat="server" Height="30px" Width="35px" 
                            ImageUrl="~/imagenes/BotonCerrar.jpg" />
                <asp:Label id="Label7" runat="server" Font-Size="11px" Text="Cerrar"></asp:Label>
            </div>
	    </td>
    </tr>
</table>


