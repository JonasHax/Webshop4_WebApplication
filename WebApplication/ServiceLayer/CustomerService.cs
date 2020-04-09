using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication.Models;
using WebApplication.Utilities;
using Proxy = WebApplication.ServiceReference1;

namespace WebApplication.ServiceLayer
{
    public class CustomerService : IUseCustomerService 
    {
        public int AddCustomer(Customer aClientPerson)
        {
            int insertedId = -2;
            Proxy.Customer customerInServiceFormat = new ConvertDataModel().ConvertToServiceCutsomer(aClientPerson);
            using (Proxy.CustomerServiceClient customerProxy = new Proxy.CustomerServiceClient())
            {
                insertedId = customerProxy.AddCustomer(customerInServiceFormat);
            }
            return insertedId;
        }
    }
    
}