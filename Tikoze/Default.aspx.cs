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
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Page.IsPostBack)
                searchResults.Text = Server.HtmlDecode(SearchDatabase());
        }//end Page_Load()

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

            DataTable myTable = Database.Search( Database.ParameterizeQuery(query, search), connection);

            string results = Format.FormatSearchResults(myTable,3);

            return results;


        }//end SearchDatabase()

        protected void Button1_Click(object sender, EventArgs e)
        {
        }//end Button1_Click()

    }//end class _Default:Page
}//end namespace Tikoze