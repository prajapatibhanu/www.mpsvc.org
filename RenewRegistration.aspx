<%@ Page Language="C#" MasterPageFile="~/AdminSection/MasterPage.master" AutoEventWireup="true"
    CodeFile="RenewRegistration.aspx.cs" Inherits="AdminSection_RenewRegistration"
    Title="Untitled Page" %>

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

      <%-- --%>
        .pd {
            kj padding-bottom:0;
        }

        .modal {
            display: none; /* Hidden by default */
            position: fixed; /* Stay in place */
            z-index: 1; /* Sit on top */
            padding-top: 100px; /* Location of the box */
            left: 0;
            top: 0;
            width: 100%; /* Full width */
            height: 100%; /* Full height */
            overflow: auto; /* Enable scroll if needed */
            background-color: rgb(0,0,0); /* Fallback color */
            background-color: rgba(0,0,0,0.4); /* Black w/ opacity */
        }

        /* Modal Content */
        .modal-content {
            background-color: #fefefe;
            margin: auto;
            padding: 20px;
            border: 1px solid #888;
            width: 30%;
            height: 30%;
        }

        /* The Close Button */
        .close {
            color: #aaaaaa;
            float: right;
            font-size: 28px;
            font-weight: bold;
        }

            .close:hover,
            .close:focus {
                color: #000;
                text-decoration: none;
                cursor: pointer;
            }

        .hid {
            display: none;
        }
    </style>
        <script type="text/javascript" language="javascript">
            $(document).ready(function () {
                $('#myBtn').click(function () {

                    modal.style.display = "none";
                });
            });
</script>
    <script type="text/javascript" language="javascript">

<%---    --%>
       function showpopup() {
            document.getElementById('<%=myModal.ClientID%>').style.display = "block";
       }

        var modal = document.getElementById("myModal");
        var fileb = document.getElementById("fil");
        var filebtn = document.getElementById("fie");

        // Get the button that opens the modal
        //var btn = document.getElementById("myBtn");

        // Get the <span> element that closes the modal
        var span = document.getElementsByClassName("close")[0];

        // When the user clicks the button, open the modal 
        //btn.onclick = function () {
        //    modal.style.display = "block";

        //}
        btnAcept.onclick = function () {

            fileb.style.display = "block";
            modal.style.display = "none";
            btn.style.display = "none";



        }
        btnCancel.onclick = function () {

            fileb.style.display = "none";
            modal.style.display = "none";
            btn.style.display = "block";



        }
        // When the user clicks on <span> (x), close the modal
        span.onclick = function () {
            modal.style.display = "none";
        }

        // When the user clicks anywhere outside of the modal, close it
        window.onclick = function (event) {
            if (event.target == modal) {
                modal.style.display = "none";
            }
        }



<%---    --%>
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
            else if (document.getElementById('<%=ddldept.ClientID%>').selectedIndex == 0) {
                msg = msg + "-Please select department \n";
            }
            if (document.getElementById('<%=ddldesig.ClientID%>').value.trim() == "") {
                msg = msg + "-Please select designation \n";
            }
            if (document.getElementById('<%=ddlPresentOcc.ClientID%>').value == "Select") {
                msg = msg + "-Please select Sector \n";
            }
            else if (document.getElementById('<%=ddldesig.ClientID%>').selectedIndex == 0) {
                msg = msg + "-Please select designation \n";
            }
            if (document.getElementById('<%=txtResAdd.ClientID%>').value.trim() == "") {
                msg = msg + "-Residential address can not be left blank \n";
            }
            if (document.getElementById('<%=txtResCity.ClientID%>').value.trim() == "") {
                msg = msg + "-Residential city can not be left blank \n";
            }
            if (document.getElementById('<%=ddlResDistrict.ClientID%>').value.trim() == "") {
                msg = msg + "-Residential district can not be left blank \n";
            }
            if (document.getElementById('<%=txtResPinCode.ClientID%>').value.trim() == "") {
                msg = msg + "-Residential pincode can not be left blank \n";
            }
            if (document.getElementById('<%=ddlResState.ClientID%>').value == "Select") {
                msg = msg + "-Please select residential state \n";
            }
            if (document.getElementById('<%=txtProAdd.ClientID%>').value.trim() == "") {
                msg = msg + "-Professional address can not be left blank \n";
            }
            if (document.getElementById('<%=txtProCity.ClientID%>').value.trim() == "") {
                msg = msg + "-Professional city can not be left blank \n";
            }
            if (document.getElementById('<%=ddlProDistrict.ClientID%>').value.trim() == "") {
                msg = msg + "-Professional District can not be left blank \n";
            }
            else if (document.getElementById('<%=ddlProDistrict.ClientID%>').selectedIndex == 0) {
                msg = msg + "-Please select professional district \n";
            }
            if (document.getElementById('<%=txtProPinCode.ClientID%>').value.trim() == "") {
                msg = msg + "-Professional PinCode can not be left blank \n";
            }
            if (document.getElementById('<%=ddlProState.ClientID%>').value == "Select") {
                msg = msg + "-Professional State can not be left blank \n";
            }
            if (document.getElementById('<%=txtPerAdd.ClientID%>').value.trim() == "") {
                msg = msg + "-Permanent address can not be left blank \n";
            }
            if (document.getElementById('<%=txtPerCity.ClientID%>').value.trim() == "") {
                msg = msg + "-Permanent city can not be left blank \n";
            }
            if (document.getElementById('<%=ddlPerDistrict.ClientID%>').value.trim() == "") {
                msg = msg + "-Permanent district can not be left blank \n";
            }
            else if (document.getElementById('<%=ddlPerDistrict.ClientID%>').selectedIndex == 0) {
                msg = msg + "-Please select permanent district \n";
            }
            if (document.getElementById('<%=txtPerPinCode.ClientID%>').value.trim() == "") {
                msg = msg + "-Permanent Pincode can not be left blank \n";
            }
            if (document.getElementById('<%=ddlPerState.ClientID%>').value == "Select") {
                msg = msg + "-Permanent State can not be left blank \n";
            }

            if (document.getElementById('<%=ddlPreffAddress.ClientID%>').value == "Select") {
                msg = msg + "-Please select Preffered Address \n";
            }
            <%--if (document.getElementById('<%=txtPhoneNo.ClientID%>').value.trim() == "") {
                alert("Phone No can not be left blank");
                return false;
            }--%>
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
            if (document.getElementById('<%=ddl1.ClientID%>').selectedIndex == 0) {
                msg = msg + "-Please select university \n";
            }
            if (document.getElementById('<%=ddlc1.ClientID%>').selectedIndex == 0) {
                msg = msg + "-Please select College \n";
            }
            if (document.getElementById('<%=ddlY1.ClientID%>').selectedIndex == 0) {
                msg = msg + "-Please select passing year \n";
            }
            <%-- if (document.getElementById('<%=ddl2.ClientID%>').selectedIndex == 0) {
                alert("Please select university");
                return false;
            }--%>
            <%-- Change Date : 01/05/2021
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
			--%>
            <%--if (document.getElementById('<%=FileUpload1.ClientID%>').value.trim() == "") {
                msg = msg + "-Domicile certificate can not be left blank \n";
            }
            if (document.getElementById('<%=FileUpload2.ClientID%>').value.trim() == "") {
                msg = msg + "-Graduation Degree / PDC Certificate can not be left blank \n";
            }--%>
            if (document.getElementById('<%=FileUpload3.ClientID%>').value.trim() == "") {
                msg = msg + "-Photo certificate can not be left blank \n";
            }
            <%-- if (document.getElementById('<%=FileUpload4.ClientID%>').value.trim() == "") {
                alert("Other can not be left blank");
                return false;
            }--%>
           <%-- if (document.getElementById('<%=txtDegreedate.ClientID%>').value.trim() == "") {
                msg = msg + "-Graduation Degree / PDC Date can not be left blank \n";
            }
            if (document.getElementById('<%=txtDegid.ClientID%>').value.trim() == "") {
                msg = msg + "-Degree id can not be left blank \n";
            }--%>
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


        function PopTemAndConditionRenew() {
            document.getElementById('<%=divRenewal.ClientID%>').style.display = "block";
            return false;
        }
        function PopAcceptRenew() {
            document.getElementById('<%=divRenewal.ClientID%>').style.display = "none";
            return true;
        }

        function PopOTPVerification() {
            document.getElementById('<%=divOTP.ClientID%>').style.display = "block";
            return false;
        }
        function PopOTPNotVerified() {
            document.getElementById('<%=divOTP.ClientID%>').style.display = "none";
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
                <h2><strong>
                    <asp:Label ID="lblHeader" runat="server" Font-Bold="True" Text="Renewal Registration" ForeColor="Black" Font-Size="15pt"></asp:Label>
                </strong></h2>
            </td>
        </tr>
        <tr>
            <td colspan="4">
                <asp:Label ID="lblMsg" runat="server" Font-Bold="True" Font-Size="15pt"></asp:Label>
                <asp:HiddenField ID="HF_Ok" runat="server" />
                <asp:HiddenField ID="hf_TotalAmount" runat="server" />

                <asp:HiddenField ID="HF_RegistationFees" runat="server" />
                <asp:HiddenField ID="HF_RenewalFees" runat="server" />
                <asp:HiddenField ID="HF_LateFees" runat="server" />
                <asp:HiddenField ID="HF_ReEstabilishmentFees" runat="server" />

            </td>
        </tr>
        <tr>
            <td>Registration No :
            </td>
            <td>
                <asp:TextBox ID="txtRegNo" runat="server" MaxLength="12"
                    CssClass="txtbox reqirerd"></asp:TextBox><span style="color: Red">*</span>
            </td>
            <td colspan="2">
                <span style="color: red; font-size: 14px;">* Step1. Enter Your Registration Number and Click on Search Button.</span>
            </td>

        </tr>
        <tr>
            <td></td>
            <td>
                <asp:Button ID="btnSearch" runat="server" CssClass="btn" Text="Search" OnClick="btnSearch_Click" /></td>
            <td></td>
            <td></td>
        </tr>

        <tr>
            <td colspan="4">
                <hr />
            </td>

        </tr>
    </table>
    <div id="FormControls" runat="server">
        <table width="100%" cellpadding="0" cellspacing="0">
            <tr>
                <td>
                    <br />
                </td>
                <td></td>
                <td></td>
                <td></td>
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
                        CssClass="txtbox reqirerd" Enabled="false"></asp:TextBox><span style="color: Red">*</span>
                    &nbsp;<img id="imgDob" src="images/calender.png" />
                </td>
                <td>Gender :
            </td>
                <td>
                    <asp:DropDownList ID="ddlGender" runat="server" CssClass="txtbox">
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
                    </asp:DropDownList><span style="color: Red">*</span>
                    <asp:TextBox ID="txtPresentOcc" runat="server" Visible="false"></asp:TextBox>
                </td>
                <td></td>
                <td></td>
            </tr>
            <tr>
                <td>
                    <h3 class="bluefnt">Residential Address</h3>
                </td>
                <td></td>
                <td></td>
                <td></td>
            </tr>
            <tr>
                <td>Address :
            </td>
                <td>
                    <asp:TextBox ID="txtResAdd" runat="server" MaxLength="200" CssClass="txtbox reqirerd"></asp:TextBox><span style="color: Red">*</span>
                </td>
                <td>City/Town/Village :
            </td>
                <td>
                    <asp:TextBox ID="txtResCity" runat="server" MaxLength="50" onkeypress='javascript:tbx_fnAlphaOnly(event, this);'
                        CssClass="txtbox reqirerd"></asp:TextBox><span style="color: Red">*</span>
                </td>
            </tr>
            <tr>
                <td>Post :
            </td>
                <td>
                    <asp:TextBox ID="txtResPost" runat="server" MaxLength="50" onkeypress='javascript:tbx_fnAlphaOnly(event, this);'
                        CssClass="txtbox reqirerd"></asp:TextBox>
                </td>
                <td>Block/Tehsil :
            </td>
                <td>
                    <asp:TextBox ID="txtResTehsil" runat="server" MaxLength="50" onkeypress='javascript:tbx_fnAlphaOnly(event, this);'
                        CssClass="txtbox reqirerd"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>State :
            </td>
                <td>
                    <asp:DropDownList ID="ddlResState" runat="server" CssClass="txtbox">
                        <asp:ListItem Selected="True" Text="Madhya Pradesh" Value="20"></asp:ListItem>
                    </asp:DropDownList><span style="color: Red">*</span>
                </td>
                <td>District :
            </td>
                <td>
                    <asp:DropDownList ID="ddlResDistrict" runat="server" CssClass="txtbox">
                    </asp:DropDownList><span style="color: Red">*</span>
                </td>
            </tr>
            <tr>
                <td>Pin Code :
            </td>
                <td>
                    <asp:TextBox ID="txtResPinCode" runat="server" MaxLength="6" onblur="return ValidPinNo('txtResPinCode');"
                        onkeypress='javascript:tbx_fnInteger(event, this);' CssClass="txtbox reqirerd"></asp:TextBox><span style="color: Red">*</span>
                </td>
                <td></td>
                <td></td>
                <%--<td>Town/Village :
            </td>
            <td>
                <asp:TextBox ID="txtResTown" runat="server" MaxLength="50" onkeypress='javascript:tbx_fnAlphaOnly(event, this);'
                    CssClass="txtbox reqirerd"></asp:TextBox>
            </td>--%>
            </tr>
            <tr>
                <td>
                    <h3 class="bluefnt">Professional Address</h3>
                </td>
                <td></td>
                <td></td>
                <td></td>
            </tr>
            <tr>
                <td>Address :
            </td>
                <td>
                    <asp:TextBox ID="txtProAdd" runat="server" MaxLength="200" CssClass="txtbox"></asp:TextBox><span style="color: Red">*</span>
                </td>
                <td>City/Town/Village :
            </td>
                <td>
                    <asp:TextBox ID="txtProCity" runat="server" MaxLength="50" onkeypress='javascript:tbx_fnAlphaOnly(event, this);'
                        CssClass="txtbox"></asp:TextBox><span style="color: Red">*</span>
                </td>
            </tr>
            <tr>
                <td>Post :
            </td>
                <td>
                    <asp:TextBox ID="txtProPost" runat="server" MaxLength="50" onkeypress='javascript:tbx_fnAlphaOnly(event, this);'
                        CssClass="txtbox reqirerd"></asp:TextBox>
                </td>
                <td>Block/Tehsil :
            </td>
                <td>
                    <asp:TextBox ID="txtProTehsil" runat="server" MaxLength="50" onkeypress='javascript:tbx_fnAlphaOnly(event, this);'
                        CssClass="txtbox reqirerd"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>State :
            </td>
                <td>
                    <asp:DropDownList ID="ddlProState" runat="server" CssClass="txtbox" AutoPostBack="true" OnSelectedIndexChanged="ddlProState_SelectedIndexChanged">
                    </asp:DropDownList><span style="color: Red">*</span>
                </td>
                <td>District :
            </td>
                <td>
                    <asp:DropDownList ID="ddlProDistrict" runat="server" CssClass="txtbox">
                    </asp:DropDownList><span style="color: Red">*</span>
                </td>
            </tr>
            <tr>

                <td>Pin Code :
            </td>
                <td>
                    <asp:TextBox ID="txtProPinCode" runat="server" MaxLength="6" onblur="return ValidPinNo('txtProPinCode');"
                        onkeypress='javascript:tbx_fnInteger(event, this);' CssClass="txtbox"></asp:TextBox><span style="color: Red">*</span>
                </td>
                <td></td>
                <td></td>
                <%--<td>Town/Village :
            </td>
            <td>
                <asp:TextBox ID="txtProTown" runat="server" MaxLength="50" onkeypress='javascript:tbx_fnAlphaOnly(event, this);'
                    CssClass="txtbox reqirerd"></asp:TextBox>
            </td>--%>
            </tr>
            <tr>
                <td>
                    <h3 class="bluefnt">Permanent Address</h3>
                </td>
                <td></td>
                <td></td>
                <td></td>
            </tr>
            <tr>
                <td>
                    <asp:CheckBox ID="chkPermanent" AutoPostBack="true" Text=" Same as  Residential Address "
                        runat="server" OnCheckedChanged="chkPermanent_CheckedChanged" />
                </td>
                <td></td>
                <td></td>
                <td></td>
            </tr>
            <tr>
                <td>Address :
            </td>
                <td>
                    <asp:TextBox ID="txtPerAdd" runat="server" MaxLength="200" CssClass="txtbox"></asp:TextBox><span style="color: Red">*</span>
                </td>
                <td>City/Town/Village :
            </td>
                <td>
                    <asp:TextBox ID="txtPerCity" runat="server" MaxLength="50" onkeypress='javascript:tbx_fnAlphaOnly(event, this);'
                        CssClass="txtbox"></asp:TextBox><span style="color: Red">*</span>
                </td>
            </tr>
            <tr>
                <td>Post :
            </td>
                <td>
                    <asp:TextBox ID="txtPerPost" runat="server" MaxLength="50" onkeypress='javascript:tbx_fnAlphaOnly(event, this);'
                        CssClass="txtbox reqirerd"></asp:TextBox>
                </td>
                <td>Block/Tehsil :
            </td>
                <td>
                    <asp:TextBox ID="txtPerTehsil" runat="server" MaxLength="50" onkeypress='javascript:tbx_fnAlphaOnly(event, this);'
                        CssClass="txtbox reqirerd"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>State :
            </td>
                <td>
                    <asp:DropDownList ID="ddlPerState" runat="server" CssClass="txtbox" AutoPostBack="true" OnSelectedIndexChanged="ddlPerState_SelectedIndexChanged">
                    </asp:DropDownList><span style="color: Red">*</span>
                </td>
                <td>District :
            </td>
                <td>
                    <asp:DropDownList ID="ddlPerDistrict" runat="server" CssClass="txtbox">
                    </asp:DropDownList><span style="color: Red">*</span>
                </td>
            </tr>
            <tr>
                <td>Pin Code :
            </td>
                <td>
                    <asp:TextBox ID="txtPerPinCode" runat="server" MaxLength="6" onblur="return ValidPinNo('txtPerPinCode');"
                        onkeypress='javascript:tbx_fnInteger(event, this);' CssClass="txtbox"></asp:TextBox><span style="color: Red">*</span>
                </td>
                <td></td>
                <td></td>
                <%--<td>Town/Village :
            </td>
            <td>
                <asp:TextBox ID="txtPerTown" runat="server" MaxLength="50" onkeypress='javascript:tbx_fnAlphaOnly(event, this);'
                    CssClass="txtbox reqirerd"></asp:TextBox>
            </td>--%>
            </tr>

            <tr>
                <td></td>
                <td>
                    <br />
                </td>
                <td></td>
                <td></td>
            </tr>

            <tr>
                <td>Preffered Address :
            </td>
                <td>
                    <asp:DropDownList ID="ddlPreffAddress" runat="server" CssClass="txtbox">
                        <asp:ListItem>Residential</asp:ListItem>
                        <asp:ListItem>Professional</asp:ListItem>
                        <asp:ListItem>Permanent</asp:ListItem>
                    </asp:DropDownList><span style="color: Red">*</span>
                </td>
                <td></td>
                <td></td>
            </tr>
            <%-- <tr>
            <td>
                Phone No :
            </td>
            <td>
                <asp:TextBox ID="txtPhoneNo" runat="server" MaxLength="7" CssClass="txtbox reqirerd"
                    onkeypress='javascript:tbx_fnInteger(event, this);'></asp:TextBox>
            </td>
            <td>
                Mobile No :
            </td>
            <td>
                <asp:TextBox ID="txtMobileNo" runat="server" MaxLength="10" CssClass="txtbox reqirerd"
                    onkeypress='javascript:tbx_fnInteger(event, this);'></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Fax No :
            </td>
            <td>
                <asp:TextBox ID="txtFaxNo" runat="server" MaxLength="15" CssClass="txtbox" onkeypress='javascript:tbx_fnInteger(event, this);'></asp:TextBox>
            </td>
            <td>
                Email Id :
            </td>
            <td>
                <asp:TextBox ID="txtEmailId" runat="server" MaxLength="100" CssClass="txtbox reqirerd"
                    onblur="return EmailValid();"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Preffered Phone No :
            </td>
            <td>
                <asp:TextBox ID="txtSTDcode" runat="server" MaxLength="4" Style="width: 30px; margin-left: -44px;"
                    onblur="return checkAphabets(this);" onkeypress='javascript:tbx_fnInteger(event, this);'></asp:TextBox>
                <asp:TextBox ID="txtPreffPhoneNo" runat="server" MaxLength="7" CssClass="txtbox"
                    onblur="return chkPreferedPhone(this);" onkeypress='javascript:tbx_fnInteger(event, this);'></asp:TextBox>
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>--%>

            <tr>
                <td>Land-Line No. :
            </td>
                <td>
                    <%--<asp:TextBox ID="txtPhoneNo" runat="server" MaxLength="7" CssClass="txtbox reqirerd"
                    onblur="return checkAphabets(this);" onkeypress='javascript:tbx_fnInteger(event, this);'></asp:TextBox>--%>

                    <asp:TextBox ID="txtSTDcode" runat="server" MaxLength="5" Style="width: 40px;"
                        onblur="return checkAphabets(this);" onkeypress='javascript:tbx_fnInteger(event, this);'></asp:TextBox>
                    <asp:TextBox ID="txtPreffPhoneNo" runat="server" MaxLength="7" CssClass="txtbox" Width="140"
                        onblur="return chkPreferedPhone(this);" onkeypress='javascript:tbx_fnInteger(event, this);'></asp:TextBox><span style="color: Red">*</span>
                </td>
                <td valign="middle">Mobile No. :                
            </td>
                <td>1. &nbsp;<asp:TextBox ID="txtMobileNo1" runat="server" MaxLength="10" Style="width: 65px; font-size: 10px;" CssClass="txtbox reqirerd"
                    onblur="return checkAphabets(this);" onkeypress='javascript:tbx_fnInteger(event, this);'></asp:TextBox><span style="color: Red">*</span>
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
                    <asp:TextBox ID="txtEmailId" runat="server" MaxLength="100" CssClass="txtbox reqirerd"></asp:TextBox><span style="color: Red">*</span>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2"
                        runat="server" ErrorMessage="Please Enter Valid Email ID" ControlToValidate="txtEmailId" ForeColor="Red" Display="Dynamic"
                        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">
                </asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td>Preffered Mobile No. :
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

            <tr id="tr_Qualification" runat="server">
                <td colspan="4">
                    <asp:Panel ID="pnl_Qualification" runat="server">
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
                                    <asp:DropDownList ID="ddl2" runat="server" Enabled="false" AutoPostBack="True" OnSelectedIndexChanged="ddl2_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </td>
                                <td style="width: 100px">
                                    <asp:DropDownList ID="ddlc2" Enabled="false" runat="server">
                                    </asp:DropDownList>
                                </td>
                                <td style="width: 100px">
                                    <asp:DropDownList ID="ddlY2" Enabled="false" runat="server">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 100px">PHD
                            </td>
                                <td style="width: 100px">
                                    <asp:DropDownList ID="ddl3" runat="server" Enabled="false" AutoPostBack="True" OnSelectedIndexChanged="ddl3_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </td>
                                <td style="width: 100px">
                                    <asp:DropDownList ID="ddlc3" Enabled="false" runat="server">
                                    </asp:DropDownList>
                                </td>
                                <td style="width: 100px">
                                    <asp:DropDownList ID="ddlY3" Enabled="false" runat="server">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 100px">Other
                            </td>
                                <td style="width: 100px">
                                    <asp:DropDownList ID="ddl4" runat="server" Enabled="false" AutoPostBack="True" OnSelectedIndexChanged="ddl4_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </td>
                                <td style="width: 100px">
                                    <asp:DropDownList ID="ddlc4" Enabled="false" runat="server">
                                    </asp:DropDownList>
                                </td>
                                <td style="width: 100px">
                                    <asp:DropDownList ID="ddlY4" Enabled="false" runat="server">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                </td>
            </tr>

            <tr id="Tr1" runat="server" visible="false">
                <td colspan="4"></td>
            </tr>
            <tr>
                <td style="color: red;" colspan="4">Note: Please upload photo which will be used for official purpose , file size should not be greater than 1024 kb and file format should be .jpeg/ .png/ .jpg/ .gif </td>
            </tr>
            <tr style="visibility: hidden">
                <td>Last Registration Id :
            </td>
                <td>
                    <asp:FileUpload ID="FileUpload1" runat="server" onChange="UploadControlValidationForLenthAndFileFormat(100, 'PDF', this),ValidateFileSize(this)" />
                </td>
                <td>Last registration certificate :
            </td>
                <td>
                    <asp:FileUpload ID="FileUpload2" runat="server" onChange="UploadControlValidationForLenthAndFileFormat(100, 'PDF', this),ValidateFileSize(this)" />
                </td>
            </tr>
            <tr>
                <td>Photo
            </td>
                <td>
                    <asp:FileUpload ID="FileUpload3" runat="server" CssClass="hid" onChange="UploadControlValidationForLenthAndFileFormat(100, 'JPEG*PNG*JPG*GIF', this),ValidateFileSize(this)" />
                    <span style="color: Red">*</span>
                    <asp:Button ID="myBtn" runat="server" Text="Showpopup" CssClass="btn btn-blue"/>
                </td>
                <td>Others :
            </td>
                <td>
                    <asp:FileUpload ID="FileUpload4" runat="server" onChange="UploadControlValidationForLenthAndFileFormat(100, 'PDF', this),ValidateFileSize(this)" />
                </td>
            </tr>
            <%--<tr>
            <td>10th Marksheet
            </td>
            <td>
                <asp:FileUpload ID="FileUpload5" runat="server" onChange="UploadControlValidationForLenthAndFileFormat(100, 'PDF', 'ctl00_ContentPlaceHolder1_FileUpload5'),ValidateFileSize(this)" />
            </td>
            <td></td>
        </tr>--%>
            <tr style="display: none;">
                <td>Graduation Degree /
               
                <br />
                    PDC Date :
            </td>
                <td>
                    <asp:TextBox ID="txtDegreedate" runat="server" onchange="checkDateFormat(this)"></asp:TextBox>
                    <img id="imgDob1" src="images/calender.png" /><span style="color: Red">*</span>
                    &nbsp;<cc1:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txtDegreedate"
                        Format="dd/MM/yyyy" PopupButtonID="imgDob1">
                    </cc1:CalendarExtender>
                    <cc1:CalendarExtender ID="CalendarExtender4" runat="server" TargetControlID="txtDegreedate"
                        Format="dd/MM/yyyy">
                    </cc1:CalendarExtender>
                </td>
                <td>Degree Id :
            </td>
                <td>
                    <asp:TextBox ID="txtDegid" runat="server"></asp:TextBox><span style="color: Red">*</span>
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
                    <asp:TextBox ID="lblAmount" runat="server" Enabled="false"></asp:TextBox>

                </td>


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
                        MaxLength="15" CssClass="txtbox"></asp:TextBox><span style="color: Red">*</span>
                    <img id="imgDob2" src="images/calender.png" />
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
            <asp:HiddenField ID="HF_ServiceChagre" runat="server" />
            <asp:HiddenField ID="hdnFile" runat="server" />
            <asp:HiddenField ID="hf_regno" runat="server" />
            <cc1:CalendarExtender ID="CetxtTenderSubDt" runat="server" TargetControlID="txtDOB"
                Format="dd/MM/yyyy" PopupButtonID="imgDob">
            </cc1:CalendarExtender>
        </table>


    </div>
    <div class="reveal-modal-bg" id="divRenewal" runat="server" style="display: none; width: 70%; position: absolute; padding-left: 30%; padding-top: 20%">
        <asp:Panel ID="Panel1" runat="server" BackColor="#FFFFFF" Height="300px" Width="440px"
            BorderStyle="Solid" BorderWidth="3" BorderColor="#004040" ScrollBars="None">
            <table width="440px">
                <tr>
                    <td colspan="2" style="padding-top: 10px; color: Red; font-weight: bold;" align="center">
                        <asp:Label ID="lblMSgAlert" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="padding-top: 10px; padding-left: 20px; font-weight: bold;">1.Renewal fees charge
                    </td>
                    <td>
                        <asp:Label ID="lblrenewalFees" runat="server">0.00</asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="padding-top: 10px; padding-left: 20px; font-weight: bold;">2.Service fees charge
                    </td>
                    <td>
                        <asp:Label ID="lblServiceCharge" runat="server">0.00</asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="padding-top: 10px; padding-left: 20px; font-weight: bold;">3. Late fees charge
                    </td>
                    <td>
                        <asp:Label ID="lbllateFees" runat="server">0.00</asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="padding-top: 10px; padding-left: 20px; font-weight: bold;">4. Re-establishment charge
                    </td>
                    <td>
                        <asp:Label ID="lblrestablishmentCharge" runat="server">0.00</asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="padding-top: 10px; padding-left: 20px; font-weight: bold;">Total amount :
                    </td>
                    <td>
                        <asp:Label ID="lblTotalAmount" runat="server">0.00</asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="padding-top: 20px;" align="center">
                        <asp:Button ID="Button1" runat="server" Text="Ok" OnClientClick="javascript:return(PopAcceptRenew());"
                            Width="100" CssClass="btn" OnClick="Button1_Click" />
                    </td>
                </tr>
            </table>
        </asp:Panel>
    </div>

    <div class="reveal-modal-bg" id="divOTP" runat="server" style="display: none; width: 70%; position: absolute; padding-left: 30%; padding-top: 20%">
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
                       
                        <asp:Button ID="btnVerify" runat="server" Text="Verify" OnClientClick="javascript:return(PopAcceptRenew());"
                            Width="100" CssClass="btn" OnClick="btnVerify_Click" />
                    </td>
                </tr>
                <tr>
                    <td style="padding-top: 10px; padding-left: 20px; font-weight: bold;" colspan="2">
                        <asp:HyperLink ID="HyperLink1" runat="server" Font-Underline="True" ForeColor="#0066FF" NavigateUrl="~/RegistrationLinkNew.aspx">Go Back</asp:HyperLink>
                        &nbsp;&nbsp;&nbsp;&nbsp;
                       
                        <asp:Label ID="lblOTPInvalid" runat="server" ForeColor="Red" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="padding-top: 10px; padding-left: 20px;" colspan="2">if the mobile no being displayed on blue tape is wrong then
                       
                        <br />
                        <asp:HyperLink ID="HyperLink2" runat="server" Font-Underline="True" ForeColor="#0066FF" NavigateUrl="~/frm_userupdateddetails.aspx">click here to update information</asp:HyperLink>
                        &nbsp;&nbsp;&nbsp;&nbsp;
                       
                        <asp:Label ID="Label1" runat="server" ForeColor="Red" Text=""></asp:Label></td>
                </tr>
            </table>
        </asp:Panel>
    </div>
    <%--- Start HERE--
         Add New Popup alert For upload Images---%>
    <div id="myModal" class="modal" runat="server">

        <!-- Modal content -->
        <div class="modal-content">
            <span class="close">&times;</span>
            <p>Some text in the Modal..</p>
            <%-- <button id="btnAcept" class="pd">Accept</button>--%>
            <asp:Button ID="btnAccept" runat="server" Text="Accept" CssClass="btn btn pd" OnClick="btnAccept_Click" />
            <button id="btnCancel" class="pd">Cancel</button>
        </div>

    </div>
    <%--- END HERE--
         Add New Popup alert For upload Images---%>
    <asp:HiddenField ID="HdnDate" runat="server" />
</asp:Content>
