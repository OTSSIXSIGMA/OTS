<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TestQuestion.aspx.cs" Inherits="TestQuestion" ValidateRequest="false"  %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Test Question</title>
<script src="http://www.google.com/jsapi" type="text/javascript"></script>

    <style type="text/css">
        body {
            background-image:url('Resources/images/loginbackground.png');
            background-repeat:no-repeat;
            background-attachment:fixed;
            }

#divCenter {
    position: absolute;
    top: 40%;
    left: 22%;
    margin-top: -50px;
    margin-left: -50px;
    font-size : 16px;
    font-family : Calibri;
    color :  #0000CD;
    }
p.big {line-height:200%;}
p.small {line-height:150%;}
   table.mylist input {
      width: 20px;
      display: block;
      float: left;
   }
   table.mylist label {
      width: 90%;
      display: block;
      float: left;
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
        <p class="big">
        <asp:Label ID="lblPreface" runat="server"></asp:Label>
        <b>
        <asp:Label ID="lblQuestion" runat="server"></asp:Label>
            </b>
        </p>
        <p class="small">   
        <asp:UpdatePanel ID="uppOptions" runat="server" UpdateMode="Always"> 
            <ContentTemplate>
        <asp:Panel ID="pnlRadioBtn" runat="server">
                <asp:RadioButtonList ID="rblOptions" runat="server" CssClass="mylist" RepeatColumns="1" RepeatDirection="Vertical" ValidationGroup="options" Width="90%" OnSelectedIndexChanged="rblOptions_SelectedIndexChanged"  AutoPostBack="true"></asp:RadioButtonList>      
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
            </p>
        <asp:Button ID ="btnPrevious" runat ="server" Text="Previous" OnClick="btnPrevious_Click"/>
        <asp:Button ID="btnSubmit" runat="server" Text="Next" OnClick="btnSubmit_Click" ValidationGroup="options"  CausesValidation="true" />
        <asp:Button ID="btnMenu" runat="server" Text="Return to main menu" OnClick="btnMenu_Click" />
        <br />
        <asp:Label ID="lblError" runat="server" Text=""></asp:Label>

    </div>
    </form>
</body>
</html>
