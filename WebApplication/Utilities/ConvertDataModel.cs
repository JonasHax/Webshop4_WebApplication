﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication.Models;
using WebApplication.ProductService;
using Serviceproxy = WebApplication.CustomerServiceReference;

namespace WebApplication.Utilities {

    public class ConvertDataModel : IModelConvert {

        public ConvertDataModel() {
        }

        public OrderService.Product ConvertFromCompanyProduct(CompanyProduct productToConvert) {
            OrderService.Product convertedProduct = new OrderService.Product() {
                Name = productToConvert.Name,
                Description = productToConvert.Description,
                Price = productToConvert.Price,
                State = productToConvert.State,
                StyleNumber = productToConvert.StyleNumber
            };

            return convertedProduct;
        }

        public OrderService.ProductVersion ConvertFromCompanyProductVersion(CompanyProductVersion prodVerToConvert) {
            OrderService.ProductVersion convertedProdVer = new OrderService.ProductVersion() {
                ColorCode = prodVerToConvert.ColorCode,
                SizeCode = prodVerToConvert.SizeCode,
                Stock = prodVerToConvert.Stock,
                Product = ConvertFromCompanyProduct(prodVerToConvert.Product)
            };

            return convertedProdVer;
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
                if (productToConvert.ProductVersions.ToList().Count > 0) {
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

        public Serviceproxy.Customer ConvertToServiceCutsomer(Customer clientModelCustomer) {
            Serviceproxy.Customer foundProxyCustomer = null;
            if (clientModelCustomer != null) {
                foundProxyCustomer = new Serviceproxy.Customer {
                    FirstName = clientModelCustomer.FirstName,
                    LastName = clientModelCustomer.LastName,
                    Street = clientModelCustomer.Street,
                    HouseNo = clientModelCustomer.HouseNo,
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