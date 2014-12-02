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

        }//end Page_Load()

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