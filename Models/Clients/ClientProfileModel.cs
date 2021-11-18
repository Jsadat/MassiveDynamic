using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MassiveDynamicSimpleMembershipApp.Models.Clients
{
    public class ClientProfileModel
    {
        public string  Name { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string UniqueId { get; set; }

    }
}