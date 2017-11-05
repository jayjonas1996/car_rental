<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="show_feedback.aspx.cs" Inherits="car_rental.show_feedback" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:LoginStatus ID="LoginStatus1" runat="server" LogoutPageUrl="login.aspx" OnLoggingOut="LoginStatus1_LoggingOut" />
        </div>
        <div>
            <asp:DataGrid ID="dg1" runat="server" />
        </div>
    </form>
</body>
</html>
