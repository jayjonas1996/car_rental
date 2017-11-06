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
            <asp:FileUpload ID="fup1" runat="server" /> &nbsp<asp:Button ID="upload_btn" OnClick="upload_btn_Click"  Text="Upload" runat="server" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Image ID="Image1" runat="server" Width="400px" />
        </div>
    </form>
</body>
</html>
