using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication.Models;
using WebApplication.ProductService;
using WebApplication.Utilities;

namespace WebApplication.ServiceLayer {

    public class ServiceProduct : IUseProductService {

        public ServiceProduct() {
        }

        public List<CompanyProduct> GetAllProducts() {
            ProductServiceClient proxy = new ProductServiceClient();
            ConvertDataModel converter = new ConvertDataModel();

            List<CompanyProduct> productList = converter.ConvertFromServiceProductAllProducts(proxy.GetAllProducts().ToList());
            return productList;
        }

        public CompanyProduct GetProductById(int id) {
            ProductServiceClient proxy = new ProductServiceClient();
            ConvertDataModel converter = new ConvertDataModel();
            CompanyProduct product = converter.ConvertFromServiceProduct(proxy.GetProduct(id));

            return product;
        }
    }
}