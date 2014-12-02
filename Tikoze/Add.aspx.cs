using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace Tikoze
{
    public partial class Add : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }//end Page_Load()


        protected void CalculateProgressBar(object sender, WizardNavigationEventArgs e)
        {
            switch (e.NextStepIndex) 
            {
                case 0://step 1
                    if (divForStyle != null && Wizard1.ActiveStep.Equals(this.WizardStep1)) 
                    {
                        divForStyle.Style.Remove(HtmlTextWriterStyle.Width);
                        divForStyle.Style.Add(HtmlTextWriterStyle.Width, "20%");
                    }
                    if (progressBarSR != null)
                    {
                        progressBarSR.InnerHtml = "20% Complete";
                    }
                    break;
                case 1://step 2
                    if (divForStyle != null) 
                    {
                        divForStyle.Style.Remove(HtmlTextWriterStyle.Width);
                        divForStyle.Style.Add(HtmlTextWriterStyle.Width, "40%");
                    }
                    if (progressBarSR != null)
                    {
                        progressBarSR.InnerHtml = "40% Complete";
                    }
                    break;
                case 2://step 3
                    if (divForStyle != null) 
                    {
                        divForStyle.Style.Remove(HtmlTextWriterStyle.Width);
                        divForStyle.Style.Add(HtmlTextWriterStyle.Width, "60%");
                    }
                    if (progressBarSR != null)
                    {
                        progressBarSR.InnerHtml = "60% Complete";
                    }
                    break;
                case 3://step 4
                    if (divForStyle != null) 
                    {
                        divForStyle.Style.Remove(HtmlTextWriterStyle.Width);
                        divForStyle.Style.Add(HtmlTextWriterStyle.Width, "80%");
                    }
                    if (progressBarSR != null)
                    {
                        progressBarSR.InnerHtml = "80% Complete";
                    }
                    break;
                case 4://step 5
                    if (divForStyle != null) 
                    {
                        divForStyle.Style.Remove(HtmlTextWriterStyle.Width);
                        divForStyle.Style.Add(HtmlTextWriterStyle.Width, "100%");
                    }
                    if (progressBarSR != null)
                    {
                        progressBarSR.InnerHtml = "100% Complete";
                    }
                    break;
            }//end switch(Wizard1.ActiveStepIndex) 

    }//end CalculateProgressBar()

        protected void DoInputValidation(object sender, WizardNavigationEventArgs e) 
        {
            switch (e.NextStepIndex)
            {
                case 0://step 1
                    break;
                case 1://step 2
                    //remove all leading and trailing white spaces
                    string typeOfArtist = mTypeOfTextBox.Text.Trim();
                    string artist = aNameTextBox.Text.Trim();

                    //convert artist type to lower case
                    typeOfArtist = typeOfArtist.ToLower();

                    //validate type of artist
                    if (typeOfArtist != "solo" && typeOfArtist != "band") 
                    {
                        e.Cancel = true;
                        stepValidation1.Text = Server.HtmlDecode("The type of musician needs to be either <strong>Band</strong> or <strong>Solo</strong>");
                        stepValidation1.Visible = true;
                    }//end if validation

                    //return processed entry to textbox
                    aNameTextBox.Text = Server.HtmlEncode(artist);
                    mTypeOfTextBox.Text = Server.HtmlEncode(typeOfArtist);
                    break;
                case 2://step 3
                    break;
                case 3://step 4
                    break;
                case 4://step 5
                    break;
            }//end switch(e.NextStepIndex) 

        }//end DoInputValidation()
        

        protected void Wizard1_FinishButtonClick1(object sender, WizardNavigationEventArgs e)
        {

        }//end FinishButtonClick()

        protected void Wizard1_NextButtonClick(object sender, WizardNavigationEventArgs e)
        {

            DoInputValidation(sender, e);
            CalculateProgressBar(sender, e);
        }//end NextButtonClick()
  
    }// Page class
}//end namespace