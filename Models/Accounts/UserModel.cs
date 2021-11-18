using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MassiveDynamicSimpleMembershipApp.Models.Accounts
{
    public class UserModel
    {
        [Display(Name="User ID")]
        public int UserId { get; internal set; }
        public string Name { get; internal set; }

        [Display(Name = "User Name")]
        public string UserName { get; internal set; }
        public string Email { get; internal set; }
        public string Role { get; internal set; }
    }
}