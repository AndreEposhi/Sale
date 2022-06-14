using Microsoft.EntityFrameworkCore;
using BalanceEntity = Sale.Inventory.Domain.Balance.Balance;

namespace Sale.Inventory.Infra.Data
{
    public class InventoryContext : DbContext
    {
        public DbSet<BalanceEntity> Balances { get; set; }
        public InventoryContext(DbContextOptions<InventoryContext> options) : base(options)
        { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(InventoryContext).Assembly);
        }
    }
}