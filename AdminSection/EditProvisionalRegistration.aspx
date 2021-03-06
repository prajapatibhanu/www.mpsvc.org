<%@ Page Title="" Language="C#" MasterPageFile="~/AdminSection/AdminMaster.master" AutoEventWireup="true" EnableEventValidation="false" CodeFile="EditProvisionalRegistration.aspx.cs" Inherits="AdminSection_EditProvisionalRegistration" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript" language="javascript">

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

             var msg = "";

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
                msg = msg + "-Permanent pincode can not be left blank \n";
            }
            if (document.getElementById('<%=ddlPerState.ClientID%>').value == "Select") {
                msg = msg + "-Please select permanent state \n";
            }
          <%--  if (document.getElementById('<%=txtPhoneNo.ClientID%>').value.trim() == "") {
                alert("Phone No can not be left blank");
                return false;
            }--%>
            if (document.getElementById('<%=txtMobileNo1.ClientID%>').value.trim() == "") {
                msg = msg + "-Mobile can not be left blank \n";
            }
            if (document.getElementById('<%=rbmobile2.ClientID%>').checked == true) {
                if (document.getElementById('<%=txtMobileNo2.ClientID%>').value.trim() == "") {
                    msg = msg + "Please enter mobile no2(If you are checked preferred mobile no2) \n";
                }
            }

            if (document.getElementById('<%=txtEmailId.ClientID%>').value.trim() == "") {
                msg = msg + "-Email id can not be left blank \n";
            }

            if (document.getElementById('<%=txtRollNo.ClientID%>').value.trim() == "") {
                msg = msg + "-Roll No can not be left blank \n";
            }
            if (document.getElementById('<%=txtUniversityEnrollNo.ClientID%>').value.trim() == "") {
                msg = msg + "-University Enrollment No can not be left blank \n";
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

        function PopTemAndCondition() {
            document.getElementById('<%=divProvision.ClientID%>').style.display = "block";
            return false;
        }
        function Accept() {
            document.getElementById('<%=divProvision.ClientID%>').style.display = "none";
        }
    </script>

    <script type="text/javascript" language="javascript">

        function MessageVerify(url) {

            alert("Verified successfully");
        }

        //ctl00_

        function openDiv(that) {
            var FileID = "";
            if (that.id == "ContentPlaceHolder1_lnkDomicile") {
                FileID = document.getElementById('<%=HF_DomicileCert.ClientID%>').value
                if (FileID == "") {
                    alert("Document not available.");
                    return false;
                }
            }
            if (that.id == "ContentPlaceHolder1_lnkPhoto") {
                FileID = document.getElementById('<%=HF_Photo.ClientID%>').value
                if (FileID == "") {
                    alert("Document not available");
                    return false;
                }
            }
            if (that.id == "ContentPlaceHolder1_lnkOtherCert") {
                FileID = document.getElementById('<%=HF_OtherCert.ClientID%>').value
                if (FileID == "") {
                    alert("Document not available");
                    return false;
                }
            }
            var path = "../Upload_Certificate/" + FileID;
            window.open(path, '_blank', 'addressbar=yes,resizable=yes,toolbar=no,status=no,menubar=no,location=center,scrollbars=yes,width=1000px,height=600px');
            return false;
        }

    </script>

    <table width="100%" cellpadding="0" cellspacing="0">
        <tr>
            <td colspan="4">
                <asp:Label ID="lblMsg" runat="server" Font-Bold="True" Font-Size="15pt"></asp:Label>
            </td>
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
                    CssClass="txtbox reqirerd"></asp:TextBox>
            </td>
            <td>Middle Name :
            </td>
            <td>
                <asp:TextBox ID="txtMName" runat="server" onkeypress='javascript:tbx_fnAlphaOnly(event, this);'
                    MaxLength="60"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Last Name :
            </td>
            <td>
                <asp:TextBox ID="txtLastName" runat="server" MaxLength="60" onkeypress='javascript:tbx_fnAlphaOnly(event, this);'
                    CssClass="txtbox reqirerd"></asp:TextBox>
            </td>
            <td>Father Name :
            </td>
            <td>
                <asp:TextBox ID="txtFatherName" runat="server" MaxLength="200" onkeypress='javascript:tbx_fnAlphaOnly(event, this);'
                    CssClass="txtbox reqirerd"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Date Of Birth :
            </td>
            <td>
                <asp:TextBox ID="txtDOB" runat="server" onchange="checkDateFormat(this)" MaxLength="10"
                    CssClass="txtbox reqirerd"></asp:TextBox>
                <img id="imgDob" src="../images/calender.png" />
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
                <asp:TextBox ID="txtResAdd" runat="server" MaxLength="200" CssClass="txtbox reqirerd"></asp:TextBox>
            </td>
            <td>City/Town/Village :
            </td>
            <td>
                <asp:TextBox ID="txtResCity" runat="server" MaxLength="50" onkeypress='javascript:tbx_fnAlphaOnly(event, this);'
                    CssClass="txtbox reqirerd"></asp:TextBox>
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
                </asp:DropDownList>
            </td>
            <td>District :
            </td>
            <td>
                <asp:DropDownList ID="ddlResDistrict" runat="server" CssClass="txtbox">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>Pin Code :
            </td>
            <td>
                <asp:TextBox ID="txtResPinCode" runat="server" MaxLength="6" onblur="return checkAphabets(this);"
                    onkeypress='javascript:tbx_fnInteger(event, this);' CssClass="txtbox reqirerd"></asp:TextBox>
            </td>
            <td></td>
            <td></td>
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
                <asp:TextBox ID="txtPerAdd" runat="server" MaxLength="200" CssClass="txtbox"></asp:TextBox>
            </td>
            <td>City/Town/Village :
            </td>
            <td>
                <asp:TextBox ID="txtPerCity" runat="server" MaxLength="50" onkeypress='javascript:tbx_fnAlphaOnly(event, this);'
                    CssClass="txtbox"></asp:TextBox>
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
                </asp:DropDownList>
            </td>
            <td>District :
            </td>
            <td>
                <asp:DropDownList ID="ddlPerDistrict" runat="server" CssClass="txtbox">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>Pin Code :
            </td>
            <td>
                <asp:TextBox ID="txtPerPinCode" runat="server" MaxLength="6" onblur="return checkAphabets(this);"
                    onkeypress='javascript:tbx_fnInteger(event, this);' CssClass="txtbox"></asp:TextBox>
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
            <td>Preffered Address :
            </td>
            <td>
                <asp:DropDownList ID="ddlPreffAddress" runat="server" CssClass="txtbox">
                    <asp:ListItem>Residential</asp:ListItem>
                    <asp:ListItem>Professional</asp:ListItem>
                    <asp:ListItem>Permanent</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td valign="middle">Mobile No. :                
            </td>
            <td>1. &nbsp;<asp:TextBox ID="txtMobileNo1" runat="server" MaxLength="10" Style="width: 65px; font-size: 10px;" CssClass="txtbox reqirerd"
                onblur="return checkAphabets(this);" onkeypress='javascript:tbx_fnInteger(event, this);'></asp:TextBox>
                &nbsp;&nbsp;&nbsp;
                2. &nbsp;
                <asp:TextBox ID="txtMobileNo2" runat="server" MaxLength="10" Style="width: 65px; font-size: 10px;" CssClass="txtbox reqirerd"
                    onblur="return checkAphabets(this);" onkeypress='javascript:tbx_fnInteger(event, this);'></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Email Id :
            </td>
            <td>
                <asp:TextBox ID="txtEmailId" runat="server" MaxLength="100" CssClass="txtbox reqirerd"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2"
                    runat="server" ErrorMessage="Please Enter Valid Email ID" ControlToValidate="txtEmailId" ForeColor="Red" Display="Dynamic"
                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">
                </asp:RegularExpressionValidator>
            </td>
            <td>Preffered Mobile No. :
            </td>
            <td>
                <asp:RadioButton ID="rbmobile1" Checked="true" GroupName="mobile" runat="server" Text="Mobile No. 1" />
                <asp:RadioButton ID="rbmobile2" runat="server" GroupName="mobile" Text="Mobile No. 2" />
            </td>
        </tr>

        <tr>
            <td style="height: 27px" colspan="4">
                <h3 class="bluefnt">Qualification</h3>
                &nbsp; &nbsp;
            </td>
        </tr>
        <tr>
            <td>Roll No :
            </td>
            <td>
                <asp:TextBox ID="txtRollNo" runat="server" MaxLength="15"></asp:TextBox><span style="color: Red">*</span>
            </td>
            <td>University Enrollment No :
            </td>
            <td>
                <asp:TextBox ID="txtUniversityEnrollNo" runat="server" MaxLength="15"></asp:TextBox><span style="color: Red">*</span>
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
                            <asp:DropDownList ID="ddl1" runat="server" Enabled="false" AutoPostBack="True" OnSelectedIndexChanged="ddl1_SelectedIndexChanged">
                            </asp:DropDownList><span style="color: Red">*</span>
                        </td>
                        <td style="width: 100px; height: 35px;">
                            <asp:DropDownList ID="ddlc1" runat="server">
                            </asp:DropDownList><span style="color: Red">*</span>
                        </td>
                        <td style="width: 100px; height: 35px;">
                            <asp:DropDownList ID="ddlY1" runat="server">
                            </asp:DropDownList>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>


        <tr>
            <td style="height: 27px" colspan="5">
                <h3 class="bluefnt">Uploaded Documents</h3>
                &nbsp; &nbsp;
            </td>
        </tr>
        <tr id="tr_New" runat="server">
            <td colspan="5">
                <table border="1" cellpadding="0" cellspacing="0" style="width: 100%">
                    <tr>
                        <td style="font-weight: bold; width: 50px; height: 30px">Sr No.
                        </td>
                        <td style="font-weight: bold; width: 100px; height: 30px">Document Title
                        </td>
                        <td style="font-weight: bold; width: 100px; height: 30px">View Documents
                        </td>
                        <td style="font-weight: bold; width: 100px; height: 30px">Approve
                        </td>
                        <td style="font-weight: bold; width: 50px; height: 30px">Edit
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 50px; height: 35px;">1.
                        </td>
                        <td style="width: 100px; height: 35px;">University certificate :
                        </td>
                        <td style="width: 100px; height: 35px;">
                            <asp:LinkButton ID="lnkDomicile" Style="color: #01BAF2;" runat="server" OnClientClick="return openDiv(this);">View Domicile Certificate</asp:LinkButton>
                        </td>
                        <td style="width: 100px; height: 35px;">
                            <asp:RadioButton ID="rbApprove" Text="Approve" runat="server" GroupName="Domicile"
                                Checked="true" />
                            <asp:RadioButton ID="rbDecline" runat="server" Text="Decline" GroupName="Domicile" />
                        </td>
                        <td style="width: 50px; height: 35px;">
                            <asp:FileUpload ID="FileUpload1" runat="server" onChange="UploadControlValidationForLenthAndFileFormat(100, 'PDF', 'ctl00_ContentPlaceHolder1_FileUpload1'),ValidateFileSize(this)" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 50px">2.
                        </td>
                        <td style="width: 100px">Photo:
                        </td>
                        <td style="width: 100px">
                            <asp:LinkButton ID="lnkPhoto" Style="color: #01BAF2;" runat="server" OnClientClick="return openDiv(this);">View Photo</asp:LinkButton>
                        </td>
                        <td style="width: 100px">
                            <asp:RadioButton ID="rbApprove2" Text="Approve" runat="server" GroupName="Photo"
                                Checked="true" />
                            <asp:RadioButton ID="rbDecline2" runat="server" Text="Decline" GroupName="Photo" />
                        </td>
                        <td style="width: 50px; height: 35px;">
                            <asp:FileUpload ID="FileUpload2" runat="server" onChange="UploadControlValidationForLenthAndFileFormat(100, 'JPEG*PNG*JPG', 'ctl00_ContentPlaceHolder1_FileUpload2'),ValidateFileSize(this)" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 50px">3.
                        </td>
                        <td style="width: 100px">Other
                        </td>
                        <td style="width: 100px">
                            <asp:LinkButton ID="lnkOtherCert" Style="color: #01BAF2;" runat="server" OnClientClick="return openDiv(this);">View Other Certificate</asp:LinkButton>
                        </td>
                        <td style="width: 100px">
                            <asp:RadioButton ID="rbApprove3" Text="Approve" runat="server" GroupName="Other"
                                Checked="true" />
                            <asp:RadioButton ID="rbDecline3" runat="server" Text="Decline" GroupName="Other" />
                        </td>
                        <td style="width: 50px; height: 35px;">
                            <asp:FileUpload ID="FileUpload3" runat="server" onChange="UploadControlValidationForLenthAndFileFormat(100, 'PDF', 'ctl00_ContentPlaceHolder1_FileUpload3'),ValidateFileSize(this)" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr id="tr_payment" runat="server">
            <td style="height: 27px" colspan="4">
                <h3 class="bluefnt">Payment</h3>
                &nbsp; &nbsp;
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
        <tr id="tr_cheque" runat="server">
            <td>Cheque/DD No :
            </td>
            <td>
                <asp:TextBox ID="txtcheque" runat="server" MaxLength="15" CssClass="txtbox"></asp:TextBox>
            </td>
            <td>Bank Name
            </td>
            <td>
                <asp:TextBox ID="txtbank" runat="server" MaxLength="50" CssClass="txtbox" onblur="return checkBankName(this);"></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="filtered1" runat="server" TargetControlID="txtbank" FilterType="LowercaseLetters, UppercaseLetters"></cc1:FilteredTextBoxExtender>
            </td>
        </tr>
        <tr id="tr_Pdate" runat="server">
            <td>Date :
            </td>
            <td>
                <asp:TextBox ID="txtPaymentDate" runat="server" onchange="checkDateFormat(this), CheckPastDate();"
                    MaxLength="15" CssClass="txtbox"></asp:TextBox>
                <img id="imgDob2" src="../images/calender.png" />
                <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtPaymentDate"
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
                <asp:Button ID="btnUpdate" runat="server" Text="Verify" CssClass="btn" OnClick="btnUpdate_Click"
                    OnClientClick="return ValidationInitialization();" />
                &nbsp;&nbsp;
                <asp:LinkButton ID="lnkdisApprove" runat="server" CssClass="btn" Text="Not Approve" OnClick="lnkdisApprove_Click"></asp:LinkButton>
                <%--<asp:Button ID="redirect" runat="server" Text="" Style="display: none;" OnClick="redirect_Click" />--%>
            </td>
            <td></td>
            <td></td>
        </tr>
    </table>
    <div class="reveal-modal-bg" id="divProvision" runat="server" style="display: none; width: 70%; position: absolute; padding-left: 30%; padding-top: 20%">
        <asp:Panel ID="Panel1" runat="server" BackColor="#FFFFFF" Height="140px" Width="440px"
            BorderStyle="Solid" BorderWidth="3" BorderColor="#004040" ScrollBars="None">
            <table width="440px">
                <tr>
                    <td colspan="2" style="padding-top: 10px; color: Red; font-weight: bold; font-size: 14px;"
                        align="center">
                        <asp:Label ID="lblMSgAlert" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="padding-top: 20px;" align="center">
                        <asp:Button ID="Ok" runat="server" Text="Ok" OnClientClick="javascript:return(Accept());"
                            Width="100" CssClass="btn" OnClick="Ok_Click" />
                    </td>
                </tr>
            </table>
        </asp:Panel>
    </div>

    <asp:HiddenField ID="HF_DomicileCert" runat="server" />
    <asp:HiddenField ID="HF_DegreeCert" runat="server" />
    <asp:HiddenField ID="HF_Photo" runat="server" />
    <asp:HiddenField ID="HF_OtherCert" runat="server" />
    <asp:HiddenField ID="HF_10thCert" runat="server" />
    <asp:HiddenField ID="HdnDate" runat="server" />
    <asp:HiddenField ID="HF_RegistationFees" runat="server" />
    <asp:HiddenField ID="HF_RenewalFees" runat="server" />
    <asp:HiddenField ID="HF_ServiceChagre" runat="server" />
    <asp:HiddenField ID="HF_LateFees" runat="server" />
    <asp:HiddenField ID="HF_ReEstabilishmentFees" runat="server" />
    <asp:HiddenField ID="HF_TotalAmount" runat="server" />
</asp:Content>

