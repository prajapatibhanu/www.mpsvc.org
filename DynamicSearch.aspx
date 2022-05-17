<%@ Page Language="C#" MasterPageFile="~/AdminSection/AdminMaster.master" AutoEventWireup="true"
    CodeFile="DynamicSearch.aspx.cs" Inherits="AdminSection_DynamicSearch" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
  <asp:UpdatePanel ID="updatepanel1" runat="server">
        <contenttemplate>
            
   
        <table cellspacing="5" cellpadding="0" width="100%">
            <tr>
                <td colspan="2">
                    Dynamic Report</td>
            </tr>
            
                <tr>
                    <td colspan="2">
                        <asp:CheckBoxList ID="cblFields" runat="server" OnSelectedIndexChanged="cblFields_SelectedIndexChanged">
                        </asp:CheckBoxList>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: right" colspan="2">
                        &nbsp;<asp:Button ID="btnExport" OnClick="btnExport_Click" runat="server" CssClass="button"
                            Height="28px" Text="Export To Excel" Visible="false"></asp:Button></td>
                </tr>
                <tr>
                    <td colspan="2">
                        <div style="overflow: auto; width: 930px">
                            <asp:GridView ID="gridDetails" runat="server" Width="100%" AutoGenerateColumns="false"
                                ShowHeader="true" CssClass="attengrid" EnableViewState="false">
                            </asp:GridView>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: right" colspan="4">
                        &nbsp;</td>
                </tr>
            
        </table>
        </contenttemplate>
 <triggers>
            <asp:PostBackTrigger ControlID="btnExport" />
        </triggers>
    </asp:UpdatePanel>
    
</asp:Content>
