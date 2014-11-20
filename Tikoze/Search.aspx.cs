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
        //create queryString variables
        int pageNumber;
        string searchType = string.Empty;
        string searchText = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
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
                case 3: ProcessQueryString();
                    //if (!(pageNumber == 0 && searchType == string.IsNullOrEmpty && searchText == string.IsNullOrEmpty))
                    //    searchResults.Text = Server.HtmlDecode(SearchDatabase());
                    break;
                default:
                    addSongMessage.Text = Server.HtmlDecode(PageContent.AddSongMessage());
                    addSongMessage.Visible = true;
                    break;
            }//switch

        }//end Page_Load()

        protected void ProcessQueryString() 
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
                return;
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
                return;
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
                return;
            }//end else if

        }//end ProcessQueryString()

        //protected string searchChoice() 
        //{
        //    string choice = string.Empty;
        //    if (songNameRB.Checked == true)
        //    {
        //        choice = "song";
        //        return choice;
        //    }//end if
        //}//end searchChoice()

        protected string SearchDatabase()
        {
            int searchType = 0; //lyrics
            string searchTerms = Server.HtmlEncode(searchBox.Text);
            int pageNumber = 1;

            string query = Music.ChooseSql(3, searchType, pageNumber);

            Music search = new Music();

            search.SongLyrics = searchTerms;

            //create SqlConnection object with database connection string
            SqlConnection connection = new SqlConnection(Database.GetConnectionString());

            DataTable myTable = Database.Search(Database.ParameterizeQuery(query, search), connection);

            string results = Format.FormatSearchResults(myTable, 3);

            return results;


        }//end SearchDatabase()

        protected void Button1_Click(object sender, EventArgs e)
        {
            //string url = string.Empty;
            //url += "/Search.aspx?pg=1&stext=" + Server.HtmlEncode(searchBox.Text) + "&stype=" + searchChoice();
            //Response.Redirect(url, true);
        }//Button1_Click

    }//end class Search: System.Web.UI.Page
}//end namespace Tikoze