<%@ Page Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="RpteProyectado.aspx.cs" Inherits="Reportes.RpteProyectado" Title="Página sin título" %>
<%@ Register src="Controles/CtCombo.ascx" tagname="CtCombo" tagprefix="uc1" %>
<%@ Register src="Controles/CtlGrilla.ascx" tagname="CtlGrilla" tagprefix="uc2" %>
<%@ Register src="Controles/CtlMensajes.ascx" tagname="CtlMensajes" tagprefix="uc3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .TextContenido
        {
        	font-family:Calibri;
        	  color: #fff;
              text-shadow: -2px 2px #346392;
              background-color: #2E4172;
              background-image: linear-gradient(top, #fff, #fff);
              box-shadow: inset 0 0 0 1px #27496d;
              border: none;
              height: 20px; 
              border-radius: 5px;
              text-align :center;
        	}
        .Consulta
        {
        	  font-family:Calibri;        	  
              background-color: #2E4172;                            
              border-radius: 15px;
            }
        .button1
        {
        	  font-family:Calibri;
        	  color: #fff;
              text-shadow: -2px 2px #346392;
              background-color: #2E4172;
              background-image: linear-gradient(top, #fff, #fff);
              box-shadow: inset 0 0 0 1px #27496d;
              border: none;
              border-radius: 15px;                            
            }
 button1:hover,
button1.hover {
  box-shadow: inset 0 0 0 1px #27496d,0 5px 15px #193047;
}

button1:active,
button1.active {
  box-shadow: inset 0 0 0 1px #27496d,inset 0 5px 30px #193047;
}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contenido" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
        <center>
            <table align="center" style="background:#2E4172;" cellpadding="0" cellspacing="0" class="style1" width="20%" >                
                <tr>                    
                    <td style="font-size:medium; font-family:Calibri; background:#2E4172; color:white"  
                        colspan="4" align="right"><center>
                            REPORTE DE PROYECCION DE RECAUDO 
                        <uc3:CtlMensajes ID="CtlMensajes1" runat="server" />
                        </center></td>                   
                </tr>                 
                <tr>
                    <td style="font-family:Calibri;">
                        <fieldset>
                        <legend style="font-family:Calibri; font-size:larger">PROYECCION POR CARTERA MES</legend>
                        
                            <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="White" Text="CORPORACION :"/><uc1:CtCombo ID="cboCorporacion" runat="server" Longitud="100" Procedimiento="QRYC018" AutoPostBack="true"/>
                            <asp:Label ID="Label7" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="White" Text="EMPRESA :"/><uc1:CtCombo ID="cboempresa" runat="server" Longitud="100" Procedimiento="QRYC015" AutoPostBack="true"/>
                            <asp:Label ID="Label8" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="White" Text="GRUPO :"/><uc1:CtCombo ID="cboGrupo" runat="server" Longitud="100" Procedimiento="QRYC016" AutoPostBack="true"/>
                            <asp:Label ID="Label9" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="White" Text="CARTERA :"/><uc1:CtCombo ID="CtCombo1" runat="server" Longitud="100" Procedimiento="QRYC017" AutoPostBack="true"/>
                                                    
                            <asp:Button CssClass="button1" ID="bTNiR" runat="server" Text="Ir" Height="21px" Width="21px" />
                            <asp:Button CssClass="button1"  ID="BtnMetas" runat="server" Text="Ing. Metas" Height="21px"/>                                                
                            (PDP):<asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="White" Text="Label" Visible="False"></asp:Label>/ 
                            (DIAS):<asp:Label ID="Label5" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="White" Text="Label" Visible="False"></asp:Label>/
                            (REC):<asp:Label ID="Label6" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="White" Text="Label" Visible="False"></asp:Label>
                            <asp:Label ID="Label3" runat="server" Text="ING. META PDP: " Visible="False"></asp:Label>
                            <asp:TextBox ID="TextBox1" runat="server" Width="50px" ReadOnly="true"  BackColor="#FFFFAC" Height="10px" Visible="false" ></asp:TextBox>
                            <asp:Label ID="Label4" runat="server" Text="RECAUDO: " Visible="false"></asp:Label>
                            <asp:TextBox ID="TextBox4" runat="server" Width="50px"   Height="10px" Visible="false" ></asp:TextBox>
                            <asp:Label ID="lblCaida" runat="server" Text="CAIDA: " Visible="False"></asp:Label>
                            <asp:TextBox ID="TextBox2" runat="server" Width="17px" ReadOnly="true" BackColor="#FFFFAC"  Height="10px" Visible="false" ></asp:TextBox>
                            <asp:Label ID="lblHW" runat="server" Text="DIAS LABORABLES: " Visible="False"></asp:Label>
                            <asp:TextBox ID="TextBox3" runat="server" Width="17px"  ReadOnly="true" BackColor="#FFFFAC"  Height="10px" Visible="false" ></asp:TextBox>
                            <asp:Button CssClass="button1"  ID="BtnMetas0" runat="server" Height="21px" Text="Grabar Metas" Visible="False"/>
                            <asp:Button CssClass="button1"  ID="BtnMostrarTodo" runat="server" Text="Mostrar Todo" Height="21px" />                                                
                            <asp:Button CssClass="button1"  ID="BtnSoloResumen" runat="server" Text="Solo Resumen" Height="21px" />                                                
                            <asp:Button CssClass="button1"  ID="BtnExportaPagos" runat="server" Text="Exporta Pagos" Height="21px" />
                            <asp:Button CssClass="button1"  ID="BtnExportaCompromisos" runat="server" Text="Exporta PDP" Height="21px"/>                      
                            <asp:Button CssClass="button1"  ID="BtnMostrar" runat="server" Text="Muestra Timing" Height="21px"/>                      
                       </fieldset>                         
                    </td>                                        
                </tr>
                <tr>                                           
                    <td>
                        
                        <div class="Consulta">
                        <uc2:CtlGrilla ID="CtlGrilla1"  runat="server" Desactiva_Boton="false" Desactivar_Exportar="true" Activa_ckeck="false" Activa_Delete="false" Activa_Edita="false" Activa_Export="false" Activa_option="false"/>
                        </div>                        
                        <asp:Timer ID="Timer1" runat="server" Interval="360000"></asp:Timer>                   
                        
                    </td>
                </tr>
            </table>               
            </center>             
        </ContentTemplate>
    </asp:UpdatePanel>
      <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1" DisplayAfter="1">
	<ProgressTemplate>
        <div class="loading"></div>        
    </ProgressTemplate>
    </asp:UpdateProgress>
</asp:Content>
