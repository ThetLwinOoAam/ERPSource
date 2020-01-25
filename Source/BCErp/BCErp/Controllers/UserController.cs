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

        [HttpGet]
        public ActionResult Create()
        {
            List<RoleDTO> roleList = roleBL.GetAll();
            ViewBag.RoleList = new SelectList(roleList, "Id","Name");


            return View();
        }

        
        [HttpPost,ActionName("Create")]
        public ActionResult Create_Post(UserDTO userDTO)
        {
            if (userBL.Create(userDTO) > 0)
            {
                ResultMessage resultMessage = new ResultMessage() { Code = "000", Description = "Success save" };
                return Json(resultMessage, JsonRequestBehavior.AllowGet);
            }

            return Json(new ResultMessage() { Code = "001", Description = "Create fail" }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            List<RoleDTO> roleList = roleBL.GetAll();
            ViewBag.RoleList = new SelectList(roleList, "Id", "Name");
            UserDTO userDTO = userBL.GetById(id);
            return View(userDTO);
        }

        [HttpPost, ActionName("Edit")]
        public ActionResult Edit_Post(UserDTO userDTO)
        {
            if (userBL.Edit(userDTO) > 0)
            {
                ResultMessage resultMessage = new ResultMessage() { Code = "000", Description = "Success save" };
                return Json(resultMessage, JsonRequestBehavior.AllowGet);
            }

            return Json(new ResultMessage() { Code = "001", Description = "Create fail" }, JsonRequestBehavior.AllowGet);
        }
    }
}