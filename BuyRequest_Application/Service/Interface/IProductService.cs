using Infrastructure.Entity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BuyRequest_Application.Service.Interface
{
    public interface IProductService
    {
        Task AddProduct(Product Product);

        Task<List<Product>> GetAllProducts();

        Task<List<Product>> GetAllProductsByBuyRequestId(Guid orderId);

        Task DeleteProduct(Guid id);

        Task UpdateProduct(Product product);
    }
}