using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OnlineTrainingBL;
public partial class Description : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        lblDescription.Text = ((Question)Session["Question"]).OptionList.Find(q=>q.ID==Convert.ToInt16(Request.QueryString["id"])).Description;

    }
    protected void btnReturn_Click(object sender, EventArgs e)
    {
        Response.Redirect("TestQuestion.aspx");
    }
}