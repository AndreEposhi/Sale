using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using BalanceEntity = Sale.Inventory.Domain.Balance.Balance;

namespace Sale.Inventory.Infra.Data.Balance
{
    public class BalanceMapping : IEntityTypeConfiguration<BalanceEntity>
    {
        public void Configure(EntityTypeBuilder<BalanceEntity> builder)
        {
            builder.ToTable("Balance", "sale");
            builder.HasKey(k => k.Id);
            builder.Property(p => p.CreateAt)
                .HasColumnType("datetime")
                .IsRequired();
            builder.Property(p => p.ProductId)
                .HasColumnType("uniqueidentifier")
                .IsRequired();
            builder.Property(p => p.Quantity)
                .HasColumnType("decimal(10,3)")
                .IsRequired();
        }
    }
}