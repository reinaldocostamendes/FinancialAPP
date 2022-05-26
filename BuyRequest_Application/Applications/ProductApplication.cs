using BuyRequest_Application.Interface;
using BuyRequest_Application.Service.Interface;
using Infrastructure.Entity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BuyRequest_Application.Applications
{
    public class ProductApplication : IProductApplication
    {
        private readonly IProductService _productService;

        public ProductApplication(IProductService productService)
        {
            _productService = productService;
        }

        public async Task AddProduct(Product product)
        {
            await _productService.AddProduct(product);
        }

        public async Task DeleteProduct(Guid id)
        {
            await _productService.DeleteProduct(id);
        }

        public async Task<List<Product>> GetAllProducts()
        {
            return await _productService.GetAllProducts();
        }

        public async Task<List<Product>> GetAllProductsByBuyRequestId(Guid orderId)
        {
            return await _productService.GetAllProductsByBuyRequestId(orderId);
        }

        public async Task UpdateProduct(Product product)
        {
            await _productService.UpdateProduct(product);
        }
    }
}