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
        Session["SessionID"] = Guid.NewGuid().ToString();
        if (Session["Questions"] != null)
        {
            foreach (Question question in (List<Question>)(Session["Questions"]))
            {
                question.SelectedList = null;
            }
        }
        Session["Options"] = GetOptions();
        Session["Questions"] = GetQuestions();
        Session["ResultList"] = null;
        CheckOpenSession();

        Response.Redirect("TestQuestion.aspx");

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
        while (reader.Read())
        {
            tmpQuestion = new Question(Convert.ToInt16(reader.GetValue(0)), reader.GetValue(1).ToString(), ((List<Option>)Session["Options"]).FindAll(que => que.QuestionID == Convert.ToInt16(reader.GetValue(0))));
            Questions.Add(tmpQuestion);
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
            tmpOption = new Option(Convert.ToInt16(reader.GetValue(0)), Convert.ToInt16(reader.GetValue(1)), reader.GetValue(2).ToString(), reader.GetValue(3).ToString(), Convert.ToBoolean(reader.GetValue(4)));
            Options.Add(tmpOption);
        }
        reader.Close();
        connection.Close();
        return Options;
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
    protected void btnSignout_Click(object sender, EventArgs e)
    {
        Session.Abandon();
        FormsAuthentication.SignOut();
        Response.Redirect("Logon.aspx");

    }
    protected void btnContinue_Click(object sender, EventArgs e)
    {
        Response.Redirect("TestQuestion.aspx");
    }
}
