using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication.Models;
using WebApplication.ProductService;
using WebApplication.ServiceLayer;
using WebApplication.Utilities;

namespace WebApplication.Tests
{

    [TestClass]
    public class ServiceProductTest
    {
        readonly ServiceProduct testservice = new ServiceProduct();


        [TestMethod]
        public void TestGetAllProducts()
        {
            //Arrange and Act
            List<CompanyProduct> productList = testservice.GetAllProducts();

            //Assert
            Assert.IsTrue(productList.Count > 0);
        }


        [TestMethod]
        public void TestGetProductById()
        {
            //Arrange and Act
            CompanyProduct product =testservice.GetProductById(3);

            //Assert
            Assert.IsNotNull(product.Name);
            Assert.IsNotNull(product.Description);
            Assert.IsNotNull(product.StyleNumber);
            Assert.IsNotNull(product.ProductVersions);
            Assert.IsNotNull(product.Price);
        }

        [TestMethod]
        public void TestGetColors()
        {
            //Arrange
            CompanyProduct product = testservice.GetProductById(3);

            //Act
            List<string> colors = product.GetAvailableColors();

            //Assert
            Assert.IsTrue(colors.Count > 0);
        }


        [TestMethod]
        public void TestGetSizesFromColor()
        {
            //Arrange
            CompanyProduct product = testservice.GetProductById(3);

            //Act
            List<string> sizes = product.GetSizesAvailableInSpecificColor("blue");

            //Assert
            Assert.IsTrue(sizes.Count > 0);
        }

        [TestMethod]
        public void TestGetProductVersion()
        {
            //Arrange
            CompanyProduct product = testservice.GetProductById(3);

            //Act
            CompanyProductVersion prodver = product.GetProductVersion("m", "blue");


            //Assert
            Assert.IsTrue(prodver != null );
        }





    }
}
