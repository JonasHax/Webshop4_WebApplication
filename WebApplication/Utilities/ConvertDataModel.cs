using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication.Models;
using WebApplication.ProductService;
using Serviceproxy = WebApplication.ServiceReference1;


namespace WebApplication.Utilities {

    public class ConvertDataModel : IModelConvert {

        public ConvertDataModel() {
        }

        public CompanyProduct ConvertFromServiceProduct(ProductService.Product productToConvert) {
            CompanyProduct convertedProduct = null;
            if (productToConvert != null) {
                convertedProduct = new CompanyProduct() {
                    Name = productToConvert.Name,
                    Description = productToConvert.Description,
                    Price = productToConvert.Price,
                    State = productToConvert.State,
                    StyleNumber = productToConvert.StyleNumber
                };
                foreach (var prodVer in productToConvert.ProductVersions) {
                    CompanyProductVersion convertedProdVer = new CompanyProductVersion() {
                        ColorCode = prodVer.ColorCode,
                        SizeCode = prodVer.SizeCode,
                        Stock = prodVer.Stock,
                        Product = convertedProduct
                    };
                    convertedProduct.ProductVersions.Add(convertedProdVer);
                }
            }
            return convertedProduct;
        }

        public List<CompanyProduct> ConvertFromServiceProductAllProducts(List<Product> listToConvert) {
            List<CompanyProduct> convertedList = new List<CompanyProduct>();
                                             
            foreach (ProductService.Product product in listToConvert) {
                CompanyProduct convertedProd = ConvertFromServiceProduct(product);
                convertedList.Add(convertedProd);
            }

            return convertedList;
        }

        public Serviceproxy.Customer ConvertToServiceCutsomer(Customer clientModelCustomer)
        {
            Serviceproxy.Customer foundProxyCustomer = null;
            if (clientModelCustomer != null)
            {
                foundProxyCustomer = new Serviceproxy.Customer
                {
                    //Id = clientModelCustomer.Id,
                    FirstName = clientModelCustomer.FirstName,
                    LastName = clientModelCustomer.LastName,
                    CustStreet = clientModelCustomer.CustStreet,
                    CustNo = clientModelCustomer.CustNo,
                    ZipCode = clientModelCustomer.ZipCode,
                    Email = clientModelCustomer.Email,
                    PhoneNumber = clientModelCustomer.PhoneNumber,
                    Password = clientModelCustomer.Password
                };
            }
            return foundProxyCustomer;
        }

    }
}