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
            //define the sql code for the charts
            string chart1SQL = "SELECT TOP 5 ArtistName, MusicalReleaseName, SongName FROM MusicDatabaseView ORDER BY SongViews DESC;";
            string chart2SQL = "SELECT TOP 5 * FROM MusicDatabaseView ORDER BY SongDate DESC;";
            string chart3SQL = string.Empty;

            chart1.InnerHtml = CreateChart("5 Most Popular Songs", chart1SQL);
            chart2.InnerHtml = CreateChart("5 Most Recent Songs", chart2SQL);
            //chart3.InnerHtml = CreateChart("Most Shared Songs", chart3SQL);

        }//end Page_Load()

        //build charts
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

    }//end class _Default:Page
}//end namespace Tikoze