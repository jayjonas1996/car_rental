<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="new_booking.aspx.cs" Inherits="car_rental.new_booking" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:LoginStatus ID="LoginStatus1" runat="server" />
            <br />
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            <br />
            <br />
            <asp:Label ID="Label1" runat="server" Text="Estimate new booking:"></asp:Label>
            <br />
            <br />
            <asp:Label ID="Label2" runat="server" Text="rent date:"></asp:Label>
&nbsp;<asp:TextBox ID="rent_start_date" runat="server" Enabled="False"></asp:TextBox>
            <asp:Image ID="Image1" ImageUrl="~/assets/up.jpg"  runat="server" Height="20" Width="20" />
            <asp:CalendarExtender ID="CalendarExtender1" runat="server" 

    TargetControlID="rent_start_date" PopupButtonID="Image1">
            
            </asp:CalendarExtender>
            <br />
            <asp:Label ID="Label3" runat="server" Text="rent till"></asp:Label>
&nbsp;<asp:TextBox ID="rent_till_date" runat="server" Enabled="False"></asp:TextBox>
            <asp:Image ID="Image2" runat="server" ImageUrl="~/assets/up.jpg" Height="20" Width="20" />
            <asp:CalendarExtender ID="CalendarExtender2" runat="server" 
                    TargetControlID="rent_till_date" PopupButtonID="Image2"> 
            </asp:CalendarExtender>
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
        </div>
    </form>
</body>
</html>
