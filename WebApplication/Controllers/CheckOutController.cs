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


        public ActionResult Index(/*Order order*/)
        {
            ShoppingCart = (List<CompanyProductVersion>)Session["ShoppingCart"];

            // opret ordre
            // kunden bliver sat på hardcoded lige nu - skal senere findes fra session
            OrderService.Order order = new OrderService.Order() {
                CustomerId = 1,
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

            return View(order);
        }
    }
}