<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserApplicationStatus.aspx.cs"
    Inherits="UserApplicationStatus" MasterPageFile="~/AdminSection/MasterPage.master"
    Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="100%" cellpadding="0" cellspacing="0">
        <tr>
            <td colspan="7">
                <strong>Check your Status </strong>
            </td>
        </tr>
        <tr>
            <td colspan="7">
                <asp:Label ID="lblMsg" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                Registration No:
            </td>
            <td>
                <asp:TextBox ID="txtname" runat="server" MaxLength="30" CssClass="txtbox "></asp:TextBox>
            </td>
            <td>
                &nbsp;
                <asp:Button ID="btnSearch" runat="server" CssClass="btn" Text="Search" OnClick="btnSearch_Click" />
            </td>
        </tr>
        <tr>
            <td colspan="7">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="White"
                    BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" Width="100%">
                    <RowStyle ForeColor="#000066" />
                    <Columns>
                        <asp:BoundField DataField="RegiNo" HeaderText="Reg.No" />
                        <asp:BoundField DataField="Name" HeaderText="Name" />
                        <asp:BoundField DataField="DOB" HeaderText="Date of Birth" />
                        <asp:BoundField DataField="FatherName" HeaderText="Father Name" />
                        <asp:BoundField DataField="MobileNo" HeaderText="Mobile No" />
                        <asp:BoundField DataField="EmailId" HeaderText="Email ID" />
                        <%--<asp:BoundField DataField="aa" HeaderText="Status" />--%>
                        <asp:TemplateField HeaderText="Status">
                            <ItemTemplate>
                                <asp:Label ID="lblStatus" runat="server"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="ForRenewal" runat="server" Visible="false" Style="color: Green"
                                    Text="Apply For Renewal" PostBackUrl="RenewRegistration.aspx"></asp:LinkButton>
                                <asp:LinkButton ID="ForTransafer" PostBackUrl="TransferRegistration.aspx" runat="server" Visible="false" Style="color: Green"
                                    Text="Apply For Transfer"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <FooterStyle BackColor="White" ForeColor="#000066" />
                    <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                    <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                </asp:GridView>
            </td>
        </tr>
    </table>
</asp:Content>
