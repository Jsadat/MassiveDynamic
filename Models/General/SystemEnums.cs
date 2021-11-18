using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MassiveDynamicSimpleMembershipApp.Models.General
{
    public class SystemEnums
    {
        //this enum is used to define the roles to the view and identify curren user role
        public enum role
        {
            NoRole = 0,
            Administrator = 1,
            Secretary = 2,
            Client = 3,
        }
    }
}