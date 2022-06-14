using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrderEntity = Sale.Order.Domain.Order.Order;

namespace Sale.Order.Infra.Data.Order
{
    public class OrderMapping : IEntityTypeConfiguration<OrderEntity>
    {
        public void Configure(EntityTypeBuilder<OrderEntity> builder)
        {
            builder.ToTable("Order", "sale");
            builder.HasKey(k => k.Id);
            builder.Property(p => p.Code)
                .HasColumnType("int")
                .IsRequired();
            builder.Property(p => p.CreateAt)
                .HasColumnType("datetime")
                .IsRequired();
            builder.Property(p => p.Amount)
                .HasColumnType("decimal(10,3)")
                .IsRequired();
        }
    }
}