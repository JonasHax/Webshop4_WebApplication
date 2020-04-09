using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.Models;
using WebApplication.ServiceLayer;

namespace WebApplication.Controllers {

    public class CartController : Controller {
        private List<CompanyProductVersion> ShoppingCart;

        // GET: Cart
        public ActionResult Index() {
            return RedirectToAction("Add");
        }

        [HttpPost]
        public ActionResult Add(CompanyProductVersion prodVer) {
            if (Session["ShoppingCart"] == null) {
                ShoppingCart = new List<CompanyProductVersion>();
            }

            //ServiceProduct service = new ServiceProduct();
            //prodVer.Product = service.GetProductById(3);
            //var products = (List<CompanyProductVersion>)Session["ShoppingCart"];
            //products.Add(prodVer);

            ShoppingCart.Add(prodVer);

            Session["ShoppingCart"] = ShoppingCart;

            return View((List<CompanyProductVersion>)Session["ShoppingCart"]);
        }
    }
}