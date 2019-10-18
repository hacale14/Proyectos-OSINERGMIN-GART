<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Login.aspx.vb" Inherits="Cobranza.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register src="Controles/CtlMensajes.ascx" tagname="CtlMensajes" tagprefix="uc1" %>
<%@ Register src="~/Controles/CtCombo.ascx" tagname="CtCombo" tagprefix="uc3" %>
<%@ Register src="Controles/CtCombo.ascx" tagname="CtCombo" tagprefix="uc2" %>

<!DOCTYPE html>
<html lang="es">
<head>
<meta charset="utf-8" />
<title>Acceso al Sistema</title>
<link href="Estilos.css" rel="stylesheet" type="text/css" />        
<link href="css/login.css" rel="stylesheet" type="text/css" />       
 
 <link href="https://fonts.googleapis.com/css?family=Bubbler+One|Coda|Josefin+Sans|Kalam|Righteous" rel="stylesheet">
<style>
.Button
        {
            background-color: #000;
            color: #fff;
            font-size: 20px;
            width: 150px;
            font-weight: bold;
        }
        #mybutton:hover
        {
            background-color: #fff;
            color: #000;
        }
</style>
</head>
<body style="background-image:url('/Imagenes/DF2.GIF');background-repeat: no-repeat;background-position:center;background-attachment: fixed;background-size:95% 95%;">  
    <form id="form1" runat="server">        
        <div id="Div1">
        <table  align="center" style="margin-top:170px;">
            <tr>
            <td >
                <div style="background:rgba(1,1,1,.9); border-radius:5px;">
                <table style="width:390px;"; align="center">
                	<tr>
                	    <td colspan="2" align="center">
                	    <center>
                	        <table border=0>
                	        <tr><td height=10px;></td></tr>
                	        <tr>
                	            <td style="width:155px; height:155px;" ><img src="Imagenes/pimay.jpeg" width="100%" height="100%" class="log_img" /></td>
                	        </tr>
                	        <tr>
                	            <td></td>
                	        </tr>
                	        </table>
                	     
                            <table border="0">
                            <tr><td colspan="2" class="login_tit"> <center>I N I C I A R &nbsp;&nbsp; S E S I Ó N</center></td></tr>
                            <tr><td></td><td></td></tr>             
                            <tr><td class="log_item">Usuario</td>
                            <td><asp:TextBox ID="usuario" runat="server" AutoPostBack="true"></asp:TextBox></td></tr>
                            <tr><td class="log_item">Empresa</td>
                            <td><uc2:CtCombo ID="cboEmpresa" runat="server" Longitud="268" Largo="25"  AutoPostBack="true" Procedimiento="QRYCO001"/></td></tr>
                            <tr><td class="log_item">Contraseña</td>
                            <td><asp:TextBox ID="clave" TextMode="Password" runat="server"></asp:TextBox></td></tr>
                            <%--<tr><td style="font-size:small">Perfil</td><td><uc2:CtCombo ID="cboPerfil" runat="server" Longitud="200" Largo="20" Activa="false" /></td></tr>--%>
                            <tr><td>&nbsp;</td></tr>
                            <tr><td colspan=2 align="center"><center>                                               
                            
                                <asp:Button ID="btnIngresar" runat="server" CssClass="log_btn" Text="INGRESAR" />
                                <asp:Button ID="Button2" runat="server" Text="LIMPIAR" CssClass="log_btn"/></center></td></tr>

                            <tr><td>&nbsp;</td></tr>
                        </table>
                        </center>
                        </td>
                    </tr>
        
        <tr>
        <td></td> 
        <td colspan=2 align="center">
                        <center></center>
                        </td></tr>
        </table>       
                </div>
        </div>
    
<uc1:CtlMensajes ID="CtlMensajes1" runat="server" />
    
        <p align="center"></p>
        <div style="background:rgba(2,117,216,.5); border-radius:5px;">
        <p align="center" >
            <asp:Label ID="lblMensaje" runat="server" CssClass="log_copy" Text="Derechos Reservados PIMAY SAC"></asp:Label>
        </p>
        <p align="center" >
            <asp:Label ID="lblMensaje0" runat="server" CssClass="log_copy" Text="www.pimay.com"></asp:Label>
        </p>
        </div>
    </form>
    </body>
</html>