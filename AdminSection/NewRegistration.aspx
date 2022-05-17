<%@ Page Title="" Language="C#" MasterPageFile="~/AdminSection/AdminMaster.master"  
    AutoEventWireup="true" CodeFile="NewRegistration.aspx.cs" Inherits="AdminSection_NewRegistration" %>
    <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    
    
    <table width="100%" cellpadding="0" cellspacing="0">
        <tr>
            <td colspan="4">
                <asp:Label ID="lblMsg" runat="server" Font-Bold="True" Font-Size="15pt" ></asp:Label>
                
                </td>
        </tr>
        <tr style="display:none;">
            <td>
                Registration No :
            </td>
            <td>
                
                <asp:TextBox ID="txtRegNo" runat="server" MaxLength="30" onkeypress='javascript:tbx_fnInteger(event, this);' CssClass="txtbox reqirerd"></asp:TextBox>
                
            </td>
            <td>
                Registration Date :
            </td>
            <td>
                
                <asp:TextBox ID="txtRegDate" runat="server" MaxLength="10"  CssClass="txtbox reqirerd"></asp:TextBox>
                
            </td>
        </tr>
        <tr>
            <td>
                First Name :
            </td>
            <td>
                <asp:TextBox ID="txtFName" runat="server" MaxLength="60" onkeypress='javascript:tbx_fnAlphaOnly(event, this);'  CssClass="txtbox reqirerd"></asp:TextBox>
            </td>
            <td>
                Middle Name :
            </td>
            <td>
                <asp:TextBox ID="txtMName" runat="server" onkeypress='javascript:tbx_fnAlphaOnly(event, this);' MaxLength="60"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Last Name :
            </td>
            <td>
                <asp:TextBox ID="txtLastName" runat="server" MaxLength="60" onkeypress='javascript:tbx_fnAlphaOnly(event, this);'  CssClass="txtbox reqirerd"></asp:TextBox>
            </td>
            <td>
                Father Name :
            </td>
            <td>
                <asp:TextBox ID="txtFatherName" runat="server" MaxLength="200" onkeypress='javascript:tbx_fnAlphaOnly(event, this);' CssClass="txtbox reqirerd"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Date Of Birth :
            </td>
            <td>
                <asp:TextBox ID="txtDOB" runat="server" MaxLength="10"  CssClass="txtbox reqirerd"></asp:TextBox>
            </td>
            <td>
                Gender :
            </td>
            <td>
                <asp:DropDownList ID="ddlGender" runat="server" CssClass="txtbox">
                    <asp:ListItem>Male</asp:ListItem>
                    <asp:ListItem>Female</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                Sector :
            </td>
            <td>
                <asp:DropDownList ID="ddlPresentOcc" runat="server"  CssClass="txtbox">
                    <asp:ListItem>Office</asp:ListItem>
                    <asp:ListItem>Adminiatration</asp:ListItem>
                    <asp:ListItem Value="Semi Govt.">Clinics</asp:ListItem>
                    <asp:ListItem Value="Semi Govt.">Poultry</asp:ListItem>
                    <asp:ListItem Value="Semi Govt.">Dairy</asp:ListItem>
                    <asp:ListItem Value="Semi Govt.">Pharma</asp:ListItem>
                    <asp:ListItem Value="Semi Govt.">Others</asp:ListItem>
                    
                </asp:DropDownList>
            </td>
            <td>
            </td>
            <td>
            </td>
        </tr>
           <tr>
            <td>
                Organization :
            </td>
            <td>
                <asp:DropDownList ID="ddlorg" runat="server"  CssClass="txtbox">
                    <asp:ListItem>Private</asp:ListItem>
                    <asp:ListItem>Govt.</asp:ListItem>
                    <asp:ListItem Value="Semi Govt.">Semi Govt.</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
            </td>
            <td>
            </td>
        </tr>
        
        
            <tr>
            <td>
                Department :
            </td>
            <td>
                <asp:DropDownList ID="ddldept" runat="server"  CssClass="txtbox">
                    <asp:ListItem>Private</asp:ListItem>
                    <asp:ListItem>Govt.</asp:ListItem>
                    <asp:ListItem Value="Semi Govt.">Semi Govt.</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
            </td>
            <td>
            </td>
        </tr>
        
        <tr>
            <td>
                Designation :
            </td>
            <td>
                <asp:DropDownList ID="ddldesig" runat="server"  CssClass="txtbox">
                    <asp:ListItem>Private</asp:ListItem>
                    <asp:ListItem>Govt.</asp:ListItem>
                    <asp:ListItem Value="Semi Govt.">Semi Govt.</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td>
              <h3 class="bluefnt">  Residential Address</h3>
            </td>
            <td>
                
               </td>
            <td>
                
            </td>
            <td>
                
            </td>
        </tr>
        <tr>
            <td>
                Address :
            </td>
            <td>
                <asp:TextBox ID="txtResAdd" runat="server" MaxLength="200"  CssClass="txtbox reqirerd"></asp:TextBox>
            </td>
            <td>
                City :
            </td>
            <td>
                <asp:TextBox ID="txtResCity" runat="server" MaxLength="50" onkeypress='javascript:tbx_fnAlphaOnly(event, this);' CssClass="txtbox reqirerd"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                District :
            </td>
            <td>
                <asp:TextBox ID="txtResDistrict" runat="server" MaxLength="50"  onkeypress='javascript:tbx_fnAlphaOnly(event, this);' CssClass="txtbox reqirerd"></asp:TextBox>
            </td>
            <td>
                State :
            </td>
            <td>
             <asp:DropDownList ID="ddlResState" runat="server"  CssClass="txtbox" 
                    oninit="ddlResState_Init">
                    
                </asp:DropDownList>
            </td>
        </tr>
         <tr>
            <td>
                Pin Code :
            </td>
            <td>
                <asp:TextBox ID="txtResPinCode" runat="server" MaxLength="6"  onblur="return ValidPinNo('txtResPinCode');"  onkeypress='javascript:tbx_fnInteger(event, this);' CssClass="txtbox reqirerd"></asp:TextBox>
            </td>
            <td>
                
            </td>
            <td>
            
            </td>
        </tr>
        <tr>
            <td>
              <h3 class="bluefnt">  Professional Address</h3>
            </td>
            <td>
            </td>
            <td>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td>
                Address :
            </td>
            <td>
                <asp:TextBox ID="txtProAdd" runat="server" MaxLength="200"   CssClass="txtbox"></asp:TextBox>
            </td>
            <td>
                City :
            </td>
            <td>
                <asp:TextBox ID="txtProCity" runat="server" MaxLength="50" onkeypress='javascript:tbx_fnAlphaOnly(event, this);' CssClass="txtbox"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                District :
            </td>
            <td>
                <asp:TextBox ID="txtProDistrict" runat="server" MaxLength="50" onkeypress='javascript:tbx_fnAlphaOnly(event, this);' CssClass="txtbox"></asp:TextBox>
            </td>
            <td>
                State :
            </td>
            <td><asp:DropDownList ID="ddlProState" runat="server"  CssClass="txtbox" 
                    oninit="ddlProState_Init">
                    
                </asp:DropDownList>
            </td>
        </tr>
          <tr>
            <td>
                Pin Code :
            </td>
            <td>
                <asp:TextBox ID="txtProPinCode" runat="server" MaxLength="6"  onblur="return ValidPinNo('txtProPinCode');"  onkeypress='javascript:tbx_fnInteger(event, this);' CssClass="txtbox"></asp:TextBox>
            </td>
            <td>
                
            </td>
            <td>
            
            </td>
        </tr>
        <tr>
            <td>
               <h3 class="bluefnt"> Permanent Address</h3>
            </td>
            <td>
            </td>
            <td>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td>
                Address :
            </td>
            <td>
                <asp:TextBox ID="txtPerAdd" runat="server" MaxLength="200"  CssClass="txtbox"></asp:TextBox>
            </td>
            <td>
                City :
            </td>
            <td>
                <asp:TextBox ID="txtPerCity" runat="server" MaxLength="50" onkeypress='javascript:tbx_fnAlphaOnly(event, this);'  CssClass="txtbox"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                District :
            </td>
            <td>
                <asp:TextBox ID="txtPerDistrict" runat="server" MaxLength="200" onkeypress='javascript:tbx_fnAlphaOnly(event, this);'
                    CssClass="txtbox"></asp:TextBox>
            </td>
            <td>
                State :
            </td>
            <td><asp:DropDownList ID="ddlPerState" runat="server"  CssClass="txtbox" 
                    oninit="ddlPerState_Init">
                    
                </asp:DropDownList>
            </td>
        </tr>
          <tr>
            <td>
                Pin Code :
            </td>
            <td>
                <asp:TextBox ID="txtPerPinCode" runat="server" MaxLength="6" onblur="return ValidPinNo('txtPerPinCode');"  onkeypress='javascript:tbx_fnInteger(event, this);'  CssClass="txtbox"></asp:TextBox>
            </td>
            <td>
                
            </td>
            <td>
            
            </td>
        </tr>
        <tr>
            <td>
                Preffered Address :
            </td>
            <td>
                
                <asp:DropDownList ID="ddlPreffAddress" runat="server"  CssClass="txtbox">
                    <asp:ListItem>Residential</asp:ListItem>
                    <asp:ListItem>Professional</asp:ListItem>
                    <asp:ListItem >Permanent</asp:ListItem>
                </asp:DropDownList>
                
            </td>
            <td>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td>
                Phone No :
            </td>
            <td>
                <asp:TextBox ID="txtPhoneNo" runat="server" MaxLength="15"   CssClass="txtbox reqirerd" onkeypress='javascript:tbx_fnInteger(event, this);'
                    ></asp:TextBox>
            </td>
            <td>
                Mobile No :
            </td>
            <td>
                <asp:TextBox ID="txtMobileNo" runat="server" MaxLength="10"  CssClass="txtbox reqirerd" onkeypress='javascript:tbx_fnInteger(event, this);'
                    ></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Fax No :
            </td>
            <td>
                <asp:TextBox ID="txtFaxNo" runat="server" MaxLength="15"  CssClass="txtbox" onkeypress='javascript:tbx_fnInteger(event, this);'
                    ></asp:TextBox>
            </td>
            <td>
                Email Id :
            </td>
            <td>
                <asp:TextBox ID="txtEmailId" runat="server" MaxLength="100"  CssClass="txtbox reqirerd" onblur="return EmailValid();"
                    ></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Preffered Phone No :
            </td>
            <td>
                
                <asp:TextBox ID="txtPreffPhoneNo" runat="server" MaxLength="15"   CssClass="txtbox" onkeypress='javascript:tbx_fnInteger(event, this);'
                    ></asp:TextBox>
                
            </td>
            <td>
                &nbsp;</td>
            <td>
                
                &nbsp;</td>
        </tr>
        <tr>
            <td style="height: 27px" colspan="4">
               <h3 class="bluefnt"> Qualification</h3>
                &nbsp; &nbsp;</td>
        </tr>
        <tr>
            <td colspan="4">
                <table border="1" cellpadding="0" cellspacing="0" style="width: 100%">
                    <tr>
                        <td style="font-weight: bold; width: 100px; height: 30px">
                            Degree Name</td>
                        <td style="font-weight: bold; width: 100px; height: 30px">
                            Name of University</td>
                        <td style="font-weight: bold; width: 100px; height: 30px">
                            Name of Collage
                        </td>
                        <td style="font-weight: bold; width: 100px; height: 30px">
                            Passing Year
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100px; height: 35px;">
                            B.V.SC.&amp; A.H.</td>
                        <td style="width: 100px; height: 35px;">
                            <asp:DropDownList ID="ddl1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddl1_SelectedIndexChanged">
                            </asp:DropDownList></td>
                        <td style="width: 100px; height: 35px;">
                            <asp:DropDownList ID="ddlc1" runat="server">
                            </asp:DropDownList></td>
                        <td style="width: 100px; height: 35px;">
                            <asp:DropDownList ID="ddlY1" runat="server">
                            </asp:DropDownList></td>
                    </tr>
                    <tr>
                        <td style="width: 100px">
                            M.V.SC.</td>
                        <td style="width: 100px">
                            <asp:DropDownList ID="ddl2" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddl2_SelectedIndexChanged">
                            </asp:DropDownList></td>
                        <td style="width: 100px">
                            <asp:DropDownList ID="ddlc2" runat="server">
                            </asp:DropDownList></td>
                        <td style="width: 100px">
                            <asp:DropDownList ID="ddlY2" runat="server">
                            </asp:DropDownList></td>
                    </tr>
                    <tr>
                        <td style="width: 100px">
                            PHD</td>
                        <td style="width: 100px">
                            <asp:DropDownList ID="ddl3" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddl3_SelectedIndexChanged">
                            </asp:DropDownList></td>
                        <td style="width: 100px">
                            <asp:DropDownList ID="ddlc3" runat="server">
                            </asp:DropDownList></td>
                        <td style="width: 100px">
                            <asp:DropDownList ID="ddlY3" runat="server">
                            </asp:DropDownList></td>
                    </tr>
                    <tr>
                        <td style="width: 100px">
                            Other</td>
                        <td style="width: 100px">
                            <asp:DropDownList ID="ddl4" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddl4_SelectedIndexChanged">
                            </asp:DropDownList></td>
                        <td style="width: 100px">
                            <asp:DropDownList ID="ddlc4" runat="server">
                            </asp:DropDownList></td>
                        <td style="width: 100px">
                            <asp:DropDownList ID="ddlY4" runat="server">
                            </asp:DropDownList></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr id="Tr1" runat="server" visible="false">
            <td colspan="4">
            </td>
        </tr>
        <tr id="Tr2" visible="false"  runat="server" >
            <td>
                Qualification :
            </td>
            <td>
                
                <asp:TextBox ID="txtQualification" runat="server" MaxLength="100"  CssClass="txtbox reqirerd"  onkeypress="tbx_fnAlphaNumericOnly(event, this);"
                    ></asp:TextBox>
                
            </td>
            <td>
                &nbsp;</td>
            <td>
                
                &nbsp;</td>
        </tr>
        <tr id="Tr3" visible="false"  runat="server" >
            <td>
                Year Of Passing :
             </td>
            <td>
                
                <asp:DropDownList ID="ddlPassingYear" runat="server"  CssClass="txtbox" 
                    oninit="ddlPassingYear_Init">
                </asp:DropDownList>
                
            </td>
            <td>
                  University / Institue Name :
            </td>
            <td>
                  <asp:TextBox ID="txtUniversity" runat="server" MaxLength="200"   CssClass="txtbox reqirerd"  onkeypress="tbx_fnAlphaNumericOnly(event, this);"
                    ></asp:TextBox>
            </td>
        </tr>
        <tr id="Tr4" visible="false"  runat="server" >
            <td>
              
            </td>
            <td>
                
              
                
            </td>
            <td>
                
            </td>
            <td>
                
            </td>
        </tr>
        <tr id="Tr5" visible="false"  runat="server" >
            <td>
                  <h3 class="bluefnt">Other Qualification</h3>
                   
                
            </td>
            <td>
                
            </td>
            <td>
                
            </td>
        </tr>
        <tr id="Tr6" visible="false"  runat="server" >
            <td>
                Other Qualification :
            </td>
            <td>
                
                <asp:TextBox ID="txtOtherQualification" runat="server" MaxLength="200"   CssClass="txtbox"  onkeypress="tbx_fnAlphaNumericOnly(event, this);"
                    ></asp:TextBox>
                
            </td>
            <td>
                Year Of Passing :
            </td>
            <td>
                
                <asp:DropDownList ID="ddlOtherPassingYear" runat="server"  CssClass="txtbox"  
                    oninit="ddlOtherPassingYear_Init">
                </asp:DropDownList>
                
            </td>
        </tr>
        <tr id="Tr7" visible="false"  runat="server" >
            <td>
                University / Institue Name :
            </td>
            <td>
                
                <asp:TextBox ID="txtOtherUniversity" runat="server" MaxLength="15"   CssClass="txtbox"  onkeypress="tbx_fnAlphaNumericOnly(event, this);"
                    ></asp:TextBox>
                
            </td>
            <td>
                     
                
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                Domicile certificate :
            </td>
            <td>
                <asp:FileUpload ID="FileUpload1" runat="server" /></td>
            <td>
                Degree Certificate</td>
            <td>
                <asp:FileUpload ID="FileUpload2" runat="server" /></td>
        </tr>
        <tr>
            <td>
                Photo</td>
            <td>
                <asp:FileUpload ID="FileUpload3" runat="server" /></td>
            <td>
                Others :
            </td>
            <td>
                <asp:FileUpload ID="FileUpload4" runat="server" /></td>
        </tr>
        
        <tr>
            <td>
                10th Marksheet</td>
            <td>
                <asp:FileUpload ID="FileUpload5" runat="server" /></td>
            <td>
               
            </td>
            <td>
               
        </tr>
        <tr>
            <td>
               Degree Date</td>
            <td>
           <asp:TextBox ID="txtDegreedate" runat="server" ></asp:TextBox>
               <cc1:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txtDegreedate"
        Format="dd/MM/yyyy">
    </cc1:CalendarExtender>
    <cc1:CalendarExtender ID="CalendarExtender4" runat="server" TargetControlID="txtDegreedate" Format="dd/MM/yyyy">
    </cc1:CalendarExtender>
            <td>
                Degree Id :
            </td>
            <td>
                <asp:TextBox ID="txtDegid" runat="server" ></asp:TextBox>
            </td>
            <td>
              
        </tr>
        <tr id="Tr8" runat="server" visible="false" >
            <td>
                
                Registration Status :
            </td>
            <td>
                  <asp:DropDownList ID="ddlRegiStatus" runat="server"  CssClass="txtbox">
                    <asp:ListItem>New</asp:ListItem>
                    <asp:ListItem>NOC</asp:ListItem>
                    <asp:ListItem >Dead</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                
            </td>
            <td>
                
            </td>
        </tr>
          <tr>
            <td>
              Payment Type :
            </td>
            <td>
                
               <asp:RadioButton ID="rbOnline"  runat="server" Text="Online Payment" GroupName="rbPayment" />
                <asp:RadioButton ID="rboffline"  runat="server" Text="Offline Payment" Checked="true"  GroupName="rbPayment" />
            </td>
            <td>
               &nbsp;</td>
            <td>
                
                 &nbsp;
        </tr>
        
        <tr>
            <td style="height: 27px" colspan="4">
               <h3 class="bluefnt"> Payment</h3>
                &nbsp; &nbsp;</td>
        </tr>
        <tr>
            <td>
               Cheque/DD No :
            </td>
            <td>
                
                <asp:TextBox ID="txtcheque" runat="server" MaxLength="15"   CssClass="txtbox" 
                    ></asp:TextBox>
                
            </td>
            <td>
                Bank Name</td>
            <td>
                
                 <asp:TextBox ID="txtbank" runat="server" MaxLength="15"   CssClass="txtbox" 
                    ></asp:TextBox></td>
        </tr>
          <tr>
            <td>
               Date :
            </td>
            <td>
                
                <asp:TextBox ID="txtPaymentDate" runat="server" MaxLength="15"   CssClass="txtbox" 
                    ></asp:TextBox>
                     <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtPaymentDate"
        Format="dd/MM/yyyy">
    </cc1:CalendarExtender>
    <cc1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtPaymentDate" Format="dd/MM/yyyy">
    </cc1:CalendarExtender>
                
            </td>
            <td>
               &nbsp;</td>
            <td>
                
                 &nbsp;</td>
        </tr>
        
        <tr>
            <td>
                
            </td>
            <td>
                
                <asp:Button ID="btnSubmit" runat="server" Text="Save"  CssClass="btn" 
                    onclick="btnSubmit_Click"/>
                
            </td>
            <td>
                
            </td>
            <td>
                
            </td>
        </tr>
        <tr>
            <td>
                
            </td>
            <td>
                
            </td>
            <td>
                
            </td>
            <td>
                
            </td>
        </tr>
    </table> 
    <asp:HiddenField ID="hdnFile" runat="server" />
    <cc1:CalendarExtender ID="CetxtTenderSubDt" runat="server" TargetControlID="txtDOB"
        Format="dd/MM/yyyy">
    </cc1:CalendarExtender>
    <cc1:CalendarExtender ID="CetxtDate" runat="server" TargetControlID="txtRegDate" Format="dd/MM/yyyy">
    </cc1:CalendarExtender>
</asp:Content>
