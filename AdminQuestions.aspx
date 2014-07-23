<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AdminQuestions.aspx.cs" Inherits="AdminQuestions" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Questions</title>
    <style type="text/css">
#divCenter {
	position: absolute;
    top: 20%;
    left: 20%;
    margin-top: -50px;
    margin-left: -50px;
    width: 1000px;
    height: 1000px;
}
</style>
</head>
<body>
    <form id="form1" runat="server">
    <div id="divCenter">
         <asp:GridView ID="grdQuestions" runat="server" DataKeyNames="que_ID" AutoGenerateColumns="false" OnRowDeleting="grdQuestions_RowDeleting" OnRowEditing="grdQuestions_RowEditing">
            <Columns>   
               <asp:BoundField DataField="que_ID" HeaderText="Question ID" >
               <ItemStyle HorizontalAlign="Center" />
               </asp:BoundField>
             <asp:BoundField DataField="que_Value" HeaderText="Description">
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
