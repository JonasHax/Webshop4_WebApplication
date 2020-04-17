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
            return View((List<CompanyProductVersion>)Session["ShoppingCart"]);
        }

        [HttpPost]
        public ActionResult Index(CompanyProduct product, FormCollection form) {
            if (Session["ShoppingCart"] == null) {
                ShoppingCart = new List<CompanyProductVersion>();
                Session["ShoppingCart"] = ShoppingCart;
            }

            // add productversions to product
            ServiceProduct service = new ServiceProduct();
            product = service.GetProductById(product.StyleNumber);

            var selectedColor = form.Get("colors");
            var selectedSize = form.Get("sizes");

            CompanyProductVersion prodVer = product.GetProductVersion(selectedSize, selectedColor);

            if (prodVer != null) {
                ShoppingCart = (List<CompanyProductVersion>)Session["ShoppingCart"];
                ShoppingCart.Add(prodVer);
            } 
            else {
                return RedirectToAction("List", "Product");
            }

            Session["ShoppingCart"] = ShoppingCart;

            return RedirectToAction("Index", "Cart");
        }


        public ActionResult Delete(int id)
        {
            ShoppingCart = (List<CompanyProductVersion>)Session["ShoppingCart"];
            ShoppingCart.RemoveAt(id);
            Session["ShoppingCart"] = ShoppingCart;

            return RedirectToAction("Index", "Cart");

        }

    }
}