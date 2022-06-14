using Microsoft.EntityFrameworkCore;
using OrderEntity = Sale.Order.Domain.Order.Order;
using OrderItemEntity = Sale.Order.Domain.Order.OrderItem;

namespace Sale.Order.Infra.Data
{
    public class OrderContext : DbContext
    {
        public DbSet<OrderEntity> Orders { get; set; }
        public DbSet<OrderItemEntity> OrdemItems { get; set; }
        public OrderContext(DbContextOptions<OrderContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(OrderContext).Assembly);
        }
    }
}