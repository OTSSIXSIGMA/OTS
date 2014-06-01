﻿using System;
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
            btnPrevious.Visible = false;
            if (Request.UrlReferrer != null)
            {
                if ((Request.UrlReferrer.OriginalString.ToString().ToLower().Contains("review.aspx")))
                {
                    if (Session["Question"] != null)
                    {
                        index = ((List<Question>)Session["Questions"]).FindIndex(q => q.ID == Convert.ToInt16(((Question)Session["Question"]).ID));
                        QuestionID = ((List<Question>)Session["Questions"]).ElementAt(index + 1).ID;
                    }
                }
                else if ((Request.UrlReferrer.OriginalString.ToString().ToLower().Contains("studentmenu.aspx")))
                {
                    if (((List<Question>)(Session["Questions"])).Exists(q => q.SelectedList != null))
                    {
                        QuestionID = ((List<Question>)(Session["Questions"])).FindLast(q => q.SelectedList != null).ID;
                    }
                    else
                    {
                        QuestionID = ((List<Question>)(Session["Questions"])).ElementAt(0).ID;
                    }
                }
                else if ((Request.UrlReferrer.OriginalString.ToString().ToLower().Contains("testquestion.aspx")))
                {
                    QuestionID = ((Question)Session["Question"]).ID;
                }
            }
            else
            {
                QuestionID = ((List<Question>)(Session["Questions"])).ElementAt(0).ID;
            }

            question = ((List<Question>)Session["Questions"]).Find(q => q.ID == QuestionID);
            lblQuestion.Text = question.Value;

            foreach (Option option in question.OptionList)
            {
                ListItem tmpItem = new ListItem(option.ID.ToString(), option.Value);
                tmpItem.Text = "<a href='Description.aspx?id=" +option.ID + "' rel=shadowbox;height=700;width=700>" + tmpItem.Value + "</a>";
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


            hddQuestionID.Value = question.ID.ToString() ;
            Session["Question"] = question;

            if (((List<Question>)Session["Questions"]).FindIndex(q => q.ID == ((Question)Session["Question"]).ID) == ((List<Question>)Session["Questions"]).Count - 1)
            {
                Session["SessionID"] = Session["SessionID"] + "CLOSED"; 
            }
            
        }

    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        #region connection
        string connectionstring = @"Data Source=(LocalDB)\v11.0;" +
            @"AttachDbFilename=|DataDirectory|\OnlineTraining.mdf;
                Integrated Security=True;
                Connect Timeout=30;";
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
}