using FluentValidation;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Entity.Validations
{
    public class BuyRequestValidator : AbstractValidator<BuyRequest>
    {
        public BuyRequestValidator()
        {
            RuleFor(o => o.Id).NotNull().WithMessage("Id is requirid");
            RuleFor(o => o.Code).NotNull().WithMessage("Code is requirid");
            RuleFor(o => o.Date).NotNull().WithMessage("Date is requirid");
            RuleFor(o => o.DeliveryDate).NotNull().WithMessage("Delivery Date is requirid");
            RuleFor(o => o.Client).NotNull().WithMessage("Custumer is requirid");
            RuleFor(o => o.ClientDescription).NotNull().WithMessage("Custumer Description is requirid");
            RuleFor(o => o.ClientEmail).NotNull().WithMessage("Custumer emáil  is requirid").EmailAddress().WithMessage("Email format not Valid");
            RuleFor(o => o.ClientPhone).NotNull().WithMessage("custumer phone is requirid");
            RuleFor(o => o.Status).NotNull().WithMessage("Status is requirid");
            RuleFor(o => o.ProductsValues).NotNull().WithMessage("Products Values is requirid");
            RuleFor(o => o.CostValue).NotNull().WithMessage("Cost Value is requirid");
            RuleFor(o => o.TotalValue).NotNull().WithMessage("Total Value is requirid");
            RuleFor(o => ContainDiferentsCategory(o.Products.ToList())).NotNull().WithMessage("Not possible to post diferent category!");
            RuleFor(o => ContainEqualProduts(o.Products.ToList())).NotNull().WithMessage("Not possible to post equals products!");
        }

        private object ContainDiferentsCategory(List<Product> products)
        {
            if (products == null || products.Count > 1)
            {
                var product = products[0];
                for (int i = 1; i < products.Count; i++)
                {
                    var p = products[i];
                    if ((p != null && product != null) && (p.ProductCategory != product.ProductCategory)) { return null; }
                    else
                    {
                        product = products[i];
                    }
                }
            }

            return false;
        }

        private object ContainEqualProduts(List<Product> products)
        {
            if (products == null || products.Count > 1)
            {
                var product = products[0];
                for (int i = 1; i < products.Count; i++)
                {
                    var p = products[i];
                    if ((p != null && product != null) && (p.ProductCategory == product.ProductCategory && p.ProductDescription == product.ProductDescription
                        )) { return null; }
                    else
                    {
                        product = products[i];
                    }
                }
            }

            return false;
        }
    }
}