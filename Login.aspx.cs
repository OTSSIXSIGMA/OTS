using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.IO;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.CodeDom.Compiler;
using OnlineTrainingBL;
using System.Collections;

public partial class Login : System.Web.UI.Page
{
    public string username;
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Logon_Click(object sender, EventArgs e)
    {   //to check for authentication

        #region connection
        SqlDataReader reader;
        string connectionstring = "Server=55eb3ba5-c93f-4d5d-a746-a33d0187f51c.sqlserver.sequelizer.com;Database=db55eb3ba5c93f4d5da746a33d0187f51c;User ID=decjkfdwyfdldmsg;Password=joja5KVaS7pvgVztqJtWcVkv2Y2YyYpuUbbExi4FxeLA6UVjVXkFi5mvdVgfR5H2;";
        SqlConnection connection = new SqlConnection(connectionstring);
        #endregion


        SqlCommand cmd2 = new SqlCommand("usr_login", connection);
        cmd2.CommandType = CommandType.StoredProcedure;
        cmd2.Parameters.Add("@User", SqlDbType.VarChar);
        cmd2.Parameters["@User"].Value = UserEmail.Text;
        cmd2.Parameters.Add("@Password", SqlDbType.VarChar);
        cmd2.Parameters["@Password"].Value = UserPass.Text;

        connection.Open();

        reader = cmd2.ExecuteReader();
        if (reader.FieldCount != 0)
        {
            FormsAuthentication.RedirectFromLoginPage
                      (UserEmail.Text, Persist.Checked);
            while (reader.Read())
            {
                if(((IDataReader)reader)["usr_ID"] != null)
                {
                    Session["UserID"] = Convert.ToInt16(((IDataReader)reader)["usr_ID"]);
                }
                if (Convert.ToBoolean(((IDataReader)reader)["usr_isAdmin"]) == true)
                {
                    Response.Redirect("AdminMenu.aspx");
                }
                else 
                {   
                    Response.Redirect("StudentTests.aspx");
                }
            }
        }
        else
        {
            Msg.Text = "Invalid credentials. Please try again.";
        }
        reader.Close();
        connection.Close();
    }

}