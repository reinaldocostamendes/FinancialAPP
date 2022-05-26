using Infrastructure.Entity.Enums;
using System;

namespace BuyRequestDomain.DTO
{
    public class ProductDTO
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public string ProductDescription { get; set; }
        public ProductCategory ProductCategory { get; set; }
        public decimal Quantity { get; set; }
        public decimal Value { get; set; }
        public decimal Total => (Value * Quantity);
    }
}