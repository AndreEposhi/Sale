using System;

namespace Sale.Core.Messages.IntegrationEvents.Order
{
    public class OrderStartedIntegrationEvent : IntegrationEvent
    {
        public Guid OrderId { get; set; }
        public decimal Amount { get; set; }
        public OrderStartedIntegrationEvent(Guid orderId, decimal amount)
        {
            OrderId = orderId;
            Amount = amount;
        }
    }
}