using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MassiveDynamicSimpleMembershipApp.Models.Document;
using MassiveDynamicSimpleMembershipApp.ViewModels.Document;

using WebMatrix.WebData;

namespace MassiveDynamicSimpleMembershipApp.Controllers
{
    public class DocumentController : Controller
    {
        // GET: Document this is an extral control to add new documents for client
        [Authorize(Roles = "Administrator , Secretary")]
        public ActionResult Index()
        {
            return View();
        }

        //this Function is used to Upload the posted file and keep record to DB
        [HttpPost, ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator , Secretary")]
        public ActionResult Index(Document_Model model, HttpPostedFileBase postedFile)
        {
            //Extract Image File Name.
            string fileName = Path.GetFileName(postedFile.FileName);
            //Set the Image File Path.
            string filePath = "~/Models/Files/" + fileName;
            //Save the Image File in Folder.
            postedFile.SaveAs(Server.MapPath(filePath));
            model.FileName = fileName;
            model.FilePath = filePath;
            model.UserID = (int)TempData["UserID"];

            DocumentViewModel.InsertDocument(model);
            return RedirectToAction("Index", "Clients");
        }

    }
}