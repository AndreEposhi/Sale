using EasyNetQ;
using Sale.Core.Constants;
using System;

namespace Sale.Core.Messages.IntegrationEvents.Order
{
    [Queue(IntegrationEventConstant.OrderCreatedQueue, ExchangeName = IntegrationEventConstant.OrderPrecessedExchangeName)]
    public class OrderProcessedIntegrationEvent : IntegrationEvent
    {
        public Guid ProductId { get; set; }
        public OrderProcessedIntegrationEvent(Guid orderId, Guid productId)
        {
            AggregateRootId = orderId;
            ProductId = productId;
        }
    }
}