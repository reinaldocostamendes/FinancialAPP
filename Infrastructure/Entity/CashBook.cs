using Infrastructure.Entity.Enums;
using Infrastructure.Entity.Validations;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Entity
{
    public class CashBook : EntityBase<CashBook>
    {
        public Guid Id { get; set; }
        public CashBookOrigin? Origin { get; set; }

        public Guid? OriginId { get; set; }

        public string Description { get; set; }
        public CashBookType Type { get; set; }

        [Column("Value")]
        public decimal Value { get; set; }

        public override bool IsValid()
        {
            if (ValidationResult == null)
            {
                var validator = new CashBookValidator();
                ValidationResult = validator.Validate(this);
            }
            return ValidationResult?.IsValid != false;
        }
    }
}