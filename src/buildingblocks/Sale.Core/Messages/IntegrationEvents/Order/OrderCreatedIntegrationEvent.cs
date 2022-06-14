using EasyNetQ;
using Sale.Core.Constants;
using System;

namespace Sale.Core.Messages.IntegrationEvents.Order
{
    [Queue(IntegrationEventConstant.OrderCreatedQueue, ExchangeName = IntegrationEventConstant.OrderCreatedExchange)]
    public class OrderCreatedIntegrationEvent : IntegrationEvent
    {
        public Guid ProductId { get; private set; }
        public decimal Quantity { get; private set; }
        public OrderCreatedIntegrationEvent(Guid orderId, Guid productId, decimal quantity)
        {
            AggregateRootId = orderId;
            ProductId = productId;
            Quantity = quantity;
        }
    }
}