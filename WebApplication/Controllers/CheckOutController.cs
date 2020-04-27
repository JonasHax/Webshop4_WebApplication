using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.Models;
using WebApplication.OrderService;
using WebApplication.ServiceLayer;
using WebApplication.Utilities;

namespace WebApplication.Controllers
{
    public class CheckOutController : Controller
    {
        private List<CompanyProductVersion> ShoppingCart;
        private Order sessionOrder;


        public ActionResult Index(/*Order order*/)
        {
            ShoppingCart = (List<CompanyProductVersion>)Session["ShoppingCart"];
            sessionOrder = (Order)Session["SessionOrder"];

            // opret ordre
            // kunden bliver sat på hardcoded lige nu - skal senere findes fra session
            OrderService.Order order = new OrderService.Order() {
                CustomerId = 2,
                Date = DateTime.Now,
                Status = false
            };

            // indsæt ordre til database og få genereret id ud og sat ind i objektet
            ServiceOrder service = new ServiceOrder();
            int id = service.AddOrder(order);
            order.OrderId = id;
            //order.SalesLineItems = new List<SalesLineItem>();

            // konverter liste til saleslineitems
            // tilføj saleslineitems til ordren
            ConvertDataModel converter = new ConvertDataModel();
            List<SalesLineItem> sliList = new List<SalesLineItem>();
            foreach (CompanyProductVersion item in ShoppingCart) {
                OrderService.SalesLineItem sli = new OrderService.SalesLineItem() {
                    amount = 1,
                    Price = item.Product.Price,
                    Product = converter.ConvertFromCompanyProduct(item.Product),
                    ProductVersion = converter.ConvertFromCompanyProductVersion(item),
                    Order = order
                };
                sliList.Add(sli);
            }

            // adding the saleslineitems to the order
            order.SalesLineItems = sliList.ToArray();

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
                // returner view hvis alt går godt
                return View(order);

            } catch (Exception e) {
                ViewBag.Message = e.Message;     
                return View();
            }

            // ændre ordre status til betalt
            //service.ChangeOrderToPaid(order);

            // if it fails, give error message. If not, return view
            //if (result) {
            //    order.Status = true;
            //    Session["SessionOrder"] = order;
            //    return View(order);
            //}

            //return View();
        }
    }
}