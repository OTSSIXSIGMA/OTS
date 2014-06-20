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
        foreach (Question question in ((List<Question>)Session["Questions"]))
        {
            if (!string.IsNullOrEmpty(question.SelectedList))
            {
                List<String> OptionsOrder = new List<String>(question.SelectedList.Split(','));
                string OptionChosen = question.OptionList.Find(q => q.ID == Convert.ToInt16(OptionsOrder.ElementAt(OptionsOrder.Count - 1))).DisplayID;
                string OptionCorrect = question.OptionList.Find(q => q.isAnswer == true).DisplayID;
                Report tmpReport = new Report(question.DisplayID.ToString(), OptionChosen, OptionCorrect, (OptionChosen == OptionCorrect) ? "Correct" : "Wrong");
                report.Add(tmpReport);
            }
        }

        int numberCorrect = 0;
        foreach (Question question in ((List<Question>)Session["Questions"]).FindAll(x => x.SelectedList != null))
        {
            List<string> OptionsOrder = new List<string>(question.SelectedList.Split(','));
            string Chosen = question.OptionList.Find(q => q.ID == Convert.ToInt16(OptionsOrder.ElementAt(OptionsOrder.Count - 1))).Value.Replace("[", "").Replace("]", "");
            string Correct = question.OptionList.Find(q => q.isAnswer == true).Value.Replace("[", "").Replace("]", "");
            if (Chosen == Correct)
            {
                numberCorrect++;
            }

        }
        double Accuracy = ((double)numberCorrect / (((List<Question>)Session["Questions"]).FindAll(x => x.SelectedList != null).Count)) * 100;
        lblReport.Text = "<br/>Accuracy =" + Accuracy + "%";
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

