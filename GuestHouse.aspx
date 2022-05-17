<%@ Page Language="C#" MasterPageFile="~/AdminSection/MasterPage.master" AutoEventWireup="true"
    CodeFile="GuestHouse.aspx.cs" Inherits="GuestHouse" Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script type="text/javascript" language="javascript">
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
            }
        }
        function PopTemAndConditionRenew() {
            document.getElementById('<%=divRenewal.ClientID%>').style.display = "block";
            return false;
        }
        function PopAcceptRenew() {
            document.getElementById('<%=divRenewal.ClientID%>').style.display = "none";
            return true;
        }
        function ValidationOnAvailability() {
            var msg = '';

            if (document.getElementById('<%=txtFromdt.ClientID%>').value.trim() == "") {
                msg = msg + "- Enter from date \n";
            }
            if (document.getElementById('<%=txtToDt.ClientID%>').value.trim() == "") {
                msg = msg + "- Enter to date \n";
            }

            if (msg != '') {
                alert(msg);
                return false;
            }
        }

        function MessageVerify() {
            alert("Room Booked Successfully");
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
                        <td colspan="4" align="left" style="color: red;">Note: 1. Check in time at 8:00 AM of day of booking checkout time 8:00 AM next day and  after booking amount can not be refundable
                        <br />
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 2. For member other than madhya pradesh please contact to MPSVC contact no.  0755 - 2670153 / 2771987 </td>
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
                        <td>
                            <asp:Button ID="btnsearch" runat="server" CssClass="btn" Text="search" OnClick="btnsearch_Click" />
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
                        <td>Applicant's Identity Type
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
                        <td>
                            <b>Select date</b>
                        </td>
                        <td></td>
                        <td></td>
                        <td></td>
                    </tr>
                    <tr>
                        <td>From Date
                        </td>
                        <td>
                            <asp:TextBox ID="txtFromdt" runat="server" onchange="checkDateFormat(this),CheckFromDateToDate()" AutoPostBack="true" OnTextChanged="txtFromdt_TextChanged" MaxLength="10"
                                CssClass="txtbox reqirerd"></asp:TextBox>
                            <img id="imgFromdt" src="images/calender.png" /><span style="color: Red">*</span>
                            <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtFromdt" PopupButtonID="imgFromdt"
                                Format="dd/MM/yyyy">
                            </cc1:CalendarExtender>
                        </td>
                        <td>To Date
                        </td>
                        <td>
                            <asp:TextBox ID="txtToDt" runat="server" onchange="checkDateFormat(this),CheckFromDateToDate()" AutoPostBack="true" OnTextChanged="txtFromdt_TextChanged" MaxLength="10"
                                CssClass="txtbox reqirerd"></asp:TextBox>
                            <img id="imgToDt" src="images/calender.png" /><span style="color: Red">*</span>
                            <cc1:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txtToDt" PopupButtonID="imgToDt"
                                Format="dd/MM/yyyy">
                            </cc1:CalendarExtender>

                            <asp:LinkButton ID="lnkChkAvail" runat="server" CssClass="btn" OnClientClick="return ValidationOnAvailability();" OnClick="lnkChkAvail_Click">Check Availability</asp:LinkButton>

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
                  <span style="color: Red">800 Rs/- per day</span>
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
                <asp:Button ID="btnBook" runat="server" CssClass="btn" OnClick="btnBook_Click" Text="Proceed For Payment" OnClientClick="return ValidationOnSave();" />
            </td>
        </tr>
                </table>
             <asp:HiddenField ID="HF_Application" runat="server" />
                <asp:HiddenField ID="hf_regno" runat="server" />
                <asp:HiddenField ID="hf_noofroom" runat="server" />
                <asp:HiddenField ID="hf_noofday" runat="server" />
                <div class="reveal-modal-bg" id="divRenewal" runat="server" style="display: none; width: 70%; position: absolute; padding-left: 30%; padding-top: 20%">
                    <asp:Panel ID="Panel1" runat="server" BackColor="#FFFFFF" Height="150px" Width="440px"
                        BorderStyle="Solid" BorderWidth="3" BorderColor="#004040" ScrollBars="None">
                        <table width="440px">
                            <tr>
                                <td colspan="2" style="padding-top: 10px; color: Red; font-weight: bold;" align="center">
                                    <asp:Label ID="lblMSgAlert" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="padding-top: 20px;" align="center">
                                    <asp:Button ID="btnRedirect" runat="server" Text="Ok" OnClientClick="javascript:return(PopAcceptRenew());"
                                        Width="100" CssClass="btn" OnClick="Button1_Click" />
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>  
</asp:Content>
