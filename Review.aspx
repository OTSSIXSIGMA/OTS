<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Review.aspx.cs" Inherits="Review" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Review</title>
    <style type="text/css">
            body {
            background-image:url('Resources/images/loginbackground.png');
            background-repeat:no-repeat;
            background-attachment:fixed;
            background-color:#F9FAFF;
            }
    #divCenter {
    position: absolute;
    top: 45%;
    left: 20%;
    margin-top: -50px;
    margin-left: -50px;
    width: 1000px;
    height: 1000px;
    font-size : 16px;
    font-family : Calibri;
    font-weight : bold;
    color : #244C95;
    }
    </style>
     <script type="text/javascript" src="Resources/js/jquery-1.7.2.min.js"></script>
    <script type="text/javascript" src="Resources/js/Shadowbox/shadowbox.js"></script>
    <link rel="stylesheet" type="text/css" href="Resources/css/Shadowbox.css"/>
    <script type="text/javascript">
        Shadowbox.init();
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="divCenter">
        <asp:Label ID="LblResult" runat="server" Text=""></asp:Label>
        <br />
        <div>
            <br />
        <a href="Reporting.aspx" rel="shadowbox;height=500;width=500"> Click here to Check Status </a>
        </div>
        <br />
        <div>
        <asp:Button ID="btnPrevious" runat="server" Text="Previous" OnClick="btnPrevious_Click" BackColor="#C7D7E6" />
        <asp:Button ID="btnContinue" runat="server" Text="Next" OnClick="btnContinue_Click" BackColor="#C7D7E6" />
        <asp:Button ID="btnMenu" runat="server" Text="Return to Main Menu" OnClick="btnMenu_Click" BackColor="#C7D7E6" />
        </div>
        
        </div>
    </form>
</body>
</html>
