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


    }
    protected void btnContinue_Click(object sender, EventArgs e)
    {
        Response.Redirect("TestQuestion.aspx");
    }
}