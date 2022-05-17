<%@ Page Language="C#" AutoEventWireup="true" CodeFile="OTPSEND.aspx.cs" Inherits="OTPSEND" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="lblMSg" runat="server"></asp:Label>
            <asp:TextBox ID="txtOtp" runat="server"></asp:TextBox>
            <asp:Button ID="btnOtp" runat="server" OnClick="btnOtp_Click" Text="Send" />
        </div>
    </form>
</body>
</html>
