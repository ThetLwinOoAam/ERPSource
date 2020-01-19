using BCErp.BusinessLogic;
using BCErp.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BCErp.Controllers
{
    public class SupplierController : Controller
    {
        SupplierBL supplierBL = new SupplierBL();

        // GET: Supplier
        public ActionResult Index()
        {
            List<SupplierDTO> userDTOs = supplierBL.GetAll();
            ViewBag.SupplierList = userDTOs;
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            
            return View();
        }


        [HttpPost, ActionName("Create")]
        public ActionResult Create_Post(SupplierDTO supplierDTO)
        {

            return Json(supplierDTO, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Edit()
        {
            SupplierDTO supplierDTO = new SupplierDTO();
            supplierDTO.RegisterDate = new DateTime(2020, 4, 11);
            return View(supplierDTO);
        }


        [HttpPost, ActionName("Edit")]
        public ActionResult Edit_Post(SupplierDTO supplierDTO)
        {

            return Json(supplierDTO, JsonRequestBehavior.AllowGet);
        }

    }
}