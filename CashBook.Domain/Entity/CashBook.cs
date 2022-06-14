using CashBookDomain.Entity.Enums;
using CashBookDomain.Validations;
using Infrastructure.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashBookDomain.Entity
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