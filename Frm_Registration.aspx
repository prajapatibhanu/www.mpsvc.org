<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Frm_Registration.aspx.vb" Inherits="JeeneKiRaah.Frm_Registration" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Registration</title>
    <meta http-equiv="expires" content="0" />
    <meta http-equiv="pragma" content="no-cache" />
    <meta http-equiv="last-modified" content="date" />
    <meta http-equiv="cache-control" content="max-age=0" />
    <meta http-equiv="cache-control" content="private" />
    <meta http-equiv="cache-control" content="no-cache" />
    <meta http-equiv="cache-control" content="no-store" />
    <meta http-equiv="cache-control" content="pre-check=0" />
    <meta http-equiv="cache-control" content="post-check=0" />
    <meta http-equiv="cache-control" content="must-revalidate" />
    <meta http-equiv="Content-Style-Type" content="text/css" />
    <meta http-equiv="Content-Script-Type" content="text/javascript" />
    <meta name="Keywords" content="Yojnaerp, ERP Software for NGO and Government Organisations, Duble entry  accounting software, Software for Budget Monitoring, Fund based accounting software, Accounting software for Non Profit ogranisation,Budget Management, Budget Estimate, Budget Allotment, Financial Management Software. " />
    <meta name="Description" content="Double entry based  software for online accounting, physical & financial monitoring and supervision of panchayats, NGOs and other entityin development  sector, Yojnaerp  is specially designed and developed software for physical and financial monitoring of agencies implementing the externally aided projects in development sector, Duble entry  accounting software with budget monitoring, civil work monitoring, Software for budget preparation and monitoring of budget  and expenditure variances of agencies implementing the externally aided projects in development sector, software for scheme/fund wise accounting  and  monitoring, software for  non-profit organizations. " />
    <meta name="Keywords" content="Pratham Softcon Pvt. Ltd." />
    <meta name="Description" content="Pratham Software is the IT Services, Solutions & Products firm.  We bring to market tailor-made, organization specific solutions  for  development and social sector. Multi-platform expertise, extensive reach and tested delivery mechanisms help us deliver reliable, high-quality, cost-effective IT solutions.  The Consulting portfolio includes Financial e-governance , Financial management support services and  Capacity building programs ." />
    <meta name="Keywords" content="Group Master, Agency Opening, Agency Type, Ledger, Ledger Type, Scheme, Scheme Type,Category Type, Category." />
    <meta name="Description" content="Double entry based  software for online accounting, physical & financial monitoring and supervision of panchayats, NGOs and other entityin development  sector, Yojnaerp  is specially designed and developed software for physical and financial monitoring of agencies implementing the externally aided projects in development sector, Duble entry  accounting software with budget monitoring, civil work monitoring, Software for budget preparation and monitoring of budget  and expenditure variances of agencies implementing the externally aided projects in development sector, software for scheme/fund wise accounting  and  monitoring, software for  non-profit organizations. " />
   
    <style type="text/css">
        .Frm_Head
{
	font-family: Arial Unicode MS;
	font-size: 20px;
	font-weight: bold;
	color: #fff;
	text-decoration: none;
	padding-left: 50px;
	text-transform: uppercase;
}
        .GridHead
{
            height:50px;
	margin: 0px;
	padding: 0px;
	background-color: #804040;
	font-family: Arial Unicode MS;
	font-size: 14px;
	font-weight: bold;
	color: #FFF;
	text-decoration: none;
}
        .yellow_bg_middle
{
	background-image: url(images/yellow_bg_middle.jpg);
	background-repeat: repeat-x;
	height: 43px;
}
        .main_tab_color
{
	background-color: #e69355;
}
        .btn
{
	background-color: #804040;
	font-family: 'Arial Unicode MS';
	border: 4px outset #804040;
	cursor: pointer;
	font-size: 13px;
	color: #FFFFFF;
	font-weight: bold;
	text-decoration: none;
}
    </style>
    <script type="text/javascript" src="CSS/CommonFunction.js"></script>

    <script type="text/javascript">
        function ckLengthOnChange(a, max) {
            var len = document.getElementById(a.id).value.length;
            if (len > max) {
                if (document.getElementById("HF_Choice").value == 0) {
                    alert("आप  " + max + " अक्षर से ज्यादा नहीं डाल सकते ।");
                }
                else {
                    alert("Can not enter more then " + max + " character.");
                }
                document.getElementById(a.id).value = document.getElementById(a.id).value.substring(0, max);
                return false;
            }
        }

        function SaveValidation()
        {
            var FirstName = document.getElementById('txtFirstName').value;
            var FirstName = document.getElementById('txtFirstName').value;
        }

    </script>

    <style type="text/css">
        .Width_1280 {
            width: 1200px;
        }

        .Width_1024 {
            width: 960px;
        }
        .DottedPanelBorder {
            height: 318px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
            <cc1:toolkitscriptmanager runat="Server" EnableScriptGlobalization="true" EnableScriptLocalization="true"
        ID="ScriptFormRegister" CombineScripts="false" />            
    <asp:UpdateProgress ID="UpdateProgressConsolidatedAbstractRegister" runat="server"
        DisplayAfter="5">
        <progresstemplate>
            <div id="Progress" style="position: absolute; left: 40%; top: 30%; visibility: visible;">
                <img alt="Wait............" src="../img/icon_update_checking.gif" id="IMG1" />
            </div>
            <div id="bgDiv">
                <br />
            </div>
        </progresstemplate>
    </asp:UpdateProgress>
        <table id="MainTable" border="0" align="center" cellpadding="0" cellspacing="0" width="100%">

            <tr class="GridHead">
                <td align="left" valign="bottom" >
                    <table width="100%" align="left" border="0" cellspacing="0" cellpadding="0">
                        <tr class="GridHead">
                            <td align="left" valign="middle" id="ICON"></td>
                            <td align="center" valign="middle" class="Frm_Head">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Label ID="LblHeader" runat="server" Text="Member's Registration"></asp:Label>
                            </td>
                            <td width="300" align="left" valign="middle" class="Frm_Txt">
                                <label><b>Language: </b></label>
                                <asp:DropDownList ID="ddlLanguage" runat="server" CssClass="ddl" Width="120">
                                    <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                    <asp:ListItem Text="English" Value="1"></asp:ListItem>
                                    <asp:ListItem Text="Hindi" Value="2"></asp:ListItem>
                                </asp:DropDownList>
                            </td>

                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td valign="top" class="main_tab_color" align="center">
                    <asp:UpdatePanel ID="UpdatePanelConsolidatedAbstractRegister" runat="server">
                        <ContentTemplate>
                            <table class="accordionContentNew" width="100%" align="center">
                                <tr>
                                    <td align="center">
                                        <asp:Label ID="LblError" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center">
                                        <table width="95%" cellpadding="0px" cellspacing="5">
                                            <tr>
                                                <td align="center" valign="top" style="height: 500px;">
                                                    <asp:Panel runat="server" ID="FundAllotmentReportPanel">
                                                        <table width="100%" class="DottedPanelBorder" border="0" cellpadding="3" cellspacing="3">
                                                            <tr>
                                                                <td align="left">
                                                                    <label><b>Name:</b></label>
                                                                </td>
                                                                <td align="left">
                                                                    <%--<input Placeholder="First Name" id="firstName" name="firstName" onchange="SpecialCharNotAllow(this, event);" onkeyup="MaxLength(this, 50),SpecialCharNotAllow(this, event);" type="text" value="" />--%>
                                                                    <asp:TextBox runat="server" MaxLength="50" Placeholder="First Name" ID="txtFirstName" onchange="SpecialCharNotAllow(this, event);" onkeyup="ckLengthOnChange(this, 50),SpecialCharNotAllow(this, event);"></asp:TextBox>
                                                                    <label style="color: red;"><b>*</b></label>
                                                                    <asp:TextBox runat="server" Placeholder="Middle Name" MaxLength="50" ID="txtMiddleName" onchange="SpecialCharNotAllow(this, event);" onkeyup="ckLengthOnChange(this, 50),SpecialCharNotAllow(this, event);"></asp:TextBox>
                                                                    <asp:TextBox runat="server" MaxLength="50" Placeholder="Last Name" ID="txtLastName" onchange="SpecialCharNotAllow(this, event);" onkeyup="ckLengthOnChange(this, 50),SpecialCharNotAllow(this, event);"></asp:TextBox>
                                                                </td>

                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    <label><b>Mobile No.:</b></label>
                                                                    <%--<asp:Label ID="lblPaybillNo" CssClass="rb" runat="server" Text="Mobile No. :"></asp:Label>--%>
                                                                </td>
                                                                <td align="left">
                                                                    <%--<input id="StdCode" name="StdCode" onkeyup="MaxLength(this, 3),AllowNumbersOnly(this);" style="width:50px;" type="text" value="" />--%>
                                                                    <asp:TextBox Width="40" MaxLength="3" runat="server" Placeholder="+91" ID="txtISDCode" onchange="SpecialCharNotAllow(this, event);" onkeyup="MaxLength(this, 3),SpecialCharNotAllow(this, event);"></asp:TextBox>
                                                                     <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" TargetControlID="txtISDCode"
                                                                        ValidChars="+0123456789">
                                                                    </cc1:FilteredTextBoxExtender>
                                                                    <%--<span class="field-validation-valid" data-valmsg-for="StdCode" data-valmsg-replace="true"></span>--%>
                                                                    <%--<input id="MobNo" name="MobNo" onkeyup="MaxLength(this, 15),AllowNumbersOnly(this);" style="width:150px" type="text" value="" />--%>
                                                                    <asp:TextBox runat="server" MaxLength="20" Placeholder="" ID="txtMobileNo" onkeyup="ckLengthOnChange(this, 20),AllowNumbersOnly(this);"></asp:TextBox>
                                                                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="txtMobileNo"
                                                                        ValidChars="0123456789">
                                                                    </cc1:FilteredTextBoxExtender>
                                                                    <label style="color: red;"><b>*</b></label>

                                                                    <%--<span class="field-validation-valid" data-valmsg-for="MobNo" data-valmsg-replace="true"></span>--%>
                                                                    
                                                                </td>

                                                            </tr>

                                                            <tr>
                                                                <td align="left">
                                                                    <label><b>Email:</b></label></td>

                                                                <td align="left">
                                                                    <%--<input id="Email" name="Email" onchange="SpecialCharNotAllow(this, event);" onkeyup="MaxLength(this, 50),SpecialCharNotAllow(this, event);" style="width:150px" type="text" value="" />--%>

                                                                    <asp:TextBox runat="server" Width="250" ID="txtEmail" MaxLength="50" onkeyup="ckLengthOnChange(this, 50);" Onchange="CheckEmail()"></asp:TextBox>
                                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" Font-Size="Small"
                                                                            Font-Bold="True" ErrorMessage="Please enter valid email id." ControlToValidate="txtEmail"
                                                                            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>

                                                                </td>

                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    <label><b>Gender:</b></label>
                                                                </td>
                                                                <td align="left">
                                                                    <asp:RadioButton ID="rbMale" runat="server" GroupName="Gender"
                                                                        Text="Male" Font-Bold="true" />
                                                                    <asp:RadioButton ID="rbFemale" runat="server" GroupName="Gender"
                                                                        Text="Female" Font-Bold="true" />

                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    <label><b>Country:</b></label>
                                                                </td>
                                                                <td align="left">
                                                                    <asp:DropDownList ID="ddlCountry" runat="server" CssClass="ddl" Width="150">
                                                                        <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                                                        <asp:ListItem Text="India" Value="1"></asp:ListItem>
                                                                        <asp:ListItem Text="China" Value="2"></asp:ListItem>
                                                                        <asp:ListItem Text="America" Value="3"></asp:ListItem>
                                                                    </asp:DropDownList>

                                                                </td>
                                                            </tr>

                                                            <tr>
                                                                <td align="left">
                                                                    <label><b>State:</b></label>
                                                                </td>
                                                                <td align="left">
                                                                    <asp:DropDownList ID="ddlState" runat="server" CssClass="ddl" Width="150">
                                                                        <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                                                        <asp:ListItem Text="Madhya Pradesh" Value="1"></asp:ListItem>
                                                                        <asp:ListItem Text="Uttar Pradesh" Value="2"></asp:ListItem>
                                                                        <asp:ListItem Text="Andhra Pradesh" Value="3"></asp:ListItem>
                                                                        <asp:ListItem Text="Maharashtra " Value="4"></asp:ListItem>
                                                                    </asp:DropDownList>


                                                                </td>
                                                            </tr>

                                                            <tr>
                                                                <td align="left">
                                                                    <label><b>City:</b></label>
                                                                </td>
                                                                <td align="left">
                                                                    <asp:DropDownList ID="ddlCity" runat="server" CssClass="ddl" Width="150">
                                                                        <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                                                        <asp:ListItem Text="Bhopal" Value="1"></asp:ListItem>
                                                                        <asp:ListItem Text="Gwalior" Value="2"></asp:ListItem>
                                                                        <asp:ListItem Text="Jabalpur" Value="3"></asp:ListItem>
                                                                        <asp:ListItem Text="Indore" Value="4"></asp:ListItem>
                                                                    </asp:DropDownList>

                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    <label><b>Duration of Association With "Jine Ki Raah" : </b></label>

                                                                </td>

                                                                <td align="left">
                                                                    <asp:DropDownList ID="ddlDuration" runat="server" CssClass="ddl" Width="150">
                                                                        <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                                                        <asp:ListItem Text="1 Year" Value="1"></asp:ListItem>
                                                                        <asp:ListItem Text="2 Year" Value="2"></asp:ListItem>
                                                                        <asp:ListItem Text="3 Year" Value="3"></asp:ListItem>
                                                                        <asp:ListItem Text="More than 3 Year" Value="4"></asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </td>

                                                            </tr>
                                                            <tr>
                                                                <td colspan="2" style="vertical-align: bottom" class="mGrid">
                                                                    <table align="center" width="800" cellpadding="3" cellspacing="5" border="0">
                                                                        <tr>
                                                                            <td align="center">
                                                                                <asp:Button ID="btnSave" runat="server" CssClass="btn" Text="Save" Width="80" />
                                                                                <asp:Button ID="btnCancel" runat="server" CssClass="btn" Text="Cancel" Width="80" />
                                                                                
                                                                            </td>
                                                                        </tr>
                                                                         <tr>
                                                                            <td align="center">
                                                                              <asp:Panel ID="pnlsave" Visible="false"  runat="server" >
                                                                                  <table>
                                                                                      <tr>
                                                                                          <td>
                                                                                              <asp:Label ID="lblMembership" runat="server" ></asp:Label>
                                                                                             
                                                                                               <asp:Label ID="lblContinue" Text="If you want to be a part of guiness book of world Records" runat="server" ></asp:Label>
                                                                                              <asp:LinkButton ID="btnRedirect" runat="server" Text="Click Here for more details"></asp:LinkButton>
                                                                                          </td>
                                                                                      </tr>

                                                                                  </table>

                                                                              </asp:Panel>
                                                                            </td>
                                                                        </tr>

                                                                    </table>
                                                                </td>
                                                            </tr>
                                                            <%---------------------%>
                                                            <div id="dvMore" style="display:none">
                                                                <table>
                                                                    <tr>
                                                                        <td>
                                                                            <label></label>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </div>
                                                        </table>
                                                        <%--<cc1:ModalPopupExtender ID="mymodel" runat="server"  TargetControlID="btnsave" BackgroundCssClass="yellow_bg_middle"--%>  
                                                    </asp:Panel>
                                                </td>
                                            </tr>
                                        </table>
                                        <asp:HiddenField ID="HF_Choice" runat="server" />
                                        <asp:HiddenField ID="HF_ErrorMsg" runat="server" />
                                    </td>
                                </tr>
                            </table>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
