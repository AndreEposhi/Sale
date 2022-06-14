using EasyNetQ;
using EasyNetQ.Internals;
using Sale.Core.Messages;
using Sale.Core.Messages.IntegrationEvents;
using System;
using System.Threading.Tasks;

namespace Sale.Core.MessageBus
{
    public interface IMessageBus : IDisposable
    {
        Task PublishAsync<T>(string exchangeName, string queueName, string routingKey, T message,
            bool mandatory = false, string exchangeType = "topic") where T : Event;
        void SubscribeAsync<T>(string subscriptionId, Func<T, Task> onMessage) where T : class;

        Task<TResponse> RequestAsync<TRequest, TResponse>(TRequest request)
            where TRequest : Event
            where TResponse : ResponseMessage;

        AwaitableDisposable<IDisposable> RespondAsync<TRequest, TResponse>(Func<TRequest, Task<TResponse>> responder)
            where TRequest : Event
            where TResponse : ResponseMessage;

        Task<TResponse> RequestAsync<TRequest, TResponse>(TRequest request, Action<IRequestConfiguration> configure)
            where TRequest : Event
            where TResponse : ResponseMessage;

        IDisposable Respond<TRequest, TResponse>(Func<TRequest, Task<TResponse>> responder, Action<IResponderConfiguration> configure)
            where TRequest : Event
            where TResponse : ResponseMessage;

        TResponse Request<TRequest, TResponse>(TRequest request, Action<IRequestConfiguration> configure)
            where TRequest : Event
            where TResponse : ResponseMessage;
    }
}