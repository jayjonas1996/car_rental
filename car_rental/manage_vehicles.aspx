<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="manage_vehicles.aspx.cs" Inherits="car_rental.manage_vehicles" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxtoolkit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            height: 174px;
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
        height: 370px;
    }
        .auto-style2 {
            width: 1100px;
            height: 377px;
        }
        .vehiclebutton {
            position: relative;
            left: 750px;
        }
        .editbutton {
            top: 100px;
            position :relative;
            left: 800px;
        }
        .idiot_button{
            font-size: 18px;
            color: #ffd800;
            padding: 3px 5px 5px 3px;
            margin-bottom: 10px;
            background-color:#FFFFFF;
            border-color: #FFFFFF;
        }
        .confirmbtn
        {
            background-color:#6b83f5;
        }
        .confirm_red
        {
            background-color:#f16c6c;
        }
        .table_location {
            position: relative;
            left: 850px;
        }
        </style>
    <script>
        function show_edit_name()
        {
            
            $find("me").show();
            return true;
            
            
        }
        function show_image_up()
        {
            return false;
        }
    </script>
</head>
<body style="height: 669px">
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div class="auto-style1">
           <h1> <asp:Label ID="Label1" runat="server" Text="Manage Vehicles"></asp:Label></h1>
            <br />
            <br />
            <asp:Button ID="newmodelbtn" runat="server" Text="New Model" Width="80px" />
            
            <asp:Button ID="add_vehicle" runat="server" CssClass="vehiclebutton" Text="Button" Visible="False" />
            
            <asp:Button ID="editbutton" runat="server" CssClass="vehiclebutton" clientscript="return show_edit_name();" Text="Button" Visible="False" />
            
            <br />
&nbsp;&nbsp;&nbsp;
            <asp:Table ID="Table3" runat="server" Visible="false" CssClass="table_location">
                <asp:TableRow>
                                    <asp:TableCell ColumnSpan="2" HorizontalAlign="Center">
                                        <b>       <asp:Label text="change Status" runat="server"/>              </b>
                                    </asp:TableCell>

          </asp:TableRow>
            <asp:TableRow>
                                    <asp:TableCell>
                                        <asp:Label runat="server" text="select vehicle id"></asp:Label>
                                    </asp:TableCell>
                                        
                                    <asp:TableCell    HorizontalAlign="Center">
                                        <asp:DropDownList ID="store_vid" runat="server" >

                                        </asp:DropDownList>
                                    </asp:TableCell>
            </asp:TableRow>
          <asp:TableRow>
                                    <asp:TableCell>
                                                  <asp:Label text="availability" runat="server"/>
                                    </asp:TableCell>
                                    <asp:TableCell>
                                                    <asp:DropDownList ID="dropdown_status_change" runat="server">
                                                        <asp:ListItem Selected="True">Y</asp:ListItem>
                                                        <asp:ListItem>N</asp:ListItem>
                                                    </asp:DropDownList>
                                    </asp:TableCell>

          </asp:TableRow>
         <asp:TableRow>
                                    <asp:TableCell>
                                                    <asp:Label runat="server" Text="status" />
                                    </asp:TableCell>
                                    <asp:TableCell>
                                                    <asp:TextBox runat="server" ID="new_status_box" />
                                    </asp:TableCell>

         </asp:TableRow>
         <asp:TableRow>
                                    <asp:TableCell HorizontalAlign="Center">
                                                    <asp:Button ID="close_status_popup" runat="server" Text="cancel" />
                                    </asp:TableCell>
                                    <asp:TableCell HorizontalAlign="Center">
                                                    <asp:Button ID="change_status" runat="server" text="Change Status"  OnClick="change_status_pressed" />
                                    </asp:TableCell>

         </asp:TableRow>
            </asp:Table>
            
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
       <asp:Label runat="server" ID="Label12" Text="Fuel Type"  />     <asp:RadioButton ID="RadioButton1" runat="server"  GroupName="f" Text="petrol" Checked="True" />
          <asp:RadioButton ID="RadioButton2" runat="server" GroupName="f" Text="diesel" />  <br/>
         <asp:Label runat="server" ID="seats" Text="number of seats; "  />   <asp:DropDownList ID="seats_list" runat="server" >
            <asp:ListItem Selected="True">2</asp:ListItem>
            <asp:ListItem>3</asp:ListItem>
            <asp:ListItem>4</asp:ListItem>
            <asp:ListItem>5</asp:ListItem>
                <asp:ListItem>6</asp:ListItem>
            <asp:ListItem>7</asp:ListItem>
                <asp:ListItem>8</asp:ListItem>
            <asp:ListItem>9</asp:ListItem>
                <asp:ListItem>10</asp:ListItem>
            <asp:ListItem>11</asp:ListItem>
                 <asp:ListItem>12</asp:ListItem>
        </asp:DropDownList>                                                         <br/>
            <asp:Label runat="server" ID="Label13" Text="Charge amount:"  />             <asp:Textbox runat="server" ID="Textbox4" type="number"/>            <br/>
        <asp:Label id="l5" runat="server" Text="Registration Number" />           <asp:Textbox ID="t4" runat="server" />        <asp:Label runat="server" ID="l6" Text="eg. XX01YY1234" />      <br/>
        <asp:FileUpload runat="server" id="fileupload_vimg" />                                                                                      <br/>
            <asp:Button ID="btnClose" runat="server" Text="Close" /> <asp:Button ID="savebtn" runat="server" Text="save" oncommand="savebtn_Command"/>
        </asp:Panel>


        <ajaxtoolkit:ModalPopupExtender ID="mp2" runat="server" PopupControlID="Panel2" TargetControlID="add_vehicle"
    CancelControlID="close" BackgroundCssClass="modalBackground">
</ajaxtoolkit:ModalPopupExtender>


        <asp:Panel ID="Panel2" runat="server" CssClass="modalPopup" HorizontalAlign="Center" style="display:none">
            <h4>Add another</h4>
            <asp:Label id="Label2" runat="server" Text="Vehicle ID:" />&nbsp&nbsp&nbsp<asp:Label id="Label3" runat="server" Text=" :" />              <br/>
            <asp:Label id="Label10" runat="server" Text="Vehicle Name:" />&nbsp&nbsp&nbsp<asp:Label id="Label11" runat="server" Text=" :" />              <br/>
            <asp:Label id="Label_seats" runat="server" Text="___" />&nbsp&nbsp <asp:Label id="Label_charges" runat="server" Text="___" /> &nbsp&nbsp<asp:Label id="Label_type" runat="server" Text="____" />        <br/>
            <asp:Label id="Label4" runat="server" Text="availability:" />  &nbsp&nbsp&nbsp    <asp:DropDownList runat="server" ID="dropdown_yn">  <asp:ListItem Selected="True">Y</asp:ListItem>
              <asp:ListItem>N</asp:ListItem>   </asp:DropDownList>                    <br/>
            <asp:Label id="Label5" runat="server" Text="Status" />   &nbsp&nbsp&nbsp   <asp:Textbox ID="Textbox1" runat="server" /> &nbsp<asp:Label id="Label6" runat="server" Text="leave blank if above option is Y" />                                 <br/>
            <asp:Label id="Label7" runat="server" Text="initial kilometer readings" />   &nbsp&nbsp&nbsp <asp:Textbox ID="Textbox2" runat="server" Type="number" />                                                             <br/>
        <asp:Label id="Label8" runat="server" Text="Registration Number" />           <asp:Textbox ID="Textbox3" runat="server" />        <asp:Label runat="server" ID="Label9" Text="eg. XX01YY1234" />                        <br/>
            <asp:Button ID="close" runat="server" Text="Close" /> <asp:Button ID="insert_vehicle" runat="server" OnClick="insert_vehicle_Click" Text="Insert" />
            </asp:Panel>


        <!--modal extender for editing group name-->

        <ajaxtoolkit:ModalPopupExtender ID="mp3" BehaviorID="me" runat="server" PopupControlID="Panel3_edit_name" TargetControlID="editbutton"
    CancelControlID="close_group_name_modal" BackgroundCssClass="modalBackground">
</ajaxtoolkit:ModalPopupExtender>

        <!--edit group name panel-->

        <asp:Panel ID="Panel3_edit_name" runat="server" CssClass="modalPopup" HorizontalAlign="Center" style="display:none">
            <asp:table runat="server">
                <asp:TableRow>
                    <asp:TableCell >
                        <asp:Label ID="edit_name_grp_id" runat="server" Text="__"/> 
                    </asp:TableCell></asp:TableRow><asp:TableRow>
                    <asp:TableCell >
                            <b>    <asp:Label ID="show_heading_edit_name" runat="server" Text="Change Display Name"/> </b>
                    </asp:TableCell></asp:TableRow><asp:TableRow>
                    <asp:TableCell>
                                    <asp:Label runat="server" Text="Name: "/>
                    </asp:TableCell><asp:TableCell>
                                    <asp:TextBox ID="edit_name_box" runat="server"/>
                    </asp:TableCell></asp:TableRow><asp:TableRow>
                    <asp:TableCell HorizontalAlign="Center">
                                    <asp:Button ID="close_group_name_modal" runat="server" text="Cancel"/>
                    </asp:TableCell><asp:TableCell HorizontalAlign="Center">
                                    <asp:Button id="edit_name" runat="server" OnClick="edit_name_btn" text="Change" />
                    </asp:TableCell></asp:TableRow></asp:table></asp:Panel>
        
        
        <!-- modal extender for changing status --><!-- Change status panel -->
        
        <asp:Panel id="Panel3" runat="server" cssclass="modalPopup" HorizontalAlign="Center" style="display:none">

                           

        </asp:Panel><div class="auto-style2">
            <asp:Button ID="dumb" visible="true" Enabled="false" CssClass="idiot_button" text="Models" runat="server"></asp:Button>
            <br />
            <asp:Table ID="Table1" runat="server">
            </asp:Table>
            

        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:Table ID="Table2" runat="server" HorizontalAlign="Right" Visible="False" BorderStyle="Solid" BorderWidth="2px" GridLines="Both">
          
            </asp:Table>
            
        </div>
        
    </form>
</body>
</html>
