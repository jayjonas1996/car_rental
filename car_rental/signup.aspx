﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="signup.aspx.cs" Inherits="car_rental.signup" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            height: 537px;
        }
        .auto-style2 {
            width: 100%;
            height: 403px;
        }
        .auto-style3 {
            width: 491px;
        }
    </style>
</head>
<body style="height: 714px">
    <form id="form1" runat="server">
        <div class="auto-style1">
            <br />
            <asp:Label ID="Label1" runat="server" Text="SIGNUP:"></asp:Label>
            <table class="auto-style2">
                <tr>
                    <td class="auto-style3">
                        <asp:Label ID="Label2" runat="server" Text="Full Name*"></asp:Label>
                        <br />
                        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
&nbsp;
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox1" ErrorMessage="RequiredFieldValidator"></asp:RequiredFieldValidator>
                        <br />
                        <asp:Label ID="Label3" runat="server" Text="address*"></asp:Label>
                        <br />
                        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
&nbsp;
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="RequiredFieldValidator"></asp:RequiredFieldValidator>
                        <br />
                        <asp:Label ID="Label4" runat="server" Text="email*"></asp:Label>
                        <br />
                        <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
&nbsp;&nbsp;
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="RequiredFieldValidator"></asp:RequiredFieldValidator>
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
                        <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
&nbsp;&nbsp;
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="RegularExpressionValidator"></asp:RegularExpressionValidator>
                        <br />
                        <asp:Label ID="Label9" runat="server" Text="pincode*"></asp:Label>
                        <br />
                        <asp:TextBox ID="TextBox7" runat="server"></asp:TextBox>
&nbsp;&nbsp;
                        <br />
                        <asp:Label ID="Label10" runat="server" Text="Liscence no.*"></asp:Label>
                        <br />
                        <asp:TextBox ID="TextBox8" runat="server"></asp:TextBox>
&nbsp;&nbsp;
                        <br />
&nbsp;<br />
                        <br />
                        <asp:Button ID="Button1" runat="server" Text="Sign Up" />
                        <br />
                    </td>
                    <td>
                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" Height="153px" Width="558px" />
                    </td>
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
