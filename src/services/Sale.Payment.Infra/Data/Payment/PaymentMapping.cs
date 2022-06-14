using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PaymentEntity = Sale.Payment.Domain.Payment.Payment;

namespace Sale.Payment.Infra.Data.Payment
{
    public class PaymentMapping : IEntityTypeConfiguration<PaymentEntity>
    {
        public void Configure(EntityTypeBuilder<PaymentEntity> builder)
        {
            builder.ToTable("Payment", "sale");
            builder.HasKey(k => k.Id);
            builder.Property(p => p.CreateAt)
                .HasColumnType("datetime")
                .IsRequired();
            builder.Property(p => p.OrderId)
                .HasColumnType("uniqueidentifier")
                .IsRequired();
            builder.Property(p => p.Amount)
                .HasColumnType("decimal(10,3)")
                .IsRequired();
            builder.Property(p => p.Status)
                .HasConversion<int>()
                .IsRequired();
        }
    }
}