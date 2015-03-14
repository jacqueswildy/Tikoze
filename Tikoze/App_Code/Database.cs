using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Tikoze
{
    public class Database
    {
        #region connectionString
        public static string GetConnectionString()
        {
            string connectionString =
            ConfigurationManager.ConnectionStrings["JacquesWildyConnection"].ConnectionString;
            return connectionString;
        }//end GetConnectionString() function
        #endregion connectionString

        #region DataProtection
        public static SqlCommand ParameterizeQuery(string sqlText, Music o) 
        {
            //create SqlConnection object with database connection string
            SqlConnection connection = new SqlConnection(GetConnectionString());

            //create SqlCommand object
            SqlCommand cmd = new SqlCommand(sqlText, connection);

            //Add parameters

            //artist info
            if(sqlText.Contains("@ArtistName"))
                cmd.Parameters.AddWithValue("@ArtistName", o.ArtistName);
            if(sqlText.Contains("MusicianType"))
                cmd.Parameters.AddWithValue("@MusicianType",o.MusicianType);

            //album info
            if (sqlText.Contains("@ReleaseName"))
                cmd.Parameters.AddWithValue("@ReleaseName", o.ReleaseName);
            if(sqlText.Contains("@ReleaseType"))
                cmd.Parameters.AddWithValue("@ReleaseType", o.ReleaseType);
            if(sqlText.Contains("@ReleaseYear"))
                cmd.Parameters.AddWithValue("@ReleaseYear",o.ReleaseYear);

            //song info
            if(sqlText.Contains("@SongName"))
                cmd.Parameters.AddWithValue("@SongName", o.SongName);
            if(sqlText.Contains("@SongLyrics"))
                cmd.Parameters.AddWithValue("@SongLyrics", o.SongLyrics);
            if(sqlText.Contains("@SongTrack"))
                cmd.Parameters.AddWithValue("@SongTrack",o.SongTrack);
            
            //syntax
            //if(sqlText.Contains(""))
            //    cmd.Parameters.AddWithValue("",);

            return cmd;

        }//end ParameterizeQuery()

        #endregion DataProtection

        #region Search

        public static DataTable Search(SqlCommand cmd, SqlConnection connection) 
        {
            //connect and retrieve the data
            try
            {

                using (connection)
                {
                    SqlDataAdapter myDataAdapter = new SqlDataAdapter();
                    DataSet myDataSet = new DataSet();
                    connection.Open();
                    myDataAdapter.SelectCommand = cmd;
                    myDataAdapter.Fill(myDataSet);
                    DataTable myDataTable = myDataSet.Tables[0];

                    return myDataTable;
                }//end using(connection)
            }//end try
            catch (Exception err)
            {
                throw err;
            }//end catch
        }//end Search()

        #endregion Search

        #region Insert

        public static string Insert(SqlCommand cmd, SqlConnection connection) 
        {
            //feedback to user on whether the insert was successful
            string success = "Success! Thank you for contributing to this project";
            
            int added = 0;

            //connect and insert the data
            try
            {
                using (connection)
                {
                    cmd.Connection = connection; //Here assign connection to command object
                    connection.Open();
                    added = cmd.ExecuteNonQuery();

                    //update success variable
                    success += "\n" + added.ToString() + " records inserted.";
                }//end using(connection)
            }//end try
            catch (Exception err)
            {
                //if we have an error, return message
                string message = err.Message;
                return message;
            }//end catch

            return success;
        }//end Insert()

        #endregion Insert

    }//end class Database
}//end namespace