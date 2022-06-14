using Sale.Order.Application.Order.Validations;
using System;

namespace Sale.Order.Application.Order.Command
{
    public class AddOrderCommand : Core.Messages.Command
    {
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitaryValue { get; set; }
        public string ProductDescription { get; set; }
        public AddOrderCommand(Guid productId, int quantity, decimal unitaryValue, string productDescription)
        {
            ProductId = productId;
            Quantity = quantity;
            UnitaryValue = unitaryValue;
            ProductDescription = productDescription;
        }
        public override bool IsValid()
        {
            ValidationResult = new AddOrderValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}