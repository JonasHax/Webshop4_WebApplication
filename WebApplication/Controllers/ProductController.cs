using System;
using System.Collections.Generic;
using System.Diagnostics;
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

        public ActionResult Details(int? id) {
            if (id != null && id > -1) {
                ServiceProduct service = new ServiceProduct();
                CompanyProduct product = service.GetProductById((int)id);
                return View(product);
            } else {
                return RedirectToAction("List");
            }
        }

        public ActionResult NotinStock(int? id) {
            if (id != null && id > -1) {
                ServiceProduct service = new ServiceProduct();
                CompanyProduct product = service.GetProductById((int)id);
                ViewBag.Message = "Den valgte vare er ikke på lager";
                return View("Details", product);
            } else {
                return RedirectToAction("List");
            }
        }
    }
}