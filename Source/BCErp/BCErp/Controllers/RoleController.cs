using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BCErp.BusinessLogic;
using BCErp.DTO;

namespace BCErp.Controllers
{
    public class RoleController : Controller
    {
        RoleBL roleBL = new RoleBL();
        // GET: Role
        public ActionResult Index()
        {

           List<RoleDTO> roleDTOs= roleBL.GetAll();
            ViewBag.RoleList = roleDTOs;
            return View();
        }
    }
}