<%@ Page Language="C#" AutoEventWireup="true" CodeFile="StudentTests.aspx.cs" Inherits="StudentTestsaspx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Student Test Menu</title>
</head>
<style type="text/css">
            body {
            background-image:url('Resources/images/loginbackground.png');
            background-repeat:no-repeat;
            background-attachment:fixed;
            }
            #logout{
             top: 35%;
            left: 50%;
            margin-top: 160px;
            margin-left: 1200px;
            font-size : 18px;
            font-family : Calibri;
            align-content:center;
            font-weight: bold;
            color:#193168;
            }
            #p{
            top: 35%;
            left: 30%;
            margin-top: 150px;
            margin-left: 375px;
            font-size : 18px;
            font-family : Calibri;
            align-content:center;
            font-weight: bold;
            color:#193168;
            }
            #divCenter 
            {
            position: absolute;
            align-content:center;
            top: 45%;
            left: 30%;
            margin-top: -50px;
            margin-left: -25px;
            font-size : 16px;
            font-family : Calibri;
            color :  #0000CD;
            }
</style>
<body>
   <form id="form1" runat="server">
        <p id="logout"><asp:Button ID="btnSignout" runat="server" Text="Signout" BackColor="WhiteSmoke" OnClick="btnSignout_Click" style="height:50px; width:70px;color:#6971f8;font-weight:bold"/></p> 
        <p id="p"> Welcome! Please select a Test to proceed...</p>
  <table>
      <td>
      </td>
  <td>
    <div id="divCenter" style="height:400px; width:400px; border:solid; border-color:#21448B; overflow:scroll">
        <asp:GridView ID="grdTests" runat="server" DataKeyNames="tst_ID" AutoGenerateColumns="false" OnRowEditing="grdTests_RowEditing" BorderWidth="1px" BackColor="#E2EBF2"
            CellPadding="8" CellSpacing="3" BorderStyle="Double" BorderColor="#301793" SkinID="Professional" Font-Name="Calibri"
            Font-Size="14pt"
            HeaderStyle-BackColor="#444444"
            HeaderStyle-ForeColor="White"
            AlternatingRowStyle-BackColor="#dddddd" Width="400" Height="400">
            <FooterStyle ForeColor="#8C4510"
                BackColor="#F7DFB5"></FooterStyle>
            <PagerStyle ForeColor="#8C4510"
                HorizontalAlign="Center"></PagerStyle>
            <HeaderStyle ForeColor="White" Font-Bold="True" BackColor="#0000CD"></HeaderStyle>
            <Columns>
                <asp:BoundField DataField="tst_Title" HeaderText="Test Name">
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="tst_Description" HeaderText="Description">
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>

                <asp:TemplateField HeaderText="Chose" FooterStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="Proceed" Width="100" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
         
    </div>
      </td>
      </table>
    </form>
</body>
</html>
