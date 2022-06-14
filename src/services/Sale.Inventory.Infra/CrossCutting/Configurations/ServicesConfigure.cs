using FluentValidation.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sale.Core.Data;
using Sale.Core.Mediator;
using Sale.Inventory.Application.Balance.Command;
using Sale.Inventory.Application.Balance.Services;
using Sale.Inventory.Domain.Balance;
using Sale.Inventory.Infra.Data;
using Sale.Inventory.Infra.Data.Balance;

namespace Sale.Inventory.Infra.CrossCutting.Configurations
{
    public static class ServicesConfigure
    {
        public static void AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            //Database
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<InventoryContext>(options => options.UseSqlServer(connectionString,
                config => config.MigrationsHistoryTable("__EFMigrationsHistory", "sale")));
            //Domain
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IBalanceRepository, BalanceRepository>();
            //Application
            services.AddScoped<IMediatorHandler, MediatorHandler>();
            services.AddScoped<IBalanceService, BalanceService>();
            services.AddScoped<IRequestHandler<AddBalanceCommand, ValidationResult>, BalanceCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateBalanceCommand, ValidationResult>, BalanceCommandHandler>();
            //Infra
            services.AddScoped<InventoryContext>();
        }
    }
}