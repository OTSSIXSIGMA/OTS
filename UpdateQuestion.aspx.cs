using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class UpdateQuestion : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        #region Declaration
        SqlDataReader reader;
        SqlConnection connection;
        SqlCommand cmd;
        string connectionstring;
        #endregion

        connectionstring = "Server=55eb3ba5-c93f-4d5d-a746-a33d0187f51c.sqlserver.sequelizer.com;Database=db55eb3ba5c93f4d5da746a33d0187f51c;User ID=decjkfdwyfdldmsg;Password=joja5KVaS7pvgVztqJtWcVkv2Y2YyYpuUbbExi4FxeLA6UVjVXkFi5mvdVgfR5H2;";
        connection = new SqlConnection(connectionstring);
        cmd = new SqlCommand("que_GetQuestionByID", connection);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@ID", Convert.ToInt16(Request.QueryString["ID"]));

        connection.Open();
        reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            txtQuestion.Text = reader["que_Value"].ToString();
        }
        reader.Close();
        connection.Close();

        connection = new SqlConnection(connectionstring);
        cmd = new SqlCommand("opt_GetByQuestion", connection);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@ID", Convert.ToInt16(Request.QueryString["ID"]));

        connection.Open();
        reader = cmd.ExecuteReader();

        List<string> values = new List<string>();
        while (reader.Read())
        {
            values.Add(reader["opt_Value"].ToString());
        }
        txtOption1.Text = values.ElementAt(0);
        txtOption2.Text = values.ElementAt(1);
        txtOption3.Text = values.ElementAt(2);
        txtOption4.Text = values.ElementAt(3);

        reader.Close();
        connection.Close();
    }
    protected void btnUodate_Click(object sender, EventArgs e)
    {
        //#region connection
        //string connectionstring = "Server=55eb3ba5-c93f-4d5d-a746-a33d0187f51c.sqlserver.sequelizer.com;Database=db55eb3ba5c93f4d5da746a33d0187f51c;User ID=decjkfdwyfdldmsg;Password=joja5KVaS7pvgVztqJtWcVkv2Y2YyYpuUbbExi4FxeLA6UVjVXkFi5mvdVgfR5H2;";
        //SqlConnection connection = new SqlConnection(connectionstring);
        //#endregion


        //SqlCommand cmd = new SqlCommand("que_UpdateQuestion", connection);
        //cmd.CommandType = CommandType.StoredProcedure;
        //cmd.Parameters.AddWithValue("@ID", );
        //cmd.Parameters.AddWithValue("@Question", txtQuestion.Text);
        //cmd.Parameters.AddWithValue("@Option1", txtOption1.Text);
        //cmd.Parameters.AddWithValue("@Option2", txtOption2.Text);
        //cmd.Parameters.AddWithValue("@Option3", txtOption3.Text);
        //cmd.Parameters.AddWithValue("@Option4", txtOption4.Text);
        //foreach (SqlParameter parameter in cmd.Parameters)
        //{
        //    if (parameter.Value == null)
        //        parameter.Value = DBNull.Value;
        //}
        //connection.Open();
        //cmd.ExecuteNonQuery();
        //connection.Close();
    }
    
    protected void btnMenu_Click(object sender, EventArgs e)
    {
        Response.Redirect("AdminMenu.aspx");
    }
}
