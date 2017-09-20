<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="CheckingAvailability.aspx.cs" Inherits="WebDevProject_BookingSystem.CheckingAvailability" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <!-- Inline CSS based on choices in "Settings" tab -->
    <style>
        .asteriskField {
            color: red;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="form-group ">
        <label class="control-label " for="partySize">
            Party Size
                        <span class="asteriskField">*
                        </span>
        </label>
        <asp:DropDownList class="select form-control" ID="partySizeList" runat="server"></asp:DropDownList>
    </div>
    <div class="form-group ">
        <label class="control-label " for="date">
            Date
                                                    <span class="asteriskField">*
                                                    </span>
        </label>
        <div class="input-group">
            <div class="input-group-addon">
                <i class="fa fa-calendar"></i>
            </div>
            <asp:TextBox class="form-control" ID="dateCalendar" placeholder="DD/MM/YYYY" autocomplete="off" runat="server"></asp:TextBox>
        </div>
    </div>
    <div class="form-group ">
        <label class="control-label " for="time">
            Time
                        <span class="asteriskField">*
                        </span>
        </label>
        <asp:DropDownList class="select form-control" ID="timeList" runat="server"></asp:DropDownList>
    </div>
    <div class="form-group">
        <div>
            <asp:Button ID="SubmitBtn" class="btn btn-primary " runat="server" Text="Check availability" OnClick="SubmitBtn_Click" />
        </div>
    </div>
    <div>
        <asp:Label ID="Msg" runat="server" ForeColor="Red" Text=""></asp:Label>
    </div>


    <!--  jQuery -->
    <script src="Scripts/jquery-3.2.1.min.js"></script>

    <!-- Bootstrap Date-Picker Plugin -->
    <script src="Scripts/bootstrap-datepicker.min.js"></script>
    <link href="Styles/bootstrap-datepicker3.css" rel="stylesheet" />

    <!--  jQuery -->
    <script src="Scripts/jquery-3.2.1.min.js"></script>
    <script src="Scripts/bootstrap-datepicker.min.js"></script>
    <script>
        $(document).ready(function () {
            var date_input = $('[id$=dateCalendar]'); //our date input has the name "date"
            var container = $('.bootstrap-iso form').length > 0 ? $('.bootstrap-iso form').parent() : "body";
            var options = {
                format: 'dd/mm/yyyy',
                container: container,
                weekStart: 1,
                todayBtn: true,
                todayHighlight: true,
                autoclose: true,
            };
            date_input.datepicker(options);
        });
    </script>
</asp:Content>
