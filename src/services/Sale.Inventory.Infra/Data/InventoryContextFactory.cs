using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Sale.Inventory.Infra.Data
{
    public class InventoryContextFactory : IDesignTimeDbContextFactory<InventoryContext>
    {
        public InventoryContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<InventoryContext>();
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=InventoryApiDB;Trusted_Connection=True;MultipleActiveResultSets=True",
                config => config.MigrationsHistoryTable("__EFMigrationsHistory", "sale"));

            return new InventoryContext(optionsBuilder.Options);
        }
    }
}