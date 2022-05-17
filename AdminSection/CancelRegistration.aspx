<%@ Page Title="" Language="C#" MasterPageFile="~/AdminSection/AdminMaster.master" AutoEventWireup="true" CodeFile="CancelRegistration.aspx.cs" Inherits="AdminSection_CancelRegistration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="css/style.css" rel="stylesheet" type="text/css" />
    <link href="css/slider.css" rel="stylesheet" type="text/css" />
    <link href="../css/MyStyle.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../js/CommonCtrl.js"></script>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/font-awesome/4.4.0/css/font-awesome.min.css" />
    <script type="text/javascript" language="javascript">
        function Validate() {
            var remark = document.getElementById('<%=txtRemark.ClientID%>').value.trim();
            if (remark == "") {
                alert("Remark can not be left blank.");
                document.getElementById('<%=divRemark.ClientID%>').style.display = "block";
                return false;
            }
        }

        function MessageAlert() {
            alert("Registration Cancelled Successfully.");
        }
    </script>
    <script type="text/javascript">
        function PopTemAndConditionQualification() {
            document.getElementById('<%=divRemark.ClientID%>').style.display = "block";
            return false;
        }
        function AcceptQualification() {
            document.getElementById('<%=divRemark.ClientID%>').style.display = "none";
            return false;
        }
        function PopupCancelQualification() {
            document.getElementById('<%=divRemark.ClientID%>').style.display = "none";
        }
    </script>
    <table width="100%">
        <tr>
            <asp:HiddenField ID="hdnGetId" runat="server" />
            <td style="text-align: left" width="20%"></td>
            <td style="text-align: right" width="75%">
                <asp:TextBox ID="txtSearch" MaxLength="200" placeholder="Any keyboard" runat="server"></asp:TextBox>
            </td>
            <td style="text-align: left" width="5%">
                <asp:Button ID="btnSearch" runat="server" CssClass="btn" Text="Search" OnClick="btnSearch_Click" />
            </td>
        </tr>
        <tr>
            <td style="text-align: center" colspan="3">
                <asp:GridView ID="GrdPendingReg" runat="server" AutoGenerateColumns="false" GridLines="None"
                    CssClass="tab" Width="100%" EmptyDataText="Record Not Found." DataKeyNames="RegiNo"
                    PageSize="10" AllowPaging="True" OnPageIndexChanging="GrdPaperMaster_PageIndexChanging" OnRowDataBound="GrdPendingReg_RowDataBound">
                    <Columns>
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
                        <asp:TemplateField HeaderText="Registration Date">
                            <ItemTemplate>
                                <%#Eval("RegiDate")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Name">
                            <ItemTemplate>
                                <%#Eval("Name")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Mobile No">
                            <ItemTemplate>
                                <%#Eval("MobileNo")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Email Id">
                            <ItemTemplate>
                                <%#Eval("EmailId")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Preferred Address">
                            <ItemTemplate>
                                <%#Eval("PreferedAdd")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Cancel">
                            <ItemTemplate>
                                <%--<a href="#" class="big-link" style="font-weight: normal;" onclick="return PopTemAndConditionQualification();">
                                    Cancel</a>--%>
                                <asp:Button ID="btnverify" CommandName="select" ToolTip='<%#Eval("id")%>' runat="server"
                                    CssClass="btn" Text="Cancel" OnClientClick="return PopTemAndConditionQualification();" />
                                <asp:HiddenField ID="hdn_Id" runat="server" Value='<%# Eval("id")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <%--  <asp:TemplateField HeaderText="Print">
                            <ItemTemplate>
                                <a href="PrintCertificate.aspx?ID=<%#Eval("RegiNo") %>">Certificate </a>
                            </ItemTemplate>
                        </asp:TemplateField>--%>
                    </Columns>
                    <PagerStyle CssClass="Gvpaging" />
                    <EmptyDataRowStyle CssClass="GvEmptyText" />
                </asp:GridView>
            </td>
        </tr>
    </table>

    <div id="divRemark" runat="server" style="display: none; width: 70%; position: absolute; padding-left: 30%; padding-top: 20%; text-align: center; top: 50px;">
        <asp:Panel ID="Panel4" runat="server" BackColor="#FFFFFF" Height="200px"
            Width="300px" BorderStyle="Solid" BorderWidth="3" BorderColor="#004040" ScrollBars="None">
            <table width="300px">
                <tr>
                    <td style="padding-top: 10px; padding-left: 22px; font-weight: bold; font-size: 15px;">Remark
                    </td>
                </tr>
                <tr>
                    <td style="padding-top: 10px; padding-left: 20px; font-weight: bold;">
                        <asp:TextBox ID="txtRemark" TextMode="MultiLine" runat="server" CssClass="txtbox reqirerd"></asp:TextBox><span style="color: Red">*</span>
                    </td>
                </tr>
                <tr>
                    <td style="padding-top: 20px;" align="center">
                        <asp:Button ID="btnOk" runat="server" Text="Ok" CssClass="btn" CommandArgument='<%#Eval("id")%>'  OnClick="btnOk_Click" OnClientClick="return Validate();" />
                        &nbsp;&nbsp;
                        <asp:Button ID="Button3" runat="server" Text="Close" Width="100" CssClass="btn"
                            OnClientClick="return PopupCancelQualification();" />
                    </td>
                </tr>
            </table>
        </asp:Panel>
    </div>
</asp:Content>

