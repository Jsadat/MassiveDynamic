using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using MassiveDynamicSimpleMembershipApp.Models.Accounts;
using WebMatrix.WebData;
using static MassiveDynamicSimpleMembershipApp.Models.General.SystemEnums;
using MassiveDynamicSimpleMembershipApp.ViewModels.Accounts;
using MassiveDynamicSimpleMembershipApp.Models.Clients;
using MassiveDynamicSimpleMembershipApp.ViewModels.Document;

namespace MassiveDynamicSimpleMembershipApp.Controllers
{
    public class AccountsController : Controller
    {
        // is used to get all users from DB and only administrator can see
        [Authorize(Roles = "Administrator")]
        public ActionResult UserList()
        {
            List<UserModel> users = AccountsViewModels.GetAllUser();
            return View(users);
        }

        // administrator allow to delete Users
        [Authorize(Roles = "Administrator")]
        public ActionResult DeleteUser(int userid = 0)
        {
            if (userid != 0)
            {
                AccountsViewModels.DeleteUsers(userid);
            }
            return RedirectToAction("UserList", "Accounts");

        }
        // GET: Accounts Return view of login page
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        //is used login to the system by username and password
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel loginModel)
        {
            if (ModelState.IsValid)
            {
                //checking user is authentcated
                bool isAuthenticated = WebSecurity.Login(loginModel.UserName, loginModel.Password, loginModel.RememberMe);
                if (isAuthenticated)
                {
                    // keeping Url history if it's not null redirect to Return Url other redirect to Dashboard
                    string returnUrl = Request.QueryString["ReturnUrl"];
                    if (returnUrl == null)
                    {
                        return RedirectToAction("Index", "Dashboard");
                    }
                    else
                    {
                        return Redirect(Url.Content(returnUrl));
                    }
                }
                else
                {
                    ModelState.AddModelError("", "User Name or Passowrd Are Invalid.");
                }
            }
            return View();
        }

        public ActionResult SignOut()
        {
            WebSecurity.Logout();
            return RedirectToAction("Login", "Accounts");
        }

        //is the View of Registration Field
        [HttpGet]
        [Authorize(Roles = "Administrator , Secretary")]
        public ActionResult Register()
        {
            GetRolesForCurrentUser();
            return View();
        }

        //this Function is Used to check the role of the current client with enum class and pass to dropdownlist
        private void GetRolesForCurrentUser()
        {
            if (Roles.IsUserInRole(WebSecurity.CurrentUserName, "Administrator"))
                ViewBag.RoleId = (int)role.Administrator;
            else ViewBag.RoleId = (int)role.NoRole;
        }

        // only Administrator can do everything , Scretary here can only register the client
        [HttpPost, ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator , Secretary")]
        public ActionResult Register(RegisterModel registrationModel, HttpPostedFileBase postedFile)
        {
            GetRolesForCurrentUser();
            if (ModelState.IsValid)
            {
               //Checking user existance
                bool IsUserExist = WebSecurity.UserExists(registrationModel.UserName);
                if (IsUserExist)
                {
                    ModelState.AddModelError("UserName", "User Name already Exist");
                }
                else
                {
                    // if the role is client it's goint keep tha file and unique ID from view
                    if (registrationModel.Role == "Client")
                    {
                        string FronUniqueID = registrationModel.ClientUniqueID;
                        string DBClientID = DocumentViewModel.CheckUniqueID(FronUniqueID);

                        // here We are Checking where the Unique Client ID is Exist or not
                        if (DBClientID == FronUniqueID)
                        {
                            ModelState.AddModelError("ClientUniqueID", "This Id is already Exist");
                        }
                        else
                        {
                            #region This is for files unique ID and and client Info insertion
                            //Extract Image File Name.
                            string fileName = Path.GetFileName(postedFile.FileName);
                            //Set the Image File Path.
                            string filePath = "~/Models/Files/" + fileName;
                            //Save the Image File in Folder.
                            postedFile.SaveAs(Server.MapPath(filePath));
                            registrationModel.FileName = fileName;
                            registrationModel.FilePath = filePath;

                            //Used to create different Users based on roles
                            WebSecurity.CreateUserAndAccount(registrationModel.UserName, registrationModel.Password,
                                new { Name = registrationModel.Name, Email = registrationModel.Email });
                            //Used to add roles to user
                            Roles.AddUserToRole(registrationModel.UserName, registrationModel.Role);
                            //insert path and file name to Db
                            DocumentViewModel.InsertFile(registrationModel);
                            ViewBag.Message = "User Registered Successfully";
                            #endregion
                        }
                    }
                    else
                    {
                        #region this is for administrator/Scretary Insert 
                        //Used to create different Users based on roles
                        WebSecurity.CreateUserAndAccount(registrationModel.UserName, registrationModel.Password,
                            new { Name = registrationModel.Name, Email = registrationModel.Email });
                        //Used to add roles to user
                        Roles.AddUserToRole(registrationModel.UserName, registrationModel.Role);
                        ViewBag.Message = "User Registered Successfully";
                        #endregion
                    }
                }
            }
            return View();
        }

    }
}