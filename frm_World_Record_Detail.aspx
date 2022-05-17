<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="frm_World_Record_Detail.aspx.vb" Inherits="JeeneKiRaah.frm_World_Record_Detail" %>
<%@ Register Namespace="AjaxControlToolkit" Assembly="AjaxControlToolKit" TagPrefix="cc1" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Jine Ki Raah</title>
    <script type="text/javascript" src="Scripts/CommonFunction.js"></script>
    <script type="text/javascript" src="Scripts/HelperScript.js"></script>
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
          .GridRow
{
            height:20px;
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
</head>

<body>

    <form id="form1" runat="server">
        <cc1:ToolkitScriptManager runat="Server" EnableScriptGlobalization="true" EnableScriptLocalization="true" EnablePartialRendering="true" ScriptMode="Release"
                ID="ScriptManager1" CombineScripts="true" />  
    <table align="center" width="90%" border="1" cellpadding="3" cellspacing="5">
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
                <td  align="left"  class="main_tab_color">
                    <table width="80%">
                        <tr>
                            <td align="center" style="color:red; font-family:Calibri;">

                                <asp:Label ID="lblerrormessage" runat="server" Text="" style="font-weight: 700"></asp:Label>
                            </td>
                        </tr>
                    </table>
                  
        <asp:UpdatePanel runat="server" ID="UPJKR">
        <ContentTemplate>
        <div id="Tab2">
            <table align="center" width="100%" cellpadding="3" cellspacing="5">
                <tr>

                    <td align="Center">
                        <label><b>Details Of Meditation With Hanuman Chalisa:</b></label>
                    </td>
                </tr>
                <tr>

                    <td align="Center">
                        <asp:TextBox  ID="txtmeditation"  width="86%" Height="100px"  runat="server" ReadOnly="True" TextMode="MultiLine"></asp:TextBox>
                    </td>
                </tr>


                <tr class="GridRow">
                    <td align="Left" width="100%" style="font-size:16pt;">
                        <label><b>Refference:</b></label>
                    </td>

                </tr>

                <tr>
                    <td>
                        <table>
                         
                            <tr>
                                <td align="Center"  ><label><b>1</b></label></td>
                                <td align="left"  >

                                    <asp:TextBox ID="txtrefname1" onkeyup = "MaxLength(this, 50),SpecialCharNotAllow(this, event);" onchange = "SpecialCharNotAllow(this, event);" placeHolder="Name" MaxLength="50" runat="server"></asp:TextBox>
                                   
                                       <td>
                                           <asp:DropDownList ID="DropDownList1" runat="server">
                                               <asp:ListItem Value="0">Select </asp:ListItem>
                                               <asp:ListItem Value="1">Male</asp:ListItem>
                                               <asp:ListItem Value="2">Female</asp:ListItem>
                                           </asp:DropDownList>
                                    </td>
                                   

                                </td>
                                <td align="Center" >

                                   
                                    <asp:TextBox ID="txtrefmob1" onkeyup = "MaxLength(this, 50),SpecialCharNotAllow(this, event);" onchange = "SpecialCharNotAllow(this, event);" placeHolder="Mobile No." MaxLength="20" runat="server"></asp:TextBox>
                                     <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" ValidChars="0123456789/-" TargetControlID="txtrefmob1">  </cc1:FilteredTextBoxExtender>
                                </td>
                                <td align="Center" >
                                    <asp:TextBox ID="txtrefemail1" placeHolder="Email"  MaxLength="50" runat="server"></asp:TextBox>
                                   

                                </td>
                            </tr>
                            <tr>
                                <td align="Center"><label><b>2</b></label></td>
                                <td align="left">
                                   
                                    <asp:TextBox ID="txtrefname2" placeHolder="Name" onkeyup = "MaxLength(this, 50),SpecialCharNotAllow(this, event);" onchange = "SpecialCharNotAllow(this, event);" MaxLength="50" runat="server"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:DropDownList ID="DropDownList2" runat="server">
                                        <asp:ListItem Value="0">Select </asp:ListItem>
                                        <asp:ListItem Value="1">Male</asp:ListItem>
                                        <asp:ListItem Value="2">Female</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td align="Center"  >
                                    <asp:TextBox ID="txtrefmob2" placeHolder="Mobile No." onkeyup = "MaxLength(this, 50),SpecialCharNotAllow(this, event);" onchange = "SpecialCharNotAllow(this, event);" MaxLength="20" runat="server"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" ValidChars="0123456789/-" TargetControlID="txtrefmob2">  </cc1:FilteredTextBoxExtender>
                                </td>
                                <td align="Center" >
                                    <asp:TextBox ID="txtrefemail2"   placeHolder="Email" MaxLength="50"  runat="server"></asp:TextBox>
</td>
                            </tr>
                            <tr>
                                <td align="Center" ><label><b>3</b></label></td>

                                <td>
                                   
                                    <asp:TextBox ID="txtrefname3" placeHolder="Name" MaxLength="50"  onkeyup = "MaxLength(this, 50),SpecialCharNotAllow(this, event);" onchange = "SpecialCharNotAllow(this, event);" runat="server"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:DropDownList ID="DropDownList3" runat="server">
                                        <asp:ListItem Value="0">Select </asp:ListItem>
                                        <asp:ListItem Value="1">Male</asp:ListItem>
                                        <asp:ListItem Value="2">Female</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td align="left">
                                     <asp:TextBox ID="txtrefmob3" placeHolder="Mobile No." MaxLength="20" onkeyup = "MaxLength(this, 50),SpecialCharNotAllow(this, event);" onchange = "SpecialCharNotAllow(this, event);" runat="server"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server" ValidChars="0123456789/-" TargetControlID="txtrefmob3">  </cc1:FilteredTextBoxExtender>
                                </td>
                                <td align="Center" >
                                    <asp:TextBox ID="txtrefemail3"  placeHolder="Email" MaxLength="50"   runat="server"></asp:TextBox>

                                </td>
                            </tr>
                            <tr>
                                <td align="Center" ><label><b>4</b></label></td>
                                <td >
                                   
                                    <asp:TextBox ID="txtrefname4"  placeHolder="Name" MaxLength="50" onkeyup = "MaxLength(this, 50),SpecialCharNotAllow(this, event);" onchange = "SpecialCharNotAllow(this, event);" runat="server"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:DropDownList ID="DropDownList4" runat="server">
                                        <asp:ListItem Value="0">Select </asp:ListItem>
                                        <asp:ListItem Value="1">Male</asp:ListItem>
                                        <asp:ListItem Value="2">Female</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td align="Center">
                                    <asp:TextBox ID="txtrefmob4" placeHolder="Mobile No." MaxLength="20" onkeyup = "MaxLength(this, 50),SpecialCharNotAllow(this, event);" onchange = "SpecialCharNotAllow(this, event);" runat="server"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server" ValidChars="0123456789/-" TargetControlID="txtrefmob4">  </cc1:FilteredTextBoxExtender>
                                </td>
                                <td align="Center">
                                     <asp:TextBox ID="txtrefemail4"  placeHolder="Email" MaxLength="50"  runat="server"></asp:TextBox>
                                
                                </td>
                            </tr>
                            <tr>
                                <td align="Center" ><label><b>5</b></label></td>
                                <td>
                                    
                                    <asp:TextBox ID="txtrefname5" placeHolder="Name" MaxLength="50" onkeyup = "MaxLength(this, 50),SpecialCharNotAllow(this, event);" onchange = "SpecialCharNotAllow(this, event);" runat="server"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:DropDownList ID="DropDownList5" runat="server">
                                        <asp:ListItem Value="0">Select </asp:ListItem>
                                        <asp:ListItem Value="1">Male</asp:ListItem>
                                        <asp:ListItem Value="2">Female</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td align="Center">
                                    <asp:TextBox ID="txtrefmob5" placeHolder="Mobile No." MaxLength="20" onkeyup = "MaxLength(this, 50),SpecialCharNotAllow(this, event);" onchange = "SpecialCharNotAllow(this, event);" runat="server"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender5" runat="server" ValidChars="0123456789/-" TargetControlID="txtrefmob5">  </cc1:FilteredTextBoxExtender>
                                </td>
                                <td align="Center" >
                                     <asp:TextBox ID="txtrefemail5"  placeHolder="Email" MaxLength="50"  runat="server"></asp:TextBox>

                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: right">
                                    <label><b style="text-align: right"> Donate Amount</b></label>
                                </td>
                                <td align="Center" style="text-align: left">
                      
                                    <asp:TextBox ID="txtdonateamt"  onkeyPress="ValidateTextLength(event,10,this);" runat="server"></asp:TextBox>
                                   <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender8" runat="server" ValidChars="0123456789."
                                                                                                TargetControlID="txtdonateamt">
                                                                                            </cc1:FilteredTextBoxExtender>
                                </td>
                                <td></td>
                                <td></td>

                            </tr>

                            <tr>
                                <td></td>
                                <td></td>
                                <td>
                                    
                                    <asp:Button runat="server" class="btn"  Text="Pay" id="btnpay" />
                                   </td>
                                <td></td>
                            </tr>

                        </table>
                    </td>

                </tr>
            </table>
        </div>
     
 </ContentTemplate>
 </asp:UpdatePanel>


        </td>
        </tr>
        </table>
        <table align="center" width="80%" cellpadding="3" cellspacing="5" border="0">
            <tr>
                <td class="footer">
                    &copy;copy-right: Pratham Softcon Pvt Ltd.
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
