<%@ Page Title="" Language="C#" MasterPageFile="~/AdminSection/GuestHouseMaster.master" AutoEventWireup="true" CodeFile="Frm_EditGuestHouse.aspx.cs" Inherits="AdminSection_Frm_EditGuestHouse" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript" language="javascript">
        function PopupOpen() {
            document.getElementById('<%=divCheckInOut.ClientID%>').style.display = "block";
            return false;
        }
        function PopupCancel() {
            document.getElementById('<%=divCheckInOut.ClientID%>').style.display = "none";
           }
           function ValidationOnSave() {
               var msg = '';
               if (document.getElementById('<%=ddlIdentityType.ClientID%>').selectedIndex <= 0) {
                msg = msg + "- Please select your identity \n";
            }
            if (document.getElementById('<%=txtIdentityNo.ClientID%>').value.trim() == "") {
                msg = msg + "- Enter Identity No \n";
            }
            if (document.getElementById('<%=txtFromdt.ClientID%>').value.trim() == "") {
                msg = msg + "- Enter from date \n";
            }
            if (document.getElementById('<%=txtToDt.ClientID%>').value.trim() == "") {
                msg = msg + "- Enter to date \n";
            }
            if (document.getElementById('<%=ChkRoom1.ClientID%>').checked == false && document.getElementById('<%=ChkRoom2.ClientID%>').checked == false && document.getElementById('<%=ChkRoom3.ClientID%>').checked == false && document.getElementById('<%=ChkRoom4.ClientID%>').checked == false) {
                msg = msg + "- Please select atleast 1 room \n";
            }
            if (msg != '') {
                alert(msg);
                return false;
            } else {
                document.getElementById('<%=divCheckInOut.ClientID%>').style.display = "block";
            }
        }

        function checkIN() {
            alert("Checked in successfully");
        }
        function checkOut() {
            alert("Checked out successfully");
        }
        function CheckFromDateToDate() {
            var str1 = document.getElementById('<%=txtFromdt.ClientID%>').value; //Fromdate
            var str2 = document.getElementById('<%=txtToDt.ClientID%>').value;  //todate      
            var sptdate1 = str1.split("/");
            var sptdate2 = str2.split("/");
            var datestring1 = sptdate1[1] + "/" + sptdate1[0] + "/" + sptdate1[2];
            var datestring2 = sptdate2[1] + "/" + sptdate2[0] + "/" + sptdate2[2];
            // alert(GlobalLanguage);
            var date1 = new Date(datestring1)
            var date2 = new Date(datestring2);
            if (date2 < date1) {

                alert("From Date Must Be Less Than To Date");
                document.getElementById('<%=txtToDt.ClientID%>').value = "";
                return false;
            }
            else {
                CheckDate();
                return true;
            }

        }
        function CheckDate() {
            var str1 = document.getElementById('<%=txtFromdt.ClientID%>').value; //Fromdate
            var str2 = document.getElementById('<%=txtToDt.ClientID%>').value;  //todate      
            var sptdate1 = str1.split("/");
            var sptdate2 = str2.split("/");
            var datestring1 = sptdate1[1] + "/" + sptdate1[0] + "/" + sptdate1[2];
            var datestring2 = sptdate2[1] + "/" + sptdate2[0] + "/" + sptdate2[2];
            // alert(GlobalLanguage);
            var date1 = new Date(datestring1)
            var date2 = new Date(datestring2);
            var NoOfDay = days_between(date1, date2)
            if (NoOfDay >= 2) {

                alert("Booking not allow more than two days");
                document.getElementById('<%=txtToDt.ClientID%>').value = "";
                return false;
            }
            else {
                return true;
            }
        }
        function days_between(date1, date2) {

            var ONE_DAY = 1000 * 60 * 60 * 24
            var date1_ms = date1.getTime()
            var date2_ms = date2.getTime()
            var difference_ms = Math.abs(date1_ms - date2_ms)
            return Math.round(difference_ms / ONE_DAY)

        }
    </script>
    <asp:UpdatePanel ID="up1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <table width="100%" align="center">
                <tr>
                    <td colspan="4" align="left" style="color: red;">Note: Check in time at 8:00 AM of day of booking checkout time 8:00 AM next day</td>
                </tr>
                <tr>
                    <td colspan="4">
                        <h3>
                            <asp:Label ID="lblError" runat="server" Font-Bold="True" Font-Size="15pt"></asp:Label></h3>
                    </td>
                </tr>
                <tr>
                    <td>Registration No.
                    </td>
                    <td>
                        <asp:TextBox ID="txtRegistrationno" runat="server"></asp:TextBox>
                    </td>
                    <td rowspan="2">
                        <img id="imgPic" runat="server" />
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td>Name
                    </td>
                    <td>
                        <asp:TextBox ID="txtName" runat="server" ReadOnly="true"></asp:TextBox>
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td>Email
                    </td>
                    <td>
                        <asp:TextBox ID="txtMail" runat="server" ReadOnly="true"></asp:TextBox>
                    </td>
                    <td>Mobile No
                    </td>
                    <td>
                        <asp:TextBox ID="txtMob" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Identity Type
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlIdentityType" runat="server" CssClass="txtbox">
                            <asp:ListItem Text="---Select---" Value="0"></asp:ListItem>
                            <asp:ListItem Text="Voter ID" Value="1"></asp:ListItem>
                            <asp:ListItem Text="Aadhar Card ID" Value="2"></asp:ListItem>
                            <asp:ListItem Text="Pan Card" Value="3"></asp:ListItem>
                            <asp:ListItem Text="Driving licence" Value="4"></asp:ListItem>
                        </asp:DropDownList>
                        <span style="color: Red">*</span>
                    </td>
                    <td>Identity No.
                    </td>
                    <td>
                        <asp:TextBox ID="txtIdentityNo" MaxLength="20" runat="server"></asp:TextBox>
                        <span style="color: Red">*</span>
                    </td>
                </tr>
                <tr>
                    <td>From Date
                    </td>
                    <td>
                        <asp:TextBox ID="txtFromdt" runat="server" onchange="checkDateFormat(this),CheckFromDateToDate()" AutoPostBack="true" OnTextChanged="txtFromdt_TextChanged" MaxLength="10"
                            CssClass="txtbox reqirerd"></asp:TextBox>
                        <img id="imgFromdt" src="../images/calender.png" /><span style="color: Red">*</span>
                        <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtFromdt"
                            Format="dd/MM/yyyy">
                        </cc1:CalendarExtender>
                    </td>
                    <td>To Date
                    </td>
                    <td>
                        <asp:TextBox ID="txtToDt" runat="server" onchange="checkDateFormat(this),CheckFromDateToDate()" AutoPostBack="true" OnTextChanged="txtFromdt_TextChanged" MaxLength="10"
                            CssClass="txtbox reqirerd"></asp:TextBox>
                        <img id="imgToDt" src="../images/calender.png" /><span style="color: Red">*</span>
                        <cc1:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txtToDt"
                            Format="dd/MM/yyyy">
                        </cc1:CalendarExtender>
                    </td>
                </tr>
                <tr>
                    <td>Select Room
                    </td>
                    <td colspan='3'>
                        <asp:CheckBox ID="ChkRoom1" runat="server" Text="Room1" OnCheckedChanged="ChkBedRequired_CheckedChanged" AutoPostBack="true" />
                        &nbsp;&nbsp;&nbsp; 
                <asp:CheckBox ID="ChkRoom2" runat="server" Text="Room2" OnCheckedChanged="ChkBedRequired_CheckedChanged" AutoPostBack="true" />
                        &nbsp;&nbsp;&nbsp;
                <asp:CheckBox ID="ChkRoom3" runat="server" Text="Room3" OnCheckedChanged="ChkBedRequired_CheckedChanged" AutoPostBack="true" />
                        &nbsp;&nbsp;&nbsp;
                <asp:CheckBox ID="ChkRoom4" runat="server" Text="Room4" OnCheckedChanged="ChkBedRequired_CheckedChanged" AutoPostBack="true" />
                        &nbsp;&nbsp;
                  <span style="color: Red">600 Rs/- per day</span>
                    </td>
                </tr>
                <tr>
                    <td>Extra Bed
                    </td>
                    <td colspan='3'>
                          <asp:CheckBox ID="ChkBedRequired1" runat="server" Text="Room1" OnCheckedChanged="ChkBedRequired_CheckedChanged" AutoPostBack="true" />
                        &nbsp;&nbsp;&nbsp; 
                        <asp:CheckBox ID="ChkBedRequired2" runat="server" Text="Room2" OnCheckedChanged="ChkBedRequired_CheckedChanged" AutoPostBack="true" />
                        &nbsp;&nbsp;&nbsp; 
                        <asp:CheckBox ID="ChkBedRequired3" runat="server" Text="Room3" OnCheckedChanged="ChkBedRequired_CheckedChanged" AutoPostBack="true" />
                        &nbsp;&nbsp;&nbsp; 
                        <asp:CheckBox ID="ChkBedRequired4" runat="server" Text="Room4" OnCheckedChanged="ChkBedRequired_CheckedChanged" AutoPostBack="true" />
                        <span style="color: Red">&nbsp;&nbsp; 200 Rs for extra bed per room.</span>
                    </td>
                </tr>
                <tr>
                    <td colspan="4">
                        <table width="100%">
                            <tr>
                                <td>No. of Room&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; *</td>
                                <td>No. of day&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; *</td>
                                <td>Charge per day&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; +</td>
                                <td>Extra Bed Amount&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; =</td>
                                <td>Total Payable Amount</td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblNoOfRoom" runat="server" Text="0"></asp:Label></td>
                                <td>
                                    <asp:Label ID="lblNoOfDay" runat="server" Text="0"></asp:Label></td>
                    </td>
                    <td>
                        <asp:Label ID="lblChargePerday" runat="server" Text="0"></asp:Label></td>
                    </td>
                       <td>
                           <asp:Label ID="lblExtraBedAmount" runat="server" Text="0"></asp:Label></td>
                    </td>
                       <td>
                           <asp:Label ID="lblTotalAmount" runat="server" Text="0"></asp:Label></td>
                    </td>
                </tr>
            </table>
            </td>
        </tr>           
        <tr>
            <td colspan="4" align="center">
                <asp:Button ID="BtnIn" runat="server" CssClass="btn" Text="Check In" OnClick="BtnIn_Click" OnClientClick="return ValidationOnSave(this);" />
                &nbsp;
                <asp:Button ID="BtnOut" runat="server" CssClass="btn" Text="Check Out" OnClick="BtnOut_Click" OnClientClick="return ValidationOnSave(this);" />
            </td>
        </tr>
            </table>
            <asp:HiddenField ID="hf_regno" runat="server" />
            <asp:HiddenField ID="hf_noofroom" runat="server" />
            <asp:HiddenField ID="hf_noofday" runat="server" />
            <asp:HiddenField ID="hf_ChkInChkOut" runat="server" />
        </ContentTemplate>
    </asp:UpdatePanel>

    <div id="divCheckInOut" runat="server" style="display: none; width: 70%; position: absolute; padding-left: 30%; padding-top: 20%; text-align: center; top: 50px;">
        <asp:Panel ID="Panel4" runat="server" BackColor="#FFFFFF" Height="200px"
            Width="300px" BorderStyle="Solid" BorderWidth="3" BorderColor="#004040" ScrollBars="None">
            <table width="300px">
                <tr>
                    <td style="padding-top: 10px; padding-left: 22px; font-weight: bold; font-size: 15px;">
                        <asp:Label ID="lblCheckInOut" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="padding-top: 10px; padding-left: 20px; font-weight: bold;">
                        <asp:DropDownList ID="ddlTime" Width="35px" runat="server" Height="27px">
                            <asp:ListItem>-Select-</asp:ListItem>
                            <asp:ListItem>1</asp:ListItem>
                            <asp:ListItem>2</asp:ListItem>
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
                        </asp:DropDownList>
                        &nbsp;<asp:DropDownList ID="ddlAMPM" runat="server" Width="50px">
                            <asp:ListItem>-Select-</asp:ListItem>
                            <asp:ListItem>AM</asp:ListItem>
                            <asp:ListItem>PM</asp:ListItem>
                        </asp:DropDownList>
                        <span style="color: Red">*</span>
                    </td>
                </tr>
                <tr>
                    <td style="padding-top: 20px;" align="center">
                        <asp:Button ID="btnOk" runat="server" Text="Ok" CssClass="btn" CommandArgument='<%#Eval("id")%>' OnClick="btnOk_Click" OnClientClick="return Validate();" />
                        &nbsp;&nbsp;
                        <asp:Button ID="btnclose" runat="server" Text="Close" CssClass="btn"
                            OnClientClick="return PopupCancel();" />
                    </td>
                </tr>
            </table>

        </asp:Panel>
    </div>
</asp:Content>

