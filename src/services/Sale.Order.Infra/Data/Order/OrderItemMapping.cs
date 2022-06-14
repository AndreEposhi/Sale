using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrderItemEntity = Sale.Order.Domain.Order.OrderItem;

namespace Sale.Order.Infra.Data.Order
{
    public class OrderItemMapping : IEntityTypeConfiguration<OrderItemEntity>
    {
        public void Configure(EntityTypeBuilder<OrderItemEntity> builder)
        {
            builder.ToTable("OrderItem", "sale");
            builder.HasKey(k => k.Id);
            builder.Property(p => p.CreateAt).HasColumnType("datetime").IsRequired();
            builder.Property(p => p.Quantity).HasColumnType("decimal(10,3)").IsRequired();
            builder.Property(p => p.UnitaryValue).HasColumnType("decimal(10,3)").IsRequired();
            builder.Property(p => p.ProductId).HasColumnType("uniqueidentifier").IsRequired();
            builder.Property(p => p.ProductDescription).HasColumnType("varchar(200)").IsRequired();

            builder.HasOne(i => i.Order)
                .WithMany(i => i.Items)
                .HasForeignKey(i => i.OrderId);
        }
    }
}