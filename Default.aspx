<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html>
<head>
  <title>Default Page</title>
</head>

<script runat="server">
    #region Load Menu
    void Page_Load(object sender, EventArgs e)
  {
      Response.Redirect("Login.aspx");
  }

  void Signout_Click(object sender, EventArgs e)
  {
    FormsAuthentication.SignOut();
    Response.Redirect("Login.aspx");
  }
    #endregion
</script>

<body>
 
</body>
</html>
