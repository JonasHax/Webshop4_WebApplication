using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication.OrderService;

namespace WebApplication.ServiceLayer {
    public interface IUseOrderService {
        int AddOrder(Order order);

        bool AddSalesLineItem(SalesLineItem sli);
    }
}
