using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Sale.Catalog.Infra.Data.Product
{
    public class ProductMapping : IEntityTypeConfiguration<Domain.Product.Product>
    {
        public void Configure(EntityTypeBuilder<Domain.Product.Product> builder)
        {
            builder.ToTable("Product", "sale");
            builder.HasKey(k => k.Id);
            builder.Property(p => p.CreateAt)
                .HasColumnType("datetime")
                .IsRequired();
            builder.Property(p => p.Description)
                .HasColumnType("varchar(200)")
                .IsRequired();
            builder.Property(p => p.Amount)
                .HasColumnType("decimal(10,3)")
                .IsRequired();
        }
    }
}