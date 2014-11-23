﻿using System; 
using System.Collections.Generic; 
using System.Linq; 
using System.Web; 
 
 
namespace Tikoze 
{ 
   public class PageContent 
   { 
        public static string AddSongMessage() 
        { 
            string message = string.Empty; 

            message += "<div class='active'><strong>Can't find what you're looking for? We apologize.</strong></div>"; 
            message += "<a class='btn btn-link' href='/Add.aspx' role='button'>"; 
            message += "Contribute & Add song &raquo;"; 
            message += "</a>"; 


            return message; 


        }//end AddSongMessage() 
    } 
} 
