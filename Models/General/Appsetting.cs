using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace MassiveDynamicSimpleMembershipApp.Models.General
{
    public class Appsetting
    {
        //is used to Get connection from Web.Config
        public static string ConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["dbx"].ConnectionString;
        }
    }
}