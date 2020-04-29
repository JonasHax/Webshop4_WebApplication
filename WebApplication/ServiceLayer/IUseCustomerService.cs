using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication.Models;

namespace WebApplication.ServiceLayer {

    internal interface IUseCustomerService {

        bool AddCustomer(Customer cust);

        CustomerServiceReference.Customer CustomerLogin(string email, string password);
    }
}