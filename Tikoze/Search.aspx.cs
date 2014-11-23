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
        int pageNumber; 
        string searchType = string.Empty; 
        string searchText = string.Empty; 

 
        #endregion Page Variables 

 
        protected void Page_Load(object sender, EventArgs e) 
        { 
            #region Switch for QueryCount 
            //parse the queryString; process only if there are 3 query strings 
            switch (Request.QueryString.Count) 
            { 
                case 0: //no query string 
                addSongMessage.Text = Server.HtmlDecode(PageContent.AddSongMessage()); 
                addSongMessage.Visible = true; 
                    break; 
                case 1: //1 query string 
                    addSongMessage.Text = Server.HtmlDecode(PageContent.AddSongMessage()); 
                    addSongMessage.Visible = true; 
                    break; 
                case 2: //2 query string 
                    addSongMessage.Text = Server.HtmlDecode(PageContent.AddSongMessage()); 
                    addSongMessage.Visible = true; 
                    break; 
                case 3: //3 query string 
                    Boolean queryIsLegit = ProcessQueryString(); 

 
                    //if page number is not 0 or ProcessQueryString() didn't return false 
                    if (pageNumber != 0 || !queryIsLegit) 
                        searchResults.Text = Server.HtmlDecode(SearchDatabase()); 
                    else 
                    { 
                        addSongMessage.Text = Server.HtmlDecode(PageContent.AddSongMessage()); 
                        addSongMessage.Visible = true; 
                    } 
                    break; 
                default: 
                    addSongMessage.Text = Server.HtmlDecode(PageContent.AddSongMessage()); 
                    addSongMessage.Visible = true; 
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
                return false; 
            }//end else if 


            //process pageNumber 
            if (Request.QueryString["pg"] != null)  
            { 
                // 
                //add error handling code in case user enters a non integer value 
                // 
                pageNumber = Convert.ToInt32(Request.QueryString["pg"]); 
            }//end if 
            else if (Request.QueryString["pg"] == null) 
            { 
                addSongMessage.Text = Server.HtmlDecode(PageContent.AddSongMessage()); 
                addSongMessage.Visible = true; 
                return false; 
            }//end else if 

            return true; 

 
        }//end ProcessQueryString()
 
        protected string SearchDatabase() 
        { 
            int sType = Music.SearchTypeToInt(searchType); 
            string sTerms = searchText; 
            int pgNumber = pageNumber; 

 
            string query = Music.ChooseSql(3, sType, pgNumber); 


            Music search = new Music(); 

 
            search.SongLyrics = sTerms; 

 
            //create SqlConnection object with database connection string 
            SqlConnection connection = new SqlConnection(Database.GetConnectionString()); 

 
            DataTable myTable = Database.Search(Database.ParameterizeQuery(query, search), connection); 

            string results = Format.FormatSearchResults(myTable, sType); 

 
            return results; 


 
        }//end SearchDatabase() 

 
        protected void Search_Click(object sender, EventArgs e) 
        { 
            string stext = Server.HtmlEncode(searchBox.Text); 

 
            //get the radio button selection, convert it to string 
            string stype = (searchOptions.SelectedItem == null) ? Music.SearchTypeToString(Convert.ToInt32("0")) : Music.SearchTypeToString(Convert.ToInt32(searchOptions.SelectedItem.Value)); 

 
            //build url 
            string url = "/Search?pg=1&stype=" + stype + "&stext=" + stext; 


            //redirect page to newly created url 
            Response.Redirect(url, true); 

 
        }//Search_Click() 

 
    }//end class Search: System.Web.UI.Page 
}//end namespace Tikoze 
