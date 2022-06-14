using DocumentDomain.Entity;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentDomain.Validations
{
    public class DocumentValidator : AbstractValidator<Document>
    {
        public DocumentValidator()
        {
            RuleFor(d => d.Id).NotNull().WithMessage("Id is requirid");
            RuleFor(d => d.Number).NotNull().WithMessage("Number is requirid");
            RuleFor(d => d.Date).NotNull().WithMessage("Date is requirid");
            RuleFor(d => d.DocumentType).NotNull().WithMessage("Document type is requirid");
            RuleFor(d => d.Operation).NotNull().WithMessage("Operation is requirid");
            RuleFor(d => d.Payed).NotNull().WithMessage("Payed info is requirid");
            RuleFor(d => d.PaymentDate).NotNull().WithMessage("PaymentDate is requirid");
            RuleFor(d => d.Description).NotNull().WithMessage("Description is requirid");
            RuleFor(d => d.Total).NotNull().WithMessage("Total is requirid");
        }
    }
}