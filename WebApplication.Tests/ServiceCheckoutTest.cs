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
        public void TestGetOrder()
        {
           Order test = testservice.GetOrder(2);

            Assert.IsTrue(test.CustomerId == 65);



        }

        [TestMethod]
        public void TestCreateOrder()
        {
            OrderService.Order order = new OrderService.Order
            {
                CustomerId = 65,
                Date = DateTime.Now,
                Status = true
            };

            
            int id = testservice.AddOrder(order);
            order.OrderId = id;

            Assert.IsTrue(testservice.AddOrder(order) > 0);

        }
    }
}
