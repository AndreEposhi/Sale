using Microsoft.EntityFrameworkCore;
using System.Reflection;
using PaymentEntity = Sale.Payment.Domain.Payment.Payment;

namespace Sale.Payment.Infra.Data
{
    public class PaymentContext : DbContext
    {
        public DbSet<PaymentEntity> Payments { get; set; }
        public PaymentContext(DbContextOptions<PaymentContext> options) : base(options)
        { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}