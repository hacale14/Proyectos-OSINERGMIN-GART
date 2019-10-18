<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="Calendar.ascx.vb" Inherits="Controles.Calendar" %>
<asp:TextBox ID="DC" runat="server" Font-Names="Arial Narrow" 
    Font-Size="X-Small" MaxLength="10" Width="63px"></asp:TextBox>
<asp:ImageButton ID="ImageButton1" runat="server" Height="17px" 
ImageUrl="~/Imagenes/Calendar.jpg" Width="16px" ImageAlign="Middle" />
<!---<DIV id=popCal style='BORDER-RIGHT: 2px ridge; BORDER-TOP: 2px ridge; Z-INDEX: 100; VISIBILITY: hidden; BORDER-LEFT: 2px ridge; WIDTH: 10px; BORDER-BOTTOM: 2px ridge; POSITION: absolute' onclick=event.cancelBubble=true>
<IFRAME name=popFrame src='Controles/calendar.htm' frameBorder=0 width=183 scrolling=no height=188></IFRAME>    
</DIV>    --->
<!--<input id='Button' Style = 'border-width: 1px; border-color: #FF0000; height: 21px; width: 15px' type='button' value='.' align='top'/>-->
