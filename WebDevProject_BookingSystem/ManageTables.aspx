<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ManageTables.aspx.cs" Inherits="WebDevProject_BookingSystem.ManageTables" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            margin-left: 0px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <table class="auto-style1">
        <tr>
            <td>Name</td>
            <td>
                <asp:TextBox ID="name" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Number of seats</td>
            <td>
                <asp:TextBox ID="numSeats" runat="server" CssClass="auto-style2">0</asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Minimal number of seats available for booking</td>
            <td>
                <asp:TextBox ID="minNumBookingSeats" runat="server">0</asp:TextBox>
            </td>
        </tr>
        <tr>
            <td></td>
            <td>
                <asp:Button ID="AddTableBtn" runat="server" Text="Add table" OnClick="AddTableBtn_Click" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Message" runat="server" ForeColor="Red"></asp:Label>
            </td>
            <td>
                <asp:Button ID="UpdateTableBtn" runat="server" Text="Update table" OnClick="UpdateTableBtn_Click" />
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                <asp:Button ID="DeleteTableBtn" runat="server" Text="Delete table" OnClick="DeleteTableBtn_Click" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="ShowTablesBtn" runat="server" Text="Show tables" OnClick="ShowTablesBtn_Click" />
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="2">
            <asp:GridView ID="TablesGridView" runat="server" OnSelectedIndexChanged="TablesGridView_SelectedIndexChanged" EnableModelValidation="False">
                <Columns>
                    <asp:CommandField ShowSelectButton="True" />
                </Columns>
                </asp:GridView>
            </td>
        </tr>
    </table>

    </asp:Content>
