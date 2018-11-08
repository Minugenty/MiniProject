<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="ProjectMMS.Registration" %>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:UpdatePanel ID="updatepanel12" runat="server">
        <Triggers>
                <asp:AsyncPostBackTrigger ControlID="btnAdd" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="btnClear" EventName="Click" />
        </Triggers>
        <ContentTemplate>
            <br />
            <br />
            <table style="width:100%">
                <tr>
                    <td colspan="3" class="tddata">
                    <center>
                        <h5 class="style1" style="height: 20px; background-color: #6E8043;">
                                    Registration</h5>
                    </center>
                    </td>
                </tr>
                <tr>
                    <td> <br />
                    </td>
                </tr>
                <tr>
                    <td>    &nbsp;First Name
                    </td>
                    <td>
                        <asp:TextBox ID="txtfirstName" Width="150px" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*"
                                ControlToValidate="txtfirstName"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td> &nbsp;Last Name :
                    </td>
                    <td>
                        <asp:TextBox ID="txtLastName" Width="150px" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="*"
                                ControlToValidate="txtLastName"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td> Date Of Birth :
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
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td class="top"> Address :
                    </td>
                    <td>
                        <asp:TextBox ID="txtAddress" runat="server" Height="56px" TextMode="MultiLine" Width="150px"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="*"
                                ControlToValidate="txtAddress"></asp:RequiredFieldValidator>
                    </td>
                </tr>  
                <tr>
                    <td> Email Id :
                    </td>
                    <td>
                        <asp:TextBox ID="txtEmailId" Width="150px" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*"
                                ControlToValidate="txtEmailId"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                                ErrorMessage="*" ControlToValidate="txtEmailId" 
                                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td> &nbsp;Phone No:
                    </td>
                    <td>
                        <asp:TextBox ID="txtPhoneNO" Width="150px" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*"
                                ControlToValidate="txtPhoneNO"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
                                ErrorMessage="{10}" ControlToValidate="txtPhoneNO" 
                                ValidationExpression="\d{10}"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td colspan="3"> &nbsp;</td>
                    </tr>
                    <tr>
                        <td>House No: </td>
                        <td>
                            <asp:TextBox ID="txtHouseNo" runat="server" Width="150px"></asp:TextBox>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtHouseNo" ErrorMessage="*"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td> &nbsp;</td>
                        <td> <asp:Label ID="Label2" runat="server" ForeColor="#FF3300" Visible="False" >Sorry! Someone has already registered using this House Number!</asp:Label></td>
                        <td>&nbsp;</td>
                    </tr>
                    </tr>
                    <tr>
                        <td>PassWord: </td>
                        <td>
                            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" Width="150px"></asp:TextBox>
                        </td>
                        
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtPassword" ErrorMessage="*"></asp:RequiredFieldValidator>
                        </td>
                        <tr>
                            <td>Confirm PassWord: </td>
                            <td>
                                <asp:TextBox ID="txtConformPassword" runat="server" TextMode="Password" Width="150px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="txtConformPassword" ErrorMessage="*"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                            <td>
                                    <asp:Label ID="Label1" runat="server" ForeColor="#FF3300" Visible="False">Passwords don&#39;t match!!</asp:Label>
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td colspan="3">
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td class="tddata" colspan="3">
                                <center style="height: 18px; background-color: #6E8043;">
                                    <asp:Button ID="btnAdd" runat="server" BackColor="#6E8043" Font-Bold="True" Font-Size="Medium" ForeColor="#ffffff" Height="21px" OnClick="btnAdd_Click" Text="Submit" />
                                    &nbsp;&nbsp;&nbsp;
                                    <asp:Button ID="btnClear" runat="server" BackColor="#6E8043" Font-Bold="True" ForeColor="#ffffff" Height="21px" OnClick="btnClear_Click" Text="Clear" ValidationGroup="b1" />
                                </center>
                            </td>
                        </tr>
                    </tr>
                
            </table>
            <br />
            <br />
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>