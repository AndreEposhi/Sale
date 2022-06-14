using Sale.Inventory.Application.Balance.Validations;
using System;

namespace Sale.Inventory.Application.Balance.Command
{
    public class UpdateBalanceCommand : Core.Messages.Command
    {
        public Guid ProductId { get; set; }
        public decimal Quantity { get; set; }
        public UpdateBalanceCommand(Guid productId, decimal quantity)
        {
            ProductId = productId;
            Quantity = quantity;
        }
        public override bool IsValid()
        {
            ValidationResult = new UpdateBalanceValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}