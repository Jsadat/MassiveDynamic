using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MassiveDynamicSimpleMembershipApp.Controllers
{
    public class DashboardController : Controller
    {
        // GET: Dashboard is only for design purpose
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }
    }
}