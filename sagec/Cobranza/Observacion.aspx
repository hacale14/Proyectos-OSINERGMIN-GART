<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Observacion.aspx.vb" Inherits="Cobranza.Observacion" %>

<%@ Register src="Controles/CtlGrilla.ascx" tagname="CtlGrilla" tagprefix="uc1" %>

<html>
<head>
    <title> Observaciones </title>
</head>
<body>
<form id="form1" runat="server">
<table bgcolor="#003366">
<tr>
    <td>
        <asp:label ID="lblidProceso" runat="server" Text="" Visible="false"></asp:label>
        <fieldset>
        <uc1:CtlGrilla ID="gvObservacion" runat="server" Ancho="400px" Largo="400px" Activa_ckeck="false" Activa_Delete="false" Activa_Edita="false" Activa_Export="false" Activa_option="false" Desactiva_Boton="false" />
        </fieldset>
    </td>
</tr>
</table>
</form>
</body>
</html>

