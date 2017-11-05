<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="car_rental._default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            height: 134px;
        }
        .auto-style2 {
            height: 168px;
        }
        .auto-style3 {
            height: 207px;
        }
    </style>
</head>
<body style="height: 620px">
    <form id="form1" runat="server" class="auto-style1">
    &nbsp;
        <asp:Label ID="Label1" runat="server" Text="Welcome "></asp:Label>
&nbsp;<asp:LoginName ID="LoginName1" runat="server" />
        <asp:LoginStatus ID="LoginStatus1" runat="server" />
        <br />
        <br />
        <br />
        
        <br />
        <br />



        <div id="admin_div" runat="server" class="auto-style2">
            <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="add_admin.aspx">add new admin user</asp:HyperLink>
            <br />
            <asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl="manage_vehicles.aspx">manage vehicles</asp:HyperLink>
            <br/>
            <asp:HyperLink ID="admin_hp7" runat="server" NavigateUrl="~/manage_bookings.aspx">manage bookings</asp:HyperLink>
            <br />
            <asp:HyperLink ID="admin_hp8" runat="server" NavigateUrl="~/show_feedback.aspx">show feedbacks</asp:HyperLink>
        </div>



        <div id="user_div" runat="server" class="auto-style3">
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="profile.aspx">profile</asp:HyperLink>
        <br />
        <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="catalogue.aspx">new booking</asp:HyperLink>
        <br />
        <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="show_bookings.aspx">show bookings</asp:HyperLink>
        <br />
            <asp:HyperLink id="user_hp6" runat="server" NavigateUrl="send_feedback.aspx">send feedback</asp:HyperLink>
        </div>
    </form>
</body>
</html>
