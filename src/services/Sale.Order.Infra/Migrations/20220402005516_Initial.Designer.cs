// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Sale.Order.Infra.Data;

namespace Sale.Order.Infra.Migrations
{
    [DbContext(typeof(OrderContext))]
    [Migration("20220402005516_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.15")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Sale.Order.Domain.Order.Order", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(10,3)");

                    b.Property<int>("Code")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.ToTable("Order", "sale");
                });

            modelBuilder.Entity("Sale.Order.Domain.Order.OrderItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("datetime");

                    b.Property<Guid>("OrderId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ProductDescription")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Quantity")
                        .HasColumnType("decimal(10,3)");

                    b.Property<decimal>("UnitaryValue")
                        .HasColumnType("decimal(10,3)");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderItem", "sale");
                });

            modelBuilder.Entity("Sale.Order.Domain.Order.OrderItem", b =>
                {
                    b.HasOne("Sale.Order.Domain.Order.Order", "Order")
                        .WithMany("Items")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");
                });

            modelBuilder.Entity("Sale.Order.Domain.Order.Order", b =>
                {
                    b.Navigation("Items");
                });
#pragma warning restore 612, 618
        }
    }
}
