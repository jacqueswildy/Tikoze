using System; 
using System.Collections.Generic; 
using System.Linq; 
using System.Web; 
using System.Web.UI; 
using System.Web.UI.WebControls; 
using System.Data; 
using System.Data.SqlClient; 
using System.Configuration; 

 
namespace Tikoze 
{ 
    public partial class Search : System.Web.UI.Page 
    { 
        #region Page Variables 

 
        //create queryString variables 
        int pageNumber = 1; 
        string searchType = string.Empty; 
        string searchText = string.Empty;

        //create rowCount variable to count how many search results are returned
        int rowCount = 0;
        //find out how many total results in the database
        int totalRowCount = 0;
 
        #endregion Page Variables 

 
        protected void Page_Load(object sender, EventArgs e) 
        { 
            //add Icons to navigation Buttons
            //addIcons();

            #region Switch for QueryCount 
            //parse the queryString; search only if there are 3 query strings 
            switch (Request.QueryString.Count) 
            { 
                case 0: //no query string 
                addSongMessage.Text = Server.HtmlDecode(PageContent.AddSongMessage()); 
                addSongMessage.Visible = true;
                DisplaySearchNavigation();
                    break; 
                case 1: //1 query string 
                    addSongMessage.Text = Server.HtmlDecode(PageContent.AddSongMessage()); 
                    addSongMessage.Visible = true;
                    DisplaySearchNavigation();
                    break; 
                case 2: //2 query string 
                    addSongMessage.Text = Server.HtmlDecode(PageContent.AddSongMessage()); 
                    addSongMessage.Visible = true;
                    DisplaySearchNavigation();
                    break; 
                case 3: //3 query string 
                    Boolean queryIsLegit = ProcessQueryString(); 

 
                    //if page number is not 0 or ProcessQueryString() didn't return false 
                    if (pageNumber != 0 || !queryIsLegit)
                    {
                        //GetSearchMetaData
                        //string metaDataResults = SearchDatabase((int)Sql.Metadata);
                        //metaDataResults = " Total Results";

                        //get actual search results
                        string results = SearchDatabase((int)Sql.Search);
                        searchResults.Text = Server.HtmlDecode(results);
                        DisplaySongMessage();
                        DisplaySearchNavigation();

                    }//end if (pageNumber != 0 || !queryIsLegit)
                         
                    else 
                    { 
                        addSongMessage.Text = Server.HtmlDecode(PageContent.AddSongMessage()); 
                        addSongMessage.Visible = true;
                        DisplaySearchNavigation();
                    } 
                    break; 
                default: 
                    addSongMessage.Text = Server.HtmlDecode(PageContent.AddSongMessage()); 
                    addSongMessage.Visible = true;
                    DisplaySearchNavigation();
                    break; 
            }//switch 

 
            #endregion Switch for QueryCount 
 
        }//end Page_Load() 
 
        protected bool ProcessQueryString()  
        { 
            //process searchType 
            if (Request.QueryString["stype"] != null) 
            { 
                searchType = Server.HtmlEncode(Request.QueryString["stype"]); 
            }//end if 
            else if (Request.QueryString["stype"] == null)  
            { 
                addSongMessage.Text = Server.HtmlDecode(PageContent.AddSongMessage()); 
                addSongMessage.Visible = true;
                DisplaySearchNavigation();
                return false; 
            }//end else if 

 
            //process searchText 
            if (Request.QueryString["stext"] != null) 
            { 
                searchText = Server.HtmlEncode(Request.QueryString["stext"]); 
            }//end if 
            else if (Request.QueryString["stext"] == null) 
            { 
                addSongMessage.Text = Server.HtmlDecode(PageContent.AddSongMessage()); 
                addSongMessage.Visible = true;
                DisplaySearchNavigation();
                return false; 
            }//end else if 


            //process pageNumber 
            if (Request.QueryString["pg"] != null)  
            {
                try
                {
                    pageNumber = Convert.ToInt32(Request.QueryString["pg"]);
                }
                catch (Exception e)
                {
                    string error = e.Message;
                }
                finally 
                {
                    pageNumber = 1;
                }

            }//end if 
            else if (Request.QueryString["pg"] == null) 
            { 
                addSongMessage.Text = Server.HtmlDecode(PageContent.AddSongMessage()); 
                addSongMessage.Visible = true;
                DisplaySearchNavigation();
                return false; 
            }//end else if 

            return true; 

 
        }//end ProcessQueryString()
 
        protected string SearchDatabase(int sqlType) 
        { 
            int sType = Music.SearchTypeToInt(searchType); 
            string sTerms = searchText; 
            int pgNumber = pageNumber; 

            string query = Music.ChooseSql(sqlType, sType, pgNumber); 


             

            #region Add Data to Search Parameter

            Music search = new Music();

            if (sType == Music.SearchTypeToInt("SongName")) { search.SongName = sTerms; }
            else if (sType == Music.SearchTypeToInt("SongLyrics")) { search.SongLyrics = sTerms; }
            else if (sType == Music.SearchTypeToInt("ArtistName")) { search.ArtistName = sTerms; }
            else if (sType == Music.SearchTypeToInt("MusicalReleaseName")) { search.ReleaseName = sTerms; }

            #endregion Add Data to Search Parameter


            //create SqlConnection object with database connection string 
            SqlConnection connection = new SqlConnection(Database.GetConnectionString()); 

            //parameterize query and search database
            DataTable myTable = Database.Search(Database.ParameterizeQuery(query, search), connection);

            //format the data returned as search results
            string results = Format.FormatSearchResults(myTable, sType);

            //return how many search results displayed in page variable rowCount
            rowCount = Format.CountSearchResults(myTable);

            return results; 
 
        }//end SearchDatabase()

        protected void DisplaySongMessage() 
        {
            if (rowCount < 10)
            {
                addSongMessage.Text = Server.HtmlDecode(PageContent.AddSongMessage());
                addSongMessage.Visible = true; 
            }
        }//end DisplaySongMessage()

        protected void DisplaySearchNavigation()
        {
            if (addSongMessage.Visible) 
            {
                nextButton.CssClass += " disabled";
                lastButton.CssClass += " disabled";
            }
            if (pageNumber <= 1)
            {
                firstButton.CssClass += " disabled";
                previousButton.CssClass += " disabled";
            }
        }//end DisplaySongMessage()

 
        protected void Search_Click(object sender, EventArgs e) 
        {
            BuildUrlAndRedirect();

        }//end Search_Click(object sender, EventArgs e)

        protected void BuildUrlAndRedirect() 
        {
            string stext = Server.HtmlEncode(searchBox.Text);


            //get the radio button selection, convert it to string 
            string stype = (searchOptions.SelectedItem == null) ? Music.SearchTypeToString(Convert.ToInt32("0")) : Music.SearchTypeToString(Convert.ToInt32(searchOptions.SelectedItem.Value));


            //build url 
            string url = "/Search?pg=" + pageNumber + "&stype=" + stype + "&stext=" + stext;


            //redirect page to newly created url 
            Response.Redirect(url, true); 

        }//end BuildURLAndRedirect()

        protected void NavigateToPage()
        {
            string stext = searchText;
            string stype = searchType;


            //build url 
            string url = "/Search?pg=" + pageNumber + "&stype=" + stype + "&stext=" + stext;


            //redirect page to newly created url 
            Response.Redirect(url, true);

        }//end NavigateToPage()


        protected void firstButton_Click(object sender, EventArgs e)
        {
            if (pageNumber >= 1)
            {
                pageNumber = 1;
                NavigateToPage();
            }

        }//end firstButton_Click

        protected void previousButton_Click(object sender, EventArgs e)
        {
            if (pageNumber >= 2)
            {
                --pageNumber;
                NavigateToPage();
            }
        }//end previousButton_Click

        protected void nextButton_Click(object sender, EventArgs e)
        {
            if (pageNumber >= 1)
            {
                ++pageNumber;
                NavigateToPage();
            }
        }//end nextButton_Click()

        protected void lastButton_Click(object sender, EventArgs e)
        {

        }//end lastButton_Click 

        protected void addIcons() 
        {
            firstButton.Text += Server.HtmlDecode("<span>class='glyphicon glyphicon-align-left'</span>");
        }

    }//end class Search: System.Web.UI.Page 
}//end namespace Tikoze 
