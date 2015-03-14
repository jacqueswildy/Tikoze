﻿using System; 
using System.Collections.Generic; 
using System.Linq; 
using System.Web; 

 
namespace Tikoze 
{ 
    public interface IMusic 
    {
        // Required Properties 
        string MusicianType { get; set; } 
        string ArtistName { get; set; } 
        string ReleaseType { get; set; } 
        int ReleaseYear { get; set; } 
        string ReleaseName { get; set; } 
        string SongName { get; set; } 
        int SongTrack { get; set; } 
        string SongLyrics { get; set; } 
        string SongDateAdded { get; set; } 
        string SongLastModifiedDate { get; set; } 
        string SongValidationCount { get; set; } 
        string SongGenre { get; set; } 
        string SongSnippet { get; set; } 
    }//End of IMusic interface 
    public class Music : IMusic 
    { 
        #region Properties 
        // Required Properties 
        public string MusicianType { get; set; } 
        public string ArtistName { get; set; } 
        public string ReleaseType { get; set; } 
        public int ReleaseYear { get; set; } 
        public string ReleaseName { get; set; } 
        public string SongName { get; set; } 
        public int SongTrack { get; set; } 
        public string SongLyrics { get; set; } 
        public string SongDateAdded { get; set; } 
        public string SongLastModifiedDate { get; set; } 
        public string SongValidationCount { get; set; } 
        public string SongGenre { get; set; } 
        public string SongSnippet { get; set; } 
        public string SearchText { get; set; } 
        public string SearchResults { get; set; } 

 
        #endregion Properties 

        #region Constructors 
        public Music() { } 
        public Music(string songName) 
        { 
            SongName = songName; 
        } 
        #endregion Constructors 

 
        #region Methods 
        public static string ChooseSql(int sqlType, int searchTypeInt, int pageNumber) 
        { 
            string sqlText = ""; 
            switch (sqlType) 
            { 
                case 0://insert 
                    sqlText = "EXEC InsertNewSong "; 
                    sqlText += "@NewArtistName = @ArtistName, "; 
                    sqlText += "@NewMusicianType = @MusicianType,"; 
                    sqlText += "@NewMusicalReleaseName = @ReleaseName, "; 
                    sqlText += "@NewMusicalReleaseType = @ReleaseType, "; 
                    sqlText += "@NewMusicalReleaseYear = @ReleaseYear, "; 
                    sqlText += "@NewSongName = @SongName, "; 
                    sqlText += "@NewSongTrack = @SongTrack, "; 
                    sqlText += "@NewSongLyrics = @SongLyrics;"; 
                    break; 
                case 1://retrieve 
                    sqlText = "SELECT * FROM MUSICDATABASEVIEW WHERE ";
                    sqlText += "ArtistName=@ArtistName AND MusicalReleaseName=@ReleaseName "; 
                    sqlText += "AND SongName=@SongName"; 
                    break; 
                case 2://update 
                    sqlText = "EXEC sp_UpdateMusic"; 
                    break; 
                case 3://search 
                    if (searchTypeInt == Music.SearchTypeToInt("SongName")) 
                    {
                        sqlText = "SELECT TOP 10 ArtistName, MusicalReleaseName, SongName, SongSnippet FROM ";
                        sqlText += "(SELECT TOP " + pageNumber * 10;
                        sqlText += " ArtistName, MusicalReleaseName, SongName, SongSnippet, SongViews FROM MUSICDATABASEVIEW AS T1 ";
                        sqlText += "WHERE ";
                        sqlText += Music.SearchTypeToString(searchTypeInt);
                        sqlText += " LIKE ('%' + @" + Music.SearchTypeToString(searchTypeInt) + " + '%') ";
                        sqlText += "ORDER BY SongViews ASC) ";
                        sqlText += "AS T2 ORDER BY SongViews DESC";
                        break;
                    }
                    else if (searchTypeInt == Music.SearchTypeToInt("SongLyrics")) 
                    {
                        sqlText = "SELECT TOP 10 ArtistName, MusicalReleaseName, SongName, SongSnippet FROM ";
                        sqlText += "(SELECT TOP " + pageNumber * 10;
                        sqlText += " ArtistName, MusicalReleaseName, SongName, SongSnippet, SongViews FROM MUSICDATABASEVIEW AS T1 ";
                        sqlText += "WHERE ";
                        sqlText += Music.SearchTypeToString(searchTypeInt);
                        sqlText += " LIKE ('%' + @" + Music.SearchTypeToString(searchTypeInt) + " + '%') ";
                        sqlText += "ORDER BY SongViews ASC) ";
                        sqlText += "AS T2 ORDER BY SongViews DESC";
                        break;
                    }
                    else if (searchTypeInt == Music.SearchTypeToInt("ArtistName")) 
                    {
                        sqlText = "SELECT DISTINCT TOP 10 ArtistName FROM ";
                        sqlText += "(SELECT DISTINCT TOP " + pageNumber * 10;
                        sqlText += " ArtistName FROM MUSICDATABASEVIEW AS T1 ";
                        sqlText += "WHERE ";
                        sqlText += Music.SearchTypeToString(searchTypeInt);
                        sqlText += " LIKE ('%' + @" + Music.SearchTypeToString(searchTypeInt) + " + '%') ";
                        sqlText += "ORDER BY ArtistName ASC) ";
                        sqlText += "AS T2 ORDER BY ArtistName DESC";
                        break;
                    }
                    else if (searchTypeInt == Music.SearchTypeToInt("MusicalReleaseName")) 
                    {
                        sqlText = "SELECT DISTINCT TOP 10 ArtistName, MusicalReleaseName FROM ";
                        sqlText += "(SELECT DISTINCT TOP " + pageNumber * 10;
                        sqlText += " ArtistName, MusicalReleaseName FROM MUSICDATABASEVIEW AS T1 ";
                        sqlText += "WHERE ";
                        sqlText += Music.SearchTypeToString(searchTypeInt);
                        sqlText += " LIKE ('%' + @" + Music.SearchTypeToString(searchTypeInt) + " + '%') ";
                        sqlText += "ORDER BY MusicalReleaseName ASC) ";
                        sqlText += "AS T2 ORDER BY MusicalReleaseName DESC";
                        break;
                    }
                    break;
                case 4: //get search metadata
                    sqlText = "SELECT COUNT(DISTINCT " + Music.SearchTypeToString(searchTypeInt) + ") AS TotalRowCount ";
                    sqlText += "FROM FROM MUSICDATABASEVIEW WHERE ";
                    sqlText += Music.SearchTypeToString(searchTypeInt);
                    sqlText += " LIKE ('%' + @" + Music.SearchTypeToString(searchTypeInt) + " + '%') ";
                    break;
                default: 
                    sqlText = String.Empty; 
                    break; 
            }//end switch 

             return sqlText; 
        }//end ChooseSql(int sqlType, int searchTypeInt, int pageNumber) function 


        public static string SearchTypeToString(int choice) 
        { 
             string searchType = string.Empty; 
 
            switch (choice)  
            { 
                case 0: //lyrics 
                    searchType = "SongName"; 
                    break; 
                case 1: //song titles 
                    searchType = "SongLyrics"; 
                    break; 
                case 2: //artists 
                    searchType = "ArtistName"; 
                    break; 
                case 3: //albums 
                    searchType = "MusicalReleaseName"; 
                    break; 
                case 4: //search metadata
                    searchType = "SearchMetaData";
                    break;
                case 5: //song
                    searchType = "song";
                    break;
                //default: //should never happen but if so, default to songName 
                //    searchType = "SongName"; 
                //    break; 
            }//end switch 

 
            return searchType; 
        }//end DefineSearchType() 

 
        public static int SearchTypeToInt(string searchType)  
        { 
            string formattedSearchType = searchType.ToLower(); 
            int searchTypeInt; 

 
            if (formattedSearchType == "songlyrics") 
            { 
                searchTypeInt = 1; 
                return searchTypeInt; 
            } 
            else if (formattedSearchType == "songname") 
            { 
                searchTypeInt = 0; 
                return searchTypeInt; 
            } 
            else if (formattedSearchType == "artistname") 
            { 
                searchTypeInt = 2; 
                return searchTypeInt; 
            } 
            else if (formattedSearchType == "musicalreleasename") 
            { 
                searchTypeInt = 3; 
                return searchTypeInt; 
            }
            else if (formattedSearchType == "searchmetadata")
            {
                searchTypeInt = 4;
                return searchTypeInt;
            }
            else if (formattedSearchType == "song")
            {
                searchTypeInt = 5;
                return searchTypeInt;
            }
            else
            {
                searchTypeInt = 0;
                return searchTypeInt;
            } 

 
        }//end SearchTypeToInt() 

        public static string LowerCaseAndTrim(string text)
        {
            string processedText = string.Empty;

            processedText = text.Trim();
            processedText = processedText.ToLower();

            return processedText;
        }//end LowerCaseAndTrim()

        public static string FormatEOL(string lyrics) 
        {
            string newLyrics = string.Empty;
            string newLyricsPart = string.Empty;

            string[] splitRawLyrics = null;

            //split and add each line into an index of the string array
            if (lyrics.Contains(Environment.NewLine))
            {
                splitRawLyrics = lyrics.Split(Environment.NewLine.ToCharArray());
            }

            foreach (string item in splitRawLyrics)
            {
                //do the formatting here
                newLyricsPart = string.Format("{0} <br />", item);
                newLyrics += newLyricsPart;//display formatted data in second Multiline TextBox

            }//end foreach

            return newLyrics;
        }//end FormatEOL(string lyrics)

        public static string FormatLetterCase(string lyrics)
        {
            //do some stuff
            return lyrics;
        }//end FormatLetterCase(string lyrics)

        public static string FormatIntro(string lyrics)
        {
            //do some stuff
            return lyrics;
        }//end FormatIntro(string lyrics)

        public static string FormatChorus(string lyrics)
        {
            //do some stuff
            return lyrics;
        }//end FormatChorus(string lyrics)

        public static string FormatVerse(string lyrics)
        {
            //do some stuff
            return lyrics;
        }//end FormatVerse(string lyrics)

        public static string FormatOutro(string lyrics)
        {
            //do some stuff
            return lyrics;
        }//end FormatOutro(string lyrics)

        public static string CreateSnippet(string lyrics)
        {
            //do some stuff
            return lyrics;
        }//end CreateSnippet(string lyrics)

        #endregion Methods 

    }//end Music class 
}//end namespace 
