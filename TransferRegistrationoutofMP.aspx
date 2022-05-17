<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TransferRegistrationoutofMP.aspx.cs" Inherits="TransferRegistrationoutofMP" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta name="description" content="" />
    <meta name="author" content="" />
    <link rel="shortcut icon" href="../images/favicon.ico" type="image/x-icon" />
    <title>Madhya Pradesh State Veterinary Council</title>
    <link href="../../css/style.css" rel="stylesheet" type="text/css" />   
    <link href="../css/MyStyle.css" rel="stylesheet" type="text/css" />
    <link href="../css/daterangepicker.css" rel="stylesheet" />
    <link href="../css/bootstrap-datepicker.css" rel="stylesheet" />
    <link href="../css/jquery.datetimepicker.css" rel="stylesheet" />
    <link href="../css/bootstrap-timepicker.css" rel="stylesheet" />
    <link href="../css/StyleSheet.css" rel="stylesheet" /> 
    <link href="../css/jquery.treegrid.css" rel="stylesheet" />   
    <%--<script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.9.1/jquery.min.js"></script>
    <script type="text/javascript" src="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.2/js/bootstrap.min.js"></script>
    <link rel="stylesheet" href="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.2/css/bootstrap.min.css" />--%>
    <script src="poplink/POPUPMODAL1jquery.min.js"></script>
    <link href="poplink/POPMODAL3bootstrap.min.css" rel="stylesheet" />
    <script src="poplink/POPMODAL2bootstrap.min.js"></script>
    <script type="text/javascript">
     
        function validateNum(evt) {
            evt = (evt) ? evt : window.event;
            var charCode = (evt.which) ? evt.which : evt.keyCode;
            if (charCode > 31 && (charCode < 48 || charCode > 57) && charCode != 46) {
                return false;
            }
            return true;

        }

        function PopTemAndConditionOnSave() {
            document.getElementById('<%=divPopOnSave.ClientID%>').style.display = "block";
            return false;
        }
        function PopOTPVerification() {
            document.getElementById('<%=divOTP.ClientID%>').style.display = "block";
            return false;
        }
        function PopOTPNotVerified() {
            document.getElementById('<%=divOTP.ClientID%>').style.display = "none";
            return true;
        }

        function PopTemAndConditionTrans() {
            document.getElementById('<%=divRenewal.ClientID%>').style.display = "block";
            return false;
        }
        function PopAcceptTrans() {
            document.getElementById('<%=divRenewal.ClientID%>').style.display = "none";
            return true;
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
        function MessageVerify() {
            alert("Application forwarded successfully");
        }
        function CancelRegistration() {
            alert("Your Registration is cancelled, Please contact to mpsvc office");
        }
        <%-- function IsOffline() {
            if (document.getElementById('<%=rboffline.ClientID%>').checked == true) {
                document.getElementById('<%=payment.ClientID%>').style.visibility = "visible";
                document.getElementById('<%=chequeDD.ClientID%>').style.visibility = "visible";            
                document.getElementById('<%=BranchName.ClientID%>').style.visibility = "visible";
               

            } else {
                document.getElementById('<%=payment.ClientID%>').style.visibility = "hidden";
                document.getElementById('<%=chequeDD.ClientID%>').style.visibility = "hidden";               
                document.getElementById('<%=BranchName.ClientID%>').style.visibility = "hidden";
             
               
               
            }--%>
        //}

    </script>

    <style>
        strong {
            color: #01baf2;
        }

        label {
            font-size: 14px;
        }

        .reason {
            width: 600px;
            height: 40px;
            padding-right: 90px;
            margin-left: 80px;
        }

        .customCSS td {
            padding: 0px !important;
        }

        .customCSS label {
            padding-left: 10px;
        }

        /*table {
            white-space: nowrap;
        }*/

        .capitalize {
            text-transform: capitalize;
        }

        ul.ui-autocomplete.ui-menu.ui-widget.ui-widget-content.ui-corner-all {
            height: 197px !important;
            overflow-y: scroll !important;
            width: 520px !important;
        }

        .NonPrintable {
            display: none;
        }

        * .header {
            display: table-header-group;
        }
        /*table 
			{
				display: block;
				overflow-x: auto;
				white-space: nowrap;
			}*/
        @media print {
            .NonPrintable {
                display: block;
            }

            .noprint {
                display: none;
            }
        }

        .printtd {
            font-weight: bold;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">

        <div class="top-bar" id="changeFont">
        </div>
        <div class="wrapper" id="wrapper">
            <a href="index.aspx" class="noprint">
                <img style="width: 100%;" src="images/header.jpg" />
            </a>
            <div class="CL">
            </div>
            <div class="menu noprint">
                <ul>
                    <li class="active"><a href="index.aspx" title="Home">Home</a></li>
                    <li><a href="NewRegistration.aspx" title="About Us">Registration</a> </li>
                    <li>
                        <a href="UserApplicationStatus.aspx">Check Your Status</a>
                    </li>
                </ul>
                <div class="CL">
                </div>
            </div>
            <div class="MT10 noprint">
                <!-- Breadcrumb Example Here -->
                <div id="breadcrumb">
                    <ul class="crumbs">
                        <li><a href="../AdminSection/ActionRegistration.aspx" class="first">Home</a></li>
                       
                        <li></li>
                    </ul>
                </div>
            </div>
            <div class="MT20 noprint" style="min-height: 500px;">
                <td class="MT20">
                    <asp:ScriptManager ID="ScriptManager1" runat="server">
                    </asp:ScriptManager>
                </td>
                <table style="width: 100%" cellpadding="0" cellspacing="0">
                    <tr>
                        <td colspan="4">
                            <h3><strong>Transfer Registration/ Out Of M.P</strong></h3>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4">
                            <asp:Label ID="lblMsg" runat="server" Font-Bold="true" Font-Size="15pt"></asp:Label>
                        </td>
                    </tr>
                </table>
                <table style="width: 101%">
                    <tr id="trReg" runat="server">
                        <td>
                            <label>Registration No.<span style="color: red"><b> *</b></span></label>
                        </td>
                        <td colspan="2">
                            <asp:TextBox ID="txtRegNo" AutoComplete="off" runat="server" Style="margin-left: 46px"></asp:TextBox>
                            <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btn btn-primary" OnClick="btnSearch_Click" />
                        </td>
                        <td colspan="2">
                            <span style="color: red; font-size: 14px;">* Step1. Enter Your Registration Number and Click on Search Button.</span>
                        </td>
                    </tr>

                </table>
                <div id="hidefrom" runat="server">
                    <table width="101%" cellpadding="0" cellspacing="0">
                        <tr>
                            <td colspan="3">
                                <span style="color: red; font-size: 14px;">* Step2. Please Read All Information Carefully And Then Forword To Next Step.</span>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <label>First Name:<span style="color: red"><b> *</b></span></label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtApplicant" runat="server" MaxLength="60" AutoComplete="off" placeholder="Applicant Name"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvApplicant" runat="server" ControlToValidate="txtApplicant" ValidationGroup="Save" ForeColor="Red" Font-Bold="true" Font-Size="Small" ErrorMessage="Mandatory Field"></asp:RequiredFieldValidator>
                            </td>
                            <td>
                                <label>Middle Name:</label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtMiddleName" runat="server" MaxLength="60" AutoComplete="off" placeholder="Applicant Name"></asp:TextBox>
                                <%--<asp:RequiredFieldValidator ID="rfvMiddlename" runat="server" ControlToValidate="txtMiddleName" ValidationGroup="Save" ForeColor="Red" Font-Bold="true" Font-Size="Small" ErrorMessage="Mandatory Field"></asp:RequiredFieldValidator>--%>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <label>Last Name:</label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtLastname" runat="server" MaxLength="60" AutoComplete="off"></asp:TextBox>
                            </td>
                            <td>
                                <label>Father/Husband Name:<span style="color: red"><b> *</b></span></label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtFHname" runat="server" onkeypress="return lettersOnly(event)" AutoComplete="off" placeholder="Father/Husband Name" MaxLength="60"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RFVFhnmae" runat="server" ValidationGroup="Save" ControlToValidate="txtFHname" ErrorMessage="Mandatory Field" ForeColor="Red" Font-Bold="true" Font-Size="Small"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <label>Date Of Birth:<span style="color: red"><b> *</b></span></label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtDOBb" data-date-format="dd/mm/yyyy" AutoComplete="off" data-provide="datepicker" data-date-autoclose="true" runat="server" CssClass="form-control"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvDOB" runat="server" ValidationGroup="Save" ControlToValidate="txtDOBb" ErrorMessage="Mandatory Field" ForeColor="Red" Font-Bold="true" Font-Size="Small"></asp:RequiredFieldValidator>
                            </td>

                            <td>
                                <label>Gender:<span style="color: red"><b> *</b></span></label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlgender" runat="server">
                                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                                    <asp:ListItem Value="Male">Male</asp:ListItem>
                                    <asp:ListItem Value="Female">Female</asp:ListItem>
                                    <asp:ListItem Value="Transgender">Transgender</asp:ListItem>
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="rfvender" runat="server" ValidationGroup="Save" ControlToValidate="ddlgender" ErrorMessage="Mandatory Field" ForeColor="Red" Font-Bold="true" InitialValue="0" Font-Size="Small"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <h4 class="strong">
                                    <strong>Details of recognized Veterinary Qualification :-</strong>
                                </h4>
                            </td>
                        </tr>
                        <tr>
                            <%-- <td>
                            <label>Degree Name:<span style="color: red"><b> *</b></span></label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtDegree" onkeypress="return lettersOnly(event)" placeholder="Degree" runat="server" AutoComplete="off"></asp:TextBox>
                             <asp:RequiredFieldValidator ID="rfvDegree" runat="server" ValidationGroup="Save" ControlToValidate="txtDegree" ErrorMessage="Mandatory Field" ForeColor="Red" Font-Bold="true" Font-Size="Small"></asp:RequiredFieldValidator>
                        </td>--%>
                            <td>
                                <label>Organization :<span style="color: red"><b> *</b></span></label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlorg" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlorg_SelectedIndexChanged1">
                                </asp:DropDownList>
                                <asp:TextBox ID="txtOrg" runat="server" Visible="false"></asp:TextBox>
                            </td>

                            <td>
                                <label>Department :<span style="color: red"><b> *</b></span></label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddldept" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddldept_SelectedIndexChanged">
                                </asp:DropDownList>
                                <asp:TextBox ID="txtDept" runat="server" Visible="false"></asp:TextBox>
                            </td>
                        </tr>

                        <tr>

                            <td></td>
                            <td></td>
                        </tr>
                        <tr>
                            <td>
                                <label>Designation :<span style="color: red"><b> *</b></span></label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddldesig" runat="server" CssClass="txtbox" AutoPostBack="True" OnSelectedIndexChanged="ddldesig_SelectedIndexChanged">
                                </asp:DropDownList>
                                <asp:TextBox ID="txtDesig" runat="server" Visible="false"></asp:TextBox>
                            </td>

                            <td>
                                <label>Sector :<span style="color: red"><b> *</b></span></label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlPresentOcc" runat="server" AutoPostBack="true" CssClass="txtbox"
                                    OnSelectedIndexChanged="ddlPresentOcc_SelectedIndexChanged">
                                </asp:DropDownList>
                                <asp:TextBox ID="txtPresentOcc" runat="server" Visible="false"></asp:TextBox>
                            </td>
                        </tr>

                        <tr>
                            <td colspan="2">
                                <h4><strong>Residential Address:-</strong></h4>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <label>Address :<span style="color: red"><b> *</b></span></label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtResAdd" runat="server" MaxLength="200" CssClass=""></asp:TextBox>
                            </td>
                            <td>
                                <label>City :<span style="color: red"><b> *</b></span></label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtResCity" runat="server" MaxLength="50" onkeypress='javascript:tbx_fnAlphaOnly(event, this);' CssClass="txtbox reqirerd"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <label>Post :</label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtRessPost" runat="server"></asp:TextBox>
                            </td>
                            <td>
                                <label>Tehsil :</label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtRessTehsil" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <label>State :<span style="color: red"><b> *</b></span></label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlRestate" runat="server" CssClass="txtbox"
                                    OnInit="ddlRestate_Init">
                                </asp:DropDownList>
                            </td>
                            <td>
                                <label>District : <span style="color: red"><b>*</b></span></label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtResDistrict" runat="server" MaxLength="50" onkeypress='javascript:tbx_fnAlphaOnly(event, this);' CssClass="txtbox reqirerd"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <label>Pin Code :<span style="color: red"><b> *</b></span></label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtResPinCode" runat="server" MaxLength="6" onblur="return ValidPinNo('txtResPinCode');" onkeypress='javascript:tbx_fnInteger(event, this);' CssClass="txtbox reqirerd"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <h4><strong>Professional Address:-</strong></h4>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <label>Address :<span style="color: red"> <b>*</b></span></label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtProAdd" runat="server" MaxLength="200" CssClass="txtbox"></asp:TextBox>
                            </td>
                            <td>
                                <label>City :<span style="color: red"> <b>*</b></span></label>
                            </td>

                            <td>
                                <asp:TextBox ID="txtProCity" runat="server" MaxLength="50" onkeypress='javascript:tbx_fnAlphaOnly(event, this);' CssClass="txtbox"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <label>Post :</label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtProPost" runat="server"></asp:TextBox>
                            </td>
                            <td>
                                <label>Tehsil :</label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtProTehsil" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <label>State :<span style="color: red"> <b>*</b></span></label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlproState" runat="server" CssClass="txtbox"
                                    OnInit="ddlproState_Init">
                                </asp:DropDownList>
                            </td>
                            <td>
                                <label>District :<span style="color: red"> <b>*</b></span></label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtProDistrict" runat="server" MaxLength="50" onkeypress='javascript:tbx_fnAlphaOnly(event, this);' CssClass="txtbox"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <label>Pin Code :<span style="color: red"> <b>*</b></span></label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtProPinCode" runat="server" MaxLength="6" onblur="return ValidPinNo('txtProPinCode');" onkeypress='javascript:tbx_fnInteger(event, this);' CssClass="txtbox"></asp:TextBox>
                            </td>
                        </tr>
                        <%--  </table>
                <table width="101%" cellpadding="0" cellspacing="0">--%>
                        <tr>
                            <td colspan="2">
                                <h4><strong>Permanent Address:-</strong> </h4>
                            </td>
                            <td></td>
                            <td></td>
                            <td></td>
                        </tr>
                        <tr>
                            <td>
                                <label>address :<span style="color: red"><b> *</b></span></label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtPerAdd" runat="server" MaxLength="200" CssClass="txtbox"></asp:TextBox>
                            </td>
                            <td>
                                <label>City :<span style="color: red"><b> *</b></span></label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtPerCity" runat="server" MaxLength="50" onkeypress='javascript:tbx_fnAlphaOnly(event, this);' CssClass="txtbox"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <label>Post :</label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtPerPost" runat="server"></asp:TextBox>
                            </td>
                            <td>
                                <label>Tehsil :</label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtPerTehsil" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <label>State :<span style="color: red"><b> *</b></span></label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlPerState" runat="server" CssClass="txtbox"
                                    OnInit="ddlPerState_Init">
                                </asp:DropDownList>
                            </td>
                            <td>
                                <label>District :<span style="color: red"><b> *</b></span></label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtPerDistrict" runat="server" MaxLength="200" onkeypress='javascript:tbx_fnAlphaOnly(event, this);'
                                    CssClass="txtbox"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                        </tr>
                        <tr>
                            <td>
                                <label>Pin Code :<span style="color: red"><b> *</b></span></label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtPerPinCode" runat="server" MaxLength="6" onblur="return ValidPinNo('txtPerPinCode');" onkeypress='javascript:tbx_fnInteger(event, this);' CssClass="txtbox"></asp:TextBox>
                            </td>
                            <td>
                                <label>Email:<span style="color: red"><b> *</b></span></label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtEmailID" placeholder="Email" runat="server" MaxLength="30" AutoComplete="off"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ValidationGroup="Save" ControlToValidate="txtEmailID" ErrorMessage="Mandatory Field" ForeColor="Red" Font-Bold="true" Font-Size="Small"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="revtxtEmailID" runat="server" ForeColor="Red" Font-Bold="true" ControlToValidate="txtEmailID" ErrorMessage="Enter Valid Email-Id" ValidationExpression="^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3}))$"></asp:RegularExpressionValidator>
                            </td>
                            <td></td>
                        </tr>
                        <%--  </table>
           <table width="101%" cellpadding="0" cellspacing="0">--%>
                        <tr>
                            <%--<td>
                 <label>Preffered Address :<span style="color:red"><b> *</b></span></label>
            </td>
            <td>
                
                <asp:DropDownList ID="ddlPreffAddress" runat="server"  CssClass="txtbox">
                    <asp:ListItem>Residential</asp:ListItem>
                    <asp:ListItem>Professional</asp:ListItem>
                    <asp:ListItem >Permanent</asp:ListItem>
                </asp:DropDownList>
                
            </td>--%>
                        </tr>
                        <tr>
                            <td>
                                <label>Mobile No:<span style="color: red"><b> *</b></span></label>
                            </td>
                            <td>&nbsp;<asp:TextBox ID="txtMobileno" placeholder="Mobile no" runat="server" MaxLength="10" onkeypress="return validateNum(event)" AutoComplete="off"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvmobile" runat="server" ValidationGroup="Save" ControlToValidate="txtMobileno" ErrorMessage="Mandatory Field" ForeColor="Red" Font-Bold="true" Font-Size="Small"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="revtxtMobileNo" runat="server" ControlToValidate="txtMobileno" Font-Bold="true" ForeColor="Red" ValidationExpression="^[6-9][0-9]{9}$" ErrorMessage="Enter Valid Mobile No"></asp:RegularExpressionValidator>
                            </td>
                            <td>
                                <label>Alternate Mobile No:</label>
                            </td>
                            <td>&nbsp;<asp:TextBox ID="txtmobileother" placeholder="Mobile no" runat="server" MaxLength="10" onkeypress="return validateNum(event)" AutoComplete="off"></asp:TextBox>
                                <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ValidationGroup="Save" ControlToValidate="txtMobileno" ErrorMessage="Mandatory Field" ForeColor="Red" Font-Bold="true" Font-Size="Small"></asp:RequiredFieldValidator>--%>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtMobileno" Font-Bold="true" ForeColor="Red" ValidationExpression="^[6-9][0-9]{9}$" ErrorMessage="Enter Valid Mobile No"></asp:RegularExpressionValidator>
                            </td>
                            <%-- <td>
                            <label>Email:<span style="color: red"><b> *</b></span></label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtEmailID" placeholder="Email" runat="server" MaxLength="30" AutoComplete="off"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ValidationGroup="Save" ControlToValidate="txtEmailID" ErrorMessage="Mandatory Field" ForeColor="Red" Font-Bold="true" Font-Size="Small"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="revtxtEmailID" runat="server" ForeColor="Red" Font-Bold="true" ControlToValidate="txtEmailID" ErrorMessage="Enter Valid Email-Id" ValidationExpression="^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3}))$"></asp:RegularExpressionValidator>
                        </td>--%>
                        </tr>
                        <tr>
                            <td>Preferred Mobile No. :
                            </td>
                            <td>
                                <asp:RadioButton ID="rbmobile1" Checked="true" GroupName="mobile" runat="server" Text="Mobile No. 1" />
                                <asp:RadioButton ID="rbmobile2" runat="server" GroupName="mobile" Text="Mobile No. 2" />
                            </td>

                            <td>
                                <label>Preffered Address :<span style="color: red"><b> *</b></span></label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlPreffAddress" runat="server" CssClass="txtbox">
                                    <asp:ListItem>Select</asp:ListItem>
                                    <asp:ListItem>Residential</asp:ListItem>
                                    <asp:ListItem>Professional</asp:ListItem>
                                    <asp:ListItem>Permanent</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        &nbsp; &nbsp;                       
                      <tr>
                          <td colspan="2">
                              <h4>
                                  <strong>Details of Registration
                                     and Transfer applied :-</strong>
                              </h4>
                          </td>
                      </tr>
                        <tr>
                            <td>
                                <label>
                                    Name of the State Veterinary<br />
                                    Council
                                wherein,candidate is<br />
                                    presently registered:<span style="color: red"><b> *</b></span></label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtNameofsvp" Text="Madhya Pradesh State Veterinary Council" ReadOnly="true" runat="server" onkeypress="return lettersOnly(event)" AutoComplete="off"></asp:TextBox>
                                <%--<asp:RequiredFieldValidator ID="rfvnameofSvp" runat="server" ValidationGroup="Save" ControlToValidate="txtNameofsvp" ErrorMessage="Mandatory Field" ForeColor="Red" Font-Bold="true" Font-Size="Small"></asp:RequiredFieldValidator>--%>
                            </td>
                            <td>
                                <label>Validity of Registration:<span style="color: red"><b> *</b></span></label>
                            </td>
                            <td>
                                <%--<asp:TextBox ID="txtValidity" data-date-format="dd/mm/yyyy" data-date-autoclose="true" data-provide="datepicker" runat="server" AutoComplete="off"></asp:TextBox>--%>
                                <asp:TextBox ID="txtValidity" runat="server" AutoComplete="off" ReadOnly="true"></asp:TextBox>
                                <%--<asp:RequiredFieldValidator ID="rfvvalidity" runat="server" ValidationGroup="Save" ControlToValidate="txtValidity" ErrorMessage="Mandatory Field" ForeColor="Red" Font-Bold="true" Font-Size="Small"></asp:RequiredFieldValidator>--%>
                            </td>

                        </tr>
                        <tr>
                            <td>
                                <label>
                                    Name of the State Veterinary Council<br />
                                    wherein, the transfer of registration is applied:<span style="color: red"><b> *</b></span></label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlState" runat="server"></asp:DropDownList>
                                <%--<asp:RequiredFieldValidator ID="rfvState" runat="server" ValidationGroup="Save" ControlToValidate="ddlState" ErrorMessage="Mandatory Field" ForeColor="Red" Font-Bold="true" Font-Size="Small"></asp:RequiredFieldValidator>--%>
                            </td>
                            <td id="regno" runat="server">
                                <label>
                                    State Veterinary Council<br />
                                    Registration Number:<span style="color: red"><b> *</b></span></label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtReginumber" placeholder="Registration Number" MaxLength="30" runat="server" AutoComplete="off"></asp:TextBox>
                                <%--<asp:RequiredFieldValidator ID="rfvRegister" runat="server" ValidationGroup="Save" ControlToValidate="txtReginumber" ErrorMessage="Mandatory Field" ForeColor="Red" Font-Bold="true" Font-Size="Small"></asp:RequiredFieldValidator>--%>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <h4>
                                    <strong class="strong">Payment details (Demand /draft) of
                                   
                                    transfer
                                    Fee of Rs 15 in desired Transfer State :-</strong>
                                </h4>
                            </td>
                        </tr>
                        <tr>
                            <%--<td>
                            <label>Payment Type :<span style="color:red"><b> *</b></span></label> 
                         </td>--%>
                            <td>
                                <%--<asp:RadioButton ID="rbOnline"  runat="server" Text="Online Payment" onchange="IsOffline()"
                                GroupName="rbPayment" />--%>&nbsp
                            <asp:RadioButton ID="rboffline" runat="server" Visible="false" Text="Offline Payment" onchange="IsOffline()"
                                Checked="true" GroupName="rbPayment" />
                            </td>
                        </tr>
                        <tr id="chequeDD" runat="server">
                            <td>
                                <label>Demand Draft No:<span style="color: red"><b> *</b></span></label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtDDno" placeholder="DD No" runat="server" onkeypress="return validateNum(event)" AutoComplete="off"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvDDNO" runat="server" ValidationGroup="Save" ControlToValidate="txtDDno" ErrorMessage="Mandatory Field" ForeColor="Red" Font-Bold="true" Font-Size="Small"></asp:RequiredFieldValidator>
                            </td>

                            <td>
                                <label>Drawn in the name of(DD):<span style="color: red"><b> *</b></span> </label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtDrwan" onkeypress="return lettersOnly(event)" placeholder="Drawn in the name of(DD)" runat="server" AutoComplete="off"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvDrawn" runat="server" ValidationGroup="Save" ControlToValidate="txtDrwan" ErrorMessage="Mandatory Field" ForeColor="Red" Font-Bold="true" Font-Size="Small"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr id="payment" runat="server">
                            <td>
                                <label>Payment Date:<span style="color: red"><b> *</b></span></label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtdate" data-provide="datepicker" data-date-format="dd/mm/yyyy" data-date-autoclose="true" AutoComplete="off" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvdate" runat="server" ValidationGroup="Save" ControlToValidate="txtdate" ErrorMessage="Mandatory Field" ForeColor="Red" Font-Bold="true" Font-Size="Small"></asp:RequiredFieldValidator>
                            </td>
                            <td>
                                <label>Name of issuing Bank:<span style="color: red"><b> *</b></span></label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtBank" placeholder="Bank Name" runat="server" onkeypress="return lettersOnly(event)" AutoComplete="off"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvBank" runat="server" ValidationGroup="Save" ControlToValidate="txtBank" ErrorMessage="Mandatory Field" ForeColor="Red" Font-Bold="true" Font-Size="Small"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr id="BranchName" runat="server">
                            <td>
                                <label>Branch Name:<span style="color: red"><b> *</b></span></label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtBranch" placeholder="Branch Name" onkeypress="return lettersOnly(event)" runat="server" AutoComplete="off"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvBranch" runat="server" ValidationGroup="Save" ControlToValidate="txtBranch" ErrorMessage="Mandatory Field" ForeColor="Red" Font-Bold="true" Font-Size="Small"></asp:RequiredFieldValidator>
                            </td>

                            <td>
                                <label>DD in original<span style="color: red"><b> *</b></span></label>
                            </td>
                            <td>
                                <asp:FileUpload ID="filUploadDD" onChange="UploadControlValidationForLenthAndFileFormat(100, 'PDF', this),ValidateFileSize(this)" Width="200px" runat="server" />
                                <asp:RequiredFieldValidator ID="rfvfilUploadDD" runat="server" ControlToValidate="filUploadDD" ValidationGroup="Save" ForeColor="Red" Font-Bold="true" Font-Size="Small" ErrorMessage="Mandatory Field"></asp:RequiredFieldValidator>
                                <asp:HyperLink ID="HyperlinkDD" Target="_blank" runat="server" Style="margin-left: -3%" CssClass="label label-primary" Text="ViewDemaondDraft"></asp:HyperLink>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <h4>
                                    <strong>Reason for seeking transfer
                                    of registration:-</strong>
                                </h4>
                            </td>
                        </tr>
                    </table>
                    <table>
                        <tr>
                            <td>
                                <label>Reason for Transfer Registration:<span style="color: red"><b> *</b></span></label>
                            </td>

                            <td>
                                <asp:TextBox ID="txtreason" CssClass="reason" placeholder="Reason for transfer of registration" onkeypress="return lettersOnly(event)" TextMode="MultiLine" runat="server" AutoComplete="off" Style="margin-right: 210px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvReason" runat="server" Style="margin-left: -185px" ValidationGroup="Save" ControlToValidate="txtreason" ErrorMessage="Mandatory Field" ForeColor="Red" Font-Bold="true" Font-Size="Small"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <%-- <tr>
                        <td>
                            <h4>
                                <strong>List of documents enclosed :-</strong>
                            </h4>
                        </td>
                    </tr>--%>
                    </table>
                    <table style="width: 99%">
                        <tr>
                            <td colspan="2">
                                <h4><strong>Qualification:-</strong></h4>
                                &nbsp; &nbsp;</td>
                        </tr>
                        <tr>
                            <td colspan="4">
                                <table border="1" cellpadding="0" cellspacing="0" style="width: 100%">
                                    <tr>
                                        <td style="font-weight: bold; width: 100px; height: 30px">Degree Name</td>
                                        <td style="font-weight: bold; width: 100px; height: 30px">Name of University</td>
                                        <td style="font-weight: bold; width: 100px; height: 30px">Name of Collage
                                        </td>
                                        <td style="font-weight: bold; width: 100px; height: 30px">Passing Year
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 100px; height: 35px;">B.V.SC.&amp; A.H.</td>
                                        <td style="width: 100px; height: 35px;">
                                            <asp:DropDownList ID="ddlUniversity" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlUniversity_SelectedIndexChanged"></asp:DropDownList>
                                            <span style="color: red"><b>*</b></span>
                                        </td>
                                        <td style="width: 100px; height: 35px;">
                                            <asp:DropDownList ID="ddlCollege" runat="server">
                                            </asp:DropDownList><span style="color: red"><b> *</b></span></td>
                                        <td style="width: 100px; height: 35px;">
                                            <asp:DropDownList ID="ddlY1" runat="server">
                                            </asp:DropDownList>
                                            <span style="color: red"><b>*</b></span></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 100px">M.V.SC.</td>
                                        <td style="width: 100px">
                                            <asp:DropDownList ID="ddluniversity2" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddluniversity2_SelectedIndexChanged"></asp:DropDownList></td>
                                        <td style="width: 100px">
                                            <asp:DropDownList ID="ddlcollege2" runat="server">
                                            </asp:DropDownList></td>
                                        <td style="width: 100px">
                                            <asp:DropDownList ID="ddlY2" runat="server">
                                            </asp:DropDownList></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 100px">PHD</td>
                                        <td style="width: 100px">
                                            <asp:DropDownList ID="ddluniversity3" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddluniversity3_SelectedIndexChanged"></asp:DropDownList>

                                        </td>
                                        <td style="width: 100px">
                                            <asp:DropDownList ID="ddlcollege3" runat="server">
                                            </asp:DropDownList></td>
                                        <td style="width: 100px">
                                            <asp:DropDownList ID="ddlY3" runat="server">
                                            </asp:DropDownList></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 100px">Other</td>
                                        <td style="width: 100px">
                                            <asp:DropDownList ID="ddluniversity4" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddluniversity4_SelectedIndexChanged"></asp:DropDownList>

                                        </td>
                                        <td style="width: 100px">
                                            <asp:DropDownList ID="ddlcollege4" runat="server">
                                            </asp:DropDownList></td>
                                        <td style="width: 100px">
                                            <asp:DropDownList ID="ddlY4" runat="server">
                                            </asp:DropDownList></td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <h4>
                                    <strong>List of documents enclosed :-</strong>
                                </h4>
                            </td>
                        </tr>
                    </table>
                    <table>
                        <%--<tr>
            <td style="color: red;" colspan="4">Note: Please upload photo which will be used for official purpose , file size should not be greater than 1024 kb and file format should be jpeg,png,jpg,gif *</td>
           </tr>--%>
                        <tr class="row">
                            <td class="col-md-3">
                                <label>Photo:<span style="color: red"><b> * <br />(Passport size photo (3x4 cm))</b></span></label>
                            </td>
                            <td class="col-md-3" id="filimage" runat="server">
                                <asp:FileUpload ID="filUploadImg" onChange="UploadControlValidationForLenthAndFileFormat(100, 'JPEG*PNG*JPG*GIF', this),ValidateFileSize(this)" Style="margin-left: 50px" AllowMultiple="true" runat="server" />
                                <%-- <asp:RequiredFieldValidator ID="rfvfilUploadImg" Style="margin-left: 50px" runat="server" ControlToValidate="filUploadImg" ValidationGroup="Save" ForeColor="Red" Font-Bold="true" Font-Size="Small" ErrorMessage="Mandatory Filed"></asp:RequiredFieldValidator>--%>
                                <asp:HyperLink ID="hyperliinkImage" Target="_blank" Style="margin-left: 50px" CssClass="label label-primary" runat="server" Text="ViewIMG"></asp:HyperLink>
                            </td>
                            <td class="col-md-3">
                                <label>Domicile Ceritficate :</label>
                            </td>
                            <td class="col-md-3">
                                <asp:FileUpload ID="filUploadDomicile" onChange="UploadControlValidationForLenthAndFileFormat(100, 'PDF', this),ValidateFileSize(this)" runat="server" />
                                <asp:HyperLink ID="hyperLinkDomicile" runat="server" Target="_blank" Text="ViewDomicile" CssClass="label label-primary"></asp:HyperLink>
                            </td>

                            <%-- <asp:HyperLink ID="hyperlinkDD" runat="server" Target="_blank" CssClass="label label-primary" Text="ViewDD" ></asp:HyperLink>--%>
                        </tr>
                        <tr class="row">
                            <td class="col-md-3">
                                <label>
                                    Date of Birth
                                        <br />
                                    (Aadhar / Passport / Marksheet / DL/SSLC):<span style="color: red"><b> *</b></span></label>
                            </td>
                            <td class="col-md-3">
                                <asp:FileUpload ID="filUploadBirthproof" onChange="UploadControlValidationForLenthAndFileFormat(100, 'PDF', this),ValidateFileSize(this)" Style="margin-left: 50px" runat="server" />
                                <%--<asp:RequiredFieldValidator ID="rfvfilUploadBirthproof" Style="margin-left: 50px" runat="server" ControlToValidate="filUploadBirthproof" ValidationGroup="Save" ForeColor="Red" Font-Bold="true" Font-Size="Small" ErrorMessage="Mandatory Filed"></asp:RequiredFieldValidator>--%>
                                <asp:HyperLink ID="hyperlinkBirth" Style="margin-left: 50px" runat="server" Target="_blank" CssClass="label label-primary" Text="ViewBirthCertificate"></asp:HyperLink>
                            </td>
                            <td class="col-md-3">
                                <label>
                                    Degree certificate<br />
                                    (BVSc&AH/MVSc/ PhD/ Other)<span style="color: red"><b> *</b></span></label>
                            </td>
                            <td class="col-md-3">
                                <asp:FileUpload ID="filUploadDegree" onChange="UploadControlValidationForLenthAndFileFormat(100, 'PDF', this),ValidateFileSize(this)" runat="server" />
                                <%--<asp:RequiredFieldValidator ID="rfvfilUploadDegree" runat="server" ControlToValidate="filUploadDegree" ValidationGroup="Save" ForeColor="Red" Font-Bold="true" Font-Size="Small" ErrorMessage="Mandatory Filed"></asp:RequiredFieldValidator>--%>
                                <asp:HyperLink ID="hyperlinkDegree" runat="server" Target="_blank" CssClass="label label-primary" Text="ViewDegree"></asp:HyperLink>
                            </td>
                        </tr>
                        <tr class="row">
                            <td class="col-md-3">
                                <label>
                                    Copy of the State Veterinary Council<br />
                                    Registration Certificate:<span style="color: red"><b> *</b></span></label>
                            </td>
                            <td class="col-md-3">
                                <asp:FileUpload ID="filUploadRegisCert" onChange="UploadControlValidationForLenthAndFileFormat(100, 'PDF', this),ValidateFileSize(this)" Style="margin-left: 50px" runat="server" />
                                <asp:RequiredFieldValidator ID="rfvfilUploadRegisCert" Style="margin-left: 64%" runat="server" ControlToValidate="filUploadRegisCert" ValidationGroup="Save" ForeColor="Red" Font-Bold="true" Font-Size="Small" ErrorMessage="Mandatory Field"></asp:RequiredFieldValidator>
                                <asp:HyperLink ID="hyperlinkRegicert" Target="_blank" Style="margin-left: -80%" runat="server" CssClass="label label-primary" Text="ViewRegistrationCert"></asp:HyperLink>
                            </td>
                            <%-- <td class="col-md-3">
                                <label>DD in original<span style="color: red"><b> *</b></span></label>
                            </td>
                            <td class="col-md-3">
                                <asp:FileUpload ID="filUploadDD" onChange="UploadControlValidationForLenthAndFileFormat(100, 'PDF', this),ValidateFileSize(this)" runat="server" />
                                <asp:RequiredFieldValidator ID="rfvfilUploadDD" runat="server" ControlToValidate="filUploadDD" Style="margin-right: -121px" ValidationGroup="Save" ForeColor="Red" Font-Bold="true" Font-Size="Small" ErrorMessage="Mandatory"></asp:RequiredFieldValidator>
                                <asp:HyperLink ID="HyperlinkDD" Target="_blank" runat="server" Style="margin-left: 50px" CssClass="label label-primary" Text="ViewDemaondDraft"></asp:HyperLink>
                            </td>--%>
                        </tr>
                        <tr class="row form-group">
                            <td class="col-md-3">
                                <label>Name of State Veterinary Council Registrar:<span style="color: red;"><b> *</b></span></label>
                            </td>
                            <td class="col-md-3">
                                <asp:TextBox ID="txtNameofCouncil" Style="margin-left: 50px; width: 277px;" Text="Madhya Pradesh State Veterinary Council" CssClass="form-control" AutoComplete="off" onkeypress="return lettersOnly(event)" runat="server" ReadOnly="true"></asp:TextBox>
                                <%--<asp:RequiredFieldValidator ID="rfvtxtNameofCouncil" Style="margin-left: 50px" runat="server" ValidationGroup="Save" ControlToValidate="txtNameofCouncil" ErrorMessage="Mandatory Field" ForeColor="Red" Font-Bold="true" Font-Size="Small"></asp:RequiredFieldValidator>--%>
                            </td>
                            <td class="col-md-3">
                                <label>Address:<span style="color: red"><b> *</b></span></label>
                            </td>
                            <td class="col-md-3">
                                <asp:TextBox ID="txtaddressd" Text="Kamdhenu Bhavan,Vaishali Nagar, Bhopal MP – 462003" ReadOnly="true" Style="margin-left: 1px; width: 277px;" AutoComplete="off" CssClass="form-control" runat="server" onkeypress="return lettersOnly(event)"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvAddress" runat="server" ValidationGroup="Save" ControlToValidate="txtaddressd" ErrorMessage="Mandatory Field" ForeColor="Red" Font-Bold="true" Font-Size="Small"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                    </table>

                    <%-- Start Add Aditional Details By Bhanu On 25-03-2022 --%>
                    <div class="row">
                        <h4>
                            <strong class="strong" style="margin-left: 16px">Payment details of Fee for MPSVC/- :-</strong>
                        </h4>
                    </div>
                    <table style="width: 100%">
                        <tr class="row form-group">
                            <td>
                                <label>Cheque/DD No:<span style="color: red"><b> *</b></span></label>
                            </td>
                            <td class="col-md-3">
                                <asp:TextBox ID="txtCheckDD_forMPSVC" runat="server" CssClass="form-control" Style="width: 277px; margin-left: 95px" AutoComplete="Off" onkeypress="return lettersOnly(event)"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvcheckddforMPSVC" Style="margin-left: 189px" runat="server" ValidationGroup="Save" ControlToValidate="txtCheckDD_forMPSVC" ErrorMessage="Mandatory Field" ForeColor="Red" Font-Bold="true" Font-Size="Small"></asp:RequiredFieldValidator>
                            </td>

                            <td>
                                <label>Drawn in the name of(DD):<span style="color: red"><b> *</b></span></label>
                            </td>
                            <td class="col-md-3">
                                <asp:TextBox ID="txtdrawnamedd_forMPSVC" runat="server" ReadOnly="true" Style="width: 277px; margin-left: -3%;" CssClass="form-control" AutoComplete="off" Text="Registrar M P State Veterinary Council"></asp:TextBox>
                               <%-- <asp:RequiredFieldValidator ID="rfvdranameddforMPSVC" runat="server" ValidationGroup="Save" Style="margin-left: 22%;" ControlToValidate="txtdrawnamedd_forMPSVC" ErrorMessage="Mandatory Field" ForeColor="Red" Font-Bold="true" Font-Size="Small"></asp:RequiredFieldValidator>--%>
                            </td>

                        </tr>
                        <tr class="row form-group">
                            <td>
                                <label>Payment Date:<span style="color: red"><b> *</b></span></label>
                            </td>
                            <td class="col-md-3">
                                <asp:TextBox ID="txtpaymentdate_forMPSVC" runat="server" Style="width: 277px; margin-left: 95px" CssClass="form-control" data-date-format="dd/mm/yyyy" AutoComplete="off" data-provide="datepicker" data-date-autoclose="true"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvpaymentforMPSVC" Display="Dynamic" Style="margin-left: 189px" runat="server" ValidationGroup="Save" ControlToValidate="txtpaymentdate_forMPSVC" ErrorMessage="Mandatory Field" ForeColor="Red" Font-Bold="true" Font-Size="Small"></asp:RequiredFieldValidator>
                            </td>
                            <td>
                                <label>Payable Amount:</label>
                            </td>
                            <td class="col-md-3">
                                <asp:TextBox ID="txtTotalPayAmount" runat="server" Style="width: 277px; margin-left: -3%" ReadOnly="true" CssClass="form-control"  AutoComplete="off"></asp:TextBox>
                            </td>                         
                            <%-- END Add Aditional Details By Bhanu On 25-03-2022 --%>
                        </tr>
                        <tr class="row">
                             <td>
                                <label>Name of issuing Bank: <span style="color: red"><b>*</b></span></label>
                            </td>
                            <td class="col-md-3">
                                <asp:TextBox ID="txtBankname_forMPSVC" runat="server" CssClass="form-control" Style="width: 277px; margin-left: 95px" AutoComplete="Off" onkeypress="return lettersOnly(event)"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvbanknameforMPSVC" runat="server" ValidationGroup="Save" ControlToValidate="txtBankname_forMPSVC" ErrorMessage="Mandatory Field" ForeColor="Red" Font-Bold="true" Font-Size="Small" Style="margin-left:51%"></asp:RequiredFieldValidator>
                            </td>
                            <td>
                                <label>Branch Name:<span style="color: red"><b> *</b></span></label>
                            </td>
                            <td class="col-md-3">
                                <asp:TextBox ID="txtBranch_forMPSVC" runat="server" Style="width: 277px; margin-left: -3%" CssClass="form-control" AutoComplete="off"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvbranchforMPSVC" runat="server" Style="margin-left: 24%" ValidationGroup="Save" ControlToValidate="txtBranch_forMPSVC" ErrorMessage="Mandatory Field" ForeColor="Red" Font-Bold="true" Font-Size="Small"></asp:RequiredFieldValidator>
                            </td>                          
                        </tr>
                        <tr class="row">
                             <td>
                                <label>DD in Original:<span style="color: red;"><b> *</b></span></label>
                            </td>
                            <td class="col-md-3">
                                <asp:FileUpload ID="filupDD_forMPSVC" runat="server" Style="margin-left:26%" onChange="UploadControlValidationForLenthAndFileFormat(100, 'PDF', this),ValidateFileSize(this)" />
                                <asp:RequiredFieldValidator ID="rfvdd_forMPSVC" Style="margin-left: 68%;"  runat="server" ControlToValidate="filupDD_forMPSVC" ValidationGroup="Save" ForeColor="Red" Font-Bold="true" Font-Size="Small" ErrorMessage="Mandatory Field"></asp:RequiredFieldValidator>
                                &nbsp;
                                <asp:HyperLink ID="hyperDD_forMPSVC" Target="_blank" runat="server" Style="margin-left: -72%;" CssClass="label label-primary" Text="ViewRegistrationCert"></asp:HyperLink>
                            </td>
                        </tr>
                    </table>

                    <%-- END Add Aditional Details By Bhanu --%>

                    <asp:Button ID="btnsubmit" runat="server" OnClick="btnSave_Click" Style="margin-top: 30px" ValidationGroup="Save" CssClass="btn btn-primary" />
                    <asp:Button ID="btnprint" Visible="false" Text="Print" runat="server" OnClick="btnprint_Click" />
                    <%--<a href="TransferRegistrationoutofMP.aspx" class="btn btn-danger">Refresh</a>--%>
                    <asp:LinkButton ID="lnkdisApprove" runat="server" CssClass="btn" Text="Not Approve" Style="margin-top: 30px" OnClick="lnkdisApprove_Click" Visible="false"></asp:LinkButton>

                </div>
            </div>
        </div>
        <%-- <asp:LinkButton ID="popup" runat="server" Text="Confirm" ValidationGroup="Save"  CssClass="btn btn-info" OnClick="popup_Click"></asp:LinkButton>
                <a href="TransferRegistrationoutofMP.aspx" class="btn btn-danger">Clear</a>--%>

        <%-- <div id="myModal1" class="modal fade" role="dialog">
            <div class="modal-dialog" style="width: 900px">
                <!-- Modal content-->
                <div class="modal-content">
                    <div class="modal-header">
                        <%-- <button  type="button" class="close" data-dismiss="modal" >&times;</button>--%>
        <%-- <h4>Transfer Registration From Preview</h4>
                    </div>
                    <div class="modal-body noprint">
                        <div class="row">
                            <div class="col-md-4">
                                <div class="form-group">
                                    <asp:Label runat="server" Text="Applcant Name"></asp:Label>
                                    <span style="color: red">*</span>
                                    <asp:TextBox runat="server" ReadOnly="true" CssClass="form-control" ID="txtName2"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-group">
                                    <asp:Label runat="server" Text="Father/Husband Name"></asp:Label>
                                    <span style="color: red">*</span>
                                    <asp:TextBox runat="server" ReadOnly="true" ID="txtFHofname2" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-group">
                                    <asp:Label runat="server" Text="DOB"></asp:Label>
                                    <span style="color: red">*</span>
                                    <asp:TextBox runat="server" ReadOnly="true" ID="txtdateofbirth2" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-4">
                                <div class="form-group">
                                    <asp:Label runat="server" Text="Gender"></asp:Label>
                                    <span style="color: red">*</span>
                                    <asp:DropDownList ID="dldGender2" Enabled="false" CssClass="form-control" runat="server">
                                        <asp:ListItem Value="0">--Select--</asp:ListItem>
                                        <asp:ListItem Value="Male">Male</asp:ListItem>
                                        <asp:ListItem Value="Female">Female</asp:ListItem>
                                        <asp:ListItem Value="Other">Other</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-group">
                                    <asp:Label runat="server" Text="Degree Name"></asp:Label>
                                    <span style="color: red">*</span>
                                    <asp:TextBox runat="server" ReadOnly="true" ID="txtDigri2" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-group">
                                    <asp:Label runat="server">University Name</asp:Label>
                                    <span style="color: red">*</span>
                                    <asp:TextBox runat="server" ReadOnly="true" ID="txtinstitute2" CssClass="form-control"></asp:TextBox>                                   
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-4">
                                <div class="form-group">
                                   <asp:Label runat="server"><small>College Name</small></asp:Label>
                                    <span style="color: red">*</span>
                                    <asp:TextBox runat="server" ReadOnly="true" ID="txtNameofCollege2" CssClass="form-control"></asp:TextBox> 
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-group">
                                    <asp:Label runat="server">Residential Address</asp:Label>
                                    <span style="color: red">*</span>
                                    <asp:TextBox runat="server" ReadOnly="true" ID="txtResidential2" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-group">
                                    <asp:Label runat="server" Text="Mobile No"></asp:Label>
                                    <span style="color: red">*</span>
                                    <asp:TextBox runat="server" ReadOnly="true" ID="txtno2" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-4">
                                <div class="form-group">
                                    <asp:Label runat="server" Text="Email"></asp:Label>
                                    <span style="color: red">*</span>
                                    <asp:TextBox runat="server" ReadOnly="true" ID="txtmail2" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-group">
                                    <asp:Label runat="server" Text="candidate is presently registered(SVC) "></asp:Label>
                                    <span style="color: red">*</span>
                                    <asp:TextBox runat="server" ReadOnly="true" ID="txtpr2" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-group">
                                    <asp:Label runat="server" Text="Registration Number"></asp:Label>
                                    <span style="color: red">*</span>
                                    <asp:TextBox runat="server" ReadOnly="true" ID="txtRegistrationNumber2" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-4">
                                <div class="form-group">
                                    <asp:Label runat="server" Text="Validity of Registration"></asp:Label>
                                    <span style="color: red">*</span>
                                    <asp:TextBox runat="server" ReadOnly="true" ID="txtValidityofR2"  data-date-format="dd/mm/yyyy" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-group">
                                    <asp:Label runat="server" Text="State"></asp:Label>
                                    <span style="color: red">*</span>
                                    <asp:TextBox runat="server" ReadOnly="true" ID="txtregistrationisapplied2" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-group">
                                    <asp:Label runat="server" Text="DDNO"></asp:Label>
                                    <span style="color: red">*</span>
                                    <asp:TextBox runat="server" ReadOnly="true" ID="txtDemandNo2" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-4">
                                <div class="form-group">
                                    <asp:Label runat="server" Text="For draw dd"></asp:Label>
                                    <span style="color: red">*</span>
                                    <asp:TextBox runat="server" ReadOnly="true" ID="Textdraw2" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-group">
                                    <asp:Label runat="server" Text="Date"></asp:Label>
                                    <span style="color: red">*</span>
                                    <asp:TextBox runat="server" ReadOnly="true" ID="Textdate2" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-group">
                                    <asp:Label runat="server" Text="Bank"></asp:Label>
                                    <span style="color: red">*</span>
                                    <asp:TextBox runat="server" ReadOnly="true" ID="Textbank2" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-4">
                                <div class="form-group">
                                    <asp:Label runat="server" Text="Branch"></asp:Label>
                                    <span style="color: red">*</span>
                                    <asp:TextBox runat="server" ReadOnly="true" ID="TextBranch2" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-group">
                                    <asp:Label runat="server" Text="Reason"></asp:Label>
                                    <span style="color: red">*</span>
                                    <asp:TextBox runat="server" ReadOnly="true" ID="textreason2" Width="500px" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-4">
                                <div class="form-group">
                                    <asp:Label runat="server" Text="Applicant image"></asp:Label>
                                    <span style="color: red">*</span>
                                    <asp:Label ID="lblurl" runat="server" Visible="false"></asp:Label>
                                    <asp:Image ID="imgApplicant" runat="server" Height="70" Width="70" />
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-group">
                                    <asp:Label runat="server" Text="Origional DD"></asp:Label>
                                    <span style="color: red">*</span>
                                    <asp:Label runat="server" ID="lblDD" Visible="false"></asp:Label>
                                    <asp:Image ID="imgDD" runat="server" Height="80" Width="80" />
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-group">
                                    <asp:Label runat="server" Text="Birth Proof"></asp:Label>
                                    <span style="color: red">*</span>
                                    <asp:Label runat="server" ID="lblBirth" Visible="false"></asp:Label>
                                    <asp:Image ID="imgBirthproof" runat="server" Height="80" Width="80" />
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-4">
                                <div class="form-group">
                                    <asp:Label runat="server" Text="Degree certificate"></asp:Label>
                                    <span style="color: red">*</span>
                                    <asp:Label ID="lblDegricert" runat="server" Visible="false"></asp:Label>
                                    <asp:Image ID="imgDegreeCertifiacte" runat="server" Height="80" Width="80" />
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-group">
                                    <asp:Label runat="server" Text="Registration Certificate"></asp:Label>
                                    <span style="color: red">*</span>
                                    <asp:Label ID="lblregicert" runat="server" Visible="false"></asp:Label>
                                    <asp:Image ID="imgReegiCert" runat="server" Height="80" Width="80" />
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-group">
                                    <asp:Label runat="server" Text="Applicant Signature"></asp:Label>
                                    <span style="color: red">*</span>
                                    <asp:Label ID="lblSign" runat="server" Visible="false"></asp:Label>
                                    <asp:Image ID="imgSign" runat="server" Height="80" Width="80" />
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <asp:Label runat="server" Text=" Registrar Name"></asp:Label>
                                    <span style="color: red">*</span>
                                    <asp:TextBox runat="server" ReadOnly="true" Width="350px" ID="TextregisName2" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <asp:Label runat="server" Text=" Registrar Address"></asp:Label>
                                    <span style="color: red">*</span>
                                    <asp:TextBox runat="server" Width="350px" ReadOnly="true" ID="TextRegistAdd" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="modal-footer">--%>
        <%-- <asp:Button ID="btnsubmit" runat="server" OnClick="btnSave_Click" ValidationGroup="Save&Pay" Text="Submit" CssClass="btn btn-primary  noprint" />
                              <asp:Button ID="btnprint" Visible="false"  Text="Print" runat="server"  OnClick="btnprint_Click" />
                           <asp:LinkButton ID="lnkdisApprove" runat="server" CssClass="btn" Text="Not Approve" OnClick="lnkdisApprove_Click" Visible="false"></asp:LinkButton>--%>
        <%--  <asp:button type="button" class="btn btn-warning" data-dismiss="modal"></asp:button>--%>
        <%-- <asp:Button ID="btnClose" runat="server" OnClick="btndelete_Click"  Text="Close" CssClass="btn btn-danger" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
         </div>   --%>
        <div class="NonPrintable" id="Divprint" runat="server">
            <div class="row">
                <div class="col-md-12">
                    <%-- Start PART-1 HERE ----%>
                    <h3 style="text-align: center;  margin-bottom:-15px">भारतीय पशुचिकित्सा परिषद् नई दिल्ली - 110066 </h3>
                    <h3 style="text-align: center;">Veterinary Council of India, New Delhi – 110066</h3>
                    <h4 style="text-align: center; margin-top: 1px">एक राज्य पशुचिकित्सा परिषद् से दूसरे राज्य पशुचिकित्सा परिषद् मे पंजीयन अंतरण हेतु आवेदन</h4>
                    <h3 style="text-align: center; margin-bottom: 30PX; border:solid"> APPLICATION FORM</h3>
                    <h4 style="text-align: center; margin-bottom:-5px"">TRANSFER OF REGISTRATION FROM ONE STATE VETERINARY <br />REGISTER TO ANOTHER STATE VETERINARY REGISTER</h4>
                    <h4 style="text-align:center; "><b>(Under IVC Act 1984, Rule 55)</b></h4>
                    <h3 style="text-align: center">PART 1</h3>
                    <%--  <table style="width: 100%;" cellpadding="0" cellspacing="0" style="margin-top: 50PX">
                        <tr>
                            <td>
                                <asp:Label ID="lblID" runat="server" Visible="false" Text='<%# Eval("RegiNo")%>'></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <label>Applicant Name:</label>
                            </td>
                            <td>
                                <asp:Label ID="lblapllicant" runat="server" Text='<%# Eval("Name")%>'>' ></asp:Label>
                            </td>

                            <td>
                                <label>Applicant Image:</label>
                            </td>
                            <td>
                                <asp:Image ID="myimg" runat="server" BorderWidth="1" BorderColor="Blue" Height="120px" Width="120px" CssClass="img-responsive" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <label>Applicant Father/Husband Name:</label>
                            </td>
                            <td>
                                <asp:Label ID="lblApplicantFH" runat="server" Text='<%# Eval("FatherName")%>'>'></asp:Label>
                            </td>

                            <td>
                                <label>Date Of Birth:</label>
                            </td>
                            <td>
                                <asp:Label ID="lblDOB" runat="server" Text='<%# Eval("DOB")%>'>' ></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <label>Gender:</label>
                            </td>
                            <td>
                                <asp:Label ID="lblGender" runat="server" Text='<%# Eval("Gender")%>'>' ></asp:Label>
                            </td>
                        </tr>
                        <tr>                         
                        </tr>
                        <tr>                           
                        </tr>
                        <tr>
                            <td>
                                <label>Residential Address:</label>
                            </td>
                            <td colspan="3">
                                <asp:Label ID="lblresidntialAddress" runat="server" Text='<%# Eval("PreferedAdd")%>'>'></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <label>Mobile No: </label>
                            </td>
                            <td>
                                <asp:Label ID="lblNO" runat="server" Text='<%# Eval("MobileNo")%>'>' ></asp:Label>
                            </td>
                            <td>
                                <label>AlterNate Mobileno:</label>
                            </td>
                            <td>
                                <asp:Label ID="lblAltermobileno" runat="server" Text='<%# Eval("MobileNo2") %>'>'</asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <label>Email:</label>
                            </td>
                            <td>
                                <asp:Label ID="lblemail" runat="server" Text='<%# Eval("EmailId")%>'>'></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <label>
                                    Name of the State Veterinary Council wherein,candidate<br />
                                    is presently registered:</label>
                            </td>
                            <td colspan="3">
                                <asp:Label ID="lblPR" runat="server" Text='<%# Eval("State_Veterinary_Council_namepresent")%>'>'></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <label>Registration Number:</label>
                            </td>
                            <td>
                                <asp:Label ID="lblRn" runat="server" Text='<%# Eval("RegiNo")%>'>'></asp:Label>
                            </td>

                            <td>
                                <label>Validity of Registration:</label>
                            </td>
                            <td>
                                <asp:Label ID="lblVr" runat="server" Text='<%# Eval("Validupto")%>'>'></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <label>Name of the State Veterinary Council wherein, the transfer of registration is applied:</label>
                            </td>
                            <td colspan="3">
                                <asp:Label ID="lblAppli" runat="server" Text='<%# Eval("StateName")%>'>'></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <label>DD NO:</label>
                            </td>
                            <td>
                                <asp:Label ID="lblddno" runat="server" Text='<%# Eval("ChequeNo")%>'>'></asp:Label>
                            </td>
                            <td>
                                <label>Date:</label>
                            </td>
                            <td>
                                <asp:Label ID="lblDate" runat="server" Text='<%# Eval("alDate")%>'>'></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <label>DD draw name:</label>
                            </td>
                            <td colspan="3">
                                <asp:Label ID="lblDddrname" runat="server" Text='<%# Eval("Drawn_name_DD")%>'>'></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <label>Bank:</label>
                            </td>
                            <td colspan="3">
                                <asp:Label ID="lblIssuebank" runat="server" Text='<%# Eval("BankName")%>'>'></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <label>Branch:</label>
                            </td>
                            <td colspan="3">
                                <asp:Label ID="lblIssueBranch" runat="server" Text='<%# Eval("Bank_Branch_Name")%>'>'></asp:Label>
                            </td>
                        </tr>

                        <tr>
                            <td>
                                <label>Name of State Veterinary Council:</label>
                            </td>
                            <td colspan="3">
                                <asp:Label ID="lblVetenaryCouncil" runat="server" Text='<%# Eval("Registrar_Name")%>'>'></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <label>Registrar Adderess:</label>
                            </td>
                            <td colspan="3">
                                <asp:Label ID="lblRAddress" runat="server" Text='<%# Eval("Registrar_Adresse")%>'>'></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <label>Reason:</label>
                            </td>
                            <td colspan="3">
                                <asp:Label ID="Lblrison" runat="server" Text='<%# Eval("Remark")%>'>'></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="break-after: page"></td>
                        </tr>                       
                    </table>--%>

                    <table style="width: 100%" class="table table-bordered">
                        <tr>
                            <td><b> S.No.</b></td>
                            <td><b>विवरण/Particulars</b></td>
                            <td></td>
                        </tr>
                        <tr>
                            <td>1.</td>
                            <td>आवेदक का फोटो/<br />
                                Photograph of the Applicant:</td>
                            <td style="width:500px; height:150px"><p>अपना पासपोर्ट साइज़ फोटो चिपकाएं</p>
                                <%--<asp:Image ID="myimg" runat="server" BorderWidth="1" BorderColor="Blue" CssClass="img-responsive" />--%>
                            </td>
                        </tr>
                        <tr>
                            <td>2.</td>
                            <td>आवेदक का नाम बड़े अक्षरो में/<br />
                                Name of Applicant(in Capital Letter):</td>
                            <td>
                                <asp:Label ID="lblapllicant" runat="server" Text='<%# Eval("Name")%>'></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>3.</td>
                            <td>पिता/पति का नाम/<br />
                                Father’s/Husband Name
                            </td>
                            <td>
                                <asp:Label ID="lblApplicantFH" runat="server" Text='<%# Eval("FatherName")%>'></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>4.</td>
                            <td>जन्मतिथि/<br />
                                Date of Birth</td>
                            <td>
                                <asp:Label ID="lblDOB" runat="server" Text='<%# Eval("DOB")%>'></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>5.</td>
                            <td>लिंग/Gender</td>
                            <td>
                                <asp:Label ID="lblGender" runat="server" Text='<%# Eval("Gender")%>'></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td rowspan="4">6.</td>
                            <td colspan="2" style="height: 50px">मान्यता प्राप्त पशु चिकित्सा योग्यता का विविरण/<br />Details of recognized Veterinary Qualification:</td>
                        </tr>
                        <tr>
                            <td>A. डिग्री का नाम/Degree Nomenclature</td>
                            <td>
                               <%-- <asp:Label ID="lblDegreeName" runat="server" Text='<%# Eval("DegreeName") %>'></asp:Label>--%>
                                 <asp:Label ID="lblDegreeName" runat="server" Text="Bachelor of Veterinary Science And A.H"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>B. कॉलेज का नाम/Name of College</td>
                            <td>
                                <asp:Label ID="lblCollegeName" runat="server" Text='<%# Eval("CollegeName") %>'></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>C. उस संस्था का नाम जिसने मान्यता प्राप्त पशु चिकित्सा योग्तया प्रदान की है /<br />
                                Name of Institution awarded Recognized veterinary qualification</td>
                            <td>
                                <asp:Label ID="lblUniversity" runat="server" Text='<%# Eval("UniversityName") %>'></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>7.</td>
                            <td>पूरा पत्राचार / आवसीय पता/Full Correspondence/Residential Address</td>
                            <td>
                                <asp:Label ID="lblresidntialAddress" runat="server" Text='<%# Eval("PreferedAdd")%>'></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td rowspan="3">8.</td>
                            <td colspan="2">आवेदक का चल दूरभाष नंबर एव ईमेल- आईडी/<br />Mobile Number and Email-ID of applicant</td>
                        </tr>
                        <tr>
                            <td>A. मोबाइल नंबर/Mobile Number of applicant:</td>
                            <td>
                                <asp:Label ID="lblNO" runat="server" Text='<%# Eval("MobileNo")%>'></asp:Label></td>
                        </tr>
                        <tr>
                            <td>B. ईमेल- आईडी/Email-ID of applicant:</td>
                            <td>
                                <asp:Label ID="lblemail" runat="server" Text='<%# Eval("EmailId")%>'></asp:Label>
                            </td>
                        </tr>
                    </table><%-- END PART-1 HERE ----%>
                    <div style="break-after: page"></div>
                    <h3 style="text-align: center">PART 2</h3> <%-- Start PART-2 HERE ----%>
                    <div class="row">
                        <div class="col-md-12">
                            <h3 style="text-align: center; margin-bottom: 30PX; border:solid">Details of Registration and Transfer applied</h3>
                        </div>
                    </div>
                    <table style="width: 100%; height: 100%" class="table table-bordered">
                        <tr>
                            <td>9.</td>
                            <td>राज्य पशु चिकत्सा परिषद का नाम जहाँआवेदक वर्तमान मे पंजीकृत है/<br />
                                Name of the State Veterinary Council wherein, candidate is presently registered</td>
                            <td>
                                <asp:Label ID="lblPR" runat="server" Text='<%# Eval("State_Veterinary_Council_namepresent")%>'></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>10.</td>
                            <td>राज्य पशु चिकत्सा परिषद पंजीकरण संख्या/
                                State Veterinary Council Registration Number</td>
                            <td>
                                <asp:Label ID="lblRn" runat="server" Text='<%# Eval("RegiNo")%>'></asp:Label>

                            </td>
                        </tr>
                        <tr>
                            <td>11.</td>
                            <td>पंजीकरण की वैधता(दिवस/ मास / वर्ष)/<br />
                                Validity of Registration (dd/mm/yyyy)</td>
                            <td>
                                <asp:Label ID="lblVr" runat="server" Text='<%# Eval("Validupto")%>'></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>12.</td>
                            <td>उस राज्य पशु चिकत्सा  परिषद का नाम जहा आवेदक को पंजीयन का अंतरण करना है|/<br />
                                Name of the State Veterinary Council wherein, the transfer of registration is applied</td>
                            <td>
                                <asp:Label ID="lblAppli" runat="server" Text='<%# Eval("StateName")%>'></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td rowspan="7">13.</td>
                            <td colspan="2">अंतरण शुल्क रुपये15 का विवरण/<br />
                                Payment details of transfer Fee of Rs 15/-. </td>
                        </tr>
                        <tr>
                            <td>1. डिमांड ड्राफ्ट संख्या/DD No</td>
                            <td>
                                <asp:Label ID="lblddno" runat="server" Text='<%# Eval("ChequeNo")%>'></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>2. जिसके पक्ष में किया गया उसका नाम/
                                Drawn in the name of</td>
                            <td>
                                <asp:Label ID="lblDddrname" runat="server" Text='<%# Eval("Drawn_name_DD")%>'></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>3. तिथि/Date:</td>
                            <td>
                                <asp:Label ID="lblDate" runat="server" Text='<%# Eval("alDate")%>'></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>4. रकम/Amount</td>
                            <td>
                                <asp:Label ID="lblAmount" runat="server" Text='<%# Eval("TotalAmount") %>'></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>5.जारी करने वाले बैंक का नाम/ Name of issuing Bank</td>
                            <td>
                                <asp:Label ID="lblIssuebank" runat="server" Text='<%# Eval("BankName")%>'></asp:Label>
                            </td>
                        </tr>
                        <tr>

                            <td>6.जारी करने वाले शाखा का नाम/ Name of issuing Branch</td>
                            <td>
                                <asp:Label ID="lblIssueBranch" runat="server" Text='<%# Eval("Bank_Branch_Name")%>'></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>14.</td>
                            <td>पंजीयन अंतरण का कारण/
                                Reason for seeking transfer of registration:</td>
                            <td>
                                <asp:Label ID="Lblrison" runat="server" Text='<%# Eval("Remark")%>'></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td rowspan="5">15.</td>
                            <td colspan="2">संलग्न प्रमाण पत्र की सूची/List of documents enclosed: 
                                <%-- <br />
                                <br />
                                Note-: <b style="color:red;">Strike out which is not applicable</b>--%></td>
                        </tr>
                        <tr>
                            <td>1. डिमांड ड्राफ्ट की मूल प्रति/DD in original</td>
                            <td>Yes</td>
                        </tr>
                        <tr>
                            <td>2. जन्म तिथि/Aadhar / Passport / DL/SSLC :
                            </td>
                            <td>Yes</td>
                        </tr>
                        <tr>
                            <td>3. डिग्री प्रमाण पत्र/Degree certificate (BVSc&AH/MVSc/ PhD/ Other):
                            </td>
                            <td>Yes</td>
                        </tr>
                        <tr>
                            <td>4. राज्य पशु चिकत्सा परिषद की पंजीयन प्रमाण पत्र की प्रतिलिपि/
                                Copy of the State Veterinary Council Registration Certificate:
                            </td>
                            <td>Yes</td>
                        </tr>
                    </table> <%-- END PART-2 HERE ----%>
                    &nbsp&nbsp<span style="margin-left: 60px;">आवेदक का हस्ताक्षर/Signature of the Applicant:________________________    &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp जमा किया/ Submitted to:</span>
                    <br />
                    <br />
                    &nbsp&nbsp<span style="margin-left: 60px;">श्रीमान पंजीयक/The Registrar: --<b><asp:Label ID="lblVetenaryCouncil" runat="server" Text='<%# Eval("Registrar_Name")%>'></asp:Label></b>
                        &nbsp&nbsp&nbsp&nbsp(राज्य पशु चिकित्सा का नाम)/Name of State Veterinary Council</span><br />
                    <br />
                    &nbsp&nbsp<span style="margin-left: 60px">पता/Address:-- 
                     <b>
                         <asp:Label ID="lblRAddress" runat="server" Text='<%# Eval("Registrar_Adresse")%>'></asp:Label></b></span>


                </div>
            </div>
        </div>
        <div style="break-after: page"></div>
        <div class="NonPrintable" id="printnoc" runat="server">
            <div class="row">
                <div class="col-md-12">
                    <h2 style="text-align: center">TRANSFER OF REGISTRATION FROM ONE STATE VETERINARY REGISTER TO ANOTHER STATE VETERINARY REGISTER</h2>
                    <h3 style="text-align: center">(Under IVC Act 1984, Rule 55)</h3>
                    <h2 style="text-align: center; margin-bottom: 50PX">निर्देश/ INSTRUCTIONS</h2>
                    <table class="table table-bordered">
                        <tr>
                            <td>1.</td>
                            <td style="font-size: 16px">
                                <strong>स्थानान्तरण आवेदन पत्र www.vci.dadf.gov.in वेबसाईट पर उपलब्ध है/</strong>
                            </td>
                        </tr>
                        <tr>
                            <td>2.</td>
                            <td style="font-size: 16px"><strong>प्रथम राज्य पशु चिकित्सा परिषद को आवदेन की तीन प्रतियों में प्रस्तुत किया जाना चाहिये/</strong><br />
                                Application should be submitted in TRIPLICATE, to the first named State Veterinary Council(SVC).</td>
                        </tr>
                        <tr>
                            <td>3.</td>
                            <td style="font-size: 16px"><strong>पार्ट 1, पार्ट 2: आवेदक द्वारा भरे जाने के लिए<br />
                                पार्ट 3 प्रथम राज्य पशु चिकित्सा परिषद द्वारा अनापत्ति प्रमाण पत्र जारी करने के संबंध में<br />
                                पार्ट 4: दूसरे राज्य पशु चिकित्सा परिषद की सिफारिश/आदेश<br />
                                पार्ट 5: दूसरे राज्य पशु चिकित्सा परिषद में नाम एवं पुन: पंजीकरण संख्या का आवंटन</strong>  &nbsp
                                <br />
                                Part 1 and Part 2 : To be filled by the applicant<br />
                                Part 3: For issue of NOC by the first named SVC<br />
                                Part 4: Recommendation / Orders of the VCI, New Delhi<br />
                                Part 5: Re-registration and allotment of number by Second named SVC </td>
                        </tr>
                        <tr>
                            <td>4.</td>
                            <td style="font-size: 16px">
                                <strong>प्रथम राज्य पशु चिकित्सा परिषद से दस्तावेज के सत्यापन और (एन. ओ. सी.) जारी होने और डिमांड ड्राफ्ट के साथ आवेदक दो सेट के साथ  बी सी आई को अग्रेषित करेगी। अगर बी सी आई पंजीकरण के हस्तानंतरण पर विचार करती हे
                                तो बह आदेश के साथ मूल डिमांड ड्राफ्ट के साथ आवदेन को दूसरे राज्य पशु चिकित्सा परिषद अग्रेषित करेगा ।</strong><br />
                                Upon verification of Documents and issue of NOC (Part-III) the first Demand Draft
                                    (DD) named SVC will forward two set of applications along with copies documents &
                                    Demand Draft (DD) to VCI. The VCI may consider for transfer of registration and with
                                    its Orders (Part-IV) forward one set of application along with Original D.D and
                                    documents to Second named State Veterinary Council. 
                            </td>
                        </tr>
                        <tr>
                            <td>5.
                            </td>
                            <td style="font-size: 16px">
                                <strong>डिमांड ड्राफ्ट संलग्न करके दूसरे राज्य पशु चिकित्सा में भेजा जाएगा।</strong> &nbsp&nbsp
                                <br />
                                The D.D will be accounted in the office of second named SVC
                            </td>
                        </tr>
                    </table>
                    <strong>Note: First named SVC is the place wherein the registration exists and Second named
                          SVC is the place wherein transfer is opted.</strong>
                </div>
            </div>
        </div>
        <div class="reveal-modal-bg" id="divOTP" runat="server" style="display: none; width: 100%; position: fixed; padding-left: 30%; padding-top: 20%">
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
                          <asp:Button ID="Button2" runat="server" Text="Verify" OnClientClick="javascript:return(PopAcceptRenew());" Width="100" CssClass="btn" OnClick="Button2_Click" />
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
                        <td style="padding-top: 10px; padding-left: 20px;" colspan="2">if the mobile no being displayed on blue tape is wrong then
                            <br />
                            <asp:HyperLink ID="HyperLink2" runat="server" Font-Underline="True" ForeColor="#0066FF" NavigateUrl="~/frm_userupdateddetails.aspx">click here to update information</asp:HyperLink>
                            &nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Label ID="Label1" runat="server" ForeColor="Red" Text=""></asp:Label></td>
                    </tr>
                </table>
            </asp:Panel>
        </div>
        <div class="reveal-modal-bg" id="divRenewal" runat="server" style="display: none; width: 100%; position: fixed; padding-left: 30%; padding-top: 20%">
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
                            <asp:Button ID="Confirm" runat="server" Text="Ok" OnClick="btnok_Click" OnClientClick="javascript:return(PopAcceptTrans());"
                                Width="100" CssClass="btn" />
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </div>
        <div class="reveal-modal-bg" id="divPopOnSave" runat="server" style="display: none; width: 100%; position: fixed; padding-left: 30%; padding-top: 20%">
            <asp:Panel ID="Panel3" runat="server" BackColor="#FFFFFF" Height="150px" Width="440px"
                BorderStyle="Solid" BorderWidth="3" BorderColor="#004040" ScrollBars="None">
                <table style="width: 440px">
                    <tr>
                        <td colspan="2" style="padding-top: 10px; color: Red; font-weight: bold;" align="center">
                            <asp:Label ID="lblalert" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="padding-top: 20px;" align="center">
                            <asp:Button ID="btnok" runat="server" Text="Ok" Width="100" CssClass="btn" OnClick="btnok_Click" OnClientClick="javascript:return(PopAcceptOnSave());" />
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </div>
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
        <div class="ftr_logo noprint">
            <a href="http://india.gov.in" target="_blank">
                <img src="../images/india_gov_logo.jpg" alt="National Portal of India" title="National Portal of India" /></a>
            <a href="http://mygov.in" target="_blank">
                <img src="../images/my_gov_logo.jpg" alt="My Gov" title="My Gov" /></a>
        </div>
        <div class="footer noprint">
            <div class="footer-cnt">
                <div class="FL">
                    <a href="#">Accessibility Statement</a> | <a href="#">Terms of Use</a> | <a href="#">Disclaimer</a> | <a href="#">Privacy Policy</a>
                </div>
                <div class="FR">
                    2015 &copy; Content Owned by Madhya Pradesh State Veterinary Council.
                </div>
                <div class="CL">
                </div>
            </div>
        </div>
        <%--  <script type="text/javascript" src="js/jquery.min.js"></script>--%>
        <%-- <script type="text/javascript" src="js/jquery-1.6.1.min.js"></script>--%>
        <%-- <script type="text/javascript" src="js/jquery.reveal.js"></script>--%>
        <%-- <script type="text/javascript" src="js/news.js"></script>--%>
        <script type="text/javascript"></script>


        <script src="js/jquery-2.2.4.js"></script>
        <script src="js/bootstrap-datepicker.js"></script>
        <script src="js/bootstrap-timepicker.js"></script>
        <script src="js/bootstrap.js"></script>
        <script src="js/daterangepicker.js"></script>
        <script src="js/jquery.datetimepicker.js"></script>
        <script src="js/moment.js"></script>
        <%-- <script src="js/ValidationJs.js"></script>--%>
        <script>
            //$('.select2').select2()

            $('.DateAdd').datepicker({
                autoclose: true,
                format: 'dd/MM/yyyy'
            })
        </script>
        <div>
        </div>
    </form>
</body>
</html>
