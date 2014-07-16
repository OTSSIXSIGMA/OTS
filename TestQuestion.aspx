<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TestQuestion.aspx.cs" Inherits="TestQuestion" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Test Question</title>
<script src="http://www.google.com/jsapi" type="text/javascript"></script>

    <style type="text/css">
#divCenter {
    position: absolute;
    top: 45%;
    left: 40%;
    margin-top: -50px;
    margin-left: -50px;
    width: 1000px;
    height: 1000px;
}


</style>

    <script type="text/javascript" src="Resources/js/jquery-1.7.2.min.js"></script>
    <script type="text/javascript" src="Resources/js/Shadowbox/shadowbox.js"></script>
    <link rel="stylesheet" type="text/css" href="Resources/css/Shadowbox.css"/>
    <script type="text/javascript">
        Shadowbox.init();
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:scriptmanager ID="Scriptmanager1" runat="server"></asp:scriptmanager>
    <div id="divCenter">

        <asp:HiddenField ID="hddQuestionID" runat="server" />
        <asp:Label ID="lblQuestion" runat="server"></asp:Label>
        <asp:UpdatePanel ID="uppOptions" runat="server" UpdateMode="Always"> 
            <ContentTemplate>
        <asp:Panel ID="pnlRadioBtn" runat="server">
                <asp:RadioButtonList ID="rblOptions" runat="server" RepeatColumns="1" RepeatDirection="Vertical" ValidationGroup="options" Width="90%" OnSelectedIndexChanged="rblOptions_SelectedIndexChanged"  AutoPostBack="true"></asp:RadioButtonList>      
            <asp:RequiredFieldValidator   
            ID="RqdOptions"  
            runat="server"  
            ControlToValidate="rblOptions"  
            ErrorMessage="Select an option"  
            ValidationGroup="options"
            >  
        </asp:RequiredFieldValidator>  
        </asp:Panel>            
        </ContentTemplate>
        </asp:UpdatePanel>
        <asp:Button ID ="btnPrevious" runat ="server" Text="Previous" OnClick="btnPrevious_Click"/>
        <asp:Button ID="btnSubmit" runat="server" Text="Next" OnClick="btnSubmit_Click" ValidationGroup="options"  CausesValidation="true" />
        <asp:Button ID="btnMenu" runat="server" Text="Return to main menu" OnClick="btnMenu_Click" />
        <br />
        <asp:Label ID="lblError" runat="server" Text=""></asp:Label>

    </div>
    </form>
</body>
</html>
