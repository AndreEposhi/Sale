namespace Sale.Core.Constants
{
    public class IntegrationEventConstant
    {
        public const string BaseExchangeName = "Sale.Order.";
        public const string BaseQueueName = "Sale.Order.";
        public const string OrderCreatedExchange = BaseExchangeName + "OrderCreatedIntegration";
        public const string OrderCreatedQueue = BaseQueueName + "OrderCreated";
        public const string OrderCreatedRountigKey = "OrderCreated";
        public const string OrderStartedQueue = BaseQueueName + "OrderStarted";
        public const string OrderPrecessedExchangeName = BaseExchangeName + "OrderProcessedIntegration";
    }
}