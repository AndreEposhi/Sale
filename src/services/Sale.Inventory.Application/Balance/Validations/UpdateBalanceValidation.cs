using FluentValidation;
using Sale.Inventory.Application.Balance.Command;
using System;

namespace Sale.Inventory.Application.Balance.Validations
{
    public class UpdateBalanceValidation : AbstractValidator<UpdateBalanceCommand>
    {
        public UpdateBalanceValidation()
        {
            RuleFor(r => r.ProductId)
                .NotEqual(Guid.Empty)
                .WithMessage("Product id is invalid");
            RuleFor(r => r.Quantity)
                .GreaterThan(0)
                .WithMessage("Quantity is invalid");
        }
    }
}