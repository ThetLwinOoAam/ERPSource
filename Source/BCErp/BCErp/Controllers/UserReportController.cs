using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BCErp.Controllers
{
    public class UserReportController : Controller
    {
        // GET: UserReport
        public ActionResult UserListing()
        {
            return View();
        }
    }
}