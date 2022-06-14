using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Sale.Core.MessageBus;
using Sale.Inventory.Api.Services;
using Sale.Inventory.Infra.CrossCutting.Configurations;

namespace Sale.Inventory.Api
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMediatR(typeof(Startup));
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Sale.Inventory.Api", Version = "v1" });
            });
            ServicesConfigure.AddServices(services, Configuration);
            ConfigureMessageBus(services, Configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Sale.Inventory.Api v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private IServiceCollection ConfigureMessageBus(IServiceCollection services, IConfiguration configuration)
        {
            //Message Brocker
            var messageBusConnection = configuration?.GetSection("MessageQueueConnection")?["MessageBus"];
            services.AddMessageBus(messageBusConnection).AddHostedService<InventoryIntegrationHandler>();

            return services;
        }
    }
}