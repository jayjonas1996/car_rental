<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="manage_vehicles.aspx.cs" Inherits="car_rental.manage_vehicles" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            height: 256px;
        }
    </style>
</head>
<body style="height: 430px">
    <form id="form1" runat="server">
        <div class="auto-style1">
            <br />
            <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" Height="16px" Width="98px">
                <asp:ListItem Selected="True">add new</asp:ListItem>
            </asp:DropDownList>
        </div>
    </form>
</body>
</html>
