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
                         formattedSearchResults += "<a href='" +href + "'></a> </br>"; 
 
 
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
                         formattedSearchResults += "<a href='" + href + "'>" + dataRow["SongName"] + " by " + dataRow["ArtistName"] + " from album " + dataRow["MusicalReleaseName"] + "</a> </br>"; 
 
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
                         formattedSearchResults += "<a href='" + href + "'></a> </br>"; 
 
 
                         //display the link 
                         formattedSearchResults += "<code>http://www.tikoze.com" + href + "</code>"; 
                         formattedSearchResults += "</div>"; 
                     }//end foreach loop 
                     break; 
             }//end switch 
 
 
             return formattedSearchResults; 
         }//end FormatSearchResults() 
     }//end class Format  
 }//end namespace Tikoze 
