<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Print.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>शिकायत  पंजीकरण</title>

    <style>
        fieldset {
            border: 1px solid #01baf2;
            padding: 10px;
            margin-bottom: 10px;
            width: 920px;
        }

        legend {
            display: block;
            white-space: normal;
            width: initial;
            padding: 5px 15px;
            margin: 0;
            font-size: 12px;
            color: #011ff2;
            border: 1px solid #01baf2;
            font-weight: 600;
        }

        .form-control {
            display: block;
            /*width: 100%;*/
            min-height: 12px;
            padding: 3px 12px;
            font-size: 10px;
            line-height: 1.42857143;
            color: #000;
            background-color: #fff;
            background-image: none;
            border: 1px solid #ccc;
            border-radius: 4px;
            -webkit-box-shadow: inset 0 1px 1px rgb(0 0 0 / 8%);
            box-shadow: inset 0 1px 1px rgb(0 0 0 / 8%);
            -webkit-transition: border-color ease-in-out .15s,-webkit-box-shadow ease-in-out .15s;
            -o-transition: border-color ease-in-out .15s,box-shadow ease-in-out .15s;
            transition: border-color ease-in-out .15s,box-shadow ease-in-out .15s;
        }
        /*th{
            padding:17px
        }*/
        /*td {
            font-size: 13px;
            font-weight: 600;
        }*/
       
        .row{
            margin-right:15px;margin-left:15px;

        }
        .col-md-12{
            width:100%

        }
        .tabler {
  font-family: arial, sans-serif;
  border-collapse: collapse;
  width: 100%;
}

td, tr {
  border: 1px solid #dddddd;
  text-align: left;
  padding: 8px;
}

    </style>
</head>
<body>
    <form id="form1" runat="server">


       <%-- <div style="width: 920px;">
            <header style="text-align: center;">
                <h2 style="margin-bottom: 5px;">Madhya Pradesh State Veterinary council</h2>
                <h3 style="margin-top: 5px;">शिकायत पंजीकरण</h3>
            </header>
            <table style="width: 100%">
                <tr>
                    <td style="width: 50%; text-align: left;">शिकायत क्रमांक :
                        <asp:Label ID="lblComplaintNo" runat="server" Text=""></asp:Label>
                        [<asp:Label ID="lblStatus" runat="server" Text=""></asp:Label>]</td>
                    <td style="width: 50%; text-align: right;">शिकायत दिनांक :
                        <asp:Label ID="lblComplaintDate" runat="server" Text=""></asp:Label></td>
                </tr>
            </table>

            <fieldset>
                <legend>शिकायतकर्ता</legend>

                <table style="width: 100%">
                    <tr>
                        <td style="width: 45%">शिकायतकर्ता का नाम : 
                                            <asp:Label ID="lblNameOfComplainant" runat="server" CssClass="form-control" Text=""></asp:Label>
                        </td>
                        <td style="width: 45%">पिता / पति का नाम :
                                            <asp:Label ID="lblFatherHusbandName" runat="server" CssClass="form-control" Text=""></asp:Label>
                        </td>
                        <td style="width: 10%">लिंग : 
                                            <asp:Label ID="lblGenderOfComplainant" runat="server" CssClass="form-control" Text=" "></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 45%">मोबाइल नं.: 
                                            <asp:Label ID="lblMobileNoOfComplainant" runat="server" CssClass="form-control" Text=""></asp:Label>
                        </td>
                        <td style="width: 45%">ई - मेल :
                                            <asp:Label ID="lblEmailOfComplainant" runat="server" CssClass="form-control" Text=""></asp:Label>
                        </td>
                        <td style="width: 10%"></td>
                    </tr>
                    <%--<tr>

                                        <td>मोबाइल नं. </td>
                                        <td>ई - मेल</td>
                                        <td></td>
                                        <td>आधार नं. </td>
                                    </tr>--%>
                   <%-- <tr>
                        <td colspan="3">शिकायतकर्ता का पूरा पता : 
                                             <asp:Label ID="lblAddressOfComplainant" runat="server" CssClass="form-control" Text=""></asp:Label>
                        </td>
                    </tr>
                </table>
            </fieldset>
            <fieldset>
                <legend>शिकायत</legend>
                <table style="width: 100%">
                    <tr>
                        <td colspan="3">
                            <table style="width: 100%">
                                <tr>
                                    <td>शिकायत का प्रकार :
                                             <asp:Label ID="lblComplaintType" runat="server" CssClass="form-control" Text=""></asp:Label>
                                    </td>
                                    <td>पशु का प्रकार :
                                             <asp:Label ID="lblTypeOfAnimal" runat="server" CssClass="form-control" Text=""></asp:Label>
                                    </td>
                                    <td>पशु की उम्र :
                                             <asp:Label ID="lblAgeOfAnimal" runat="server" CssClass="form-control" Text=""></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </td>

                    </tr>
                    <tr>
                        <td colspan="3">
                            <table style="width: 100%">
                                <tr>
                                    <td  style="width: 50%">घटना का स्थान :
                                             <asp:Label ID="lblPlaceOfEvent" runat="server" CssClass="form-control" Text=""></asp:Label>
                                    </td>
                                    <td style="width: 50%">पशु चिकित्सक के अस्पताल का पता  :
                                             <asp:Label ID="lblHospitalAddress" runat="server" CssClass="form-control" Text=""></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </td>

                    </tr>
                    <tr>
                        <td colspan="3">शिकायत का संक्षिप्त विवरण :
                                             <asp:Label ID="lblDetailOfComplaint" runat="server" CssClass="form-control" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>जिसके विरुद्ध शिकायत की जा रही है उसका नाम :
                                             <asp:Label ID="lblNameAgainstComplaint" runat="server" CssClass="form-control" Text=""></asp:Label>
                        </td>
                        <td>मोबाइल नं (यदि हो तो) :
                                             <asp:Label ID="lblMobileNoAgainstComplaint" runat="server" CssClass="form-control" Text=""></asp:Label>
                        </td>
                        <td>क्या वह रजिस्टर्ड डॉक्टर है :
                                             <asp:Label ID="lblRegistrationType" runat="server" CssClass="form-control" Text=""></asp:Label>
                        </td>
                    </tr>
                </table>
            </fieldset>
            <table style="width: 100%">
                <tr>
                    <td>अन्य विवरण :
                                    <asp:Label ID="lblOtherRemark" runat="server" CssClass="form-control" Text=""></asp:Label>
                    </td>
                </tr>
            </table>

        </div>--%>



          <div class="NonPrintable" id="Divprint" runat="server">
            <div class="row">
                <div class="col-md-12">
                    <%-- Start PART-1 HERE ----%>
                   <%-- <h3 style="text-align: center;  margin-bottom:-15px">भारतीय पशुचिकित्सा परिषद् नई दिल्ली - 110066 </h3>
                    <h3 style="text-align: center;">Veterinary Council of India, New Delhi – 110066</h3>--%>
                    <h4 style="text-align: center; margin-top: 1px">Online Registration Complaint Against Registerd Veterinary Practitiner(RVP) for Professional Misconduct.</h4>
                    <%--<h3 style="text-align: center; margin-bottom: 30PX; border:solid"> APPLICATION FORM</h3>
                    <h4 style="text-align: center; margin-bottom:-5px"">TRANSFER OF REGISTRATION FROM ONE STATE VETERINARY <br />REGISTER TO ANOTHER STATE VETERINARY REGISTER</h4>
                    <h4 style="text-align:center; "><b>(Under IVC Act 1984, Rule 55)</b></h4>
                    <h3 style="text-align: center">PART 1</h3>--%>
          
                    <table class="tabler" style="width:100%">
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
                       <%-- <tr>
                            <td rowspan="4">6.</td>
                            <td colspan="2" style="height: 50px">मान्यता प्राप्त पशु चिकित्सा योग्यता का विविरण/<br />Details of recognized Veterinary Qualification:</td>
                        </tr>--%>
                        <tr>
                            <td>7.</td>
                            <td>Palease Attach a copy of identification of complainant(Aadhar Card/Pan Card/Voter ID or Any other id Issue by State or Central Goverment)</td>
                            <td>
                                 <asp:Label ID="lblIdtype" runat="server"></asp:Label><strong>=</strong>
                                 <asp:Label ID="lblIdProof" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td rowspan="8">8.</td>
                            <th colspan="1">Name of RVP Along with particulars of RVP(s) against whom complaint is logged:</th>
                           
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
                            <td >C.Name of State Veterinary Council:</td>
                            
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
                                <asp:Label ID="lblEmailOfAgainstComplaint" runat="server" Text =""></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>9.</td>
                            <td>Place of MisConduct:</td>
                            <td>
                                <asp:Label ID="lblplaceofEvent" runat="server" Text =""></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>10.</td>
                            <td>Nature of Complaint/Allegation as per Regulations:(professional misconducts, misuse of titles and falsely claimming to be registered Veterinary practioners, etc)</td>
                            <td>
                                <asp:Label ID="lblNatureofComplaint" runat="server" Text =""></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>11.</td>
                            <td>Describe the misconduct in brief(Maximum 250 words):</td>
                            <td>
                                <asp:Label ID="lblDetailofComplaint" runat="server" Text =""></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>12.</td>
                            <td>Whether complaint is related with Large Animals' or small animals'/wild animals:</td>
                            <td>
                                <asp:Label ID="lblcomplaintrelation" runat="server" Text =""></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>13.</td>
                            <td>
                               Age of Animal at the time of treatment:
                            </td>                         
                                <td>
                                <asp:Label ID="lblAnimalAge" runat="server" Text =""></asp:Label>
                            </td>                          
                        </tr>
                        <%-- <tr>
                            <td>14.</td>
                            <td>
                             List of Documents Attached in support with  Complaint:
                            </td>                         
                                <td>
                                <asp:Label ID="Label1" runat="server" Text =""></asp:Label>
                            </td>                          
                        </tr>--%>
                    </table>
                    <h4>I hereby affirm and certify that the aforesaid information provided above are true incorrect to the best of my knowledge and belief.</h4>
                </div>
            </div>
               <div>
            <span>
                <label>Date:</label>
            </span> &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;
            <span style="float:right">
                <label>Signature</label>
            </span>
            <br />
                <span>
                    <label>Place:</label>
                </span>&nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;
            <span style="float:right">
                <label>Name in full:___________</label>
            </span>
        </div>
        </div>
        <script>
            window.print();
        </script>
    </form>
</body>
</html>
