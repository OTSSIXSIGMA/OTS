using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OnlineTrainingBL;
using System.Data.SqlClient;
using System.Data;
using System.Web.Security;
public partial class Menu : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["SessionID"] != null)
        {
            btnContinue.Visible = true;
        }
    }
    protected void btnStartTest_Click(object sender, EventArgs e)
    {
        Response.Redirect("TestQuestion.aspx");
    }
    protected void btnSignout_Click(object sender, EventArgs e)
    {
        Session.Abandon();
        FormsAuthentication.SignOut();
        Response.Redirect("Login.aspx");

    }
    protected void btnContinue_Click(object sender, EventArgs e)
    {
        Response.Redirect("TestQuestion.aspx");
    }
}