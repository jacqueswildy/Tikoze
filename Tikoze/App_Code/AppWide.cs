using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tikoze
{
        //Enum declared here so that every object in this namespace can have access to it.
        enum Sql : int
        {
            Insert,
            Retrieve,
            Update,
            Search,
            Metadata
        }//end enum Sql
}