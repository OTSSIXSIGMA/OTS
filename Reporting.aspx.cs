using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OnlineTrainingBL;
using System.Text.RegularExpressions;
public partial class Reporting : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if ((Request.UrlReferrer.OriginalString.ToString().ToLower().Contains("review.aspx")))
            {
                btnReturn.Visible = false;
            }
        }
        catch (Exception ex)
        { }
        List<OnlineTrainingBL.Report> report = new List<OnlineTrainingBL.Report>();
        int QuestionCount=0;
        foreach (Question question in ((List<Question>)Session["Questions"]).FindAll(x=> x.ID > 0))
        {
            if(!string.IsNullOrEmpty( question.SelectedList))
            {
                QuestionCount++;
               List<String> OptionsOrder = new List<String>(question.SelectedList.Split(','));
               string OptionChosen = question.OptionList.Find(q => q.ID == Convert.ToInt16(OptionsOrder.ElementAt(OptionsOrder.Count - 1))).DisplayID;
               string OptionCorrect = question.OptionList.Find(q => q.isAnswer == true).DisplayID;
               int numberCorrect = 0;
               foreach (Question quelocal in ((List<Question>)Session["Questions"]).FindAll(x=>x.ID > 0).GetRange(0,QuestionCount))
               {
                   List<String> Options = new List<String>(quelocal.SelectedList.Split(','));
                   string Chosen = quelocal.OptionList.Find(q => q.ID == Convert.ToInt16(Options.ElementAt(OptionsOrder.Count - 1))).Value.Replace("[", "").Replace("]", "");
                   string Correct = quelocal.OptionList.Find(q => q.isAnswer == true).Value.Replace("[", "").Replace("]", "");
                   if (Chosen == Correct)
                   {
                       numberCorrect++;
                   }
               }

               Report tmpReport = new Report(question.DisplayID.ToString(), OptionChosen, OptionCorrect, (OptionChosen == OptionCorrect) ? "Correct" : "Wrong", ((double)numberCorrect / QuestionCount) * 100);
               report.Add(tmpReport);
            }
        }

        if (report.Count != 0)
        {
            gdvReport.DataSource = report;
            gdvReport.DataBind();
        }
        else { lblReport.Text = "No report found."; }
    }

    protected void btnReturn_Click(object sender, EventArgs e)
    {
        Response.Redirect("StudentMenu.aspx");
    }
}

