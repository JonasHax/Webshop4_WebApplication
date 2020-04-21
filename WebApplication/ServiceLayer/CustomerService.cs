using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication.Models;
using WebApplication.Utilities;
using Proxy = WebApplication.CustomerServiceReference;


namespace WebApplication.ServiceLayer
{
    public class CustomerService : IUseCustomerService 
    {
        public bool AddCustomer(Customer aClientPerson)
        {
            
            Proxy.Customer customerInServiceFormat = new ConvertDataModel().ConvertToServiceCutsomer(aClientPerson);
            using (CustomerServiceReference.CustomerServiceClient customerProxy = new CustomerServiceReference.CustomerServiceClient())
            {
                return customerProxy.AddCustomer(customerInServiceFormat);
            }
                   
        }
    }
    
}