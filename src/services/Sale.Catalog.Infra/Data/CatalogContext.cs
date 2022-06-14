using Microsoft.EntityFrameworkCore;

namespace Sale.Catalog.Infra.Data
{
    public class CatalogContext : DbContext
    {
        public DbSet<Domain.Product.Product> Products { get; set; }
        public CatalogContext(DbContextOptions<CatalogContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CatalogContext).Assembly);
        }
    }
}