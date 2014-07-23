using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.Security;

public partial class AdminMenu : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
     
    }
    protected void btnUsers_Click(object sender, EventArgs e)
    {
        Response.Redirect("AdminUsers.aspx");
    }

    protected void btnTests_Click(object sender, EventArgs e)
    {
        Response.Redirect("AdminTest.aspx");
    }
    
    protected void btnSignout_Click(object sender, EventArgs e)
    {
        Session.Abandon();
        FormsAuthentication.SignOut();
        Response.Redirect("Login.aspx");

    }
}
