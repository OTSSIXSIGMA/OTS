<%@ Page Language="C#" AutoEventWireup="true" CodeFile="StudentMenu.aspx.cs" Inherits="Menu" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Student Menu</title>
<style type="text/css">

 
#divCenter {
	position: absolute;
    top: 50%;
    left: 47%;
    margin-top: -50px;
    margin-left: -40px;
    width: 100px;
    height: 100px;
}
</style>
 
</head>
<body>
    <form id="form1" runat="server">
    <div id="banner">
               <img src="Resources/images/loginbackground.png"  style="width:100%;height:90%;align-items:center" alt="Welcome to Six Sigma Online Training System"/>
             </div>
    <div id="divCenter">
<asp:Button ID="btnStartTest" runat="server" Text="Start Test" BackColor="#C7D7E6" OnClick="btnStartTest_Click" style="height:50px; width:200px;color:#08088A;font-weight:bold;font-family:Calibri;font-size:18px;"/>
<asp:Button ID="btnContinue" runat="server" Text="Resume Test" BackColor="#C7D7E6" OnClick="btnContinue_Click" style="height:50px; width:200px;color:#08088A;font-weight:bold;font-family:Calibri;font-size:18px;"/>
<asp:Button ID="btnReturn" runat="server" Text="Return to the Test Menu" BackColor="#C7D7E6" OnClick="btnReturn_Click" style="height:50px; width:200px;color:#08088A;font-weight:bold;font-family:Calibri;font-size:18px;"/>
<asp:Button ID="btnSignout" runat="server" Text="SignOut" BackColor="#C7D7E6" OnClick="btnSignout_Click" style="height:50px; width:200px;color:#08088A;font-weight:bold;font-family:Calibri;font-size:18px;"/>
    </div>
    </form>
</body>
</html>
   
