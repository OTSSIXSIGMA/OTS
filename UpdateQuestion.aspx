<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UpdateQuestion.aspx.cs" Inherits="UpdateQuestion" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Update Question</title>
    <style type="text/css">
    #divCenter {
	background-color:#FFD700;
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
        <asp:TextBox ID="txtQuestion" runat="server" TextMode="MultiLine" ToolTip="Update with a new Question value" Width="800px" length="500px"></asp:TextBox>
        <br />
        <br />
        <asp:TextBox ID="txtOption1" runat="server" TextMode="MultiLine" ToolTip="Update with a new Option1 value" Width="800px" length="500px"></asp:TextBox>
        <br />
        <br />
        <br />
        <asp:TextBox ID="txtOption2" runat="server" TextMode="MultiLine" ToolTip="Update with a new Option2 value" Width="800px" length="500px"></asp:TextBox>
        <br />
        <br />
        <br />
        <asp:TextBox ID="txtOption3" runat="server" TextMode="MultiLine" ToolTip="Update with a new Option3 value" Width="800px" length="500px"></asp:TextBox>
        <br />
        <br />
        <br />
        <asp:TextBox ID="txtOption4" runat="server" TextMode="MultiLine" ToolTip="Update with a new Option4 value" Width="800px" length="500px"></asp:TextBox>
        <br />
    </div>

        <asp:Button ID="btnUodate" runat="server" Text="Save" OnClick="btnUodate_Click" />
    </form>
</body>
</html>
