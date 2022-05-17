<%@ Page Title="" Language="C#" MasterPageFile="~/AdminSection/AdminMaster.master" AutoEventWireup="true" CodeFile="FrmSecondLevelValid.aspx.cs" Inherits="AdminSection_FrmSecondLevelValid" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 <script type="text/javascript" language="javascript">  
     function MessageVerify() {grdtranss
         alert("Registration verified successfully");
     }
    </script>


    <style type="text/css">
        .renewgrd {
            background: #F6FFA9;
        }

        .newgrd {
            background: #A3FFA8;
        }

        .transfergrd {
            background: #FFDAA9;
        }
        .DuplicateGrd {
            background: #B378D3;
        }
        .ProvisionalGrd {
            background: #FFC3F5;
        }
    </style>
    <table width="100%">
        <asp:Label ID="lblmsg" runat="server" Visible="false" ForeColor="Red"></asp:Label>
        <asp:HiddenField ID="hf_Status" runat="server" />
        <asp:HiddenField ID="hf_Gettappid" runat="server" />
        <asp:HiddenField ID="hf_GetPid" runat="server" />
        <tr>
            <td colspan="3" align="center">
                <asp:RadioButton ID="rbProvisional" runat="server" Font-Bold="true" AutoPostBack="true"
                    Text="For Provisional Registration" GroupName="Action" OnCheckedChanged="rbProvisional_CheckedChanged" />
                &nbsp;&nbsp&nbsp;      
                <asp:RadioButton ID="rbDuplicate" runat="server" Font-Bold="true" AutoPostBack="true"
                    Text="For Duplicate Certificate" GroupName="Action" OnCheckedChanged="rbDuplicate_CheckedChanged" />
                &nbsp;&nbsp;&nbsp;
                <asp:RadioButton ID="rbOutsideTransfer" runat="server" Font-Bold="true" AutoPostBack="true"
                    Text="For Transfer(Outside to MP)" GroupName="Action" OnCheckedChanged="rbOutsideTransfer_CheckedChanged" />
                &nbsp;&nbsp;&nbsp;
                <asp:RadioButton ID="rbRenew" runat="server" Font-Bold="true" AutoPostBack="true"
                    Text="For Renewal" GroupName="Action" OnCheckedChanged="rbRenew_CheckedChanged" />
                &nbsp;&nbsp;&nbsp;
                <asp:RadioButton ID="rbTransfer" runat="server" Font-Bold="true" AutoPostBack="true"
                    Text="For Transfer(MP to Outside)" GroupName="Action" OnCheckedChanged="rbTransfer_CheckedChanged" />
                &nbsp;&nbsp;&nbsp;
                <asp:RadioButton ID="rbPending" runat="server" Font-Bold="true" Checked="true" AutoPostBack="true"
                    Text="For New" GroupName="Action" OnCheckedChanged="rbPending_CheckedChanged" />
                &nbsp;&nbsp;&nbsp;
                <asp:RadioButton ID="rbQualification" runat="server" Font-Bold="true" AutoPostBack="true" 
                    Text="For Qualification " GroupName="Action" OnCheckedChanged="rbQualification_CheckedChanged" />
                &nbsp;&nbsp;&nbsp;
                <asp:RadioButton ID="rbIDCard" runat="server" Font-Bold="true" AutoPostBack="true"
                    Text="For Duplicate ID Card" GroupName="Action" OnCheckedChanged="rbIDCard_CheckedChanged" />
                &nbsp;&nbsp;              
            </td>
        </tr>
        <tr>
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
                <asp:GridView ID="GrdProvisional" runat="server" AutoGenerateColumns="false" GridLines="None"
                    CssClass="tab" Width="100%" EmptyDataText="Record Not Found." DataKeyNames="ApplicationNo"
                    PageSize="10" AllowPaging="True" OnPageIndexChanging="GrdPaperMaster_PageIndexChanging" OnSelectedIndexChanged="GrdProvisional_SelectedIndexChanged">
                    <Columns>
                        <asp:TemplateField HeaderText="SrNo">
                            <ItemTemplate>
                                <%# Container.DataItemIndex+1 %>.
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Application No">
                            <ItemTemplate>
                                <%#Eval("ApplicationNo")%>
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
                        <asp:TemplateField HeaderText="Verify">
                            <ItemTemplate>
                                <asp:Button ID="btnverify" CommandName="select" ToolTip='<%#Eval("id")%>' runat="server"
                                    CssClass="btn" Text="Verify" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <PagerStyle CssClass="Gvpaging" />
                    <EmptyDataRowStyle CssClass="GvEmptyText" />
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td style="text-align: center" colspan="3">
                <asp:GridView ID="GrdDupicateReg" runat="server" AutoGenerateColumns="false" GridLines="None"
                    CssClass="tab" Width="100%" EmptyDataText="Record Not Found." DataKeyNames="RegiNo"
                    PageSize="10" AllowPaging="True" OnPageIndexChanging="GrdPaperMaster_PageIndexChanging" OnSelectedIndexChanged="GrdDupicateReg_SelectedIndexChanged">
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
                        <asp:TemplateField HeaderText="Verify">
                            <ItemTemplate>
                                <asp:Button ID="btnverify" CommandName="select" ToolTip='<%#Eval("id")%>' runat="server"
                                    CssClass="btn" Text="Verify" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <PagerStyle CssClass="Gvpaging" />
                    <EmptyDataRowStyle CssClass="GvEmptyText" />
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td style="text-align: center" colspan="3">
                <asp:GridView ID="GrdTransferOutside" runat="server" AutoGenerateColumns="false" GridLines="None"
                    CssClass="tab" Width="100%" EmptyDataText="Record Not Found." DataKeyNames="RegiNo"
                    PageSize="10" AllowPaging="True" OnPageIndexChanging="GrdPaperMaster_PageIndexChanging" OnSelectedIndexChanged="GrdTransferOutside_SelectedIndexChanged">
                    <Columns>
                        <asp:TemplateField HeaderText="SrNo">
                            <ItemTemplate>
                                <%# Container.DataItemIndex+1 %>.
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Application No">
                            <ItemTemplate>
                                <%#Eval("ApplicationNo")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Application Date">
                            <ItemTemplate>
                                <%#Eval("ApplicationDate")%>
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
                        <asp:TemplateField HeaderText="Noc State">
                            <ItemTemplate>
                                <%#Eval("NocState")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Verify">
                            <ItemTemplate>
                                <asp:Button ID="btnverify" CommandName="select" ToolTip='<%#Eval("id")%>' runat="server"
                                    CssClass="btn" Text="Verify" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <PagerStyle CssClass="Gvpaging" />
                    <EmptyDataRowStyle CssClass="GvEmptyText" />
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td style="text-align: center" colspan="3">
                <asp:GridView ID="GrdRenew" runat="server" AutoGenerateColumns="false" GridLines="None"
                    CssClass="tab" Width="100%" EmptyDataText="Record Not Found." DataKeyNames="id"
                    PageSize="10" AllowPaging="True" OnPageIndexChanging="GrdPaperMaster_PageIndexChanging"
                    OnSelectedIndexChanged="GrdRenew_SelectedIndexChanged">
                    <Columns>
                        <asp:TemplateField HeaderText="SrNo">
                            <ItemTemplate>
                                <%# Container.DataItemIndex+1 %>.
                                 <asp:Label ID="lblID" runat="server" Visible="false" Text='<%#Eval("id")%>'>'</asp:Label>
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
                        <asp:TemplateField HeaderText="Verify">
                            <ItemTemplate>
                                <asp:Button ID="btnverify" CommandName="select" ToolTip='<%#Eval("id")%>' runat="server"
                                    CssClass="btn" Text="Verify" />
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
        <tr>
            <td style="text-align: center" colspan="3">
                <asp:GridView ID="GrdTransfer" runat="server" AutoGenerateColumns="false" GridLines="None"
                    CssClass="tab" Width="100%" EmptyDataText="Record Not Found." DataKeyNames="RegiNo"
                    PageSize="10" AllowPaging="True" OnSelectedIndexChanged="GrdTransfer_SelectedIndexChanged">
                    <Columns>
                        <asp:TemplateField HeaderText="SrNo">
                            <ItemTemplate>
                                <%# Container.DataItemIndex+1 %>.
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Application No">
                            <ItemTemplate>
                                <%#Eval("ApplicationNo")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Application Date">
                            <ItemTemplate>
                                <%#Eval("ApplicationDate")%>
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
                        <asp:TemplateField HeaderText="Verify">
                            <ItemTemplate>
                                <asp:Button ID="btnverify" CommandName="select" ToolTip='<%#Eval("id")%>' runat="server"
                                    CssClass="btn" Text="Verify" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <PagerStyle CssClass="Gvpaging" />
                    <EmptyDataRowStyle CssClass="GvEmptyText" />
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td style="text-align: center" colspan="3">
                <asp:GridView ID="GrdPendingReg" runat="server" AutoGenerateColumns="false" GridLines="None"
                    CssClass="tab" Width="100%" EmptyDataText="Record Not Found." DataKeyNames="RegiNo"
                    PageSize="10" AllowPaging="True" OnPageIndexChanging="GrdPaperMaster_PageIndexChanging"
                    OnSelectedIndexChanged="GrdPendingReg_SelectedIndexChanged">
                    <Columns>
                        <asp:TemplateField HeaderText="SrNo">
                            <ItemTemplate>
                                <%# Container.DataItemIndex+1 %>.
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Application No">
                            <ItemTemplate>
                                <%#Eval("ApplicationNo")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Application Date">
                            <ItemTemplate>
                                <%#Eval("ApplicationDate")%>
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
                        <asp:TemplateField HeaderText="Verify">
                            <ItemTemplate>
                                <asp:Button ID="btnverify" CommandName="select" ToolTip='<%#Eval("id")%>' runat="server"
                                    CssClass="btn" Text="Verify" />
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
         <tr>
            <td style="text-align: center" colspan="3">
                <asp:GridView ID="GrdQualificationUpdate" runat="server" AutoGenerateColumns="false" GridLines="None"
                    CssClass="tab" Width="100%" EmptyDataText="Record Not Found." DataKeyNames="RegiNo"
                    PageSize="10" AllowPaging="True" OnPageIndexChanging="GrdPaperMaster_PageIndexChanging" OnSelectedIndexChanged="GrdQualificationUpdate_SelectedIndexChanged">
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
                        <asp:TemplateField HeaderText="Verify">
                            <ItemTemplate>
                                <asp:Button ID="btnverify" CommandName="select" ToolTip='<%#Eval("id")%>' runat="server"
                                    CssClass="btn" Text="Verify" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <PagerStyle CssClass="Gvpaging" />
                    <EmptyDataRowStyle CssClass="GvEmptyText" />
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td style="text-align: center" colspan="3">
                <asp:GridView ID="GridDupIDCard" runat="server" AutoGenerateColumns="false" GridLines="None"
                    CssClass="tab" Width="100%" EmptyDataText="Record Not Found." DataKeyNames="RegiNo"
                    PageSize="10" AllowPaging="True" OnPageIndexChanging="GrdPaperMaster_PageIndexChanging" OnSelectedIndexChanged="GridDupIDCard_SelectedIndexChanged">
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
                        <asp:TemplateField HeaderText="Verify">
                            <ItemTemplate>
                                <asp:Button ID="btnverify" CommandName="select" ToolTip='<%#Eval("id")%>' runat="server"
                                    CssClass="btn" Text="Verify" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <PagerStyle CssClass="Gvpaging" />
                    <EmptyDataRowStyle CssClass="GvEmptyText" />
                </asp:GridView>
            </td>
        </tr>
    </table>
</asp:Content>

