using FluentValidation;
using Sale.Payment.Application.Payment.Command;
using System;

namespace Sale.Payment.Application.Payment.Validations
{
    public class AuthorizePaymentValidation : AbstractValidator<AuthorizePaymentCommand>
    {
        public AuthorizePaymentValidation()
        {
            RuleFor(r => r.OrderId).NotEqual(Guid.Empty).WithMessage("Order id is invalid");
            RuleFor(r => r.Amount).GreaterThan(0).WithMessage("Amount is invalid");
        }
    }
}