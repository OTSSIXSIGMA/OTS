<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AdminQuestions.aspx.cs" Inherits="AdminQuestions" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Questions</title>
    <style type="text/css">
#divCenter {
	position: absolute;
    top: 50%;
    left: 50%;
    margin-top: -50px;
    margin-left: -50px;
    width: 100px;
    height: 100px;
}
</style>
</head>
<body>
    <form id="form1" runat="server">
    <div id="divCenter">
        <asp:Button ID="btnView" runat="server" Text="View Questions" OnClick="btnView_Click"/>
        <asp:Button ID="btnEdit" runat="server" Text="Edit/Delete Questions"  OnClick="btnEdit_Click"/>
        <asp:Button ID="btnAdd" runat="server" Text="Add Questions" OnClick="btnAdd_Click"/>
    </div>
    </form>
</body>
</html>
