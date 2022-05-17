<%@ Page Title="" Language="C#" MasterPageFile="~/AdminSection/AdminMaster.master" AutoEventWireup="true" CodeFile="RptGuestHouse.aspx.cs" Inherits="AdminSection_RptGuestHouse" ValidateRequest="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript" language="javascript">
        function validationOnshow() {
            var errormsf = '';
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

            var gridData = document.getElementById('<%= grdRoomBookRequest.ClientID %>');
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
        function CheckFromDateToDate() {
            var str1 = document.getElementById('<%=txtFDate.ClientID%>').value; //Fromdate
            var str2 = document.getElementById('<%=txtToDate.ClientID%>').value;  //todate      
            var sptdate1 = str1.split("/");
            var sptdate2 = str2.split("/");
            var datestring1 = sptdate1[1] + "/" + sptdate1[0] + "/" + sptdate1[2];
            var datestring2 = sptdate2[1] + "/" + sptdate2[0] + "/" + sptdate2[2];
            // alert(GlobalLanguage);
            var date1 = new Date(datestring1)
            var date2 = new Date(datestring2);
            if (date2 < date1) {
                alert("From Date Must Be Less Than To Date");
                document.getElementById('<%=txtToDate.ClientID%>').value = "";
                return false;
            }
            else {
                CheckDate();
                return true;
            }

        }
    </script>
    <table width="100%">
        <tr>
            <td>From Date :
            </td>
            <td>
                <asp:TextBox runat="server" ID="txtFDate" CssClass="txtbox" onchange="checkDateFormat(this),CheckFromDateToDate()" MaxLength="10"></asp:TextBox>
                <cc1:CalendarExtender ID="CalendarExtender4" runat="server" TargetControlID="txtFDate"
                    PopupButtonID="imgFrmdate" Format="dd/MM/yyyy">
                </cc1:CalendarExtender>
                <img id="imgFrmdate" src="../images/calender.png" />
            </td>
            <td>To Date :
            </td>
            <td>
                <asp:TextBox runat="server" ID="txtToDate" CssClass="txtbox" onchange="checkDateFormat(this),CheckFromDateToDate()" MaxLength="10"></asp:TextBox>
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
            <td colspan="5"></td>
        </tr>
        <tr>
            <td style="text-align: center" colspan="5">
                <div id="divPhysical" runat="server" style="overflow: auto;">
                    <asp:GridView ID="grdRoomBookRequest" runat="server" Width="100%" AutoGenerateColumns="false"
                                ShowHeader="true" CssClass="attengrid" EnableViewState="false">
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
                            <asp:TemplateField HeaderText="Mobile No">
                                <ItemTemplate>
                                    <%#Eval("MobileNo")%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Booked Room No.">
                                <ItemTemplate>
                                    <%#Eval("RoomNo")%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Extra Bed">
                                <ItemTemplate>
                                    <%#Eval("IsExtraBedRequired")%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="From Date">
                                <ItemTemplate>
                                    <%#Eval("FromDate")%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="To Date">
                                <ItemTemplate>
                                    <%#Eval("ToDate")%>
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
                            <asp:TemplateField HeaderText="Check In Time">
                                <ItemTemplate>
                                    <%#Eval("CheckInTime")%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Check Out Time">
                                <ItemTemplate>
                                    <%#Eval("CheckOutTime")%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="TransactionId">
                                <ItemTemplate>
                                    <%#Eval("TransactionId")%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="No of day">
                                <ItemTemplate>
                                    <%#Eval("NoOfDay")%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Extra bed amount">
                                <ItemTemplate>
                                    <%#Eval("ExtraBedAmount")%>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:Label ID="lblTotalAmt" runat="server" Text="TOTAL AMOUNT" Font-Bold="true" />
                                </FooterTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Total Amount Paid">
                                <ItemTemplate>
                                    <asp:Label ID="lblPrice" runat="server" Text='<%#Eval("TotalAmount")%>' />
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:Label ID="lblTotal" runat="server" Font-Bold="true" />
                                </FooterTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <PagerStyle CssClass="Gvpaging" />
                        <EmptyDataRowStyle CssClass="GvEmptyText" />
                    </asp:GridView>
                </div>
            </td>
        </tr>
        <tr>
            <td style="text-align: center" colspan="5">
                <asp:Button ID="btnPrint" runat="server" CssClass="btn" Text="Print" OnClick="btnPrint_Click" OnClientClick="GetGridValue()" />
                &nbsp;&nbsp;&nbsp;
                <asp:HiddenField ID="HF_GridData" runat="server" />
            </td>

        </tr>
    </table>
</asp:Content>

