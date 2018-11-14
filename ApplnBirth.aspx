<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ApplnBirth.aspx.cs" Inherits="ProjectMMS.User.ApplnBirth" %>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <table style="width:100%;">
        <tr>
            <td colspan="3" style="text-align:center">
                <asp:Label ID="Label1" runat="server" Text="APPLICATION FOR BIRTH CERTIFICATE" 
                    Font-Bold="True"></asp:Label>
            </td>
        </tr>
        <tr>
            <td> &nbsp;</td>
            <td> &nbsp;</td>
            <td> &nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label2" runat="server" Font-Bold="True" Text="Form Number"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtfrmno" runat="server" ReadOnly="True"></asp:TextBox>
            </td>
            <td> &nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label3" runat="server" Font-Bold="True" Text="Name of Applicant"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtNameApplcnt" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="txtNameApplcnt" ErrorMessage="*" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                    ControlToValidate="txtNameApplcnt" ErrorMessage="*" 
                    ValidationExpression="^[a-zA-Z'.\s]{1,40}$"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label4" runat="server" Font-Bold="True" Text="Address"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtAddr" TextMode="MultiLine" Height="56px" runat="server" Width="122px"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ControlToValidate="txtAddr" ErrorMessage="*" ForeColor="#FF3300"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label5" runat="server" Font-Bold="True" 
                    Text="Need For Certificate"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtNeed" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                    ControlToValidate="txtNeed" ErrorMessage="*" ForeColor="#FF3300"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label6" runat="server" Font-Bold="True" 
                    Text="Relationship of child with Applicant"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtRelation" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                    ControlToValidate="txtRelation" ErrorMessage="*" ForeColor="#FF3300"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td> &nbsp;</td>
            <td> &nbsp;</td>
            <td> &nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label7" runat="server" Text="INFORMATION RELATED TO BIRTH"></asp:Label>
            </td>
            <td> &nbsp;</td>
            <td> &nbsp;</td>
        </tr>
        <tr>
            <td> &nbsp;</td>
            <td> &nbsp;</td>
            <td> &nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label9" runat="server" Font-Bold="True" Text="Place of Birth"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtPlcofbrth" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                    ControlToValidate="txtPlcofbrth" ErrorMessage="*" ForeColor="#FF3300"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="style2">
                <asp:Label ID="Label10" runat="server" Font-Bold="True" Text="Name of Mother"></asp:Label>
            </td>
            <td class="style2">
                <asp:TextBox ID="txtNameofmthr" runat="server"></asp:TextBox>
            </td>
            <td class="style2">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" 
                    ControlToValidate="txtNameofmthr" ErrorMessage="*" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label11" runat="server" Font-Bold="True" Text="Name of Father"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtNameoffthr" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" 
                    ControlToValidate="txtNameoffthr" ErrorMessage="*" ForeColor="#FF3300"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label12" runat="server" Font-Bold="True" Text="Gender"></asp:Label>
            </td>
            <td>
                <asp:RadioButton ID="rdoMale" runat="server" Font-Bold="True" 
                    Text="MALE" GroupName="Gender" />
                &nbsp; &nbsp;
                <asp:RadioButton ID="rdoFemale" runat="server" Font-Bold="True" 
                    Text="FEMALE" GroupName="Gender" />
            </td>
            <td> &nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label13" runat="server" Font-Bold="True" Text="Date of Birth"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="drplstDay" runat="server">
                    <asp:ListItem>Day</asp:ListItem>
                    <asp:ListItem>1</asp:ListItem>
                    <asp:ListItem>2</asp:ListItem>
                    <asp:ListItem>3</asp:ListItem>
                    <asp:ListItem>4</asp:ListItem>
                    <asp:ListItem>5</asp:ListItem>
                    <asp:ListItem>6</asp:ListItem>
                    <asp:ListItem>7</asp:ListItem>
                    <asp:ListItem>8</asp:ListItem>
                    <asp:ListItem>9</asp:ListItem>
                    <asp:ListItem>10</asp:ListItem>
                    <asp:ListItem>11</asp:ListItem>
                    <asp:ListItem>12</asp:ListItem>
                    <asp:ListItem>13</asp:ListItem>
                    <asp:ListItem>14</asp:ListItem>
                    <asp:ListItem>15</asp:ListItem>
                    <asp:ListItem>16</asp:ListItem>
                    <asp:ListItem>17</asp:ListItem>
                    <asp:ListItem>18</asp:ListItem>
                    <asp:ListItem>19</asp:ListItem>
                    <asp:ListItem>20</asp:ListItem>
                    <asp:ListItem>21</asp:ListItem>
                    <asp:ListItem>22</asp:ListItem>
                    <asp:ListItem>23</asp:ListItem>
                    <asp:ListItem>24</asp:ListItem>
                    <asp:ListItem>25</asp:ListItem>
                    <asp:ListItem>26</asp:ListItem>
                    <asp:ListItem>27</asp:ListItem>
                    <asp:ListItem>28</asp:ListItem>
                    <asp:ListItem>29</asp:ListItem>
                    <asp:ListItem>30</asp:ListItem>
                    <asp:ListItem>31</asp:ListItem>
                </asp:DropDownList>
                <asp:DropDownList ID="drplstMonth" runat="server">
                    <asp:ListItem>Month</asp:ListItem>
                    <asp:ListItem Value="1">January</asp:ListItem>
                    <asp:ListItem Value="2">February</asp:ListItem>
                    <asp:ListItem Value="3">March</asp:ListItem>
                    <asp:ListItem Value="4">April</asp:ListItem>
                    <asp:ListItem Value="5">May</asp:ListItem>
                    <asp:ListItem Value="6">June</asp:ListItem>
                    <asp:ListItem Value="7">July</asp:ListItem>
                    <asp:ListItem Value="8">August</asp:ListItem>
                    <asp:ListItem Value="9">September</asp:ListItem>
                    <asp:ListItem Value="10">October</asp:ListItem>
                    <asp:ListItem Value="11">November</asp:ListItem>
                    <asp:ListItem Value="12">December</asp:ListItem>
                </asp:DropDownList>
                <asp:DropDownList ID="drplstYear" runat="server" AppendDataBoundItems="True">
                    <asp:ListItem>Year</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>&nbsp; </td>
        </tr>
        <tr>
            <td class="style1">
                <asp:Label ID="Label14" runat="server" Font-Bold="True" 
                    Text="Name of the Hospital"></asp:Label>
            </td>
            <td class="style1">
                <asp:TextBox ID="txtNameHsptl" runat="server"></asp:TextBox>
            </td>
            <td class="style1">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" 
                    ControlToValidate="txtNameHsptl" ErrorMessage="*" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label15" runat="server" Font-Bold="True" Text="Father's Address"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtFadradr" runat="server" TextMode="MultiLine"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" 
                    ControlToValidate="txtFadradr" ErrorMessage="*" ForeColor="#FF3300"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label16" runat="server" Font-Bold="True" Text="Mother's Address"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtMthraddr" runat="server" TextMode="MultiLine"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" 
                    ControlToValidate="txtMthraddr" ErrorMessage="*" ForeColor="#FF3300"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label17" runat="server" Font-Bold="True" Text="Proof from Hospital"></asp:Label>
            </td>
            <td>
                <asp:FileUpload ID="fupProof" runat="server" />
            </td>
            <td> &nbsp; </td>
        </tr>
        <tr>
            <td> &nbsp;</td>
            <td> 
                <asp:Label ID="Status" runat="server"></asp:Label>
            </td>
            <td> &nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label18" runat="server" 
                    Text="Requesting name of the child  that is to be added to the Register" 
                    Font-Italic="True"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtRqst" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" 
                    ControlToValidate="txtRqst" ErrorMessage="*" ForeColor="#FF3300"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td> &nbsp;</td>
            <td> &nbsp;</td>
            <td> &nbsp;</td>
        </tr>
        <tr>
            <td colspan="3" style="text-align:center">
                <asp:Button ID="btnSubmit" runat="server" Text="SUBMIT" Font-Bold="True" 
                    onclick="btnSubmit_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
