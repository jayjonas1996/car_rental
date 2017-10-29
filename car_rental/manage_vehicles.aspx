<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="manage_vehicles.aspx.cs" Inherits="car_rental.manage_vehicles" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxtoolkit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            height: 256px;
        }
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
        height: 270px;
    }
    </style>
</head>
<body style="height: 430px">
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div class="auto-style1">
           <h1> <asp:Label ID="Label1" runat="server" Text="Manage Vehicles"></asp:Label></h1>
            <br />
            <br />
            <asp:Button ID="newmodelbtn" runat="server" Text="New Model" Width="80px" />
        </div>


        <ajaxtoolkit:ModalPopupExtender ID="mp1" runat="server" PopupControlID="Panel1" TargetControlID="newmodelbtn"
    CancelControlID="btnClose" BackgroundCssClass="modalBackground">
</ajaxtoolkit:ModalPopupExtender>


        <asp:Panel ID="Panel1" runat="server" CssClass="modalPopup" align="center" style = "display:none">
   <h3>Add new model</h3>                                                                                                                        
            <h5>Add first vehicle</h5>                                                                                                           <br/>           
        <asp:Label id="l1" runat="server" Text="Model name(ID):" />               <asp:Textbox ID="t1" runat="server" />                         <br/>
        <asp:Label id="l2" runat="server" Text="Name:" />                         <asp:Textbox ID="t2" runat="server" />                         <br/>
        <asp:Label runat="server" ID="l3" Text="available?"/>                     <asp:CheckBox runat="server"  ID="yncheckbox"/>                <br/>
        <asp:Label runat="server" ID="l4" Text="kilometers used?"  />             <asp:Textbox runat="server" ID="t3" type="number"/>            <br/>
        <asp:Label id="l5" runat="server" Text="Registration Number" />           <asp:Textbox ID="t4" runat="server" />        <asp:Label runat="server" ID="l6" Text="eg. XX01YY1234" />      <br/>
        <asp:FileUpload runat="server" id="fileupload_vimg" />                                                                                      <br/>
            <asp:Button ID="btnClose" runat="server" Text="Close" /> <asp:Button ID="savebtn" runat="server" Text="save" oncommand="savebtn_Command"/>
        </asp:Panel>
    </form>
</body>
</html>
