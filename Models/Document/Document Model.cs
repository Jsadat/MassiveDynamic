using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MassiveDynamicSimpleMembershipApp.Models.Document
{
    public class Document_Model
    {
        
        public int  UserID { get; set; }

        [Display(Name = "Select File")]
        [Required(ErrorMessage = "File is required")]
        public string FilePath { get; set; }

        public string FileName   { get; internal set; }
    }
}