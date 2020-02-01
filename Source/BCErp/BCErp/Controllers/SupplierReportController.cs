using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BCErp.DTO;

namespace BCErp.Controllers
{
    public class SupplierReportController : Controller
    {
        // GET: SupplierReport
        public ActionResult SupplierListing()
        {
            return View();
        }

        public ActionResult SupplierListingView(SupplierListingFilterDTO filter)
        {
            List<SupplierDTO> list = new List<SupplierDTO>();
            list.Add(new SupplierDTO() { Name = "mdsmsf", Email = "sdf@gmail.com", RegisterDate = DateTime.Now });
            list.Add(new SupplierDTO() { Name = "mdsmxdfdfsf", Email = "fgsdf@gmail.com", RegisterDate = DateTime.Now });

            return Json(list, JsonRequestBehavior.AllowGet);
        }
    }
}