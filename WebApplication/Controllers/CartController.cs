using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.UI.WebControls;
using WebApplication.Models;
using WebApplication.OrderService;
using WebApplication.ServiceLayer;
using WebApplication.Utilities;

namespace WebApplication.Controllers {

    public class CartController : Controller {
        private List<SalesLineItem> ShoppingCart;

        // GET: Cart
        public ActionResult Index() {
            return View((List<SalesLineItem>)Session["ShoppingCart"]);
        }

        [HttpPost]
        public ActionResult Index(CompanyProduct product, FormCollection form) {
            if (Session["ShoppingCart"] == null) {
                ShoppingCart = new List<SalesLineItem>();
                Session["ShoppingCart"] = ShoppingCart;
            }

            // add productversions to product
            ServiceProduct service = new ServiceProduct();
            product = service.GetProductById(product.StyleNumber);

            var selectedColor = form.Get("colors");
            var selectedSize = form.Get("sizes");
            int selectedAmount = Int32.Parse(form.Get("amount"));

            CompanyProductVersion prodVer = product.GetProductVersion(selectedSize, selectedColor);

            ConvertDataModel converter = new ConvertDataModel();
           
            if (prodVer != null) {
                SalesLineItem lineitem = new SalesLineItem() {
                    amount = selectedAmount,
                    Product = converter.ConvertFromCompanyProduct(product),
                    ProductVersion = converter.ConvertFromCompanyProductVersion(prodVer),
                    Price = (selectedAmount * product.Price)
                };
                ShoppingCart = (List<SalesLineItem>)Session["ShoppingCart"];
                // check if item is already in cart
                if (ItemAlreadyExists(lineitem)) {
                    foreach (var item in ShoppingCart) {
                        if (item.Product.StyleNumber == lineitem.Product.StyleNumber && item.ProductVersion.SizeCode.Equals(lineitem.ProductVersion.SizeCode) && item.ProductVersion.ColorCode.Equals(lineitem.ProductVersion.ColorCode)) {
                            item.amount += lineitem.amount;
                        }
                    }
                } else {
                    ShoppingCart.Add(lineitem);
                }
            } else {
                return RedirectToAction("NotInStock", "Product", new { id = product.StyleNumber });
            }

            Session["ShoppingCart"] = ShoppingCart;

            return RedirectToAction("index", "Cart");
        }

        private bool ItemAlreadyExists(SalesLineItem lineItem) {
            bool result = false;
            ShoppingCart = (List<SalesLineItem>)Session["ShoppingCart"];

            foreach (var item in ShoppingCart) {
                if (item.Product.StyleNumber == lineItem.Product.StyleNumber && item.ProductVersion.SizeCode.Equals(lineItem.ProductVersion.SizeCode) && item.ProductVersion.ColorCode.Equals(lineItem.ProductVersion.ColorCode)) {
                    result = true;
                }
            }

            return result;
        }

        //[HttpGet]
        //[ActionName("Delete")]
        //public ActionResult Delete_Get(CompanyProductVersion pro)
        //{
        //    if (Session["ShoppingCart"] == null)
        //    {
        //        ShoppingCart = new List<CompanyProductVersion>();
        //        Session["ShoppingCart"] = ShoppingCart;
        //    }

        //    CompanyProductVersion product = pro;
        //    return View(product);

        //}

        //[HttpPost]
        //[ActionName("Delete")]
        //public ActionResult Delete_Post(CompanyProductVersion pro)
        //{
        //    if (Session["ShoppingCart"] == null)
        //    {
        //        ShoppingCart = new List<CompanyProductVersion>();
        //        Session["ShoppingCart"] = ShoppingCart;
        //    }

        //    ShoppingCart.Remove(pro);
        //    Session["ShoppingCart"] = ShoppingCart;
        //    return View();

        //}

        // Sletter produkter fra kurven
        public ActionResult Delete(int id) {
            ShoppingCart = (List<SalesLineItem>)Session["ShoppingCart"];
            ShoppingCart.RemoveAt(id);
            Session["ShoppingCart"] = ShoppingCart;

            return RedirectToAction("Index", "Cart");
        }
    }
}