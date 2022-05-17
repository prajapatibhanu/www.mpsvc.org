<%@ Page Language="C#" MasterPageFile="~/AdminSection/AdminMaster.master" AutoEventWireup="true"
    CodeFile="AbstractPhysicalAndFinancialReport.aspx.cs" Inherits="AdminSection_AbstractPhysicalAndFinancialReport"
    Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
       <script type="text/javascript" language="javascript">
        function validationOnshow() {
            var errormsf = '';
            if (document.getElementById('<%=txtFDate.ClientID%>').value.trim() == '') {
                errormsf = errormsf + "Please select from date. \n"
            }
            if (document.getElementById('<%=txtToDate.ClientID%>').value.trim() == '') {
                errormsf = errormsf + "Please select To date. \n"
            }
            if (errormsf != '') {
                alert(errormsf);
                return false;
            }

        }
       
    </script>
    <table width="100%" cellpadding="0" cellspacing="0">
        <tr>
            <td>
                From Date :
            </td>
            <td>
                <asp:TextBox runat="server" ID="txtFDate" CssClass="txtbox" onchange="checkDateFormat(this)" MaxLength="10"></asp:TextBox>
                <cc1:CalendarExtender ID="CalendarExtender4" runat="server" TargetControlID="txtFDate"
                    PopupButtonID="imgFrmdate" Format="dd/MM/yyyy">
                </cc1:CalendarExtender>
                <img id="imgFrmdate" src="../images/calender.png" />
            </td>
            <td>
                To Date :
            </td>
            <td>
                <asp:TextBox runat="server" ID="txtToDate" CssClass="txtbox" onchange="checkDateFormat(this)" MaxLength="10"></asp:TextBox>
                <cc1:CalendarExtender ID="CalendarExtender5" runat="server" TargetControlID="txtToDate"
                    PopupButtonID="ImgTodate" Format="dd/MM/yyyy">
                </cc1:CalendarExtender>
                <img id="ImgTodate" src="../images/calender.png" />
            </td>
            <td>
                <asp:Button ID="btnSearch" runat="server" CssClass="btn" Text="Search" OnClientClick="javascript:return(validationOnshow());"
                    OnClick="btnSearch_Click" />
            </td>
        </tr>
        <tr >
            <td colspan="5" style ="padding-top :50px" >
                <div id="divreport" runat="server">
                </div>
            </td>
        </tr>
        <tr>
            <td colspan="5" align ="center" >
             <asp:Button ID="btnPrint" runat="server" CssClass="btn" Text="Print" OnClick="btnPrint_Click"/>
            </td>
        </tr>
    </table>
</asp:Content>
