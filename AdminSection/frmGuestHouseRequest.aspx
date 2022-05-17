<%@ Page Title="" Language="C#" MasterPageFile="~/AdminSection/GuestHouseMaster.master" AutoEventWireup="true" CodeFile="frmGuestHouseRequest.aspx.cs" Inherits="AdminSection_frmGuestHouseRequest" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
   
    <table width="100%">
        <tr>
            <td style="text-align: center" colspan="3">
                <asp:GridView ID="grdRoomBookRequest" runat="server" AutoGenerateColumns="false" GridLines="None"
                    CssClass="tab" Width="100%" EmptyDataText="Record Not Found." DataKeyNames="RegiNo"
                    PageSize="10" AllowPaging="True" OnSelectedIndexChanged="grdRoomBookRequest_SelectedIndexChanged" OnPageIndexChanging="grdRoomBookRequest_PageIndexChanging" >
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
                        <asp:TemplateField HeaderText="Date Of Booking">
                            <ItemTemplate>
                                <%#Eval("DateOfBooking")%>
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
                        <asp:TemplateField HeaderText="Extra Bed Amount">
                            <ItemTemplate>
                                <%#Eval("ExtraBedAmount")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Total Amount Paid">
                            <ItemTemplate>
                                <%#Eval("TotalAmount")%>
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
                        <asp:TemplateField HeaderText="View">
                            <ItemTemplate>
                                <asp:Button ID="btnverify" CommandName="select" ToolTip='<%#Eval("id")%>' runat="server"
                                    CssClass="btn" Text="View"/>
                            </ItemTemplate>
                        </asp:TemplateField>
                       
                    </Columns>
                    <PagerStyle CssClass="Gvpaging" />
                    <EmptyDataRowStyle CssClass="GvEmptyText" />
                </asp:GridView>
            </td>
        </tr>
    </table>
</asp:Content>

