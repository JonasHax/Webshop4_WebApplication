using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.Models;
using WebApplication.ServiceLayer;

namespace WebApplication.Controllers {

    public class ProductController : Controller {

        // GET: Product
        public ActionResult Index() {
            ServiceProduct service = new ServiceProduct();
            CompanyProduct model = service.GetProductById(3);
            return View(model);
        }

        public ActionResult List() {
            ServiceProduct service = new ServiceProduct();
            List<CompanyProduct> model = service.GetAllProducts();
            return View(model);
        }

        public ActionResult Details() {
        }
    }
}