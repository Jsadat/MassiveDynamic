using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MassiveDynamicSimpleMembershipApp.Models.Clients
{
    public class ClientsModel
    {
        public int ID { get; internal set; }

        [Display(Name = "User ID")]
        public int UserId { get; set; }

        public string Name { get; set; }


        [Display(Name = "User Name")]
        public string UserName { get; set; }

        public string Email { get; set; }


        [Display(Name = "Unique ID")]
        public string UniqueID { get; set; }

        [Display(Name = "Documents")]
        public string FilePath { get; set; }

        [Display(Name = "File Name")]
        public string FileName { get; set; }


    }
}