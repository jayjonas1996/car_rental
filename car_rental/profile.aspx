<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="profile.aspx.cs" Inherits="car_rental.profile" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:LoginStatus ID="loginstatus2" runat="server" OnLoggingOut="loginstatus2_LoggingOut" />
        </div>
        <div>
            <asp:DetailsView ID="detailview1" runat="server" />
        </div>
    </form>
</body>
</html>
