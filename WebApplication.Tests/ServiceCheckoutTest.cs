using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApplication.OrderService;
using WebApplication.ServiceLayer;

namespace WebApplication.Tests {

    [TestClass]
    public class ServiceCheckoutTest {
        private readonly ServiceOrder testservice = new ServiceOrder();

        [TestMethod]
        public void TestGetOrder()
        {
            Order test = testservice.GetOrder(1);

            Assert.IsNotNull(test.CustomerId);
            Assert.IsNotNull(test.OrderId);
        }

        [TestMethod]
        public void TestCreateOrder()
        {
            Order order = new OrderService.Order
            {
                CustomerId = 63,
                Date = DateTime.Now,
                Status = true
            };

            int id = testservice.AddOrder(order);
            order.OrderId = id;

            Assert.IsTrue(testservice.AddOrder(order) > 0);
        }
    }
}