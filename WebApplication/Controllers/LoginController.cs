using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.ServiceLayer;

namespace WebApplication.Controllers {

    public class LoginController : Controller {

        // GET: Login
        public ActionResult Index() {
            return View();
        }

        [HttpPost]
        public ActionResult loginform(FormCollection collection) {
            // Få fat på information
            string email = collection.Get("email");
            string password = collection.Get("Password");

            // find bruger
            CustomerService service = new CustomerService();
            CustomerServiceReference.Customer customer = service.CustomerLogin(email, password);

            // valider korrekt login
            if (customer != null) {
                // tilføj bruger til Session
                Session["LoggedInUser"] = customer;
                return View("LoginSuccess");
            } else {
                ViewBag.Message = string.Format("Please enter valid Email and Password!");
                return View("Index");
            }
        }
    }
}