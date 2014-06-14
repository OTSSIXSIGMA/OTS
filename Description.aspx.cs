using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OnlineTrainingBL;
using System.Collections;

public partial class Description : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       if(((Hashtable)(Session["Descriptions"])).ContainsKey(Context.Request.QueryString["name"]))
       {
           lblDescription.Text = ((Hashtable)(Session["Descriptions"]))[Context.Request.QueryString["name"]].ToString();
       }
    }
    protected void btnReturn_Click(object sender, EventArgs e)
    {
        Response.Redirect("TestQuestion.aspx");
    }
}