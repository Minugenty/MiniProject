<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ApplnStatus.aspx.cs" Inherits="ProjectMMS.User.ApplnStatus" %>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <table style="width:100%;">
        <tr>
            <td colspan="3" style="text-align:center">
                <asp:Label ID="Label1" runat="server" Font-Bold="True" 
                    Text="STATUS INFORMATION"></asp:Label>
            </td>
        </tr>
        <tr>
            <td> &nbsp;</td>
            <td> &nbsp;</td>
            <td> &nbsp;</td>
        </tr>
        <tr>
            <td colspan="3" style="text-align:center">
                <asp:RadioButton ID="rdoBirth" runat="server" Font-Bold="True" 
                    Text="Birth Status" GroupName="Status" />
&nbsp; <asp:RadioButton ID="rdoMarriage" runat="server" Font-Bold="True" 
                    Text="Marriage Status" GroupName="Status" />
&nbsp ;<asp:RadioButton ID="rdoDeath" runat="server" Font-Bold="True" Text="Death Status" GroupName="Status" />
            </td>
        </tr>
        <tr>
            <td> &nbsp;</td>
            <td> &nbsp;</td>
            <td> &nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label3" runat="server" Font-Bold="True" 
                    Text="Application Form No."></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtfrmno" runat="server"></asp:TextBox>
            </td>
            <td> &nbsp;</td>
        </tr>
        <tr>
            <td> &nbsp; </td>
            <td> &nbsp; </td>
            <td> &nbsp; </td>
        </tr>
        <tr>
            <td colspan="3" style="text-align:center">
                <asp:Button ID="bttnSearch" runat="server" Text="SEARCH" 
                    onclick="bttnSearch_Click" />
            </td>
        </tr>
        <tr>
            <td> &nbsp; </td>
            <td> &nbsp; </td>
            <td> &nbsp; </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label4" runat="server" Font-Bold="True" 
                    Text="Verification Status"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="TextBox1" runat="server" ReadOnly="True"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td> &nbsp;</td>
            <td> &nbsp;</td>
            <td> &nbsp;</td>
        </tr>
        <tr>
            <td colspan="3" style="text-align:center">
                <asp:Button ID="Button1" runat="server" Text="DOWNLOAD" 
                    onclick="btn_Download" Enabled="False" />
            </td>
        </tr>
    </table>
</asp:Content>