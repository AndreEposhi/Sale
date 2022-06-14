using FluentValidation.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sale.Catalog.Api.Application.Product.Command;
using Sale.Catalog.Application.Product.Query;
using Sale.Catalog.Application.Product.Services;
using Sale.Catalog.Domain.Product;
using Sale.Catalog.Infra.Data;
using Sale.Catalog.Infra.Data.Product;
using Sale.Core.Data;
using Sale.Core.Mediator;

namespace Sale.Catalog.Infra.CrossCutting.Configurations
{
    public static class ServicesConfigure
    {
        public static void AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            //Database
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<CatalogContext>(options => options.UseSqlServer(connectionString,
                config => config.MigrationsHistoryTable("__EFMigrationsHistory", "sale")));

            //services.AddDbContext<CatalogContext>(options => options.UseInMemoryDatabase("InMemoryDb"));

            //Domain
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IProductRepository, ProductRepository>();
            //Application
            services.AddScoped<IMediatorHandler, MediatorHandler>();
            services.AddScoped<IRequestHandler<AddProductCommand, ValidationResult>, ProductCommandHandler>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IProductQuery, ProductQuery>();
            //Infra
            services.AddScoped<CatalogContext>();
        }
    }
}