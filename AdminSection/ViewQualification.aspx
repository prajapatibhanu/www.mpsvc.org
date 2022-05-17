<%@ Page Title="" Language="C#" MasterPageFile="~/AdminSection/AdminMaster.master" AutoEventWireup="true" CodeFile="ViewQualification.aspx.cs" Inherits="AdminSection_ViewQualification" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    
    <script type ="text/javascript" language ="javascript" >
        function OpenIdentity(that) {
            var str = that.id;
            var str1 = str.split('_');
            var hfId = str1[0] + '_' + str1[1] + '_hdnIPath_' + str1[3];
            var hfvalue = document.getElementById(hfId).value ; 
            var FilePath = '../Upload_Certificate/' + hfvalue
            window.open(FilePath);
        }
    </script>
    <table width="100%">
        <tr>
            <td colspan="3" align="center">
                <asp:RadioButton ID="rbQualification" runat="server" Font-Bold="true" AutoPostBack="true" Checked="true"
                    Text="For Qualification " GroupName="Action" OnCheckedChanged="rbQualification_CheckedChanged" />
                &nbsp;&nbsp;&nbsp;
                <asp:RadioButton ID="rbIDCard" runat="server" Font-Bold="true" AutoPostBack="true"
                    Text="For Duplicate ID Card" GroupName="Action" OnCheckedChanged="rbIDCard_CheckedChanged" />
                &nbsp;&nbsp;   
                 <asp:RadioButton ID="rbUpdateinfo" runat="server" Font-Bold="true" AutoPostBack="true"
                    Text="For Update profile" GroupName="Action" OnCheckedChanged="rbUpdateinfo_CheckedChanged" />
                &nbsp;&nbsp;       
            </td>
        </tr>
        <tr>
            <td style="text-align: left" width="20%"></td>
            <td style="text-align: right" width="75%">
                <asp:TextBox ID="txtSearch" MaxLength="200" placeholder="Any keyboard" runat="server"></asp:TextBox>
            </td>
            <td style="text-align: left" width="5%">
                <asp:Button ID="btnSearch" runat="server" CssClass="btn" Text="Search" />
            </td>
        </tr>
        <tr>
            <td style="text-align: center" colspan="3">
                <asp:GridView ID="GrdQualificationUpdate" runat="server" AutoGenerateColumns="false" GridLines="None"
                    CssClass="tab" Width="100%" EmptyDataText="Record Not Found." DataKeyNames="RegiNo"
                    PageSize="10" AllowPaging="True" OnPageIndexChanging="GrdQualificationUpdate_PageIndexChanging" OnSelectedIndexChanged="GrdQualificationUpdate_SelectedIndexChanged">
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
                <asp:GridView ID="GrdDupicateReg" runat="server" AutoGenerateColumns="false" GridLines="None"
                    CssClass="tab" Width="100%" EmptyDataText="Record Not Found." DataKeyNames="RegiNo"
                    PageSize="10" AllowPaging="True" OnPageIndexChanging="GrdQualificationUpdate_PageIndexChanging" OnSelectedIndexChanged="GrdDupicateReg_SelectedIndexChanged">
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
                <asp:GridView ID="GrdProfileUpdatetion" runat="server" AutoGenerateColumns="false" GridLines="None"
                    CssClass="tab" Width="100%" EmptyDataText="Record Not Found." DataKeyNames="RegiNo"
                    PageSize="10" OnPageIndexChanging="GrdQualificationUpdate_PageIndexChanging" OnSelectedIndexChanged="GrdProfileUpdatetion_SelectedIndexChanged">
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
                        <asp:TemplateField HeaderText="Name">
                            <ItemTemplate>
                                <%#Eval("Name")%>
                            </ItemTemplate>
                        </asp:TemplateField> 
                         <asp:TemplateField HeaderText="Identity Type">
                            <ItemTemplate>
                                <%#Eval("IdentityType")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                         <asp:TemplateField HeaderText="Identity No.">
                            <ItemTemplate>
                                <%#Eval("IdentityNo")%>
                            </ItemTemplate>
                        </asp:TemplateField>   
                          <asp:TemplateField HeaderText="Date of Request">
                            <ItemTemplate>
                                <%#Eval("DateOfRequest")%>
                            </ItemTemplate>
                        </asp:TemplateField>                      
                        <asp:TemplateField HeaderText="View Uploaded Identity">
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkIdentity" runat="server" OnClientClick ="OpenIdentity(this)"> View </asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>   
                        <asp:TemplateField HeaderText="Verify">
                            <ItemTemplate>
                                <asp:Button ID="btnverify" CommandName="select" ToolTip='<%#Eval("id")%>' runat="server"
                                    CssClass="btn" Text="Verify" />
                                <asp:HiddenField ID="hdnIPath" Value ='<%#Eval("File1")%>' runat="server" />
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

