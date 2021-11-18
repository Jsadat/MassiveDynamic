using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MassiveDynamicSimpleMembershipApp.Models.Accounts
{
    public class RegisterModel
    {
    

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Display(Name = "User Name")]
        [Required(ErrorMessage = "User Name is required")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Passowrd is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }

        [Display(Name = "Confirm Password")]
        [Required(ErrorMessage = "User Name is required")]
        [Compare(otherProperty: "Password", ErrorMessage = "Password Doesn't Match")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }


        [Display(Name = "Roles")]
        [Required(ErrorMessage = "Role is required")]
        [UIHint("RolesComboBox")]
        public string Role { get; set; }


        [Display(Name = "Select File")]
        //    [Required(ErrorMessage = "File is required")]
        public string FilePath { get; set; }


        [Display(Name = "Client Unique ID")]
        //     [Required (ErrorMessage = "Unique ID is required")]
        [StringLength(6, MinimumLength = 6, ErrorMessage = "Must be 6 Characters")]
        [RegularExpression("^[a-zA-Z0-9]*$", ErrorMessage = "Only Alphabets and Numbers allowed.")]
        public string ClientUniqueID { get; set; }
        public object FileName { get; internal set; }
        public int UserID { get; internal set; }
    }
}