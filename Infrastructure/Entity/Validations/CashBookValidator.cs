using FluentValidation;

namespace Infrastructure.Entity.Validations
{
    public class CashBookValidator : AbstractValidator<CashBook>
    {
        public CashBookValidator()
        {
            RuleFor(c => c.Id).NotNull().WithMessage("Id is requirid");
            //   RuleFor(c => c.OriginId).NotNull().WithMessage("Origin Id is requirid");
            RuleFor(c => c.Origin).NotNull().WithMessage("Origin is requirid");
            RuleFor(c => c.Description).NotNull().WithMessage("Description is requirid");
            RuleFor(c => c.Type).NotNull().WithMessage("Type is requirid");
            RuleFor(c => c.Value).NotNull().WithMessage("Value is requirid");
            When(cashBook => cashBook.Type == Enums.CashBookType.RECEIVEMENT, () =>
            {
                RuleFor(cashBook => cashBook.Value).
GreaterThanOrEqualTo(0).WithMessage("CashBook type Payment must be greater than 0");
            });
            When(cashBook => cashBook.Type == Enums.CashBookType.PAYMENT, () =>
            {
                RuleFor(cashBook => cashBook.Value).
            LessThan(0).WithMessage("CashBook type Payment must be less than 0");
            });
            When(cashBook => cashBook.Origin == Enums.CashBookOrigin.PURCHASEORDER ||
            cashBook.Origin == Enums.CashBookOrigin.DOCUMENT, () =>
            {
                RuleFor(cashBook => cashBook.OriginId).NotNull().WithMessage("Origin Id is required for integration!");
            });
        }
    }
}