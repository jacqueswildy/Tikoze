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

        //create rowCount variable to count how many search results are returned
        int rowCount = 0;
        //find out how many total results in the database
        //int totalRowCount = 0;
 
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
                    DisplaySongMessage();
                    DisplaySearchNavigation();
                    break; 
                case 1: //1 query string 
                    DisplaySongMessage();
                    DisplaySearchNavigation();
                    break; 
                case 2: //2 query string 
                    DisplaySongMessage();
                    DisplaySearchNavigation();
                    break; 
                case 3: //3 query string 
                    Boolean queryIsLegit = ProcessQueryString(); 

                    //if ProcessQueryString() didn't return false 
                    if (queryIsLegit)
                    {
                        //retrieve queryString variables
                        int pageNumber = Convert.ToInt32(Request.QueryString["pg"]);
                        string searchType = Server.HtmlEncode(Request.QueryString["stype"]);
                        string searchText = Server.HtmlEncode(Request.QueryString["stext"]);

                        //get the type of sql we need in integer
                        int sqlType = (int)Sql.Search;

                        //get the type of search this this in int
                        int sType = Music.SearchTypeToInt(searchType);

                        //get the searchText
                        string sTerms = searchText;

                        //get the page number
                        int pgNumber = pageNumber;

                        string query = Music.ChooseSql(sqlType, sType, pgNumber);

                        #region Add Data to Search Object

                        Music search = new Music();

                        if (sType == Music.SearchTypeToInt("SongName")) { search.SongName = sTerms; }
                        else if (sType == Music.SearchTypeToInt("SongLyrics")) { search.SongLyrics = sTerms; }
                        else if (sType == Music.SearchTypeToInt("ArtistName")) { search.ArtistName = sTerms; }
                        else if (sType == Music.SearchTypeToInt("MusicalReleaseName")) { search.ReleaseName = sTerms; }

                        #endregion Add Data to Search Parameter

                        //create SqlConnection object with database connection string 
                        SqlConnection connection = new SqlConnection(Database.GetConnectionString());

                        //parameterize query
                        SqlCommand cmd = Database.ParameterizeQuery(query, search);

                        //search database
                        DataTable myTable = Database.Search(cmd, connection);

                        //format the data returned as search results
                        string results = Format.FormatSearchResults(myTable, sType);

                        //return how many search results displayed in page variable rowCount
                        rowCount = Format.CountSearchResults(myTable);

                        searchResults.Text = Server.HtmlDecode(results);
                        DisplaySongMessage();
                        DisplaySearchNavigation();

                    }//end if (queryIsLegit)
                         
                    else 
                    {
                        DisplaySongMessage();
                        DisplaySearchNavigation();
                    } 
                    break; 
                default: 
                    DisplaySongMessage();
                    DisplaySearchNavigation();
                    break; 
            }//switch 

 
            #endregion Switch for QueryCount 
 
        }//end Page_Load() 
 
        protected bool ProcessQueryString()  
        { 
            //process searchType 
            if (Request.QueryString["stype"] == null)  
            { 
                return false; 
            }//end else if 

 
            //process searchText 
            if (Request.QueryString["stext"] == null) 
            { 
                return false; 
            }//end else if 


            //process pageNumber 
            if (Request.QueryString["pg"] != null)  
            {
                try
                {
                    int page = Convert.ToInt32(Request.QueryString["pg"]);
                }
                catch (Exception e)
                {
                    string error = e.Message;
                    return false;
                }

            }//end if 
            else if (Request.QueryString["pg"] == null) 
            { 
                return false; 
            }//end else if 

            return true; 

        }//end ProcessQueryString()

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
            string stext = Server.HtmlEncode(Request.QueryString["stext"]);
            string stype = Server.HtmlEncode(Request.QueryString["stype"]);
            int page = 1;

            //retrieve page number
            try
            {
                page = Convert.ToInt32(Request.QueryString["pg"]);
            }
            catch (Exception exception)
            {
                string error = exception.Message;
            }


            //actual code to display nav buttons
            if (addSongMessage.Visible) 
            {
                nextButton.CssClass += " disabled";
                lastButton.CssClass += " disabled";
            }
            if (page <= 1)
            {
                firstButton.CssClass += " disabled";
                previousButton.CssClass += " disabled";
            }
        }//end DisplaySongMessage()

 
        protected void Search_Click(object sender, EventArgs e) 
        {
            string stext = Server.HtmlEncode(searchBox.Text);

            //get the radio button selection, convert it to string 
            string stype = (searchOptions.SelectedItem == null) ? Music.SearchTypeToString(Convert.ToInt32("0")) : Music.SearchTypeToString(Convert.ToInt32(searchOptions.SelectedItem.Value));

            //build url 
            string url = "/Search?pg=1" + "&stype=" + stype + "&stext=" + stext;

            //redirect page to newly created url 
            Response.Redirect(url, true); 

        }//end Search_Click(object sender, EventArgs e)

        protected void BuildUrlAndRedirect() 
        {
        }//end BuildURLAndRedirect()

        protected void NavigateToPage(string stext, string stype, int page)
        {
                //build url 
                string url = "/Search?pg=" + page + "&stype=" + stype + "&stext=" + stext;

                //redirect page to newly created url 
                Response.Redirect(url, true);            

        }//end NavigateToPage()


        protected void firstButton_Click(object sender, EventArgs e)
        {
            //make sure the query strings are legit
            Boolean queryIsLegit = ProcessQueryString();
            if (queryIsLegit) 
            {
                string stext = Server.HtmlEncode(Request.QueryString["stext"]);
                string stype = Server.HtmlEncode(Request.QueryString["stype"]);
                int page = Convert.ToInt32(Request.QueryString["pg"]);

                //assign the page number
                if (page >= 1)
                {
                    page = 1;
                }

                //build the url and navigate to it
                NavigateToPage(stext, stype, page);

            }//end if(queryIsLegit)

        }//end firstButton_Click

        protected void previousButton_Click(object sender, EventArgs e)
        {
            //make sure the query strings are legit
            Boolean queryIsLegit = ProcessQueryString();
            if (queryIsLegit)
            {
                string stext = Server.HtmlEncode(Request.QueryString["stext"]);
                string stype = Server.HtmlEncode(Request.QueryString["stype"]);
                int page = Convert.ToInt32(Request.QueryString["pg"]);

                //assign the page number
                if (page >= 2)
                {
                    --page;
                }

                //build the url and navigate to it
                NavigateToPage(stext, stype, page);

            }//end if(queryIsLegit)
 
        }//end previousButton_Click

        protected void nextButton_Click(object sender, EventArgs e)
        {
            //make sure the query strings are legit
            Boolean queryIsLegit = ProcessQueryString();
            if (queryIsLegit)
            {
                string stext = Server.HtmlEncode(Request.QueryString["stext"]);
                string stype = Server.HtmlEncode(Request.QueryString["stype"]);
                int page = Convert.ToInt32(Request.QueryString["pg"]);


                //assign the page number
                if (page >= 1)
                {
                    ++page;
                }

                //build the url and navigate to it
                NavigateToPage(stext, stype, page);

            }//end if(queryIsLegit)



            
        }//end nextButton_Click()

        protected void lastButton_Click(object sender, EventArgs e) {}//end lastButton_Click 

        protected void addIcons() 
        {
            firstButton.Text += Server.HtmlDecode("<span>class='glyphicon glyphicon-align-left'</span>");
        }

    }//end class Search: System.Web.UI.Page 
}//end namespace Tikoze 
