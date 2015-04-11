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
    public partial class Display : System.Web.UI.Page
    {
        //create music object
        Music musicObj = new Music();
        protected void Page_Load(object sender, EventArgs e)
        {
            //parse the queryString; display song only if there are 3 query strings
            switch (Request.QueryString.Count)
            {
                case 0:
                    break;
                case 1:
                    break;
                case 2:
                    break;
                case 3: //display song
                    Boolean queryIsLegit = ProcessQueryString();
                    if(queryIsLegit)
                    {


                        //get the sqlText
                        int sqlType = (int)Sql.Retrieve;
                        int searchType = Music.SearchTypeToInt("song");
                        string sqlText = Music.ChooseSql(sqlType, searchType, 1);

                        //parameterize the query
                        SqlCommand cmd = Database.ParameterizeQuery(sqlText, musicObj);

                        //create SqlConnection object with database connection string 
                        SqlConnection connection = new SqlConnection(Database.GetConnectionString()); 

                        //get data from database
                        DataTable myTable = Database.Search(cmd, connection);

                        //add data to page
                        songMetaDataDisplay.InnerHtml = Server.HtmlDecode(Format.FormatSongMetaData(myTable));
                        lyricsVerificationDisplay.InnerHtml = Server.HtmlDecode("<p>Adding Verification Controls ...</p>");
                        songBodyDisplay.InnerHtml = Server.HtmlDecode(Format.FormatSongBody(myTable));
                        songFooterDisplay.InnerHtml = Server.HtmlDecode(Format.FormatSongFooterInfo(myTable));

                    }//end if(!queryIsLegit)
                    break;
                default:
                    break;
            }//end switch

        }//end Page_Load()

        protected bool ProcessQueryString()
        {
            //process artist name 
            if (Request.QueryString["artist"] != null)
            {
               musicObj.ArtistName = Server.HtmlEncode(Request.QueryString["artist"]);
            }//end if 
            else if (Request.QueryString["artist"] == null)
            {
                return false;
            }//end else if 


            //process album name 
            if (Request.QueryString["album"] != null)
            {
                musicObj.ReleaseName = Server.HtmlEncode(Request.QueryString["album"]);
            }//end if 
            else if (Request.QueryString["album"] == null)
            {
                return false;
            }//end else if 


            //process pageNumber 
            if (Request.QueryString["song"] != null)
            {
                musicObj.SongName = Server.HtmlEncode(Request.QueryString["song"]);
            }//end if 
            else if (Request.QueryString["song"] == null)
            {
                return false;
            }//end else if 

            //if all three query strings process successfully, return true
            return true;


        }//end ProcessQueryString()

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

    }//end class Display : System.Web.UI.Page
}//end namespace Tikoze