<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="signup.aspx.cs" Inherits="car_rental.signup" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            height: 3px;
        }
        .auto-style2 {
            width: 100%;
            height: 403px;
        }
        .auto-style3 {
            width: 491px;
        }
        .far {
            position: relative;
            left: 500px;
        }
    </style>
</head>
<body style="height: 714px">
    <form id="form1" runat="server">
        <div class="auto-style1">
            <br />
            <asp:Label ID="Label1" runat="server" Text="SIGNUP:"></asp:Label>
            <asp:HyperLink ID="tp_login" runat="server" CssClass="far" NavigateUrl="~/login.aspx"> </asp:HyperLink>
            <br />
            <table class="auto-style2">
                <tr>
                    <td class="auto-style3">
                        First Name<br />
                        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
&nbsp;
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox1" ErrorMessage="first name is Required">*</asp:RequiredFieldValidator>
                        <br />
                        Last Name<br />
                        <asp:TextBox ID="TextBox11" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="last name is required" ControlToValidate="TextBox11">*</asp:RequiredFieldValidator>
                        <br />
                        <asp:Label ID="Label13" runat="server" Text="Username"></asp:Label>
                        <br />
                        <asp:TextBox ID="TextBox14" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="TextBox14" ErrorMessage="Username required">*</asp:RequiredFieldValidator>
                        <br />
                        <br />
                        <asp:Label ID="Label3" runat="server" Text="address"></asp:Label>
                        <br />
                        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
&nbsp;
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="address is Required" ControlToValidate="TextBox2">*</asp:RequiredFieldValidator>
                        <br />
                        <asp:Label ID="Label4" runat="server" Text="email"></asp:Label>
                        <br />
                        <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
&nbsp;&nbsp;
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="email is Required" ControlToValidate="TextBox3">*</asp:RequiredFieldValidator>
                        <br />
                        <asp:Label ID="Label5" runat="server" Text="city"></asp:Label>
                        <br />
                        <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
&nbsp;&nbsp;
                        <br />
                        <asp:Label ID="Label6" runat="server" Text="state"></asp:Label>
                        <br />
                        <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
&nbsp;&nbsp;
                        <br />
                        <asp:Label ID="Label7" runat="server" Text="date of birth*"></asp:Label>
                        <br />
                        <asp:DropDownList ID="DropDownList1" runat="server">
                        </asp:DropDownList>
                        <asp:DropDownList ID="DropDownList2" runat="server">
                        </asp:DropDownList>
                        <asp:DropDownList ID="DropDownList3" runat="server">
                        </asp:DropDownList>
&nbsp;&nbsp;
                        <br />
                        <asp:Label ID="Label8" runat="server" Text="contact number*"></asp:Label>
                        <br />
                        <asp:TextBox ID="TextBox6" Type="number"  runat="server"></asp:TextBox>
&nbsp;&nbsp;
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Enter 10 Digit Number" ControlToValidate="TextBox6" ForeColor="Red" ValidationExpression="^(\+91[\-\s]?)?[0]?(91)?[789]\d{9}$"></asp:RegularExpressionValidator>
                        <br />
                        <asp:Label ID="Label9" runat="server" Text="pincode"></asp:Label>
                        <br />
                        <asp:TextBox ID="TextBox7" Type="number" runat="server"></asp:TextBox>
&nbsp;&nbsp;
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="pincode is required" ControlToValidate="TextBox7">*</asp:RequiredFieldValidator>
                        <br />
                        <asp:Label ID="Label10" runat="server" Text="Liscence no."></asp:Label>
                        <br />
                        <asp:TextBox ID="TextBox8" runat="server"></asp:TextBox>
&nbsp;&nbsp;
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="liscence number is required" ControlToValidate="TextBox8">*</asp:RequiredFieldValidator>
                        <br />
                        <br />
                        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click1" Text="SIGN UP" />
                        <br />
&nbsp;<br />
                        <br />
                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:conshivam %>" SelectCommand="SELECT * FROM [user_master]"></asp:SqlDataSource>
                        <br />
                        <br />
                        <br />
                    </td>
                    <td>
                        <br />
                        <asp:Label ID="Label11" runat="server" Text="Create Password"></asp:Label>
                        <br />
                        <asp:TextBox ID="TextBox12" type="password" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="password is required" ControlToValidate="TextBox12">*</asp:RequiredFieldValidator>
                        <br />
                        <asp:Label ID="Label12" runat="server"  Text="Reenter password"></asp:Label>
                        <br />
                        <asp:TextBox ID="TextBox13"  type="password" runat="server"></asp:TextBox>
                        &nbsp;
                        <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="TextBox12" ControlToValidate="TextBox13" ErrorMessage="Password doesn't match"></asp:CompareValidator>
                        <br />
                        <br />
                        <br />
                        <br />
                        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="login.aspx">Go to Login</asp:HyperLink>
                        <br />
                        <br />
                        <br />
                        <br />
                        <br />
                        <br />
                        <br />
                        <br />
                        <br />
                        <br />
                        <br />
                        <br />
                        <br />
                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" Height="153px" Width="558px" />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3">
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
            </table>
            <br />
            <br />
            <br />
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
