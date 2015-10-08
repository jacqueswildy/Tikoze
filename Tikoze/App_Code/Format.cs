using System; 
using System.Collections.Generic; 
using System.Linq; 
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data; 
using System.Data.SqlClient; 

 
namespace Tikoze 
 { 
     public class Format 
     { 
         public static string FormatSearchResults(DataTable searchResults, int searchTypeInt)  
         { 
             //will contain the finished results 
             string formattedSearchResults = string.Empty; 
 
 
             switch(searchTypeInt) 
             { 
                 case 0: //song title 
                     foreach (DataRow dataRow in searchResults.Rows)  
                     { 
                         //this will contain the link to the search result 
                         string href = string.Empty; 
 
 
                         //build href 
                         href = "/Display.aspx?artist=" + dataRow["ArtistName"] + "&album=" + dataRow["MusicalReleaseName"] + "&song=" + dataRow["SongName"]; 
 
 
                         //place all data in a div 
                         formattedSearchResults += "<div>";


                         //build linkable search title for each row of result 
                         formattedSearchResults += "<a href=\"" + href +"\"" + ">"; 
                         formattedSearchResults += dataRow["SongName"] + " by " + dataRow["ArtistName"];
                         formattedSearchResults += " from album " + dataRow["MusicalReleaseName"] + "</a> </br>";  
 
 
                         //display the link 
                         formattedSearchResults += "<code>http://www.tikoze.com" + href + "</code>"; 
                         formattedSearchResults += "</div>";  
                     }//end foreach loop 
                     break; 
                 case 1: //lyrics 
                     foreach (DataRow dataRow in searchResults.Rows)  
                     { 
                         //this will contain the link to the search result 
                         string href = string.Empty; 
 
 
                         //build href 
                         href = "/Display?artist=" + dataRow["ArtistName"] + "&album=" + dataRow["MusicalReleaseName"] + "&song=" + dataRow["SongName"]; 
 
 
                         //place all data in a div 
                         formattedSearchResults += "<div>"; 
 
 
                         //build linkable search title for each row of result 
                         formattedSearchResults += "<a href='" + href + "'>" + dataRow["SongName"] + " by " + dataRow["ArtistName"];
                         formattedSearchResults += " from album " + dataRow["MusicalReleaseName"] + "</a> </br>"; 
 
                         //display the link 
                         formattedSearchResults += "<div class='.pre-scrollable'><code>http://www.tikoze.com" + href + "</code> <br /></div>"; 
 
 
                         //add snippet 
                         formattedSearchResults += "<div>" + dataRow["SongSnippet"]; 
                         formattedSearchResults += "</div></div>";  
                     }//end foreach loop 
                     break; 
                 case 2: //artist 
                     foreach (DataRow dataRow in searchResults.Rows) 
                     { 
                         //this will contain the link to the search result 
                         string href = string.Empty; 
 
 
                         //build href 
                         href = "/Display?artist=" + dataRow["ArtistName"]; 
 
                         //place all data in a div 
                         formattedSearchResults += "<div>"; 
 
 
                         //build linkable search title for each row of result 
                         formattedSearchResults += "<a href='" + href + "'>" + dataRow["ArtistName"] + "</a> </br>"; 
 
 
                         //display the link 
                         formattedSearchResults += "<div class='.pre-scrollable'><code>http://www.tikoze.com" + href + "</code>"; 
                         formattedSearchResults += "</div></div>"; 
                     }//end foreach loop 
                     break; 
                 case 3: //album 
                     foreach (DataRow dataRow in searchResults.Rows) 
                     { 
                         //this will contain the link to the search result 
                         string href = string.Empty; 
 
 
                         //build href 
                         href = "/Display?artist=" + dataRow["ArtistName"] + "&album=" + dataRow["MusicalReleaseName"]; 
 
 
                         //place all data in a div 
                         formattedSearchResults += "<div>"; 
 
 
                         //build linkable search title for each row of result 
                         formattedSearchResults += "<a href='" + href + "'>" + dataRow["MusicalReleaseName"] + " by " + dataRow["ArtistName"];
                         formattedSearchResults += "</a> </br>"; 
 
 
                         //display the link 
                         formattedSearchResults += "<code>http://www.tikoze.com" + href + "</code>"; 
                         formattedSearchResults += "</div>"; 
                     }//end foreach loop 
                     break; 
             }//end switch 
 
 
             return formattedSearchResults; 
         }//end FormatSearchResults() 

         public static int ProcessSearchMetaData(DataTable metadata) 
         {
             int totalRows = 0;
             foreach (DataRow dataRow in metadata.Rows)
             {
                 try 
                 {
                     totalRows = Convert.ToInt32(dataRow["TotalRowCount"]);
                 }
                 catch(Exception e) 
                 {
                     throw e;
                 }
                 finally 
                 {
                     totalRows = 0;
                 }
             }//end foreach

             return totalRows;
         }//end ProcessSearchMetaData()
         public static int CountSearchResults(DataTable searchResults) 
         {
             int rowCount = searchResults.Rows.Count;

             return rowCount;
         }//end CountSearchResults()

         public static string FormatSongBody(DataTable myTable) 
         {
             string songBody = string.Empty;

             foreach (DataRow dataRow in myTable.Rows) 
             {
                 songBody += "<div runat=\"" + "server" + " class=\"" + "" + " style ='line-height:80%;'>";
                 songBody += dataRow["SongLyrics"] + "</div>";
             }//end foreach

             return songBody;

         }//end FormatSongBody()

         public static string FormatSongMetaData(DataTable myTable)
         {
             string metadata = string.Empty;

             foreach (DataRow dataRow in myTable.Rows)
             {
                 metadata += "<hgroup>";
                 metadata += "<h4><strong>Song Name:</strong> " + dataRow["SongName"] + "</h4>";
                 metadata += "<h4><strong>Artist Name:</strong> " + dataRow["ArtistName"] + "</h4>";
                 metadata += "<h4><strong>Album Name:</strong> " + dataRow["MusicalReleaseName"] + "</h4>";
                 metadata += "<h4><strong>Release Date:</strong> " + dataRow["MusicalReleaseYear"] + "</h4>";
                 metadata += "</hgroup>";
                 metadata += "<hr />";
             }//end foreach

             return metadata;

         }//end FormatSongMetaData()

         public static string FormatSongFooterInfo(DataTable myTable)
         {
             string footerInfo = string.Empty;
             foreach (DataRow dataRow in myTable.Rows)
             {
                 footerInfo += "<p>Added on: " + dataRow["SongDate"] + "</p>";
             }//end foreach

             return footerInfo;

         }//end FormatSongFooterInfo()

         //format chart title
         public static string GetChartTitle(string chartTitle) 
         {
             string formattedChartTitle = "<hgroup><h3>";
             formattedChartTitle += chartTitle;
             formattedChartTitle += "</h3></hgroup>";

             return formattedChartTitle;
         }//end GetChartTitle()

         public static string ProcessChart(DataTable myTable) 
         {
             /**
             *
             -May need to restructure all of the procedures in this class. look into making the looping into a separate procedure
             -open <ol>, loop through songs
                -open <li>, add song info
                -add link info
             -close </ol>, 
             *
             **/
             string chartBody = "<ol>";

             foreach (DataRow dataRow in myTable.Rows) 
             {                                  
                 //build hrefs 
                 string hrefSong, hrefArtist = string.Empty;
                 hrefSong = "/Display.aspx?artist=" + dataRow["ArtistName"] + "&album=" + dataRow["MusicalReleaseName"] + "&song=" + dataRow["SongName"];
                 hrefArtist = "/Display.aspx?artist=" + dataRow["ArtistName"];

                 //start building the chart
                 chartBody += "<li><a href=\"";
                 chartBody += hrefSong;
                 chartBody += "\">";
                 chartBody += dataRow["SongName"];
                 chartBody += "</a>";
                 chartBody += " by <a href=\"";
                 chartBody += hrefArtist;
                 chartBody += "\">";
                 chartBody += dataRow["ArtistName"];
                 chartBody += "</a>";
                 chartBody += "</li>";
             }//end foreach()

             chartBody += "</ol>";
             
             return chartBody;
         }//end ProcessChart()

     }//end class Format  
 }//end namespace Tikoze 
