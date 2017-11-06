<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="new_booking.aspx.cs" Inherits="car_rental.new_booking" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            height: 318px;
            width: 1523px;
        }
        .auto-style2 {
            height: 232px;
        }
    </style>
</head>
<body style="height: 657px">
    <form id="form1" runat="server">
        <div class="auto-style1">
            <asp:LoginStatus ID="LoginStatus1" runat="server" OnLoggingOut="LoginStatus1_LoggingOut" />
            <br />
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            <br />
            <br />
            <asp:Label ID="Label1" runat="server" Text="Estimate new booking for:"></asp:Label>
            &nbsp;&nbsp;&nbsp;
            <asp:Label ID="display_id_label" runat="server" Text="Label"></asp:Label>
            <br />
            <br />
            <asp:Label ID="Label2" runat="server" Text="rent date:"></asp:Label>
&nbsp;<asp:TextBox ID="rent_start_date" runat="server"></asp:TextBox>
            <asp:Image ID="Image1" ImageUrl="~/assets/up.jpg"  runat="server" Height="20" Width="20" />
            <asp:CalendarExtender ID="CalendarExtender1" runat="server" 
                Format="dd/MM/yyyy"
    TargetControlID="rent_start_date" PopupButtonID="Image1">
            
            </asp:CalendarExtender>
            <br />
            <asp:Label ID="Label3" runat="server" Text="rent till"></asp:Label>
&nbsp;<asp:TextBox ID="rent_till_date" runat="server"></asp:TextBox>
            <asp:Image ID="Image2" runat="server" ImageUrl="~/assets/up.jpg" Height="20" Width="20" />
            <asp:CalendarExtender ID="CalendarExtender2" runat="server" 
                Format="dd/MM/yyyy"
                    TargetControlID="rent_till_date" PopupButtonID="Image2"> 
            </asp:CalendarExtender>
            <br />
            <asp:Label ID="location" runat="server" Text="Trip location:"></asp:Label>
            <asp:TextBox ID="location_box" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="pickuploc" runat="server" Text="PickUp Location"></asp:Label>
            <asp:DropDownList ID="pickuplocs" runat="server">
            </asp:DropDownList>
            <br />
            <br />
            <asp:Button ID="estimate_btn" runat="server" OnClick="estimate_btn_Click" Text="Estimate" />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
        </div>
        <div class="auto-style2">
            <asp:Table ID="Table1" runat="server" Visible="False">
            </asp:Table>
            <br />
            <asp:Button ID="book_btn" runat="server" Text="Book" Visible="False" OnClick="book_btn_Click" />
        </div>
    </form>
</body>
</html>
