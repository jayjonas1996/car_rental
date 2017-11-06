<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="profile.aspx.cs" Inherits="car_rental.profile" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxtoolkit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>

         .modalBackground
    {
        background-color: Black;
        filter: alpha(opacity=90);
        
        opacity: 0.8;
    }
    .modalPopup
    {
        background-color: #FFFFFF;
        border-width: 3px;
        border-style: solid;
        border-color: black;
        padding-top: 10px;
        padding-left: 10px;
        width: 430px;
        height: 250px;
    }
        .delete_pop{
            position: relative;
            left: 400px;
            background-color: #ff0000;
            color: #FFFFFF;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="scriptmanager1" runat="server" />
        <div>
            <asp:LoginStatus ID="loginstatus2" runat="server" OnLoggingOut="loginstatus2_LoggingOut" /> <asp:Button ID="delete_pop" Text="DELETE ACCOUNT" runat="server" />
        </div>
        <div>
            <asp:DetailsView ID="detailview1" runat="server" />
            <asp:FileUpload ID="fup1" runat="server" /> &nbsp<asp:Button ID="upload_btn" OnClick="upload_btn_Click"  Text="Upload" runat="server" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Image ID="Image1" runat="server" Width="400px" />
        </div>
        <div>

            <asp:Button ID="pop_password_btn" runat="server" text="Change Password"/> 
        </div>

        <!-- Modal extender for passwordchange -->

         <ajaxtoolkit:ModalPopupExtender ID="mp3"  runat="server" PopupControlID="password_panel" TargetControlID="pop_password_btn"
    CancelControlID="close" BackgroundCssClass="modalBackground">
</ajaxtoolkit:ModalPopupExtender>

        <!-- Panel for changing password -->

        <asp:Panel ID="password_panel" runat="server" CssClass="modalPopup" HorizontalAlign="Center" style="display:none">

            <h2><asp:Label runat="server" text="Change Password" id="lbl_heading"/></h2>

             <asp:Table ID="table1" runat="server">

                <asp:TableRow>

                    <asp:TableCell>

                        <asp:Label runat="server" ID="lb1" Text="Old Password:" />

                    </asp:TableCell>

                    <asp:TableCell>

                        <asp:TextBox ID="old_pass_box" runat="server" /> 

                    </asp:TableCell>

                </asp:TableRow>

                <asp:TableRow>

                    <asp:TableCell>

                        <asp:Label runat="server" ID="Lbl2" Text="New Password" />

                    </asp:TableCell>

                    <asp:TableCell>

                        <asp:TextBox ID="new_password_box" runat="server" type="password" /> 

                    </asp:TableCell>

                </asp:TableRow>

                <asp:TableRow>

                    <asp:TableCell>

                        <asp:Label ID="lbl_retype" Text="Re enter New password" runat="server" />

                    </asp:TableCell>

                    <asp:TableCell>

                        <asp:TextBox ID="new_password_re_box" type="password" runat="server"/>

                    </asp:TableCell>

                </asp:TableRow>

                <asp:TableRow>

                    <asp:TableCell >

                        <asp:Button ID="close" Text="Cancel" runat="server" />

                    </asp:TableCell>

                    <asp:TableCell>

                        <asp:Button ID="change_pass_btn" Text="Change" runat="server" OnClick="change_pass_btn_Click"/>

                    </asp:TableCell>

                    

                </asp:TableRow>

                 <asp:TableRow>

                     <asp:TableCell ColumnSpan="2" text="Please fill all the required information and make sure new password is different than old password">
                            


                    </asp:TableCell>

                 </asp:TableRow>

            </asp:Table>
          

        </asp:Panel>



        <!-- Modal extender for deleting account -->

        <ajaxtoolkit:ModalPopupExtender ID="extender_delete"  runat="server" PopupControlID="delete_acc_panel" TargetControlID="delete_pop"
    CancelControlID="close2" BackgroundCssClass="modalBackground">
</ajaxtoolkit:ModalPopupExtender>


        <!-- Panel for deleting password -->

        <asp:Panel ID="delete_acc_panel" runat="server" CssClass="modalPopup" HorizontalAlign="Center" style="display:none">

          <h2>  <asp:Label ID="labl4" runat="server" Text="Delete Account" /></h2>

            <asp:Table ID="table33" runat="server">

                <asp:TableRow>

                    <asp:TableCell>

                        <asp:Label id="display_lbl1" runat="server" Text="Confirm Password" />

                    </asp:TableCell>

                    <asp:TableCell>

                        <asp:TextBox ID="confirm_pass_box" type="password" runat="server" />

                    </asp:TableCell>

                </asp:TableRow>


                <asp:TableRow >

                    <asp:TableCell >

                        <asp:Button ID="close2" text="close" runat="server" />

                    </asp:TableCell>

                    <asp:TableCell>

                        <asp:Button ID="delete_acc" runat="server" OnClick="delete_acc_Click" text="CONFIRM DELETE" />

                    </asp:TableCell>

                </asp:TableRow>

            </asp:Table>

        </asp:Panel>

    </form>
</body>
</html>
