using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.Models;
using WebApplication.OrderService;
using WebApplication.ServiceLayer;
using WebApplication.Utilities;

namespace WebApplication.Controllers {

    public class CheckOutController : Controller {
        private List<SalesLineItem> ShoppingCart;
        private Order sessionOrder;

        public ActionResult Index(FormCollection collection) {
            ShoppingCart = (List<SalesLineItem>)Session["ShoppingCart"];
            sessionOrder = (Order)Session["SessionOrder"];

            // opret ordre
            // kunden bliver sat på hardcoded lige nu - skal senere findes fra session
            OrderService.Order order = new OrderService.Order() {
                CustomerId = 4,
                Date = DateTime.Now,
                Status = false
            };

            // indsæt ordre til database og få genereret id ud og sat ind i objektet
            ServiceOrder service = new ServiceOrder();
            int id = service.AddOrder(order);
            order.OrderId = id;

            // add orderID to the saleslineitems
            foreach (var sli in ShoppingCart) {
                sli.Order = order;
            }

            // adding the saleslineitems to the order
            //order.SalesLineItems = sliList.ToArray();
            order.SalesLineItems = ShoppingCart.ToArray();

            // add order to session
            Session["SessionOrder"] = order;

            return View(order);
        }

        [HttpPost]
        public ActionResult Receipt() {
            Order order = (Order)Session["SessionOrder"];
            ServiceOrder service = new ServiceOrder();
            //bool result = true;

            // add the saleslineitems to the database
            try {
                service.AddSalesLineItem(order.SalesLineItems.ToList());
                // ændre ordre status til betalt
                service.ChangeOrderToPaid(order);
                order.Status = true;

                // Opdater ordren på session
                Session["SessionOrder"] = order;

                // reset the basket
                ShoppingCart = (List<SalesLineItem>)Session["ShoppingCart"];
                ShoppingCart.Clear();
                Session["ShoppingCart"] = ShoppingCart;

                // returner view hvis alt går godt
                return View(order);
            } catch (Exception e) {
                ViewBag.Message = e.Message;
                return View();
            }
        }
    }
}