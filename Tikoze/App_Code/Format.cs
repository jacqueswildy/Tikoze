using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace Tikoze
{
    public class Format
    {
        public static string FormatSearchResults(DataTable searchResults, int searchTypeInt) 
        {
            //this will contain the link to the search result
            string href = string.Empty;

            //will contain the finished results
            string formattedSearchResults = string.Empty;

            switch(searchTypeInt)
            {
                case 0: //artist
                    foreach (DataRow dataRow in searchResults.Rows) 
                    {
                        //build href
                        href = "/Display?artist=" + dataRow["ArtistName"];

                        //place all data in a div
                        formattedSearchResults = "<div>";

                        //build linkable search title for each row of result
                        formattedSearchResults += "<a href='" +href + "'></a> </br>";

                        //display the link
                        formattedSearchResults += "<code>http://www.tikoze.com" + href + "</code>";
                        formattedSearchResults += "</div>"; 
                    }//end foreach loop
                    break;
                case 1: //album
                    foreach (DataRow dataRow in searchResults.Rows) 
                    {
                        //build href
                        href = "/Display?artist=" + dataRow["ArtistName"] + "&album=" + dataRow["MusicalReleaseName"];

                        //place all data in a div
                        formattedSearchResults = "<div>";

                        //build linkable search title for each row of result
                        formattedSearchResults += "<a href='" +href + "'></a> </br>";

                        //display the link
                        formattedSearchResults += "<code>http://www.tikoze.com" + href + "</code>";
                        formattedSearchResults += "</div>"; 
                    }//end foreach loop
                    break;
                case 2: //song
                    foreach (DataRow dataRow in searchResults.Rows) 
                    {
                        //build href
                        href = "/Display?artist=" + dataRow["ArtistName"] + "&album=" + dataRow["MusicalReleaseName"] + "&song=" + dataRow["SongName"];

                        //place all data in a div
                        formattedSearchResults = "<div>";

                        //build linkable search title for each row of result
                        formattedSearchResults += "<a href='" +href + "'></a> </br>";

                        //display the link
                        formattedSearchResults += "<code>http://www.tikoze.com" + href + "</code>";
                        formattedSearchResults += "</div>"; 
                    }//end foreach loop
                    break;
                case 3: //lyrics
                    foreach (DataRow dataRow in searchResults.Rows) 
                    {
                        //build href
                        href = "/Display?artist=" + dataRow["ArtistName"] + "&album=" + dataRow["MusicalReleaseName"] + "&song=" + dataRow["SongName"];

                        //place all data in a div
                        formattedSearchResults = "<div>";

                        //build linkable search title for each row of result
                        formattedSearchResults += "<a href='" +href + "'></a> </br>";

                        //display the link
                        formattedSearchResults += "<code>http://www.tikoze.com" + href + "</code> <br />";

                        //add snippet
                        formattedSearchResults += "<div>" + dataRow["SongSnippet"];
                        formattedSearchResults += "</div>"; 
                    }//end foreach loop
                    break;
            }//end switch

            return formattedSearchResults;
        }//end FormatSearchResults()
    }//end class Format 
}//end namespace Tikoze