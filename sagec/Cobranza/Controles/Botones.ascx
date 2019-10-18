<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="Botones.ascx.vb" Inherits="Controles.Botones" %>

<%@ Register src="~/Controles/NAsignacion.ascx" tagname="NAsignacion" tagprefix="uc1" %>
<%@ Register src="~/Controles/ConsultaClientes.ascx" tagname="ConsultaClientes" tagprefix="uc2" %>
<%@ Register src="~/Controles/DefinirCondicion.ascx" tagname="DefinirCondicion" tagprefix="uc3" %>

<table style="width: 100%">
		<tr>
		    <td><asp:Label ID="lblTituloPrincipal" runat="server" Text="" Visible="false"></asp:Label></td>
			<td style="text-align:right;" width="35px">
			    <div class="curvoG">                
			    <asp:ImageButton id="btnNuevo" runat="server" Height="30px" Width="30px" ImageUrl="~/imagenes/botonNuevo.jpg" ToolTip="Nueva Asignacion" />
			    <asp:Label id="lblNuevo" runat="server" Font-Size="9px" Text="Nueva" />
			    <asp:Label id="Label3" runat="server" Font-Size="9px" Text="Asig." />
			    </div>
			</td>
			<td style="text-align:right;" width="35px">
			    <div class="curvoG">                
			    <asp:ImageButton id="btnImpInfAdicional" runat="server" Height="30px" Width="30px" ImageUrl="~/Imagenes/botonExcel.jpg" ToolTip="Importar Informacion Adicional" />
			    <asp:Label id="lblImpInfAdicional" runat="server" Font-Size="9px" Text="Importar" />
			    <asp:Label id="Label2" runat="server" Font-Size="9px" Text="Inf.Adic." />
			    </div>
			</td>
			<td style="text-align:right;" width="35px">
			    <div class="curvoG">                
			    <asp:ImageButton id="btnImportarAsignacion" runat="server" Height="30px" Width="30px" ImageUrl="~/imagenes/botonExcel.jpg" ToolTip="Importar Asignaciones" />
			    <asp:Label id="lblImportarAsignacion" runat="server" Font-Size="9px" Text="Importar" />
			    <asp:Label id="Label1" runat="server" Font-Size="9px" Text="Asig." />
			    </div>
			</td>
			<td style="text-align:right;" width="35px">
			    <div class="curvoG">
			    <asp:ImageButton id="btnDefinirCD" runat="server" Height="30px" Width="30px" ImageUrl="~/imagenes/BotonDefinirCD.jpg" ToolTip="Definir CD" />
			    <asp:Label id="lblDefinirCD" runat="server" Font-Size="9px" Text="Definir" />
			    <asp:Label id="Label4" runat="server" Font-Size="9px" Text="CD" />
			    </div>
			</td>
			<td style="text-align:right;" width="35px">
			    <div class="curvoG">
			    <asp:ImageButton id="btnImpDirCast" runat="server" Height="30px" Width="30px" ImageUrl="~/imagenes/botonExcel.jpg"  ToolTip="Importar Dir. Castigo" />
			    <asp:Label id="lblImpDirCast" runat="server" Font-Size="9px" Text="Importar" />
			    <asp:Label id="lblImpDirCast1" runat="server" Font-Size="9px" Text="Dir.Cast"/>
			    </div>
			</td>
			<td style="text-align:right;" width="35px">
			    <div class="curvoG">
			    <asp:ImageButton id="btnImpDirAct" runat="server" Height="30px" Width="30px" ImageUrl="~/imagenes/botonExcel.jpg" ToolTip="Importar Dir. Activa" />
			    <asp:Label id="lblImpDirAct" runat="server" Font-Size="9px" Text="Importar" />
			    <asp:Label id="lblImpDirAct1" runat="server" Font-Size="9px" Text="Dir.Act." />
			    </div>
			</td>
			<td style="text-align:right;" width="35px">
			    <div class="curvoG">
			    <asp:ImageButton id="btnImportarTelefonos" runat="server" Height="30px" Width="30px" ImageUrl="~/imagenes/BotonImportarTelefonos.png" ToolTip="Importar Telefonos" />
			    <asp:Label id="lblImportarTelefonos" runat="server" Font-Size="9px" Text="Importar" />
			    <asp:Label id="lblImportarTelefonos1" runat="server" Font-Size="9px" Text="Telefono" />
			    </div>
			</td>
			<td style="text-align:right;" width="35px">
			    <div class="curvoG">
			    <asp:ImageButton id="btnGestionar" runat="server" Height="30px" Width="30px" ImageUrl="~/imagenes/BotonGestionar.png"  ToolTip="Gestionar"/>
			    <asp:Label id="lblGestionar" runat="server" Font-Size="9px" Text="Gestionar" />
			    <asp:Label id="lblGestionar1" runat="server" Font-Size="9px" Text="Cliente" />
			    </div>
			</td>
			<td style="text-align:right;" width="35px">
			    <div class="curvoG">
			    <asp:ImageButton id="btnImportarHistorico" runat="server" Height="30px" Width="30px" ImageUrl="~/imagenes/botonExcel.jpg" ToolTip="Importar Historial" />
			    <asp:Label id="lblImportarHistorico" runat="server" Font-Size="9px" Text="Importar"></asp:Label>
			    <asp:Label id="lblImportarHistorico1" runat="server" Font-Size="9px" Text="Histórico"></asp:Label>
			    </div>
			</td>
		</tr>
	</table>
<div style="height:auto; width:auto; position: absolute; left:30%; top:20%; border:none" >
    <uc1:NAsignacion ID="NAsignacion1" runat="server" Visible="false" />    
</div>
<div style="height:auto; width:auto; position: absolute; left:10%; top:20%; border:none" >
    <uc3:DefinirCondicion ID="DefinirCondicion1" runat="server" Visible ="false" />
</div>