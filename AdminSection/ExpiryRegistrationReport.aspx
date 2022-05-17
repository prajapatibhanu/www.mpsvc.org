<%@ Page Language="C#" MasterPageFile="~/AdminSection/AdminMaster.master" AutoEventWireup="true"
    CodeFile="ExpiryRegistrationReport.aspx.cs" Inherits="AdminSection_ExpiryRegistrationReport" ValidateRequest ="false" 
    Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<script type ="text/javascript" language ="javascript" >
    function GetGridValue() {
        document.getElementById('<%=HF_GridData.ClientID%>').value = document.getElementById('<%=divPhysical.ClientID%>').innerHTML;
    }
</script>
    <table width="100%">
        <tr>
            <td style="text-align: center" colspan="3">
             <div id ="divPhysical" runat="server"  style="overflow: auto;">
                <asp:GridView ID="GrdInvalidReg" runat="server" AutoGenerateColumns="false"
                    CssClass="tab" Width="100%" EmptyDataText="Record Not Found." DataKeyNames="RegiNo"
                    PageSize="10" AllowPaging="True" OnPageIndexChanging="GrdPaperMaster_PageIndexChanging">
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
                        <asp:TemplateField HeaderText="Preffered Address">
                            <ItemTemplate>
                                <%#Eval("PreferedAdd")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Valid up to">
                            <ItemTemplate>
                                <%#Eval("Validupto")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <PagerStyle CssClass="Gvpaging" />
                    <EmptyDataRowStyle CssClass="GvEmptyText" />
                </asp:GridView>
                 </div>
            </td>
        </tr>
        <tr>
            <td style="text-align: center" colspan="3">
                <asp:Button ID="btnPrint" runat="server" CssClass="btn" Text="Print" onclick="btnPrint_Click" OnClientClick ="GetGridValue()" />
                &nbsp;&nbsp;&nbsp;
            </td>
        </tr>
         <asp:HiddenField ID="HF_GridData" runat="server" />
    </table>
</asp:Content>
