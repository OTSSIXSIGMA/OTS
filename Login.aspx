<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml"/>
   <html>
      <head id="Head1" runat="server">
         <title>Login Page</title>
         <style type="text/css">
            body {
            background-image:url('Resources/images/loginbackground.png');
            background-repeat:no-repeat;
            background-attachment:fixed;
            }
            #divCenter 
            {
            position: absolute;
            top: 50%;
            left: 32%;
            margin-top: -250px;
            margin-left: -50px;
            width: 500px;
            height: 500px;
            font-size : 16px;
            font-family : Calibri;
            color :  #0000CD;
            }
            table
            {
            border-collapse:separate;
            border-spacing:2 5px;
            }
         </style>
      </head>
      <body>
         <form id="form1" runat="server">
            <!-- <img src="Resources/images/logo.png" alt="Welcome to Six Sigma Online Training System" align="center" width="1335" height="125">-->
            <div id="divCenter">
               <table border="0" width="100%" cellspacing="1" height="100%" id="table1">
                  <tr>
                     <td align="center" >
                        <table border="0" width="500" id="table2">
                           <tr>
                              <td width="211">
                                 <img border="0" src="Resources/images/studenttakingexam.jpg" width="144" height="183">
                              </td>
                              <td width="211">
                                 <table border="0" width="100%" id="table3" style="border: 1px solid #251272">
                                    <tr>
                                       <td>
                                          <table border="0" width="100%" id="table4" cellpadding="2">
                                             <tr>
                                                <td align="left" valign="bottom">
                                                   Username
                                                </td>
                                                <td align="left" valign="bottom">
                                                   <asp:TextBox ID="UserEmail" runat="server" type="text" />
                                                </td>
                                                <td>
                                                   <asp:RequiredFieldValidator ID="RequiredFieldValidator1" 
                                                      ControlToValidate="UserEmail"
                                                      Display="Dynamic" 
                                                      ErrorMessage="Cannot be EMPTY." 
                                                      runat="server" />
                                                </td>
                                             </tr>
                                            
                                             <tr>
                                                <td align="left" valign="top">
                                                   Password
                                                </td>
                                                <td align="left" valign="top">
                                                   <asp:TextBox ID="UserPass" TextMode="Password" runat="server" />
                                                </td>
                                                <td>
                                                   <asp:RequiredFieldValidator ID="RequiredFieldValidator2" 
                                                      ControlToValidate="UserPass"
                                                      ErrorMessage="Cannot be EMPTY." runat="server" />
                                                </td>
                                             </tr>
                                             
                                          </table>
                                          <asp:Button ID="Submit1" OnClick="Logon_Click" Text="Log In" BackColor="#C7D7E6" runat="server" />
                                          <p>
                                             <asp:Label ID="Msg" ForeColor="red" runat="server" />
                                          </p>
                                       </td>
                                    </tr>
                                 </table>
                              </td>
                           </tr>
                        </table>
                      </td>
                  </tr>
               </table>
            </div>
         </form>
      </body>
   </html>
