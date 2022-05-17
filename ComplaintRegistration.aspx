<%@ Page Title="" Language="C#" MasterPageFile="~/AdminSection/MasterPage.master" AutoEventWireup="true" CodeFile="ComplaintRegistration.aspx.cs" Inherits="ComplaintRegistration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js" type="text/javascript"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js" type="text/javascript"></script>

    <script type="text/javascript">

        function PopOTPVerification() {
            document.getElementById('<%=divOTP.ClientID%>').style.display = "block";
            return false;
        }
        function PopOTPNotVerified() {
            document.getElementById('<%=divOTP.ClientID%>').style.display = "none";
            return true;
        }

        function MessageVerify() {
            alert("Application forwarded successfully");
        }

        <%--function dropddl() {  // Show Hide textbox/div with thise function 
            if (document.getElementById('<%=ddlPersonalID.ClientID%>').value = "2") {
                document.getElementById('<%=txtAadharNo.ClientID%>').style.display = "block";
            }
        }--%>

    </script>

    <style>
        fieldset {
            border: 1px solid #01baf2;
            padding: 10px;
            margin-bottom: 10px;
            width: 100%;
        }

        legend {
            display: block;
            white-space: normal;
            width: initial;
            padding: 5px 15px;
            margin: 0;
            font-size: 12px;
            color: #011ff2;
            text-transform: uppercase;
            /*background-color: #d72d4c;*/
            border: 1px solid #01baf2;
            font-weight: 600;
        }


        .form-control {
            width: 100% !important;
        }

        .NonPrintable {
            display: none;
        }

        * .header {
            display: table-header-group;
        }

        @media print {
            .NonPrintable {
                display: block;
            }

            .footer {
                display: none;
            }

            .ftr_logo {
                display: none;
            }

            .menu {
                display: none;
            }

            .title {
                display: none;
            }

            .CL {
                display: none;
            }

            .noprint {
                display: none;
            }

            .crumbs {
                display: none;
            }

            .img {
                display: none;
            }

            .print {
                display: none;
            }
        }

        .printtd {
            font-weight: bold;
        }
    </style>

    <div class="container noprint">
        <div class="row ">
            <h5><b style="font-weight: bold; color: red">नोट-: शिकायत की जानकारी का विवरण देखने के लिये शिकायत क्रमांक दर्ज करके रखे |</b></h5>
        </div>
        <div class="row">
            <div class="col-md-12">
                <h3><b>शिकायत पंजीकरण</b></h3>
                <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
            </div>
        </div>
        <div id="hideotp" runat="server">
            <div class="row">
                <div class="col-md-2">
                    <div class="form-group">
                        <label>Mobile No.</label>
                        <asp:TextBox ID="txtMobileNo" runat="server" CssClass="form-control" AutoComplete="off" onkeypress='return restrictAlphabets(event)' MaxLength="10" placeholder="मोबाइल नम्बर दर्ज करें"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfv1" ControlToValidate="txtMobileNo" runat="server" Font-Bold="true" ForeColor="Red" ErrorMessage="अपना मोबाइल नम्बर दर्ज करें" ValidationGroup="Sa"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="col-md-2">
                    <div class="form-group">
                        <asp:Button ID="btnOtpGenerate" runat="server" Text="Generate OTP" ValidationGroup="Sa" CssClass="btn btn-primary" Style="margin-top: 14%;" OnClick="btnOtpGenerate_Click" />
                    </div>
                </div>
            </div>
        </div>
        <div id="ComplaintForm" runat="server" class="noprint">
            <div class="row">
                <div class="col-md-12">
                    <fieldset>
                        <legend>शिकायतकर्ता</legend>
                        <div class="row">
                            <div class="col-md-3">
                                <div class="form-group">
                                    <label>शिकायतकर्ता का नाम<span style="color: red;">*</span></label>
                                    <asp:TextBox ID="txtNameOfComplainant" runat="server" CssClass="form-control" onkeypress="return allowOnlyLetters(event,this);" placeholder="शिकायत कर्ता का नाम ..."></asp:TextBox>
                                </div>

                            </div>
                            <div class="col-md-3">
                                <div class="form-group">
                                    <label>पिता / पति का नाम<span style="color: red;">*</span></label>
                                    <asp:TextBox ID="txtFatherHusbandName" runat="server" CssClass="form-control" onkeypress="return allowOnlyLetters(event,this);" placeholder="पिता / पति का नाम ..."></asp:TextBox>
                                </div>

                            </div>
                            <div class="col-md-3">
                                <div class="form-group">
                                    <label>लिंग<span style="color: red;">*</span></label>
                                    <asp:DropDownList ID="ddlGenderOfComplainant" runat="server" CssClass="form-control">
                                        <asp:ListItem Value="0">Select</asp:ListItem>
                                        <asp:ListItem Value="Male">Male</asp:ListItem>
                                        <asp:ListItem Value="Female">Female</asp:ListItem>
                                        <asp:ListItem Value="Other">Other</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-md-3">
                                <div class="form-group">
                                    <label>मोबाइल नं. <span style="color: red;">*</span></label>
                                    <asp:TextBox ID="txtMobileNoOfComplainant" runat="server" ReadOnly="true" onkeypress='return restrictAlphabets(event)' MaxLength="10" CssClass="form-control" placeholder="मोबाइल नं. ..."></asp:TextBox>
                                </div>

                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-3">
                                <div class="form-group">
                                    <label>ई- मेल</label>
                                    <asp:TextBox ID="txtEmailOfComplainant" runat="server" CssClass="form-control" placeholder="ई - मेल ..."></asp:TextBox>
                                    <asp:RegularExpressionValidator ID="revEmail" runat="server" ValidationGroup="Save" ErrorMessage="Enter Valid Email-id" ValidationExpression="[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?" ForeColor="Red" Font-Bold="true" Font-Size="Small" ControlToValidate="txtEmailOfComplainant"></asp:RegularExpressionValidator>
                                </div>

                            </div>
                            <div class="col-md-3">
                                <div class="form-group">
                                    <label>शिकायतकर्ता की पहचान का प्रकार<span style="color: red;">*</span></label>
                                    <asp:DropDownList ID="ddlPersonalID" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlPersonalID_SelectedIndexChanged">
                                        <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                        <asp:ListItem Text="Voter ID" Value="1"></asp:ListItem>
                                        <asp:ListItem Text="Aadhar Card ID" Value="2"></asp:ListItem>
                                        <asp:ListItem Text="Pan Card" Value="3"></asp:ListItem>
                                        <asp:ListItem Text="Driving licence" Value="4"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div id="Identity" runat="server" visible="false">
                                <div class="col-md-3">
                                    <div class="form-group">
                                        <label>शिकायतकर्ता का पहचान क्रंमाक<span style="color: red;">*</span></label>
                                        <asp:TextBox ID="txtIdentity" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-3">
                                <div class="form-group">
                                    <label>शिकायतकर्ता  के पहचान दस्तावेज<span style="color: red;">*</span></label>
                                    <asp:FileUpload ID="FileupIdentity_DOC" runat="server" CssClass="form-control" />
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-12">
                                <div class="form-group">
                                    <label>शिकायतकर्ता का पूरा पता<span style="color: red;">*</span></label>
                                    <asp:TextBox ID="txtAddressOfComplainant" runat="server" CssClass="form-control" placeholder="शिकायतकर्ता का पूरा पता..." TextMode="MultiLine" Rows="3"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </fieldset>
                    <fieldset>
                        <legend>शिकायत</legend>
                        <div class="row">
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label>जिसके विरुद्ध शिकायत की जा रही है उसका नाम <span style="color: red;">*</span></label>
                                    <asp:TextBox ID="txtNameAgainstComplaint" runat="server" CssClass="form-control" onkeypress="return allowOnlyLetters(event,this);" placeholder="जिसके विरुद्ध शिकायत की जा रही है उसका नाम ..."></asp:TextBox>
                                </div>

                            </div>
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label>मोबाइल नं (यदि हो तो)</label>
                                    <asp:TextBox ID="txtMobileNoAgainstComplaint" runat="server" MaxLength="10" onkeypress='return restrictAlphabets(event)' CssClass="form-control" placeholder="मोबाइल नं (यदि हो तो) ..."></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-2">
                                <div class="form-group">
                                    <label>क्या वह रजिस्टर्ड डॉक्टर है<span style="color: red;">*</span></label>
                                    <asp:DropDownList ID="ddlRegistrationType" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlRegistrationType_SelectedIndexChanged">
                                        <asp:ListItem Value="0">Select</asp:ListItem>
                                        <asp:ListItem Value="हां">हां</asp:ListItem>
                                        <asp:ListItem Value="नहीं">नहीं</asp:ListItem>
                                        <asp:ListItem Value="पता नहीं">पता नहीं</asp:ListItem>
                                    </asp:DropDownList>

                                </div>
                            </div>
                            <div id="regino" runat="server" visible="false">
                                <div class="col-md-2">
                                    <div class="form-group">
                                        <label>रजिस्ट्रेशन नंबर<span style="color: red"><b> *</b></span></label>
                                        <asp:TextBox ID="txtRegno" runat="server" CssClass="form-control" placeholder="रजिस्ट्रेशन नंबर.."></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label>ईमेल आईडी</label>
                                    <asp:TextBox ID="txtEmailID" runat="server" CssClass="form-control" placeholder="ईमेल आईडी दर्ज करें.."></asp:TextBox>
                                    <asp:RegularExpressionValidator ID="REG1" runat="server" ValidationGroup="Save" ErrorMessage="Enter Valid Email-id" ValidationExpression="[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?" ForeColor="Red" Font-Bold="true" Font-Size="Small" ControlToValidate="txtEmailID"></asp:RegularExpressionValidator>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label>घर का पता</label>
                                    <asp:TextBox ID="txtresidential" runat="server" CssClass="form-control" placeholder="घर का पता"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label>राज्य पशु चिकित्सा परिषद का नाम</label>
                                    <asp:TextBox ID="txtSVC" runat="server" CssClass="form-control" Text="Madhya Pradesh State Veterinary Council" ReadOnly="true"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label>शिकायत का प्रकार<span style="color: red"><b>*</b></span></label>
                                    <asp:DropDownList ID="ddlComplaintType" runat="server" CssClass="form-control">
                                        <asp:ListItem Value="0">Select</asp:ListItem>
                                        <asp:ListItem Value="गलत इलाज किया">गलत इलाज किया</asp:ListItem>
                                        <asp:ListItem Value="डॉ. रजिस्टर्ड नही है">डॉ. रजिस्टर्ड नही है</asp:ListItem>
                                        <asp:ListItem Value="अन्य समस्या">अन्य समस्या</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label>पशु/पक्षी का प्रकार</label>
                                    <asp:DropDownList ID="ddlTypeOfAnimal" runat="server" CssClass="form-control">
                                        <asp:ListItem Value="Cow">Cow</asp:ListItem>
                                        <asp:ListItem Value="Buffalo">Buffalo</asp:ListItem>
                                        <asp:ListItem Value="Goat">Goat</asp:ListItem>
                                        <asp:ListItem Value="Other">Other</asp:ListItem>
                                    </asp:DropDownList>
                                </div>

                            </div>
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label>पशु की उम्र</label>
                                    <asp:TextBox ID="txtAgeOfAnimal" runat="server" CssClass="form-control" placeholder="पशु की उम्र ..." MaxLength="10" onkeypress='return AnimalAge(event)'></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>घटना का स्थान</label>
                                    <asp:TextBox ID="txtPlaceOfEvent" runat="server" CssClass="form-control" onkeypress="return allowOnlyLetters(event,this);" placeholder="घटना का स्थान  ..." MaxLength="400"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>पशु चिकित्सक के अस्पताल का पता (यदि हो तो)</label>
                                    <asp:TextBox ID="txtHospitalAddress" runat="server" CssClass="form-control" placeholder="पशु चिकित्सक के अस्पताल का पता (यदि हो तो) ..." MaxLength="400"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-12">
                                <div class="form-group">
                                    <label>शिकायत का संक्षिप्त विवरण<span style="color: red;">*</span></label>
                                    <asp:TextBox ID="txtDetailOfComplaint" runat="server" CssClass="form-control" placeholder="शिकायत का संक्षिप्त विवरण ..." TextMode="MultiLine" Rows="3"></asp:TextBox>
                                </div>

                            </div>
                        </div>
                        <div class="row">

                            <div class="col-md-3">
                                <div class="form-group">
                                    <label>डाक्यूमेंट - 1</label>
                                    <asp:FileUpload ID="FU_Doc1" runat="server" CssClass="form-control" onchange="UploadControlValidationForLenthAndFileFormat(100, 'JPEG*PNG*JPG*GIF*PDF*DOC*DOCX', this),ValidateFileSize(this)" />
                                </div>


                            </div>
                            <div class="col-md-3">
                                <div class="form-group">
                                    <label>डाक्यूमेंट - 2</label>
                                    <asp:FileUpload ID="FU_Doc2" runat="server" CssClass="form-control" onchange="UploadControlValidationForLenthAndFileFormat(100, 'JPEG*PNG*JPG*GIF*PDF*DOC*DOCX', this),ValidateFileSize(this)" />
                                </div>
                            </div>
                            <div class="col-md-3">
                                <div class="form-group">
                                    <label>डाक्यूमेंट - 3</label>
                                    <asp:FileUpload ID="filupDoc1" runat="server" CssClass="form-control" onchange="UploadControlValidationForLenthAndFileFormat(100, 'JPEG*PNG*JPG*GIF*PDF*DOC*DOCX', this),ValidateFileSize(this)" />
                                </div>
                            </div>
                            <div class="col-md-3">
                                <div class="form-group">
                                    <label>डाक्यूमेंट - 4</label>
                                    <asp:FileUpload ID="FilupDoc2" runat="server" CssClass="form-control" onchange="UploadControlValidationForLenthAndFileFormat(100, 'JPEG*PNG*JPG*GIF*PDF*DOC*DOCX', this),ValidateFileSize(this)" />
                                </div>
                            </div>
                        </div>
                    </fieldset>
                </div>
                <div class="row" style="padding-left: 15px; padding-right: 15px;">
                    <div class="col-md-12">
                        <div class="form-group">
                            <label>अन्य विवरण</label>
                            <asp:TextBox ID="txtOtherRemark" runat="server" CssClass="form-control" placeholder="अन्य विवरण ..." TextMode="MultiLine" Rows="3"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="row" style="padding-left: 15px; padding-right: 15px;">
                    <div class="col-md-8"></div>
                    <div class="col-md-2">
                        <div class="form-group">
                            <asp:Button ID="btnSubmit" runat="server" CssClass="btn btn-block btn-success" ValidationGroup="Save" Text="दर्ज करें" OnClick="btnSubmit_Click" />
                            <asp:Button ID="btnprint" runat="server" Visible="false" Text="Print" OnClick="btnprint_Click" />
                        </div>
                    </div>
                    <div class="col-md-2">
                        <div class="form-group">
                            <a class="btn btn-block btn-info" href="ComplaintRegistration.aspx">Cancel</a>
                        </div>
                    </div>
                </div>
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
                          <asp:Button ID="btnSaveotp" runat="server" Text="Verify" OnClientClick="javascript:return(PopAcceptRenew());" Width="100" CssClass="btn" OnClick="btnSaveotp_Click" />
                    </td>
                </tr>
                <tr>
                    <td style="padding-top: 10px; padding-left: 20px; font-weight: bold;" colspan="2">
                        <asp:HyperLink ID="HyperLink1" runat="server" Font-Underline="True" ForeColor="#0066FF" NavigateUrl="~/ComplaintRegistration.aspx">Go Back</asp:HyperLink>
                        &nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Label ID="lblOTPInvalid" runat="server" ForeColor="Red" Text=""></asp:Label>
                    </td>
                </tr>
            </table>
        </asp:Panel>
    </div>
    <div class="NonPrintable" id="Divprint" runat="server">
        <div class="row">
            <div class="col-md-12">
                <h4 style="text-align: center;"><ins>Online Register Complaint Against Registered Veterinary Practitiner(RVP) for Professional<br />
                    Misconduct.</ins></h4>

                <table border="1" class="table table-bordered">
                    <tr>
                        <td>1.</td>
                        <td>Complaint Number:</td>
                        <td>
                            <asp:Label ID="lblComplaintNO" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>2.</td>
                        <td>Name of Complainant:</td>
                        <td>
                            <asp:Label ID="lblapllicantname" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>3.</td>
                        <td>Father’s Name
                        </td>
                        <td>
                            <asp:Label ID="lblApplicantFH" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>4.</td>
                        <td>E-mail ID of Complainant:</td>
                        <td>
                            <asp:Label ID="lblEmailIDofComplainant" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>5.</td>
                        <td>Mobile Number Of Complainant:</td>
                        <td>
                            <asp:Label ID="lblMObileOFComplainant" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>6.</td>
                        <td>Full Correspondance Address:</td>
                        <td>
                            <asp:Label ID="lblFullAddressofComplainant" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>7.</td>
                        <td>Palease Attach a copy of identification of complainant(Aadhar Card/Pan Card/Voter ID or Any other id Issue by State or Central Goverment)</td>
                        <td>
                            <asp:Label ID="lblIDType" runat="server"></asp:Label><strong>=</strong>
                            <asp:Label ID="lblIdProof" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td rowspan="8">8.</td>
                        <th colspan="2">Name of RVP Along with particulars of RVP(s) against whom complaint is logged:</th>

                    </tr>
                    <tr>
                        <td>A.Name of RVP:</td>
                        <td>
                            <asp:Label ID="lblnameAgainstComplaint" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>B.State Veterinary Registration No:</td>

                        <td>
                            <asp:Label ID="lblregino" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>C.Name of State Veterinary Council:</td>

                        <td>
                            <asp:Label ID="lblSVC" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>D.Residential Address:</td>

                        <td>
                            <asp:Label ID="lblresidentialAddress" runat="server" Text=""></asp:Label></td>
                    </tr>
                    <tr>
                        <td>E.Clinic/Dispensary/Hospital address:</td>
                        <td>
                            <asp:Label ID="lblhospitaladdress" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>F.TelePhone/Mobile No:</td>
                        <td>
                            <asp:Label ID="lbltelephonmobile" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>G.Email-ID</td>
                        <td>
                            <asp:Label ID="lblEmailOfAgainstComplaint" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>9.</td>
                        <td>Place of MisConduct:</td>
                        <td>
                            <asp:Label ID="lblplaceofEvent" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>10.</td>
                        <td>Nature of Complaint/Allegation as per Regulations:(professional misconducts, misuse of titles and falsely claimming to be registered Veterinary practioners, etc)</td>
                        <td>
                            <asp:Label ID="lblNatureofComplaint" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>11.</td>
                        <td>Describe the misconduct in brief(Maximum 250 words):</td>
                        <td>
                            <asp:Label ID="lblDetailofComplaint" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>12.</td>
                        <td>Whether complaint is related with Large Animals' or small animals'/wild animals:</td>
                        <td>
                            <asp:Label ID="lblcomplaintrelation" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>13.</td>
                        <td>Age of Animal at the time of treatment:
                        </td>
                        <td>
                            <asp:Label ID="lblAnimalAge" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                </table>
                <h4>I hereby affirm and certify that the aforesaid information provided above are true incorrect to the best of my knowledge and belief.</h4>

                &nbsp;&nbsp;
            </div>
            <div>
                <span>
                    <label>Date:</label>
                </span>&nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;
            <span style="float: right">
                <label>Signature</label>
            </span>
                <br />
                <span>
                    <label>Place:</label>
                </span>&nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;
            <span style="float: right">
                <label>Name in full:___________</label>
            </span>
            </div>
        </div>

    </div>
    <script language="javascript" type="text/javascript">
        function UploadControlValidationForLenthAndFileFormat(maxLengthFileName, validFileFormaString, that) {

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
                        msg += '- File Name Should be less than ' + maxLengthFileName + ' characters. \n';
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
                            msg += 'File Format Is Not Correct (Only ' + strValidFormates + ').\n';
                        }
                    }

                }
                else {
                    msg += '- File Name is incorrect';
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
        function ValidateFileSize(a) {

            var uploadcontrol = document.getElementById(a.id);
            if (uploadcontrol.files[0].size > 20971520) {
                alert('File size should not greater than 5 mb.');
                document.getElementById(a.id).value = '';
                return false;
            }
            else {
                return true;
            }

        }

        <%-- Start Add on 21-03-2022 by bhanu (only character and number allow func.) --%>

        function allowOnlyLetters(e, t) {
            if (window.event) {
                var charCode = window.event.keyCode;
            }
            else if (e) {
                var charCode = e.which;
            }
            else { return true; }
            if ((charCode > 64 && charCode < 91) || (charCode > 96 && charCode < 123) || e.charCode == 32)

                return true;
            else {
                //alert("Please enter only alphabets");
                return false;
            }
        }

        function restrictAlphabets(e) {
            var x = e.which || e.keycode;
            if ((x >= 48 && x <= 57))
                return true;
            else
                //alert("Only numbers allow");
                return false;
        }

        function AnimalAge(e) {
            var x = e.which || e.keycode;
            if ((x >= 46 && x <= 57))
                return true;
            else
                //alert("Only numbers allow");
                return false;
        }
        <%-- END Add on 21-03-2022 by bhanu (only character and number allow func.) --%>
    </script>
</asp:Content>

