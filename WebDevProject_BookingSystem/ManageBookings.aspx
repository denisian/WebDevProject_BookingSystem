<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ManageBookings.aspx.cs" Inherits="WebDevProject_BookingSystem.ManageBookings" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <style>
        .asteriskField {
            color: red;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="form-group ">
        <label class="control-label" for="name1">
            Title
        </label>
        <asp:TextBox class="form-control" ID="title" runat="server"></asp:TextBox>
    </div>
    <div class="form-group ">
        <label class="control-label requiredField" for="name1">
            First Name
       <span class="asteriskField">*
       </span>
        </label>
        <asp:TextBox class="form-control" ID="firstName" runat="server"></asp:TextBox>
    </div>
    <div class="form-group ">
        <label class="control-label requiredField" for="name">
            Last Name
       <span class="asteriskField">*
       </span>
        </label>
        <asp:TextBox class="form-control" ID="lastName" runat="server"></asp:TextBox>
    </div>
        <div class="form-group ">
        <label class="control-label requiredField" for="email">
            Email
       <span class="asteriskField">*
       </span>
        </label>
         <asp:TextBox class="form-control" ID="email" runat="server"></asp:TextBox>
    </div>
    <div class="form-group ">
        <label class="control-label requiredField" for="tel">
            Telephone
                   <span class="asteriskField">*
       </span>
        </label>
        <asp:TextBox class="form-control" ID="phone" runat="server"></asp:TextBox>
    </div>
    <div class="form-group ">
        <label class="control-label " for="select2">
            Occasion
        </label>
        <asp:DropDownList class="select form-control" ID="occasionList" runat="server"></asp:DropDownList>
    </div>
    <div class="form-group ">
        <label class="control-label " for="text">
            Notes
        </label>
         <asp:TextBox class="form-control" ID="notes" runat="server"></asp:TextBox>
    </div>
    <div class="form-group">
        <div>
            <asp:Button class="btn btn-primary " ID="BookingBtn" runat="server" Text="Book table" OnClick="BookingBtn_Click" />
        </div>
    </div>
        <div class="form-group">
        <div>
            <asp:Label class="btn btn-primary " ID="Msg" runat="server" ForeColor="Red"></asp:Label>
        </div>
    </div>
</asp:Content>
