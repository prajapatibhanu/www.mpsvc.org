<%@ Page Title="" Language="C#" MasterPageFile="~/AdminSection/AdminMaster.master" AutoEventWireup="true" CodeFile="FrmAdmin_InformationUpdation.aspx.cs" Inherits="AdminSection_FrmAdmin_InformationUpdation" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
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
          .auto-style1 {
              height: 48px;
          }
          .auto-style2 {
              height: 36px;
          }
          .auto-style3 {
              height: 41px;
          }
          .auto-style4 {
              height: 30px;
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
        function UploadControlValidationForLenthAndFileFormat(maxLengthFileName, validFileFormaString, that) {
            //ex---------------
            //maxLengthFileName=50;
            //validFileFormaString=JPG*JPEG*PDF*DOCX
            //uploadControlId=upSaveBill
            //ex---------------
            var msg = '';
            if (document.getElementById(that).value != '') {
                var size = document.getElementById(that);

                var fileName = document.getElementById(that).value;
                var lengthFileName = parseInt(document.getElementById(that).value.length)

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
                    document.getElementById(that).value = "";
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
            if (document.getElementById('<%=txtPerPinCode.ClientID%>').value.trim() == "") {
                msg = msg + "-Permanent Pincode can not be left blank \n";
            }
            if (document.getElementById('<%=ddlPerState.ClientID%>').value == "Select") {
                msg = msg + "-Permanent State can not be left blank \n";
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
            if (msg != '') {
                alert(msg);
                return false;
            }
            else {
                if (confirm("Do you really want to update with your login id ?")) {
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
            alert("User information Updated successfully");
        }
        function CancelRegistration() {
            alert("This Registration no. is cancelled, You can't update the information of this registration no.");
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
            <td colspan="4" class="auto-style4">
                <asp:Label ID="lblMsg" runat="server" Font-Bold="True" Font-Size="15pt"></asp:Label>
              
            </td>
        </tr>
        <tr>
            <td class="auto-style1">Registration No :
            </td>
            <td class="auto-style1">
                <asp:TextBox ID="txtRegNo" runat="server" MaxLength="12"
                    CssClass="txtbox reqirerd"></asp:TextBox><span style="color: Red">*</span>
            </td>
            <td class="auto-style1">
                <asp:Button ID="btnSearch" runat="server" CssClass="btn" Text="Search" OnClick="btnSearch_Click" />
            </td>
            <td class="auto-style1"></td>
        </tr>
        <tr>
            <td class="auto-style2">First Name :
            </td>
            <td class="auto-style2">
                <asp:TextBox ID="txtFName" runat="server" MaxLength="60" onkeypress='javascript:tbx_fnAlphaOnly(event, this);'
                    CssClass="txtbox reqirerd"></asp:TextBox><span style="color: Red">*</span>
            </td>
            <td class="auto-style2">Middle Name :
            </td>
            <td class="auto-style2">
                <asp:TextBox ID="txtMName" runat="server" onkeypress='javascript:tbx_fnAlphaOnly(event, this);'
                    MaxLength="60"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Last Name :
            </td>
            <td>
                <asp:TextBox ID="txtLastName" runat="server" MaxLength="60" onkeypress='javascript:tbx_fnAlphaOnly(event, this);'
                    CssClass="txtbox reqirerd"></asp:TextBox><span style="color: Red">*</span>
            </td>
            <td>Father Name :
            </td>
            <td>
                <asp:TextBox ID="txtFatherName" runat="server" MaxLength="200" onkeypress='javascript:tbx_fnAlphaOnly(event, this);'
                    CssClass="txtbox reqirerd"></asp:TextBox><span style="color: Red">*</span>
            </td>
        </tr>
        <tr>
            <td class="auto-style3">Date Of Birth :
            </td>
            <td class="auto-style3">
                <asp:TextBox ID="txtDOB" runat="server" onchange="checkDateFormat(this)" MaxLength="10"
                    CssClass="txtbox reqirerd"></asp:TextBox><span style="color: Red">*</span>
                &nbsp;<img id="imgDob" src="../images/calender.png" />
            </td>
            <td class="auto-style3">Gender :
            </td>
            <td class="auto-style3">
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
                </asp:DropDownList>
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
                Preferred Phone No :
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
            <td></td>
            <td>
                <asp:Button ID="btnUpdate" runat="server" Text="Update" CssClass="btn" OnClick="btnUpdate_Click"
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
        <asp:HiddenField ID="hdnFile" runat="server" />
        <asp:HiddenField ID="hf_regno" runat="server" />   
          <asp:HiddenField ID="HF_Ok" runat="server" />  
    </table>   

    <div class="reveal-modal-bg" id="divRenewal" runat="server" style="display: none; width: 70%; position: absolute; padding-left: 30%; padding-top: 20%">
        <asp:Panel ID="Panel1" runat="server" BackColor="#FFFFFF" Height="200px" Width="440px"
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
                onblur="return checkAphabets(this);" onkeypress='javascript:tbx_fnInteger(event, this);' Height="20px"></asp:TextBox>   &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;   <asp:Button ID="Button1" runat="server" Text="Verify" OnClientClick="javascript:return(PopAcceptRenew());"
                            Width="100" CssClass="btn" OnClick="Button1_Click" />
                    </td>                
                </tr>
              <%--  <tr style ="visibility:hidden" >
                    <td style="padding-top: 10px; padding-left: 20px;" colspan ="2"> Didn't get the code yet? <asp:HyperLink ID="HyperLink2" runat="server" Font-Underline="True" ForeColor="#0066FF"> Request </asp:HyperLink> another one.
                    </td>                
                </tr>--%>
                <tr>
                    <td style="padding-top: 10px; padding-left: 20px; font-weight: bold;" colspan ="2">
                        <asp:HyperLink ID="HyperLink1" runat="server" Font-Underline="True" ForeColor="#0066FF" NavigateUrl="~/AdminSection/ActionRegistration.aspx?Mt=New Registration">Go Back</asp:HyperLink>  &nbsp;&nbsp;&nbsp;&nbsp; <asp:Label ID="lblOTPInvalid" runat="server" ForeColor ="Red"  Text=""></asp:Label>
                    </td>                   
                </tr>
                <tr>
                    <td style="padding-top: 10px; padding-left: 20px; " colspan ="2">Contact MPSVC office if the number being displayed above is wrong</td>                 
                </tr>               
            </table>
        </asp:Panel>
    </div>
    <asp:HiddenField ID="HdnDate" runat="server" />
</asp:Content>

