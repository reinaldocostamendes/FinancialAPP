using AutoMapper;
using BuyRequest_Application.Interface;
using BuyRequest_Application.Service.Interface;
using BuyRequestDomain.DTO;
using BuyRequestDomain.Entity;
using Infrastructure.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuyRequest_Application.Applications
{
    public class ProductApplication : IProductApplication
    {
        private readonly IProductService _productService;
        private readonly IMapper imapper;

        public ProductApplication(IProductService productService, IMapper imapper)
        {
            _productService = productService;
            this.imapper = imapper;
        }

        private String ErrorList(List<string> message)
        {
            var string_errors = "[ ";
            foreach (var error in message)
            {
                string_errors += " - " + error.ToString();
            }
            return string_errors + " ]";
        }

        public async Task<Product> AddProductDTO(ProductDTO productDTO)
        {
            var product = imapper.Map<Product>(productDTO);
            if (!product.IsValid())
            {
                var message = product.
                   ValidationResult.Errors.
                   ConvertAll(x => x.ErrorMessage.ToString()).ToList();

                throw new Exception(ErrorList(message));
            }
            await _productService.AddProduct(product);
            return product;
        }

        public async Task AddProduct(Product product)
        {
            if (!product.IsValid())
            {
                var message = product.
                   ValidationResult.Errors.
                   ConvertAll(x => x.ErrorMessage.ToString()).ToList();

                throw new Exception(ErrorList(message));
            }
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

        public async Task<Product> getProductById(Guid id)
        {
            return await _productService.getProductById(id);
        }

        public async Task UpdateProduct(Product product)
        {
            if (!product.IsValid())
            {
                var message = product.
                   ValidationResult.Errors.
                   ConvertAll(x => x.ErrorMessage.ToString()).ToList();

                throw new Exception(ErrorList(message));
            }
            await _productService.UpdateProduct(product);
        }

        public async Task<Product> UpdateProductDTO(ProductDTO productDTO)
        {
            var product = imapper.Map<Product>(productDTO);
            if (!product.IsValid())
            {
                var message = product.
                   ValidationResult.Errors.
                   ConvertAll(x => x.ErrorMessage.ToString()).ToList();

                throw new Exception(ErrorList(message));
            }
            await _productService.UpdateProduct(product);
            return product;
        }
    }
}