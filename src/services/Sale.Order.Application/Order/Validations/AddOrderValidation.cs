using FluentValidation;
using Sale.Order.Application.Order.Command;
using System;

namespace Sale.Order.Application.Order.Validations
{
    public class AddOrderValidation : AbstractValidator<AddOrderCommand>
    {
        public AddOrderValidation()
        {
            RuleFor(r => r.ProductId).NotEqual(Guid.Empty).WithMessage("Product id is invalid");
            RuleFor(r => r.Quantity).GreaterThan(0).WithMessage("Quantity is invalid");
            RuleFor(r => r.UnitaryValue).GreaterThan(0).WithMessage("Unitary value is invalid");
            RuleFor(r => r.ProductDescription).NotEmpty().WithMessage("Product description is invalid");
        }
    }
}