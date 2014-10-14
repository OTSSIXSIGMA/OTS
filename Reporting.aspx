<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Reporting.aspx.cs" Inherits="Reporting" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Report</title>
      <style type="text/css">
    #divCenter {
    position: absolute;
    top: 45%;
    left: 30%;
    margin-top: -100px;
    margin-left: -150px;
    width: 100px;
    height: 100px;
    font-size : 16px;
            font-family : Calibri;
            color :  #0000CD;
    }
     #logout{
             top: 50%;
            left: 50%;
            margin-top: 10px;
            margin-left: 1200px;
            font-size : 18px;
            font-family : Calibri;
            align-content:center;
            font-weight: bold;
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
             <asp:GridView ID="gdvReport" runat="server" AutoGenerateColumns="false" BorderWidth="1px" BackColor="#E2EBF2"
            CellPadding="5" CellSpacing="2" BorderStyle="Double" BorderColor="#301793" SkinID="Professional" Font-Name="Calibri"
            Font-Size="14pt"
            HeaderStyle-BackColor="#6666FF"
            HeaderStyle-ForeColor="White"
            AlternatingRowStyle-BackColor="#dddddd" Width="120" Height="100">
            <Columns>   
               <asp:BoundField DataField="Question" HeaderText="Question" >
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
                <asp:BoundField DataField="CorrectRate" HeaderText="CorrectRate %">
               <ItemStyle HorizontalAlign="Center" />
               </asp:BoundField>
                </Columns>
        </asp:GridView>
        <asp:Button ID="btnReturn" runat="server" Text="Return to main menu" BackColor="#C7D7E6" OnClick="btnReturn_Click" />
        <asp:Button ID="btnPrint" runat="server" Text="Print" BackColor="#C7D7E6" OnClientClick="javascript:PrintPage();" />
        
    </div>
    </form>
</body>
</html>
