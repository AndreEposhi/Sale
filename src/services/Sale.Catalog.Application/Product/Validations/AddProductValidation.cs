using FluentValidation;
using Sale.Catalog.Api.Application.Product.Command;
using System;

namespace Sale.Catalog.Api.Application.Product.Validations
{
    public class AddProductValidation : AbstractValidator<AddProductCommand>
    {
        public AddProductValidation()
        {
            RuleFor(v => v.Description).NotEmpty().WithMessage("Product description is invalid");
            RuleFor(v => v.Amount).GreaterThan(0).WithMessage("Product amount is invalid");
        }
    }
}