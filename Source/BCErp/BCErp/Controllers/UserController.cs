using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BCErp.BusinessLogic;
using BCErp.DTO;


namespace BCErp.Controllers
{
    public class UserController : Controller
    {
        UserBL userBL = new UserBL();
        RoleBL roleBL = new RoleBL();

        // GET: User
        public ActionResult Index()
        {
            List<UserDTO> userDTOs = userBL.GetAll();
            ViewBag.UserList = userDTOs;
            return View();
        }

        public ActionResult Create()
        {
            List<RoleDTO> roleList = roleBL.GetAll();
            ViewBag.RoleList = new SelectList(roleList, "Id","Name");


            return View();
        }
    }
}