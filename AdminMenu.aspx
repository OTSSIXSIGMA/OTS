<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AdminMenu.aspx.cs" Inherits="AdminMenu" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Admin Menu</title>
    <style type="text/css">
#divCenter {
    position: absolute;
    top: 50%;
    left: 50%;
    margin-top: -50px;
    margin-left: -50px;
    width: 200px;
    height: 100px;
    font-size: 16px;
    color :  #0000CD;
}
</style>
</head>
<body>
    <form id="form1" runat="server">
    <div id="divCenter">
    <p> Welcome Admin !!</p>
        <asp:Button ID="btnUsers" runat="server" Text="Manage Users" OnClick="btnUsers_Click"/>
        <br/>
        <asp:Button ID="btnTests" runat="server" Text="Manage Tests" OnClick="btnTests_Click"/>

    </div>
    </form>
</body>
</html>
