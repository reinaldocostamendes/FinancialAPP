using BuyRequestDomain.Entity.Enums;
using BuyRequestDomain.Validations;
using Infrastructure.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuyRequestDomain.Entity
{
    public class BuyRequest : EntityBase<BuyRequest>
    {
        public long Code { get; set; }
        public DateTimeOffset Date { get; set; }
        public DateTimeOffset DeliveryDate { get; set; }
        public List<Product> Products { get; set; }
        public Guid Client { get; set; }

        public string ClientDescription { get; set; }

        public string ClientEmail { get; set; }
        public string ClientPhone { get; set; }
        public BuyRequestStatus Status { get; set; }
        public string Street { get; set; }
        public string StreetNumber { get; set; }
        public string Sector { get; set; }
        public string Complement { get; set; }
        public string City { get; set; }
        public string State { get; set; }

        public decimal ProductsValues { get; set; }

        public decimal Discount { get; set; }

        [Column("CostValue")]
        public decimal CostValue { get; set; }

        [Column("TotalValue")]
        public decimal TotalValue { get; set; }

        public override bool IsValid()
        {
            if (ValidationResult == null)
            {
                var validator = new BuyRequestValidator();
                ValidationResult = validator.Validate(this);
            }
            return ValidationResult?.IsValid != false;
        }
    }
}