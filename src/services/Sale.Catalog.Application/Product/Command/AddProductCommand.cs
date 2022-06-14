using Sale.Catalog.Api.Application.Product.Validations;
using System;

namespace Sale.Catalog.Api.Application.Product.Command
{
    public class AddProductCommand : Core.Messages.Command
    {
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public AddProductCommand(string description, decimal amount)
        {
            Description = description;
            Amount = amount;
        }
        public override bool IsValid()
        {
            ValidationResult = new AddProductValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}