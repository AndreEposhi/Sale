using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Sale.Catalog.Api;
using Sale.Catalog.Infra.Data;
using System;
using System.Linq;

namespace Sale.Catalog.IntegrationTest
{
    public class TestingWebAppFactory<T> : WebApplicationFactory<Startup> where T : class
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                var dbContext = services.SingleOrDefault(d => d.ServiceType == typeof(DbContextOptions<CatalogContext>));

                if (dbContext != null)
                    services.Remove(dbContext);

                var serviceProvider = new ServiceCollection().AddEntityFrameworkInMemoryDatabase().BuildServiceProvider();

                services.AddDbContext<CatalogContext>(options =>
                {
                    options.UseInMemoryDatabase(databaseName: "InMemoryCatalogDB");
                    options.UseInternalServiceProvider(serviceProvider);
                });
                var sp = services.BuildServiceProvider();

                using var scope = sp.CreateScope();
                using var appContext = scope.ServiceProvider.GetRequiredService<CatalogContext>();
                try
                {
                    appContext.Database.EnsureCreated();
                    InitializeDatabase(appContext);
                }
                catch (Exception)
                {
                    //Log errors
                    throw;
                }
            });
        }

        private static void InitializeDatabase(CatalogContext context)
        {
            if (!context.Products.Any())
            {
                context.Products.Add(new Domain.Product.Product(Guid.NewGuid(), "Celular Xiaomi Redmine 9", 2500));
                context.Products.Add(new Domain.Product.Product(Guid.NewGuid(), "Celular Samsung S7", 1500));
                context.Products.Add(new Domain.Product.Product(Guid.NewGuid(), "Celular Asus B8", 2000));
                context.SaveChanges();
            }
        }
    }
}