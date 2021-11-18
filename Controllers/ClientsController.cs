using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MassiveDynamicSimpleMembershipApp.Models.Clients;
using MassiveDynamicSimpleMembershipApp.ViewModels.Clients;
using WebMatrix.WebData;

namespace MassiveDynamicSimpleMembershipApp.Controllers
{
    public class ClientsController : Controller
    {
        // GET: Clients
        public ActionResult Index()
        {
            List<ClientsModel> Cleintlist = ClientsViewModel.GetAllClient();
            return View(Cleintlist);

            
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Index(string SearchTerm)
        {
            if (SearchTerm != "")
            {
               // ClientsViewModel CVM = new ClientsViewModel();
                List<ClientsModel> Cleintlist = ClientsViewModel.FindClient(SearchTerm);
                return View(Cleintlist);
            }
            else
            {
                return RedirectToAction("Index", "Clients");
            }

        }

        // is used to View the Documents of the client
        public ActionResult ViewDocument(int id)
        {
            List<ClientsModel> Documents = ClientsViewModel.GetDocumentsOfClient(id);
            TempData["UserID"]  = id;
            return View(Documents);
        }




        //This Delete is Used To Delete Document of the Client

        [Authorize(Roles = "Administrator")]
        [HttpGet]
        public ActionResult Delete(int Clientid = 0)
        {
            if (Clientid != 0)
            {
                ClientsViewModel.DeleteDocument(Clientid);
            }
            return RedirectToAction("Index", "Clients");

        }

        [HttpGet]
        [Authorize(Roles = "Administrator , Secretary")]
        public ActionResult EditClient(int UserId)
        {
            ClientsModel Cleintlist = ClientsViewModel.GetClientByUserID(UserId);
            return View(Cleintlist);
            //return View();
        }

        [HttpPost]
        [Authorize(Roles = "Administrator , Secretary")]
        public ActionResult EditClient(ClientsModel clientmodel)
        {
            if(clientmodel.UserId!=0)
            {ClientsViewModel.EditClientInfo(clientmodel); }

            return RedirectToAction("Index", "Clients");

        }


        //follwoing funtion is to delete client only adminstrator can

        [Authorize(Roles = "Administrator")]
        public ActionResult DeleteClient(int userid = 0)
        {
            if (userid != 0)
            {
                ClientsViewModel.DeleteClientInfo(userid);
            }
            return RedirectToAction("Index", "Clients");

        }

        [Authorize]
        [HttpGet]
        public ActionResult ClientProfile()
        {
            ClientProfileModel Cleintlist = ClientsViewModel.GetClientProfile(WebSecurity.CurrentUserId);
            return View(Cleintlist);
        }

    }
}

