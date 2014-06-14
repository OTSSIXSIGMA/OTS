<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Reporting.aspx.cs" Inherits="Reporting" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Report</title>
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
    </style>
     <script type="text/javascript">
         function PrintPage() {
             window.print();
         }
</script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="divCenter">
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
            <asp:BoundField DataField="Result" HeaderText="Result">
               <ItemStyle HorizontalAlign="Center" />
               </asp:BoundField>
                </Columns>
        </asp:GridView>
        <asp:Button ID="btnReturn" runat="server" Text="Return to main menu" OnClick="btnReturn_Click" />
        <asp:Button ID="btnPrint" runat="server" Text="Print" OnClientClick="javascript:PrintPage();" />
        
    </div>
    </form>
</body>
</html>
