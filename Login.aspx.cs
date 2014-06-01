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
       string connectionstring = @"Data Source=(LocalDB)\v11.0;" +
            @"AttachDbFilename=|DataDirectory|\OnlineTraining.mdf;
                Integrated Security=True;
                Connect Timeout=30;";
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
                    Response.Redirect("StudentMenu.aspx");
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
