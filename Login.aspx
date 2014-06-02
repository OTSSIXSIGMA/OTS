<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml"/>
<html>
<head id="Head1" runat="server">
  <title>Login Page</title>
<style type="text/css">
#divCenter {
	position: absolute;
    top: 45%;
    left: 40%;
    margin-top: -50px;
    margin-left: -50px;
    width: 100px;
    height: 100px;
}

#HeadingCenter {
    position: absolute;
    top: 30%;
    left: 33%;
    margin-top: -54px;
    margin-left: 50px;
    width: 295px;
    height: 100px;
}
</style>
    
</head>
<body>
  <form id="form1" runat="server">
    <div id="HeadingCenter">
    <h3>
      Welcome to Online Training System</h3>
    <h3>
    </div>
    <div id="divCenter">
      <h3>
      Login Page</h3>
    <table>
      <tr>
        <td>
          Username:</td>
        <td>
          <asp:TextBox ID="UserEmail" runat="server"  /></td>
        <td>
          <asp:RequiredFieldValidator ID="RequiredFieldValidator1" 
            ControlToValidate="UserEmail"
            Display="Dynamic" 
            ErrorMessage="Cannot be empty." 
            runat="server" />
        </td>
      </tr>
      <tr>
        <td>
          Password:</td>
        <td>
          <asp:TextBox ID="UserPass" TextMode="Password" 
             runat="server" />
        </td>
        <td>
          <asp:RequiredFieldValidator ID="RequiredFieldValidator2" 
            ControlToValidate="UserPass"
            ErrorMessage="Cannot be empty." 
            runat="server" />
        </td>
      </tr>
      <tr>
        <td>
          Remember me?</td>
        <td>
          <asp:CheckBox ID="Persist" runat="server" /></td>
      </tr>
    </table>
    <asp:Button ID="Submit1" OnClick="Logon_Click" Text="Log In" 
       runat="server" />
    <p>
      <asp:Label ID="Msg" ForeColor="red" runat="server" />
    </p>
    </div>
  </form>
</body>
</html>

