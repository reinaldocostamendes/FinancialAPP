using BuyRequestData.Context;
using BuyRequestData.Repository.Interface;
using BuyRequestDomain.Entity;
using Infrastructure.Entity;
using Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuyRequestData.Repository
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        private readonly BuyRequestContext _context;

        public ProductRepository(BuyRequestContext context) : base(context)
        {
            _context = context;
        }

        public async Task AddProduct(Product Product)
        {
            await Post(Product);
        }

        public async Task DeleteProduct(Guid id)
        {
            var p = await base.GetById(id);
            if (p != null)
            {
                await Delete(p);
            }
        }

        public async Task<Product> getProductById(Guid Id)
        {
            return await _context.Products.Where(p => p.Id == Id).FirstOrDefaultAsync();
        }

        public async Task<List<Product>> GetAllProducts()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<List<Product>> GetAllProductsByBuyRequestId(Guid id)
        {
            var products = await _context.Products.AsNoTracking().Where(p => p.BuyRequestId == id).ToListAsync();
            return products;
        }

        public async Task UpdateProduct(Product product)
        {
            await Put(product);
        }
    }
}