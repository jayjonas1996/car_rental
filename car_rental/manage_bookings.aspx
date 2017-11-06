<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="manage_bookings.aspx.cs" Inherits="car_rental.manage_bookings" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:LoginStatus ID="loginstatus1" runat="server" OnLoggingOut="loginstatus1_LoggingOut" />

        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="default.aspx">HOME</asp:HyperLink>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

        <div id="msg_div" runat="server" visible="false">
               <asp:DataGrid runat="server" ID="datagrid1" />
            <asp:TextBox ID="message_box" runat="server" /> &nbsp <asp:Button ID="send_msg_btn" runat="server" text="Send" OnClick="send_msg_pressed"/>       <br/>
            <asp:Label text="booking id: " runat="server" ID="label1"/><asp:Label text="__" runat="server" ID="display_b_id"/><asp:Label text="user " runat="server" ID="label2"/><asp:Label text="___" runat="server" ID="display_u_id"/>
        </div>
        
        <div id="complete_div" runat="server" visible="false">
            <asp:Label  ID="lbl_2" Text ="for booking: " runat="server"/> <asp:Label ID="display_booking_id" Text="__" runat="server"/><br/>
         <asp:Label ID="cl1" runat="server" Text="Final kms value on odometer: " />&nbsp<asp:TextBox runat="server" ID="kms_box" type="number"/><br/>
            <asp:Label ID="lbl3" runat="server" Text="fuel amt: " />&nbsp<asp:TextBox runat="server" ID="fuel_box" type="number"/><br/>
                <asp:Button id="do_complete" text="Complete" runat="server"  OnClick="complete_pressed"/>
            </div>
        
        <div>
            <asp:Table ID="table1" runat="server" />
        </div>
    </form>
</body>
</html>
