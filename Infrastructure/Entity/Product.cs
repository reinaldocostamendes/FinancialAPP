using Infrastructure.Entity.Enums;
using Infrastructure.Entity.Validations;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Infrastructure.Entity
{
    public class Product : EntityBase<Product>
    {
        [ForeignKey("BuyRequest")]
        public Guid BuyRequestId { get; set; }

        public Guid ProductId { get; set; }
        public string ProductDescription { get; set; }
        public ProductCategory ProductCategory { get; set; }

        [Column("Quantity")]
        public decimal Quantity { get; set; }

        [Column("Value")]
        public decimal Value { get; set; }

        [Column("Total")]
        public decimal Total { get; set; }

        [JsonIgnore]
        public virtual BuyRequest BuyRequest { get; set; }

        public override bool IsValid()
        {
            if (ValidationResult == null)
            {
                var validator = new ProductValidator();
                ValidationResult = validator.Validate(this);
            }
            return ValidationResult?.IsValid != false;
        }
    }
}