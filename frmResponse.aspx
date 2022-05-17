<%@ Page Title="" Language="C#" MasterPageFile="~/AdminSection/MasterPage.master" AutoEventWireup="true" CodeFile="frmResponse.aspx.cs" Inherits="frmResponse" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table width ="100%">
        <tr>
          <td colspan ="2"> <asp:Label ID="lblMsg" runat="server" Text ="Result"></asp:Label> </td>
        </tr>
         <tr>
            <td align ="left"> <asp:Label ID="Labelvalidate" runat="server" Text ="Transaction Status :-" Font-Bold="True" ></asp:Label>&nbsp;&nbsp; <asp:Label ID="lblValidate" runat="server"></asp:Label></td>
           
        </tr>

    </table>
</asp:Content>

