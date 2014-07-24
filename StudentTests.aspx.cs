using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Web.Security;

public partial class StudentTestsaspx : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = "Server=55eb3ba5-c93f-4d5d-a746-a33d0187f51c.sqlserver.sequelizer.com;Database=db55eb3ba5c93f4d5da746a33d0187f51c;User ID=decjkfdwyfdldmsg;Password=joja5KVaS7pvgVztqJtWcVkv2Y2YyYpuUbbExi4FxeLA6UVjVXkFi5mvdVgfR5H2;";
            SqlCommand command = new SqlCommand("exec tst_GetTests");

            connection.Open();
            command.Connection = connection;
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            grdTests.DataSource = reader;
            grdTests.DataBind();
        }
    }


    protected void grdTests_RowEditing(object sender, GridViewEditEventArgs e)
    {
        string TestID = grdTests.DataKeys[e.NewEditIndex].Value.ToString();
        Response.Redirect("StudentMenu.aspx?TestID=" + TestID);
    }


protected void btnSignout_Click(object sender, EventArgs e)
{
    Session.Abandon();
    FormsAuthentication.SignOut();
    Response.Redirect("Login.aspx");
}
}