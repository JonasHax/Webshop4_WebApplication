using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.Models;
using WebApplication.ServiceLayer;

namespace WebApplication.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        //public ActionResult Index()
        //{
        //    return View();
        //}

        //// GET: Customer/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        // GET: Customer/Create
        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Create(Customer personFromBrowser)
        {

            CustomerService cs = new CustomerService();
            cs.AddCustomer(personFromBrowser);

            return View("CustomerCreated");
        }


    }
}
