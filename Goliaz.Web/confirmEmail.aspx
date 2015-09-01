<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="confirmEmail.aspx.cs" Inherits="Goliaz.Web.confirmEmail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Goliaz Challenge</title>
    <script src="js/jquery-1.11.3.min.js"></script>
    <script src="js/jquery-ui.js" type="text/javascript" ></script>

    <meta http-equiv="Cache-Control" content="no-store" />

    <link href="css/jquery-ui.css" type="text/css" rel="stylesheet" />
    <link href="css/StyleIndex.css" type="text/css" rel="stylesheet" />
    <script type="text/javascript">
        $(document).ready(function () {
            $("#divMensaje").dialog({
                autoOpen: false,
                width: 290,
                height: "auto",
                dialogClass: 'noTitleStuff'
            });

            $("#divError").dialog({
                autoOpen: false,
                width: 290,
                height: "auto",
                dialogClass: 'noTitleStuff'
            });
        });
        
        function showMessage() {
            $("#divMensaje").dialog("open");
        }

        function showError() {
            $("#divError").dialog("open");
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="divMensaje" >
        <p style="padding-top:30px;">
            Congratulations! Your registration has been confirmed! Now, please go to the <a href="http://www.freeleticsworld.com/goliaz-vo2max-challenge-sep2015/" >Frequently Asked Questions</a> which will tell you everything you need to know.<br /><br />
            Have a great challenge!<br />
            <asp:Button ID="btnGoto" runat="server" Text="Go to Reports" CssClass="btnEstilo" OnClick="btnGoto_Click" />
        </p>
    </div>
    <div id="divError" >
        <p id="errorParrafo" runat="server" style="padding-top:30px;">
        </p>
    </div>
    </form>
</body>
</html>