using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class AdminQuestions : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = "Server=55eb3ba5-c93f-4d5d-a746-a33d0187f51c.sqlserver.sequelizer.com;Database=db55eb3ba5c93f4d5da746a33d0187f51c;User ID=decjkfdwyfdldmsg;Password=joja5KVaS7pvgVztqJtWcVkv2Y2YyYpuUbbExi4FxeLA6UVjVXkFi5mvdVgfR5H2;";
            SqlCommand command = new SqlCommand("exec que_GetQuestionsByTest "+ Convert.ToInt16( Request.QueryString["ID"]));

            connection.Open();
            command.Connection = connection;
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            grdQuestions.DataSource = reader;
            grdQuestions.DataBind();
        }

    }
    protected void grdQuestions_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }
    protected void grdQuestions_RowEditing(object sender, GridViewEditEventArgs e)
    {
        string ID = grdQuestions.DataKeys[e.NewEditIndex].Value.ToString();
        Response.Redirect("UpdateQuestion.aspx?ID=" + ID);
    }
}