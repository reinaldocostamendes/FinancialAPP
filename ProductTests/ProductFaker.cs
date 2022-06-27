using Bogus;
using BuyRequestDomain.DTO;
using BuyRequestDomain.Entity;
using BuyRequestDomain.Entity.Enums;
using Infrastructure.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductTests
{
    public class ProductFaker
    {
        public static Product Generate()
        {
            Faker<Product> prodReq = new Faker<Product>()
                .RuleFor(x => x.Id, Guid.NewGuid())
                //.RuleFor(x => x.ProductId, Guid.NewGuid())
                .RuleFor(x => x.ProductDescription, x => x.Random.String(1, 256))
                .RuleFor(x => x.ProductCategory, x => x.PickRandom<ProductCategory>())
                .RuleFor(x => x.Quantity, x => x.Random.Int(1, 10))
                .RuleFor(x => x.Value, x => x.Random.Decimal(1, 100));

            return prodReq;
        }

        public static ProductDTO GenerateDTO()
        {
            Faker<ProductDTO> prodReq = new Faker<ProductDTO>()
                .RuleFor(x => x.Id, Guid.NewGuid())
                //.RuleFor(x => x.ProductId, Guid.NewGuid())
                .RuleFor(x => x.ProductDescription, x => x.Random.String(1, 256))
                .RuleFor(x => x.ProductCategory, x => x.PickRandom<ProductCategory>())
                .RuleFor(x => x.Quantity, x => x.Random.Int(1, 10))
                .RuleFor(x => x.Value, x => x.Random.Decimal(1, 100));

            return prodReq;
        }
    }
}