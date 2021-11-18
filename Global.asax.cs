using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using WebMatrix.WebData;

namespace MassiveDynamicSimpleMembershipApp
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            GlobalFilters.Filters.Add(new HandleErrorAttribute());
            InializeAuthenticationProcess();
        }


        //this line of codes is used to generate Table schema in sql server
        private void InializeAuthenticationProcess()
        {
            if(!WebSecurity.Initialized)
            {
                WebSecurity.InitializeDatabaseConnection("dbx", "Users", "UserId", "UserName", true);
                //WebSecurity.CreateUserAndAccount("Admin", "admin33");
                //Roles.CreateRole("Administrator");
                //Roles.CreateRole("Secretary");
                //Roles.CreateRole("Client");

                //Roles.AddUserToRole("Admin", "Administrator");
            }
        }
    }
}
