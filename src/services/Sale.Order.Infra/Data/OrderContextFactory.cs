using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Sale.Order.Infra.Data
{
    public class OrderContextFactory : IDesignTimeDbContextFactory<OrderContext>
    {
        public OrderContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<OrderContext>();
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=OrderApiDB;Trusted_Connection=True;MultipleActiveResultSets=True",
                config => config.MigrationsHistoryTable("__EFMigrationsHistory", "sale"));

            return new OrderContext(optionsBuilder.Options);
        }
    }
}