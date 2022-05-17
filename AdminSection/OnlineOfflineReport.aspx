<%@ Page Title="" Language="C#" MasterPageFile="~/AdminSection/AdminMaster.master" ValidateRequest="false" AutoEventWireup="true" CodeFile="OnlineOfflineReport.aspx.cs" Inherits="AdminSection_OnlineOfflineReport" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript" language="javascript">
        function validationOnshow() {
            var errormsf = '';
            if (document.getElementById('<%=ddlType.ClientID%>').selectedIndex <= 0) {
                errormsf = errormsf + "Please select Report Type. \n"
            }
            if (document.getElementById('<%=txtFDate.ClientID%>').value == '') {
                errormsf = errormsf + "Please select from date. \n"
            }
            if (document.getElementById('<%=txtToDate.ClientID%>').value == '') {
                errormsf = errormsf + "Please select To date. \n"
            }
            if (errormsf != '') {
                alert(errormsf);
                return false;
            }

        }
        function GetGridValue() {
            //document.getElementById('<%=HF_GridData.ClientID%>').value = document.getElementById('<%=divPhysical.ClientID%>').innerHTML;
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
        }
    </script>
    <asp:UpdatePanel ID="updatepanel1" runat="server">
        <ContentTemplate>
            <table width="100%" cellpadding="0" cellspacing="0">
                <tr>
                    <td>Payment Type :
                    </td>
                    <td colspan="2">
                        <asp:RadioButton ID="rbOnline" runat="server" Text="Online" GroupName="Status" />
                        <asp:RadioButton ID="rbOffline" runat="server" Text="Offline" GroupName="Status" />
                        <asp:RadioButton ID="rbBoth" runat="server" Text="Both" GroupName="Status" />
                    </td>
                </tr>
                <tr>
                    <td>Select Report Type :
                    </td>
                    <td colspan="2">
                        <asp:DropDownList runat="server" ID="ddlType" CssClass="txtbox" onchange="OnChange();">
                            <asp:ListItem Text="----Select----" Value="0000"></asp:ListItem>
                            <asp:ListItem Text="All" Value="00000"></asp:ListItem>
                            <asp:ListItem Text="Provisional" Value="7"></asp:ListItem>
                            <asp:ListItem Text="New" Value="0"></asp:ListItem>
                            <asp:ListItem Text="Renewal" Value="1"></asp:ListItem>
                            <asp:ListItem Text="Transfer out of M.P" Value="2"></asp:ListItem>
                            <asp:ListItem Text="Transfer in M.P" Value="3"></asp:ListItem>
                            <asp:ListItem Text="Duplicate Id Card" Value="4"></asp:ListItem>
                            <asp:ListItem Text="Duplicate Certificate" Value="5"></asp:ListItem>
                            <asp:ListItem Text="Addition of Qualification" Value="6"></asp:ListItem>
                        </asp:DropDownList>
                    </td>

                </tr>
                <tr>
                    <td>From Date :
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtFDate" CssClass="txtbox" onchange="checkDateFormat(this)" MaxLength="10"></asp:TextBox>
                        <cc1:CalendarExtender ID="CalendarExtender4" runat="server" TargetControlID="txtFDate"
                            PopupButtonID="imgFrmdate" Format="dd/MM/yyyy">
                        </cc1:CalendarExtender>
                        <img id="imgFrmdate" src="../images/calender.png" />
                    </td>
                    <td>To Date :
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtToDate" CssClass="txtbox" onchange="checkDateFormat(this)" MaxLength="10"></asp:TextBox>
                        <cc1:CalendarExtender ID="CalendarExtender5" runat="server" TargetControlID="txtToDate"
                            PopupButtonID="ImgTodate" Format="dd/MM/yyyy">
                        </cc1:CalendarExtender>
                        <img id="ImgTodate" src="../images/calender.png" />
                    </td>
                    <td>
                        <asp:Button ID="btnSearch" runat="server" CssClass="btn" Text="Search" OnClientClick="javascript:return(validationOnshow());" OnClick="btnSearch_Click" />
                    </td>
                </tr>
                <tr>
                    <td colspan="5">
                        <asp:CheckBoxList ID="cblFields" runat="server" OnSelectedIndexChanged="cblFields_SelectedIndexChanged">
                        </asp:CheckBoxList>
                    </td>
                </tr>
                <tr>
                    <td colspan="5" style="padding-top: 20px;">
                        <div id="divPhysical" runat="server" style="overflow: auto; width: 930px">
                            <asp:GridView ID="gridDetails" runat="server" Width="100%" AutoGenerateColumns="false"
                                ShowHeader="true" CssClass="attengrid" EnableViewState="false">
                            </asp:GridView>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td colspan="5" align="center"></td>
                </tr>
                <tr>
                    <td colspan="5" align="center">
                        <asp:Button ID="btnPrint" runat="server" CssClass="btn" Text="Print"
                            OnClick="btnPrint_Click" OnClientClick="GetGridValue()" />

                    </td>
                </tr>
                <asp:HiddenField ID="HF_GridData" runat="server" />
            </table>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnSearch" />
            <asp:PostBackTrigger ControlID="btnPrint" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>

