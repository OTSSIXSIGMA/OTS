<%@ Page Language="C#" AutoEventWireup="true" CodeFile="StudentTests.aspx.cs" Inherits="StudentTestsaspx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Student Test Menu</title>
</head>
<style type="text/css">
           
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
            #p{
            top: 35%;
            left: 30%;
            margin-top: 180px;
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
            #heading 
            {
            position: absolute;
            align-content:center;
            top: 40%;
            left: 30%;
            margin-top: -50px;
            margin-left: -25px;
            font-size : 16px;
            font-family : Calibri;
            color :  #0000CD;
            }
</style>
<body style="width:auto">
   <form id="form1" runat="server" >
   <div id="banner">
               <img src="Resources/images/loginbackground.png"  style="width:100%;height:90%;align-items:center" alt="Welcome to Six Sigma Online Training System"/>
             </div>
        <p id="logout"><asp:Button ID="btnSignout" runat="server" Text="Sign Out" BackColor="#C7D7E6" OnClick="btnSignout_Click" style="height:50px; width:70px;font-weight:bold;font-family:Calibri;font-size:16px;" /></p> 

  <table>
      <p id="heading">Welcome! Please select a Test to proceed...!</p>
      <td>
      </td>
  <td>
    <div id="divCenter" style="height:350px; width:auto; border:solid; border-color:#21448B; overflow:scroll">
        <asp:GridView ID="grdTests" runat="server" DataKeyNames="tst_ID" AutoGenerateColumns="false" OnRowEditing="grdTests_RowEditing" BorderWidth="1px" BackColor="#E2EBF2"
            CellPadding="8" CellSpacing="3" BorderStyle="Double" BorderColor="#301793" SkinID="Professional" Font-Name="Calibri"
            Font-Size="14pt"
            HeaderStyle-BackColor="#444444"
            HeaderStyle-ForeColor="White"
            AlternatingRowStyle-BackColor="#dddddd" Width="400" Height="350">
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
