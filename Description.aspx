<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Description.aspx.cs" Inherits="Description" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">

#HeadingCenter {
    position: absolute;
    top: 30%;
    left: 33%;
    margin-top: -54px;
    margin-left: 50px;
    }
</style>
</head>
<body>
    <form id="form1" runat="server">
    <div align="center" id="HeadingCenter">
        <asp:Label ID ="lblDescription" runat ="server"/>
        <%--<asp:Button ID="btnReturn" runat="server" Text="Return to Question" OnClick="btnReturn_Click" />--%>
    </div>
    </form>
</body>
</html>
