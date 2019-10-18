<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WebForm1.aspx.vb" Inherits="Cobranza.WebForm1" %>

<%@ Register src="Controles/CtlEditor.ascx" tagname="CtlEditor" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title id='Description'>Prueba</title>
    <link rel="stylesheet" href="jqwidgets/styles/jqx.base.css" type="text/css" />
    <script type="text/javascript" src="scripts/jquery-1.11.1.min.js"></script>
    <script type="text/javascript" src="scripts/demos.js"></script>
    <script type="text/javascript" src="jqwidgets/jqxcore.js"></script>
    <script type="text/javascript" src="jqwidgets/jqxbuttons.js"></script>
    <script type="text/javascript" src="jqwidgets/jqxscrollbar.js"></script>
    <script type="text/javascript" src="jqwidgets/jqxlistbox.js"></script>
    <script type="text/javascript" src="jqwidgets/jqxdropdownlist.js"></script>
    <script type="text/javascript" src="jqwidgets/jqxdropdownbutton.js"></script>
    <script type="text/javascript" src="jqwidgets/jqxcolorpicker.js"></script>
    <script type="text/javascript" src="jqwidgets/jqxwindow.js"></script>
    <script type="text/javascript" src="jqwidgets/jqxeditor.js"></script>
    <script type="text/javascript" src="jqwidgets/jqxtooltip.js"></script>
    <script type="text/javascript" src="jqwidgets/jqxcheckbox.js"></script>
</head>
<body>    
    
    <form id="form1" runat="server">
    <uc1:CtlEditor ID="CtlEditor1" runat="server" />
    </form>    
</body>
</html>
