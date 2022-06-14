using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Sale.Core.DomainObjects;
using Sale.Core.MessageBus;
using Sale.Core.Messages.IntegrationEvents.Order;
using Sale.Inventory.Domain.Balance;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Sale.Inventory.Api.Services
{
    public class InventoryIntegrationHandler : BackgroundService
    {
        private readonly IMessageBus _bus;
        private readonly IServiceProvider _serviceProvider;

        public InventoryIntegrationHandler(IMessageBus bus, IServiceProvider serviceProvider)
        {
            _bus = bus;
            _serviceProvider = serviceProvider;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            SetSubscribers();
            return Task.CompletedTask;
        }

        private void SetSubscribers()
        {
            _bus.SubscribeAsync<OrderCreatedIntegrationEvent>(string.Empty, async request => await DecreaseBalance(request));

            _bus.SubscribeAsync<OrderProcessedIntegrationEvent>(string.Empty, request => ProcessedBalance(request));
        }

        private async Task DecreaseBalance(OrderCreatedIntegrationEvent message)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var balanceRepository = scope.ServiceProvider.GetRequiredService<IBalanceRepository>();

                var balance = await balanceRepository.GetBalanceByProductId(message.ProductId);
                balance.DecreaseBalance(message.Quantity);

                await balanceRepository.UpdateAsync(balance);

                if (!await balanceRepository.Commit())
                {
                    throw new DomainException($"There was an error updating the product balance: {message.ProductId}");
                }
            }
        }

        private Task ProcessedBalance(OrderProcessedIntegrationEvent message)
        {
            return Task.CompletedTask;
        }
    }
}