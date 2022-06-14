using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Sale.Catalog.Infra.Data
{
    public class CatalogContextFactory : IDesignTimeDbContextFactory<CatalogContext>
    {
        public CatalogContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<CatalogContext>();
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=CatalogApiDB;Trusted_Connection=True;MultipleActiveResultSets=True", 
                config => config.MigrationsHistoryTable("__EFMigrationsHistory", "sale"));

            return new CatalogContext(optionsBuilder.Options);
        }
    }
}