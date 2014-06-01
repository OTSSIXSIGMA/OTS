using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminMenu : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnUsers_Click(object sender, EventArgs e)
    {
        Response.Redirect("AdminUsers.aspx");
    }
    protected void btnQuestions_Click(object sender, EventArgs e)
    {
        Response.Redirect("AdminQuestions.aspx");
    }
}