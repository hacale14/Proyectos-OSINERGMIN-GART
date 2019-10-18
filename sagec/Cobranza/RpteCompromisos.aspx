<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.Master" CodeBehind="RpteCompromisos.aspx.vb" Inherits="Cobranza.RpteCompromisos" 
    title="Página sin título" %>
<%@ Register src="Controles/CtCombo.ascx" tagname="CtCombo" tagprefix="uc1" %>
<%@ Register src="Controles/CtlGrilla.ascx" tagname="CtlGrilla" tagprefix="uc2" %>
<%@ Register src="Controles/CtlMensajes.ascx" tagname="CtlMensajes" tagprefix="uc3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
    </style>
    <style type="text/css">
    thead th{
    padding:15px;
    color:#fff;
    text-shadow:1px 1px 1px #568F23;
    border:1px solid #93CE37;
    border-bottom:3px solid #9ED929;
    background-color:#9DD929;
    background:-webkit-gradient(
        linear,
        left bottom,
        left top,
        color-stop(0.02, rgb(123,192,67)),
        color-stop(0.51, rgb(139,198,66)),
        color-stop(0.87, rgb(158,217,41))
        );
    background: -moz-linear-gradient(
        center bottom,
        rgb(123,192,67) 2%,
        rgb(139,198,66) 51%,
        rgb(158,217,41) 87%
        );
    -webkit-border-top-left-radius:5px;
    -webkit-border-top-right-radius:5px;
    -moz-border-radius:5px 5px 0px 0px;
    border-top-left-radius:5px;
    border-top-right-radius:5px;
    }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contenido" runat="server">
<asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
<ProgressTemplate>    		
		<div style="position:absolute;top:200px;left:500px;">
			<img src="Imagenes/loader.gif"/>    		
		</div>		
</ProgressTemplate>
</asp:UpdateProgress>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
        <center>
            <table align="center" style="background:#2E4172;" cellpadding="0" cellspacing="0" class="style1" width="20%" >                
                <tr>                    
                    <td style="font-size:medium; font-family:Arial; background:#2E4172; color:white"  
                        colspan="4" align="right"><center>
                        RESUMEN DE COMPROMISOS DIARIOS
                        <uc3:CtlMensajes ID="CtlMensajes1" runat="server" />
                        </center></td>                   
                </tr>                 
                <tr>
                    <td width=26%%>
                        <fieldset>
                        <legend style="font-family:Arial; font-size:larger">POR HORA Y CARTERA</legend>
                        <large>CARTERA :</large><uc1:CtCombo ID="CtCombo1" runat="server" Longitud="200" Procedimiento="QRYC007" AutoPostBack="true"/>
                            <asp:Button ID="bTNiR" runat="server" Text="Ir" Height="21px" Width="21px" />
                            <asp:Button ID="BtnMetas" runat="server" Text="Ingresar Metas" Height="21px" 
                                Width="101px" />                                                
                            <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Red" Text="Label" Visible="False"></asp:Label>
                            <asp:Label ID="Label3" runat="server" Text="INGRESAR META: " Visible="False"></asp:Label>
                            <asp:TextBox ID="TextBox1" runat="server" Width="50px"   Height="10px" Visible="false" ></asp:TextBox>
                            <asp:Label ID="lblCaida" runat="server" Text="CAIDA: " Visible="False"></asp:Label>
                            <asp:TextBox ID="TextBox2" runat="server" Width="17px"   Height="10px" Visible="false" ></asp:TextBox>
                            <asp:Label ID="lblHW" runat="server" Text="HORA TRABAJADAS: " Visible="False"></asp:Label>
                            <asp:TextBox ID="TextBox3" runat="server" Width="17px"   Height="10px" Visible="false" ></asp:TextBox>
                            <asp:Button ID="BtnMetas0" runat="server" Height="21px" Text="Grabar Metas" 
                                Visible="False" Width="101px" />
                        <fieldset width="90%">                                                
                        <uc2:CtlGrilla ID="CtlGrilla1" runat="server" Desactiva_Boton="false" Desactivar_Exportar="true" Activa_ckeck="false" Activa_Delete="false" Activa_Edita="false" Activa_Export="false" Activa_option="false"/>
                        <center><asp:Button ID="BtnExportar" runat="server" Text="Exportar Data a Excel" Height="21px" Width="200px" /></center> 
                        </fieldset>
                                                
                    </td>
                    <td width=40%>
                        <fieldset >
                        <legend style="font-family:Arial; font-size:larger">POR GESTOR Y CARTERA</legend>                        
                        <large>GESTOR :</large><uc1:CtCombo ID="cboGestor" runat="server" Longitud="200" AutoPostBack="true"/>
                        <fieldset>                                                
                        <uc2:CtlGrilla ID="CtlGrilla2" runat="server" Desactiva_Boton="false" Desactivar_Exportar="true" Activa_ckeck="false" Activa_Delete="false" Activa_Edita="false" Activa_Export="false" Activa_option="false"/>                        
                        </fieldset>                            
                        </fieldset>
                    </td>
                </tr>
                <tr>                    
                        <asp:Timer ID="Timer1" runat="server" Interval="360000">
                        </asp:Timer>
                    </td>
                    <td>
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                    <td></td>
                </tr>
            </table>
            </center>             
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
