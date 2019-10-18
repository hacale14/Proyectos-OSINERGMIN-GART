<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ConsultaAsigancionPopup.aspx.vb" Inherits="Cobranza.ConsultaAsigancion" %>
<%@ Register src="Controles/CtlGrilla.ascx" tagname="CtlGrilla" tagprefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Consulta Asignacion</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table class="curvoG1" align="center" style="background:#415162; margin-top:170px;">
            <tr>
                <td style="background:#415162; color:#fff; font-size:1.5em;">
                    Onsulta de Asignacion
                </td>
            </tr>
            <tr>
                <td style="background:#415162; color:#fff; text-align:center;">
                    <uc1:CtlGrilla ID="gvConsultaAsignacion" runat="server" Activa_ckeck="false" Activa_Delete="false" Activa_Export="false" Activa_option="false" Desactiva_Boton="false" Activa_Edita="false"/>                    
                    
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
