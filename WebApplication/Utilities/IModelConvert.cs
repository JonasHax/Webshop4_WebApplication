﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication.Models;
using Serviceproxy = WebApplication.CustomerServiceReference;


namespace WebApplication.Utilities {

    public interface IModelConvert {

        CompanyProduct ConvertFromServiceProduct(ProductService.Product productToConvert);

        OrderService.Product ConvertFromCompanyProduct(CompanyProduct productToConvert);

        OrderService.ProductVersion ConvertFromCompanyProductVersion(CompanyProductVersion prodVerToConvert);

        List<CompanyProduct> ConvertFromServiceProductAllProducts(List<ProductService.Product> listToConvert);

        Serviceproxy.Customer ConvertToServiceCutsomer(Customer clientModelCustomer);
    }
}