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
                    sqlText = "SELECT TOP 10 ArtistName, MusicalReleaseName, SongName, SongSnippet FROM ";
                    sqlText += "(SELECT TOP " + pageNumber*10;
                    sqlText += " ArtistName, MusicalReleaseName, SongName, SongSnippet, SongViews FROM MUSICDATABASEVIEW AS T1 ";
                    sqlText += "WHERE ";
                    sqlText += Music.DefineSearchType(searchTypeInt);
                    sqlText += " LIKE ('%' + @SongLyrics + '%') ";
                    sqlText += "ORDER BY SongViews ASC) ";
                    sqlText += "AS T2 ORDER BY SongViews DESC";
                    break;
                default:
                    sqlText = String.Empty;
                    break;
            }//end switch

            return sqlText;
        }//end ChooseSql() function

        public static string DefineSearchType(int choice)
        {
            string searchType = string.Empty;

            switch (choice) 
            {
                case 0: //lyrics
                    searchType = "SongLyrics";
                    break;
                case 1: //song titles
                    searchType = "SongName";
                    break;
                case 2: //artists
                    searchType = "ArtistName";
                    break;
                case 3: //albums
                    searchType = "MusicalReleaseName";
                    break;
                default: //should never happen
                    break;
            }//end switch

            return searchType;
        }//end DefineSearchType()


        #endregion Methods

    }//end Music class
}//end namespace