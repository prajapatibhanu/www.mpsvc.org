<%@ Page Title="" Language="C#" MasterPageFile="~/AdminSection/AdminMaster.master"
    AutoEventWireup="true" CodeFile="RegistrationDetails.aspx.cs" Inherits="AdminSection_RegistrationDetails" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript">
        function OnChange() {
            if (document.getElementById('<%=ddlType.ClientID %>').value == "All") {
                document.getElementById('ddlDivMemType').style.display = "none";
                document.getElementById('ddlDiv2').style.display = "none";
                document.getElementById('ddlDiv3').style.display = "none";
            }
            else if (document.getElementById('<%=ddlType.ClientID %>').value == "Registration Status") {
                document.getElementById('ddlDivMemType').style.display = "block";
                document.getElementById('ddlDiv2').style.display = "none";
                document.getElementById('ddlDiv3').style.display = "block";
            }
            else if (document.getElementById('<%=ddlType.ClientID %>').value == "Registration No") {
                document.getElementById('ddlDiv2').style.display = "block";
                document.getElementById('ddlDivMemType').style.display = "none";
                document.getElementById('ddlDiv3').style.display = "block";
            }
             else if (document.getElementById('<%=ddlType.ClientID %>').value == "Gender") {
                document.getElementById('DvGender').style.display = "block";
                document.getElementById('ddlDivMemType').style.display = "none";
                document.getElementById('ddlDiv3').style.display = "none";
                document.getElementById('ddlDiv2').style.display = "none";
            }
            else {
                document.getElementById('ddlDiv3').style.display = "none";
                document.getElementById('ddlDiv2').style.display = "none";
                document.getElementById('ddlDivMemType').style.display = "none";
            }
        }

    </script>
    <table width="100%" cellpadding="0" cellspacing="0">
        <tr>
            <td>
                Select :
            </td>
            <td>
                <asp:DropDownList runat="server" ID="ddlType" CssClass="txtbox" onchange="OnChange();">
                    <asp:ListItem Text="All"></asp:ListItem>
                    <asp:ListItem>Registration No</asp:ListItem>
                    <asp:ListItem>Registration Date</asp:ListItem>
                    <asp:ListItem>Registration Status</asp:ListItem>
                    <asp:ListItem>Renew Date</asp:ListItem>
                    <asp:ListItem>Previous Regi Date</asp:ListItem>
                     <asp:ListItem>Gender</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                <div id="ddlDiv3" style="display: none">
                    Value :</div>
                      <div id="DvGender" style="display: none">
                    <asp:RadioButton ID="rbMale" runat="server" Text="Male" GroupName="rbG"   Checked="true"  />
                      <asp:RadioButton ID="rbFemale" runat="server" Text="Female" GroupName="rbG" />
                    </div>
                    
                   
            </td>
            
            <td>
                <div id="ddlDivMemType" style="display: none">
                    <asp:DropDownList runat="server" ID="ddlMemType" CssClass="txtbox">
                        <asp:ListItem>New</asp:ListItem>
                        <asp:ListItem>NOC</asp:ListItem>
                        <asp:ListItem>Dead</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div id="ddlDiv2" style="display: none">
                    <asp:TextBox runat="server" ID="txtValue" CssClass="txtbox" MaxLength="10"></asp:TextBox>
                </div>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td>
                From Date :
            </td>
            <td>
                <asp:TextBox runat="server" ID="txtFDate" CssClass="txtbox" MaxLength="10"></asp:TextBox>
                <cc1:CalendarExtender ID="CalendarExtender4" runat="server" TargetControlID="txtFDate"
                    Format="dd/MM/yyyy">
                </cc1:CalendarExtender>
            </td>
            <td>
                To Date :
            </td>
            <td>
                <asp:TextBox runat="server" ID="txtToDate" CssClass="txtbox" MaxLength="10"></asp:TextBox>
                <cc1:CalendarExtender ID="CalendarExtender5" runat="server" TargetControlID="txtToDate"
                    Format="dd/MM/yyyy">
                </cc1:CalendarExtender>
            </td>
            <td>
                <asp:Button ID="btnSearch" runat="server" CssClass="btn" Text="Search" OnClick="btnSearch_Click" />
            </td>
        </tr>
        <tr>
            <td colspan="5" style="padding-top: 170px;">
                &nbsp;<asp:Panel ID="Panel1" runat="server" ScrollBars="Both" Width="900px" Height="400px">
                    <asp:GridView ID="GridView1" runat="server" BackColor="White" BorderColor="#CCCCCC"
                        BorderStyle="None" BorderWidth="1px" CellPadding="3" AutoGenerateColumns="False">
                        <RowStyle ForeColor="#000066" />
                        <FooterStyle BackColor="White" ForeColor="#000066" />
                        <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                        <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                        <Columns>
                            <asp:BoundField DataField="Name" HeaderText="Name" />
                            <asp:BoundField DataField="FatherName" HeaderText="FatherName" />
                            <asp:BoundField DataField="RegiDate" HeaderText="Reg. Date" />
                            <asp:BoundField DataField="PreRenableDate" HeaderText="Renewal Date" />
                            <asp:BoundField DataField="UpCommingDate" HeaderText="UpComming Date" />
                        </Columns>
                    </asp:GridView>
                </asp:Panel>
                <%--<rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="8pt"
                    InteractiveDeviceInfos="(Collection)" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt"
                    Width="100%" Height="600px">
                </rsweb:ReportViewer>--%>
            </td>
        </tr>
    </table>
</asp:Content>
