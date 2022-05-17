<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RegistrationLinkNew.aspx.cs" Inherits="RegistrationLinkNew" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta name="description" content="" />
    <meta name="author" content="" />
    <link rel="shortcut icon" href="images/favicon.ico" type="image/x-icon" />
    <title>Madhya Pradesh State Veterinary Council</title>
    <link href="css/style.css" rel="stylesheet" type="text/css" />
    <link href="css/slider.css" rel="stylesheet" type="text/css" />
    <link href="../css/MyStyle.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../js/CommonCtrl.js"></script>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/font-awesome/4.4.0/css/font-awesome.min.css" />
    <script type="text/javascript">
        //function checkDateFormat(that) {

        //    var mo, day, yr;
        //    var entry = that.value;
        //    var re = /\b\d{1,2}[\/-]\d{1,2}[\/-]\d{4}\b/;
        //    if (re.test(entry)) {
        //        var delimChar = (entry.indexOf("/") != -1) ? "/" : "-";
        //        var delim1 = entry.indexOf(delimChar);
        //        var delim2 = entry.lastIndexOf(delimChar);

        //        day = parseInt(entry.substring(0, delim1), 10);
        //        mo = parseInt(entry.substring(delim1 + 1, delim2), 10);
        //        yr = parseInt(entry.substring(delim2 + 1), 10);
        //        var testDate = new Date(yr, mo - 1, day);

        //        if (testDate.getDate() == day) {
        //            if (testDate.getMonth() + 1 == mo) {
        //                if (testDate.getFullYear() == yr) {
        //                    return true;
        //                } else {
        //                    that.value = "";
        //                    alert("Invalid date.");
        //                }
        //            }
        //            else {
        //                that.value = "";
        //                alert("Invalid date.");

        //            }
        //        }
        //        else {
        //            that.value = "";
        //            alert("Invalid date.");
        //        }
        //    }
        //    else {
        //        if (entry != "") {
        //            that.value = "";
        //            alert("Incorrect date format. Enter as (dd/MM/yyyy).");
        //        }
        //    }
        //    return false;
        //}
    </script>

    <script type="text/javascript">
        function test() {
            try {
                document.getElementById('HF_Reg').value = document.getElementById('txtregNo').value.trim();
                document.getElementById('HF_Name').value = document.getElementById('txtName').value.trim();
                document.getElementById('HF_Email').value = document.getElementById('txtEmail').value.trim();
                document.getElementById('HF_Mob').value = document.getElementById('txtMobile').value.trim();
                document.getElementById('HF_DOB').value = document.getElementById('txtDob').value.trim();
                if (document.getElementById('txtregNo').value.trim() == "" && document.getElementById('txtName').value.trim() == "" && document.getElementById('txtEmail').value.trim() == "" && document.getElementById('txtMobile').value.trim() == "" && document.getElementById('txtDob').value.trim() == "") {
                    alert("Please enter any keyword for search");
                    return false;
                }
                document.getElementById('btnSearch').click();
                //var msg = document.getElementById('HF_Msg').value;
                //alert(msg);
            }
            catch (e) {
                alert(e);

            }
        }

        function PopTemAndCondition() {
            document.getElementById('<%=divNewReg.ClientID%>').style.display = "block";
            return false;
        }

        function PopupCancel() {
            document.getElementById('<%=divNewReg.ClientID%>').style.display = "none";
            return false;
        }
    </script>

    <script type="text/javascript">
        function PopTemAndConditionRenew() {
            document.getElementById('<%=divRenewReg.ClientID%>').style.display = "block";
            return false;
        }

        function PopupCancelRenew() {
            document.getElementById('<%=divRenewReg.ClientID%>').style.display = "none";
            return false;
        }
    </script>

    <script type="text/javascript">
        function PopTemAndConditionTrans() {
            document.getElementById('<%=divTransReg.ClientID%>').style.display = "block";
            return false;
        }
        function AcceptTrans() {
            document.getElementById('<%=divTransReg.ClientID%>').style.display = "none";
            return false;
        }
        function PopupCancelTrans() {
            document.getElementById('<%=divTransReg.ClientID%>').style.display = "none";
            return false;
        }
    </script>

    <script type="text/javascript">
        function PopTemAndConditionDuplicate() {
            document.getElementById('<%=divDuplicateCertificate.ClientID%>').style.display = "block";
            return false;
        }
        function AcceptDuplicate() {
            document.getElementById('<%=divDuplicateCertificate.ClientID%>').style.display = "none";
            return false;
        }
        function PopupCancelDuplicate() {
            document.getElementById('<%=divDuplicateCertificate.ClientID%>').style.display = "none";
            return false;
        }
    </script>

    <script type="text/javascript">
        function PopTemAndConditionQualification() {
            document.getElementById('<%=divQualification.ClientID%>').style.display = "block";
            return false;
        }
        function AcceptQualification() {
            document.getElementById('<%=divQualification.ClientID%>').style.display = "none";
            return false;
        }
        function PopupCancelQualification() {
            document.getElementById('<%=divQualification.ClientID%>').style.display = "none";
            return false;
        }
    </script>

    <script type="text/javascript">
        function PopTemAndConditionProvisional() {
            document.getElementById('<%=divProvisional.ClientID%>').style.display = "block";
            return false;
        }
        function AcceptProvisional() {
            document.getElementById('<%=divProvisional.ClientID%>').style.display = "none";
            return false;
        }
        function PopupCancelProvisional() {
            document.getElementById('<%=divProvisional.ClientID%>').style.display = "none";
            return false;
        }
    </script>

    <script type="text/javascript">
        function btnclick() {
            //        alert("hi");
            document.getElementById("btnSave").Click();
            alert("hello");
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">

        <div id="divProvisional" runat="server" style="display: none; width: 70%; position: absolute; padding-left: 30%; padding-top: 20%">
            <asp:Panel ID="Panel5" runat="server" BackColor="#FFFFFF" Height="220px"
                Width="500px" BorderStyle="Solid" BorderWidth="3" BorderColor="#004040" ScrollBars="None">
                <table width="500px">
                    <tr>
                        <td style="padding-top: 10px; padding-left: 22px; font-weight: bold;">Term and Condition's -
                        </td>
                    </tr>
                    <tr>
                        <td style="padding-top: 10px; padding-left: 20px; font-weight: bold;">1. You should be student of recognized college of Madhya Pradesh(Schedule II)
                        </td>
                    </tr>
                    <tr>
                        <td style="padding-top: 10px; padding-left: 20px; font-weight: bold;">2. Provisional registration fees is Rs. 15
                        </td>
                    </tr>
                    <tr>
                        <td style="padding-top: 20px;" align="center">
                            <a href="#" class="btn" data-reveal-id="myModal" style="font-weight: normal;">Accept & Proceed</a>
                            &nbsp;&nbsp;
                        <asp:Button ID="Button5" runat="server" Text="Cancel" Width="100" CssClass="btn"
                            OnClientClick="return PopupCancelProvisional();" />
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </div>

        <div id="divNewReg" runat="server" style="display: none; width: 70%; position: absolute; padding-left: 30%; padding-top: 20%">
            <asp:Panel ID="PanelSaveSubmitmsg" runat="server" BackColor="#FFFFFF" Height="420px"
                Width="500px" BorderStyle="Solid" BorderWidth="3" BorderColor="#004040" ScrollBars="None">
                <table width="500px">
                    <tr>
                        <td style="padding-top: 10px; padding-left: 22px; font-weight: bold;">Term and Condition's -
                        </td>
                    </tr>
                     <tr>
                        <td style="padding-top: 10px; padding-left: 20px; font-weight: bold;">This form will work both for New Registration & Transfer in M.P
                        </td>
                    </tr>
                    <tr>
                        <td style="padding-top: 10px; padding-left: 20px; font-weight: bold;">1. User should have a domicile of MP in case of  New Registration. 
                        </td>
                    </tr>
                    <tr>
                        <td style="padding-top: 10px; padding-left: 20px; font-weight: bold;">2. User should have a domicile of parent state in case of Transfer in M.P. 
                        </td>
                    </tr>
                     <tr>
                        <td style="padding-top: 10px; padding-left: 20px; font-weight: bold;">3. Applicant has to bring with him letter (NOC) of V.C.I. New Delhi  in case of Transfer in M.P.
                        </td>
                    </tr>
                     <tr>
                        <td style="padding-top: 10px; padding-left: 20px; font-weight: bold;">4.Require Affidavit of 50 Rs with subject regarding his/her professional work in Madhya Pradesh while reporting to M.P.V.C.I. Bhopal office for verification in case of Transfer in M.P. 
                        </td>
                    </tr>
                    <tr>
                        <td style="padding-top: 10px; padding-left: 20px; font-weight: bold;">5. Registration fees is Rs. 25
                        </td>
                    </tr>
                    <tr>
                        <td style="padding-top: 10px; padding-left: 20px; font-weight: bold;">6. Service Charge Fees is Rs. 2000
                        </td>
                    </tr>
                    <tr>
                        <td style="padding-top: 20px;" align="center">
                            <a href="#" class="btn" data-reveal-id="myModal2" style="font-weight: normal;">Accept & Proceed</a>
                            &nbsp;&nbsp;
                        <asp:Button ID="btnCancel" runat="server" Text="Cancel" Width="100" CssClass="btn"
                            OnClientClick="return PopupCancel();" />
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </div>

        <div id="divRenewReg" runat="server" style="display: none; width: 70%; position: absolute; padding-left: 30%; padding-top: 20%">
            <asp:Panel ID="Panel1" runat="server" BackColor="#FFFFFF" Height="180px"
                Width="500px" BorderStyle="Solid" BorderWidth="3" BorderColor="#004040" ScrollBars="None">
                <table width="500px">
                    <tr>
                        <td style="padding-top: 10px; padding-left: 22px; font-weight: bold;">Term and Condition's -
                        </td>
                    </tr>
                    <tr>
                        <td style="padding-top: 10px; padding-left: 20px; font-weight: bold;">1. Renewal Registration Fees is Rs.15
                        </td>
                    </tr>
                    <tr>
                        <td style="padding-top: 10px; padding-left: 20px; font-weight: bold;">2. Renewal Service Charge is Rs.1000
                        </td>
                    </tr>
                    <tr>
                        <td style="padding-top: 20px;" align="center">
                            <a href="#" class="btn" data-reveal-id="myModal4" style="font-weight: normal;">Accept & Proceed</a>
                            &nbsp;&nbsp;
                        <asp:Button ID="Button2" runat="server" Text="Cancel" Width="100" CssClass="btn"
                            OnClientClick="return PopupCancelRenew();" />
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </div>

        <div id="divTransReg" runat="server" style="display: none; width: 70%; position: absolute; padding-left: 30%; padding-top: 20%">
            <asp:Panel ID="Panel2" runat="server" BackColor="#FFFFFF" Height="180px"
                Width="500px" BorderStyle="Solid" BorderWidth="3" BorderColor="#004040" ScrollBars="None">
                <table width="500px">
				<%--<tr>
					<td style="padding-top: 10px; padding-left: 22px; font-weight: bold;">Fill the NOC form and submit it manually to MPSVC Office
					</td>
				</tr>
				<tr>
					<td style="padding-top: 10px; padding-left: 22px; font-weight: bold;"><a href="../Upload_Certificate/New_NOC_Forms.pdf" target="_blank">Click here to Download NOC Forms</a>
					</td>
				</tr>
				<tr>
					<td style="padding-top: 10px; padding-left: 22px; font-weight: bold;">
						<a href="RegistrationLinkNew.aspx" class="btn btn-primary pull-right">Clear</a>
					</td>
				</tr>--%>
				<tr>
					<td style="padding-top: 10px; padding-left: 22px; font-weight: bold;">Term and Condition's -
					</td>
				</tr>
				<tr>
					<td style="padding-top: 10px; padding-left: 20px; font-weight: bold;">2. Transfer registration fees is Rs.15
					</td>
				</tr>
				<tr>
					<td style="padding-top: 20px;" align="center">
						<a href="#" class="btn" data-reveal-id="myModal3" style="font-weight: normal;">Accept & Proceed</a>
						&nbsp;&nbsp;
				<asp:Button ID="Button4" runat="server" Text="Cancel" Width="100" CssClass="btn"
				OnClientClick="return PopupCancelTrans();" />
					</td>
				</tr>
                </table>
            </asp:Panel>
        </div>

        <div id="divDuplicateCertificate" runat="server" style="display: none; width: 70%; position: absolute; padding-left: 30%; padding-top: 20%">
            <asp:Panel ID="Panel3" runat="server" BackColor="#FFFFFF" Height="220px"
                Width="500px" BorderStyle="Solid" BorderWidth="3" BorderColor="#004040" ScrollBars="None">
                <table width="500px">
                    <tr>
                        <td style="padding-top: 10px; padding-left: 22px; font-weight: bold;">Term and Condition's -
                        </td>
                    </tr>
                     <tr>
                        <td style="padding-top: 10px; padding-left: 20px; font-weight: bold;">1. Duplicate id card fees is Rs. 50
                        </td>
                    </tr>
                   <%-- <tr>
                        <td style="padding-top: 10px; padding-left: 20px; font-weight: bold;">1. Duplicate id card fees is Rs. 550
                        </td>
                    </tr>--%>
                    <tr>
                        <td style="padding-top: 10px; padding-left: 20px; font-weight: bold;">2. Duplicate Certificate Fees is Rs. 510
                        </td>
                    </tr>
                    <tr>
                        <td style="padding-top: 20px;" align="center">
                            <a href="#" class="btn" data-reveal-id="myModal5" style="font-weight: normal;">Accept & Proceed</a>
                            &nbsp;&nbsp;
                        <asp:Button ID="Button1" runat="server" Text="Cancel" Width="100" CssClass="btn"
                            OnClientClick="return PopupCancelDuplicate();" />
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </div>

        <div id="divQualification" runat="server" style="display: none; width: 70%; position: absolute; padding-left: 30%; padding-top: 20%">
            <asp:Panel ID="Panel4" runat="server" BackColor="#FFFFFF" Height="220px"
                Width="500px" BorderStyle="Solid" BorderWidth="3" BorderColor="#004040" ScrollBars="None">
                <table width="500px">
                    <tr>
                        <td style="padding-top: 10px; padding-left: 22px; font-weight: bold;">Term and Condition's -
                        </td>
                    </tr>
                    <tr>
                        <td style="padding-top: 10px; padding-left: 20px; font-weight: bold;">1. Update qualification fees is Rs. 10
                        </td>
                    </tr>
                    <tr>
                        <td style="padding-top: 20px;" align="center">
                            <a href="#" class="btn" data-reveal-id="myModal6" style="font-weight: normal;">Accept & Proceed</a>
                            &nbsp;&nbsp;
                        <asp:Button ID="Button3" runat="server" Text="Cancel" Width="100" CssClass="btn"
                            OnClientClick="return PopupCancelQualification();" />
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </div>



        <div class="top-bar" id="changeFont">
            <a href="#wrapper" title="Skip to main content">Skip to main content / Screen Reader
            Access</a> &nbsp; <a href="#" class="resetFont">A</a> <a href="#" class="increaseFont">A<sup>+</sup></a> <a href="#" class="increaseFont2"><b>A<sup>+</sup></b></a>
            &nbsp; <a href="#" class="whtbg">A</a> <a href="#" class="blkbg">A</a>
            <img src="images/top-icon.png" border="0" usemap="#Map" />
            <map name="Map">
                <area shape="rect" coords="0,1,12,12" title="Home" href="#">
                <area shape="rect" coords="28,1,40,12" href="#">
                <area shape="rect" coords="54,1,65,12" title="Contact Us" href="#">
            </map>
            <span class="ML12" id="menu">English
            <div class="flyout">
                <a href="#">Hindi</a><br>
                <a href="#">English</a>
            </div>
            </span>
        </div>

        <div class="wrapper" id="wrapper">
			<a href="index.aspx">
				<img style="width: 100%;" src="images/header.jpg" />
			</a>
            <div class="CL">
            </div>
            <div class="menu">
                <ul>
                    <li class="active"><a href="index.aspx" title="Home">Home</a></li>
                    <li><a title="About Us" href="#">About Us</a>
                        <ul>
                            <li><a href="StateVeterinaryCouncil.html">Present Council</a></li>
                            <!--<li><a href="OfficialBearers.html">Official Bearers</a></li>-->
                            <li><a href="SubCommittees.html">Sub Committees</a></li>
                        </ul>
                    </li>
                    <li><a title="Act &amp; Rules" href="#">Act &amp; Rules</a>
                        <ul>
                            <li><a href="Act_Rules.html">Council</a></li>
                            <li><a href="#">Others</a></li>
                        </ul>
                    </li>
                    <!--<li><a href="#" title="MPVPR">MPVPR</a></li>-->
                    <li><a href="AnnualReport.html" title="Annual Report">Annual Report</a></li>
                    <li><a href="PhotoGallery.html" title="Photo Gallery">Photo Gallery</a></li>
                    <li><a href="contectus.html" title="Contct Us" class="last">Contact Us</a></li>
                    <li><a title="help" href="help.html">help </a></li>
                    <li><a title="help" href="Login.aspx">Login </a></li>
                </ul>
                <div class="CL">
                </div>
            </div>
            <div class="MT10">
                <!-- Breadcrumb Example Here -->
                <div id="breadcrumb">
                    <ul class="crumbs">
                        <li><a href="#" class="first">Home</a></li>
                        <li>Registration</li>
                    </ul>
                </div>
            </div>
            <div class="MT20" style="min-height: 500px;">
                <div id="about-content" class="col-sm-8">
                    <h2>
                        <strong>Online Registration</strong></h2>
                    <div style="text-align: center">
                        <div class="col-sm-4 text-center blue">
                            <a href="#" class="big-link" style="font-weight: normal;" onclick="return PopTemAndConditionProvisional();">
                                <div class="thumbnail">
                                    <span style="font-size: 60px; padding-top: 5px;" class="fa fa-pencil-square-o"></span>
                                    <h5>Provisional Registration</h5>
                                </div>
                                <!--thumbnail-->
                            </a>
                        </div>
                        <!--col-sm-2-->
                        <div class="col-sm-4 text-center green">
                            <a href="#" class="big-link" style="font-weight: normal;" onclick="return PopTemAndCondition();">
                                <div class="thumbnail">
                                    <span style="font-size: 60px; padding-top: 5px;" class="fa fa-pencil-square-o"></span>
                                    <h5>New Registration/Transfer In M.P.</h5>
                                </div>
                                <!--thumbnail-->
                            </a>
                        </div>
                        <div class="col-sm-4 text-center yello">
                            <a href="#" class="big-link" style="font-weight: normal;" onclick="return PopTemAndConditionRenew();">
                                <div class="thumbnail">
                                    <span style="font-size: 60px; padding-top: 5px;" class="fa fa-pencil-square-o"></span>
                                    <h5>Renewal Registration</h5>
                                </div>
                                <!--thumbnail-->
                            </a>
                        </div>
                        <!--col-sm-2-->
                        <div class="CL">
                        </div>

                        <!--col-sm-2-->
                        <div class="col-sm-4 text-center orange">
                            <a href="TransferRegistrationoutofMP.aspx" class="big-link" style="font-weight: normal;" onclick="return PopTemAndConditionTrans();">
                                <div class="thumbnail">
                                    <span style="font-size: 60px; padding-top: 5px;" class="fa fa-pencil-square-o"></span>
                                    <h5>Transfer out of M.P.</h5>
                                </div>
                                <!--thumbnail-->
                            </a>
                        </div>
                        <!--col-sm-2-->
                        <div class="col-sm-4 text-center Purple">
                            <a href="#" class="big-link" style="font-weight: normal;" onclick="return PopTemAndConditionDuplicate();">
                                <div class="thumbnail">
                                    <span style="font-size: 60px; padding-top: 5px;" class="fa fa-pencil-square-o"></span>
                                    <h5>Duplicate Certificate</h5>
                                </div>
                                <!--thumbnail-->
                            </a>
                        </div>

                        <div class="col-sm-4 text-center Rose">
                            <a href="#" class="big-link" style="font-weight: normal;" onclick="return PopTemAndConditionQualification();">
                                <div class="thumbnail">
                                    <span style="font-size: 60px; padding-top: 5px;" class="fa fa-pencil-square-o"></span>
                                    <h5>Addition of Qualification</h5>
                                </div>
                                <!--thumbnail-->
                            </a>
                        </div>
						<%--START HERE_ Comment by bhanu on 23 APR 2022 As per Change Request --%>
						 <!--New Link Complaint Registration-->
						<%-- <div class="col-sm-4 text-center green">
                            <a href="ComplaintRegistration.aspx" class="big-link" style="font-weight: normal;">
                                <div class="thumbnail">
                                    <span style="font-size: 60px; padding-top: 5px;" class="fa fa-pencil-square-o"></span>
                                    <h5>Complaint Registration</h5>
                                </div>
                                <!--thumbnail-->
                            </a>
                        </div>--%>
                        <%-- END HERE_ Comment by bhanu on 23 APR 2022 As per Change Request--%>
                         <div class="col-sm-4" style="border:none;"></div>
                         <div class="col-sm-4" style="border:none;"></div>

                    </div>
                </div>
            </div>
            <div>
                Note* : In case your mobile no, email id is not registered <asp:HyperLink ID="HyperLink2" runat="server" Font-Underline="True" ForeColor="#0066FF" NavigateUrl="~/frm_userupdateddetails.aspx"> click here to update information</asp:HyperLink> .
            </div>
        </div>
        <div class="ftr_logo">
            <a href="http://india.gov.in" target="_blank">
                <img src="images/india_gov_logo.jpg" alt="National Portal of India" title="National Portal of India" /></a>
            <a href="http://mygov.in" target="_blank">
                <img src="images/my_gov_logo.jpg" alt="My Gov" title="My Gov" /></a>
        </div>
        <div id="myModal" class="reveal-modal">
            <h1>Provisional Registration</h1>
            <ul class="list">
                <li><a href="ProvisionalRegistration.aspx"><i class="fa fa-level-down"></i>
                    <br>
                    Online Form</a></li>
                <li><a href="Provisional_Registration.pdf" target="_blank"><i class="fa fa-level-up"></i>
                    <br>
                    Offline Form</a></li>
            </ul>
            <a class="close-reveal-modal">&#215;</a>
        </div>
        <div id="myModal2" class="reveal-modal" runat="server">
            <h1>New Registration</h1>
            <ul class="list">
                <li><a href="Newregistration.aspx"><i class="fa fa-level-down"></i>
                    <br>
                    Online Form</a></li>
                <li><a href="Registration_Form.pdf" target="_blank"><i class="fa fa-level-up"></i>
                    <br>
                    Offline Form</a></li>
            </ul>
            <a class="close-reveal-modal">&#215;</a>
        </div>
        <div id="myModal3" class="reveal-modal">
            <h1>Transfer out of M.P.</h1>
            <ul class="list">
                <%-- <li><a href="TransferRegistration.aspx"><i class="fa fa-level-down"></i>old page--%>
                   
                   <li><a href="TransferRegistrationoutofMP.aspx"><i class="fa fa-level-down"></i>
                    <br>
                    Online Form</a></li>
                 <%--  <li><a href="Transfer_For_Registration.pdf" target="_blank"><i class="fa fa-level-up"></i>old Pdf--%>
                <li><a href="New_NOC_Forms.pdf" target="_blank"><i class="fa fa-level-up"></i>
                    <br>
                    Offline Form</a></li>
            </ul>
            <a class="close-reveal-modal">&#215;</a>
        </div>
        <div id="myModal4" class="reveal-modal">
            <h1>Renewal Registration</h1>
            <ul class="list">
                <li><a href="RenewRegistration.aspx"><i class="fa fa-level-down"></i>
                    <br>
                    Online Form</a></li>
                <li><a href="Renewal_Registration.PDF" target="_blank"><i class="fa fa-level-up"></i>
                    <br>
                    Offline Form</a></li>
            </ul>
            <a class="close-reveal-modal">&#215;</a>
        </div>
        <div id="myModal5" class="reveal-modal">
            <h1>Duplicate Certificate</h1>
            <ul class="list">
                <li><a href="DuplicateCertificate.aspx"><i class="fa fa-level-down"></i>
                    <br>
                    Online Form</a></li>
                <li><a href="Registration_Form.PDF" target="_blank"><i class="fa fa-level-up"></i>
                    <br>
                    Offline Form</a></li>
            </ul>
            <a class="close-reveal-modal">&#215;</a>
        </div>
        <div id="myModal6" class="reveal-modal">
            <h1>Update Qualification</h1>
            <ul class="list">
                <li><a href="UpdateQualification.aspx"><i class="fa fa-level-down"></i>
                    <br>
                    Online Form</a></li>
                <li><a href="Registration_Form.PDF" target="_blank"><i class="fa fa-level-up"></i>
                    <br>
                    Offline Form</a></li>
            </ul>
            <a class="close-reveal-modal">&#215;</a>
        </div>
        
        <div class="footer">
            <div class="footer-cnt">
                <div class="FL">
                    <p class="footer-links">
                        <a class="text-uppercase" href="Disclaimer.html">Disclaimer</a> | <a class="text-uppercase"
                            href="PrivacyPolicy.html">Privacy Policy</a> | <a class="text-uppercase" href="Refund.html">Refund / Cancellation Policy</a> | <a class="text-uppercase" href="TermsandConditions.html">Terms &amp; Conditions</a>
                    </p>
                </div>
                <div class="FR" style="text-align: right;">
                    2015 � Content Owned by Madhya Pradesh State Veterinary Council.<br>
                    Powered By : SFA Technologies
                </div>
                <div class="CL">
                </div>
            </div>
        </div>


        <script type="text/javascript" src="js/jquery.min.js"></script>

        <script type="text/javascript" src="js/jquery-1.6.1.min.js"></script>

        <script type="text/javascript" src="js/jquery.reveal.js"></script>

        <script type="text/javascript" src="js/news.js"></script>

        <script type="text/javascript" language="javascript">


            $(document).ready(function () {
                // Reset Font Size
                var originalFontSize = $('html').css('font-size');
                $(".resetFont").click(function () {
                    $('html').css('font-size', originalFontSize);
                });
                // Increase Font Size
                $(".increaseFont").click(function () {
                    var currentFontSize = $('html').css('font-size');
                    var currentFontSizeNum = parseFloat(currentFontSize, 10);
                    var newFontSize = 13;
                    $('html').css('font-size', newFontSize);
                    return false;
                });

                $(".increaseFont2").click(function () {
                    var currentFontSize = $('html').css('font-size');
                    var currentFontSizeNum = parseFloat(currentFontSize, 10);
                    var newFontSize = 14;
                    $('html').css('font-size', newFontSize);
                    return false;
                });
            });
            $(document).ready(function () {
                $("#breakingnews1").BreakingNews();

                $("#breakingnews2").BreakingNews({
                    background: '#e9e9df',
                    //title			:'NEWS',
                    //titlecolor		:'#FFF',
                    titlebgcolor: '#01baf2',
                    linkcolor: '#0f0f0f',
                    linkhovercolor: '#01baf2',
                    fonttextsize: 14,
                    isbold: false,
                    //border			:'solid 1px #099',
                    width: '100%',
                    timer: 2000,
                    autoplay: true,
                    effect: 'slide'

                });

                $('#apply').click(function (e) {
                    addValues();
                });
                addValues();
            });

            $(window).load(function () {

                $('#slider').nivoSlider();

            });

            $('.popup-opener').bind('click', function (e) {
                e.preventDefault();
                $($(this).attr('popup-element')).bPopup();
            });

            $("#menu").click(function () {

                $(".flyout").toggle();

            });
        </script>

        <script type="text/javascript">
            (function (jQuery) {
               
                $.fn.BreakingNews = function (settings) {
                    var defaults = {
                        background: '#FFF',
                        //title			:'NEWS',
                        //titlecolor		:'#FFF',
                        //titlebgcolor	:'#5aa628',
                        linkcolor: '#333',
                        linkhovercolor: '#5aa628',
                        fonttextsize: 14,
                        isbold: false,
                        border: 'none',
                        width: '100%',
                        autoplay: true,
                        timer: 3000,
                        modulid: 'brekingnews',
                        effect: 'fade'	//or slide	
                    };
                    var settings = $.extend(defaults, settings);

                    return this.each(function () {
                        settings.modulid = "#" + $(this).attr("id");
                        var timername = settings.modulid;
                        var activenewsid = 1;

                        if (settings.isbold == true)
                            fontw = 'bold';
                        else
                            fontw = 'normal';

                        if (settings.effect == 'slide')
                            $(settings.modulid + ' ul li').css({ 'display': 'block' });
                        else
                            $(settings.modulid + ' ul li').css({ 'display': 'none' });

                        $(settings.modulid + ' .bn-title').html(settings.title);
                        $(settings.modulid).css({ 'width': settings.width, 'background': settings.background, 'border': settings.border, 'font-size': settings.fonttextsize });
                        $(settings.modulid + ' ul').css({ 'left': $(settings.modulid + ' .bn-title').width() + 40 });
                        $(settings.modulid + ' .bn-title').css({ 'background': settings.titlebgcolor, 'color': settings.titlecolor, 'font-weight': fontw });
                        $(settings.modulid + ' ul li a').css({ 'color': settings.linkcolor, 'font-weight': fontw, 'height': parseInt(settings.fonttextsize) + 6 });
                        $(settings.modulid + ' ul li').eq(parseInt(activenewsid - 1)).css({ 'display': 'block' });

                        // Links hover events ......
                        $(settings.modulid + ' ul li a').hover(function () {
                            $(this).css({ 'color': settings.linkhovercolor });
                        },
                            function () {
                                $(this).css({ 'color': settings.linkcolor });
                            }
                        );


                        // Arrows Click Events ......
                        $(settings.modulid + ' .bn-arrows span').click(function (e) {
                            if ($(this).attr('class') == "bn-arrows-left")
                                BnAutoPlay('prev');
                            else
                                BnAutoPlay('next');
                        });

                        // Timer events ...............
                        if (settings.autoplay == true) {
                            timername = setInterval(function () { BnAutoPlay('next') }, settings.timer);
                            $(settings.modulid).hover(function () {
                                clearInterval(timername);
                            },
                                function () {
                                    timername = setInterval(function () { BnAutoPlay('next') }, settings.timer);
                                }
                            );
                        }
                        else {
                            clearInterval(timername);
                        }

                        //timer and click events function ...........
                        function BnAutoPlay(pos) {
                            if (pos == "next") {
                                if ($(settings.modulid + ' ul li').length > activenewsid)
                                    activenewsid++;
                                else
                                    activenewsid = 1;
                            }
                            else {
                                if (activenewsid - 2 == -1)
                                    activenewsid = $(settings.modulid + ' ul li').length;
                                else
                                    activenewsid = activenewsid - 1;
                            }

                            if (settings.effect == 'fade') {
                                $(settings.modulid + ' ul li').css({ 'display': 'none' });
                                $(settings.modulid + ' ul li').eq(parseInt(activenewsid - 1)).fadeIn();
                            }
                            else {
                                $(settings.modulid + ' ul').animate({ 'marginTop': -($(settings.modulid + ' ul li').height() + 20) * (activenewsid - 1) });
                            }
                        }

                        // links size calgulating function ...........
                        $(window).resize(function (e) {
                            if ($(settings.modulid).width() < 360) {
                                $(settings.modulid + ' .bn-title').html('&nbsp;');
                                $(settings.modulid + ' .bn-title').css({ 'width': '4px' });
                                $(settings.modulid + ' ul').css({ 'left': 4 });
                            } else {
                                $(settings.modulid + ' .bn-title').html(settings.title);
                                $(settings.modulid + ' .bn-title').css({ 'width': 'auto' });
                                $(settings.modulid + ' ul').css({ 'left': $(settings.modulid + ' .bn-title').width() + 40 });
                            }
                        });
                    });

                };

            })(jQuery);

           

            //jQuery(document).ready(function () {
            //    alert('ggg');
            //    jQuery('.hidesidebar').hide();

            //});

            function GiveAlert() {
                alert(document.getElementById('HF_Msg').value);
            }

        </script>
        <%--<asp:Button CssClass="" ID="btnSearch" runat="server" Text="Button" OnClick="btnSearch_Click" />--%>
        <asp:HiddenField ID="HF_Reg" runat="server" />
          <asp:HiddenField ID="HF_Name" runat="server" />
          <asp:HiddenField ID="HF_Mob" runat="server" />
          <asp:HiddenField ID="HF_Email" runat="server" />
          <asp:HiddenField ID="HF_DOB" runat="server" />
        <asp:HiddenField ID="HF_Msg" runat="server" />
    </form>
</body>
</html>
