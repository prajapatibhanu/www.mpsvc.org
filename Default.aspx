<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript" src='https://ajax.aspnetcdn.com/ajax/jQuery/jquery-1.8.3.min.js'></script>
    <script type="text/javascript" src='https://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/3.0.3/js/bootstrap.min.js'></script>
    <link rel="stylesheet" href='https://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/3.0.3/css/bootstrap.min.css' media="screen" />
    <script src="poplink/NewpopupLinkjquery-1.8.3.min.js"></script>
    <script src="poplink/NewpopupLinkbootstrap.min.js"></script>
    <link href="poplink/newpopupLink23bootstrap.min.css" rel="stylesheet" />
    <script type="text/javascript">
        function ShowPopup(title, body) {
            $("#myModal1 .modal-title").html(title);
            $("#myModal1 .modal-body").html(body);
            $("#myModal1").modal("show");
        }

    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div id="strFeedback" runat="server">
          <%--  <table">
                <td colspan="4"
            </table>--%>
        </div>
    </form>
</body>
</html>
