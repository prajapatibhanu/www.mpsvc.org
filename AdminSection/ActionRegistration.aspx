<%@ Page Language="C#" MasterPageFile="~/AdminSection/AdminMaster.master" AutoEventWireup="true" EnableEventValidation="false"
    CodeFile="ActionRegistration.aspx.cs" Inherits="AdminSection_ActionRegistration"
    Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script type="text/javascript" language="javascript">
        function MessageAlert() {
            alert("Please upload certificate with seal and sign");
        }
        function MessageVerify() {
            alert("Registration verified successfully");
        }
        function MessageUpload() {
            alert("Certificate Uploaded successfully");
        }
        function ValidateOutwardNo() {
            alert("Outward no can not be left blank.");
            return false;
        }

        //function checkGenerate(that) {

        //    var str = that.id;
        //    // var requestId = str[0] + '_' + str[1] + '_' + str[2] + '_' + str[3] + '_hf_RequestIdBit';
        //    var a = that.id;
        //    if (a == 3) {
        //        var b = confirm("You are already generated certificate, do you want generate again?");
        //        if (b == false) {

        //            window.location = "ActionRegistration.aspx?Mt=New+Registration";
        //            return false;
        //        }
        //    }
        //}
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
                <asp:RadioButton ID="rbComplaint" runat="server" Text="ComplaintManagment" AutoPostBack="true" Font-Bold="true"
                    GroupName="Action" OnCheckedChanged="rbComplaint_CheckedChanged" />
                &nbsp;&nbsp&nbsp;
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
                <asp:RadioButton ID="rbValid" runat="server" Font-Bold="true" AutoPostBack="true"
                    Text="Valid" GroupName="Action" OnCheckedChanged="rbValid_CheckedChanged" />
                &nbsp;&nbsp;&nbsp;              
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
                <asp:GridView ID="GrdComplaint" runat="server" AutoGenerateColumns="false" GridLines="None"
                    CssClass="tab" Width="100%" EmptyDataText="Record Not Found." DataKeyNames="ComplainantID"
                    PageSize="10" AllowPaging="False" OnPageIndexChanging="GrdComplaint_PageIndexChanging" OnSelectedIndexChanged="GrdComplaint_SelectedIndexChanged" >
                    <Columns>
                        <asp:TemplateField HeaderText="SrNo">
                            <ItemTemplate>
                                <%# Container.DataItemIndex+1 %>.
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Complaint No">
                            <ItemTemplate>
                                <%#Eval("ComplaintNo")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Complaint Date">
                            <ItemTemplate>
                                <%#Eval("ComplaintDate")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Name Of Complainant">
                            <ItemTemplate>
                                <%#Eval("NameOfComplainant")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="MobileNo of Complainant">
                            <ItemTemplate>
                                <%#Eval("MobileNoOfComplainant")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                         <asp:TemplateField HeaderText="Address of Complainant">
                            <ItemTemplate>
                                <%#Eval("AddressOfComplainant")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Name Of Against Complaint " >
                            <ItemTemplate>
                                <%#Eval("NameAgainstComplaint")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Status">
                            <ItemTemplate>
                                <span style="color: <%# (Eval("Status").ToString() == "Pending") ? "red" : "#b55613;" %>;font-weight:bold"><%# Eval("Status") %></span>                          
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Verify">
                            <ItemTemplate>
                                <asp:Button ID="btnverify" CommandName="select" ToolTip='<%#Eval("ComplainantID")%>' runat="server"
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
                <asp:GridView ID="GrdProvisional" runat="server" AutoGenerateColumns="false" GridLines="None"
                    CssClass="tab" Width="100%" EmptyDataText="Record Not Found." DataKeyNames="ApplicationNo"
                    PageSize="10" AllowPaging="False" OnPageIndexChanging="GrdPaperMaster_PageIndexChanging" OnSelectedIndexChanged="GrdProvisional_SelectedIndexChanged">
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
                    CssClass="tab" Width="100%" EmptyDataText="Record Not Found." DataKeyNames="RegiNo"
                    PageSize="10" AllowPaging="True" OnPageIndexChanging="GrdPaperMaster_PageIndexChanging"
                    OnSelectedIndexChanged="GrdRenew_SelectedIndexChanged">
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
                    CssClass="tab" Width="100%" EmptyDataText="Record Not Found." DataKeyNames="id" OnPageIndexChanging="GrdTransfer_PageIndexChanging"
                    PageSize="100" AllowPaging="True" OnSelectedIndexChanged="GrdTransfer_SelectedIndexChanged">
                    <Columns>
                        <asp:TemplateField HeaderText="SrNo">
                            <ItemTemplate>
                                <%# Container.DataItemIndex+1 %>.
                                <asp:Label ID="lblID" runat="server" Visible="false" Text='<%#Eval("id")%>'>'</asp:Label>
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
                        <%--<asp:TemplateField HeaderText="For Transfer">
                            <ItemTemplate>
                                <%#Eval("For_Transfer")%>
                            </ItemTemplate>--%>
                       <%-- </asp:TemplateField>--%>
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
                    PageSize="10" AllowPaging="False" OnPageIndexChanging="GrdPaperMaster_PageIndexChanging"
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
              <asp:GridView ID="GrdValidReg" runat="server" AutoGenerateColumns="false" GridLines="None"
                    CssClass="tab" Width="100%" EmptyDataText="Record Not Found." DataKeyNames="RegiNo"
                    PageSize="10" OnPageIndexChanging="GrdPaperMaster_PageIndexChanging"
                    OnSelectedIndexChanged="GrdValidReg_SelectedIndexChanged" OnRowDataBound="GrdValidReg_RowDataBound">
                    <Columns>
                        <asp:TemplateField HeaderText="SrNo">
                            <ItemTemplate>
                                <%# Container.DataItemIndex+1 %>.
                                <asp:HiddenField ID="hf_RequestIdBit" runat="server" Value='<%# Eval("RegistrationStatus")%>' />
                                <asp:HiddenField ID="hf_ApplicationStatus" runat="server" Value='<%# Eval("ApplicationRequestId")%>' />
                              <asp:HiddenField ID="hf_Pid" runat="server" Value='<%# Eval("id")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Application Type">
                            <ItemTemplate>
                                <%#Eval("Apptype")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField Visible="false">
                            <ItemTemplate>
                                <%#Eval("Id")%>
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
                        <asp:TemplateField HeaderText="Outward Registration No">
                            <ItemTemplate>
                                <asp:TextBox ID="txtOutwardNo" runat="server" Width="100px"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Generate Certificate">
                            <ItemTemplate>
                                <a href="test.aspx?ID=<%# Eval("ID") %>" id='<%#Eval("RegistrationStatus")%>' target="_blank">Generate </a>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Upload Certificate With Seal & Sign">
                            <ItemTemplate>
                                <asp:FileUpload ID="FileUploadcert" Width="120" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Save">
                            <ItemTemplate>
                                <asp:Button ID="btnsave" CommandName="select" ToolTip='<%#Eval("id")%>' runat="server"
                                    CssClass="btn" Text="Save" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <PagerStyle CssClass="Gvpaging" />
                    <EmptyDataRowStyle CssClass="GvEmptyText" />
                </asp:GridView>

                <%--<asp:GridView ID="GrdValidReg" runat="server" AutoGenerateColumns="false" GridLines="None"
                    CssClass="tab" Width="100%" EmptyDataText="Record Not Found." DataKeyNames="id"
                    PageSize="10" OnPageIndexChanging="GrdPaperMaster_PageIndexChanging"
                    OnSelectedIndexChanged="GrdValidReg_SelectedIndexChanged" OnRowDataBound="GrdValidReg_RowDataBound">
                    <Columns>
                        <asp:TemplateField HeaderText="SrNo">
                            <ItemTemplate>
                                <%# Container.DataItemIndex+1 %>.
                                <asp:HiddenField ID="hf_RequestIdBit" runat="server" Value='<%# Eval("RegistrationStatus")%>' />
                                <asp:HiddenField ID="hf_ApplicationStatus" runat="server" Value='<%# Eval("ApplicationRequestId")%>' />
                             <asp:HiddenField ID="hf_Pid" runat="server" Value='<%# Eval("id")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Application Type">
                            <ItemTemplate>
                                <%#Eval("Apptype")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField Visible="false">
                            <ItemTemplate>
                                <%#Eval("id")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Registration No">
                            <ItemTemplate>
                                <%#Eval("RegiNo")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Registration Validity">
                            <ItemTemplate>
                                <%#Eval("RegiValidity")%>
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
                                <%#Eval("EmailID")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Outward Registration No">
                            <ItemTemplate>
                                <asp:TextBox ID="txtOutwardNo" runat="server" Width="100px"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                       <asp:TemplateField HeaderText="Generate Certificate">
                            <ItemTemplate>
                                <a href="test.aspx?ID=<%# Eval("ID") %>" id='<%#Eval("RegistrationStatus")%>' target="_blank">Generate </a>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Upload Certificate With Seal & Sign">
                            <ItemTemplate>
                                <asp:FileUpload ID="FileUploadcert" Width="120" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Save">
                            <ItemTemplate>
                                <asp:Button ID="btnsave" CommandName="select" ToolTip='<%#Eval("id")%>' runat="server"
                                    CssClass="btn" Text="Save" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <PagerStyle CssClass="Gvpaging" />
                    <EmptyDataRowStyle CssClass="GvEmptyText" />
                </asp:GridView> --%>
            </td>
        </tr>    
    </table>
</asp:Content>
