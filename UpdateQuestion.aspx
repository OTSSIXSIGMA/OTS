<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UpdateQuestion.aspx.cs" Inherits="UpdateQuestion" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Update Question</title>
    <style type="text/css">
    #divCenter {
	background-color:#81DAF5;
    }
</style>

</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table>
            <tr>
                
            </tr>
            <tr>
                
            </tr>
            <tr>
                
            </tr>
            <tr>
               
            </tr>
            <tr>
                
            </tr>
        </table>
        <asp:TextBox ID="txtQuestion" runat="server" TextMode="MultiLine" ToolTip="Update with a new value" Width="800px" length="300px"></asp:TextBox>
        <br />
        <br />
        <asp:TextBox ID="txtOption1" runat="server" TextMode="MultiLine"></asp:TextBox>
        <br />
        <br />
        <br />
        <asp:TextBox ID="txtOption2" runat="server" TextMode="MultiLine"></asp:TextBox>
        <br />
        <br />
        <br />
        <asp:TextBox ID="txtOption3" runat="server" TextMode="MultiLine"></asp:TextBox>
        <br />
        <br />
        <br />
        <asp:TextBox ID="txtOption4" runat="server" TextMode="MultiLine"></asp:TextBox>
        <br />
    </div>

        <asp:Button ID="btnUodate" runat="server" Text="Save" OnClick="btnUodate_Click" />
    </form>
</body>
</html>
