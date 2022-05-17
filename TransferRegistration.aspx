<%@ Page Language="C#" MasterPageFile="~/AdminSection/MasterPage.master" AutoEventWireup="true"
    CodeFile="TransferRegistration.aspx.cs" Inherits="TransferRegistration" Title="Transfer Registration" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <style type="text/css">
        .bgDiv {
            position: absolute;
            height: 600px;
            width: 100%;
            top: 0px;
            bottom: 0px;
            left: 0px;
            right: 0px;
            overflow: hidden;
            padding: 0;
            padding-top: 100px;
            margin: 0; /*background-color: Transparent; */
            background-image: url(webyojnaimgYellow/Transparent_bg.gif);
            z-index: 1000;
            clear: both;
        }
    </style>

    <script type="text/javascript" language="javascript">

        function PopOTPVerification() {
            document.getElementById('<%=divOTP.ClientID%>').style.display = "block";
             return false;
         }
         function PopOTPNotVerified() {
             document.getElementById('<%=divOTP.ClientID%>').style.display = "none";
            return true;
        }

        function CheckPastDate() {
            var chkDt = document.getElementById('<%=txtPaymentDate.ClientID%>').value;
            var beforeDate = document.getElementById('<%=HdnDate.ClientID%>').value;
            var ArrChequeDate = chkDt.split('/');
            var Finalchequedate = ArrChequeDate[1] + '/' + ArrChequeDate[0] + '/' + ArrChequeDate[2];

            if (new Date(Finalchequedate) <= new Date(beforeDate)) {
                alert("Payment date should not accept more than 45 days old");
                document.getElementById('<%=txtPaymentDate.ClientID%>').value = '';
                return false;
            }
        }

        function checkDateFormat(that) {

            var mo, day, yr;
            var entry = that.value;
            var re = /\b\d{1,2}[\/-]\d{1,2}[\/-]\d{4}\b/;
            if (re.test(entry)) {
                var delimChar = (entry.indexOf("/") != -1) ? "/" : "-";
                var delim1 = entry.indexOf(delimChar);
                var delim2 = entry.lastIndexOf(delimChar);

                day = parseInt(entry.substring(0, delim1), 10);
                mo = parseInt(entry.substring(delim1 + 1, delim2), 10);
                yr = parseInt(entry.substring(delim2 + 1), 10);
                var testDate = new Date(yr, mo - 1, day);

                if (testDate.getDate() == day) {
                    if (testDate.getMonth() + 1 == mo) {
                        if (testDate.getFullYear() == yr) {
                            return true;
                        } else {
                            that.value = "";
                            alert("Invalid date.");
                        }
                    }
                    else {
                        that.value = "";
                        alert("Invalid date.");

                    }
                }
                else {
                    that.value = "";
                    alert("Invalid date.");
                }
            }
            else {
                if (entry != "") {
                    that.value = "";
                    alert("Incorrect date format. Enter as (dd/MM/yyyy).");
                }
            }
            return false;
        }

        function ValidateFileSize(a) {

            var uploadcontrol = document.getElementById(a.id);
            if (uploadcontrol.files[0].size > 512000) {
                alert('File size should not greater than 512 kb.');
                document.getElementById(a.id).value = '';
                return false;
            }
            else {
                return true;
            }

        }
        function UploadControlValidationForLenthAndFileFormat(maxLengthFileName, validFileFormaString, uploadControlId) {
            //ex---------------
            //maxLengthFileName=50;
            //validFileFormaString=JPG*JPEG*PDF*DOCX
            //uploadControlId=upSaveBill
            //ex---------------
            var msg = '';
            if (document.getElementById(uploadControlId).value != '') {
                var size = document.getElementById(uploadControlId);

                var fileName = document.getElementById(uploadControlId).value;
                var lengthFileName = parseInt(document.getElementById(uploadControlId).value.length)

                var fileExtacntionArray = new Array();
                fileExtacntionArray = fileName.split('.');

                if (fileExtacntionArray.length == 2) {

                    var fileExtacntion = fileExtacntionArray[fileExtacntionArray.length - 1];


                    if (lengthFileName >= parseInt(maxLengthFileName) + parseInt(1)) {
                        msg += '- File name should be less than ' + maxLengthFileName + ' characters. \n';
                    }
                    for (i = 0; i <= (fileName.length - 1) ; i++) {
                        var charFileName = '';

                        charFileName = fileName.substring(i, i + 1);

                        if ((charFileName == '~') || (charFileName == '!') || (charFileName == '@') || (charFileName == '#') || (charFileName == '$') || (charFileName == '%') || (charFileName == '&') || (charFileName == '*') || (charFileName == '{') || (charFileName == '}') || (charFileName == '|') || (charFileName == '<') || (charFileName == '>') || (charFileName == '?')) {

                            msg += '- Special character not allowed in file name. \n';
                            break;
                        }

                    }
                    var isFileFormatCorrect = false;
                    var strValidFormates = '';

                    if (validFileFormaString != "") {

                        var fileFormatArray = new Array();
                        fileFormatArray = validFileFormaString.split('*');

                        for (var j = 0; j < fileFormatArray.length; j++) {
                            if (fileFormatArray[j].toUpperCase() == fileExtacntion.toUpperCase()) {
                                isFileFormatCorrect = true;
                            }

                            if (j == fileFormatArray.length - 1) {
                                strValidFormates += '.' + fileFormatArray[j].toLowerCase();

                            }
                            else {
                                strValidFormates += '.' + fileFormatArray[j].toLowerCase() + '/';

                            }
                        }

                        if (isFileFormatCorrect == false) {
                            msg += '- File format is not correct (only ' + strValidFormates + ').\n';
                        }

                    }

                }
                else {
                    msg += '- File name is incorrect';
                }
                if (msg != '') {
                    document.getElementById(uploadControlId).value = "";
                    alert(msg);
                    return false;
                }
                else {
                    return true;
                }

            }
        }

        function ValidationInitialization() {
            var msg = '';
            if (document.getElementById('<%=txtFName.ClientID%>').value.trim() == "") {
                msg = msg + "-First name can not be left blank \n";
            }
            if (document.getElementById('<%=txtLastName.ClientID%>').value.trim() == "") {
                msg = msg + "-Last name can not be left blank \n";
            }
            if (document.getElementById('<%=txtFatherName.ClientID%>').value.trim() == "") {
                msg = msg + "-Father name can not be left blank \n";
            }
            if (document.getElementById('<%=txtDOB.ClientID%>').value.trim() == "") {
                msg = msg + "-Date of birth can not be left blank \n";
            }
            if (document.getElementById('<%=ddldept.ClientID%>').value.trim() == "") {
                msg = msg + "-Please select department \n";
            }
            if (document.getElementById('<%=ddldesig.ClientID%>').value.trim() == "") {
                msg = msg + "-Please select designation \n";
            }
            <%--   if (document.getElementById('<%=txtPhoneNo.ClientID%>').value.trim() == "") {
                alert("Phone No can not be left blank");
                return false;
            }--%>
            if (document.getElementById('<%=ddlPresentOcc.ClientID%>').value == "Select") {
                msg = msg + "-Please select Sector \n";
            }
            if (document.getElementById('<%=ddlPreffAddress.ClientID%>').value == "Select") {
                msg = msg + "-Please select Preferred Address \n";
            }
            if (document.getElementById('<%=txtMobileNo1.ClientID%>').value.trim() == "") {
                msg = msg + "-Mobile no. can not be left blank \n";
            }
            if (document.getElementById('<%=rbmobile2.ClientID%>').checked == true) {
                if (document.getElementById('<%=txtMobileNo2.ClientID%>').value.trim() == "") {
                    msg = msg + "Please enter mobile no2(If you are checked preferred mobile no2) \n";
                }
            }
            if (document.getElementById('<%=txtEmailId.ClientID%>').value.trim() == "") {
                msg = msg + "-Email address can not be left blank \n";
            }
            if (document.getElementById('<%=ddlTransferState.ClientID%>').value.trim() == "Select") {
                msg = msg + "-Please select Transfer state \n";
            }
            if (document.getElementById('<%= rboffline.ClientID%>').checked == true) {
                if (document.getElementById('<%=txtcheque.ClientID%>').value.trim() == "") {
                    msg = msg + "-Cheque no. can not be left blank \n";
                }
            }
            if (document.getElementById('<%= rboffline.ClientID%>').checked == true) {
                if (document.getElementById('<%=txtbank.ClientID%>').value.trim() == "") {
                    msg = msg + "-Bank name can not be left blank \n";
                }
            }
            if (document.getElementById('<%= rboffline.ClientID%>').checked == true) {
                if (document.getElementById('<%=txtPaymentDate.ClientID%>').value.trim() == "") {
                    msg = msg + "-Payment date can not be left blank \n";
                }
            }
            if (msg != '') {
                alert(msg);
                return false;
            }
            else {
                if (confirm("Do you really want to save?")) {
                    return true;
                }
                else {
                    return false;
                }
            }
        }


    </script>

    <script type="text/javascript" language="javascript">

        function MessageVerify() {
            alert("Application forwarded successfully");
        }
        function CancelRegistration() {
            alert("Your Registration is cancelled, Please contact to mpsvc office");
        }

        function IsOffline() {
            if (document.getElementById('<%=rboffline.ClientID%>').checked == true) {
                document.getElementById('<%=tr_Pdate.ClientID%>').style.visibility = "visible";
                document.getElementById('<%=tr_cheque.ClientID%>').style.visibility = "visible";
                document.getElementById('<%=tr_payment.ClientID%>').style.visibility = "visible";

            } else {
                document.getElementById('<%=tr_Pdate.ClientID%>').style.visibility = "hidden";
                document.getElementById('<%=tr_cheque.ClientID%>').style.visibility = "hidden";
                document.getElementById('<%=tr_payment.ClientID%>').style.visibility = "hidden";
            }
        }

        function PopTemAndConditionTrans() {
            document.getElementById('<%=divRenewal.ClientID%>').style.display = "block";
            return false;
        }
        function PopAcceptTrans() {
            document.getElementById('<%=divRenewal.ClientID%>').style.display = "none";
            return true;
        }

        function PopTemAndConditionOnSave() {
            document.getElementById('<%=divPopOnSave.ClientID%>').style.display = "block";
             return false;
         }
         function PopAcceptOnSave() {
             document.getElementById('<%=divPopOnSave.ClientID%>').style.display = "none";
            return true;
        }

        function checkAphabets(a) {

            var pin = document.getElementById(a.id).value;
            var valid = pin.length;

            for (i = 0; i <= valid - 1; i++) {
                var age = Number(pin.charAt(i));
                if (age != 0 && age != 1 && age != 2 && age != 3 && age != 4 && age != 5 && age != 6 && age != 7 && age != 8 && age != 9) {
                    alert("Characters are not allowed");
                    document.getElementById(a.id).value = '';
                    return false;
                }
            }
        }

    </script>

    <table width="100%" cellpadding="0" cellspacing="0">
        <tr>
            <td colspan="4">
                <h2>
                    <strong>Transfer out of M.P.</strong></h2>
            </td>
        </tr>
        <tr>
            <td colspan="4">
                <asp:Label ID="lblMsg" runat="server" Font-Bold="True" Font-Size="15pt"></asp:Label>
            </td>
        </tr>
        <tr id="tr_Reg" runat="server">
            <td>Registration No :
            </td>
            <td>
                <asp:TextBox ID="txtRegNo" runat="server" MaxLength="12"
                    CssClass="txtbox reqirerd"></asp:TextBox><span style="color:Red">*</span><asp:Button ID="btnSearch" runat="server" CssClass="btn" Text="Search" OnClick="btnSearch_Click" />
            </td>
            <td colspan="2">
                <span style="color:red;font-size:14px;">* Step1. Enter Your Registration Number <br />and Click on Search Button.</span>
            </td>
           
        </tr>

        <tr>
            <td><br /></td>
            <td></td>
            <td></td>
            <td></td>
        </tr>

        <tr>
            <td colspan="4"> <hr /></td>
            
        </tr>

        <tr>
            <td><br /></td>
            <td></td>
            <td></td>
            <td></td>
        </tr>

        <tr>
            <td>First Name :
            </td>
            <td>
                <asp:TextBox ID="txtFName" runat="server" MaxLength="60" onkeypress='javascript:tbx_fnAlphaOnly(event, this);'
                    CssClass="txtbox reqirerd" Enabled="false"></asp:TextBox><span style="color:Red">*</span>
            </td>
            <td>Middle Name :
            </td>
            <td>
                <asp:TextBox ID="txtMName" runat="server" onkeypress='javascript:tbx_fnAlphaOnly(event, this);'
                    MaxLength="60" Enabled="false"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Last Name :
            </td>
            <td>
                <asp:TextBox ID="txtLastName" runat="server" MaxLength="60" onkeypress='javascript:tbx_fnAlphaOnly(event, this);'
                    CssClass="txtbox reqirerd" Enabled="false"></asp:TextBox><span style="color:Red">*</span>
            </td>
            <td>Father Name :
            </td>
            <td>
                <asp:TextBox ID="txtFatherName" runat="server" MaxLength="200" onkeypress='javascript:tbx_fnAlphaOnly(event, this);'
                    CssClass="txtbox reqirerd" Enabled="false"></asp:TextBox><span style="color:Red">*</span>
            </td>
        </tr>
        <tr>
            <td>Date Of Birth :
            </td>
            <td>
                <asp:TextBox ID="txtDOB" runat="server" onchange="checkDateFormat(this)" MaxLength="10"
                    CssClass="txtbox reqirerd" Enabled="false"></asp:TextBox>
                &nbsp;<img id="imgDob" src="images/calender.png" /><span style="color:Red">*</span>
            </td>
            <td>Gender :
            </td>
            <td>
                <asp:DropDownList ID="ddlGender" runat="server" CssClass="txtbox" Enabled="false">
                    <asp:ListItem>Transgender</asp:ListItem>
                    <asp:ListItem>Male</asp:ListItem>
                    <asp:ListItem>Female</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>Organization :
            </td>
            <td>
                <asp:DropDownList ID="ddlorg" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlorg_SelectedIndexChanged">
                </asp:DropDownList>
                <asp:TextBox ID="txtOrg" runat="server" Visible="false"></asp:TextBox>
            </td>
            <td></td>
            <td></td>
        </tr>
        <tr>
            <td>Department :
            </td>
            <td>
                <asp:DropDownList ID="ddldept" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddldept_SelectedIndexChanged">
                </asp:DropDownList><span style="color:Red">*</span>
                <asp:TextBox ID="txtDept" runat="server" Visible="false"></asp:TextBox>
            </td>
            <td></td>
            <td></td>
        </tr>
        <tr>
            <td>Designation :
            </td>
            <td>
                <asp:DropDownList ID="ddldesig" runat="server" CssClass="txtbox" AutoPostBack="True" OnSelectedIndexChanged="ddldesig_SelectedIndexChanged">
                </asp:DropDownList><span style="color:Red">*</span>
                <asp:TextBox ID="txtDesig" runat="server" Visible="false"></asp:TextBox>
            </td>
            <td></td>
            <td></td>
        </tr>
        <tr>
            <td>Sector :
            </td>
            <td>
                <asp:DropDownList ID="ddlPresentOcc" runat="server" AutoPostBack="true" CssClass="txtbox"
                    OnSelectedIndexChanged="ddlPresentOcc_SelectedIndexChanged">
                </asp:DropDownList>
                <asp:TextBox ID="txtPresentOcc" runat="server" Visible="false"></asp:TextBox><span style="color:Red">*</span>
            </td>
            <td></td>
            <td></td>
        </tr>
        
        <tr>
            <td>Preferred Address :
            </td>
            <td>
                <asp:DropDownList ID="ddlPreffAddress" runat="server" CssClass="txtbox">
                    <asp:ListItem>Select</asp:ListItem>
                    <asp:ListItem>Residential</asp:ListItem>
                    <asp:ListItem>Professional</asp:ListItem>
                    <asp:ListItem>Permanent</asp:ListItem>
                </asp:DropDownList><span style="color:Red">*</span>
            </td>
            <td></td>
            <td></td>
        </tr>
        <tr>
            <td>Land-Line No. :
            </td>
            <td>
                <%--<asp:TextBox ID="txtPhoneNo" runat="server" MaxLength="7" CssClass="txtbox reqirerd"
                    onblur="return checkAphabets(this);" onkeypress='javascript:tbx_fnInteger(event, this);'></asp:TextBox>--%>

                <asp:TextBox ID="txtSTDcode" runat="server" MaxLength="5" Style="width: 40px;"
                    onblur="return checkAphabets(this);" onkeypress='javascript:tbx_fnInteger(event, this);'></asp:TextBox>
                <asp:TextBox ID="txtPreffPhoneNo" runat="server" MaxLength="7" CssClass="txtbox" Width="140"
                    onblur="return chkPreferedPhone(this);" onkeypress='javascript:tbx_fnInteger(event, this);'></asp:TextBox>
            </td>
            <td valign="middle">Mobile No. :                
            </td>
            <td>1. &nbsp;<asp:TextBox ID="txtMobileNo1" runat="server" MaxLength="10" Style="width: 65px; font-size: 10px;" CssClass="txtbox reqirerd"
                onblur="return checkAphabets(this);" onkeypress='javascript:tbx_fnInteger(event, this);'></asp:TextBox><span style="color:Red">*</span>
                &nbsp;&nbsp;&nbsp;
                2. &nbsp;
                <asp:TextBox ID="txtMobileNo2" runat="server" MaxLength="10" Style="width: 65px; font-size: 10px;" CssClass="txtbox reqirerd"
                    onblur="return checkAphabets(this);" onkeypress='javascript:tbx_fnInteger(event, this);'></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Fax No :
            </td>
            <td>
                <asp:TextBox ID="txtStdFaxCode" runat="server" MaxLength="5" Style="width: 40px;"
                    onblur="return checkAphabets(this);" onkeypress='javascript:tbx_fnInteger(event, this);'></asp:TextBox>
                <asp:TextBox ID="txtFaxNo" runat="server" MaxLength="15" CssClass="txtbox" Width="140" onblur="return checkAphabets(this);"
                    onkeypress='javascript:tbx_fnInteger(event, this);'></asp:TextBox>
            </td>
            <td>Email Id :
            </td>
            <td>
                <asp:TextBox ID="txtEmailId" runat="server" MaxLength="100" CssClass="txtbox reqirerd"></asp:TextBox><span style="color:Red">*</span>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2"
                    runat="server" ErrorMessage="Please Enter Valid Email ID" ControlToValidate="txtEmailId" ForeColor="Red" Display="Dynamic"
                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">
                </asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td>Preferred Mobile No. :
            </td>
            <td>
                <asp:RadioButton ID="rbmobile1" Checked="true" GroupName="mobile" runat="server" Text="Mobile No. 1" />
                <asp:RadioButton ID="rbmobile2" runat="server" GroupName="mobile" Text="Mobile No. 2" />
            </td>
            <td>&nbsp;
            </td>
            <td>&nbsp;
            </td>
        </tr>

        <tr id="tr1" runat="server">
            <td style="height: 27px" colspan="4">
                <h3 class="bluefnt">Transfer Detail</h3>
                &nbsp; &nbsp;
            </td>
        </tr>
        <tr>
            <td>Transfer To State :
            </td>
            <td>
                <asp:DropDownList ID="ddlTransferState" runat="server" CssClass="txtbox" OnInit="ddlTransferState_Init">
                </asp:DropDownList><span style="color:Red">*</span>
            </td>
            <td>&nbsp;
            </td>
            <td>&nbsp;
            </td>
        </tr>
        <tr>
            <td>Payment Type :
            </td>
            <td>
                <asp:RadioButton ID="rbOnline" runat="server" Text="Online Payment" onchange="IsOffline()"
                    GroupName="rbPayment" />
                <asp:RadioButton ID="rboffline" runat="server" Text="Offline Payment" onchange="IsOffline()"
                    GroupName="rbPayment" />
            </td>
            <td>Payable Amount :
            </td>
            <td>
                <asp:TextBox ID="lblAmount" runat="server" Text="15" Enabled="false"></asp:TextBox></td>
            &nbsp;
        </tr>
        <tr id="tr_payment" runat="server">
            <td style="height: 27px" colspan="4">
                <h3 class="bluefnt">Payment</h3>
                &nbsp; &nbsp;
            </td>
        </tr>
        <tr id="tr_cheque" runat="server">
            <td>Cheque/DD No :
            </td>
            <td>
                <asp:TextBox ID="txtcheque" runat="server" MaxLength="15" CssClass="txtbox"></asp:TextBox><span style="color:Red">*</span>
            </td>
            <td>Bank Name
            </td>
            <td>
                <asp:TextBox ID="txtbank" runat="server" MaxLength="50" CssClass="txtbox"></asp:TextBox><span style="color:Red">*</span>
                <cc1:FilteredTextBoxExtender ID="filtered1" runat="server" TargetControlID="txtbank" FilterType="LowercaseLetters, UppercaseLetters"></cc1:FilteredTextBoxExtender>
            </td>
        </tr>
        <tr id="tr_Pdate" runat="server">
            <td>Date :
            </td>
            <td>
                <asp:TextBox ID="txtPaymentDate" runat="server" onchange="checkDateFormat(this), CheckPastDate();"
                    MaxLength="15" CssClass="txtbox"></asp:TextBox>
                <img id="imgDob2" src="images/calender.png" /><span style="color:Red">*</span>
                &nbsp;<cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtPaymentDate"
                    Format="dd/MM/yyyy" PopupButtonID="imgDob2">
                </cc1:CalendarExtender>
                <cc1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtPaymentDate"
                    Format="dd/MM/yyyy">
                </cc1:CalendarExtender>
            </td>
            <td>&nbsp;
            </td>
            <td>&nbsp;
            </td>
        </tr>
        <tr>
            <td></td>
            <td>
                <asp:Button ID="btnUpdate" runat="server" Text="Save & Pay" CssClass="btn" OnClick="btnUpdate_Click"
                    OnClientClick="return ValidationInitialization();" />
                &nbsp;&nbsp;&nbsp;&nbsp;
                <asp:LinkButton ID="lnkdisApprove" runat="server" CssClass="btn" Text="Not Approve" OnClick="lnkdisApprove_Click" Visible="false"></asp:LinkButton>
            </td>
            <td></td>
            <td></td>
        </tr>
        <tr>
            <td></td>
            <td></td>
            <td></td>
            <td></td>
        </tr>
        <asp:HiddenField ID="hdnFile" runat="server" />
        <asp:HiddenField ID="hf_regno" runat="server" />
        <asp:HiddenField ID="HF_RegistationFees" runat="server" />
        <asp:HiddenField ID="HF_RenewalFees" runat="server" />
        <asp:HiddenField ID="HF_transferFees" runat="server" />
        <asp:HiddenField ID="HF_ServiceChagre" runat="server" />
        <asp:HiddenField ID="HF_LateFees" runat="server" />
        <asp:HiddenField ID="HF_ReEstabilishmentFees" runat="server" />
        <asp:HiddenField ID="HF_Ok" runat="server" />
        <asp:HiddenField ID="HF_Totalamount" runat="server" />
        <cc1:CalendarExtender ID="CetxtTenderSubDt" runat="server" TargetControlID="txtDOB"
            Format="dd/MM/yyyy" PopupButtonID="imgDob">
        </cc1:CalendarExtender>
    </table>

    <div class="reveal-modal-bg" id="divRenewal" runat="server" style="display: none; width: 70%; position: absolute; padding-left: 30%; padding-top: 20%">
        <asp:Panel ID="Panel1" runat="server" BackColor="#FFFFFF" Height="340px" Width="440px"
            BorderStyle="Solid" BorderWidth="3" BorderColor="#004040" ScrollBars="None">
            <table width="440px">
                <tr>
                    <td colspan="2" style="padding-top: 10px; color: Red; font-weight: bold;" align="center">
                        <asp:Label ID="lblMSgAlert" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="padding-top: 10px; padding-left: 20px; font-weight: bold;">1.Transfer fees charge
                    </td>
                    <td>
                        <asp:Label ID="lblTransferFees" runat="server"></asp:Label>
                    </td>
                </tr>
                 <tr>
                    <td style="padding-top: 10px; padding-left: 20px; font-weight: bold;">1.Renewal fees charge
                    </td>
                    <td>
                        <asp:Label ID="lblRenewalFees" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="padding-top: 10px; padding-left: 20px; font-weight: bold;">2. Late fees charge
                    </td>
                    <td>
                        <asp:Label ID="lbllateFees" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="padding-top: 10px; padding-left: 20px; font-weight: bold;">3. Re-establishment charge
                    </td>
                    <td>
                        <asp:Label ID="lblrestablishmentCharge" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="padding-top: 10px; padding-left: 20px; font-weight: bold;">3. Service Fees charge
                    </td>
                    <td>
                        <asp:Label ID="lblServiceFees" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="padding-top: 10px; padding-left: 20px; font-weight: bold;">Total amount :
                    </td>
                    <td>
                        <asp:Label ID="lblTotalAmount" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="padding-top: 20px;" align="center">
                        <asp:Button ID="Button1" runat="server" Text="Ok" OnClientClick="javascript:return(PopAcceptTrans());"
                            Width="100" CssClass="btn"  OnClick="Ok_Click"/>
                    </td>
                </tr>
            </table>
        </asp:Panel>
    </div>

    <div class="reveal-modal-bg" id="divPopOnSave" runat="server" style="display: none; width: 70%; position: absolute; padding-left: 30%; padding-top: 20%">
        <asp:Panel ID="Panel3" runat="server" BackColor="#FFFFFF" Height="150px" Width="440px"
            BorderStyle="Solid" BorderWidth="3" BorderColor="#004040" ScrollBars="None">
            <table width="440px">
                <tr>
                    <td colspan="2" style="padding-top: 10px; color: Red; font-weight: bold;" align="center">
                        <asp:Label ID="lblSaveAlert" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="padding-top: 20px;" align="center">
                        <asp:Button ID="Button3" runat="server" Text="Ok" OnClientClick="javascript:return(PopAcceptOnSave());"
                            Width="100" CssClass="btn"  OnClick="Ok_Click"/>
                    </td>
                </tr>
            </table>
        </asp:Panel>
    </div>
    <div class="reveal-modal-bg" id="divOTP" runat="server" style="display: none; width: 70%; position: absolute; padding-left: 30%; padding-top: 20%">
        <asp:Panel ID="Panel2" runat="server" BackColor="#FFFFFF" Height="220px" Width="440px"
            BorderStyle="Solid" BorderWidth="3" BorderColor="#004040" ScrollBars="None">
            <table width="440px">
                <tr >
                    <td colspan="2" style=" color: white; background-color:#34A0C0; font-weight: bold;" align ="left" >  
                            <asp:Label ID="lblMobilealert" runat="server" ForeColor ="white"  Text=""></asp:Label>           
                    </td>
                </tr>
                <tr>
                    <td style="padding-top: 10px; padding-left: 20px; font-weight: bold;" colspan ="2">Enter the verification code we have sent on this number
                    </td>                   
                </tr>
                <tr>
                    <td style="padding-top: 10px; padding-left: 20px; font-weight: bold;" colspan ="2">
                        <asp:TextBox ID="txtOTP" runat="server" MaxLength="6" Style="width: 200px; font-size: 10px;" CssClass="txtbox reqirerd"
                onblur="return checkAphabets(this);" onkeypress='javascript:tbx_fnInteger(event, this);' Height="20px"></asp:TextBox>   &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;   <asp:Button ID="Button2" runat="server" Text="Verify" OnClientClick="javascript:return(PopAcceptRenew());"
                            Width="100" CssClass="btn" OnClick="Button1_Click" />
                    </td>                
                </tr>
              <%--  <tr style ="visibility:hidden" >
                    <td style="padding-top: 10px; padding-left: 20px;" colspan ="2"> Didn't get the code yet? <asp:HyperLink ID="HyperLink2" runat="server" Font-Underline="True" ForeColor="#0066FF"> Request </asp:HyperLink> another one.
                    </td>                
                </tr>--%>
                <tr>
                    <td style="padding-top: 10px; padding-left: 20px; font-weight: bold;" colspan ="2">
                        <asp:HyperLink ID="HyperLink1" runat="server" Font-Underline="True" ForeColor="#0066FF" NavigateUrl="~/RegistrationLinkNew.aspx">Go Back</asp:HyperLink>  &nbsp;&nbsp;&nbsp;&nbsp; <asp:Label ID="lblOTPInvalid" runat="server" ForeColor ="Red"  Text=""></asp:Label>
                    </td>                   
                </tr>
                <tr>
                    <td style="padding-top: 10px; padding-left: 20px; " colspan ="2">if the mobile no being displayed on blue tape is wrong then <br /><asp:HyperLink ID="HyperLink2" runat="server" Font-Underline="True" ForeColor="#0066FF" NavigateUrl="~/frm_userupdateddetails.aspx">click here to update information</asp:HyperLink>  &nbsp;&nbsp;&nbsp;&nbsp; <asp:Label ID="Label1" runat="server" ForeColor ="Red"  Text=""></asp:Label></td>
                </tr>               
            </table>
        </asp:Panel>
    </div>
    <asp:HiddenField ID="HdnDate" runat="server" />
</asp:Content>
