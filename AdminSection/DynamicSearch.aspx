<%@ Page Language="C#" MasterPageFile="~/AdminSection/AdminMaster.master" AutoEventWireup="true"
    CodeFile="DynamicSearch.aspx.cs" Inherits="AdminSection_DynamicSearch" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type ="text/javascript" language ="javascript" >
        function GetGridValue() {
            var gridData = document.getElementById('<%= gridDetails.ClientID %>');
            var windowUrl = 'about:blank';
            //set print document name for gridview
            var uniqueName = new Date();
            var windowName = 'Print_' + uniqueName.getTime();

            var prtWindow = window.open(windowUrl, windowName, 'left=100,top=100,right=100,bottom=100,width=950,height=500');
            prtWindow.document.write('<html><head></head>');
            prtWindow.document.write('<body style=”background:none !important”>');
            prtWindow.document.write(gridData.outerHTML);
            prtWindow.document.write('</body></html>');
            prtWindow.document.close();
            prtWindow.focus();
            prtWindow.print();
            prtWindow.close();
            return false;
        }
</script>
    <asp:UpdatePanel ID="updatepanel1" runat="server">
        <ContentTemplate>
            <table cellspacing="5" cellpadding="0" width="100%">
                <tr>
                    <td colspan="2">
                        </td>
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
                            Height="28px" Text="Export To Excel" Visible="false"></asp:Button>
                    </td>
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
                    <td style="text-align: center" colspan="2">
                        <asp:Button ID="btnPrint" runat="server" CssClass="btn" Text="Print"  OnClientClick ="return GetGridValue();" />
                    </td>
                </tr>

                <tr>
                    <td style="text-align: right" colspan="4">
                        &nbsp;
                    </td>
                </tr>
            </table>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnExport" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
