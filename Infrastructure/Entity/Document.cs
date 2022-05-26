﻿using Infrastructure.Entity.Enums;
using Infrastructure.Entity.Validations;
using System;

namespace Infrastructure.Entity
{
    public class Document : EntityBase<Document>
    {
        public string Number { get; set; }
        public DateTime Date { get; set; }
        public DocumentType DocumentType { get; set; }
        public Operation Operation { get; set; }
        public bool Payed { get; set; }
        public DateTime PaymentDate { get; set; }
        public string Description { get; set; }
        public decimal Total { get; set; }

        public string Observation { get; set; }

        public override bool IsValid()
        {
            if (ValidationResult == null)
            {
                var validator = new DocumentValidator();
                ValidationResult = validator.Validate(this);
            }
            return ValidationResult?.IsValid != false;
        }
    }
}