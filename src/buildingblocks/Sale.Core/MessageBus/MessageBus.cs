using EasyNetQ;
using EasyNetQ.Internals;
using EasyNetQ.Topology;
using Polly;
using RabbitMQ.Client.Exceptions;
using Sale.Core.Messages;
using Sale.Core.Messages.IntegrationEvents;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Sale.Core.MessageBus
{
    public class MessageBus : IMessageBus
    {
        private readonly string _connectionString;
        private IBus _bus;
        public bool IsConnected => _bus?.Advanced.IsConnected ?? false;

        public MessageBus(string connectionString)
        {
            _connectionString = connectionString;
            TryConnect();
        }

        public async Task PublishAsync<T>(string exchangeName, string queueName, string routingKey, T message,
            bool mandatory = false, string exchangeType = "topic") where T : Event
        {
            TryConnect();
            _bus.Advanced.Bind(ExchangeDeclare(exchangeName, exchangeType), QueueDeclare(queueName), routingKey);
            await _bus.Advanced.PublishAsync(ExchangeDeclare(exchangeName, exchangeType), routingKey, mandatory, MessageDeclare(message));
        }

        public void SubscribeAsync<T>(string subscriptionId, Func<T, Task> onMessage) where T : class
        {
            TryConnect();
            _bus.PubSub.SubscribeAsync(subscriptionId, onMessage);
        }

        public async Task<TResponse> RequestAsync<TRequest, TResponse>(TRequest request)
            where TRequest : Event
            where TResponse : ResponseMessage
        {
            TryConnect();
            return await _bus.Rpc.RequestAsync<TRequest, TResponse>(request);
        }

        public async Task<TResponse> RequestAsync<TRequest, TResponse>(TRequest request, Action<IRequestConfiguration> configure)
            where TRequest : Event
            where TResponse : ResponseMessage
        {
            TryConnect();
            return await _bus.Rpc.RequestAsync<TRequest, TResponse>(request, configure);
        }

        public AwaitableDisposable<IDisposable> RespondAsync<TRequest, TResponse>(Func<TRequest, Task<TResponse>> responder)
            where TRequest : Event
            where TResponse : ResponseMessage
        {
            TryConnect();
            return _bus.Rpc.RespondAsync<TRequest, TResponse>(responder);
        }

        public IDisposable Respond<TRequest, TResponse>(Func<TRequest, Task<TResponse>> responder, Action<IResponderConfiguration> configure)
            where TRequest : Event
            where TResponse : ResponseMessage
        {
            TryConnect();
            return _bus.Rpc.Respond(responder, configure);
        }

        public void Dispose()
        {
            _bus.Dispose();
        }
        private IExchange ExchangeDeclare(string exchangeName, string exchangeType)
            => _bus.Advanced.ExchangeDeclare(exchangeName, exchangeType);

        private IQueue QueueDeclare(string queueName)
            => _bus.Advanced.QueueDeclare(queueName);

        private IMessage MessageDeclare<T>(T message)
            => new Message<T>(message);
        private void TryConnect()
        {
            if (IsConnected) return;

            var policy = Policy.Handle<EasyNetQException>()
                .Or<BrokerUnreachableException>()
                .WaitAndRetry(3, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)));

            policy.Execute(() =>
            {
                //bus = RabbitHutch.CreateBus(_connectionString, config => config.Register<IConventions, Conventions>());
                _bus = RabbitHutch.CreateBus(_connectionString);
            });
        }

        public TResponse Request<TRequest, TResponse>(TRequest request, Action<IRequestConfiguration> configure)
            where TRequest : Event
            where TResponse : ResponseMessage
        {
            TryConnect();
            return _bus.Rpc.Request<TRequest, TResponse>(request, configure);
        }
    }
}