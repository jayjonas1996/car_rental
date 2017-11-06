<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="notifications.aspx.cs" Inherits="car_rental.notifications" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:LoginStatus ID="loginstatus1" runat="server" OnLoggingOut="loginstatus1_LoggingOut" />
        </div>
        <div>
            <asp:DropDownList ID="dropdown_bookid" runat="server" /> &nbsp <asp:Button ID="show_notifications" runat="server" Text="show" OnClick="show_notifications_Click" /><br />

        </div>
        <div>
            <asp:GridView ID="gridview1" runat="server" />
        </div>
    </form>
</body>
</html>
