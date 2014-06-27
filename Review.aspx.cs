using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OnlineTrainingBL;
using System.Text.RegularExpressions;
using System.Collections;
public partial class Review : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        List<String> OptionsOrder = new List<String>(((Question)Session["Question"]).SelectedList.Split(','));
        string OptionChosen =  ((Question)Session["Question"]).OptionList.Find(q => q.ID == Convert.ToInt16(OptionsOrder.ElementAt(OptionsOrder.Count - 1))).Value.Replace("[","").Replace("]","");
        string OptionCorrect = ((Question)Session["Question"]).OptionList.Find(q => q.isAnswer == true).Value.Replace("[", "").Replace("]", "");
        OptionChosen = "(" + ((Question)Session["Question"]).OptionList.Find(q => q.ID == Convert.ToInt16(OptionsOrder.ElementAt(OptionsOrder.Count - 1))).DisplayID + ")" + OptionChosen;
        OptionCorrect = "(" + ((Question)Session["Question"]).OptionList.Find(q => q.isAnswer == true).DisplayID+ ")" + OptionCorrect;
        int numberCorrect=0;
        foreach (Question question in ((List<Question>)Session["Questions"]).FindAll(x=>x.SelectedList!=null))
        {
            OptionsOrder = new List<string>( question.SelectedList.Split(','));
            string Chosen = question.OptionList.Find(q => q.ID == Convert.ToInt16(OptionsOrder.ElementAt(OptionsOrder.Count - 1))).Value.Replace("[", "").Replace("]", "");
            string Correct = question.OptionList.Find(q => q.isAnswer == true).Value.Replace("[", "").Replace("]", "");
            if (Chosen == Correct)
            {
                numberCorrect++;
            }

        }
        double Accuracy = ((double)numberCorrect / (((List<Question>)Session["Questions"]).FindAll(x => x.SelectedList != null).Count)) * 100;
        if (OptionChosen == OptionCorrect)
        {
            LblResult.Text = "Correct Answer";
        }
        else
        {
            string result = "Wrong Answer<br/>Option Chosen: " + OptionChosen + "<br/>Option Correct: " + OptionCorrect;
            //string result1 = result + "<br/>" + OptionCorrect;
            //result1 = result1 + ((Hashtable)(Session["Descriptions"]))[Context.Request.QueryString["name"]].ToString();

            LblResult.Text = result;
        }

        LblResult.Text = LblResult.Text+"<br/> Accuarcy = " + Accuracy + "%";


    }
    protected void btnContinue_Click(object sender, EventArgs e)
    {
        Response.Redirect("TestQuestion.aspx");
    }
}