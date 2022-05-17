<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default2.aspx.cs" Inherits="VerifyForm_Default2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <script src="../poplink/POPMODAL2bootstrap.min.js"></script>
    <link href="../poplink/POPMODAL3bootstrap.min.css" rel="stylesheet" />
    <script src="../poplink/POPUPMODAL1jquery.min.js"></script>
    <style>
        table
        {
            border:1px solid #ddd;

        }
        .table-bordered{border:1px solid #ddd}
    </style>
</head>   
<body>

<h2>Modal Example</h2>
    <form id="fomr2" runat="server">
    <div class="NonPrintable" id="Divprint" runat="server">
          <%--  <div class="row">
                <div class="col-md-12">
                    
                    <h3 style="text-align: center;"> - 110066 </h3>
                    <h3 style="text-align: center;">Veterinary Council of India, New Delhi – 110066</h3>                   
                    <h3 style="text-align: center;"> APPLICATION FORM</h3>
                    <h4 style="text-align: center;">TRANSFER OF REGISTRATION FROM ONE STATE VETERINARY <br />REGISTER TO ANOTHER STATE VETERINARY REGISTER</h4>
                    <h4 style="text-align:center; "><b>(Under IVC Act 1984, Rule 55)</b></h4>
                    <h3 style="text-align: center">PART 1</h3>
                    
                    <table class="table table-bordered">
                        <tr>
                            <th> S.No.</th>
                            <th>Particulars</th>
                            <td></td>
                        </tr>
                        <tr>
                            <td>1.</td>
                            <td>
                                Photograph of the Applicant:</td>
                            <td>
                                
                            </td>
                        </tr>
                        <tr>
                            <td>2.</td>
                            <td>
                                Name of Applicant(in Capital Letter):</td>
                            <td>
                                <asp:Label ID="lblapllicant" runat="server" Text='<%# Eval("Name")%>'></asp:Label>
                                <asp:Label ID="lblregno" runat="server" Visible="false" ></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>3.</td>
                            <td>
                                Father’s/Husband Name
                            </td>
                            <td>
                                <asp:Label ID="lblApplicantFH" runat="server" Text='<%# Eval("FatherName")%>'></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>4.</td>
                            <td>
                                Date of Birth</td>
                            <td>
                                <asp:Label ID="lblDOB" runat="server" Text='<%# Eval("DOB")%>'></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>5.</td>
                            <td>Gender</td>
                            <td>
                                <asp:Label ID="lblGender" runat="server" Text='<%# Eval("Gender")%>'></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td rowspan="4">6.</td>
                            <td colspan="2" style="height: 50px">Details of recognized Veterinary Qualification:</td>
                        </tr>
                        <tr>
                            <td>A. Degree Nomenclature</td>
                            <td>
                             
                                 <asp:Label ID="lblDegreeName" runat="server" Text="Bachelor of Veterinary Science And A.H"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>B. Name of College</td>
                            <td>
                                <asp:Label ID="lblCollegeName" runat="server" Text='<%# Eval("CollegeName") %>'></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>C.
                                Name of Institution awarded Recognized veterinary qualification</td>
                            <td>
                                <asp:Label ID="lblUniversity" runat="server" Text='<%# Eval("UniversityName") %>'></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>7.</td>
                            <td>Full Correspondence/Residential Address</td>
                            <td>
                                <asp:Label ID="lblresidntialAddress" runat="server" Text='<%# Eval("PreferedAdd")%>'></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td rowspan="3">8.</td>
                            <td colspan="2"> Mobile Number and Email-ID of applicant</td>
                        </tr>
                        <tr>
                            <td>A. Mobile Number of applicant:</td>
                            <td>
                                <asp:Label ID="lblNO" runat="server" Text='<%# Eval("MobileNo")%>'></asp:Label></td>
                        </tr>
                        <tr>
                            <td>B. Email-ID of applicant:</td>
                            <td>
                                <asp:Label ID="lblemail" runat="server" Text='<%# Eval("EmailId")%>'></asp:Label>
                            </td>
                        </tr>
                    </table>
                   <div style="page-break-before:always">&nbsp;</div>
                    <h3 style="text-align: center; color: #0094ff">PART 2</h3>
                    <div class="row">
                        <div class="col-md-12">
                            <h3 style="text-align: center; margin-bottom: 30PX; border:solid">Details of Registration and Transfer applied</h3>
                        </div>
                    </div>
                    <table border="1" class="table table-bordered">
                        <tr>
                            <td width="8%">9.</td>
                            <td>Name of the State Veterinary Council wherein, candidate is presently registered</td>
                            <td>
                                <asp:Label ID="lblPR" runat="server" Text='<%# Eval("State_Veterinary_Council_namepresent")%>'></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>10.</td>
                            <td>
                                State Veterinary Council Registration Number</td>
                            <td>
                                <asp:Label ID="lblRn" runat="server" Text='<%# Eval("RegiNo")%>'></asp:Label>

                            </td>
                        </tr>
                        <tr>
                            <td>11.</td>
                            <td>
                                Validity of Registration (dd/mm/yyyy)</td>
                            <td>
                                <asp:Label ID="lblVr" runat="server" Text='<%# Eval("Validupto")%>'></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>12.</td>
                            <td>
                                Name of the State Veterinary Council wherein, the transfer of registration is applied</td>
                            <td>
                                <asp:Label ID="lblAppli" runat="server" Text='<%# Eval("StateName")%>'></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td rowspan="7">13.</td>
                            <td colspan="2">
                                Payment details of transfer Fee of Rs 15/-. </td>
                        </tr>
                        <tr>
                            <td>1.DD No</td>
                            <td>
                                <asp:Label ID="lblddno" runat="server" Text='<%# Eval("ChequeNo")%>'></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>2.
                                Drawn in the name of</td>
                            <td>
                                <asp:Label ID="lblDddrname" runat="server" Text='<%# Eval("Drawn_name_DD")%>'></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>3. Date:</td>
                            <td>
                                <asp:Label ID="lblDate" runat="server" Text='<%# Eval("alDate")%>'></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>4. Amount</td>
                            <td>
                                <asp:Label ID="lblAmount" runat="server" Text='<%# Eval("TotalAmount") %>'></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>5. Name of issuing Bank</td>
                            <td>
                                <asp:Label ID="lblIssuebank" runat="server" Text='<%# Eval("BankName")%>'></asp:Label>
                            </td>
                        </tr>
                        <tr>

                            <td>6. Name of issuing Branch</td>
                            <td>
                                <asp:Label ID="lblIssueBranch" runat="server" Text='<%# Eval("Bank_Branch_Name")%>'></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>14.</td>
                            <td>
                                Reason for seeking transfer of registration:</td>
                            <td>
                                <asp:Label ID="Lblrison" runat="server" Text='<%# Eval("Remark")%>'></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td rowspan="5">15.</td>
                            <td colspan="2">List of documents enclosed: 
                              
                        </tr>
                        <tr>
                            <td>1. DD in original</td>
                            <td>Yes</td>
                        </tr>
                        <tr>
                            <td>2. Aadhar / Passport / DL/SSLC :
                            </td>
                            <td>Yes</td>
                        </tr>
                        <tr>
                            <td>3. Degree certificate (BVSc&AH/MVSc/ PhD/ Other):
                            </td>
                            <td>Yes</td>
                        </tr>
                        <tr>
                            <td>4. 
                                Copy of the State Veterinary Council Registration Certificate:
                            </td>
                            <td>Yes</td>
                        </tr>
                    </table> 
                   <span style="margin-left: 60px;">Signature of the Applicant:________________________     Submitted to:</span>
                    <br />
                    <br />
                    <span style="margin-left: 60px;">The Registrar: --<b><asp:Label ID="lblVetenaryCouncil" runat="server" Text='<%# Eval("Registrar_Name")%>'></asp:Label></b>
                       Name of State Veterinary Council</span><br />
                    <br />
                   <span>Address:-- 
                     <b>
                         <asp:Label ID="lblRAddress" runat="server" Text='<%# Eval("Registrar_Adresse")%>'></asp:Label></b></span>


                </div>
            </div>--%>
        </div>
        </form>
      
</body>
</html>
