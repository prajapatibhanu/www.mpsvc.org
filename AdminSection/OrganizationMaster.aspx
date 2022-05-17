<%@ Page Language="C#" MasterPageFile="~/AdminSection/AdminMaster.master" AutoEventWireup="true"
    CodeFile="OrganizationMaster.aspx.cs" Inherits="AdminSection_OrganizationMaster"
    Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="100%">
        <tr>
            <td style="text-align: left" colspan="3">
                <strong>Organization</strong>
            </td>
        </tr>
        <tr>
            <td colspan="3" style="text-align: left">
                &nbsp;<asp:Label ID="lblMsg" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="text-align: left" width="20%">
                <strong>Organization </strong>Name
            </td>
            <td colspan="2" style="text-align: left">
                <asp:TextBox ID="txtSearch" MaxLength="200" CssClass="txtbox reqirerd" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="3" style="text-align: left">
                <asp:Button ID="btnSearch" runat="server" CssClass="btn" Text="Save" OnClick="btnSearch_Click"
                    OnClientClick="return ValidateAllTextForm();" />
                <asp:HiddenField ID="HiddenField1" runat="server" />
            </td>
        </tr>
        <tr>
            <td colspan="3" style="text-align: left">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="White"
                    BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" DataKeyNames="ID"
                    OnSelectedIndexChanged="GridView1_SelectedIndexChanged" Width="100%">
                    <RowStyle ForeColor="#000066" />
                    <Columns>
                        <asp:TemplateField HeaderText="Sr.No">
                            <ItemTemplate>
                                <%# Container.DataItemIndex + 1 %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="OrganaizationName" HeaderText="Organization Name" />
                        <asp:CommandField ShowSelectButton="True" HeaderText="Select" />
                        <asp:TemplateField HeaderText="Delete">
                            <ItemTemplate>
                                <asp:LinkButton ID="LnkDelete" Text="Delete" runat="server" OnClick="delete_Click"></asp:LinkButton>
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
