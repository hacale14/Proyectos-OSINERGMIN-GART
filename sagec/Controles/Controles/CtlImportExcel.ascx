<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="CtlImportExcel.ascx.vb" Inherits="CtlUsuarios.CtlImportExcel" %>


<table width="100%">
<tr>
    <td style="text-align:center" colspan="2">
        <asp:FileUpload ID="Field" runat="server" BorderStyle="Outset" Font-Size="X-Small" />
        <asp:Button ID="btnCargar" runat="server" Text="Cargar"  />
    </td>
</tr>
<tr>
    <td colspan="2"> 
    <fieldset>
    <legend>Datos a Importar</legend>
        <div style="border: None; OVERFLOW: scroll; WIDTH: auto; HEIGHT: 170px; position: relative; top: 0px; left: 0px;" id="DetalleGRD">
            <asp:GridView ID="gvDetalle" runat="server" Width="100%">
            <Columns>
                <asp:TemplateField HeaderText="Seleccionar Campos" HeaderStyle-Width="170px">
                   <ItemTemplate>
                       <asp:DropDownList ID="DDLCampos" runat="server" Width="100%">
                       </asp:DropDownList>
                   </ItemTemplate>
               </asp:TemplateField>
            </Columns>
            </asp:GridView>
        </div>
    </fieldset>
    </td>
</tr>
<tr>
    <td style="text-align:right" colspan="2">
    <asp:Button ID="btnSiguiente" runat="server" Text="Siguiente" />
    </td>
</tr>
</table>
