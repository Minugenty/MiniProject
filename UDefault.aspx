<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UDefault.aspx.cs" Inherits="ProjectMMS.User.WebForm1" %>


<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table text-align: center;" style="height: 500px; width: 1000px;" >
    <tr>
        <td colspan="2" style="text-align:center">
            <asp:Label ID="Label1" runat="server" BorderStyle="Solid" Font-Bold="True" Font-Italic="True" Width="400px" Font-Names="Century Schoolbook" Font-Size="X-Large">CERTIFICATE REQUESTING</asp:Label>
        </td>
    </tr>
    <tr>
        <td colspan="2"> &nbsp;</td>
    </tr>
    <tr>
        <td style="text-align: center; ">
             <asp:Button ID="Button1" Text="BIRTH" runat="server" PostBackUrl="~/User/ApplnBirth.aspx" Height="100px" Width="200px" />                        
        </td>
        <td style="text-align: center; ">
            <asp:Button ID="Button2" Text="MARRIAGE" runat="server" PostBackUrl="~/User/ApplnMarriage.aspx" Height="100px" Width="200px" />                        
        </td>
     </tr>
     <tr>
        <td colspan="2"> &nbsp;</td>
    </tr>
     <tr>
        <td style="text-align: center; ">
             <asp:Button ID="Button3" Text="DEATH" runat="server" PostBackUrl="~/User/ApplnDeath.aspx" Height="100px" Width="200px" />                        
        </td>
        <td style="text-align: center; ">
            <asp:Button ID="Button4" Text="STATUS" runat="server" PostBackUrl="~/User/ApplnStatus.aspx" Height="100px" Width="200px" />                        
        </td>
     </tr>
     <tr>
        <td colspan="2"> &nbsp;</td>
    </tr>
     <tr>
        <td colspan="2" style="text-align:center">
            <asp:Label ID="Label2" runat="server" BorderStyle="Solid" Font-Bold="True" Font-Italic="True" Width="400px" Font-Names="Century Schoolbook" Font-Size="X-Large">FEEDBACK</asp:Label>
        </td>
    </tr>
    <tr>
        <td colspan="2"> &nbsp;</td>
    </tr>
    <tr>
        <td style="text-align: center; ">
             <asp:Button ID="Button5" Text="COMPLAINT" runat="server" PostBackUrl="~/User/Feedback.aspx" Height="100px" Width="200px" />                        
        </td>
        <td style="text-align: center; ">
            <asp:Button ID="Button6" Text="INBOX" runat="server" PostBackUrl="~/User/ApplnMarriage.aspx" Height="100px" Width="200px" />                        
        </td>
     </tr>
     <tr>
        <td colspan="2"> &nbsp;</td>
    </tr>
     <tr>
        <td colspan="2" style="text-align:center">
            <asp:Label ID="Label3" runat="server" BorderStyle="Solid" Font-Bold="True" Font-Italic="True" Width="400px" Font-Names="Century Schoolbook" Font-Size="X-Large">BILLING</asp:Label>
        </td>
    </tr>
    <tr>
        <td colspan="2"> &nbsp;</td>
    </tr>
    <tr>
        <td colspan="2" style="text-align: center;  ">
             <asp:Button ID="Button7" Text="WATER" runat="server" PostBackUrl="~/User/Feedback.aspx" Height="100px" Width="200px" />                        
        </td>
     </tr>
     <tr>
        <td colspan="2"> &nbsp;</td>
    </tr>
      <tr>
        <td colspan="2" style="text-align:center">
            <asp:Label ID="Label4" runat="server" BorderStyle="Solid" Font-Bold="True" Font-Italic="True" Width="400px" Font-Names="Century Schoolbook" Font-Size="X-Large">TAXES</asp:Label>
        </td>
    </tr>
    <tr>
        <td colspan="2"> &nbsp;</td>
    </tr>
    <tr>
        <td style="text-align: center; ">
             <asp:Button ID="Button8" Text="BUILDING" runat="server" PostBackUrl="~/User/Feedback.aspx" Height="100px" Width="200px" />                        
        </td>
        <td style="text-align: center; ">
            <asp:Button ID="Button9" Text="PROPERTY" runat="server" PostBackUrl="~/User/ApplnMarriage.aspx" Height="100px" Width="200px" />                        
        </td>
    </tr>
 </table>
</asp:Content>