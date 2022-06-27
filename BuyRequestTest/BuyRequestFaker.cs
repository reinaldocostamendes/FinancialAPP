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

namespace BuyRequestTest
{
    public class BuyRequestFaker
    {
        public static BuyRequestDTO Generate()
        {
            Faker<ProductDTO> prodReq = new Faker<ProductDTO>()
                .RuleFor(x => x.Id, Guid.NewGuid())
                //.RuleFor(x => x.ProductId, Guid.NewGuid())
                .RuleFor(x => x.ProductDescription, x => x.Random.String(1, 256))
                .RuleFor(x => x.ProductCategory, x => x.PickRandom<ProductCategory>())
                .RuleFor(x => x.Quantity, x => x.Random.Int(1, 10))
                .RuleFor(x => x.Value, x => x.Random.Decimal(1, 100));

            BuyRequestDTO buyReq = new Faker<BuyRequestDTO>()
                //.RuleFor(x => x.Id, Guid.NewGuid())
                .RuleFor(x => x.Code, x => x.Random.Number(1, 20000))
                .RuleFor(x => x.Date, DateTime.UtcNow)
                .RuleFor(x => x.DeliveryDate, DateTime.UtcNow)
                .RuleFor(x => x.Client, Guid.NewGuid())
                .RuleFor(x => x.ClientDescription, x => x.Random.String(1, 256))
                .RuleFor(x => x.ClientEmail, x => x.Person.Email)
                .RuleFor(x => x.ClientPhone, x => x.Person.Phone)
                .RuleFor(x => x.Status, x => x.PickRandom<BuyRequestStatus>())
                .RuleFor(x => x.Discount, 0)
                .RuleFor(x => x.CostValue, 0)
                .RuleFor(x => x.TotalValue, 0)
                .RuleFor(x => x.Products, x => prodReq.GenerateBetween(1, 5));

            return buyReq;
        }

        public static BuyRequest GenerateBuyRequest()
        {
            Faker<Product> prodReq = new Faker<Product>()
                .RuleFor(x => x.Id, Guid.NewGuid())
                //.RuleFor(x => x.ProductId, Guid.NewGuid())
                .RuleFor(x => x.ProductDescription, x => x.Random.String(1, 256))
                .RuleFor(x => x.ProductCategory, x => x.PickRandom<ProductCategory>())
                .RuleFor(x => x.Quantity, x => x.Random.Int(1, 10))
                .RuleFor(x => x.Value, x => x.Random.Decimal(1, 100));

            BuyRequest buyReq = new Faker<BuyRequest>()
                //.RuleFor(x => x.Id, Guid.NewGuid())
                .RuleFor(x => x.Code, x => x.Random.Number(1, 20000))
                .RuleFor(x => x.Date, DateTime.UtcNow)
                .RuleFor(x => x.DeliveryDate, DateTime.UtcNow)
                .RuleFor(x => x.Client, Guid.NewGuid())
                .RuleFor(x => x.ClientDescription, x => x.Random.String(1, 256))
                .RuleFor(x => x.ClientEmail, x => x.Person.Email)
                .RuleFor(x => x.ClientPhone, x => x.Person.Phone)
                .RuleFor(x => x.Status, x => x.PickRandom<BuyRequestStatus>())
                .RuleFor(x => x.Discount, 0)
                .RuleFor(x => x.CostValue, 0)
                .RuleFor(x => x.TotalValue, 0)
                .RuleFor(x => x.Products, x => prodReq.GenerateBetween(1, 5));

            return buyReq;
        }
    }
}