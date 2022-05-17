<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ComplaintStatus.aspx.cs" Inherits="ComplaintStatus" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta name="description" content="" />
    <meta name="author" content="" />
    <link rel="shortcut icon" href="images/favicon.ico" type="image/x-icon" />
    <title>Madhya Pradesh State Veterinary Council</title>
    <link href="css/style.css" rel="stylesheet" type="text/css" />
    <link href="css/MyStyle.css" rel="stylesheet" />
    <link href="css/style.css" rel="stylesheet" />
    <link href="css/bootstrap.min.css" rel="stylesheet" />
    <link href="css/news.css" rel="stylesheet" type="text/css" />
    <link href="css/slider.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.2/js/bootstrap.min.js"></script>
    <link rel="stylesheet" href="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.2/css/bootstrap.min.css" />
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.9.1/jquery.min.js"></script>
    <style>
        .fildset {
            border: 2px solid;
            border-color: black;
        }

        .tableset {
            margin-top: 20px;
            margin-bottom: 10px;
            margin-left: 20px;
        }

        table td {
            padding: 5px;
        }

        table th {
            padding: 5px;
            font-weight: bold;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
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
                    <li><a href="NewRegistration.aspx" title="ComplaintStatus">Registraion</a></li>
                    <%--<ul>
                            <li><a href="StateVeterinaryCouncil.html">State Veterinary Council </a></li>
                            <li><a href="OfficialBearers.html">Official Bearers</a></li>
                            <li><a href="SubCommittees.html">Sub Committees</a></li>
                        </ul>--%>
                    <%-- </li>--%>
                    <%--<li><a href="#" title="Act & Rules">Act & Rules</a>
                        <ul>
                            <li><a href="Act_Rules.html">Council</a></li>
                            <li><a href="#">General</a></li>
                        </ul>
                    </li>--%>
                    <%--<li><a href="#" title="MPVPR">MPVPR</a></li>
                    <li><a href="#" title="CVE">CVE</a></li>
                    <li><a href="PhotoGallery.html" title="Photo Gallery">Photo Gallery</a></li>
                    <li><a href="contectus.html" title="Contct Us" class="last">Contact Us</a></li>--%>
                </ul>
                <div class="CL">
                </div>
            </div>
            <%-- <div class="MT10">
                <!-- Breadcrumb Example Here -->
                <div id="breadcrumb">
                    <ul class="crumbs">
                        <li><a href="#" class="first">Home</a></li>
                        <li>Login</li>
                    </ul>
                </div>
            </div>--%>
            <div class="MT20" style="min-height: 500px;">
                <div class="MT20">
                    <%--<b>Member Login</b>--%>
                    <asp:Label ID="lblMsg" runat="server"></asp:Label>

                    <div class="row">
                        <div class="col-md-6">
                            <table style="width: 100%;" class="tableset">
                                <tr>
                                    <td colspan="7">
                                        <strong>Check your Status </strong>
                                    </td>
                                </tr>
                                <tr>
                                    <td></td>
                                </tr>
                                <tr>
                                    <td>Complaint No :<span style="color: red"><b> *</b></span></td>
                                    <td>
                                        <%--<div class="col-md-3">
                                            <div class="form-group">--%>
                                        <asp:TextBox ID="txtcomplaintno" runat="server" CssClass="form-control"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="rfvComplaintnant" runat="server" ControlToValidate="txtcomplaintno" ForeColor="Red" Font-Bold="true" Font-Size="Small" ErrorMessage="Mandatory Field" ValidationGroup="Search"></asp:RequiredFieldValidator>
                                        <%-- </div> 
                                        </div>--%>
                                    </td>
                                    <td>Mobile No :<span style="color: red"><b> *</b></span></td>
                                    <td>
                                        <%--  <div class="col-md-3">
                                            <div class="form-group">--%>
                                        <asp:TextBox ID="txtmobileno" runat="server" CssClass="form-control"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="rfvMobileno" runat="server" ControlToValidate="txtmobileno" ForeColor="Red" Font-Bold="true" Font-Size="Small" ErrorMessage="Mandatory Field" ValidationGroup="Search"></asp:RequiredFieldValidator>
                                        <%-- </div>
                                        </div>--%>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div class="form-group">
                            <asp:Button ID="btnSearch" runat="server" Text="Search" Style="margin-top: 64px" ValidationGroup="Search" CssClass="btn btn-primary" OnClick="btnSearch_Click" />
                            <a href="ComplaintStatus.aspx" style="margin-top: 64px" class="btn btn-warning">Reset</a>
                        </div>

                    </div>

                    <%-- <div class="row tableset" style="margin-top:50px">
                        <div class="col-md-3">
                            <div class="form-group">
                                <label>Number:</label>
                                <asp:TextBox ID="tstnum" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                         <div class="col-md-3">
                            <div class="form-group">
                                <label>email:</label>
                                <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Button ID="btnsubmit" runat="server" CssClass="btn" Text="Submit" Style="margin-top:20px"/>
                        </div>
                    </div>--%>
                    <div class="row">
                        <div class="col-md-6">
                            <asp:DetailsView ID="dtlcomplaitnant" HeaderText="शिकायतकर्ता की जानकारी" runat="server" BorderWidth="1px" Height="50px" Width="100%" DataKeyNames="ComplainantID" AutoGenerateRows="false">
                                <FieldHeaderStyle BackColor="#d7d7db" ForeColor="#1a0b0b" />
                                <HeaderStyle ForeColor="#e9cc9a" BackColor="#3e3e25" Font-Names="Arial" Font-Size="10" Font-Bold="true" />
                                <Fields>
                                    <asp:BoundField HeaderText="शिकायत क्रमांक" DataField="ComplaintNo" />
                                    <asp:BoundField HeaderText="शिकायत की तारीख" DataField="complaintDate" />
                                    <asp:BoundField HeaderText="शिकायतकर्ता का नाम" DataField="NameOfComplainant" />
                                    <asp:BoundField HeaderText="शिकायतकर्ता के पिता का नाम" DataField="FatherHusbandName" />
                                    <asp:BoundField HeaderText="लिंग" DataField="GenderOfComplainant" />
                                    <asp:BoundField HeaderText="मोबाइल नंबर" DataField="MobileNoOfComplainant" />
                                    <asp:BoundField HeaderText="ईमेल" DataField="EmailOfComplainant" />
                                    <asp:BoundField HeaderText="शिकायतकर्ता की पहचान का प्रकार" DataField="Identity_Type" />
                                    <asp:BoundField HeaderText="शिकायतकर्ता का पहचान क्रंमाक" DataField="AadharNo" />
                                    <asp:BoundField HeaderText="शिकायतकर्ता का का पूरा पता" DataField="AddressOfComplainant" />
                                    <asp:TemplateField HeaderText="शिकायतकर्ता  के पहचान दस्तावेज">
                                        <ItemTemplate>
                                            <asp:HyperLink ID="hyperIdentityDOC" runat="server" Target="_blank" CssClass="label label-primary" Text="View" NavigateUrl='<%# Eval("Identity_Document") %>'></asp:HyperLink>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Fields>
                            </asp:DetailsView>
                        </div>
                        <div class="col-md-6">
                            <asp:DetailsView ID="dtlagainstofComplaint" runat="server" Width="100%" HeaderText="जिसके बिरुद्ध शिकायत की गई उसकी जानकारी" Height="50px" AutoGenerateRows="false" BorderWidth="1px">
                                <FieldHeaderStyle BackColor="#d7d7db" ForeColor="#1a0b0b" />
                                <HeaderStyle ForeColor="#e9cc9a" BackColor="#3e3e25" Font-Names="Arial" Font-Size="10" Font-Bold="true" />
                                <Fields>
                                    <asp:BoundField HeaderText="जिसके विरुद्ध शिकायत की जा रही है उसका नाम" DataField="NameAgainstComplaint" />
                                    <asp:BoundField HeaderText="मोबाइल नं" DataField="MobileNoAgainstComplaint" />
                                    <asp:BoundField HeaderText="क्या वह रजिस्टर्ड डॉक्टर है" DataField="RegistrationType" />
                                     <asp:BoundField HeaderText="डॉक्टर का रजिस्ट्रेशन नंबर" DataField="RegistraionNumberAgainstComplaint" />
                                    <asp:BoundField HeaderText="ईमेल आईडी" DataField="EmailofAgainstComplaint" />
                                    <asp:BoundField HeaderText="घर का पता" DataField="ResidentialAddressofAgainstCompalint" />
                                    <asp:BoundField HeaderText="राज्य पशु चिकित्सा परिषद का नाम" DataField="StateVerinaryCouncilName" />
                                    <asp:BoundField HeaderText="शिकायत का प्रकार" DataField="ComplaintType" />
                                    <asp:BoundField HeaderText="पशु/पक्षी का प्रकार" DataField="TypeOfAnimal" />
                                    <asp:BoundField HeaderText="पशु की उम्र" DataField="AgeOfAnimal" />
                                     <asp:BoundField HeaderText="घटना का स्थान" DataField="PlaceOfEvent" />
                                    <asp:BoundField HeaderText="पशु चिकित्सक के अस्पताल का पता" DataField="HospitalAddress" />
                                    <asp:BoundField HeaderText="शिकायत का संक्षिप्त विवरण" DataField="DetailOfComplaint" />                                                               
                                    <asp:TemplateField HeaderText="दस्तावेज़">
                                        <ItemTemplate>
                                            <asp:HyperLink ID="hyperDoc1" runat="server" Target="_blank" CssClass="label label-primary" Text="View" NavigateUrl='<%# Eval("FU_Doc1") %>'></asp:HyperLink>&nbsp&nbsp
                                            <asp:HyperLink ID="hyperDoc2" runat="server" Target="_blank" CssClass="label label-primary" NavigateUrl='<%# Eval("FU_Doc2") %>' Text="View"></asp:HyperLink>
                                            <asp:HyperLink ID="hyperComplaintDoc1" Target="_blank" runat="server" CssClass="label label-primary" NavigateUrl='<%# Eval("Complaint_Documnet1") %>' Text="View"></asp:HyperLink>
                                            <asp:HyperLink ID="hypercomplaintDoc2" Target="_blank" runat="server" CssClass="label label-primary" NavigateUrl='<%# Eval("Complaint_Documnet2") %>' Text="View"></asp:HyperLink>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <%--<asp:BoundField HeaderText="शिकायत की स्थिति" DataField="FStatus" ItemStyle-ForeColor="YellowGreen" />--%>
                                    <asp:TemplateField HeaderText="शिकायत की स्थिति">
                                        <ItemTemplate>
                                            <%--<span style="color: <%# (Eval("FStatus").ToString() == "Closed") ? "green" : "red;" %>; font-weight: bold"><%# Eval("FStatus") %></span>--%>
                                            <asp:Label ID="lblComplaintStatus" runat="server" Font-Bold="true" CssClass='<%# Eval("FStatus") %>'><%# Eval("FStatus") %></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Fields>
                            </asp:DetailsView>
                        </div>
                    </div>
                    &nbsp&nbsp&nbsp&nbsp
                  <%--  <div id="StrFeedback" runat="server">--%> <%-- Comment on 6-may-2022 by bhnau As per Change Request. --%>
                    <%--  <div class="row">
                        <div class="col-md-6">
                    --%>
                    <%-- <div  class="table-responsive">
                                <asp:DetailsView ID="Dtlfeedback" runat="server" headertext="निराकरण अधिकारी द्वारा की गई कार्यवाही " AutoGenerateRows="false" BorderWidth="1px" Width="100%" Height="50px">
                                   <FieldHeaderStyle BackColor="#d7d7db" ForeColor="#1a0b0b" />
                                <HeaderStyle ForeColor="#e9cc9a" BackColor="#3e3e25" Font-Names="Arial" Font-Size="10" Font-Bold="true" />
                                    <Fields>
                                        <asp:BoundField HeaderText="FeedBack" DataField="Feedback" />
                                        <asp:TemplateField HeaderText="दस्तावेज़">
                                            <ItemTemplate>
                                                <asp:HyperLink ID="hyperSolutionDoc" runat="server" Target="_blank" CssClass="label label-primary" Text="View" NavigateUrl='<%# Eval("FeedbackDocument") %>'></asp:HyperLink>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                       
                                    </Fields>
                                </asp:DetailsView>
                            </div>  --%>
                    <%--  </div>
                    </div>--%>
                    <%--</div>--%> <%-- Comment on 6-may-2022 by bhnau As per Change Request. --%>
                    <div class="row" id="FeedbackByAdmin" runat="server">
                        <div class="col-md-12">
                            <h4 style="color: #4269c1">निराकरण अधिकारी द्वारा की गई कार्यवाही</h4>
                            <div class="table-responsive">
                                <asp:GridView ID="grdLastFeedback" runat="server" HeaderStyle-BackColor="#3e3e25" HeaderStyle-ForeColor="#e9cc9a" AllowPaging="true" AutoGenerateColumns="false" EmptyDataText="NO RECORD FOUND">
                                    <Columns>
                                        <asp:TemplateField HeaderText="S.No.">
                                            <ItemTemplate>
                                                <asp:Label ID="lblID" runat="server" Text='<%# Container.DataItemIndex + 1 %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField HeaderText="FeedBack Date" DataField="LastFeedBack_Date" />
                                        <asp:BoundField HeaderText="FeedBack" DataField="Feedback" />                                       
                                        <asp:TemplateField HeaderText="Documents">
                                            <ItemTemplate>
                                                <asp:HyperLink ID="hyperLastfeedbackDoc" Text="view" Target="_blank" runat="server" CssClass="label label-primary" NavigateUrl='<%# Eval("Feedback_Documnet") %>'></asp:HyperLink>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="ftr_logo">
            <a href="http://india.gov.in" target="_blank">
                <img src="images/india_gov_logo.jpg" alt="National Portal of India" title="National Portal of India" /></a>
            <a href="http://mygov.in" target="_blank">
                <img src="images/my_gov_logo.jpg" alt="My Gov" title="My Gov" /></a>
        </div>
        <div class="footer">
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
        <script src="js/jquery.min.js"></script>
        <script src="js/jquery-1.6.1.min.js"></script>
        <script src="js/jquery.reveal.js"></script>
    </form>
</body>
</html>
