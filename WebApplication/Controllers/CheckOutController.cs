using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.Models;
using WebApplication.OrderService;
using WebApplication.ProductService;
using WebApplication.ServiceLayer;
using WebApplication.Utilities;

namespace WebApplication.Controllers {

    public class CheckOutController : Controller {
        private List<SalesLineItem> ShoppingCart;
        private Order sessionOrder;

        [HttpPost]
        public ActionResult Index(FormCollection collection) {
            ShoppingCart = (List<SalesLineItem>)Session["ShoppingCart"];
            sessionOrder = (Order)Session["SessionOrder"];

            // få fat i kunden
            CustomerServiceReference.Customer customer = (CustomerServiceReference.Customer)Session["LoggedInUser"];

            // tjek om der er noget i kurv
            if (ShoppingCart == null || ShoppingCart.Count == 0) {
                return View("NoItemsInCart");
            }

            // tjek om der er nok af alle produkter på lager. Send en fejlbesked hvis ikke
            ProductServiceClient productService = new ProductServiceClient();
            foreach (var item in ShoppingCart) {
                int stock = productService.GetStock(item.Product.StyleNumber, item.ProductVersion.SizeCode, item.ProductVersion.ColorCode);
                if (stock < item.amount) {
                    ViewModelProductStock model = new ViewModelProductStock() {
                        SalesLineItem = item,
                        Stock = stock
                    };
                    return View("ItemNotInStock", model);
                }
            }

            if (customer != null) {
                // opret ordre
                OrderService.Order order = new OrderService.Order() {
                    CustomerId = customer.CustomerID,
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
            } else {
                return View("NoCustomerLoggedIn");
            }
        }

        [HttpPost]
        public ActionResult Receipt() {
            Order order = (Order)Session["SessionOrder"];
            ServiceOrder service = new ServiceOrder();
            CustomerServiceReference.Customer customer = (CustomerServiceReference.Customer)Session["LoggedInUser"];
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

                // opret model
                ViewModelReciept model = new ViewModelReciept() {
                    Order = order,
                    Customer = customer
                };

                // returner view hvis alt går godt
                return View(model);
            } catch (Exception e) {
                ViewBag.Message = e.Message;
                return View();
            }
        }
    }
}