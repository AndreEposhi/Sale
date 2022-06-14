using FluentValidation.Results;
using MediatR;
using Sale.Core.Constants;
using Sale.Core.MessageBus;
using Sale.Core.Messages.IntegrationEvents;
using Sale.Core.Messages.IntegrationEvents.Order;
using Sale.Order.Domain.Order;
using System;
using System.Threading;
using System.Threading.Tasks;
using OrderEntity = Sale.Order.Domain.Order.Order;

namespace Sale.Order.Application.Order.Command
{
    public class OrderCommandHandler : Core.Messages.CommandHandler, IRequestHandler<AddOrderCommand, ValidationResult>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMessageBus _bus;

        public OrderCommandHandler(IOrderRepository orderRepository, IMessageBus bus)
        {
            _orderRepository = orderRepository;
            _bus = bus;
        }

        public async Task<ValidationResult> Handle(AddOrderCommand command, CancellationToken cancellationToken)
        {
            if (!command.IsValid())
                return command.ValidationResult;

            var code = new Random().Next();
            var order = new OrderEntity(Guid.NewGuid(), code);
            order.AddItem(new OrderItem(Guid.NewGuid(), order.Id, command.ProductId, command.ProductDescription,
                                        command.Quantity, command.UnitaryValue));
            order.CalculateAmount();

            if (!await ProcessaPagamento(order))
                return ValidationResult;

            await _orderRepository.AddAsync(order);
            var result = await Commit(_orderRepository);

            if (result.IsValid)
            {
                var message = new OrderCreatedIntegrationEvent(order.Id, command.ProductId, command.Quantity);
                await _bus.PublishAsync(IntegrationEventConstant.OrderCreatedExchange, IntegrationEventConstant.OrderCreatedQueue, 
                    IntegrationEventConstant.OrderCreatedRountigKey, message);

                var orderProcessed = new OrderProcessedIntegrationEvent(order.Id, command.ProductId);
                await _bus.PublishAsync(IntegrationEventConstant.OrderPrecessedExchangeName, IntegrationEventConstant.OrderCreatedQueue, 
                    IntegrationEventConstant.OrderCreatedRountigKey, orderProcessed);
            }

            return result;
        }

        private async Task<bool> ProcessaPagamento(OrderEntity order)
        {
            var result = await _bus.RequestAsync<OrderStartedIntegrationEvent, ResponseMessage>(
                new OrderStartedIntegrationEvent(order.Id, order.Amount), config => config.WithQueueName(IntegrationEventConstant.OrderStartedQueue));

            if (result.ValidationResult.IsValid)
                return true;

            foreach (var error in result.ValidationResult.Errors)
                AddError(error.ErrorMessage);

            return false;
        }
    }
}