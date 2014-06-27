using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OnlineTrainingBL;
using System.Data.SqlClient;
using System.Data;
using System.Text.RegularExpressions;

public partial class TestQuestion : System.Web.UI.Page
{
    int index=0;
    int QuestionID;
    Question question;
    
    protected void Page_Load(object sender, EventArgs e)
    {
         if (!Page.IsPostBack)
        {
            if (((Question)Session["Question"]) != null)
            {
                index = ((List<Question>)Session["Questions"]).FindIndex(q => q.ID == Convert.ToInt16(((Question)Session["Question"]).ID));
            }
            else
            { index = -1; }
            question = ((List<Question>)Session["Questions"]).ElementAt(index + 1);
            if (question.OverviewID != null && question.OverviewID != Convert.ToInt16(Session["CurrentOverviewID"]))
            {
                lblQuestion.Text = ((List<Overview>)Session["Overviews"]).Find(x => x.ID == question.OverviewID).Title+"<br/><br/>"+ ((List<Overview>)Session["Overviews"]).Find(x => x.ID == question.OverviewID).Value;
                Session["CurrentOverviewID"] = question.OverviewID;
                btnOverviewNext.Visible = true;
                btnSubmit.Visible = false;
            }
            else
            {
                btnPrevious.Visible = false;
                if (Request.UrlReferrer != null)
                {
                    if ((Request.UrlReferrer.OriginalString.ToString().ToLower().Contains("review.aspx")))
                    {
                        if (Session["Question"] != null)
                        {
                            QuestionID = ((List<Question>)Session["Questions"]).ElementAt(index + 1).ID;
                        }
                    }
                    else if ((Request.UrlReferrer.OriginalString.ToString().ToLower().Contains("studentmenu.aspx")))
                    {
                        if (((List<Question>)(Session["Questions"])).Exists(q => q.SelectedList != null))
                        {
                            QuestionID = ((List<Question>)(Session["Questions"])).FindLast(q => q.SelectedList != null).ID;
                            lblError.Text = "\n Your previous session has been retrieved. ";
                        }
                        else
                        {
                            QuestionID = ((List<Question>)(Session["Questions"])).ElementAt(0).ID;
                        }
                    }
                    else if ((Request.UrlReferrer.OriginalString.ToString().ToLower().Contains("testquestion.aspx")))
                    {
                        QuestionID = ((List<Question>)Session["Questions"]).ElementAt(index).ID;
                    }
                }
                else
                {
                    QuestionID = ((List<Question>)(Session["Questions"])).ElementAt(0).ID;
                }

                question = ((List<Question>)Session["Questions"]).Find(q => q.ID == QuestionID);
                lblQuestion.Text = question.DisplayID + ". " + question.Value;
                ICollection<string> matches =
                Regex.Matches(question.Value.Replace(Environment.NewLine, ""), @"\[([^]]*)\]")
               .Cast<Match>()
               .Select(x => x.Groups[1].Value)
               .ToList();
                foreach (string match in matches)
                {
                    string wildcard = "[" + match + "]";
                    lblQuestion.Text = lblQuestion.Text.Replace(wildcard, "<a href='Description.aspx?name=" + match + "' rel=shadowbox;height=700;width=700>" + match + "</a>");
                }

                foreach (Option option in question.OptionList)
                {
                    ListItem tmpItem = new ListItem(option.ID.ToString(), option.Value);
                    //tmpItem.Text = "<a href='Description.aspx?id=" +option.ID + "' rel=shadowbox;height=700;width=700>" + tmpItem.Value + "</a>";
                    tmpItem.Text = "(" + option.DisplayID + ") " + option.Value;
                    matches =
                    Regex.Matches(option.Value.Replace(Environment.NewLine, ""), @"\[([^]]*)\]")
                   .Cast<Match>()
                   .Select(x => x.Groups[1].Value)
                   .ToList();
                    foreach (string match in matches)
                    {
                        string wildcard = "[" + match + "]";
                        tmpItem.Text = tmpItem.Text.Replace(wildcard, "<a href='Description.aspx?name=" + match + "' rel=shadowbox;height=700;width=700>" + match + "</a>");
                    }
                    rblOptions.Items.Add(tmpItem);
                }

                if (!string.IsNullOrEmpty(question.SelectedList))
                {
                    List<String> OptionsOrder = new List<String>(question.SelectedList.Split(','));
                    rblOptions.SelectedIndex = rblOptions.Items.IndexOf(rblOptions.Items.FindByValue(question.OptionList.Find(q => q.ID == Convert.ToInt16(OptionsOrder.ElementAt(OptionsOrder.Count - 1))).Value));
                }


                index = ((List<Question>)Session["Questions"]).FindIndex(q => q.ID == Convert.ToInt16(question.ID));
                if (index == ((List<Question>)Session["Questions"]).Count - 1)
                { btnSubmit.Text = "Finish"; }
                else if (index != 0)
                { btnPrevious.Visible = true; }


                hddQuestionID.Value = question.ID.ToString();
                Session["Question"] = question;

                if (((List<Question>)Session["Questions"]).FindIndex(q => q.ID == ((Question)Session["Question"]).ID) == ((List<Question>)Session["Questions"]).Count - 1)
                {
                    Session["SessionID"] = Session["SessionID"] + "CLOSED";
                }

            }
            
        }

    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (rblOptions.Items.Count != 0)
        {
            #region connection
            string connectionstring = "Server=55eb3ba5-c93f-4d5d-a746-a33d0187f51c.sqlserver.sequelizer.com;Database=db55eb3ba5c93f4d5da746a33d0187f51c;User ID=decjkfdwyfdldmsg;Password=joja5KVaS7pvgVztqJtWcVkv2Y2YyYpuUbbExi4FxeLA6UVjVXkFi5mvdVgfR5H2;";
            SqlConnection connection = new SqlConnection(connectionstring);
            #endregion
            SqlCommand cmd = new SqlCommand("uam_InsertData", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@UserID", Convert.ToInt16(Session["UserID"]));
            cmd.Parameters.AddWithValue("@SessionID", Session["SessionID"]);
            cmd.Parameters.AddWithValue("@QuestionID", ((Question)Session["Question"]).ID);
            cmd.Parameters.AddWithValue("@SelectedList", ((Question)Session["Question"]).SelectedList);
            foreach (SqlParameter parameter in cmd.Parameters)
            {
                if (parameter.Value == null)
                    parameter.Value = DBNull.Value;
            }
            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();

            if (!Session["SessionID"].ToString().Contains("CLOSED"))
            {
                Response.Redirect("Review.aspx");
            }
            else
            {
                Response.Redirect("Reporting.aspx");
            }
        }
        else
        { Response.Redirect("TestQuestion.aspx"); }

    }
    protected void rblOptions_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Session["Question"] != null)
        {
            if (string.IsNullOrEmpty( ((Question)Session["Question"]).SelectedList))
            {
                ((Question)Session["Question"]).SelectedList = ((Question)Session["Question"]).SelectedList + ((Question)Session["Question"]).OptionList.Find(q => q.Value == rblOptions.SelectedItem.Value).ID.ToString();
            }
            else
            {
                ((Question)Session["Question"]).SelectedList = ((Question)Session["Question"]).SelectedList + ","+((Question)Session["Question"]).OptionList.Find(q=>q.Value==rblOptions.SelectedItem.Value).ID.ToString();
            }

        }
    }
    protected void btnPrevious_Click(object sender, EventArgs e)
    {
        int index = ((List<Question>)Session["Questions"]).FindIndex(q => q.ID == Convert.ToInt16(((Question)Session["Question"]).ID));
        if (index >= 1)
        {
            QuestionID = ((List<Question>)Session["Questions"]).ElementAt(index - 1).ID;
            question = ((List<Question>)(Session["Questions"])).ElementAt(((List<Question>)(Session["Questions"])).FindIndex(q => q.ID == QuestionID));
            Session["Question"] = question;
            Session["CurrentOverviewID"] = question.OverviewID;
        }
        else
        {
            Session["Question"] = null;
        }

        Response.Redirect("TestQuestion.aspx");
    }
    protected void btnMenu_Click(object sender, EventArgs e)
    {
        Response.Redirect("StudentMenu.aspx");
    }
    protected void btnOverviewNext_Click(object sender, EventArgs e)
    {
        int index = 0;
        if (Session["Question"] != null)
        {
            index = ((List<Question>)Session["Questions"]).FindIndex(q => q.ID == Convert.ToInt16(((Question)Session["Question"]).ID));
        }
            QuestionID = ((List<Question>)Session["Questions"]).ElementAt(index + 1).ID;
            question = ((List<Question>)(Session["Questions"])).ElementAt(((List<Question>)(Session["Questions"])).FindIndex(q => q.ID == QuestionID));
            Session["Question"] = question;
 
        Response.Redirect("TestQuestion.aspx");
    }
}