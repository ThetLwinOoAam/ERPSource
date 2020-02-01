using BCErp.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BCErp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost, ActionName("Index")]
        public ActionResult Create_Post(UserDTO userDTO)
        {
            if (userDTO.Email == "a@gmail.com" ||userDTO.Password == "123")
            {
                UserDTO sessionUser = new UserDTO() { Id = 1, Email = userDTO.Email, Password =userDTO.Password };

                Session["sessionUser"] = sessionUser;

                ResultMessage resultMessage = new ResultMessage() { Code = "000", Description = "Login Success" };
                return Json(resultMessage, JsonRequestBehavior.AllowGet);
            }

            return Json(new ResultMessage() { Code = "001", Description = "Login fail" }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}