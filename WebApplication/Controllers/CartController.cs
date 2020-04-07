using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.Models;
using WebApplication.ServiceLayer;

namespace WebApplication.Controllers
{
    public class CartController : Controller
    {


        // GET: Cart
        public ActionResult Index()
        {
            ServiceProduct service = new ServiceProduct();
            CompanyProduct model = service.GetProductById(3);
            return View(model);
        }
    }
}