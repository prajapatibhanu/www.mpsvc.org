<%@ Page Title="" Language="C#" MasterPageFile="~/AdminSection/MasterPage.master" EnableViewStateMac="false" AutoEventWireup="true" EnableEventValidation="false" CodeFile="frm_userupdateddetails.aspx.cs" Inherits="frm_userupdateddetails" %>

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

    <script type="text/javascript">

        function PopTemAndConditionRenew() {
            document.getElementById('<%=divRenewal.ClientID%>').style.display = "block";
            return false;
        }
        function PopAcceptRenew() {
            document.getElementById('<%=divRenewal.ClientID%>').style.display = "none";
            return true;
        }

        function MessageVerify() {
            alert("Application forwarded successfully.your information will be updated within 24 hours");
        }

        function CancelRegistration() {
            alert("Your Registration is cancelled, Please contact to mpsvc office");
        }

        function ValidationInitialization() {
            var msg = '';
            if (document.getElementById('<%=txtMobile.ClientID%>').value.trim() == "") {
                 msg = msg + "-First name can not be left blank \n";
             }
             if (document.getElementById('<%=txtEmailId.ClientID%>').value.trim() == "") {
                 msg = msg + "-Last name can not be left blank \n";
             }
             if (document.getElementById('<%=ddlIdentityType.ClientID%>').selectedIndex <= 0) {
                 msg = msg + "- Please select your identity \n";
             }
             if (document.getElementById('<%=txtIdentityNo.ClientID%>').value.trim() == "") {
                 msg = msg + "- Enter Identity No \n";
             }
             if (document.getElementById('<%=FileUpload1.ClientID%>').value.trim() == "") {
                 msg = msg + "-Identity proof can not be left blank \n";
             }
             if (document.getElementById('<%=txtPrefAdd.ClientID%>').value.trim() == "") {
                 msg = msg + "-Residential address can not be left blank \n";
             }
             if (document.getElementById('<%=txtPrefCity.ClientID%>').value.trim() == "") {
                 msg = msg + "-Residential city can not be left blank \n";
             }
             if (document.getElementById('<%=ddlPrefDistrict.ClientID%>').value.trim() == "") {
                 msg = msg + "-Please select residential district \n";
             }
             if (document.getElementById('<%=txtPrefPinCode.ClientID%>').value.trim() == "") {
                 msg = msg + "-Residential pincode can not be left blank \n";
             }
             if (document.getElementById('<%=ddlPrefState.ClientID%>').value == "Select") {
                 msg = msg + "-Please select residential state \n";
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
    </script>
    <table width="100%" cellpadding="0" cellspacing="0">
        <tr>
            <td colspan="4">
                <h2>
                    <strong>Details Update</strong></h2>
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
                <asp:TextBox ID="txtSearchRegistrationNo" runat="server" MaxLength="12"
                    CssClass="txtbox reqirerd"></asp:TextBox><span style="color: Red">*</span>
            </td>
            <td>
                <asp:Button ID="btnSearch" runat="server" CssClass="btn" Text="Search" OnClick="btnSearch_Click" />
            </td>
            <td></td>
        </tr>
        <tr>
            <td>Mobile No :
            </td>
            <td>
                <asp:TextBox ID="txtMobile" runat="server" MaxLength="10" CssClass="txtbox reqirerd"
                    onblur="return checkAphabets(this);" onkeypress='javascript:tbx_fnInteger(event, this);'></asp:TextBox><span style="color: Red">*</span>
            </td>
            <td>Email Id :
            </td>
            <td>
                <asp:TextBox ID="txtEmailId" runat="server" MaxLength="100" CssClass="txtbox reqirerd"></asp:TextBox><span style="color: Red">*</span>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1"
                    runat="server" ErrorMessage="Please Enter Valid Email ID" ControlToValidate="txtEmailId" ForeColor="Red" Display="Dynamic"
                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">
                </asp:RegularExpressionValidator>
            </td>
        </tr>

        <tr>
            <td>
                <h3 class="bluefnt">Preffered Address</h3>
            </td>
            <td></td>
            <td></td>
            <td></td>
        </tr>
        <tr>
            <td>Address :
            </td>
            <td>
                <asp:TextBox ID="txtPrefAdd" runat="server" MaxLength="200" CssClass="txtbox reqirerd"></asp:TextBox><span style="color: Red">*</span>
            </td>
            <td>City/Town/Village :
            </td>
            <td>
                <asp:TextBox ID="txtPrefCity" runat="server" MaxLength="50" onkeypress='javascript:tbx_fnAlphaOnly(event, this);'
                    CssClass="txtbox reqirerd"></asp:TextBox><span style="color: Red">*</span>
            </td>
        </tr>
        <tr>
            <td>Post :
            </td>
            <td>
                <asp:TextBox ID="txtPrefPost" runat="server" MaxLength="50" onkeypress='javascript:tbx_fnAlphaOnly(event, this);'
                    CssClass="txtbox reqirerd"></asp:TextBox>
            </td>
            <td>Block/Tehsil :
            </td>
            <td>
                <asp:TextBox ID="txtPrefTehsil" runat="server" MaxLength="50" onkeypress='javascript:tbx_fnAlphaOnly(event, this);'
                    CssClass="txtbox reqirerd"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>State :
            </td>
            <td>
                <asp:DropDownList ID="ddlPrefState" runat="server" CssClass="txtbox" OnSelectedIndexChanged="ddlPrefState_SelectedIndexChanged" AutoPostBack="True">
                </asp:DropDownList><span style="color: Red">*</span>
            </td>
            <td>District :
            </td>
            <td>
                <asp:DropDownList ID="ddlPrefDistrict" runat="server" CssClass="txtbox">
                </asp:DropDownList><span style="color: Red">*</span>
            </td>
        </tr>
        <tr>
            <td>Pin Code :
            </td>
            <td>
                <asp:TextBox ID="txtPrefPinCode" onblur="return checkAphabets(this);" runat="server"
                    MaxLength="6" onkeypress='javascript:tbx_fnInteger(event, this);' CssClass="txtbox reqirerd"></asp:TextBox><span style="color: Red">*</span>
            </td>
            <td></td>
            <td></td>
        </tr>

        <tr id="tr_idtype" runat="server">
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
            <td style="color: red;" colspan="4"> Note: Please upload Identity which will be used to identify your registration , file size should not be greater than 512 kb and file format should be jpeg,png,jpg,gif *</td>
        </tr>
        <tr id="tr_idProof" runat="server">
            <td>Identity Proof :
            </td>
            <td>
                <asp:FileUpload ID="FileUpload1" runat="server" onChange="UploadControlValidationForLenthAndFileFormat(100, 'JPEG*PNG*JPG*GIF', 'ctl00_ContentPlaceHolder1_FileUpload1'),ValidateFileSize(this)" /><span style="color: Red">*</span>
            </td>
            <td></td>
            <td></td>
        </tr>

        <tr>
            <td></td>
            <td>
                <asp:Button ID="btnUpdate" runat="server" Text="Submit" CssClass="btn" OnClick="btnUpdate_Click"
                    OnClientClick="return ValidationInitialization()" />
                 &nbsp;&nbsp;
                 <asp:Button ID="btnNotApprove" runat="server" Text="Not Approve" CssClass="btn" Visible ="false" OnClick="btnNotApprove_Click"  />
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
    <asp:HiddenField ID="hf_regno" runat="server" />
    <asp:HiddenField ID="hf_appno" runat="server" />
    <asp:HiddenField ID="hf_pAddress" runat="server" />
     <asp:HiddenField ID="HF_IsRedirect" runat="server" />
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
</asp:Content>

