<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="AddingCustomer.aspx.cs" Inherits="WebDevProject_BookingSystem.AddingCustomer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
    .auto-style2 {
        height: 22px;
    }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="auto-style1">
                <tr>
                    <td>&nbsp;</td>
                    <td>
                        <asp:TextBox ID="email" placeholder="Email*" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>
                        <asp:TextBox ID="password" placeholder="Password*" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>
                        <asp:DropDownList ID="title" placeholder="Title*" runat="server"></asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>
                        <asp:TextBox ID="firstName" placeholder="First Name*" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>
                        <asp:TextBox ID="lastName" placeholder="Last Name*" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2"></td>
                    <td class="auto-style2">
                        <asp:TextBox ID="phone" placeholder="Phone*" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>
                        <asp:DropDownList ID="occasion" runat="server"></asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>
                        <asp:TextBox ID="notes" placeholder="Notes*" runat="server"></asp:TextBox>
                    </td>
                </tr>
                        <tr>
                    <td>&nbsp;</td>
                    <td>
                        <asp:RadioButton ID="GuestType" runat="server" GroupName="RadioGroup" OnCheckedChanged="GuestType_CheckedChanged" Text="Guest" />
                        <asp:RadioButton ID="RegisterType" runat="server" GroupName="RadioGroup" OnCheckedChanged="RegisterType_CheckedChanged" Text="Register" />
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>
                        
                        <asp:Button ID="AddCustomerBtn" runat="server" Text="Add" OnClick="AddCustomerBtn_Click" />
                        
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>
                        <asp:TextBox ID="TextBox1" runat="server" Width="208px"></asp:TextBox>
                    </td>
                </tr>
            </table>
</asp:Content>
