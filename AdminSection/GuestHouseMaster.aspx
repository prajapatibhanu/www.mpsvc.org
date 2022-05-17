<%@ Page Title="" Language="C#" MasterPageFile="~/AdminSection/AdminMaster.master" AutoEventWireup="true" CodeFile="GuestHouseMaster.aspx.cs" Inherits="AdminSection_GuestHouseMaster" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
  
     <script type ="text/javascript" language ="javascript" >
        function ValidationOnSave() {
            var msg = '';
            if (document.getElementById('<%=txtRoom1Amount.ClientID%>').value.trim() == "") {
                msg = msg + "- Enter Amount in Room 1 \n";
            }
            if (document.getElementById('<%=txtRoom2Amount.ClientID%>').value.trim() == "") {
                msg = msg + "- Enter Amount in Room 2 \n";
            }
            if (document.getElementById('<%=txtRoom3Amount.ClientID%>').value.trim() == "") {
                msg = msg + "- Enter Amount in Room 3 \n";
            }
            if (document.getElementById('<%=txtRoom4Amount.ClientID%>').value.trim() == "") {
                msg = msg + "- Enter Amount in Room 4 \n";
            }          
            if (msg != '') {
                alert(msg);
                return false;
            }
        }
     
    </script>
    <table width="100%">
        <tr>
            <td colspan="3" align="center" style=" background-color:#34A0C0; font-weight: bold;">Room Master</td>
        </tr>
        <tr>
            <td align="center" style="font-weight: bold">Room</td>
            <td align="center" style="font-weight: bold">Amount</td>
            <td align="center" style="font-weight: bold">Availability</td>
        </tr>
        <tr>
            <td align="center">Room 1</td>
            <td align="center">
                <asp:TextBox ID="txtRoom1Amount" runat="server" MaxLength="3"></asp:TextBox><span style="color: Red">*</span>
            </td>
            <cc1:filteredtextboxextender id="FilteredTextBoxExtender1" runat="server" filtertype="Numbers"
                targetcontrolid="txtRoom1Amount" />
            <td align="center">
                <asp:CheckBox ID="ChkRoom1" runat="server" />
            </td>
        </tr>
        <tr>
            <td align="center">Room 2</td>
            <td align="center">
                <asp:TextBox ID="txtRoom2Amount" runat="server" MaxLength="3"></asp:TextBox><span style="color: Red">*</span>
            </td>
            <cc1:filteredtextboxextender id="FilteredTextBoxExtender2" runat="server" filtertype="Numbers"
                targetcontrolid="txtRoom2Amount" />
            <td align="center">
                <asp:CheckBox ID="ChkRoom2" runat="server" />
            </td>
        </tr>
        <tr>
            <td align="center">Room 3 </td>
            <td align="center">
                <asp:TextBox ID="txtRoom3Amount" runat="server" MaxLength="3"></asp:TextBox><span style="color: Red">*</span>
            </td>
            <cc1:filteredtextboxextender id="FilteredTextBoxExtender3" runat="server" filtertype="Numbers"
                targetcontrolid="txtRoom3Amount" />
            <td align="center">
                <asp:CheckBox ID="ChkRoom3" runat="server" />
            </td>
        </tr>
        <tr>
            <td align="center">Room 4</td>
            <td align="center">
                <asp:TextBox ID="txtRoom4Amount" runat="server" MaxLength="3"></asp:TextBox><span style="color: Red">*</span>
            </td>
            <cc1:filteredtextboxextender id="FilteredTextBoxExtender4" runat="server" filtertype="Numbers"
                targetcontrolid="txtRoom4Amount" />
            <td align="center">
                <asp:CheckBox ID="ChkRoom4" runat="server" />
            </td>
        </tr>
        <tr>
            <td colspan ="3"></td>
        </tr>
        <tr>
            <td colspan="3" align="center">
                <asp:Button ID="btnSave" runat="server" CssClass="btn"  OnClientClick="return ValidationOnSave()" OnClick="btnBook_Click" Text="Save" /></td>
        </tr>
    </table>
</asp:Content>

