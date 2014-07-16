<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AdminTest.aspx.cs" Inherits="AdminTest" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Admin Test</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
            <asp:GridView ID="grdTests" runat="server" DataKeyNames="tst_ID" AutoGenerateColumns="false" OnRowDeleting="grdTests_RowDeleting" OnRowEditing="grdTests_RowEditing">
            <Columns>   
               <asp:BoundField DataField="tst_Title" HeaderText="Test Name">
               <ItemStyle HorizontalAlign="Center" />
               </asp:BoundField>
             <asp:BoundField DataField="tst_Description" HeaderText="Description">
               <ItemStyle HorizontalAlign="Center" />
               </asp:BoundField>
             
                          <asp:TemplateField HeaderText="Edit">
                            <ItemTemplate>
                            <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="Edit" />
                             </ItemTemplate>
                             </asp:TemplateField>

                           <asp:TemplateField HeaderText="Delete">
                            <ItemTemplate>
                            <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="Delete"/>
                             </ItemTemplate>
                             </asp:TemplateField>
                </Columns>
        </asp:GridView>
    </div>
    </form>
</body>
</html>
