using BuyRequestDomain.DTO;
using Infrastructure.Entity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BuyRequestData.Repository.Interface
{
    public interface IProductRepository
    {
        Task AddProduct(Product Product);

        Task<List<Product>> GetAllProductsByBuyRequestId(Guid orderId);

        Task DeleteProduct(Guid id);

        Task UpdateProduct(Product product);

        Task<Product> getProductById(Guid Id);

        Task<List<Product>> GetAllProducts();
    }
}