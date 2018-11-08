<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ProjectMMS.Login" %>

<%--<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .style6
        {
            font-size: large;
            font-weight: bold;
            color: #FFFFCC;
            background-color: #546138;
        }
    </style>
</asp:Content>--%>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
<table border="1" style="border-color: #5A5D5A; border-width: 1px; text-align: center; margin-left: 300px;" >
    <tr>
        <td  class="style1" style="width: 429px">
            <asp:Label ID="lblLogin" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td style="width: 429px">
        <br />
            <table style="margin-left:50px">
                <tr>
                    <td style="text-align: right; height: 40px;">
                                <b>UserName :</b>
                    </td>
                    <td style="text-align: left; height: 40px;">
                               <asp:TextBox ID="txtUsername" runat="server" Width="213px"></asp:TextBox>
                    </td>
                    <td style="height: 40px">
                                <asp:RequiredFieldValidator ControlToValidate="txtUsername" ID="RequiredFieldValidator1"
                                    runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <br />
                    </td>
                </tr>
                <tr>
                    <td style="text-align: right">
                                <b>Password :</b>
                    </td>
                    <td style="text-align: left">
                                <asp:TextBox ID="txtPassword" runat="server" Width="211px" TextMode="Password"></asp:TextBox>
                    </td>
                    <td>
                                <asp:RequiredFieldValidator ControlToValidate="txtPassword" ID="RequiredFieldValidator2"
                                    runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                         <br />
                    </td>
                </tr>
                <tr>
                    <td colspan="3" >
                                <asp:Button ID="btnLogin" Text="Login" runat="server" OnClick="btnLogin_Click" />
                                &nbsp; &nbsp; &nbsp; &nbsp;
                                <asp:Button ID="btnClr" Text="Clear" runat="server" OnClick="btnClr_Click" />
                    </td>
                </tr>
                <tr>
                    <td>
                          <br />
                    </td>
                </tr>
                <tr>
                    <td colspan="3" style="text-align: center">
                        <asp:LinkButton ID="linkShow" runat="server" Text="New User? Sign Up!" 
                                PostBackUrl="~/Registration.aspx" style="font-weight: 700" 
                                ValidationGroup="c" Visible="True"></asp:LinkButton>
                    </td>
                </tr>
           </table>
       </td>
    </tr>
    <tr>
        <td style="width: 429px">
                    <asp:Label ID="lblMsg" runat="server" Style="font-weight: 700; font-size: xx-small;
                        color: #FF3300"></asp:Label>
        </td>
    </tr>
    <tr>
         <td  style="background-color: #525F37; width: 429px;">
                   <br />
         </td>
    </tr>
 </table>
<br />
</asp:Content>



