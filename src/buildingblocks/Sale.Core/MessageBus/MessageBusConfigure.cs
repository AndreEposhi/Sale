using Microsoft.Extensions.DependencyInjection;
using System;

namespace Sale.Core.MessageBus
{
    public static class MessageBusConfigure
    {
        public static IServiceCollection AddMessageBus(this IServiceCollection services, string connectionString)
        {
            if (string.IsNullOrWhiteSpace(connectionString))
                throw new ArgumentNullException($"Parameter {nameof(connectionString)} is invalid");

            services.AddSingleton<IMessageBus>(new MessageBus(connectionString));

            return services;
        }
    }
}