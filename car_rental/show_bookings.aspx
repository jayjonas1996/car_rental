<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="show_bookings.aspx.cs" Inherits="car_rental.show_bookings" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            height: 103px;
        }
    </style>
</head>
<body style="height: 638px">
    <form id="form1" runat="server">
        <div>
            <asp:LoginStatus ID="LoginStatus1" runat="server" LogoutPageUrl="login.aspx" OnLoggingOut="LoginStatus1_LoggingOut" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="default.aspx">Home</asp:HyperLink>
        </div>
        <div id="payment_div" visible="false" runat="server" class="auto-style1">

            <asp:Label ID="payment_idshow" runat="server" text="Paying for: "/>&nbsp <asp:Label ID="display_id" Text="___" runat="server"/> <br/>
            <asp:Label ID="pay_amt" runat="server" text="Amount "/> <asp:TextBox runat="server" id="amount_box" type="number" />        <br/>
            <asp:Label ID="card_label" runat="server" text="card number"/>  <asp:TextBox runat="server" ID="card_box"  type="number"/>  <br/>
            <asp:Button ID="do_payment_btn" runat="server" Text="PAY" onClick="do_payment_pressed"/>

        </div>
        <div id="cancel_div" visible="false" runat="server">
            <asp:Label runat="server" ID="why_cancel" Text="Why cancel booking id:"/>&nbsp<asp:Label ID="display_cncl_id" runat="server" Text="__"/>&nbsp <asp:TextBox runat="server" ID="cancel_box" Width="200px" />  <br/>
            <asp:Button runat="server" ID="cacncel_pressed" Text="Cancel"  OnClick="do_cancel" />
        </div>
        <div>


            <asp:Table ID="Table1" runat="server">
            </asp:Table>


        </div>
    </form>
</body>
</html>
