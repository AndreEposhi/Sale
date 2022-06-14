using FluentValidation.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sale.Core.Data;
using Sale.Core.Mediator;
using Sale.Core.MessageBus;
using Sale.Order.Application.Order.Command;
using Sale.Order.Application.Order.Services;
using Sale.Order.Domain.Order;
using Sale.Order.Infra.Data;
using Sale.Order.Infra.Data.Order;

namespace Sale.Order.Infra.CrossCutting.Configurations
{
    public static class ServicesConfigure
    {
        public static void AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            //Database
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<OrderContext>(options => options.UseSqlServer(connectionString,
                config => config.MigrationsHistoryTable("__EFMigrationsHistory", "sale")));
            //Domain
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IOrderRepository, OrderRepository>();
            //Application
            services.AddScoped<IMediatorHandler, MediatorHandler>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IRequestHandler<AddOrderCommand, ValidationResult>, OrderCommandHandler>();
            //Infra
            services.AddScoped<OrderContext>();
            //Message Brocker
            var messageBusConnection = configuration?.GetSection("MessageQueueConnection")?["MessageBus"];
            services.AddMessageBus(messageBusConnection);
        }
    }
}