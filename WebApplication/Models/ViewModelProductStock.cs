using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Models {

    public class ViewModelProductStock {
        public int Stock { get; set; }
        public OrderService.SalesLineItem SalesLineItem { get; set; }
    }
}