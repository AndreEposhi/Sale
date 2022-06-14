using Sale.Inventory.Application.Balance.Validations;
using System;

namespace Sale.Inventory.Application.Balance.Command
{
    public class AddBalanceCommand : Core.Messages.Command
    {
        public Guid ProductId { get; set; }
        public decimal Quantity { get; set; }

        public AddBalanceCommand(Guid productId, decimal quantity)
        {
            ProductId = productId;
            Quantity = quantity;
        }
        public override bool IsValid()
        {
            ValidationResult = new AddBalanceValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}