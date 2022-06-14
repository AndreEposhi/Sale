using FluentValidation.Results;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Sale.Core.Constants;
using Sale.Core.MessageBus;
using Sale.Core.Messages.IntegrationEvents;
using Sale.Core.Messages.IntegrationEvents.Order;
using Sale.Payment.Domain.Payment;
using System;
using System.Threading;
using System.Threading.Tasks;
using PaymentEntity = Sale.Payment.Domain.Payment.Payment;

namespace Sale.Payment.Api.Services
{
    public class PaymentIntegrationHandler : BackgroundService
    {
        private readonly IMessageBus _bus;
        private readonly IServiceProvider _serviceProvider;

        public PaymentIntegrationHandler(IMessageBus bus, IServiceProvider serviceProvider)
        {
            _bus = bus;
            _serviceProvider = serviceProvider;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            SetResponder();
            return Task.CompletedTask;
        }

        private void SetResponder()
        {
            _bus.Respond<OrderStartedIntegrationEvent, ResponseMessage>(async request =>
            await AuthorizePayment(request), config => config.WithQueueName(IntegrationEventConstant.OrderStartedQueue));
        }

        private async Task<ResponseMessage> AuthorizePayment(OrderStartedIntegrationEvent order)
        {
            using var scope = _serviceProvider.CreateScope();
            var paymentRepository = scope.ServiceProvider.GetRequiredService<IPaymentRepository>();
            var payment = new PaymentEntity(Guid.NewGuid(), order.OrderId, order.Amount);
            await paymentRepository.AddAsync(payment);
            var validationResult = new ValidationResult();
            var responseMessage = new ResponseMessage(new ValidationResult());

            if (!await paymentRepository.Commit())
            {
                validationResult.Errors.Add(
                    new ValidationFailure(string.Empty, "An error occurred while persisting to the database"));
                responseMessage.ValidationResult = validationResult;
                return responseMessage;
            }

            return responseMessage;
        }
    }
}