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
            if(sqlText.Contains("@ArtistName"))
                cmd.Parameters.AddWithValue("@ArtistName", o.ArtistName);
            if(sqlText.Contains("@MusicalReleaseName"))
                cmd.Parameters.AddWithValue("@MusicalReleaseName", o.ReleaseName);
            if(sqlText.Contains("@SongName"))
                cmd.Parameters.AddWithValue("@SongName", o.SongName);
            if(sqlText.Contains("@SongLyrics"))
                cmd.Parameters.AddWithValue("@SongLyrics", o.SongLyrics);
            /*
            if(sqlText.Contains(''))
                cmd.Parameters.AddWithValue("",);
            if(sqlText.Contains(''))
                cmd.Parameters.AddWithValue("",);
             */

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

    }//end class Database
}//end namespace