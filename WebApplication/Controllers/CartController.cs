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
            int selectedAmount = Int32.Parse(form.Get("amount"));

            CompanyProductVersion prodVer = product.GetProductVersion(selectedSize, selectedColor);

            

            if (prodVer != null) {
                prodVer.Amount = selectedAmount;
                ShoppingCart = (List<CompanyProductVersion>)Session["ShoppingCart"];
                ShoppingCart.Add(prodVer);
            } 
            else {
                return RedirectToAction("NotInStock", "Product", new { id = product.StyleNumber });
            }

            Session["ShoppingCart"] = ShoppingCart;

            return RedirectToAction("index", "Cart");
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

        public ActionResult Delete(int id)
        {
            ShoppingCart = (List<CompanyProductVersion>)Session["ShoppingCart"];
            ShoppingCart.RemoveAt(id);
            Session["ShoppingCart"] = ShoppingCart;




            return RedirectToAction("Index", "Cart");

        }

        //[HttpPost]
        //public ActionResult CheckOut() {
        //    // find listen
        //    ShoppingCart = (List<CompanyProductVersion>)Session["ShoppingCart"];

        //    // opret ordre
        //    // kunden bliver sat på hardcoded lige nu - skal senere findes fra session
        //    OrderService.Order order = new OrderService.Order() {
        //        CustomerId = 1,
        //        Date = DateTime.Now,
        //        Status = false
        //    };

        //    // indsæt ordre til database og få genereret id ud og sat ind i objektet
        //    ServiceOrder service = new ServiceOrder();
        //    int id = service.AddOrder(order);
        //    order.OrderId = id;
        //    //order.SalesLineItems = new List<SalesLineItem>();

        //    // konverter liste til saleslineitems
        //    // tilføj saleslineitems til ordren
        //    ConvertDataModel converter = new ConvertDataModel();
        //    List<SalesLineItem> sliList = new List<SalesLineItem>();
        //    foreach (CompanyProductVersion item in ShoppingCart) {
        //        OrderService.SalesLineItem sli = new OrderService.SalesLineItem() {
        //            amount = 1,
        //            Price = item.Product.Price,
        //            Product = converter.ConvertFromCompanyProduct(item.Product),
        //            ProductVersion = converter.ConvertFromCompanyProductVersion(item),
        //            Order = order
        //        };
        //        sliList.Add(sli);
        //    }

        //    // adding the saleslineitems to the order
        //    order.SalesLineItems = sliList.ToArray();

        //    // send ordre til ny controller
        //    return RedirectToAction("Index", "CheckOut", order);

        //}

    }
}