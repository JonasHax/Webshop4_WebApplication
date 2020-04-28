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
                RedirectToAction("List");
            }
            return View(); // hvorfor skal den være der??
        }


        //[HttpPost]
        //public ActionResult Validate(FormCollection form, int id) {
        //    CompanyProductVersion prodVer = null;
        //    var selectedColor = form.Get("colors");
        //    var selectedSize = form.Get("sizes");

        //    // gets the product
        //    ServiceProduct service = new ServiceProduct();
        //    CompanyProduct product = service.GetProductById(id);

        //    if (product != null) {
        //        prodVer = product.GetProductVersion(selectedSize, selectedColor);
        //        //prodVer.Product = newProd;
        //        if (prodVer != null) {
        //            return RedirectToAction("Add", "Cart", prodVer);
        //        } else {
        //            return View(prodVer);
        //        }
        //    }

        //    return View(prodVer);
        //}
    }
}