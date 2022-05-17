<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PrintHTMLReport.aspx.cs"
    Inherits="AdminSection_PrintHTMLReport" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Print Report</title>

    <script type="text/javascript" language="javascript">
        function Print() { window.print(); }
    </script>

    <script type="text/javascript">
        function burstCache() {
            if (!navigator.onLine) {
                document.body.innerHTML = 'Loading...';
                window.location = 'ErrorPage.html';
            }
        }
    </script>

</head>
<body onload="Print();">
    <form id="form1" runat="server" style="font-family: 'Arial Unicode MS'">
    <center>
        <%=PrintSTR%>
    </center>
    </form>
</body>
</html>
