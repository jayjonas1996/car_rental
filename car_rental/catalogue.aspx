<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="catalogue.aspx.cs" Inherits="car_rental.catalogue" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            height: 93px;
        }
        .prop_img {
        width:27%;
        margin-right:3px;
        }
        .book_btn {
            margin-left: 6px;
        
        }
        .catalogue_table {
            position:relative;
            border-radius:15px;
            padding: 25px;
            left:120px;
            border: 2px solid #ffffff;
            right:150px;
            float: left;
            margin-left: 30px;
            margin-top:70px;
           
            
        }
        .product_area {
            padding-right:200px;
        }
        .catalogue_table:hover {
            border-radius:15px;
            border:2px solid #ffd800;
        }
    </style>
</head>
<body style="height: 91px">
    <form id="form1" runat="server">
        <div class="auto-style1">
            <asp:LoginStatus ID="loginstatus" runat="server" OnLoggingOut="loginstatus_LoggingOut" />
        </div>
        <asp:Panel ID="Product_Panel" CssClass="product_area" runat="server">
        </asp:Panel>
    </form>
</body>
</html>
