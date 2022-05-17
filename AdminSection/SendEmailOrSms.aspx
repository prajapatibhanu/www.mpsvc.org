<%@ Page Title="" Language="C#" MasterPageFile="~/AdminSection/AdminMaster.master"
    AutoEventWireup="true" CodeFile="SendEmailOrSms.aspx.cs" Inherits="AdminSection_SendEmailOrSms" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript">
        function OnChange() {
            if (document.getElementById('<%=ddlType.ClientID %>').value == "All") {
                document.getElementById('ddlDivMemType').style.display = "none";
                document.getElementById('ddlDiv2').style.display = "none";
                document.getElementById('ddlDiv3').style.display = "none";
            }
            else if (document.getElementById('<%=ddlType.ClientID %>').value == "Registration Status") {
                document.getElementById('ddlDivMemType').style.display = "block";
                document.getElementById('ddlDiv2').style.display = "none";
                document.getElementById('ddlDiv3').style.display = "block";
            }
            else if (document.getElementById('<%=ddlType.ClientID %>').value == "Registration No") {
                document.getElementById('ddlDiv2').style.display = "block";
                document.getElementById('ddlDivMemType').style.display = "none";
                document.getElementById('ddlDiv3').style.display = "block";
            }
            else {
                document.getElementById('ddlDiv3').style.display = "none";
                document.getElementById('ddlDiv2').style.display = "none";
                document.getElementById('ddlDivMemType').style.display = "none";
            }
        }

    </script>
    <table width="100%" cellpadding="0" cellspacing="0">
        <tr>
            <td>
                Select :
            </td>
            <td>
                <asp:DropDownList runat="server" ID="ddlType" CssClass="txtbox" onchange="OnChange();">
                    <asp:ListItem Text="All"></asp:ListItem>
                    <asp:ListItem>Registration No</asp:ListItem>
                    <asp:ListItem>Registration Date</asp:ListItem>
                    <asp:ListItem>Registration Status</asp:ListItem>
                    <asp:ListItem>Renew Date</asp:ListItem>
                    <asp:ListItem>Previous Regi Date</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                <div id="ddlDiv3" style="display: none">
                    Value :</div>
            </td>
            <td>
                <div id="ddlDivMemType" style="display: none">
                    <asp:DropDownList runat="server" ID="ddlMemType" CssClass="txtbox">
                        <asp:ListItem>New</asp:ListItem>
                        <asp:ListItem>NOC</asp:ListItem>
                        <asp:ListItem>Dead</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div id="ddlDiv2" style="display: none">
                    <asp:TextBox runat="server" ID="txtValue" CssClass="txtbox" MaxLength="10"></asp:TextBox>
                </div>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td>
                From Date :
            </td>
            <td>
                <asp:TextBox runat="server" ID="txtFDate" CssClass="txtbox" MaxLength="10"></asp:TextBox>
                <cc1:CalendarExtender ID="CalendarExtender4" runat="server" TargetControlID="txtFDate"
                    Format="dd/MM/yyyy">
                </cc1:CalendarExtender>
            </td>
            <td>
                To Date :
            </td>
            <td>
                <asp:TextBox runat="server" ID="txtToDate" CssClass="txtbox" MaxLength="10"></asp:TextBox>
                <cc1:CalendarExtender ID="CalendarExtender5" runat="server" TargetControlID="txtToDate"
                    Format="dd/MM/yyyy">
                </cc1:CalendarExtender>
            </td>
            <td>
                <asp:Button ID="btnSearch" runat="server" CssClass="btn" Text="Search" OnClick="btnSearch_Click" />
            </td>
        </tr>
        <tr id="tr1" runat="server" visible="false">
            <td>
            </td>
            <td colspan="4">
            <asp:RadioButton ID="rbEmail"
                    GroupName="a" runat="server" Text="E-Mail"  Checked="true"/>
                <asp:RadioButton ID="rbSMS" runat="server" Text="SMS" GroupName="a" />
            </td>
        </tr>
        <tr id="tr2" runat="server"  visible="false">
            <td valign="top">
                SMS/E-Mail Messsage :
            </td>
            <td colspan="4">
                <asp:TextBox runat="server" ID="txtSendMessage" CssClass="txtbox reqirerd" 
                    MaxLength="400" TextMode="MultiLine" Height="119px" Width="564px" ></asp:TextBox>
            </td>
        </tr>
        <tr id="tr3" runat="server"  visible="false">
            <td>
            </td>
            <td colspan="4">
                <asp:Button ID="btnSend" runat="server" CssClass="btn" Text="Send" OnClick="btnSend_Click" OnClientClick="return ValidateAllTextForm();"/>
            </td>
        </tr>
        <tr>
            <td colspan="5">
         
                <asp:GridView ID="GrdPaperMaster" runat="server" AutoGenerateColumns="false" GridLines="None"
                    CssClass="tab" Width="100%" EmptyDataText="Record Not Found." DataKeyNames="RegiNo"
                    PageSize="50" AllowPaging="True" OnPageIndexChanging="GrdPaperMaster_PageIndexChanging">
                    <Columns>
                        <asp:TemplateField HeaderText="Select">
                            <HeaderTemplate>
                                <asp:CheckBox ID="chkSelectAll" runat="server"  onclick="RadioCheck(this);"/>
                            </HeaderTemplate>
                            <ItemTemplate>
                             <asp:Panel ID="dddd" runat="server" Visible='<%#Eval("MemStatus").ToString().Equals("Dead")?false:true%>'>
                                <asp:CheckBox ID="chkSelect" runat="server" />
                                </asp:Panel>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="SrNo">
                            <ItemTemplate>
                                <%# Container.DataItemIndex+1 %>.
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Registration No">
                            <ItemTemplate>
                                <%#Eval("RegiNo")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Last Renew Date">
                            <ItemTemplate>
                                <%#Eval("PreYear")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Registration Date">
                            <ItemTemplate>
                                <%#Eval("RegiDate")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Next Renew Date">
                            <ItemTemplate>
                            <asp:Panel ID="dd" runat="server" Visible='<%#Eval("MemStatus").ToString().Equals("Dead")?false:true%>'>
                                    <%#Eval("UpComingYear")%>
                            </asp:Panel>                                
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Name">
                            <ItemTemplate>
                                <%#Eval("Name")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Mobile No">
                            <ItemTemplate>
                             <asp:Label ID="lblMobileNo" runat="server"   Text='<%#Eval("MobileNo")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Email Id">
                            <ItemTemplate>
                                <asp:Label ID="lblEmailId" runat="server"   Text='<%#Eval("EmailId")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Preffered Address">
                            <ItemTemplate>
                                <%#Eval("CurrentAdd")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Registration Status">
                            <ItemTemplate>
                            <asp:Label ID="lblMemStatus" runat="server"   Text='<%#Eval("MemStatus")%>'></asp:Label>    
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <PagerStyle CssClass="Gvpaging" />
                    <EmptyDataRowStyle CssClass="GvEmptyText" />
                </asp:GridView>
            </td>
        </tr>
    </table>
         <script type="text/javascript" >

             function RadioCheck(rb) {

                 var gv = document.getElementById("<%= GrdPaperMaster.ClientID  %>");

                 var rbs = gv.getElementsByTagName("input");

                 var row = rb.parentNode.parentNode;

                 for (var i = 0; i < rbs.length; i++) {

                     if (rbs[i].type == "checkbox") {
                         rbs[i].checked = rb.checked;
                     }
                 }
             }

</script>
</asp:Content>
