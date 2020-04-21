﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication.Tests.ProductService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ProductService.IProductService")]
    public interface IProductService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProductService/GetProduct", ReplyAction="http://tempuri.org/IProductService/GetProductResponse")]
        WebApplication.ProductService.Product GetProduct(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProductService/GetProduct", ReplyAction="http://tempuri.org/IProductService/GetProductResponse")]
        System.Threading.Tasks.Task<WebApplication.ProductService.Product> GetProductAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProductService/GetANumber", ReplyAction="http://tempuri.org/IProductService/GetANumberResponse")]
        int GetANumber(int number);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProductService/GetANumber", ReplyAction="http://tempuri.org/IProductService/GetANumberResponse")]
        System.Threading.Tasks.Task<int> GetANumberAsync(int number);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProductService/GetAllProducts", ReplyAction="http://tempuri.org/IProductService/GetAllProductsResponse")]
        WebApplication.ProductService.Product[] GetAllProducts();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProductService/GetAllProducts", ReplyAction="http://tempuri.org/IProductService/GetAllProductsResponse")]
        System.Threading.Tasks.Task<WebApplication.ProductService.Product[]> GetAllProductsAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProductService/InsertProduct", ReplyAction="http://tempuri.org/IProductService/InsertProductResponse")]
        bool InsertProduct(WebApplication.ProductService.Product productToInsert);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProductService/InsertProduct", ReplyAction="http://tempuri.org/IProductService/InsertProductResponse")]
        System.Threading.Tasks.Task<bool> InsertProductAsync(WebApplication.ProductService.Product productToInsert);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProductService/GetAllSizes", ReplyAction="http://tempuri.org/IProductService/GetAllSizesResponse")]
        string[] GetAllSizes();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProductService/GetAllSizes", ReplyAction="http://tempuri.org/IProductService/GetAllSizesResponse")]
        System.Threading.Tasks.Task<string[]> GetAllSizesAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProductService/GetAllColors", ReplyAction="http://tempuri.org/IProductService/GetAllColorsResponse")]
        string[] GetAllColors();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProductService/GetAllColors", ReplyAction="http://tempuri.org/IProductService/GetAllColorsResponse")]
        System.Threading.Tasks.Task<string[]> GetAllColorsAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProductService/GetAllCategories", ReplyAction="http://tempuri.org/IProductService/GetAllCategoriesResponse")]
        string[] GetAllCategories();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProductService/GetAllCategories", ReplyAction="http://tempuri.org/IProductService/GetAllCategoriesResponse")]
        System.Threading.Tasks.Task<string[]> GetAllCategoriesAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProductService/InsertProductVersion", ReplyAction="http://tempuri.org/IProductService/InsertProductVersionResponse")]
        bool InsertProductVersion(WebApplication.ProductService.ProductVersion prodVerToInsert, int styleNumber);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProductService/InsertProductVersion", ReplyAction="http://tempuri.org/IProductService/InsertProductVersionResponse")]
        System.Threading.Tasks.Task<bool> InsertProductVersionAsync(WebApplication.ProductService.ProductVersion prodVerToInsert, int styleNumber);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProductService/GetCategory", ReplyAction="http://tempuri.org/IProductService/GetCategoryResponse")]
        string[] GetCategory(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProductService/GetCategory", ReplyAction="http://tempuri.org/IProductService/GetCategoryResponse")]
        System.Threading.Tasks.Task<string[]> GetCategoryAsync(int id);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IProductServiceChannel : WebApplication.Tests.ProductService.IProductService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ProductServiceClient : System.ServiceModel.ClientBase<WebApplication.Tests.ProductService.IProductService>, WebApplication.Tests.ProductService.IProductService {
        
        public ProductServiceClient() {
        }
        
        public ProductServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ProductServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ProductServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ProductServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public WebApplication.ProductService.Product GetProduct(int id) {
            return base.Channel.GetProduct(id);
        }
        
        public System.Threading.Tasks.Task<WebApplication.ProductService.Product> GetProductAsync(int id) {
            return base.Channel.GetProductAsync(id);
        }
        
        public int GetANumber(int number) {
            return base.Channel.GetANumber(number);
        }
        
        public System.Threading.Tasks.Task<int> GetANumberAsync(int number) {
            return base.Channel.GetANumberAsync(number);
        }
        
        public WebApplication.ProductService.Product[] GetAllProducts() {
            return base.Channel.GetAllProducts();
        }
        
        public System.Threading.Tasks.Task<WebApplication.ProductService.Product[]> GetAllProductsAsync() {
            return base.Channel.GetAllProductsAsync();
        }
        
        public bool InsertProduct(WebApplication.ProductService.Product productToInsert) {
            return base.Channel.InsertProduct(productToInsert);
        }
        
        public System.Threading.Tasks.Task<bool> InsertProductAsync(WebApplication.ProductService.Product productToInsert) {
            return base.Channel.InsertProductAsync(productToInsert);
        }
        
        public string[] GetAllSizes() {
            return base.Channel.GetAllSizes();
        }
        
        public System.Threading.Tasks.Task<string[]> GetAllSizesAsync() {
            return base.Channel.GetAllSizesAsync();
        }
        
        public string[] GetAllColors() {
            return base.Channel.GetAllColors();
        }
        
        public System.Threading.Tasks.Task<string[]> GetAllColorsAsync() {
            return base.Channel.GetAllColorsAsync();
        }
        
        public string[] GetAllCategories() {
            return base.Channel.GetAllCategories();
        }
        
        public System.Threading.Tasks.Task<string[]> GetAllCategoriesAsync() {
            return base.Channel.GetAllCategoriesAsync();
        }
        
        public bool InsertProductVersion(WebApplication.ProductService.ProductVersion prodVerToInsert, int styleNumber) {
            return base.Channel.InsertProductVersion(prodVerToInsert, styleNumber);
        }
        
        public System.Threading.Tasks.Task<bool> InsertProductVersionAsync(WebApplication.ProductService.ProductVersion prodVerToInsert, int styleNumber) {
            return base.Channel.InsertProductVersionAsync(prodVerToInsert, styleNumber);
        }
        
        public string[] GetCategory(int id) {
            return base.Channel.GetCategory(id);
        }
        
        public System.Threading.Tasks.Task<string[]> GetCategoryAsync(int id) {
            return base.Channel.GetCategoryAsync(id);
        }
    }
}
