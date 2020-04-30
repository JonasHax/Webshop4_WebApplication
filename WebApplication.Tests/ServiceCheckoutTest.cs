using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApplication.OrderService;
using WebApplication.ServiceLayer;

namespace WebApplication.Tests
{
    [TestClass]
    public class ServiceCheckoutTest
    {

        readonly ServiceOrder testservice = new ServiceOrder();
        [TestMethod]
        public void TestAddOrder()
        {
           Order test = testservice.GetOrder(4);

            Assert.IsTrue(test.CustomerId == 4);



        }
    }
}
