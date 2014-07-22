<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Description.aspx.cs" Inherits="Description" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
         <script type="text/javascript">
             function PrintPage() {
                 window.print();
             }
</script>
    <style type="text/css">
#divCenter {
    position: absolute;
    top: 20%;
    left: 20%;
    margin-top: -50px;
    margin-left: -50px;
    width: 1000px;
    height: 1000px;
}
</style>
</head>
<body>
    <form id="form1" runat="server">
    <div id="divCenter">
        <asp:Label ID ="lblDescription" runat ="server"/>
        <br />
        <br />
        <br />
        <br />
        <br />
         <asp:Button ID="btnPrint" runat="server" Text="Print" OnClientClick="javascript:PrintPage();" />
        <%--<asp:Button ID="btnReturn" runat="server" Text="Return to Question" OnClick="btnReturn_Click" />--%>
    </div>
    </form>
</body>
</html>
