using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication.Models;


namespace WebApplication.Utilities {

    public interface IModelConvert {

        CompanyProduct ConvertFromServiceProduct(ProductService.Product productToConvert);

        OrderService.Product ConvertFromCompanyProduct(CompanyProduct productToConvert);

        OrderService.ProductVersion ConvertFromCompanyProductVersion(CompanyProductVersion prodVerToConvert);

        List<CompanyProduct> ConvertFromServiceProductAllProducts(List<ProductService.Product> listToConvert);

        CustomerServiceReference.Customer ConvertToServiceCutsomer(Customer clientModelCustomer);
    }
}