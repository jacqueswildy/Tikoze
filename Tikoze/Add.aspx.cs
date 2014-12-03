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

        protected Boolean DoInputValidation(object sender, WizardNavigationEventArgs e) 
        {
            switch (e.NextStepIndex)
            {
                case 0://step 1
                    break;
                case 1://step 2
                    //this may be revalidation on page post. If we don't reset this value, this function will always return true
                    stepValidation1.Visible = false;

                    //remove all leading and trailing white spaces and lower case
                    string typeOfArtist = Music.ProcessSingleLineTextBox(mTypeOfTextBox.Text);
                    string artist = Music.ProcessSingleLineTextBox(aNameTextBox.Text);

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
                    //this may be revalidation on page post. If we don't reset this value, this function will always return true
                    stepValidation2.Visible = false;

                    string album = Music.ProcessSingleLineTextBox(mRNameTextBox.Text);
                    string typeOfAlbum = Music.ProcessSingleLineTextBox(mRTypeOfTextBox.Text);
                    int year;

                    //validate type of album
                    if (typeOfAlbum != "single" && typeOfAlbum != "album") 
                    {
                        e.Cancel = true;
                        stepValidation2.Text = Server.HtmlDecode("The type of Musical Release needs to be either <strong>Single</strong> or <strong>Album</strong>");
                        stepValidation2.Visible = true;
                    }//end if validation

                    //validate year
                    try 
                    {
                        year = Convert.ToInt32(mRYearReleasedTextBox.Text);
                    }
                    catch 
                    {
                        e.Cancel = true;
                        stepValidation2.Text = Server.HtmlDecode("The year needs to be a <strong>numerical value</strong>.");
                        stepValidation2.Visible = true;
                    }

                    //return processed entry to textbox
                    mRNameTextBox.Text = album;
                    mRTypeOfTextBox.Text = typeOfAlbum;

                    break;
                case 3://step 4
                    //this may be revalidation on page post. If we don't reset this value, this function will always return true
                    stepValidation3.Visible = false;

                    string song = Music.ProcessSingleLineTextBox(sNameTextBox.Text);
                    int track;

                    //validate track
                    if (sTrackTextBox.Text != null) 
                    {
                        try
                        {
                            track = Convert.ToInt32(sTrackTextBox.Text);
                        }
                        catch
                        {
                            e.Cancel = true;
                            stepValidation3.Text = Server.HtmlDecode("The track number needs to be a <strong>numerical value</strong>.");
                            stepValidation3.Visible = true;
                        }
                    }//end validate track

                    //return processed entry to textbox
                    sNameTextBox.Text = song;
                    
                    break;
                case 4://step 5
                    break;
            }//end switch(e.NextStepIndex) 

            if (stepValidation1.Visible | stepValidation2.Visible | stepValidation3.Visible)
            {
                return true;
            }//end return true

            else 
            {
                return false;
            }//end return false

        }//end DoInputValidation()

        protected void DisplayUserAnswers() 
        {
            Label1.Text = aNameTextBoxLabel.Text;
            Label2.Text = aNameTextBox.Text;
            Label3.Text = mTypeOfTextBoxLabel.Text;
            Label4.Text = mTypeOfTextBox.Text;
            Label5.Text = mRNameTextBoxLabel.Text;
            Label6.Text = mRNameTextBox.Text;
            Label7.Text = mRTypeOfTextBoxLabel.Text;
            Label8.Text = mRTypeOfTextBox.Text;
            Label9.Text = mRYearReleasedTextBoxLabel.Text;
            Label10.Text = mRYearReleasedTextBox.Text;
            Label11.Text = sNameTextBoxLabel.Text;
            Label12.Text = sNameTextBox.Text;
            Label13.Text = sTrackTextBoxLabel.Text;
            Label14.Text = sTrackTextBox.Text;
            Label15.Text = sLyricsTextBoxLabel.Text;
            Label16.Text = Server.HtmlDecode(sLyricsTextBox.Text);
        }//end DisplayUserAnswers()
        

        protected void Wizard1_FinishButtonClick1(object sender, WizardNavigationEventArgs e)
        {

        }//end FinishButtonClick()

        protected void Wizard1_NextButtonClick(object sender, WizardNavigationEventArgs e)
        {

            bool hasErrors = DoInputValidation(sender, e);

            //only calculate the progress bar is no validation errors are showing
            if (!hasErrors) 
            {
                CalculateProgressBar(sender, e);
            }//end if(hasErrors)

            //if this is the results page, attach the user inputs to the labels so user can review his/her answers
            if (e.NextStepIndex == 4) 
            {
                DisplayUserAnswers();
            }//end if (e.NextStepIndex == 5)
            
        }//end NextButtonClick()
  
    }// Page class
}//end namespace