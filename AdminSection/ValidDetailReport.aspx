<%@ Page Title="" Language="C#" MasterPageFile="~/AdminSection/AdminMaster.master" AutoEventWireup="true" CodeFile="ValidDetailReport.aspx.cs" ValidateRequest="false" Inherits="AdminSection_ValidDetailReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript" language="javascript">
        function GetGridValue() {
            if (document.getElementById('<%=rbValid.ClientID%>').checked == true) {

                var gridData = document.getElementById('<%= GrdValidReg.ClientID %>');
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




                //document.getElementById('<%=HF_GridData.ClientID%>').value = document.getElementById('<%=divValid.ClientID%>').innerHTML;
                return false;
            }
            else if (document.getElementById('<%=rbInvalid.ClientID%>').checked == true) {

                var gridData = document.getElementById('<%= GrdInvalidReg.ClientID %>');
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

            else if (document.getElementById('<%=rbTransOut.ClientID%>').checked == true) {

                var gridData = document.getElementById('<%= GrdTransferOut.ClientID %>');
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


            else if (document.getElementById('<%=rbCancel.ClientID%>').checked == true) {

                var gridData = document.getElementById('<%= GridCancel.ClientID %>');
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
        }
    </script>

    <table width="100%">
        <tr>
            <td colspan="3" align="center">
                <asp:RadioButton ID="rbValid" runat="server" Font-Bold="true" AutoPostBack="true" Checked="true"
                    Text="For Valid " GroupName="Action" OnCheckedChanged="rbValid_CheckedChanged" />
                &nbsp;&nbsp;&nbsp;
                <asp:RadioButton ID="rbInvalid" runat="server" Font-Bold="true" AutoPostBack="true"
                    Text="For Invalid" GroupName="Action" OnCheckedChanged="rbInvalid_CheckedChanged" />
                &nbsp;&nbsp; 
                 <asp:RadioButton ID="rbTransOut" runat="server" Font-Bold="true" AutoPostBack="true"
                    Text="For Transfer out" GroupName="Action" OnCheckedChanged="rbTransOut_CheckedChanged" />
                &nbsp;&nbsp; 
                 <asp:RadioButton ID="rbCancel" runat="server" Font-Bold="true" AutoPostBack="true"
                    Text="For Canceled" GroupName="Action" OnCheckedChanged="rbCancel_CheckedChanged" />
                &nbsp;&nbsp;          
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
                <div id="divValid" runat="server" style="overflow: auto;">
                    <asp:GridView ID="GrdValidReg"  runat="server" Width="100%" AutoGenerateColumns="false" AllowSorting ="true" 
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
                <div id="divInvalid" runat="server" style="overflow: auto;">
                    <asp:GridView ID="GrdInvalidReg" runat="server" Width="100%" AutoGenerateColumns="false"
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
                <div id="DivTransferOut" runat="server" style="overflow: auto;">
                    <asp:GridView ID="GrdTransferOut" runat="server" Width="100%" AutoGenerateColumns="false"
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
                            <asp:TemplateField HeaderText="Valid up to">
                                <ItemTemplate>
                                    <%#Eval("Validupto")%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Transfered To">
                                <ItemTemplate>
                                    <%#Eval("StateName")%>
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
                <div id="Divcancel" runat="server" style="overflow: auto;">
                    <asp:GridView ID="GridCancel" runat="server" Width="100%" AutoGenerateColumns="false"
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
                            <%--<asp:TemplateField HeaderText="Valid up to">
                                <ItemTemplate>
                                    <%#Eval("Validupto")%>
                                </ItemTemplate>
                            </asp:TemplateField>--%>
                           
                        </Columns>
                        <PagerStyle CssClass="Gvpaging" />
                        <EmptyDataRowStyle CssClass="GvEmptyText" />
                    </asp:GridView>
                </div>
            </td>
        </tr>
        <tr>
            <td style="text-align: center" colspan="3">
                <asp:Button ID="btnPrint" runat="server" CssClass="btn" Text="Print" OnClick="btnPrint_Click" OnClientClick="return GetGridValue();" />
                &nbsp;&nbsp;&nbsp;
            </td>
        </tr>
        <asp:HiddenField ID="HF_GridData" runat="server" />
    </table>
</asp:Content>

