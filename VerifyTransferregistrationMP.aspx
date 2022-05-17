<%@ Page Title="" Language="C#" MasterPageFile="~/AdminSection/MasterPage.master" AutoEventWireup="true" CodeFile="VerifyTransferregistrationMP.aspx.cs" Inherits="VerifyTransferregistrationMP" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <style>
        strong {
            color: #01baf2;
            font-size:16px;
        }
        label {
            font-size: 13px;
        }
    </style>
 <script type="text/javascript" language="javascript">
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
    function MessageVerify() {
        alert("Application forwarded successfully");
    }
    function PopTemAndConditionOnSave() {
        document.getElementById('<%=divPopOnSave.ClientID%>').style.display = "block";
         return false;
     }
</script>
 
    <table width="100%" cellpadding="0" cellspacing="0">
        <tr>
                        <td colspan="4">
                            <h3><strong>Transfer Registration/ Out Of M.P</strong></h3>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4">
                            <asp:Label ID="lblMsg" runat="server" Font-Bold="true" Font-Size="15pt"></asp:Label>
                            <asp:Label ID="lblID" runat="server" Visible="false"  Text='<%# Eval("id") %>'>'></asp:Label>
                        </td>
                    </tr>
                </table>

                <table width="101%" cellpadding="0" cellspacing="0">
                  
                    <tr>
                        <td>
                            <label>Applcant Name:<span style="color: red"><b> *</b></span></label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtApplicant" ReadOnly="true" runat="server" Text='<%# Eval("Name") %>'>'></asp:TextBox>
                          
                        </td>
                        <td>
                            <label>Father/Husband Name:<span style="color: red"><b> *</b></span></label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtFHname" ReadOnly="true" runat="server" Text='<%# Eval("FatherName") %>'>'></asp:TextBox>
                          
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <label>Date Of Birth:<span style="color: red"><b> *</b></span></label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtDOBb" ReadOnly="true"  data-date-format="dd/mm/yyyy" AutoComplete="off" onchange="checkDateFormat(this)"  data-date-autoclose="true" runat="server" CssClass="form-control" ></asp:TextBox>
                           
                        </td>

                        <td>
                            <label>Gender:<span style="color: red"><b> *</b></span></label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtgenderName" ReadOnly="true" runat="server" Text='<%# Eval("Gender") %>'>'></asp:TextBox>
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
                        <td>
                            <label>Degree Name:<span style="color: red"><b> *</b></span></label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtDegree" ReadOnly="true" runat="server" Text='<%# Eval("DegreeName") %>'>'></asp:TextBox>
                             
                        </td>
                        <td>
                            <label>
                                Name of Institution awarded<br />
                                Recognized veterinary qualification<span style="color: red"><b> *</b></span></label>
                        </td>
                        <td>
                          
                           <asp:TextBox ID="txtuniversityName" ReadOnly="true" runat="server" Text='<%# Eval("UniversityName") %>'>'></asp:TextBox>

                        </td>

                    </tr>
                    <tr>
                        
                        <td>
                            <label>College Name:<span style="color: red"><b> *</b></span></label>
                        </td>
                        <td>
                           
                            <asp:TextBox ID="txtCollegeName" ReadOnly="true" runat="server" Text='<%# Eval("CollegeName") %>'>'></asp:TextBox>
                          
                        </td>
                        <td>
                            <label>Residential Address:<span style="color: red"><b> *</b></span></label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtAddress" ReadOnly="true" runat="server"  Text='<%# Eval("ResAdd") %>'>'></asp:TextBox>
                          
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <label>Mobile No:<span style="color: red"><b> *</b></span></label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtMobileno" ReadOnly="true" runat="server" Text='<%#  Eval("MobileNo")%>'>'></asp:TextBox>
                            
                        </td>
                        <td>
                            <label>Email:<span style="color: red"><b> *</b></span></label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtEmailID" ReadOnly="true" runat="server" Text='<%# Eval("EmailId") %>'>'></asp:TextBox>
                            
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
                                Name of the State Veterinary<br /> Council
                                wherein,candidate is<br /> presently registered:<span style="color: red"><b> *</b></span></label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtNameofsvp" runat="server" ReadOnly="true" Text='<%# Eval("State_Veterinary_Council_namepresent") %>'>'></asp:TextBox>
                           
                        </td>
                        <td>
                            <label>
                                State Veterinary Council<br />
                                Registration Number:<span style="color: red"><b> *</b></span></label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtReginumber" runat="server" ReadOnly="true" Text='<%# Eval("RegiNo") %>'>'></asp:TextBox>
                             
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <label>Validity of Registration:<span style="color: red"><b> *</b></span></label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtValidity"  data-date-format="dd/mm/yyyy" ReadOnly="true"  data-provide="datepicker" runat="server" AutoComplete="off"></asp:TextBox>
                            
                        </td>
                        <td>
                            <label>
                                Name of the State Veterinary Council<br />
                                wherein, the transfer of registration is applied:<span style="color: red"><b> *</b></span></label>
                        </td>
                        <td>
                           <asp:TextBox ID="txtState" runat="server" ReadOnly="true" Text='<%# Eval("PreferedAdd") %>'>'></asp:TextBox>
                           
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <h4>
                                <strong class="strong">Payment details of
                                   
                                    transfer
                                    Fee of Rs 15/- :-</strong>
                            </h4>
                        </td>
                    </tr>
                    <tr>
                     <td>
                            <%--<label>Payment Type :<span style="color:red"><b> *</b></span></label> --%>
                         </td>
                         <td >
                            <asp:RadioButton ID="rbOnline"  runat="server" Visible="false" Text="Online Payment" onchange="IsOffline()"
                                GroupName="rbPayment" />&nbsp
                            <asp:RadioButton ID="rboffline"  runat="server" Visible="false" Text="Offline Payment" onchange="IsOffline()"
                                Checked="true" GroupName="rbPayment" />
                        </td>
                        </tr>
                    <tr>
                        <td>
                            <label>Cheque/DD NO:<span style="color: red"><b> *</b></span></label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtDDno" ReadOnly="true" runat="server" Text='<%# Eval("ChequeNo") %>'>'></asp:TextBox>                          
                        </td>
                        <td>
                            <label>Payment Date:<span style="color: red"><b> *</b></span></label>
                        </td>
                        <td>
                             <asp:TextBox ID="txtdate" ReadOnly="true" data-provide="datepicker"  data-date-format="dd/mm/yyyy" data-date-autoclose="true" AutoComplete="off" runat="server"></asp:TextBox>
                          
                        </td>
                         </tr>
                    <tr>
                         <td>
                            <label>Name of issuing Bank:<span style="color: red"><b> *</b></span></label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtBank" ReadOnly="true" runat="server" Text='<%# Eval("BankName") %>'>'></asp:TextBox>                           
                        </td>
                        <td>
                            <label>Drawn in the name of(DD):<span style="color: red"><b> *</b></span> </label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtDrwan" ReadOnly="true" runat="server" Text='<%# Eval("Drawn_name_DD") %>'>'></asp:TextBox>                           
                        </td>                       
                        </tr>
                    <tr>
                        <td>
                            <label>Branch Name:<span style="color: red"><b> *</b></span></label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtBranch" ReadOnly="true" runat="server" Text='<%# Eval("Bank_Branch_Name") %>'>'></asp:TextBox>                           
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
                            <asp:TextBox ID="txtreason" ReadOnly="true" Style="margin-left:110px; height:50px; width:650px" runat="server" Text='<%# Eval("Remark") %>'>'></asp:TextBox> 
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
                <table >
                   <%--  <tr>
            <td style="color: red;" colspan="4">Note: Please upload photo which will be used for official purpose , file size should not be greater than 1024 kb and file format should be jpeg,png,jpg,gif *</td>
           </tr>--%>
                   <tr class="row">

                       <%-- <td class="col-md-3">
                            <label>Image:<span style="color: red"><b> *</b></span></label>
                        </td>
                        <td class="col-md-3">
                          
                            <asp:Image ID="ApplicantIMG" ReadOnly="true" runat="server" Width="120px" Height="120px" CssClass="img-responsive"/>
                           
                        </td>--%>
                       <td class="col-md-3">
                            <label>
                                Copy of the State Veterinary Council<br />
                                Registration Certificate:<span style="color:red"><b> *</b></span></label>
                        </td>
                        <td class="col-md-3">
                       
                            <asp:Image ID="ApplicantRegistrationCert" ReadOnly="true" runat="server" Width="420px" Height="220px" CssClass="img-responsive"/>
                         
                        </td>
                        <td class="col-md-3">
                            <label>DD in original<span style="color: red"><b> *</b></span></label>
                        </td>
                        <td class="col-md-3">
                           
                            <asp:Image ID="ApplicantDD" ReadOnly="true" runat="server" Width="420px" Height="220px" CssClass="img-responsive" />
                          
                        </td>
                    </tr>
                    <tr class="row">
                        <td class="col-md-3">
                            <label>
                                Date of Birth
                                        <br />
                                (Aadhar / Passport / DL/SSLC):<span style="color: red"><b> *</b></span></label>
                        </td>
                        <td class="col-md-3" >
                        
                            <asp:Image ID="ApplicantBirthProof" ReadOnly="true" runat="server" Width="420px" Height="220px" CssClass="img-responsive" />
                           
                        </td>
                        <td class="col-md-3" >
                            <label>
                                Degree certificate<br />
                                (BVSc&AH/MVSc/ PhD/ Other)<span style="color: red"><b> *</b></span></label>
                        </td>
                        <td class="col-md-3" >
                        
                            <asp:Image ID="ApplicantDegree" ReadOnly="true" runat="server" Width="420px" Height="220px" CssClass="img-responsive" />
                           
                        </td>
                    </tr>
                   <tr class="row">
                        
                      <td class="col-md-3">
                            <label>Image:<span style="color: red"><b> *</b></span></label>
                        </td>
                        <td class="col-md-3">
                          
                            <asp:Image ID="ApplicantIMG" ReadOnly="true" runat="server" Width="120px" Height="120px" CssClass="img-responsive"/>
                           
                        </td>
                        <td class="col-md-3">
                            <label>Appliant Signature:<span style="color: red"><b> *</b></span></label>
                        </td>
                        <td class="col-md-3">
                       
                            <asp:Image ID="ApplicantSign" ReadOnly="true" runat="server" Width="120px" Height="120px" CssClass="img-responsive"/>
                           
                        </td>
                    </tr>
                
                    <tr class="row form-group">
                        <td class="col-md-3">
                            <label>Name of State Veterinary Council:<span style="color: red;"><b> *</b></span></label>
                        </td>
                        <td class="col-md-3"">
                            <asp:TextBox ID="txtNameofCouncil" ReadOnly="true" style="margin-left: 1px;width: 420px; height:20px"  CssClass="form-control" AutoComplete="off" onkeypress="return lettersOnly(event)" runat="server" Text='<%# Eval("Registrar_Name") %>'>'></asp:TextBox>
                         
                        </td>
                        <td class="col-md-3">
                            <label>Address:<span style="color: red;"><b> *</b></span></label>
                        </td>
                        <td class="col-md-3">
                            <asp:TextBox ID="txtaddressd" ReadOnly="true" Style="margin-left: 1px; width: 420px; height:20px"  CssClass="form-control" runat="server" Text='<%# Eval("Registrar_Adresse") %>'>'></asp:TextBox>
                           
                        </td>
                    </tr>                 
        <tr>
            <td></td>
            <td>

                <asp:Button ID="btnUpdate" runat="server" Text="Verify" CssClass="btn" OnClick="btnUpdate_Click" />
                &nbsp;&nbsp;&nbsp;&nbsp;
                <asp:LinkButton ID="lnkdisApprove" runat="server" CssClass="btn" Text="Not Approve" OnClick="lnkdisApprove_Click"  Visible="true"></asp:LinkButton>
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
    <div class="reveal-modal-bg" id="divPopOnSave" runat="server" style="display: none; width: 70%; position: absolute; padding-left: 30%; padding-top: 20%">
        <asp:Panel ID="Panel3" runat="server" BackColor="#FFFFFF" Height="150px" Width="440px"
            BorderStyle="Solid" BorderWidth="3" BorderColor="#004040" ScrollBars="None">
            <table width="440px">
                <tr>
                    <td colspan="2" style="padding-top: 10px; color: Red; font-weight: bold;" align="center">
                        <asp:Label ID="lblalert" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="padding-top: 20px;" align="center">
                        <asp:Button ID="btnok" runat="server" Text="Ok" Width="100" CssClass="btn" OnClick="btnok_Click" />
                    </td>
                </tr>
            </table>
        </asp:Panel>
    </div>
   <%-- <script src="../js/jquery.min.js"></script>
    <script src="../js/jquery-1.6.1.min.js"></script>
    <script src="../js/jquery.reveal.js"></script>
    <script src="../js/jquery-2.2.4.js"></script>
    <script src="../js/bootstrap-datepicker.js"></script>
    <script src="../js/bootstrap-timepicker.js"></script>
    <script src="../js/bootstrap.js"></script>
    <script src="../js/daterangepicker.js"></script>
    <script src="../js/jquery.datetimepicker.js"></script>
    <script src="../js/jquery.treegrid.js"></script>
    <script src="../js/jquery.js"></script>
    <script src="../js/ValidationJs.js"></script>
    
    <script type="text/javascript">
   
        $('.select2').select2()

        $('.DateAdd').datepicker({
            autoclose: true,
            format: 'dd/MM/yyyy'
        })
        </script>--%>
     <asp:HiddenField ID="HFOK" runat="server" />
</asp:Content>

