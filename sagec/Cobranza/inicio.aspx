<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="inicio.aspx.vb" Inherits="Cobranza.inicio" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register src="Controles/CtlMensajes.ascx" tagname="CtlMensajes" tagprefix="uc1" %>
<%@ Register src="~/Controles/CtCombo.ascx" tagname="CtCombo" tagprefix="uc3" %>
<%@ Register src="Controles/CtCombo.ascx" tagname="CtCombo" tagprefix="uc2" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
<title>Acceso de Seguridad</title>

<link href="login-box.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .style1
        {
            height: 35px;
        }
    </style>
</head>

<body style="background:url('Imagenes/fondo.png') no-repeat fixed center;" >
<br />
<br />
<br />
<br />
<br />
<br />
<br />
<br />
<br />
<br />
<br />
<br />
<br />
<br />
<br />
<br />
    <center>
        <form id="form2" runat="server">        
        <div style="padding: 100px 0.1 0 250px;">
            <div id="login-box">

<table>
<tr>
<td align="left">
    Usuario:</td>
    <td>
        <asp:TextBox class="form-login" ID="usuario" runat="server" Height="20px" AutoPostBack="true"/>
    </td>
</tr>
<tr align="left">
<td>
    Password:</td>
    <td>
        <asp:TextBox class="form-login" ID="clave" TextMode="Password" Height="20px"   runat="server"/>
    </td>
</tr>
<tr align="left">
<td class="style1">
    Corporacion:</td>
    <td>
        <uc2:CtCombo class="form-login" ID="cboEmpresa" runat="server" Longitud="150" Largo="20" AutoPostBack="true" Procedimiento="QRYCO001"/>
    </td>
</tr>
<tr>
<td colspan="2">
<asp:Button ID="btnIngresar" runat="server" Text="Ingresar"/>
<asp:Button ID="Button2" runat="server" Text="Limpiar" />
</td>
</tr>
</table>
<uc1:CtlMensajes ID="CtlMensajes1" runat="server" />
</div>

</div>
</form>
</center>
</body>
</html>

