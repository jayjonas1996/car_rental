<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="add_admin.aspx.cs" Inherits="car_rental.add_admin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            height: 298px;
        }
    </style>
</head>
<body style="height: 530px">
    <form id="form1" runat="server">
        <div>
            <asp:LoginStatus ID="loginstatus1" runat="server" OnLoggingOut="loginstatus1_LoggingOut" />
        </div>
        <div class="auto-style1">
           <h1> <asp:Label ID="Label1" runat="server" Text="Add new Admin Account"></asp:Label></h1><asp:ScriptManager ID="sc1" runat="server" />
        </div>
        <div>
            <asp:Table ID="table1" runat="server">

                <asp:TableRow>

                    <asp:TableCell>

                        <asp:Label runat="server" ID="lb1" Text="Username:" />

                    </asp:TableCell>

                    <asp:TableCell>

                        <asp:TextBox ID="username_box" runat="server" /> <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="username_box" ErrorMessage="please enter username">*</asp:RequiredFieldValidator>

                    </asp:TableCell>

                </asp:TableRow>

                <asp:TableRow>

                    <asp:TableCell>

                        <asp:Label runat="server" ID="Lbl2" Text="Password" />

                    </asp:TableCell>

                    <asp:TableCell>

                        <asp:TextBox ID="password_box" runat="server" type="password" /> <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="password_box" ErrorMessage="password is required">*</asp:RequiredFieldValidator>

                    </asp:TableCell>

                </asp:TableRow>

                <asp:TableRow>

                    <asp:TableCell>

                        <asp:Label ID="lbl_retype" Text="Re enter password" runat="server" />

                    </asp:TableCell>

                    <asp:TableCell>

                        <asp:TextBox ID="password_re_box" type="password" runat="server"/> <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="password_re_box" ErrorMessage="re enter password">*</asp:RequiredFieldValidator> 
                        <asp:CompareValidator ID="compare1" runat="server" ControlToCompare="password_box" ControlToValidate="password_re_box" ErrorMessage="reenter same pssword" >*</asp:CompareValidator>

                    </asp:TableCell>

                </asp:TableRow>

                <asp:TableRow>

                    <asp:TableCell ColumnSpan="2"  HorizontalAlign="Center">

                        <asp:Button ID="add_btn" Text="Add"  OnClick="add_btn_pressed" runat="server"/>

                    </asp:TableCell>

                </asp:TableRow>

            </asp:Table>
        </div>
    </form>
</body>
</html>
