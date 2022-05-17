<%@ Page Language="C#" MasterPageFile="~/AdminSection/AdminMaster.master" AutoEventWireup="true" CodeFile="SearchBy.aspx.cs" Inherits="AdminSection_SearchBy" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table width="100%" cellpadding="0" cellspacing="0">
    <tr>
        <td colspan="7">
            <strong>Check your Status </strong>
        </td>
    </tr>
        <tr>
            <td colspan="7">
                <asp:Label ID="lblMsg" runat="server" ></asp:Label>
                
                </td>
        </tr>
        <tr>
            <td>
                Name:
            </td>
            <td>
                
                <asp:TextBox ID="txtname" runat="server" MaxLength="30" onkeypress='javascript:tbx_fnInteger(event, this);' CssClass="txtbox "></asp:TextBox>
                
            </td>
            <td>
                Mobile No</td>
            <td>
                <asp:TextBox ID="txMobile" runat="server" CssClass="txtbox reqirerd" MaxLength="10"></asp:TextBox></td>
            <td>
                Email ID</td>
            <td>
                <asp:TextBox ID="TextBox1" runat="server" CssClass="txtbox reqirerd" MaxLength="10"></asp:TextBox></td>
            <td>
                &nbsp;
                <asp:Button ID="btnSearch" runat="server" CssClass="btn" OnClick="btnSearch_Click"
                    Text="Search" /></td>
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
                    <asp:BoundField DataField="aa" HeaderText="Status" />
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

