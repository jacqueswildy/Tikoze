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
                        lyricsVerificationDisplay.InnerHtml = Server.HtmlDecode("<p><em>Adding Verification Controls ...</em></p>");
                        songBodyDisplay.InnerHtml = Server.HtmlDecode(Format.FormatSongBody(myTable));
                        songFooterDisplay.InnerHtml = Server.HtmlDecode(Format.FormatSongFooterInfo(myTable));

                    }//end if(!queryIsLegit)
                    break;
                default:
                    break;
            }//end switch

            //get the charts whether there is lyrics to display or not
            //define the sql code for the charts
            string chart1SQL = "SELECT TOP 5 ArtistName, MusicalReleaseName, SongName FROM MusicDatabaseView ORDER BY SongViews DESC;";
            string chart2SQL = "SELECT TOP 5 * FROM MusicDatabaseView ORDER BY SongDate DESC;";
            string chart3SQL = string.Empty;

            //Get the Chart Titles
            string chart1Title = "5 Most Popular Songs";
            string chart2Title = "5 Most Recent Songs";
            
            chart1.InnerHtml = CreateChart(chart1Title, chart1SQL);
            chart2.InnerHtml = CreateChart(chart2Title, chart2SQL);
            //chart3.InnerHtml = CreateChart("Most Shared Songs", chart3SQL);

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


        //the CreateChart lyrics is a duplicate method from the page Default.aspx.cs page. It is best to have it called from a class.
        public string CreateChart(string chartTitle, string chartSQL)
        {
            string chart = string.Empty;

            //get the formatted chart title
            chart = Format.GetChartTitle(chartTitle);

            /*********************************************************************
                Parameterize the SQL, search the database, then build the chart               
             *********************************************************************/
            //create SqlConnection object with database connection string 
            SqlConnection connection = new SqlConnection(Database.GetConnectionString());

            //parameterize the query
            Music chartObj = new Music();
            SqlCommand cmd = Database.ParameterizeQuery(chartSQL, chartObj);

            //search database
            DataTable myTable = Database.Search(cmd, connection);

            //get the body of the chart
            string chartBody = Format.ProcessChart(myTable);

            /*********************************************************************            
                END Parameterize the SQL, search the database, then build the chart              
             *********************************************************************/
            //add the body of the chart to the title
            chart += chartBody;

            return chart;
        }//end CreateChart()

    }//end class Display : System.Web.UI.Page
}//end namespace Tikoze