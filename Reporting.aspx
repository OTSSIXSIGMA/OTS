<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Reporting.aspx.cs" Inherits="Reporting" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Report</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="lblReport" runat="server" ></asp:Label>
        <asp:GridView ID="gdvReport" runat="server" AutoGenerateColumns="false">
            <Columns>   
               <asp:BoundField DataField="Question" HeaderText="Question">
               <ItemStyle HorizontalAlign="Center" />
               </asp:BoundField>
            <asp:BoundField DataField="Choice" HeaderText="Choice">
               <ItemStyle HorizontalAlign="Center" />
               </asp:BoundField>
            <asp:BoundField DataField="Answer" HeaderText="Answer">
               <ItemStyle HorizontalAlign="Center" />
               </asp:BoundField>
                </Columns>
        </asp:GridView>
        
    </div>
    </form>
</body>
</html>
