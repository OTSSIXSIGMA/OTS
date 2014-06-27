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
                    Session["Options"] = GetOptions();
                    Session["Questions"] = GetQuestions();
                    Session["Descriptions"] = GetDescriptions();
                    Session["Overviews"] = GetOverview();
                    Session["ResultList"] = null;
                    Session["CurrentOverviewID"] = 0;
                    CheckOpenSession();
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
    protected List<Question> GetQuestions()
    {
        #region Declaration
        SqlDataReader reader;
        SqlConnection connection;
        SqlCommand cmd;
        string connectionstring;
        List<Question> Questions;
        Question tmpQuestion;
        #endregion

        connectionstring = "Server=55eb3ba5-c93f-4d5d-a746-a33d0187f51c.sqlserver.sequelizer.com;Database=db55eb3ba5c93f4d5da746a33d0187f51c;User ID=decjkfdwyfdldmsg;Password=joja5KVaS7pvgVztqJtWcVkv2Y2YyYpuUbbExi4FxeLA6UVjVXkFi5mvdVgfR5H2;";
        connection = new SqlConnection(connectionstring);
        cmd = new SqlCommand("que_GetQuestions", connection);
        cmd.CommandType = CommandType.StoredProcedure;

        connection.Open();
        reader = cmd.ExecuteReader();
        Questions = new List<Question>();
        int DisplayID = 1;
        while (reader.Read())
        {
            List<Option> optDisplay = ((List<Option>)Session["Options"]).FindAll(que => que.QuestionID == Convert.ToInt16(reader.GetValue(0)));
            optDisplay.ElementAt(0).DisplayID = "a";
            optDisplay.ElementAt(1).DisplayID = "b";
            optDisplay.ElementAt(2).DisplayID = "c";
            optDisplay.ElementAt(3).DisplayID = "d";
            tmpQuestion = new Question(Convert.ToInt16(reader.GetValue(0)), DisplayID, reader.GetValue(1).ToString(), Convert.ToInt16(reader.GetValue(2)), (!string.IsNullOrEmpty(reader.GetValue(3).ToString())? (int?)Convert.ToInt32(reader.GetValue(3)) : null),((List<Option>)Session["Options"]).FindAll(que => que.QuestionID == Convert.ToInt16(reader.GetValue(0))));
            Questions.Add(tmpQuestion);
            DisplayID++;
        }
        reader.Close();
        connection.Close();
        return Questions;
    }
    protected List<Option> GetOptions()
    {
        #region Declaration
        SqlDataReader reader;
        SqlConnection connection;
        SqlCommand cmd;
        string connectionstring;
        List<Option> Options;
        Option tmpOption;
        #endregion

        connectionstring = "Server=55eb3ba5-c93f-4d5d-a746-a33d0187f51c.sqlserver.sequelizer.com;Database=db55eb3ba5c93f4d5da746a33d0187f51c;User ID=decjkfdwyfdldmsg;Password=joja5KVaS7pvgVztqJtWcVkv2Y2YyYpuUbbExi4FxeLA6UVjVXkFi5mvdVgfR5H2;";
        connection = new SqlConnection(connectionstring);
        cmd = new SqlCommand("opt_GetOptions", connection);
        cmd.CommandType = CommandType.StoredProcedure;

        connection.Open();
        reader = cmd.ExecuteReader();
        Options = new List<Option>();
        while (reader.Read())
        {
            tmpOption = new Option(Convert.ToInt16(reader.GetValue(0)), Convert.ToInt16(reader.GetValue(1)), reader.GetValue(2).ToString(),  Convert.ToBoolean(reader.GetValue(3)));
            Options.Add(tmpOption);
        }
        reader.Close();
        connection.Close();
        return Options;
    }
    protected Hashtable GetDescriptions()
    {
        #region Declaration
        SqlDataReader reader;
        SqlConnection connection;
        SqlCommand cmd;
        string connectionstring;
        Hashtable Descriptions;
        #endregion
        Descriptions = new Hashtable();
        connectionstring = "Server=55eb3ba5-c93f-4d5d-a746-a33d0187f51c.sqlserver.sequelizer.com;Database=db55eb3ba5c93f4d5da746a33d0187f51c;User ID=decjkfdwyfdldmsg;Password=joja5KVaS7pvgVztqJtWcVkv2Y2YyYpuUbbExi4FxeLA6UVjVXkFi5mvdVgfR5H2;";
        connection = new SqlConnection(connectionstring);
        cmd = new SqlCommand("des_GetDescriptions", connection);
        cmd.CommandType = CommandType.StoredProcedure;

        connection.Open();
        reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            Descriptions.Add(reader.GetValue(0),reader.GetValue(1));
        }
        reader.Close();
        connection.Close();
        return Descriptions;
    }
    protected List<Overview> GetOverview()
    {
        #region Declaration
        SqlDataReader reader;
        SqlConnection connection;
        SqlCommand cmd;
        string connectionstring;
        List<Overview> Overviews;
        Overview tmpOverview;
        #endregion

        connectionstring = "Server=55eb3ba5-c93f-4d5d-a746-a33d0187f51c.sqlserver.sequelizer.com;Database=db55eb3ba5c93f4d5da746a33d0187f51c;User ID=decjkfdwyfdldmsg;Password=joja5KVaS7pvgVztqJtWcVkv2Y2YyYpuUbbExi4FxeLA6UVjVXkFi5mvdVgfR5H2;";
        connection = new SqlConnection(connectionstring);
        cmd = new SqlCommand("ovr_GetOverviews", connection);
        cmd.CommandType = CommandType.StoredProcedure;

        connection.Open();
        reader = cmd.ExecuteReader();
        Overviews = new List<Overview>();
        while (reader.Read())
        {
            tmpOverview = new Overview(Convert.ToInt16(Convert.ToInt16( reader.GetValue(0))), reader.GetValue(2).ToString(), reader.GetValue(1).ToString());
            Overviews.Add(tmpOverview);
        }
        reader.Close();
        connection.Close();
        return Overviews;
    }
    protected void CheckOpenSession()
    {
        #region Declaration
        SqlDataReader reader;
        SqlConnection connection;
        SqlCommand cmd;
        string connectionstring;
        #endregion

        connectionstring = "Server=55eb3ba5-c93f-4d5d-a746-a33d0187f51c.sqlserver.sequelizer.com;Database=db55eb3ba5c93f4d5da746a33d0187f51c;User ID=decjkfdwyfdldmsg;Password=joja5KVaS7pvgVztqJtWcVkv2Y2YyYpuUbbExi4FxeLA6UVjVXkFi5mvdVgfR5H2;";
        connection = new SqlConnection(connectionstring);
        cmd = new SqlCommand("uam_CheckOpenSession", connection);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@UserID", Convert.ToInt16(Session["UserID"]));

        connection.Open();
        reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            ((List<Question>)Session["Questions"]).Find(q => q.ID == Convert.ToInt16(reader["uam_que_ID"])).SelectedList = reader["uam_SelectedList"].ToString();
            Session["SessionID"] = reader["uam_SessionID"];
        }
        reader.Close();
        connection.Close();

    }
}