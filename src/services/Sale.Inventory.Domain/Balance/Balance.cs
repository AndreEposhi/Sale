using Sale.Core.DomainObjects;
using System;

namespace Sale.Inventory.Domain.Balance
{
    public class Balance : Entity, IAggregateRoot
    {
        public Guid ProductId { get; private set; }
        public decimal Quantity { get; private set; }

        public Balance() { }
        public Balance(Guid id, Guid productId, decimal quantity)
        {
            Id = id;
            ProductId = productId;
            Quantity = quantity;
        }

        public void UpdateQuantity(decimal quantity)
            => Quantity += quantity;

        public void DecreaseBalance(decimal quantity)
            => Quantity -= quantity;
    }
}