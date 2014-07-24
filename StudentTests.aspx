<%@ Page Language="C#" AutoEventWireup="true" CodeFile="StudentTests.aspx.cs" Inherits="StudentTestsaspx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Student Test Menu</title>
</head>
<body>
   <form id="form1" runat="server">
    <div>
            <asp:GridView ID="grdTests" runat="server" DataKeyNames="tst_ID" AutoGenerateColumns="false" OnRowEditing="grdTests_RowEditing">
            <Columns>   
               <asp:BoundField DataField="tst_Title" HeaderText="Test Name">
               <ItemStyle HorizontalAlign="Center" />
               </asp:BoundField>
             <asp:BoundField DataField="tst_Description" HeaderText="Description">
               <ItemStyle HorizontalAlign="Center" />
               </asp:BoundField>
             
                          <asp:TemplateField HeaderText="Chose">
                            <ItemTemplate>
                            <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="Start" />
                             </ItemTemplate>
                             </asp:TemplateField>
                </Columns>
        </asp:GridView>
        <asp:Button ID="btnSignout" runat="server" Text="Signout" OnClick="btnSignout_Click"/>
    </div>
    </form>
</body>
</html>
