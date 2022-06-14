using Sale.Core.DomainObjects;
using System;

namespace Sale.Order.Domain.Order
{
    public class OrderItem : Entity
    {
        public Guid OrderId { get; private set; }
        public Guid ProductId { get; private set; }
        public int Quantity { get; private set; }
        public decimal UnitaryValue { get; private set; }
        public Order Order { get; private set; }
        public string ProductDescription { get; private set; }

        public OrderItem()
        {

        }
        public OrderItem(Guid id, Guid orderId, Guid productId, string productDescription, int quantity, decimal unitaryValue)
        {
            Id = id;
            OrderId = orderId;
            ProductId = productId;
            Quantity = quantity;
            UnitaryValue = unitaryValue;
            ProductDescription = productDescription;
        }
    }
}