<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Principal.aspx.vb" Inherits="Cobranza.Principal"
    MasterPageFile="~/MasterPage.Master" %>
<%@ Register src="Controles/CtCombo.ascx" tagname="CtCombo" tagprefix="uc1" %>
<%@ Register src="Controles/CtlGrilla.ascx" tagname="CtlGrilla" tagprefix="uc2" %>
<%@ Register src="Controles/CtlMensajes.ascx" tagname="CtlMensajes" tagprefix="uc3" %>

    <asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
        <style type="text/css">
            .style1 {
                width: 100%;
                height: 500px;
            }
        </style>
        <link href="css/main.css" rel="stylesheet" type="text/css" />
    </asp:Content>
    <asp:Content ID="Content1" runat="server" ContentPlaceHolderID="Contenido">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div class="container">                                                                                                                                                    
                    <div class="col-3">
                        <div class="mini-panel">
                            <legend>
                                <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="blue" Text="CORPORACION :"/><uc1:CtCombo ID="cboCorporacion" runat="server" Longitud="150" Procedimiento="QRYC018" AutoPostBack="true"/>
                            </legend>                                                    
                        </div>
                    </div>
                    <div class="col-3">
                        <div class="mini-panel">
                            <legend>
                            <asp:Label ID="Label7" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="blue" Text="EMPRESA :"/><uc1:CtCombo ID="cboempresa" runat="server" Longitud="150" Procedimiento="QRYC015" AutoPostBack="true"/></div>
                            </legend>
                    </div>
                    <div class="col-3">
                        <div class="mini-panel">
                            <legend>
                            <asp:Label ID="Label8" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="blue" Text="GRUPO :"/><uc1:CtCombo ID="cboGrupo" runat="server" Longitud="150" Procedimiento="QRYC016" AutoPostBack="true"/></div>
                            </legend>
                    </div>
                    <div class="col-3">
                        <div class="mini-panel">
                        <legend>
                            <asp:Label ID="Label9" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="blue" Text="CARTERA :"/><uc1:CtCombo ID="CtCombo1" runat="server" Longitud="150" Procedimiento="QRYC017" AutoPostBack="true"/></div>
                        </legend>                            
                    </div>
                </div>
                <div class="container">
                    <div class="col-5">
                        <div id="grafico01" class="p-f-5" style="min-width: 310px; height: 400px; margin: 0 auto">
                        </div>
                    </div>
                    <div class="col-7">
                        <div id="grafico02" class="p-f-5" style="min-width: 310px; height: 400px; margin: 0 auto">
                        </div>
                    </div>
                    <div class="col-7">
                        <div id="grafico04" class="p-f-5" style="min-width: 250px; height: 400px; margin: 0 auto">
                        </div>
                    </div>
                    <div class="col-5">
                        <div id="grafico03" class="p-f-5" style="min-width: 250px; height: 400px; margin: 0 auto">
                        </div>
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </asp:Content>
    <asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="server">

        <script src="lib/highcharts/highcharts.js" type="text/javascript"></script>

        <script src="https://code.highcharts.com/modules/heatmap.js" type="text/javascript"></script>
                
    </asp:Content>