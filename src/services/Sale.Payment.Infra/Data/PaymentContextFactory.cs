using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Sale.Payment.Infra.Data
{
    public class PaymentContextFactory : IDesignTimeDbContextFactory<PaymentContext>
    {
        public PaymentContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<PaymentContext>();
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=PaymentApiDB;Trusted_Connection=True;MultipleActiveResultSets=True",
                config => config.MigrationsHistoryTable("__EFMigrationsHistory", "sale"));

            return new PaymentContext(optionsBuilder.Options);
        }
    }
}