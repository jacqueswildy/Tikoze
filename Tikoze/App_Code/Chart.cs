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
    //public interface IChart
    //{
    //    // Required Properties
    //    string ChartName { get; set; }
    //    int ChartID { get; set; }
    //    DateTime DateCreated { get; set; }
    //    string CreatedByUser { get; }
    //    DateTime LastModified { get; set; }
        
    //}//End of Chart interface 
    public class Chart
    {
        #region Members

        private string chartName;
        private int chartID;
        private DateTime dateCreated;
        private string createdByUser;
        private string sqlCode;
        private DateTime lastModified;
        private string chartHeader;
        private string chartBody;
        //this variable will hold the rank of the chart if it's active
        private int carouselNumber;
        //this variable will hold the results of the IsChartUnique() method
        private bool chartUniqueness;

        #endregion Members

        #region Properties
        //These properties are the interface through which other programmers can access the members of this class (which are private)
        //We have to define the accessors manually if we explicitly definite the class members though. Automatic { get; set; } create
        //the private members behind the scenes if all we do is retrieve or assign a value
        public string ChartName 
        { 
            get 
            { 
                return chartName; 
            }
            set 
            { 
                chartName = value;
            } 
        }//end public string ChartName
        //public int ChartID { get; set; }
        //public DateTime DateCreated { get;}
        //public string CreatedByUser { get; set; }
        //public string SqlCode { get; set; }
        //public DateTime LastModified { get; }
        //public string ChartHeader { get; }
        //public string ChartBody { get; }               
        //private bool ChartUniqueness { get; }
        //public int CarouselNumber { get; }
        #endregion Properties

        #region Constructors

        public Chart() { }
        public Chart(string NewChartName, string NewSqlCode, string NewUserName) 
        {
            chartName = NewChartName;
            sqlCode = NewSqlCode;
            createdByUser = NewUserName;
            dateCreated = System.DateTime.Now;
            lastModified = System.DateTime.Now;
            chartUniqueness = IsChartUnique(chartName, sqlCode);
            chartID = CreateChart();
        }

        #endregion Constructors

        #region Methods

        #region Use on Regular Pages

        //Use this when a specific chart needs to be displayed
        public static string Display(string chartName, string chartID) 
        {
            string chart = string.Empty;
            return chart;
        }//end Display(string NewChartName, string NewChartID)

        //The carouselNumber should correspond to the rank of the chart on the page. 
        //For example, Chart #2 should be on div #2 and should have carouselNumber = 2; 
        public static string Display(int carouselNumber)
        {
            string chart = string.Empty;
            return chart;
        }//end Display(int carouselNumber)
        
        #endregion Use on Regular Pages

        #region Create Chart

        private bool IsChartUnique(string chartName, string sqlCode) 
        {
            /*if(chartName OR sqlCode do not exist in database)*/
            return true;
        }//end IsChartUnique(string chartName, string sqlCode)

        //CreateChart() returns the chartID property
        private int CreateChart() 
        {
            //The ChartID will be returned from the databasebut to avoid confusion, 
            //i'm naming it dBChartID to clarify it's coming from the database.
            int dBChartID = 0;
            //be sure to run all the code in a try/catch that tests whether ChartUniqueness == true;
            //Connect to chart database, 
            //log all of the chart's properties, 
            //create a new chartID, 
            //retrieve the new chartID
            return dBChartID;
        }//end CreateChart()

        private int Carousel(int ChartID) 
        {
            //For the sample code, i just need to initialize the int value. Notice that
            //
            int carouselNumber = 1;
            return carouselNumber;
        }//end Carousel(int ChartID)

        #endregion Create Chart

        #region Retrieve Chart
        #endregion Retrieve Chart


        #region Database Connection
        #endregion Database Connection

        #endregion Methods

    }//end public class Chart
}//end namespace Tikoze