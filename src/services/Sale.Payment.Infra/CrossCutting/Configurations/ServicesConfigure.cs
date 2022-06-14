using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sale.Core.Data;
using Sale.Core.Mediator;
using Sale.Core.MessageBus;
using Sale.Payment.Domain.Payment;
using Sale.Payment.Infra.Data;
using Sale.Payment.Infra.Data.Payment;

namespace Sale.Payment.Infra.CrossCutting.Configurations
{
    public static class ServicesConfigure
    {
        public static void AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            //Database
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<PaymentContext>(options => options.UseSqlServer(connectionString,
                config => config.MigrationsHistoryTable("__EFMigrationsHistory", "sale")));
            //Domain
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IPaymentRepository, PaymentRepository>();
            //Application
            services.AddScoped<IMediatorHandler, MediatorHandler>();
            //services.AddScoped<IOrderService, OrderService>();
            //services.AddScoped<IRequestHandler<AddOrderCommand, ValidationResult>, OrderCommandHandler>();
            //Infra
            services.AddScoped<PaymentContext>();
            //Message Brocker
            var messageBusConnection = configuration?.GetSection("MessageQueueConnection")?["MessageBus"];
            services.AddMessageBus(messageBusConnection);
        }
    }
}