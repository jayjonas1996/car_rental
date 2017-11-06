<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="print_invoice.aspx.cs" Inherits="car_rental.print_invoice" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:DetailsView ID="DetailsView1" runat="server" Height="50px" Width="407px">
            </asp:DetailsView>
            <br />
            <asp:Label ID="Label1" runat="server" Text="Sub Total: "></asp:Label>
            <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
            <br />
            <asp:Button ID="print_btn" runat="server" text="Print" OnClientClick="javascript:window.print();"/>
        </div>
    </form>
</body>
</html>
