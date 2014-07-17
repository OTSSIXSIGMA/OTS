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
    width: 100px;
    height: 100px;
    font-weight : bold;
    color: #0000CD;
    font-size : 16px;
}
</style>
</head>
<body>
    <form id="form1" runat="server">
    <div id="divCenter">
    <p>Welcome Admin !!</p>
    
        <asp:Button ID="btnUsers" runat="server" ForeColor="SeaGreen"  Text="BackColor LightCoral"  Font-Bold="true"  Text="Manage Users" OnClick="btnUsers_Click"/>
        <asp:Button ID="btnTests" runat="server" ForeColor="SeaGreen"  Text="BackColor LightCoral"  Font-Bold="true"  Text="Manage Tests" OnClick="btnTests_Click"/>
        <asp:Button ID="btnSignout" runat="server" ForeColor="SeaGreen"  Text="BackColor LightCoral"  Font-Bold="true"  Text="Signout" OnClick="btnSignout_Click"/>
    </div>
    </form>
</body>
</html>
