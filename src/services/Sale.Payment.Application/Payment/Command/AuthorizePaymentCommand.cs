using Sale.Payment.Application.Payment.Validations;
using System;

namespace Sale.Payment.Application.Payment.Command
{
    public class AuthorizePaymentCommand : Core.Messages.Command
    {
        public Guid OrderId { get; set; }
        public decimal Amount { get; set; }
        public AuthorizePaymentCommand(Guid orderId, decimal amount)
        {
            OrderId = orderId;
            Amount = amount;
        }
        public override bool IsValid()
        {
            ValidationResult = new AuthorizePaymentValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}