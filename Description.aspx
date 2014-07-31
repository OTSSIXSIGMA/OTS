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
    #divCenter 
            {
            position: absolute;
            top: 40%;
            left: 20%;
            margin-top: -250px;
            margin-left: -50px;
            width: 500px;
            height: 500px;
            font-size : 16px;
            font-family : Calibri;
            color :  #0000CD;
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
        <asp:Button ID="btnReturnQuestion" runat="server" Text="Go back to Question" OnClick="btnReturn_Click"/>
    </div>
    </form>
</body>
</html>
