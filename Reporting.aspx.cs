﻿using System;
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
        List<OnlineTrainingBL.Report> report = new List<OnlineTrainingBL.Report>();
        foreach (Question question in ((List<Question>)Session["Questions"]))
        {
            if(!string.IsNullOrEmpty( question.SelectedList))
            {
               List<String> OptionsOrder = new List<String>(question.SelectedList.Split(','));
               string OptionChosen = question.OptionList.Find(q => q.ID == Convert.ToInt16(OptionsOrder.ElementAt(OptionsOrder.Count - 1))).Value;
               string OptionCorrect = question.OptionList.Find(q => q.isAnswer == true).Value;
               Report tmpReport = new Report(question.Value, OptionChosen, OptionCorrect);
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

}
