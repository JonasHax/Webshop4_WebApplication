using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication.Controllers {

    public class LoginController : Controller {

        // GET: Login
        public ActionResult Index() {
            return View();
        }

        private int customerID;

        [HttpPost]
        public ActionResult loginform(FormCollection collection) {
            // tjek på information

            // find bruger

            // tilføj bruger til en Session

            string email = collection.Get("email");
            string Password = collection.Get("Password");
            if (email == "test@gmail.com" && Password == "123") {
                customerID = 5;
                return View("LoginSuccess");
            } else {
                ViewBag.Message = string.Format("Please enter valid Email and Password!");
                return View("Index");
            }
            // return View("Index");
        }
    }
}