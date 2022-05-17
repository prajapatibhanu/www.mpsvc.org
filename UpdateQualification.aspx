<%@ Page Title="" Language="C#" MasterPageFile="~/AdminSection/MasterPage.master" EnableViewStateMac="false" AutoEventWireup="true" CodeFile="UpdateQualification.aspx.cs" Inherits="UpdateQualification" EnableEventValidation="false"  %>

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
            background-image: url(~/images/Transparent_bg.gif);
            z-index: 1000;
            clear: both;
        }
    </style>

    <script type="text/javascript" language="javascript">
        function PopOTPVerification() {
            document.getElementById('<%=divRenewal.ClientID%>').style.display = "block";
            return false;
        }
        function PopOTPNotVerified() {
            document.getElementById('<%=divRenewal.ClientID%>').style.display = "none";
            return true;
        }

        function ValidateMobNumber(that) {
            var fld = document.getElementById(that.id);
            if (!(fld.value.length == 10)) {
                alert("The mobile no. is the wrong length. \nPlease enter 10 digit mobile no.");
                fld.value = "";
                fld.focus();
                return false;
            }

        }
        function MessageVerify() {
            alert("Application forwarded successfully");
        }

        function CancelRegistration() {
            alert("Your Registration is cancelled, Please contact to mpsvc office");
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
            if (uploadcontrol.files[0].size > 1024000) {
                alert('File size should not greater than 1024 kb.');
                document.getElementById(a.id).value = '';
                return false;
            }
            else {
                return true;
            }

        }
        function UploadControlValidationForLenthAndFileFormat(maxLengthFileName, validFileFormaString, that) {
            //ex---------------
            //maxLengthFileName=50;
            //validFileFormaString=JPG*JPEG*PDF*DOCX
            //uploadControlId=upSaveBill
            //ex---------------
            var msg = '';
            if (document.getElementById(that.id).value != '') {
                var size = document.getElementById(that.id);

                var fileName = document.getElementById(that.id).value;
                var lengthFileName = parseInt(document.getElementById(that.id).value.length)

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
                    document.getElementById(that.id).value = "";
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
            if (document.getElementById('<%=txtMobileNo1.ClientID%>').value.trim() == "") {
                msg = msg + "-Mobile no1 . can not be left blank \n";
            }
            if (document.getElementById('<%=rbmobile2.ClientID%>').checked == true) {
                if (document.getElementById('<%=txtMobileNo2.ClientID%>').value.trim() == "") {
                    msg = msg + "Please enter mobile no2(If you are checked preferred mobile no2) \n";
                }
            }
            if (document.getElementById('<%=txtEmailId.ClientID%>').value.trim() == "") {
                msg = msg + "-Email address can not be left blank \n";
            }
            if (document.getElementById('<%=ddl1.ClientID%>').selectedIndex == 0) {
                msg = msg + "-Please select university \n";
            }
            if (document.getElementById('<%=ddlc1.ClientID%>').selectedIndex == 0) {
                msg = msg + "-Please select College \n";
            }
            if (document.getElementById('<%=ddlY1.ClientID%>').selectedIndex == 0) {
                msg = msg + "-Please select passing year \n";
            }
            if (document.getElementById('<%=ddl2.ClientID%>').selectedIndex > 0) {
                if (document.getElementById('<%=ddlc2.ClientID%>').value != "") {
                    if (document.getElementById('<%=ddlc2.ClientID%>').selectedIndex <= 0) {
                        msg = msg + "-Please select College Selected University \n";
                    }
                }
                if (document.getElementById('<%=ddlY2.ClientID%>').selectedIndex <= 0) {
                    msg = msg + "-Please select passing year \n";
                }
            }

            if (document.getElementById('<%=ddl3.ClientID%>').selectedIndex > 0) {
                if (document.getElementById('<%=ddlc3.ClientID%>').value != "") {
                    if (document.getElementById('<%=ddlc3.ClientID%>').selectedIndex <= 0) {
                        msg = msg + "-Please select College Selected University \n";
                    }
                }
                if (document.getElementById('<%=ddlY3.ClientID%>').value.trim() <= 0) {
                    msg = msg + "-Please select passing year \n";
                }
            }

            if (document.getElementById('<%=ddl4.ClientID%>').selectedIndex > 0) {
                if (document.getElementById('<%=ddlc4.ClientID%>').value != "") {
                    if (document.getElementById('<%=ddlc4.ClientID%>').selectedIndex <= 0) {
                        msg = msg + "-Please select College Selected University \n";
                    }
                }
                if (document.getElementById('<%=ddlY4.ClientID%>').value.trim() <= 0) {
                    msg = msg + "-Please select passing year \n";
                }
            }


            if (document.getElementById('<%=ddlc2.ClientID%>').disabled == false && document.getElementById('<%=ddlc2.ClientID%>').selectedIndex > 0) {
                if (document.getElementById('<%=FileUpload1.ClientID%>').value == "") {
                    msg = msg + "-Please upload M.V.SC Certificate \n";
                }
            }
            else {
            }

            if (document.getElementById('<%=ddlc3.ClientID%>').disabled == false && document.getElementById('<%=ddlc3.ClientID%>').selectedIndex > 0) {
                if (document.getElementById('<%=FileUpload2.ClientID%>').value == "") {
                    msg = msg + "-Please upload PHD degree certificate \n";
                }
            }
            else {
            }


            if (document.getElementById('<%=ddlc4.ClientID%>').disabled == false && document.getElementById('<%=ddlc4.ClientID%>').selectedIndex > 0) {
                if (document.getElementById('<%=FileUpload4.ClientID%>').value == "") {
                    msg = msg + "-Please Upload Other Certificate \n";
                }
            }
            else {
            }

            if (document.getElementById('<%= rboffline.ClientID%>').checked == true) {
                if (document.getElementById('<%=txtcheque.ClientID%>').value.trim() == "") {
                    msg = msg + "-Cheque no. can not be left blank \n";
                }
            }
            else {
            }
            if (document.getElementById('<%= rboffline.ClientID%>').checked == true) {
                if (document.getElementById('<%=txtbank.ClientID%>').value.trim() == "") {
                    msg = msg + "-Bank name can not be left blank \n";
                }
            }
            else {
            }
            if (document.getElementById('<%= rboffline.ClientID%>').checked == true) {
                if (document.getElementById('<%=txtPaymentDate.ClientID%>').value.trim() == "") {
                    msg = msg + "-Payment date can not be left blank \n";
                }
            }
            else {
            }
            if (msg != '') {
                alert(msg);
                return false;
            }
            else {
                if (confirm("Do you really want to save??")) {
                    return true;
                }
                else {
                    return false;
                }
            }
        }
        function checkqualification() {

        }

    </script>

    <script type="text/javascript" language="javascript">
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

    </script>

    <script type="text/javascript" language="javascript">

        function checkBankName() {
            var bname = document.getElementById("txtBank").value;

            var e1 = bname.length;

            for (i = 0; i <= e1 - 1; i++) {
                var name = bname.charAt(i)
                if (name == 0 || name == 1 || name == 2 || name == 3 || name == 4 || name == 5 || name == 6 || name == 7 || name == 8 || name == 9) {
                    alert("Numbers are not allowed");
                    document.getElementById("txtBank").value = document.getElementById("txtBank").value.substring(0, i - 0);
                    return false;
                }
            }
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

        function PopTemAndConditionDuplicate() {
            document.getElementById('<%=divUpdateQualification.ClientID%>').style.display = "block";
            return false;
        }
        function PopAcceptDuplicate() {
            document.getElementById('<%=divUpdateQualification.ClientID%>').style.display = "none";
            return true;
        }

    </script>

    <table width="100%" cellpadding="0" cellspacing="0">
        <tr>
            <td colspan="4">
                <h2>
                    <strong>Update Qualification</strong></h2>
            </td>
        </tr>
        <tr>
            <td colspan="4">
                <asp:Label ID="lblMsg" runat="server" Font-Bold="True" Font-Size="15pt"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>Registration No :
            </td>
            <td>
                <asp:TextBox ID="txtSearchRegistrationNo" runat="server" MaxLength="12"
                    CssClass="txtbox reqirerd"></asp:TextBox><span style="color: Red">*</span>
            </td>
            <td>
                <asp:Button ID="btnSearch" runat="server" CssClass="btn" Text="Search" OnClick="btnSearch_Click" />
            </td>
            <td></td>
        </tr>
        <tr style="display: none;">
            <td>Registration No :
            </td>
            <td>
                <asp:TextBox ID="txtRegNo" runat="server" MaxLength="30" onkeypress='javascript:tbx_fnInteger(event, this);'
                    CssClass="txtbox reqirerd"></asp:TextBox>
            </td>
            <td>Registration Date :
            </td>
            <td>
                <asp:TextBox ID="txtRegDate" runat="server" MaxLength="10" CssClass="txtbox reqirerd"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>First Name :
            </td>
            <td>
                <asp:TextBox ID="txtFName" runat="server" MaxLength="60" onkeypress='javascript:tbx_fnAlphaOnly(event, this);'
                    CssClass="txtbox reqirerd" Enabled="false"></asp:TextBox><span style="color: Red">*</span>
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
                    CssClass="txtbox reqirerd" Enabled="false"></asp:TextBox><span style="color: Red">*</span>
            </td>
            <td>Father Name :
            </td>
            <td>
                <asp:TextBox ID="txtFatherName" runat="server" MaxLength="200" onkeypress='javascript:tbx_fnAlphaOnly(event, this);'
                    CssClass="txtbox reqirerd" Enabled="false"></asp:TextBox><span style="color: Red">*</span>
            </td>
        </tr>
        <tr>
            <td>Date Of Birth :
            </td>
            <td>
                <asp:TextBox ID="txtDOB" runat="server" onchange="checkDateFormat(this)" MaxLength="10"
                    CssClass="txtbox reqirerd" Enabled="false"></asp:TextBox>
                <img id="imgDob" src="images/calender.png" /><span style="color: Red">*</span>
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
                </asp:DropDownList><span style="color: Red">*</span>
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
                </asp:DropDownList><span style="color: Red">*</span>
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
                <asp:TextBox ID="txtPresentOcc" runat="server" Visible="false"></asp:TextBox>
            </td>
            <td></td>
            <td></td>
        </tr>

        <tr>
            <td>Preferred Address :
            </td>
            <td>
                <asp:DropDownList ID="ddlPreffAddress" runat="server" CssClass="txtbox">
                    <asp:ListItem>Residential</asp:ListItem>
                    <asp:ListItem>Professional</asp:ListItem>
                    <asp:ListItem>Permanent</asp:ListItem>
                </asp:DropDownList>
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
                <td valign="middle">Mobile No. :                
                </td>
                <td>1. &nbsp;<asp:TextBox ID="txtMobileNo1" runat="server" MaxLength="10" Style="width: 65px; font-size: 10px;" CssClass="txtbox reqirerd"
                    onblur="return checkAphabets(this),ValidateMobNumber(this);" onkeypress='javascript:tbx_fnInteger(event, this);'></asp:TextBox><span style="color: Red">*</span>
                    &nbsp;&nbsp;&nbsp;
                2. &nbsp;
                <asp:TextBox ID="txtMobileNo2" runat="server" MaxLength="10" Style="width: 65px; font-size: 10px;" CssClass="txtbox reqirerd"
                    onblur="return checkAphabets(this),ValidateMobNumber(this);" onkeypress='javascript:tbx_fnInteger(event, this);'></asp:TextBox>
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
                <asp:TextBox ID="txtEmailId" runat="server" MaxLength="100" CssClass="txtbox reqirerd"></asp:TextBox><span style="color: Red">*</span>
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

        <tr>
            <td style="height: 27px" colspan="4">
                <h3 class="bluefnt">Qualification</h3>
                &nbsp; &nbsp;
            </td>
        </tr>
        <tr>
            <td colspan="4">
                <table border="1" cellpadding="0" cellspacing="0" style="width: 100%">
                    <tr>
                        <td style="font-weight: bold; width: 100px; height: 30px">Degree Name
                        </td>
                        <td style="font-weight: bold; width: 100px; height: 30px">Name of University
                        </td>
                        <td style="font-weight: bold; width: 100px; height: 30px">Name of College
                        </td>
                        <td style="font-weight: bold; width: 100px; height: 30px">Passing Year
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100px; height: 35px;">B.V.SC.&amp; A.H.
                        </td>
                        <td style="width: 100px; height: 35px;">
                            <asp:DropDownList ID="ddl1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddl1_SelectedIndexChanged">
                            </asp:DropDownList><span style="color: Red">*</span>
                        </td>
                        <td style="width: 100px; height: 35px;">
                            <asp:DropDownList ID="ddlc1" runat="server">
                            </asp:DropDownList><span style="color: Red">*</span>
                        </td>
                        <td style="width: 100px; height: 35px;">
                            <asp:DropDownList ID="ddlY1" runat="server">
                            </asp:DropDownList><span style="color: Red">*</span>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100px">M.V.SC.
                        </td>
                        <td style="width: 100px">
                            <asp:DropDownList ID="ddl2" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddl2_SelectedIndexChanged">
                            </asp:DropDownList>
                        </td>
                        <td style="width: 100px">
                            <asp:DropDownList ID="ddlc2" runat="server">
                            </asp:DropDownList>
                        </td>
                        <td style="width: 100px">
                            <asp:DropDownList ID="ddlY2" runat="server">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100px">PHD
                        </td>
                        <td style="width: 100px">
                            <asp:DropDownList ID="ddl3" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddl3_SelectedIndexChanged">
                            </asp:DropDownList>
                        </td>
                        <td style="width: 100px">
                            <asp:DropDownList ID="ddlc3" runat="server">
                            </asp:DropDownList>
                        </td>
                        <td style="width: 100px">
                            <asp:DropDownList ID="ddlY3" runat="server">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100px">Other
                        </td>
                        <td style="width: 100px">
                            <asp:DropDownList ID="ddl4" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddl4_SelectedIndexChanged">
                            </asp:DropDownList>
                        </td>
                        <td style="width: 100px">
                            <asp:DropDownList ID="ddlc4" runat="server">
                            </asp:DropDownList>
                        </td>
                        <td style="width: 100px">
                            <asp:DropDownList ID="ddlY4" runat="server">
                            </asp:DropDownList>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td style="height: 27px" colspan="5">
                <h3 class="bluefnt">Upload Degree</h3>
                &nbsp; &nbsp;
            </td>
        </tr>
        <tr>
            <td style="color: red;" colspan="4">Note: Please upload photo which will be used for official purpose , file size should not be greater than 1024 kb and file format should be .pdf </td>

        </tr>
        <tr>
            <td>M.V.SC :
            </td>
            <td>
                <asp:FileUpload ID="FileUpload1" runat="server" onChange="UploadControlValidationForLenthAndFileFormat(100, 'PDF', this),ValidateFileSize(this)" />
                <span style="color: Red">*</span>
            </td>
            <td>PHD :
            </td>
            <td>
                <asp:FileUpload ID="FileUpload2" runat="server" onChange="UploadControlValidationForLenthAndFileFormat(100, 'PDF', this),ValidateFileSize(this)" />
                <span style="color: Red">*</span>
            </td>
        </tr>
        <tr>
            <td>Others :
            </td>
            <td>
                <asp:FileUpload ID="FileUpload4" runat="server" onChange="UploadControlValidationForLenthAndFileFormat(100, 'PDF', this),ValidateFileSize(this)" />
            </td>
        </tr>
        <tr>
            <td>Payment Type :
            </td>
            <td>
                <asp:RadioButton ID="rbOnline" runat="server" Text="Online Payment" onchange="IsOffline()"
                    GroupName="rbPayment" />
                <asp:RadioButton ID="rboffline" runat="server" Text="Offline Payment" onchange="IsOffline()"
                    Checked="true" GroupName="rbPayment" />
            </td>
            <td>Payable Amount :
            </td>
            <td>
                <asp:TextBox ID="lblAmount" runat="server" Text="10" Enabled="false"></asp:TextBox><span style="color: Red">*</span></td>
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
                <asp:TextBox ID="txtcheque" runat="server" MaxLength="15" CssClass="txtbox"></asp:TextBox><span style="color: Red">*</span>
            </td>
            <td>Bank Name
            </td>
            <td>
                <asp:TextBox ID="txtbank" runat="server" MaxLength="50" CssClass="txtbox"></asp:TextBox><span style="color: Red">*</span>
                <cc1:FilteredTextBoxExtender ID="filtered1" runat="server" TargetControlID="txtbank" FilterType="LowercaseLetters, UppercaseLetters"></cc1:FilteredTextBoxExtender>
            </td>
        </tr>
        <tr id="tr_Pdate" runat="server">
            <td>Payment Date :
            </td>
            <td>
                <asp:TextBox ID="txtPaymentDate" runat="server" onchange="checkDateFormat(this), CheckPastDate();"
                    MaxLength="15" CssClass="txtbox"></asp:TextBox>
                <img id="imgDob2" src="images/calender.png" /><span style="color: Red">*</span>
                <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtPaymentDate"
                    Format="dd/MM/yyyy">
                </cc1:CalendarExtender>
                <cc1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtPaymentDate"
                    Format="dd/MM/yyyy" PopupButtonID="imgDob2">
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
                    OnClientClick="return ValidationInitialization()" />
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
    </table>
    <asp:HiddenField ID="HF_ServiceChagre" runat="server" />
    <asp:HiddenField ID="hdnFile" runat="server" />
    <asp:HiddenField ID="hf_regno" runat="server" />
    <cc1:CalendarExtender ID="CetxtTenderSubDt" runat="server" TargetControlID="txtDOB"
        PopupButtonID="imgDob" Format="dd/MM/yyyy">
    </cc1:CalendarExtender>
    <cc1:CalendarExtender ID="CetxtDate" runat="server" TargetControlID="txtRegDate"
        Format="dd/MM/yyyy">
    </cc1:CalendarExtender>

    <div class="reveal-modal-bg" id="divUpdateQualification" runat="server" style="display: none; width: 70%; position: absolute; padding-left: 30%; padding-top: 20%">
        <asp:Panel ID="Panel1" runat="server" BackColor="#FFFFFF" Height="200px" Width="440px"
            BorderStyle="Solid" BorderWidth="3" BorderColor="#004040" ScrollBars="None">
            <table width="440px">
                <tr>
                    <td colspan="2" style="padding-top: 10px; color: Red; font-weight: bold;" align="center">
                        <asp:Label ID="lblMSgAlert" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="padding-top: 10px; padding-left: 20px; font-weight: bold;">1.Update qualification fees charge
                    </td>
                    <td>
                        <asp:Label ID="lblrenewalFees" runat="server" Text="Rs. 10"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="padding-top: 20px;" align="center">
                        <asp:Button ID="Button1" runat="server" Text="Ok" OnClientClick="javascript:return(PopAcceptDuplicate());"
                            Width="100" CssClass="btn" />
                    </td>
                </tr>
            </table>
        </asp:Panel>
    </div>

    <div class="reveal-modal-bg" id="divRenewal" runat="server" style="display: none; width: 70%; position: absolute; padding-left: 30%; padding-top: 20%">
        <asp:Panel ID="Panel2" runat="server" BackColor="#FFFFFF" Height="220px" Width="440px"
            BorderStyle="Solid" BorderWidth="3" BorderColor="#004040" ScrollBars="None">
            <table width="440px">
                <tr>
                    <td colspan="2" style="color: white; background-color: #34A0C0; font-weight: bold;" align="left">
                        <asp:Label ID="lblMobilealert" runat="server" ForeColor="white" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="padding-top: 10px; padding-left: 20px; font-weight: bold;" colspan="2">Enter the verification code we have sent on this number
                    </td>
                </tr>
                <tr>
                    <td style="padding-top: 10px; padding-left: 20px; font-weight: bold;" colspan="2">
                        <asp:TextBox ID="txtOTP" runat="server" MaxLength="6" Style="width: 200px; font-size: 10px;" CssClass="txtbox reqirerd"
                            onblur="return checkAphabets(this);" onkeypress='javascript:tbx_fnInteger(event, this);' Height="20px"></asp:TextBox>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;  
                        <asp:Button ID="Button2" runat="server" Text="Verify" OnClientClick="javascript:return(PopAcceptRenew());"
                            Width="100" CssClass="btn" OnClick="Button1_Click" />
                    </td>
                </tr>
                <%--  <tr style ="visibility:hidden" >
                    <td style="padding-top: 10px; padding-left: 20px;" colspan ="2"> Didn't get the code yet? <asp:HyperLink ID="HyperLink2" runat="server" Font-Underline="True" ForeColor="#0066FF"> Request </asp:HyperLink> another one.
                    </td>                
                </tr>--%>
                <tr>
                    <td style="padding-top: 10px; padding-left: 20px; font-weight: bold;" colspan="2">
                        <asp:HyperLink ID="HyperLink1" runat="server" Font-Underline="True" ForeColor="#0066FF" NavigateUrl="~/RegistrationLinkNew.aspx">Go Back</asp:HyperLink>
                        &nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label ID="lblOTPInvalid" runat="server" ForeColor="Red" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="padding-top: 10px; padding-left: 20px;" colspan="2">if the mobile no being displayed on blue tape is wrong then <br /><asp:HyperLink ID="HyperLink2" runat="server" Font-Underline="True" ForeColor="#0066FF" NavigateUrl="~/frm_userupdateddetails.aspx">click here to update information</asp:HyperLink>  &nbsp;&nbsp;&nbsp;&nbsp; <asp:Label ID="Label1" runat="server" ForeColor ="Red"  Text=""></asp:Label></td>
                </tr>
            </table>
        </asp:Panel>
    </div>
    <asp:HiddenField ID="HF_Ok" runat="server" />
    <%--<asp:HiddenField ID="hf_TotalAmount" runat="server" />--%>
    <asp:HiddenField ID="HiddenField1" runat="server" />
    <asp:HiddenField ID="HiddenField2" runat="server" />
    <asp:HiddenField ID="HiddenField3" runat="server" />
    <asp:HiddenField ID="HF_RegistationFees" runat="server" />
    <asp:HiddenField ID="HF_RenewalFees" runat="server" />
    <asp:HiddenField ID="HiddenField4" runat="server" />
    <asp:HiddenField ID="HF_LateFees" runat="server" />
    <asp:HiddenField ID="HF_ReEstabilishmentFees" runat="server" />
    <asp:HiddenField ID="HiddenField5" runat="server" />
    <asp:HiddenField ID="HF_Totalamount" runat="server" />
    <asp:HiddenField ID="HdnDate" runat="server" />
    <asp:HiddenField ID="HF_DomicileCert" runat="server" />
    <asp:HiddenField ID="HF_DegreeCert" runat="server" />
    <asp:HiddenField ID="HF_OtherCert" runat="server" />
</asp:Content>

