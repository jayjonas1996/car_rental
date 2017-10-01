<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="car_rental.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Login ID="Login1" runat="server" OnAuthenticate="Login1_Authenticate">
        </asp:Login>
        <br />
        
        <asp:LoginView ID="LoginView1" runat="server">
            <AnonymousTemplate>
                SignUp?? <a href ="signup.aspx" >Here</a>
            </AnonymousTemplate>
        </asp:LoginView>
        
        <br />
        <br />
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:conshivam %>" SelectCommand="SELECT * FROM [admin_login]"></asp:SqlDataSource>
        <br />
        <br />
    </form>
</body>
</html>
