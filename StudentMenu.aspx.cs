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
using System.Collections;
public partial class Menu : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            Session["Question"] = null;
            Session["SessionID"] = null;
            Session["Options"] = GetOptions();
            Session["Questions"] = GetQuestions();
            Session["Descriptions"] = GetDescriptions();
            GetOverviews();
            Session["ResultList"] = null;
            CheckOpenSession();
            if (Session["SessionID"] != null)
            {
                btnContinue.Visible = true;
            }
        }
    }
    protected void btnStartTest_Click(object sender, EventArgs e)
    {
        Session["SessionID"] = Guid.NewGuid().ToString();
        foreach(Question question in ((List<Question>)(Session["Questions"])))
        {
            question.SelectedList=null;
        }
        Response.Redirect("TestQuestion.aspx");
    }
    protected void btnSignout_Click(object sender, EventArgs e)
    {
        Session.Abandon();
        FormsAuthentication.SignOut();
        Response.Redirect("Login.aspx");

    }
    protected void btnContinue_Click(object sender, EventArgs e)
    {
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
        cmd = new SqlCommand("que_GetQuestionsByTest", connection);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@TestID", SqlDbType.VarChar);
        cmd.Parameters["@TestID"].Value = Convert.ToInt16( Request.QueryString["TestID"]);

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
            tmpQuestion = new Question(Convert.ToInt16(reader.GetValue(0)), DisplayID, reader.GetValue(1).ToString(), reader.GetValue(2).ToString(),Convert.ToInt16(reader.GetValue(3)), (!string.IsNullOrEmpty(reader.GetValue(4).ToString()) ? (int?)Convert.ToInt32(reader.GetValue(4)) : null), ((List<Option>)Session["Options"]).FindAll(que => que.QuestionID == Convert.ToInt16(reader.GetValue(0))));
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
        cmd = new SqlCommand("opt_GetOptionsByTest", connection);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@TestID", Convert.ToInt16(Request.QueryString["TestID"]));

        connection.Open();
        reader = cmd.ExecuteReader();
        Options = new List<Option>();
        while (reader.Read())
        {
            tmpOption = new Option(Convert.ToInt16(reader.GetValue(0)), Convert.ToInt16(reader.GetValue(1)), reader.GetValue(2).ToString(), Convert.ToBoolean(reader.GetValue(3)));
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
        cmd.Parameters.AddWithValue("@TestID", Convert.ToInt16(Request.QueryString["TestID"]));

        connection.Open();
        reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            Descriptions.Add(reader.GetValue(0), reader.GetValue(1));
        }
        reader.Close();
        connection.Close();
        return Descriptions;
    }
    protected void GetOverviews()
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
            tmpOverview = new Overview(Convert.ToInt16(Convert.ToInt16(reader.GetValue(0))), reader.GetValue(2).ToString(), reader.GetValue(1).ToString());
            Overviews.Add(tmpOverview);
        }
        reader.Close();
        connection.Close();
        int overviewID = 0;
        List<Question> questions = new List<Question>();
        questions = ((List<Question>)Session["Questions"]).ToList();
        foreach (Question question in questions)
        {
            if (!string.IsNullOrEmpty(question.OverviewID.ToString()) && (question.OverviewID != overviewID))
            {
                overviewID = (int)question.OverviewID;
                Question tmpQuestion = new Question(Overviews.Find(x => x.ID == question.OverviewID));
                ((List<Question>)Session["Questions"]).Insert(((List<Question>)Session["Questions"]).IndexOf(question), tmpQuestion);
            }
        }

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
        cmd.Parameters.AddWithValue("@TestID", Convert.ToInt16( Request.QueryString["TestID"]));
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
    protected void btnReturn_Click(object sender, EventArgs e)
    {
        Response.Redirect("StudentTests.aspx");
    }
}