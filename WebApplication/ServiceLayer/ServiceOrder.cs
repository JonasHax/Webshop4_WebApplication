using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication.OrderService;

namespace WebApplication.ServiceLayer {
    public class ServiceOrder : IUseOrderService {

        public int AddOrder(Order order) {
            OrderServiceClient proxy = new OrderServiceClient();
            return proxy.AddOrder(order);
        }

        public bool AddSalesLineItem(SalesLineItem sli) {
            OrderServiceClient proxy = new OrderServiceClient();
            return proxy.AddSalesLineItemToOrder(sli);
        }
    }
}